<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CourseOffering
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
        btnCreateOffering = New Button()
        btnUpdateDeleteOffering = New Button()
        btnViewOfferings = New Button()
        lblOfferingTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlCreateOffering = New Panel()
        lblCreateOfferingTitle = New Label()
        lblCourse = New Label()
        cmbCourse = New ComboBox()
        lblSemester = New Label()
        cmbSemester = New ComboBox()
        lblTerm = New Label()
        cmbTerm = New ComboBox()
        lblInstructor = New Label()
        cmbInstructor = New ComboBox()
        lblSection = New Label()
        txtSection = New TextBox()
        lblMaxStudents = New Label()
        txtMaxStudents = New TextBox()
        lblSchedule = New Label()
        txtSchedule = New TextBox()
        lblRoom = New Label()
        txtRoom = New TextBox()
        lblOfferingStatus = New Label()
        cmbOfferingStatus = New ComboBox()
        btnSubmitOffering = New Button()
        pnlViewOfferings = New Panel()
        dgvOfferings = New DataGridView()
        lblViewOfferingsTitle = New Label()
        btnRefreshOfferings = New Button()
        pnlUpdateDeleteOffering = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectOffering = New Label()
        cmbSelectOffering = New ComboBox()
        btnLoadOfferingData = New Button()
        grpOfferingInfo = New GroupBox()
        lblUpdateCourse = New Label()
        cmbUpdateCourse = New ComboBox()
        lblUpdateSemester = New Label()
        cmbUpdateSemester = New ComboBox()
        lblUpdateTerm = New Label()
        cmbUpdateTerm = New ComboBox()
        lblUpdateInstructor = New Label()
        cmbUpdateInstructor = New ComboBox()
        lblUpdateSection = New Label()
        txtUpdateSection = New TextBox()
        lblUpdateMaxStudents = New Label()
        txtUpdateMaxStudents = New TextBox()
        lblUpdateSchedule = New Label()
        txtUpdateSchedule = New TextBox()
        lblUpdateRoom = New Label()
        txtUpdateRoom = New TextBox()
        lblUpdateOfferingStatus = New Label()
        cmbUpdateOfferingStatus = New ComboBox()
        btnUpdateOffering = New Button()
        btnDeleteOffering = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlCreateOffering.SuspendLayout()
        pnlViewOfferings.SuspendLayout()
        CType(dgvOfferings, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteOffering.SuspendLayout()
        grpOfferingInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCreateOffering)
        pnlSidebar.Controls.Add(btnUpdateDeleteOffering)
        pnlSidebar.Controls.Add(btnViewOfferings)
        pnlSidebar.Controls.Add(lblOfferingTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCreateOffering
        ' 
        btnCreateOffering.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateOffering.Dock = DockStyle.Top
        btnCreateOffering.FlatAppearance.BorderSize = 0
        btnCreateOffering.FlatStyle = FlatStyle.Flat
        btnCreateOffering.Font = New Font("Times New Roman", 11F)
        btnCreateOffering.ForeColor = Color.White
        btnCreateOffering.Location = New Point(0, 180)
        btnCreateOffering.Name = "btnCreateOffering"
        btnCreateOffering.Size = New Size(220, 50)
        btnCreateOffering.TabIndex = 1
        btnCreateOffering.Text = "+ Create Course Offer"
        btnCreateOffering.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteOffering
        ' 
        btnUpdateDeleteOffering.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteOffering.Dock = DockStyle.Top
        btnUpdateDeleteOffering.FlatAppearance.BorderSize = 0
        btnUpdateDeleteOffering.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteOffering.Font = New Font("Times New Roman", 11F)
        btnUpdateDeleteOffering.ForeColor = Color.White
        btnUpdateDeleteOffering.Location = New Point(0, 130)
        btnUpdateDeleteOffering.Name = "btnUpdateDeleteOffering"
        btnUpdateDeleteOffering.Size = New Size(220, 50)
        btnUpdateDeleteOffering.TabIndex = 2
        btnUpdateDeleteOffering.Text = "Update/Delete Course Offer"
        btnUpdateDeleteOffering.UseVisualStyleBackColor = False
        ' 
        ' btnViewOfferings
        ' 
        btnViewOfferings.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewOfferings.Dock = DockStyle.Top
        btnViewOfferings.FlatAppearance.BorderSize = 0
        btnViewOfferings.FlatStyle = FlatStyle.Flat
        btnViewOfferings.Font = New Font("Times New Roman", 11F)
        btnViewOfferings.ForeColor = Color.White
        btnViewOfferings.Location = New Point(0, 80)
        btnViewOfferings.Name = "btnViewOfferings"
        btnViewOfferings.Size = New Size(220, 50)
        btnViewOfferings.TabIndex = 3
        btnViewOfferings.Text = "View Course Offers"
        btnViewOfferings.UseVisualStyleBackColor = False
        ' 
        ' lblOfferingTitle
        ' 
        lblOfferingTitle.BackColor = Color.Navy
        lblOfferingTitle.Dock = DockStyle.Top
        lblOfferingTitle.Font = New Font("Times New Roman", 13F, FontStyle.Bold)
        lblOfferingTitle.ForeColor = Color.White
        lblOfferingTitle.Location = New Point(0, 0)
        lblOfferingTitle.Name = "lblOfferingTitle"
        lblOfferingTitle.Size = New Size(220, 80)
        lblOfferingTitle.TabIndex = 0
        lblOfferingTitle.Text = "Course Offerings Management"
        lblOfferingTitle.TextAlign = ContentAlignment.MiddleCenter
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
        btnClose.Size = New Size(220, 50)
        btnClose.TabIndex = 4
        btnClose.Text = "🚪 Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlMainContent.Controls.Add(pnlCreateOffering)
        pnlMainContent.Controls.Add(pnlViewOfferings)
        pnlMainContent.Controls.Add(pnlUpdateDeleteOffering)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlCreateOffering
        ' 
        pnlCreateOffering.AutoScroll = True
        pnlCreateOffering.BackColor = Color.White
        pnlCreateOffering.Controls.Add(lblCreateOfferingTitle)
        pnlCreateOffering.Controls.Add(lblCourse)
        pnlCreateOffering.Controls.Add(cmbCourse)
        pnlCreateOffering.Controls.Add(lblSemester)
        pnlCreateOffering.Controls.Add(cmbSemester)
        pnlCreateOffering.Controls.Add(lblTerm)
        pnlCreateOffering.Controls.Add(cmbTerm)
        pnlCreateOffering.Controls.Add(lblInstructor)
        pnlCreateOffering.Controls.Add(cmbInstructor)
        pnlCreateOffering.Controls.Add(lblSection)
        pnlCreateOffering.Controls.Add(txtSection)
        pnlCreateOffering.Controls.Add(lblMaxStudents)
        pnlCreateOffering.Controls.Add(txtMaxStudents)
        pnlCreateOffering.Controls.Add(lblSchedule)
        pnlCreateOffering.Controls.Add(txtSchedule)
        pnlCreateOffering.Controls.Add(lblRoom)
        pnlCreateOffering.Controls.Add(txtRoom)
        pnlCreateOffering.Controls.Add(lblOfferingStatus)
        pnlCreateOffering.Controls.Add(cmbOfferingStatus)
        pnlCreateOffering.Controls.Add(btnSubmitOffering)
        pnlCreateOffering.Dock = DockStyle.Fill
        pnlCreateOffering.Location = New Point(0, 0)
        pnlCreateOffering.Name = "pnlCreateOffering"
        pnlCreateOffering.Padding = New Padding(30, 20, 30, 20)
        pnlCreateOffering.Size = New Size(980, 800)
        pnlCreateOffering.TabIndex = 0
        pnlCreateOffering.Visible = False
        ' 
        ' lblCreateOfferingTitle
        ' 
        lblCreateOfferingTitle.AutoSize = True
        lblCreateOfferingTitle.Font = New Font("Times New Roman", 20F, FontStyle.Bold)
        lblCreateOfferingTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateOfferingTitle.Location = New Point(30, 20)
        lblCreateOfferingTitle.Name = "lblCreateOfferingTitle"
        lblCreateOfferingTitle.Size = New Size(348, 31)
        lblCreateOfferingTitle.TabIndex = 0
        lblCreateOfferingTitle.Text = "Create New Course Offering"
        ' 
        ' lblCourse
        ' 
        lblCourse.AutoSize = True
        lblCourse.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblCourse.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblCourse.Location = New Point(50, 75)
        lblCourse.Name = "lblCourse"
        lblCourse.Size = New Size(69, 19)
        lblCourse.TabIndex = 1
        lblCourse.Text = "Course *"
        ' 
        ' cmbCourse
        ' 
        cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList
        cmbCourse.Font = New Font("Times New Roman", 12F)
        cmbCourse.FormattingEnabled = True
        cmbCourse.Location = New Point(50, 97)
        cmbCourse.Name = "cmbCourse"
        cmbCourse.Size = New Size(400, 27)
        cmbCourse.TabIndex = 2
        ' 
        ' lblSemester
        ' 
        lblSemester.AutoSize = True
        lblSemester.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblSemester.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblSemester.Location = New Point(500, 75)
        lblSemester.Name = "lblSemester"
        lblSemester.Size = New Size(84, 19)
        lblSemester.TabIndex = 3
        lblSemester.Text = "Semester *"
        ' 
        ' cmbSemester
        ' 
        cmbSemester.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSemester.Font = New Font("Times New Roman", 12F)
        cmbSemester.FormattingEnabled = True
        cmbSemester.Location = New Point(500, 97)
        cmbSemester.Name = "cmbSemester"
        cmbSemester.Size = New Size(400, 27)
        cmbSemester.TabIndex = 4
        ' 
        ' lblTerm
        ' 
        lblTerm.AutoSize = True
        lblTerm.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblTerm.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblTerm.Location = New Point(50, 145)
        lblTerm.Name = "lblTerm"
        lblTerm.Size = New Size(56, 19)
        lblTerm.TabIndex = 5
        lblTerm.Text = "Term *"
        ' 
        ' cmbTerm
        ' 
        cmbTerm.DropDownStyle = ComboBoxStyle.DropDownList
        cmbTerm.Font = New Font("Times New Roman", 12F)
        cmbTerm.FormattingEnabled = True
        cmbTerm.Location = New Point(50, 167)
        cmbTerm.Name = "cmbTerm"
        cmbTerm.Size = New Size(400, 27)
        cmbTerm.TabIndex = 6
        ' 
        ' lblInstructor
        ' 
        lblInstructor.AutoSize = True
        lblInstructor.Font = New Font("Times New Roman", 12F)
        lblInstructor.Location = New Point(500, 145)
        lblInstructor.Name = "lblInstructor"
        lblInstructor.Size = New Size(133, 19)
        lblInstructor.TabIndex = 7
        lblInstructor.Text = "Instructor (Optional)"
        ' 
        ' cmbInstructor
        ' 
        cmbInstructor.DropDownStyle = ComboBoxStyle.DropDownList
        cmbInstructor.Font = New Font("Times New Roman", 12F)
        cmbInstructor.FormattingEnabled = True
        cmbInstructor.Location = New Point(500, 167)
        cmbInstructor.Name = "cmbInstructor"
        cmbInstructor.Size = New Size(400, 27)
        cmbInstructor.TabIndex = 8
        ' 
        ' lblSection
        ' 
        lblSection.AutoSize = True
        lblSection.Font = New Font("Times New Roman", 12F)
        lblSection.Location = New Point(50, 215)
        lblSection.Name = "lblSection"
        lblSection.Size = New Size(54, 19)
        lblSection.TabIndex = 9
        lblSection.Text = "Section"
        ' 
        ' txtSection
        ' 
        txtSection.Font = New Font("Times New Roman", 12F)
        txtSection.Location = New Point(50, 237)
        txtSection.MaxLength = 10
        txtSection.Name = "txtSection"
        txtSection.Size = New Size(200, 26)
        txtSection.TabIndex = 10
        txtSection.Text = "A"
        ' 
        ' lblMaxStudents
        ' 
        lblMaxStudents.AutoSize = True
        lblMaxStudents.Font = New Font("Times New Roman", 12F)
        lblMaxStudents.Location = New Point(300, 215)
        lblMaxStudents.Name = "lblMaxStudents"
        lblMaxStudents.Size = New Size(93, 19)
        lblMaxStudents.TabIndex = 11
        lblMaxStudents.Text = "Max Students"
        ' 
        ' txtMaxStudents
        ' 
        txtMaxStudents.Font = New Font("Times New Roman", 12F)
        txtMaxStudents.Location = New Point(300, 237)
        txtMaxStudents.MaxLength = 3
        txtMaxStudents.Name = "txtMaxStudents"
        txtMaxStudents.Size = New Size(150, 26)
        txtMaxStudents.TabIndex = 12
        txtMaxStudents.Text = "40"
        ' 
        ' lblSchedule
        ' 
        lblSchedule.AutoSize = True
        lblSchedule.Font = New Font("Times New Roman", 12F)
        lblSchedule.Location = New Point(50, 285)
        lblSchedule.Name = "lblSchedule"
        lblSchedule.Size = New Size(64, 19)
        lblSchedule.TabIndex = 13
        lblSchedule.Text = "Schedule"
        ' 
        ' txtSchedule
        ' 
        txtSchedule.Font = New Font("Times New Roman", 12F)
        txtSchedule.Location = New Point(50, 307)
        txtSchedule.MaxLength = 255
        txtSchedule.Multiline = True
        txtSchedule.Name = "txtSchedule"
        txtSchedule.ScrollBars = ScrollBars.Vertical
        txtSchedule.Size = New Size(850, 60)
        txtSchedule.TabIndex = 14
        txtSchedule.Text = "MWF 10:00-11:00 AM"
        ' 
        ' lblRoom
        ' 
        lblRoom.AutoSize = True
        lblRoom.Font = New Font("Times New Roman", 12F)
        lblRoom.Location = New Point(50, 385)
        lblRoom.Name = "lblRoom"
        lblRoom.Size = New Size(46, 19)
        lblRoom.TabIndex = 15
        lblRoom.Text = "Room"
        ' 
        ' txtRoom
        ' 
        txtRoom.Font = New Font("Times New Roman", 12F)
        txtRoom.Location = New Point(50, 407)
        txtRoom.MaxLength = 50
        txtRoom.Name = "txtRoom"
        txtRoom.Size = New Size(300, 26)
        txtRoom.TabIndex = 16
        ' 
        ' lblOfferingStatus
        ' 
        lblOfferingStatus.AutoSize = True
        lblOfferingStatus.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblOfferingStatus.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblOfferingStatus.Location = New Point(400, 385)
        lblOfferingStatus.Name = "lblOfferingStatus"
        lblOfferingStatus.Size = New Size(63, 19)
        lblOfferingStatus.TabIndex = 17
        lblOfferingStatus.Text = "Status *"
        ' 
        ' cmbOfferingStatus
        ' 
        cmbOfferingStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbOfferingStatus.Font = New Font("Times New Roman", 12F)
        cmbOfferingStatus.FormattingEnabled = True
        cmbOfferingStatus.Items.AddRange(New Object() {"Open", "Closed", "Cancelled", "Full"})
        cmbOfferingStatus.Location = New Point(400, 407)
        cmbOfferingStatus.Name = "cmbOfferingStatus"
        cmbOfferingStatus.Size = New Size(300, 27)
        cmbOfferingStatus.TabIndex = 18
        ' 
        ' btnSubmitOffering
        ' 
        btnSubmitOffering.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnSubmitOffering.FlatStyle = FlatStyle.Flat
        btnSubmitOffering.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnSubmitOffering.ForeColor = Color.White
        btnSubmitOffering.Location = New Point(50, 465)
        btnSubmitOffering.Name = "btnSubmitOffering"
        btnSubmitOffering.Size = New Size(220, 45)
        btnSubmitOffering.TabIndex = 19
        btnSubmitOffering.Text = "+ Create Course Offering"
        btnSubmitOffering.UseVisualStyleBackColor = False
        ' 
        ' pnlViewOfferings
        ' 
        pnlViewOfferings.BackColor = Color.White
        pnlViewOfferings.Controls.Add(dgvOfferings)
        pnlViewOfferings.Controls.Add(lblViewOfferingsTitle)
        pnlViewOfferings.Controls.Add(btnRefreshOfferings)
        pnlViewOfferings.Dock = DockStyle.Fill
        pnlViewOfferings.Location = New Point(0, 0)
        pnlViewOfferings.Name = "pnlViewOfferings"
        pnlViewOfferings.Padding = New Padding(20)
        pnlViewOfferings.Size = New Size(980, 800)
        pnlViewOfferings.TabIndex = 1
        pnlViewOfferings.Visible = False
        ' 
        ' dgvOfferings
        ' 
        dgvOfferings.AllowUserToAddRows = False
        dgvOfferings.AllowUserToDeleteRows = False
        dgvOfferings.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvOfferings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvOfferings.BackgroundColor = SystemColors.Control
        dgvOfferings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvOfferings.Location = New Point(23, 70)
        dgvOfferings.Name = "dgvOfferings"
        dgvOfferings.ReadOnly = True
        dgvOfferings.Size = New Size(934, 690)
        dgvOfferings.TabIndex = 1
        ' 
        ' lblViewOfferingsTitle
        ' 
        lblViewOfferingsTitle.AutoSize = True
        lblViewOfferingsTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblViewOfferingsTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewOfferingsTitle.Location = New Point(23, 20)
        lblViewOfferingsTitle.Name = "lblViewOfferingsTitle"
        lblViewOfferingsTitle.Size = New Size(301, 36)
        lblViewOfferingsTitle.TabIndex = 0
        lblViewOfferingsTitle.Text = "All Course Offerings"
        ' 
        ' btnRefreshOfferings
        ' 
        btnRefreshOfferings.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshOfferings.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshOfferings.FlatStyle = FlatStyle.Flat
        btnRefreshOfferings.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRefreshOfferings.ForeColor = Color.White
        btnRefreshOfferings.Location = New Point(797, 20)
        btnRefreshOfferings.Name = "btnRefreshOfferings"
        btnRefreshOfferings.Size = New Size(160, 40)
        btnRefreshOfferings.TabIndex = 2
        btnRefreshOfferings.Text = "🔄 Refresh"
        btnRefreshOfferings.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteOffering
        ' 
        pnlUpdateDeleteOffering.AutoScroll = True
        pnlUpdateDeleteOffering.BackColor = Color.White
        pnlUpdateDeleteOffering.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteOffering.Controls.Add(lblSelectOffering)
        pnlUpdateDeleteOffering.Controls.Add(cmbSelectOffering)
        pnlUpdateDeleteOffering.Controls.Add(btnLoadOfferingData)
        pnlUpdateDeleteOffering.Controls.Add(grpOfferingInfo)
        pnlUpdateDeleteOffering.Dock = DockStyle.Fill
        pnlUpdateDeleteOffering.Location = New Point(0, 0)
        pnlUpdateDeleteOffering.Name = "pnlUpdateDeleteOffering"
        pnlUpdateDeleteOffering.Padding = New Padding(20)
        pnlUpdateDeleteOffering.Size = New Size(980, 800)
        pnlUpdateDeleteOffering.TabIndex = 2
        pnlUpdateDeleteOffering.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(507, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete Course Offering Info"
        ' 
        ' lblSelectOffering
        ' 
        lblSelectOffering.AutoSize = True
        lblSelectOffering.Font = New Font("Times New Roman", 14F)
        lblSelectOffering.Location = New Point(40, 80)
        lblSelectOffering.Name = "lblSelectOffering"
        lblSelectOffering.Size = New Size(181, 21)
        lblSelectOffering.TabIndex = 1
        lblSelectOffering.Text = "Select Course Offering"
        ' 
        ' cmbSelectOffering
        ' 
        cmbSelectOffering.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectOffering.Font = New Font("Times New Roman", 12F)
        cmbSelectOffering.FormattingEnabled = True
        cmbSelectOffering.Location = New Point(40, 105)
        cmbSelectOffering.Name = "cmbSelectOffering"
        cmbSelectOffering.Size = New Size(600, 27)
        cmbSelectOffering.TabIndex = 2
        ' 
        ' btnLoadOfferingData
        ' 
        btnLoadOfferingData.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadOfferingData.FlatStyle = FlatStyle.Flat
        btnLoadOfferingData.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnLoadOfferingData.ForeColor = Color.White
        btnLoadOfferingData.Location = New Point(660, 105)
        btnLoadOfferingData.Name = "btnLoadOfferingData"
        btnLoadOfferingData.Size = New Size(140, 29)
        btnLoadOfferingData.TabIndex = 3
        btnLoadOfferingData.Text = "Load Data"
        btnLoadOfferingData.UseVisualStyleBackColor = False
        ' 
        ' grpOfferingInfo
        ' 
        grpOfferingInfo.Controls.Add(lblUpdateCourse)
        grpOfferingInfo.Controls.Add(cmbUpdateCourse)
        grpOfferingInfo.Controls.Add(lblUpdateSemester)
        grpOfferingInfo.Controls.Add(cmbUpdateSemester)
        grpOfferingInfo.Controls.Add(lblUpdateTerm)
        grpOfferingInfo.Controls.Add(cmbUpdateTerm)
        grpOfferingInfo.Controls.Add(lblUpdateInstructor)
        grpOfferingInfo.Controls.Add(cmbUpdateInstructor)
        grpOfferingInfo.Controls.Add(lblUpdateSection)
        grpOfferingInfo.Controls.Add(txtUpdateSection)
        grpOfferingInfo.Controls.Add(lblUpdateMaxStudents)
        grpOfferingInfo.Controls.Add(txtUpdateMaxStudents)
        grpOfferingInfo.Controls.Add(lblUpdateSchedule)
        grpOfferingInfo.Controls.Add(txtUpdateSchedule)
        grpOfferingInfo.Controls.Add(lblUpdateRoom)
        grpOfferingInfo.Controls.Add(txtUpdateRoom)
        grpOfferingInfo.Controls.Add(lblUpdateOfferingStatus)
        grpOfferingInfo.Controls.Add(cmbUpdateOfferingStatus)
        grpOfferingInfo.Controls.Add(btnUpdateOffering)
        grpOfferingInfo.Controls.Add(btnDeleteOffering)
        grpOfferingInfo.Location = New Point(40, 150)
        grpOfferingInfo.Name = "grpOfferingInfo"
        grpOfferingInfo.Size = New Size(900, 620)
        grpOfferingInfo.TabIndex = 4
        grpOfferingInfo.TabStop = False
        grpOfferingInfo.Text = "Course Offering Information"
        grpOfferingInfo.Visible = False
        ' 
        ' lblUpdateCourse
        ' 
        lblUpdateCourse.AutoSize = True
        lblUpdateCourse.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateCourse.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateCourse.Location = New Point(30, 40)
        lblUpdateCourse.Name = "lblUpdateCourse"
        lblUpdateCourse.Size = New Size(69, 19)
        lblUpdateCourse.TabIndex = 0
        lblUpdateCourse.Text = "Course *"
        ' 
        ' cmbUpdateCourse
        ' 
        cmbUpdateCourse.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateCourse.Font = New Font("Times New Roman", 12F)
        cmbUpdateCourse.FormattingEnabled = True
        cmbUpdateCourse.Location = New Point(30, 62)
        cmbUpdateCourse.Name = "cmbUpdateCourse"
        cmbUpdateCourse.Size = New Size(400, 27)
        cmbUpdateCourse.TabIndex = 1
        ' 
        ' lblUpdateSemester
        ' 
        lblUpdateSemester.AutoSize = True
        lblUpdateSemester.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateSemester.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateSemester.Location = New Point(470, 40)
        lblUpdateSemester.Name = "lblUpdateSemester"
        lblUpdateSemester.Size = New Size(84, 19)
        lblUpdateSemester.TabIndex = 2
        lblUpdateSemester.Text = "Semester *"
        ' 
        ' cmbUpdateSemester
        ' 
        cmbUpdateSemester.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateSemester.Font = New Font("Times New Roman", 12F)
        cmbUpdateSemester.FormattingEnabled = True
        cmbUpdateSemester.Location = New Point(470, 62)
        cmbUpdateSemester.Name = "cmbUpdateSemester"
        cmbUpdateSemester.Size = New Size(400, 27)
        cmbUpdateSemester.TabIndex = 3
        ' 
        ' lblUpdateTerm
        ' 
        lblUpdateTerm.AutoSize = True
        lblUpdateTerm.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateTerm.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateTerm.Location = New Point(30, 110)
        lblUpdateTerm.Name = "lblUpdateTerm"
        lblUpdateTerm.Size = New Size(56, 19)
        lblUpdateTerm.TabIndex = 4
        lblUpdateTerm.Text = "Term *"
        ' 
        ' cmbUpdateTerm
        ' 
        cmbUpdateTerm.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateTerm.Font = New Font("Times New Roman", 12F)
        cmbUpdateTerm.FormattingEnabled = True
        cmbUpdateTerm.Location = New Point(30, 132)
        cmbUpdateTerm.Name = "cmbUpdateTerm"
        cmbUpdateTerm.Size = New Size(400, 27)
        cmbUpdateTerm.TabIndex = 5
        ' 
        ' lblUpdateInstructor
        ' 
        lblUpdateInstructor.AutoSize = True
        lblUpdateInstructor.Font = New Font("Times New Roman", 12F)
        lblUpdateInstructor.Location = New Point(470, 110)
        lblUpdateInstructor.Name = "lblUpdateInstructor"
        lblUpdateInstructor.Size = New Size(133, 19)
        lblUpdateInstructor.TabIndex = 6
        lblUpdateInstructor.Text = "Instructor (Optional)"
        ' 
        ' cmbUpdateInstructor
        ' 
        cmbUpdateInstructor.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateInstructor.Font = New Font("Times New Roman", 12F)
        cmbUpdateInstructor.FormattingEnabled = True
        cmbUpdateInstructor.Location = New Point(470, 132)
        cmbUpdateInstructor.Name = "cmbUpdateInstructor"
        cmbUpdateInstructor.Size = New Size(400, 27)
        cmbUpdateInstructor.TabIndex = 7
        ' 
        ' lblUpdateSection
        ' 
        lblUpdateSection.AutoSize = True
        lblUpdateSection.Font = New Font("Times New Roman", 12F)
        lblUpdateSection.Location = New Point(30, 180)
        lblUpdateSection.Name = "lblUpdateSection"
        lblUpdateSection.Size = New Size(54, 19)
        lblUpdateSection.TabIndex = 8
        lblUpdateSection.Text = "Section"
        ' 
        ' txtUpdateSection
        ' 
        txtUpdateSection.Font = New Font("Times New Roman", 12F)
        txtUpdateSection.Location = New Point(30, 202)
        txtUpdateSection.MaxLength = 10
        txtUpdateSection.Name = "txtUpdateSection"
        txtUpdateSection.Size = New Size(200, 26)
        txtUpdateSection.TabIndex = 9
        ' 
        ' lblUpdateMaxStudents
        ' 
        lblUpdateMaxStudents.AutoSize = True
        lblUpdateMaxStudents.Font = New Font("Times New Roman", 12F)
        lblUpdateMaxStudents.Location = New Point(280, 180)
        lblUpdateMaxStudents.Name = "lblUpdateMaxStudents"
        lblUpdateMaxStudents.Size = New Size(93, 19)
        lblUpdateMaxStudents.TabIndex = 10
        lblUpdateMaxStudents.Text = "Max Students"
        ' 
        ' txtUpdateMaxStudents
        ' 
        txtUpdateMaxStudents.Font = New Font("Times New Roman", 12F)
        txtUpdateMaxStudents.Location = New Point(280, 202)
        txtUpdateMaxStudents.MaxLength = 3
        txtUpdateMaxStudents.Name = "txtUpdateMaxStudents"
        txtUpdateMaxStudents.Size = New Size(150, 26)
        txtUpdateMaxStudents.TabIndex = 11
        ' 
        ' lblUpdateSchedule
        ' 
        lblUpdateSchedule.AutoSize = True
        lblUpdateSchedule.Font = New Font("Times New Roman", 12F)
        lblUpdateSchedule.Location = New Point(30, 250)
        lblUpdateSchedule.Name = "lblUpdateSchedule"
        lblUpdateSchedule.Size = New Size(64, 19)
        lblUpdateSchedule.TabIndex = 12
        lblUpdateSchedule.Text = "Schedule"
        ' 
        ' txtUpdateSchedule
        ' 
        txtUpdateSchedule.Font = New Font("Times New Roman", 12F)
        txtUpdateSchedule.Location = New Point(30, 272)
        txtUpdateSchedule.MaxLength = 255
        txtUpdateSchedule.Multiline = True
        txtUpdateSchedule.Name = "txtUpdateSchedule"
        txtUpdateSchedule.ScrollBars = ScrollBars.Vertical
        txtUpdateSchedule.Size = New Size(840, 60)
        txtUpdateSchedule.TabIndex = 13
        ' 
        ' lblUpdateRoom
        ' 
        lblUpdateRoom.AutoSize = True
        lblUpdateRoom.Font = New Font("Times New Roman", 12F)
        lblUpdateRoom.Location = New Point(30, 350)
        lblUpdateRoom.Name = "lblUpdateRoom"
        lblUpdateRoom.Size = New Size(46, 19)
        lblUpdateRoom.TabIndex = 14
        lblUpdateRoom.Text = "Room"
        ' 
        ' txtUpdateRoom
        ' 
        txtUpdateRoom.Font = New Font("Times New Roman", 12F)
        txtUpdateRoom.Location = New Point(30, 372)
        txtUpdateRoom.MaxLength = 50
        txtUpdateRoom.Name = "txtUpdateRoom"
        txtUpdateRoom.Size = New Size(300, 26)
        txtUpdateRoom.TabIndex = 15
        ' 
        ' lblUpdateOfferingStatus
        ' 
        lblUpdateOfferingStatus.AutoSize = True
        lblUpdateOfferingStatus.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateOfferingStatus.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateOfferingStatus.Location = New Point(380, 350)
        lblUpdateOfferingStatus.Name = "lblUpdateOfferingStatus"
        lblUpdateOfferingStatus.Size = New Size(63, 19)
        lblUpdateOfferingStatus.TabIndex = 16
        lblUpdateOfferingStatus.Text = "Status *"
        ' 
        ' cmbUpdateOfferingStatus
        ' 
        cmbUpdateOfferingStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateOfferingStatus.Font = New Font("Times New Roman", 12F)
        cmbUpdateOfferingStatus.FormattingEnabled = True
        cmbUpdateOfferingStatus.Items.AddRange(New Object() {"Open", "Closed", "Cancelled", "Full"})
        cmbUpdateOfferingStatus.Location = New Point(380, 372)
        cmbUpdateOfferingStatus.Name = "cmbUpdateOfferingStatus"
        cmbUpdateOfferingStatus.Size = New Size(300, 27)
        cmbUpdateOfferingStatus.TabIndex = 17
        ' 
        ' btnUpdateOffering
        ' 
        btnUpdateOffering.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnUpdateOffering.FlatStyle = FlatStyle.Flat
        btnUpdateOffering.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnUpdateOffering.ForeColor = Color.White
        btnUpdateOffering.Location = New Point(30, 430)
        btnUpdateOffering.Name = "btnUpdateOffering"
        btnUpdateOffering.Size = New Size(220, 45)
        btnUpdateOffering.TabIndex = 18
        btnUpdateOffering.Text = "Update Course Offering"
        btnUpdateOffering.UseVisualStyleBackColor = False
        btnUpdateOffering.Visible = False
        ' 
        ' btnDeleteOffering
        ' 
        btnDeleteOffering.BackColor = Color.FromArgb(CByte(255), CByte(71), CByte(71))
        btnDeleteOffering.FlatStyle = FlatStyle.Flat
        btnDeleteOffering.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnDeleteOffering.ForeColor = Color.White
        btnDeleteOffering.Location = New Point(270, 430)
        btnDeleteOffering.Name = "btnDeleteOffering"
        btnDeleteOffering.Size = New Size(220, 45)
        btnDeleteOffering.TabIndex = 19
        btnDeleteOffering.Text = "Delete Course Offering"
        btnDeleteOffering.UseVisualStyleBackColor = False
        btnDeleteOffering.Visible = False
        ' 
        ' CourseOffering
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "CourseOffering"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Course Offerings Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlCreateOffering.ResumeLayout(False)
        pnlCreateOffering.PerformLayout()
        pnlViewOfferings.ResumeLayout(False)
        pnlViewOfferings.PerformLayout()
        CType(dgvOfferings, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteOffering.ResumeLayout(False)
        pnlUpdateDeleteOffering.PerformLayout()
        grpOfferingInfo.ResumeLayout(False)
        grpOfferingInfo.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblOfferingTitle As Label
    Friend WithEvents btnCreateOffering As Button
    Friend WithEvents btnUpdateDeleteOffering As Button
    Friend WithEvents btnViewOfferings As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Create Course Offering Panel
    Friend WithEvents pnlCreateOffering As Panel
    Friend WithEvents lblCreateOfferingTitle As Label
    Friend WithEvents lblCourse As Label
    Friend WithEvents cmbCourse As ComboBox
    Friend WithEvents lblSemester As Label
    Friend WithEvents cmbSemester As ComboBox
    Friend WithEvents lblTerm As Label
    Friend WithEvents cmbTerm As ComboBox
    Friend WithEvents lblInstructor As Label
    Friend WithEvents cmbInstructor As ComboBox
    Friend WithEvents lblSection As Label
    Friend WithEvents txtSection As TextBox
    Friend WithEvents lblMaxStudents As Label
    Friend WithEvents txtMaxStudents As TextBox
    Friend WithEvents lblSchedule As Label
    Friend WithEvents txtSchedule As TextBox
    Friend WithEvents lblRoom As Label
    Friend WithEvents txtRoom As TextBox
    Friend WithEvents lblOfferingStatus As Label
    Friend WithEvents cmbOfferingStatus As ComboBox
    Friend WithEvents btnSubmitOffering As Button

    ' View Course Offerings Panel
    Friend WithEvents pnlViewOfferings As Panel
    Friend WithEvents lblViewOfferingsTitle As Label
    Friend WithEvents dgvOfferings As DataGridView
    Friend WithEvents btnRefreshOfferings As Button

    ' Update/Delete Course Offering Panel
    Friend WithEvents pnlUpdateDeleteOffering As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectOffering As Label
    Friend WithEvents cmbSelectOffering As ComboBox
    Friend WithEvents btnLoadOfferingData As Button
    Friend WithEvents grpOfferingInfo As GroupBox
    Friend WithEvents lblUpdateCourse As Label
    Friend WithEvents cmbUpdateCourse As ComboBox
    Friend WithEvents lblUpdateSemester As Label
    Friend WithEvents cmbUpdateSemester As ComboBox
    Friend WithEvents lblUpdateTerm As Label
    Friend WithEvents cmbUpdateTerm As ComboBox
    Friend WithEvents lblUpdateInstructor As Label
    Friend WithEvents cmbUpdateInstructor As ComboBox
    Friend WithEvents lblUpdateSection As Label
    Friend WithEvents txtUpdateSection As TextBox
    Friend WithEvents lblUpdateMaxStudents As Label
    Friend WithEvents txtUpdateMaxStudents As TextBox
    Friend WithEvents lblUpdateSchedule As Label
    Friend WithEvents txtUpdateSchedule As TextBox
    Friend WithEvents lblUpdateRoom As Label
    Friend WithEvents txtUpdateRoom As TextBox
    Friend WithEvents lblUpdateOfferingStatus As Label
    Friend WithEvents cmbUpdateOfferingStatus As ComboBox
    Friend WithEvents btnUpdateOffering As Button
    Friend WithEvents btnDeleteOffering As Button
End Class
