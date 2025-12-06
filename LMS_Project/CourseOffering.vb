Imports MySql.Data.MySqlClient
Public Class CourseOffering
    ' Connection string - same as other forms
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current offering ID for update/delete
    Private currentOfferingId As Integer = 0

    Private Sub CourseOffering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Course Offerings Management - MGOD LMS"

        ' Initialize dropdowns
        InitializeCourseDropdown()
        InitializeSemesterDropdown()
        InitializeTermDropdown()
        InitializeInstructorDropdown()

        ' Initialize status dropdowns
        InitializeStatusDropdown()

        ' Load offerings data
        LoadOfferingsData()
        LoadOfferingUpdateDropdown()

        ' Show View Offerings panel by default
        ShowPanel(pnlViewOfferings)
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlCreateOffering.Visible = False
        pnlViewOfferings.Visible = False
        pnlUpdateDeleteOffering.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnCreateOffering.BackColor = Color.FromArgb(35, 35, 38)
        btnViewOfferings.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteOffering.BackColor = Color.FromArgb(35, 35, 38)
        btnCourseScheduling.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnCreateOffering_Click(sender As Object, e As EventArgs) Handles btnCreateOffering.Click
        ShowPanel(pnlCreateOffering)
        SetActiveButton(btnCreateOffering)
        ClearCreateOfferingForm()
    End Sub

    Private Sub btnViewOfferings_Click(sender As Object, e As EventArgs) Handles btnViewOfferings.Click
        ShowPanel(pnlViewOfferings)
        SetActiveButton(btnViewOfferings)
        LoadOfferingsData()
    End Sub

    Private Sub btnUpdateDeleteOffering_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteOffering.Click
        ShowPanel(pnlUpdateDeleteOffering)
        SetActiveButton(btnUpdateDeleteOffering)
        LoadOfferingUpdateDropdown()
        ClearUpdateForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnCourseScheduling_Click(sender As Object, e As EventArgs) Handles btnCourseScheduling.Click
        ' Open the Course Scheduling form
        Dim scheduleForm As New CourseSchedule()
        scheduleForm.Show()
        ' Optionally close the current form
        ' Me.Close()
    End Sub

    ' ============= INITIALIZATION METHODS =============

    Private Sub InitializeCourseDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT course_id, CONCAT(course_code, ' - ', course_name) as display_name " &
                                    "FROM Courses " &
                                    "WHERE is_active = TRUE " &
                                    "ORDER BY course_code"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim courseTable As New DataTable()
                    adapter.Fill(courseTable)

                    ' Bind to Create dropdown
                    cmbCourse.DataSource = courseTable.Copy()
                    cmbCourse.DisplayMember = "display_name"
                    cmbCourse.ValueMember = "course_id"

                    ' Bind to Update dropdown
                    cmbUpdateCourse.DataSource = courseTable.Copy()
                    cmbUpdateCourse.DisplayMember = "display_name"
                    cmbUpdateCourse.ValueMember = "course_id"

                    If cmbCourse.Items.Count > 0 Then cmbCourse.SelectedIndex = 0
                    If cmbUpdateCourse.Items.Count > 0 Then cmbUpdateCourse.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeSemesterDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT s.semester_id, CONCAT(ay.academic_year_name, ' - ', st.type_name) as display_name " &
                                    "FROM Semesters s " &
                                    "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                                    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                                    "WHERE s.is_active = TRUE " &
                                    "ORDER BY ay.year_start DESC, st.display_order"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim semesterTable As New DataTable()
                    adapter.Fill(semesterTable)

                    cmbSemester.DataSource = semesterTable.Copy()
                    cmbSemester.DisplayMember = "display_name"
                    cmbSemester.ValueMember = "semester_id"

                    cmbUpdateSemester.DataSource = semesterTable.Copy()
                    cmbUpdateSemester.DisplayMember = "display_name"
                    cmbUpdateSemester.ValueMember = "semester_id"

                    If cmbSemester.Items.Count > 0 Then cmbSemester.SelectedIndex = 0
                    If cmbUpdateSemester.Items.Count > 0 Then cmbUpdateSemester.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading semesters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeTermDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT t.term_id, CONCAT(ay.academic_year_name, ' - ', st.type_name, ' - ', tt.type_name) as display_name " &
                                    "FROM Terms t " &
                                    "INNER JOIN Semesters s ON t.semester_id = s.semester_id " &
                                    "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                                    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                                    "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
                                    "WHERE t.is_active = TRUE " &
                                    "ORDER BY ay.year_start DESC, st.display_order, tt.display_order"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim termTable As New DataTable()
                    adapter.Fill(termTable)

                    cmbTerm.DataSource = termTable.Copy()
                    cmbTerm.DisplayMember = "display_name"
                    cmbTerm.ValueMember = "term_id"

                    cmbUpdateTerm.DataSource = termTable.Copy()
                    cmbUpdateTerm.DisplayMember = "display_name"
                    cmbUpdateTerm.ValueMember = "term_id"

                    If cmbTerm.Items.Count > 0 Then cmbTerm.SelectedIndex = 0
                    If cmbUpdateTerm.Items.Count > 0 Then cmbUpdateTerm.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading terms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeInstructorDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT i.instructor_id, CONCAT(i.first_name, ' ', i.last_name, ' (', IFNULL(d.department_code, 'No Dept'), ')') as display_name " &
                                    "FROM Instructors i " &
                                    "LEFT JOIN Departments d ON i.department_id = d.department_id " &
                                    "WHERE i.employment_status = 'Active' " &
                                    "ORDER BY i.first_name, i.last_name"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim instructorTable As New DataTable()
                    adapter.Fill(instructorTable)

                    ' Add "None" option
                    Dim noneRow As DataRow = instructorTable.NewRow()
                    noneRow("instructor_id") = DBNull.Value
                    noneRow("display_name") = "-- None (To Be Assigned) --"
                    instructorTable.Rows.InsertAt(noneRow, 0)

                    cmbInstructor.DataSource = instructorTable.Copy()
                    cmbInstructor.DisplayMember = "display_name"
                    cmbInstructor.ValueMember = "instructor_id"
                    cmbInstructor.SelectedIndex = 0

                    cmbUpdateInstructor.DataSource = instructorTable.Copy()
                    cmbUpdateInstructor.DisplayMember = "display_name"
                    cmbUpdateInstructor.ValueMember = "instructor_id"
                    cmbUpdateInstructor.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading instructors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeStatusDropdown()
        ' Initialize Create offering status
        cmbOfferingStatus.Items.Clear()
        cmbOfferingStatus.Items.AddRange(New String() {"Open", "Closed", "Cancelled", "Full"})
        cmbOfferingStatus.SelectedIndex = 0

        ' Initialize Update offering status
        cmbUpdateOfferingStatus.Items.Clear()
        cmbUpdateOfferingStatus.Items.AddRange(New String() {"Open", "Closed", "Cancelled", "Full"})
        cmbUpdateOfferingStatus.SelectedIndex = 0
    End Sub

    ' ============= CREATE OFFERING METHODS =============

    Private Sub btnSubmitOffering_Click(sender As Object, e As EventArgs) Handles btnSubmitOffering.Click
        ' Validate required fields
        If cmbCourse.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a course.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbSemester.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a semester.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbTerm.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate max students
        Dim maxStudents As Integer = 0
        If Not Integer.TryParse(txtMaxStudents.Text.Trim(), maxStudents) OrElse maxStudents <= 0 Then
            MessageBox.Show("Max students must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMaxStudents.Focus()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for duplicate offering
                Dim checkQuery As String = "SELECT COUNT(*) FROM Course_Offerings " &
                                          "WHERE course_id = @course_id AND semester_id = @semester_id " &
                                          "AND term_id = @term_id AND section = @section"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@course_id", Convert.ToInt32(cmbCourse.SelectedValue))
                    checkCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbSemester.SelectedValue))
                    checkCmd.Parameters.AddWithValue("@term_id", Convert.ToInt32(cmbTerm.SelectedValue))
                    checkCmd.Parameters.AddWithValue("@section", txtSection.Text.Trim().ToUpper())

                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("This course offering already exists for the selected semester, term, and section.",
                                      "Duplicate Offering", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Get instructor ID (nullable)
                Dim instructorId As Object = DBNull.Value
                If cmbInstructor.SelectedIndex > 0 AndAlso cmbInstructor.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbInstructor.SelectedValue) Then
                    instructorId = Convert.ToInt32(cmbInstructor.SelectedValue)
                End If

                ' Insert new offering
                Dim insertQuery As String = "INSERT INTO Course_Offerings " &
                                           "(course_id, semester_id, term_id, instructor_id, section, max_students, offering_status, created_at, updated_at) " &
                                           "VALUES (@course_id, @semester_id, @term_id, @instructor_id, @section, @max_students, @offering_status, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@course_id", Convert.ToInt32(cmbCourse.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbSemester.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@term_id", Convert.ToInt32(cmbTerm.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@instructor_id", instructorId)
                    insertCmd.Parameters.AddWithValue("@section", txtSection.Text.Trim().ToUpper())
                    insertCmd.Parameters.AddWithValue("@max_students", maxStudents)
                    insertCmd.Parameters.AddWithValue("@offering_status", cmbOfferingStatus.SelectedItem.ToString())

                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Course offering created successfully!" & vbCrLf & vbCrLf &
                              $"Course: {cmbCourse.Text}" & vbCrLf &
                              $"Semester: {cmbSemester.Text}" & vbCrLf &
                              $"Term: {cmbTerm.Text}" & vbCrLf &
                              $"Section: {txtSection.Text.Trim().ToUpper()}" & vbCrLf &
                              $"Max Students: {maxStudents}",
                              "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
                ClearCreateOfferingForm()
                LoadOfferingsData()
                LoadOfferingUpdateDropdown()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("This course offering already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error creating offering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateOfferingForm()
        If cmbCourse.Items.Count > 0 Then cmbCourse.SelectedIndex = 0
        If cmbSemester.Items.Count > 0 Then cmbSemester.SelectedIndex = 0
        If cmbTerm.Items.Count > 0 Then cmbTerm.SelectedIndex = 0
        If cmbInstructor.Items.Count > 0 Then cmbInstructor.SelectedIndex = 0
        txtSection.Text = "A"
        txtMaxStudents.Text = "40"
        cmbOfferingStatus.SelectedIndex = 0
    End Sub

    ' ============= VIEW OFFERINGS METHODS =============

    Private Sub LoadOfferingsData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT co.offering_id as 'Offering ID', " &
                                    "c.course_code as 'Course Code', " &
                                    "c.course_name as 'Course Name', " &
                                    "CONCAT(ay.academic_year_name, ' - ', st.type_name) as 'Semester', " &
                                    "tt.type_name as 'Term', " &
                                    "co.section as 'Section', " &
                                    "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA') as 'Instructor', " &
                                    "co.max_students as 'Max Students', " &
                                    "co.offering_status as 'Status', " &
                                    "DATE_FORMAT(co.created_at, '%Y-%m-%d') as 'Created' " &
                                    "FROM Course_Offerings co " &
                                    "INNER JOIN Courses c ON co.course_id = c.course_id " &
                                    "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
                                    "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                                    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                                    "INNER JOIN Terms t ON co.term_id = t.term_id " &
                                    "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
                                    "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " &
                                    "ORDER BY ay.year_start DESC, st.display_order, tt.display_order, c.course_code, co.section"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim offeringsTable As New DataTable()
                    adapter.Fill(offeringsTable)
                    dgvOfferings.DataSource = offeringsTable
                    dgvOfferings.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading offerings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshOfferings_Click(sender As Object, e As EventArgs) Handles btnRefreshOfferings.Click
        LoadOfferingsData()
        MessageBox.Show("Offerings data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE OFFERING METHODS =============

    Private Sub LoadOfferingUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT co.offering_id, " &
                                    "CONCAT(c.course_code, ' - ', c.course_name, ' (', co.section, ') - ', " &
                                    "ay.academic_year_name, ' ', st.type_name, ' ', tt.type_name) as display_name " &
                                    "FROM Course_Offerings co " &
                                    "INNER JOIN Courses c ON co.course_id = c.course_id " &
                                    "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
                                    "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                                    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                                    "INNER JOIN Terms t ON co.term_id = t.term_id " &
                                    "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
                                    "ORDER BY ay.year_start DESC, st.display_order, tt.display_order, c.course_code, co.section"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim offeringTable As New DataTable()
                    adapter.Fill(offeringTable)
                    cmbSelectOffering.DataSource = offeringTable
                    cmbSelectOffering.DisplayMember = "display_name"
                    cmbSelectOffering.ValueMember = "offering_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading offerings for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadOfferingData_Click(sender As Object, e As EventArgs) Handles btnLoadOfferingData.Click
        If cmbSelectOffering.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an offering to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            currentOfferingId = Convert.ToInt32(cmbSelectOffering.SelectedValue)
            LoadOfferingDataForUpdate(currentOfferingId)
        Catch ex As Exception
            MessageBox.Show($"Error loading offering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadOfferingDataForUpdate(offeringId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT course_id, semester_id, term_id, instructor_id, section, max_students, offering_status " &
                                    "FROM Course_Offerings WHERE offering_id = @offering_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@offering_id", offeringId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            cmbUpdateCourse.SelectedValue = Convert.ToInt32(reader("course_id"))
                            cmbUpdateSemester.SelectedValue = Convert.ToInt32(reader("semester_id"))
                            cmbUpdateTerm.SelectedValue = Convert.ToInt32(reader("term_id"))

                            If IsDBNull(reader("instructor_id")) Then
                                cmbUpdateInstructor.SelectedIndex = 0
                            Else
                                cmbUpdateInstructor.SelectedValue = Convert.ToInt32(reader("instructor_id"))
                            End If

                            txtUpdateSection.Text = reader("section").ToString()
                            txtUpdateMaxStudents.Text = reader("max_students").ToString()
                            cmbUpdateOfferingStatus.SelectedItem = reader("offering_status").ToString()

                            grpOfferingInfo.Visible = True
                            btnUpdateOffering.Visible = True
                            btnDeleteOffering.Visible = True
                        Else
                            MessageBox.Show("Offering data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading offering data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateOffering_Click(sender As Object, e As EventArgs) Handles btnUpdateOffering.Click
        If currentOfferingId = 0 Then
            MessageBox.Show("Please load an offering first.", "No Offering Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate max students
        Dim maxStudents As Integer = 0
        If Not Integer.TryParse(txtUpdateMaxStudents.Text.Trim(), maxStudents) OrElse maxStudents <= 0 Then
            MessageBox.Show("Max students must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateMaxStudents.Focus()
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this course offering?",
                                                     "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Get instructor ID (nullable)
                    Dim instructorId As Object = DBNull.Value
                    If cmbUpdateInstructor.SelectedIndex > 0 AndAlso cmbUpdateInstructor.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbUpdateInstructor.SelectedValue) Then
                        instructorId = Convert.ToInt32(cmbUpdateInstructor.SelectedValue)
                    End If

                    ' Update offering
                    Dim updateQuery As String = "UPDATE Course_Offerings SET " &
                                               "course_id = @course_id, " &
                                               "semester_id = @semester_id, " &
                                               "term_id = @term_id, " &
                                               "instructor_id = @instructor_id, " &
                                               "section = @section, " &
                                               "max_students = @max_students, " &
                                               "offering_status = @offering_status, " &
                                               "updated_at = NOW() " &
                                               "WHERE offering_id = @offering_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@course_id", Convert.ToInt32(cmbUpdateCourse.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbUpdateSemester.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@term_id", Convert.ToInt32(cmbUpdateTerm.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@instructor_id", instructorId)
                        updateCmd.Parameters.AddWithValue("@section", txtUpdateSection.Text.Trim().ToUpper())
                        updateCmd.Parameters.AddWithValue("@max_students", maxStudents)

                        updateCmd.Parameters.AddWithValue("@offering_status", cmbUpdateOfferingStatus.SelectedItem.ToString())
                        updateCmd.Parameters.AddWithValue("@offering_id", currentOfferingId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Course offering updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh data
                    LoadOfferingsData()
                    LoadOfferingUpdateDropdown()
                    ClearUpdateForm()
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error updating offering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDeleteOffering_Click(sender As Object, e As EventArgs) Handles btnDeleteOffering.Click
        If currentOfferingId = 0 Then
            MessageBox.Show("Please load an offering first.", "No Offering Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedOfferingDisplay As String = cmbSelectOffering.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this course offering?" & vbCrLf & vbCrLf &
                                                    $"{selectedOfferingDisplay}" & vbCrLf & vbCrLf &
                                                    "This action cannot be undone.",
                                                    "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim deleteQuery As String = "DELETE FROM Course_Offerings WHERE offering_id = @offering_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@offering_id", currentOfferingId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Course offering deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Refresh data
                            LoadOfferingsData()
                            LoadOfferingUpdateDropdown()
                            ClearUpdateForm()
                        Else
                            MessageBox.Show("Failed to delete offering. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting offering: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateForm()
        currentOfferingId = 0
        txtUpdateSection.Clear()
        txtUpdateMaxStudents.Text = "40"
        grpOfferingInfo.Visible = False
        btnUpdateOffering.Visible = False
        btnDeleteOffering.Visible = False
    End Sub

    Private Sub pnlCreateOffering_Paint(sender As Object, e As PaintEventArgs) Handles pnlCreateOffering.Paint

    End Sub
End Class