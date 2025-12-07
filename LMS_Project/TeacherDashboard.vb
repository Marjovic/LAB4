Imports MySql.Data.MySqlClient

Public Class TeacherDashboard
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current instructor ID
    Private currentInstructorId As Integer = 0

    Private Sub TeacherDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form title with current user info
        Me.Text = $"Teacher Dashboard - Welcome {login.CurrentUsername}"

        ' Set welcome message
        lblWelcome.Text = $"Welcome, {login.CurrentUsername}"

        ' Get the instructor ID for the current user
        GetCurrentInstructorId()

        ' Load dashboard statistics
        LoadDashboardStats()
        LoadCourseOverview()
        LoadAlerts()

        ' Initialize course offering dropdown
        InitializeCourseOfferingDropdown()

        ' Add event handlers
        AddHandler txtStudentSearch.TextChanged, AddressOf txtStudentSearch_TextChanged
        AddHandler cmbCourseOffering.SelectedIndexChanged, AddressOf cmbCourseOffering_SelectedIndexChanged
        AddHandler cmbGradingPeriod.SelectedIndexChanged, AddressOf cmbGradingPeriod_SelectedIndexChanged

        ' Show dashboard by default
        ShowPanel(pnlDashboard)
        SetActiveButton(btnDashboard)
    End Sub

    ' Get the instructor ID for the current logged-in user
    Private Sub GetCurrentInstructorId()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT i.instructor_id FROM Instructors i " &
                      "INNER JOIN Users u ON i.user_id = u.user_id " &
              "WHERE u.username = @username"
                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@username", login.CurrentUsername)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not IsDBNull(result) Then
                        currentInstructorId = Convert.ToInt32(result)
                    Else
                        MessageBox.Show("Unable to find instructor profile for the current user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error getting instructor ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlDashboard.Visible = False
        pnlCalculateGrade.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnDashboard.BackColor = Color.FromArgb(45, 45, 48)
        btnEnrollmentManagement.BackColor = Color.FromArgb(45, 45, 48)
        btnCalculateGrade.BackColor = Color.FromArgb(45, 45, 48)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(pnlDashboard)
        SetActiveButton(btnDashboard)
        LoadDashboardStats()
        LoadCourseOverview()
        LoadAlerts()
    End Sub

    Private Sub btnEnrollmentManagement_Click(sender As Object, e As EventArgs) Handles btnEnrollmentManagement.Click
        SetActiveButton(btnEnrollmentManagement)
        Dim enrollmentForm As New EnrollStudent()
        enrollmentForm.ShowDialog()
    End Sub

    Private Sub btnCalculateGrade_Click(sender As Object, e As EventArgs) Handles btnCalculateGrade.Click
        ShowPanel(pnlCalculateGrade)
        SetActiveButton(btnCalculateGrade)
        ' Refresh dropdown
        InitializeCourseOfferingDropdown()
        ClearGradeForm()
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

    Private Sub LoadDashboardStats()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Try to use TeacherCourseOverview for comprehensive stats
                Dim useView As Boolean = CheckViewExists(connection, "TeacherCourseOverview")

                If useView Then
                    ' Get comprehensive stats from view (remove semester filter)
                    Dim statsQuery As String = "SELECT " &
     "COUNT(DISTINCT offering_id) as total_courses, " &
   "COALESCE(SUM(total_enrolled), 0) as total_students, " &
             "COALESCE(ROUND(AVG(class_average), 2), 0) as overall_average, " &
  "COALESCE(SUM(students_pending_grade), 0) as pending_grades, " &
     "SUM(CASE WHEN high_failure_rate_alert = TRUE THEN 1 ELSE 0 END) as courses_with_alerts " &
     "FROM TeacherCourseOverview " &
           "WHERE instructor_id = @instructor_id"

                    Using cmd As New MySqlCommand(statsQuery, connection)
                        cmd.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                        Using reader = cmd.ExecuteReader()
                            If reader.Read() Then
                                Dim totalCourses As Integer = Convert.ToInt32(reader("total_courses"))
                                Dim totalStudents As Integer = Convert.ToInt32(reader("total_students"))
                                Dim overallAverage As Decimal = If(IsDBNull(reader("overall_average")), 0, Convert.ToDecimal(reader("overall_average")))
                                Dim pendingGrades As Integer = Convert.ToInt32(reader("pending_grades"))

                                lblTotalCourses.Text = "My Courses" & vbCrLf & totalCourses.ToString()
                                lblTotalStudents.Text = "Total Students" & vbCrLf & totalStudents.ToString()
                                lblActiveSemesters.Text = "Class Average" & vbCrLf & overallAverage.ToString("F2") & "%"
                            End If
                        End Using
                    End Using
                Else
                    ' Fallback to basic queries
                    LoadBasicDashboardStats(connection)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading dashboard statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadBasicDashboardStats(connection As MySqlConnection)
        ' Get total courses assigned to this instructor
        Dim courseQuery As String = "SELECT COUNT(DISTINCT co.course_id) FROM Course_Offerings co " &
          "WHERE co.instructor_id = @instructor_id AND co.offering_status IN ('Open', 'Full')"
        Using cmd As New MySqlCommand(courseQuery, connection)
            cmd.Parameters.AddWithValue("@instructor_id", currentInstructorId)
            Dim totalCourses As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            lblTotalCourses.Text = "My Courses" & vbCrLf & totalCourses.ToString()
        End Using

        ' Get total students enrolled in instructor's courses
        Dim studentQuery As String = "SELECT COUNT(DISTINCT e.student_id) FROM Enrollments e " &
        "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " &
         "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " &
          "WHERE co.instructor_id = @instructor_id AND est.status_name = 'Enrolled'"
        Using cmd As New MySqlCommand(studentQuery, connection)
            cmd.Parameters.AddWithValue("@instructor_id", currentInstructorId)
            Dim totalStudents As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            lblTotalStudents.Text = "Total Students" & vbCrLf & totalStudents.ToString()
        End Using

        ' Get active semesters count
        Dim semesterQuery As String = "SELECT COUNT(*) FROM Semesters WHERE is_active = TRUE"
        Using cmd As New MySqlCommand(semesterQuery, connection)
            Dim activeSemesters As Integer = Convert.ToInt32(cmd.ExecuteScalar())
            lblActiveSemesters.Text = "Active Semesters" & vbCrLf & activeSemesters.ToString()
        End Using
    End Sub

    Private Sub LoadCourseOverview()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check if view exists
                If Not CheckViewExists(connection, "TeacherCourseOverview") Then
                    ' If view doesn't exist, hide the course overview grid or show basic data
                    If dgvCourseOverview IsNot Nothing Then
                        dgvCourseOverview.DataSource = Nothing
                    End If
                    Return
                End If

                ' Load course overview from view
                Dim query As String = "SELECT " &
   "course_code as 'Course Code', " &
      "course_name as 'Course Name', " &
       "section as 'Section', " &
             "CONCAT(semester_name, ' ', academic_year_name) as 'Semester', " &
  "total_enrolled as 'Enrolled', " &
   "max_students as 'Capacity', " &
        "COALESCE(ROUND(class_average, 2), 'N/A') as 'Class Avg', " &
          "COALESCE(passing_count, 0) as 'Passing', " &
"COALESCE(failing_count, 0) as 'Failing', " &
         "COALESCE(CONCAT(ROUND(passing_rate, 1), '%'), 'N/A') as 'Pass Rate', " &
          "students_pending_grade as 'Pending Grades', " &
 "current_grading_period as 'Current Period' " &
           "FROM TeacherCourseOverview " &
    "WHERE instructor_id = @instructor_id " &
  "ORDER BY academic_year_name DESC, semester_code, course_code, section"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    Dim courseTable As New DataTable()
                    adapter.Fill(courseTable)

                    If dgvCourseOverview IsNot Nothing Then
                        If courseTable.Rows.Count = 0 Then
                            ' No courses found - show message
                            MessageBox.Show("No course offerings found for your account." & vbCrLf & vbCrLf &
           "This could mean:" & vbCrLf &
    "1. You haven't been assigned any courses yet" & vbCrLf &
      "2. Your course offerings are not yet created in the system" & vbCrLf & vbCrLf &
  "Please contact your administrator if this is incorrect.",
    "No Courses Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If

                        dgvCourseOverview.DataSource = courseTable

                        ' Set font size for the grid
                        dgvCourseOverview.DefaultCellStyle.Font = New Font("Times New Roman", 10.0F)
                        dgvCourseOverview.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 10.0F, FontStyle.Bold)
                        dgvCourseOverview.RowTemplate.Height = 28

                        dgvCourseOverview.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                        ' Color code the Alert column
                        FormatCourseOverviewGrid()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading course overview: {ex.Message}" & vbCrLf & vbCrLf &
    "Details: " & ex.StackTrace,
       "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine($"Error loading course overview: {ex.Message}")
        End Try
    End Sub

    Private Sub FormatCourseOverviewGrid()
        If dgvCourseOverview Is Nothing OrElse dgvCourseOverview.Rows.Count = 0 Then
            Return
        End If

        For Each row As DataGridViewRow In dgvCourseOverview.Rows
            ' Color code based on pass rate
          If row.Cells("Pass Rate").Value IsNot Nothing Then
     Dim passRateStr As String = row.Cells("Pass Rate").Value.ToString().Replace("%", "")
    Dim passRate As Decimal = 0
         If Decimal.TryParse(passRateStr, passRate) Then
If passRate < 60 Then
      row.Cells("Pass Rate").Style.BackColor = Color.LightCoral
               row.Cells("Pass Rate").Style.ForeColor = Color.DarkRed
      ElseIf passRate >= 80 Then
    row.Cells("Pass Rate").Style.BackColor = Color.LightGreen
  row.Cells("Pass Rate").Style.ForeColor = Color.DarkGreen
               End If
            End If
         End If

      ' Color code pending grades
            If row.Cells("Pending Grades").Value IsNot Nothing Then
      Dim pending As Integer = 0
          If Integer.TryParse(row.Cells("Pending Grades").Value.ToString(), pending) Then
            If pending > 0 Then
   row.Cells("Pending Grades").Style.BackColor = Color.LightYellow
      row.Cells("Pending Grades").Style.ForeColor = Color.DarkOrange
        End If
     End If
            End If
        Next
  End Sub

    Private Sub LoadAlerts()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check if view exists
                If Not CheckViewExists(connection, "TeacherCourseOverview") Then
                    If lblAlerts IsNot Nothing Then
                        lblAlerts.Text = "No alerts"
                        lblAlerts.ForeColor = Color.Green
                    End If
                    Return
                End If

                Dim alerts As New List(Of String)

                ' Check for high failure rates (remove semester filter)
                Dim failureQuery As String = "SELECT course_code, section, passing_rate " &
         "FROM TeacherCourseOverview " &
   "WHERE instructor_id = @instructor_id AND high_failure_rate_alert = TRUE"
                Using cmd As New MySqlCommand(failureQuery, connection)
                    cmd.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim courseCode As String = reader("course_code").ToString()
                            Dim section As String = reader("section").ToString()
                            Dim passRate As Decimal = If(IsDBNull(reader("passing_rate")), 0, Convert.ToDecimal(reader("passing_rate")))
                            alerts.Add($"⚠️ {courseCode} (Section {section}): High failure rate - {passRate:F1}% passing")
                        End While
                    End Using
                End Using

                ' Check for pending grades (remove semester filter)
                Dim pendingQuery As String = "SELECT course_code, section, students_pending_grade " &
            "FROM TeacherCourseOverview " &
      "WHERE instructor_id = @instructor_id AND students_pending_grade > 0"
                Using cmd As New MySqlCommand(pendingQuery, connection)
                    cmd.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim courseCode As String = reader("course_code").ToString()
                            Dim section As String = reader("section").ToString()
                            Dim pending As Integer = Convert.ToInt32(reader("students_pending_grade"))
                            alerts.Add($"📝 {courseCode} (Section {section}): {pending} students need grades")
                        End While
                    End Using
                End Using

                ' Check for low enrollment (remove semester filter)
                Dim enrollmentQuery As String = "SELECT course_code, section, enrollment_percentage " &
          "FROM TeacherCourseOverview " &
   "WHERE instructor_id = @instructor_id AND low_enrollment_alert = TRUE"
                Using cmd As New MySqlCommand(enrollmentQuery, connection)
                    cmd.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim courseCode As String = reader("course_code").ToString()
                            Dim section As String = reader("section").ToString()
                            Dim enrollment As Decimal = If(IsDBNull(reader("enrollment_percentage")), 0, Convert.ToDecimal(reader("enrollment_percentage")))
                            alerts.Add($"📉 {courseCode} (Section {section}): Low enrollment - {enrollment:F1}%")
                        End While
                    End Using
                End Using

                ' Display alerts
                If lblAlerts IsNot Nothing Then
                    If alerts.Count > 0 Then
                        lblAlerts.Text = String.Join(vbCrLf, alerts.Take(5)) ' Show max 5 alerts
                        lblAlerts.ForeColor = Color.DarkOrange
                    Else
                        lblAlerts.Text = "✓ No alerts - All courses are performing well!"
                        lblAlerts.ForeColor = Color.Green
                    End If
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error loading alerts: {ex.Message}")
        End Try
    End Sub

    Private Function CheckViewExists(connection As MySqlConnection, viewName As String) As Boolean
        Try
            Dim query As String = "SELECT COUNT(*) FROM information_schema.VIEWS " &
       "WHERE TABLE_SCHEMA = DATABASE() AND TABLE_NAME = @viewName"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@viewName", viewName)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count > 0
            End Using
        Catch
            Return False
        End Try
    End Function

    ' ============= CALCULATE GRADE METHODS =============

    Private Sub InitializeCourseOfferingDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Get course offerings assigned to this instructor
                Dim query As String = "SELECT co.offering_id, " &
                      "CONCAT(c.course_code, ' - ', c.course_name, ' (Section: ', co.section, ' - ', " &
                           "ay.academic_year_name, ' ', st.type_name, ')') as display_name, " &
                   "ay.year_start, c.course_code " &
                                    "FROM Course_Offerings co " &
                 "INNER JOIN Courses c ON co.course_id = c.course_id " &
                        "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
                   "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                                    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                        "WHERE co.instructor_id = @instructor_id " &
                             "AND co.offering_status IN ('Open', 'Full') " &
                     "GROUP BY co.offering_id, display_name, ay.year_start, c.course_code " &
                     "ORDER BY ay.year_start DESC, c.course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@instructor_id", currentInstructorId)
                    Dim courseTable As New DataTable()
                    adapter.Fill(courseTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = courseTable.NewRow()
                    emptyRow("offering_id") = DBNull.Value
                    emptyRow("display_name") = "-- Select Course Offering --"
                    courseTable.Rows.InsertAt(emptyRow, 0)

                    cmbCourseOffering.DataSource = courseTable
                    cmbCourseOffering.DisplayMember = "display_name"
                    cmbCourseOffering.ValueMember = "offering_id"
                    cmbCourseOffering.SelectedIndex = 0
                End Using
            End Using

            ' Clear dependent dropdowns
            ClearGradingPeriodDropdown()
            ClearAssignmentTypeDropdown()

        Catch ex As Exception
            MessageBox.Show($"Error loading course offerings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Event handler when Course Offering selection changes
    Private Sub cmbCourseOffering_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbCourseOffering.SelectedValue Is Nothing OrElse IsDBNull(cmbCourseOffering.SelectedValue) Then
            ClearGradingPeriodDropdown()
            ClearAssignmentTypeDropdown()
            grpStudentGrades.Visible = False
            Return
        End If

        ' Load grading periods available for this course offering
        LoadGradingPeriodsForOffering()
        ClearAssignmentTypeDropdown()
        grpStudentGrades.Visible = False
    End Sub

    ' Event handler when Grading Period selection changes
    Private Sub cmbGradingPeriod_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbGradingPeriod.SelectedValue Is Nothing OrElse IsDBNull(cmbGradingPeriod.SelectedValue) OrElse
           cmbCourseOffering.SelectedValue Is Nothing OrElse IsDBNull(cmbCourseOffering.SelectedValue) Then
            ClearAssignmentTypeDropdown()
            grpStudentGrades.Visible = False
            Return
        End If

        ' Load assignment types available for this course offering and grading period
        LoadAssignmentTypesForOfferingAndPeriod()
        grpStudentGrades.Visible = False
    End Sub

    Private Sub ClearGradingPeriodDropdown()
        Dim emptyTable As New DataTable()
        emptyTable.Columns.Add("period_id", GetType(Object))
        emptyTable.Columns.Add("display_name", GetType(String))
        Dim emptyRow As DataRow = emptyTable.NewRow()
        emptyRow("period_id") = DBNull.Value
        emptyRow("display_name") = "-- Select Course First --"
        emptyTable.Rows.Add(emptyRow)

        cmbGradingPeriod.DataSource = emptyTable
        cmbGradingPeriod.DisplayMember = "display_name"
        cmbGradingPeriod.ValueMember = "period_id"
    End Sub

    Private Sub ClearAssignmentTypeDropdown()
        Dim emptyTable As New DataTable()
        emptyTable.Columns.Add("type_id", GetType(Object))
        emptyTable.Columns.Add("display_name", GetType(String))
        Dim emptyRow As DataRow = emptyTable.NewRow()
        emptyRow("type_id") = DBNull.Value
        emptyRow("display_name") = "-- Select Period First --"
        emptyTable.Rows.Add(emptyRow)

        cmbAssignmentType.DataSource = emptyTable
        cmbAssignmentType.DisplayMember = "display_name"
        cmbAssignmentType.ValueMember = "type_id"
    End Sub

    Private Sub LoadGradingPeriodsForOffering()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim offeringId As Integer = Convert.ToInt32(cmbCourseOffering.SelectedValue)

                ' Get grading periods that have weights configured for this offering
                Dim query As String = "SELECT gp.period_id, " &
        "CONCAT(gp.period_code, ' - ', gp.period_name, ' (', gp.period_weight, '%)') as display_name, " &
              "gp.display_order " &
        "FROM Grading_Periods gp " &
  "INNER JOIN Offering_Grading_Weights ogw ON gp.period_id = ogw.period_id " &
         "WHERE ogw.offering_id = @offering_id " &
              "GROUP BY gp.period_id, display_name, gp.display_order " &
         "ORDER BY gp.display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@offering_id", offeringId)
                    Dim periodTable As New DataTable()
                    adapter.Fill(periodTable)

                    If periodTable.Rows.Count = 0 Then
                        ' No configured periods - show message
                        periodTable.Columns.Add("period_id", GetType(Object))
                        periodTable.Columns.Add("display_name", GetType(String))
                        Dim emptyRow As DataRow = periodTable.NewRow()
                        emptyRow("period_id") = DBNull.Value
                        emptyRow("display_name") = "-- No Grade Weights Configured --"
                        periodTable.Rows.Add(emptyRow)

                        cmbGradingPeriod.DataSource = periodTable
                        cmbGradingPeriod.DisplayMember = "display_name"
                        cmbGradingPeriod.ValueMember = "period_id"

                        MessageBox.Show("No grade weights have been configured for this course offering." & vbCrLf & vbCrLf &
                                 "Please use the 'Offering Grade Weight' management screen to set up grade weights for:" & vbCrLf &
                          "- Each Grading Period (Prelim, Midterm, Finals)" & vbCrLf &
               "- Each Assignment Type (Quiz, Assignments, Exam, Labs, Participation)",
                "Configuration Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Return
                    End If

                    ' Add empty row for selection
                    Dim selectRow As DataRow = periodTable.NewRow()
                    selectRow("period_id") = DBNull.Value
                    selectRow("display_name") = "-- Select Grading Period --"
                    periodTable.Rows.InsertAt(selectRow, 0)

                    cmbGradingPeriod.DataSource = periodTable
                    cmbGradingPeriod.DisplayMember = "display_name"
                    cmbGradingPeriod.ValueMember = "period_id"
                    cmbGradingPeriod.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading grading periods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAssignmentTypesForOfferingAndPeriod()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim offeringId As Integer = Convert.ToInt32(cmbCourseOffering.SelectedValue)
                Dim periodId As Integer = Convert.ToInt32(cmbGradingPeriod.SelectedValue)

                ' Get assignment types that have weights configured for this offering and period
                Dim query As String = "SELECT at.type_id, " &
                 "CONCAT(at.type_code, ' - ', at.type_name, ' (Weight: ', ogw.custom_weight, '%, Max: ', ogw.max_score, ')') as display_name " &
                   "FROM AssignmentTypes at " &
                        "INNER JOIN Offering_Grading_Weights ogw ON at.type_id = ogw.type_id " &
                     "WHERE ogw.offering_id = @offering_id AND ogw.period_id = @period_id " &
                   "AND at.is_active = TRUE " &
                     "ORDER BY at.display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@offering_id", offeringId)
                    adapter.SelectCommand.Parameters.AddWithValue("@period_id", periodId)
                    Dim typeTable As New DataTable()
                    adapter.Fill(typeTable)

                    If typeTable.Rows.Count = 0 Then
                        ' No configured types for this period
                        Dim emptyTable As New DataTable()
                        emptyTable.Columns.Add("type_id", GetType(Object))
                        emptyTable.Columns.Add("display_name", GetType(String))
                        Dim emptyRow As DataRow = emptyTable.NewRow()
                        emptyRow("type_id") = DBNull.Value
                        emptyRow("display_name") = "-- No Types for This Period --"
                        emptyTable.Rows.Add(emptyRow)

                        cmbAssignmentType.DataSource = emptyTable
                        cmbAssignmentType.DisplayMember = "display_name"
                        cmbAssignmentType.ValueMember = "type_id"
                        Return
                    End If

                    ' Add empty row for selection
                    Dim selectRow As DataRow = typeTable.NewRow()
                    selectRow("type_id") = DBNull.Value
                    selectRow("display_name") = "-- Select Assignment Type --"
                    typeTable.Rows.InsertAt(selectRow, 0)

                    cmbAssignmentType.DataSource = typeTable
                    cmbAssignmentType.DisplayMember = "display_name"
                    cmbAssignmentType.ValueMember = "type_id"
                    cmbAssignmentType.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading assignment types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadStudents_Click(sender As Object, e As EventArgs) Handles btnLoadStudents.Click
        ' Validate selections
        If cmbCourseOffering.SelectedValue Is Nothing OrElse IsDBNull(cmbCourseOffering.SelectedValue) Then
            MessageBox.Show("Please select a course offering.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbGradingPeriod.SelectedValue Is Nothing OrElse IsDBNull(cmbGradingPeriod.SelectedValue) Then
            MessageBox.Show("Please select a grading period.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbAssignmentType.SelectedValue Is Nothing OrElse IsDBNull(cmbAssignmentType.SelectedValue) Then
            MessageBox.Show("Please select an assignment type.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        LoadStudentGrades()
        LoadStudentDropdown()
        grpStudentGrades.Visible = True
    End Sub

    Private Function GetGradeWeightInfo() As (Weight As Decimal, MaxScore As Decimal)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim offeringId As Integer = Convert.ToInt32(cmbCourseOffering.SelectedValue)
                Dim periodId As Integer = Convert.ToInt32(cmbGradingPeriod.SelectedValue)
                Dim typeId As Integer = Convert.ToInt32(cmbAssignmentType.SelectedValue)

                Dim query As String = "SELECT custom_weight, max_score FROM Offering_Grading_Weights " &
             "WHERE offering_id = @offering_id AND period_id = @period_id AND type_id = @type_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@offering_id", offeringId)
                    cmd.Parameters.AddWithValue("@period_id", periodId)
                    cmd.Parameters.AddWithValue("@type_id", typeId)

                    Using reader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Return (Convert.ToDecimal(reader("custom_weight")), Convert.ToDecimal(reader("max_score")))
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Error getting grade weight info: {ex.Message}")
        End Try

        Return (0D, 100D) ' Default values
    End Function

    Private Sub LoadStudentGrades()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim offeringId As Integer = Convert.ToInt32(cmbCourseOffering.SelectedValue)
                Dim periodId As Integer = Convert.ToInt32(cmbGradingPeriod.SelectedValue)
                Dim typeId As Integer = Convert.ToInt32(cmbAssignmentType.SelectedValue)

                ' Get the term_id from the course offering
                Dim termId As Integer = 0
                Dim getTermQuery As String = "SELECT term_id FROM Course_Offerings WHERE offering_id = @offering_id"
                Using termCmd As New MySqlCommand(getTermQuery, connection)
                    termCmd.Parameters.AddWithValue("@offering_id", offeringId)
                    Dim termResult = termCmd.ExecuteScalar()
                    If termResult IsNot Nothing AndAlso Not IsDBNull(termResult) Then
                        termId = Convert.ToInt32(termResult)
                    End If
                End Using

                ' Get grade weight info for display
                Dim weightInfo = GetGradeWeightInfo()

                ' Get assignment type name for display
                Dim typeName As String = ""
                Dim getTypeQuery As String = "SELECT type_name FROM AssignmentTypes WHERE type_id = @type_id"
                Using typeCmd As New MySqlCommand(getTypeQuery, connection)
                    typeCmd.Parameters.AddWithValue("@type_id", typeId)
                    Dim typeResult = typeCmd.ExecuteScalar()
                    If typeResult IsNot Nothing Then
                        typeName = typeResult.ToString()
                    End If
                End Using

                ' Get grading period name for display
                Dim periodName As String = ""
                Dim getPeriodQuery As String = "SELECT period_name FROM Grading_Periods WHERE period_id = @period_id"
                Using periodCmd As New MySqlCommand(getPeriodQuery, connection)
                    periodCmd.Parameters.AddWithValue("@period_id", periodId)
                    Dim periodResult = periodCmd.ExecuteScalar()
                    If periodResult IsNot Nothing Then
                        periodName = periodResult.ToString()
                    End If
                End Using

                ' Load students and their grades
                Dim query As String = "SELECT " &
   "s.student_id as 'Student ID', " &
      "e.enrollment_id as 'Enrollment ID', " &
  "s.student_number as 'Student Number', " &
       "CONCAT(s.first_name, ' ', s.last_name) as 'Student Name', " &
       $"'{periodName}' as 'Period', " &
    $"'{typeName}' as 'Type', " &
             "IFNULL(g.numeric_grade, 'N/A') as 'Score', " &
           $"'{weightInfo.MaxScore}' as 'Max Score', " &
            $"'{weightInfo.Weight}%' as 'Weight', " &
                    "IFNULL(g.notes, '') as 'Notes', " &
          "IFNULL(DATE_FORMAT(g.grade_date, '%Y-%m-%d'), 'Not Graded') as 'Grade Date' " &
          "FROM Enrollments e " &
      "INNER JOIN Students s ON e.student_id = s.student_id " &
        "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " &
               "LEFT JOIN Term_Grading_Periods tgp ON tgp.term_id = @term_id AND tgp.period_id = @period_id " &
         "LEFT JOIN Grades g ON g.enrollment_id = e.enrollment_id " &
          "    AND g.term_period_id = tgp.term_period_id " &
                  "    AND g.type_id = @type_id " &
        "WHERE e.offering_id = @offering_id " &
         "AND est.status_name = 'Enrolled' " &
  "ORDER BY s.last_name, s.first_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@offering_id", offeringId)
                    adapter.SelectCommand.Parameters.AddWithValue("@term_id", termId)
                    adapter.SelectCommand.Parameters.AddWithValue("@period_id", periodId)
                    adapter.SelectCommand.Parameters.AddWithValue("@type_id", typeId)

                    Dim gradesTable As New DataTable()
                    adapter.Fill(gradesTable)
                    dgvStudentGrades.DataSource = gradesTable
                    dgvStudentGrades.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                    ' Hide the ID columns
                    If dgvStudentGrades.Columns.Contains("Student ID") Then
                        dgvStudentGrades.Columns("Student ID").Visible = False
                    End If
                    If dgvStudentGrades.Columns.Contains("Enrollment ID") Then
                        dgvStudentGrades.Columns("Enrollment ID").Visible = False
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading student grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStudentDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim offeringId As Integer = Convert.ToInt32(cmbCourseOffering.SelectedValue)

                Dim query As String = "SELECT s.student_id, " &
  "CONCAT(s.student_number, ' - ', s.first_name, ' ', s.last_name) as display_name " &
               "FROM Enrollments e " &
     "INNER JOIN Students s ON e.student_id = s.student_id " &
     "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " &
    "WHERE e.offering_id = @offering_id " &
           "AND est.status_name = 'Enrolled' " &
     "ORDER BY s.last_name, s.first_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@offering_id", offeringId)

                    Dim studentTable As New DataTable()
                    adapter.Fill(studentTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = studentTable.NewRow()
                    emptyRow("student_id") = DBNull.Value
                    emptyRow("display_name") = "-- Select Student --"
                    studentTable.Rows.InsertAt(emptyRow, 0)

                    cmbSelectStudent.DataSource = studentTable
                    cmbSelectStudent.DisplayMember = "display_name"
                    cmbSelectStudent.ValueMember = "student_id"
                    cmbSelectStudent.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtStudentSearch_TextChanged(sender As Object, e As EventArgs)
        ' Filter the student dropdown based on search text
        If cmbSelectStudent.DataSource Is Nothing Then Return
        If cmbCourseOffering.SelectedValue Is Nothing OrElse IsDBNull(cmbCourseOffering.SelectedValue) Then Return

        Dim searchText As String = txtStudentSearch.Text.Trim().ToLower()

        If String.IsNullOrEmpty(searchText) Then
            LoadStudentDropdown()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim offeringId As Integer = Convert.ToInt32(cmbCourseOffering.SelectedValue)

                Dim query As String = "SELECT s.student_id, " &
          "CONCAT(s.student_number, ' - ', s.first_name, ' ', s.last_name) as display_name " &
       "FROM Enrollments e " &
      "INNER JOIN Students s ON e.student_id = s.student_id " &
        "INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id " &
        "WHERE e.offering_id = @offering_id " &
   "AND est.status_name = 'Enrolled' " &
         "AND (LOWER(s.first_name) LIKE @search OR LOWER(s.last_name) LIKE @search OR s.student_number LIKE @search) " &
     "ORDER BY s.last_name, s.first_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@offering_id", offeringId)
                    adapter.SelectCommand.Parameters.AddWithValue("@search", $"%{searchText}%")

                    Dim studentTable As New DataTable()
                    adapter.Fill(studentTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = studentTable.NewRow()
                    emptyRow("student_id") = DBNull.Value
                    emptyRow("display_name") = "-- Select Student --"
                    studentTable.Rows.InsertAt(emptyRow, 0)

                    cmbSelectStudent.DataSource = studentTable
                    cmbSelectStudent.DisplayMember = "display_name"
                    cmbSelectStudent.ValueMember = "student_id"
                    cmbSelectStudent.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine($"Search error: {ex.Message}")
        End Try
    End Sub

    Private Sub btnSaveGrade_Click(sender As Object, e As EventArgs) Handles btnSaveGrade.Click
        ' Validate selections
        If cmbSelectStudent.SelectedValue Is Nothing OrElse IsDBNull(cmbSelectStudent.SelectedValue) Then
            MessageBox.Show("Please select a student.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate grade value
        Dim gradeValue As Decimal = 0
        If Not Decimal.TryParse(txtGradeValue.Text.Trim(), gradeValue) Then
            MessageBox.Show("Please enter a valid numeric grade value.", "Invalid Grade", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtGradeValue.Focus()
            Return
        End If

        ' Get max score for validation
        Dim weightInfo = GetGradeWeightInfo()
        Dim maxScore As Decimal = weightInfo.MaxScore

        ' Validate grade range (0 to max score)
        If gradeValue < 0 OrElse gradeValue > maxScore Then
            MessageBox.Show($"Grade value must be between 0 and {maxScore}.", "Invalid Grade Range", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtGradeValue.Focus()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim offeringId As Integer = Convert.ToInt32(cmbCourseOffering.SelectedValue)
                Dim periodId As Integer = Convert.ToInt32(cmbGradingPeriod.SelectedValue)
                Dim typeId As Integer = Convert.ToInt32(cmbAssignmentType.SelectedValue)
                Dim studentId As Integer = Convert.ToInt32(cmbSelectStudent.SelectedValue)

                ' Get term_id from the course offering
                Dim termId As Integer = 0
                Dim getTermQuery As String = "SELECT term_id FROM Course_Offerings WHERE offering_id = @offering_id"
                Using termCmd As New MySqlCommand(getTermQuery, connection)
                    termCmd.Parameters.AddWithValue("@offering_id", offeringId)
                    Dim termResult = termCmd.ExecuteScalar()
                    If termResult IsNot Nothing AndAlso Not IsDBNull(termResult) Then
                        termId = Convert.ToInt32(termResult)
                    End If
                End Using

                ' Get term_period_id
                Dim termPeriodId As Integer = 0
                Dim getTermPeriodQuery As String = "SELECT term_period_id FROM Term_Grading_Periods " &
"WHERE term_id = @term_id AND period_id = @period_id"
                Using tpCmd As New MySqlCommand(getTermPeriodQuery, connection)
                    tpCmd.Parameters.AddWithValue("@term_id", termId)
                    tpCmd.Parameters.AddWithValue("@period_id", periodId)
                    Dim tpResult = tpCmd.ExecuteScalar()
                    If tpResult IsNot Nothing AndAlso Not IsDBNull(tpResult) Then
                        termPeriodId = Convert.ToInt32(tpResult)
                    Else
                        MessageBox.Show("No grading period configuration found for this term. Please contact the administrator.",
         "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Get enrollment_id for this student and offering
                Dim enrollmentId As Integer = 0
                Dim getEnrollmentQuery As String = "SELECT enrollment_id FROM Enrollments WHERE offering_id = @offering_id AND student_id = @student_id"
                Using cmd As New MySqlCommand(getEnrollmentQuery, connection)
                    cmd.Parameters.AddWithValue("@offering_id", offeringId)
                    cmd.Parameters.AddWithValue("@student_id", studentId)
                    Dim result = cmd.ExecuteScalar()
                    If result IsNot Nothing Then
                        enrollmentId = Convert.ToInt32(result)
                    Else
                        MessageBox.Show("Enrollment not found for the selected student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using

                ' Calculate percentage 
                Dim percentage As Decimal = (gradeValue / maxScore) * 100

                ' Check if grade already exists
                Dim checkQuery As String = "SELECT grade_id FROM Grades " &
     "WHERE enrollment_id = @enrollment_id AND term_period_id = @term_period_id AND type_id = @type_id"
                Dim existingGradeId As Integer = 0
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@enrollment_id", enrollmentId)
                    checkCmd.Parameters.AddWithValue("@term_period_id", termPeriodId)
                    checkCmd.Parameters.AddWithValue("@type_id", typeId)
                    Dim checkResult = checkCmd.ExecuteScalar()
                    If checkResult IsNot Nothing Then
                        existingGradeId = Convert.ToInt32(checkResult)
                    End If
                End Using

                If existingGradeId > 0 Then
                    ' UPDATE existing grade
                    Dim updateQuery As String = "UPDATE Grades SET " &
            "numeric_grade = @numeric_grade, " &
         "notes = @notes, " &
        "graded_by = @graded_by, " &
   "grade_date = CURDATE(), " &
        "updated_at = NOW() " &
   "WHERE grade_id = @grade_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@numeric_grade", gradeValue)
                        updateCmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(txtRemarks.Text), DBNull.Value, txtRemarks.Text.Trim()))
                        updateCmd.Parameters.AddWithValue("@graded_by", currentInstructorId)
                        updateCmd.Parameters.AddWithValue("@grade_id", existingGradeId)
                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show($"Grade updated successfully!" & vbCrLf & vbCrLf &
     $"Student: {cmbSelectStudent.Text}" & vbCrLf &
     $"Grading Period: {cmbGradingPeriod.Text}" & vbCrLf &
      $"Assignment Type: {cmbAssignmentType.Text}" & vbCrLf &
       $"Score: {gradeValue}/{maxScore}" & vbCrLf &
         $"Percentage: {percentage:F2}%",
     "Grade Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' INSERT new grade
                    Dim insertQuery As String = "INSERT INTO Grades " &
      "(enrollment_id, term_period_id, type_id, numeric_grade, grade_date, graded_by, notes, created_at) " &
       "VALUES (@enrollment_id, @term_period_id, @type_id, @numeric_grade, CURDATE(), @graded_by, @notes, NOW())"

                    Using insertCmd As New MySqlCommand(insertQuery, connection)
                        insertCmd.Parameters.AddWithValue("@enrollment_id", enrollmentId)
                        insertCmd.Parameters.AddWithValue("@term_period_id", termPeriodId)
                        insertCmd.Parameters.AddWithValue("@type_id", typeId)
                        insertCmd.Parameters.AddWithValue("@numeric_grade", gradeValue)
                        insertCmd.Parameters.AddWithValue("@graded_by", currentInstructorId)
                        insertCmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(txtRemarks.Text), DBNull.Value, txtRemarks.Text.Trim()))
                        insertCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show($"Grade saved successfully!" & vbCrLf & vbCrLf &
     $"Student: {cmbSelectStudent.Text}" & vbCrLf &
           $"Grading Period: {cmbGradingPeriod.Text}" & vbCrLf &
       $"Assignment Type: {cmbAssignmentType.Text}" & vbCrLf &
              $"Score: {gradeValue}/{maxScore}" & vbCrLf &
        $"Percentage: {percentage:F2}%",
    "Grade Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                ' Refresh the grades display
                LoadStudentGrades()
                ClearGradeInputs()
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error saving grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshGrades_Click(sender As Object, e As EventArgs) Handles btnRefreshGrades.Click
        If cmbCourseOffering.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbCourseOffering.SelectedValue) AndAlso
           cmbGradingPeriod.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbGradingPeriod.SelectedValue) AndAlso
       cmbAssignmentType.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbAssignmentType.SelectedValue) Then
            LoadStudentGrades()
            MessageBox.Show("Grades refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please select a course offering, grading period, and assignment type first.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ClearGradeForm()
        grpStudentGrades.Visible = False
        ClearGradeInputs()
    End Sub

    Private Sub ClearGradeInputs()
        If cmbSelectStudent.Items.Count > 0 Then cmbSelectStudent.SelectedIndex = 0
        txtGradeValue.Clear()
        txtRemarks.Clear()
        txtStudentSearch.Clear()
    End Sub

    ' Handle DataGridView row selection to populate grade form
    Private Sub dgvStudentGrades_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudentGrades.CellClick
        If e.RowIndex >= 0 Then
            Dim selectedRow As DataGridViewRow = dgvStudentGrades.Rows(e.RowIndex)

            ' Get student ID from hidden column
            If selectedRow.Cells("Student ID").Value IsNot Nothing Then
                Dim studentId As Integer = Convert.ToInt32(selectedRow.Cells("Student ID").Value)

                ' Find and select the student in the dropdown
                For i As Integer = 0 To cmbSelectStudent.Items.Count - 1
                    Dim item As DataRowView = TryCast(cmbSelectStudent.Items(i), DataRowView)
                    If item IsNot Nothing AndAlso Not IsDBNull(item("student_id")) Then
                        If Convert.ToInt32(item("student_id")) = studentId Then
                            cmbSelectStudent.SelectedIndex = i
                            Exit For
                        End If
                    End If
                Next

                ' Populate grade value if exists
                If selectedRow.Cells("Score").Value IsNot Nothing AndAlso selectedRow.Cells("Score").Value.ToString() <> "N/A" Then
                    txtGradeValue.Text = selectedRow.Cells("Score").Value.ToString()
                Else
                    txtGradeValue.Clear()
                End If

                ' Populate notes if exists
                If selectedRow.Cells("Notes").Value IsNot Nothing Then
                    txtRemarks.Text = selectedRow.Cells("Notes").Value.ToString()
                Else
                    txtRemarks.Clear()
                End If
            End If
        End If
    End Sub

    Private Sub TeacherDashboard_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        login.ClearUserSession()
        Dim loginForm As New login()
        loginForm.Show()
    End Sub
End Class