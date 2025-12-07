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

        ' Initialize semester filter for grade summary
        InitializeSemesterFilter()

        ' Show dashboard by default
        ShowPanel(pnlDashboard)
        SetActiveButton(btnDashboard)
    End Sub

    ' Get the student ID for the current logged-in user
    Private Sub GetCurrentStudentId()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT s.student_id FROM Students s " +
        "INNER JOIN Users u ON s.user_id = u.user_id " +
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
        pnlGradeSummary.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnDashboard.BackColor = Color.FromArgb(45, 45, 48)
        btnMyEnrollments.BackColor = Color.FromArgb(45, 45, 48)
        btnViewGrades.BackColor = Color.FromArgb(45, 45, 48)
        btnGradeSummary.BackColor = Color.FromArgb(45, 45, 48)
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

    Private Sub btnGradeSummary_Click(sender As Object, e As EventArgs) Handles btnGradeSummary.Click
        ShowPanel(pnlGradeSummary)
        SetActiveButton(btnGradeSummary)
        InitializeSemesterFilter()
        LoadGradeSummary()
        LoadCourseAverages()
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

                Dim query As String = "SELECT s.student_number, s.first_name, s.last_name, " +
         "IFNULL(yl.year_level_name, 'N/A') as year_level, " +
      "IFNULL(p.program_name, 'N/A') as program_name " +
"FROM Students s " +
        "LEFT JOIN Year_Levels yl ON s.year_level_id = yl.year_level_id " +
      "LEFT JOIN Programs p ON s.program_id = p.program_id " +
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

                ' Get total enrolled courses - Fixed: use status_id with join to Enrollment_Status_Types
                Dim courseQuery As String = "SELECT COUNT(*) FROM Enrollments e " +
       "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " +
        "WHERE e.student_id = @student_id AND est.status_name = 'Enrolled'"
                Using cmd As New MySqlCommand(courseQuery, connection)
                    cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                    Dim enrolledCourses As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    lblEnrolledCourses.Text = "Enrolled Courses" & vbCrLf & enrolledCourses.ToString()
                End Using

                ' Get current semester
                Dim semesterQuery As String = "SELECT CONCAT(ay.academic_year_name, ' - ', st.type_name) as current_semester " +
    "FROM Semesters s " +
      "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " +
        "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " +
         "WHERE s.is_active = TRUE " +
 "LIMIT 1"
                Using cmd As New MySqlCommand(semesterQuery, connection)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        lblCurrentSemester.Text = "Current Semester" & vbCrLf & result.ToString()
                    Else
                        lblCurrentSemester.Text = "Current Semester" & vbCrLf & "N/A"
                    End If
                End Using

                ' Get Overall GPA using Final_Grades table
                Dim gpaQuery As String = "SELECT " +
             "ROUND(SUM(fg.gpa_points * c.credits) / NULLIF(SUM(c.credits), 0), 2) AS overall_gpa " +
          "FROM Enrollments e " +
       "INNER JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id " +
             "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " +
        "INNER JOIN Courses c ON co.course_id = c.course_id " +
   "WHERE e.student_id = @student_id " +
       "AND fg.gpa_points IS NOT NULL"
                Using cmd As New MySqlCommand(gpaQuery, connection)
                    cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                    Dim gpaResult = cmd.ExecuteScalar()
                    If gpaResult IsNot Nothing AndAlso Not IsDBNull(gpaResult) Then
                        lblOverallGPA.Text = "Overall GPA" & vbCrLf & gpaResult.ToString()
                    Else
                        lblOverallGPA.Text = "Overall GPA" & vbCrLf & "N/A"
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

                ' Fixed: use status_id with join to Enrollment_Status_Types
                Dim query As String = "SELECT " +
          "c.course_code as 'Course Code', " +
     "c.course_name as 'Course Name', " +
        "co.section as 'Section', " +
  "CONCAT(ay.academic_year_name, ' - ', st.type_name) as 'Semester', " +
     "tt.type_name as 'Term', " +
                  "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA') as 'Instructor', " +
        "est.status_name as 'Status', " +
            "DATE_FORMAT(e.enrollment_date, '%Y-%m-%d') as 'Enrolled Date' " +
      "FROM Enrollments e " +
       "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " +
              "INNER JOIN Courses c ON co.course_id = c.course_id " +
           "INNER JOIN Semesters s ON co.semester_id = s.semester_id " +
"INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " +
             "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " +
   "INNER JOIN Terms t ON co.term_id = t.term_id " +
        "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " +
          "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " +
               "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " +
             "WHERE e.student_id = @student_id " +
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

                ' Fixed: Include all enrollment statuses so students can see grades for completed courses
                Dim query As String = "SELECT offering_id, display_name FROM (" +
       "SELECT DISTINCT co.offering_id, " +
    "CONCAT(c.course_code, ' - ', c.course_name, ' (', co.section, ')') as display_name, " +
 "c.course_code " +
    "FROM Enrollments e " +
  "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " +
     "INNER JOIN Courses c ON co.course_id = c.course_id " +
   "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " +
         "WHERE e.student_id = @student_id " +
      "AND est.status_name IN ('Enrolled', 'Completed', 'Failed')" +
       ") AS subquery " +
    "ORDER BY course_code"

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

                ' Get enrollment_id first
                Dim enrollmentId As Integer = 0
                Dim getEnrollmentQuery As String = "SELECT enrollment_id FROM Enrollments " +
          "WHERE offering_id = @offering_id AND student_id = @student_id"
                Using cmd As New MySqlCommand(getEnrollmentQuery, connection)
                    cmd.Parameters.AddWithValue("@offering_id", offeringId)
                    cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        enrollmentId = Convert.ToInt32(result)
                    Else
                        MessageBox.Show("Enrollment not found for this course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Create a DataTable manually for better control
                Dim gradesTable As New DataTable()
                gradesTable.Columns.Add("Grade Period", GetType(String))
                gradesTable.Columns.Add("Grade", GetType(String))
                gradesTable.Columns.Add("Max Score", GetType(String))
                gradesTable.Columns.Add("Status", GetType(String))

                ' Get the final grades for this enrollment
                Dim gradesQuery As String = "SELECT prelim_grade, midterm_grade, finals_grade, " &
              "overall_numeric_grade, is_passing FROM Final_Grades " &
                 "WHERE enrollment_id = @enrollment_id"

                Using cmd As New MySqlCommand(gradesQuery, connection)
                    cmd.Parameters.AddWithValue("@enrollment_id", enrollmentId)
                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Prelim
                            Dim prelimGrade = If(IsDBNull(reader("prelim_grade")), Nothing, reader("prelim_grade"))
                            Dim prelimRow As DataRow = gradesTable.NewRow()
                            prelimRow("Grade Period") = "Prelim"
                            prelimRow("Grade") = If(prelimGrade Is Nothing, "N/A", prelimGrade.ToString())
                            prelimRow("Max Score") = "100"
                            prelimRow("Status") = If(prelimGrade Is Nothing, "Not Yet Graded",
                               If(Convert.ToDecimal(prelimGrade) >= 75, "Passed", "Failed"))
                            gradesTable.Rows.Add(prelimRow)

                            ' Midterm
                            Dim midtermGrade = If(IsDBNull(reader("midterm_grade")), Nothing, reader("midterm_grade"))
                            Dim midtermRow As DataRow = gradesTable.NewRow()
                            midtermRow("Grade Period") = "Midterm"
                            midtermRow("Grade") = If(midtermGrade Is Nothing, "N/A", midtermGrade.ToString())
                            midtermRow("Max Score") = "100"
                            midtermRow("Status") = If(midtermGrade Is Nothing, "Not Yet Graded",
                         If(Convert.ToDecimal(midtermGrade) >= 75, "Passed", "Failed"))
                            gradesTable.Rows.Add(midtermRow)

                            ' Finals
                            Dim finalsGrade = If(IsDBNull(reader("finals_grade")), Nothing, reader("finals_grade"))
                            Dim finalsRow As DataRow = gradesTable.NewRow()
                            finalsRow("Grade Period") = "Finals"
                            finalsRow("Grade") = If(finalsGrade Is Nothing, "N/A", finalsGrade.ToString())
                            finalsRow("Max Score") = "100"
                            finalsRow("Status") = If(finalsGrade Is Nothing, "Not Yet Graded",
        If(Convert.ToDecimal(finalsGrade) >= 75, "Passed", "Failed"))
                            gradesTable.Rows.Add(finalsRow)

                            ' Overall Grade
                            Dim overallGrade = If(IsDBNull(reader("overall_numeric_grade")), Nothing, reader("overall_numeric_grade"))
                            Dim isPassing = If(IsDBNull(reader("is_passing")), False, Convert.ToBoolean(reader("is_passing")))
                            Dim overallRow As DataRow = gradesTable.NewRow()
                            overallRow("Grade Period") = "Overall Grade"
                            overallRow("Grade") = If(overallGrade Is Nothing, "N/A", overallGrade.ToString())
                            overallRow("Max Score") = "100"
                            overallRow("Status") = If(overallGrade Is Nothing, "Not Yet Graded",
          If(isPassing, "Passed", "Failed"))
                            gradesTable.Rows.Add(overallRow)
                        Else
                            ' No final grades calculated yet - show default rows
                            For Each period As String In {"Prelim", "Midterm", "Finals", "Overall Grade"}
                                Dim row As DataRow = gradesTable.NewRow()
                                row("Grade Period") = period
                                row("Grade") = "N/A"
                                row("Max Score") = "100"
                                row("Status") = "Not Yet Graded"
                                gradesTable.Rows.Add(row)
                            Next
                        End If
                    End Using
                End Using

                ' Bind to DataGridView
                dgvMyGrades.DataSource = gradesTable
                dgvMyGrades.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                ' Apply color coding
                FormatMyGradesGrid()
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

    Private Sub FormatMyGradesGrid()
        Try
            If dgvMyGrades Is Nothing OrElse dgvMyGrades.Rows.Count = 0 Then
                Return
            End If

            For Each row As DataGridViewRow In dgvMyGrades.Rows
                If row.Cells("Status").Value IsNot Nothing Then
                    Dim status As String = row.Cells("Status").Value.ToString()
                    Select Case status
                        Case "Passed"
                            row.Cells("Status").Style.BackColor = Color.LightGreen
                            row.Cells("Status").Style.ForeColor = Color.DarkGreen
                        Case "Failed"
                            row.Cells("Status").Style.BackColor = Color.LightCoral
                            row.Cells("Status").Style.ForeColor = Color.DarkRed
                        Case "Not Yet Graded"
                            row.Cells("Status").Style.BackColor = Color.LightYellow
                            row.Cells("Status").Style.ForeColor = Color.DarkOrange
                    End Select
                End If

                ' Color code the grade column
                If row.Cells("Grade").Value IsNot Nothing Then
                    Dim gradeStr As String = row.Cells("Grade").Value.ToString()
                    If gradeStr <> "N/A" Then
                        Dim gradeValue As Decimal = 0
                        If Decimal.TryParse(gradeStr, gradeValue) Then
                            If gradeValue >= 75 Then
                                row.Cells("Grade").Style.BackColor = Color.LightGreen
                            Else
                                row.Cells("Grade").Style.BackColor = Color.LightCoral
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    ' ============= GRADE SUMMARY METHODS =============

    Private Sub InitializeSemesterFilter()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Fixed: Include all columns needed for ORDER BY in the SELECT when using DISTINCT
                ' Use a subquery to get distinct values then order
                Dim query As String = "SELECT semester_display, semester_value FROM (" +
      "SELECT DISTINCT " +
          "CONCAT(ay.academic_year_name, ' - ', st.type_name) as semester_display, " +
       "CONCAT(ay.academic_year_name, '|', st.type_name) as semester_value, " +
            "ay.year_start, st.display_order " +
      "FROM Enrollments e " +
            "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " +
       "INNER JOIN Semesters s ON co.semester_id = s.semester_id " +
                "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " +
           "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " +
   "WHERE e.student_id = @student_id" +
   ") AS subquery " +
 "ORDER BY year_start DESC, display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@student_id", currentStudentId)
                    Dim semesterTable As New DataTable()
                    adapter.Fill(semesterTable)

                    ' Add "All Semesters" option
                    Dim allRow As DataRow = semesterTable.NewRow()
                    allRow("semester_display") = "-- All Semesters --"
                    allRow("semester_value") = "ALL"
                    semesterTable.Rows.InsertAt(allRow, 0)

                    cmbFilterSemester.DataSource = semesterTable
                    cmbFilterSemester.DisplayMember = "semester_display"
                    cmbFilterSemester.ValueMember = "semester_value"
                    cmbFilterSemester.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading semesters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadGradeSummary_Click(sender As Object, e As EventArgs) Handles btnLoadGradeSummary.Click
        LoadGradeSummary()
        LoadCourseAverages()
    End Sub

    Private Sub btnRefreshGradeSummary_Click(sender As Object, e As EventArgs) Handles btnRefreshGradeSummary.Click
        InitializeSemesterFilter()
        LoadGradeSummary()
        LoadCourseAverages()
        MessageBox.Show("Grade summary refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadGradeSummary()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim semesterValue As String = If(cmbFilterSemester.SelectedValue IsNot Nothing,
     cmbFilterSemester.SelectedValue.ToString(), "ALL")

                ' Build query using direct table joins instead of view
                Dim query As String = "SELECT " +
  "c.course_code AS 'Course Code', " +
      "c.course_name AS 'Course Name', " +
           "co.section AS 'Section', " +
     "CONCAT(ay.academic_year_name, ' - ', st.type_name) AS 'Semester', " +
             "tt.type_name AS 'Term', " +
            "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA') AS 'Instructor', " +
  "c.credits AS 'Units', " +
        "IFNULL(CAST(fg.prelim_grade AS CHAR), 'N/A') AS 'Prelim', " +
                "IFNULL(CAST(fg.midterm_grade AS CHAR), 'N/A') AS 'Midterm', " +
  "IFNULL(CAST(fg.finals_grade AS CHAR), 'N/A') AS 'Finals', " +
          "IFNULL(CAST(fg.overall_numeric_grade AS CHAR), 'N/A') AS 'Final Grade', " +
        "IFNULL(CAST(fg.gpa_points AS CHAR), 'N/A') AS 'GPA Points', " +
        "CASE " +
 "    WHEN fg.overall_numeric_grade IS NULL THEN 'In Progress' " +
               " WHEN fg.is_incomplete = TRUE THEN 'Incomplete' " +
        "    WHEN fg.is_delinquent = TRUE THEN 'Delinquent' " +
   "    WHEN fg.is_passing = TRUE THEN 'Passed' " +
   "    ELSE 'Failed' " +
        "END AS 'Status', " +
       "est.status_name AS 'Enrollment' " +
        "FROM Enrollments e " +
                 "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " +
       "INNER JOIN Courses c ON co.course_id = c.course_id " +
         "INNER JOIN Semesters s ON co.semester_id = s.semester_id " +
           "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " +
  "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " +
       "INNER JOIN Terms t ON co.term_id = t.term_id " +
  "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " +
      "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " +
 "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " +
             "LEFT JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id " +
    "WHERE e.student_id = @student_id"

                ' Add semester filter if not "ALL"
                If semesterValue <> "ALL" AndAlso semesterValue.Contains("|") Then
                    Dim parts() As String = semesterValue.Split("|"c)
                    If parts.Length = 2 Then
                        query &= " AND ay.academic_year_name = @academic_year AND st.type_name = @semester_name"
                    End If
                End If

                query &= " ORDER BY ay.year_start DESC, st.display_order, c.course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@student_id", currentStudentId)

                    If semesterValue <> "ALL" AndAlso semesterValue.Contains("|") Then
                        Dim parts() As String = semesterValue.Split("|"c)
                        If parts.Length = 2 Then
                            adapter.SelectCommand.Parameters.AddWithValue("@academic_year", parts(0))
                            adapter.SelectCommand.Parameters.AddWithValue("@semester_name", parts(1))
                        End If
                    End If

                    Dim summaryTable As New DataTable()
                    adapter.Fill(summaryTable)
                    dgvGradeSummary.DataSource = summaryTable
                    dgvGradeSummary.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                    ' Apply conditional formatting for grade status
                    FormatGradeSummaryGrid()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading grade summary: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGradeSummaryGrid()
        Try
            For Each row As DataGridViewRow In dgvGradeSummary.Rows
                If row.Cells("Status").Value IsNot Nothing Then
                    Dim status As String = row.Cells("Status").Value.ToString()
                    Select Case status
                        Case "Passed"
                            row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200)
                        Case "Failed"
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200)
                        Case "In Progress"
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200)
                        Case "Incomplete"
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 180)
                        Case "Delinquent"
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 180, 180)
                    End Select
                End If
            Next
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    Private Sub LoadCourseAverages()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim semesterValue As String = If(cmbFilterSemester.SelectedValue IsNot Nothing,
       cmbFilterSemester.SelectedValue.ToString(), "ALL")

                ' Calculate course averages using direct table joins
                Dim query As String = "SELECT " +
     "c.course_code AS 'Course Code', " +
      "c.course_name AS 'Course Name', " +
            "c.credits AS 'Units', " +
      "IFNULL(CAST(fg.overall_numeric_grade AS CHAR), 'N/A') AS 'Final Grade', " +
           "IFNULL(CAST(fg.gpa_points AS CHAR), 'N/A') AS 'GPA Points', " +
          "CASE " +
         "    WHEN fg.overall_numeric_grade IS NULL THEN 'In Progress' " +
              "    WHEN fg.is_incomplete = TRUE THEN 'Incomplete' " +
