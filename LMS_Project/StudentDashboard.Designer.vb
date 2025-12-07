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
        pnlSidebar = New Panel()
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
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlStats.SuspendLayout()
        pnlMyEnrollments.SuspendLayout()
        CType(dgvMyEnrollments, ComponentModel.ISupportInitialize).BeginInit()
        pnlViewGrades.SuspendLayout()
        CType(dgvMyGrades, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
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
        ' btnViewGrades
        ' 
        btnViewGrades.BackColor = SystemColors.MenuHighlight
        btnViewGrades.Dock = DockStyle.Top
        btnViewGrades.FlatAppearance.BorderSize = 0
        btnViewGrades.FlatStyle = FlatStyle.Flat
        btnViewGrades.Font = New Font("Times New Roman", 12.0F)
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
        btnMyEnrollments.Font = New Font("Times New Roman", 12.0F)
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
        btnDashboard.Font = New Font("Times New Roman", 12.0F)
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
        lblStudentTitle.Font = New Font("Times New Roman", 14.0F, FontStyle.Bold)
        lblStudentTitle.ForeColor = Color.White
        lblStudentTitle.Location = New Point(0, 0)
        lblStudentTitle.Name = "lblStudentTitle"
        lblStudentTitle.Size = New Size(227, 80)
        lblStudentTitle.TabIndex = 0
        lblStudentTitle.Text = "MGOD LMS" & vbCrLf & "Student Portal"
        lblStudentTitle.TextAlign = ContentAlignment.MiddleCenter
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
        btnLogout.Size = New Size(227, 50)
        btnLogout.TabIndex = 4
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
        lblDashboardTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblDashboardTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblDashboardTitle.Location = New Point(20, 15)
        lblDashboardTitle.Name = "lblDashboardTitle"
        lblDashboardTitle.Size = New Size(283, 36)
        lblDashboardTitle.TabIndex = 0
        lblDashboardTitle.Text = "Student Dashboard"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Times New Roman", 16.0F)
        lblWelcome.Location = New Point(20, 70)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(159, 25)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome, Student"
        ' 
        ' lblStudentInfo
        ' 
        lblStudentInfo.AutoSize = True
        lblStudentInfo.Font = New Font("Times New Roman", 12.0F)
        lblStudentInfo.ForeColor = Color.DimGray
        lblStudentInfo.Location = New Point(20, 100)
        lblStudentInfo.Name = "lblStudentInfo"
        lblStudentInfo.Size = New Size(155, 19)
        lblStudentInfo.TabIndex = 2
        lblStudentInfo.Text = "Student Number: N/A"
        ' 
        ' pnlStats
        ' 
        pnlStats.Controls.Add(lblEnrolledCourses)
        pnlStats.Controls.Add(lblCurrentSemester)
        pnlStats.Controls.Add(lblYearLevel)
        pnlStats.Location = New Point(20, 140)
        pnlStats.Name = "pnlStats"
        pnlStats.Size = New Size(900, 150)
        pnlStats.TabIndex = 3
        ' 
        ' lblEnrolledCourses
        ' 
        lblEnrolledCourses.BackColor = SystemColors.MenuHighlight
        lblEnrolledCourses.Font = New Font("Times New Roman", 18.0F, FontStyle.Bold)
        lblEnrolledCourses.ForeColor = Color.White
        lblEnrolledCourses.Location = New Point(3, 10)
        lblEnrolledCourses.Name = "lblEnrolledCourses"
        lblEnrolledCourses.Size = New Size(280, 130)
        lblEnrolledCourses.TabIndex = 0
        lblEnrolledCourses.Text = "Enrolled Courses" & vbCrLf & "0"
        lblEnrolledCourses.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblCurrentSemester
        ' 
        lblCurrentSemester.BackColor = Color.RoyalBlue
        lblCurrentSemester.Font = New Font("Times New Roman", 18.0F, FontStyle.Bold)
        lblCurrentSemester.ForeColor = Color.White
        lblCurrentSemester.Location = New Point(300, 10)
        lblCurrentSemester.Name = "lblCurrentSemester"
        lblCurrentSemester.Size = New Size(280, 130)
        lblCurrentSemester.TabIndex = 1
        lblCurrentSemester.Text = "Current Semester" & vbCrLf & "N/A"
        lblCurrentSemester.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblYearLevel
        ' 
        lblYearLevel.BackColor = Color.MediumBlue
        lblYearLevel.Font = New Font("Times New Roman", 18.0F, FontStyle.Bold)
        lblYearLevel.ForeColor = Color.White
        lblYearLevel.Location = New Point(598, 10)
        lblYearLevel.Name = "lblYearLevel"
        lblYearLevel.Size = New Size(280, 130)
        lblYearLevel.TabIndex = 2
        lblYearLevel.Text = "Year Level" & vbCrLf & "N/A"
        lblYearLevel.TextAlign = ContentAlignment.MiddleCenter
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
        lblMyEnrollmentsTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblMyEnrollmentsTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblMyEnrollmentsTitle.Location = New Point(20, 15)
        lblMyEnrollmentsTitle.Name = "lblMyEnrollmentsTitle"
        lblMyEnrollmentsTitle.Size = New Size(241, 36)
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
        btnRefreshEnrollments.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
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
        lblViewGradesTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblViewGradesTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblViewGradesTitle.Location = New Point(20, 15)
        lblViewGradesTitle.Name = "lblViewGradesTitle"
        lblViewGradesTitle.Size = New Size(196, 36)
        lblViewGradesTitle.TabIndex = 0
        lblViewGradesTitle.Text = "My Grades"
        ' 
        ' lblSelectCourseGrade
        ' 
        lblSelectCourseGrade.AutoSize = True
        lblSelectCourseGrade.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblSelectCourseGrade.Location = New Point(20, 70)
        lblSelectCourseGrade.Name = "lblSelectCourseGrade"
        lblSelectCourseGrade.Size = New Size(103, 19)
        lblSelectCourseGrade.TabIndex = 1
        lblSelectCourseGrade.Text = "Select Course:"
        ' 
        ' cmbCourseForGrades
        ' 
        cmbCourseForGrades.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCourseForGrades.Font = New Font("Times New Roman", 12.0F)
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
        btnLoadGrades.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
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
        btnRefreshGrades.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnRefreshGrades.ForeColor = Color.White
        btnRefreshGrades.Location = New Point(710, 93)
        btnRefreshGrades.Name = "btnRefreshGrades"
        btnRefreshGrades.Size = New Size(150, 30)
        btnRefreshGrades.TabIndex = 5
        btnRefreshGrades.Text = "🔄 Refresh"
        btnRefreshGrades.UseVisualStyleBackColor = False
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
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblStudentTitle As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnMyEnrollments As Button
    Friend WithEvents btnViewGrades As Button
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
End Class
