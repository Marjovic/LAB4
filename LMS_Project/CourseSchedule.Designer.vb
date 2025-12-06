<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CourseSchedule
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
        btnCreateSchedule = New Button()
        btnUpdateDeleteSchedule = New Button()
        btnViewSchedules = New Button()
        lblScheduleTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlCreateSchedule = New Panel()
        lblCreateScheduleTitle = New Label()
        lblOffering = New Label()
        cmbOffering = New ComboBox()
        lblDay = New Label()
        cmbDay = New ComboBox()
        lblRoom = New Label()
        cmbRoom = New ComboBox()
        lblStartTime = New Label()
        dtpStartTime = New DateTimePicker()
        lblEndTime = New Label()
        dtpEndTime = New DateTimePicker()
        lblScheduleType = New Label()
        cmbScheduleType = New ComboBox()
        lblIsActive = New Label()
        chkIsActive = New CheckBox()
        btnSubmitSchedule = New Button()
        pnlViewSchedules = New Panel()
        dgvSchedules = New DataGridView()
        lblViewSchedulesTitle = New Label()
        btnRefreshSchedules = New Button()
        pnlUpdateDeleteSchedule = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectSchedule = New Label()
        cmbSelectSchedule = New ComboBox()
        btnLoadScheduleData = New Button()
        grpScheduleInfo = New GroupBox()
        lblUpdateOffering = New Label()
        cmbUpdateOffering = New ComboBox()
        lblUpdateDay = New Label()
        cmbUpdateDay = New ComboBox()
        lblUpdateRoom = New Label()
        cmbUpdateRoom = New ComboBox()
        lblUpdateStartTime = New Label()
        dtpUpdateStartTime = New DateTimePicker()
        lblUpdateEndTime = New Label()
        dtpUpdateEndTime = New DateTimePicker()
        lblUpdateScheduleType = New Label()
        cmbUpdateScheduleType = New ComboBox()
        lblUpdateIsActive = New Label()
        chkUpdateIsActive = New CheckBox()
        btnUpdateSchedule = New Button()
        btnDeleteSchedule = New Button()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlCreateSchedule.SuspendLayout()
        pnlViewSchedules.SuspendLayout()
        CType(dgvSchedules, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteSchedule.SuspendLayout()
        grpScheduleInfo.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCreateSchedule)
        pnlSidebar.Controls.Add(btnUpdateDeleteSchedule)
        pnlSidebar.Controls.Add(btnViewSchedules)
        pnlSidebar.Controls.Add(lblScheduleTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnCreateSchedule
        ' 
        btnCreateSchedule.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateSchedule.Dock = DockStyle.Top
        btnCreateSchedule.FlatAppearance.BorderSize = 0
        btnCreateSchedule.FlatStyle = FlatStyle.Flat
        btnCreateSchedule.Font = New Font("Times New Roman", 11.0F)
        btnCreateSchedule.ForeColor = Color.White
        btnCreateSchedule.Location = New Point(0, 180)
        btnCreateSchedule.Name = "btnCreateSchedule"
        btnCreateSchedule.Size = New Size(220, 50)
        btnCreateSchedule.TabIndex = 1
        btnCreateSchedule.Text = "+ Create Schedule"
        btnCreateSchedule.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteSchedule
        ' 
        btnUpdateDeleteSchedule.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteSchedule.Dock = DockStyle.Top
        btnUpdateDeleteSchedule.FlatAppearance.BorderSize = 0
        btnUpdateDeleteSchedule.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteSchedule.Font = New Font("Times New Roman", 11.0F)
        btnUpdateDeleteSchedule.ForeColor = Color.White
        btnUpdateDeleteSchedule.Location = New Point(0, 130)
        btnUpdateDeleteSchedule.Name = "btnUpdateDeleteSchedule"
        btnUpdateDeleteSchedule.Size = New Size(220, 50)
        btnUpdateDeleteSchedule.TabIndex = 2
        btnUpdateDeleteSchedule.Text = "Update/Delete Schedule"
        btnUpdateDeleteSchedule.UseVisualStyleBackColor = False
        ' 
        ' btnViewSchedules
        ' 
        btnViewSchedules.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewSchedules.Dock = DockStyle.Top
        btnViewSchedules.FlatAppearance.BorderSize = 0
        btnViewSchedules.FlatStyle = FlatStyle.Flat
        btnViewSchedules.Font = New Font("Times New Roman", 11.0F)
        btnViewSchedules.ForeColor = Color.White
        btnViewSchedules.Location = New Point(0, 80)
        btnViewSchedules.Name = "btnViewSchedules"
        btnViewSchedules.Size = New Size(220, 50)
        btnViewSchedules.TabIndex = 3
        btnViewSchedules.Text = "View Schedules"
        btnViewSchedules.UseVisualStyleBackColor = False
        ' 
        ' lblScheduleTitle
        ' 
        lblScheduleTitle.BackColor = Color.Navy
        lblScheduleTitle.Dock = DockStyle.Top
        lblScheduleTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblScheduleTitle.ForeColor = Color.White
        lblScheduleTitle.Location = New Point(0, 0)
        lblScheduleTitle.Name = "lblScheduleTitle"
        lblScheduleTitle.Size = New Size(220, 80)
        lblScheduleTitle.TabIndex = 0
        lblScheduleTitle.Text = "Course Schedule Management"
        lblScheduleTitle.TextAlign = ContentAlignment.MiddleCenter
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
        pnlMainContent.Controls.Add(pnlCreateSchedule)
        pnlMainContent.Controls.Add(pnlViewSchedules)
        pnlMainContent.Controls.Add(pnlUpdateDeleteSchedule)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlCreateSchedule
        ' 
        pnlCreateSchedule.AutoScroll = True
        pnlCreateSchedule.BackColor = Color.White
        pnlCreateSchedule.Controls.Add(lblCreateScheduleTitle)
        pnlCreateSchedule.Controls.Add(lblOffering)
        pnlCreateSchedule.Controls.Add(cmbOffering)
        pnlCreateSchedule.Controls.Add(lblDay)
        pnlCreateSchedule.Controls.Add(cmbDay)
        pnlCreateSchedule.Controls.Add(lblRoom)
        pnlCreateSchedule.Controls.Add(cmbRoom)
        pnlCreateSchedule.Controls.Add(lblStartTime)
        pnlCreateSchedule.Controls.Add(dtpStartTime)
        pnlCreateSchedule.Controls.Add(lblEndTime)
        pnlCreateSchedule.Controls.Add(dtpEndTime)
        pnlCreateSchedule.Controls.Add(lblScheduleType)
        pnlCreateSchedule.Controls.Add(cmbScheduleType)
        pnlCreateSchedule.Controls.Add(lblIsActive)
        pnlCreateSchedule.Controls.Add(chkIsActive)
        pnlCreateSchedule.Controls.Add(btnSubmitSchedule)
        pnlCreateSchedule.Dock = DockStyle.Fill
        pnlCreateSchedule.Location = New Point(0, 0)
        pnlCreateSchedule.Name = "pnlCreateSchedule"
        pnlCreateSchedule.Padding = New Padding(30, 20, 30, 20)
        pnlCreateSchedule.Size = New Size(980, 800)
        pnlCreateSchedule.TabIndex = 0
        pnlCreateSchedule.Visible = False
        ' 
        ' lblCreateScheduleTitle
        ' 
        lblCreateScheduleTitle.AutoSize = True
        lblCreateScheduleTitle.Font = New Font("Times New Roman", 20.0F, FontStyle.Bold)
        lblCreateScheduleTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateScheduleTitle.Location = New Point(30, 20)
        lblCreateScheduleTitle.Name = "lblCreateScheduleTitle"
        lblCreateScheduleTitle.Size = New Size(353, 31)
        lblCreateScheduleTitle.TabIndex = 0
        lblCreateScheduleTitle.Text = "Create New Course Schedule"
        ' 
        ' lblOffering
        ' 
        lblOffering.AutoSize = True
        lblOffering.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblOffering.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblOffering.Location = New Point(50, 75)
        lblOffering.Name = "lblOffering"
        lblOffering.Size = New Size(132, 19)
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
        cmbOffering.Size = New Size(850, 27)
        cmbOffering.TabIndex = 2
        ' 
        ' lblDay
        ' 
        lblDay.AutoSize = True
        lblDay.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblDay.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblDay.Location = New Point(50, 145)
        lblDay.Name = "lblDay"
        lblDay.Size = New Size(115, 19)
        lblDay.TabIndex = 3
        lblDay.Text = "Day of Week *"
        ' 
        ' cmbDay
        ' 
        cmbDay.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDay.Font = New Font("Times New Roman", 12.0F)
        cmbDay.FormattingEnabled = True
        cmbDay.Location = New Point(50, 167)
        cmbDay.Name = "cmbDay"
        cmbDay.Size = New Size(300, 27)
        cmbDay.TabIndex = 4
        ' 
        ' lblRoom
        ' 
        lblRoom.AutoSize = True
        lblRoom.Font = New Font("Times New Roman", 12.0F)
        lblRoom.Location = New Point(400, 145)
        lblRoom.Name = "lblRoom"
        lblRoom.Size = New Size(113, 19)
        lblRoom.TabIndex = 5
        lblRoom.Text = "Room (Optional)"
        ' 
        ' cmbRoom
        ' 
        cmbRoom.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRoom.Font = New Font("Times New Roman", 12.0F)
        cmbRoom.FormattingEnabled = True
        cmbRoom.Location = New Point(400, 167)
        cmbRoom.Name = "cmbRoom"
        cmbRoom.Size = New Size(500, 27)
        cmbRoom.TabIndex = 6
        ' 
        ' lblStartTime
        ' 
        lblStartTime.AutoSize = True
        lblStartTime.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblStartTime.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblStartTime.Location = New Point(50, 215)
        lblStartTime.Name = "lblStartTime"
        lblStartTime.Size = New Size(92, 19)
        lblStartTime.TabIndex = 7
        lblStartTime.Text = "Start Time *"
        ' 
        ' dtpStartTime
        ' 
        dtpStartTime.CustomFormat = "hh:mm tt"
        dtpStartTime.Font = New Font("Times New Roman", 12.0F)
        dtpStartTime.Format = DateTimePickerFormat.Custom
        dtpStartTime.Location = New Point(50, 237)
        dtpStartTime.Name = "dtpStartTime"
        dtpStartTime.ShowUpDown = True
        dtpStartTime.Size = New Size(300, 26)
        dtpStartTime.TabIndex = 8
        ' 
        ' lblEndTime
        ' 
        lblEndTime.AutoSize = True
        lblEndTime.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblEndTime.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblEndTime.Location = New Point(400, 215)
        lblEndTime.Name = "lblEndTime"
        lblEndTime.Size = New Size(85, 19)
        lblEndTime.TabIndex = 9
        lblEndTime.Text = "End Time *"
        ' 
        ' dtpEndTime
        ' 
        dtpEndTime.CustomFormat = "hh:mm tt"
        dtpEndTime.Font = New Font("Times New Roman", 12.0F)
        dtpEndTime.Format = DateTimePickerFormat.Custom
        dtpEndTime.Location = New Point(400, 237)
        dtpEndTime.Name = "dtpEndTime"
        dtpEndTime.ShowUpDown = True
        dtpEndTime.Size = New Size(300, 26)
        dtpEndTime.TabIndex = 10
        ' 
        ' lblScheduleType
        ' 
        lblScheduleType.AutoSize = True
        lblScheduleType.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblScheduleType.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblScheduleType.Location = New Point(50, 285)
        lblScheduleType.Name = "lblScheduleType"
        lblScheduleType.Size = New Size(118, 19)
        lblScheduleType.TabIndex = 11
        lblScheduleType.Text = "Schedule Type *"
        ' 
        ' cmbScheduleType
        ' 
        cmbScheduleType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbScheduleType.Font = New Font("Times New Roman", 12.0F)
        cmbScheduleType.FormattingEnabled = True
        cmbScheduleType.Items.AddRange(New Object() {"Lecture", "Laboratory", "Recitation", "Online"})
        cmbScheduleType.Location = New Point(50, 307)
        cmbScheduleType.Name = "cmbScheduleType"
        cmbScheduleType.Size = New Size(300, 27)
        cmbScheduleType.TabIndex = 12
        ' 
        ' lblIsActive
        ' 
        lblIsActive.AutoSize = True
        lblIsActive.Font = New Font("Times New Roman", 12.0F)
        lblIsActive.Location = New Point(400, 285)
        lblIsActive.Name = "lblIsActive"
        lblIsActive.Size = New Size(50, 19)
        lblIsActive.TabIndex = 13
        lblIsActive.Text = "Active"
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.Checked = True
        chkIsActive.CheckState = CheckState.Checked
        chkIsActive.Font = New Font("Times New Roman", 12.0F)
        chkIsActive.Location = New Point(400, 310)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(185, 23)
        chkIsActive.TabIndex = 14
        chkIsActive.Text = "Schedule is Active/Open"
        chkIsActive.UseVisualStyleBackColor = True
        ' 
        ' btnSubmitSchedule
        ' 
        btnSubmitSchedule.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnSubmitSchedule.FlatStyle = FlatStyle.Flat
        btnSubmitSchedule.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnSubmitSchedule.ForeColor = Color.White
        btnSubmitSchedule.Location = New Point(50, 370)
        btnSubmitSchedule.Name = "btnSubmitSchedule"
        btnSubmitSchedule.Size = New Size(220, 45)
        btnSubmitSchedule.TabIndex = 15
        btnSubmitSchedule.Text = "+ Create Schedule"
        btnSubmitSchedule.UseVisualStyleBackColor = False
        ' 
        ' pnlViewSchedules
        ' 
        pnlViewSchedules.BackColor = Color.White
        pnlViewSchedules.Controls.Add(dgvSchedules)
        pnlViewSchedules.Controls.Add(lblViewSchedulesTitle)
        pnlViewSchedules.Controls.Add(btnRefreshSchedules)
        pnlViewSchedules.Dock = DockStyle.Fill
        pnlViewSchedules.Location = New Point(0, 0)
        pnlViewSchedules.Name = "pnlViewSchedules"
        pnlViewSchedules.Padding = New Padding(20)
        pnlViewSchedules.Size = New Size(980, 800)
        pnlViewSchedules.TabIndex = 1
        pnlViewSchedules.Visible = False
        ' 
        ' dgvSchedules
        ' 
        dgvSchedules.AllowUserToAddRows = False
        dgvSchedules.AllowUserToDeleteRows = False
        dgvSchedules.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvSchedules.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSchedules.BackgroundColor = SystemColors.Control
        dgvSchedules.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSchedules.Location = New Point(23, 70)
        dgvSchedules.Name = "dgvSchedules"
        dgvSchedules.ReadOnly = True
        dgvSchedules.Size = New Size(934, 690)
        dgvSchedules.TabIndex = 1
        ' 
        ' lblViewSchedulesTitle
        ' 
        lblViewSchedulesTitle.AutoSize = True
        lblViewSchedulesTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblViewSchedulesTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewSchedulesTitle.Location = New Point(23, 20)
        lblViewSchedulesTitle.Name = "lblViewSchedulesTitle"
        lblViewSchedulesTitle.Size = New Size(306, 36)
        lblViewSchedulesTitle.TabIndex = 0
        lblViewSchedulesTitle.Text = "All Course Schedules"
        ' 
        ' btnRefreshSchedules
        ' 
        btnRefreshSchedules.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshSchedules.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshSchedules.FlatStyle = FlatStyle.Flat
        btnRefreshSchedules.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnRefreshSchedules.ForeColor = Color.White
        btnRefreshSchedules.Location = New Point(797, 20)
        btnRefreshSchedules.Name = "btnRefreshSchedules"
        btnRefreshSchedules.Size = New Size(160, 40)
        btnRefreshSchedules.TabIndex = 2
        btnRefreshSchedules.Text = "🔄 Refresh"
        btnRefreshSchedules.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteSchedule
        ' 
        pnlUpdateDeleteSchedule.AutoScroll = True
        pnlUpdateDeleteSchedule.BackColor = Color.White
        pnlUpdateDeleteSchedule.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteSchedule.Controls.Add(lblSelectSchedule)
        pnlUpdateDeleteSchedule.Controls.Add(cmbSelectSchedule)
        pnlUpdateDeleteSchedule.Controls.Add(btnLoadScheduleData)
        pnlUpdateDeleteSchedule.Controls.Add(grpScheduleInfo)
        pnlUpdateDeleteSchedule.Dock = DockStyle.Fill
        pnlUpdateDeleteSchedule.Location = New Point(0, 0)
        pnlUpdateDeleteSchedule.Name = "pnlUpdateDeleteSchedule"
        pnlUpdateDeleteSchedule.Padding = New Padding(20)
        pnlUpdateDeleteSchedule.Size = New Size(980, 800)
        pnlUpdateDeleteSchedule.TabIndex = 2
        pnlUpdateDeleteSchedule.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24.0F, FontStyle.Bold)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(512, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete Course Schedule Info"
        ' 
        ' lblSelectSchedule
        ' 
        lblSelectSchedule.AutoSize = True
        lblSelectSchedule.Font = New Font("Times New Roman", 14.0F)
        lblSelectSchedule.Location = New Point(40, 80)
        lblSelectSchedule.Name = "lblSelectSchedule"
        lblSelectSchedule.Size = New Size(186, 21)
        lblSelectSchedule.TabIndex = 1
        lblSelectSchedule.Text = "Select Course Schedule"
        ' 
        ' cmbSelectSchedule
        ' 
        cmbSelectSchedule.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectSchedule.Font = New Font("Times New Roman", 12.0F)
        cmbSelectSchedule.FormattingEnabled = True
        cmbSelectSchedule.Location = New Point(40, 105)
        cmbSelectSchedule.Name = "cmbSelectSchedule"
        cmbSelectSchedule.Size = New Size(700, 27)
        cmbSelectSchedule.TabIndex = 2
        ' 
        ' btnLoadScheduleData
        ' 
        btnLoadScheduleData.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnLoadScheduleData.FlatStyle = FlatStyle.Flat
        btnLoadScheduleData.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnLoadScheduleData.ForeColor = Color.White
        btnLoadScheduleData.Location = New Point(760, 105)
        btnLoadScheduleData.Name = "btnLoadScheduleData"
        btnLoadScheduleData.Size = New Size(140, 29)
        btnLoadScheduleData.TabIndex = 3
        btnLoadScheduleData.Text = "Load Data"
        btnLoadScheduleData.UseVisualStyleBackColor = False
        ' 
        ' grpScheduleInfo
        ' 
        grpScheduleInfo.Controls.Add(lblUpdateOffering)
        grpScheduleInfo.Controls.Add(cmbUpdateOffering)
        grpScheduleInfo.Controls.Add(lblUpdateDay)
        grpScheduleInfo.Controls.Add(cmbUpdateDay)
        grpScheduleInfo.Controls.Add(lblUpdateRoom)
        grpScheduleInfo.Controls.Add(cmbUpdateRoom)
        grpScheduleInfo.Controls.Add(lblUpdateStartTime)
        grpScheduleInfo.Controls.Add(dtpUpdateStartTime)
        grpScheduleInfo.Controls.Add(lblUpdateEndTime)
        grpScheduleInfo.Controls.Add(dtpUpdateEndTime)
        grpScheduleInfo.Controls.Add(lblUpdateScheduleType)
        grpScheduleInfo.Controls.Add(cmbUpdateScheduleType)
        grpScheduleInfo.Controls.Add(lblUpdateIsActive)
        grpScheduleInfo.Controls.Add(chkUpdateIsActive)
        grpScheduleInfo.Controls.Add(btnUpdateSchedule)
        grpScheduleInfo.Controls.Add(btnDeleteSchedule)
        grpScheduleInfo.Location = New Point(40, 150)
        grpScheduleInfo.Name = "grpScheduleInfo"
        grpScheduleInfo.Size = New Size(900, 620)
        grpScheduleInfo.TabIndex = 4
        grpScheduleInfo.TabStop = False
        grpScheduleInfo.Text = "Course Schedule Information"
        grpScheduleInfo.Visible = False
        ' 
        ' lblUpdateOffering
        ' 
        lblUpdateOffering.AutoSize = True
        lblUpdateOffering.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateOffering.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateOffering.Location = New Point(30, 40)
        lblUpdateOffering.Name = "lblUpdateOffering"
        lblUpdateOffering.Size = New Size(132, 19)
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
        cmbUpdateOffering.Size = New Size(840, 27)
        cmbUpdateOffering.TabIndex = 1
        ' 
        ' lblUpdateDay
        ' 
        lblUpdateDay.AutoSize = True
        lblUpdateDay.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateDay.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateDay.Location = New Point(30, 110)
        lblUpdateDay.Name = "lblUpdateDay"
        lblUpdateDay.Size = New Size(115, 19)
        lblUpdateDay.TabIndex = 2
        lblUpdateDay.Text = "Day of Week *"
        ' 
        ' cmbUpdateDay
        ' 
        cmbUpdateDay.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateDay.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateDay.FormattingEnabled = True
        cmbUpdateDay.Location = New Point(30, 132)
        cmbUpdateDay.Name = "cmbUpdateDay"
        cmbUpdateDay.Size = New Size(300, 27)
        cmbUpdateDay.TabIndex = 3
        ' 
        ' lblUpdateRoom
        ' 
        lblUpdateRoom.AutoSize = True
        lblUpdateRoom.Font = New Font("Times New Roman", 12.0F)
        lblUpdateRoom.Location = New Point(370, 110)
        lblUpdateRoom.Name = "lblUpdateRoom"
        lblUpdateRoom.Size = New Size(113, 19)
        lblUpdateRoom.TabIndex = 4
        lblUpdateRoom.Text = "Room (Optional)"
        ' 
        ' cmbUpdateRoom
        ' 
        cmbUpdateRoom.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateRoom.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateRoom.FormattingEnabled = True
        cmbUpdateRoom.Location = New Point(370, 132)
        cmbUpdateRoom.Name = "cmbUpdateRoom"
        cmbUpdateRoom.Size = New Size(500, 27)
        cmbUpdateRoom.TabIndex = 5
        ' 
        ' lblUpdateStartTime
        ' 
        lblUpdateStartTime.AutoSize = True
        lblUpdateStartTime.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateStartTime.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateStartTime.Location = New Point(30, 180)
        lblUpdateStartTime.Name = "lblUpdateStartTime"
        lblUpdateStartTime.Size = New Size(92, 19)
        lblUpdateStartTime.TabIndex = 6
        lblUpdateStartTime.Text = "Start Time *"
        ' 
        ' dtpUpdateStartTime
        ' 
        dtpUpdateStartTime.CustomFormat = "hh:mm tt"
        dtpUpdateStartTime.Font = New Font("Times New Roman", 12.0F)
        dtpUpdateStartTime.Format = DateTimePickerFormat.Custom
        dtpUpdateStartTime.Location = New Point(30, 202)
        dtpUpdateStartTime.Name = "dtpUpdateStartTime"
        dtpUpdateStartTime.ShowUpDown = True
        dtpUpdateStartTime.Size = New Size(300, 26)
        dtpUpdateStartTime.TabIndex = 7
        ' 
        ' lblUpdateEndTime
        ' 
        lblUpdateEndTime.AutoSize = True
        lblUpdateEndTime.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateEndTime.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateEndTime.Location = New Point(370, 180)
        lblUpdateEndTime.Name = "lblUpdateEndTime"
        lblUpdateEndTime.Size = New Size(85, 19)
        lblUpdateEndTime.TabIndex = 8
        lblUpdateEndTime.Text = "End Time *"
        ' 
        ' dtpUpdateEndTime
        ' 
        dtpUpdateEndTime.CustomFormat = "hh:mm tt"
        dtpUpdateEndTime.Font = New Font("Times New Roman", 12.0F)
        dtpUpdateEndTime.Format = DateTimePickerFormat.Custom
        dtpUpdateEndTime.Location = New Point(370, 202)
        dtpUpdateEndTime.Name = "dtpUpdateEndTime"
        dtpUpdateEndTime.ShowUpDown = True
        dtpUpdateEndTime.Size = New Size(300, 26)
        dtpUpdateEndTime.TabIndex = 9
        ' 
        ' lblUpdateScheduleType
        ' 
        lblUpdateScheduleType.AutoSize = True
        lblUpdateScheduleType.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblUpdateScheduleType.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        lblUpdateScheduleType.Location = New Point(30, 250)
        lblUpdateScheduleType.Name = "lblUpdateScheduleType"
        lblUpdateScheduleType.Size = New Size(118, 19)
        lblUpdateScheduleType.TabIndex = 10
        lblUpdateScheduleType.Text = "Schedule Type *"
        ' 
        ' cmbUpdateScheduleType
        ' 
        cmbUpdateScheduleType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateScheduleType.Font = New Font("Times New Roman", 12.0F)
        cmbUpdateScheduleType.FormattingEnabled = True
        cmbUpdateScheduleType.Items.AddRange(New Object() {"Lecture", "Laboratory", "Recitation", "Online"})
        cmbUpdateScheduleType.Location = New Point(30, 272)
        cmbUpdateScheduleType.Name = "cmbUpdateScheduleType"
        cmbUpdateScheduleType.Size = New Size(300, 27)
        cmbUpdateScheduleType.TabIndex = 11
        ' 
        ' lblUpdateIsActive
        ' 
        lblUpdateIsActive.AutoSize = True
        lblUpdateIsActive.Font = New Font("Times New Roman", 12.0F)
        lblUpdateIsActive.Location = New Point(370, 250)
        lblUpdateIsActive.Name = "lblUpdateIsActive"
        lblUpdateIsActive.Size = New Size(50, 19)
        lblUpdateIsActive.TabIndex = 12
        lblUpdateIsActive.Text = "Active"
        ' 
        ' chkUpdateIsActive
        ' 
        chkUpdateIsActive.AutoSize = True
        chkUpdateIsActive.Font = New Font("Times New Roman", 12.0F)
        chkUpdateIsActive.Location = New Point(370, 275)
        chkUpdateIsActive.Name = "chkUpdateIsActive"
        chkUpdateIsActive.Size = New Size(185, 23)
        chkUpdateIsActive.TabIndex = 13
        chkUpdateIsActive.Text = "Schedule is Active/Open"
        chkUpdateIsActive.UseVisualStyleBackColor = True
        ' 
        ' btnUpdateSchedule
        ' 
        btnUpdateSchedule.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnUpdateSchedule.FlatStyle = FlatStyle.Flat
        btnUpdateSchedule.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnUpdateSchedule.ForeColor = Color.White
        btnUpdateSchedule.Location = New Point(30, 340)
        btnUpdateSchedule.Name = "btnUpdateSchedule"
        btnUpdateSchedule.Size = New Size(220, 45)
        btnUpdateSchedule.TabIndex = 14
        btnUpdateSchedule.Text = "Update Schedule"
        btnUpdateSchedule.UseVisualStyleBackColor = False
        btnUpdateSchedule.Visible = False
        ' 
        ' btnDeleteSchedule
        ' 
        btnDeleteSchedule.BackColor = Color.FromArgb(CByte(255), CByte(71), CByte(71))
        btnDeleteSchedule.FlatStyle = FlatStyle.Flat
        btnDeleteSchedule.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnDeleteSchedule.ForeColor = Color.White
        btnDeleteSchedule.Location = New Point(270, 340)
        btnDeleteSchedule.Name = "btnDeleteSchedule"
        btnDeleteSchedule.Size = New Size(220, 45)
        btnDeleteSchedule.TabIndex = 15
        btnDeleteSchedule.Text = "Delete Schedule"
        btnDeleteSchedule.UseVisualStyleBackColor = False
        btnDeleteSchedule.Visible = False
        ' 
        ' CourseSchedule
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "CourseSchedule"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Course Schedule Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlCreateSchedule.ResumeLayout(False)
        pnlCreateSchedule.PerformLayout()
        pnlViewSchedules.ResumeLayout(False)
        pnlViewSchedules.PerformLayout()
        CType(dgvSchedules, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteSchedule.ResumeLayout(False)
        pnlUpdateDeleteSchedule.PerformLayout()
        grpScheduleInfo.ResumeLayout(False)
        grpScheduleInfo.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblScheduleTitle As Label
    Friend WithEvents btnCreateSchedule As Button
    Friend WithEvents btnUpdateDeleteSchedule As Button
    Friend WithEvents btnViewSchedules As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Create Schedule Panel
    Friend WithEvents pnlCreateSchedule As Panel
    Friend WithEvents lblCreateScheduleTitle As Label
    Friend WithEvents lblOffering As Label
    Friend WithEvents cmbOffering As ComboBox
    Friend WithEvents lblDay As Label
    Friend WithEvents cmbDay As ComboBox
    Friend WithEvents lblRoom As Label
    Friend WithEvents cmbRoom As ComboBox
    Friend WithEvents lblStartTime As Label
    Friend WithEvents dtpStartTime As DateTimePicker
    Friend WithEvents lblEndTime As Label
    Friend WithEvents dtpEndTime As DateTimePicker
    Friend WithEvents lblScheduleType As Label
    Friend WithEvents cmbScheduleType As ComboBox
    Friend WithEvents lblIsActive As Label
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents btnSubmitSchedule As Button

    ' View Schedules Panel
    Friend WithEvents pnlViewSchedules As Panel
    Friend WithEvents lblViewSchedulesTitle As Label
    Friend WithEvents dgvSchedules As DataGridView
    Friend WithEvents btnRefreshSchedules As Button

    ' Update/Delete Schedule Panel
    Friend WithEvents pnlUpdateDeleteSchedule As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectSchedule As Label
    Friend WithEvents cmbSelectSchedule As ComboBox
    Friend WithEvents btnLoadScheduleData As Button
    Friend WithEvents grpScheduleInfo As GroupBox
    Friend WithEvents lblUpdateOffering As Label
    Friend WithEvents cmbUpdateOffering As ComboBox
    Friend WithEvents lblUpdateDay As Label
    Friend WithEvents cmbUpdateDay As ComboBox
    Friend WithEvents lblUpdateRoom As Label
    Friend WithEvents cmbUpdateRoom As ComboBox
    Friend WithEvents lblUpdateStartTime As Label
    Friend WithEvents dtpUpdateStartTime As DateTimePicker
    Friend WithEvents lblUpdateEndTime As Label
    Friend WithEvents dtpUpdateEndTime As DateTimePicker
    Friend WithEvents lblUpdateScheduleType As Label
    Friend WithEvents cmbUpdateScheduleType As ComboBox
    Friend WithEvents lblUpdateIsActive As Label
    Friend WithEvents chkUpdateIsActive As CheckBox
    Friend WithEvents btnUpdateSchedule As Button
    Friend WithEvents btnDeleteSchedule As Button
End Class