"    WHEN fg.is_delinquent = TRUE THEN 'Delinquent' " +
    "    WHEN fg.is_passing = TRUE THEN 'Passed' " +
         "    ELSE 'Failed' " +
             "END AS 'Status' " +
         "FROM Enrollments e " +
            "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " +
    "INNER JOIN Courses c ON co.course_id = c.course_id " +
               "INNER JOIN Semesters s ON co.semester_id = s.semester_id " +
          "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " +
  "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " +
     "LEFT JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id " +
       "WHERE e.student_id = @student_id"

                ' Add semester filter if not "ALL"
                If semesterValue <> "ALL" AndAlso semesterValue.Contains("|") Then
                    Dim parts() As String = semesterValue.Split("|"c)
                    If parts.Length = 2 Then
                        query &= " AND ay.academic_year_name = @academic_year AND st.type_name = @semester_name"
                    End If
                End If

                query &= " ORDER BY c.course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@student_id", currentStudentId)

                    If semesterValue <> "ALL" AndAlso semesterValue.Contains("|") Then
                        Dim parts() As String = semesterValue.Split("|"c)
                        If parts.Length = 2 Then
                            adapter.SelectCommand.Parameters.AddWithValue("@academic_year", parts(0))
                            adapter.SelectCommand.Parameters.AddWithValue("@semester_name", parts(1))
                        End If
                    End If

                    Dim averagesTable As New DataTable()
                    adapter.Fill(averagesTable)
                    dgvCourseAverages.DataSource = averagesTable
                    dgvCourseAverages.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using

                ' Calculate overall average and GPA
                CalculateOverallAverage(semesterValue)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading course averages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CalculateOverallAverage(semesterValue As String)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Calculate weighted GPA and overall average using Final_Grades table
                Dim query As String = "SELECT " +
    "ROUND(AVG(fg.overall_numeric_grade), 2) AS overall_average, " +
          "ROUND(SUM(fg.gpa_points * c.credits) / NULLIF(SUM(c.credits), 0), 2) AS weighted_gpa, " +
  "SUM(c.credits) AS total_units, " +
          "COUNT(*) AS total_courses, " +
         "SUM(CASE WHEN fg.is_passing = TRUE THEN 1 ELSE 0 END) AS passed_courses, " +
    "SUM(CASE WHEN fg.is_passing = FALSE AND fg.overall_numeric_grade IS NOT NULL THEN 1 ELSE 0 END) AS failed_courses " +
        "FROM Enrollments e " +
      "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " +
       "INNER JOIN Courses c ON co.course_id = c.course_id " +
   "INNER JOIN Semesters s ON co.semester_id = s.semester_id " +
    "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " +
         "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " +
