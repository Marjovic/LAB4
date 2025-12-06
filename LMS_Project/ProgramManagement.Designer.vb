<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ProgramManagement
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
        btnCreateProgram = New Button()
        btnUpdateDeleteProgram = New Button()
        btnViewPrograms = New Button()
        lblProgramTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlCreateProgram = New Panel()
        lblCreateProgramTitle = New Label()
        lblProgramCode = New Label()
        txtProgramCode = New TextBox()
        lblProgramName = New Label()
        txtProgramName = New TextBox()
        lblProgramDescription = New Label()
        txtProgramDescription = New TextBox()
        lblDepartment = New Label()
        cmbDepartment = New ComboBox()
        lblTotalUnits = New Label()
        txtTotalUnits = New TextBox()
        lblYearsToComplete = New Label()
        txtYearsToComplete = New TextBox()
        lblAccreditationStatus = New Label()
        cmbAccreditationStatus = New ComboBox()
        lblIsActive = New Label()
        chkIsActive = New CheckBox()
        btnSubmitProgram = New Button()
        pnlViewPrograms = New Panel()
        dgvPrograms = New DataGridView()
        lblViewProgramsTitle = New Label()
        btnRefreshPrograms = New Button()
        pnlUpdateDeleteProgram = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectProgram = New Label()
        cmbSelectProgram = New ComboBox()
        btnLoadProgramData = New Button()
        grpProgramInfo = New GroupBox()
        lblUpdateProgramCode = New Label()
        txtUpdateProgramCode = New TextBox()
        lblUpdateProgramName = New Label()
        txtUpdateProgramName = New TextBox()
        lblUpdateProgramDescription = New Label()
        txtUpdateProgramDescription = New TextBox()
        lblUpdateDepartment = New Label()
        cmbUpdateDepartment = New ComboBox()
        lblUpdateTotalUnits = New Label()
        txtUpdateTotalUnits = New TextBox()
        lblUpdateYearsToComplete = New Label()
        txtUpdateYearsToComplete = New TextBox()
        lblUpdateAccreditationStatus = New Label()
        cmbUpdateAccreditationStatus = New ComboBox()
        lblUpdateIsActive = New Label()
        chkUpdateIsActive = New CheckBox()
        btnUpdateProgram = New Button()
        btnDeleteProgram = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlCreateProgram.SuspendLayout()
        pnlViewPrograms.SuspendLayout()
        CType(dgvPrograms, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteProgram.SuspendLayout()
        grpProgramInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCreateProgram)
        pnlSidebar.Controls.Add(btnUpdateDeleteProgram)
        pnlSidebar.Controls.Add(btnViewPrograms)
        pnlSidebar.Controls.Add(lblProgramTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCreateProgram
        ' 
        btnCreateProgram.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateProgram.Dock = DockStyle.Top
        btnCreateProgram.FlatAppearance.BorderSize = 0
        btnCreateProgram.FlatStyle = FlatStyle.Flat
        btnCreateProgram.Font = New Font("Times New Roman", 11.0F)
        btnCreateProgram.ForeColor = Color.White
        btnCreateProgram.Location = New Point(0, 180)
        btnCreateProgram.Name = "btnCreateProgram"
        btnCreateProgram.Size = New Size(220, 50)
        btnCreateProgram.TabIndex = 1
        btnCreateProgram.Text = "+ Create Program"
        btnCreateProgram.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteProgram
        ' 
        btnUpdateDeleteProgram.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteProgram.Dock = DockStyle.Top
        btnUpdateDeleteProgram.FlatAppearance.BorderSize = 0
        btnUpdateDeleteProgram.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteProgram.Font = New Font("Times New Roman", 11.0F)
        btnUpdateDeleteProgram.ForeColor = Color.White
        btnUpdateDeleteProgram.Location = New Point(0, 130)
        btnUpdateDeleteProgram.Name = "btnUpdateDeleteProgram"
        btnUpdateDeleteProgram.Size = New Size(220, 50)
        btnUpdateDeleteProgram.TabIndex = 2
        btnUpdateDeleteProgram.Text = "Update/Delete Program"
        btnUpdateDeleteProgram.UseVisualStyleBackColor = False
        ' 
        ' btnViewPrograms
        ' 
        btnViewPrograms.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewPrograms.Dock = DockStyle.Top
        btnViewPrograms.FlatAppearance.BorderSize = 0
        btnViewPrograms.FlatStyle = FlatStyle.Flat
        btnViewPrograms.Font = New Font("Times New Roman", 11.0F)
        btnViewPrograms.ForeColor = Color.White
        btnViewPrograms.Location = New Point(0, 80)
        btnViewPrograms.Name = "btnViewPrograms"
        btnViewPrograms.Size = New Size(220, 50)
        btnViewPrograms.TabIndex = 3
        btnViewPrograms.Text = "View Programs"
        btnViewPrograms.UseVisualStyleBackColor = False
        ' 
        ' lblProgramTitle
        ' 
        lblProgramTitle.BackColor = Color.Navy
        lblProgramTitle.Dock = DockStyle.Top
        lblProgramTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblProgramTitle.ForeColor = Color.White
        lblProgramTitle.Location = New Point(0, 0)
        lblProgramTitle.Name = "lblProgramTitle"
        lblProgramTitle.Size = New Size(220, 80)
        lblProgramTitle.TabIndex = 0
        lblProgramTitle.Text = "Program Management"
        lblProgramTitle.TextAlign = ContentAlignment.MiddleCenter
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
        btnClose.TabIndex = 4
        btnClose.Text = "🚪 Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlMainContent.Controls.Add(pnlCreateProgram)
        pnlMainContent.Controls.Add(pnlViewPrograms)
        pnlMainContent.Controls.Add(pnlUpdateDeleteProgram)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlCreateProgram
        ' 
        pnlCreateProgram.AutoScroll = True
        pnlCreateProgram.BackColor = Color.White
        pnlCreateProgram.Controls.Add(lblCreateProgramTitle)
        pnlCreateProgram.Controls.Add(lblProgramCode)
        pnlCreateProgram.Controls.Add(txtProgramCode)
        pnlCreateProgram.Controls.Add(lblProgramName)
        pnlCreateProgram.Controls.Add(txtProgramName)
        pnlCreateProgram.Controls.Add(lblProgramDescription)
        pnlCreateProgram.Controls.Add(txtProgramDescription)
        pnlCreateProgram.Controls.Add(lblDepartment)
        pnlCreateProgram.Controls.Add(cmbDepartment)
        pnlCreateProgram.Controls.Add(lblTotalUnits)
        pnlCreateProgram.Controls.Add(txtTotalUnits)
        pnlCreateProgram.Controls.Add(lblYearsToComplete)
        pnlCreateProgram.Controls.Add(txtYearsToComplete)
        pnlCreateProgram.Controls.Add(lblAccreditationStatus)
        pnlCreateProgram.Controls.Add(cmbAccreditationStatus)
        pnlCreateProgram.Controls.Add(lblIsActive)
        pnlCreateProgram.Controls.Add(chkIsActive)
        pnlCreateProgram.Controls.Add(btnSubmitProgram)
        pnlCreateProgram.Dock = DockStyle.Fill
        pnlCreateProgram.Location = New Point(0, 0)
        pnlCreateProgram.Name = "pnlCreateProgram"
        pnlCreateProgram.Padding = New Padding(30, 20, 30, 20)
        pnlCreateProgram.Size = New Size(980, 800)
        pnlCreateProgram.TabIndex = 0
        pnlCreateProgram.Visible = False
        ' 
        ' lblCreateProgramTitle
        ' 
        lblCreateProgramTitle.AutoSize = True
        lblCreateProgramTitle.Font = New Font("Times New Roman", 20.0F, FontStyle.Bold)
        lblCreateProgramTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateProgramTitle.Location = New Point(30, 20)
        lblCreateProgramTitle.Name = "lblCreateProgramTitle"
        lblCreateProgramTitle.Size = New Size(259, 31)
        lblCreateProgramTitle.TabIndex = 0
        lblCreateProgramTitle.Text = "Create New Program"
        ' 
        ' lblProgramCode
        ' 
        lblProgramCode.AutoSize = True
        lblProgramCode.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblProgramCode.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblProgramCode.Location = New Point(50, 75)
        lblProgramCode.Name = "lblProgramCode"
        lblProgramCode.Size = New Size(122, 19)
        lblProgramCode.TabIndex = 1
        lblProgramCode.Text = "Program Code *"
        ' 
        ' txtProgramCode
        ' 
        txtProgramCode.Font = New Font("Times New Roman", 12.0F)
        txtProgramCode.Location = New Point(50, 97)
        txtProgramCode.MaxLength = 20
        txtProgramCode.Name = "txtProgramCode"
        txtProgramCode.Size = New Size(400, 26)
        txtProgramCode.TabIndex = 2
        ' 
        ' lblProgramName
        ' 
        lblProgramName.AutoSize = True
        lblProgramName.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblProgramName.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblProgramName.Location = New Point(500, 75)
        lblProgramName.Name = "lblProgramName"
        lblProgramName.Size = New Size(125, 19)
        lblProgramName.TabIndex = 3
        lblProgramName.Text = "Program Name *"
        ' 
        ' txtProgramName
        ' 
        txtProgramName.Font = New Font("Times New Roman", 12.0F)
        txtProgramName.Location = New Point(500, 97)
        txtProgramName.MaxLength = 255
        txtProgramName.Name = "txtProgramName"
        txtProgramName.Size = New Size(400, 26)
        txtProgramName.TabIndex = 4
        ' 
        ' lblProgramDescription
        ' 
        lblProgramDescription.AutoSize = True
        lblProgramDescription.Font = New Font("Times New Roman", 12.0F)
        lblProgramDescription.Location = New Point(50, 145)
        lblProgramDescription.Name = "lblProgramDescription"
        lblProgramDescription.Size = New Size(148, 19)
        lblProgramDescription.TabIndex = 5
        lblProgramDescription.Text = "Program Description"
        ' 
        ' txtProgramDescription
        ' 
        txtProgramDescription.Font = New Font("Times New Roman", 12.0F)
        txtProgramDescription.Location = New Point(50, 167)
        txtProgramDescription.Multiline = True
        txtProgramDescription.Name = "txtProgramDescription"
        txtProgramDescription.ScrollBars = ScrollBars.Vertical
        txtProgramDescription.Size = New Size(850, 80)
        txtProgramDescription.TabIndex = 6
        ' 
        ' lblDepartment
        ' 
        lblDepartment.AutoSize = True
        lblDepartment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblDepartment.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblDepartment.Location = New Point(50, 270)
        lblDepartment.Name = "lblDepartment"
        lblDepartment.Size = New Size(101, 19)
        lblDepartment.TabIndex = 7
        lblDepartment.Text = "Department *"
        ' 
        ' cmbDepartment
        ' 
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDepartment.Font = New Font("Times New Roman", 12.0F)
        cmbDepartment.FormattingEnabled = True
        cmbDepartment.Location = New Point(50, 292)
        cmbDepartment.Name = "cmbDepartment"
        cmbDepartment.Size = New Size(400, 27)
        cmbDepartment.TabIndex = 8
        ' 
        ' lblTotalUnits
        ' 
        lblTotalUnits.AutoSize = True
        lblTotalUnits.Font = New Font("Times New Roman", 12.0F)
        lblTotalUnits.Location = New Point(500, 270)
        lblTotalUnits.Name = "lblTotalUnits"
        lblTotalUnits.Size = New Size(150, 19)
        lblTotalUnits.TabIndex = 9
        lblTotalUnits.Text = "Total Units Required"
        ' 
        ' txtTotalUnits
        ' 
        txtTotalUnits.Font = New Font("Times New Roman", 12.0F)
        txtTotalUnits.Location = New Point(500, 292)
        txtTotalUnits.MaxLength = 3
        txtTotalUnits.Name = "txtTotalUnits"
        txtTotalUnits.Size = New Size(200, 26)
        txtTotalUnits.TabIndex = 10
        txtTotalUnits.Text = "160"
        ' 
        ' lblYearsToComplete
        ' 
        lblYearsToComplete.AutoSize = True
        lblYearsToComplete.Font = New Font("Times New Roman", 12.0F)
        lblYearsToComplete.Location = New Point(750, 270)
        lblYearsToComplete.Name = "lblYearsToComplete"
        lblYearsToComplete.Size = New Size(133, 19)
        lblYearsToComplete.TabIndex = 11
        lblYearsToComplete.Text = "Years To Complete"
        ' 
        ' txtYearsToComplete
        ' 
        txtYearsToComplete.Font = New Font("Times New Roman", 12.0F)
        txtYearsToComplete.Location = New Point(750, 292)
        txtYearsToComplete.MaxLength = 2
        txtYearsToComplete.Name = "txtYearsToComplete"
        txtYearsToComplete.Size = New Size(150, 26)
        txtYearsToComplete.TabIndex = 12
        txtYearsToComplete.Text = "4"
        ' 
        ' lblAccreditationStatus
        ' 
        lblAccreditationStatus.AutoSize = True
        lblAccreditationStatus.Font = New Font("Times New Roman", 12.0F)
        lblAccreditationStatus.Location = New Point(50, 340)
        lblAccreditationStatus.Name = "lblAccreditationStatus"
        lblAccreditationStatus.Size = New Size(139, 19)
        lblAccreditationStatus.TabIndex = 13
        lblAccreditationStatus.Text = "Accreditation Status"
        ' 
        ' cmbAccreditationStatus
        ' 
        cmbAccreditationStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAccreditationStatus.Font = New Font("Times New Roman", 12.0F)
        cmbAccreditationStatus.FormattingEnabled = True
        cmbAccreditationStatus.Items.AddRange(New Object() {"Not Accredited", "Level I", "Level II", "Level III", "Level IV", "Autonomous"})
        cmbAccreditationStatus.Location = New Point(50, 362)
        cmbAccreditationStatus.Name = "cmbAccreditationStatus"
        cmbAccreditationStatus.Size = New Size(400, 27)
        cmbAccreditationStatus.TabIndex = 14
        ' 
        ' lblIsActive
        ' 
        lblIsActive.AutoSize = True
        lblIsActive.Font = New Font("Times New Roman", 12.0F)
        lblIsActive.Location = New Point(500, 340)
        lblIsActive.Name = "lblIsActive"
        lblIsActive.Size = New Size(94, 19)
        lblIsActive.TabIndex = 15
        lblIsActive.Text = "Active Status"
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.Checked = True
        chkIsActive.CheckState = CheckState.Checked
        chkIsActive.Font = New Font("Times New Roman", 12.0F)
        chkIsActive.Location = New Point(500, 365)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(150, 23)
        chkIsActive.TabIndex = 16
        chkIsActive.Text = "Program is Active"
        chkIsActive.UseVisualStyleBackColor = True
        ' 
        ' btnSubmitProgram
        ' 
        btnSubmitProgram.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnSubmitProgram.FlatStyle = FlatStyle.Flat
        btnSubmitProgram.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnSubmitProgram.ForeColor = Color.White
        btnSubmitProgram.Location = New Point(50, 420)
        btnSubmitProgram.Name = "btnSubmitProgram"
        btnSubmitProgram.Size = New Size(220, 45)
        btnSubmitProgram.TabIndex = 17
        btnSubmitProgram.Text = "+ Create Program"
        btnSubmitProgram.UseVisualStyleBackColor = False
        ' 
        ' pnlViewPrograms
        ' 
        pnlViewPrograms.BackColor = Color.White
        pnlViewPrograms.Controls.Add(dgvPrograms)
        pnlViewPrograms.Controls.Add(lblViewProgramsTitle)
        pnlViewPrograms.Controls.Add(btnRefreshPrograms)
        pnlViewPrograms.Dock = DockStyle.Fill
        pnlViewPrograms.Location = New Point(0, 0)
        pnlViewPrograms.Name = "pnlViewPrograms"
        pnlViewPrograms.Padding = New Padding(20)
        pnlViewPrograms.Size = New Size(980, 800)
        pnlViewPrograms.TabIndex = 1
        pnlViewPrograms.Visible = False
        ' 
        ' dgvPrograms
        ' 
        dgvPrograms.AllowUserToAddRows = False
        dgvPrograms.AllowUserToDeleteRows = False
        dgvPrograms.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPrograms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPrograms.BackgroundColor = SystemColors.Control
        dgvPrograms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPrograms.Location = New Point(23, 70)
        dgvPrograms.Name = "dgvPrograms"
        dgvPrograms.ReadOnly = True
        dgvPrograms.Size = New Size(934, 690)
        dgvPrograms.TabIndex = 1
        ' 
        ' lblViewProgramsTitle
        ' 
        lblViewProgramsTitle.AutoSize = True
        lblViewProgramsTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblViewProgramsTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewProgramsTitle.Location = New Point(23, 20)
        lblViewProgramsTitle.Name = "lblViewProgramsTitle"
        lblViewProgramsTitle.Size = New Size(203, 36)
        lblViewProgramsTitle.TabIndex = 0
        lblViewProgramsTitle.Text = "All Programs"
        ' 
        ' btnRefreshPrograms
        ' 
        btnRefreshPrograms.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshPrograms.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshPrograms.FlatStyle = FlatStyle.Flat
        btnRefreshPrograms.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnRefreshPrograms.ForeColor = Color.White
        btnRefreshPrograms.Location = New Point(797, 20)
        btnRefreshPrograms.Name = "btnRefreshPrograms"
        btnRefreshPrograms.Size = New Size(160, 40)
        btnRefreshPrograms.TabIndex = 2
        btnRefreshPrograms.Text = "🔄 Refresh"
        btnRefreshPrograms.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteProgram
        ' 
        pnlUpdateDeleteProgram.AutoScroll = True
        pnlUpdateDeleteProgram.BackColor = Color.White
        pnlUpdateDeleteProgram.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteProgram.Controls.Add(lblSelectProgram)
        pnlUpdateDeleteProgram.Controls.Add(cmbSelectProgram)
        pnlUpdateDeleteProgram.Controls.Add(btnLoadProgramData)
        pnlUpdateDeleteProgram.Controls.Add(grpProgramInfo)
        pnlUpdateDeleteProgram.Dock = DockStyle.Fill
        pnlUpdateDeleteProgram.Location = New Point(0, 0)
        pnlUpdateDeleteProgram.Name = "pnlUpdateDeleteProgram"
        pnlUpdateDeleteProgram.Padding = New Padding(20)
        pnlUpdateDeleteProgram.Size = New Size(980, 800)
        pnlUpdateDeleteProgram.TabIndex = 2
        pnlUpdateDeleteProgram.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(431, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete Program Info"
        ' 
        ' lblSelectProgram
        ' 
        lblSelectProgram.AutoSize = True
        lblSelectProgram.Font = New Font("Times New Roman", 14.0F)
        lblSelectProgram.Location = New Point(40, 80)
        lblSelectProgram.Name = "lblSelectProgram"
        lblSelectProgram.Size = New Size(125, 21)
        lblSelectProgram.TabIndex = 1
        lblSelectProgram.Text = "Select Program"
        ' 
        ' cmbSelectProgram
        ' 
        cmbSelectProgram.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectProgram.Font = New Font("Times New Roman", 12.0F)
        cmbSelectProgram.FormattingEnabled = True
        cmbSelectProgram.Location = New Point(40, 105)
        cmbSelectProgram.Name = "cmbSelectProgram"
        cmbSelectProgram.Size = New Size(600, 27)
        cmbSelectProgram.TabIndex = 2
        ' 
        ' btnLoadProgramData
        ' 
        btnLoadProgramData.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadProgramData.FlatStyle = FlatStyle.Flat
        btnLoadProgramData.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnLoadProgramData.ForeColor = Color.White
        btnLoadProgramData.Location = New Point(660, 105)
        btnLoadProgramData.Name = "btnLoadProgramData"
        btnLoadProgramData.Size = New Size(140, 29)
        btnLoadProgramData.TabIndex = 3
        btnLoadProgramData.Text = "Load Data"
        btnLoadProgramData.UseVisualStyleBackColor = False
        ' 
        ' grpProgramInfo
        ' 
        grpProgramInfo.Controls.Add(lblUpdateProgramCode)
        grpProgramInfo.Controls.Add(txtUpdateProgramCode)
        grpProgramInfo.Controls.Add(lblUpdateProgramName)
        grpProgramInfo.Controls.Add(txtUpdateProgramName)
        grpProgramInfo.Controls.Add(lblUpdateProgramDescription)
        grpProgramInfo.Controls.Add(txtUpdateProgramDescription)
        grpProgramInfo.Controls.Add(lblUpdateDepartment)
        grpProgramInfo.Controls.Add(cmbUpdateDepartment)
        grpProgramInfo.Controls.Add(lblUpdateTotalUnits)
        grpProgramInfo.Controls.Add(txtUpdateTotalUnits)
        grpProgramInfo.Controls.Add(lblUpdateYearsToComplete)
        grpProgramInfo.Controls.Add(txtUpdateYearsToComplete)
        grpProgramInfo.Controls.Add(lblUpdateAccreditationStatus)
        grpProgramInfo.Controls.Add(cmbUpdateAccreditationStatus)
        grpProgramInfo.Controls.Add(lblUpdateIsActive)
        grpProgramInfo.Controls.Add(chkUpdateIsActive)
        grpProgramInfo.Controls.Add(btnUpdateProgram)
        grpProgramInfo.Controls.Add(btnDeleteProgram)
        grpProgramInfo.Location = New Point(40, 150)
        grpProgramInfo.Name = "grpProgramInfo"
        grpProgramInfo.Size = New Size(900, 620)
        grpProgramInfo.TabIndex = 4
        grpProgramInfo.TabStop = False
        grpProgramInfo.Text = "Program Information"
        grpProgramInfo.Visible = False
        ' 
        ' lblUpdateProgramCode
        ' 
        lblUpdateProgramCode.AutoSize = True
        lblUpdateProgramCode.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateProgramCode.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateProgramCode.Location = New Point(30, 40)
        lblUpdateProgramCode.Name = "lblUpdateProgramCode"
        lblUpdateProgramCode.Size = New Size(122, 19)
        lblUpdateProgramCode.TabIndex = 0
        lblUpdateProgramCode.Text = "Program Code *"
        ' 
        ' txtUpdateProgramCode
        ' 
        txtUpdateProgramCode.Font = New Font("Times New Roman", 12.0F)
        txtUpdateProgramCode.Location = New Point(30, 62)
        txtUpdateProgramCode.MaxLength = 20
        txtUpdateProgramCode.Name = "txtUpdateProgramCode"
        txtUpdateProgramCode.Size = New Size(400, 26)
        txtUpdateProgramCode.TabIndex = 1
        ' 
        ' lblUpdateProgramName
        ' 
        lblUpdateProgramName.AutoSize = True
        lblUpdateProgramName.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateProgramName.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateProgramName.Location = New Point(470, 40)
        lblUpdateProgramName.Name = "lblUpdateProgramName"
        lblUpdateProgramName.Size = New Size(125, 19)
        lblUpdateProgramName.TabIndex = 2
        lblUpdateProgramName.Text = "Program Name *"
        ' 
        ' txtUpdateProgramName
        ' 
        txtUpdateProgramName.Font = New Font("Times New Roman", 12.0F)
        txtUpdateProgramName.Location = New Point(470, 62)
        txtUpdateProgramName.MaxLength = 255
        txtUpdateProgramName.Name = "txtUpdateProgramName"
        txtUpdateProgramName.Size = New Size(400, 26)
        txtUpdateProgramName.TabIndex = 3
        ' 
        ' lblUpdateProgramDescription
        ' 
        lblUpdateProgramDescription.AutoSize = True
        lblUpdateProgramDescription.Font = New Font("Times New Roman", 12.0F)
        lblUpdateProgramDescription.Location = New Point(30, 110)
        lblUpdateProgramDescription.Name = "lblUpdateProgramDescription"
        lblUpdateProgramDescription.Size = New Size(148, 19)
        lblUpdateProgramDescription.TabIndex = 4
        lblUpdateProgramDescription.Text = "Program Description"
        ' 
        ' txtUpdateProgramDescription
        ' 
        txtUpdateProgramDescription.Font = New Font("Times New Roman", 12.0F)
        txtUpdateProgramDescription.Location = New Point(30, 132)
        txtUpdateProgramDescription.Multiline = True
        txtUpdateProgramDescription.Name = "txtUpdateProgramDescription"
        txtUpdateProgramDescription.ScrollBars = ScrollBars.Vertical
        txtUpdateProgramDescription.Size = New Size(840, 80)
        txtUpdateProgramDescription.TabIndex = 5
        ' 
        ' lblUpdateDepartment
        ' 
        lblUpdateDepartment.AutoSize = True
        lblUpdateDepartment.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateDepartment.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateDepartment.Location = New Point(30, 235)
        lblUpdateDepartment.Name = "lblUpdateDepartment"
        lblUpdateDepartment.Size = New Size(101, 19)
        lblUpdateDepartment.TabIndex = 6
        lblUpdateDepartment.Text = "Department *"
        ' 
        ' cmbUpdateDepartment
        ' 
        cmbUpdateDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateDepartment.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateDepartment.FormattingEnabled = True
        cmbUpdateDepartment.Location = New Point(30, 257)
        cmbUpdateDepartment.Name = "cmbUpdateDepartment"
        cmbUpdateDepartment.Size = New Size(400, 27)
        cmbUpdateDepartment.TabIndex = 7
        ' 
        ' lblUpdateTotalUnits
        ' 
        lblUpdateTotalUnits.AutoSize = True
        lblUpdateTotalUnits.Font = New Font("Times New Roman", 12.0F)
        lblUpdateTotalUnits.Location = New Point(470, 235)
        lblUpdateTotalUnits.Name = "lblUpdateTotalUnits"
        lblUpdateTotalUnits.Size = New Size(150, 19)
        lblUpdateTotalUnits.TabIndex = 8
        lblUpdateTotalUnits.Text = "Total Units Required"
        ' 
        ' txtUpdateTotalUnits
        ' 
        txtUpdateTotalUnits.Font = New Font("Times New Roman", 12.0F)
        txtUpdateTotalUnits.Location = New Point(470, 257)
        txtUpdateTotalUnits.MaxLength = 3
        txtUpdateTotalUnits.Name = "txtUpdateTotalUnits"
        txtUpdateTotalUnits.Size = New Size(200, 26)
        txtUpdateTotalUnits.TabIndex = 9
        ' 
        ' lblUpdateYearsToComplete
        ' 
        lblUpdateYearsToComplete.AutoSize = True
        lblUpdateYearsToComplete.Font = New Font("Times New Roman", 12.0F)
        lblUpdateYearsToComplete.Location = New Point(720, 235)
        lblUpdateYearsToComplete.Name = "lblUpdateYearsToComplete"
        lblUpdateYearsToComplete.Size = New Size(133, 19)
        lblUpdateYearsToComplete.TabIndex = 10
        lblUpdateYearsToComplete.Text = "Years To Complete"
        ' 
        ' txtUpdateYearsToComplete
        ' 
        txtUpdateYearsToComplete.Font = New Font("Times New Roman", 12.0F)
        txtUpdateYearsToComplete.Location = New Point(720, 257)
        txtUpdateYearsToComplete.MaxLength = 2
        txtUpdateYearsToComplete.Name = "txtUpdateYearsToComplete"
        txtUpdateYearsToComplete.Size = New Size(150, 26)
        txtUpdateYearsToComplete.TabIndex = 11
        ' 
        ' lblUpdateAccreditationStatus
        ' 
        lblUpdateAccreditationStatus.AutoSize = True
        lblUpdateAccreditationStatus.Font = New Font("Times New Roman", 12.0F)
        lblUpdateAccreditationStatus.Location = New Point(30, 305)
        lblUpdateAccreditationStatus.Name = "lblUpdateAccreditationStatus"
        lblUpdateAccreditationStatus.Size = New Size(139, 19)
        lblUpdateAccreditationStatus.TabIndex = 12
        lblUpdateAccreditationStatus.Text = "Accreditation Status"
        ' 
        ' cmbUpdateAccreditationStatus
        ' 
        cmbUpdateAccreditationStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateAccreditationStatus.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateAccreditationStatus.FormattingEnabled = True
        cmbUpdateAccreditationStatus.Items.AddRange(New Object() {"Not Accredited", "Level I", "Level II", "Level III", "Level IV", "Autonomous"})
        cmbUpdateAccreditationStatus.Location = New Point(30, 327)
        cmbUpdateAccreditationStatus.Name = "cmbUpdateAccreditationStatus"
        cmbUpdateAccreditationStatus.Size = New Size(400, 27)
        cmbUpdateAccreditationStatus.TabIndex = 13
        ' 
        ' lblUpdateIsActive
        ' 
        lblUpdateIsActive.AutoSize = True
        lblUpdateIsActive.Font = New Font("Times New Roman", 12.0F)
        lblUpdateIsActive.Location = New Point(470, 305)
        lblUpdateIsActive.Name = "lblUpdateIsActive"
        lblUpdateIsActive.Size = New Size(94, 19)
        lblUpdateIsActive.TabIndex = 14
        lblUpdateIsActive.Text = "Active Status"
        ' 
        ' chkUpdateIsActive
        ' 
        chkUpdateIsActive.AutoSize = True
        chkUpdateIsActive.Font = New Font("Times New Roman", 12.0F)
        chkUpdateIsActive.Location = New Point(470, 330)
        chkUpdateIsActive.Name = "chkUpdateIsActive"
        chkUpdateIsActive.Size = New Size(150, 23)
        chkUpdateIsActive.TabIndex = 15
        chkUpdateIsActive.Text = "Program is Active"
        chkUpdateIsActive.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateProgram
        ' 
        btnUpdateProgram.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnUpdateProgram.FlatStyle = FlatStyle.Flat
        btnUpdateProgram.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnUpdateProgram.ForeColor = Color.White
        btnUpdateProgram.Location = New Point(30, 385)
        btnUpdateProgram.Name = "btnUpdateProgram"
        btnUpdateProgram.Size = New Size(220, 45)
        btnUpdateProgram.TabIndex = 16
        btnUpdateProgram.Text = "Update Program"
        btnUpdateProgram.UseVisualStyleBackColor = False
        btnUpdateProgram.Visible = False
        ' 
        ' btnDeleteProgram
        ' 
        btnDeleteProgram.BackColor = Color.FromArgb(CByte(255), CByte(71), CByte(71))
        btnDeleteProgram.FlatStyle = FlatStyle.Flat
        btnDeleteProgram.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnDeleteProgram.ForeColor = Color.White
        btnDeleteProgram.Location = New Point(270, 385)
        btnDeleteProgram.Name = "btnDeleteProgram"
        btnDeleteProgram.Size = New Size(220, 45)
        btnDeleteProgram.TabIndex = 17
        btnDeleteProgram.Text = "Delete Program"
        btnDeleteProgram.UseVisualStyleBackColor = False
        btnDeleteProgram.Visible = False
        ' 
        ' ProgramManagement
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "ProgramManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Program Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlCreateProgram.ResumeLayout(False)
        pnlCreateProgram.PerformLayout()
        pnlViewPrograms.ResumeLayout(False)
        pnlViewPrograms.PerformLayout()
        CType(dgvPrograms, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteProgram.ResumeLayout(False)
        pnlUpdateDeleteProgram.PerformLayout()
        grpProgramInfo.ResumeLayout(False)
        grpProgramInfo.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblProgramTitle As Label
    Friend WithEvents btnCreateProgram As Button
    Friend WithEvents btnUpdateDeleteProgram As Button
    Friend WithEvents btnViewPrograms As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Create Program Panel
    Friend WithEvents pnlCreateProgram As Panel
    Friend WithEvents lblCreateProgramTitle As Label
    Friend WithEvents lblProgramCode As Label
    Friend WithEvents txtProgramCode As TextBox
    Friend WithEvents lblProgramName As Label
    Friend WithEvents txtProgramName As TextBox
    Friend WithEvents lblProgramDescription As Label
    Friend WithEvents txtProgramDescription As TextBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents lblTotalUnits As Label
    Friend WithEvents txtTotalUnits As TextBox
    Friend WithEvents lblYearsToComplete As Label
    Friend WithEvents txtYearsToComplete As TextBox
    Friend WithEvents lblAccreditationStatus As Label
    Friend WithEvents cmbAccreditationStatus As ComboBox
    Friend WithEvents lblIsActive As Label
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents btnSubmitProgram As Button

    ' View Programs Panel
    Friend WithEvents pnlViewPrograms As Panel
    Friend WithEvents lblViewProgramsTitle As Label
    Friend WithEvents dgvPrograms As DataGridView
    Friend WithEvents btnRefreshPrograms As Button

    ' Update/Delete Program Panel
    Friend WithEvents pnlUpdateDeleteProgram As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectProgram As Label
    Friend WithEvents cmbSelectProgram As ComboBox
    Friend WithEvents btnLoadProgramData As Button
    Friend WithEvents grpProgramInfo As GroupBox
    Friend WithEvents lblUpdateProgramCode As Label
    Friend WithEvents txtUpdateProgramCode As TextBox
    Friend WithEvents lblUpdateProgramName As Label
    Friend WithEvents txtUpdateProgramName As TextBox
    Friend WithEvents lblUpdateProgramDescription As Label
    Friend WithEvents txtUpdateProgramDescription As TextBox
    Friend WithEvents lblUpdateDepartment As Label
    Friend WithEvents cmbUpdateDepartment As ComboBox
    Friend WithEvents lblUpdateTotalUnits As Label
    Friend WithEvents txtUpdateTotalUnits As TextBox
    Friend WithEvents lblUpdateYearsToComplete As Label
    Friend WithEvents txtUpdateYearsToComplete As TextBox
    Friend WithEvents lblUpdateAccreditationStatus As Label
    Friend WithEvents cmbUpdateAccreditationStatus As ComboBox
    Friend WithEvents lblUpdateIsActive As Label
    Friend WithEvents chkUpdateIsActive As CheckBox
    Friend WithEvents btnUpdateProgram As Button
    Friend WithEvents btnDeleteProgram As Button
End Class
