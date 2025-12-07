Imports MySql.Data.MySqlClient

Public Class EnrollStudent
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current enrollment ID for update/delete
    Private currentEnrollmentId As Integer = 0

    ' Store current instructor ID (retrieved from logged-in user)
    Private currentInstructorId As Integer = 0

    ' Store current user ID for enrollment tracking
    Private currentUserId As Integer = 0

    Private Sub EnrollStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Enrollment Management (Instructor) - MGOD LMS"

        ' Get the instructor ID and user ID for the logged-in user
        GetCurrentInstructorId()

        ' Initialize dropdowns
        InitializeStudentDropdown()
        InitializeCourseOfferingDropdown()
        InitializeEnrollmentStatusDropdown()

        ' Load enrollments data
        LoadEnrollmentsData()
        LoadEnrollmentUpdateDropdown()

        ' Show View Enrollments panel by default
        ShowPanel(pnlViewEnrollments)

        ' Add event handlers for checkboxes
        AddHandler chkSetDropDate.CheckedChanged, AddressOf chkSetDropDate_CheckedChanged
        AddHandler chkSetCompletionDate.CheckedChanged, AddressOf chkSetCompletionDate_CheckedChanged
    End Sub

    ' New method to get instructor ID from logged-in user
    Private Sub GetCurrentInstructorId()
        Try
            ' Get username from login form
            Dim currentUsername As String = login.CurrentUsername

            If String.IsNullOrEmpty(currentUsername) Then
                MessageBox.Show("No user is currently logged in.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Get user_id and instructor_id from the logged-in user's username
                Dim query As String = "SELECT u.user_id, i.instructor_id FROM Users u " &
          "LEFT JOIN Instructors i ON u.user_id = i.user_id " &
            "WHERE u.username = @username"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@username", currentUsername)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            currentUserId = Convert.ToInt32(reader("user_id"))

                            If Not IsDBNull(reader("instructor_id")) Then
                                currentInstructorId = Convert.ToInt32(reader("instructor_id"))
                                Debug.WriteLine($"Instructor ID retrieved: {currentInstructorId}")
                            Else
                                ' User is not an instructor (might be admin or student)
                                currentInstructorId = 0
                                Debug.WriteLine("Current user is not an instructor")
                            End If
                        Else
                            currentUserId = 1
                            currentInstructorId = 0
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving instructor information: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            currentInstructorId = 0
            currentUserId = 1
        End Try
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlCreateEnrollment.Visible = False
        pnlViewEnrollments.Visible = False
        pnlUpdateDeleteEnrollment.Visible = False
        pnlBulkEnrollment.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnCreateEnrollment.BackColor = Color.FromArgb(35, 35, 38)
        btnViewEnrollments.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteEnrollment.BackColor = Color.FromArgb(35, 35, 38)
        btnBulkEnrollment.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnCreateEnrollment_Click(sender As Object, e As EventArgs) Handles btnCreateEnrollment.Click
        ShowPanel(pnlCreateEnrollment)
        SetActiveButton(btnCreateEnrollment)
        ClearCreateEnrollmentForm()
    End Sub

    Private Sub btnViewEnrollments_Click(sender As Object, e As EventArgs) Handles btnViewEnrollments.Click
        ShowPanel(pnlViewEnrollments)
        SetActiveButton(btnViewEnrollments)
        LoadEnrollmentsData()
    End Sub

    Private Sub btnUpdateDeleteEnrollment_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteEnrollment.Click
        ShowPanel(pnlUpdateDeleteEnrollment)
        SetActiveButton(btnUpdateDeleteEnrollment)
        LoadEnrollmentUpdateDropdown()
        ClearUpdateForm()
    End Sub

    Private Sub btnBulkEnrollment_Click(sender As Object, e As EventArgs) Handles btnBulkEnrollment.Click
        ShowPanel(pnlBulkEnrollment)
        SetActiveButton(btnBulkEnrollment)
        InitializeBulkEnrollmentDropdowns()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= INITIALIZATION METHODS =============

    Private Sub InitializeStudentDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT s.student_id, " &
  "CONCAT(s.student_number, ' - ', s.first_name, ' ', s.last_name, " &
    "' (', IFNULL(p.program_code, 'No Program'), ' - ', " &
        "IFNULL(yl.year_level_name, 'No Year'), ')') as display_name " &
"FROM Students s " &
        "LEFT JOIN Programs p ON s.program_id = p.program_id " &
    "LEFT JOIN Year_Levels yl ON s.year_level_id = yl.year_level_id " &
        "ORDER BY s.last_name, s.first_name"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim studentTable As New DataTable()
                    adapter.Fill(studentTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = studentTable.NewRow()
                    emptyRow("student_id") = DBNull.Value
                    emptyRow("display_name") = "-- Select Student --"
                    studentTable.Rows.InsertAt(emptyRow, 0)

                    ' Bind to Create dropdown
                    cmbStudent.DataSource = studentTable.Copy()
                    cmbStudent.DisplayMember = "display_name"
                    cmbStudent.ValueMember = "student_id"
                    cmbStudent.SelectedIndex = 0

                    ' Bind to Update dropdown
                    cmbUpdateStudent.DataSource = studentTable.Copy()
                    cmbUpdateStudent.DisplayMember = "display_name"
                    cmbUpdateStudent.ValueMember = "student_id"
                    cmbUpdateStudent.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeCourseOfferingDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT co.offering_id, " &
  "CONCAT(c.course_code, ' - ', c.course_name, ' (Section: ', co.section, ') - ', " &
   "ay.academic_year_name, ' ', st.type_name, ' ', tt.type_name, ' - ', " &
   "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA'), " &
   "' [', co.offering_status, ']') as display_name " &
     "FROM Course_Offerings co " &
       "INNER JOIN Courses c ON co.course_id = c.course_id " &
 "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
      "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
        "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
  "INNER JOIN Terms t ON co.term_id = t.term_id " &
      "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
   "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " &
         "WHERE co.offering_status = 'Open' "

                ' Add instructor filter if applicable
                If currentInstructorId > 0 Then
                    query &= "AND co.instructor_id = @instructor_id "
                End If

                query &= "ORDER BY ay.year_start DESC, st.display_order, tt.display_order, c.course_code, co.section"

                Using adapter As New MySqlDataAdapter(query, connection)
                    ' Add parameter if filtering by instructor
                    If currentInstructorId > 0 Then
                        adapter.SelectCommand.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    End If

                    Dim offeringTable As New DataTable()
                    adapter.Fill(offeringTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = offeringTable.NewRow()
                    emptyRow("offering_id") = DBNull.Value
                    emptyRow("display_name") = "-- Select Course Offering --"
                    offeringTable.Rows.InsertAt(emptyRow, 0)

                    cmbCourseOffering.DataSource = offeringTable.Copy()
                    cmbCourseOffering.DisplayMember = "display_name"
                    cmbCourseOffering.ValueMember = "offering_id"
                    cmbCourseOffering.SelectedIndex = 0

                    cmbUpdateCourseOffering.DataSource = offeringTable.Copy()
                    cmbUpdateCourseOffering.DisplayMember = "display_name"
                    cmbUpdateCourseOffering.ValueMember = "offering_id"
                    cmbUpdateCourseOffering.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading course offerings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeEnrollmentStatusDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT status_id, status_name " &
     "FROM Enrollment_Status_Types " &
    "WHERE is_active_status = TRUE " &
  "ORDER BY status_name"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim statusTable As New DataTable()
                    adapter.Fill(statusTable)

                    cmbEnrollmentStatus.DataSource = statusTable.Copy()
                    cmbEnrollmentStatus.DisplayMember = "status_name"
                    cmbEnrollmentStatus.ValueMember = "status_id"

                    cmbUpdateEnrollmentStatus.DataSource = statusTable.Copy()
                    cmbUpdateEnrollmentStatus.DisplayMember = "status_name"
                    cmbUpdateEnrollmentStatus.ValueMember = "status_id"

                    If cmbEnrollmentStatus.Items.Count > 0 Then cmbEnrollmentStatus.SelectedIndex = 0
                    If cmbUpdateEnrollmentStatus.Items.Count > 0 Then cmbUpdateEnrollmentStatus.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading enrollment statuses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============= CREATE ENROLLMENT METHODS (Using Stored Procedure) =============

    Private Sub btnSubmitEnrollment_Click(sender As Object, e As EventArgs) Handles btnSubmitEnrollment.Click
        ' Validate required fields
        If cmbStudent.SelectedValue Is Nothing OrElse IsDBNull(cmbStudent.SelectedValue) Then
            MessageBox.Show("Please select a student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbStudent.Focus()
            Return
        End If

        If cmbCourseOffering.SelectedValue Is Nothing OrElse IsDBNull(cmbCourseOffering.SelectedValue) Then
            MessageBox.Show("Please select a course offering.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cmbCourseOffering.Focus()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Call the stored procedure sp_EnrollStudent
                Using cmd As New MySqlCommand("sp_EnrollStudent", connection)
                    cmd.CommandType = CommandType.StoredProcedure

                    ' Input parameters
                    cmd.Parameters.AddWithValue("@p_student_id", Convert.ToInt32(cmbStudent.SelectedValue))
                    cmd.Parameters.AddWithValue("@p_offering_id", Convert.ToInt32(cmbCourseOffering.SelectedValue))
                    cmd.Parameters.AddWithValue("@p_enrolled_by", currentUserId)

                    ' Output parameters
                    Dim enrollmentIdParam As New MySqlParameter("@p_enrollment_id", MySqlDbType.Int32)
                    enrollmentIdParam.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(enrollmentIdParam)

                    Dim statusParam As New MySqlParameter("@p_status", MySqlDbType.VarChar, 50)
                    statusParam.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(statusParam)

                    Dim messageParam As New MySqlParameter("@p_message", MySqlDbType.VarChar, 500)
                    messageParam.Direction = ParameterDirection.Output
                    cmd.Parameters.Add(messageParam)

                    ' Execute and read results
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Get values from result set
                            Dim status As String = reader("status").ToString()
                            Dim message As String = reader("message").ToString()

                            If status = "SUCCESS" OrElse status = "WARNING" Then
                                Dim icon As MessageBoxIcon = If(status = "WARNING", MessageBoxIcon.Warning, MessageBoxIcon.Information)
                                MessageBox.Show(message, "Enrollment Result", MessageBoxButtons.OK, icon)

                                ' Clear form and reload data
                                ClearCreateEnrollmentForm()
                                LoadEnrollmentsData()
                                LoadEnrollmentUpdateDropdown()
                                InitializeCourseOfferingDropdown() ' Refresh in case offering is now full
                            Else
                                MessageBox.Show(message, "Enrollment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            ' No result set, check output parameters
                            reader.Close()
                            Dim status As String = If(statusParam.Value IsNot Nothing, statusParam.Value.ToString(), "ERROR")
                            Dim message As String = If(messageParam.Value IsNot Nothing, messageParam.Value.ToString(), "Unknown error occurred.")

                            If status = "SUCCESS" OrElse status = "WARNING" Then
                                MessageBox.Show(message, "Enrollment Result", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                ClearCreateEnrollmentForm()
                                LoadEnrollmentsData()
                                LoadEnrollmentUpdateDropdown()
                            Else
                                MessageBox.Show(message, "Enrollment Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        End If
                    End Using
                End Using
            End Using
        Catch ex As MySqlException
            MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"Error creating enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateEnrollmentForm()
        If cmbStudent.Items.Count > 0 Then cmbStudent.SelectedIndex = 0
        If cmbCourseOffering.Items.Count > 0 Then cmbCourseOffering.SelectedIndex = 0
        If cmbEnrollmentStatus.Items.Count > 0 Then cmbEnrollmentStatus.SelectedIndex = 0
        txtRemarks.Clear()
    End Sub

    ' ============= VIEW ENROLLMENTS METHODS =============

    Private Sub LoadEnrollmentsData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT e.enrollment_id as 'Enrollment ID', " &
          "s.student_number as 'Student Number', " &
     "CONCAT(s.first_name, ' ', s.last_name) as 'Student Name', " &
        "CONCAT(c.course_code, ' - ', c.course_name) as 'Course', " &
             "co.section as 'Section', " &
          "CONCAT(ay.academic_year_name, ' ', st.type_name, ' ', tt.type_name) as 'Semester/Term', " &
            "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA') as 'Instructor', " &
    "est.status_name as 'Status', " &
  "DATE_FORMAT(e.enrollment_date, '%Y-%m-%d') as 'Enrollment Date', " &
          "DATE_FORMAT(e.drop_date, '%Y-%m-%d') as 'Drop Date', " &
     "DATE_FORMAT(e.completion_date, '%Y-%m-%d') as 'Completion Date' " &
  "FROM Enrollments e " &
         "INNER JOIN Students s ON e.student_id = s.student_id " &
 "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " &
    "INNER JOIN Courses c ON co.course_id = c.course_id " &
            "INNER JOIN Semesters sem ON co.semester_id = sem.semester_id " &
 "INNER JOIN Academic_Years ay ON sem.academic_year_id = ay.academic_year_id " &
    "INNER JOIN Semester_Types st ON sem.semester_type_id = st.semester_type_id " &
 "INNER JOIN Terms t ON co.term_id = t.term_id " &
   "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
     "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " &
           "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id "

                ' Add WHERE clause if current user is an instructor
                If currentInstructorId > 0 Then
                    query &= "WHERE co.instructor_id = @instructor_id "
                End If

                query &= "ORDER BY e.enrollment_date DESC, s.last_name, s.first_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    ' Add parameter if filtering by instructor
                    If currentInstructorId > 0 Then
                        adapter.SelectCommand.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    End If

                    Dim enrollmentsTable As New DataTable()
                    adapter.Fill(enrollmentsTable)
                    dgvEnrollments.DataSource = enrollmentsTable
                    dgvEnrollments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                    ' Hide Enrollment ID column
                    If dgvEnrollments.Columns.Contains("Enrollment ID") Then
                        dgvEnrollments.Columns("Enrollment ID").Visible = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading enrollments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshEnrollments_Click(sender As Object, e As EventArgs) Handles btnRefreshEnrollments.Click
        LoadEnrollmentsData()
        MessageBox.Show("Enrollments data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE ENROLLMENT METHODS =============

    Private Sub LoadEnrollmentUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT e.enrollment_id, " &
    "CONCAT(s.student_number, ' - ', s.first_name, ' ', s.last_name, ' -> ', " &
    "c.course_code, ' - ', c.course_name, ' (', co.section, ') - ', " &
        "ay.academic_year_name, ' ', st.type_name, ' ', tt.type_name) as display_name " &
       "FROM Enrollments e " &
         "INNER JOIN Students s ON e.student_id = s.student_id " &
       "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " &
       "INNER JOIN Courses c ON co.course_id = c.course_id " &
       "INNER JOIN Semesters sem ON co.semester_id = sem.semester_id " &
   "INNER JOIN Academic_Years ay ON sem.academic_year_id = ay.academic_year_id " &
      "INNER JOIN Semester_Types st ON sem.semester_type_id = st.semester_type_id " &
     "INNER JOIN Terms t ON co.term_id = t.term_id " &
            "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id "

                ' Add instructor filter if applicable
                If currentInstructorId > 0 Then
                    query &= "WHERE co.instructor_id = @instructor_id "
                End If

                query &= "ORDER BY e.enrollment_date DESC"

                Using adapter As New MySqlDataAdapter(query, connection)
                    ' Add parameter if filtering by instructor
                    If currentInstructorId > 0 Then
                        adapter.SelectCommand.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    End If

                    Dim enrollmentTable As New DataTable()
                    adapter.Fill(enrollmentTable)
                    cmbSelectEnrollment.DataSource = enrollmentTable
                    cmbSelectEnrollment.DisplayMember = "display_name"
                    cmbSelectEnrollment.ValueMember = "enrollment_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading enrollments for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadEnrollmentData_Click(sender As Object, e As EventArgs) Handles btnLoadEnrollmentData.Click
        If cmbSelectEnrollment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an enrollment to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            currentEnrollmentId = Convert.ToInt32(cmbSelectEnrollment.SelectedValue)
            LoadEnrollmentDataForUpdate(currentEnrollmentId)
        Catch ex As Exception
            MessageBox.Show($"Error loading enrollment data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadEnrollmentDataForUpdate(enrollmentId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT student_id, offering_id, status_id, remarks, drop_date, completion_date " &
    "FROM Enrollments WHERE enrollment_id = @enrollment_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@enrollment_id", enrollmentId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            cmbUpdateStudent.SelectedValue = Convert.ToInt32(reader("student_id"))
                            cmbUpdateCourseOffering.SelectedValue = Convert.ToInt32(reader("offering_id"))
                            cmbUpdateEnrollmentStatus.SelectedValue = Convert.ToInt32(reader("status_id"))

                            If IsDBNull(reader("remarks")) Then
                                txtUpdateRemarks.Clear()
                            Else
                                txtUpdateRemarks.Text = reader("remarks").ToString()
                            End If

                            ' Handle drop date
                            If IsDBNull(reader("drop_date")) Then
                                chkSetDropDate.Checked = False
                                dtpDropDate.Value = DateTime.Now
                            Else
                                chkSetDropDate.Checked = True
                                dtpDropDate.Value = Convert.ToDateTime(reader("drop_date"))
                            End If

                            ' Handle completion date
                            If IsDBNull(reader("completion_date")) Then
                                chkSetCompletionDate.Checked = False
                                dtpCompletionDate.Value = DateTime.Now
                            Else
                                chkSetCompletionDate.Checked = True
                                dtpCompletionDate.Value = Convert.ToDateTime(reader("completion_date"))
                            End If

                            grpEnrollmentInfo.Visible = True
                            btnUpdateEnrollment.Visible = True
                        Else
                            MessageBox.Show("Enrollment data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading enrollment data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateEnrollment_Click(sender As Object, e As EventArgs) Handles btnUpdateEnrollment.Click
        If currentEnrollmentId = 0 Then
            MessageBox.Show("Please load an enrollment first.", "No Enrollment Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this enrollment?" & vbCrLf & vbCrLf +
"This will update the enrollment status and related information.",
  "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Prepare drop date and completion date values
                    Dim dropDate As Object = If(chkSetDropDate.Checked, dtpDropDate.Value, DBNull.Value)
                    Dim completionDate As Object = If(chkSetCompletionDate.Checked, dtpCompletionDate.Value, DBNull.Value)

                    ' Update enrollment
                    Dim updateQuery As String = "UPDATE Enrollments SET " &
    "student_id = @student_id, " &
"offering_id = @offering_id, " &
        "status_id = @status_id, " &
 "remarks = @remarks, " &
         "drop_date = @drop_date, " &
         "completion_date = @completion_date, " &
"updated_at = NOW() " &
       "WHERE enrollment_id = @enrollment_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@student_id", Convert.ToInt32(cmbUpdateStudent.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@offering_id", Convert.ToInt32(cmbUpdateCourseOffering.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@status_id", Convert.ToInt32(cmbUpdateEnrollmentStatus.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@remarks", If(String.IsNullOrWhiteSpace(txtUpdateRemarks.Text), DBNull.Value, txtUpdateRemarks.Text.Trim()))
                        updateCmd.Parameters.AddWithValue("@drop_date", dropDate)
                        updateCmd.Parameters.AddWithValue("@completion_date", completionDate)
                        updateCmd.Parameters.AddWithValue("@enrollment_id", currentEnrollmentId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Enrollment updated successfully!" & vbCrLf & vbCrLf &
  "Status, dates, and remarks have been updated.",
     "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh data
                    LoadEnrollmentsData()
                    LoadEnrollmentUpdateDropdown()
                    ClearUpdateForm()
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error updating enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateForm()
        currentEnrollmentId = 0
        txtUpdateRemarks.Clear()
        chkSetDropDate.Checked = False
        chkSetCompletionDate.Checked = False
        grpEnrollmentInfo.Visible = False
        btnUpdateEnrollment.Visible = False
    End Sub

    ' ============= BULK ENROLLMENT METHODS (Using Stored Procedure) =============

    Private Sub InitializeBulkEnrollmentDropdowns()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Load Semesters (Active only)
                Dim semesterQuery As String = "SELECT s.semester_id, " &
                 "CONCAT(ay.academic_year_name, ' - ', st.type_name) as display_name " &
   "FROM Semesters s " &
        "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
        "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
            "WHERE s.is_active = TRUE " &
 "ORDER BY ay.year_start DESC, st.display_order"
                Using adapter As New MySqlDataAdapter(semesterQuery, connection)
                    Dim semesterTable As New DataTable()
                    adapter.Fill(semesterTable)
                    cmbBulkSemester.DataSource = semesterTable
                    cmbBulkSemester.DisplayMember = "display_name"
                    cmbBulkSemester.ValueMember = "semester_id"
                End Using

                ' Load Programs
                Dim programQuery As String = "SELECT program_id, CONCAT(program_code, ' - ', program_name) as display_name " &
      "FROM Programs WHERE is_active = TRUE ORDER BY program_code"
                Using adapter As New MySqlDataAdapter(programQuery, connection)
                    Dim programTable As New DataTable()
                    adapter.Fill(programTable)
                    cmbBulkProgram.DataSource = programTable
                    cmbBulkProgram.DisplayMember = "display_name"
                    cmbBulkProgram.ValueMember = "program_id"
                End Using

                ' Load Year Levels
                Dim yearQuery As String = "SELECT year_level_id, year_level_name FROM Year_Levels ORDER BY year_level_id"
                Using adapter As New MySqlDataAdapter(yearQuery, connection)
                    Dim yearTable As New DataTable()
                    adapter.Fill(yearTable)
                    cmbBulkYearLevel.DataSource = yearTable
                    cmbBulkYearLevel.DisplayMember = "year_level_name"
                    cmbBulkYearLevel.ValueMember = "year_level_id"
                End Using

                ' Load Departments
                Dim deptQuery As String = "SELECT department_id, CONCAT(department_code, ' - ', department_name) as display_name " &
         "FROM Departments ORDER BY department_code"
                Using adapter As New MySqlDataAdapter(deptQuery, connection)
                    Dim deptTable As New DataTable()
                    adapter.Fill(deptTable)
                    cmbBulkDepartment.DataSource = deptTable
                    cmbBulkDepartment.DisplayMember = "display_name"
                    cmbBulkDepartment.ValueMember = "department_id"
                End Using

                Dim infoText As String = "Select filters and click 'Preview Data' to see available enrollments."
                If currentInstructorId > 0 Then
                    infoText &= " (Filtered to your courses only)"
                End If
                lblBulkInfo.Text = infoText
                btnExecuteBulkEnrollment.Enabled = False
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading bulk enrollment dropdowns: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnPreviewBulkEnrollment_Click(sender As Object, e As EventArgs) Handles btnPreviewBulkEnrollment.Click
        If cmbBulkSemester.SelectedValue Is Nothing OrElse
           cmbBulkProgram.SelectedValue Is Nothing OrElse
      cmbBulkYearLevel.SelectedValue Is Nothing OrElse
           cmbBulkDepartment.SelectedValue Is Nothing Then
     MessageBox.Show("Please select all required filters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
  Return
        End If

        Try
 Using connection As New MySqlConnection(connectionString)
          connection.Open()

     Dim semesterId As Integer = Convert.ToInt32(cmbBulkSemester.SelectedValue)
            Dim programId As Integer = Convert.ToInt32(cmbBulkProgram.SelectedValue)
       Dim yearLevelId As Integer = Convert.ToInt32(cmbBulkYearLevel.SelectedValue)
      Dim departmentId As Integer = Convert.ToInt32(cmbBulkDepartment.SelectedValue)

 ' Get semester type from the selected semester
          Dim semesterTypeId As Integer
      Dim semesterTypeQuery As String = "SELECT semester_type_id FROM Semesters WHERE semester_id = @semester_id"
     Using cmd As New MySqlCommand(semesterTypeQuery, connection)
    cmd.Parameters.AddWithValue("@semester_id", semesterId)
          Dim result = cmd.ExecuteScalar()
    If result Is Nothing OrElse IsDBNull(result) Then
        MessageBox.Show("Could not determine semester type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Return
    End If
  semesterTypeId = Convert.ToInt32(result)
           End Using

      ' Preview query
      Dim previewQuery As String = "SELECT DISTINCT " &
                "s.student_id, " &
"co.offering_id, " &
   "s.student_number as 'Student Number', " &
"CONCAT(s.first_name, ' ', s.last_name) as 'Student Name', " &
    "c.course_code as 'Course Code', " &
         "c.course_name as 'Course Name', " &
      "co.section as 'Section', " &
        "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA') as 'Instructor', " &
   "CASE " &
   "  WHEN e.enrollment_id IS NOT NULL THEN 'Already Enrolled' " &
        "  ELSE 'Ready to Enroll' " &
        "END as 'Status' " &
   "FROM Students s " &
         "INNER JOIN Program_Curriculum pc ON s.program_id = pc.program_id " &
          " AND s.year_level_id = pc.year_level_id " &
       "    AND pc.semester_type_id = @semester_type_id " &
      "    AND pc.is_active = TRUE " &
       "INNER JOIN Course_Offerings co ON pc.course_id = co.course_id " &
           "    AND co.semester_id = @semester_id " &
                "    AND co.offering_status = 'Open' "

    ' Add instructor filter if current user is an instructor
   If currentInstructorId > 0 Then
        previewQuery &= "    AND co.instructor_id = @instructor_id "
     End If

    previewQuery &= "INNER JOIN Courses c ON co.course_id = c.course_id " &
     "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " &
       "LEFT JOIN Enrollments e ON s.student_id = e.student_id " &
            "    AND co.offering_id = e.offering_id " &
     "WHERE s.program_id = @program_id " &
"    AND s.year_level_id = @year_level_id " &
          "    AND s.department_id = @department_id " &
        "ORDER BY s.student_number, c.course_code, co.section"

    Using adapter As New MySqlDataAdapter(previewQuery, connection)
    adapter.SelectCommand.Parameters.AddWithValue("@semester_id", semesterId)
              adapter.SelectCommand.Parameters.AddWithValue("@program_id", programId)
         adapter.SelectCommand.Parameters.AddWithValue("@year_level_id", yearLevelId)
   adapter.SelectCommand.Parameters.AddWithValue("@department_id", departmentId)
              adapter.SelectCommand.Parameters.AddWithValue("@semester_type_id", semesterTypeId)

          If currentInstructorId > 0 Then
                adapter.SelectCommand.Parameters.AddWithValue("@instructor_id", currentInstructorId)
          End If

         Dim previewTable As New DataTable()
        adapter.Fill(previewTable)

  If previewTable.Rows.Count = 0 Then
     Dim noDataMessage As String = "No students or course offerings found matching the selected criteria." & vbCrLf & vbCrLf &
                "Please ensure:" & vbCrLf &
  "1. Students exist with the selected program, year level, and department" & vbCrLf &
 "2. Program curriculum is defined for this program/year level/semester type" & vbCrLf &
   "3. Course offerings (Open status) exist for the selected semester"

   If currentInstructorId > 0 Then
         noDataMessage &= vbCrLf & "4. You are assigned as the instructor for relevant course offerings"
          End If

             MessageBox.Show(noDataMessage, "No Data Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
        dgvBulkEnrollmentPreview.DataSource = Nothing
            btnExecuteBulkEnrollment.Enabled = False
   lblBulkInfo.Text = "No matching records found."
  Return
       End If

  dgvBulkEnrollmentPreview.DataSource = previewTable
     dgvBulkEnrollmentPreview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

         ' Hide ID columns
     If dgvBulkEnrollmentPreview.Columns.Contains("student_id") Then
     dgvBulkEnrollmentPreview.Columns("student_id").Visible = False
              End If
                  If dgvBulkEnrollmentPreview.Columns.Contains("offering_id") Then
            dgvBulkEnrollmentPreview.Columns("offering_id").Visible = False
     End If

            ' Count enrollments
           Dim readyCount As Integer = 0
    Dim alreadyCount As Integer = 0
   For Each row As DataRow In previewTable.Rows
  If row("Status").ToString() = "Ready to Enroll" Then
                  readyCount += 1
      Else
    alreadyCount += 1
      End If
        Next

    Dim infoMessage As String = $"Preview: {readyCount} enrollments ready, {alreadyCount} already enrolled"
        If currentInstructorId > 0 Then
      infoMessage &= " (your courses only)"
    End If
  lblBulkInfo.Text = infoMessage
   btnExecuteBulkEnrollment.Enabled = (readyCount > 0)
         End Using
         End Using
        Catch ex As Exception
            MessageBox.Show($"Error previewing bulk enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExecuteBulkEnrollment_Click(sender As Object, e As EventArgs) Handles btnExecuteBulkEnrollment.Click
        Dim result As DialogResult = MessageBox.Show(
"Are you sure you want to enroll all students shown in the preview?" & vbCrLf & vbCrLf &
       "This will use the sp_EnrollStudent stored procedure for validation.",
            "Confirm Bulk Enrollment", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then Return

        Try
   Using connection As New MySqlConnection(connectionString)
    connection.Open()

    Dim successCount As Integer = 0
       Dim failCount As Integer = 0
        Dim warningCount As Integer = 0
    Dim errorMessages As New List(Of String)()

    ' Get data from preview grid
           Dim previewData As DataTable = CType(dgvBulkEnrollmentPreview.DataSource, DataTable)

 For Each row As DataRow In previewData.Rows
        If row("Status").ToString() = "Ready to Enroll" Then
    Dim studentId As Integer = Convert.ToInt32(row("student_id"))
  Dim offeringId As Integer = Convert.ToInt32(row("offering_id"))

       Try
           ' Call stored procedure for each enrollment
      Using cmd As New MySqlCommand("sp_EnrollStudent", connection)
   cmd.CommandType = CommandType.StoredProcedure

      cmd.Parameters.AddWithValue("@p_student_id", studentId)
         cmd.Parameters.AddWithValue("@p_offering_id", offeringId)
    cmd.Parameters.AddWithValue("@p_enrolled_by", currentUserId)

   Dim enrollmentIdParam As New MySqlParameter("@p_enrollment_id", MySqlDbType.Int32)
             enrollmentIdParam.Direction = ParameterDirection.Output
           cmd.Parameters.Add(enrollmentIdParam)

          Dim statusParam As New MySqlParameter("@p_status", MySqlDbType.VarChar, 50)
     statusParam.Direction = ParameterDirection.Output
            cmd.Parameters.Add(statusParam)

       Dim messageParam As New MySqlParameter("@p_message", MySqlDbType.VarChar, 500)
        messageParam.Direction = ParameterDirection.Output
     cmd.Parameters.Add(messageParam)

       Using reader As MySqlDataReader = cmd.ExecuteReader()
             If reader.Read() Then
Dim status As String = reader("status").ToString()
    If status = "SUCCESS" Then
        successCount += 1
     ElseIf status = "WARNING" Then
      warningCount += 1
 Else
   failCount += 1
     errorMessages.Add($"Student {row("Student Number")}: {reader("message")}")
        End If
        End If
        End Using
         End Using
         Catch ex As Exception
      failCount += 1
        errorMessages.Add($"Student {row("Student Number")}: {ex.Message}")
  End Try
          End If
    Next

       Dim summary As String = $"Bulk Enrollment Complete!" & vbCrLf & vbCrLf &
      $"✅ Successful: {successCount}" & vbCrLf &
   $"⚠️ Warnings: {warningCount}" & vbCrLf &
  $"❌ Failed: {failCount}"

    If errorMessages.Count > 0 AndAlso errorMessages.Count <= 5 Then
        summary &= vbCrLf & vbCrLf & "Errors:" & vbCrLf & String.Join(vbCrLf, errorMessages)
             ElseIf errorMessages.Count > 5 Then
       summary &= vbCrLf & vbCrLf & $"(First 5 errors of {errorMessages.Count}):" & vbCrLf & String.Join(vbCrLf, errorMessages.Take(5))
   End If

         MessageBox.Show(summary, "Bulk Enrollment Results", MessageBoxButtons.OK, MessageBoxIcon.Information)

          ' Refresh data
        btnPreviewBulkEnrollment_Click(Nothing, Nothing)
     LoadEnrollmentsData()
            InitializeCourseOfferingDropdown()
        End Using
   Catch ex As Exception
        MessageBox.Show($"Error executing bulk enrollment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============= CHECKBOX EVENT HANDLERS =============

    Private Sub chkSetDropDate_CheckedChanged(sender As Object, e As EventArgs)
        dtpDropDate.Enabled = chkSetDropDate.Checked
  If chkSetDropDate.Checked Then
  dtpDropDate.Value = DateTime.Now
        End If
    End Sub

    Private Sub chkSetCompletionDate_CheckedChanged(sender As Object, e As EventArgs)
        dtpCompletionDate.Enabled = chkSetCompletionDate.Checked
        If chkSetCompletionDate.Checked Then
          dtpCompletionDate.Value = DateTime.Now
     End If
    End Sub
End Class