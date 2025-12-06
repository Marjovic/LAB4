<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OfferingGradeWeight
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
        btnCreateWeight = New Button()
        btnUpdateDeleteWeight = New Button()
        btnViewWeights = New Button()
        lblWeightTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlCreateWeight = New Panel()
        lblCreateTitle = New Label()
        lblOffering = New Label()
        cmbOffering = New ComboBox()
        lblAssignmentType = New Label()
        cmbAssignmentType = New ComboBox()
        lblGradingPeriod = New Label()
        cmbGradingPeriod = New ComboBox()
        lblCustomWeight = New Label()
        txtCustomWeight = New TextBox()
        lblMaxScore = New Label()
        txtMaxScore = New TextBox()
        lblNotes = New Label()
        txtNotes = New TextBox()
        btnSubmitWeight = New Button()
        pnlViewWeights = New Panel()
        dgvWeights = New DataGridView()
        lblViewTitle = New Label()
        btnRefreshWeights = New Button()
        pnlUpdateDeleteWeight = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectWeight = New Label()
        cmbSelectWeight = New ComboBox()
        btnLoadWeightData = New Button()
        grpWeightInfo = New GroupBox()
        lblUpdateOffering = New Label()
        cmbUpdateOffering = New ComboBox()
        lblUpdateAssignmentType = New Label()
        cmbUpdateAssignmentType = New ComboBox()
        lblUpdateGradingPeriod = New Label()
        cmbUpdateGradingPeriod = New ComboBox()
        lblUpdateCustomWeight = New Label()
        txtUpdateCustomWeight = New TextBox()
        lblUpdateMaxScore = New Label()
        txtUpdateMaxScore = New TextBox()
        lblUpdateNotes = New Label()
        txtUpdateNotes = New TextBox()
        btnUpdateWeight = New Button()
        btnDeleteWeight = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlCreateWeight.SuspendLayout()
        pnlViewWeights.SuspendLayout()
        CType(dgvWeights, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteWeight.SuspendLayout()
        grpWeightInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnViewWeights)
        pnlSidebar.Controls.Add(btnUpdateDeleteWeight)
        pnlSidebar.Controls.Add(btnCreateWeight)
        pnlSidebar.Controls.Add(lblWeightTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCreateWeight
        ' 
        btnCreateWeight.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateWeight.Dock = DockStyle.Top
        btnCreateWeight.FlatAppearance.BorderSize = 0
        btnCreateWeight.FlatStyle = FlatStyle.Flat
        btnCreateWeight.Font = New Font("Times New Roman", 11.0F)
        btnCreateWeight.ForeColor = Color.White
        btnCreateWeight.Location = New Point(0, 80)
        btnCreateWeight.Name = "btnCreateWeight"
        btnCreateWeight.Size = New Size(220, 50)
        btnCreateWeight.TabIndex = 1
        btnCreateWeight.Text = "+ Create Grade Weight"
        btnCreateWeight.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteWeight
        ' 
        btnUpdateDeleteWeight.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteWeight.Dock = DockStyle.Top
        btnUpdateDeleteWeight.FlatAppearance.BorderSize = 0
        btnUpdateDeleteWeight.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteWeight.Font = New Font("Times New Roman", 11.0F)
        btnUpdateDeleteWeight.ForeColor = Color.White
        btnUpdateDeleteWeight.Location = New Point(0, 130)
        btnUpdateDeleteWeight.Name = "btnUpdateDeleteWeight"
        btnUpdateDeleteWeight.Size = New Size(220, 50)
        btnUpdateDeleteWeight.TabIndex = 2
        btnUpdateDeleteWeight.Text = "Update/Delete Weight"
        btnUpdateDeleteWeight.UseVisualStyleBackColor = False
        ' 
        ' btnViewWeights
        ' 
        btnViewWeights.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewWeights.Dock = DockStyle.Top
        btnViewWeights.FlatAppearance.BorderSize = 0
        btnViewWeights.FlatStyle = FlatStyle.Flat
        btnViewWeights.Font = New Font("Times New Roman", 11.0F)
        btnViewWeights.ForeColor = Color.White
        btnViewWeights.Location = New Point(0, 180)
        btnViewWeights.Name = "btnViewWeights"
        btnViewWeights.Size = New Size(220, 50)
        btnViewWeights.TabIndex = 3
        btnViewWeights.Text = "View Grade Weights"
        btnViewWeights.UseVisualStyleBackColor = False
        ' 
        ' lblWeightTitle
        ' 
        lblWeightTitle.BackColor = Color.Navy
        lblWeightTitle.Dock = DockStyle.Top
        lblWeightTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblWeightTitle.ForeColor = Color.White
        lblWeightTitle.Location = New Point(0, 0)
        lblWeightTitle.Name = "lblWeightTitle"
        lblWeightTitle.Size = New Size(220, 80)
        lblWeightTitle.TabIndex = 0
        lblWeightTitle.Text = "Offering Grade Weight Management"
        lblWeightTitle.TextAlign = ContentAlignment.MiddleCenter
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
        pnlMainContent.Controls.Add(pnlCreateWeight)
        pnlMainContent.Controls.Add(pnlViewWeights)
        pnlMainContent.Controls.Add(pnlUpdateDeleteWeight)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlCreateWeight
        ' 
        pnlCreateWeight.AutoScroll = True
        pnlCreateWeight.BackColor = Color.White
        pnlCreateWeight.Controls.Add(lblCreateTitle)
        pnlCreateWeight.Controls.Add(lblOffering)
        pnlCreateWeight.Controls.Add(cmbOffering)
        pnlCreateWeight.Controls.Add(lblAssignmentType)
        pnlCreateWeight.Controls.Add(cmbAssignmentType)
        pnlCreateWeight.Controls.Add(lblGradingPeriod)
        pnlCreateWeight.Controls.Add(cmbGradingPeriod)
        pnlCreateWeight.Controls.Add(lblCustomWeight)
        pnlCreateWeight.Controls.Add(txtCustomWeight)
        pnlCreateWeight.Controls.Add(lblMaxScore)
        pnlCreateWeight.Controls.Add(txtMaxScore)
        pnlCreateWeight.Controls.Add(lblNotes)
        pnlCreateWeight.Controls.Add(txtNotes)
        pnlCreateWeight.Controls.Add(btnSubmitWeight)
        pnlCreateWeight.Dock = DockStyle.Fill
        pnlCreateWeight.Location = New Point(0, 0)
        pnlCreateWeight.Name = "pnlCreateWeight"
        pnlCreateWeight.Padding = New Padding(30, 20, 30, 20)
        pnlCreateWeight.Size = New Size(980, 800)
        pnlCreateWeight.TabIndex = 0
        pnlCreateWeight.Visible = False
        ' 
        ' lblCreateTitle
        ' 
        lblCreateTitle.AutoSize = True
        lblCreateTitle.Font = New Font("Times New Roman", 20.0F, FontStyle.Bold)
        lblCreateTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateTitle.Location = New Point(30, 20)
        lblCreateTitle.Name = "lblCreateTitle"
        lblCreateTitle.Size = New Size(428, 31)
        lblCreateTitle.TabIndex = 0
        lblCreateTitle.Text = "Create New Offering Grade Weight"
        ' 
        ' lblOffering
        ' 
        lblOffering.AutoSize = True
        lblOffering.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblOffering.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblOffering.Location = New Point(50, 75)
        lblOffering.Name = "lblOffering"
        lblOffering.Size = New Size(136, 19)
        lblOffering.TabIndex = 1
        lblOffering.Text = "Course Offering *"
        ' 
        ' cmbOffering
        ' 
        cmbOffering.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOffering.Font = New Font("Times New Roman", 12.0F)
        cmbOffering.FormattingEnabled = True
        cmbOffering.Location = New Point(50, 97)
        cmbOffering.Name = "cmbOffering"
        cmbOffering.Size = New Size(650, 27)
        cmbOffering.TabIndex = 2
        ' 
        ' lblAssignmentType
        ' 
        lblAssignmentType.AutoSize = True
        lblAssignmentType.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblAssignmentType.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblAssignmentType.Location = New Point(50, 145)
        lblAssignmentType.Name = "lblAssignmentType"
        lblAssignmentType.Size = New Size(142, 19)
        lblAssignmentType.TabIndex = 3
        lblAssignmentType.Text = "Assignment Type *"
        ' 
        ' cmbAssignmentType
        ' 
        cmbAssignmentType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbAssignmentType.Font = New Font("Times New Roman", 12.0F)
        cmbAssignmentType.FormattingEnabled = True
        cmbAssignmentType.Location = New Point(50, 167)
        cmbAssignmentType.Name = "cmbAssignmentType"
        cmbAssignmentType.Size = New Size(400, 27)
        cmbAssignmentType.TabIndex = 4
        ' 
        ' lblGradingPeriod
        ' 
        lblGradingPeriod.AutoSize = True
        lblGradingPeriod.Font = New Font("Times New Roman", 12.0F)
        lblGradingPeriod.Location = New Point(500, 145)
        lblGradingPeriod.Name = "lblGradingPeriod"
        lblGradingPeriod.Size = New Size(176, 19)
        lblGradingPeriod.TabIndex = 5
        lblGradingPeriod.Text = "Grading Period (Optional)"
        ' 
        ' cmbGradingPeriod
        ' 
        cmbGradingPeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cmbGradingPeriod.Font = New Font("Times New Roman", 12.0F)
        cmbGradingPeriod.FormattingEnabled = True
        cmbGradingPeriod.Location = New Point(500, 167)
        cmbGradingPeriod.Name = "cmbGradingPeriod"
        cmbGradingPeriod.Size = New Size(250, 27)
        cmbGradingPeriod.TabIndex = 6
        ' 
        ' lblCustomWeight
        ' 
        lblCustomWeight.AutoSize = True
        lblCustomWeight.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblCustomWeight.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblCustomWeight.Location = New Point(50, 215)
        lblCustomWeight.Name = "lblCustomWeight"
        lblCustomWeight.Size = New Size(194, 19)
        lblCustomWeight.TabIndex = 7
        lblCustomWeight.Text = "Custom Weight (0-100) *"
        ' 
        ' txtCustomWeight
        ' 
        txtCustomWeight.Font = New Font("Times New Roman", 12.0F)
        txtCustomWeight.Location = New Point(50, 237)
        txtCustomWeight.MaxLength = 6
        txtCustomWeight.Name = "txtCustomWeight"
        txtCustomWeight.Size = New Size(150, 26)
        txtCustomWeight.TabIndex = 8
        txtCustomWeight.Text = "0.00"
        ' 
        ' lblMaxScore
        ' 
        lblMaxScore.AutoSize = True
        lblMaxScore.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblMaxScore.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblMaxScore.Location = New Point(250, 215)
        lblMaxScore.Name = "lblMaxScore"
        lblMaxScore.Size = New Size(98, 19)
        lblMaxScore.TabIndex = 9
        lblMaxScore.Text = "Max Score *"
        ' 
        ' txtMaxScore
        ' 
        txtMaxScore.Font = New Font("Times New Roman", 12.0F)
        txtMaxScore.Location = New Point(250, 237)
        txtMaxScore.MaxLength = 6
        txtMaxScore.Name = "txtMaxScore"
        txtMaxScore.Size = New Size(150, 26)
        txtMaxScore.TabIndex = 10
        txtMaxScore.Text = "100.00"
        ' 
        ' lblNotes
        ' 
        lblNotes.AutoSize = True
        lblNotes.Font = New Font("Times New Roman", 12.0F)
        lblNotes.Location = New Point(50, 285)
        lblNotes.Name = "lblNotes"
        lblNotes.Size = New Size(120, 19)
        lblNotes.TabIndex = 11
        lblNotes.Text = "Notes (Optional)"
        ' 
        ' txtNotes
        ' 
        txtNotes.Font = New Font("Times New Roman", 12.0F)
        txtNotes.Location = New Point(50, 307)
        txtNotes.MaxLength = 255
        txtNotes.Multiline = True
        txtNotes.Name = "txtNotes"
        txtNotes.Size = New Size(700, 80)
        txtNotes.TabIndex = 12
        ' 
        ' btnSubmitWeight
        ' 
        btnSubmitWeight.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnSubmitWeight.FlatStyle = FlatStyle.Flat
        btnSubmitWeight.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnSubmitWeight.ForeColor = Color.White
        btnSubmitWeight.Location = New Point(50, 410)
        btnSubmitWeight.Name = "btnSubmitWeight"
        btnSubmitWeight.Size = New Size(240, 45)
        btnSubmitWeight.TabIndex = 13
        btnSubmitWeight.Text = "+ Create Grade Weight"
        btnSubmitWeight.UseVisualStyleBackColor = False
        ' 
        ' pnlViewWeights
        ' 
        pnlViewWeights.BackColor = Color.White
        pnlViewWeights.Controls.Add(dgvWeights)
        pnlViewWeights.Controls.Add(lblViewTitle)
        pnlViewWeights.Controls.Add(btnRefreshWeights)
        pnlViewWeights.Dock = DockStyle.Fill
        pnlViewWeights.Location = New Point(0, 0)
        pnlViewWeights.Name = "pnlViewWeights"
        pnlViewWeights.Padding = New Padding(20)
        pnlViewWeights.Size = New Size(980, 800)
        pnlViewWeights.TabIndex = 1
        pnlViewWeights.Visible = False
        ' 
        ' dgvWeights
        ' 
        dgvWeights.AllowUserToAddRows = False
        dgvWeights.AllowUserToDeleteRows = False
        dgvWeights.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvWeights.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvWeights.BackgroundColor = SystemColors.Control
        dgvWeights.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvWeights.Location = New Point(23, 70)
        dgvWeights.Name = "dgvWeights"
        dgvWeights.ReadOnly = True
        dgvWeights.Size = New Size(934, 690)
        dgvWeights.TabIndex = 1
        ' 
        ' lblViewTitle
        ' 
        lblViewTitle.AutoSize = True
        lblViewTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblViewTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewTitle.Location = New Point(23, 20)
        lblViewTitle.Name = "lblViewTitle"
        lblViewTitle.Size = New Size(447, 36)
        lblViewTitle.TabIndex = 0
        lblViewTitle.Text = "All Offering Grade Weights"
        ' 
        ' btnRefreshWeights
        ' 
        btnRefreshWeights.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshWeights.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshWeights.FlatStyle = FlatStyle.Flat
        btnRefreshWeights.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnRefreshWeights.ForeColor = Color.White
        btnRefreshWeights.Location = New Point(797, 20)
        btnRefreshWeights.Name = "btnRefreshWeights"
        btnRefreshWeights.Size = New Size(160, 40)
        btnRefreshWeights.TabIndex = 2
        btnRefreshWeights.Text = "🔄 Refresh"
        btnRefreshWeights.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteWeight
        ' 
        pnlUpdateDeleteWeight.AutoScroll = True
        pnlUpdateDeleteWeight.BackColor = Color.White
        pnlUpdateDeleteWeight.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteWeight.Controls.Add(lblSelectWeight)
        pnlUpdateDeleteWeight.Controls.Add(cmbSelectWeight)
        pnlUpdateDeleteWeight.Controls.Add(btnLoadWeightData)
        pnlUpdateDeleteWeight.Controls.Add(grpWeightInfo)
        pnlUpdateDeleteWeight.Dock = DockStyle.Fill
        pnlUpdateDeleteWeight.Location = New Point(0, 0)
        pnlUpdateDeleteWeight.Name = "pnlUpdateDeleteWeight"
        pnlUpdateDeleteWeight.Padding = New Padding(20)
        pnlUpdateDeleteWeight.Size = New Size(980, 800)
        pnlUpdateDeleteWeight.TabIndex = 2
        pnlUpdateDeleteWeight.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(587, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete Offering Grade Weight"
        ' 
        ' lblSelectWeight
        ' 
        lblSelectWeight.AutoSize = True
        lblSelectWeight.Font = New Font("Times New Roman", 14.0F)
        lblSelectWeight.Location = New Point(40, 80)
        lblSelectWeight.Name = "lblSelectWeight"
        lblSelectWeight.Size = New Size(181, 21)
        lblSelectWeight.TabIndex = 1
        lblSelectWeight.Text = "Select Offering Weight"
        ' 
        ' cmbSelectWeight
        ' 
        cmbSelectWeight.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectWeight.Font = New Font("Times New Roman", 12.0F)
        cmbSelectWeight.FormattingEnabled = True
        cmbSelectWeight.Location = New Point(40, 105)
        cmbSelectWeight.Name = "cmbSelectWeight"
        cmbSelectWeight.Size = New Size(700, 27)
        cmbSelectWeight.TabIndex = 2
        ' 
        ' btnLoadWeightData
        ' 
        btnLoadWeightData.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadWeightData.FlatStyle = FlatStyle.Flat
        btnLoadWeightData.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnLoadWeightData.ForeColor = Color.White
        btnLoadWeightData.Location = New Point(760, 105)
        btnLoadWeightData.Name = "btnLoadWeightData"
        btnLoadWeightData.Size = New Size(140, 29)
        btnLoadWeightData.TabIndex = 3
        btnLoadWeightData.Text = "Load Data"
        btnLoadWeightData.UseVisualStyleBackColor = False
        ' 
        ' grpWeightInfo
        ' 
        grpWeightInfo.Controls.Add(lblUpdateOffering)
        grpWeightInfo.Controls.Add(cmbUpdateOffering)
        grpWeightInfo.Controls.Add(lblUpdateAssignmentType)
        grpWeightInfo.Controls.Add(cmbUpdateAssignmentType)
        grpWeightInfo.Controls.Add(lblUpdateGradingPeriod)
        grpWeightInfo.Controls.Add(cmbUpdateGradingPeriod)
        grpWeightInfo.Controls.Add(lblUpdateCustomWeight)
        grpWeightInfo.Controls.Add(txtUpdateCustomWeight)
        grpWeightInfo.Controls.Add(lblUpdateMaxScore)
        grpWeightInfo.Controls.Add(txtUpdateMaxScore)
        grpWeightInfo.Controls.Add(lblUpdateNotes)
        grpWeightInfo.Controls.Add(txtUpdateNotes)
        grpWeightInfo.Controls.Add(btnUpdateWeight)
        grpWeightInfo.Controls.Add(btnDeleteWeight)
        grpWeightInfo.Location = New Point(40, 150)
        grpWeightInfo.Name = "grpWeightInfo"
        grpWeightInfo.Size = New Size(900, 580)
        grpWeightInfo.TabIndex = 4
        grpWeightInfo.TabStop = False
        grpWeightInfo.Text = "Offering Grade Weight Information"
        grpWeightInfo.Visible = False
        ' 
        ' lblUpdateOffering
        ' 
        lblUpdateOffering.AutoSize = True
        lblUpdateOffering.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateOffering.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateOffering.Location = New Point(30, 40)
        lblUpdateOffering.Name = "lblUpdateOffering"
        lblUpdateOffering.Size = New Size(136, 19)
        lblUpdateOffering.TabIndex = 0
        lblUpdateOffering.Text = "Course Offering *"
        ' 
        ' cmbUpdateOffering
        ' 
        cmbUpdateOffering.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateOffering.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateOffering.FormattingEnabled = True
        cmbUpdateOffering.Location = New Point(30, 62)
        cmbUpdateOffering.Name = "cmbUpdateOffering"
        cmbUpdateOffering.Size = New Size(640, 27)
        cmbUpdateOffering.TabIndex = 1
        ' 
        ' lblUpdateAssignmentType
        ' 
        lblUpdateAssignmentType.AutoSize = True
        lblUpdateAssignmentType.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateAssignmentType.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateAssignmentType.Location = New Point(30, 110)
        lblUpdateAssignmentType.Name = "lblUpdateAssignmentType"
        lblUpdateAssignmentType.Size = New Size(142, 19)
        lblUpdateAssignmentType.TabIndex = 2
        lblUpdateAssignmentType.Text = "Assignment Type *"
        ' 
        ' cmbUpdateAssignmentType
        ' 
        cmbUpdateAssignmentType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateAssignmentType.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateAssignmentType.FormattingEnabled = True
        cmbUpdateAssignmentType.Location = New Point(30, 132)
        cmbUpdateAssignmentType.Name = "cmbUpdateAssignmentType"
        cmbUpdateAssignmentType.Size = New Size(400, 27)
        cmbUpdateAssignmentType.TabIndex = 3
        ' 
        ' lblUpdateGradingPeriod
        ' 
        lblUpdateGradingPeriod.AutoSize = True
        lblUpdateGradingPeriod.Font = New Font("Times New Roman", 12.0F)
        lblUpdateGradingPeriod.Location = New Point(470, 110)
        lblUpdateGradingPeriod.Name = "lblUpdateGradingPeriod"
        lblUpdateGradingPeriod.Size = New Size(107, 19)
        lblUpdateGradingPeriod.TabIndex = 4
        lblUpdateGradingPeriod.Text = "Grading Period"
        ' 
        ' cmbUpdateGradingPeriod
        ' 
        cmbUpdateGradingPeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateGradingPeriod.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateGradingPeriod.FormattingEnabled = True
        cmbUpdateGradingPeriod.Location = New Point(470, 132)
        cmbUpdateGradingPeriod.Name = "cmbUpdateGradingPeriod"
        cmbUpdateGradingPeriod.Size = New Size(250, 27)
        cmbUpdateGradingPeriod.TabIndex = 5
        ' 
        ' lblUpdateCustomWeight
        ' 
        lblUpdateCustomWeight.AutoSize = True
        lblUpdateCustomWeight.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateCustomWeight.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateCustomWeight.Location = New Point(30, 180)
        lblUpdateCustomWeight.Name = "lblUpdateCustomWeight"
        lblUpdateCustomWeight.Size = New Size(194, 19)
        lblUpdateCustomWeight.TabIndex = 6
        lblUpdateCustomWeight.Text = "Custom Weight (0-100) *"
        ' 
        ' txtUpdateCustomWeight
        ' 
        txtUpdateCustomWeight.Font = New Font("Times New Roman", 12.0F)
        txtUpdateCustomWeight.Location = New Point(30, 202)
        txtUpdateCustomWeight.MaxLength = 6
        txtUpdateCustomWeight.Name = "txtUpdateCustomWeight"
        txtUpdateCustomWeight.Size = New Size(150, 26)
        txtUpdateCustomWeight.TabIndex = 7
        ' 
        ' lblUpdateMaxScore
        ' 
        lblUpdateMaxScore.AutoSize = True
        lblUpdateMaxScore.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateMaxScore.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateMaxScore.Location = New Point(230, 180)
        lblUpdateMaxScore.Name = "lblUpdateMaxScore"
        lblUpdateMaxScore.Size = New Size(98, 19)
        lblUpdateMaxScore.TabIndex = 8
        lblUpdateMaxScore.Text = "Max Score *"
        ' 
        ' txtUpdateMaxScore
        ' 
        txtUpdateMaxScore.Font = New Font("Times New Roman", 12.0F)
        txtUpdateMaxScore.Location = New Point(230, 202)
        txtUpdateMaxScore.MaxLength = 6
        txtUpdateMaxScore.Name = "txtUpdateMaxScore"
        txtUpdateMaxScore.Size = New Size(150, 26)
        txtUpdateMaxScore.TabIndex = 9
        ' 
        ' lblUpdateNotes
        ' 
        lblUpdateNotes.AutoSize = True
        lblUpdateNotes.Font = New Font("Times New Roman", 12.0F)
        lblUpdateNotes.Location = New Point(30, 250)
        lblUpdateNotes.Name = "lblUpdateNotes"
        lblUpdateNotes.Size = New Size(45, 19)
        lblUpdateNotes.TabIndex = 10
        lblUpdateNotes.Text = "Notes"
        ' 
        ' txtUpdateNotes
        ' 
        txtUpdateNotes.Font = New Font("Times New Roman", 12.0F)
        txtUpdateNotes.Location = New Point(30, 272)
        txtUpdateNotes.MaxLength = 255
        txtUpdateNotes.Multiline = True
        txtUpdateNotes.Name = "txtUpdateNotes"
        txtUpdateNotes.Size = New Size(690, 80)
        txtUpdateNotes.TabIndex = 11
        ' 
        ' btnUpdateWeight
        ' 
        btnUpdateWeight.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnUpdateWeight.FlatStyle = FlatStyle.Flat
        btnUpdateWeight.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnUpdateWeight.ForeColor = Color.White
        btnUpdateWeight.Location = New Point(30, 380)
        btnUpdateWeight.Name = "btnUpdateWeight"
        btnUpdateWeight.Size = New Size(240, 45)
        btnUpdateWeight.TabIndex = 12
        btnUpdateWeight.Text = "Update Grade Weight"
        btnUpdateWeight.UseVisualStyleBackColor = False
        btnUpdateWeight.Visible = False
        ' 
        ' btnDeleteWeight
        ' 
        btnDeleteWeight.BackColor = Color.FromArgb(CByte(255), CByte(71), CByte(71))
        btnDeleteWeight.FlatStyle = FlatStyle.Flat
        btnDeleteWeight.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnDeleteWeight.ForeColor = Color.White
        btnDeleteWeight.Location = New Point(290, 380)
        btnDeleteWeight.Name = "btnDeleteWeight"
        btnDeleteWeight.Size = New Size(240, 45)
        btnDeleteWeight.TabIndex = 13
        btnDeleteWeight.Text = "Delete Grade Weight"
        btnDeleteWeight.UseVisualStyleBackColor = False
        btnDeleteWeight.Visible = False
        ' 
        ' OfferingGradeWeight
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "OfferingGradeWeight"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Offering Grade Weight Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlCreateWeight.ResumeLayout(False)
        pnlCreateWeight.PerformLayout()
        pnlViewWeights.ResumeLayout(False)
        pnlViewWeights.PerformLayout()
        CType(dgvWeights, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteWeight.ResumeLayout(False)
        pnlUpdateDeleteWeight.PerformLayout()
        grpWeightInfo.ResumeLayout(False)
        grpWeightInfo.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblWeightTitle As Label
    Friend WithEvents btnCreateWeight As Button
    Friend WithEvents btnUpdateDeleteWeight As Button
    Friend WithEvents btnViewWeights As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Create Panel
    Friend WithEvents pnlCreateWeight As Panel
    Friend WithEvents lblCreateTitle As Label
    Friend WithEvents lblOffering As Label
    Friend WithEvents cmbOffering As ComboBox
    Friend WithEvents lblAssignmentType As Label
    Friend WithEvents cmbAssignmentType As ComboBox
    Friend WithEvents lblGradingPeriod As Label
    Friend WithEvents cmbGradingPeriod As ComboBox
    Friend WithEvents lblCustomWeight As Label
    Friend WithEvents txtCustomWeight As TextBox
    Friend WithEvents lblMaxScore As Label
    Friend WithEvents txtMaxScore As TextBox
    Friend WithEvents lblNotes As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents btnSubmitWeight As Button

    ' View Panel
    Friend WithEvents pnlViewWeights As Panel
    Friend WithEvents lblViewTitle As Label
    Friend WithEvents dgvWeights As DataGridView
    Friend WithEvents btnRefreshWeights As Button

    ' Update/Delete Panel
    Friend WithEvents pnlUpdateDeleteWeight As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectWeight As Label
    Friend WithEvents cmbSelectWeight As ComboBox
    Friend WithEvents btnLoadWeightData As Button
    Friend WithEvents grpWeightInfo As GroupBox
    Friend WithEvents lblUpdateOffering As Label
    Friend WithEvents cmbUpdateOffering As ComboBox
    Friend WithEvents lblUpdateAssignmentType As Label
    Friend WithEvents cmbUpdateAssignmentType As ComboBox
    Friend WithEvents lblUpdateGradingPeriod As Label
    Friend WithEvents cmbUpdateGradingPeriod As ComboBox
    Friend WithEvents lblUpdateCustomWeight As Label
    Friend WithEvents txtUpdateCustomWeight As TextBox
    Friend WithEvents lblUpdateMaxScore As Label
    Friend WithEvents txtUpdateMaxScore As TextBox
    Friend WithEvents lblUpdateNotes As Label
    Friend WithEvents txtUpdateNotes As TextBox
    Friend WithEvents btnUpdateWeight As Button
    Friend WithEvents btnDeleteWeight As Button
End Class
