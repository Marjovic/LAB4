Imports MySql.Data.MySqlClient

Public Class ReportsForm
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current selected student ID
    Private currentStudentId As Integer = 0

    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Reports - MGOD LMS"

        ' Initialize student dropdown
        InitializeStudentDropdown()

        ' Show Student Transcript panel by default
        ShowPanel(pnlStudentTranscript)
        SetActiveButton(btnStudentTranscript)
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlStudentTranscript.Visible = False
        pnlCourseAnalytics.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnStudentTranscript.BackColor = Color.FromArgb(35, 35, 38)
        btnCourseAnalytics.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnStudentTranscript_Click(sender As Object, e As EventArgs) Handles btnStudentTranscript.Click
        ShowPanel(pnlStudentTranscript)
        SetActiveButton(btnStudentTranscript)
    End Sub

    Private Sub btnCourseAnalytics_Click(sender As Object, e As EventArgs) Handles btnCourseAnalytics.Click
        ShowPanel(pnlCourseAnalytics)
        SetActiveButton(btnCourseAnalytics)
        MessageBox.Show("Course Analytics feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= STUDENT TRANSCRIPT METHODS =============

    Private Sub InitializeStudentDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Load all students with their basic info
                Dim query As String = "SELECT s.student_id, " &
                       "CONCAT(s.student_number, ' - ', s.first_name, ' ', s.last_name, " &
                         "' (', IFNULL(p.program_code, 'No Program'), ')') as display_name " &
           "FROM Students s " &
                     "LEFT JOIN Programs p ON s.program_id = p.program_id " &
           "ORDER BY s.student_number, s.last_name, s.first_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim studentTable As New DataTable()
                    adapter.Fill(studentTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = studentTable.NewRow()
                    emptyRow("student_id") = DBNull.Value
                    emptyRow("display_name") = "-- Select Student --"
                    studentTable.Rows.InsertAt(emptyRow, 0)

                    cmbStudentSelect.DataSource = studentTable
                    cmbStudentSelect.DisplayMember = "display_name"
                    cmbStudentSelect.ValueMember = "student_id"
                    cmbStudentSelect.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading students: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub txtStudentSearch_TextChanged(sender As Object, e As EventArgs) Handles txtStudentSearch.TextChanged
        ' Filter the student dropdown based on search text
        If String.IsNullOrWhiteSpace(txtStudentSearch.Text) Then
            InitializeStudentDropdown()
            Return
        End If

        Dim searchText As String = txtStudentSearch.Text.Trim().ToLower()

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT s.student_id, " &
               "CONCAT(s.student_number, ' - ', s.first_name, ' ', s.last_name, " &
               "' (', IFNULL(p.program_code, 'No Program'), ')') as display_name " &
     "FROM Students s " &
          "LEFT JOIN Programs p ON s.program_id = p.program_id " &
         "WHERE LOWER(s.student_number) LIKE @search " &
               "OR LOWER(s.first_name) LIKE @search " &
                "OR LOWER(s.last_name) LIKE @search " &
                        "ORDER BY s.student_number, s.last_name, s.first_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@search", $"%{searchText}%")
                    Dim studentTable As New DataTable()
                    adapter.Fill(studentTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = studentTable.NewRow()
                    emptyRow("student_id") = DBNull.Value
                    emptyRow("display_name") = "-- Select Student --"
                    studentTable.Rows.InsertAt(emptyRow, 0)

                    cmbStudentSelect.DataSource = studentTable
                    cmbStudentSelect.DisplayMember = "display_name"
                    cmbStudentSelect.ValueMember = "student_id"
                    cmbStudentSelect.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            ' Silently handle search errors
        End Try
    End Sub

    Private Sub btnGenerateTranscript_Click(sender As Object, e As EventArgs) Handles btnGenerateTranscript.Click
        ' Validate selection
        If cmbStudentSelect.SelectedValue Is Nothing OrElse IsDBNull(cmbStudentSelect.SelectedValue) Then
            MessageBox.Show("Please select a student to generate transcript.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        currentStudentId = Convert.ToInt32(cmbStudentSelect.SelectedValue)
        GenerateStudentTranscript()
    End Sub

    Private Sub GenerateStudentTranscript()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' First, load student header information
                LoadStudentHeaderInfo(connection)

                ' Load complete transcript from StudentTranscript view
                Dim query As String = "SELECT " &
              "academic_year_name as 'Academic Year', " &
                 "semester_name as 'Semester', " &
               "term_name as 'Term', " &
               "course_code as 'Course Code', " &
             "course_name as 'Course Name', " &
                                 "total_units as 'Units', " &
                      "instructor_name as 'Instructor', " &
              "COALESCE(CAST(overall_numeric_grade AS CHAR), 'N/A') as 'Grade', " &
                        "letter_grade as 'Letter Grade', " &
                       "CASE " &
                     "  WHEN is_passing = TRUE THEN 'Passed' " &
                        "  WHEN overall_numeric_grade IS NULL THEN 'In Progress' " &
                   "  ELSE 'Failed' " &
                "END as 'Status', " &
                "units_earned as 'Units Earned' " &
                 "FROM StudentTranscript " &
                      "WHERE student_id = @student_id " &
                 "ORDER BY year_start DESC, semester_code, term_code, course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@student_id", currentStudentId)
                    Dim transcriptTable As New DataTable()
                    adapter.Fill(transcriptTable)

                    If transcriptTable.Rows.Count = 0 Then
                        MessageBox.Show("No enrollment records found for this student.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgvTranscript.DataSource = Nothing
                        grpTranscriptSummary.Visible = False
                        Return
                    End If

                    dgvTranscript.DataSource = transcriptTable
                    dgvTranscript.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                    ' Apply formatting
                    FormatTranscriptGrid()

                    ' Calculate and display summary statistics
                    CalculateTranscriptSummary(connection)

                    grpTranscriptSummary.Visible = True
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error generating transcript: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadStudentHeaderInfo(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT DISTINCT " &
                    "student_number, " &
        "student_name, " &
             "student_email, " &
               "date_of_birth, " &
         "admission_date, " &
     "program_name, " &
        "department_name, " &
                    "current_year_level " &
               "FROM StudentTranscript " &
     "WHERE student_id = @student_id " &
          "LIMIT 1"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        lblStudentInfo.Text = $"Student Number: {reader("student_number")}" & vbCrLf &
                           $"Name: {reader("student_name")}" & vbCrLf &
                         $"Email: {If(IsDBNull(reader("student_email")), "N/A", reader("student_email"))}" & vbCrLf &
                            $"Date of Birth: {If(IsDBNull(reader("date_of_birth")), "N/A", Convert.ToDateTime(reader("date_of_birth")).ToString("yyyy-MM-dd"))}" & vbCrLf &
                               $"Admission Date: {If(IsDBNull(reader("admission_date")), "N/A", Convert.ToDateTime(reader("admission_date")).ToString("yyyy-MM-dd"))}" & vbCrLf &
                         $"Program: {reader("program_name")}" & vbCrLf &
                               $"Department: {reader("department_name")}" & vbCrLf &
                              $"Current Year Level: {reader("current_year_level")}"

                        lblStudentInfo.Visible = True
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblStudentInfo.Text = "Error loading student information"
            lblStudentInfo.Visible = True
        End Try
    End Sub

    Private Sub CalculateTranscriptSummary(connection As MySqlConnection)
        Try
            ' Calculate GPA and summary using StudentTranscript view
            Dim query As String = "SELECT " &
         "SUM(units_earned) as total_units_earned, " &
            "COUNT(DISTINCT course_id) as total_courses, " &
        "SUM(CASE WHEN is_passing = TRUE THEN 1 ELSE 0 END) as courses_passed, " &
                 "SUM(CASE WHEN is_passing = FALSE THEN 1 ELSE 0 END) as courses_failed, " &
        "ROUND(SUM(gpa_points * total_units) / NULLIF(SUM(CASE WHEN gpa_points IS NOT NULL THEN total_units ELSE 0 END), 0), 2) as cumulative_gpa, " &
                "ROUND(AVG(CASE WHEN overall_numeric_grade IS NOT NULL THEN overall_numeric_grade ELSE NULL END), 2) as overall_average " &
      "FROM StudentTranscript " &
       "WHERE student_id = @student_id"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@student_id", currentStudentId)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim unitsEarned As String = If(IsDBNull(reader("total_units_earned")), "0", reader("total_units_earned").ToString())
                        Dim totalCourses As String = If(IsDBNull(reader("total_courses")), "0", reader("total_courses").ToString())
                        Dim coursesPassed As String = If(IsDBNull(reader("courses_passed")), "0", reader("courses_passed").ToString())
                        Dim coursesFailed As String = If(IsDBNull(reader("courses_failed")), "0", reader("courses_failed").ToString())
                        Dim cumulativeGpa As String = If(IsDBNull(reader("cumulative_gpa")), "N/A", reader("cumulative_gpa").ToString())
                        Dim overallAvg As String = If(IsDBNull(reader("overall_average")), "N/A", reader("overall_average").ToString())

                        lblTranscriptSummary.Text = $"Total Units Earned: {unitsEarned}  |  Total Courses: {totalCourses}  |  Passed: {coursesPassed}  |  Failed: {coursesFailed}" & vbCrLf & vbCrLf &
                    $"Cumulative GPA: {cumulativeGpa}  |  Overall Average: {overallAvg}%"
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblTranscriptSummary.Text = "Error calculating summary"
        End Try
    End Sub

    Private Sub FormatTranscriptGrid()
        Try
            If dgvTranscript Is Nothing OrElse dgvTranscript.Rows.Count = 0 Then
                Return
            End If

            For Each row As DataGridViewRow In dgvTranscript.Rows
                ' Color code status column
                If row.Cells("Status").Value IsNot Nothing Then
                    Dim status As String = row.Cells("Status").Value.ToString()
                    Select Case status
                        Case "Passed"
                            row.Cells("Status").Style.BackColor = Color.LightGreen
                            row.Cells("Status").Style.ForeColor = Color.DarkGreen
                        Case "Failed"
                            row.Cells("Status").Style.BackColor = Color.LightCoral
                            row.Cells("Status").Style.ForeColor = Color.DarkRed
                        Case "In Progress"
                            row.Cells("Status").Style.BackColor = Color.LightYellow
                            row.Cells("Status").Style.ForeColor = Color.DarkOrange
                    End Select
                End If

                ' Color code letter grade
                If row.Cells("Letter Grade").Value IsNot Nothing Then
                    Dim letterGrade As String = row.Cells("Letter Grade").Value.ToString()
                    If letterGrade <> "NG" And letterGrade <> "INC" Then
                        Dim gradeValue As Decimal = 0
                        If Decimal.TryParse(letterGrade, gradeValue) Then
                            If gradeValue < 3.0 Then
                                row.Cells("Letter Grade").Style.BackColor = Color.LightGreen
                            ElseIf gradeValue = 5.0 Then
                                row.Cells("Letter Grade").Style.BackColor = Color.LightCoral
                            End If
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    Private Sub btnExportTranscript_Click(sender As Object, e As EventArgs) Handles btnExportTranscript.Click
        If dgvTranscript.DataSource Is Nothing OrElse dgvTranscript.Rows.Count = 0 Then
            MessageBox.Show("No transcript data to export. Please generate a transcript first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("Export to PDF/Excel feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnPrintTranscript_Click(sender As Object, e As EventArgs) Handles btnPrintTranscript.Click
        If dgvTranscript.DataSource Is Nothing OrElse dgvTranscript.Rows.Count = 0 Then
            MessageBox.Show("No transcript data to print. Please generate a transcript first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        MessageBox.Show("Print transcript feature coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class