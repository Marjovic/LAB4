<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AssignmentType
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
        btnCreateAssignmentType = New Button()
        btnUpdateDeleteAssignmentType = New Button()
        btnViewAssignmentTypes = New Button()
        lblAssignmentTypeTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlCreateAssignmentType = New Panel()
        lblCreateTitle = New Label()
        lblTypeName = New Label()
        txtTypeName = New TextBox()
        lblTypeCode = New Label()
        txtTypeCode = New TextBox()
        lblDefaultWeight = New Label()
        txtDefaultWeight = New TextBox()
        lblDescription = New Label()
        txtDescription = New TextBox()
        lblDisplayOrder = New Label()
        txtDisplayOrder = New TextBox()
        chkIsActive = New CheckBox()
        btnSubmitAssignmentType = New Button()
        pnlViewAssignmentTypes = New Panel()
        dgvAssignmentTypes = New DataGridView()
        lblViewTitle = New Label()
        btnRefreshAssignmentTypes = New Button()
        pnlUpdateDeleteAssignmentType = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectAssignmentType = New Label()
        cmbSelectAssignmentType = New ComboBox()
        btnLoadAssignmentTypeData = New Button()
        grpAssignmentTypeInfo = New GroupBox()
        lblUpdateTypeName = New Label()
        txtUpdateTypeName = New TextBox()
        lblUpdateTypeCode = New Label()
        txtUpdateTypeCode = New TextBox()
        lblUpdateDefaultWeight = New Label()
        txtUpdateDefaultWeight = New TextBox()
        lblUpdateDescription = New Label()
        txtUpdateDescription = New TextBox()
        lblUpdateDisplayOrder = New Label()
        txtUpdateDisplayOrder = New TextBox()
        chkUpdateIsActive = New CheckBox()
        btnUpdateAssignmentType = New Button()
        btnDeleteAssignmentType = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlCreateAssignmentType.SuspendLayout()
        pnlViewAssignmentTypes.SuspendLayout()
        CType(dgvAssignmentTypes, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteAssignmentType.SuspendLayout()
        grpAssignmentTypeInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnViewAssignmentTypes)
        pnlSidebar.Controls.Add(btnUpdateDeleteAssignmentType)
        pnlSidebar.Controls.Add(btnCreateAssignmentType)
        pnlSidebar.Controls.Add(lblAssignmentTypeTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCreateAssignmentType
        ' 
        btnCreateAssignmentType.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateAssignmentType.Dock = DockStyle.Top
        btnCreateAssignmentType.FlatAppearance.BorderSize = 0
        btnCreateAssignmentType.FlatStyle = FlatStyle.Flat
        btnCreateAssignmentType.Font = New Font("Times New Roman", 11.0F)
        btnCreateAssignmentType.ForeColor = Color.White
        btnCreateAssignmentType.Location = New Point(0, 80)
        btnCreateAssignmentType.Name = "btnCreateAssignmentType"
        btnCreateAssignmentType.Size = New Size(220, 50)
        btnCreateAssignmentType.TabIndex = 1
        btnCreateAssignmentType.Text = "+ Create Assignment Type"
        btnCreateAssignmentType.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteAssignmentType
        ' 
        btnUpdateDeleteAssignmentType.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteAssignmentType.Dock = DockStyle.Top
        btnUpdateDeleteAssignmentType.FlatAppearance.BorderSize = 0
        btnUpdateDeleteAssignmentType.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteAssignmentType.Font = New Font("Times New Roman", 11.0F)
        btnUpdateDeleteAssignmentType.ForeColor = Color.White
        btnUpdateDeleteAssignmentType.Location = New Point(0, 130)
        btnUpdateDeleteAssignmentType.Name = "btnUpdateDeleteAssignmentType"
        btnUpdateDeleteAssignmentType.Size = New Size(220, 50)
        btnUpdateDeleteAssignmentType.TabIndex = 2
        btnUpdateDeleteAssignmentType.Text = "Update/Delete Type"
        btnUpdateDeleteAssignmentType.UseVisualStyleBackColor = False
        ' 
        ' btnViewAssignmentTypes
        ' 
        btnViewAssignmentTypes.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewAssignmentTypes.Dock = DockStyle.Top
        btnViewAssignmentTypes.FlatAppearance.BorderSize = 0
        btnViewAssignmentTypes.FlatStyle = FlatStyle.Flat
        btnViewAssignmentTypes.Font = New Font("Times New Roman", 11.0F)
        btnViewAssignmentTypes.ForeColor = Color.White
        btnViewAssignmentTypes.Location = New Point(0, 180)
        btnViewAssignmentTypes.Name = "btnViewAssignmentTypes"
        btnViewAssignmentTypes.Size = New Size(220, 50)
        btnViewAssignmentTypes.TabIndex = 3
        btnViewAssignmentTypes.Text = "View Assignment Types"
        btnViewAssignmentTypes.UseVisualStyleBackColor = False
        ' 
        ' lblAssignmentTypeTitle
        ' 
        lblAssignmentTypeTitle.BackColor = Color.Navy
        lblAssignmentTypeTitle.Dock = DockStyle.Top
        lblAssignmentTypeTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblAssignmentTypeTitle.ForeColor = Color.White
        lblAssignmentTypeTitle.Location = New Point(0, 0)
        lblAssignmentTypeTitle.Name = "lblAssignmentTypeTitle"
        lblAssignmentTypeTitle.Size = New Size(220, 80)
        lblAssignmentTypeTitle.TabIndex = 0
        lblAssignmentTypeTitle.Text = "Assignment Type Management"
        lblAssignmentTypeTitle.TextAlign = ContentAlignment.MiddleCenter
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
        pnlMainContent.Controls.Add(pnlCreateAssignmentType)
        pnlMainContent.Controls.Add(pnlViewAssignmentTypes)
        pnlMainContent.Controls.Add(pnlUpdateDeleteAssignmentType)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlCreateAssignmentType
        ' 
        pnlCreateAssignmentType.AutoScroll = True
        pnlCreateAssignmentType.BackColor = Color.White
        pnlCreateAssignmentType.Controls.Add(lblCreateTitle)
        pnlCreateAssignmentType.Controls.Add(lblTypeName)
        pnlCreateAssignmentType.Controls.Add(txtTypeName)
        pnlCreateAssignmentType.Controls.Add(lblTypeCode)
        pnlCreateAssignmentType.Controls.Add(txtTypeCode)
        pnlCreateAssignmentType.Controls.Add(lblDefaultWeight)
        pnlCreateAssignmentType.Controls.Add(txtDefaultWeight)
        pnlCreateAssignmentType.Controls.Add(lblDescription)
        pnlCreateAssignmentType.Controls.Add(txtDescription)
        pnlCreateAssignmentType.Controls.Add(lblDisplayOrder)
        pnlCreateAssignmentType.Controls.Add(txtDisplayOrder)
        pnlCreateAssignmentType.Controls.Add(chkIsActive)
        pnlCreateAssignmentType.Controls.Add(btnSubmitAssignmentType)
        pnlCreateAssignmentType.Dock = DockStyle.Fill
        pnlCreateAssignmentType.Location = New Point(0, 0)
        pnlCreateAssignmentType.Name = "pnlCreateAssignmentType"
        pnlCreateAssignmentType.Padding = New Padding(30, 20, 30, 20)
        pnlCreateAssignmentType.Size = New Size(980, 800)
        pnlCreateAssignmentType.TabIndex = 0
        pnlCreateAssignmentType.Visible = False
        ' 
        ' lblCreateTitle
        ' 
        lblCreateTitle.AutoSize = True
        lblCreateTitle.Font = New Font("Times New Roman", 20.0F, FontStyle.Bold)
        lblCreateTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateTitle.Location = New Point(30, 20)
        lblCreateTitle.Name = "lblCreateTitle"
        lblCreateTitle.Size = New Size(396, 31)
        lblCreateTitle.TabIndex = 0
        lblCreateTitle.Text = "Create New Assignment Type"
        ' 
        ' lblTypeName
        ' 
        lblTypeName.AutoSize = True
        lblTypeName.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblTypeName.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblTypeName.Location = New Point(50, 75)
        lblTypeName.Name = "lblTypeName"
        lblTypeName.Size = New Size(108, 19)
        lblTypeName.TabIndex = 1
        lblTypeName.Text = "Type Name *"
        ' 
        ' txtTypeName
        ' 
        txtTypeName.Font = New Font("Times New Roman", 12.0F)
        txtTypeName.Location = New Point(50, 97)
        txtTypeName.MaxLength = 100
        txtTypeName.Name = "txtTypeName"
        txtTypeName.Size = New Size(400, 26)
        txtTypeName.TabIndex = 2
        ' 
        ' lblTypeCode
        ' 
        lblTypeCode.AutoSize = True
        lblTypeCode.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblTypeCode.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblTypeCode.Location = New Point(500, 75)
        lblTypeCode.Name = "lblTypeCode"
        lblTypeCode.Size = New Size(104, 19)
        lblTypeCode.TabIndex = 3
        lblTypeCode.Text = "Type Code *"
        ' 
        ' txtTypeCode
        ' 
        txtTypeCode.Font = New Font("Times New Roman", 12.0F)
        txtTypeCode.Location = New Point(500, 97)
        txtTypeCode.MaxLength = 20
        txtTypeCode.Name = "txtTypeCode"
        txtTypeCode.Size = New Size(200, 26)
        txtTypeCode.TabIndex = 4
        ' 
        ' lblDefaultWeight
        ' 
        lblDefaultWeight.AutoSize = True
        lblDefaultWeight.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblDefaultWeight.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblDefaultWeight.Location = New Point(50, 145)
        lblDefaultWeight.Name = "lblDefaultWeight"
        lblDefaultWeight.Size = New Size(200, 19)
        lblDefaultWeight.TabIndex = 5
        lblDefaultWeight.Text = "Default Weight (0-100) *"
        ' 
        ' txtDefaultWeight
        ' 
        txtDefaultWeight.Font = New Font("Times New Roman", 12.0F)
        txtDefaultWeight.Location = New Point(50, 167)
        txtDefaultWeight.MaxLength = 6
        txtDefaultWeight.Name = "txtDefaultWeight"
        txtDefaultWeight.Size = New Size(150, 26)
        txtDefaultWeight.TabIndex = 6
        txtDefaultWeight.Text = "0.00"
        ' 
        ' lblDescription
        ' 
        lblDescription.AutoSize = True
        lblDescription.Font = New Font("Times New Roman", 12.0F)
        lblDescription.Location = New Point(50, 215)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(158, 19)
        lblDescription.TabIndex = 7
        lblDescription.Text = "Description (Optional)"
        ' 
        ' txtDescription
        ' 
        txtDescription.Font = New Font("Times New Roman", 12.0F)
        txtDescription.Location = New Point(50, 237)
        txtDescription.MaxLength = 255
        txtDescription.Multiline = True
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(650, 80)
        txtDescription.TabIndex = 8
        ' 
        ' lblDisplayOrder
        ' 
        lblDisplayOrder.AutoSize = True
        lblDisplayOrder.Font = New Font("Times New Roman", 12.0F)
        lblDisplayOrder.Location = New Point(50, 335)
        lblDisplayOrder.Name = "lblDisplayOrder"
        lblDisplayOrder.Size = New Size(99, 19)
        lblDisplayOrder.TabIndex = 9
        lblDisplayOrder.Text = "Display Order"
        ' 
        ' txtDisplayOrder
        ' 
        txtDisplayOrder.Font = New Font("Times New Roman", 12.0F)
        txtDisplayOrder.Location = New Point(50, 357)
        txtDisplayOrder.MaxLength = 5
        txtDisplayOrder.Name = "txtDisplayOrder"
        txtDisplayOrder.Size = New Size(150, 26)
        txtDisplayOrder.TabIndex = 10
        txtDisplayOrder.Text = "1"
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.Checked = True
        chkIsActive.CheckState = CheckState.Checked
        chkIsActive.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        chkIsActive.Location = New Point(50, 405)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(114, 23)
        chkIsActive.TabIndex = 11
        chkIsActive.Text = "Set as Active"
        chkIsActive.UseVisualStyleBackColor = True
        ' 
        ' btnSubmitAssignmentType
        ' 
        btnSubmitAssignmentType.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnSubmitAssignmentType.FlatStyle = FlatStyle.Flat
        btnSubmitAssignmentType.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnSubmitAssignmentType.ForeColor = Color.White
        btnSubmitAssignmentType.Location = New Point(50, 450)
        btnSubmitAssignmentType.Name = "btnSubmitAssignmentType"
        btnSubmitAssignmentType.Size = New Size(240, 45)
        btnSubmitAssignmentType.TabIndex = 12
        btnSubmitAssignmentType.Text = "+ Create Assignment Type"
        btnSubmitAssignmentType.UseVisualStyleBackColor = False
        ' 
        ' pnlViewAssignmentTypes
        ' 
        pnlViewAssignmentTypes.BackColor = Color.White
        pnlViewAssignmentTypes.Controls.Add(dgvAssignmentTypes)
        pnlViewAssignmentTypes.Controls.Add(lblViewTitle)
        pnlViewAssignmentTypes.Controls.Add(btnRefreshAssignmentTypes)
        pnlViewAssignmentTypes.Dock = DockStyle.Fill
        pnlViewAssignmentTypes.Location = New Point(0, 0)
        pnlViewAssignmentTypes.Name = "pnlViewAssignmentTypes"
        pnlViewAssignmentTypes.Padding = New Padding(20)
        pnlViewAssignmentTypes.Size = New Size(980, 800)
        pnlViewAssignmentTypes.TabIndex = 1
        pnlViewAssignmentTypes.Visible = False
        ' 
        ' dgvAssignmentTypes
        ' 
        dgvAssignmentTypes.AllowUserToAddRows = False
        dgvAssignmentTypes.AllowUserToDeleteRows = False
        dgvAssignmentTypes.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvAssignmentTypes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAssignmentTypes.BackgroundColor = SystemColors.Control
        dgvAssignmentTypes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAssignmentTypes.Location = New Point(23, 70)
        dgvAssignmentTypes.Name = "dgvAssignmentTypes"
        dgvAssignmentTypes.ReadOnly = True
        dgvAssignmentTypes.Size = New Size(934, 690)
        dgvAssignmentTypes.TabIndex = 1
        ' 
        ' lblViewTitle
        ' 
        lblViewTitle.AutoSize = True
        lblViewTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblViewTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewTitle.Location = New Point(23, 20)
        lblViewTitle.Name = "lblViewTitle"
        lblViewTitle.Size = New Size(377, 36)
        lblViewTitle.TabIndex = 0
        lblViewTitle.Text = "All Assignment Types"
        ' 
        ' btnRefreshAssignmentTypes
        ' 
        btnRefreshAssignmentTypes.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshAssignmentTypes.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshAssignmentTypes.FlatStyle = FlatStyle.Flat
        btnRefreshAssignmentTypes.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnRefreshAssignmentTypes.ForeColor = Color.White
        btnRefreshAssignmentTypes.Location = New Point(797, 20)
        btnRefreshAssignmentTypes.Name = "btnRefreshAssignmentTypes"
        btnRefreshAssignmentTypes.Size = New Size(160, 40)
        btnRefreshAssignmentTypes.TabIndex = 2
        btnRefreshAssignmentTypes.Text = "🔄 Refresh"
        btnRefreshAssignmentTypes.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteAssignmentType
        ' 
        pnlUpdateDeleteAssignmentType.AutoScroll = True
        pnlUpdateDeleteAssignmentType.BackColor = Color.White
        pnlUpdateDeleteAssignmentType.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteAssignmentType.Controls.Add(lblSelectAssignmentType)
        pnlUpdateDeleteAssignmentType.Controls.Add(cmbSelectAssignmentType)
        pnlUpdateDeleteAssignmentType.Controls.Add(btnLoadAssignmentTypeData)
        pnlUpdateDeleteAssignmentType.Controls.Add(grpAssignmentTypeInfo)
        pnlUpdateDeleteAssignmentType.Dock = DockStyle.Fill
        pnlUpdateDeleteAssignmentType.Location = New Point(0, 0)
        pnlUpdateDeleteAssignmentType.Name = "pnlUpdateDeleteAssignmentType"
        pnlUpdateDeleteAssignmentType.Padding = New Padding(20)
        pnlUpdateDeleteAssignmentType.Size = New Size(980, 800)
        pnlUpdateDeleteAssignmentType.TabIndex = 2
        pnlUpdateDeleteAssignmentType.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(555, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete Assignment Type Info"
        ' 
        ' lblSelectAssignmentType
        ' 
        lblSelectAssignmentType.AutoSize = True
        lblSelectAssignmentType.Font = New Font("Times New Roman", 14.0F)
        lblSelectAssignmentType.Location = New Point(40, 80)
        lblSelectAssignmentType.Name = "lblSelectAssignmentType"
        lblSelectAssignmentType.Size = New Size(197, 21)
        lblSelectAssignmentType.TabIndex = 1
        lblSelectAssignmentType.Text = "Select Assignment Type"
        ' 
        ' cmbSelectAssignmentType
        ' 
        cmbSelectAssignmentType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectAssignmentType.Font = New Font("Times New Roman", 12.0F)
        cmbSelectAssignmentType.FormattingEnabled = True
        cmbSelectAssignmentType.Location = New Point(40, 105)
        cmbSelectAssignmentType.Name = "cmbSelectAssignmentType"
        cmbSelectAssignmentType.Size = New Size(600, 27)
        cmbSelectAssignmentType.TabIndex = 2
        ' 
        ' btnLoadAssignmentTypeData
        ' 
        btnLoadAssignmentTypeData.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadAssignmentTypeData.FlatStyle = FlatStyle.Flat
        btnLoadAssignmentTypeData.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnLoadAssignmentTypeData.ForeColor = Color.White
        btnLoadAssignmentTypeData.Location = New Point(660, 105)
        btnLoadAssignmentTypeData.Name = "btnLoadAssignmentTypeData"
        btnLoadAssignmentTypeData.Size = New Size(140, 29)
        btnLoadAssignmentTypeData.TabIndex = 3
        btnLoadAssignmentTypeData.Text = "Load Data"
        btnLoadAssignmentTypeData.UseVisualStyleBackColor = False
        ' 
        ' grpAssignmentTypeInfo
        ' 
        grpAssignmentTypeInfo.Controls.Add(lblUpdateTypeName)
        grpAssignmentTypeInfo.Controls.Add(txtUpdateTypeName)
        grpAssignmentTypeInfo.Controls.Add(lblUpdateTypeCode)
        grpAssignmentTypeInfo.Controls.Add(txtUpdateTypeCode)
        grpAssignmentTypeInfo.Controls.Add(lblUpdateDefaultWeight)
        grpAssignmentTypeInfo.Controls.Add(txtUpdateDefaultWeight)
        grpAssignmentTypeInfo.Controls.Add(lblUpdateDescription)
        grpAssignmentTypeInfo.Controls.Add(txtUpdateDescription)
        grpAssignmentTypeInfo.Controls.Add(lblUpdateDisplayOrder)
        grpAssignmentTypeInfo.Controls.Add(txtUpdateDisplayOrder)
        grpAssignmentTypeInfo.Controls.Add(chkUpdateIsActive)
        grpAssignmentTypeInfo.Controls.Add(btnUpdateAssignmentType)
        grpAssignmentTypeInfo.Controls.Add(btnDeleteAssignmentType)
        grpAssignmentTypeInfo.Location = New Point(40, 150)
        grpAssignmentTypeInfo.Name = "grpAssignmentTypeInfo"
        grpAssignmentTypeInfo.Size = New Size(900, 580)
        grpAssignmentTypeInfo.TabIndex = 4
        grpAssignmentTypeInfo.TabStop = False
        grpAssignmentTypeInfo.Text = "Assignment Type Information"
        grpAssignmentTypeInfo.Visible = False
        ' 
        ' lblUpdateTypeName
        ' 
        lblUpdateTypeName.AutoSize = True
        lblUpdateTypeName.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateTypeName.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateTypeName.Location = New Point(30, 40)
        lblUpdateTypeName.Name = "lblUpdateTypeName"
        lblUpdateTypeName.Size = New Size(108, 19)
        lblUpdateTypeName.TabIndex = 0
        lblUpdateTypeName.Text = "Type Name *"
        ' 
        ' txtUpdateTypeName
        ' 
        txtUpdateTypeName.Font = New Font("Times New Roman", 12.0F)
        txtUpdateTypeName.Location = New Point(30, 62)
        txtUpdateTypeName.MaxLength = 100
        txtUpdateTypeName.Name = "txtUpdateTypeName"
        txtUpdateTypeName.Size = New Size(400, 26)
        txtUpdateTypeName.TabIndex = 1
        ' 
        ' lblUpdateTypeCode
        ' 
        lblUpdateTypeCode.AutoSize = True
        lblUpdateTypeCode.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateTypeCode.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateTypeCode.Location = New Point(470, 40)
        lblUpdateTypeCode.Name = "lblUpdateTypeCode"
        lblUpdateTypeCode.Size = New Size(104, 19)
        lblUpdateTypeCode.TabIndex = 2
        lblUpdateTypeCode.Text = "Type Code *"
        ' 
        ' txtUpdateTypeCode
        ' 
        txtUpdateTypeCode.Font = New Font("Times New Roman", 12.0F)
        txtUpdateTypeCode.Location = New Point(470, 62)
        txtUpdateTypeCode.MaxLength = 20
        txtUpdateTypeCode.Name = "txtUpdateTypeCode"
        txtUpdateTypeCode.Size = New Size(200, 26)
        txtUpdateTypeCode.TabIndex = 3
        ' 
        ' lblUpdateDefaultWeight
        ' 
        lblUpdateDefaultWeight.AutoSize = True
        lblUpdateDefaultWeight.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateDefaultWeight.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateDefaultWeight.Location = New Point(30, 110)
        lblUpdateDefaultWeight.Name = "lblUpdateDefaultWeight"
        lblUpdateDefaultWeight.Size = New Size(200, 19)
        lblUpdateDefaultWeight.TabIndex = 4
        lblUpdateDefaultWeight.Text = "Default Weight (0-100) *"
        ' 
        ' txtUpdateDefaultWeight
        ' 
        txtUpdateDefaultWeight.Font = New Font("Times New Roman", 12.0F)
        txtUpdateDefaultWeight.Location = New Point(30, 132)
        txtUpdateDefaultWeight.MaxLength = 6
        txtUpdateDefaultWeight.Name = "txtUpdateDefaultWeight"
        txtUpdateDefaultWeight.Size = New Size(150, 26)
        txtUpdateDefaultWeight.TabIndex = 5
        ' 
        ' lblUpdateDescription
        ' 
        lblUpdateDescription.AutoSize = True
        lblUpdateDescription.Font = New Font("Times New Roman", 12.0F)
        lblUpdateDescription.Location = New Point(30, 180)
        lblUpdateDescription.Name = "lblUpdateDescription"
        lblUpdateDescription.Size = New Size(80, 19)
        lblUpdateDescription.TabIndex = 6
        lblUpdateDescription.Text = "Description"
        ' 
        ' txtUpdateDescription
        ' 
        txtUpdateDescription.Font = New Font("Times New Roman", 12.0F)
        txtUpdateDescription.Location = New Point(30, 202)
        txtUpdateDescription.MaxLength = 255
        txtUpdateDescription.Multiline = True
        txtUpdateDescription.Name = "txtUpdateDescription"
        txtUpdateDescription.Size = New Size(640, 80)
        txtUpdateDescription.TabIndex = 7
        ' 
        ' lblUpdateDisplayOrder
        ' 
        lblUpdateDisplayOrder.AutoSize = True
        lblUpdateDisplayOrder.Font = New Font("Times New Roman", 12.0F)
        lblUpdateDisplayOrder.Location = New Point(30, 300)
        lblUpdateDisplayOrder.Name = "lblUpdateDisplayOrder"
        lblUpdateDisplayOrder.Size = New Size(99, 19)
        lblUpdateDisplayOrder.TabIndex = 8
        lblUpdateDisplayOrder.Text = "Display Order"
        ' 
        ' txtUpdateDisplayOrder
        ' 
        txtUpdateDisplayOrder.Font = New Font("Times New Roman", 12.0F)
        txtUpdateDisplayOrder.Location = New Point(30, 322)
        txtUpdateDisplayOrder.MaxLength = 5
        txtUpdateDisplayOrder.Name = "txtUpdateDisplayOrder"
        txtUpdateDisplayOrder.Size = New Size(150, 26)
        txtUpdateDisplayOrder.TabIndex = 9
        ' 
        ' chkUpdateIsActive
        ' 
        chkUpdateIsActive.AutoSize = True
        chkUpdateIsActive.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        chkUpdateIsActive.Location = New Point(30, 370)
        chkUpdateIsActive.Name = "chkUpdateIsActive"
        chkUpdateIsActive.Size = New Size(114, 23)
        chkUpdateIsActive.TabIndex = 10
        chkUpdateIsActive.Text = "Set as Active"
        chkUpdateIsActive.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateAssignmentType
        ' 
        btnUpdateAssignmentType.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnUpdateAssignmentType.FlatStyle = FlatStyle.Flat
        btnUpdateAssignmentType.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnUpdateAssignmentType.ForeColor = Color.White
        btnUpdateAssignmentType.Location = New Point(30, 420)
        btnUpdateAssignmentType.Name = "btnUpdateAssignmentType"
        btnUpdateAssignmentType.Size = New Size(240, 45)
        btnUpdateAssignmentType.TabIndex = 11
        btnUpdateAssignmentType.Text = "Update Assignment Type"
        btnUpdateAssignmentType.UseVisualStyleBackColor = False
        btnUpdateAssignmentType.Visible = False
        ' 
        ' btnDeleteAssignmentType
        ' 
        btnDeleteAssignmentType.BackColor = Color.FromArgb(CByte(255), CByte(71), CByte(71))
        btnDeleteAssignmentType.FlatStyle = FlatStyle.Flat
        btnDeleteAssignmentType.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnDeleteAssignmentType.ForeColor = Color.White
        btnDeleteAssignmentType.Location = New Point(290, 420)
        btnDeleteAssignmentType.Name = "btnDeleteAssignmentType"
        btnDeleteAssignmentType.Size = New Size(240, 45)
        btnDeleteAssignmentType.TabIndex = 12
        btnDeleteAssignmentType.Text = "Delete Assignment Type"
        btnDeleteAssignmentType.UseVisualStyleBackColor = False
        btnDeleteAssignmentType.Visible = False
        ' 
        ' AssignmentType
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "AssignmentType"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Assignment Type Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlCreateAssignmentType.ResumeLayout(False)
        pnlCreateAssignmentType.PerformLayout()
        pnlViewAssignmentTypes.ResumeLayout(False)
        pnlViewAssignmentTypes.PerformLayout()
        CType(dgvAssignmentTypes, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteAssignmentType.ResumeLayout(False)
        pnlUpdateDeleteAssignmentType.PerformLayout()
        grpAssignmentTypeInfo.ResumeLayout(False)
        grpAssignmentTypeInfo.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblAssignmentTypeTitle As Label
    Friend WithEvents btnCreateAssignmentType As Button
    Friend WithEvents btnUpdateDeleteAssignmentType As Button
    Friend WithEvents btnViewAssignmentTypes As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Create Panel
    Friend WithEvents pnlCreateAssignmentType As Panel
    Friend WithEvents lblCreateTitle As Label
    Friend WithEvents lblTypeName As Label
    Friend WithEvents txtTypeName As TextBox
    Friend WithEvents lblTypeCode As Label
    Friend WithEvents txtTypeCode As TextBox
    Friend WithEvents lblDefaultWeight As Label
    Friend WithEvents txtDefaultWeight As TextBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblDisplayOrder As Label
    Friend WithEvents txtDisplayOrder As TextBox
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents btnSubmitAssignmentType As Button

    ' View Panel
    Friend WithEvents pnlViewAssignmentTypes As Panel
    Friend WithEvents lblViewTitle As Label
    Friend WithEvents dgvAssignmentTypes As DataGridView
    Friend WithEvents btnRefreshAssignmentTypes As Button

    ' Update/Delete Panel
    Friend WithEvents pnlUpdateDeleteAssignmentType As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectAssignmentType As Label
    Friend WithEvents cmbSelectAssignmentType As ComboBox
    Friend WithEvents btnLoadAssignmentTypeData As Button
    Friend WithEvents grpAssignmentTypeInfo As GroupBox
    Friend WithEvents lblUpdateTypeName As Label
    Friend WithEvents txtUpdateTypeName As TextBox
    Friend WithEvents lblUpdateTypeCode As Label
    Friend WithEvents txtUpdateTypeCode As TextBox
    Friend WithEvents lblUpdateDefaultWeight As Label
    Friend WithEvents txtUpdateDefaultWeight As TextBox
    Friend WithEvents lblUpdateDescription As Label
    Friend WithEvents txtUpdateDescription As TextBox
    Friend WithEvents lblUpdateDisplayOrder As Label
    Friend WithEvents txtUpdateDisplayOrder As TextBox
    Friend WithEvents chkUpdateIsActive As CheckBox
    Friend WithEvents btnUpdateAssignmentType As Button
    Friend WithEvents btnDeleteAssignmentType As Button
End Class
