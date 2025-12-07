Imports MySql.Data.MySqlClient

Public Class StudentDashboard
    ' Connection string
 Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current student ID
    Private currentStudentId As Integer = 0

    Private Sub StudentDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
     ' Set the form title with current user info
    Me.Text = $"Student Dashboard - Welcome {login.CurrentUsername}"

        ' Set welcome message
      lblWelcome.Text = $"Welcome, {login.CurrentUsername}"

        ' Get the student ID for the current user
    GetCurrentStudentId()

        ' Load student info and dashboard statistics
        LoadStudentInfo()
  LoadDashboardStats()

        ' Initialize course dropdown for grades
        InitializeCourseDropdownForGrades()

   ' Show dashboard by default
        ShowPanel(pnlDashboard)
        SetActiveButton(btnDashboard)
    End Sub

    ' Get the student ID for the current logged-in user
    Private Sub GetCurrentStudentId()
Try
      Using connection As New MySqlConnection(connectionString)
          connection.Open()
   Dim query As String = "SELECT s.student_id FROM Students s " &
        "INNER JOIN Users u ON s.user_id = u.user_id " &
 "WHERE u.username = @username"
     Using cmd As New MySqlCommand(query, connection)
             cmd.Parameters.AddWithValue("@username", login.CurrentUsername)
   Dim result = cmd.ExecuteScalar()
     If result IsNot Nothing AndAlso Not IsDBNull(result) Then
    currentStudentId = Convert.ToInt32(result)
          Else
        MessageBox.Show("Unable to find student profile for the current user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
        End Using
      End Using
Catch ex As Exception
            MessageBox.Show($"Error getting student ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
  ' Hide all panels
        pnlDashboard.Visible = False
        pnlMyEnrollments.Visible = False
        pnlViewGrades.Visible = False

    ' Show selected panel
      panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnDashboard.BackColor = Color.FromArgb(45, 45, 48)
        btnMyEnrollments.BackColor = Color.FromArgb(45, 45, 48)
        btnViewGrades.BackColor = Color.FromArgb(45, 45, 48)
  End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(pnlDashboard)
        SetActiveButton(btnDashboard)
        LoadDashboardStats()
    End Sub

    Private Sub btnMyEnrollments_Click(sender As Object, e As EventArgs) Handles btnMyEnrollments.Click
        ShowPanel(pnlMyEnrollments)
        SetActiveButton(btnMyEnrollments)
        LoadMyEnrollments()
    End Sub

  Private Sub btnViewGrades_Click(sender As Object, e As EventArgs) Handles btnViewGrades.Click
        ShowPanel(pnlViewGrades)
        SetActiveButton(btnViewGrades)
    InitializeCourseDropdownForGrades()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Confirm logout action
  Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?" & vbCrLf & vbCrLf &
     "You will be redirected to the login page.",
 "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Clear user session
  login.ClearUserSession()

            ' Show login form
    Dim loginForm As New login()
        loginForm.Show()

     ' Close current form
         Me.Close()
        End If
    End Sub

    ' ============= DASHBOARD METHODS =============

    Private Sub LoadStudentInfo()
        Try
 Using connection As New MySqlConnection(connectionString)
      connection.Open()

     Dim query As String = "SELECT s.student_number, s.first_name, s.last_name, " &
        "IFNULL(yl.year_level_name, 'N/A') as year_level, " &
    "IFNULL(p.program_name, 'N/A') as program_name " &
          "FROM Students s " &
          "LEFT JOIN Year_Levels yl ON s.year_level_id = yl.year_level_id " &
 "LEFT JOIN Programs p ON s.program_id = p.program_id " &
               "WHERE s.student_id = @student_id"

     Using cmd As New MySqlCommand(query, connection)
         cmd.Parameters.AddWithValue("@student_id", currentStudentId)
     Using reader As MySqlDataReader = cmd.ExecuteReader()
     If reader.Read() Then
 Dim studentNumber As String = reader("student_number").ToString()
       Dim firstName As String = reader("first_name").ToString()
   Dim lastName As String = reader("last_name").ToString()
          Dim yearLevel As String = reader("year_level").ToString()
     Dim programName As String = reader("program_name").ToString()

          lblWelcome.Text = $"Welcome, {firstName} {lastName}"
       lblStudentInfo.Text = $"Student Number: {studentNumber} | Program: {programName}"
         lblYearLevel.Text = "Year Level" & vbCrLf & yearLevel
        End If
       End Using
         End Using
            End Using
    Catch ex As Exception
MessageBox.Show($"Error loading student info: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

  Private Sub LoadDashboardStats()
        Try
    Using connection As New MySqlConnection(connectionString)
 connection.Open()

        ' Get total enrolled courses
     Dim courseQuery As String = "SELECT COUNT(*) FROM Enrollments WHERE student_id = @student_id AND enrollment_status = 'Enrolled'"
   Using cmd As New MySqlCommand(courseQuery, connection)
          cmd.Parameters.AddWithValue("@student_id", currentStudentId)
    Dim enrolledCourses As Integer = Convert.ToInt32(cmd.ExecuteScalar())
     lblEnrolledCourses.Text = "Enrolled Courses" & vbCrLf & enrolledCourses.ToString()
        End Using

   ' Get current semester
    Dim semesterQuery As String = "SELECT CONCAT(ay.academic_year_name, ' - ', st.type_name) as current_semester " &
     "FROM Semesters s " &
        "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
  "WHERE s.is_active = TRUE " &
         "LIMIT 1"
    Using cmd As New MySqlCommand(semesterQuery, connection)
          Dim result = cmd.ExecuteScalar()
      If result IsNot Nothing Then
        lblCurrentSemester.Text = "Current Semester" & vbCrLf & result.ToString()
               Else
       lblCurrentSemester.Text = "Current Semester" & vbCrLf & "N/A"
   End If
         End Using
       End Using
        Catch ex As Exception
       MessageBox.Show($"Error loading dashboard statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    ' ============= MY ENROLLMENTS METHODS =============

    Private Sub LoadMyEnrollments()
        Try
            Using connection As New MySqlConnection(connectionString)
     connection.Open()

  Dim query As String = "SELECT " &
          "c.course_code as 'Course Code', " &
           "c.course_name as 'Course Name', " &
  "co.section as 'Section', " &
   "CONCAT(ay.academic_year_name, ' - ', st.type_name) as 'Semester', " &
       "tt.type_name as 'Term', " &
    "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA') as 'Instructor', " &
       "e.enrollment_status as 'Status', " &
   "DATE_FORMAT(e.enrollment_date, '%Y-%m-%d') as 'Enrolled Date' " &
            "FROM Enrollments e " &
 "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " &
           "INNER JOIN Courses c ON co.course_id = c.course_id " &
      "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
                "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
           "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
    "INNER JOIN Terms t ON co.term_id = t.term_id " &
  "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
      "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " &
       "WHERE e.student_id = @student_id " &
         "ORDER BY ay.year_start DESC, st.display_order, c.course_code"

          Using adapter As New MySqlDataAdapter(query, connection)
       adapter.SelectCommand.Parameters.AddWithValue("@student_id", currentStudentId)
   Dim enrollmentsTable As New DataTable()
      adapter.Fill(enrollmentsTable)
       dgvMyEnrollments.DataSource = enrollmentsTable
               dgvMyEnrollments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
         End Using
            End Using
    Catch ex As Exception
 MessageBox.Show($"Error loading enrollments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshEnrollments_Click(sender As Object, e As EventArgs) Handles btnRefreshEnrollments.Click
        LoadMyEnrollments()
    MessageBox.Show("Enrollments refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= VIEW GRADES METHODS =============

  Private Sub InitializeCourseDropdownForGrades()
   Try
  Using connection As New MySqlConnection(connectionString)
   connection.Open()

         ' Get courses the student is enrolled in
      Dim query As String = "SELECT DISTINCT co.offering_id, " &
         "CONCAT(c.course_code, ' - ', c.course_name, ' (', co.section, ')') as display_name " &
     "FROM Enrollments e " &
 "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " &
              "INNER JOIN Courses c ON co.course_id = c.course_id " &
  "WHERE e.student_id = @student_id " &
       "AND e.enrollment_status = 'Enrolled' " &
             "ORDER BY c.course_code"

    Using adapter As New MySqlDataAdapter(query, connection)
        adapter.SelectCommand.Parameters.AddWithValue("@student_id", currentStudentId)
           Dim courseTable As New DataTable()
          adapter.Fill(courseTable)

          ' Add empty row for selection
Dim emptyRow As DataRow = courseTable.NewRow()
       emptyRow("offering_id") = DBNull.Value
        emptyRow("display_name") = "-- Select Course --"
 courseTable.Rows.InsertAt(emptyRow, 0)

   cmbCourseForGrades.DataSource = courseTable
      cmbCourseForGrades.DisplayMember = "display_name"
       cmbCourseForGrades.ValueMember = "offering_id"
     cmbCourseForGrades.SelectedIndex = 0
         End Using
  End Using
Catch ex As Exception
        MessageBox.Show($"Error loading courses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

 Private Sub btnLoadGrades_Click(sender As Object, e As EventArgs) Handles btnLoadGrades.Click
        If cmbCourseForGrades.SelectedValue Is Nothing OrElse IsDBNull(cmbCourseForGrades.SelectedValue) Then
            MessageBox.Show("Please select a course.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LoadMyGrades()
    End Sub

    Private Sub LoadMyGrades()
        Try
     Using connection As New MySqlConnection(connectionString)
           connection.Open()

           Dim offeringId As Integer = Convert.ToInt32(cmbCourseForGrades.SelectedValue)

    Dim query As String = "SELECT " &
    "at.type_name as 'Assignment Type', " &
      "IFNULL(g.grade_value, 'N/A') as 'Grade', " &
        "IFNULL(ogw.max_score, 100) as 'Max Score', " &
      "IFNULL(g.remarks, '') as 'Remarks', " &
         "IFNULL(DATE_FORMAT(g.graded_at, '%Y-%m-%d'), 'Not Graded') as 'Graded Date' " &
    "FROM Enrollments e " &
           "CROSS JOIN AssignmentTypes at " &
       "LEFT JOIN Offering_Grading_Weights ogw ON ogw.offering_id = e.offering_id AND ogw.type_id = at.type_id " &
    "LEFT JOIN Grades g ON g.enrollment_id = e.enrollment_id AND g.type_id = at.type_id " &
        "WHERE e.offering_id = @offering_id " &
 "AND e.student_id = @student_id " &
          "AND at.is_active = TRUE " &
          "ORDER BY at.display_order"

            Using adapter As New MySqlDataAdapter(query, connection)
           adapter.SelectCommand.Parameters.AddWithValue("@offering_id", offeringId)
     adapter.SelectCommand.Parameters.AddWithValue("@student_id", currentStudentId)
        Dim gradesTable As New DataTable()
          adapter.Fill(gradesTable)
    dgvMyGrades.DataSource = gradesTable
       dgvMyGrades.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
         End Using
 End Using
        Catch ex As Exception
          MessageBox.Show($"Error loading grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshGrades_Click(sender As Object, e As EventArgs) Handles btnRefreshGrades.Click
     If cmbCourseForGrades.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbCourseForGrades.SelectedValue) Then
 LoadMyGrades()
            MessageBox.Show("Grades refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
      MessageBox.Show("Please select a course first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub StudentDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        login.ClearUserSession()
        Dim loginForm As New login()
        loginForm.Show()
    End Sub
End Class
