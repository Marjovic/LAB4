Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class Course
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=;"

    ' Store current course ID for prerequisites
    Private currentPrereqCourseId As Integer = 0

    Private Sub Course_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Course Management - MGOD LMS"

        ' Initialize dropdowns
        InitializeDepartmentDropdown()
        InitializeYearLevelDropdown()

        ' Add input validation event handlers
        AddHandler txtCourseCode.KeyPress, AddressOf ValidateCourseCodeInput
        AddHandler txtCourseName.KeyPress, AddressOf ValidateCourseNameInput
        AddHandler txtLabUnits.KeyPress, AddressOf ValidateNumericInput
        AddHandler txtLectureUnits.KeyPress, AddressOf ValidateNumericInput

        ' Add validation for update fields
        AddHandler txtUpdateCourseCode.KeyPress, AddressOf ValidateCourseCodeInput
        AddHandler txtUpdateCourseName.KeyPress, AddressOf ValidateCourseNameInput
        AddHandler txtUpdateLabUnits.KeyPress, AddressOf ValidateNumericInput
        AddHandler txtUpdateLectureUnits.KeyPress, AddressOf ValidateNumericInput

        ' Set default values
        txtLectureUnits.Text = "3"
        txtLabUnits.Text = "0"
        txtUpdateLectureUnits.Text = "3"
        txtUpdateLabUnits.Text = "0"

        ' Load course data
        LoadCoursesData()
        LoadCourseUpdateDropdown()

        ' Show View Courses panel by default
        ShowPanel(pnlViewCourses)
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlAddCourse.Visible = False
        pnlViewCourses.Visible = False
        pnlUpdateDeleteCourse.Visible = False
        pnlManagePrerequisites.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnAddCourse.BackColor = Color.FromArgb(35, 35, 38)
        btnViewCourses.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteCourse.BackColor = Color.FromArgb(35, 35, 38)
        btnManagePrerequisites.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnAddCourse_Click(sender As Object, e As EventArgs) Handles btnAddCourse.Click
        ShowPanel(pnlAddCourse)
        SetActiveButton(btnAddCourse)
        ClearAddCourseForm()
    End Sub

    Private Sub btnViewCourses_Click(sender As Object, e As EventArgs) Handles btnViewCourses.Click
        ShowPanel(pnlViewCourses)
        SetActiveButton(btnViewCourses)
        LoadCoursesData()
    End Sub

    Private Sub btnUpdateDeleteCourse_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteCourse.Click
        ShowPanel(pnlUpdateDeleteCourse)
        SetActiveButton(btnUpdateDeleteCourse)
        LoadCourseUpdateDropdown()
        ClearUpdateForm()
    End Sub

    Private Sub btnManagePrerequisites_Click(sender As Object, e As EventArgs) Handles btnManagePrerequisites.Click
        ShowPanel(pnlManagePrerequisites)
        SetActiveButton(btnManagePrerequisites)
        LoadCoursePrereqDropdown()
        ClearPrerequisitesForm()
    End Sub

    Private Sub btnCourseOffer_Click(sender As Object, e As EventArgs) Handles btnCourseOffer.Click
        ' Open Course Offering form
        Dim courseOfferingForm As New CourseOffering()
        courseOfferingForm.Show()
        ' Optionally hide or close the current form
        ' Me.Hide() ' Use this if you want to hide the Course form
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= INITIALIZATION METHODS =============

    Private Sub InitializeDepartmentDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT department_id, CONCAT(department_code, ' - ', department_name) as display_name FROM Departments ORDER BY department_name"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim departmentTable As New DataTable()
                    adapter.Fill(departmentTable)

                    ' Bind to Add Course dropdown
                    cmbDepartment.DataSource = departmentTable.Copy()
                    cmbDepartment.DisplayMember = "display_name"
                    cmbDepartment.ValueMember = "department_id"

                    ' Bind to Update Course dropdown
                    cmbUpdateDepartment.DataSource = departmentTable.Copy()
                    cmbUpdateDepartment.DisplayMember = "display_name"
                    cmbUpdateDepartment.ValueMember = "department_id"

                    ' Set to first item if available
                    If cmbDepartment.Items.Count > 0 Then
                        cmbDepartment.SelectedIndex = 0
                    End If
                    If cmbUpdateDepartment.Items.Count > 0 Then
                        cmbUpdateDepartment.SelectedIndex = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeYearLevelDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT year_level_id, year_level_name FROM Year_Levels ORDER BY year_number"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim yearLevelTable As New DataTable()
                    adapter.Fill(yearLevelTable)

                    ' Bind to Add Course dropdown
                    cmbYearLevel.DataSource = yearLevelTable.Copy()
                    cmbYearLevel.DisplayMember = "year_level_name"
                    cmbYearLevel.ValueMember = "year_level_id"

                    ' Bind to Update Course dropdown
                    cmbUpdateYearLevel.DataSource = yearLevelTable.Copy()
                    cmbUpdateYearLevel.DisplayMember = "year_level_name"
                    cmbUpdateYearLevel.ValueMember = "year_level_id"

                    ' Set to first item if available
                    If cmbYearLevel.Items.Count > 0 Then
                        cmbYearLevel.SelectedIndex = 0
                    End If
                    If cmbUpdateYearLevel.Items.Count > 0 Then
                        cmbUpdateYearLevel.SelectedIndex = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading year levels: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============= INPUT VALIDATION METHODS =============

    Private Sub ValidateCourseCodeInput(sender As Object, e As KeyPressEventArgs)
        ' Allow only uppercase letters, numbers, hyphens, and backspace
        If Not (Char.IsLetterOrDigit(e.KeyChar) OrElse e.KeyChar = "-"c OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            MessageBox.Show("Course code can only contain letters, numbers, and hyphens.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ValidateCourseNameInput(sender As Object, e As KeyPressEventArgs)
        ' Allow letters, numbers, spaces, comma, period, colon, hyphen ONLY - NO PARENTHESES
        If Not (Char.IsLetterOrDigit(e.KeyChar) OrElse
            e.KeyChar = " "c OrElse
            e.KeyChar = "-"c OrElse
            e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            MessageBox.Show("Course name can only contain letters, numbers, spaces, and hyphen (-)." & vbCrLf &
                       "Other symbols are not allowed.",
                       "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ValidateNumericInput(sender As Object, e As KeyPressEventArgs)
        ' Allow only numbers and backspace
        If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function IsValidCourseInput() As Boolean
        ' Validate course code
        If String.IsNullOrWhiteSpace(txtCourseCode.Text) Then
            MessageBox.Show("Course code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCourseCode.Focus()
            Return False
        End If

        If Not Regex.IsMatch(txtCourseCode.Text.Trim(), "^[A-Z0-9-]+$") Then
            MessageBox.Show("Course code must contain only uppercase letters, numbers, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCourseCode.Focus()
            Return False
        End If

        ' Validate course name
        If String.IsNullOrWhiteSpace(txtCourseName.Text) Then
            MessageBox.Show("Course name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCourseName.Focus()
            Return False
        End If

        ' Validate lab units
        Dim labUnits As Integer = 0
        If Not Integer.TryParse(txtLabUnits.Text.Trim(), labUnits) OrElse labUnits < 0 Then
            MessageBox.Show("Lab units must be a non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLabUnits.Focus()
            Return False
        End If

        ' Validate lecture units
        Dim lectureUnits As Integer = 0
        If Not Integer.TryParse(txtLectureUnits.Text.Trim(), lectureUnits) OrElse lectureUnits <= 0 Then
            MessageBox.Show("Lecture units must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLectureUnits.Focus()
            Return False
        End If

        ' Validate total units (should not exceed reasonable limit)
        If (labUnits + lectureUnits) > 10 Then
            MessageBox.Show("Total units (Lab + Lecture) cannot exceed 10.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate department selection
        If cmbDepartment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbDepartment.Focus()
            Return False
        End If

        ' Validate year level selection
        If cmbYearLevel.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a year level.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbYearLevel.Focus()
            Return False
        End If

        Return True
    End Function

    ' ============= ADD COURSE METHODS =============

    Private Sub btnSubmitCourse_Click(sender As Object, e As EventArgs) Handles btnSubmitCourse.Click
        ' Validate input
        If Not IsValidCourseInput() Then
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for duplicate course code
                Dim checkQuery As String = "SELECT COUNT(*) FROM Courses WHERE course_code = @course_code"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@course_code", txtCourseCode.Text.Trim().ToUpper())
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Course code already exists. Please use a different code.", "Duplicate Course Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtCourseCode.Focus()
                        Return
                    End If
                End Using

                ' Insert new course
                Dim insertQuery As String = "INSERT INTO Courses (course_code, course_name, course_description, lab_units, lecture_units, department_id, year_level_id, is_active, created_at, updated_at) " &
                                           "VALUES (@course_code, @course_name, @course_description, @lab_units, @lecture_units, @department_id, @year_level_id, TRUE, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@course_code", txtCourseCode.Text.Trim().ToUpper())
                    insertCmd.Parameters.AddWithValue("@course_name", txtCourseName.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@course_description", If(String.IsNullOrWhiteSpace(txtCourseDescription.Text), DBNull.Value, CType(txtCourseDescription.Text.Trim(), Object)))
                    insertCmd.Parameters.AddWithValue("@lab_units", Convert.ToInt32(txtLabUnits.Text.Trim()))
                    insertCmd.Parameters.AddWithValue("@lecture_units", Convert.ToInt32(txtLectureUnits.Text.Trim()))
                    insertCmd.Parameters.AddWithValue("@department_id", Convert.ToInt32(cmbDepartment.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@year_level_id", Convert.ToInt32(cmbYearLevel.SelectedValue))

                    insertCmd.ExecuteNonQuery()
                End Using

                ' Calculate total credits
                Dim totalCredits As Integer = Convert.ToInt32(txtLabUnits.Text.Trim()) + Convert.ToInt32(txtLectureUnits.Text.Trim())

                Dim successMessage As String = $"Course added successfully!" & vbCrLf & vbCrLf &
                                              $"Course Code: {txtCourseCode.Text.Trim().ToUpper()}" & vbCrLf &
                                              $"Course Name: {txtCourseName.Text.Trim()}" & vbCrLf &
                                              $"Total Credits: {totalCredits} units"

                MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
                ClearAddCourseForm()
                LoadCoursesData()
                LoadCourseUpdateDropdown()

            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Course code already exists. Please use a different code.", "Duplicate Course Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error adding course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAddCourseForm()
        txtCourseCode.Clear()
        txtCourseName.Clear()
        txtCourseDescription.Clear()
        txtLabUnits.Text = "0"
        txtLectureUnits.Text = "3"

        If cmbDepartment.Items.Count > 0 Then
            cmbDepartment.SelectedIndex = 0
        End If

        If cmbYearLevel.Items.Count > 0 Then
            cmbYearLevel.SelectedIndex = 0
        End If
    End Sub

    ' ============= VIEW COURSES METHODS =============

    Private Sub LoadCoursesData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT c.course_id as 'Course ID', " &
                                    "c.course_code as 'Course Code', " &
                                    "c.course_name as 'Course Name', " &
                                    "IFNULL(c.course_description, 'N/A') as 'Description', " &
                                    "c.lab_units as 'Lab Units', " &
                                    "c.lecture_units as 'Lecture Units', " &
                                    "c.credits as 'Total Credits', " &
                                    "IFNULL(d.department_name, 'N/A') as 'Department', " &
                                    "IFNULL(yl.year_level_name, 'N/A') as 'Year Level', " &
                                    "IF(c.is_active, 'Active', 'Inactive') as 'Status', " &
                                    "DATE_FORMAT(c.created_at, '%Y-%m-%d') as 'Created' " &
                                    "FROM Courses c " &
                                    "LEFT JOIN Departments d ON c.department_id = d.department_id " &
                                    "LEFT JOIN Year_Levels yl ON c.year_level_id = yl.year_level_id " &
                                    "WHERE c.is_active = TRUE " &
                                    "ORDER BY c.course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim coursesTable As New DataTable()
                    adapter.Fill(coursesTable)
                    dgvCourses.DataSource = coursesTable

                    ' Auto-resize columns
                    dgvCourses.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshCourses_Click(sender As Object, e As EventArgs) Handles btnRefreshCourses.Click
        LoadCoursesData()
        MessageBox.Show("Courses data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE COURSE METHODS =============

    Private Sub LoadCourseUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT course_id, CONCAT(course_code, ' - ', course_name) as display_name FROM Courses WHERE is_active = TRUE ORDER BY course_code"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim courseTable As New DataTable()
                    adapter.Fill(courseTable)
                    cmbSelectCourseUpdate.DataSource = courseTable
                    cmbSelectCourseUpdate.DisplayMember = "display_name"
                    cmbSelectCourseUpdate.ValueMember = "course_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading courses for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadCourseData_Click(sender As Object, e As EventArgs) Handles btnLoadCourseData.Click
        If cmbSelectCourseUpdate.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a course to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedCourseId As Integer = Convert.ToInt32(cmbSelectCourseUpdate.SelectedValue)
            LoadCourseDataForUpdate(selectedCourseId)
        Catch ex As Exception
            MessageBox.Show($"Error loading course data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadCourseDataForUpdate(courseId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT course_code, course_name, course_description, lab_units, lecture_units, department_id, year_level_id " &
                                    "FROM Courses WHERE course_id = @course_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@course_id", courseId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtUpdateCourseCode.Text = reader("course_code").ToString()
                            txtUpdateCourseName.Text = reader("course_name").ToString()
                            txtUpdateCourseDescription.Text = If(IsDBNull(reader("course_description")), "", reader("course_description").ToString())
                            txtUpdateLabUnits.Text = reader("lab_units").ToString()
                            txtUpdateLectureUnits.Text = reader("lecture_units").ToString()

                            If Not IsDBNull(reader("department_id")) Then
                                cmbUpdateDepartment.SelectedValue = Convert.ToInt32(reader("department_id"))
                            End If

                            If Not IsDBNull(reader("year_level_id")) Then
                                cmbUpdateYearLevel.SelectedValue = Convert.ToInt32(reader("year_level_id"))
                            End If

                            ' Show group box and buttons
                            grpCourseInfo.Visible = True
                            btnUpdateCourse.Visible = True
                            btnDeleteCourse.Visible = True
                        Else
                            MessageBox.Show("Course data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading course data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateCourse_Click(sender As Object, e As EventArgs) Handles btnUpdateCourse.Click
        If cmbSelectCourseUpdate.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a course to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate update input
        If String.IsNullOrWhiteSpace(txtUpdateCourseCode.Text) OrElse
           String.IsNullOrWhiteSpace(txtUpdateCourseName.Text) OrElse
           String.IsNullOrWhiteSpace(txtUpdateLabUnits.Text) OrElse
           String.IsNullOrWhiteSpace(txtUpdateLectureUnits.Text) Then
            MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate units are numeric and valid
        Dim labUnits As Integer = 0
        Dim lectureUnits As Integer = 0
        If Not Integer.TryParse(txtUpdateLabUnits.Text.Trim(), labUnits) OrElse labUnits < 0 Then
            MessageBox.Show("Lab units must be a non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateLabUnits.Focus()
            Return
        End If

        If Not Integer.TryParse(txtUpdateLectureUnits.Text.Trim(), lectureUnits) OrElse lectureUnits <= 0 Then
            MessageBox.Show("Lecture units must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateLectureUnits.Focus()
            Return
        End If

        If (labUnits + lectureUnits) > 10 Then
            MessageBox.Show("Total units (Lab + Lecture) cannot exceed 10.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this course information?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedCourseId As Integer = Convert.ToInt32(cmbSelectCourseUpdate.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Check for duplicate course code (excluding current course)
                    Dim checkQuery As String = "SELECT COUNT(*) FROM Courses WHERE course_code = @course_code AND course_id != @course_id"
                    Using checkCmd As New MySqlCommand(checkQuery, connection)
                        checkCmd.Parameters.AddWithValue("@course_code", txtUpdateCourseCode.Text.Trim().ToUpper())
                        checkCmd.Parameters.AddWithValue("@course_id", selectedCourseId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Course code already exists for another course. Please use a different code.", "Duplicate Course Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtUpdateCourseCode.Focus()
                            Return
                        End If
                    End Using

                    ' Update course
                    Dim updateQuery As String = "UPDATE Courses SET " &
                                               "course_code = @course_code, " &
                                               "course_name = @course_name, " &
                                               "course_description = @course_description, " &
                                               "lab_units = @lab_units, " &
                                               "lecture_units = @lecture_units, " &
                                               "department_id = @department_id, " &
                                               "year_level_id = @year_level_id, " &
                                               "updated_at = NOW() " &
                                               "WHERE course_id = @course_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@course_code", txtUpdateCourseCode.Text.Trim().ToUpper())
                        updateCmd.Parameters.AddWithValue("@course_name", txtUpdateCourseName.Text.Trim())
                        updateCmd.Parameters.AddWithValue("@course_description", If(String.IsNullOrWhiteSpace(txtUpdateCourseDescription.Text), DBNull.Value, CType(txtUpdateCourseDescription.Text.Trim(), Object)))
                        updateCmd.Parameters.AddWithValue("@lab_units", Convert.ToInt32(txtUpdateLabUnits.Text.Trim()))
                        updateCmd.Parameters.AddWithValue("@lecture_units", Convert.ToInt32(txtUpdateLectureUnits.Text.Trim()))
                        updateCmd.Parameters.AddWithValue("@department_id", Convert.ToInt32(cmbUpdateDepartment.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@year_level_id", Convert.ToInt32(cmbUpdateYearLevel.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@course_id", selectedCourseId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Course information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh data
                    LoadCoursesData()
                    LoadCourseUpdateDropdown()
                    ClearUpdateForm()
                End Using
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    MessageBox.Show("Course code already exists. Please use a different code.", "Duplicate Course Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error updating course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDeleteCourse_Click(sender As Object, e As EventArgs) Handles btnDeleteCourse.Click
        If cmbSelectCourseUpdate.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a course to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedCourseDisplay As String = cmbSelectCourseUpdate.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the course: {selectedCourseDisplay}?" & vbCrLf & vbCrLf &
                                                     "This will mark the course as inactive (soft delete).", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedCourseId As Integer = Convert.ToInt32(cmbSelectCourseUpdate.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Soft delete - mark as inactive
                    Dim deleteQuery As String = "UPDATE Courses SET is_active = FALSE, updated_at = NOW() WHERE course_id = @course_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@course_id", selectedCourseId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Course deleted successfully: {selectedCourseDisplay}", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Refresh data
                            LoadCoursesData()
                            LoadCourseUpdateDropdown()
                            ClearUpdateForm()
                        Else
                            MessageBox.Show("Failed to delete course. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting course: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateForm()
        txtUpdateCourseCode.Clear()
        txtUpdateCourseName.Clear()
        txtUpdateCourseDescription.Clear()
        txtUpdateLabUnits.Text = "0"
        txtUpdateLectureUnits.Text = "3"

        grpCourseInfo.Visible = False
        btnUpdateCourse.Visible = False
        btnDeleteCourse.Visible = False
    End Sub

    ' ============= MANAGE PREREQUISITES METHODS =============

    Private Sub LoadCoursePrereqDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT course_id, CONCAT(course_code, ' - ', course_name) as display_name FROM Courses WHERE is_active = TRUE ORDER BY course_code"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim courseTable As New DataTable()
                    adapter.Fill(courseTable)
                    cmbSelectCourseForPrereq.DataSource = courseTable
                    cmbSelectCourseForPrereq.DisplayMember = "display_name"
                    cmbSelectCourseForPrereq.ValueMember = "course_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading courses for prerequisites: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadPrerequisites_Click(sender As Object, e As EventArgs) Handles btnLoadPrerequisites.Click
        If cmbSelectCourseForPrereq.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a course to load prerequisites.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            currentPrereqCourseId = Convert.ToInt32(cmbSelectCourseForPrereq.SelectedValue)
            LoadPrerequisitesData(currentPrereqCourseId)
            LoadAvailablePrerequisites(currentPrereqCourseId)

            ' Show group box
            grpPrerequisiteInfo.Visible = True
        Catch ex As Exception
            MessageBox.Show($"Error loading prerequisites: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadPrerequisitesData(courseId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT " &
                                    "cp.prerequisite_id as 'Prerequisite ID', " &
                                    "c.course_code as 'Prerequisite Code', " &
                                    "c.course_name as 'Prerequisite Name', " &
                                    "IF(cp.is_corequisite, 'Corequisite', 'Prerequisite') as 'Type', " &
                                    "DATE_FORMAT(cp.created_at, '%Y-%m-%d') as 'Added On' " &
                                    "FROM Course_Prerequisites cp " &
                                    "INNER JOIN Courses c ON cp.prerequisite_course_id = c.course_id " &
                                    "WHERE cp.course_id = @course_id " &
                                    "ORDER BY cp.is_corequisite, c.course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@course_id", courseId)
                    Dim prereqTable As New DataTable()
                    adapter.Fill(prereqTable)
                    dgvPrerequisites.DataSource = prereqTable

                    ' Auto-resize columns
                    dgvPrerequisites.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading prerequisites data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAvailablePrerequisites(courseId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Get courses that are NOT already prerequisites and NOT the current course itself
                Dim query As String = "SELECT c.course_id, CONCAT(c.course_code, ' - ', c.course_name) as display_name " &
                                    "FROM Courses c " &
                                    "WHERE c.is_active = TRUE " &
                                    "AND c.course_id != @course_id " &
                                    "AND c.course_id NOT IN ( " &
                                    "    SELECT prerequisite_course_id FROM Course_Prerequisites WHERE course_id = @course_id " &
                                    ") " &
                                    "ORDER BY c.course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@course_id", courseId)
                    Dim availableCoursesTable As New DataTable()
                    adapter.Fill(availableCoursesTable)
                    cmbPrerequisiteCourse.DataSource = availableCoursesTable
                    cmbPrerequisiteCourse.DisplayMember = "display_name"
                    cmbPrerequisiteCourse.ValueMember = "course_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading available prerequisites: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAddPrerequisite_Click(sender As Object, e As EventArgs) Handles btnAddPrerequisite.Click
        If currentPrereqCourseId = 0 Then
            MessageBox.Show("Please load a course first.", "No Course Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbPrerequisiteCourse.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a prerequisite course.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim prerequisiteCourseId As Integer = Convert.ToInt32(cmbPrerequisiteCourse.SelectedValue)
            Dim isCorequisite As Boolean = chkIsCorequisite.Checked

            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for circular dependency
                If CheckCircularDependency(currentPrereqCourseId, prerequisiteCourseId, connection) Then
                    MessageBox.Show("Cannot add this prerequisite as it would create a circular dependency." & vbCrLf &
                                  "The selected course directly or indirectly depends on the current course.",
                                  "Circular Dependency Detected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                ' Insert prerequisite
                Dim insertQuery As String = "INSERT INTO Course_Prerequisites (course_id, prerequisite_course_id, is_corequisite, created_at) " &
                                           "VALUES (@course_id, @prerequisite_course_id, @is_corequisite, NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@course_id", currentPrereqCourseId)
                    insertCmd.Parameters.AddWithValue("@prerequisite_course_id", prerequisiteCourseId)
                    insertCmd.Parameters.AddWithValue("@is_corequisite", isCorequisite)

                    insertCmd.ExecuteNonQuery()
                End Using

                Dim prereqType As String = If(isCorequisite, "Corequisite", "Prerequisite")
                MessageBox.Show($"{prereqType} added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh data
                LoadPrerequisitesData(currentPrereqCourseId)
                LoadAvailablePrerequisites(currentPrereqCourseId)

                ' Reset checkbox
                chkIsCorequisite.Checked = False
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("This prerequisite already exists for this course.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error adding prerequisite: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function CheckCircularDependency(courseId As Integer, prerequisiteId As Integer, connection As MySqlConnection) As Boolean
        ' Check if prerequisiteId already depends on courseId (directly or indirectly)
        Try
            Dim query As String = "WITH RECURSIVE CoursePrereqs AS ( " &
                                "    SELECT prerequisite_course_id FROM Course_Prerequisites WHERE course_id = @prerequisite_id " &
                                "    UNION ALL " &
                                "    SELECT cp.prerequisite_course_id " &
                                "    FROM Course_Prerequisites cp " &
                                "    INNER JOIN CoursePrereqs cpr ON cp.course_id = cpr.prerequisite_course_id " &
                                ") " &
                                "SELECT COUNT(*) FROM CoursePrereqs WHERE prerequisite_course_id = @course_id"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@course_id", courseId)
                cmd.Parameters.AddWithValue("@prerequisite_id", prerequisiteId)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return (count > 0)
            End Using
        Catch ex As Exception
            ' If recursive CTE not supported, do a simple check for direct dependency
            Dim simpleQuery As String = "SELECT COUNT(*) FROM Course_Prerequisites WHERE course_id = @prerequisite_id AND prerequisite_course_id = @course_id"
            Using cmd As New MySqlCommand(simpleQuery, connection)
                cmd.Parameters.AddWithValue("@course_id", courseId)
                cmd.Parameters.AddWithValue("@prerequisite_id", prerequisiteId)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return (count > 0)
            End Using
        End Try
    End Function

    Private Sub btnRemovePrerequisite_Click(sender As Object, e As EventArgs) Handles btnRemovePrerequisite.Click
        If dgvPrerequisites.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a prerequisite to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedRow As DataGridViewRow = dgvPrerequisites.SelectedRows(0)
            Dim prerequisiteId As Integer = Convert.ToInt32(selectedRow.Cells("Prerequisite ID").Value)
            Dim prerequisiteDisplay As String = $"{selectedRow.Cells("Prerequisite Code").Value} - {selectedRow.Cells("Prerequisite Name").Value}"

            Dim result As DialogResult = MessageBox.Show($"Are you sure you want to remove this prerequisite?" & vbCrLf & vbCrLf &
                                                        $"{prerequisiteDisplay}",
                                                        "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim deleteQuery As String = "DELETE FROM Course_Prerequisites WHERE prerequisite_id = @prerequisite_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@prerequisite_id", prerequisiteId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show("Prerequisite removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Refresh data
                            LoadPrerequisitesData(currentPrereqCourseId)
                            LoadAvailablePrerequisites(currentPrereqCourseId)
                        Else
                            MessageBox.Show("Failed to remove prerequisite. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End If
        Catch ex As Exception
            MessageBox.Show($"Error removing prerequisite: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearPrerequisitesForm()
        currentPrereqCourseId = 0
        chkIsCorequisite.Checked = False
        grpPrerequisiteInfo.Visible = False
        dgvPrerequisites.DataSource = Nothing
    End Sub

    Private Sub pnlAddCourse_Paint(sender As Object, e As PaintEventArgs) Handles pnlAddCourse.Paint

    End Sub
End Class