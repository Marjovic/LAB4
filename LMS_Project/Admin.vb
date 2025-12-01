Imports MySql.Data.MySqlClient
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Public Class Admin
    ' Connection string - same as login form
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=;"

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the form title with current user info
        Me.Text = $"Admin Dashboard - Welcome {login.CurrentUsername}"

        ' Set welcome message
        lblWelcome.Text = $"Welcome, {login.CurrentUsername}"

        ' Initialize role dropdown
        InitializeRoleDropdown()

        ' Add event handlers for input validation
        AddHandler txtFirstName.KeyPress, AddressOf ValidateNameInput
        AddHandler txtLastName.KeyPress, AddressOf ValidateNameInput
        AddHandler txtMiddleName.KeyPress, AddressOf ValidateNameInput
        AddHandler txtUsername.KeyPress, AddressOf ValidateUsernameInput
        AddHandler txtPassword.KeyPress, AddressOf ValidatePasswordInput
        AddHandler txtNewPassword.KeyPress, AddressOf ValidatePasswordInput
        AddHandler txtStudentEmail.KeyPress, AddressOf ValidateEmailInput
        AddHandler txtInstructorEmail.KeyPress, AddressOf ValidateEmailInput

        AddHandler txtDeptCode.KeyPress, AddressOf ValidateDepartmentCodeInput
        AddHandler txtDeptName.KeyPress, AddressOf ValidateDepartmentNameInput
        AddHandler txtUpdateDeptCode.KeyPress, AddressOf ValidateDepartmentCodeInput
        AddHandler txtUpdateDeptName.KeyPress, AddressOf ValidateDepartmentNameInput

        ' Add event handler for role selection change
        AddHandler cmbRole.SelectedIndexChanged, AddressOf cmbRole_SelectedIndexChanged

        ' Initialize gender combo box
        cmbGender.SelectedIndex = 3 ' Default to "Prefer not to say"
        dtpHireDate.Value = DateTime.Now

        ' Add event handler for update role selection change
        AddHandler cmbUpdateRole.SelectedIndexChanged, AddressOf cmbUpdateRole_SelectedIndexChanged

        ' Initialize enrollment status dropdown
        InitializeEnrollmentStatusDropdown()

        ' Initialize year level and department dropdowns
        InitializeYearLevelDropdown()
        InitializeDepartmentDropdown()

        ' Load user data and populate dropdowns
        LoadUserData()
        LoadUserResetDropdown()
        LoadDashboardStats()

        ' Show dashboard by default
        ShowPanel(pnlDashboard)

        InitializeHeadInstructorDropdown()
        LoadDepartmentsData()
        LoadDepartmentUpdateDropdown()
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlDashboard.Visible = False
        pnlAddUser.Visible = False
        pnlUserDetails.Visible = False
        pnlResetPassword.Visible = False
        pnlUpdateDeleteUser.Visible = False
        pnlDepartmentManagement.Visible = False
        pnlAddDepartment.Visible = False
        pnlUpdateDeleteDepartment.Visible = False

        ' Show the selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    ' NEW METHOD: Handle role selection change
    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbRole.SelectedValue Is Nothing Then
            pnlStudentFields.Visible = False
            pnlInstructorFields.Visible = False
            Return
        End If

        Dim selectedRoleId As Integer = Convert.ToInt32(cmbRole.SelectedValue)

        ' Hide both panels first
        pnlStudentFields.Visible = False
        pnlInstructorFields.Visible = False

        ' Show appropriate panel based on role
        Select Case selectedRoleId
            Case 2 ' Instructor/Teacher
                pnlInstructorFields.Visible = True
            Case 3 ' Student
                pnlStudentFields.Visible = True
            Case Else ' Admin or other
                ' Keep both panels hidden
        End Select
    End Sub

    ' NEW METHOD: Handle update role selection change
    Private Sub cmbUpdateRole_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbUpdateRole.SelectedValue Is Nothing Then
            pnlUpdateStudentFields.Visible = False
            pnlUpdateInstructorFields.Visible = False
            Return
        End If

        ' Safety check: Ensure SelectedValue is an integer before proceeding
        Dim selectedRoleId As Integer
        Try
            ' Check if SelectedValue is a DataRowView (happens during initialization)
            If TypeOf cmbUpdateRole.SelectedValue Is DataRowView Then
                Return ' Exit silently during initialization
            End If

            ' Convert to integer
            selectedRoleId = Convert.ToInt32(cmbUpdateRole.SelectedValue)
        Catch ex As Exception
            ' If conversion fails, exit silently
            Return
        End Try

        ' Hide both panels first
        pnlUpdateStudentFields.Visible = False
        pnlUpdateInstructorFields.Visible = False

        ' Show appropriate panel based on role
        Select Case selectedRoleId
            Case 2 ' Instructor/Teacher
                pnlUpdateInstructorFields.Visible = True
                ' Enable name fields for instructor
                txtUpdateFirstName.Enabled = True
                txtUpdateMiddleName.Enabled = True
                txtUpdateLastName.Enabled = True
            Case 3 ' Student
                pnlUpdateStudentFields.Visible = True
                ' Enable name fields for student
                txtUpdateFirstName.Enabled = True
                txtUpdateMiddleName.Enabled = True
                txtUpdateLastName.Enabled = True
            Case 1 ' Admin
                ' Disable name fields for admin
                txtUpdateFirstName.Enabled = False
                txtUpdateMiddleName.Enabled = False
                txtUpdateLastName.Enabled = False
                ' Clear name fields
                txtUpdateFirstName.Clear()
                txtUpdateMiddleName.Clear()
                txtUpdateLastName.Clear()
        End Select
    End Sub

    Private Sub ResetButtonColors()
        ' Reset all button colors to default
        btnDashboard.BackColor = Color.FromArgb(45, 45, 48)
        btnUserManagement.BackColor = Color.FromArgb(45, 45, 48)
        btnDepartmentManagement.BackColor = Color.FromArgb(45, 45, 48)
        btnCourseManagement.BackColor = Color.FromArgb(45, 45, 48)
        btnEnrollmentManagement.BackColor = Color.FromArgb(45, 45, 48)
        btnAddUser.BackColor = Color.FromArgb(35, 35, 38)
        btnUserDetails.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteUser.BackColor = Color.FromArgb(35, 35, 38)
        btnResetPassword.BackColor = Color.FromArgb(35, 35, 38)
        btnAddDepartment.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteDepartment.BackColor = Color.FromArgb(35, 35, 38)
        btnDepartmentDetails.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button, Optional isSubmenu As Boolean = False)
        If isSubmenu Then
            btn.BackColor = Color.FromArgb(0, 122, 204)
        Else
            btn.BackColor = Color.FromArgb(0, 122, 204)
        End If
    End Sub

    Private Sub btnDashboard_Click(sender As Object, e As EventArgs) Handles btnDashboard.Click
        ShowPanel(pnlDashboard)
        SetActiveButton(btnDashboard)
        pnlUserManagementSubmenu.Visible = False
        LoadDashboardStats()
    End Sub

    Private Sub btnUserManagement_Click(sender As Object, e As EventArgs) Handles btnUserManagement.Click
        ' Toggle submenu visibility
        pnlUserManagementSubmenu.Visible = Not pnlUserManagementSubmenu.Visible
        ' Close Department Management submenu if open
        pnlDepartmentManagementSubmenu.Visible = False

        ' Update button text to show collapse/expand state
        If pnlUserManagementSubmenu.Visible Then
            btnUserManagement.Text = "User Management (Expanded)"
        Else
            btnUserManagement.Text = "User Management"
        End If
    End Sub

    Private Sub btnCourseManagement_Click(sender As Object, e As EventArgs) Handles btnCourseManagement.Click
        ' Open Course Management form as a dialog
        Dim courseForm As New Course()
        courseForm.ShowDialog()

        ' Set active button
        SetActiveButton(btnCourseManagement)
    End Sub

    Private Sub btnEnrollmentManagement_Click(sender As Object, e As EventArgs) Handles btnEnrollmentManagement.Click
        ' Open Enrollment Management form as a dialog
        Dim enrollmentForm As New Enrollment()
        enrollmentForm.ShowDialog()

        ' Set active button
        SetActiveButton(btnEnrollmentManagement)
    End Sub

    Private Sub btnAddUserNav_Click(sender As Object, e As EventArgs) Handles btnAddUser.Click
        ShowPanel(pnlAddUser)
        SetActiveButton(btnAddUser, True)
        SetActiveButton(btnUserManagement)
        ClearAddUserForm()
    End Sub

    Private Sub btnUserDetailsNav_Click(sender As Object, e As EventArgs) Handles btnUserDetails.Click
        ShowPanel(pnlUserDetails)
        SetActiveButton(btnUserDetails, True)
        SetActiveButton(btnUserManagement)
        LoadUserData()
    End Sub

    Private Sub btnResetPasswordNav_Click(sender As Object, e As EventArgs) Handles btnResetPassword.Click
        ShowPanel(pnlResetPassword)
        SetActiveButton(btnResetPassword, True)
        SetActiveButton(btnUserManagement)
    End Sub

    Private Sub btnUpdateDeleteUserNav_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteUser.Click
        ShowPanel(pnlUpdateDeleteUser)
        SetActiveButton(btnUpdateDeleteUser, True)
        SetActiveButton(btnUserManagement)
        LoadUserUpdateDropdown()
        ClearUpdateForm()
    End Sub

    ' ============= DASHBOARD METHODS =============

    Private Sub LoadDashboardStats()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Get total users (only active users)
                Dim userQuery As String = "SELECT COUNT(*) FROM Users WHERE is_active = TRUE"
                Using command As New MySqlCommand(userQuery, connection)
                    Dim totalUsers As Integer = Convert.ToInt32(command.ExecuteScalar())
                    lblTotalUsers.Text = "Total Users" & vbCrLf & totalUsers.ToString()
                End Using

                ' Get total instructors (only active employment status)
                Dim instructorQuery As String = "SELECT COUNT(*) FROM Instructors WHERE employment_status = 'Active'"
                Using command As New MySqlCommand(instructorQuery, connection)
                    Dim totalInstructors As Integer = Convert.ToInt32(command.ExecuteScalar())
                    lblTotalInstructors.Text = "Total Instructors" & vbCrLf & totalInstructors.ToString()
                End Using

                ' Get total students
                Dim studentQuery As String = "SELECT COUNT(*) FROM Students"
                Using command As New MySqlCommand(studentQuery, connection)
                    Dim totalStudents As Integer = Convert.ToInt32(command.ExecuteScalar())
                    lblTotalStudents.Text = "Total Students" & vbCrLf & totalStudents.ToString()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading dashboard statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeRoleDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT role_id, role_name FROM Roles ORDER BY role_id"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim roleTable As New DataTable()
                    adapter.Fill(roleTable)
                    cmbRole.DataSource = roleTable
                    cmbRole.DisplayMember = "role_name"
                    cmbRole.ValueMember = "role_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading roles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeEnrollmentStatusDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                ' Remove the is_active_status filter to show ALL enrollment statuses
                Dim query As String = "SELECT status_id, status_name FROM Enrollment_Status_Types ORDER BY status_id"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim statusTable As New DataTable()
                    adapter.Fill(statusTable)

                    ' Add a default "Select Status" row
                    Dim defaultRow As DataRow = statusTable.NewRow()
                    defaultRow("status_id") = DBNull.Value
                    defaultRow("status_name") = "-- Select Status --"
                    statusTable.Rows.InsertAt(defaultRow, 0)

                    cmbEnrollmentStatus.DataSource = statusTable
                    cmbEnrollmentStatus.DisplayMember = "status_name"
                    cmbEnrollmentStatus.ValueMember = "status_id"
                    cmbEnrollmentStatus.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading enrollment statuses: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeYearLevelDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT year_level_id, year_level_name FROM Year_Levels ORDER BY year_number"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim yearLevelTable As New DataTable()
                    adapter.Fill(yearLevelTable)

                    cmbYearLevel.DataSource = yearLevelTable
                    cmbYearLevel.DisplayMember = "year_level_name"
                    cmbYearLevel.ValueMember = "year_level_id"

                    ' Set to first item if available
                    If cmbYearLevel.Items.Count > 0 Then
                        cmbYearLevel.SelectedIndex = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading year levels: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeDepartmentDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT department_id, CONCAT(department_code, ' - ', department_name) as display_name FROM Departments ORDER BY department_name"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim departmentTable As New DataTable()
                    adapter.Fill(departmentTable)

                    ' Bind to student department dropdown
                    cmbDepartment.DataSource = departmentTable
                    cmbDepartment.DisplayMember = "display_name"
                    cmbDepartment.ValueMember = "department_id"

                    ' Set to first item if available
                    If cmbDepartment.Items.Count > 0 Then
                        cmbDepartment.SelectedIndex = 0
                    End If

                    ' Bind to instructor department dropdown (create a copy of the DataTable)
                    Dim instructorDeptTable As DataTable = departmentTable.Copy()
                    cmbInstructorDepartment.DataSource = instructorDeptTable
                    cmbInstructorDepartment.DisplayMember = "display_name"
                    cmbInstructorDepartment.ValueMember = "department_id"

                    ' Set to first item if available
                    If cmbInstructorDepartment.Items.Count > 0 Then
                        cmbInstructorDepartment.SelectedIndex = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUserResetDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT u.user_id, CONCAT(u.username, ' - ', r.role_name) as display_name FROM Users u INNER JOIN Roles r ON u.role_id = r.role_id WHERE u.username != @current_user AND u.is_active = TRUE ORDER BY u.username"
                Using adapter As New MySqlDataAdapter(query, connection)
                    adapter.SelectCommand.Parameters.AddWithValue("@current_user", login.CurrentUsername)
                    Dim userTable As New DataTable()
                    adapter.Fill(userTable)
                    cmbSelectUserReset.DataSource = userTable
                    cmbSelectUserReset.DisplayMember = "display_name"
                    cmbSelectUserReset.ValueMember = "user_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading users for password reset: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Input validation methods
    Private Sub ValidateNameInput(sender As Object, e As KeyPressEventArgs)
        ' Allow only letters, spaces, backspace, and delete
        If Not (Char.IsLetter(e.KeyChar) OrElse e.KeyChar = " "c OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            MessageBox.Show("Names can only contain letters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ValidateUsernameInput(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)

        ' Allow backspace and delete
        If e.KeyChar = ControlChars.Back Then
            Return
        End If

        ' If this is the first character, it must be a letter
        If textBox.Text.Length = 0 Then
            If Not Char.IsLetter(e.KeyChar) Then
                e.Handled = True
                MessageBox.Show("Username must start with a letter.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            ' After the first character, allow letters, numbers, underscore, and @
            If Not (Char.IsLetter(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "_"c OrElse e.KeyChar = "@"c) Then
                e.Handled = True
                MessageBox.Show("Username can only contain letters, numbers, underscore, and @ (must start with a letter).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If
    End Sub

    Private Sub ValidatePasswordInput(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)

        ' Allow backspace and delete
        If e.KeyChar = ControlChars.Back Then
            Return
        End If

        ' If this is the first character, it must be a letter
        If textBox.Text.Length = 0 Then
            If Not Char.IsLetter(e.KeyChar) Then
                e.Handled = True
                MessageBox.Show("Password must start with a letter.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            ' After the first character, allow letters, numbers, underscore, and @
            If Not (Char.IsLetter(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "_"c OrElse e.KeyChar = "@"c) Then
                e.Handled = True
                MessageBox.Show("Password can only contain letters, numbers, underscore, and @ (must start with a letter).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If
    End Sub

    Private Sub ValidateEmailInput(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)

        ' Allow backspace and delete
        If e.KeyChar = ControlChars.Back Then
            Return
        End If

        ' If this is the first character, it must be a letter
        If textBox.Text.Length = 0 Then
            If Not Char.IsLetter(e.KeyChar) Then
                e.Handled = True
                MessageBox.Show("Email must start with a letter.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            ' After the first character, allow letters, numbers, dot, and @
            ' Check if @ already exists in the text
            Dim hasAt As Boolean = textBox.Text.Contains("@")

            If e.KeyChar = "@"c Then
                ' Only allow one @ symbol
                If hasAt Then
                    e.Handled = True
                    MessageBox.Show("Email can only contain one @ symbol.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            ElseIf Not (Char.IsLetter(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "."c) Then
                e.Handled = True
                MessageBox.Show("Email can only contain letters, numbers, dot (.), and @ symbol (format: name@domain.com).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        If String.IsNullOrWhiteSpace(email) Then
            Return True ' Email is optional
        End If

        ' Email must start with a letter, then can have letters, numbers, dots before @
        ' Must have @ symbol, then domain with letters, numbers, dots
        ' Must end with a dot and letters (like .com, .org, etc.)
        Dim emailPattern As String = "^[a-zA-Z][a-zA-Z0-9.]*@[a-zA-Z0-9]+\.[a-zA-Z]+$"

        If Not Regex.IsMatch(email, emailPattern) Then
            MessageBox.Show("Please enter a valid email address (e.g., name@domain.com)." & vbCrLf &
     "Email must start with a letter and contain @ and domain extension.",
  "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    Private Function IsValidInput() As Boolean
        ' Validate names contain only letters and spaces
        If Not Regex.IsMatch(txtFirstName.Text.Trim(), "^[a-zA-Z\s]+$") Then
            MessageBox.Show("First name can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFirstName.Focus()
            Return False
        End If

        If Not Regex.IsMatch(txtLastName.Text.Trim(), "^[a-zA-Z\s]+$") Then
            MessageBox.Show("Last name can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLastName.Focus()
            Return False
        End If

        ' Validate username starts with letter, then letters, numbers, underscore, and @
        If Not Regex.IsMatch(txtUsername.Text.Trim(), "^[a-zA-Z][a-zA-Z0-9_@]*$") Then
            MessageBox.Show("Username must start with a letter and can only contain letters, numbers, underscore, and @.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If

        ' Validate password starts with letter, then letters, numbers, underscore, and @
        If Not Regex.IsMatch(txtPassword.Text.Trim(), "^[a-zA-Z][a-zA-Z0-9_@]*$") Then
            MessageBox.Show("Password must start with a letter and can only contain letters, numbers, underscore, and @.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If

        ' Validate student email if provided
        If pnlStudentFields.Visible AndAlso Not String.IsNullOrWhiteSpace(txtStudentEmail.Text) Then
            If Not IsValidEmail(txtStudentEmail.Text.Trim()) Then
                txtStudentEmail.Focus()
                Return False
            End If
        End If

        ' Validate instructor email if provided
        If pnlInstructorFields.Visible AndAlso Not String.IsNullOrWhiteSpace(txtInstructorEmail.Text) Then
            If Not IsValidEmail(txtInstructorEmail.Text.Trim()) Then
                txtInstructorEmail.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    ' Helper function to generate unique student number
    Private Function GenerateStudentNumber() As String
        Dim currentYear As String = DateTime.Now.Year.ToString()
        Dim random As New Random()
        Dim uniqueNumber As String = ""
        Dim isUnique As Boolean = False

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            While Not isUnique
                ' Generate format: YYYY-XXXXXX (Year-6 digit random number)
                uniqueNumber = $"{currentYear}-{random.Next(100000, 999999)}"

                ' Check if student number already exists
                Dim checkQuery As String = "SELECT COUNT(*) FROM Students WHERE student_number = @student_number"
                Using command As New MySqlCommand(checkQuery, connection)
                    command.Parameters.AddWithValue("@student_number", uniqueNumber)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    isUnique = (count = 0)
                End Using
            End While
        End Using

        Return uniqueNumber
    End Function

    Private Sub btnSubmitUser_Click(sender As Object, e As EventArgs) Handles btnSubmitUser.Click
        ' Validate required input
        If String.IsNullOrWhiteSpace(txtFirstName.Text) OrElse
   String.IsNullOrWhiteSpace(txtLastName.Text) OrElse
         String.IsNullOrWhiteSpace(txtUsername.Text) OrElse
  String.IsNullOrWhiteSpace(txtPassword.Text) OrElse
   cmbRole.SelectedValue Is Nothing Then
            MessageBox.Show("Please fill in all required fields (First Name, Last Name, Username, Password, Role).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate input format
        If Not IsValidInput() Then
            Return
        End If

        Dim selectedRoleId As Integer = Convert.ToInt32(cmbRole.SelectedValue)
        Dim selectedRoleName As String = cmbRole.Text

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Start transaction for both inserts
                Using transaction As MySqlTransaction = connection.BeginTransaction()
                    Try
                        ' Step 1: Insert into Users table with is_active = TRUE
                        Dim userQuery As String = "INSERT INTO Users (username, password_hash, role_id, is_active, created_at) VALUES (@username, SHA2(@password, 256), @role_id, TRUE, NOW())"

                        Dim userId As Integer
                        Using userCommand As New MySqlCommand(userQuery, connection, transaction)
                            userCommand.Parameters.AddWithValue("@username", txtUsername.Text.Trim())
                            userCommand.Parameters.AddWithValue("@password", txtPassword.Text.Trim())
                            userCommand.Parameters.AddWithValue("@role_id", selectedRoleId)

                            userCommand.ExecuteNonQuery()
                        End Using

                        ' Get the inserted user ID using LAST_INSERT_ID()
                        Using idCommand As New MySqlCommand("SELECT LAST_INSERT_ID()", connection, transaction)
                            userId = Convert.ToInt32(idCommand.ExecuteScalar())
                        End Using

                        ' Step 2: Insert into role-specific table based on actual schema
                        If selectedRoleId = 2 Then ' Teacher/Instructor
                            ' Get department (optional)
                            Dim instructorDepartmentId As Object = DBNull.Value
                            If cmbInstructorDepartment.SelectedValue IsNot Nothing Then
                                instructorDepartmentId = Convert.ToInt32(cmbInstructorDepartment.SelectedValue)
                            End If

                            ' Updated query to match Instructors table schema with optional fields
                            Dim instructorQuery As String = "INSERT INTO Instructors (user_id, first_name, last_name, middle_name, department_id, email, hire_date, employment_status, specialization, created_at, updated_at) " &
    "VALUES (@user_id, @first_name, @last_name, @middle_name, @department_id, @email, @hire_date, 'Active', @specialization, NOW(), NOW())"

                            Using instructorCommand As New MySqlCommand(instructorQuery, connection, transaction)
                                instructorCommand.Parameters.AddWithValue("@user_id", userId)
                                instructorCommand.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim())
                                instructorCommand.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim())

                                ' Middle Name (optional)
                                If String.IsNullOrWhiteSpace(txtMiddleName.Text) Then
                                    instructorCommand.Parameters.AddWithValue("@middle_name", DBNull.Value)
                                Else
                                    instructorCommand.Parameters.AddWithValue("@middle_name", txtMiddleName.Text.Trim())
                                End If

                                ' Department (optional)
                                instructorCommand.Parameters.AddWithValue("@department_id", instructorDepartmentId)

                                ' Email (optional)
                                If String.IsNullOrWhiteSpace(txtInstructorEmail.Text) Then
                                    instructorCommand.Parameters.AddWithValue("@email", DBNull.Value)
                                Else
                                    instructorCommand.Parameters.AddWithValue("@email", txtInstructorEmail.Text.Trim())
                                End If

                                ' Hire Date (use selected date)
                                instructorCommand.Parameters.AddWithValue("@hire_date", dtpHireDate.Value.Date)

                                ' Specialization (optional)
                                If String.IsNullOrWhiteSpace(txtSpecialization.Text) Then
                                    instructorCommand.Parameters.AddWithValue("@specialization", DBNull.Value)
                                Else
                                    instructorCommand.Parameters.AddWithValue("@specialization", txtSpecialization.Text.Trim())
                                End If

                                instructorCommand.ExecuteNonQuery()
                            End Using

                        ElseIf selectedRoleId = 3 Then ' Student
                            ' Generate unique student number
                            Dim studentNumber As String = GenerateStudentNumber()

                            ' Get enrollment status (optional) - leave NULL if not selected
                            Dim enrollmentStatusId As Object = DBNull.Value
                            If cmbEnrollmentStatus.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbEnrollmentStatus.SelectedValue) Then
                                If cmbEnrollmentStatus.SelectedIndex > 0 Then ' Not the default "Select Status" option
                                    enrollmentStatusId = Convert.ToInt32(cmbEnrollmentStatus.SelectedValue)
                                End If
                            End If

                            ' Get year level (required)
                            If cmbYearLevel.SelectedValue Is Nothing Then
                                MessageBox.Show("Please select a Year Level for the student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                transaction.Rollback()
                                Return
                            End If
                            Dim yearLevelId As Integer = Convert.ToInt32(cmbYearLevel.SelectedValue)

                            ' Get department (required)
                            If cmbDepartment.SelectedValue Is Nothing Then
                                MessageBox.Show("Please select a Department for the student.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                transaction.Rollback()
                                Return
                            End If
                            Dim departmentId As Integer = Convert.ToInt32(cmbDepartment.SelectedValue)

                            ' Determine enrollment_year based on status
                            ' Only set enrollment_year if a valid status is selected and it's 'Enrolled' (status_id = 1)
                            Dim enrollmentYear As Object = DBNull.Value
                            If Not IsDBNull(enrollmentStatusId) Then
                                Dim statusId As Integer = Convert.ToInt32(enrollmentStatusId)
                                If statusId = 1 Then ' Enrolled status
                                    enrollmentYear = DateTime.Now.Year
                                End If
                            End If

                            ' Updated query to match Students table schema - using current_status_id
                            Dim studentQuery As String = "INSERT INTO Students (user_id, student_number, first_name, last_name, middle_name, date_of_birth, gender, year_level_id, department_id, email, enrollment_year, current_status_id, created_at, updated_at) " &
      "VALUES (@user_id, @student_number, @first_name, @last_name, @middle_name, @date_of_birth, @gender, @year_level_id, @department_id, @email, @enrollment_year, @current_status_id, NOW(), NOW())"

                            Using studentCommand As New MySqlCommand(studentQuery, connection, transaction)
                                studentCommand.Parameters.AddWithValue("@user_id", userId)
                                studentCommand.Parameters.AddWithValue("@student_number", studentNumber)
                                studentCommand.Parameters.AddWithValue("@first_name", txtFirstName.Text.Trim())
                                studentCommand.Parameters.AddWithValue("@last_name", txtLastName.Text.Trim())

                                ' Middle Name (optional)
                                If String.IsNullOrWhiteSpace(txtMiddleName.Text) Then
                                    studentCommand.Parameters.AddWithValue("@middle_name", DBNull.Value)
                                Else
                                    studentCommand.Parameters.AddWithValue("@middle_name", txtMiddleName.Text.Trim())
                                End If

                                ' Date of Birth (use selected date)
                                studentCommand.Parameters.AddWithValue("@date_of_birth", dtpDateOfBirth.Value.Date)

                                ' Gender (use selected or default)
                                Dim selectedGender As String = If(cmbGender.SelectedItem IsNot Nothing, cmbGender.SelectedItem.ToString(), "Prefer not to say")
                                studentCommand.Parameters.AddWithValue("@gender", selectedGender)

                                ' Year Level and Department (required)
                                studentCommand.Parameters.AddWithValue("@year_level_id", yearLevelId)
                                studentCommand.Parameters.AddWithValue("@department_id", departmentId)

                                ' Email (optional)
                                If String.IsNullOrWhiteSpace(txtStudentEmail.Text) Then
                                    studentCommand.Parameters.AddWithValue("@email", DBNull.Value)
                                Else
                                    studentCommand.Parameters.AddWithValue("@email", txtStudentEmail.Text.Trim())
                                End If

                                ' Enrollment year and status (both optional, NULL if not selected)
                                studentCommand.Parameters.AddWithValue("@enrollment_year", enrollmentYear)
                                studentCommand.Parameters.AddWithValue("@current_status_id", enrollmentStatusId)

                                studentCommand.ExecuteNonQuery()
                            End Using
                        End If

                        ' Commit transaction
                        transaction.Commit()

                        Dim successMessage As String = $"{selectedRoleName} added successfully!" & vbCrLf &
        $"Username: {txtUsername.Text}" & vbCrLf &
        $"Password: [Securely hashed with SHA2-256]" & vbCrLf &
   $"User ID: {userId}"

                        ' Add student number to message if it's a student
                        If selectedRoleId = 3 Then
                            Using conn As New MySqlConnection(connectionString)
                                conn.Open()
                                Dim getStudentNumQuery As String = "SELECT student_number FROM Students WHERE user_id = @user_id"
                                Using cmd As New MySqlCommand(getStudentNumQuery, conn)
                                    cmd.Parameters.AddWithValue("@user_id", userId)
                                    Dim studNum As String = cmd.ExecuteScalar()?.ToString()
                                    If Not String.IsNullOrEmpty(studNum) Then
                                        successMessage &= vbCrLf & $"Student Number: {studNum}"
                                    End If
                                End Using
                            End Using
                        End If

                        MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Clear form and reload data
                        ClearAddUserForm()
                        LoadUserData()
                        LoadUserResetDropdown()
                        LoadDashboardStats()

                    Catch ex As Exception
                        transaction.Rollback()
                        Throw ex
                    End Try
                End Using
            End Using

        Catch ex As MySqlException
            If ex.Number = 1062 Then ' Duplicate entry error
                MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error adding user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUserData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Load Users with Role Names and Account Status
                Dim usersQuery As String = "SELECT u.user_id as 'User ID', u.username as 'Username', r.role_name as 'Role', " &
      "IF(u.is_active, 'Active', 'Inactive') as 'Status', " &
       "DATE_FORMAT(u.created_at, '%Y-%m-%d') as 'Created' " &
      "FROM Users u INNER JOIN Roles r ON u.role_id = r.role_id ORDER BY u.user_id"
                Using usersAdapter As New MySqlDataAdapter(usersQuery, connection)
                    Dim usersTable As New DataTable()
                    usersAdapter.Fill(usersTable)
                    dgvUsers.DataSource = usersTable
                End Using

                ' Load Instructors with complete information
                Dim instructorsQuery As String = "SELECT i.instructor_id as 'Instructor ID', " &
     "u.username as 'Username', " &
      "i.first_name as 'First Name', " &
           "i.last_name as 'Last Name', " &
     "IFNULL(i.middle_name, 'N/A') as 'Middle Name', " &
  "IFNULL(d.department_name, 'N/A') as 'Department', " &
      "IFNULL(i.specialization, 'N/A') as 'Specialization', " &
          "IFNULL(i.email, 'N/A') as 'Email', " &
        "IFNULL(DATE_FORMAT(i.hire_date, '%Y-%m-%d'), 'N/A') as 'Hire Date', " &
    "i.employment_status as 'Employment Status' " &
                "FROM Instructors i " &
        "INNER JOIN Users u ON i.user_id = u.user_id " &
   "LEFT JOIN Departments d ON i.department_id = d.department_id " &
                "ORDER BY i.instructor_id"
                Using instructorsAdapter As New MySqlDataAdapter(instructorsQuery, connection)
                    Dim instructorsTable As New DataTable()
                    instructorsAdapter.Fill(instructorsTable)
                    dgvInstructors.DataSource = instructorsTable
                End Using

                ' Load Students with complete information
                Dim studentsQuery As String = "SELECT s.student_id as 'Student ID', " &
                "s.student_number as 'Student Number', " &
          "u.username as 'Username', " &
              "s.first_name as 'First Name', " &
   "s.last_name as 'Last Name', " &
                "IFNULL(s.middle_name, 'N/A') as 'Middle Name', " &
     "IFNULL(DATE_FORMAT(s.date_of_birth, '%Y-%m-%d'), 'N/A') as 'Date of Birth', " &
        "IFNULL(s.gender, 'N/A') as 'Gender', " &
       "IFNULL(yl.year_level_name, 'N/A') as 'Year Level', " &
     "IFNULL(d.department_name, 'N/A') as 'Department', " &
             "IFNULL(s.email, 'N/A') as 'Email', " &
          "IFNULL(s.enrollment_year, 'N/A') as 'Enrollment Year', " &
     "IFNULL(est.status_name, 'N/A') as 'Enrollment Status' " &
       "FROM Students s " &
     "INNER JOIN Users u ON s.user_id = u.user_id " &
             "LEFT JOIN Year_Levels yl ON s.year_level_id = yl.year_level_id " &
      "LEFT JOIN Departments d ON s.department_id = d.department_id " &
  "LEFT JOIN Enrollment_Status_Types est ON s.current_status_id = est.status_id " &
       "ORDER BY s.student_id"
                Using studentsAdapter As New MySqlDataAdapter(studentsQuery, connection)
                    Dim studentsTable As New DataTable()
                    studentsAdapter.Fill(studentsTable)
                    dgvStudents.DataSource = studentsTable
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAddUserForm()
        txtFirstName.Clear()
        txtLastName.Clear()
        txtMiddleName.Clear()
        txtUsername.Clear()
        txtPassword.Clear()

        ' Clear student fields
        dtpDateOfBirth.Value = DateTime.Now.AddYears(-18)
        If cmbGender.Items.Count > 0 Then
            cmbGender.SelectedIndex = 3 ' "Prefer not to say"
        End If
        txtStudentEmail.Clear()
        If cmbEnrollmentStatus.Items.Count > 0 Then
            cmbEnrollmentStatus.SelectedIndex = 0 ' Default to "Select Status"
        End If
        If cmbYearLevel.Items.Count > 0 Then
            cmbYearLevel.SelectedIndex = 0 ' Reset to first year level
        End If
        If cmbDepartment.Items.Count > 0 Then
            cmbDepartment.SelectedIndex = 0 ' Reset to first department
        End If

        ' Clear instructor fields
        txtInstructorEmail.Clear()
        txtSpecialization.Clear()
        dtpHireDate.Value = DateTime.Now
        If cmbInstructorDepartment.Items.Count > 0 Then
            cmbInstructorDepartment.SelectedIndex = 0 ' Reset to first department
        End If

        ' Hide role-specific panels
        pnlStudentFields.Visible = False
        pnlInstructorFields.Visible = False

        If cmbRole.Items.Count > 0 Then
            cmbRole.SelectedIndex = 0
        End If
    End Sub

    ' ============= PASSWORD RESET METHODS =============

    Private Sub btnResetPasswordSubmit_Click(sender As Object, e As EventArgs) Handles btnResetPasswordSubmit.Click
        If cmbSelectUserReset.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a user to reset password for.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNewPassword.Text) Then
            MessageBox.Show("Please enter a new password.", "Password Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Regex.IsMatch(txtNewPassword.Text.Trim(), "^[a-zA-Z][a-zA-Z0-9_@]*$") Then
            MessageBox.Show("Password must start with a letter and can only contain letters, numbers, underscore, and @.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNewPassword.Focus()
            Return
        End If

        Dim selectedUserId As Integer = Convert.ToInt32(cmbSelectUserReset.SelectedValue)
        Dim selectedUserDisplay As String = cmbSelectUserReset.Text

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to reset the password for user: {selectedUserDisplay}?" & vbCrLf & vbCrLf &
    "This action cannot be undone.",
        "Confirm Password Reset", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE Users SET password_hash = SHA2(@password, 256) WHERE user_id = @user_id"

                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@password", txtNewPassword.Text.Trim())
                        command.Parameters.AddWithValue("@user_id", selectedUserId)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Password reset successfully for user: {selectedUserDisplay}" & vbCrLf & vbCrLf &
   "The password has been securely hashed and stored.",
       "Password Reset Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            txtNewPassword.Clear()
                        Else
                            MessageBox.Show("Failed to reset password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error resetting password: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnGeneratePassword_Click(sender As Object, e As EventArgs) Handles btnGeneratePassword.Click
        Dim generatedPassword As String = GenerateSecurePassword()
        txtNewPassword.Text = generatedPassword

        MessageBox.Show($"Secure password generated!" & vbCrLf & vbCrLf &
    $"Generated Password: {generatedPassword}" & vbCrLf & vbCrLf &
             "Please copy this password and provide it to the user securely.",
         "Password Generated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function GenerateSecurePassword() As String
        Const letters As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        Const allChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_@"
        Dim random As New Random()
        Dim password As New StringBuilder()

        password.Append(letters(random.Next(letters.Length)))

        For i As Integer = 1 To 11
            password.Append(allChars(random.Next(allChars.Length)))
        Next

        Return password.ToString()
    End Function

    Private Sub Admin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        login.ClearUserSession()
        Dim loginForm As New login()
        loginForm.Show()
    End Sub

    ' ============= LOGOUT FUNCTIONALITY =============

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        ' Confirm logout action
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to logout?" & vbCrLf & vbCrLf &
            "You will be redirected to the login page.",
            "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            ' Clear user session
            login.ClearUserSession()

            ' Show login form
            Dim loginForm As New login()
            loginForm.Show()

            ' Close current admin form
            Me.Close()
        End If
    End Sub

    ' ============= UPDATE/DELETE USER METHODS =============

    Private Sub LoadUserUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                ' Load all users except the current admin user
                Dim query As String = "SELECT u.user_id, CONCAT(u.username, ' - ', r.role_name) as display_name, u.role_id " &
        "FROM Users u " &
        "INNER JOIN Roles r ON u.role_id = r.role_id " &
       "WHERE u.is_active = TRUE " &
        "ORDER BY u.username"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim userTable As New DataTable()
                    adapter.Fill(userTable)
                    cmbSelectUserUpdate.DataSource = userTable
                    cmbSelectUserUpdate.DisplayMember = "display_name"
                    cmbSelectUserUpdate.ValueMember = "user_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading users for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeUpdateDropdowns()
        ' Initialize year level dropdown for update
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Roles
                Try
                    ' Remove event handler before setting DataSource to prevent crash
                    RemoveHandler cmbUpdateRole.SelectedIndexChanged, AddressOf cmbUpdateRole_SelectedIndexChanged

                    Dim roleQuery As String = "SELECT role_id, role_name FROM Roles ORDER BY role_id"
                    Using adapter As New MySqlDataAdapter(roleQuery, connection)
                        Dim roleTable As New DataTable()
                        adapter.Fill(roleTable)

                        If roleTable.Rows.Count > 0 Then
                            cmbUpdateRole.DataSource = roleTable
                            cmbUpdateRole.DisplayMember = "role_name"
                            cmbUpdateRole.ValueMember = "role_id"
                        End If
                    End Using

                    ' Re-add event handler after setting DataSource
                    AddHandler cmbUpdateRole.SelectedIndexChanged, AddressOf cmbUpdateRole_SelectedIndexChanged
                Catch ex As Exception
                    MessageBox.Show($"Error loading roles dropdown: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

                ' Year Levels
                Try
                    Dim yearQuery As String = "SELECT year_level_id, year_level_name FROM Year_Levels ORDER BY year_number"
                    Using adapter As New MySqlDataAdapter(yearQuery, connection)
                        Dim yearTable As New DataTable()
                        adapter.Fill(yearTable)

                        If yearTable.Rows.Count > 0 Then
                            cmbUpdateYearLevel.DataSource = yearTable
                            cmbUpdateYearLevel.DisplayMember = "year_level_name"
                            cmbUpdateYearLevel.ValueMember = "year_level_id"
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show($"Error loading year levels: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

                ' Departments for students
                Try
                    Dim deptQuery As String = "SELECT department_id, CONCAT(department_code, ' - ', department_name) as display_name FROM Departments ORDER BY department_name"
                    Using adapter As New MySqlDataAdapter(deptQuery, connection)
                        Dim deptTable As New DataTable()
                        adapter.Fill(deptTable)

                        If deptTable.Rows.Count > 0 Then
                            cmbUpdateDepartment.DataSource = deptTable.Copy()
                            cmbUpdateDepartment.DisplayMember = "display_name"
                            cmbUpdateDepartment.ValueMember = "department_id"

                            cmbUpdateInstructorDepartment.DataSource = deptTable.Copy()
                            cmbUpdateInstructorDepartment.DisplayMember = "display_name"
                            cmbUpdateInstructorDepartment.ValueMember = "department_id"
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show($"Error loading departments: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

                ' Enrollment Status
                Try
                    Dim statusQuery As String = "SELECT status_id, status_name FROM Enrollment_Status_Types ORDER BY status_id"
                    Using adapter As New MySqlDataAdapter(statusQuery, connection)
                        Dim statusTable As New DataTable()
                        adapter.Fill(statusTable)

                        If statusTable.Rows.Count > 0 Then
                            Dim defaultRow As DataRow = statusTable.NewRow()
                            defaultRow("status_id") = DBNull.Value
                            defaultRow("status_name") = "-- Select Status --"
                            statusTable.Rows.InsertAt(defaultRow, 0)

                            cmbUpdateEnrollmentStatus.DataSource = statusTable
                            cmbUpdateEnrollmentStatus.DisplayMember = "status_name"
                            cmbUpdateEnrollmentStatus.ValueMember = "status_id"
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show($"Error loading enrollment statuses: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try

                ' Employment Status for instructors
                Try
                    cmbUpdateEmploymentStatus.Items.Clear()
                    cmbUpdateEmploymentStatus.Items.AddRange(New String() {"Active", "On Leave", "Resigned", "Retired"})
                Catch ex As Exception
                    MessageBox.Show($"Error loading employment statuses: {ex.Message}", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error initializing update dropdowns: {ex.Message}" & vbCrLf & vbCrLf &
                          $"Stack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ' Re-throw to let the calling method handle it
        End Try
    End Sub

    Private Sub ClearUpdateForm()
        txtUpdateFirstName.Clear()
        txtUpdateMiddleName.Clear()
        txtUpdateLastName.Clear()
        txtUpdateUsername.Clear()
        lblUpdateRoleDisplay.Text = ""

        ' Reset role dropdown
        If cmbUpdateRole.Items.Count > 0 Then
            cmbUpdateRole.SelectedIndex = 0
        End If
        cmbUpdateRole.Visible = False
        lblUpdateRoleDisplay.Visible = False

        pnlUpdateStudentFields.Visible = False
        pnlUpdateInstructorFields.Visible = False

        grpUserInfo.Visible = False
        btnUpdateUser.Enabled = False
        btnDeleteUser.Enabled = False
        btnUpdateUser.Visible = False
        btnDeleteUser.Visible = False
    End Sub

    Private Sub btnLoadUserData_Click(sender As Object, e As EventArgs) Handles btnLoadUserData.Click
        If cmbSelectUserUpdate.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a user to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedUserId As Integer = Convert.ToInt32(cmbSelectUserUpdate.SelectedValue)
            Dim selectedRow As DataRowView = CType(cmbSelectUserUpdate.SelectedItem, DataRowView)
            Dim userRoleId As Integer = Convert.ToInt32(selectedRow("role_id"))

            ' Check if trying to update current admin
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim usernameQuery As String = "SELECT username FROM Users WHERE user_id = @user_id"
                Using cmd As New MySqlCommand(usernameQuery, connection)
                    cmd.Parameters.AddWithValue("@user_id", selectedUserId)
                    Dim username As String = cmd.ExecuteScalar()?.ToString()

                    If username = login.CurrentUsername Then
                        MessageBox.Show("You cannot update your own account from this panel.", "Action Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using
            End Using

            LoadUserDataForUpdate(selectedUserId, userRoleId)

        Catch ex As Exception
            MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadUserDataForUpdate(userId As Integer, roleId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Initialize dropdowns if not already done
                If cmbUpdateYearLevel.Items.Count = 0 Then
                    InitializeUpdateDropdowns()
                End If

                ' Add validation event handlers for update fields
                RemoveHandler txtUpdateFirstName.KeyPress, AddressOf ValidateNameInput
                RemoveHandler txtUpdateLastName.KeyPress, AddressOf ValidateNameInput
                RemoveHandler txtUpdateMiddleName.KeyPress, AddressOf ValidateNameInput
                RemoveHandler txtUpdateUsername.KeyPress, AddressOf ValidateUsernameInput
                RemoveHandler txtUpdateStudentEmail.KeyPress, AddressOf ValidateEmailInput
                RemoveHandler txtUpdateInstructorEmail.KeyPress, AddressOf ValidateEmailInput

                AddHandler txtUpdateFirstName.KeyPress, AddressOf ValidateNameInput
                AddHandler txtUpdateLastName.KeyPress, AddressOf ValidateNameInput
                AddHandler txtUpdateMiddleName.KeyPress, AddressOf ValidateNameInput
                AddHandler txtUpdateUsername.KeyPress, AddressOf ValidateUsernameInput
                AddHandler txtUpdateStudentEmail.KeyPress, AddressOf ValidateEmailInput
                AddHandler txtUpdateInstructorEmail.KeyPress, AddressOf ValidateEmailInput

                ' Hide all role-specific panels first
                pnlUpdateStudentFields.Visible = False
                pnlUpdateInstructorFields.Visible = False

                ' Load data based on CURRENT role
                Select Case roleId
                    Case 1 ' Admin
                        LoadAdminData(userId, connection)
                        ' Admin can be converted to any role, so enable name fields
                        txtUpdateFirstName.Enabled = True
                        txtUpdateMiddleName.Enabled = True
                        txtUpdateLastName.Enabled = True

                    Case 2 ' Instructor
                        LoadInstructorData(userId, connection)
                        pnlUpdateInstructorFields.Visible = True
                        txtUpdateFirstName.Enabled = True
                        txtUpdateMiddleName.Enabled = True
                        txtUpdateLastName.Enabled = True

                    Case 3 ' Student
                        LoadStudentData(userId, connection)
                        pnlUpdateStudentFields.Visible = True
                        txtUpdateFirstName.Enabled = True
                        txtUpdateMiddleName.Enabled = True
                        txtUpdateLastName.Enabled = True
                End Select

                ' Enable role dropdown for all users to allow role changes
                cmbUpdateRole.Enabled = True
                cmbUpdateRole.Visible = True
                lblUpdateRoleDisplay.Visible = False

                grpUserInfo.Visible = True
                btnUpdateUser.Enabled = True

                ' Enable delete for all non-admin users
                btnDeleteUser.Enabled = (roleId <> 1)

                ' Make buttons visible
                btnUpdateUser.Visible = True
                btnDeleteUser.Visible = True

            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading user data for update: {ex.Message}" & vbCrLf & vbCrLf &
          $"Stack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            ' Reset the form state
            grpUserInfo.Visible = False
            btnUpdateUser.Enabled = False
            btnDeleteUser.Enabled = False
            btnUpdateUser.Visible = False
            btnDeleteUser.Visible = False
        End Try
    End Sub

    Private Sub LoadAdminData(userId As Integer, connection As MySqlConnection)
        Try
            Dim query As String = "SELECT username, role_id FROM Users WHERE user_id = @user_id"
            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@user_id", userId)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        ' Clear name fields for admin (they don't have names in the system yet)
                        txtUpdateFirstName.Text = ""
                        txtUpdateMiddleName.Text = ""
                        txtUpdateLastName.Text = ""
                        txtUpdateUsername.Text = reader("username").ToString()

                        ' Set the role dropdown
                        If Not IsDBNull(reader("role_id")) AndAlso cmbUpdateRole.Items.Count > 0 Then
                            Try
                                cmbUpdateRole.SelectedValue = Convert.ToInt32(reader("role_id"))
                            Catch ex As Exception
                                ' If setting selected value fails, just log it but continue
                                Debug.WriteLine($"Could not set role dropdown value: {ex.Message}")
                            End Try
                        End If

                        ' Enable name fields for admin (in case they want to convert to Student/Instructor)
                        txtUpdateFirstName.Enabled = True
                        txtUpdateMiddleName.Enabled = True
                        txtUpdateLastName.Enabled = True

                        ' Add placeholder text hint
                        txtUpdateFirstName.PlaceholderText = "Required if converting to Student/Instructor"
                        txtUpdateLastName.PlaceholderText = "Required if converting to Student/Instructor"
                        txtUpdateMiddleName.PlaceholderText = "Optional"

                        ' Show role dropdown
                        cmbUpdateRole.Visible = True
                        lblUpdateRoleDisplay.Visible = False
                    Else
                        Throw New Exception("No data found for the selected admin user.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading admin data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ' Re-throw to let calling method handle it
        End Try
    End Sub

    Private Sub LoadInstructorData(userId As Integer, connection As MySqlConnection)
        Try
            Dim query As String = "SELECT i.first_name, i.last_name, i.middle_name, i.email, i.department_id, " &
     "i.specialization, i.hire_date, i.employment_status, u.username, u.role_id " &
   "FROM Instructors i " &
     "INNER JOIN Users u ON i.user_id = u.user_id " &
       "WHERE i.user_id = @user_id"

            Using cmd As New MySqlCommand(query, connection)
                cmd.Parameters.AddWithValue("@user_id", userId)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        txtUpdateFirstName.Text = reader("first_name").ToString()
                        txtUpdateMiddleName.Text = If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())
                        txtUpdateLastName.Text = reader("last_name").ToString()
                        txtUpdateUsername.Text = reader("username").ToString()
                        txtUpdateInstructorEmail.Text = If(IsDBNull(reader("email")), "", reader("email").ToString())
                        txtUpdateSpecialization.Text = If(IsDBNull(reader("specialization")), "", reader("specialization").ToString())

                        If Not IsDBNull(reader("department_id")) Then
                            Try
                                cmbUpdateInstructorDepartment.SelectedValue = Convert.ToInt32(reader("department_id"))
                            Catch ex As Exception
                                Debug.WriteLine($"Could not set instructor department: {ex.Message}")
                            End Try
                        End If

                        If Not IsDBNull(reader("hire_date")) Then
                            dtpUpdateHireDate.Value = Convert.ToDateTime(reader("hire_date"))
                        End If

                        If Not IsDBNull(reader("employment_status")) Then
                            Try
                                cmbUpdateEmploymentStatus.Text = reader("employment_status").ToString()
                            Catch ex As Exception
                                Debug.WriteLine($"Could not set employment status: {ex.Message}")
                            End Try
                        End If

                        ' Set the role dropdown
                        If Not IsDBNull(reader("role_id")) AndAlso cmbUpdateRole.Items.Count > 0 Then
                            Try
                                cmbUpdateRole.SelectedValue = Convert.ToInt32(reader("role_id"))
                            Catch ex As Exception
                                Debug.WriteLine($"Could not set role dropdown value: {ex.Message}")
                            End Try
                        End If

                        ' Enable all fields and clear placeholder text
                        txtUpdateFirstName.Enabled = True
                        txtUpdateMiddleName.Enabled = True
                        txtUpdateLastName.Enabled = True
                        txtUpdateFirstName.PlaceholderText = ""
                        txtUpdateLastName.PlaceholderText = ""
                        txtUpdateMiddleName.PlaceholderText = ""

                        ' Show role dropdown
                        cmbUpdateRole.Visible = True
                        lblUpdateRoleDisplay.Visible = False
                    Else
                        Throw New Exception("No instructor data found for the selected user.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading instructor data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw ' Re-throw to let calling method handle it
        End Try
    End Sub

    Private Sub LoadStudentData(userId As Integer, connection As MySqlConnection)
        Dim query As String = "SELECT s.first_name, s.last_name, s.middle_name, s.email, s.date_of_birth, " &
"s.gender, s.year_level_id, s.department_id, s.current_status_id, u.username, u.role_id " &
          "FROM Students s " &
        "INNER JOIN Users u ON s.user_id = u.user_id " &
    "WHERE s.user_id = @user_id"

        Using cmd As New MySqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@user_id", userId)
            Using reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    txtUpdateFirstName.Text = reader("first_name").ToString()
                    txtUpdateMiddleName.Text = If(IsDBNull(reader("middle_name")), "", reader("middle_name").ToString())
                    txtUpdateLastName.Text = reader("last_name").ToString()
                    txtUpdateUsername.Text = reader("username").ToString()
                    txtUpdateStudentEmail.Text = If(IsDBNull(reader("email")), "", reader("email").ToString())

                    If Not IsDBNull(reader("date_of_birth")) Then
                        dtpUpdateDateOfBirth.Value = Convert.ToDateTime(reader("date_of_birth"))
                    End If

                    If Not IsDBNull(reader("gender")) Then
                        Try
                            cmbUpdateGender.Text = reader("gender").ToString()
                        Catch ex As Exception
                            Debug.WriteLine($"Could not set gender: {ex.Message}")
                        End Try
                    End If

                    If Not IsDBNull(reader("year_level_id")) Then
                        Try
                            cmbUpdateYearLevel.SelectedValue = Convert.ToInt32(reader("year_level_id"))
                        Catch ex As Exception
                            Debug.WriteLine($"Could not set year level: {ex.Message}")
                        End Try
                    End If

                    If Not IsDBNull(reader("department_id")) Then
                        Try
                            cmbUpdateDepartment.SelectedValue = Convert.ToInt32(reader("department_id"))
                        Catch ex As Exception
                            Debug.WriteLine($"Could not set department: {ex.Message}")
                        End Try
                    End If

                    If Not IsDBNull(reader("current_status_id")) Then
                        Try
                            cmbUpdateEnrollmentStatus.SelectedValue = Convert.ToInt32(reader("current_status_id"))
                        Catch ex As Exception
                            Debug.WriteLine($"Could not set enrollment status: {ex.Message}")
                        End Try
                    Else
                        Try
                            cmbUpdateEnrollmentStatus.SelectedIndex = 0
                        Catch ex As Exception
                            Debug.WriteLine($"Could not reset enrollment status: {ex.Message}")
                        End Try
                    End If

                    ' Set the role dropdown
                    If Not IsDBNull(reader("role_id")) AndAlso cmbUpdateRole.Items.Count > 0 Then
                        Try
                            cmbUpdateRole.SelectedValue = Convert.ToInt32(reader("role_id"))
                        Catch ex As Exception
                            Debug.WriteLine($"Could not set role dropdown value: {ex.Message}")
                        End Try
                    End If

                    ' Enable all fields and clear placeholder text
                    txtUpdateFirstName.Enabled = True
                    txtUpdateMiddleName.Enabled = True
                    txtUpdateLastName.Enabled = True
                    txtUpdateFirstName.PlaceholderText = ""
                    txtUpdateLastName.PlaceholderText = ""
                    txtUpdateMiddleName.PlaceholderText = ""

                    ' Show role dropdown
                    cmbUpdateRole.Visible = True
                    lblUpdateRoleDisplay.Visible = False
                Else
                    Throw New Exception("No student data found for the selected user.")
                End If
            End Using
        End Using
    End Sub

    Private Sub btnUpdateUser_Click(sender As Object, e As EventArgs) Handles btnUpdateUser.Click
        If cmbSelectUserUpdate.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a user to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get the selected role ID
        If cmbUpdateRole.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedRoleId As Integer = Convert.ToInt32(cmbUpdateRole.SelectedValue)
        Dim selectedRoleName As String = cmbUpdateRole.Text

        ' Validate required fields based on user type
        If selectedRoleId <> 1 Then ' Not Admin
            If String.IsNullOrWhiteSpace(txtUpdateFirstName.Text) OrElse
           String.IsNullOrWhiteSpace(txtUpdateLastName.Text) Then
                MessageBox.Show("Please fill in all required fields (First Name, Last Name).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Validate input formats using existing validation methods
            If Not Regex.IsMatch(txtUpdateFirstName.Text.Trim(), "^[a-zA-Z\s]+$") Then
                MessageBox.Show("First name can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUpdateFirstName.Focus()
                Return
            End If

            If Not Regex.IsMatch(txtUpdateLastName.Text.Trim(), "^[a-zA-Z\s]+$") Then
                MessageBox.Show("Last name can only contain letters and spaces.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtUpdateLastName.Focus()
                Return
            End If
        End If

        If String.IsNullOrWhiteSpace(txtUpdateUsername.Text) Then
            MessageBox.Show("Username is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If Not Regex.IsMatch(txtUpdateUsername.Text.Trim(), "^[a-zA-Z][a-zA-Z0-9_@]*$") Then
            MessageBox.Show("Username must start with a letter and can only contain letters, numbers, underscore, and @.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateUsername.Focus()
            Return
        End If

        ' Validate emails if provided
        If pnlUpdateStudentFields.Visible AndAlso Not String.IsNullOrWhiteSpace(txtUpdateStudentEmail.Text) Then
            If Not IsValidEmail(txtUpdateStudentEmail.Text.Trim()) Then
                txtUpdateStudentEmail.Focus()
                Return
            End If
        End If

        If pnlUpdateInstructorFields.Visible AndAlso Not String.IsNullOrWhiteSpace(txtUpdateInstructorEmail.Text) Then
            If Not IsValidEmail(txtUpdateInstructorEmail.Text.Trim()) Then
                txtUpdateInstructorEmail.Focus()
                Return
            End If
        End If

        ' Get original role
        Dim selectedUserId As Integer = Convert.ToInt32(cmbSelectUserUpdate.SelectedValue)
        Dim selectedRow As DataRowView = CType(cmbSelectUserUpdate.SelectedItem, DataRowView)
        Dim originalRoleId As Integer = Convert.ToInt32(selectedRow("role_id"))

        ' ============================================================
        ' Username Duplicate Check - FIXED VERSION
        ' ============================================================
        Try
            Using checkConn As New MySqlConnection(connectionString)
                checkConn.Open()

                ' Get current username from database (with TRIM to avoid whitespace issues)
                Dim getCurrentUsernameQuery As String = "SELECT TRIM(username) FROM Users WHERE user_id = @user_id"
                Dim currentUsername As String = ""

                Using cmd As New MySqlCommand(getCurrentUsernameQuery, checkConn)
                    cmd.Parameters.AddWithValue("@user_id", selectedUserId)
                    Dim queryResult = cmd.ExecuteScalar()  ' ← Fixed: renamed to 'queryResult'
                    currentUsername = If(queryResult IsNot Nothing, queryResult.ToString(), "")
                End Using

                ' Trim the new username
                Dim newUsername As String = txtUpdateUsername.Text.Trim()

                ' Check if username is actually changing (case-insensitive comparison)
                Dim isUsernameChanging As Boolean = Not String.Equals(currentUsername, newUsername, StringComparison.OrdinalIgnoreCase)

                ' Only check for duplicates if username is actually changing
                If isUsernameChanging Then
                    ' Check if the new username exists for ANY OTHER user
                    Dim checkDuplicateQuery As String = "SELECT COUNT(*) FROM Users WHERE TRIM(LOWER(username)) = LOWER(@username) AND user_id != @user_id"
                    Using cmd As New MySqlCommand(checkDuplicateQuery, checkConn)
                        cmd.Parameters.AddWithValue("@username", newUsername)
                        cmd.Parameters.AddWithValue("@user_id", selectedUserId)
                        Dim duplicateCount As Integer = Convert.ToInt32(cmd.ExecuteScalar())

                        If duplicateCount > 0 Then
                            MessageBox.Show($"Username '{newUsername}' is already taken by another user. Please choose a different username.",
                                      "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            txtUpdateUsername.Focus()
                            Return
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error checking username availability: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try
        ' ============================================================
        ' END OF USERNAME CHECK
        ' ============================================================

        ' Check if role is changing
        Dim isRoleChanging As Boolean = (originalRoleId <> selectedRoleId)

        ' Confirm update with role change warning if applicable
        Dim confirmMessage As String = "Are you sure you want to update this user's information?" & vbCrLf & vbCrLf &
                                  "This action will modify the user's data in the database."

        If isRoleChanging Then
            confirmMessage = "⚠️ ROLE CHANGE DETECTED ⚠️" & vbCrLf & vbCrLf &
                        $"You are changing this user's role from {GetRoleName(originalRoleId)} to {selectedRoleName}." & vbCrLf & vbCrLf &
                        "Important Notes:" & vbCrLf &
                        "• Changing to Admin will preserve the user's existing data" & vbCrLf &
                        "• The user will gain/lose permissions based on the new role" & vbCrLf &
                        "• This action cannot be easily undone" & vbCrLf & vbCrLf &
                        "Are you sure you want to proceed?"
        End If

        Dim result As DialogResult = MessageBox.Show(confirmMessage, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Using transaction As MySqlTransaction = connection.BeginTransaction()
                        Try
                            ' Get current username INSIDE transaction
                            Dim getCurrentUsernameQuery As String = "SELECT username FROM Users WHERE user_id = @user_id FOR UPDATE"
                            Dim currentUsername As String = ""

                            Using getCmd As New MySqlCommand(getCurrentUsernameQuery, connection, transaction)
                                getCmd.Parameters.AddWithValue("@user_id", selectedUserId)
                                Dim dbUsername = getCmd.ExecuteScalar()
                                currentUsername = If(dbUsername IsNot Nothing, dbUsername.ToString(), "")
                            End Using

                            ' Trim and compare usernames
                            Dim newUsername As String = txtUpdateUsername.Text.Trim()
                            Dim isUsernameActuallyChanging As Boolean = Not currentUsername.Equals(newUsername, StringComparison.Ordinal)

                            ' Build and execute UPDATE query
                            If isUsernameActuallyChanging Then
                                ' Username IS changing - update both
                                Dim userQuery As String = "UPDATE Users SET username = @username, role_id = @role_id WHERE user_id = @user_id"
                                Using userCmd As New MySqlCommand(userQuery, connection, transaction)
                                    userCmd.Parameters.AddWithValue("@username", newUsername)
                                    userCmd.Parameters.AddWithValue("@role_id", selectedRoleId)
                                    userCmd.Parameters.AddWithValue("@user_id", selectedUserId)
                                    userCmd.ExecuteNonQuery()
                                End Using
                            Else
                                ' Username is NOT changing - only update role
                                Dim userQuery As String = "UPDATE Users SET role_id = @role_id WHERE user_id = @user_id"
                                Using userCmd As New MySqlCommand(userQuery, connection, transaction)
                                    userCmd.Parameters.AddWithValue("@role_id", selectedRoleId)
                                    userCmd.Parameters.AddWithValue("@user_id", selectedUserId)
                                    userCmd.ExecuteNonQuery()
                                End Using
                            End If

                            ' Handle role-specific updates based on NEW role
                            Try
                                Select Case selectedRoleId
                                    Case 1 ' Changing to Admin
                    ' No action needed

                                    Case 2 ' Changing TO Instructor
                                        If originalRoleId = 2 Then
                                            UpdateInstructorData(selectedUserId, connection, transaction)
                                        Else
                                            CreateInstructorRecord(selectedUserId, connection, transaction)
                                        End If

                                    Case 3 ' Changing TO Student
                                        If originalRoleId = 3 Then
                                            UpdateStudentData(selectedUserId, connection, transaction)
                                        Else
                                            CreateStudentRecord(selectedUserId, connection, transaction)
                                        End If
                                End Select

                            Catch innerEx As MySqlException
                                ' Show the ACTUAL MySQL error with error number
                                MessageBox.Show($"MySQL Error #{innerEx.Number}: {innerEx.Message}" & vbCrLf & vbCrLf &
                          $"This error occurred while creating/updating role-specific data." & vbCrLf &
                          $"Target Role: {selectedRoleName}" & vbCrLf &
                          $"User ID: {selectedUserId}" & vbCrLf & vbCrLf &
                          $"Stack Trace: {innerEx.StackTrace}",
                          "Database Error Detail", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Throw ' Re-throw to trigger rollback
                            End Try

                            transaction.Commit()

                            Dim successMessage As String = "User information updated successfully!" & vbCrLf &
                                      $"Role: {selectedRoleName}"

                            If isRoleChanging Then
                                successMessage &= vbCrLf & vbCrLf &
                            $"Role changed from {GetRoleName(originalRoleId)} to {selectedRoleName}"
                            End If

                            MessageBox.Show(successMessage, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Refresh data
                            LoadUserData()
                            LoadUserUpdateDropdown()
                            LoadDashboardStats()
                            ClearUpdateForm()

                        Catch ex As Exception
                            transaction.Rollback()
                            Throw ex
                        End Try
                    End Using
                End Using

            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    ' This should rarely happen now since we check before updating
                    MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error updating user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Helper function to get role name by ID
    Private Function GetRoleName(roleId As Integer) As String
        Select Case roleId
            Case 1
                Return "Admin"
            Case 2
                Return "Instructor"
            Case 3
                Return "Student"
            Case Else
                Return "Unknown"
        End Select
    End Function

    ' Helper method to create a new instructor record when converting from another role
    Private Sub CreateInstructorRecord(userId As Integer, connection As MySqlConnection, transaction As MySqlTransaction)
        ' ============================================================
        ' CHECK if instructor record already exists for this user_id
        ' ============================================================
        Dim checkQuery As String = "SELECT COUNT(*) FROM Instructors WHERE user_id = @user_id"
        Dim recordExists As Boolean = False

        Using checkCmd As New MySqlCommand(checkQuery, connection, transaction)
            checkCmd.Parameters.AddWithValue("@user_id", userId)
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            recordExists = (count > 0)
        End Using

        ' If record exists, UPDATE it instead of INSERT
        If recordExists Then
            MessageBox.Show("Instructor record already exists for this user. Updating existing record instead.",
                       "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            UpdateInstructorData(userId, connection, transaction)
            Return
        End If
        ' ============================================================

        ' Validate required fields have data
        If String.IsNullOrWhiteSpace(txtUpdateFirstName.Text) Then
            Throw New Exception("First Name is required to create an instructor record.")
        End If
        If String.IsNullOrWhiteSpace(txtUpdateLastName.Text) Then
            Throw New Exception("Last Name is required to create an instructor record.")
        End If

        ' INSERT new instructor record (only runs if no existing record)
        Dim query As String = "INSERT INTO Instructors (user_id, first_name, last_name, middle_name, department_id, email, hire_date, employment_status, specialization, created_at, updated_at) " &
                         "VALUES (@user_id, @first_name, @last_name, @middle_name, @department_id, @email, @hire_date, 'Active', @specialization, NOW(), NOW())"

        Using cmd As New MySqlCommand(query, connection, transaction)
            cmd.Parameters.AddWithValue("@user_id", userId)
            cmd.Parameters.AddWithValue("@first_name", txtUpdateFirstName.Text.Trim())
            cmd.Parameters.AddWithValue("@last_name", txtUpdateLastName.Text.Trim())
            cmd.Parameters.AddWithValue("@middle_name", If(String.IsNullOrWhiteSpace(txtUpdateMiddleName.Text), DBNull.Value, txtUpdateMiddleName.Text.Trim()))
            cmd.Parameters.AddWithValue("@department_id", If(cmbUpdateInstructorDepartment.SelectedValue Is Nothing, DBNull.Value, cmbUpdateInstructorDepartment.SelectedValue))
            cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtUpdateInstructorEmail.Text), DBNull.Value, txtUpdateInstructorEmail.Text.Trim()))
            cmd.Parameters.AddWithValue("@hire_date", dtpUpdateHireDate.Value.Date)
            cmd.Parameters.AddWithValue("@specialization", If(String.IsNullOrWhiteSpace(txtUpdateSpecialization.Text), DBNull.Value, txtUpdateSpecialization.Text.Trim()))
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' Helper method to create a new student record when converting from another role
    Private Sub CreateStudentRecord(userId As Integer, connection As MySqlConnection, transaction As MySqlTransaction)
        ' ============================================================
        ' CHECK if student record already exists for this user_id
        ' ============================================================
        Dim checkQuery As String = "SELECT COUNT(*) FROM Students WHERE user_id = @user_id"
        Dim recordExists As Boolean = False

        Using checkCmd As New MySqlCommand(checkQuery, connection, transaction)
            checkCmd.Parameters.AddWithValue("@user_id", userId)
            Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
            recordExists = (count > 0)
        End Using

        ' If record exists, UPDATE it instead of INSERT
        If recordExists Then
            MessageBox.Show("Student record already exists for this user. Updating existing record instead.",
                       "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            UpdateStudentData(userId, connection, transaction)
            Return
        End If
        ' ============================================================

        ' Validate required fields
        If String.IsNullOrWhiteSpace(txtUpdateFirstName.Text) Then
            Throw New Exception("First Name is required to create a student record.")
        End If
        If String.IsNullOrWhiteSpace(txtUpdateLastName.Text) Then
            Throw New Exception("Last Name is required to create a student record.")
        End If
        If cmbUpdateYearLevel.SelectedValue Is Nothing Then
            Throw New Exception("Please select a Year Level for the student.")
        End If
        If cmbUpdateDepartment.SelectedValue Is Nothing Then
            Throw New Exception("Please select a Department for the student.")
        End If

        ' Generate unique student number (only for NEW students)
        Dim studentNumber As String = GenerateStudentNumber()

        ' Get enrollment status
        Dim enrollmentStatusId As Object = DBNull.Value
        If cmbUpdateEnrollmentStatus.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbUpdateEnrollmentStatus.SelectedValue) Then
            If cmbUpdateEnrollmentStatus.SelectedIndex > 0 Then
                enrollmentStatusId = Convert.ToInt32(cmbUpdateEnrollmentStatus.SelectedValue)
            End If
        End If

        ' Determine enrollment_year based on status
        Dim enrollmentYear As Object = DBNull.Value
        If Not IsDBNull(enrollmentStatusId) Then
            Dim statusId As Integer = Convert.ToInt32(enrollmentStatusId)
            If statusId = 1 Then ' Enrolled status
                enrollmentYear = DateTime.Now.Year
            End If
        End If

        Dim query As String = "INSERT INTO Students (user_id, student_number, first_name, last_name, middle_name, date_of_birth, gender, year_level_id, department_id, email, enrollment_year, current_status_id, created_at, updated_at) " &
                         "VALUES (@user_id, @student_number, @first_name, @last_name, @middle_name, @date_of_birth, @gender, @year_level_id, @department_id, @email, @enrollment_year, @current_status_id, NOW(), NOW())"

        Using cmd As New MySqlCommand(query, connection, transaction)
            cmd.Parameters.AddWithValue("@user_id", userId)
            cmd.Parameters.AddWithValue("@student_number", studentNumber)
            cmd.Parameters.AddWithValue("@first_name", txtUpdateFirstName.Text.Trim())
            cmd.Parameters.AddWithValue("@last_name", txtUpdateLastName.Text.Trim())
            cmd.Parameters.AddWithValue("@middle_name", If(String.IsNullOrWhiteSpace(txtUpdateMiddleName.Text), DBNull.Value, txtUpdateMiddleName.Text.Trim()))
            cmd.Parameters.AddWithValue("@date_of_birth", dtpUpdateDateOfBirth.Value.Date)
            cmd.Parameters.AddWithValue("@gender", If(cmbUpdateGender.SelectedItem Is Nothing, DBNull.Value, cmbUpdateGender.SelectedItem.ToString()))
            cmd.Parameters.AddWithValue("@year_level_id", Convert.ToInt32(cmbUpdateYearLevel.SelectedValue))
            cmd.Parameters.AddWithValue("@department_id", Convert.ToInt32(cmbUpdateDepartment.SelectedValue))
            cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtUpdateStudentEmail.Text), DBNull.Value, txtUpdateStudentEmail.Text.Trim()))
            cmd.Parameters.AddWithValue("@enrollment_year", enrollmentYear)
            cmd.Parameters.AddWithValue("@current_status_id", enrollmentStatusId)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' Helper method to update existing instructor record
    Private Sub UpdateInstructorData(userId As Integer, connection As MySqlConnection, transaction As MySqlTransaction)
        Dim query As String = "UPDATE Instructors SET " &
"first_name = @first_name, " &
    "last_name = @last_name, " &
   "middle_name = @middle_name, " &
            "email = @email, " &
         "department_id = @department_id, " &
           "specialization = @specialization, " &
      "hire_date = @hire_date, " &
   "employment_status = @employment_status, " &
  "updated_at = NOW() " &
 "WHERE user_id = @user_id"

        Using cmd As New MySqlCommand(query, connection, transaction)
            cmd.Parameters.AddWithValue("@first_name", txtUpdateFirstName.Text.Trim())
            cmd.Parameters.AddWithValue("@last_name", txtUpdateLastName.Text.Trim())
            cmd.Parameters.AddWithValue("@middle_name", If(String.IsNullOrWhiteSpace(txtUpdateMiddleName.Text), DBNull.Value, txtUpdateMiddleName.Text.Trim()))
            cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtUpdateInstructorEmail.Text), DBNull.Value, txtUpdateInstructorEmail.Text.Trim()))
            cmd.Parameters.AddWithValue("@department_id", If(cmbUpdateInstructorDepartment.SelectedValue Is Nothing, DBNull.Value, cmbUpdateInstructorDepartment.SelectedValue))
            cmd.Parameters.AddWithValue("@specialization", If(String.IsNullOrWhiteSpace(txtUpdateSpecialization.Text), DBNull.Value, txtUpdateSpecialization.Text.Trim()))
            cmd.Parameters.AddWithValue("@hire_date", dtpUpdateHireDate.Value.Date)
            cmd.Parameters.AddWithValue("@employment_status", If(String.IsNullOrWhiteSpace(cmbUpdateEmploymentStatus.Text), "Active", cmbUpdateEmploymentStatus.Text))
            cmd.Parameters.AddWithValue("@user_id", userId)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    ' Helper method to update existing student record
    Private Sub UpdateStudentData(userId As Integer, connection As MySqlConnection, transaction As MySqlTransaction)
        ' Get enrollment status
        Dim enrollmentStatusId As Object = DBNull.Value
        If cmbUpdateEnrollmentStatus.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbUpdateEnrollmentStatus.SelectedValue) Then
            If cmbUpdateEnrollmentStatus.SelectedIndex > 0 Then
                enrollmentStatusId = Convert.ToInt32(cmbUpdateEnrollmentStatus.SelectedValue)
            End If
        End If

        ' Validate required fields
        If cmbUpdateYearLevel.SelectedValue Is Nothing Then
            Throw New Exception("Please select a Year Level for the student.")
        End If

        If cmbUpdateDepartment.SelectedValue Is Nothing Then
            Throw New Exception("Please select a Department for the student.")
        End If

        ' Determine enrollment_year based on status
        Dim enrollmentYear As Object = DBNull.Value
        If Not IsDBNull(enrollmentStatusId) Then
            Dim statusId As Integer = Convert.ToInt32(enrollmentStatusId)
            If statusId = 1 Then ' Enrolled status
                enrollmentYear = DateTime.Now.Year
            End If
        End If

        Dim query As String = "UPDATE Students SET " &
"first_name = @first_name, " &
       "last_name = @last_name, " &
   "middle_name = @middle_name, " &
       "email = @email, " &
     "date_of_birth = @date_of_birth, " &
 "gender = @gender, " &
     "year_level_id = @year_level_id, " &
"department_id = @department_id, " &
     "current_status_id = @current_status_id, " &
      "enrollment_year = @enrollment_year, " &
 "updated_at = NOW() " &
   "WHERE user_id = @user_id"

        Using cmd As New MySqlCommand(query, connection, transaction)
            cmd.Parameters.AddWithValue("@first_name", txtUpdateFirstName.Text.Trim())
            cmd.Parameters.AddWithValue("@last_name", txtUpdateLastName.Text.Trim())
            cmd.Parameters.AddWithValue("@middle_name", If(String.IsNullOrWhiteSpace(txtUpdateMiddleName.Text), DBNull.Value, txtUpdateMiddleName.Text.Trim()))
            cmd.Parameters.AddWithValue("@email", If(String.IsNullOrWhiteSpace(txtUpdateStudentEmail.Text), DBNull.Value, txtUpdateStudentEmail.Text.Trim()))
            cmd.Parameters.AddWithValue("@date_of_birth", dtpUpdateDateOfBirth.Value.Date)
            cmd.Parameters.AddWithValue("@gender", If(cmbUpdateGender.SelectedItem Is Nothing, DBNull.Value, cmbUpdateGender.SelectedItem.ToString()))
            cmd.Parameters.AddWithValue("@year_level_id", Convert.ToInt32(cmbUpdateYearLevel.SelectedValue))
            cmd.Parameters.AddWithValue("@department_id", Convert.ToInt32(cmbUpdateDepartment.SelectedValue))
            cmd.Parameters.AddWithValue("@current_status_id", enrollmentStatusId)
            cmd.Parameters.AddWithValue("@enrollment_year", enrollmentYear)
            cmd.Parameters.AddWithValue("@user_id", userId)
            cmd.ExecuteNonQuery()
        End Using
    End Sub

    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        If cmbSelectUserUpdate.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a user to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedUserId As Integer = Convert.ToInt32(cmbSelectUserUpdate.SelectedValue)
        Dim selectedUserDisplay As String = cmbSelectUserUpdate.Text

        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the user: {selectedUserDisplay}?" & vbCrLf & vbCrLf &
    "This action cannot be undone.",
        "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE Users SET is_active = FALSE WHERE user_id = @user_id"

                    Using command As New MySqlCommand(query, connection)
                        command.Parameters.AddWithValue("@user_id", selectedUserId)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"User deleted successfully: {selectedUserDisplay}", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ' Reload user data
                            LoadUserData()
                            LoadUserUpdateDropdown()
                        Else
                            MessageBox.Show("Failed to delete user. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' ============= DEPARTMENT MANAGEMENT METHODS =============

    ' Add navigation method
    Private Sub btnDepartmentManagement_Click(sender As Object, e As EventArgs) Handles btnDepartmentManagement.Click
        ShowPanel(pnlDepartmentManagement)
        SetActiveButton(btnDepartmentManagement)
        pnlDepartmentManagementSubmenu.Visible = Not pnlDepartmentManagementSubmenu.Visible
        pnlUserManagementSubmenu.Visible = False
        InitializeHeadInstructorDropdown()
        LoadDepartmentsData()
        LoadDepartmentUpdateDropdown()
        ClearDepartmentForm()

        ' Update button text to show collapse/expand state
        If pnlDepartmentManagementSubmenu.Visible Then
            btnDepartmentManagement.Text = "Department Management (Expanded)"
        Else
            btnDepartmentManagement.Text = "Department Management"
        End If
    End Sub

    ' Initialize Head Instructor Dropdown (from Instructors table)
    Private Sub InitializeHeadInstructorDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Get active instructors with FULL NAME
                Dim query As String = "SELECT i.instructor_id, CONCAT(i.first_name, ' ', i.last_name, ' (', i.specialization, ')') as display_name " &
                                "FROM Instructors i " &
                                "INNER JOIN Users u ON i.user_id = u.user_id " &
                                "WHERE i.employment_status = 'Active' AND u.is_active = TRUE " &
                                "ORDER BY i.first_name, i.last_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim instructorTable As New DataTable()
                    adapter.Fill(instructorTable)

                    ' Add "None" option at the beginning
                    Dim noneRow As DataRow = instructorTable.NewRow()
                    noneRow("instructor_id") = DBNull.Value
                    noneRow("display_name") = "-- None (No Head Instructor) --"
                    instructorTable.Rows.InsertAt(noneRow, 0)

                    ' Bind to Add Department dropdown
                    cmbDeptHeadInstructor.DataSource = instructorTable.Copy()
                    cmbDeptHeadInstructor.DisplayMember = "display_name"
                    cmbDeptHeadInstructor.ValueMember = "instructor_id"
                    cmbDeptHeadInstructor.SelectedIndex = 0

                    ' Bind to Update Department dropdown
                    cmbUpdateDeptHeadInstructor.DataSource = instructorTable.Copy()
                    cmbUpdateDeptHeadInstructor.DisplayMember = "display_name"
                    cmbUpdateDeptHeadInstructor.ValueMember = "instructor_id"
                    cmbUpdateDeptHeadInstructor.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading head instructors: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load all departments into DataGridView
    Private Sub LoadDepartmentsData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT d.department_id as 'Department ID', " &
                                "d.department_code as 'Code', " &
                                "d.department_name as 'Name', " &
                                "IFNULL(d.description, 'N/A') as 'Description', " &
                                "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'None') as 'Head Instructor', " &
                                "DATE_FORMAT(d.created_at, '%Y-%m-%d') as 'Created' " &
                                "FROM Departments d " &
                                "LEFT JOIN Instructors i ON d.head_instructor_id = i.instructor_id " &
                                "ORDER BY d.department_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim departmentTable As New DataTable()
                    adapter.Fill(departmentTable)
                    dgvDepartments.DataSource = departmentTable

                    ' Auto-resize columns
                    dgvDepartments.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load departments for update dropdown
    Private Sub LoadDepartmentUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT department_id, CONCAT(department_code, ' - ', department_name) as display_name " &
                                "FROM Departments " &
                                "ORDER BY department_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim deptTable As New DataTable()
                    adapter.Fill(deptTable)
                    cmbSelectDepartment.DataSource = deptTable
                    cmbSelectDepartment.DisplayMember = "display_name"
                    cmbSelectDepartment.ValueMember = "department_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading departments for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Add Department Button Click
    ' Submit Department Button Click (for the ACTUAL form submission button)
    Private Sub btnSubmitDepartment_Click(sender As Object, e As EventArgs) Handles btnSubmitDepartment.Click
        ' Validate required fields using the new validation functions
        If Not IsValidDepartmentCode(txtDeptCode.Text) Then
            txtDeptCode.Focus()
            Return
        End If

        If Not IsValidDepartmentName(txtDeptName.Text) Then
            txtDeptName.Focus()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for duplicate department code or name
                Dim checkQuery As String = "SELECT COUNT(*) FROM Departments WHERE department_code = @code OR department_name = @name"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@code", txtDeptCode.Text.Trim().ToUpper())
                    checkCmd.Parameters.AddWithValue("@name", txtDeptName.Text.Trim())
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Department code or name already exists. Please use different values.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Get head instructor ID (nullable)
                Dim headInstructorId As Object = DBNull.Value
                If cmbDeptHeadInstructor.SelectedIndex > 0 AndAlso cmbDeptHeadInstructor.SelectedValue IsNot Nothing Then
                    If Not IsDBNull(cmbDeptHeadInstructor.SelectedValue) Then
                        headInstructorId = Convert.ToInt32(cmbDeptHeadInstructor.SelectedValue)
                    End If
                End If

                ' Insert new department
                Dim insertQuery As String = "INSERT INTO Departments (department_code, department_name, description, head_instructor_id, created_at, updated_at) " &
                                   "VALUES (@code, @name, @description, @head_instructor_id, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@code", txtDeptCode.Text.Trim().ToUpper())
                    insertCmd.Parameters.AddWithValue("@name", txtDeptName.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(txtDeptDescription.Text), DBNull.Value, CType(txtDeptDescription.Text.Trim(), Object)))
                    insertCmd.Parameters.AddWithValue("@head_instructor_id", headInstructorId)

                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show($"Department added successfully!" & vbCrLf & vbCrLf &
                      $"Code: {txtDeptCode.Text.Trim().ToUpper()}" & vbCrLf &
                      $"Name: {txtDeptName.Text.Trim()}",
                      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh data and clear form
                LoadDepartmentsData()
                LoadDepartmentUpdateDropdown()
                InitializeDepartmentDropdown()
                ClearDepartmentForm()

            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Department code or name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error adding department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load Department Data Button
    Private Sub btnLoadDepartmentData_Click(sender As Object, e As EventArgs) Handles btnLoadDepartmentData.Click
        If cmbSelectDepartment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a department to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedDeptId As Integer = Convert.ToInt32(cmbSelectDepartment.SelectedValue)
            LoadDepartmentForUpdate(selectedDeptId)
        Catch ex As Exception
            MessageBox.Show($"Error loading department data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Load department data for update
    Private Sub LoadDepartmentForUpdate(departmentId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT department_code, department_name, description, head_instructor_id " &
                                "FROM Departments WHERE department_id = @department_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@department_id", departmentId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtUpdateDeptCode.Text = reader("department_code").ToString()
                            txtUpdateDeptName.Text = reader("department_name").ToString()
                            txtUpdateDeptDescription.Text = If(IsDBNull(reader("description")), "", reader("description").ToString())

                            ' Set head instructor
                            If IsDBNull(reader("head_instructor_id")) Then
                                cmbUpdateDeptHeadInstructor.SelectedIndex = 0 ' None
                            Else
                                cmbUpdateDeptHeadInstructor.SelectedValue = Convert.ToInt32(reader("head_instructor_id"))
                            End If

                            ' Show group box and buttons
                            grpDepartmentInfo.Visible = True
                            btnUpdateDepartment.Visible = True
                            btnDeleteDepartment.Visible = True
                        Else
                            MessageBox.Show("Department data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading department data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Update Department Button
    Private Sub btnUpdateDepartment_Click(sender As Object, e As EventArgs) Handles btnUpdateDepartment.Click
        If cmbSelectDepartment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a department to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate required fields using the new validation functions
        If Not IsValidDepartmentCode(txtUpdateDeptCode.Text) Then
            txtUpdateDeptCode.Focus()
            Return
        End If

        If Not IsValidDepartmentName(txtUpdateDeptName.Text) Then
            txtUpdateDeptName.Focus()
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this department information?",
                                             "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedDeptId As Integer = Convert.ToInt32(cmbSelectDepartment.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Check for duplicate (excluding current department)
                    Dim checkQuery As String = "SELECT COUNT(*) FROM Departments WHERE (department_code = @code OR department_name = @name) AND department_id != @dept_id"
                    Using checkCmd As New MySqlCommand(checkQuery, connection)
                        checkCmd.Parameters.AddWithValue("@code", txtUpdateDeptCode.Text.Trim().ToUpper())
                        checkCmd.Parameters.AddWithValue("@name", txtUpdateDeptName.Text.Trim())
                        checkCmd.Parameters.AddWithValue("@dept_id", selectedDeptId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Department code or name already exists for another department.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Get head instructor ID
                    Dim headInstructorId As Object = DBNull.Value
                    If cmbUpdateDeptHeadInstructor.SelectedIndex > 0 AndAlso cmbUpdateDeptHeadInstructor.SelectedValue IsNot Nothing Then
                        If Not IsDBNull(cmbUpdateDeptHeadInstructor.SelectedValue) Then
                            headInstructorId = Convert.ToInt32(cmbUpdateDeptHeadInstructor.SelectedValue)
                        End If
                    End If

                    ' Update department
                    Dim updateQuery As String = "UPDATE Departments SET " &
                                       "department_code = @code, " &
                                       "department_name = @name, " &
                                       "description = @description, " &
                                       "head_instructor_id = @head_instructor_id, " &
                                       "updated_at = NOW() " &
                                       "WHERE department_id = @dept_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@code", txtUpdateDeptCode.Text.Trim().ToUpper())
                        updateCmd.Parameters.AddWithValue("@name", txtUpdateDeptName.Text.Trim())
                        updateCmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(txtUpdateDeptDescription.Text), DBNull.Value, CType(txtUpdateDeptDescription.Text.Trim(), Object)))
                        updateCmd.Parameters.AddWithValue("@head_instructor_id", headInstructorId)
                        updateCmd.Parameters.AddWithValue("@dept_id", selectedDeptId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Department information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh data
                    LoadDepartmentsData()
                    LoadDepartmentUpdateDropdown()
                    InitializeDepartmentDropdown()
                    ClearUpdateDepartmentForm()
                End Using
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    MessageBox.Show("Department code or name already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error updating department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ValidateDepartmentCodeInput(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)

        ' Allow backspace
        If e.KeyChar = ControlChars.Back Then
            Return
        End If

        ' If this is the first character, it must be an uppercase letter
        If textBox.Text.Length = 0 Then
            If Not Char.IsUpper(e.KeyChar) Then
                e.Handled = True
                MessageBox.Show("Department Code must start with an uppercase letter.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            ' Check if hyphen already exists
            Dim hasHyphen As Boolean = textBox.Text.Contains("-")

            ' If trying to type a hyphen
            If e.KeyChar = "-"c Then
                ' Only allow one hyphen, and it must come after at least one letter
                If hasHyphen Then
                    e.Handled = True
                    MessageBox.Show("Department Code can only contain one hyphen.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                ' Don't allow hyphen as the second character (at least 2 letters before hyphen)
                If textBox.Text.Length < 2 Then
                    e.Handled = True
                    MessageBox.Show("Department Code must have at least 2 letters before the hyphen." & vbCrLf &
                          "Format example: CS-101, DEPT-222", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
                ' Check if there are only letters before this position
                If Not textBox.Text.All(AddressOf Char.IsUpper) Then
                    e.Handled = True
                    MessageBox.Show("Hyphen can only be placed after letters.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            ElseIf hasHyphen Then
                ' After hyphen, only allow numbers
                If Not Char.IsDigit(e.KeyChar) Then
                    e.Handled = True
                    MessageBox.Show("After the hyphen, only numbers are allowed." & vbCrLf &
                          "Format example: CS-101, DEPT-222", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            Else
                ' Before hyphen, only allow uppercase letters
                If Not Char.IsUpper(e.KeyChar) Then
                    e.Handled = True
                    MessageBox.Show("Before the hyphen, only uppercase letters are allowed." & vbCrLf &
                          "Format example: CS-101 or DEPT222", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub ValidateDepartmentNameInput(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)

        ' Allow backspace and spaces
        If e.KeyChar = ControlChars.Back OrElse e.KeyChar = " "c Then
            Return
        End If

        ' Get the text without spaces to check if any letters exist
        Dim textWithoutSpaces As String = textBox.Text.Replace(" ", "")

        ' If no letters have been typed yet, only allow letters
        If textWithoutSpaces.Length = 0 OrElse Not textWithoutSpaces.Any(AddressOf Char.IsLetter) Then
            If Not Char.IsLetter(e.KeyChar) Then
                e.Handled = True
                MessageBox.Show("Department Name must start with at least one letter before numbers can be used.",
                          "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Else
            ' After at least one letter exists, allow letters, numbers, and spaces
            If Not (Char.IsLetter(e.KeyChar) OrElse Char.IsDigit(e.KeyChar)) Then
                e.Handled = True
                MessageBox.Show("Department Name can only contain letters, numbers, and spaces." & vbCrLf &
                          "Must start with a letter.",
                          "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If
    End Sub

    ' Validation function for Department Code format
    ' Validation function for Department Code format
    Private Function IsValidDepartmentCode(deptCode As String) As Boolean
        If String.IsNullOrWhiteSpace(deptCode) Then
            MessageBox.Show("Department Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim trimmedCode As String = deptCode.Trim().ToUpper()

        ' Check if it contains a hyphen
        If trimmedCode.Contains("-") Then
            ' Format: LETTERS-NUMBERS (e.g., CS-101, DEPT-222)
            ' Must have: uppercase letters, one hyphen, then numbers
            If Not Regex.IsMatch(trimmedCode, "^[A-Z]{2,}-[0-9]+$") Then
                MessageBox.Show("Department Code with hyphen must:" & vbCrLf &
                      "• Start with at least 2 uppercase letters" & vbCrLf &
                      "• Have exactly one hyphen (-)" & vbCrLf &
                      "• End with numbers" & vbCrLf &
                      "• Examples: CS-101, DEPT-222, IT-301", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If

            ' Additional check: ensure hyphen count is exactly 1
            If trimmedCode.Count(Function(c) c = "-"c) > 1 Then
                MessageBox.Show("Department Code can only contain one hyphen.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Else
            ' Format without hyphen: LETTERSNUMBERS (e.g., CS101, DEPT222)
            ' Must start with uppercase letter, followed by uppercase letters and/or numbers
            If Not Regex.IsMatch(trimmedCode, "^[A-Z][A-Z0-9]*$") Then
                MessageBox.Show("Department Code must:" & vbCrLf &
                      "• Start with an uppercase letter" & vbCrLf &
                      "• Contain only uppercase letters and numbers" & vbCrLf &
                      "• Or use format: LETTERS-NUMBERS" & vbCrLf &
                      "• Examples: CS, CS101, CS-101, DEPT-222", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        End If

        Return True
    End Function

    ' Validation function for Department Name format
    Private Function IsValidDepartmentName(deptName As String) As Boolean
        If String.IsNullOrWhiteSpace(deptName) Then
            MessageBox.Show("Department Name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim trimmedName As String = deptName.Trim()

        ' Must contain at least one letter
        If Not trimmedName.Any(AddressOf Char.IsLetter) Then
            MessageBox.Show("Department Name must contain at least one letter.",
                      "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Must start with a letter (after removing leading spaces)
        If Not Char.IsLetter(trimmedName(0)) Then
            MessageBox.Show("Department Name must start with a letter.",
                      "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Can only contain letters, numbers, and spaces
        If Not Regex.IsMatch(trimmedName, "^[a-zA-Z][a-zA-Z0-9\s]*$") Then
            MessageBox.Show("Department Name can only contain letters, numbers, and spaces." & vbCrLf &
                      "Must start with a letter.",
                      "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Check that at least one letter comes before any numbers
        Dim foundLetter As Boolean = False
        For Each c As Char In trimmedName
            If Char.IsLetter(c) Then
                foundLetter = True
            ElseIf Char.IsDigit(c) And Not foundLetter Then
                MessageBox.Show("Department Name must have at least one letter before any numbers.",
                          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        Return True
    End Function

    ' Delete Department Button
    Private Sub btnDeleteDepartment_Click(sender As Object, e As EventArgs) Handles btnDeleteDepartment.Click
        If cmbSelectDepartment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a department to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedDeptId As Integer = Convert.ToInt32(cmbSelectDepartment.SelectedValue)
        Dim selectedDeptDisplay As String = cmbSelectDepartment.Text

        ' Check if department has courses or students assigned
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for dependencies
                Dim courseCountQuery As String = "SELECT COUNT(*) FROM Courses WHERE department_id = @dept_id"
                Dim studentCountQuery As String = "SELECT COUNT(*) FROM Students WHERE department_id = @dept_id"
                Dim instructorCountQuery As String = "SELECT COUNT(*) FROM Instructors WHERE department_id = @dept_id"

                Dim courseCount, studentCount, instructorCount As Integer

                Using cmd As New MySqlCommand(courseCountQuery, connection)
                    cmd.Parameters.AddWithValue("@dept_id", selectedDeptId)
                    courseCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Using cmd As New MySqlCommand(studentCountQuery, connection)
                    cmd.Parameters.AddWithValue("@dept_id", selectedDeptId)
                    studentCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                Using cmd As New MySqlCommand(instructorCountQuery, connection)
                    cmd.Parameters.AddWithValue("@dept_id", selectedDeptId)
                    instructorCount = Convert.ToInt32(cmd.ExecuteScalar())
                End Using

                ' Show warning if dependencies exist
                If courseCount > 0 OrElse studentCount > 0 OrElse instructorCount > 0 Then
                    Dim dependencyMsg As String = $"⚠️ WARNING: This department has dependencies!" & vbCrLf & vbCrLf &
                                             $"• {courseCount} course(s)" & vbCrLf &
                                             $"• {studentCount} student(s)" & vbCrLf &
                                             $"• {instructorCount} instructor(s)" & vbCrLf & vbCrLf &
                                             "Deleting this department will NOT delete these records, but they will lose their department association." & vbCrLf & vbCrLf &
                                             "Are you sure you want to proceed?"

                    Dim dependencyResult As DialogResult = MessageBox.Show(dependencyMsg, "Confirm Deletion with Dependencies", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

                    If dependencyResult <> DialogResult.Yes Then
                        Return
                    End If
                Else
                    ' No dependencies, simple confirmation
                    Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the department: {selectedDeptDisplay}?",
                                                             "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If result <> DialogResult.Yes Then
                        Return
                    End If
                End If

                ' Delete department
                Dim deleteQuery As String = "DELETE FROM Departments WHERE department_id = @dept_id"
                Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                    deleteCmd.Parameters.AddWithValue("@dept_id", selectedDeptId)
                    Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show($"Department deleted successfully: {selectedDeptDisplay}", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' Refresh data
                        LoadDepartmentsData()
                        LoadDepartmentUpdateDropdown()
                        InitializeDepartmentDropdown()
                        ClearUpdateDepartmentForm()
                    Else
                        MessageBox.Show("Failed to delete department. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error deleting department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Clear Add Department Form
    Private Sub ClearDepartmentForm()
        txtDeptCode.Clear()
        txtDeptName.Clear()
        txtDeptDescription.Clear()
        If cmbDeptHeadInstructor.Items.Count > 0 Then
            cmbDeptHeadInstructor.SelectedIndex = 0
        End If
    End Sub

    ' Clear Update Department Form
    Private Sub ClearUpdateDepartmentForm()
        txtUpdateDeptCode.Clear()
        txtUpdateDeptName.Clear()
        txtUpdateDeptDescription.Clear()
        If cmbUpdateDeptHeadInstructor.Items.Count > 0 Then
            cmbUpdateDeptHeadInstructor.SelectedIndex = 0
        End If
        grpDepartmentInfo.Visible = False
        btnUpdateDepartment.Visible = False
        btnDeleteDepartment.Visible = False
    End Sub

    ' RENAMED: Navigation handler for Add Department submenu button
    Private Sub btnAddDepartmentNav_Click(sender As Object, e As EventArgs) Handles btnAddDepartment.Click
        ShowPanel(pnlAddDepartment)
        SetActiveButton(btnAddDepartment, True)
        SetActiveButton(btnDepartmentManagement)
        ClearDepartmentForm()
    End Sub

    ' RENAMED: Navigation handler for Update/Delete Department submenu button
    Private Sub btnUpdateDeleteDepartmentNav_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteDepartment.Click
        ShowPanel(pnlUpdateDeleteDepartment)
        SetActiveButton(btnUpdateDeleteDepartment, True)
        SetActiveButton(btnDepartmentManagement)
    End Sub

    ' RENAMED: Navigation handler for Department Details submenu button
    Private Sub btnDepartmentDetailsNav_Click(sender As Object, e As EventArgs) Handles btnDepartmentDetails.Click
        ShowPanel(pnlDepartmentManagement)
        SetActiveButton(btnDepartmentDetails, True)
        SetActiveButton(btnDepartmentManagement)
    End Sub


    Private Sub lblAdminTitle_Click(sender As Object, e As EventArgs) Handles lblAdminTitle.Click

    End Sub

    Private Sub pnlSidebar_Paint(sender As Object, e As PaintEventArgs) Handles pnlSidebar.Paint

    End Sub

    Private Sub dgvDepartments_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDepartments.CellContentClick

    End Sub
End Class
