<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StudentDashboard
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
        SuspendLayout()
        ' 
        ' StudentDashboard
        ' 
        AutoScaleDimensions = New SizeF(9F, 23F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(900, 800)
        Font = New Font("Arial Narrow", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Margin = New Padding(2, 3, 2, 3)
        Name = "StudentDashboard"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Student Dashboard"
        ResumeLayout(False)

    End Sub

    Private Sub StudentDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
