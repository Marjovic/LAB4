<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Enrollment
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
        pnlTermSubmenu = New Panel()
        btnViewTerm = New Button()
        btnUpdateDeleteTerm = New Button()
        btnCreateTerm = New Button()
        btnTermManagement = New Button()
        pnlSemesterSubmenu = New Panel()
        btnViewSemester = New Button()
        btnUpdateDeleteSemester = New Button()
        btnCreateSemester = New Button()
        btnSemesterManagement = New Button()
        lblEnrollmentTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlCreateSemester = New Panel()
        lblCreateSemesterTitle = New Label()
        pnlViewSemester = New Panel()
        dgvSemesters = New DataGridView()
        lblViewSemesterTitle = New Label()
        btnRefreshSemesters = New Button()
        pnlUpdateDeleteSemester = New Panel()
        lblUpdateDeleteSemesterTitle = New Label()
        pnlCreateTerm = New Panel()
        lblCreateTermTitle = New Label()
        pnlViewTerm = New Panel()
        dgvTerms = New DataGridView()
        lblViewTermTitle = New Label()
        btnRefreshTerms = New Button()
        pnlUpdateDeleteTerm = New Panel()
        lblUpdateDeleteTermTitle = New Label()
        pnlSidebar.SuspendLayout()
        pnlTermSubmenu.SuspendLayout()
        pnlSemesterSubmenu.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlCreateSemester.SuspendLayout()
        pnlViewSemester.SuspendLayout()
        CType(dgvSemesters, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteSemester.SuspendLayout()
        pnlCreateTerm.SuspendLayout()
        pnlViewTerm.SuspendLayout()
        CType(dgvTerms, ComponentModel.ISupportInitialize).BeginInit()
        pnlUpdateDeleteTerm.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(pnlTermSubmenu)
        pnlSidebar.Controls.Add(btnTermManagement)
        pnlSidebar.Controls.Add(pnlSemesterSubmenu)
        pnlSidebar.Controls.Add(btnSemesterManagement)
        pnlSidebar.Controls.Add(lblEnrollmentTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(232, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' pnlTermSubmenu
        ' 
        pnlTermSubmenu.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        pnlTermSubmenu.Controls.Add(btnViewTerm)
        pnlTermSubmenu.Controls.Add(btnUpdateDeleteTerm)
        pnlTermSubmenu.Controls.Add(btnCreateTerm)
        pnlTermSubmenu.Dock = DockStyle.Top
        pnlTermSubmenu.Location = New Point(0, 330)
        pnlTermSubmenu.Name = "pnlTermSubmenu"
        pnlTermSubmenu.Size = New Size(232, 150)
        pnlTermSubmenu.TabIndex = 4
        pnlTermSubmenu.Visible = False
        ' 
        ' btnViewTerm
        ' 
        btnViewTerm.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewTerm.Dock = DockStyle.Top
        btnViewTerm.FlatAppearance.BorderSize = 0
        btnViewTerm.FlatStyle = FlatStyle.Flat
        btnViewTerm.Font = New Font("Times New Roman", 10F)
        btnViewTerm.ForeColor = Color.White
        btnViewTerm.Location = New Point(0, 100)
        btnViewTerm.Name = "btnViewTerm"
        btnViewTerm.Padding = New Padding(35, 0, 0, 0)
        btnViewTerm.Size = New Size(232, 50)
        btnViewTerm.TabIndex = 2
        btnViewTerm.Text = "View Term"
        btnViewTerm.TextAlign = ContentAlignment.MiddleLeft
        btnViewTerm.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteTerm
        ' 
        btnUpdateDeleteTerm.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteTerm.Dock = DockStyle.Top
        btnUpdateDeleteTerm.FlatAppearance.BorderSize = 0
        btnUpdateDeleteTerm.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteTerm.Font = New Font("Times New Roman", 10F)
        btnUpdateDeleteTerm.ForeColor = Color.White
        btnUpdateDeleteTerm.Location = New Point(0, 50)
        btnUpdateDeleteTerm.Name = "btnUpdateDeleteTerm"
        btnUpdateDeleteTerm.Padding = New Padding(35, 0, 0, 0)
        btnUpdateDeleteTerm.Size = New Size(232, 50)
        btnUpdateDeleteTerm.TabIndex = 1
        btnUpdateDeleteTerm.Text = "Update/Delete Term"
        btnUpdateDeleteTerm.TextAlign = ContentAlignment.MiddleLeft
        btnUpdateDeleteTerm.UseVisualStyleBackColor = False
        ' 
        ' btnCreateTerm
        ' 
        btnCreateTerm.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateTerm.Dock = DockStyle.Top
        btnCreateTerm.FlatAppearance.BorderSize = 0
        btnCreateTerm.FlatStyle = FlatStyle.Flat
        btnCreateTerm.Font = New Font("Times New Roman", 10F)
        btnCreateTerm.ForeColor = Color.White
        btnCreateTerm.Location = New Point(0, 0)
        btnCreateTerm.Name = "btnCreateTerm"
        btnCreateTerm.Padding = New Padding(35, 0, 0, 0)
        btnCreateTerm.Size = New Size(232, 50)
        btnCreateTerm.TabIndex = 0
        btnCreateTerm.Text = "+ Create Term"
        btnCreateTerm.TextAlign = ContentAlignment.MiddleLeft
        btnCreateTerm.UseVisualStyleBackColor = False
        ' 
        ' btnTermManagement
        ' 
        btnTermManagement.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        btnTermManagement.Dock = DockStyle.Top
        btnTermManagement.FlatAppearance.BorderSize = 0
        btnTermManagement.FlatStyle = FlatStyle.Flat
        btnTermManagement.Font = New Font("Times New Roman", 11F, FontStyle.Bold)
        btnTermManagement.ForeColor = Color.White
        btnTermManagement.Location = New Point(0, 280)
        btnTermManagement.Name = "btnTermManagement"
        btnTermManagement.Size = New Size(232, 50)
        btnTermManagement.TabIndex = 3
        btnTermManagement.Text = "Term Management"
        btnTermManagement.UseVisualStyleBackColor = False
        ' 
        ' pnlSemesterSubmenu
        ' 
        pnlSemesterSubmenu.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        pnlSemesterSubmenu.Controls.Add(btnViewSemester)
        pnlSemesterSubmenu.Controls.Add(btnUpdateDeleteSemester)
        pnlSemesterSubmenu.Controls.Add(btnCreateSemester)
        pnlSemesterSubmenu.Dock = DockStyle.Top
        pnlSemesterSubmenu.Location = New Point(0, 130)
        pnlSemesterSubmenu.Name = "pnlSemesterSubmenu"
        pnlSemesterSubmenu.Size = New Size(232, 150)
        pnlSemesterSubmenu.TabIndex = 2
        pnlSemesterSubmenu.Visible = False
        ' 
        ' btnViewSemester
        ' 
        btnViewSemester.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewSemester.Dock = DockStyle.Top
        btnViewSemester.FlatAppearance.BorderSize = 0
        btnViewSemester.FlatStyle = FlatStyle.Flat
        btnViewSemester.Font = New Font("Times New Roman", 10F)
        btnViewSemester.ForeColor = Color.White
        btnViewSemester.Location = New Point(0, 100)
        btnViewSemester.Name = "btnViewSemester"
        btnViewSemester.Padding = New Padding(35, 0, 0, 0)
        btnViewSemester.Size = New Size(232, 50)
        btnViewSemester.TabIndex = 2
        btnViewSemester.Text = "View Semester"
        btnViewSemester.TextAlign = ContentAlignment.MiddleLeft
        btnViewSemester.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteSemester
        ' 
        btnUpdateDeleteSemester.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnUpdateDeleteSemester.Dock = DockStyle.Top
        btnUpdateDeleteSemester.FlatAppearance.BorderSize = 0
        btnUpdateDeleteSemester.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteSemester.Font = New Font("Times New Roman", 10F)
        btnUpdateDeleteSemester.ForeColor = Color.White
        btnUpdateDeleteSemester.Location = New Point(0, 50)
        btnUpdateDeleteSemester.Name = "btnUpdateDeleteSemester"
        btnUpdateDeleteSemester.Padding = New Padding(35, 0, 0, 0)
        btnUpdateDeleteSemester.Size = New Size(232, 50)
        btnUpdateDeleteSemester.TabIndex = 1
        btnUpdateDeleteSemester.Text = "Update/Delete Semester"
        btnUpdateDeleteSemester.TextAlign = ContentAlignment.MiddleLeft
        btnUpdateDeleteSemester.UseVisualStyleBackColor = False
        ' 
        ' btnCreateSemester
        ' 
        btnCreateSemester.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCreateSemester.Dock = DockStyle.Top
        btnCreateSemester.FlatAppearance.BorderSize = 0
        btnCreateSemester.FlatStyle = FlatStyle.Flat
        btnCreateSemester.Font = New Font("Times New Roman", 10F)
        btnCreateSemester.ForeColor = Color.White
        btnCreateSemester.Location = New Point(0, 0)
        btnCreateSemester.Name = "btnCreateSemester"
        btnCreateSemester.Padding = New Padding(35, 0, 0, 0)
        btnCreateSemester.Size = New Size(232, 50)
        btnCreateSemester.TabIndex = 0
        btnCreateSemester.Text = "+ Create Semester"
        btnCreateSemester.TextAlign = ContentAlignment.MiddleLeft
        btnCreateSemester.UseVisualStyleBackColor = False
        ' 
        ' btnSemesterManagement
        ' 
        btnSemesterManagement.BackColor = Color.FromArgb(CByte(45), CByte(45), CByte(48))
        btnSemesterManagement.Dock = DockStyle.Top
        btnSemesterManagement.FlatAppearance.BorderSize = 0
        btnSemesterManagement.FlatStyle = FlatStyle.Flat
        btnSemesterManagement.Font = New Font("Times New Roman", 11F, FontStyle.Bold)
        btnSemesterManagement.ForeColor = Color.White
        btnSemesterManagement.Location = New Point(0, 80)
        btnSemesterManagement.Name = "btnSemesterManagement"
        btnSemesterManagement.Size = New Size(232, 50)
        btnSemesterManagement.TabIndex = 1
        btnSemesterManagement.Text = "Semester Management"
        btnSemesterManagement.UseVisualStyleBackColor = False
        ' 
        ' lblEnrollmentTitle
        ' 
        lblEnrollmentTitle.BackColor = Color.Navy
        lblEnrollmentTitle.Dock = DockStyle.Top
        lblEnrollmentTitle.Font = New Font("Times New Roman", 14F, FontStyle.Bold)
        lblEnrollmentTitle.ForeColor = Color.White
        lblEnrollmentTitle.Location = New Point(0, 0)
        lblEnrollmentTitle.Name = "lblEnrollmentTitle"
        lblEnrollmentTitle.Size = New Size(232, 80)
        lblEnrollmentTitle.TabIndex = 0
        lblEnrollmentTitle.Text = "Semester/Term Management"
        lblEnrollmentTitle.TextAlign = ContentAlignment.MiddleCenter
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
        btnClose.Size = New Size(232, 50)
        btnClose.TabIndex = 5
        btnClose.Text = "🚪 Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlMainContent.Controls.Add(pnlCreateSemester)
        pnlMainContent.Controls.Add(pnlViewSemester)
        pnlMainContent.Controls.Add(pnlUpdateDeleteSemester)
        pnlMainContent.Controls.Add(pnlCreateTerm)
        pnlMainContent.Controls.Add(pnlViewTerm)
        pnlMainContent.Controls.Add(pnlUpdateDeleteTerm)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(232, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(968, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlCreateSemester
        ' 
        pnlCreateSemester.AutoScroll = True
        pnlCreateSemester.BackColor = Color.White
        pnlCreateSemester.Controls.Add(lblCreateSemesterTitle)
        pnlCreateSemester.Dock = DockStyle.Fill
        pnlCreateSemester.Location = New Point(0, 0)
        pnlCreateSemester.Name = "pnlCreateSemester"
        pnlCreateSemester.Padding = New Padding(30, 20, 30, 20)
        pnlCreateSemester.Size = New Size(968, 800)
        pnlCreateSemester.TabIndex = 0
        pnlCreateSemester.Visible = False
        ' 
        ' lblCreateSemesterTitle
        ' 
        lblCreateSemesterTitle.AutoSize = True
        lblCreateSemesterTitle.Font = New Font("Times New Roman", 20F, FontStyle.Bold)
        lblCreateSemesterTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateSemesterTitle.Location = New Point(30, 20)
        lblCreateSemesterTitle.Name = "lblCreateSemesterTitle"
        lblCreateSemesterTitle.Size = New Size(263, 31)
        lblCreateSemesterTitle.TabIndex = 0
        lblCreateSemesterTitle.Text = "Create New Semester"
        ' 
        ' pnlViewSemester
        ' 
        pnlViewSemester.BackColor = Color.White
        pnlViewSemester.Controls.Add(dgvSemesters)
        pnlViewSemester.Controls.Add(lblViewSemesterTitle)
        pnlViewSemester.Controls.Add(btnRefreshSemesters)
        pnlViewSemester.Dock = DockStyle.Fill
        pnlViewSemester.Location = New Point(0, 0)
        pnlViewSemester.Name = "pnlViewSemester"
        pnlViewSemester.Padding = New Padding(20)
        pnlViewSemester.Size = New Size(968, 800)
        pnlViewSemester.TabIndex = 1
        pnlViewSemester.Visible = False
        ' 
        ' dgvSemesters
        ' 
        dgvSemesters.AllowUserToAddRows = False
        dgvSemesters.AllowUserToDeleteRows = False
        dgvSemesters.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvSemesters.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSemesters.BackgroundColor = SystemColors.Control
        dgvSemesters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvSemesters.Location = New Point(23, 70)
        dgvSemesters.Name = "dgvSemesters"
        dgvSemesters.ReadOnly = True
        dgvSemesters.Size = New Size(922, 690)
        dgvSemesters.TabIndex = 1
        ' 
        ' lblViewSemesterTitle
        ' 
        lblViewSemesterTitle.AutoSize = True
        lblViewSemesterTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblViewSemesterTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewSemesterTitle.Location = New Point(23, 20)
        lblViewSemesterTitle.Name = "lblViewSemesterTitle"
        lblViewSemesterTitle.Size = New Size(200, 36)
        lblViewSemesterTitle.TabIndex = 0
        lblViewSemesterTitle.Text = "All Semesters"
        ' 
        ' btnRefreshSemesters
        ' 
        btnRefreshSemesters.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshSemesters.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshSemesters.FlatStyle = FlatStyle.Flat
        btnRefreshSemesters.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRefreshSemesters.ForeColor = Color.White
        btnRefreshSemesters.Location = New Point(718, 20)
        btnRefreshSemesters.Name = "btnRefreshSemesters"
        btnRefreshSemesters.Size = New Size(160, 40)
        btnRefreshSemesters.TabIndex = 2
        btnRefreshSemesters.Text = "🔄 Refresh"
        btnRefreshSemesters.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteSemester
        ' 
        pnlUpdateDeleteSemester.AutoScroll = True
        pnlUpdateDeleteSemester.BackColor = Color.White
        pnlUpdateDeleteSemester.Controls.Add(lblUpdateDeleteSemesterTitle)
        pnlUpdateDeleteSemester.Dock = DockStyle.Fill
        pnlUpdateDeleteSemester.Location = New Point(0, 0)
        pnlUpdateDeleteSemester.Name = "pnlUpdateDeleteSemester"
        pnlUpdateDeleteSemester.Padding = New Padding(20)
        pnlUpdateDeleteSemester.Size = New Size(968, 800)
        pnlUpdateDeleteSemester.TabIndex = 2
        pnlUpdateDeleteSemester.Visible = False
        ' 
        ' lblUpdateDeleteSemesterTitle
        ' 
        lblUpdateDeleteSemesterTitle.AutoSize = True
        lblUpdateDeleteSemesterTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblUpdateDeleteSemesterTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteSemesterTitle.Location = New Point(20, 20)
        lblUpdateDeleteSemesterTitle.Name = "lblUpdateDeleteSemesterTitle"
        lblUpdateDeleteSemesterTitle.Size = New Size(405, 36)
        lblUpdateDeleteSemesterTitle.TabIndex = 0
        lblUpdateDeleteSemesterTitle.Text = "Update/Delete Semester Info"
        ' 
        ' pnlCreateTerm
        ' 
        pnlCreateTerm.AutoScroll = True
        pnlCreateTerm.BackColor = Color.White
        pnlCreateTerm.Controls.Add(lblCreateTermTitle)
        pnlCreateTerm.Dock = DockStyle.Fill
        pnlCreateTerm.Location = New Point(0, 0)
        pnlCreateTerm.Name = "pnlCreateTerm"
        pnlCreateTerm.Padding = New Padding(30, 20, 30, 20)
        pnlCreateTerm.Size = New Size(968, 800)
        pnlCreateTerm.TabIndex = 3
        pnlCreateTerm.Visible = False
        ' 
        ' lblCreateTermTitle
        ' 
        lblCreateTermTitle.AutoSize = True
        lblCreateTermTitle.Font = New Font("Times New Roman", 20F, FontStyle.Bold)
        lblCreateTermTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblCreateTermTitle.Location = New Point(30, 20)
        lblCreateTermTitle.Name = "lblCreateTermTitle"
        lblCreateTermTitle.Size = New Size(220, 31)
        lblCreateTermTitle.TabIndex = 0
        lblCreateTermTitle.Text = "Create New Term"
        ' 
        ' pnlViewTerm
        ' 
        pnlViewTerm.BackColor = Color.White
        pnlViewTerm.Controls.Add(dgvTerms)
        pnlViewTerm.Controls.Add(lblViewTermTitle)
        pnlViewTerm.Controls.Add(btnRefreshTerms)
        pnlViewTerm.Dock = DockStyle.Fill
        pnlViewTerm.Location = New Point(0, 0)
        pnlViewTerm.Name = "pnlViewTerm"
        pnlViewTerm.Padding = New Padding(20)
        pnlViewTerm.Size = New Size(968, 800)
        pnlViewTerm.TabIndex = 4
        pnlViewTerm.Visible = False
        ' 
        ' dgvTerms
        ' 
        dgvTerms.AllowUserToAddRows = False
        dgvTerms.AllowUserToDeleteRows = False
        dgvTerms.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvTerms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvTerms.BackgroundColor = SystemColors.Control
        dgvTerms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTerms.Location = New Point(23, 70)
        dgvTerms.Name = "dgvTerms"
        dgvTerms.ReadOnly = True
        dgvTerms.Size = New Size(922, 690)
        dgvTerms.TabIndex = 1
        ' 
        ' lblViewTermTitle
        ' 
        lblViewTermTitle.AutoSize = True
        lblViewTermTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblViewTermTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblViewTermTitle.Location = New Point(23, 20)
        lblViewTermTitle.Name = "lblViewTermTitle"
        lblViewTermTitle.Size = New Size(148, 36)
        lblViewTermTitle.TabIndex = 0
        lblViewTermTitle.Text = "All Terms"
        ' 
        ' btnRefreshTerms
        ' 
        btnRefreshTerms.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefreshTerms.BackColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        btnRefreshTerms.FlatStyle = FlatStyle.Flat
        btnRefreshTerms.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnRefreshTerms.ForeColor = Color.White
        btnRefreshTerms.Location = New Point(718, 20)
        btnRefreshTerms.Name = "btnRefreshTerms"
        btnRefreshTerms.Size = New Size(160, 40)
        btnRefreshTerms.TabIndex = 2
        btnRefreshTerms.Text = "🔄 Refresh"
        btnRefreshTerms.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteTerm
        ' 
        pnlUpdateDeleteTerm.AutoScroll = True
        pnlUpdateDeleteTerm.BackColor = Color.White
        pnlUpdateDeleteTerm.Controls.Add(lblUpdateDeleteTermTitle)
        pnlUpdateDeleteTerm.Dock = DockStyle.Fill
        pnlUpdateDeleteTerm.Location = New Point(0, 0)
        pnlUpdateDeleteTerm.Name = "pnlUpdateDeleteTerm"
        pnlUpdateDeleteTerm.Padding = New Padding(20)
        pnlUpdateDeleteTerm.Size = New Size(968, 800)
        pnlUpdateDeleteTerm.TabIndex = 5
        pnlUpdateDeleteTerm.Visible = False
        ' 
        ' lblUpdateDeleteTermTitle
        ' 
        lblUpdateDeleteTermTitle.AutoSize = True
        lblUpdateDeleteTermTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold)
        lblUpdateDeleteTermTitle.ForeColor = Color.FromArgb(CByte(0), CByte(122), CByte(204))
        lblUpdateDeleteTermTitle.Location = New Point(20, 20)
        lblUpdateDeleteTermTitle.Name = "lblUpdateDeleteTermTitle"
        lblUpdateDeleteTermTitle.Size = New Size(354, 36)
        lblUpdateDeleteTermTitle.TabIndex = 0
        lblUpdateDeleteTermTitle.Text = "Update/Delete Term Info"
        ' 
        ' Enrollment
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "Enrollment"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Enrollment Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlTermSubmenu.ResumeLayout(False)
        pnlSemesterSubmenu.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlCreateSemester.ResumeLayout(False)
        pnlCreateSemester.PerformLayout()
        pnlViewSemester.ResumeLayout(False)
        pnlViewSemester.PerformLayout()
        CType(dgvSemesters, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteSemester.ResumeLayout(False)
        pnlUpdateDeleteSemester.PerformLayout()
        pnlCreateTerm.ResumeLayout(False)
        pnlCreateTerm.PerformLayout()
        pnlViewTerm.ResumeLayout(False)
        pnlViewTerm.PerformLayout()
        CType(dgvTerms, ComponentModel.ISupportInitialize).EndInit()
        pnlUpdateDeleteTerm.ResumeLayout(False)
        pnlUpdateDeleteTerm.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblEnrollmentTitle As Label
    Friend WithEvents btnSemesterManagement As Button
    Friend WithEvents pnlSemesterSubmenu As Panel
    Friend WithEvents btnCreateSemester As Button
    Friend WithEvents btnUpdateDeleteSemester As Button
    Friend WithEvents btnViewSemester As Button
    Friend WithEvents btnTermManagement As Button
    Friend WithEvents pnlTermSubmenu As Panel
    Friend WithEvents btnCreateTerm As Button
    Friend WithEvents btnUpdateDeleteTerm As Button
    Friend WithEvents btnViewTerm As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel

    ' Semester Management Panels
    Friend WithEvents pnlCreateSemester As Panel
    Friend WithEvents lblCreateSemesterTitle As Label
    Friend WithEvents pnlViewSemester As Panel
    Friend WithEvents lblViewSemesterTitle As Label
    Friend WithEvents dgvSemesters As DataGridView
    Friend WithEvents btnRefreshSemesters As Button
    Friend WithEvents pnlUpdateDeleteSemester As Panel
    Friend WithEvents lblUpdateDeleteSemesterTitle As Label

    ' Term Management Panels
    Friend WithEvents pnlCreateTerm As Panel
    Friend WithEvents lblCreateTermTitle As Label
    Friend WithEvents pnlViewTerm As Panel
    Friend WithEvents lblViewTermTitle As Label
    Friend WithEvents dgvTerms As DataGridView
    Friend WithEvents btnRefreshTerms As Button
    Friend WithEvents pnlUpdateDeleteTerm As Panel
    Friend WithEvents lblUpdateDeleteTermTitle As Label
End Class