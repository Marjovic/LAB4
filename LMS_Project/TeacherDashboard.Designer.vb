<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TeacherDashboard
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
        btnCalculateGrade = New Button()
        btnEnrollmentManagement = New Button()
        btnDashboard = New Button()
        lblTeacherTitle = New Label()
        btnLogout = New Button()
        pnlMainContent = New Panel()
        pnlDashboard = New Panel()
        lblDashboardTitle = New Label()
        lblWelcome = New Label()
        pnlStats = New Panel()
        lblTotalCourses = New Label()
        lblTotalStudents = New Label()
        lblActiveSemesters = New Label()
        grpCourseOverview = New GroupBox()
        dgvCourseOverview = New DataGridView()
        grpAlerts = New GroupBox()
        lblAlerts = New Label()
        pnlCalculateGrade = New Panel()
        lblCalculateGradeTitle = New Label()
        lblSelectCourse = New Label()
        cmbCourseOffering = New ComboBox()
        lblSelectGradingPeriod = New Label()
        cmbGradingPeriod = New ComboBox()
        lblSelectAssignmentType = New Label()
        cmbAssignmentType = New ComboBox()
        btnLoadStudents = New Button()
        grpStudentGrades = New GroupBox()
        dgvStudentGrades = New DataGridView()
        lblStudentSearch = New Label()
        txtStudentSearch = New TextBox()
        lblSelectStudent = New Label()
        cmbSelectStudent = New ComboBox()
        lblGradeValue = New Label()
        txtGradeValue = New TextBox()
        lblRemarks = New Label()
        txtRemarks = New TextBox()
        btnSaveGrade = New Button()
        btnRefreshGrades = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlStats.SuspendLayout()
        grpCourseOverview.SuspendLayout()
        CType(dgvCourseOverview, ComponentModel.ISupportInitialize).BeginInit()
        grpAlerts.SuspendLayout()
        pnlCalculateGrade.SuspendLayout()
        grpStudentGrades.SuspendLayout()
        CType(dgvStudentGrades, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCalculateGrade)
        pnlSidebar.Controls.Add(btnEnrollmentManagement)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Controls.Add(lblTeacherTitle)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(200, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCalculateGrade
        ' 
        btnCalculateGrade.BackColor = SystemColors.MenuHighlight
        btnCalculateGrade.Dock = DockStyle.Top
        btnCalculateGrade.FlatAppearance.BorderSize = 0
        btnCalculateGrade.FlatStyle = FlatStyle.Flat
        btnCalculateGrade.Font = New Font("Times New Roman", 12.0F)
        btnCalculateGrade.ForeColor = Color.White
        btnCalculateGrade.Location = New Point(0, 178)
        btnCalculateGrade.Name = "btnCalculateGrade"
        btnCalculateGrade.Padding = New Padding(10, 0, 0, 0)
        btnCalculateGrade.Size = New Size(200, 50)
        btnCalculateGrade.TabIndex = 3
        btnCalculateGrade.Text = "📊 Calculate Grade"
        btnCalculateGrade.TextAlign = ContentAlignment.MiddleLeft
        btnCalculateGrade.UseVisualStyleBackColor = False
        ' 
        ' btnEnrollmentManagement
        ' 
        btnEnrollmentManagement.BackColor = SystemColors.MenuHighlight
        btnEnrollmentManagement.Dock = DockStyle.Top
        btnEnrollmentManagement.FlatAppearance.BorderSize = 0
        btnEnrollmentManagement.FlatStyle = FlatStyle.Flat
        btnEnrollmentManagement.Font = New Font("Times New Roman", 12.0F)
        btnEnrollmentManagement.ForeColor = Color.White
        btnEnrollmentManagement.Location = New Point(0, 128)
        btnEnrollmentManagement.Name = "btnEnrollmentManagement"
        btnEnrollmentManagement.Padding = New Padding(10, 0, 0, 0)
        btnEnrollmentManagement.Size = New Size(200, 50)
        btnEnrollmentManagement.TabIndex = 2
        btnEnrollmentManagement.Text = "📝 Enroll Student"
        btnEnrollmentManagement.TextAlign = ContentAlignment.MiddleLeft
        btnEnrollmentManagement.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = SystemColors.MenuHighlight
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Times New Roman", 12.0F)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(0, 80)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(10, 0, 0, 0)
        btnDashboard.Size = New Size(200, 48)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "📋 Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' lblTeacherTitle
        ' 
        lblTeacherTitle.BackColor = Color.Navy
        lblTeacherTitle.Dock = DockStyle.Top
        lblTeacherTitle.Font = New Font("Times New Roman", 14.0F, FontStyle.Bold)
        lblTeacherTitle.ForeColor = Color.White
        lblTeacherTitle.Location = New Point(0, 0)
        lblTeacherTitle.Name = "lblTeacherTitle"
        lblTeacherTitle.Size = New Size(200, 80)
        lblTeacherTitle.TabIndex = 0
        lblTeacherTitle.Text = "MGOD LMS" + vbCrLf + "Teacher Portal"
        lblTeacherTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(192, 0, 0)
        btnLogout.Dock = DockStyle.Bottom
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(0, 750)
        btnLogout.Name = "btnLogout"
        btnLogout.Padding = New Padding(10, 0, 0, 0)
        btnLogout.Size = New Size(200, 50)
        btnLogout.TabIndex = 4
        btnLogout.Text = "🚪 Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(240, 240, 240)
        pnlMainContent.Controls.Add(pnlDashboard)
        pnlMainContent.Controls.Add(pnlCalculateGrade)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(200, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(1000, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.AutoScroll = True
        pnlDashboard.BackColor = Color.White
        pnlDashboard.Controls.Add(lblDashboardTitle)
        pnlDashboard.Controls.Add(lblWelcome)
        pnlDashboard.Controls.Add(pnlStats)
        pnlDashboard.Controls.Add(grpCourseOverview)
        pnlDashboard.Controls.Add(grpAlerts)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(0, 0)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Padding = New Padding(20)
        pnlDashboard.Size = New Size(1000, 800)
        pnlDashboard.TabIndex = 0
        ' 
        ' lblDashboardTitle
        ' 
        lblDashboardTitle.AutoSize = True
        lblDashboardTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblDashboardTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblDashboardTitle.Location = New Point(20, 15)
        lblDashboardTitle.Name = "lblDashboardTitle"
        lblDashboardTitle.Size = New Size(291, 36)
        lblDashboardTitle.TabIndex = 0
        lblDashboardTitle.Text = "Teacher Dashboard"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Times New Roman", 14.0F)
        lblWelcome.Location = New Point(20, 55)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(150, 21)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome, Instructor"
        ' 
        ' pnlStats
        ' 
        pnlStats.Controls.Add(lblTotalCourses)
        pnlStats.Controls.Add(lblTotalStudents)
        pnlStats.Controls.Add(lblActiveSemesters)
        pnlStats.Location = New Point(20, 85)
        pnlStats.Name = "pnlStats"
        pnlStats.Size = New Size(1150, 100)
        pnlStats.TabIndex = 2
        ' 
        ' lblTotalCourses
        ' 
        lblTotalCourses.BackColor = Color.FromArgb(0, 122, 204)
        lblTotalCourses.Font = New Font("Times New Roman", 16.0F, FontStyle.Bold)
        lblTotalCourses.ForeColor = Color.White
        lblTotalCourses.Location = New Point(3, 5)
        lblTotalCourses.Name = "lblTotalCourses"
        lblTotalCourses.Size = New Size(300, 90)
        lblTotalCourses.TabIndex = 0
        lblTotalCourses.Text = "My Courses" + vbCrLf + "0"
        lblTotalCourses.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotalStudents
        ' 
        lblTotalStudents.BackColor = Color.FromArgb(46, 204, 113)
        lblTotalStudents.Font = New Font("Times New Roman", 16.0F, FontStyle.Bold)
        lblTotalStudents.ForeColor = Color.White
        lblTotalStudents.Location = New Point(320, 5)
        lblTotalStudents.Name = "lblTotalStudents"
        lblTotalStudents.Size = New Size(300, 90)
        lblTotalStudents.TabIndex = 1
        lblTotalStudents.Text = "Total Students" + vbCrLf + "0"
        lblTotalStudents.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblActiveSemesters
        ' 
        lblActiveSemesters.BackColor = Color.FromArgb(155, 89, 182)
        lblActiveSemesters.Font = New Font("Times New Roman", 16.0F, FontStyle.Bold)
        lblActiveSemesters.ForeColor = Color.White
        lblActiveSemesters.Location = New Point(637, 5)
        lblActiveSemesters.Name = "lblActiveSemesters"
        lblActiveSemesters.Size = New Size(300, 90)
        lblActiveSemesters.TabIndex = 2
        lblActiveSemesters.Text = "Class Average" + vbCrLf + "0%"
        lblActiveSemesters.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' grpCourseOverview
        ' 
        grpCourseOverview.Controls.Add(dgvCourseOverview)
        grpCourseOverview.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        grpCourseOverview.ForeColor = Color.FromArgb(0, 122, 204)
        grpCourseOverview.Location = New Point(20, 195)
        grpCourseOverview.Name = "grpCourseOverview"
        grpCourseOverview.Size = New Size(1150, 550)
        grpCourseOverview.TabIndex = 3
        grpCourseOverview.TabStop = False
        grpCourseOverview.Text = "📚 My Courses Overview (Current Semester)"
        ' 
        ' dgvCourseOverview
        ' 
        dgvCourseOverview.AllowUserToAddRows = False
        dgvCourseOverview.AllowUserToDeleteRows = False
        dgvCourseOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCourseOverview.BackgroundColor = SystemColors.Control
        dgvCourseOverview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCourseOverview.DefaultCellStyle.Font = New Font("Times New Roman", 8.0F)
        dgvCourseOverview.ColumnHeadersDefaultCellStyle.Font = New Font("Times New Roman", 8.0F, FontStyle.Bold)
        dgvCourseOverview.Location = New Point(15, 28)
        dgvCourseOverview.Name = "dgvCourseOverview"
        dgvCourseOverview.ReadOnly = True
        dgvCourseOverview.RowTemplate.Height = 28
        dgvCourseOverview.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvCourseOverview.Size = New Size(1120, 505)
        dgvCourseOverview.TabIndex = 0
        ' 
        ' grpAlerts
        ' 
        grpAlerts.Controls.Add(lblAlerts)
        grpAlerts.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        grpAlerts.ForeColor = Color.FromArgb(231, 76, 60)
        grpAlerts.Location = New Point(20, 760)
        grpAlerts.Name = "grpAlerts"
        grpAlerts.Size = New Size(1150, 120)
        grpAlerts.TabIndex = 4
        grpAlerts.TabStop = False
        grpAlerts.Text = "⚠️ Alerts & Notifications"
        ' 
        ' lblAlerts
        ' 
        lblAlerts.Font = New Font("Times New Roman", 11.0F)
        lblAlerts.ForeColor = Color.DarkOrange
        lblAlerts.Location = New Point(15, 28)
        lblAlerts.Name = "lblAlerts"
        lblAlerts.Size = New Size(1120, 80)
        lblAlerts.TabIndex = 0
        lblAlerts.Text = "Loading alerts..."
        ' 
        ' pnlCalculateGrade
        ' 
        pnlCalculateGrade.AutoScroll = True
        pnlCalculateGrade.BackColor = Color.White
        pnlCalculateGrade.Controls.Add(lblCalculateGradeTitle)
        pnlCalculateGrade.Controls.Add(lblSelectCourse)
        pnlCalculateGrade.Controls.Add(cmbCourseOffering)
        pnlCalculateGrade.Controls.Add(lblSelectGradingPeriod)
        pnlCalculateGrade.Controls.Add(cmbGradingPeriod)
        pnlCalculateGrade.Controls.Add(lblSelectAssignmentType)
        pnlCalculateGrade.Controls.Add(cmbAssignmentType)
        pnlCalculateGrade.Controls.Add(btnLoadStudents)
        pnlCalculateGrade.Controls.Add(grpStudentGrades)
        pnlCalculateGrade.Dock = DockStyle.Fill
        pnlCalculateGrade.Location = New Point(0, 0)
        pnlCalculateGrade.Name = "pnlCalculateGrade"
        pnlCalculateGrade.Padding = New Padding(20)
        pnlCalculateGrade.Size = New Size(1000, 800)
        pnlCalculateGrade.TabIndex = 1
        pnlCalculateGrade.Visible = False
        ' 
        ' lblCalculateGradeTitle
        ' 
        lblCalculateGradeTitle.AutoSize = True
        lblCalculateGradeTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblCalculateGradeTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblCalculateGradeTitle.Location = New Point(20, 15)
        lblCalculateGradeTitle.Name = "lblCalculateGradeTitle"
        lblCalculateGradeTitle.Size = New Size(396, 36)
        lblCalculateGradeTitle.TabIndex = 0
        lblCalculateGradeTitle.Text = "Calculate / Enter Grades"
        ' 
        ' lblSelectCourse
        ' 
        lblSelectCourse.AutoSize = True
        lblSelectCourse.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        lblSelectCourse.Location = New Point(30, 60)
        lblSelectCourse.Name = "lblSelectCourse"
        lblSelectCourse.Size = New Size(142, 17)
        lblSelectCourse.TabIndex = 1
        lblSelectCourse.Text = "Select Course Offering:"
        ' 
        ' cmbCourseOffering
        ' 
        cmbCourseOffering.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCourseOffering.Font = New Font("Times New Roman", 11.0F)
        cmbCourseOffering.FormattingEnabled = True
        cmbCourseOffering.Location = New Point(30, 80)
        cmbCourseOffering.Name = "cmbCourseOffering"
        cmbCourseOffering.Size = New Size(550, 25)
        cmbCourseOffering.TabIndex = 2
        ' 
        ' lblSelectGradingPeriod
        ' 
        lblSelectGradingPeriod.AutoSize = True
        lblSelectGradingPeriod.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        lblSelectGradingPeriod.Location = New Point(600, 60)
        lblSelectGradingPeriod.Name = "lblSelectGradingPeriod"
        lblSelectGradingPeriod.Size = New Size(149, 17)
        lblSelectGradingPeriod.TabIndex = 3
        lblSelectGradingPeriod.Text = "Select Grading Period:"
        ' 
        ' cmbGradingPeriod
        ' 
        cmbGradingPeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cmbGradingPeriod.Font = New Font("Times New Roman", 11.0F)
        cmbGradingPeriod.FormattingEnabled = True
        cmbGradingPeriod.Location = New Point(600, 80)
        cmbGradingPeriod.Name = "cmbGradingPeriod"
        cmbGradingPeriod.Size = New Size(320, 25)
        cmbGradingPeriod.TabIndex = 4
        ' 
        ' lblSelectAssignmentType
        ' 
        lblSelectAssignmentType.AutoSize = True
        lblSelectAssignmentType.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        lblSelectAssignmentType.Location = New Point(30, 115)
        lblSelectAssignmentType.Name = "lblSelectAssignmentType"
        lblSelectAssignmentType.Size = New Size(150, 17)
        lblSelectAssignmentType.TabIndex = 5
        lblSelectAssignmentType.Text = "Select Assignment Type:"
        ' 
        ' cmbAssignmentType
        ' 
        cmbAssignmentType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAssignmentType.Font = New Font("Times New Roman", 11.0F)
        cmbAssignmentType.FormattingEnabled = True
        cmbAssignmentType.Location = New Point(30, 135)
        cmbAssignmentType.Name = "cmbAssignmentType"
        cmbAssignmentType.Size = New Size(550, 25)
        cmbAssignmentType.TabIndex = 6
        ' 
        ' btnLoadStudents
        ' 
        btnLoadStudents.BackColor = Color.FromArgb(0, 122, 204)
        btnLoadStudents.FlatStyle = FlatStyle.Flat
        btnLoadStudents.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        btnLoadStudents.ForeColor = Color.White
        btnLoadStudents.Location = New Point(600, 125)
        btnLoadStudents.Name = "btnLoadStudents"
        btnLoadStudents.Size = New Size(200, 35)
        btnLoadStudents.TabIndex = 7
        btnLoadStudents.Text = "Load Students"
        btnLoadStudents.UseVisualStyleBackColor = False
        ' 
        ' grpStudentGrades
        ' 
        grpStudentGrades.Controls.Add(dgvStudentGrades)
        grpStudentGrades.Controls.Add(lblStudentSearch)
        grpStudentGrades.Controls.Add(txtStudentSearch)
        grpStudentGrades.Controls.Add(lblSelectStudent)
        grpStudentGrades.Controls.Add(cmbSelectStudent)
        grpStudentGrades.Controls.Add(lblGradeValue)
        grpStudentGrades.Controls.Add(txtGradeValue)
        grpStudentGrades.Controls.Add(lblRemarks)
        grpStudentGrades.Controls.Add(txtRemarks)
        grpStudentGrades.Controls.Add(btnSaveGrade)
        grpStudentGrades.Controls.Add(btnRefreshGrades)
        grpStudentGrades.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        grpStudentGrades.Location = New Point(30, 175)
        grpStudentGrades.Name = "grpStudentGrades"
        grpStudentGrades.Size = New Size(930, 600)
        grpStudentGrades.TabIndex = 8
        grpStudentGrades.TabStop = False
        grpStudentGrades.Text = "Student Grades"
        grpStudentGrades.Visible = False
        ' 
        ' dgvStudentGrades
        ' 
        dgvStudentGrades.AllowUserToAddRows = False
        dgvStudentGrades.AllowUserToDeleteRows = False
        dgvStudentGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvStudentGrades.BackgroundColor = SystemColors.Control
        dgvStudentGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStudentGrades.Location = New Point(15, 30)
        dgvStudentGrades.Name = "dgvStudentGrades"
        dgvStudentGrades.ReadOnly = True
        dgvStudentGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvStudentGrades.Size = New Size(900, 350)
        dgvStudentGrades.TabIndex = 0
        ' 
        ' lblStudentSearch
        ' 
        lblStudentSearch.AutoSize = True
        lblStudentSearch.Font = New Font("Times New Roman", 11.0F)
        lblStudentSearch.Location = New Point(15, 395)
        lblStudentSearch.Name = "lblStudentSearch"
        lblStudentSearch.Size = New Size(103, 17)
        lblStudentSearch.TabIndex = 1
        lblStudentSearch.Text = "Search Student:"
        ' 
        ' txtStudentSearch
        ' 
        txtStudentSearch.Font = New Font("Times New Roman", 11.0F)
        txtStudentSearch.Location = New Point(125, 392)
        txtStudentSearch.Name = "txtStudentSearch"
        txtStudentSearch.Size = New Size(350, 24)
        txtStudentSearch.TabIndex = 2
        ' 
        ' lblSelectStudent
        ' 
        lblSelectStudent.AutoSize = True
        lblSelectStudent.Font = New Font("Times New Roman", 11.0F)
        lblSelectStudent.Location = New Point(15, 435)
        lblSelectStudent.Name = "lblSelectStudent"
        lblSelectStudent.Size = New Size(96, 17)
        lblSelectStudent.TabIndex = 3
        lblSelectStudent.Text = "Select Student:"
        ' 
        ' cmbSelectStudent
        ' 
        cmbSelectStudent.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectStudent.Font = New Font("Times New Roman", 11.0F)
        cmbSelectStudent.FormattingEnabled = True
        cmbSelectStudent.Location = New Point(125, 432)
        cmbSelectStudent.Name = "cmbSelectStudent"
        cmbSelectStudent.Size = New Size(450, 25)
        cmbSelectStudent.TabIndex = 4
        ' 
        ' lblGradeValue
        ' 
        lblGradeValue.AutoSize = True
        lblGradeValue.Font = New Font("Times New Roman", 11.0F)
        lblGradeValue.Location = New Point(15, 475)
        lblGradeValue.Name = "lblGradeValue"
        lblGradeValue.Size = New Size(44, 17)
        lblGradeValue.TabIndex = 5
        lblGradeValue.Text = "Score:"
        ' 
        ' txtGradeValue
        ' 
        txtGradeValue.Font = New Font("Times New Roman", 11.0F)
        txtGradeValue.Location = New Point(125, 472)
        txtGradeValue.Name = "txtGradeValue"
        txtGradeValue.Size = New Size(120, 24)
        txtGradeValue.TabIndex = 6
        ' 
        ' lblRemarks
        ' 
        lblRemarks.AutoSize = True
        lblRemarks.Font = New Font("Times New Roman", 11.0F)
        lblRemarks.Location = New Point(260, 475)
        lblRemarks.Name = "lblRemarks"
        lblRemarks.Size = New Size(123, 17)
        lblRemarks.TabIndex = 7
        lblRemarks.Text = "Notes (Optional):"
        ' 
        ' txtRemarks
        ' 
        txtRemarks.Font = New Font("Times New Roman", 11.0F)
        txtRemarks.Location = New Point(390, 472)
        txtRemarks.Name = "txtRemarks"
        txtRemarks.Size = New Size(420, 24)
        txtRemarks.TabIndex = 8
        ' 
        ' btnSaveGrade
        ' 
        btnSaveGrade.BackColor = Color.FromArgb(0, 122, 204)
        btnSaveGrade.FlatStyle = FlatStyle.Flat
        btnSaveGrade.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnSaveGrade.ForeColor = Color.White
        btnSaveGrade.Location = New Point(125, 515)
        btnSaveGrade.Name = "btnSaveGrade"
        btnSaveGrade.Size = New Size(200, 40)
        btnSaveGrade.TabIndex = 9
        btnSaveGrade.Text = "💾 Save Grade"
        btnSaveGrade.UseVisualStyleBackColor = False
        ' 
        ' btnRefreshGrades
        ' 
        btnRefreshGrades.BackColor = Color.FromArgb(46, 204, 113)
        btnRefreshGrades.FlatStyle = FlatStyle.Flat
        btnRefreshGrades.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnRefreshGrades.ForeColor = Color.White
        btnRefreshGrades.Location = New Point(345, 515)
        btnRefreshGrades.Name = "btnRefreshGrades"
        btnRefreshGrades.Size = New Size(200, 40)
        btnRefreshGrades.TabIndex = 10
        btnRefreshGrades.Text = "🔄 Refresh Grades"
        btnRefreshGrades.UseVisualStyleBackColor = False
        ' 
        ' TeacherDashboard
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "TeacherDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Teacher Dashboard - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlDashboard.ResumeLayout(False)
        pnlDashboard.PerformLayout()
        pnlStats.ResumeLayout(False)
        grpCourseOverview.ResumeLayout(False)
        CType(dgvCourseOverview, ComponentModel.ISupportInitialize).EndInit()
        grpAlerts.ResumeLayout(False)
        pnlCalculateGrade.ResumeLayout(False)
        pnlCalculateGrade.PerformLayout()
        grpStudentGrades.ResumeLayout(False)
        grpStudentGrades.PerformLayout()
        CType(dgvStudentGrades, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblTeacherTitle As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnEnrollmentManagement As Button
    Friend WithEvents btnCalculateGrade As Button
    Friend WithEvents btnLogout As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Dashboard Panel
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents lblDashboardTitle As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents pnlStats As Panel
    Friend WithEvents lblTotalCourses As Label
    Friend WithEvents lblTotalStudents As Label
    Friend WithEvents lblActiveSemesters As Label
    Friend WithEvents grpCourseOverview As GroupBox
    Friend WithEvents dgvCourseOverview As DataGridView
    Friend WithEvents grpAlerts As GroupBox
    Friend WithEvents lblAlerts As Label

    ' Calculate Grade Panel
    Friend WithEvents pnlCalculateGrade As Panel
    Friend WithEvents lblCalculateGradeTitle As Label
    Friend WithEvents lblSelectCourse As Label
    Friend WithEvents cmbCourseOffering As ComboBox
    Friend WithEvents lblSelectGradingPeriod As Label
    Friend WithEvents cmbGradingPeriod As ComboBox
    Friend WithEvents lblSelectAssignmentType As Label
    Friend WithEvents cmbAssignmentType As ComboBox
    Friend WithEvents btnLoadStudents As Button
    Friend WithEvents grpStudentGrades As GroupBox
    Friend WithEvents dgvStudentGrades As DataGridView
    Friend WithEvents lblStudentSearch As Label
    Friend WithEvents txtStudentSearch As TextBox
    Friend WithEvents lblSelectStudent As Label
    Friend WithEvents cmbSelectStudent As ComboBox
    Friend WithEvents lblGradeValue As Label
    Friend WithEvents txtGradeValue As TextBox
    Friend WithEvents lblRemarks As Label
    Friend WithEvents txtRemarks As TextBox
    Friend WithEvents btnSaveGrade As Button
    Friend WithEvents btnRefreshGrades As Button
End Class
