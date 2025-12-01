<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Course
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
        btnCourseOffer = New Button()
        btnManagePrerequisites = New Button()
        btnUpdateDeleteCourse = New Button()
        btnViewCourses = New Button()
        btnAddCourse = New Button()
        lblCourseTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlAddCourse = New Panel()
        lblAddCourseTitle = New Label()
        lblCourseCode = New Label()
        txtCourseCode = New TextBox()
        lblCourseName = New Label()
        txtCourseName = New TextBox()
        lblCourseDescription = New Label()
        txtCourseDescription = New TextBox()
        lblLabUnits = New Label()
        txtLabUnits = New TextBox()
        lblLectureUnits = New Label()
        txtLectureUnits = New TextBox()
        lblDepartment = New Label()
        cmbDepartment = New ComboBox()
        lblYearLevel = New Label()
        cmbYearLevel = New ComboBox()
        btnSubmitCourse = New Button()
        pnlViewCourses = New Panel()
        dgvCourses = New DataGridView()
        lblViewCoursesTitle = New Label()
        btnRefreshCourses = New Button()
        pnlUpdateDeleteCourse = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectCourseUpdate = New Label()
        cmbSelectCourseUpdate = New ComboBox()
        btnLoadCourseData = New Button()
        grpCourseInfo = New GroupBox()
        lblUpdateCourseCode = New Label()
        txtUpdateCourseCode = New TextBox()
        lblUpdateCourseName = New Label()
        txtUpdateCourseName = New TextBox()
        lblUpdateCourseDescription = New Label()
        txtUpdateCourseDescription = New TextBox()
        lblUpdateLabUnits = New Label()
        txtUpdateLabUnits = New TextBox()
        lblUpdateLectureUnits = New Label()
        txtUpdateLectureUnits = New TextBox()
        lblUpdateDepartment = New Label()
        cmbUpdateDepartment = New ComboBox()
        lblUpdateYearLevel = New Label()
        cmbUpdateYearLevel = New ComboBox()
        btnUpdateCourse = New Button()
        btnDeleteCourse = New Button()
        pnlManagePrerequisites = New Panel()
        lblPrerequisitesTitle = New Label()
        lblSelectCourseForPrereq = New Label()
        cmbSelectCourseForPrereq = New ComboBox()
        btnLoadPrerequisites = New Button()
        grpPrerequisiteInfo = New GroupBox()
        lblCurrentPrerequisites = New Label()
        dgvPrerequisites = New DataGridView()
        lblAddPrerequisite = New Label()
        cmbPrerequisiteCourse = New ComboBox()
        chkIsCorequisite = New CheckBox()
        btnAddPrerequisite = New Button()
        btnRemovePrerequisite = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlAddCourse.SuspendLayout()
        pnlViewCourses.SuspendLayout()
        CType(dgvCourses, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteCourse.SuspendLayout()
        grpCourseInfo.SuspendLayout()
        pnlManagePrerequisites.SuspendLayout()
        grpPrerequisiteInfo.SuspendLayout()
        CType(dgvPrerequisites, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCourseOffer)
        pnlSidebar.Controls.Add(btnManagePrerequisites)
        pnlSidebar.Controls.Add(btnUpdateDeleteCourse)
        pnlSidebar.Controls.Add(btnViewCourses)
        pnlSidebar.Controls.Add(btnAddCourse)
        pnlSidebar.Controls.Add(lblCourseTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(200, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCourseOffer
        ' 
        btnCourseOffer.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCourseOffer.Dock = DockStyle.Top
        btnCourseOffer.FlatAppearance.BorderSize = 0
        btnCourseOffer.FlatStyle = FlatStyle.Flat
        btnCourseOffer.Font = New Font("Times New Roman", 11F)
        btnCourseOffer.ForeColor = Color.White
        btnCourseOffer.Location = New Point(0, 280)
        btnCourseOffer.Name = "btnCourseOffer"
        btnCourseOffer.Size = New Size(200, 50)
        btnCourseOffer.TabIndex = 5
        btnCourseOffer.Text = "Course Offering Management"
        btnCourseOffer.UseVisualStyleBackColor = False
        ' 
        ' btnManagePrerequisites
        ' 
        btnManagePrerequisites.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnManagePrerequisites.Dock = DockStyle.Top
        btnManagePrerequisites.FlatAppearance.BorderSize = 0
        btnManagePrerequisites.FlatStyle = FlatStyle.Flat
        btnManagePrerequisites.Font = New Font("Times New Roman", 11F)
        btnManagePrerequisites.ForeColor = Color.White
        btnManagePrerequisites.Location = New Point(0, 230)
        btnManagePrerequisites.Name = "btnManagePrerequisites"
        btnManagePrerequisites.Size = New Size(200, 50)
        btnManagePrerequisites.TabIndex = 4
        btnManagePrerequisites.Text = "Manage Prerequisites"
        btnManagePrerequisites.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteCourse
        ' 
        btnUpdateDeleteCourse.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteCourse.Dock = DockStyle.Top
        btnUpdateDeleteCourse.FlatAppearance.BorderSize = 0
        btnUpdateDeleteCourse.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteCourse.Font = New Font("Times New Roman", 11F)
        btnUpdateDeleteCourse.ForeColor = Color.White
        btnUpdateDeleteCourse.Location = New Point(0, 180)
        btnUpdateDeleteCourse.Name = "btnUpdateDeleteCourse"
        btnUpdateDeleteCourse.Size = New Size(200, 50)
        btnUpdateDeleteCourse.TabIndex = 3
        btnUpdateDeleteCourse.Text = "Update/Delete Course"
        btnUpdateDeleteCourse.UseVisualStyleBackColor = False
        ' 
        ' btnViewCourses
        ' 
        btnViewCourses.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewCourses.Dock = DockStyle.Top
        btnViewCourses.FlatAppearance.BorderSize = 0
        btnViewCourses.FlatStyle = FlatStyle.Flat
        btnViewCourses.Font = New Font("Times New Roman", 11F)
        btnViewCourses.ForeColor = Color.White
        btnViewCourses.Location = New Point(0, 130)
        btnViewCourses.Name = "btnViewCourses"
        btnViewCourses.Size = New Size(200, 50)
        btnViewCourses.TabIndex = 2
        btnViewCourses.Text = "View Courses"
        btnViewCourses.UseVisualStyleBackColor = False
        ' 
        ' btnAddCourse
        ' 
        btnAddCourse.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnAddCourse.Dock = DockStyle.Top
        btnAddCourse.FlatAppearance.BorderSize = 0
        btnAddCourse.FlatStyle = FlatStyle.Flat
        btnAddCourse.Font = New Font("Times New Roman", 11F)
        btnAddCourse.ForeColor = Color.White
        btnAddCourse.Location = New Point(0, 80)
        btnAddCourse.Name = "btnAddCourse"
        btnAddCourse.Size = New Size(200, 50)
        btnAddCourse.TabIndex = 1
        btnAddCourse.Text = "+ Add Course"
        btnAddCourse.UseVisualStyleBackColor = False
        ' 
        ' lblCourseTitle
        ' 
        lblCourseTitle.BackColor = Color.Navy
        lblCourseTitle.Dock = DockStyle.Top
        lblCourseTitle.Font = New Font("Times New Roman", 14F, FontStyle.Bold)
        lblCourseTitle.ForeColor = Color.White
        lblCourseTitle.Location = New Point(0, 0)
        lblCourseTitle.Name = "lblCourseTitle"
        lblCourseTitle.Size = New Size(200, 80)
        lblCourseTitle.TabIndex = 0
        lblCourseTitle.Text = "Course Management"
        lblCourseTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnClose.Dock = DockStyle.Bottom
        btnClose.FlatAppearance.BorderSize = 0
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(0, 750)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(200, 50)
        btnClose.TabIndex = 5
        btnClose.Text = "🚪 Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlMainContent.Controls.Add(pnlAddCourse)
        pnlMainContent.Controls.Add(pnlViewCourses)
        pnlMainContent.Controls.Add(pnlUpdateDeleteCourse)
        pnlMainContent.Controls.Add(pnlManagePrerequisites)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(200, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(1000, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlAddCourse
        ' 
        pnlAddCourse.AutoScroll = True
        pnlAddCourse.BackColor = Color.White
        pnlAddCourse.Controls.Add(lblAddCourseTitle)
        pnlAddCourse.Controls.Add(lblCourseCode)
        pnlAddCourse.Controls.Add(txtCourseCode)
        pnlAddCourse.Controls.Add(lblCourseName)
        pnlAddCourse.Controls.Add(txtCourseName)
        pnlAddCourse.Controls.Add(lblCourseDescription)
        pnlAddCourse.Controls.Add(txtCourseDescription)
        pnlAddCourse.Controls.Add(lblLabUnits)
        pnlAddCourse.Controls.Add(txtLabUnits)
        pnlAddCourse.Controls.Add(lblLectureUnits)
        pnlAddCourse.Controls.Add(txtLectureUnits)
        pnlAddCourse.Controls.Add(lblDepartment)
        pnlAddCourse.Controls.Add(cmbDepartment)
        pnlAddCourse.Controls.Add(lblYearLevel)
        pnlAddCourse.Controls.Add(cmbYearLevel)
        pnlAddCourse.Controls.Add(btnSubmitCourse)
        pnlAddCourse.Dock = DockStyle.Fill
        pnlAddCourse.Location = New Point(0, 0)
        pnlAddCourse.Name = "pnlAddCourse"
        pnlAddCourse.Padding = New Padding(30, 20, 30, 20)
        pnlAddCourse.Size = New Size(1000, 800)
        pnlAddCourse.TabIndex = 0
        pnlAddCourse.Visible = False
        ' 
        ' lblAddCourseTitle
        ' 
        lblAddCourseTitle.AutoSize = True
        lblAddCourseTitle.Font = New Font("Times New Roman", 20F, FontStyle.Bold)
        lblAddCourseTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblAddCourseTitle.Location = New Point(30, 20)
        lblAddCourseTitle.Name = "lblAddCourseTitle"
        lblAddCourseTitle.Size = New Size(212, 31)
        lblAddCourseTitle.TabIndex = 0
        lblAddCourseTitle.Text = "Add New Course"
        ' 
        ' lblCourseCode
        ' 
        lblCourseCode.AutoSize = True
        lblCourseCode.Font = New Font("Times New Roman", 12F)
        lblCourseCode.Location = New Point(50, 75)
        lblCourseCode.Name = "lblCourseCode"
        lblCourseCode.Size = New Size(103, 19)
        lblCourseCode.TabIndex = 1
        lblCourseCode.Text = "Course Code *"
        ' 
        ' txtCourseCode
        ' 
        txtCourseCode.Font = New Font("Times New Roman", 12F)
        txtCourseCode.Location = New Point(50, 97)
        txtCourseCode.MaxLength = 50
        txtCourseCode.Name = "txtCourseCode"
        txtCourseCode.Size = New Size(300, 26)
        txtCourseCode.TabIndex = 2
        ' 
        ' lblCourseName
        ' 
        lblCourseName.AutoSize = True
        lblCourseName.Font = New Font("Times New Roman", 12F)
        lblCourseName.Location = New Point(400, 75)
        lblCourseName.Name = "lblCourseName"
        lblCourseName.Size = New Size(106, 19)
        lblCourseName.TabIndex = 3
        lblCourseName.Text = "Course Name *"
        ' 
        ' txtCourseName
        ' 
        txtCourseName.Font = New Font("Times New Roman", 12F)
        txtCourseName.Location = New Point(400, 97)
        txtCourseName.MaxLength = 255
        txtCourseName.Name = "txtCourseName"
        txtCourseName.Size = New Size(500, 26)
        txtCourseName.TabIndex = 4
        ' 
        ' lblCourseDescription
        ' 
        lblCourseDescription.AutoSize = True
        lblCourseDescription.Font = New Font("Times New Roman", 12F)
        lblCourseDescription.Location = New Point(50, 145)
        lblCourseDescription.Name = "lblCourseDescription"
        lblCourseDescription.Size = New Size(192, 19)
        lblCourseDescription.TabIndex = 5
        lblCourseDescription.Text = "Course Description (Optional)"
        ' 
        ' txtCourseDescription
        ' 
        txtCourseDescription.Font = New Font("Times New Roman", 12F)
        txtCourseDescription.Location = New Point(50, 167)
        txtCourseDescription.Multiline = True
        txtCourseDescription.Name = "txtCourseDescription"
        txtCourseDescription.ScrollBars = ScrollBars.Vertical
        txtCourseDescription.Size = New Size(850, 80)
        txtCourseDescription.TabIndex = 6
        ' 
        ' lblLabUnits
        ' 
        lblLabUnits.AutoSize = True
        lblLabUnits.Font = New Font("Times New Roman", 12F)
        lblLabUnits.Location = New Point(50, 270)
        lblLabUnits.Name = "lblLabUnits"
        lblLabUnits.Size = New Size(68, 19)
        lblLabUnits.TabIndex = 7
        lblLabUnits.Text = "Lab Units"
        ' 
        ' txtLabUnits
        ' 
        txtLabUnits.Font = New Font("Times New Roman", 12F)
        txtLabUnits.Location = New Point(50, 292)
        txtLabUnits.MaxLength = 2
        txtLabUnits.Name = "txtLabUnits"
        txtLabUnits.Size = New Size(150, 26)
        txtLabUnits.TabIndex = 8
        txtLabUnits.Text = "0"
        ' 
        ' lblLectureUnits
        ' 
        lblLectureUnits.AutoSize = True
        lblLectureUnits.Font = New Font("Times New Roman", 12F)
        lblLectureUnits.Location = New Point(250, 270)
        lblLectureUnits.Name = "lblLectureUnits"
        lblLectureUnits.Size = New Size(102, 19)
        lblLectureUnits.TabIndex = 9
        lblLectureUnits.Text = "Lecture Units *"
        ' 
        ' txtLectureUnits
        ' 
        txtLectureUnits.Font = New Font("Times New Roman", 12F)
        txtLectureUnits.Location = New Point(250, 292)
        txtLectureUnits.MaxLength = 2
        txtLectureUnits.Name = "txtLectureUnits"
        txtLectureUnits.Size = New Size(150, 26)
        txtLectureUnits.TabIndex = 10
        txtLectureUnits.Text = "3"
        ' 
        ' lblDepartment
        ' 
        lblDepartment.AutoSize = True
        lblDepartment.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblDepartment.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblDepartment.Location = New Point(50, 340)
        lblDepartment.Name = "lblDepartment"
        lblDepartment.Size = New Size(101, 19)
        lblDepartment.TabIndex = 11
        lblDepartment.Text = "Department *"
        ' 
        ' cmbDepartment
        ' 
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDepartment.Font = New Font("Times New Roman", 12F)
        cmbDepartment.FormattingEnabled = True
        cmbDepartment.Location = New Point(50, 362)
        cmbDepartment.Name = "cmbDepartment"
        cmbDepartment.Size = New Size(400, 27)
        cmbDepartment.TabIndex = 12
        ' 
        ' lblYearLevel
        ' 
        lblYearLevel.AutoSize = True
        lblYearLevel.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblYearLevel.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblYearLevel.Location = New Point(500, 340)
        lblYearLevel.Name = "lblYearLevel"
        lblYearLevel.Size = New Size(93, 19)
        lblYearLevel.TabIndex = 13
        lblYearLevel.Text = "Year Level *"
        ' 
        ' cmbYearLevel
        ' 
        cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cmbYearLevel.Font = New Font("Times New Roman", 12F)
        cmbYearLevel.FormattingEnabled = True
        cmbYearLevel.Location = New Point(500, 362)
        cmbYearLevel.Name = "cmbYearLevel"
        cmbYearLevel.Size = New Size(400, 27)
        cmbYearLevel.TabIndex = 14
        ' 
        ' btnSubmitCourse
        ' 
        btnSubmitCourse.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnSubmitCourse.FlatStyle = FlatStyle.Flat
        btnSubmitCourse.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnSubmitCourse.ForeColor = Color.White
        btnSubmitCourse.Location = New Point(50, 420)
        btnSubmitCourse.Name = "btnSubmitCourse"
        btnSubmitCourse.Size = New Size(200, 45)
        btnSubmitCourse.TabIndex = 15
        btnSubmitCourse.Text = "+ Add Course"
        btnSubmitCourse.UseVisualStyleBackColor = False
        ' 
        ' pnlViewCourses
        ' 
        pnlViewCourses.BackColor = Color.White
        pnlViewCourses.Controls.Add(dgvCourses)
        pnlViewCourses.Controls.Add(lblViewCoursesTitle)
        pnlViewCourses.Controls.Add(btnRefreshCourses)
        pnlViewCourses.Dock = DockStyle.Fill
        pnlViewCourses.Location = New Point(0, 0)
        pnlViewCourses.Name = "pnlViewCourses"
        pnlViewCourses.Padding = New Padding(20)
        pnlViewCourses.Size = New Size(1000, 800)
        pnlViewCourses.TabIndex = 1
        pnlViewCourses.Visible = False
        ' 
        ' dgvCourses
        ' 
        dgvCourses.AllowUserToAddRows = False
        dgvCourses.AllowUserToDeleteRows = False
        dgvCourses.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvCourses.BackgroundColor = SystemColors.Control
        dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvCourses.Location = New Point(23, 70)
        dgvCourses.Name = "dgvCourses"
        dgvCourses.ReadOnly = True
        dgvCourses.Size = New Size(954, 690)
        dgvCourses.TabIndex = 1
        ' 
        ' lblViewCoursesTitle
        ' 
        lblViewCoursesTitle.AutoSize = True
        lblViewCoursesTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblViewCoursesTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewCoursesTitle.Location = New Point(23, 20)
        lblViewCoursesTitle.Name = "lblViewCoursesTitle"
        lblViewCoursesTitle.Size = New Size(173, 36)
        lblViewCoursesTitle.TabIndex = 0
        lblViewCoursesTitle.Text = "All Courses"
        ' 
        ' btnRefreshCourses
        ' 
        btnRefreshCourses.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshCourses.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshCourses.FlatStyle = FlatStyle.Flat
        btnRefreshCourses.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRefreshCourses.ForeColor = Color.White
        btnRefreshCourses.Location = New Point(750, 20)
        btnRefreshCourses.Name = "btnRefreshCourses"
        btnRefreshCourses.Size = New Size(160, 40)
        btnRefreshCourses.TabIndex = 2
        btnRefreshCourses.Text = "🔄 Refresh"
        btnRefreshCourses.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteCourse
        ' 
        pnlUpdateDeleteCourse.AutoScroll = True
        pnlUpdateDeleteCourse.BackColor = Color.White
        pnlUpdateDeleteCourse.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteCourse.Controls.Add(lblSelectCourseUpdate)
        pnlUpdateDeleteCourse.Controls.Add(cmbSelectCourseUpdate)
        pnlUpdateDeleteCourse.Controls.Add(btnLoadCourseData)
        pnlUpdateDeleteCourse.Controls.Add(grpCourseInfo)
        pnlUpdateDeleteCourse.Dock = DockStyle.Fill
        pnlUpdateDeleteCourse.Location = New Point(0, 0)
        pnlUpdateDeleteCourse.Name = "pnlUpdateDeleteCourse"
        pnlUpdateDeleteCourse.Padding = New Padding(20)
        pnlUpdateDeleteCourse.Size = New Size(1000, 800)
        pnlUpdateDeleteCourse.TabIndex = 2
        pnlUpdateDeleteCourse.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(379, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete Course Info"
        ' 
        ' lblSelectCourseUpdate
        ' 
        lblSelectCourseUpdate.AutoSize = True
        lblSelectCourseUpdate.Font = New Font("Times New Roman", 14F)
        lblSelectCourseUpdate.Location = New Point(40, 80)
        lblSelectCourseUpdate.Name = "lblSelectCourseUpdate"
        lblSelectCourseUpdate.Size = New Size(114, 21)
        lblSelectCourseUpdate.TabIndex = 1
        lblSelectCourseUpdate.Text = "Select Course"
        ' 
        ' cmbSelectCourseUpdate
        ' 
        cmbSelectCourseUpdate.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectCourseUpdate.Font = New Font("Times New Roman", 12F)
        cmbSelectCourseUpdate.FormattingEnabled = True
        cmbSelectCourseUpdate.Location = New Point(40, 105)
        cmbSelectCourseUpdate.Name = "cmbSelectCourseUpdate"
        cmbSelectCourseUpdate.Size = New Size(500, 27)
        cmbSelectCourseUpdate.TabIndex = 2
        ' 
        ' btnLoadCourseData
        ' 
        btnLoadCourseData.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadCourseData.FlatStyle = FlatStyle.Flat
        btnLoadCourseData.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnLoadCourseData.ForeColor = Color.White
        btnLoadCourseData.Location = New Point(560, 105)
        btnLoadCourseData.Name = "btnLoadCourseData"
        btnLoadCourseData.Size = New Size(140, 29)
        btnLoadCourseData.TabIndex = 3
        btnLoadCourseData.Text = "Load Data"
        btnLoadCourseData.UseVisualStyleBackColor = False
        ' 
        ' grpCourseInfo
        ' 
        grpCourseInfo.Controls.Add(lblUpdateCourseCode)
        grpCourseInfo.Controls.Add(txtUpdateCourseCode)
        grpCourseInfo.Controls.Add(lblUpdateCourseName)
        grpCourseInfo.Controls.Add(txtUpdateCourseName)
        grpCourseInfo.Controls.Add(lblUpdateCourseDescription)
        grpCourseInfo.Controls.Add(txtUpdateCourseDescription)
        grpCourseInfo.Controls.Add(lblUpdateLabUnits)
        grpCourseInfo.Controls.Add(txtUpdateLabUnits)
        grpCourseInfo.Controls.Add(lblUpdateLectureUnits)
        grpCourseInfo.Controls.Add(txtUpdateLectureUnits)
        grpCourseInfo.Controls.Add(lblUpdateDepartment)
        grpCourseInfo.Controls.Add(cmbUpdateDepartment)
        grpCourseInfo.Controls.Add(lblUpdateYearLevel)
        grpCourseInfo.Controls.Add(cmbUpdateYearLevel)
        grpCourseInfo.Controls.Add(btnUpdateCourse)
        grpCourseInfo.Controls.Add(btnDeleteCourse)
        grpCourseInfo.Location = New Point(40, 150)
        grpCourseInfo.Name = "grpCourseInfo"
        grpCourseInfo.Size = New Size(920, 600)
        grpCourseInfo.TabIndex = 4
        grpCourseInfo.TabStop = False
        grpCourseInfo.Text = "Course Information"
        grpCourseInfo.Visible = False
        ' 
        ' lblUpdateCourseCode
        ' 
        lblUpdateCourseCode.AutoSize = True
        lblUpdateCourseCode.Font = New Font("Times New Roman", 12F)
        lblUpdateCourseCode.Location = New Point(30, 40)
        lblUpdateCourseCode.Name = "lblUpdateCourseCode"
        lblUpdateCourseCode.Size = New Size(103, 19)
        lblUpdateCourseCode.TabIndex = 0
        lblUpdateCourseCode.Text = "Course Code *"
        ' 
        ' txtUpdateCourseCode
        ' 
        txtUpdateCourseCode.Font = New Font("Times New Roman", 12F)
        txtUpdateCourseCode.Location = New Point(30, 62)
        txtUpdateCourseCode.MaxLength = 50
        txtUpdateCourseCode.Name = "txtUpdateCourseCode"
        txtUpdateCourseCode.Size = New Size(300, 26)
        txtUpdateCourseCode.TabIndex = 1
        ' 
        ' lblUpdateCourseName
        ' 
        lblUpdateCourseName.AutoSize = True
        lblUpdateCourseName.Font = New Font("Times New Roman", 12F)
        lblUpdateCourseName.Location = New Point(380, 40)
        lblUpdateCourseName.Name = "lblUpdateCourseName"
        lblUpdateCourseName.Size = New Size(106, 19)
        lblUpdateCourseName.TabIndex = 2
        lblUpdateCourseName.Text = "Course Name *"
        ' 
        ' txtUpdateCourseName
        ' 
        txtUpdateCourseName.Font = New Font("Times New Roman", 12F)
        txtUpdateCourseName.Location = New Point(380, 62)
        txtUpdateCourseName.MaxLength = 255
        txtUpdateCourseName.Name = "txtUpdateCourseName"
        txtUpdateCourseName.Size = New Size(500, 26)
        txtUpdateCourseName.TabIndex = 3
        ' 
        ' lblUpdateCourseDescription
        ' 
        lblUpdateCourseDescription.AutoSize = True
        lblUpdateCourseDescription.Font = New Font("Times New Roman", 12F)
        lblUpdateCourseDescription.Location = New Point(30, 110)
        lblUpdateCourseDescription.Name = "lblUpdateCourseDescription"
        lblUpdateCourseDescription.Size = New Size(192, 19)
        lblUpdateCourseDescription.TabIndex = 4
        lblUpdateCourseDescription.Text = "Course Description (Optional)"
        ' 
        ' txtUpdateCourseDescription
        ' 
        txtUpdateCourseDescription.Font = New Font("Times New Roman", 12F)
        txtUpdateCourseDescription.Location = New Point(30, 132)
        txtUpdateCourseDescription.Multiline = True
        txtUpdateCourseDescription.Name = "txtUpdateCourseDescription"
        txtUpdateCourseDescription.ScrollBars = ScrollBars.Vertical
        txtUpdateCourseDescription.Size = New Size(850, 80)
        txtUpdateCourseDescription.TabIndex = 5
        ' 
        ' lblUpdateLabUnits
        ' 
        lblUpdateLabUnits.AutoSize = True
        lblUpdateLabUnits.Font = New Font("Times New Roman", 12F)
        lblUpdateLabUnits.Location = New Point(30, 235)
        lblUpdateLabUnits.Name = "lblUpdateLabUnits"
        lblUpdateLabUnits.Size = New Size(68, 19)
        lblUpdateLabUnits.TabIndex = 6
        lblUpdateLabUnits.Text = "Lab Units"
        ' 
        ' txtUpdateLabUnits
        ' 
        txtUpdateLabUnits.Font = New Font("Times New Roman", 12F)
        txtUpdateLabUnits.Location = New Point(30, 257)
        txtUpdateLabUnits.MaxLength = 2
        txtUpdateLabUnits.Name = "txtUpdateLabUnits"
        txtUpdateLabUnits.Size = New Size(150, 26)
        txtUpdateLabUnits.TabIndex = 7
        ' 
        ' lblUpdateLectureUnits
        ' 
        lblUpdateLectureUnits.AutoSize = True
        lblUpdateLectureUnits.Font = New Font("Times New Roman", 12F)
        lblUpdateLectureUnits.Location = New Point(230, 235)
        lblUpdateLectureUnits.Name = "lblUpdateLectureUnits"
        lblUpdateLectureUnits.Size = New Size(102, 19)
        lblUpdateLectureUnits.TabIndex = 8
        lblUpdateLectureUnits.Text = "Lecture Units *"
        ' 
        ' txtUpdateLectureUnits
        ' 
        txtUpdateLectureUnits.Font = New Font("Times New Roman", 12F)
        txtUpdateLectureUnits.Location = New Point(230, 257)
        txtUpdateLectureUnits.MaxLength = 2
        txtUpdateLectureUnits.Name = "txtUpdateLectureUnits"
        txtUpdateLectureUnits.Size = New Size(150, 26)
        txtUpdateLectureUnits.TabIndex = 9
        ' 
        ' lblUpdateDepartment
        ' 
        lblUpdateDepartment.AutoSize = True
        lblUpdateDepartment.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateDepartment.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateDepartment.Location = New Point(30, 305)
        lblUpdateDepartment.Name = "lblUpdateDepartment"
        lblUpdateDepartment.Size = New Size(101, 19)
        lblUpdateDepartment.TabIndex = 10
        lblUpdateDepartment.Text = "Department *"
        ' 
        ' cmbUpdateDepartment
        ' 
        cmbUpdateDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateDepartment.Font = New Font("Times New Roman", 12F)
        cmbUpdateDepartment.FormattingEnabled = True
        cmbUpdateDepartment.Location = New Point(30, 327)
        cmbUpdateDepartment.Name = "cmbUpdateDepartment"
        cmbUpdateDepartment.Size = New Size(400, 27)
        cmbUpdateDepartment.TabIndex = 11
        ' 
        ' lblUpdateYearLevel
        ' 
        lblUpdateYearLevel.AutoSize = True
        lblUpdateYearLevel.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateYearLevel.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateYearLevel.Location = New Point(480, 305)
        lblUpdateYearLevel.Name = "lblUpdateYearLevel"
        lblUpdateYearLevel.Size = New Size(93, 19)
        lblUpdateYearLevel.TabIndex = 12
        lblUpdateYearLevel.Text = "Year Level *"
        ' 
        ' cmbUpdateYearLevel
        ' 
        cmbUpdateYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateYearLevel.Font = New Font("Times New Roman", 12F)
        cmbUpdateYearLevel.FormattingEnabled = True
        cmbUpdateYearLevel.Location = New Point(480, 327)
        cmbUpdateYearLevel.Name = "cmbUpdateYearLevel"
        cmbUpdateYearLevel.Size = New Size(400, 27)
        cmbUpdateYearLevel.TabIndex = 13
        ' 
        ' btnUpdateCourse
        ' 
        btnUpdateCourse.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnUpdateCourse.FlatStyle = FlatStyle.Flat
        btnUpdateCourse.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnUpdateCourse.ForeColor = Color.White
        btnUpdateCourse.Location = New Point(30, 385)
        btnUpdateCourse.Name = "btnUpdateCourse"
        btnUpdateCourse.Size = New Size(200, 45)
        btnUpdateCourse.TabIndex = 14
        btnUpdateCourse.Text = "Update Course"
        btnUpdateCourse.UseVisualStyleBackColor = False
        btnUpdateCourse.Visible = False
        ' 
        ' btnDeleteCourse
        ' 
        btnDeleteCourse.BackColor = Color.FromArgb(CByte(255), CByte(71), CByte(71))
        btnDeleteCourse.FlatStyle = FlatStyle.Flat
        btnDeleteCourse.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnDeleteCourse.ForeColor = Color.White
        btnDeleteCourse.Location = New Point(250, 385)
        btnDeleteCourse.Name = "btnDeleteCourse"
        btnDeleteCourse.Size = New Size(200, 45)
        btnDeleteCourse.TabIndex = 15
        btnDeleteCourse.Text = "Delete Course"
        btnDeleteCourse.UseVisualStyleBackColor = False
        btnDeleteCourse.Visible = False
        ' 
        ' pnlManagePrerequisites
        ' 
        pnlManagePrerequisites.AutoScroll = True
        pnlManagePrerequisites.BackColor = Color.White
        pnlManagePrerequisites.Controls.Add(lblPrerequisitesTitle)
        pnlManagePrerequisites.Controls.Add(lblSelectCourseForPrereq)
        pnlManagePrerequisites.Controls.Add(cmbSelectCourseForPrereq)
        pnlManagePrerequisites.Controls.Add(btnLoadPrerequisites)
        pnlManagePrerequisites.Controls.Add(grpPrerequisiteInfo)
        pnlManagePrerequisites.Dock = DockStyle.Fill
        pnlManagePrerequisites.Location = New Point(0, 0)
        pnlManagePrerequisites.Name = "pnlManagePrerequisites"
        pnlManagePrerequisites.Padding = New Padding(20)
        pnlManagePrerequisites.Size = New Size(1000, 800)
        pnlManagePrerequisites.TabIndex = 3
        pnlManagePrerequisites.Visible = False
        ' 
        ' lblPrerequisitesTitle
        ' 
        lblPrerequisitesTitle.AutoSize = True
        lblPrerequisitesTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblPrerequisitesTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblPrerequisitesTitle.Location = New Point(20, 20)
        lblPrerequisitesTitle.Name = "lblPrerequisitesTitle"
        lblPrerequisitesTitle.Size = New Size(416, 36)
        lblPrerequisitesTitle.TabIndex = 0
        lblPrerequisitesTitle.Text = "Manage Course Prerequisites"
        ' 
        ' lblSelectCourseForPrereq
        ' 
        lblSelectCourseForPrereq.AutoSize = True
        lblSelectCourseForPrereq.Font = New Font("Times New Roman", 14F)
        lblSelectCourseForPrereq.Location = New Point(40, 80)
        lblSelectCourseForPrereq.Name = "lblSelectCourseForPrereq"
        lblSelectCourseForPrereq.Size = New Size(114, 21)
        lblSelectCourseForPrereq.TabIndex = 1
        lblSelectCourseForPrereq.Text = "Select Course"
        ' 
        ' cmbSelectCourseForPrereq
        ' 
        cmbSelectCourseForPrereq.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectCourseForPrereq.Font = New Font("Times New Roman", 12F)
        cmbSelectCourseForPrereq.FormattingEnabled = True
        cmbSelectCourseForPrereq.Location = New Point(40, 105)
        cmbSelectCourseForPrereq.Name = "cmbSelectCourseForPrereq"
        cmbSelectCourseForPrereq.Size = New Size(600, 27)
        cmbSelectCourseForPrereq.TabIndex = 2
        ' 
        ' btnLoadPrerequisites
        ' 
        btnLoadPrerequisites.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadPrerequisites.FlatStyle = FlatStyle.Flat
        btnLoadPrerequisites.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnLoadPrerequisites.ForeColor = Color.White
        btnLoadPrerequisites.Location = New Point(660, 105)
        btnLoadPrerequisites.Name = "btnLoadPrerequisites"
        btnLoadPrerequisites.Size = New Size(180, 29)
        btnLoadPrerequisites.TabIndex = 3
        btnLoadPrerequisites.Text = "Load Prerequisites"
        btnLoadPrerequisites.UseVisualStyleBackColor = False
        ' 
        ' grpPrerequisiteInfo
        ' 
        grpPrerequisiteInfo.Controls.Add(lblCurrentPrerequisites)
        grpPrerequisiteInfo.Controls.Add(dgvPrerequisites)
        grpPrerequisiteInfo.Controls.Add(lblAddPrerequisite)
        grpPrerequisiteInfo.Controls.Add(cmbPrerequisiteCourse)
        grpPrerequisiteInfo.Controls.Add(chkIsCorequisite)
        grpPrerequisiteInfo.Controls.Add(btnAddPrerequisite)
        grpPrerequisiteInfo.Controls.Add(btnRemovePrerequisite)
        grpPrerequisiteInfo.Location = New Point(40, 150)
        grpPrerequisiteInfo.Name = "grpPrerequisiteInfo"
        grpPrerequisiteInfo.Size = New Size(920, 600)
        grpPrerequisiteInfo.TabIndex = 4
        grpPrerequisiteInfo.TabStop = False
        grpPrerequisiteInfo.Text = "Prerequisites Information"
        grpPrerequisiteInfo.Visible = False
        ' 
        ' lblCurrentPrerequisites
        ' 
        lblCurrentPrerequisites.AutoSize = True
        lblCurrentPrerequisites.Font = New Font("Times New Roman", 14F, FontStyle.Bold)
        lblCurrentPrerequisites.Location = New Point(30, 40)
        lblCurrentPrerequisites.Name = "lblCurrentPrerequisites"
        lblCurrentPrerequisites.Size = New Size(192, 22)
        lblCurrentPrerequisites.TabIndex = 0
        lblCurrentPrerequisites.Text = "Current Prerequisites:"
        ' 
        ' dgvPrerequisites
        ' 
        dgvPrerequisites.AllowUserToAddRows = False
        dgvPrerequisites.AllowUserToDeleteRows = False
        dgvPrerequisites.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPrerequisites.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPrerequisites.BackgroundColor = SystemColors.Control
        dgvPrerequisites.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPrerequisites.Location = New Point(30, 70)
        dgvPrerequisites.Name = "dgvPrerequisites"
        dgvPrerequisites.ReadOnly = True
        dgvPrerequisites.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPrerequisites.Size = New Size(860, 250)
        dgvPrerequisites.TabIndex = 1
        ' 
        ' lblAddPrerequisite
        ' 
        lblAddPrerequisite.AutoSize = True
        lblAddPrerequisite.Font = New Font("Times New Roman", 14F, FontStyle.Bold)
        lblAddPrerequisite.Location = New Point(30, 350)
        lblAddPrerequisite.Name = "lblAddPrerequisite"
        lblAddPrerequisite.Size = New Size(152, 22)
        lblAddPrerequisite.TabIndex = 2
        lblAddPrerequisite.Text = "Add Prerequisite:"
        ' 
        ' cmbPrerequisiteCourse
        ' 
        cmbPrerequisiteCourse.DropDownStyle = ComboBoxStyle.DropDownList
        cmbPrerequisiteCourse.Font = New Font("Times New Roman", 12F)
        cmbPrerequisiteCourse.FormattingEnabled = True
        cmbPrerequisiteCourse.Location = New Point(30, 380)
        cmbPrerequisiteCourse.Name = "cmbPrerequisiteCourse"
        cmbPrerequisiteCourse.Size = New Size(500, 27)
        cmbPrerequisiteCourse.TabIndex = 3
        ' 
        ' chkIsCorequisite
        ' 
        chkIsCorequisite.AutoSize = True
        chkIsCorequisite.Font = New Font("Times New Roman", 12F)
        chkIsCorequisite.Location = New Point(30, 425)
        chkIsCorequisite.Name = "chkIsCorequisite"
        chkIsCorequisite.Size = New Size(304, 23)
        chkIsCorequisite.TabIndex = 4
        chkIsCorequisite.Text = "Is Corequisite (can be taken at the same time)"
        chkIsCorequisite.UseVisualStyleBackColor = True
        ' 
        ' btnAddPrerequisite
        ' 
        btnAddPrerequisite.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnAddPrerequisite.FlatStyle = FlatStyle.Flat
        btnAddPrerequisite.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnAddPrerequisite.ForeColor = Color.White
        btnAddPrerequisite.Location = New Point(30, 470)
        btnAddPrerequisite.Name = "btnAddPrerequisite"
        btnAddPrerequisite.Size = New Size(200, 45)
        btnAddPrerequisite.TabIndex = 5
        btnAddPrerequisite.Text = "+ Add Prerequisite"
        btnAddPrerequisite.UseVisualStyleBackColor = False
        ' 
        ' btnRemovePrerequisite
        ' 
        btnRemovePrerequisite.BackColor = Color.FromArgb(CByte(255), CByte(71), CByte(71))
        btnRemovePrerequisite.FlatStyle = FlatStyle.Flat
        btnRemovePrerequisite.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRemovePrerequisite.ForeColor = Color.White
        btnRemovePrerequisite.Location = New Point(250, 470)
        btnRemovePrerequisite.Name = "btnRemovePrerequisite"
        btnRemovePrerequisite.Size = New Size(230, 45)
        btnRemovePrerequisite.TabIndex = 6
        btnRemovePrerequisite.Text = "Remove Selected"
        btnRemovePrerequisite.UseVisualStyleBackColor = False
        ' 
        ' Course
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "Course"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Course Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlAddCourse.ResumeLayout(False)
        pnlAddCourse.PerformLayout()
        pnlViewCourses.ResumeLayout(False)
        pnlViewCourses.PerformLayout()
        CType(dgvCourses, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteCourse.ResumeLayout(False)
        pnlUpdateDeleteCourse.PerformLayout()
        grpCourseInfo.ResumeLayout(False)
        grpCourseInfo.PerformLayout()
        pnlManagePrerequisites.ResumeLayout(False)
        pnlManagePrerequisites.PerformLayout()
        grpPrerequisiteInfo.ResumeLayout(False)
        grpPrerequisiteInfo.PerformLayout()
        CType(dgvPrerequisites, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblCourseTitle As Label
    Friend WithEvents btnAddCourse As Button
    Friend WithEvents btnViewCourses As Button
    Friend WithEvents btnUpdateDeleteCourse As Button
    Friend WithEvents btnManagePrerequisites As Button
    Friend WithEvents btnCourseOffer As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Add Course Panel
    Friend WithEvents pnlAddCourse As Panel
    Friend WithEvents lblAddCourseTitle As Label
    Friend WithEvents lblCourseCode As Label
    Friend WithEvents txtCourseCode As TextBox
    Friend WithEvents lblCourseName As Label
    Friend WithEvents txtCourseName As TextBox
    Friend WithEvents lblCourseDescription As Label
    Friend WithEvents txtCourseDescription As TextBox
    Friend WithEvents lblLabUnits As Label
    Friend WithEvents txtLabUnits As TextBox
    Friend WithEvents lblLectureUnits As Label
    Friend WithEvents txtLectureUnits As TextBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents lblYearLevel As Label
    Friend WithEvents cmbYearLevel As ComboBox
    Friend WithEvents btnSubmitCourse As Button

    ' View Courses Panel
    Friend WithEvents pnlViewCourses As Panel
    Friend WithEvents lblViewCoursesTitle As Label
    Friend WithEvents dgvCourses As DataGridView
    Friend WithEvents btnRefreshCourses As Button

    ' Update/Delete Course Panel
    Friend WithEvents pnlUpdateDeleteCourse As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectCourseUpdate As Label
    Friend WithEvents cmbSelectCourseUpdate As ComboBox
    Friend WithEvents btnLoadCourseData As Button
    Friend WithEvents grpCourseInfo As GroupBox
    Friend WithEvents lblUpdateCourseCode As Label
    Friend WithEvents txtUpdateCourseCode As TextBox
    Friend WithEvents lblUpdateCourseName As Label
    Friend WithEvents txtUpdateCourseName As TextBox
    Friend WithEvents lblUpdateCourseDescription As Label
    Friend WithEvents txtUpdateCourseDescription As TextBox
    Friend WithEvents lblUpdateLabUnits As Label
    Friend WithEvents txtUpdateLabUnits As TextBox
    Friend WithEvents lblUpdateLectureUnits As Label
    Friend WithEvents txtUpdateLectureUnits As TextBox
    Friend WithEvents lblUpdateDepartment As Label
    Friend WithEvents cmbUpdateDepartment As ComboBox
    Friend WithEvents lblUpdateYearLevel As Label
    Friend WithEvents cmbUpdateYearLevel As ComboBox
    Friend WithEvents btnUpdateCourse As Button
    Friend WithEvents btnDeleteCourse As Button

    ' Manage Prerequisites Panel
    Friend WithEvents pnlManagePrerequisites As Panel
    Friend WithEvents lblPrerequisitesTitle As Label
    Friend WithEvents lblSelectCourseForPrereq As Label
    Friend WithEvents cmbSelectCourseForPrereq As ComboBox
    Friend WithEvents btnLoadPrerequisites As Button
    Friend WithEvents grpPrerequisiteInfo As GroupBox
    Friend WithEvents lblCurrentPrerequisites As Label
    Friend WithEvents dgvPrerequisites As DataGridView
    Friend WithEvents lblAddPrerequisite As Label
    Friend WithEvents cmbPrerequisiteCourse As ComboBox
    Friend WithEvents chkIsCorequisite As CheckBox
    Friend WithEvents btnAddPrerequisite As Button
    Friend WithEvents btnRemovePrerequisite As Button
End Class