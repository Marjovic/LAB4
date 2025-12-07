Imports MySql.Data.MySqlClient

Public Class ViewStudentGrades
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    Private Sub ViewStudentGrades_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "View All Student Grades - MGOD LMS"

        ' Initialize filter dropdowns
        InitializeFilterDropdowns()

        ' Load all grades by default
        LoadAllGrades()
    End Sub

    ' ============= INITIALIZATION METHODS =============

    Private Sub InitializeFilterDropdowns()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Load Academic Years
                Dim academicYearQuery As String = "SELECT academic_year_id, academic_year_name " &
              "FROM Academic_Years " &
                "ORDER BY year_start DESC"

                Using adapter As New MySqlDataAdapter(academicYearQuery, connection)
                    Dim yearTable As New DataTable()
                    adapter.Fill(yearTable)

                    ' Add "All" option
                    Dim allRow As DataRow = yearTable.NewRow()
                    allRow("academic_year_id") = 0
                    allRow("academic_year_name") = "-- All Academic Years --"
                    yearTable.Rows.InsertAt(allRow, 0)

                    cmbFilterAcademicYear.DataSource = yearTable
                    cmbFilterAcademicYear.DisplayMember = "academic_year_name"
                    cmbFilterAcademicYear.ValueMember = "academic_year_id"
                    cmbFilterAcademicYear.SelectedIndex = 0
                End Using

                ' Load Semester Types
                Dim semesterQuery As String = "SELECT semester_type_id, type_name " &
                      "FROM Semester_Types " &
                 "ORDER BY display_order"

                Using adapter As New MySqlDataAdapter(semesterQuery, connection)
                    Dim semesterTable As New DataTable()
                    adapter.Fill(semesterTable)

                    ' Add "All" option
                    Dim allRow As DataRow = semesterTable.NewRow()
                    allRow("semester_type_id") = 0
                    allRow("type_name") = "-- All Semesters --"
                    semesterTable.Rows.InsertAt(allRow, 0)

                    cmbFilterSemester.DataSource = semesterTable
                    cmbFilterSemester.DisplayMember = "type_name"
                    cmbFilterSemester.ValueMember = "semester_type_id"
                    cmbFilterSemester.SelectedIndex = 0
                End Using

                ' Load Courses
                Dim courseQuery As String = "SELECT course_id, CONCAT(course_code, ' - ', course_name) as display_name " &
           "FROM Courses " &
                     "ORDER BY course_code"

                Using adapter As New MySqlDataAdapter(courseQuery, connection)
                    Dim courseTable As New DataTable()
                    adapter.Fill(courseTable)

                    ' Add "All" option
                    Dim allRow As DataRow = courseTable.NewRow()
                    allRow("course_id") = 0
                    allRow("display_name") = "-- All Courses --"
                    courseTable.Rows.InsertAt(allRow, 0)

                    cmbFilterCourse.DataSource = courseTable
                    cmbFilterCourse.DisplayMember = "display_name"
                    cmbFilterCourse.ValueMember = "course_id"
                    cmbFilterCourse.SelectedIndex = 0
                End Using

                ' Load Grading Periods
                Dim periodQuery As String = "SELECT period_id, CONCAT(period_code, ' - ', period_name) as display_name " &
                       "FROM Grading_Periods " &
                  "ORDER BY display_order"

                Using adapter As New MySqlDataAdapter(periodQuery, connection)
                    Dim periodTable As New DataTable()
                    adapter.Fill(periodTable)

                    ' Add "All" option
                    Dim allRow As DataRow = periodTable.NewRow()
                    allRow("period_id") = 0
                    allRow("display_name") = "-- All Periods --"
                    periodTable.Rows.InsertAt(allRow, 0)

                    cmbFilterPeriod.DataSource = periodTable
                    cmbFilterPeriod.DisplayMember = "display_name"
                    cmbFilterPeriod.ValueMember = "period_id"
                    cmbFilterPeriod.SelectedIndex = 0
                End Using

                ' Load Assignment Types
                Dim typeQuery As String = "SELECT type_id, CONCAT(type_code, ' - ', type_name) as display_name " &
               "FROM AssignmentTypes " &
                          "WHERE is_active = TRUE " &
                        "ORDER BY display_order"

                Using adapter As New MySqlDataAdapter(typeQuery, connection)
                    Dim typeTable As New DataTable()
                    adapter.Fill(typeTable)

                    ' Add "All" option
                    Dim allRow As DataRow = typeTable.NewRow()
                    allRow("type_id") = 0
                    allRow("display_name") = "-- All Types --"
                    typeTable.Rows.InsertAt(allRow, 0)

                    cmbFilterType.DataSource = typeTable
                    cmbFilterType.DisplayMember = "display_name"
                    cmbFilterType.ValueMember = "type_id"
                    cmbFilterType.SelectedIndex = 0
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading filter options: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============= DATA LOADING METHODS =============

    Private Sub LoadAllGrades()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Build query with optional filters
                Dim query As String = BuildGradesQuery()

                Using adapter As New MySqlDataAdapter(query, connection)
                    ' Add filter parameters
                    AddFilterParameters(adapter.SelectCommand)

                    Dim gradesTable As New DataTable()
                    adapter.Fill(gradesTable)

                    ' Bind to grid
                    dgvAllGrades.DataSource = gradesTable
                    dgvAllGrades.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                    ' Hide ID columns
                    If dgvAllGrades.Columns.Contains("Grade ID") Then
                        dgvAllGrades.Columns("Grade ID").Visible = False
                    End If

                    ' Apply formatting
                    FormatGradesGrid()

                    ' Update stats
                    UpdateGradeStats(gradesTable)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading grades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function BuildGradesQuery() As String
        Dim query As String = "SELECT " &
      "g.grade_id as 'Grade ID', " &
   "s.student_number as 'Student Number', " &
                "CONCAT(s.first_name, ' ', s.last_name) as 'Student Name', " &
         "c.course_code as 'Course Code', " &
           "c.course_name as 'Course Name', " &
        "co.section as 'Section', " &
             "CONCAT(ay.academic_year_name, ' - ', st.type_name) as 'Semester', " &
        "gp.period_name as 'Grading Period', " &
                 "at.type_name as 'Assignment Type', " &
     "g.numeric_grade as 'Score', " &
          "ogw.max_score as 'Max Score', " &
       "ROUND((g.numeric_grade / ogw.max_score) * 100, 2) as 'Percentage', " &
            "ogw.custom_weight as 'Weight %', " &
                  "CONCAT(i.first_name, ' ', i.last_name) as 'Graded By', " &
          "DATE_FORMAT(g.grade_date, '%Y-%m-%d') as 'Grade Date', " &
          "IFNULL(g.notes, 'N/A') as 'Notes' " &
              "FROM Grades g " &
            "INNER JOIN Enrollments e ON g.enrollment_id = e.enrollment_id " &
            "INNER JOIN Students s ON e.student_id = s.student_id " &
            "INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id " &
               "INNER JOIN Courses c ON co.course_id = c.course_id " &
      "INNER JOIN Semesters sem ON co.semester_id = sem.semester_id " &
    "INNER JOIN Academic_Years ay ON sem.academic_year_id = ay.academic_year_id " &
    "INNER JOIN Semester_Types st ON sem.semester_type_id = st.semester_type_id " &
    "INNER JOIN Term_Grading_Periods tgp ON g.term_period_id = tgp.term_period_id " &
           "INNER JOIN Grading_Periods gp ON tgp.period_id = gp.period_id " &
     "INNER JOIN AssignmentTypes at ON g.type_id = at.type_id " &
           "LEFT JOIN Offering_Grading_Weights ogw ON ogw.offering_id = co.offering_id " &
          "    AND ogw.type_id = at.type_id AND ogw.period_id = gp.period_id " &
        "LEFT JOIN Instructors i ON g.graded_by = i.instructor_id " &
            "WHERE 1=1"

        ' Add filter conditions
        Dim academicYearId As Integer = If(cmbFilterAcademicYear.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterAcademicYear.SelectedValue), 0)
        Dim semesterTypeId As Integer = If(cmbFilterSemester.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterSemester.SelectedValue), 0)
        Dim courseId As Integer = If(cmbFilterCourse.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterCourse.SelectedValue), 0)
        Dim periodId As Integer = If(cmbFilterPeriod.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterPeriod.SelectedValue), 0)
        Dim typeId As Integer = If(cmbFilterType.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterType.SelectedValue), 0)

        If academicYearId > 0 Then query &= " AND ay.academic_year_id = @academic_year_id"
        If semesterTypeId > 0 Then query &= " AND st.semester_type_id = @semester_type_id"
        If courseId > 0 Then query &= " AND c.course_id = @course_id"
        If periodId > 0 Then query &= " AND gp.period_id = @period_id"
        If typeId > 0 Then query &= " AND at.type_id = @type_id"

        ' Add student search filter
        If Not String.IsNullOrWhiteSpace(txtStudentSearch.Text) Then
            query &= " AND (s.student_number LIKE @search OR s.first_name LIKE @search OR s.last_name LIKE @search)"
        End If

        query &= " ORDER BY ay.year_start DESC, st.display_order, c.course_code, s.last_name, s.first_name, gp.display_order, at.display_order"

        Return query
    End Function

    Private Sub AddFilterParameters(cmd As MySqlCommand)
        Dim academicYearId As Integer = If(cmbFilterAcademicYear.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterAcademicYear.SelectedValue), 0)
        Dim semesterTypeId As Integer = If(cmbFilterSemester.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterSemester.SelectedValue), 0)
        Dim courseId As Integer = If(cmbFilterCourse.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterCourse.SelectedValue), 0)
        Dim periodId As Integer = If(cmbFilterPeriod.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterPeriod.SelectedValue), 0)
        Dim typeId As Integer = If(cmbFilterType.SelectedValue IsNot Nothing, Convert.ToInt32(cmbFilterType.SelectedValue), 0)

        If academicYearId > 0 Then cmd.Parameters.AddWithValue("@academic_year_id", academicYearId)
        If semesterTypeId > 0 Then cmd.Parameters.AddWithValue("@semester_type_id", semesterTypeId)
        If courseId > 0 Then cmd.Parameters.AddWithValue("@course_id", courseId)
        If periodId > 0 Then cmd.Parameters.AddWithValue("@period_id", periodId)
        If typeId > 0 Then cmd.Parameters.AddWithValue("@type_id", typeId)

        If Not String.IsNullOrWhiteSpace(txtStudentSearch.Text) Then
            cmd.Parameters.AddWithValue("@search", "%" & txtStudentSearch.Text.Trim() & "%")
        End If
    End Sub

    Private Sub FormatGradesGrid()
        Try
            If dgvAllGrades Is Nothing OrElse dgvAllGrades.Rows.Count = 0 Then
                Return
            End If

            For Each row As DataGridViewRow In dgvAllGrades.Rows
                ' Color code based on percentage
                If row.Cells("Percentage").Value IsNot Nothing Then
                    Dim percentage As Decimal = 0
                    If Decimal.TryParse(row.Cells("Percentage").Value.ToString(), percentage) Then
                        If percentage >= 90 Then
                            row.Cells("Percentage").Style.BackColor = Color.FromArgb(144, 238, 144) ' Light green
                            row.Cells("Score").Style.BackColor = Color.FromArgb(144, 238, 144)
                        ElseIf percentage >= 75 Then
                            row.Cells("Percentage").Style.BackColor = Color.FromArgb(173, 216, 230) ' Light blue
                            row.Cells("Score").Style.BackColor = Color.FromArgb(173, 216, 230)
                        ElseIf percentage >= 60 Then
                            row.Cells("Percentage").Style.BackColor = Color.FromArgb(255, 255, 224) ' Light yellow
                            row.Cells("Score").Style.BackColor = Color.FromArgb(255, 255, 224)
                        Else
                            row.Cells("Percentage").Style.BackColor = Color.FromArgb(255, 182, 193) ' Light red
                            row.Cells("Score").Style.BackColor = Color.FromArgb(255, 182, 193)
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    Private Sub UpdateGradeStats(gradesTable As DataTable)
        Try
            If gradesTable.Rows.Count = 0 Then
                lblTotalGrades.Text = "Total Grades: 0"
                lblAverageScore.Text = "Average: N/A"
                lblPassingRate.Text = "Passing Rate: N/A"
                Return
            End If

            Dim totalGrades As Integer = gradesTable.Rows.Count
            Dim totalPercentage As Decimal = 0
            Dim passingCount As Integer = 0

            For Each row As DataRow In gradesTable.Rows
                If Not IsDBNull(row("Percentage")) Then
                    Dim percentage As Decimal = Convert.ToDecimal(row("Percentage"))
                    totalPercentage += percentage
                    If percentage >= 75 Then
                        passingCount += 1
                    End If
                End If
            Next

            Dim averageScore As Decimal = If(totalGrades > 0, totalPercentage / totalGrades, 0)
            Dim passingRate As Decimal = If(totalGrades > 0, (passingCount / totalGrades) * 100, 0)

            lblTotalGrades.Text = $"Total Grades: {totalGrades:N0}"
            lblAverageScore.Text = $"Average: {averageScore:F2}%"
            lblPassingRate.Text = $"Passing Rate: {passingRate:F1}% ({passingCount}/{totalGrades})"

            ' Color code passing rate
            If passingRate >= 80 Then
                lblPassingRate.ForeColor = Color.DarkGreen
            ElseIf passingRate >= 60 Then
                lblPassingRate.ForeColor = Color.DarkOrange
            Else
                lblPassingRate.ForeColor = Color.DarkRed
            End If

        Catch ex As Exception
            ' Ignore stats calculation errors
        End Try
    End Sub

    ' ============= EVENT HANDLERS =============

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        LoadAllGrades()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ' Reset all filters to "All"
        If cmbFilterAcademicYear.Items.Count > 0 Then cmbFilterAcademicYear.SelectedIndex = 0
        If cmbFilterSemester.Items.Count > 0 Then cmbFilterSemester.SelectedIndex = 0
        If cmbFilterCourse.Items.Count > 0 Then cmbFilterCourse.SelectedIndex = 0
        If cmbFilterPeriod.Items.Count > 0 Then cmbFilterPeriod.SelectedIndex = 0
        If cmbFilterType.Items.Count > 0 Then cmbFilterType.SelectedIndex = 0
        txtStudentSearch.Clear()

        ' Reload all grades
        LoadAllGrades()
    End Sub

    Private Sub btnRefreshGrades_Click(sender As Object, e As EventArgs) Handles btnRefreshGrades.Click
        LoadAllGrades()
        MessageBox.Show("Grades refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnExportToExcel_Click(sender As Object, e As EventArgs) Handles btnExportToExcel.Click
        Try
            If dgvAllGrades.Rows.Count = 0 Then
                MessageBox.Show("No data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Create SaveFileDialog
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*"
            saveDialog.FileName = $"StudentGrades_{DateTime.Now:yyyyMMdd_HHmmss}.csv"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportToCSV(saveDialog.FileName)
                MessageBox.Show($"Grades exported successfully to:{vbCrLf}{saveDialog.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show($"Error exporting grades: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportToCSV(filePath As String)
        Using writer As New System.IO.StreamWriter(filePath, False, System.Text.Encoding.UTF8)
            ' Write headers
            Dim headers As New List(Of String)
            For Each column As DataGridViewColumn In dgvAllGrades.Columns
                If column.Visible Then
                    headers.Add($"""{column.HeaderText}""")
                End If
            Next
            writer.WriteLine(String.Join(",", headers))

            ' Write data
            For Each row As DataGridViewRow In dgvAllGrades.Rows
                Dim values As New List(Of String)
                For Each column As DataGridViewColumn In dgvAllGrades.Columns
                    If column.Visible Then
                        Dim cellValue As String = If(row.Cells(column.Index).Value IsNot Nothing,
                     row.Cells(column.Index).Value.ToString().Replace("""", """"""),
                         "")
                        values.Add($"""{cellValue}""")
                    End If
                Next
                writer.WriteLine(String.Join(",", values))
            Next
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
