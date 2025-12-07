<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportsForm
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
        btnCourseAnalytics = New Button()
        btnStudentTranscript = New Button()
        lblReportsTitle = New Label()
        btnClose = New Button()
        pnlMainContent = New Panel()
        pnlStudentTranscript = New Panel()
        pnlCourseAnalytics = New Panel()
        pnlSidebar.SuspendLayout()
        pnlMainContent.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnCourseAnalytics)
        pnlSidebar.Controls.Add(btnStudentTranscript)
        pnlSidebar.Controls.Add(lblReportsTitle)
        pnlSidebar.Controls.Add(btnClose)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(220, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnStudentTranscript
        ' 
        btnStudentTranscript.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnStudentTranscript.Dock = DockStyle.Top
        btnStudentTranscript.FlatAppearance.BorderSize = 0
        btnStudentTranscript.FlatStyle = FlatStyle.Flat
        btnStudentTranscript.Font = New Font("Times New Roman", 11.0F)
        btnStudentTranscript.ForeColor = Color.White
        btnStudentTranscript.Location = New Point(0, 80)
        btnStudentTranscript.Name = "btnStudentTranscript"
        btnStudentTranscript.Size = New Size(220, 50)
        btnStudentTranscript.TabIndex = 1
        btnStudentTranscript.Text = "📄 Student Transcript Generator"
        btnStudentTranscript.UseVisualStyleBackColor = False
        ' 
        ' btnCourseAnalytics
        ' 
        btnCourseAnalytics.BackColor = Color.FromArgb(CByte(35), CByte(35), CByte(38))
        btnCourseAnalytics.Dock = DockStyle.Top
        btnCourseAnalytics.FlatAppearance.BorderSize = 0
        btnCourseAnalytics.FlatStyle = FlatStyle.Flat
        btnCourseAnalytics.Font = New Font("Times New Roman", 11.0F)
        btnCourseAnalytics.ForeColor = Color.White
        btnCourseAnalytics.Location = New Point(0, 130)
        btnCourseAnalytics.Name = "btnCourseAnalytics"
        btnCourseAnalytics.Size = New Size(220, 50)
        btnCourseAnalytics.TabIndex = 2
        btnCourseAnalytics.Text = "📊 Course Analytics"
        btnCourseAnalytics.UseVisualStyleBackColor = False
        ' 
        ' lblReportsTitle
        ' 
        lblReportsTitle.BackColor = Color.Navy
        lblReportsTitle.Dock = DockStyle.Top
        lblReportsTitle.Font = New Font("Times New Roman", 13.0F, FontStyle.Bold)
        lblReportsTitle.ForeColor = Color.White
        lblReportsTitle.Location = New Point(0, 0)
        lblReportsTitle.Name = "lblReportsTitle"
        lblReportsTitle.Size = New Size(220, 80)
        lblReportsTitle.TabIndex = 0
        lblReportsTitle.Text = "Reports"
        lblReportsTitle.TextAlign = ContentAlignment.MiddleCenter
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
        btnClose.TabIndex = 3
        btnClose.Text = "🚪 Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        pnlMainContent.Controls.Add(pnlStudentTranscript)
        pnlMainContent.Controls.Add(pnlCourseAnalytics)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(220, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(980, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlStudentTranscript
        ' 
        pnlStudentTranscript.Dock = DockStyle.Fill
        pnlStudentTranscript.Location = New Point(0, 0)
        pnlStudentTranscript.Name = "pnlStudentTranscript"
        pnlStudentTranscript.Size = New Size(980, 800)
        pnlStudentTranscript.TabIndex = 0
        pnlStudentTranscript.Visible = True
        ' 
        ' pnlCourseAnalytics
        ' 
        pnlCourseAnalytics.Dock = DockStyle.Fill
        pnlCourseAnalytics.Location = New Point(0, 0)
        pnlCourseAnalytics.Name = "pnlCourseAnalytics"
        pnlCourseAnalytics.Size = New Size(980, 800)
        pnlCourseAnalytics.TabIndex = 1
        pnlCourseAnalytics.Visible = False
        ' 
        ' ReportsForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Name = "ReportsForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Reports - MGOD LMS"
        WindowState = FormWindowState.Maximized
        pnlSidebar.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        ResumeLayout(False)

        ' Initialize Student Transcript controls after form is created
        InitializeStudentTranscriptPanel()
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblReportsTitle As Label
    Friend WithEvents btnStudentTranscript As Button
    Friend WithEvents btnCourseAnalytics As Button
    Friend WithEvents btnClose As Button

    ' Main Content
    Friend WithEvents pnlMainContent As Panel
    Friend WithEvents pnlStudentTranscript As Panel
    Friend WithEvents pnlCourseAnalytics As Panel

    ' Student Transcript Controls
    Friend WithEvents lblTranscriptTitle As Label
    Friend WithEvents txtStudentSearch As TextBox
    Friend WithEvents cmbStudentSelect As ComboBox
    Friend WithEvents btnGenerateTranscript As Button
    Friend WithEvents lblStudentInfo As Label
    Friend WithEvents dgvTranscript As DataGridView
    Friend WithEvents grpTranscriptSummary As GroupBox
    Friend WithEvents lblTranscriptSummary As Label
    Friend WithEvents btnExportTranscript As Button
    Friend WithEvents btnPrintTranscript As Button

    Private Sub InitializeStudentTranscriptPanel()
        pnlStudentTranscript.SuspendLayout()

        ' IMPORTANT: Enable auto-scroll for the panel to handle overflow
        pnlStudentTranscript.AutoScroll = True

        ' Title Label
        lblTranscriptTitle = New Label With {
            .Text = "Student Transcript Generator",
     .Font = New Font("Times New Roman", 20, FontStyle.Bold),
       .ForeColor = Color.FromArgb(0, 122, 204),
            .Location = New Point(30, 20),
      .Size = New Size(500, 40),
            .AutoSize = False
        }
        pnlStudentTranscript.Controls.Add(lblTranscriptTitle)

        ' Search Label
        Dim lblSearch As New Label With {
      .Text = "Search Student:",
      .Font = New Font("Times New Roman", 12, FontStyle.Bold),
         .Location = New Point(30, 80),
      .Size = New Size(150, 25)
        }
        pnlStudentTranscript.Controls.Add(lblSearch)

        ' Search TextBox
        txtStudentSearch = New TextBox With {
            .Name = "txtStudentSearch",
        .Font = New Font("Times New Roman", 11),
            .Location = New Point(30, 110),
            .Size = New Size(250, 25),
            .PlaceholderText = "Type student number or name..."
        }
        pnlStudentTranscript.Controls.Add(txtStudentSearch)

        ' Student ComboBox Label
        Dim lblStudent As New Label With {
            .Text = "Select Student:",
      .Font = New Font("Times New Roman", 12, FontStyle.Bold),
       .Location = New Point(300, 80),
      .Size = New Size(150, 25)
        }
        pnlStudentTranscript.Controls.Add(lblStudent)

        ' Student ComboBox
        cmbStudentSelect = New ComboBox With {
            .Name = "cmbStudentSelect",
   .Font = New Font("Times New Roman", 11),
      .Location = New Point(300, 110),
     .Size = New Size(450, 25),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        pnlStudentTranscript.Controls.Add(cmbStudentSelect)

        ' Generate Button
        btnGenerateTranscript = New Button With {
            .Name = "btnGenerateTranscript",
          .Text = "Generate Transcript",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(770, 107),
   .Size = New Size(180, 30),
     .BackColor = Color.FromArgb(0, 122, 204),
       .ForeColor = Color.White,
     .FlatStyle = FlatStyle.Flat
        }
        pnlStudentTranscript.Controls.Add(btnGenerateTranscript)

        ' Student Info Label - INCREASED HEIGHT to show all 8+ lines properly
        lblStudentInfo = New Label With {
          .Name = "lblStudentInfo",
          .Text = "",
       .Font = New Font("Times New Roman", 10, FontStyle.Regular),
         .Location = New Point(30, 150),
     .Size = New Size(1150, 150),
  .BorderStyle = BorderStyle.FixedSingle,
 .BackColor = Color.FromArgb(250, 250, 255),
.Visible = False,
      .Padding = New Padding(10),
    .AutoSize = False,
       .UseMnemonic = False
        }
        pnlStudentTranscript.Controls.Add(lblStudentInfo)

        ' Transcript DataGridView - FULL WIDTH with Scroll
        dgvTranscript = New DataGridView With {
 .Name = "dgvTranscript",
   .Location = New Point(30, 300),
          .Size = New Size(1150, 290),
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells,
 .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
          .ReadOnly = True,
     .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        .MultiSelect = False,
.BackgroundColor = Color.White,
        .BorderStyle = BorderStyle.Fixed3D,
        .ScrollBars = ScrollBars.Both,
            .ColumnHeadersDefaultCellStyle = New DataGridViewCellStyle With {
    .Font = New Font("Times New Roman", 10, FontStyle.Bold),
      .BackColor = Color.FromArgb(0, 122, 204),
     .ForeColor = Color.White,
    .Alignment = DataGridViewContentAlignment.MiddleCenter,
  .WrapMode = DataGridViewTriState.True
            },
  .DefaultCellStyle = New DataGridViewCellStyle With {
       .Font = New Font("Times New Roman", 10),
.SelectionBackColor = Color.FromArgb(173, 216, 230),
      .SelectionForeColor = Color.Black,
         .WrapMode = DataGridViewTriState.False
  },
          .RowTemplate = New DataGridViewRow With {
       .Height = 28
            },
          .ColumnHeadersHeight = 35
  }
        pnlStudentTranscript.Controls.Add(dgvTranscript)

        ' Summary GroupBox - Wider at bottom
        grpTranscriptSummary = New GroupBox With {
    .Name = "grpTranscriptSummary",
            .Text = "📚 TRANSCRIPT SUMMARY",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
  .Location = New Point(30, 600),
     .Size = New Size(600, 120),
    .Visible = False
      }
        pnlStudentTranscript.Controls.Add(grpTranscriptSummary)

        ' Summary Label inside GroupBox
        lblTranscriptSummary = New Label With {
        .Name = "lblTranscriptSummary",
            .Text = "",
        .Font = New Font("Times New Roman", 10),
    .Location = New Point(10, 25),
   .Size = New Size(580, 85),
        .AutoSize = False
        }
        grpTranscriptSummary.Controls.Add(lblTranscriptSummary)

        ' Export Button
        btnExportTranscript = New Button With {
     .Name = "btnExportTranscript",
     .Text = "📤 Export to Excel",
   .Font = New Font("Times New Roman", 11, FontStyle.Bold),
   .Location = New Point(660, 620),
      .Size = New Size(250, 45),
      .BackColor = Color.FromArgb(0, 122, 204),
  .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        pnlStudentTranscript.Controls.Add(btnExportTranscript)

        ' Print Button
        btnPrintTranscript = New Button With {
       .Name = "btnPrintTranscript",
         .Text = "🖨️ Print Transcript",
.Font = New Font("Times New Roman", 11, FontStyle.Bold),
     .Location = New Point(940, 620),
       .Size = New Size(240, 45),
            .BackColor = Color.FromArgb(0, 122, 204),
            .ForeColor = Color.White,
       .FlatStyle = FlatStyle.Flat
        }
        pnlStudentTranscript.Controls.Add(btnPrintTranscript)

        pnlStudentTranscript.ResumeLayout(False)
    End Sub
End Class
