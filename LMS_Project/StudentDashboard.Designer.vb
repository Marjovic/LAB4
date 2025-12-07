<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentDashboard
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim DataGridViewCellStyle9 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlSidebar = New Panel()
        btnGradeSummary = New Button()
        btnViewGrades = New Button()
        btnMyEnrollments = New Button()
        btnDashboard = New Button()
        lblStudentTitle = New Label()
        btnLogout = New Button()
        pnlMainContent = New Panel()
        pnlDashboard = New Panel()
        lblDashboardTitle = New Label()
        lblWelcome = New Label()
        lblStudentInfo = New Label()
        pnlStats = New Panel()
        lblEnrolledCourses = New Label()
        lblCurrentSemester = New Label()
        lblYearLevel = New Label()
        lblOverallGPA = New Label()
        pnlMyEnrollments = New Panel()
        lblMyEnrollmentsTitle = New Label()
        dgvMyEnrollments = New DataGridView()
        btnRefreshEnrollments = New Button()
        pnlViewGrades = New Panel()
        lblViewGradesTitle = New Label()
        lblSelectCourseGrade = New Label()
        cmbCourseForGrades = New ComboBox()
        btnLoadGrades = New Button()
        dgvMyGrades = New DataGridView()
        btnRefreshGrades = New Button()
        pnlGradeSummary = New Panel()
        lblGradeSummaryTitle = New Label()
        lblFilterSemester = New Label()
        cmbFilterSemester = New ComboBox()
        btnLoadGradeSummary = New Button()
        btnRefreshGradeSummary = New Button()
        dgvGradeSummary = New DataGridView()
        pnlCourseAverages = New Panel()
        lblCourseAveragesTitle = New Label()
        dgvCourseAverages = New DataGridView()
        lblOverallAverageDisplay = New Label()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlStats.SuspendLayout()
        pnlMyEnrollments.SuspendLayout()
        CType(dgvMyEnrollments, ComponentModel.ISupportInitialize).BeginInit()
        pnlViewGrades.SuspendLayout()
        CType(dgvMyGrades, ComponentModel.ISupportInitialize).BeginInit()
        pnlGradeSummary.SuspendLayout()
        CType(dgvGradeSummary, ComponentModel.ISupportInitialize).BeginInit()
        pnlCourseAverages.SuspendLayout()
        CType(dgvCourseAverages, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnGradeSummary)
        pnlSidebar.Controls.Add(btnViewGrades)
        pnlSidebar.Controls.Add(btnMyEnrollments)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Controls.Add(lblStudentTitle)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(227, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnGradeSummary
        ' 
        btnGradeSummary.BackColor = SystemColors.MenuHighlight
        btnGradeSummary.Dock = DockStyle.Top
        btnGradeSummary.FlatAppearance.BorderSize = 0
        btnGradeSummary.FlatStyle = FlatStyle.Flat
        btnGradeSummary.Font = New Font("Times New Roman", 12F)
        btnGradeSummary.ForeColor = Color.White
        btnGradeSummary.Location = New Point(0, 228)
        btnGradeSummary.Name = "btnGradeSummary"
        btnGradeSummary.Padding = New Padding(10, 0, 0, 0)
        btnGradeSummary.Size = New Size(227, 50)
        btnGradeSummary.TabIndex = 4
        btnGradeSummary.Text = "📈 Grade Summary"
        btnGradeSummary.TextAlign = ContentAlignment.MiddleLeft
        btnGradeSummary.UseVisualStyleBackColor = False
        ' 
        ' btnViewGrades
        ' 
        btnViewGrades.BackColor = SystemColors.MenuHighlight
        btnViewGrades.Dock = DockStyle.Top
        btnViewGrades.FlatAppearance.BorderSize = 0
        btnViewGrades.FlatStyle = FlatStyle.Flat
        btnViewGrades.Font = New Font("Times New Roman", 12F)
        btnViewGrades.ForeColor = Color.White
        btnViewGrades.Location = New Point(0, 178)
        btnViewGrades.Name = "btnViewGrades"
        btnViewGrades.Padding = New Padding(10, 0, 0, 0)
        btnViewGrades.Size = New Size(227, 50)
        btnViewGrades.TabIndex = 3
        btnViewGrades.Text = "📊 View My Grades"
        btnViewGrades.TextAlign = ContentAlignment.MiddleLeft
        btnViewGrades.UseVisualStyleBackColor = False
        ' 
        ' btnMyEnrollments
        ' 
        btnMyEnrollments.BackColor = SystemColors.MenuHighlight
        btnMyEnrollments.Dock = DockStyle.Top
        btnMyEnrollments.FlatAppearance.BorderSize = 0
        btnMyEnrollments.FlatStyle = FlatStyle.Flat
        btnMyEnrollments.Font = New Font("Times New Roman", 12F)
        btnMyEnrollments.ForeColor = Color.White
        btnMyEnrollments.Location = New Point(0, 128)
        btnMyEnrollments.Name = "btnMyEnrollments"
        btnMyEnrollments.Padding = New Padding(10, 0, 0, 0)
        btnMyEnrollments.Size = New Size(227, 50)
        btnMyEnrollments.TabIndex = 2
        btnMyEnrollments.Text = "📝 My Enrollments"
        btnMyEnrollments.TextAlign = ContentAlignment.MiddleLeft
        btnMyEnrollments.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = SystemColors.MenuHighlight
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Times New Roman", 12F)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(0, 80)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(10, 0, 0, 0)
        btnDashboard.Size = New Size(227, 48)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "📋 Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' lblStudentTitle
        ' 
        lblStudentTitle.BackColor = Color.Navy
        lblStudentTitle.Dock = DockStyle.Top
        lblStudentTitle.Font = New Font("Times New Roman", 14F, FontStyle.Bold)
        lblStudentTitle.ForeColor = Color.White
        lblStudentTitle.Location = New Point(0, 0)
        lblStudentTitle.Name = "lblStudentTitle"
        lblStudentTitle.Size = New Size(227, 80)
        lblStudentTitle.TabIndex = 0
        lblStudentTitle.Text = "MGOD LMS" + vbCrLf + "Student Portal"
        lblStudentTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(192, 0, 0)
        btnLogout.Dock = DockStyle.Bottom
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(0, 750)
        btnLogout.Name = "btnLogout"
        btnLogout.Padding = New Padding(10, 0, 0, 0)
        btnLogout.Size = New Size(227, 50)
        btnLogout.TabIndex = 5
        btnLogout.Text = "🚪 Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(240, 240, 240)
        pnlMainContent.Controls.Add(pnlDashboard)
        pnlMainContent.Controls.Add(pnlMyEnrollments)
        pnlMainContent.Controls.Add(pnlViewGrades)
        pnlMainContent.Controls.Add(pnlGradeSummary)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(227, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(973, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = Color.White
        pnlDashboard.Controls.Add(lblDashboardTitle)
        pnlDashboard.Controls.Add(lblWelcome)
        pnlDashboard.Controls.Add(lblStudentInfo)
        pnlDashboard.Controls.Add(pnlStats)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(0, 0)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Padding = New Padding(20)
        pnlDashboard.Size = New Size(973, 800)
        pnlDashboard.TabIndex = 0
        ' 
        ' lblDashboardTitle
        ' 
        lblDashboardTitle.AutoSize = True
        lblDashboardTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblDashboardTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblDashboardTitle.Location = New Point(20, 15)
        lblDashboardTitle.Name = "lblDashboardTitle"
        lblDashboardTitle.Size = New Size(282, 36)
        lblDashboardTitle.TabIndex = 0
        lblDashboardTitle.Text = "Student Dashboard"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Times New Roman", 16F)
        lblWelcome.Location = New Point(20, 70)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(170, 25)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome, Student"
        ' 
        ' lblStudentInfo
        ' 
        lblStudentInfo.AutoSize = True
        lblStudentInfo.Font = New Font("Times New Roman", 12F)
        lblStudentInfo.ForeColor = Color.DimGray
        lblStudentInfo.Location = New Point(20, 100)
        lblStudentInfo.Name = "lblStudentInfo"
        lblStudentInfo.Size = New Size(143, 19)
        lblStudentInfo.TabIndex = 2
        lblStudentInfo.Text = "Student Number: N/A"
        ' 
        ' pnlStats
        ' 
        pnlStats.Controls.Add(lblEnrolledCourses)
        pnlStats.Controls.Add(lblCurrentSemester)
        pnlStats.Controls.Add(lblYearLevel)
        pnlStats.Controls.Add(lblOverallGPA)
        pnlStats.Location = New Point(20, 140)
        pnlStats.Name = "pnlStats"
        pnlStats.Size = New Size(900, 150)
        pnlStats.TabIndex = 3
        ' 
        ' lblEnrolledCourses
        ' 
        lblEnrolledCourses.BackColor = SystemColors.MenuHighlight
        lblEnrolledCourses.Font = New Font("Times New Roman", 18F, FontStyle.Bold)
        lblEnrolledCourses.ForeColor = Color.White
        lblEnrolledCourses.Location = New Point(0, 10)
        lblEnrolledCourses.Name = "lblEnrolledCourses"
        lblEnrolledCourses.Size = New Size(210, 130)
        lblEnrolledCourses.TabIndex = 0
        lblEnrolledCourses.Text = "Enrolled Courses" + vbCrLf + "0"
        lblEnrolledCourses.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblCurrentSemester
        ' 
        lblCurrentSemester.BackColor = Color.RoyalBlue
        lblCurrentSemester.Font = New Font("Times New Roman", 18F, FontStyle.Bold)
        lblCurrentSemester.ForeColor = Color.White
        lblCurrentSemester.Location = New Point(234, 10)
        lblCurrentSemester.Name = "lblCurrentSemester"
        lblCurrentSemester.Size = New Size(210, 130)
        lblCurrentSemester.TabIndex = 1
        lblCurrentSemester.Text = "Current Semester" + vbCrLf + "N/A"
        lblCurrentSemester.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblYearLevel
        ' 
        lblYearLevel.BackColor = Color.MediumBlue
        lblYearLevel.Font = New Font("Times New Roman", 18F, FontStyle.Bold)
        lblYearLevel.ForeColor = Color.White
        lblYearLevel.Location = New Point(460, 10)
        lblYearLevel.Name = "lblYearLevel"
        lblYearLevel.Size = New Size(210, 130)
        lblYearLevel.TabIndex = 2
        lblYearLevel.Text = "Year Level" + vbCrLf + "N/A"
        lblYearLevel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblOverallGPA
        ' 
        lblOverallGPA.BackColor = Color.FromArgb(46, 204, 113)
        lblOverallGPA.Font = New Font("Times New Roman", 18F, FontStyle.Bold)
        lblOverallGPA.ForeColor = Color.White
        lblOverallGPA.Location = New Point(690, 10)
        lblOverallGPA.Name = "lblOverallGPA"
        lblOverallGPA.Size = New Size(210, 130)
        lblOverallGPA.TabIndex = 3
        lblOverallGPA.Text = "Overall GPA" + vbCrLf + "N/A"
        lblOverallGPA.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlMyEnrollments
        ' 
        pnlMyEnrollments.AutoScroll = True
        pnlMyEnrollments.BackColor = Color.White
        pnlMyEnrollments.Controls.Add(lblMyEnrollmentsTitle)
        pnlMyEnrollments.Controls.Add(dgvMyEnrollments)
        pnlMyEnrollments.Controls.Add(btnRefreshEnrollments)
        pnlMyEnrollments.Dock = DockStyle.Fill
        pnlMyEnrollments.Location = New Point(0, 0)
        pnlMyEnrollments.Name = "pnlMyEnrollments"
        pnlMyEnrollments.Padding = New Padding(20)
        pnlMyEnrollments.Size = New Size(973, 800)
        pnlMyEnrollments.TabIndex = 1
        pnlMyEnrollments.Visible = False
        ' 
        ' lblMyEnrollmentsTitle
        ' 
        lblMyEnrollmentsTitle.AutoSize = True
        lblMyEnrollmentsTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblMyEnrollmentsTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblMyEnrollmentsTitle.Location = New Point(20, 15)
        lblMyEnrollmentsTitle.Name = "lblMyEnrollmentsTitle"
        lblMyEnrollmentsTitle.Size = New Size(237, 36)
        lblMyEnrollmentsTitle.TabIndex = 0
        lblMyEnrollmentsTitle.Text = "My Enrollments"
        ' 
        ' dgvMyEnrollments
        ' 
        dgvMyEnrollments.AllowUserToAddRows = False
        dgvMyEnrollments.AllowUserToDeleteRows = False
        dgvMyEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMyEnrollments.BackgroundColor = SystemColors.Control
        dgvMyEnrollments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMyEnrollments.Location = New Point(20, 70)
        dgvMyEnrollments.Name = "dgvMyEnrollments"
        dgvMyEnrollments.ReadOnly = True
        dgvMyEnrollments.Size = New Size(920, 650)
        dgvMyEnrollments.TabIndex = 1
        ' 
        ' btnRefreshEnrollments
        ' 
        btnRefreshEnrollments.BackColor = Color.FromArgb(0, 122, 204)
        btnRefreshEnrollments.FlatStyle = FlatStyle.Flat
        btnRefreshEnrollments.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRefreshEnrollments.ForeColor = Color.White
        btnRefreshEnrollments.Location = New Point(740, 20)
        btnRefreshEnrollments.Name = "btnRefreshEnrollments"
        btnRefreshEnrollments.Size = New Size(200, 35)
        btnRefreshEnrollments.TabIndex = 2
        btnRefreshEnrollments.Text = "🔄 Refresh"
        btnRefreshEnrollments.UseVisualStyleBackColor = False
        ' 
        ' pnlViewGrades
        ' 
        pnlViewGrades.AutoScroll = True
        pnlViewGrades.BackColor = Color.White
        pnlViewGrades.Controls.Add(lblViewGradesTitle)
        pnlViewGrades.Controls.Add(lblSelectCourseGrade)
        pnlViewGrades.Controls.Add(cmbCourseForGrades)
        pnlViewGrades.Controls.Add(btnLoadGrades)
        pnlViewGrades.Controls.Add(dgvMyGrades)
        pnlViewGrades.Controls.Add(btnRefreshGrades)
        pnlViewGrades.Dock = DockStyle.Fill
        pnlViewGrades.Location = New Point(0, 0)
        pnlViewGrades.Name = "pnlViewGrades"
        pnlViewGrades.Padding = New Padding(20)
        pnlViewGrades.Size = New Size(973, 800)
        pnlViewGrades.TabIndex = 2
        pnlViewGrades.Visible = False
        ' 
        ' lblViewGradesTitle
        ' 
        lblViewGradesTitle.AutoSize = True
        lblViewGradesTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblViewGradesTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblViewGradesTitle.Location = New Point(20, 15)
        lblViewGradesTitle.Name = "lblViewGradesTitle"
        lblViewGradesTitle.Size = New Size(167, 36)
        lblViewGradesTitle.TabIndex = 0
        lblViewGradesTitle.Text = "My Grades"
        ' 
        ' lblSelectCourseGrade
        ' 
        lblSelectCourseGrade.AutoSize = True
        lblSelectCourseGrade.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblSelectCourseGrade.Location = New Point(20, 70)
        lblSelectCourseGrade.Name = "lblSelectCourseGrade"
        lblSelectCourseGrade.Size = New Size(107, 19)
        lblSelectCourseGrade.TabIndex = 1
        lblSelectCourseGrade.Text = "Select Course:"
        ' 
        ' cmbCourseForGrades
        ' 
        cmbCourseForGrades.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCourseForGrades.Font = New Font("Times New Roman", 12F)
        cmbCourseForGrades.FormattingEnabled = True
        cmbCourseForGrades.Location = New Point(20, 95)
        cmbCourseForGrades.Name = "cmbCourseForGrades"
        cmbCourseForGrades.Size = New Size(500, 27)
        cmbCourseForGrades.TabIndex = 2
        ' 
        ' btnLoadGrades
        ' 
        btnLoadGrades.BackColor = Color.FromArgb(0, 122, 204)
        btnLoadGrades.FlatStyle = FlatStyle.Flat
        btnLoadGrades.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnLoadGrades.ForeColor = Color.White
        btnLoadGrades.Location = New Point(540, 93)
        btnLoadGrades.Name = "btnLoadGrades"
        btnLoadGrades.Size = New Size(150, 30)
        btnLoadGrades.TabIndex = 3
        btnLoadGrades.Text = "Load Grades"
        btnLoadGrades.UseVisualStyleBackColor = False
        ' 
        ' dgvMyGrades
        ' 
        dgvMyGrades.AllowUserToAddRows = False
        dgvMyGrades.AllowUserToDeleteRows = False
        dgvMyGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMyGrades.BackgroundColor = SystemColors.Control
        dgvMyGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvMyGrades.Location = New Point(20, 140)
        dgvMyGrades.Name = "dgvMyGrades"
        dgvMyGrades.ReadOnly = True
        dgvMyGrades.Size = New Size(920, 580)
        dgvMyGrades.TabIndex = 4
        ' 
        ' btnRefreshGrades
        ' 
        btnRefreshGrades.BackColor = Color.FromArgb(46, 204, 113)
        btnRefreshGrades.FlatStyle = FlatStyle.Flat
        btnRefreshGrades.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRefreshGrades.ForeColor = Color.White
        btnRefreshGrades.Location = New Point(710, 93)
        btnRefreshGrades.Name = "btnRefreshGrades"
        btnRefreshGrades.Size = New Size(150, 30)
        btnRefreshGrades.TabIndex = 5
        btnRefreshGrades.Text = "🔄 Refresh"
        btnRefreshGrades.UseVisualStyleBackColor = False
        ' 
        ' pnlGradeSummary
        ' 
        pnlGradeSummary.AutoScroll = True
        pnlGradeSummary.BackColor = Color.White
        pnlGradeSummary.Controls.Add(lblGradeSummaryTitle)
        pnlGradeSummary.Controls.Add(lblFilterSemester)
        pnlGradeSummary.Controls.Add(cmbFilterSemester)
        pnlGradeSummary.Controls.Add(btnLoadGradeSummary)
        pnlGradeSummary.Controls.Add(btnRefreshGradeSummary)
        pnlGradeSummary.Controls.Add(dgvGradeSummary)
        pnlGradeSummary.Controls.Add(pnlCourseAverages)
        pnlGradeSummary.Dock = DockStyle.Fill
        pnlGradeSummary.Location = New Point(0, 0)
        pnlGradeSummary.Name = "pnlGradeSummary"
        pnlGradeSummary.Padding = New Padding(20)
        pnlGradeSummary.Size = New Size(973, 800)
        pnlGradeSummary.TabIndex = 3
        pnlGradeSummary.Visible = False
        ' 
        ' lblGradeSummaryTitle
        ' 
        lblGradeSummaryTitle.AutoSize = True
        lblGradeSummaryTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblGradeSummaryTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblGradeSummaryTitle.Location = New Point(20, 15)
        lblGradeSummaryTitle.Name = "lblGradeSummaryTitle"
        lblGradeSummaryTitle.Size = New Size(244, 36)
        lblGradeSummaryTitle.TabIndex = 0
        lblGradeSummaryTitle.Text = "Grade Summary"
        ' 
        ' lblFilterSemester
        ' 
        lblFilterSemester.AutoSize = True
        lblFilterSemester.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblFilterSemester.Location = New Point(20, 60)
        lblFilterSemester.Name = "lblFilterSemester"
        lblFilterSemester.Size = New Size(137, 19)
        lblFilterSemester.TabIndex = 1
        lblFilterSemester.Text = "Filter by Semester:"
        ' 
        ' cmbFilterSemester
        ' 
        cmbFilterSemester.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterSemester.Font = New Font("Times New Roman", 12F)
        cmbFilterSemester.FormattingEnabled = True
        cmbFilterSemester.Location = New Point(20, 85)
        cmbFilterSemester.Name = "cmbFilterSemester"
        cmbFilterSemester.Size = New Size(400, 27)
        cmbFilterSemester.TabIndex = 2
        ' 
        ' btnLoadGradeSummary
        ' 
        btnLoadGradeSummary.BackColor = Color.FromArgb(0, 122, 204)
        btnLoadGradeSummary.FlatStyle = FlatStyle.Flat
        btnLoadGradeSummary.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnLoadGradeSummary.ForeColor = Color.White
        btnLoadGradeSummary.Location = New Point(440, 83)
        btnLoadGradeSummary.Name = "btnLoadGradeSummary"
        btnLoadGradeSummary.Size = New Size(150, 30)
        btnLoadGradeSummary.TabIndex = 3
        btnLoadGradeSummary.Text = "Load Summary"
        btnLoadGradeSummary.UseVisualStyleBackColor = False
        ' 
        ' btnRefreshGradeSummary
        ' 
        btnRefreshGradeSummary.BackColor = Color.FromArgb(46, 204, 113)
        btnRefreshGradeSummary.FlatStyle = FlatStyle.Flat
        btnRefreshGradeSummary.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRefreshGradeSummary.ForeColor = Color.White
        btnRefreshGradeSummary.Location = New Point(610, 83)
        btnRefreshGradeSummary.Name = "btnRefreshGradeSummary"
        btnRefreshGradeSummary.Size = New Size(150, 30)
        btnRefreshGradeSummary.TabIndex = 4
        btnRefreshGradeSummary.Text = "🔄 Refresh"
        btnRefreshGradeSummary.UseVisualStyleBackColor = False
        ' 
        ' dgvGradeSummary
        ' 
        dgvGradeSummary.AllowUserToAddRows = False
        dgvGradeSummary.AllowUserToDeleteRows = False
        dgvGradeSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvGradeSummary.BackgroundColor = SystemColors.Control
        DataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = SystemColors.Control
        DataGridViewCellStyle9.Font = New Font("Times New Roman", 10F, FontStyle.Bold)
        DataGridViewCellStyle9.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = DataGridViewTriState.True
        dgvGradeSummary.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        dgvGradeSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = SystemColors.Window
        DataGridViewCellStyle10.Font = New Font("Times New Roman", 10F)
        DataGridViewCellStyle10.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = DataGridViewTriState.False
        dgvGradeSummary.DefaultCellStyle = DataGridViewCellStyle10
        dgvGradeSummary.Location = New Point(20, 125)
        dgvGradeSummary.Name = "dgvGradeSummary"
        dgvGradeSummary.ReadOnly = True
        dgvGradeSummary.Size = New Size(1520, 350)
        dgvGradeSummary.TabIndex = 5
        ' 
        ' pnlCourseAverages
        ' 
        pnlCourseAverages.BackColor = Color.FromArgb(245, 245, 245)
        pnlCourseAverages.Controls.Add(lblCourseAveragesTitle)
        pnlCourseAverages.Controls.Add(dgvCourseAverages)
        pnlCourseAverages.Controls.Add(lblOverallAverageDisplay)
        pnlCourseAverages.Location = New Point(20, 485)
        pnlCourseAverages.Name = "pnlCourseAverages"
        pnlCourseAverages.Size = New Size(1520, 280)
        pnlCourseAverages.TabIndex = 6
        ' 
        ' lblCourseAveragesTitle
        ' 
        lblCourseAveragesTitle.AutoSize = True
        lblCourseAveragesTitle.Font = New Font("Times New Roman", 16F, FontStyle.Bold)
        lblCourseAveragesTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblCourseAveragesTitle.Location = New Point(10, 10)
        lblCourseAveragesTitle.Name = "lblCourseAveragesTitle"
        lblCourseAveragesTitle.Size = New Size(265, 25)
        lblCourseAveragesTitle.TabIndex = 0
        lblCourseAveragesTitle.Text = "Course Averages Summary"
        ' 
        ' dgvCourseAverages
        ' 
        dgvCourseAverages.AllowUserToAddRows = False
        dgvCourseAverages.AllowUserToDeleteRows = False
        dgvCourseAverages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCourseAverages.BackgroundColor = SystemColors.Control
        DataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = SystemColors.Control
        DataGridViewCellStyle11.Font = New Font("Times New Roman", 10F, FontStyle.Bold)
        DataGridViewCellStyle11.ForeColor = SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = DataGridViewTriState.True
        dgvCourseAverages.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        dgvCourseAverages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = SystemColors.Window
        DataGridViewCellStyle12.Font = New Font("Times New Roman", 10F)
        DataGridViewCellStyle12.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle12.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = DataGridViewTriState.False
        dgvCourseAverages.DefaultCellStyle = DataGridViewCellStyle12
        dgvCourseAverages.Location = New Point(10, 45)
        dgvCourseAverages.Name = "dgvCourseAverages"
        dgvCourseAverages.ReadOnly = True
        dgvCourseAverages.Size = New Size(1220, 220)
        dgvCourseAverages.TabIndex = 1
        ' 
        ' lblOverallAverageDisplay
        ' 
        lblOverallAverageDisplay.BackColor = Color.FromArgb(0, 122, 204)
        lblOverallAverageDisplay.Font = New Font("Times New Roman", 16F, FontStyle.Bold)
        lblOverallAverageDisplay.ForeColor = Color.White
        lblOverallAverageDisplay.Location = New Point(1250, 45)
        lblOverallAverageDisplay.Name = "lblOverallAverageDisplay"
        lblOverallAverageDisplay.Size = New Size(250, 220)
        lblOverallAverageDisplay.TabIndex = 2
        lblOverallAverageDisplay.Text = "Overall Average" + vbCrLf + vbCrLf + "N/A" + vbCrLf + vbCrLf + "GPA: N/A"
        lblOverallAverageDisplay.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' StudentDashboard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "StudentDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Student Dashboard - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlDashboard.ResumeLayout(False)
        pnlDashboard.PerformLayout()
        pnlStats.ResumeLayout(False)
        pnlMyEnrollments.ResumeLayout(False)
        pnlMyEnrollments.PerformLayout()
        CType(dgvMyEnrollments, ComponentModel.ISupportInitialize).EndInit()
        pnlViewGrades.ResumeLayout(False)
        pnlViewGrades.PerformLayout()
        CType(dgvMyGrades, ComponentModel.ISupportInitialize).EndInit()
        pnlGradeSummary.ResumeLayout(False)
        pnlGradeSummary.PerformLayout()
        CType(dgvGradeSummary, ComponentModel.ISupportInitialize).EndInit()
        pnlCourseAverages.ResumeLayout(False)
        pnlCourseAverages.PerformLayout()
        CType(dgvCourseAverages, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblStudentTitle As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnMyEnrollments As Button
    Friend WithEvents btnViewGrades As Button
    Friend WithEvents btnGradeSummary As Button
    Friend WithEvents btnLogout As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Dashboard Panel
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents lblDashboardTitle As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblStudentInfo As Label
    Friend WithEvents pnlStats As Panel
    Friend WithEvents lblEnrolledCourses As Label
    Friend WithEvents lblCurrentSemester As Label
    Friend WithEvents lblYearLevel As Label
    Friend WithEvents lblOverallGPA As Label

    ' My Enrollments Panel
    Friend WithEvents pnlMyEnrollments As Panel
    Friend WithEvents lblMyEnrollmentsTitle As Label
    Friend WithEvents dgvMyEnrollments As DataGridView
    Friend WithEvents btnRefreshEnrollments As Button

    ' View Grades Panel
    Friend WithEvents pnlViewGrades As Panel
    Friend WithEvents lblViewGradesTitle As Label
    Friend WithEvents lblSelectCourseGrade As Label
    Friend WithEvents cmbCourseForGrades As ComboBox
    Friend WithEvents btnLoadGrades As Button
    Friend WithEvents dgvMyGrades As DataGridView
    Friend WithEvents btnRefreshGrades As Button

    ' Grade Summary Panel
    Friend WithEvents pnlGradeSummary As Panel
    Friend WithEvents lblGradeSummaryTitle As Label
    Friend WithEvents lblFilterSemester As Label
    Friend WithEvents cmbFilterSemester As ComboBox
    Friend WithEvents btnLoadGradeSummary As Button
    Friend WithEvents btnRefreshGradeSummary As Button
    Friend WithEvents dgvGradeSummary As DataGridView
    Friend WithEvents pnlCourseAverages As Panel
    Friend WithEvents lblCourseAveragesTitle As Label
    Friend WithEvents dgvCourseAverages As DataGridView
    Friend WithEvents lblOverallAverageDisplay As Label
End Class
