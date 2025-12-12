<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportsForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlSidebar = New Panel()
        btnCourseAnalytics = New Button()
        btnStudentTranscript = New Button()
        lblReportsTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlStudentTranscript = New Panel()
        pnlCourseAnalytics = New Panel()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCourseAnalytics)
        pnlSidebar.Controls.Add(btnStudentTranscript)
        pnlSidebar.Controls.Add(lblReportsTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnStudentTranscript
        ' 
        btnStudentTranscript.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnStudentTranscript.Dock = DockStyle.Top
        btnStudentTranscript.FlatAppearance.BorderSize = 0
        btnStudentTranscript.FlatStyle = FlatStyle.Flat
        btnStudentTranscript.Font = New Font("Times New Roman", 11.0F)
        btnStudentTranscript.ForeColor = Color.White
        btnStudentTranscript.Location = New Point(0, 80)
        btnStudentTranscript.Name = "btnStudentTranscript"
        btnStudentTranscript.Size = New Size(220, 50)
        btnStudentTranscript.TabIndex = 1
        btnStudentTranscript.Text = "📄 Student Transcript Generator"
        btnStudentTranscript.UseVisualStyleBackColor = False
        ' 
        ' btnCourseAnalytics
        ' 
        btnCourseAnalytics.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCourseAnalytics.Dock = DockStyle.Top
        btnCourseAnalytics.FlatAppearance.BorderSize = 0
        btnCourseAnalytics.FlatStyle = FlatStyle.Flat
        btnCourseAnalytics.Font = New Font("Times New Roman", 11.0F)
        btnCourseAnalytics.ForeColor = Color.White
        btnCourseAnalytics.Location = New Point(0, 130)
        btnCourseAnalytics.Name = "btnCourseAnalytics"
        btnCourseAnalytics.Size = New Size(220, 50)
        btnCourseAnalytics.TabIndex = 2
        btnCourseAnalytics.Text = "📊 Course Analytics"
        btnCourseAnalytics.UseVisualStyleBackColor = False
        ' 
        ' lblReportsTitle
        ' 
        lblReportsTitle.BackColor = Color.Navy
        lblReportsTitle.Dock = DockStyle.Top
        lblReportsTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblReportsTitle.ForeColor = Color.White
        lblReportsTitle.Location = New Point(0, 0)
        lblReportsTitle.Name = "lblReportsTitle"
        lblReportsTitle.Size = New Size(220, 80)
        lblReportsTitle.TabIndex = 0
        lblReportsTitle.Text = "Reports"
        lblReportsTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnClose.Dock = DockStyle.Bottom
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(0, 750)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(220, 50)
        btnClose.TabIndex = 3
        btnClose.Text = "🚪 Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlMainContent.Controls.Add(pnlStudentTranscript)
        pnlMainContent.Controls.Add(pnlCourseAnalytics)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlStudentTranscript
        ' 
        pnlStudentTranscript.Dock = DockStyle.Fill
        pnlStudentTranscript.Location = New Point(0, 0)
        pnlStudentTranscript.Name = "pnlStudentTranscript"
        pnlStudentTranscript.Size = New Size(980, 800)
        pnlStudentTranscript.TabIndex = 0
        pnlStudentTranscript.Visible = True
        ' 
        ' pnlCourseAnalytics
        ' 
        pnlCourseAnalytics.Dock = DockStyle.Fill
        pnlCourseAnalytics.Location = New Point(0, 0)
        pnlCourseAnalytics.Name = "pnlCourseAnalytics"
        pnlCourseAnalytics.Size = New Size(980, 800)
        pnlCourseAnalytics.TabIndex = 1
        pnlCourseAnalytics.Visible = False
        ' 
        ' ReportsForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "ReportsForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reports - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        ResumeLayout(False)

        ' Initialize Student Transcript controls after form is created
        InitializeStudentTranscriptPanel()
        ' Initialize Course Analytics controls
        InitializeCourseAnalyticsPanel()
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblReportsTitle As Label
    Friend WithEvents btnStudentTranscript As Button
    Friend WithEvents btnCourseAnalytics As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents pnlStudentTranscript As Panel
    Friend WithEvents pnlCourseAnalytics As Panel

    ' Student Transcript Controls
    Friend WithEvents lblTranscriptTitle As Label
    Friend WithEvents txtStudentSearch As TextBox
    Friend WithEvents cmbStudentSelect As ComboBox
    Friend WithEvents btnGenerateTranscript As Button
    Friend WithEvents lblStudentInfo As Label
    Friend WithEvents dgvTranscript As DataGridView
    Friend WithEvents grpTranscriptSummary As GroupBox
    Friend WithEvents lblTranscriptSummary As Label
    Friend WithEvents btnExportTranscript As Button

    ' Course Analytics Controls
    Friend WithEvents lblAnalyticsTitle As Label
    Friend WithEvents grpAnalyticsFilters As GroupBox
    Friend WithEvents cmbAcademicYear As ComboBox
    Friend WithEvents cmbSemester As ComboBox
    Friend WithEvents cmbTerm As ComboBox
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents cmbInstructor As ComboBox
    Friend WithEvents btnApplyFilters As Button
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents dgvAnalytics As DataGridView
    Friend WithEvents grpAnalyticsSummary As GroupBox
    Friend WithEvents lblAnalyticsSummary As Label
    Friend WithEvents btnExportAnalytics As Button

    ' New Chart Controls
    Friend WithEvents pnlChartsContainer As Panel
    Friend WithEvents pnlKPICards As Panel
    Friend WithEvents pnlPassRateGauge As Panel
    Friend WithEvents pnlRetentionGauge As Panel
    Friend WithEvents pnlBarChart As Panel
    Friend WithEvents pnlPieChart As Panel
    Friend WithEvents pnlLineChart As Panel
    Friend WithEvents pnlStackedBarChart As Panel

    ' KPI Card Labels
    Friend WithEvents lblTotalCoursesValue As Label
    Friend WithEvents lblTotalCoursesLabel As Label
    Friend WithEvents lblTotalStudentsValue As Label
    Friend WithEvents lblTotalStudentsLabel As Label
    Friend WithEvents lblAvgGradeValue As Label
    Friend WithEvents lblAvgGradeLabel As Label
    Friend WithEvents lblPassRateValue As Label
    Friend WithEvents lblPassRateLabel As Label

    ' Chart Controls
    Friend WithEvents chartPassRate As LiveChartsCore.SkiaSharpView.WinForms.PieChart
    Friend WithEvents chartRetention As LiveChartsCore.SkiaSharpView.WinForms.PieChart
    Friend WithEvents chartPerformanceBar As LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
    Friend WithEvents chartGradeDistribution As LiveChartsCore.SkiaSharpView.WinForms.PieChart
    Friend WithEvents chartTrendLine As LiveChartsCore.SkiaSharpView.WinForms.CartesianChart
    Friend WithEvents chartDepartmentComparison As LiveChartsCore.SkiaSharpView.WinForms.CartesianChart

    ' Toggle between chart view and table view
    Friend WithEvents btnToggleView As Button
    Friend WithEvents pnlTableContainer As Panel

    Private Sub InitializeStudentTranscriptPanel()
        pnlStudentTranscript.SuspendLayout()

        ' IMPORTANT: Enable auto-scroll for the panel to handle overflow
        pnlStudentTranscript.AutoScroll = True

        ' Title Label
        lblTranscriptTitle = New Label With {
            .Text = "Student Transcript Generator",
     .Font = New Font("Times New Roman", 20, FontStyle.Bold),
       .ForeColor = Color.FromArgb(0, 122, 204),
            .Location = New Point(30, 20),
      .Size = New Size(500, 40),
            .AutoSize = False
        }
        pnlStudentTranscript.Controls.Add(lblTranscriptTitle)

        ' Search Label
        Dim lblSearch As New Label With {
      .Text = "Search Student:",
      .Font = New Font("Times New Roman", 12, FontStyle.Bold),
         .Location = New Point(30, 80),
      .Size = New Size(150, 25)
        }
        pnlStudentTranscript.Controls.Add(lblSearch)

        ' Search TextBox
        txtStudentSearch = New TextBox With {
            .Name = "txtStudentSearch",
        .Font = New Font("Times New Roman", 11),
            .Location = New Point(30, 110),
            .Size = New Size(250, 25),
            .PlaceholderText = "Type student number or name..."
        }
        pnlStudentTranscript.Controls.Add(txtStudentSearch)

        ' Student ComboBox Label
        Dim lblStudent As New Label With {
            .Text = "Select Student:",
      .Font = New Font("Times New Roman", 12, FontStyle.Bold),
       .Location = New Point(300, 80),
      .Size = New Size(150, 25)
        }
        pnlStudentTranscript.Controls.Add(lblStudent)

        ' Student ComboBox
        cmbStudentSelect = New ComboBox With {
            .Name = "cmbStudentSelect",
   .Font = New Font("Times New Roman", 11),
      .Location = New Point(300, 110),
     .Size = New Size(450, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        pnlStudentTranscript.Controls.Add(cmbStudentSelect)

        ' Generate Button
        btnGenerateTranscript = New Button With {
            .Name = "btnGenerateTranscript",
          .Text = "Generate Transcript",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(770, 107),
   .Size = New Size(180, 30),
     .BackColor = Color.FromArgb(0, 122, 204),
       .ForeColor = Color.White,
     .FlatStyle = FlatStyle.Flat
        }
        pnlStudentTranscript.Controls.Add(btnGenerateTranscript)

        ' Student Info Label - INCREASED HEIGHT to show all 8+ lines properly
        lblStudentInfo = New Label With {
          .Name = "lblStudentInfo",
          .Text = "",
       .Font = New Font("Times New Roman", 10, FontStyle.Regular),
         .Location = New Point(30, 150),
     .Size = New Size(1150, 150),
  .BorderStyle = BorderStyle.FixedSingle,
 .BackColor = Color.FromArgb(250, 250, 255),
.Visible = False,
      .Padding = New Padding(10),
    .AutoSize = False,
       .UseMnemonic = False
        }
        pnlStudentTranscript.Controls.Add(lblStudentInfo)

        ' Transcript DataGridView - FULL WIDTH with Scroll
        dgvTranscript = New DataGridView With {
 .Name = "dgvTranscript",
   .Location = New Point(30, 300),
          .Size = New Size(1150, 290),
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
 .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
          .ReadOnly = True,
     .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        .MultiSelect = False,
.BackgroundColor = Color.White,
        .BorderStyle = BorderStyle.Fixed3D,
        .ScrollBars = ScrollBars.Both,
            .ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
    .Font = New Font("Times New Roman", 10, FontStyle.Bold),
      .BackColor = Color.FromArgb(0, 122, 204),
     .ForeColor = Color.White,
    .Alignment = DataGridViewContentAlignment.MiddleCenter,
  .WrapMode = DataGridViewTriState.True
            },
  .DefaultCellStyle = New DataGridViewCellStyle With {
       .Font = New Font("Times New Roman", 10),
.SelectionBackColor = Color.FromArgb(173, 216, 230),
      .SelectionForeColor = Color.Black,
         .WrapMode = DataGridViewTriState.False
  },
          .RowTemplate = New DataGridViewRow With {
       .Height = 28
            },
          .ColumnHeadersHeight = 35
  }
        pnlStudentTranscript.Controls.Add(dgvTranscript)

        ' Summary GroupBox - Wider at bottom
        grpTranscriptSummary = New GroupBox With {
    .Name = "grpTranscriptSummary",
            .Text = "📚 TRANSCRIPT SUMMARY",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
  .Location = New Point(30, 600),
     .Size = New Size(600, 120),
    .Visible = False
      }
        pnlStudentTranscript.Controls.Add(grpTranscriptSummary)

        ' Summary Label inside GroupBox
        lblTranscriptSummary = New Label With {
        .Name = "lblTranscriptSummary",
            .Text = "",
        .Font = New Font("Times New Roman", 10),
    .Location = New Point(10, 25),
   .Size = New Size(580, 85),
        .AutoSize = False
        }
        grpTranscriptSummary.Controls.Add(lblTranscriptSummary)

        ' Export Button
        btnExportTranscript = New Button With {
     .Name = "btnExportTranscript",
     .Text = "📤 Export to PDF",
   .Font = New Font("Times New Roman", 11, FontStyle.Bold),
   .Location = New Point(660, 620),
      .Size = New Size(250, 45),
      .BackColor = Color.FromArgb(0, 122, 204),
  .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        pnlStudentTranscript.Controls.Add(btnExportTranscript)


        pnlStudentTranscript.ResumeLayout(False)
    End Sub

    Private Sub InitializeCourseAnalyticsPanel()
        pnlCourseAnalytics.SuspendLayout()

        ' Enable auto-scroll
        pnlCourseAnalytics.AutoScroll = True

        ' Title Label
        lblAnalyticsTitle = New Label With {
            .Text = "📊 Course Performance Analytics Dashboard",
    .Font = New Font("Segoe UI", 18, FontStyle.Bold),
    .ForeColor = Color.FromArgb(0, 122, 204),
       .Location = New Point(20, 15),
            .Size = New Size(500, 35),
  .AutoSize = False
   }
        pnlCourseAnalytics.Controls.Add(lblAnalyticsTitle)

        ' Toggle View Button
        btnToggleView = New Button With {
            .Name = "btnToggleView",
  .Text = "📋 Show Table View",
       .Font = New Font("Segoe UI", 10, FontStyle.Bold),
      .Location = New Point(520, 18),
    .Size = New Size(150, 30),
            .BackColor = Color.FromArgb(108, 117, 125),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        pnlCourseAnalytics.Controls.Add(btnToggleView)

        ' Filters GroupBox - Compact design
        grpAnalyticsFilters = New GroupBox With {
    .Name = "grpAnalyticsFilters",
 .Text = "🔍 Filters",
   .Font = New Font("Segoe UI", 10, FontStyle.Bold),
      .Location = New Point(20, 55),
     .Size = New Size(1140, 100),
            .BackColor = Color.White
        }
        pnlCourseAnalytics.Controls.Add(grpAnalyticsFilters)

        ' Row 1 Filters
        Dim lblAcademicYear As New Label With {
         .Text = "Academic Year:",
      .Font = New Font("Segoe UI", 9),
  .Location = New Point(15, 25),
      .Size = New Size(90, 20)
        }
        grpAnalyticsFilters.Controls.Add(lblAcademicYear)

        cmbAcademicYear = New ComboBox With {
   .Name = "cmbAcademicYear",
       .Font = New Font("Segoe UI", 9),
       .Location = New Point(15, 48),
     .Size = New Size(130, 25),
      .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpAnalyticsFilters.Controls.Add(cmbAcademicYear)

        Dim lblSemester As New Label With {
  .Text = "Semester:",
       .Font = New Font("Segoe UI", 9),
      .Location = New Point(155, 25),
            .Size = New Size(70, 20)
        }
        grpAnalyticsFilters.Controls.Add(lblSemester)

        cmbSemester = New ComboBox With {
            .Name = "cmbSemester",
  .Font = New Font("Segoe UI", 9),
            .Location = New Point(155, 48),
  .Size = New Size(120, 25),
   .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpAnalyticsFilters.Controls.Add(cmbSemester)

        Dim lblTerm As New Label With {
  .Text = "Term:",
            .Font = New Font("Segoe UI", 9),
       .Location = New Point(285, 25),
      .Size = New Size(50, 20)
        }
        grpAnalyticsFilters.Controls.Add(lblTerm)

        cmbTerm = New ComboBox With {
     .Name = "cmbTerm",
 .Font = New Font("Segoe UI", 9),
  .Location = New Point(285, 48),
.Size = New Size(100, 25),
   .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpAnalyticsFilters.Controls.Add(cmbTerm)

        Dim lblDepartment As New Label With {
         .Text = "Department:",
            .Font = New Font("Segoe UI", 9),
 .Location = New Point(395, 25),
         .Size = New Size(80, 20)
 }
        grpAnalyticsFilters.Controls.Add(lblDepartment)

        cmbDepartment = New ComboBox With {
            .Name = "cmbDepartment",
            .Font = New Font("Segoe UI", 9),
            .Location = New Point(395, 48),
    .Size = New Size(150, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
   }
        grpAnalyticsFilters.Controls.Add(cmbDepartment)

        Dim lblCourse As New Label With {
       .Text = "Course:",
     .Font = New Font("Segoe UI", 9),
       .Location = New Point(555, 25),
    .Size = New Size(60, 20)
        }
        grpAnalyticsFilters.Controls.Add(lblCourse)

        cmbCourse = New ComboBox With {
 .Name = "cmbCourse",
    .Font = New Font("Segoe UI", 9),
    .Location = New Point(555, 48),
       .Size = New Size(180, 25),
         .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpAnalyticsFilters.Controls.Add(cmbCourse)

        Dim lblInstructor As New Label With {
   .Text = "Instructor:",
     .Font = New Font("Segoe UI", 9),
          .Location = New Point(745, 25),
            .Size = New Size(70, 20)
        }
        grpAnalyticsFilters.Controls.Add(lblInstructor)

        cmbInstructor = New ComboBox With {
        .Name = "cmbInstructor",
     .Font = New Font("Segoe UI", 9),
            .Location = New Point(745, 48),
     .Size = New Size(170, 25),
         .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpAnalyticsFilters.Controls.Add(cmbInstructor)

        ' Buttons
        btnApplyFilters = New Button With {
            .Name = "btnApplyFilters",
   .Text = "📊 Apply",
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .Location = New Point(930, 30),
    .Size = New Size(90, 28),
            .BackColor = Color.FromArgb(0, 122, 204),
    .ForeColor = Color.White,
         .FlatStyle = FlatStyle.Flat
  }
        grpAnalyticsFilters.Controls.Add(btnApplyFilters)

        btnClearFilters = New Button With {
            .Name = "btnClearFilters",
         .Text = "🔄 Clear",
         .Font = New Font("Segoe UI", 9, FontStyle.Bold),
  .Location = New Point(1030, 30),
      .Size = New Size(90, 28),
      .BackColor = Color.FromArgb(108, 117, 125),
       .ForeColor = Color.White,
   .FlatStyle = FlatStyle.Flat
        }
        grpAnalyticsFilters.Controls.Add(btnClearFilters)

        ' ====== CHARTS CONTAINER ======
        pnlChartsContainer = New Panel With {
    .Name = "pnlChartsContainer",
          .Location = New Point(20, 160),
            .Size = New Size(1140, 550),
        .BackColor = Color.FromArgb(245, 247, 250),
     .Visible = True
      }
        pnlCourseAnalytics.Controls.Add(pnlChartsContainer)

        ' ====== KPI CARDS ROW ======
        pnlKPICards = New Panel With {
            .Name = "pnlKPICards",
       .Location = New Point(0, 0),
  .Size = New Size(1140, 90),
.BackColor = Color.Transparent
        }
        pnlChartsContainer.Controls.Add(pnlKPICards)

        ' Create KPI Cards
        CreateKPICard(pnlKPICards, 0, "📚", "Total Courses", "0", Color.FromArgb(0, 122, 204), lblTotalCoursesValue, lblTotalCoursesLabel)
        CreateKPICard(pnlKPICards, 1, "👥", "Total Students Enrolled", "0", Color.FromArgb(40, 167, 69), lblTotalStudentsValue, lblTotalStudentsLabel)
        CreateKPICard(pnlKPICards, 2, "📈", "Avg Grade", "0%", Color.FromArgb(255, 193, 7), lblAvgGradeValue, lblAvgGradeLabel)
        CreateKPICard(pnlKPICards, 3, "✅", "Pass Rate", "0%", Color.FromArgb(220, 53, 69), lblPassRateValue, lblPassRateLabel)

        ' ====== GAUGE CHARTS ROW ======
        ' Pass Rate Gauge Panel
        pnlPassRateGauge = New Panel With {
        .Name = "pnlPassRateGauge",
      .Location = New Point(0, 95),
.Size = New Size(280, 220),
  .BackColor = Color.White,
      .BorderStyle = BorderStyle.FixedSingle
        }
        pnlChartsContainer.Controls.Add(pnlPassRateGauge)

        Dim lblPassRateTitle As New Label With {
     .Text = "📊 Pass Rate",
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.FromArgb(50, 50, 50),
            .Location = New Point(10, 8),
          .Size = New Size(260, 25),
         .TextAlign = ContentAlignment.MiddleCenter
      }
        pnlPassRateGauge.Controls.Add(lblPassRateTitle)

        chartPassRate = New LiveChartsCore.SkiaSharpView.WinForms.PieChart With {
            .Name = "chartPassRate",
    .Location = New Point(5, 35),
       .Size = New Size(268, 180)
        }
        pnlPassRateGauge.Controls.Add(chartPassRate)

        ' Retention Rate Gauge Panel
        pnlRetentionGauge = New Panel With {
            .Name = "pnlRetentionGauge",
            .Location = New Point(290, 95),
            .Size = New Size(280, 220),
        .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }
        pnlChartsContainer.Controls.Add(pnlRetentionGauge)

        Dim lblRetentionTitle As New Label With {
     .Text = "📈 Retention Rate",
         .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .ForeColor = Color.FromArgb(50, 50, 50),
        .Location = New Point(10, 8),
 .Size = New Size(260, 25),
     .TextAlign = ContentAlignment.MiddleCenter
     }
        pnlRetentionGauge.Controls.Add(lblRetentionTitle)

        chartRetention = New LiveChartsCore.SkiaSharpView.WinForms.PieChart With {
            .Name = "chartRetention",
   .Location = New Point(5, 35),
          .Size = New Size(268, 180)
        }
        pnlRetentionGauge.Controls.Add(chartRetention)

        ' Grade Distribution Pie Chart Panel
        pnlPieChart = New Panel With {
      .Name = "pnlPieChart",
    .Location = New Point(580, 95),
          .Size = New Size(280, 220),
            .BackColor = Color.White,
    .BorderStyle = BorderStyle.FixedSingle
        }
        pnlChartsContainer.Controls.Add(pnlPieChart)

        Dim lblPieTitle As New Label With {
            .Text = "🎯 Grade Distribution",
 .Font = New Font("Segoe UI", 11, FontStyle.Bold),
       .ForeColor = Color.FromArgb(50, 50, 50),
            .Location = New Point(10, 8),
          .Size = New Size(260, 25),
   .TextAlign = ContentAlignment.MiddleCenter
        }
        pnlPieChart.Controls.Add(lblPieTitle)

        chartGradeDistribution = New LiveChartsCore.SkiaSharpView.WinForms.PieChart With {
            .Name = "chartGradeDistribution",
        .Location = New Point(5, 35),
        .Size = New Size(268, 180)
        }
        pnlPieChart.Controls.Add(chartGradeDistribution)

        ' Performance Summary Panel (for stats)
        Dim pnlPerformanceSummary As New Panel With {
   .Name = "pnlPerformanceSummary",
      .Location = New Point(870, 95),
   .Size = New Size(268, 220),
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
}
        pnlChartsContainer.Controls.Add(pnlPerformanceSummary)

        Dim lblPerfTitle As New Label With {
 .Text = "📋 Performance Summary",
  .Font = New Font("Segoe UI", 11, FontStyle.Bold),
   .ForeColor = Color.FromArgb(50, 50, 50),
     .Location = New Point(10, 8),
            .Size = New Size(248, 25),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        pnlPerformanceSummary.Controls.Add(lblPerfTitle)

        grpAnalyticsSummary = New GroupBox With {
            .Name = "grpAnalyticsSummary",
          .Text = "",
        .Font = New Font("Segoe UI", 9),
            .Location = New Point(5, 35),
   .Size = New Size(256, 180),
     .Visible = True
        }
        pnlPerformanceSummary.Controls.Add(grpAnalyticsSummary)

        lblAnalyticsSummary = New Label With {
      .Name = "lblAnalyticsSummary",
       .Text = "Apply filters to see analytics summary...",
       .Font = New Font("Segoe UI", 9),
.Location = New Point(5, 12),
     .Size = New Size(246, 160),
 .AutoSize = False
    }
        grpAnalyticsSummary.Controls.Add(lblAnalyticsSummary)

        ' ====== BAR CHART ROW ======
        pnlBarChart = New Panel With {
 .Name = "pnlBarChart",
       .Location = New Point(0, 320),
     .Size = New Size(565, 225),
          .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
     }
        pnlChartsContainer.Controls.Add(pnlBarChart)

        Dim lblBarTitle As New Label With {
  .Text = "📊 Course Performance by Department",
    .Font = New Font("Segoe UI", 11, FontStyle.Bold),
      .ForeColor = Color.FromArgb(50, 50, 50),
         .Location = New Point(10, 8),
 .Size = New Size(545, 50),
   .TextAlign = ContentAlignment.MiddleLeft
 }
        pnlBarChart.Controls.Add(lblBarTitle)

        chartPerformanceBar = New LiveChartsCore.SkiaSharpView.WinForms.CartesianChart With {
            .Name = "chartPerformanceBar",
  .Location = New Point(5, 35),
            .Size = New Size(553, 185)
   }
        pnlBarChart.Controls.Add(chartPerformanceBar)

        ' ====== STACKED BAR / LINE CHART ======
        pnlStackedBarChart = New Panel With {
            .Name = "pnlStackedBarChart",
        .Location = New Point(573, 320),
            .Size = New Size(565, 225),
        .BackColor = Color.White,
        .BorderStyle = BorderStyle.FixedSingle
        }
        pnlChartsContainer.Controls.Add(pnlStackedBarChart)

        Dim lblStackedTitle As New Label With {
  .Text = "📈 Pass vs Fail Comparison",
  .Font = New Font("Segoe UI", 11, FontStyle.Bold),
        .ForeColor = Color.FromArgb(50, 50, 50),
          .Location = New Point(10, 8),
    .Size = New Size(545, 25),
 .TextAlign = ContentAlignment.MiddleLeft
   }
        pnlStackedBarChart.Controls.Add(lblStackedTitle)

        chartDepartmentComparison = New LiveChartsCore.SkiaSharpView.WinForms.CartesianChart With {
  .Name = "chartDepartmentComparison",
            .Location = New Point(5, 35),
            .Size = New Size(553, 185)
        }
        pnlStackedBarChart.Controls.Add(chartDepartmentComparison)

        ' ====== TABLE CONTAINER (Hidden by default) ======
        pnlTableContainer = New Panel With {
         .Name = "pnlTableContainer",
  .Location = New Point(20, 160),
            .Size = New Size(1140, 550),
   .BackColor = Color.White,
            .Visible = False
        }
        pnlCourseAnalytics.Controls.Add(pnlTableContainer)

        ' Analytics DataGridView (inside table container)
        dgvAnalytics = New DataGridView With {
            .Name = "dgvAnalytics",
            .Location = New Point(5, 5),
       .Size = New Size(1130, 490),
  .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
     .AllowUserToAddRows = False,
     .AllowUserToDeleteRows = False,
            .ReadOnly = True,
.SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        .MultiSelect = False,
    .BackgroundColor = Color.White,
        .BorderStyle = BorderStyle.Fixed3D,
   .ScrollBars = ScrollBars.Both,
            .ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
   .Font = New Font("Segoe UI", 9, FontStyle.Bold),
    .BackColor = Color.FromArgb(0, 122, 204),
         .ForeColor = Color.White,
        .Alignment = DataGridViewContentAlignment.MiddleCenter,
    .WrapMode = DataGridViewTriState.True
    },
         .DefaultCellStyle = New DataGridViewCellStyle With {
           .Font = New Font("Segoe UI", 9),
        .SelectionBackColor = Color.FromArgb(173, 216, 230),
 .SelectionForeColor = Color.Black,
         .WrapMode = DataGridViewTriState.False
            },
            .RowTemplate = New DataGridViewRow With {
     .Height = 28
       },
      .ColumnHeadersHeight = 35
  }
        pnlTableContainer.Controls.Add(dgvAnalytics)

        ' Export Button
        btnExportAnalytics = New Button With {
  .Name = "btnExportAnalytics",
   .Text = "📤 Export Analytics to PDF",
    .Font = New Font("Segoe UI", 10, FontStyle.Bold),
  .Location = New Point(20, 715),
            .Size = New Size(200, 40),
    .BackColor = Color.FromArgb(0, 122, 204),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        pnlCourseAnalytics.Controls.Add(btnExportAnalytics)

        pnlCourseAnalytics.ResumeLayout(False)
    End Sub

    Private Sub CreateKPICard(container As Panel, index As Integer, icon As String, title As String, value As String, accentColor As Color, ByRef valueLabel As Label, ByRef titleLabel As Label)
        Dim cardWidth As Integer = 275
        Dim cardHeight As Integer = 85
        Dim spacing As Integer = 10
        Dim xPos As Integer = index * (cardWidth + spacing)

        Dim card As New Panel With {
        .Location = New Point(xPos, 0),
    .Size = New Size(cardWidth, cardHeight),
  .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' Accent bar on the left
        Dim accentBar As New Panel With {
            .Location = New Point(0, 0),
       .Size = New Size(5, cardHeight),
            .BackColor = accentColor
        }
        card.Controls.Add(accentBar)

        ' Icon label
        Dim iconLabel As New Label With {
    .Text = icon,
       .Font = New Font("Segoe UI", 24),
       .Location = New Point(15, 15),
     .Size = New Size(50, 50),
 .TextAlign = ContentAlignment.MiddleCenter
        }
        card.Controls.Add(iconLabel)

        ' Value label
        valueLabel = New Label With {
            .Text = value,
 .Font = New Font("Segoe UI", 22, FontStyle.Bold),
            .ForeColor = accentColor,
            .Location = New Point(70, 10),
   .Size = New Size(195, 40),
   .TextAlign = ContentAlignment.MiddleLeft
        }
        card.Controls.Add(valueLabel)

        ' Title label
        titleLabel = New Label With {
            .Text = title,
            .Font = New Font("Segoe UI", 10),
.ForeColor = Color.Gray,
            .Location = New Point(70, 50),
      .Size = New Size(195, 25),
          .TextAlign = ContentAlignment.MiddleLeft
        }
        card.Controls.Add(titleLabel)

        container.Controls.Add(card)
    End Sub
End Class
