<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        username_box = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        password_box = New TextBox()
        Label3 = New Label()
        login_button = New Button()
        SuspendLayout()
        ' 
        ' username_box
        ' 
        username_box.Location = New Point(139, 141)
        username_box.Margin = New Padding(4, 3, 4, 3)
        username_box.Name = "username_box"
        username_box.Size = New Size(487, 32)
        username_box.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(41, 144)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(99, 23)
        Label1.TabIndex = 1
        Label1.Text = "Username:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(44, 233)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 23)
        Label2.TabIndex = 2
        Label2.Text = "Password:"
        ' 
        ' password_box
        ' 
        password_box.Location = New Point(139, 230)
        password_box.Margin = New Padding(4, 3, 4, 3)
        password_box.Name = "password_box"
        password_box.Size = New Size(487, 32)
        password_box.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(38, 46)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(414, 27)
        Label3.TabIndex = 4
        Label3.Text = "Please enter your username and password"
        ' 
        ' login_button
        ' 
        login_button.Font = New Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        login_button.Location = New Point(529, 331)
        login_button.Margin = New Padding(4, 3, 4, 3)
        login_button.Name = "login_button"
        login_button.Size = New Size(97, 32)
        login_button.TabIndex = 5
        login_button.Text = "Login"
        login_button.UseVisualStyleBackColor = True
        ' 
        ' login
        ' 
        AutoScaleDimensions = New SizeF(12F, 23F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1372, 690)
        Controls.Add(login_button)
        Controls.Add(Label3)
        Controls.Add(password_box)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(username_box)
        Font = New Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ForeColor = SystemColors.Desktop
        Margin = New Padding(5, 4, 5, 4)
        Name = "login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents username_box As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents password_box As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents login_button As Button

End Class
