Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class login
    ' Connection string - update with your MySQL server details
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Public properties to store user data after successful login
    Public Shared CurrentUserId As Integer
    Public Shared CurrentUsername As String
    Public Shared CurrentUserRole As Integer
    Public Shared CurrentUserRoleName As String

    ' Variable to track password visibility state
    Private isPasswordVisible As Boolean = False

    ' Constructor to set title immediately
    Public Sub New()
        InitializeComponent()
        Me.Text = "LMS Login"
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form title explicitly - override any application settings
        Me.Text = "LMS Login"

        ' Also set it a second time to ensure it sticks
        Application.DoEvents()
        Me.Text = "LMS Login"

        ' Set password textbox to hide characters
        password_box.PasswordChar = "*"c
        ' Set focus to username textbox
        username_box.Focus()

    End Sub

    Private Sub login_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        ' Set title again when form is shown
        Me.Text = "LMS Login"
    End Sub

    Private Sub login_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ' Set title when form is activated (gets focus)
        If Me.Text <> "LMS Login" Then
            Me.Text = "LMS Login"
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles username_box.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub password_box_TextChanged(sender As Object, e As EventArgs) Handles password_box.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles login_button.Click
        AuthenticateUser()
    End Sub

    Private Sub AuthenticateUser()
        Dim username As String = username_box.Text.Trim()
        Dim password As String = password_box.Text.Trim()

        ' Input validation
        If String.IsNullOrEmpty(username) Or String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' SQL query to get user data
                Dim query As String = "SELECT username, role_id FROM users WHERE username = @username AND password_hash = SHA2(@password, 256)"

                Using command As New MySqlCommand(query, connection)
                    ' Use parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@username", username)
                    command.Parameters.AddWithValue("@password", password)

                    Using reader As MySqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Store user data in shared variables
                            CurrentUsername = reader("username").ToString()
                            CurrentUserRole = Convert.ToInt32(reader("role_id"))

                            ' Set role name based on role_id
                            Select Case CurrentUserRole
                                Case 1
                                    CurrentUserRoleName = "Admin"
                                Case 2
                                    CurrentUserRoleName = "Teacher"
                                Case 3
                                    CurrentUserRoleName = "Student"
                                Case Else
                                    CurrentUserRoleName = "User"
                            End Select

                            ' Display success message with user info
                            Dim userInfo As String = $"Login Successful!" & vbCrLf &
                                                   $"Welcome, {CurrentUsername}" & vbCrLf &
                                                   $"Role: {CurrentUserRoleName}"

                            MessageBox.Show(userInfo, "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Clear form fields
                            username_box.Clear()
                            password_box.Clear()

                            ' Redirect based on role
                            RedirectToUserDashboard()

                        Else
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            ' Clear password field for security
                            password_box.Clear()
                            password_box.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show("Database connection error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RedirectToUserDashboard()
        Try
            ' Redirect based on role_id
            Select Case CurrentUserRole
                Case 1 ' Admin
                    Try
                        MessageBox.Show($"Redirecting to Admin Dashboard" & vbCrLf &
                                      $"User: {CurrentUsername}" & vbCrLf &
                                      $"Role: {CurrentUserRoleName}", "Admin Access")

                        ' Hide login form and show Admin form
                        Me.Hide()
                        Dim adminForm As New Admin()
                        adminForm.Show()

                    Catch ex As Exception
                        MessageBox.Show("Error opening Admin dashboard: " & ex.Message, "Form Error")
                        Me.Show()
                    End Try

                Case 2 ' Teacher
                    Try
                        MessageBox.Show($"Redirecting to Teacher Dashboard" & vbCrLf &
                                      $"User: {CurrentUsername}" & vbCrLf &
                                      $"Role: {CurrentUserRoleName}", "Teacher Access")

                        ' Hide login form and show Teacher form
                        Me.Hide()
                        Dim teacherForm As New TeacherDashboard()
                        teacherForm.Show()

                    Catch ex As Exception
                        MessageBox.Show("Error opening Teacher dashboard: " & ex.Message, "Form Error")
                        Me.Show()
                    End Try

                Case 3 ' Student
                    Try
                        MessageBox.Show($"Redirecting to Student Dashboard" & vbCrLf &
                                      $"User: {CurrentUsername}" & vbCrLf &
                                      $"Role: {CurrentUserRoleName}", "Student Access")

                        ' Hide login form and show Student form
                        Me.Hide()
                        Dim studentForm As New StudentDashboard()
                        studentForm.Show()

                    Catch ex As Exception
                        MessageBox.Show("Error opening Student dashboard: " & ex.Message, "Form Error")
                        Me.Show()
                    End Try

                Case Else
                    MessageBox.Show($"Unknown role. Contact administrator." & vbCrLf &
                                  $"User: {CurrentUsername}" & vbCrLf &
                                  $"Role ID: {CurrentUserRole}", "Access Error")
            End Select

        Catch ex As Exception
            MessageBox.Show("Error during redirection: " & ex.Message, "Redirection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Show()
        End Try
    End Sub

    ' Method to get current user data from anywhere in the application
    Public Shared Function GetCurrentUserInfo() As String
        Return $"Username: {CurrentUsername}, Role: {CurrentUserRoleName} (ID: {CurrentUserRole})"
    End Function

    ' Method to clear user session (for logout)
    Public Shared Sub ClearUserSession()
        CurrentUserId = 0
        CurrentUsername = ""
        CurrentUserRole = 0
        CurrentUserRoleName = ""
    End Sub

    ' Handle Enter key press for better user experience
    Private Sub password_box_KeyPress(sender As Object, e As KeyPressEventArgs) Handles password_box.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            AuthenticateUser()
        End If
    End Sub

    Private Sub username_box_KeyPress(sender As Object, e As KeyPressEventArgs) Handles username_box.KeyPress
        If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            password_box.Focus()
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class