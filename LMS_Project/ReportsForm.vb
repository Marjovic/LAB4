Imports MySql.Data.MySqlClient
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports LiveChartsCore
Imports LiveChartsCore.SkiaSharpView
Imports LiveChartsCore.SkiaSharpView.Painting
Imports SkiaSharp

Public Class ReportsForm
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current selected student ID
    Private currentStudentId As Integer = 0

    ' PDF Font definitions (9pt as requested)
    Private baseFont As iTextSharp.text.pdf.BaseFont
    Private titleFont As iTextSharp.text.Font
    Private headerFont As iTextSharp.text.Font
    Private normalFont As iTextSharp.text.Font
    Private boldFont As iTextSharp.text.Font
    Private smallFont As iTextSharp.text.Font

    ' Long Bond Paper size: 8.5 x 13 inches (612 x 936 points)
    Private ReadOnly LongBondPaper As iTextSharp.text.Rectangle = New iTextSharp.text.Rectangle(612, 936)

    Private Sub ReportsForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Reports - MGOD LMS"

        ' Initialize PDF fonts (9pt size)
        InitializePdfFonts()

        ' Initialize student dropdown
        InitializeStudentDropdown()

        ' Initialize analytics filters
        InitializeAnalyticsFilters()

        ' Show Student Transcript panel by default
        ShowPanel(pnlStudentTranscript)
        SetActiveButton(btnStudentTranscript)
    End Sub

    Private Sub InitializePdfFonts()
        ' Initialize fonts with 9pt base size
        baseFont = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED)
        titleFont = New iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD, New iTextSharp.text.BaseColor(0, 0, 139))
        headerFont = New iTextSharp.text.Font(baseFont, 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.White)
        normalFont = New iTextSharp.text.Font(baseFont, 9, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.Black)
        boldFont = New iTextSharp.text.Font(baseFont, 9, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.Black)
        smallFont = New iTextSharp.text.Font(baseFont, 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.Gray)
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
        ' Initialize charts with empty data
        InitializeCharts()
    End Sub

    ' ============= TOGGLE VIEW METHOD =============
    Private Sub btnToggleView_Click(sender As Object, e As EventArgs) Handles btnToggleView.Click
        If pnlChartsContainer.Visible Then
            ' Switch to Table View
            pnlChartsContainer.Visible = False
            pnlTableContainer.Visible = True
            btnToggleView.Text = "📊 Show Chart View"
            btnToggleView.BackColor = Color.FromArgb(0, 122, 204)
        Else
            ' Switch to Chart View
            pnlChartsContainer.Visible = True
            pnlTableContainer.Visible = False
            btnToggleView.Text = "📋 Show Table View"
            btnToggleView.BackColor = Color.FromArgb(108, 117, 125)
        End If
    End Sub

    ' ============= CHART INITIALIZATION =============
    Private Sub InitializeCharts()
        Try
            ' Initialize Pass Rate Gauge (Donut style)
            InitializeGaugeChart(chartPassRate, 0, "Pass Rate", SKColors.LimeGreen, SKColors.LightCoral)

            ' Initialize Retention Rate Gauge
            InitializeGaugeChart(chartRetention, 0, "Retention", SKColors.DodgerBlue, SKColors.LightGray)

            ' Initialize Grade Distribution Pie
            InitializeGradeDistributionPie()

            ' Initialize Bar Chart
            InitializePerformanceBarChart()

            ' Initialize Comparison Chart
            InitializeComparisonChart()

        Catch ex As Exception
            ' Silent initialization - if charts fail, default to table view
            If pnlChartsContainer IsNot Nothing AndAlso pnlTableContainer IsNot Nothing Then
                pnlChartsContainer.Visible = False
                pnlTableContainer.Visible = True
                If btnToggleView IsNot Nothing Then
                    btnToggleView.Text = "📊 Show Chart View"
                    btnToggleView.BackColor = Color.FromArgb(0, 122, 204)
                End If
            End If
            MessageBox.Show($"Charts initialization encountered an error. Defaulting to table view. Error: {ex.Message}", "Chart Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub InitializeGaugeChart(chart As LiveChartsCore.SkiaSharpView.WinForms.PieChart, percentage As Double, title As String, mainColor As SKColor, bgColor As SKColor)
        Try
            Dim series As New List(Of ISeries)

            ' Main value
            series.Add(New PieSeries(Of Double) With {
                .Values = New Double() {percentage},
                .Fill = New SolidColorPaint(mainColor),
                .InnerRadius = 60,
                .MaxRadialColumnWidth = 25,
                .DataLabelsSize = 0,
                .HoverPushout = 0
            })

            ' Remaining (background)
            series.Add(New PieSeries(Of Double) With {
                .Values = New Double() {100 - percentage},
                .Fill = New SolidColorPaint(bgColor),
                .InnerRadius = 60,
                .MaxRadialColumnWidth = 25,
                .DataLabelsSize = 0,
                .HoverPushout = 0
            })

            chart.Series = series
            chart.InitialRotation = -90
            chart.MaxAngle = 360
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub InitializeGradeDistributionPie()
        Try
            Dim series As New List(Of ISeries)

            ' Default empty data
            series.Add(New PieSeries(Of Double) With {
                .Values = New Double() {25},
                .Name = "Excellent",
                .Fill = New SolidColorPaint(SKColors.DarkGreen),
                .DataLabelsSize = 10,
                .DataLabelsPaint = New SolidColorPaint(SKColors.White)
            })
            series.Add(New PieSeries(Of Double) With {
                .Values = New Double() {35},
                .Name = "Good",
                .Fill = New SolidColorPaint(SKColors.LimeGreen),
                .DataLabelsSize = 10
            })
            series.Add(New PieSeries(Of Double) With {
                .Values = New Double() {25},
                .Name = "Fair",
                .Fill = New SolidColorPaint(SKColors.Orange),
                .DataLabelsSize = 10
            })
            series.Add(New PieSeries(Of Double) With {
                .Values = New Double() {15},
                .Name = "Needs Work",
                .Fill = New SolidColorPaint(SKColors.Crimson),
                .DataLabelsSize = 10
            })

            chartGradeDistribution.Series = series
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub InitializePerformanceBarChart()
        Try
            Dim series As New List(Of ISeries)

            series.Add(New ColumnSeries(Of Double) With {
                .Values = New Double() {85, 78, 92, 70, 88},
                .Name = "Avg Grade",
                .Fill = New SolidColorPaint(SKColors.DodgerBlue),
                .MaxBarWidth = 35
            })

            chartPerformanceBar.Series = series
            chartPerformanceBar.XAxes = New List(Of Axis) From {
                New Axis With {
                    .Labels = New String() {"Dept 1", "Dept 2", "Dept 3", "Dept 4", "Dept 5"},
                    .LabelsRotation = 0,
                    .TextSize = 10,
                    .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
                }
            }
            chartPerformanceBar.YAxes = New List(Of Axis) From {
                New Axis With {
                    .MinLimit = 0,
                    .MaxLimit = 100,
                    .TextSize = 10,
                    .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
                }
            }
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub InitializeComparisonChart()
        Try
            Dim series As New List(Of ISeries)

            series.Add(New ColumnSeries(Of Double) With {
                .Values = New Double() {45, 52, 48, 55, 50},
                .Name = "Passed",
                .Fill = New SolidColorPaint(SKColors.LimeGreen),
                .MaxBarWidth = 30
            })
            series.Add(New ColumnSeries(Of Double) With {
                .Values = New Double() {5, 8, 2, 5, 10},
                .Name = "Failed",
                .Fill = New SolidColorPaint(SKColors.Crimson),
                .MaxBarWidth = 30
            })

            chartDepartmentComparison.Series = series
            chartDepartmentComparison.XAxes = New List(Of Axis) From {
                New Axis With {
                    .Labels = New String() {"Course 1", "Course 2", "Course 3", "Course 4", "Course 5"},
                    .LabelsRotation = 0,
                    .TextSize = 10,
                    .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
                }
            }
            chartDepartmentComparison.YAxes = New List(Of Axis) From {
                New Axis With {
                    .MinLimit = 0,
                    .TextSize = 10,
                    .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
                }
            }
        Catch ex As Exception
            ' Silent error
        End Try
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

        Try
            ' Create SaveFileDialog
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
            saveDialog.FileName = $"StudentTranscript_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            saveDialog.Title = "Export Student Transcript to PDF"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportTranscriptToPDF(saveDialog.FileName)
                MessageBox.Show($"Transcript exported successfully to:{vbCrLf}{saveDialog.FileName}",
      "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Ask if user wants to open the file
                Dim result As DialogResult = MessageBox.Show("Would you like to open the exported PDF now?",
        "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Try
                        Process.Start(New ProcessStartInfo(saveDialog.FileName) With {.UseShellExecute = True})
                    Catch ex As Exception
                        MessageBox.Show($"Could not open file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exporting transcript: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportTranscriptToPDF(filePath As String)
        ' Create PDF document with Long Bond Paper (8.5x13 inches), landscape orientation
        Dim doc As New iTextSharp.text.Document(LongBondPaper.Rotate(), 25, 25, 30, 30)

        Try
            Dim writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(filePath, System.IO.FileMode.Create))
            doc.Open()

            ' Add title
            Dim title As New iTextSharp.text.Paragraph("STUDENT TRANSCRIPT REPORT", titleFont)
            title.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(title)

            ' Add generation date
            Dim dateStr As New iTextSharp.text.Paragraph($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", smallFont)
            dateStr.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(dateStr)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' Add student information section
            If lblStudentInfo.Visible AndAlso Not String.IsNullOrEmpty(lblStudentInfo.Text) Then
                Dim infoTitle As New iTextSharp.text.Paragraph("STUDENT INFORMATION", boldFont)
                infoTitle.SpacingBefore = 10
                doc.Add(infoTitle)

                ' Create a table for student info
                Dim infoTable As New iTextSharp.text.pdf.PdfPTable(2)
                infoTable.WidthPercentage = 60
                infoTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
                infoTable.SpacingBefore = 5
                infoTable.SpacingAfter = 10

                Dim studentInfoLines() As String = lblStudentInfo.Text.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                For Each line In studentInfoLines
                    If line.Contains(":") Then
                        Dim parts() As String = line.Split(New Char() {":"c}, 2)
                        If parts.Length = 2 Then
                            Dim labelCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(parts(0).Trim() & ":", boldFont))
                            labelCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                            labelCell.PaddingBottom = 3

                            Dim valueCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(parts(1).Trim(), normalFont))
                            valueCell.Border = iTextSharp.text.Rectangle.NO_BORDER
                            valueCell.PaddingBottom = 3

                            infoTable.AddCell(labelCell)
                            infoTable.AddCell(valueCell)
                        End If
                    End If
                Next
                doc.Add(infoTable)
            End If

            ' Add summary section
            If grpTranscriptSummary.Visible AndAlso Not String.IsNullOrEmpty(lblTranscriptSummary.Text) Then
                Dim summaryTitle As New iTextSharp.text.Paragraph("TRANSCRIPT SUMMARY", boldFont)
                summaryTitle.SpacingBefore = 10
                doc.Add(summaryTitle)

                Dim summaryPara As New iTextSharp.text.Paragraph(lblTranscriptSummary.Text.Replace(vbCrLf, " | "), normalFont)
                summaryPara.SpacingBefore = 5
                summaryPara.SpacingAfter = 15
                doc.Add(summaryPara)
            End If

            ' Add course records table
            Dim recordsTitle As New iTextSharp.text.Paragraph("COURSE RECORDS", boldFont)
            recordsTitle.SpacingBefore = 10
            doc.Add(recordsTitle)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' Create table for course data
            Dim visibleColumnCount As Integer = 0
            For Each col As DataGridViewColumn In dgvTranscript.Columns
                If col.Visible Then visibleColumnCount += 1
            Next

            If visibleColumnCount > 0 Then
                Dim courseTable As New iTextSharp.text.pdf.PdfPTable(visibleColumnCount)
                courseTable.WidthPercentage = 100
                courseTable.SpacingBefore = 5

                ' Add header row
                For Each col As DataGridViewColumn In dgvTranscript.Columns
                    If col.Visible Then
                        Dim headerCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(col.HeaderText, headerFont))
                        headerCell.BackgroundColor = New iTextSharp.text.BaseColor(0, 122, 204)
                        headerCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        headerCell.Padding = 5
                        courseTable.AddCell(headerCell)
                    End If
                Next

                ' Add data rows
                For Each row As DataGridViewRow In dgvTranscript.Rows
                    For Each col As DataGridViewColumn In dgvTranscript.Columns
                        If col.Visible Then
                            Dim cellValue As String = If(row.Cells(col.Index).Value IsNot Nothing,
    row.Cells(col.Index).Value.ToString(), "")

                            Dim dataCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(cellValue, normalFont))
                            dataCell.Padding = 4
                            dataCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER

                            ' Color code status column
                            If col.HeaderText = "Status" Then
                                Select Case cellValue
                                    Case "Passed"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(144, 238, 144)
                                    Case "Failed"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(255, 182, 193)
                                    Case "In Progress"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(255, 255, 224)
                                End Select
                            End If

                            ' Color code letter grade
                            If col.HeaderText = "Letter Grade" Then
                                Select Case cellValue
                                    Case "NG"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(255, 228, 196)
                                    Case "INC"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(240, 230, 140)
                                End Select
                            End If

                            courseTable.AddCell(dataCell)
                        End If
                    Next
                Next

                doc.Add(courseTable)
            End If

            ' Add footer
            doc.Add(New iTextSharp.text.Paragraph(" "))
            Dim footer As New iTextSharp.text.Paragraph("End of Transcript Report - Generated by MGOD LMS", smallFont)
            footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(footer)

        Finally
            doc.Close()
        End Try
    End Sub

    ' ============= COURSE ANALYTICS METHODS =============

    Private Sub InitializeAnalyticsFilters()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Load Academic Years
                LoadAcademicYears(connection)

                ' Load Semesters
                LoadSemesters(connection)

                ' Load Terms
                LoadTerms(connection)

                ' Load Departments
                LoadDepartments(connection)

                ' Load Courses
                LoadCourses(connection)

                ' Load Instructors
                LoadInstructors(connection)
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error initializing filters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAcademicYears(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT DISTINCT academic_year_name FROM CoursePerformanceAnalytics ORDER BY academic_year_name DESC"
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                Dim emptyRow As DataRow = dt.NewRow()
                emptyRow("academic_year_name") = "-- All Academic Years --"
                dt.Rows.InsertAt(emptyRow, 0)

                cmbAcademicYear.DataSource = dt
                cmbAcademicYear.DisplayMember = "academic_year_name"
                cmbAcademicYear.ValueMember = "academic_year_name"
                cmbAcademicYear.SelectedIndex = 0
            End Using
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub LoadSemesters(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT DISTINCT semester_type FROM CoursePerformanceAnalytics WHERE semester_type IS NOT NULL ORDER BY semester_type"
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                Dim emptyRow As DataRow = dt.NewRow()
                emptyRow("semester_type") = "-- All Semesters --"
                dt.Rows.InsertAt(emptyRow, 0)

                cmbSemester.DataSource = dt
                cmbSemester.DisplayMember = "semester_type"
                cmbSemester.ValueMember = "semester_type"
                cmbSemester.SelectedIndex = 0
            End Using
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub LoadTerms(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT DISTINCT term_type FROM CoursePerformanceAnalytics WHERE term_type IS NOT NULL ORDER BY term_type"
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                Dim emptyRow As DataRow = dt.NewRow()
                emptyRow("term_type") = "-- All Terms --"
                dt.Rows.InsertAt(emptyRow, 0)

                cmbTerm.DataSource = dt
                cmbTerm.DisplayMember = "term_type"
                cmbTerm.ValueMember = "term_type"
                cmbTerm.SelectedIndex = 0
            End Using
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub LoadDepartments(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT DISTINCT department_name FROM CoursePerformanceAnalytics WHERE department_name IS NOT NULL ORDER BY department_name"
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                Dim emptyRow As DataRow = dt.NewRow()
                emptyRow("department_name") = "-- All Departments --"
                dt.Rows.InsertAt(emptyRow, 0)

                cmbDepartment.DataSource = dt
                cmbDepartment.DisplayMember = "department_name"
                cmbDepartment.ValueMember = "department_name"
                cmbDepartment.SelectedIndex = 0
            End Using
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub LoadCourses(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT DISTINCT course_id, course_code, course_name " &
   "FROM CoursePerformanceAnalytics " &
          "WHERE course_id IS NOT NULL " &
          "ORDER BY course_code"
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                ' Add computed display_name column
                dt.Columns.Add("display_name", GetType(String))
                For Each row As DataRow In dt.Rows
                    row("display_name") = row("course_code").ToString() & " - " & row("course_name").ToString()
                Next

                ' Add empty row for selection
                Dim emptyRow As DataRow = dt.NewRow()
                emptyRow("course_id") = DBNull.Value
                emptyRow("display_name") = "-- All Courses --"
                dt.Rows.InsertAt(emptyRow, 0)

                cmbCourse.DataSource = dt
                cmbCourse.DisplayMember = "display_name"
                cmbCourse.ValueMember = "course_id"
                cmbCourse.SelectedIndex = 0
            End Using
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub LoadInstructors(connection As MySqlConnection)
        Try
            Dim query As String = "SELECT DISTINCT instructor_id, instructor_name " &
       "FROM CoursePerformanceAnalytics WHERE instructor_name IS NOT NULL ORDER BY instructor_name"
            Using adapter As New MySqlDataAdapter(query, connection)
                Dim dt As New DataTable()
                adapter.Fill(dt)

                Dim emptyRow As DataRow = dt.NewRow()
                emptyRow("instructor_id") = DBNull.Value
                emptyRow("instructor_name") = "-- All Instructors --"
                dt.Rows.InsertAt(emptyRow, 0)

                cmbInstructor.DataSource = dt
                cmbInstructor.DisplayMember = "instructor_name"
                cmbInstructor.ValueMember = "instructor_id"
                cmbInstructor.SelectedIndex = 0
            End Using
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub btnApplyFilters_Click(sender As Object, e As EventArgs) Handles btnApplyFilters.Click
        LoadCourseAnalytics()
    End Sub

    Private Sub btnClearFilters_Click(sender As Object, e As EventArgs) Handles btnClearFilters.Click
        ' Reset all filters to default
        cmbAcademicYear.SelectedIndex = 0
        cmbSemester.SelectedIndex = 0
        cmbTerm.SelectedIndex = 0
        cmbDepartment.SelectedIndex = 0
        cmbCourse.SelectedIndex = 0
        cmbInstructor.SelectedIndex = 0

        ' Clear the grid and summary
        dgvAnalytics.DataSource = Nothing
        grpAnalyticsSummary.Visible = False
    End Sub

    Private Sub LoadCourseAnalytics()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Build query with filters
                Dim query As String = "SELECT " &
    "course_code as 'Course Code', " &
  "course_name as 'Course Name', " &
   "section as 'Section', " &
    "academic_year_name as 'Academic Year', " &
    "semester_type as 'Semester', " &
         "term_type as 'Term', " &
   "instructor_name as 'Instructor', " &
 "department_name as 'Department', " &
  "total_enrolled as 'Total Enrolled', " &
  "max_students as 'Max Students', " &
     "CONCAT(enrollment_percentage, '%') as 'Enrollment %', " &
  "CONCAT(retention_rate_percentage, '%') as 'Retention %', " &
 "CONCAT(drop_rate_percentage, '%') as 'Drop %', " &
      "students_with_final_grades as 'Graded', " &
   "average_final_grade as 'Avg Grade', " &
 "CONCAT(pass_rate_percentage, '%') as 'Pass Rate', " &
         "passing_students as 'Passed', " &
       "failing_students as 'Failed', " &
              "performance_rating as 'Performance', " &
  "failure_risk_level as 'Risk Level' " &
    "FROM CoursePerformanceAnalytics WHERE 1=1 "

                Dim parameters As New List(Of MySqlParameter)

                ' Apply filters
                If cmbAcademicYear.SelectedIndex > 0 Then
                    query &= "AND academic_year_name = @academic_year "
                    parameters.Add(New MySqlParameter("@academic_year", cmbAcademicYear.SelectedValue))
                End If

                If cmbSemester.SelectedIndex > 0 Then
                    query &= "AND semester_type = @semester "
                    parameters.Add(New MySqlParameter("@semester", cmbSemester.SelectedValue))
                End If

                If cmbTerm.SelectedIndex > 0 Then
                    query &= "AND term_type = @term "
                    parameters.Add(New MySqlParameter("@term", cmbTerm.SelectedValue))
                End If

                If cmbDepartment.SelectedIndex > 0 Then
                    query &= "AND department_name = @department "
                    parameters.Add(New MySqlParameter("@department", cmbDepartment.SelectedValue))
                End If

                If cmbCourse.SelectedIndex > 0 AndAlso Not IsDBNull(cmbCourse.SelectedValue) Then
                    query &= "AND course_id = @course_id "
                    parameters.Add(New MySqlParameter("@course_id", cmbCourse.SelectedValue))
                End If

                If cmbInstructor.SelectedIndex > 0 AndAlso Not IsDBNull(cmbInstructor.SelectedValue) Then
                    query &= "AND instructor_id = @instructor_id "
                    parameters.Add(New MySqlParameter("@instructor_id", cmbInstructor.SelectedValue))
                End If

                query &= "ORDER BY academic_year_name DESC, semester_type, course_code, section"

                Using cmd As New MySqlCommand(query, connection)
                    For Each param In parameters
                        cmd.Parameters.Add(param)
                    Next

                    Using adapter As New MySqlDataAdapter(cmd)
                        Dim dt As New DataTable()
                        adapter.Fill(dt)

                        If dt.Rows.Count = 0 Then
                            MessageBox.Show("No analytics data found for the selected filters.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            dgvAnalytics.DataSource = Nothing
                            grpAnalyticsSummary.Visible = False
                            Return
                        End If

                        dgvAnalytics.DataSource = dt
                        dgvAnalytics.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)

                        ' Apply formatting
                        FormatAnalyticsGrid()

                        ' Calculate summary and update KPI cards
                        CalculateAnalyticsSummary(connection, parameters)

                        ' Update Charts with real data
                        UpdateChartsWithData(connection, parameters)

                        grpAnalyticsSummary.Visible = True
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading analytics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateChartsWithData(connection As MySqlConnection, parameters As List(Of MySqlParameter))
        Try
            ' Get summary data for charts
            Dim summaryQuery As String = "SELECT " &
    "COUNT(DISTINCT offering_id) as total_offerings, " &
  "SUM(total_enrolled) as total_students, " &
        "ROUND(AVG(average_final_grade), 2) as overall_avg_grade, " &
   "ROUND(AVG(pass_rate_percentage), 2) as overall_pass_rate, " &
            "ROUND(AVG(retention_rate_percentage), 2) as overall_retention, " &
    "SUM(passing_students) as total_passed, " &
   "SUM(failing_students) as total_failed " &
      "FROM CoursePerformanceAnalytics WHERE 1=1 "

            ' Apply same filters
            If cmbAcademicYear.SelectedIndex > 0 Then
                summaryQuery &= "AND academic_year_name = @academic_year "
            End If
            If cmbSemester.SelectedIndex > 0 Then
                summaryQuery &= "AND semester_type = @semester "
            End If
            If cmbTerm.SelectedIndex > 0 Then
                summaryQuery &= "AND term_type = @term "
            End If
            If cmbDepartment.SelectedIndex > 0 Then
                summaryQuery &= "AND department_name = @department "
            End If
            If cmbCourse.SelectedIndex > 0 AndAlso Not IsDBNull(cmbCourse.SelectedValue) Then
                summaryQuery &= "AND course_id = @course_id "
            End If
            If cmbInstructor.SelectedIndex > 0 AndAlso Not IsDBNull(cmbInstructor.SelectedValue) Then
                summaryQuery &= "AND instructor_id = @instructor_id "
            End If

            Using cmd As New MySqlCommand(summaryQuery, connection)
                For Each param In parameters
                    cmd.Parameters.Add(New MySqlParameter(param.ParameterName, param.Value))
                Next

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim totalOfferings As Integer = If(IsDBNull(reader("total_offerings")), 0, Convert.ToInt32(reader("total_offerings")))
                        Dim totalStudents As Integer = If(IsDBNull(reader("total_students")), 0, Convert.ToInt32(reader("total_students")))
                        Dim avgGrade As Double = If(IsDBNull(reader("overall_avg_grade")), 0, Convert.ToDouble(reader("overall_avg_grade")))
                        Dim passRate As Double = If(IsDBNull(reader("overall_pass_rate")), 0, Convert.ToDouble(reader("overall_pass_rate")))
                        Dim retentionRate As Double = If(IsDBNull(reader("overall_retention")), 0, Convert.ToDouble(reader("overall_retention")))
                        Dim totalPassed As Integer = If(IsDBNull(reader("total_passed")), 0, Convert.ToInt32(reader("total_passed")))
                        Dim totalFailed As Integer = If(IsDBNull(reader("total_failed")), 0, Convert.ToInt32(reader("total_failed")))

                        ' Update KPI Cards
                        lblTotalCoursesValue.Text = totalOfferings.ToString()
                        lblTotalStudentsValue.Text = totalStudents.ToString()
                        lblAvgGradeValue.Text = $"{avgGrade:F1}%"
                        lblPassRateValue.Text = $"{passRate:F1}%"

                        ' Update Gauge Charts
                        UpdateGaugeChart(chartPassRate, passRate, SKColors.LimeGreen, SKColors.LightCoral)
                        UpdateGaugeChart(chartRetention, retentionRate, SKColors.DodgerBlue, SKColors.LightGray)

                        ' Update Grade Distribution Pie (Pass/Fail)
                        UpdatePassFailPie(totalPassed, totalFailed)
                    End If
                End Using
            End Using

            ' Update Department Performance Bar Chart
            UpdateDepartmentBarChart(connection, parameters)

            ' Update Pass/Fail Comparison Chart
            UpdateComparisonBarChart(connection, parameters)

        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub UpdateGaugeChart(chart As LiveChartsCore.SkiaSharpView.WinForms.PieChart, percentage As Double, mainColor As SKColor, bgColor As SKColor)
        Try
            Dim series As New List(Of ISeries)

            series.Add(New PieSeries(Of Double) With {
        .Values = New Double() {percentage},
    .Fill = New SolidColorPaint(mainColor),
          .InnerRadius = 60,
                .MaxRadialColumnWidth = 25,
       .DataLabelsSize = 14,
   .DataLabelsPaint = New SolidColorPaint(SKColors.Black),
                .DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
     .DataLabelsFormatter = Function(point) $"{percentage:F1}%",
       .HoverPushout = 0
            })

            series.Add(New PieSeries(Of Double) With {
        .Values = New Double() {100 - percentage},
     .Fill = New SolidColorPaint(bgColor),
     .InnerRadius = 60,
     .MaxRadialColumnWidth = 25,
       .DataLabelsSize = 0,
         .HoverPushout = 0
            })

            chart.Series = series
            chart.InitialRotation = -90
            chart.MaxAngle = 360
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub UpdatePassFailPie(passed As Integer, failed As Integer)
        Try
            Dim total As Integer = passed + failed
            If total = 0 Then Return

            Dim series As New List(Of ISeries)

            series.Add(New PieSeries(Of Integer) With {
     .Values = New Integer() {passed},
       .Name = $"Passed ({passed})",
        .Fill = New SolidColorPaint(SKColors.LimeGreen),
          .DataLabelsSize = 11,
.DataLabelsPaint = New SolidColorPaint(SKColors.White),
          .DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
          .DataLabelsFormatter = Function(point) $"{(passed * 100.0 / total):F0}%"
            })

            series.Add(New PieSeries(Of Integer) With {
     .Values = New Integer() {failed},
       .Name = $"Failed ({failed})",
     .Fill = New SolidColorPaint(SKColors.Crimson),
                .DataLabelsSize = 11,
         .DataLabelsPaint = New SolidColorPaint(SKColors.White),
    .DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
             .DataLabelsFormatter = Function(point) $"{(failed * 100.0 / total):F0}%"
            })

            chartGradeDistribution.Series = series
        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub UpdateDepartmentBarChart(connection As MySqlConnection, parameters As List(Of MySqlParameter))
        Try
            ' Get department performance data - MODIFIED to use department_code
            Dim query As String = "SELECT " &
              "d.department_code, " &
       "ROUND(AVG(cpa.average_final_grade), 1) as avg_grade " &
                  "FROM CoursePerformanceAnalytics cpa " &
                  "INNER JOIN Departments d ON cpa.department_name = d.department_name " &
                  "WHERE cpa.average_final_grade IS NOT NULL "

            If cmbAcademicYear.SelectedIndex > 0 Then query &= "AND cpa.academic_year_name = @academic_year "
            If cmbSemester.SelectedIndex > 0 Then query &= "AND cpa.semester_type = @semester "
            If cmbTerm.SelectedIndex > 0 Then query &= "AND cpa.term_type = @term "

            query &= "GROUP BY d.department_code ORDER BY avg_grade DESC LIMIT 6"

            Dim labels As New List(Of String)
            Dim values As New List(Of Double)

            Using cmd As New MySqlCommand(query, connection)
                For Each param In parameters
                    If param.ParameterName = "@academic_year" OrElse param.ParameterName = "@semester" OrElse param.ParameterName = "@term" Then
                        cmd.Parameters.Add(New MySqlParameter(param.ParameterName, param.Value))
                    End If
                Next

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim deptCode As String = If(IsDBNull(reader("department_code")), "Unknown", reader("department_code").ToString())
                        labels.Add(deptCode)
                        values.Add(If(IsDBNull(reader("avg_grade")), 0, Convert.ToDouble(reader("avg_grade"))))
                    End While
                End Using
            End Using

            If values.Count > 0 Then
                Dim series As New List(Of ISeries)
                series.Add(New ColumnSeries(Of Double) With {
             .Values = values.ToArray(),
         .Name = "Avg Grade",
                   .Fill = New SolidColorPaint(SKColors.DodgerBlue),
             .MaxBarWidth = 40,
              .DataLabelsSize = 10,
            .DataLabelsPaint = New SolidColorPaint(SKColors.Black),
       .DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Top,
          .DataLabelsFormatter = Function(point) $"{point.Model:F1}"
            })

                chartPerformanceBar.Series = series
                chartPerformanceBar.XAxes = New List(Of Axis) From {
          New Axis With {
              .Labels = labels.ToArray(),
                .LabelsRotation = 0,
              .TextSize = 10,
                  .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
        }
         }
                chartPerformanceBar.YAxes = New List(Of Axis) From {
            New Axis With {
                 .MinLimit = 0,
    .MaxLimit = 100,
                 .TextSize = 10,
                .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
           }
     }
            End If

        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub UpdateComparisonBarChart(connection As MySqlConnection, parameters As List(Of MySqlParameter))
        Try
            ' Get course pass/fail comparison data
            Dim query As String = "SELECT " &
  "course_code, " &
        "SUM(passing_students) as passed, " &
                "SUM(failing_students) as failed " &
          "FROM CoursePerformanceAnalytics WHERE 1=1 "

            If cmbAcademicYear.SelectedIndex > 0 Then query &= "AND academic_year_name = @academic_year "
            If cmbSemester.SelectedIndex > 0 Then query &= "AND semester_type = @semester "
            If cmbTerm.SelectedIndex > 0 Then query &= "AND term_type = @term "
            If cmbDepartment.SelectedIndex > 0 Then query &= "AND department_name = @department "

            query &= "GROUP BY course_code ORDER BY passed DESC LIMIT 6"

            Dim labels As New List(Of String)
            Dim passedValues As New List(Of Double)
            Dim failedValues As New List(Of Double)

            Using cmd As New MySqlCommand(query, connection)
                For Each param In parameters
                    cmd.Parameters.Add(New MySqlParameter(param.ParameterName, param.Value))
                Next

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        labels.Add(If(IsDBNull(reader("course_code")), "N/A", reader("course_code").ToString()))
                        passedValues.Add(If(IsDBNull(reader("passed")), 0, Convert.ToDouble(reader("passed"))))
                        failedValues.Add(If(IsDBNull(reader("failed")), 0, Convert.ToDouble(reader("failed"))))
                    End While
                End Using
            End Using

            If passedValues.Count > 0 Then
                Dim series As New List(Of ISeries)
                series.Add(New ColumnSeries(Of Double) With {
    .Values = passedValues.ToArray(),
        .Name = "Passed",
          .Fill = New SolidColorPaint(SKColors.LimeGreen),
       .MaxBarWidth = 30
  })
                series.Add(New ColumnSeries(Of Double) With {
 .Values = failedValues.ToArray(),
        .Name = "Failed",
  .Fill = New SolidColorPaint(SKColors.Crimson),
        .MaxBarWidth = 30
          })

                chartDepartmentComparison.Series = series
                chartDepartmentComparison.XAxes = New List(Of Axis) From {
      New Axis With {
             .Labels = labels.ToArray(),
         .LabelsRotation = 0,
          .TextSize = 9,
     .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
   }
         }
                chartDepartmentComparison.YAxes = New List(Of Axis) From {
     New Axis With {
          .MinLimit = 0,
      .TextSize = 10,
    .LabelsPaint = New SolidColorPaint(SKColors.DarkSlateGray)
            }
    }
            End If

        Catch ex As Exception
            ' Silent error
        End Try
    End Sub

    Private Sub CalculateAnalyticsSummary(connection As MySqlConnection, parameters As List(Of MySqlParameter))
        Try
            Dim query As String = "SELECT " &
   "COUNT(DISTINCT offering_id) as total_offerings, " &
       "SUM(total_enrolled) as total_students, " &
      "ROUND(AVG(enrollment_percentage), 2) as avg_enrollment_pct, " &
  "ROUND(AVG(average_final_grade), 2) as overall_avg_grade, " &
     "ROUND(AVG(pass_rate_percentage), 2) as overall_pass_rate, " &
     "ROUND(AVG(retention_rate_percentage), 2) as overall_retention, " &
   "SUM(passing_students) as total_passed, " &
             "SUM(failing_students) as total_failed " &
        "FROM CoursePerformanceAnalytics WHERE 1=1 "

            ' Apply same filters
            If cmbAcademicYear.SelectedIndex > 0 Then
                query &= "AND academic_year_name = @academic_year "
            End If

            If cmbSemester.SelectedIndex > 0 Then
                query &= "AND semester_type = @semester "
            End If

            If cmbTerm.SelectedIndex > 0 Then
                query &= "AND term_type = @term "
            End If

            If cmbDepartment.SelectedIndex > 0 Then
                query &= "AND department_name = @department "
            End If

            If cmbCourse.SelectedIndex > 0 AndAlso Not IsDBNull(cmbCourse.SelectedValue) Then
                query &= "AND course_id = @course_id "
            End If

            If cmbInstructor.SelectedIndex > 0 AndAlso Not IsDBNull(cmbInstructor.SelectedValue) Then
                query &= "AND instructor_id = @instructor_id "
            End If

            Using cmd As New MySqlCommand(query, connection)
                For Each param In parameters
                    cmd.Parameters.Add(New MySqlParameter(param.ParameterName, param.Value))
                Next

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        Dim totalOfferings As String = If(IsDBNull(reader("total_offerings")), "0", reader("total_offerings").ToString())
                        Dim totalStudents As String = If(IsDBNull(reader("total_students")), "0", reader("total_students").ToString())
                        Dim avgEnrollment As String = If(IsDBNull(reader("avg_enrollment_pct")), "N/A", reader("avg_enrollment_pct").ToString() & "%")
                        Dim overallGrade As String = If(IsDBNull(reader("overall_avg_grade")), "N/A", reader("overall_avg_grade").ToString())
                        Dim passRate As String = If(IsDBNull(reader("overall_pass_rate")), "N/A", reader("overall_pass_rate").ToString() & "%")
                        Dim retention As String = If(IsDBNull(reader("overall_retention")), "N/A", reader("overall_retention").ToString() & "%")
                        Dim totalPassed As String = If(IsDBNull(reader("total_passed")), "0", reader("total_passed").ToString())
                        Dim totalFailed As String = If(IsDBNull(reader("total_failed")), "0", reader("total_failed").ToString())

                        ' Update summary label with formatted text
                        lblAnalyticsSummary.Text = $"📚 Course Offerings: {totalOfferings}" & vbCrLf &
        $"👥 Total Students Enrolled: {totalStudents}" & vbCrLf &
     $"📊 Avg Enrollment: {avgEnrollment}" & vbCrLf &
      $"📈 Overall Grade: {overallGrade}%" & vbCrLf &
         $"✅ Pass Rate: {passRate}" & vbCrLf &
   $"🔄 Retention: {retention}" & vbCrLf &
    $"✔️ Passed: {totalPassed}" & vbCrLf &
   $"❌ Failed: {totalFailed}"
                    End If
                End Using
            End Using
        Catch ex As Exception
            lblAnalyticsSummary.Text = "Error calculating summary"
        End Try
    End Sub

    Private Sub FormatAnalyticsGrid()
        Try
            If dgvAnalytics Is Nothing OrElse dgvAnalytics.Rows.Count = 0 Then
                Return
            End If

            For Each row As DataGridViewRow In dgvAnalytics.Rows
                ' Color code Performance column
                If row.Cells("Performance").Value IsNot Nothing Then
                    Dim performance As String = row.Cells("Performance").Value.ToString()
                    Select Case performance
                        Case "Excellent"
                            row.Cells("Performance").Style.BackColor = Color.DarkGreen
                            row.Cells("Performance").Style.ForeColor = Color.White
                        Case "Very Good"
                            row.Cells("Performance").Style.BackColor = Color.LightGreen
                            row.Cells("Performance").Style.ForeColor = Color.DarkGreen
                        Case "Good"
                            row.Cells("Performance").Style.BackColor = Color.LightYellow
                            row.Cells("Performance").Style.ForeColor = Color.DarkOrange
                        Case "Fair"
                            row.Cells("Performance").Style.BackColor = Color.Orange
                            row.Cells("Performance").Style.ForeColor = Color.White
                        Case "Needs Improvement"
                            row.Cells("Performance").Style.BackColor = Color.LightCoral
                            row.Cells("Performance").Style.ForeColor = Color.DarkRed
                    End Select
                End If

                ' Color code Risk Level column
                If row.Cells("Risk Level").Value IsNot Nothing Then
                    Dim riskLevel As String = row.Cells("Risk Level").Value.ToString()
                    Select Case riskLevel
                        Case "High Risk", "High Attrition"
                            row.Cells("Risk Level").Style.BackColor = Color.DarkRed
                            row.Cells("Risk Level").Style.ForeColor = Color.White
                        Case "Medium Risk", "Moderate Attrition"
                            row.Cells("Risk Level").Style.BackColor = Color.Orange
                            row.Cells("Risk Level").Style.ForeColor = Color.White
                        Case "Low Risk", "Low Attrition"
                            row.Cells("Risk Level").Style.BackColor = Color.LightGreen
                            row.Cells("Risk Level").Style.ForeColor = Color.DarkGreen
                    End Select
                End If
            Next
        Catch ex As Exception
            ' Ignore formatting errors
        End Try
    End Sub

    Private Sub btnExportAnalytics_Click(sender As Object, e As EventArgs) Handles btnExportAnalytics.Click
        If dgvAnalytics.DataSource Is Nothing OrElse dgvAnalytics.Rows.Count = 0 Then
            MessageBox.Show("No analytics data to export. Please apply filters first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            ' Create SaveFileDialog
            Dim saveDialog As New SaveFileDialog()
            saveDialog.Filter = "PDF Files (*.pdf)|*.pdf|All Files (*.*)|*.*"
            saveDialog.FileName = $"CourseAnalytics_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            saveDialog.Title = "Export Course Analytics to PDF"

            If saveDialog.ShowDialog() = DialogResult.OK Then
                ExportAnalyticsToPDF(saveDialog.FileName)
                MessageBox.Show($"Analytics exported successfully to:{vbCrLf}{saveDialog.FileName}",
        "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Ask if user wants to open the file
                Dim result As DialogResult = MessageBox.Show("Would you like to open the exported PDF now?",
      "Open File", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    Try
                        Process.Start(New ProcessStartInfo(saveDialog.FileName) With {.UseShellExecute = True})
                    Catch ex As Exception
                        MessageBox.Show($"Could not open file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End Try
                End If
            End If
        Catch ex As Exception
            MessageBox.Show($"Error exporting analytics: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ExportAnalyticsToPDF(filePath As String)
        ' Create PDF document with Long Bond Paper (8.5x13 inches), landscape orientation
        Dim doc As New iTextSharp.text.Document(LongBondPaper.Rotate(), 25, 25, 30, 30)

        Try
            Dim writer As iTextSharp.text.pdf.PdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, New System.IO.FileStream(filePath, System.IO.FileMode.Create))
            doc.Open()

            ' Add title
            Dim title As New iTextSharp.text.Paragraph("COURSE PERFORMANCE ANALYTICS REPORT", titleFont)
            title.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(title)

            ' Add generation date
            Dim dateStr As New iTextSharp.text.Paragraph($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}", smallFont)
            dateStr.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(dateStr)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' Add applied filters section
            Dim filterTitle As New iTextSharp.text.Paragraph("APPLIED FILTERS", boldFont)
            filterTitle.SpacingBefore = 10
            doc.Add(filterTitle)

            Dim filterTable As New iTextSharp.text.pdf.PdfPTable(2)
            filterTable.WidthPercentage = 50
            filterTable.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT
            filterTable.SpacingBefore = 5
            filterTable.SpacingAfter = 10

            ' Add filter rows
            AddFilterRow(filterTable, "Academic Year", If(cmbAcademicYear.SelectedIndex > 0, cmbAcademicYear.Text, "All"))
            AddFilterRow(filterTable, "Semester", If(cmbSemester.SelectedIndex > 0, cmbSemester.Text, "All"))
            AddFilterRow(filterTable, "Term", If(cmbTerm.SelectedIndex > 0, cmbTerm.Text, "All"))
            AddFilterRow(filterTable, "Department", If(cmbDepartment.SelectedIndex > 0, cmbDepartment.Text, "All"))
            AddFilterRow(filterTable, "Course", If(cmbCourse.SelectedIndex > 0, cmbCourse.Text, "All"))
            AddFilterRow(filterTable, "Instructor", If(cmbInstructor.SelectedIndex > 0, cmbInstructor.Text, "All"))
            doc.Add(filterTable)

            ' ====== ADD KPI CARDS SECTION ======
            Dim kpiTitle As New iTextSharp.text.Paragraph("KEY PERFORMANCE INDICATORS", boldFont)
            kpiTitle.SpacingBefore = 10
            doc.Add(kpiTitle)

            Dim kpiTable As New iTextSharp.text.pdf.PdfPTable(4)
            kpiTable.WidthPercentage = 100
            kpiTable.SpacingBefore = 5
            kpiTable.SpacingAfter = 10

            ' Add KPI cells
            AddKPICell(kpiTable, "📚 Total Courses", lblTotalCoursesValue.Text, New iTextSharp.text.BaseColor(0, 122, 204))
            AddKPICell(kpiTable, "👥 Total Students Enrolled", lblTotalStudentsValue.Text, New iTextSharp.text.BaseColor(40, 167, 69))
            AddKPICell(kpiTable, "📈 Avg Grade", lblAvgGradeValue.Text, New iTextSharp.text.BaseColor(255, 193, 7))
            AddKPICell(kpiTable, "✅ Pass Rate", lblPassRateValue.Text, New iTextSharp.text.BaseColor(220, 53, 69))
            doc.Add(kpiTable)

            ' ====== ADD CHARTS SECTION ======
            Dim chartsTitle As New iTextSharp.text.Paragraph("VISUAL ANALYTICS", boldFont)
            chartsTitle.SpacingBefore = 10
            doc.Add(chartsTitle)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' Create a table for gauge charts (2 columns)
            Dim gaugeTable As New iTextSharp.text.pdf.PdfPTable(4)
            gaugeTable.WidthPercentage = 100
            gaugeTable.SpacingBefore = 5

            ' Capture and add Pass Rate Gauge
            Dim passRateImage As iTextSharp.text.Image = CaptureChartAsImage(chartPassRate, 200, 150)
            If passRateImage IsNot Nothing Then
                Dim passCell As New iTextSharp.text.pdf.PdfPCell(passRateImage)
                passCell.Border = iTextSharp.text.Rectangle.BOX
                passCell.Padding = 5
                passCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                passCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                gaugeTable.AddCell(passCell)
            Else
                AddChartPlaceholder(gaugeTable, "Pass Rate Gauge")
            End If

            ' Capture and add Retention Rate Gauge
            Dim retentionImage As iTextSharp.text.Image = CaptureChartAsImage(chartRetention, 200, 150)
            If retentionImage IsNot Nothing Then
                Dim retCell As New iTextSharp.text.pdf.PdfPCell(retentionImage)
                retCell.Border = iTextSharp.text.Rectangle.BOX
                retCell.Padding = 5
                retCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                retCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                gaugeTable.AddCell(retCell)
            Else
                AddChartPlaceholder(gaugeTable, "Retention Rate Gauge")
            End If

            ' Capture and add Grade Distribution Pie
            Dim gradeDistImage As iTextSharp.text.Image = CaptureChartAsImage(chartGradeDistribution, 200, 150)
            If gradeDistImage IsNot Nothing Then
                Dim gradeCell As New iTextSharp.text.pdf.PdfPCell(gradeDistImage)
                gradeCell.Border = iTextSharp.text.Rectangle.BOX
                gradeCell.Padding = 5
                gradeCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                gradeCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE
                gaugeTable.AddCell(gradeCell)
            Else
                AddChartPlaceholder(gaugeTable, "Grade Distribution")
            End If

            ' Add Performance Summary text cell
            Dim summaryCell As New iTextSharp.text.pdf.PdfPCell()
            summaryCell.Border = iTextSharp.text.Rectangle.BOX
            summaryCell.Padding = 8
            summaryCell.BackgroundColor = New iTextSharp.text.BaseColor(250, 250, 255)

            Dim summaryHeaderPara As New iTextSharp.text.Paragraph("📋 Performance Summary", boldFont)
            summaryHeaderPara.SpacingAfter = 5
            summaryCell.AddElement(summaryHeaderPara)

            If Not String.IsNullOrEmpty(lblAnalyticsSummary.Text) Then
                Dim summaryLines() As String = lblAnalyticsSummary.Text.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                For Each line In summaryLines
                    Dim linePara As New iTextSharp.text.Paragraph(line, smallFont)
                    linePara.SpacingAfter = 2
                    summaryCell.AddElement(linePara)
                Next
            End If
            gaugeTable.AddCell(summaryCell)

            doc.Add(gaugeTable)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' Create a table for bar charts (2 columns)
            Dim barChartsTable As New iTextSharp.text.pdf.PdfPTable(2)
            barChartsTable.WidthPercentage = 100
            barChartsTable.SpacingBefore = 5

            ' Capture and add Department Performance Bar Chart
            Dim deptBarImage As iTextSharp.text.Image = CaptureChartAsImage(chartPerformanceBar, 380, 180)
            If deptBarImage IsNot Nothing Then
                Dim deptCell As New iTextSharp.text.pdf.PdfPCell()
                deptCell.Border = iTextSharp.text.Rectangle.BOX
                deptCell.Padding = 5

                Dim deptTitle As New iTextSharp.text.Paragraph("📊 Course Performance by Department", boldFont)
                deptTitle.SpacingAfter = 5
                deptCell.AddElement(deptTitle)
                deptCell.AddElement(deptBarImage)
                barChartsTable.AddCell(deptCell)
            Else
                AddChartPlaceholder(barChartsTable, "Course Performance by Department")
            End If

            ' Capture and add Pass vs Fail Comparison Bar Chart
            Dim compBarImage As iTextSharp.text.Image = CaptureChartAsImage(chartDepartmentComparison, 380, 180)
            If compBarImage IsNot Nothing Then
                Dim compCell As New iTextSharp.text.pdf.PdfPCell()
                compCell.Border = iTextSharp.text.Rectangle.BOX
                compCell.Padding = 5

                Dim compTitle As New iTextSharp.text.Paragraph("📈 Pass vs Fail Comparison", boldFont)
                compTitle.SpacingAfter = 5
                compCell.AddElement(compTitle)
                compCell.AddElement(compBarImage)
                barChartsTable.AddCell(compCell)
            Else
                AddChartPlaceholder(barChartsTable, "Pass vs Fail Comparison")
            End If

            doc.Add(barChartsTable)

            ' Add new page for data table
            doc.NewPage()

            ' Add course performance data table
            Dim dataTitle As New iTextSharp.text.Paragraph("COURSE PERFORMANCE DATA", boldFont)
            dataTitle.SpacingBefore = 10
            doc.Add(dataTitle)
            doc.Add(New iTextSharp.text.Paragraph(" "))

            ' Create table for analytics data
            Dim visibleColumnCount As Integer = 0
            For Each col As DataGridViewColumn In dgvAnalytics.Columns
                If col.Visible Then visibleColumnCount += 1
            Next

            If visibleColumnCount > 0 Then
                Dim analyticsTable As New iTextSharp.text.pdf.PdfPTable(visibleColumnCount)
                analyticsTable.WidthPercentage = 100
                analyticsTable.SpacingBefore = 5

                ' Set smaller font size for cells to fit more data
                Dim cellFont As New iTextSharp.text.Font(baseFont, 7, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.Black)

                ' Add header row
                For Each col As DataGridViewColumn In dgvAnalytics.Columns
                    If col.Visible Then
                        Dim headerCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(col.HeaderText, headerFont))
                        headerCell.BackgroundColor = New iTextSharp.text.BaseColor(0, 122, 204)
                        headerCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                        headerCell.Padding = 2
                        headerCell.PaddingBottom = 3
                        analyticsTable.AddCell(headerCell)
                    End If
                Next

                ' Add data rows
                For Each row As DataGridViewRow In dgvAnalytics.Rows
                    For Each col As DataGridViewColumn In dgvAnalytics.Columns
                        If col.Visible Then
                            Dim cellValue As String = If(row.Cells(col.Index).Value IsNot Nothing, row.Cells(col.Index).Value.ToString(), "")

                            Dim dataCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(cellValue, cellFont))
                            dataCell.Padding = 2
                            dataCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER
                            dataCell.VerticalAlignment = iTextSharp.text.Element.ALIGN_MIDDLE

                            ' Color code Performance column
                            If col.HeaderText = "Performance" Then
                                Select Case cellValue
                                    Case "Excellent"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(0, 128, 0)
                                        dataCell.Phrase = New iTextSharp.text.Phrase(cellValue, New iTextSharp.text.Font(baseFont, 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.White))
                                    Case "Very Good"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(144, 238, 144)
                                    Case "Good"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(255, 255, 224)
                                    Case "Fair"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(255, 165, 0)
                                        dataCell.Phrase = New iTextSharp.text.Phrase(cellValue, New iTextSharp.text.Font(baseFont, 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.White))
                                    Case "Needs Improvement"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(255, 182, 193)
                                End Select
                            End If

                            ' Color code Risk Level column
                            If col.HeaderText = "Risk Level" Then
                                Select Case cellValue
                                    Case "High Risk", "High Attrition"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(139, 0, 0)
                                        dataCell.Phrase = New iTextSharp.text.Phrase(cellValue, New iTextSharp.text.Font(baseFont, 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.White))
                                    Case "Medium Risk", "Moderate Attrition"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(255, 165, 0)
                                        dataCell.Phrase = New iTextSharp.text.Phrase(cellValue, New iTextSharp.text.Font(baseFont, 7, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.White))
                                    Case "Low Risk", "Low Attrition"
                                        dataCell.BackgroundColor = New iTextSharp.text.BaseColor(144, 238, 144)
                                End Select
                            End If

                            analyticsTable.AddCell(dataCell)
                        End If
                    Next
                Next

                doc.Add(analyticsTable)
            End If

            ' Add footer
            doc.Add(New iTextSharp.text.Paragraph(" "))
            Dim footer As New iTextSharp.text.Paragraph("End of Analytics Report - Generated by MGOD LMS", smallFont)
            footer.Alignment = iTextSharp.text.Element.ALIGN_CENTER
            doc.Add(footer)

        Finally
            doc.Close()
        End Try
    End Sub

    ' Helper method to capture chart as image for PDF
    Private Function CaptureChartAsImage(chart As Control, width As Integer, height As Integer) As iTextSharp.text.Image
        Try
            If chart Is Nothing OrElse chart.Width = 0 OrElse chart.Height = 0 Then
                Return Nothing
       End If

        ' Create bitmap from control
       Dim bmp As New Bitmap(chart.Width, chart.Height)
        chart.DrawToBitmap(bmp, New System.Drawing.Rectangle(0, 0, chart.Width, chart.Height))

       ' Convert to memory stream
   Using ms As New System.IO.MemoryStream()
           bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
             ms.Position = 0

          ' Create iTextSharp image
         Dim img As iTextSharp.text.Image = iTextSharp.text.Image.GetInstance(ms.ToArray())
     img.ScaleToFit(width, height)
     Return img
       End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' Helper method to add KPI cell
Private Sub AddKPICell(table As iTextSharp.text.pdf.PdfPTable, title As String, value As String, accentColor As iTextSharp.text.BaseColor)
Dim cell As New iTextSharp.text.pdf.PdfPCell()
  cell.Border = iTextSharp.text.Rectangle.BOX
        cell.Padding = 8
        cell.BackgroundColor = New iTextSharp.text.BaseColor(250, 250, 255)

    ' Title
        Dim titlePara As New iTextSharp.text.Paragraph(title, smallFont)
    titlePara.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        cell.AddElement(titlePara)

        ' Value
  Dim valueFont As New iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD, accentColor)
        Dim valuePara As New iTextSharp.text.Paragraph(value, valueFont)
        valuePara.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        valuePara.SpacingBefore = 5
        cell.AddElement(valuePara)

      table.AddCell(cell)
    End Sub

    ' Helper method to add chart placeholder if capture fails
    Private Sub AddChartPlaceholder(table As iTextSharp.text.pdf.PdfPTable, chartName As String)
        Dim cell As New iTextSharp.text.pdf.PdfPCell()
        cell.Border = iTextSharp.text.Rectangle.BOX
        cell.Padding = 20
        cell.BackgroundColor = New iTextSharp.text.BaseColor(245, 245, 245)
        cell.MinimumHeight = 150

Dim placeholder As New iTextSharp.text.Paragraph($"[{chartName}]" & vbCrLf & "(Chart image not available)", normalFont)
        placeholder.Alignment = iTextSharp.text.Element.ALIGN_CENTER
        cell.AddElement(placeholder)

        table.AddCell(cell)
    End Sub

    Private Sub AddFilterRow(table As iTextSharp.text.pdf.PdfPTable, label As String, value As String)
        Dim labelCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(label & ":", boldFont))
        labelCell.Border = iTextSharp.text.Rectangle.NO_BORDER
        labelCell.PaddingBottom = 3

      Dim valueCell As New iTextSharp.text.pdf.PdfPCell(New iTextSharp.text.Phrase(value, normalFont))
valueCell.Border = iTextSharp.text.Rectangle.NO_BORDER
      valueCell.PaddingBottom = 3

  table.AddCell(labelCell)
        table.AddCell(valueCell)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class