<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewStudentGrades
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
        pnlTop = New Panel()
        lblTitle = New Label()
        btnClose = New Button()
        pnlFilters = New Panel()
        grpFilters = New GroupBox()
        lblAcademicYear = New Label()
        cmbFilterAcademicYear = New ComboBox()
        lblSemester = New Label()
        cmbFilterSemester = New ComboBox()
        lblCourse = New Label()
        cmbFilterCourse = New ComboBox()
        lblPeriod = New Label()
        cmbFilterPeriod = New ComboBox()
        lblType = New Label()
        cmbFilterType = New ComboBox()
        lblStudentSearch = New Label()
        txtStudentSearch = New TextBox()
        btnApplyFilters = New Button()
        btnClearFilters = New Button()
        pnlActions = New Panel()
        btnRefreshGrades = New Button()
        btnExportToExcel = New Button()
        lblTotalGrades = New Label()
        lblAverageScore = New Label()
        lblPassingRate = New Label()
        pnlMain = New Panel()
        dgvAllGrades = New DataGridView()
        pnlTop.SuspendLayout()
        pnlFilters.SuspendLayout()
        grpFilters.SuspendLayout()
        pnlActions.SuspendLayout()
        pnlMain.SuspendLayout()
        CType(dgvAllGrades, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' pnlTop
        ' 
        pnlTop.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        pnlTop.Controls.Add(lblTitle)
        pnlTop.Controls.Add(btnClose)
        pnlTop.Dock = DockStyle.Top
        pnlTop.Location = New Point(0, 0)
        pnlTop.Name = "pnlTop"
        pnlTop.Size = New Size(1400, 60)
        pnlTop.TabIndex = 0
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Times New Roman", 20.0F, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(20, 15)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(336, 31)
        lblTitle.TabIndex = 0
        lblTitle.Text = "View All Student Grades"
        ' 
        ' btnClose
        ' 
        btnClose.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClose.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btnClose.FlatStyle = FlatStyle.Flat
        btnClose.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        btnClose.ForeColor = Color.White
        btnClose.Location = New Point(1280, 10)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(100, 40)
        btnClose.TabIndex = 1
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlFilters
        ' 
        pnlFilters.BackColor = Color.White
        pnlFilters.Controls.Add(grpFilters)
        pnlFilters.Dock = DockStyle.Top
        pnlFilters.Location = New Point(0, 60)
        pnlFilters.Name = "pnlFilters"
        pnlFilters.Padding = New Padding(10)
        pnlFilters.Size = New Size(1400, 180)
        pnlFilters.TabIndex = 1
        ' 
        ' grpFilters
        ' 
        grpFilters.Controls.Add(lblAcademicYear)
        grpFilters.Controls.Add(cmbFilterAcademicYear)
        grpFilters.Controls.Add(lblSemester)
        grpFilters.Controls.Add(cmbFilterSemester)
        grpFilters.Controls.Add(lblCourse)
        grpFilters.Controls.Add(cmbFilterCourse)
        grpFilters.Controls.Add(lblPeriod)
        grpFilters.Controls.Add(cmbFilterPeriod)
        grpFilters.Controls.Add(lblType)
        grpFilters.Controls.Add(cmbFilterType)
        grpFilters.Controls.Add(lblStudentSearch)
        grpFilters.Controls.Add(txtStudentSearch)
        grpFilters.Controls.Add(btnApplyFilters)
        grpFilters.Controls.Add(btnClearFilters)
        grpFilters.Dock = DockStyle.Fill
        grpFilters.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        grpFilters.Location = New Point(10, 10)
        grpFilters.Name = "grpFilters"
        grpFilters.Size = New Size(1380, 160)
        grpFilters.TabIndex = 0
        grpFilters.TabStop = False
        grpFilters.Text = "Filter Options"
        ' 
        ' lblAcademicYear
        ' 
        lblAcademicYear.AutoSize = True
        lblAcademicYear.Font = New Font("Times New Roman", 11.0F)
        lblAcademicYear.Location = New Point(20, 30)
        lblAcademicYear.Name = "lblAcademicYear"
        lblAcademicYear.Size = New Size(99, 17)
        lblAcademicYear.TabIndex = 0
        lblAcademicYear.Text = "Academic Year"
        ' 
        ' cmbFilterAcademicYear
        ' 
        cmbFilterAcademicYear.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterAcademicYear.Font = New Font("Times New Roman", 11.0F)
        cmbFilterAcademicYear.FormattingEnabled = True
        cmbFilterAcademicYear.Location = New Point(20, 50)
        cmbFilterAcademicYear.Name = "cmbFilterAcademicYear"
        cmbFilterAcademicYear.Size = New Size(200, 25)
        cmbFilterAcademicYear.TabIndex = 1
        ' 
        ' lblSemester
        ' 
        lblSemester.AutoSize = True
        lblSemester.Font = New Font("Times New Roman", 11.0F)
        lblSemester.Location = New Point(240, 30)
        lblSemester.Name = "lblSemester"
        lblSemester.Size = New Size(63, 17)
        lblSemester.TabIndex = 2
        lblSemester.Text = "Semester"
        ' 
        ' cmbFilterSemester
        ' 
        cmbFilterSemester.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterSemester.Font = New Font("Times New Roman", 11.0F)
        cmbFilterSemester.FormattingEnabled = True
        cmbFilterSemester.Location = New Point(240, 50)
        cmbFilterSemester.Name = "cmbFilterSemester"
        cmbFilterSemester.Size = New Size(200, 25)
        cmbFilterSemester.TabIndex = 3
        ' 
        ' lblCourse
        ' 
        lblCourse.AutoSize = True
        lblCourse.Font = New Font("Times New Roman", 11.0F)
        lblCourse.Location = New Point(460, 30)
        lblCourse.Name = "lblCourse"
        lblCourse.Size = New Size(50, 17)
        lblCourse.TabIndex = 4
        lblCourse.Text = "Course"
        ' 
        ' cmbFilterCourse
        ' 
        cmbFilterCourse.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterCourse.Font = New Font("Times New Roman", 11.0F)
        cmbFilterCourse.FormattingEnabled = True
        cmbFilterCourse.Location = New Point(460, 50)
        cmbFilterCourse.Name = "cmbFilterCourse"
        cmbFilterCourse.Size = New Size(300, 25)
        cmbFilterCourse.TabIndex = 5
        ' 
        ' lblPeriod
        ' 
        lblPeriod.AutoSize = True
        lblPeriod.Font = New Font("Times New Roman", 11.0F)
        lblPeriod.Location = New Point(780, 30)
        lblPeriod.Name = "lblPeriod"
        lblPeriod.Size = New Size(96, 17)
        lblPeriod.TabIndex = 6
        lblPeriod.Text = "Grading Period"
        ' 
        ' cmbFilterPeriod
        ' 
        cmbFilterPeriod.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterPeriod.Font = New Font("Times New Roman", 11.0F)
        cmbFilterPeriod.FormattingEnabled = True
        cmbFilterPeriod.Location = New Point(780, 50)
        cmbFilterPeriod.Name = "cmbFilterPeriod"
        cmbFilterPeriod.Size = New Size(200, 25)
        cmbFilterPeriod.TabIndex = 7
        ' 
        ' lblType
        ' 
        lblType.AutoSize = True
        lblType.Font = New Font("Times New Roman", 11.0F)
        lblType.Location = New Point(1000, 30)
        lblType.Name = "lblType"
        lblType.Size = New Size(110, 17)
        lblType.TabIndex = 8
        lblType.Text = "Assignment Type"
        ' 
        ' cmbFilterType
        ' 
        cmbFilterType.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFilterType.Font = New Font("Times New Roman", 11.0F)
        cmbFilterType.FormattingEnabled = True
        cmbFilterType.Location = New Point(1000, 50)
        cmbFilterType.Name = "cmbFilterType"
        cmbFilterType.Size = New Size(250, 25)
        cmbFilterType.TabIndex = 9
        ' 
        ' lblStudentSearch
        ' 
        lblStudentSearch.AutoSize = True
        lblStudentSearch.Font = New Font("Times New Roman", 11.0F)
        lblStudentSearch.Location = New Point(20, 90)
        lblStudentSearch.Name = "lblStudentSearch"
        lblStudentSearch.Size = New Size(97, 17)
        lblStudentSearch.TabIndex = 10
        lblStudentSearch.Text = "Search Student"
        ' 
        ' txtStudentSearch
        ' 
        txtStudentSearch.Font = New Font("Times New Roman", 11.0F)
        txtStudentSearch.Location = New Point(20, 110)
        txtStudentSearch.Name = "txtStudentSearch"
        txtStudentSearch.PlaceholderText = "Student number, first name, or last name..."
        txtStudentSearch.Size = New Size(420, 24)
        txtStudentSearch.TabIndex = 11
        ' 
        ' btnApplyFilters
        ' 
        btnApplyFilters.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnApplyFilters.FlatStyle = FlatStyle.Flat
        btnApplyFilters.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        btnApplyFilters.ForeColor = Color.White
        btnApplyFilters.Location = New Point(460, 105)
        btnApplyFilters.Name = "btnApplyFilters"
        btnApplyFilters.Size = New Size(150, 35)
        btnApplyFilters.TabIndex = 12
        btnApplyFilters.Text = "Apply Filters"
        btnApplyFilters.UseVisualStyleBackColor = False
        ' 
        ' btnClearFilters
        ' 
        btnClearFilters.BackColor = Color.FromArgb(CByte(255), CByte(140), CByte(0))
        btnClearFilters.FlatStyle = FlatStyle.Flat
        btnClearFilters.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        btnClearFilters.ForeColor = Color.White
        btnClearFilters.Location = New Point(636, 105)
        btnClearFilters.Name = "btnClearFilters"
        btnClearFilters.Size = New Size(170, 35)
        btnClearFilters.TabIndex = 13
        btnClearFilters.Text = "Clear Filters"
        btnClearFilters.UseVisualStyleBackColor = False
        ' 
        ' pnlActions
        ' 
        pnlActions.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlActions.Controls.Add(btnRefreshGrades)
        pnlActions.Controls.Add(btnExportToExcel)
        pnlActions.Controls.Add(lblTotalGrades)
        pnlActions.Controls.Add(lblAverageScore)
        pnlActions.Controls.Add(lblPassingRate)
        pnlActions.Dock = DockStyle.Top
        pnlActions.Location = New Point(0, 240)
        pnlActions.Name = "pnlActions"
        pnlActions.Size = New Size(1400, 60)
        pnlActions.TabIndex = 2
        ' 
        ' btnRefreshGrades
        ' 
        btnRefreshGrades.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshGrades.FlatStyle = FlatStyle.Flat
        btnRefreshGrades.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        btnRefreshGrades.ForeColor = Color.White
        btnRefreshGrades.Location = New Point(20, 10)
        btnRefreshGrades.Name = "btnRefreshGrades"
        btnRefreshGrades.Size = New Size(160, 40)
        btnRefreshGrades.TabIndex = 0
        btnRefreshGrades.Text = "Refresh"
        btnRefreshGrades.UseVisualStyleBackColor = False
        ' 
        ' btnExportToExcel
        ' 
        btnExportToExcel.BackColor = Color.FromArgb(CByte(34), CByte(139), CByte(34))
        btnExportToExcel.FlatStyle = FlatStyle.Flat
        btnExportToExcel.Font = New Font("Times New Roman", 11.0F, FontStyle.Bold)
        btnExportToExcel.ForeColor = Color.White
        btnExportToExcel.Location = New Point(190, 10)
        btnExportToExcel.Name = "btnExportToExcel"
        btnExportToExcel.Size = New Size(180, 40)
        btnExportToExcel.TabIndex = 1
        btnExportToExcel.Text = "Export to CSV"
        btnExportToExcel.UseVisualStyleBackColor = False
        ' 
        ' lblTotalGrades
        ' 
        lblTotalGrades.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblTotalGrades.AutoSize = True
        lblTotalGrades.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblTotalGrades.Location = New Point(900, 20)
        lblTotalGrades.Name = "lblTotalGrades"
        lblTotalGrades.Size = New Size(113, 19)
        lblTotalGrades.TabIndex = 2
        lblTotalGrades.Text = "Total Grades: 0"
        ' 
        ' lblAverageScore
        ' 
        lblAverageScore.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblAverageScore.AutoSize = True
        lblAverageScore.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblAverageScore.Location = New Point(1040, 20)
        lblAverageScore.Name = "lblAverageScore"
        lblAverageScore.Size = New Size(101, 19)
        lblAverageScore.TabIndex = 3
        lblAverageScore.Text = "Average: N/A"
        ' 
        ' lblPassingRate
        ' 
        lblPassingRate.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        lblPassingRate.AutoSize = True
        lblPassingRate.Font = New Font("Times New Roman", 12.0F, FontStyle.Bold)
        lblPassingRate.Location = New Point(1180, 20)
        lblPassingRate.Name = "lblPassingRate"
        lblPassingRate.Size = New Size(133, 19)
        lblPassingRate.TabIndex = 4
        lblPassingRate.Text = "Passing Rate: N/A"
        ' 
        ' pnlMain
        ' 
        pnlMain.Controls.Add(dgvAllGrades)
        pnlMain.Dock = DockStyle.Fill
        pnlMain.Location = New Point(0, 300)
        pnlMain.Name = "pnlMain"
        pnlMain.Padding = New Padding(10)
        pnlMain.Size = New Size(1400, 500)
        pnlMain.TabIndex = 3
        ' 
        ' dgvAllGrades
        ' 
        dgvAllGrades.AllowUserToAddRows = False
        dgvAllGrades.AllowUserToDeleteRows = False
        dgvAllGrades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvAllGrades.BackgroundColor = SystemColors.Control
        dgvAllGrades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvAllGrades.Dock = DockStyle.Fill
        dgvAllGrades.Location = New Point(10, 10)
        dgvAllGrades.Name = "dgvAllGrades"
        dgvAllGrades.ReadOnly = True
        dgvAllGrades.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvAllGrades.Size = New Size(1380, 480)
        dgvAllGrades.TabIndex = 0
        ' 
        ' ViewStudentGrades
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1400, 800)
        Controls.Add(pnlMain)
        Controls.Add(pnlActions)
        Controls.Add(pnlFilters)
        Controls.Add(pnlTop)
        Name = "ViewStudentGrades"
        StartPosition = FormStartPosition.CenterScreen
        Text = "View All Student Grades - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlTop.ResumeLayout(False)
        pnlTop.PerformLayout()
        pnlFilters.ResumeLayout(False)
        grpFilters.ResumeLayout(False)
        grpFilters.PerformLayout()
        pnlActions.ResumeLayout(False)
        pnlActions.PerformLayout()
        pnlMain.ResumeLayout(False)
        CType(dgvAllGrades, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlTop As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents pnlFilters As Panel
    Friend WithEvents grpFilters As GroupBox
    Friend WithEvents lblAcademicYear As Label
    Friend WithEvents cmbFilterAcademicYear As ComboBox
    Friend WithEvents lblSemester As Label
    Friend WithEvents cmbFilterSemester As ComboBox
    Friend WithEvents lblCourse As Label
    Friend WithEvents cmbFilterCourse As ComboBox
    Friend WithEvents lblPeriod As Label
    Friend WithEvents cmbFilterPeriod As ComboBox
    Friend WithEvents lblType As Label
    Friend WithEvents cmbFilterType As ComboBox
    Friend WithEvents lblStudentSearch As Label
    Friend WithEvents txtStudentSearch As TextBox
    Friend WithEvents btnApplyFilters As Button
    Friend WithEvents btnClearFilters As Button
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnRefreshGrades As Button
    Friend WithEvents btnExportToExcel As Button
    Friend WithEvents lblTotalGrades As Label
    Friend WithEvents lblAverageScore As Label
    Friend WithEvents lblPassingRate As Label
    Friend WithEvents pnlMain As Panel
    Friend WithEvents dgvAllGrades As DataGridView
End Class
