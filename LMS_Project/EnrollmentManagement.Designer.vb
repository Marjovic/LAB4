<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnrollmentManagement
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        pnlSidebar = New Panel()
        btnCreateEnrollment = New Button()
        btnUpdateDeleteEnrollment = New Button()
        btnViewEnrollments = New Button()
        btnBulkEnrollment = New Button()
        lblEnrollmentTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlCreateEnrollment = New Panel()
        lblCreateEnrollmentTitle = New Label()
        lblStudent = New Label()
        cmbStudent = New ComboBox()
        lblCourseOffering = New Label()
        cmbCourseOffering = New ComboBox()
        btnSubmitEnrollment = New Button()
        lblEnrollmentInfo = New Label()
        pnlViewEnrollments = New Panel()
        dgvEnrollments = New DataGridView()
        lblViewEnrollmentsTitle = New Label()
        btnRefreshEnrollments = New Button()
        btnDeleteEnrollment = New Button()
        pnlUpdateDeleteEnrollment = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectEnrollment = New Label()
        cmbSelectEnrollment = New ComboBox()
        btnLoadEnrollmentData = New Button()
        grpEnrollmentInfo = New GroupBox()
        lblUpdateStudent = New Label()
        cmbUpdateStudent = New ComboBox()
        lblUpdateCourseOffering = New Label()
        cmbUpdateCourseOffering = New ComboBox()
        lblUpdateEnrollmentStatus = New Label()
        cmbUpdateEnrollmentStatus = New ComboBox()
        lblUpdateRemarks = New Label()
        txtUpdateRemarks = New TextBox()
        lblDropDate = New Label()
        dtpDropDate = New DateTimePicker()
        chkSetDropDate = New CheckBox()
        lblCompletionDate = New Label()
        dtpCompletionDate = New DateTimePicker()
        chkSetCompletionDate = New CheckBox()
        btnUpdateEnrollment = New Button()
        btnDeleteSelectedEnrollment = New Button()
        pnlBulkEnrollment = New Panel()
        lblBulkEnrollmentTitle = New Label()
        lblBulkSemester = New Label()
        cmbBulkSemester = New ComboBox()
        lblBulkProgram = New Label()
        cmbBulkProgram = New ComboBox()
        lblBulkYearLevel = New Label()
        cmbBulkYearLevel = New ComboBox()
        lblBulkDepartment = New Label()
        cmbBulkDepartment = New ComboBox()
        btnPreviewBulkEnrollment = New Button()
        dgvBulkEnrollmentPreview = New DataGridView()
        lblBulkInfo = New Label()
        btnExecuteBulkEnrollment = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlCreateEnrollment.SuspendLayout()
        pnlViewEnrollments.SuspendLayout()
        CType(dgvEnrollments, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteEnrollment.SuspendLayout()
        grpEnrollmentInfo.SuspendLayout()
        pnlBulkEnrollment.SuspendLayout()
        CType(dgvBulkEnrollmentPreview, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCreateEnrollment)
        pnlSidebar.Controls.Add(btnUpdateDeleteEnrollment)
        pnlSidebar.Controls.Add(btnViewEnrollments)
        pnlSidebar.Controls.Add(btnBulkEnrollment)
        pnlSidebar.Controls.Add(lblEnrollmentTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCreateEnrollment
        ' 
        btnCreateEnrollment.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateEnrollment.Dock = DockStyle.Top
        btnCreateEnrollment.FlatAppearance.BorderSize = 0
        btnCreateEnrollment.FlatStyle = FlatStyle.Flat
        btnCreateEnrollment.Font = New Font("Times New Roman", 11.0F)
        btnCreateEnrollment.ForeColor = Color.White
        btnCreateEnrollment.Location = New Point(0, 230)
        btnCreateEnrollment.Name = "btnCreateEnrollment"
        btnCreateEnrollment.Size = New Size(220, 50)
        btnCreateEnrollment.TabIndex = 1
        btnCreateEnrollment.Text = "+ Create Enrollment"
        btnCreateEnrollment.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteEnrollment
        ' 
        btnUpdateDeleteEnrollment.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteEnrollment.Dock = DockStyle.Top
        btnUpdateDeleteEnrollment.FlatAppearance.BorderSize = 0
        btnUpdateDeleteEnrollment.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteEnrollment.Font = New Font("Times New Roman", 11.0F)
        btnUpdateDeleteEnrollment.ForeColor = Color.White
        btnUpdateDeleteEnrollment.Location = New Point(0, 180)
        btnUpdateDeleteEnrollment.Name = "btnUpdateDeleteEnrollment"
        btnUpdateDeleteEnrollment.Size = New Size(220, 50)
        btnUpdateDeleteEnrollment.TabIndex = 2
        btnUpdateDeleteEnrollment.Text = "✏️ Update/Delete Enrollment"
        btnUpdateDeleteEnrollment.UseVisualStyleBackColor = False
        ' 
        ' btnViewEnrollments
        ' 
        btnViewEnrollments.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewEnrollments.Dock = DockStyle.Top
        btnViewEnrollments.FlatAppearance.BorderSize = 0
        btnViewEnrollments.FlatStyle = FlatStyle.Flat
        btnViewEnrollments.Font = New Font("Times New Roman", 11.0F)
        btnViewEnrollments.ForeColor = Color.White
        btnViewEnrollments.Location = New Point(0, 130)
        btnViewEnrollments.Name = "btnViewEnrollments"
        btnViewEnrollments.Size = New Size(220, 50)
        btnViewEnrollments.TabIndex = 3
        btnViewEnrollments.Text = "📋 View All Enrollments"
        btnViewEnrollments.UseVisualStyleBackColor = False
        ' 
        ' btnBulkEnrollment
        ' 
        btnBulkEnrollment.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnBulkEnrollment.Dock = DockStyle.Top
        btnBulkEnrollment.FlatAppearance.BorderSize = 0
        btnBulkEnrollment.FlatStyle = FlatStyle.Flat
        btnBulkEnrollment.Font = New Font("Times New Roman", 11.0F)
        btnBulkEnrollment.ForeColor = Color.White
        btnBulkEnrollment.Location = New Point(0, 80)
        btnBulkEnrollment.Name = "btnBulkEnrollment"
        btnBulkEnrollment.Size = New Size(220, 50)
        btnBulkEnrollment.TabIndex = 4
        btnBulkEnrollment.Text = "📚 Bulk Enrollment"
        btnBulkEnrollment.UseVisualStyleBackColor = False
        ' 
        ' lblEnrollmentTitle
        ' 
        lblEnrollmentTitle.BackColor = Color.Navy
        lblEnrollmentTitle.Dock = DockStyle.Top
        lblEnrollmentTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblEnrollmentTitle.ForeColor = Color.White
        lblEnrollmentTitle.Location = New Point(0, 0)
        lblEnrollmentTitle.Name = "lblEnrollmentTitle"
        lblEnrollmentTitle.Size = New Size(220, 80)
        lblEnrollmentTitle.TabIndex = 0
        lblEnrollmentTitle.Text = "Enrollment Management" & vbCrLf & "(Admin)"
        lblEnrollmentTitle.TextAlign = ContentAlignment.MiddleCenter
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
        btnClose.TabIndex = 5
        btnClose.Text = "🚪 Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlMainContent.Controls.Add(pnlCreateEnrollment)
        pnlMainContent.Controls.Add(pnlViewEnrollments)
        pnlMainContent.Controls.Add(pnlUpdateDeleteEnrollment)
        pnlMainContent.Controls.Add(pnlBulkEnrollment)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlCreateEnrollment
        ' 
        pnlCreateEnrollment.AutoScroll = True
        pnlCreateEnrollment.BackColor = Color.White
        pnlCreateEnrollment.Controls.Add(lblCreateEnrollmentTitle)
        pnlCreateEnrollment.Controls.Add(lblStudent)
        pnlCreateEnrollment.Controls.Add(cmbStudent)
        pnlCreateEnrollment.Controls.Add(lblCourseOffering)
        pnlCreateEnrollment.Controls.Add(cmbCourseOffering)
        pnlCreateEnrollment.Controls.Add(btnSubmitEnrollment)
        pnlCreateEnrollment.Controls.Add(lblEnrollmentInfo)
        pnlCreateEnrollment.Dock = DockStyle.Fill
        pnlCreateEnrollment.Location = New Point(0, 0)
        pnlCreateEnrollment.Name = "pnlCreateEnrollment"
        pnlCreateEnrollment.Padding = New Padding(30, 20, 30, 20)
        pnlCreateEnrollment.Size = New Size(980, 800)
        pnlCreateEnrollment.TabIndex = 0
        pnlCreateEnrollment.Visible = False
        ' 
        ' lblCreateEnrollmentTitle
        ' 
        lblCreateEnrollmentTitle.AutoSize = True
        lblCreateEnrollmentTitle.Font = New Font("Times New Roman", 20.0F, FontStyle.Bold)
        lblCreateEnrollmentTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateEnrollmentTitle.Location = New Point(30, 20)
        lblCreateEnrollmentTitle.Name = "lblCreateEnrollmentTitle"
        lblCreateEnrollmentTitle.Size = New Size(311, 31)
        lblCreateEnrollmentTitle.TabIndex = 0
        lblCreateEnrollmentTitle.Text = "Create New Enrollment"
        ' 
        ' lblStudent
        ' 
        lblStudent.AutoSize = True
        lblStudent.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblStudent.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblStudent.Location = New Point(50, 75)
        lblStudent.Name = "lblStudent"
        lblStudent.Size = New Size(73, 19)
        lblStudent.TabIndex = 1
        lblStudent.Text = "Student *"
        ' 
        ' cmbStudent
        ' 
        cmbStudent.DropDownStyle = ComboBoxStyle.DropDownList
        cmbStudent.Font = New Font("Times New Roman", 12.0F)
        cmbStudent.FormattingEnabled = True
        cmbStudent.Location = New Point(50, 97)
        cmbStudent.Name = "cmbStudent"
        cmbStudent.Size = New Size(850, 27)
        cmbStudent.TabIndex = 2
        ' 
        ' lblCourseOffering
        ' 
        lblCourseOffering.AutoSize = True
        lblCourseOffering.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblCourseOffering.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblCourseOffering.Location = New Point(50, 145)
        lblCourseOffering.Name = "lblCourseOffering"
        lblCourseOffering.Size = New Size(132, 19)
        lblCourseOffering.TabIndex = 3
        lblCourseOffering.Text = "Course Offering *"
        ' 
        ' cmbCourseOffering
        ' 
        cmbCourseOffering.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCourseOffering.Font = New Font("Times New Roman", 12.0F)
        cmbCourseOffering.FormattingEnabled = True
        cmbCourseOffering.Location = New Point(50, 167)
        cmbCourseOffering.Name = "cmbCourseOffering"
        cmbCourseOffering.Size = New Size(850, 27)
        cmbCourseOffering.TabIndex = 4
        ' 
        ' btnSubmitEnrollment
        ' 
        btnSubmitEnrollment.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnSubmitEnrollment.FlatStyle = FlatStyle.Flat
        btnSubmitEnrollment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnSubmitEnrollment.ForeColor = Color.White
        btnSubmitEnrollment.Location = New Point(50, 220)
        btnSubmitEnrollment.Name = "btnSubmitEnrollment"
        btnSubmitEnrollment.Size = New Size(220, 45)
        btnSubmitEnrollment.TabIndex = 5
        btnSubmitEnrollment.Text = "+ Enroll Student"
        btnSubmitEnrollment.UseVisualStyleBackColor = False
        ' 
        ' lblEnrollmentInfo
        ' 
        lblEnrollmentInfo.Font = New Font("Times New Roman", 11.0F)
        lblEnrollmentInfo.ForeColor = Color.Gray
        lblEnrollmentInfo.Location = New Point(50, 280)
        lblEnrollmentInfo.Name = "lblEnrollmentInfo"
        lblEnrollmentInfo.Size = New Size(850, 200)
        lblEnrollmentInfo.TabIndex = 6
        lblEnrollmentInfo.Text = "This enrollment uses the sp_EnrollStudent stored procedure which validates:" & vbCrLf &
        "• Student exists and is active" & vbCrLf &
          "• Course offering exists and is open" & vbCrLf &
            "• Semester/Term is active" & vbCrLf &
      "• Class is not full" & vbCrLf &
         "• No duplicate enrollment" & vbCrLf &
         "• Prerequisites are met" & vbCrLf &
  "• No schedule conflicts"
        ' 
        ' pnlViewEnrollments
        ' 
        pnlViewEnrollments.BackColor = Color.White
        pnlViewEnrollments.Controls.Add(dgvEnrollments)
        pnlViewEnrollments.Controls.Add(lblViewEnrollmentsTitle)
        pnlViewEnrollments.Controls.Add(btnRefreshEnrollments)
        pnlViewEnrollments.Controls.Add(btnDeleteEnrollment)
        pnlViewEnrollments.Dock = DockStyle.Fill
        pnlViewEnrollments.Location = New Point(0, 0)
        pnlViewEnrollments.Name = "pnlViewEnrollments"
        pnlViewEnrollments.Padding = New Padding(20)
        pnlViewEnrollments.Size = New Size(980, 800)
        pnlViewEnrollments.TabIndex = 1
        pnlViewEnrollments.Visible = False
        ' 
        ' dgvEnrollments
        ' 
        dgvEnrollments.AllowUserToAddRows = False
        dgvEnrollments.AllowUserToDeleteRows = False
        dgvEnrollments.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvEnrollments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvEnrollments.BackgroundColor = SystemColors.Control
        dgvEnrollments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvEnrollments.Location = New Point(23, 70)
        dgvEnrollments.Name = "dgvEnrollments"
        dgvEnrollments.ReadOnly = True
        dgvEnrollments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvEnrollments.Size = New Size(934, 670)
        dgvEnrollments.TabIndex = 1
        ' 
        ' lblViewEnrollmentsTitle
        ' 
        lblViewEnrollmentsTitle.AutoSize = True
        lblViewEnrollmentsTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblViewEnrollmentsTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewEnrollmentsTitle.Location = New Point(23, 20)
        lblViewEnrollmentsTitle.Name = "lblViewEnrollmentsTitle"
        lblViewEnrollmentsTitle.Size = New Size(236, 36)
        lblViewEnrollmentsTitle.TabIndex = 0
        lblViewEnrollmentsTitle.Text = "All Enrollments"
        ' 
        ' btnRefreshEnrollments
        ' 
        btnRefreshEnrollments.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshEnrollments.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshEnrollments.FlatStyle = FlatStyle.Flat
        btnRefreshEnrollments.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnRefreshEnrollments.ForeColor = Color.White
        btnRefreshEnrollments.Location = New Point(627, 20)
        btnRefreshEnrollments.Name = "btnRefreshEnrollments"
        btnRefreshEnrollments.Size = New Size(160, 40)
        btnRefreshEnrollments.TabIndex = 2
        btnRefreshEnrollments.Text = "🔄 Refresh"
        btnRefreshEnrollments.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteEnrollment
        ' 
        pnlUpdateDeleteEnrollment.AutoScroll = True
        pnlUpdateDeleteEnrollment.BackColor = Color.White
        pnlUpdateDeleteEnrollment.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteEnrollment.Controls.Add(lblSelectEnrollment)
        pnlUpdateDeleteEnrollment.Controls.Add(cmbSelectEnrollment)
        pnlUpdateDeleteEnrollment.Controls.Add(btnLoadEnrollmentData)
        pnlUpdateDeleteEnrollment.Controls.Add(grpEnrollmentInfo)
        pnlUpdateDeleteEnrollment.Dock = DockStyle.Fill
        pnlUpdateDeleteEnrollment.Location = New Point(0, 0)
        pnlUpdateDeleteEnrollment.Name = "pnlUpdateDeleteEnrollment"
        pnlUpdateDeleteEnrollment.Padding = New Padding(20)
        pnlUpdateDeleteEnrollment.Size = New Size(980, 800)
        pnlUpdateDeleteEnrollment.TabIndex = 2
        pnlUpdateDeleteEnrollment.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(386, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete Enrollment"
        ' 
        ' lblSelectEnrollment
        ' 
        lblSelectEnrollment.AutoSize = True
        lblSelectEnrollment.Font = New Font("Times New Roman", 14.0F)
        lblSelectEnrollment.Location = New Point(40, 80)
        lblSelectEnrollment.Name = "lblSelectEnrollment"
        lblSelectEnrollment.Size = New Size(144, 21)
        lblSelectEnrollment.TabIndex = 1
        lblSelectEnrollment.Text = "Select Enrollment"
        ' 
        ' cmbSelectEnrollment
        ' 
        cmbSelectEnrollment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectEnrollment.Font = New Font("Times New Roman", 12.0F)
        cmbSelectEnrollment.FormattingEnabled = True
        cmbSelectEnrollment.Location = New Point(40, 105)
        cmbSelectEnrollment.Name = "cmbSelectEnrollment"
        cmbSelectEnrollment.Size = New Size(700, 27)
        cmbSelectEnrollment.TabIndex = 2
        ' 
        ' btnLoadEnrollmentData
        ' 
        btnLoadEnrollmentData.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadEnrollmentData.FlatStyle = FlatStyle.Flat
        btnLoadEnrollmentData.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnLoadEnrollmentData.ForeColor = Color.White
        btnLoadEnrollmentData.Location = New Point(760, 105)
        btnLoadEnrollmentData.Name = "btnLoadEnrollmentData"
        btnLoadEnrollmentData.Size = New Size(140, 29)
        btnLoadEnrollmentData.TabIndex = 3
        btnLoadEnrollmentData.Text = "Load Data"
        btnLoadEnrollmentData.UseVisualStyleBackColor = False
        ' 
        ' grpEnrollmentInfo
        ' 
        grpEnrollmentInfo.Controls.Add(lblUpdateStudent)
        grpEnrollmentInfo.Controls.Add(cmbUpdateStudent)
        grpEnrollmentInfo.Controls.Add(lblUpdateCourseOffering)
        grpEnrollmentInfo.Controls.Add(cmbUpdateCourseOffering)
        grpEnrollmentInfo.Controls.Add(lblUpdateEnrollmentStatus)
        grpEnrollmentInfo.Controls.Add(cmbUpdateEnrollmentStatus)
        grpEnrollmentInfo.Controls.Add(lblUpdateRemarks)
        grpEnrollmentInfo.Controls.Add(txtUpdateRemarks)
        grpEnrollmentInfo.Controls.Add(lblDropDate)
        grpEnrollmentInfo.Controls.Add(dtpDropDate)
        grpEnrollmentInfo.Controls.Add(chkSetDropDate)
        grpEnrollmentInfo.Controls.Add(lblCompletionDate)
        grpEnrollmentInfo.Controls.Add(dtpCompletionDate)
        grpEnrollmentInfo.Controls.Add(chkSetCompletionDate)
        grpEnrollmentInfo.Controls.Add(btnUpdateEnrollment)
        grpEnrollmentInfo.Controls.Add(btnDeleteSelectedEnrollment)
        grpEnrollmentInfo.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        grpEnrollmentInfo.Location = New Point(40, 150)
        grpEnrollmentInfo.Name = "grpEnrollmentInfo"
        grpEnrollmentInfo.Size = New Size(900, 520)
        grpEnrollmentInfo.TabIndex = 4
        grpEnrollmentInfo.TabStop = False
        grpEnrollmentInfo.Text = "Enrollment Information"
        grpEnrollmentInfo.Visible = False
        ' 
        ' lblUpdateStudent
        ' 
        lblUpdateStudent.AutoSize = True
        lblUpdateStudent.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateStudent.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateStudent.Location = New Point(30, 40)
        lblUpdateStudent.Name = "lblUpdateStudent"
        lblUpdateStudent.Size = New Size(73, 19)
        lblUpdateStudent.TabIndex = 0
        lblUpdateStudent.Text = "Student *"
        ' 
        ' cmbUpdateStudent
        ' 
        cmbUpdateStudent.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateStudent.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateStudent.FormattingEnabled = True
        cmbUpdateStudent.Location = New Point(30, 62)
        cmbUpdateStudent.Name = "cmbUpdateStudent"
        cmbUpdateStudent.Size = New Size(840, 27)
        cmbUpdateStudent.TabIndex = 1
        ' 
        ' lblUpdateCourseOffering
        ' 
        lblUpdateCourseOffering.AutoSize = True
        lblUpdateCourseOffering.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateCourseOffering.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateCourseOffering.Location = New Point(30, 100)
        lblUpdateCourseOffering.Name = "lblUpdateCourseOffering"
        lblUpdateCourseOffering.Size = New Size(132, 19)
        lblUpdateCourseOffering.TabIndex = 2
        lblUpdateCourseOffering.Text = "Course Offering *"
        ' 
        ' cmbUpdateCourseOffering
        ' 
        cmbUpdateCourseOffering.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateCourseOffering.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateCourseOffering.FormattingEnabled = True
        cmbUpdateCourseOffering.Location = New Point(30, 122)
        cmbUpdateCourseOffering.Name = "cmbUpdateCourseOffering"
        cmbUpdateCourseOffering.Size = New Size(840, 27)
        cmbUpdateCourseOffering.TabIndex = 3
        ' 
        ' lblUpdateEnrollmentStatus
        ' 
        lblUpdateEnrollmentStatus.AutoSize = True
        lblUpdateEnrollmentStatus.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateEnrollmentStatus.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateEnrollmentStatus.Location = New Point(30, 160)
        lblUpdateEnrollmentStatus.Name = "lblUpdateEnrollmentStatus"
        lblUpdateEnrollmentStatus.Size = New Size(63, 19)
        lblUpdateEnrollmentStatus.TabIndex = 4
        lblUpdateEnrollmentStatus.Text = "Status *"
        ' 
        ' cmbUpdateEnrollmentStatus
        ' 
        cmbUpdateEnrollmentStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateEnrollmentStatus.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateEnrollmentStatus.FormattingEnabled = True
        cmbUpdateEnrollmentStatus.Location = New Point(30, 182)
        cmbUpdateEnrollmentStatus.Name = "cmbUpdateEnrollmentStatus"
        cmbUpdateEnrollmentStatus.Size = New Size(400, 27)
        cmbUpdateEnrollmentStatus.TabIndex = 5
        ' 
        ' lblUpdateRemarks
        ' 
        lblUpdateRemarks.AutoSize = True
        lblUpdateRemarks.Font = New Font("Times New Roman", 12.0F)
        lblUpdateRemarks.Location = New Point(30, 220)
        lblUpdateRemarks.Name = "lblUpdateRemarks"
        lblUpdateRemarks.Size = New Size(126, 19)
        lblUpdateRemarks.TabIndex = 6
        lblUpdateRemarks.Text = "Remarks (Optional)"
        ' 
        ' txtUpdateRemarks
        ' 
        txtUpdateRemarks.Font = New Font("Times New Roman", 12.0F)
        txtUpdateRemarks.Location = New Point(30, 242)
        txtUpdateRemarks.Multiline = True
        txtUpdateRemarks.Name = "txtUpdateRemarks"
        txtUpdateRemarks.ScrollBars = ScrollBars.Vertical
        txtUpdateRemarks.Size = New Size(840, 60)
        txtUpdateRemarks.TabIndex = 7
        ' 
        ' lblDropDate
        ' 
        lblDropDate.AutoSize = True
        lblDropDate.Font = New Font("Times New Roman", 12.0F)
        lblDropDate.Location = New Point(30, 320)
        lblDropDate.Name = "lblDropDate"
        lblDropDate.Size = New Size(72, 19)
        lblDropDate.TabIndex = 8
        lblDropDate.Text = "Drop Date"
        ' 
        ' dtpDropDate
        ' 
        dtpDropDate.Enabled = False
        dtpDropDate.Font = New Font("Times New Roman", 12.0F)
        dtpDropDate.Format = DateTimePickerFormat.Short
        dtpDropDate.Location = New Point(150, 317)
        dtpDropDate.Name = "dtpDropDate"
        dtpDropDate.Size = New Size(280, 26)
        dtpDropDate.TabIndex = 9
        ' 
        ' chkSetDropDate
        ' 
        chkSetDropDate.AutoSize = True
        chkSetDropDate.Font = New Font("Times New Roman", 11.0F)
        chkSetDropDate.Location = New Point(450, 320)
        chkSetDropDate.Name = "chkSetDropDate"
        chkSetDropDate.Size = New Size(115, 21)
        chkSetDropDate.TabIndex = 10
        chkSetDropDate.Text = "Set Drop Date"
        chkSetDropDate.UseVisualStyleBackColor = True
        ' 
        ' lblCompletionDate
        ' 
        lblCompletionDate.AutoSize = True
        lblCompletionDate.Font = New Font("Times New Roman", 12.0F)
        lblCompletionDate.Location = New Point(30, 360)
        lblCompletionDate.Name = "lblCompletionDate"
        lblCompletionDate.Size = New Size(116, 19)
        lblCompletionDate.TabIndex = 11
        lblCompletionDate.Text = "Completion Date"
        ' 
        ' dtpCompletionDate
        ' 
        dtpCompletionDate.Enabled = False
        dtpCompletionDate.Font = New Font("Times New Roman", 12.0F)
        dtpCompletionDate.Format = DateTimePickerFormat.Short
        dtpCompletionDate.Location = New Point(150, 357)
        dtpCompletionDate.Name = "dtpCompletionDate"
        dtpCompletionDate.Size = New Size(280, 26)
        dtpCompletionDate.TabIndex = 12
        ' 
        ' chkSetCompletionDate
        ' 
        chkSetCompletionDate.AutoSize = True
        chkSetCompletionDate.Font = New Font("Times New Roman", 11.0F)
        chkSetCompletionDate.Location = New Point(450, 360)
        chkSetCompletionDate.Name = "chkSetCompletionDate"
        chkSetCompletionDate.Size = New Size(159, 21)
        chkSetCompletionDate.TabIndex = 13
        chkSetCompletionDate.Text = "Set Completion Date"
        chkSetCompletionDate.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateEnrollment
        ' 
        btnUpdateEnrollment.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnUpdateEnrollment.FlatStyle = FlatStyle.Flat
        btnUpdateEnrollment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnUpdateEnrollment.ForeColor = Color.White
        btnUpdateEnrollment.Location = New Point(30, 420)
        btnUpdateEnrollment.Name = "btnUpdateEnrollment"
        btnUpdateEnrollment.Size = New Size(220, 45)
        btnUpdateEnrollment.TabIndex = 14
        btnUpdateEnrollment.Text = "💾 Update Enrollment"
        btnUpdateEnrollment.UseVisualStyleBackColor = False
        ' 
        ' btnDeleteSelectedEnrollment
        ' 
        btnDeleteSelectedEnrollment.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnDeleteSelectedEnrollment.FlatStyle = FlatStyle.Flat
        btnDeleteSelectedEnrollment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnDeleteSelectedEnrollment.ForeColor = Color.White
        btnDeleteSelectedEnrollment.Location = New Point(270, 420)
        btnDeleteSelectedEnrollment.Name = "btnDeleteSelectedEnrollment"
        btnDeleteSelectedEnrollment.Size = New Size(220, 45)
        btnDeleteSelectedEnrollment.TabIndex = 15
        btnDeleteSelectedEnrollment.Text = "🗑️ Delete Enrollment"
        btnDeleteSelectedEnrollment.UseVisualStyleBackColor = False
        ' 
        ' pnlBulkEnrollment
        ' 
        pnlBulkEnrollment.AutoScroll = True
        pnlBulkEnrollment.BackColor = Color.White
        pnlBulkEnrollment.Controls.Add(lblBulkEnrollmentTitle)
        pnlBulkEnrollment.Controls.Add(lblBulkSemester)
        pnlBulkEnrollment.Controls.Add(cmbBulkSemester)
        pnlBulkEnrollment.Controls.Add(lblBulkProgram)
        pnlBulkEnrollment.Controls.Add(cmbBulkProgram)
        pnlBulkEnrollment.Controls.Add(lblBulkYearLevel)
        pnlBulkEnrollment.Controls.Add(cmbBulkYearLevel)
        pnlBulkEnrollment.Controls.Add(lblBulkDepartment)
        pnlBulkEnrollment.Controls.Add(cmbBulkDepartment)
        pnlBulkEnrollment.Controls.Add(btnPreviewBulkEnrollment)
        pnlBulkEnrollment.Controls.Add(dgvBulkEnrollmentPreview)
        pnlBulkEnrollment.Controls.Add(lblBulkInfo)
        pnlBulkEnrollment.Controls.Add(btnExecuteBulkEnrollment)
        pnlBulkEnrollment.Dock = DockStyle.Fill
        pnlBulkEnrollment.Location = New Point(0, 0)
        pnlBulkEnrollment.Name = "pnlBulkEnrollment"
        pnlBulkEnrollment.Padding = New Padding(30, 20, 30, 20)
        pnlBulkEnrollment.Size = New Size(980, 800)
        pnlBulkEnrollment.TabIndex = 3
        pnlBulkEnrollment.Visible = False
        ' 
        ' lblBulkEnrollmentTitle
        ' 
        lblBulkEnrollmentTitle.AutoSize = True
        lblBulkEnrollmentTitle.Font = New Font("Times New Roman", 20.0F, FontStyle.Bold)
        lblBulkEnrollmentTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblBulkEnrollmentTitle.Location = New Point(30, 20)
        lblBulkEnrollmentTitle.Name = "lblBulkEnrollmentTitle"
        lblBulkEnrollmentTitle.Size = New Size(306, 31)
        lblBulkEnrollmentTitle.TabIndex = 0
        lblBulkEnrollmentTitle.Text = "Bulk Enrollment (Admin)"
        ' 
        ' lblBulkSemester
        ' 
        lblBulkSemester.AutoSize = True
        lblBulkSemester.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblBulkSemester.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblBulkSemester.Location = New Point(50, 75)
        lblBulkSemester.Name = "lblBulkSemester"
        lblBulkSemester.Size = New Size(81, 19)
        lblBulkSemester.TabIndex = 1
        lblBulkSemester.Text = "Semester *"
        ' 
        ' cmbBulkSemester
        ' 
        cmbBulkSemester.DropDownStyle = ComboBoxStyle.DropDownList
        cmbBulkSemester.Font = New Font("Times New Roman", 12.0F)
        cmbBulkSemester.FormattingEnabled = True
        cmbBulkSemester.Location = New Point(50, 97)
        cmbBulkSemester.Name = "cmbBulkSemester"
        cmbBulkSemester.Size = New Size(300, 27)
        cmbBulkSemester.TabIndex = 2
        ' 
        ' lblBulkProgram
        ' 
        lblBulkProgram.AutoSize = True
        lblBulkProgram.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblBulkProgram.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblBulkProgram.Location = New Point(400, 75)
        lblBulkProgram.Name = "lblBulkProgram"
        lblBulkProgram.Size = New Size(78, 19)
        lblBulkProgram.TabIndex = 3
        lblBulkProgram.Text = "Program *"
        ' 
        ' cmbBulkProgram
        ' 
        cmbBulkProgram.DropDownStyle = ComboBoxStyle.DropDownList
        cmbBulkProgram.Font = New Font("Times New Roman", 12.0F)
        cmbBulkProgram.FormattingEnabled = True
        cmbBulkProgram.Location = New Point(400, 97)
        cmbBulkProgram.Name = "cmbBulkProgram"
        cmbBulkProgram.Size = New Size(300, 27)
        cmbBulkProgram.TabIndex = 4
        ' 
        ' lblBulkYearLevel
        ' 
        lblBulkYearLevel.AutoSize = True
        lblBulkYearLevel.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblBulkYearLevel.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblBulkYearLevel.Location = New Point(50, 145)
        lblBulkYearLevel.Name = "lblBulkYearLevel"
        lblBulkYearLevel.Size = New Size(95, 19)
        lblBulkYearLevel.TabIndex = 5
        lblBulkYearLevel.Text = "Year Level *"
        ' 
        ' cmbBulkYearLevel
        ' 
        cmbBulkYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cmbBulkYearLevel.Font = New Font("Times New Roman", 12.0F)
        cmbBulkYearLevel.FormattingEnabled = True
        cmbBulkYearLevel.Location = New Point(50, 167)
        cmbBulkYearLevel.Name = "cmbBulkYearLevel"
        cmbBulkYearLevel.Size = New Size(300, 27)
        cmbBulkYearLevel.TabIndex = 6
        ' 
        ' lblBulkDepartment
        ' 
        lblBulkDepartment.AutoSize = True
        lblBulkDepartment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblBulkDepartment.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblBulkDepartment.Location = New Point(400, 145)
        lblBulkDepartment.Name = "lblBulkDepartment"
        lblBulkDepartment.Size = New Size(101, 19)
        lblBulkDepartment.TabIndex = 7
        lblBulkDepartment.Text = "Department *"
        ' 
        ' cmbBulkDepartment
        ' 
        cmbBulkDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbBulkDepartment.Font = New Font("Times New Roman", 12.0F)
        cmbBulkDepartment.FormattingEnabled = True
        cmbBulkDepartment.Location = New Point(400, 167)
        cmbBulkDepartment.Name = "cmbBulkDepartment"
        cmbBulkDepartment.Size = New Size(300, 27)
        cmbBulkDepartment.TabIndex = 8
        ' 
        ' btnPreviewBulkEnrollment
        ' 
        btnPreviewBulkEnrollment.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnPreviewBulkEnrollment.FlatStyle = FlatStyle.Flat
        btnPreviewBulkEnrollment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnPreviewBulkEnrollment.ForeColor = Color.White
        btnPreviewBulkEnrollment.Location = New Point(750, 167)
        btnPreviewBulkEnrollment.Name = "btnPreviewBulkEnrollment"
        btnPreviewBulkEnrollment.Size = New Size(150, 27)
        btnPreviewBulkEnrollment.TabIndex = 9
        btnPreviewBulkEnrollment.Text = "Preview Data"
        btnPreviewBulkEnrollment.UseVisualStyleBackColor = False
        ' 
        ' dgvBulkEnrollmentPreview
        ' 
        dgvBulkEnrollmentPreview.AllowUserToAddRows = False
        dgvBulkEnrollmentPreview.AllowUserToDeleteRows = False
        dgvBulkEnrollmentPreview.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvBulkEnrollmentPreview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvBulkEnrollmentPreview.BackgroundColor = SystemColors.Control
        dgvBulkEnrollmentPreview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvBulkEnrollmentPreview.Location = New Point(30, 220)
        dgvBulkEnrollmentPreview.Name = "dgvBulkEnrollmentPreview"
        dgvBulkEnrollmentPreview.ReadOnly = True
        dgvBulkEnrollmentPreview.Size = New Size(920, 450)
        dgvBulkEnrollmentPreview.TabIndex = 10
        ' 
        ' lblBulkInfo
        ' 
        lblBulkInfo.AutoSize = True
        lblBulkInfo.Font = New Font("Times New Roman", 12.0F)
        lblBulkInfo.Location = New Point(30, 700)
        lblBulkInfo.Name = "lblBulkInfo"
        lblBulkInfo.Size = New Size(400, 19)
        lblBulkInfo.TabIndex = 11
        lblBulkInfo.Text = "Admin can view and enroll all students (no instructor filter)."
        ' 
        ' btnExecuteBulkEnrollment
        ' 
        btnExecuteBulkEnrollment.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnExecuteBulkEnrollment.FlatStyle = FlatStyle.Flat
        btnExecuteBulkEnrollment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnExecuteBulkEnrollment.ForeColor = Color.White
        btnExecuteBulkEnrollment.Location = New Point(750, 730)
        btnExecuteBulkEnrollment.Name = "btnExecuteBulkEnrollment"
        btnExecuteBulkEnrollment.Size = New Size(200, 40)
        btnExecuteBulkEnrollment.TabIndex = 12
        btnExecuteBulkEnrollment.Text = "✔ Enroll Students"
        btnExecuteBulkEnrollment.UseVisualStyleBackColor = False
        ' 
        ' EnrollmentManagement
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "EnrollmentManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Enrollment Management (Admin) - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlCreateEnrollment.ResumeLayout(False)
        pnlCreateEnrollment.PerformLayout()
        pnlViewEnrollments.ResumeLayout(False)
        pnlViewEnrollments.PerformLayout()
        CType(dgvEnrollments, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteEnrollment.ResumeLayout(False)
        pnlUpdateDeleteEnrollment.PerformLayout()
        grpEnrollmentInfo.ResumeLayout(False)
        grpEnrollmentInfo.PerformLayout()
        pnlBulkEnrollment.ResumeLayout(False)
        pnlBulkEnrollment.PerformLayout()
        CType(dgvBulkEnrollmentPreview, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblEnrollmentTitle As Label
    Friend WithEvents btnCreateEnrollment As Button
    Friend WithEvents btnUpdateDeleteEnrollment As Button
    Friend WithEvents btnViewEnrollments As Button
    Friend WithEvents btnBulkEnrollment As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Create Enrollment Panel
    Friend WithEvents pnlCreateEnrollment As Panel
    Friend WithEvents lblCreateEnrollmentTitle As Label
    Friend WithEvents lblStudent As Label
    Friend WithEvents cmbStudent As ComboBox
    Friend WithEvents lblCourseOffering As Label
    Friend WithEvents cmbCourseOffering As ComboBox
    Friend WithEvents btnSubmitEnrollment As Button
    Friend WithEvents lblEnrollmentInfo As Label

    ' View Enrollments Panel
    Friend WithEvents pnlViewEnrollments As Panel
    Friend WithEvents lblViewEnrollmentsTitle As Label
    Friend WithEvents dgvEnrollments As DataGridView
    Friend WithEvents btnRefreshEnrollments As Button
    Friend WithEvents btnDeleteEnrollment As Button

    ' Update/Delete Enrollment Panel
    Friend WithEvents pnlUpdateDeleteEnrollment As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectEnrollment As Label
    Friend WithEvents cmbSelectEnrollment As ComboBox
    Friend WithEvents btnLoadEnrollmentData As Button
    Friend WithEvents grpEnrollmentInfo As GroupBox
    Friend WithEvents lblUpdateStudent As Label
    Friend WithEvents cmbUpdateStudent As ComboBox
    Friend WithEvents lblUpdateCourseOffering As Label
    Friend WithEvents cmbUpdateCourseOffering As ComboBox
    Friend WithEvents lblUpdateEnrollmentStatus As Label
    Friend WithEvents cmbUpdateEnrollmentStatus As ComboBox
    Friend WithEvents lblUpdateRemarks As Label
    Friend WithEvents txtUpdateRemarks As TextBox
    Friend WithEvents lblDropDate As Label
    Friend WithEvents dtpDropDate As DateTimePicker
    Friend WithEvents chkSetDropDate As CheckBox
    Friend WithEvents lblCompletionDate As Label
    Friend WithEvents dtpCompletionDate As DateTimePicker
    Friend WithEvents chkSetCompletionDate As CheckBox
    Friend WithEvents btnUpdateEnrollment As Button
    Friend WithEvents btnDeleteSelectedEnrollment As Button

    ' Bulk Enrollment Panel
    Friend WithEvents pnlBulkEnrollment As Panel
    Friend WithEvents lblBulkEnrollmentTitle As Label
    Friend WithEvents lblBulkSemester As Label
    Friend WithEvents cmbBulkSemester As ComboBox
    Friend WithEvents lblBulkProgram As Label
    Friend WithEvents cmbBulkProgram As ComboBox
    Friend WithEvents lblBulkYearLevel As Label
    Friend WithEvents cmbBulkYearLevel As ComboBox
    Friend WithEvents lblBulkDepartment As Label
    Friend WithEvents cmbBulkDepartment As ComboBox
    Friend WithEvents btnPreviewBulkEnrollment As Button
    Friend WithEvents dgvBulkEnrollmentPreview As DataGridView
    Friend WithEvents lblBulkInfo As Label
    Friend WithEvents btnExecuteBulkEnrollment As Button
End Class