"INNER JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id " +
        "WHERE e.student_id = @student_id " +
    "AND fg.overall_numeric_grade IS NOT NULL"

                ' Add semester filter if not "ALL"
                If semesterValue <> "ALL" AndAlso semesterValue.Contains("|") Then
                    Dim parts() As String = semesterValue.Split("|"c)
                    If parts.Length = 2 Then
                        query &= " AND ay.academic_year_name = @academic_year AND st.type_name = @semester_name"
                    End If
                End If

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@student_id", currentStudentId)

                    If semesterValue <> "ALL" AndAlso semesterValue.Contains("|") Then
                        Dim parts() As String = semesterValue.Split("|"c)
                        If parts.Length = 2 Then
                            cmd.Parameters.AddWithValue("@academic_year", parts(0))
                            cmd.Parameters.AddWithValue("@semester_name", parts(1))
                        End If
                    End If

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim overallAvg As String = If(Not IsDBNull(reader("overall_average")),
       reader("overall_average").ToString(), "N/A")
                            Dim weightedGpa As String = If(Not IsDBNull(reader("weighted_gpa")),
  reader("weighted_gpa").ToString(), "N/A")
                            Dim totalUnits As String = If(Not IsDBNull(reader("total_units")),
      reader("total_units").ToString(), "0")
                            Dim totalCourses As String = If(Not IsDBNull(reader("total_courses")),
        reader("total_courses").ToString(), "0")
                            Dim passedCourses As String = If(Not IsDBNull(reader("passed_courses")),
             reader("passed_courses").ToString(), "0")
                            Dim failedCourses As String = If(Not IsDBNull(reader("failed_courses")),
reader("failed_courses").ToString(), "0")

                            lblOverallAverageDisplay.Text = "Overall Average" & vbCrLf &
         overallAvg & vbCrLf & vbCrLf &
          "GPA: " & weightedGpa & vbCrLf & vbCrLf &
    "Units: " & totalUnits & vbCrLf &
          "Passed: " & passedCourses & "/" & totalCourses
                        Else
                            lblOverallAverageDisplay.Text = "Overall Average" & vbCrLf & vbCrLf &
    "N/A" & vbCrLf & vbCrLf & "GPA: N/A"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblOverallAverageDisplay.Text = "Overall Average" & vbCrLf & vbCrLf & "Error" & vbCrLf & vbCrLf & "GPA: Error"
        End Try
    End Sub

    Private Sub StudentDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        login.ClearUserSession()
        Dim loginForm As New login()
        loginForm.Show()
    End Sub
End Class
