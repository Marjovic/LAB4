<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GradingManagement
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        pnlSidebar = New Panel()
        btnReports = New Button()
        btnAssignmentType = New Button()
        btnOfferingGradeWeight = New Button()
        btnViewStudentGrades = New Button()
        lblGradingTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlSidebar.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnReports)
        pnlSidebar.Controls.Add(btnViewStudentGrades)
        pnlSidebar.Controls.Add(btnOfferingGradeWeight)
        pnlSidebar.Controls.Add(btnAssignmentType)
        pnlSidebar.Controls.Add(lblGradingTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnReports
        ' 
        btnReports.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnReports.Dock = DockStyle.Top
        btnReports.FlatAppearance.BorderSize = 0
        btnReports.FlatStyle = FlatStyle.Flat
        btnReports.Font = New Font("Times New Roman", 11.0F)
        btnReports.ForeColor = Color.White
        btnReports.Location = New Point(0, 230)
        btnReports.Name = "btnReports"
        btnReports.Size = New Size(220, 50)
        btnReports.TabIndex = 4
        btnReports.Text = "📊 Reports"
        btnReports.UseVisualStyleBackColor = False
        ' 
        ' btnAssignmentType
        ' 
        btnAssignmentType.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnAssignmentType.Dock = DockStyle.Top
        btnAssignmentType.FlatAppearance.BorderSize = 0
        btnAssignmentType.FlatStyle = FlatStyle.Flat
        btnAssignmentType.Font = New Font("Times New Roman", 11.0F)
        btnAssignmentType.ForeColor = Color.White
        btnAssignmentType.Location = New Point(0, 80)
        btnAssignmentType.Name = "btnAssignmentType"
        btnAssignmentType.Size = New Size(220, 50)
        btnAssignmentType.TabIndex = 1
        btnAssignmentType.Text = "📝 Assignment Type Management"
        btnAssignmentType.UseVisualStyleBackColor = False
        ' 
        ' btnOfferingGradeWeight
        ' 
        btnOfferingGradeWeight.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnOfferingGradeWeight.Dock = DockStyle.Top
        btnOfferingGradeWeight.FlatAppearance.BorderSize = 0
        btnOfferingGradeWeight.FlatStyle = FlatStyle.Flat
        btnOfferingGradeWeight.Font = New Font("Times New Roman", 11.0F)
        btnOfferingGradeWeight.ForeColor = Color.White
        btnOfferingGradeWeight.Location = New Point(0, 130)
        btnOfferingGradeWeight.Name = "btnOfferingGradeWeight"
        btnOfferingGradeWeight.Size = New Size(220, 50)
        btnOfferingGradeWeight.TabIndex = 2
        btnOfferingGradeWeight.Text = "⚖️ Offerings Grade Management"
        btnOfferingGradeWeight.UseVisualStyleBackColor = False
        ' 
        ' btnViewStudentGrades
        ' 
        btnViewStudentGrades.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnViewStudentGrades.Dock = DockStyle.Top
        btnViewStudentGrades.FlatAppearance.BorderSize = 0
        btnViewStudentGrades.FlatStyle = FlatStyle.Flat
        btnViewStudentGrades.Font = New Font("Times New Roman", 11.0F)
        btnViewStudentGrades.ForeColor = Color.White
        btnViewStudentGrades.Location = New Point(0, 180)
        btnViewStudentGrades.Name = "btnViewStudentGrades"
        btnViewStudentGrades.Size = New Size(220, 50)
        btnViewStudentGrades.TabIndex = 3
        btnViewStudentGrades.Text = "📊 View Student Grades"
        btnViewStudentGrades.UseVisualStyleBackColor = False
        ' 
        ' lblGradingTitle
        ' 
        lblGradingTitle.BackColor = Color.Navy
        lblGradingTitle.Dock = DockStyle.Top
        lblGradingTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblGradingTitle.ForeColor = Color.White
        lblGradingTitle.Location = New Point(0, 0)
        lblGradingTitle.Name = "lblGradingTitle"
        lblGradingTitle.Size = New Size(220, 80)
        lblGradingTitle.TabIndex = 0
        lblGradingTitle.Text = "Grading Management"
        lblGradingTitle.TextAlign = ContentAlignment.MiddleCenter
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
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' GradingManagement
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "GradingManagement"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Grading Management - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblGradingTitle As Label
    Friend WithEvents btnAssignmentType As Button
    Friend WithEvents btnOfferingGradeWeight As Button
    Friend WithEvents btnViewStudentGrades As Button
    Friend WithEvents btnReports As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel
End Class
