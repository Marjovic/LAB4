<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Admin
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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        pnlSidebar = New Panel()
        btnEnrollmentManagement = New Button()
        btnCourseManagement = New Button()
        pnlDepartmentManagementSubmenu = New Panel()
        btnDepartmentDetails = New Button()
        btnUpdateDeleteDepartment = New Button()
        btnAddDepartment = New Button()
        btnDepartmentManagement = New Button()
        pnlUserManagementSubmenu = New Panel()
        btnResetPassword = New Button()
        btnUserDetails = New Button()
        btnUpdateDeleteUser = New Button()
        btnAddUser = New Button()
        btnUserManagement = New Button()
        btnDashboard = New Button()
        lblAdminTitle = New Label()
        btnLogout = New Button()
        pnlMainContent = New Panel()
        pnlDepartmentManagement = New Panel()
        dgvDepartments = New DataGridView()
        lblDepartmentManagementTitle = New Label()
        pnlAddDepartment = New Panel()
        lblAddDepartmentTitle = New Label()
        lblDeptCode = New Label()
        txtDeptCode = New TextBox()
        lblDeptName = New Label()
        txtDeptName = New TextBox()
        lblDeptDescription = New Label()
        txtDeptDescription = New TextBox()
        lblDeptHeadInstructor = New Label()
        cmbDeptHeadInstructor = New ComboBox()
        btnSubmitDepartment = New Button()
        pnlUpdateDeleteDepartment = New Panel()
        lblUpdateDeleteDeptTitle = New Label()
        lblSelectDepartment = New Label()
        cmbSelectDepartment = New ComboBox()
        btnLoadDepartmentData = New Button()
        grpDepartmentInfo = New GroupBox()
        lblUpdateDeptCode = New Label()
        txtUpdateDeptCode = New TextBox()
        lblUpdateDeptName = New Label()
        txtUpdateDeptName = New TextBox()
        lblUpdateDeptDescription = New Label()
        txtUpdateDeptDescription = New TextBox()
        lblUpdateDeptHeadInstructor = New Label()
        cmbUpdateDeptHeadInstructor = New ComboBox()
        btnUpdateDepartment = New Button()
        btnDeleteDepartment = New Button()
        pnlDashboard = New Panel()
        lblDashboardTitle = New Label()
        lblWelcome = New Label()
        pnlStats = New Panel()
        lblTotalUsers = New Label()
        lblTotalInstructors = New Label()
        lblTotalStudents = New Label()
        pnlAddUser = New Panel()
        lblAddUserTitle = New Label()
        lblFirstName = New Label()
        txtFirstName = New TextBox()
        lblMiddleName = New Label()
        txtMiddleName = New TextBox()
        lblLastName = New Label()
        txtLastName = New TextBox()
        lblUsername = New Label()
        txtUsername = New TextBox()
        lblPassword = New Label()
        txtPassword = New TextBox()
        lblRole = New Label()
        cmbRole = New ComboBox()
        pnlStudentFields = New Panel()
        lblStudentFieldsTitle = New Label()
        lblDateOfBirth = New Label()
        dtpDateOfBirth = New DateTimePicker()
        lblGender = New Label()
        cmbGender = New ComboBox()
        lblYearLevel = New Label()
        cmbYearLevel = New ComboBox()
        lblDepartment = New Label()
        cmbDepartment = New ComboBox()
        lblStudentEmail = New Label()
        txtStudentEmail = New TextBox()
        lblEnrollmentStatus = New Label()
        cmbEnrollmentStatus = New ComboBox()
        pnlInstructorFields = New Panel()
        lblInstructorFieldsTitle = New Label()
        lblInstructorEmail = New Label()
        txtInstructorEmail = New TextBox()
        lblInstructorDepartment = New Label()
        cmbInstructorDepartment = New ComboBox()
        lblSpecialization = New Label()
        txtSpecialization = New TextBox()
        lblHireDate = New Label()
        dtpHireDate = New DateTimePicker()
        btnSubmitUser = New Button()
        pnlUserDetails = New Panel()
        lblUserDetailsTitle = New Label()
        lblUsers = New Label()
        dgvUsers = New DataGridView()
        lblInstructors = New Label()
        dgvInstructors = New DataGridView()
        lblStudents = New Label()
        dgvStudents = New DataGridView()
        pnlResetPassword = New Panel()
        lblResetPasswordTitle = New Label()
        lblSelectUserReset = New Label()
        cmbSelectUserReset = New ComboBox()
        lblNewPassword = New Label()
        txtNewPassword = New TextBox()
        btnGeneratePassword = New Button()
        btnResetPasswordSubmit = New Button()
        pnlUpdateDeleteUser = New Panel()
        lblUpdateDeleteTitle = New Label()
        lblSelectUserUpdate = New Label()
        cmbSelectUserUpdate = New ComboBox()
        btnLoadUserData = New Button()
        grpUserInfo = New GroupBox()
        lblUpdateFirstName = New Label()
        txtUpdateFirstName = New TextBox()
        lblUpdateMiddleName = New Label()
        txtUpdateMiddleName = New TextBox()
        lblUpdateLastName = New Label()
        txtUpdateLastName = New TextBox()
        lblUpdateUsername = New Label()
        txtUpdateUsername = New TextBox()
        lblUpdateRole = New Label()
        lblUpdateRoleDisplay = New Label()
        cmbUpdateRole = New ComboBox()
        pnlUpdateStudentFields = New Panel()
        lblUpdateStudentTitle = New Label()
        lblUpdateDateOfBirth = New Label()
        dtpUpdateDateOfBirth = New DateTimePicker()
        lblUpdateGender = New Label()
        cmbUpdateGender = New ComboBox()
        lblUpdateYearLevel = New Label()
        cmbUpdateYearLevel = New ComboBox()
        lblUpdateDepartment = New Label()
        cmbUpdateDepartment = New ComboBox()
        lblUpdateStudentEmail = New Label()
        txtUpdateStudentEmail = New TextBox()
        lblUpdateEnrollmentStatus = New Label()
        cmbUpdateEnrollmentStatus = New ComboBox()
        pnlUpdateInstructorFields = New Panel()
        lblUpdateInstructorTitle = New Label()
        lblUpdateInstructorEmail = New Label()
        txtUpdateInstructorEmail = New TextBox()
        lblUpdateInstructorDepartment = New Label()
        cmbUpdateInstructorDepartment = New ComboBox()
        lblUpdateSpecialization = New Label()
        txtUpdateSpecialization = New TextBox()
        lblUpdateHireDate = New Label()
        dtpUpdateHireDate = New DateTimePicker()
        lblUpdateEmploymentStatus = New Label()
        cmbUpdateEmploymentStatus = New ComboBox()
        btnUpdateUser = New Button()
        btnDeleteUser = New Button()
        pnlSidebar.SuspendLayout()
        pnlDepartmentManagementSubmenu.SuspendLayout()
        pnlUserManagementSubmenu.SuspendLayout()
        pnlMainContent.SuspendLayout()
        pnlDepartmentManagement.SuspendLayout()
        CType(dgvDepartments, ComponentModel.ISupportInitialize).BeginInit()
        pnlAddDepartment.SuspendLayout()
        pnlUpdateDeleteDepartment.SuspendLayout()
        grpDepartmentInfo.SuspendLayout()
        pnlDashboard.SuspendLayout()
        pnlStats.SuspendLayout()
        pnlAddUser.SuspendLayout()
        pnlStudentFields.SuspendLayout()
        pnlInstructorFields.SuspendLayout()
        pnlUserDetails.SuspendLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvInstructors, ComponentModel.ISupportInitialize).BeginInit()
        CType(dgvStudents, ComponentModel.ISupportInitialize).BeginInit()
        pnlResetPassword.SuspendLayout()
        pnlUpdateDeleteUser.SuspendLayout()
        grpUserInfo.SuspendLayout()
        pnlUpdateStudentFields.SuspendLayout()
        pnlUpdateInstructorFields.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlSidebar
        ' 
        pnlSidebar.BackColor = Color.Navy
        pnlSidebar.Controls.Add(btnEnrollmentManagement)
        pnlSidebar.Controls.Add(btnCourseManagement)
        pnlSidebar.Controls.Add(pnlDepartmentManagementSubmenu)
        pnlSidebar.Controls.Add(btnDepartmentManagement)
        pnlSidebar.Controls.Add(pnlUserManagementSubmenu)
        pnlSidebar.Controls.Add(btnUserManagement)
        pnlSidebar.Controls.Add(btnDashboard)
        pnlSidebar.Controls.Add(lblAdminTitle)
        pnlSidebar.Controls.Add(btnLogout)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Location = New Point(0, 0)
        pnlSidebar.Name = "pnlSidebar"
        pnlSidebar.Size = New Size(227, 800)
        pnlSidebar.TabIndex = 0
        ' 
        ' btnEnrollmentManagement
        ' 
        btnEnrollmentManagement.BackColor = SystemColors.MenuHighlight
        btnEnrollmentManagement.Dock = DockStyle.Top
        btnEnrollmentManagement.FlatAppearance.BorderSize = 0
        btnEnrollmentManagement.FlatStyle = FlatStyle.Flat
        btnEnrollmentManagement.Font = New Font("Times New Roman", 12F)
        btnEnrollmentManagement.ForeColor = Color.White
        btnEnrollmentManagement.Location = New Point(0, 596)
        btnEnrollmentManagement.Name = "btnEnrollmentManagement"
        btnEnrollmentManagement.Padding = New Padding(10, 0, 0, 0)
        btnEnrollmentManagement.Size = New Size(227, 50)
        btnEnrollmentManagement.TabIndex = 8
        btnEnrollmentManagement.Text = "📝Enrollment Management"
        btnEnrollmentManagement.TextAlign = ContentAlignment.MiddleLeft
        btnEnrollmentManagement.UseVisualStyleBackColor = False
        ' 
        ' btnCourseManagement
        ' 
        btnCourseManagement.BackColor = SystemColors.MenuHighlight
        btnCourseManagement.Dock = DockStyle.Top
        btnCourseManagement.FlatAppearance.BorderSize = 0
        btnCourseManagement.FlatStyle = FlatStyle.Flat
        btnCourseManagement.Font = New Font("Times New Roman", 12F)
        btnCourseManagement.ForeColor = Color.White
        btnCourseManagement.Location = New Point(0, 546)
        btnCourseManagement.Name = "btnCourseManagement"
        btnCourseManagement.Padding = New Padding(10, 0, 0, 0)
        btnCourseManagement.Size = New Size(227, 50)
        btnCourseManagement.TabIndex = 7
        btnCourseManagement.Text = "📚Course Management"
        btnCourseManagement.TextAlign = ContentAlignment.MiddleLeft
        btnCourseManagement.UseVisualStyleBackColor = False
        ' 
        ' pnlDepartmentManagementSubmenu
        ' 
        pnlDepartmentManagementSubmenu.BackColor = Color.Transparent
        pnlDepartmentManagementSubmenu.Controls.Add(btnDepartmentDetails)
        pnlDepartmentManagementSubmenu.Controls.Add(btnUpdateDeleteDepartment)
        pnlDepartmentManagementSubmenu.Controls.Add(btnAddDepartment)
        pnlDepartmentManagementSubmenu.Dock = DockStyle.Top
        pnlDepartmentManagementSubmenu.Location = New Point(0, 407)
        pnlDepartmentManagementSubmenu.Name = "pnlDepartmentManagementSubmenu"
        pnlDepartmentManagementSubmenu.Size = New Size(227, 139)
        pnlDepartmentManagementSubmenu.TabIndex = 6
        pnlDepartmentManagementSubmenu.Visible = False
        ' 
        ' btnDepartmentDetails
        ' 
        btnDepartmentDetails.BackColor = SystemColors.MenuHighlight
        btnDepartmentDetails.Dock = DockStyle.Top
        btnDepartmentDetails.FlatAppearance.BorderSize = 0
        btnDepartmentDetails.FlatStyle = FlatStyle.Flat
        btnDepartmentDetails.Font = New Font("Times New Roman", 12F)
        btnDepartmentDetails.ForeColor = Color.Transparent
        btnDepartmentDetails.Location = New Point(0, 94)
        btnDepartmentDetails.Name = "btnDepartmentDetails"
        btnDepartmentDetails.Padding = New Padding(30, 0, 0, 0)
        btnDepartmentDetails.Size = New Size(227, 45)
        btnDepartmentDetails.TabIndex = 2
        btnDepartmentDetails.Text = "Department Details"
        btnDepartmentDetails.TextAlign = ContentAlignment.MiddleLeft
        btnDepartmentDetails.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteDepartment
        ' 
        btnUpdateDeleteDepartment.BackColor = SystemColors.MenuHighlight
        btnUpdateDeleteDepartment.Dock = DockStyle.Top
        btnUpdateDeleteDepartment.FlatAppearance.BorderSize = 0
        btnUpdateDeleteDepartment.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteDepartment.Font = New Font("Times New Roman", 12F)
        btnUpdateDeleteDepartment.ForeColor = Color.Transparent
        btnUpdateDeleteDepartment.Location = New Point(0, 49)
        btnUpdateDeleteDepartment.Name = "btnUpdateDeleteDepartment"
        btnUpdateDeleteDepartment.Padding = New Padding(30, 0, 0, 0)
        btnUpdateDeleteDepartment.Size = New Size(227, 45)
        btnUpdateDeleteDepartment.TabIndex = 1
        btnUpdateDeleteDepartment.Text = "Update/Delete Department"
        btnUpdateDeleteDepartment.TextAlign = ContentAlignment.MiddleLeft
        btnUpdateDeleteDepartment.UseVisualStyleBackColor = False
        ' 
        ' btnAddDepartment
        ' 
        btnAddDepartment.BackColor = SystemColors.MenuHighlight
        btnAddDepartment.Dock = DockStyle.Top
        btnAddDepartment.FlatAppearance.BorderSize = 0
        btnAddDepartment.FlatStyle = FlatStyle.Flat
        btnAddDepartment.Font = New Font("Times New Roman", 12F)
        btnAddDepartment.ForeColor = Color.Transparent
        btnAddDepartment.Location = New Point(0, 0)
        btnAddDepartment.Name = "btnAddDepartment"
        btnAddDepartment.Padding = New Padding(30, 0, 0, 0)
        btnAddDepartment.Size = New Size(227, 49)
        btnAddDepartment.TabIndex = 0
        btnAddDepartment.Text = "+ Add Department"
        btnAddDepartment.TextAlign = ContentAlignment.MiddleLeft
        btnAddDepartment.UseVisualStyleBackColor = False
        ' 
        ' btnDepartmentManagement
        ' 
        btnDepartmentManagement.BackColor = SystemColors.MenuHighlight
        btnDepartmentManagement.Dock = DockStyle.Top
        btnDepartmentManagement.FlatAppearance.BorderSize = 0
        btnDepartmentManagement.FlatStyle = FlatStyle.Flat
        btnDepartmentManagement.Font = New Font("Times New Roman", 12F)
        btnDepartmentManagement.ForeColor = Color.White
        btnDepartmentManagement.Location = New Point(0, 357)
        btnDepartmentManagement.Name = "btnDepartmentManagement"
        btnDepartmentManagement.Padding = New Padding(10, 0, 0, 0)
        btnDepartmentManagement.Size = New Size(227, 50)
        btnDepartmentManagement.TabIndex = 5
        btnDepartmentManagement.Text = "Department Management"
        btnDepartmentManagement.TextAlign = ContentAlignment.MiddleLeft
        btnDepartmentManagement.UseVisualStyleBackColor = False
        ' 
        ' pnlUserManagementSubmenu
        ' 
        pnlUserManagementSubmenu.BackColor = Color.Transparent
        pnlUserManagementSubmenu.Controls.Add(btnResetPassword)
        pnlUserManagementSubmenu.Controls.Add(btnUserDetails)
        pnlUserManagementSubmenu.Controls.Add(btnUpdateDeleteUser)
        pnlUserManagementSubmenu.Controls.Add(btnAddUser)
        pnlUserManagementSubmenu.Dock = DockStyle.Top
        pnlUserManagementSubmenu.Location = New Point(0, 178)
        pnlUserManagementSubmenu.Name = "pnlUserManagementSubmenu"
        pnlUserManagementSubmenu.Size = New Size(227, 179)
        pnlUserManagementSubmenu.TabIndex = 3
        pnlUserManagementSubmenu.Visible = False
        ' 
        ' btnResetPassword
        ' 
        btnResetPassword.BackColor = SystemColors.MenuHighlight
        btnResetPassword.Dock = DockStyle.Top
        btnResetPassword.FlatAppearance.BorderSize = 0
        btnResetPassword.FlatStyle = FlatStyle.Flat
        btnResetPassword.Font = New Font("Times New Roman", 12F)
        btnResetPassword.ForeColor = Color.Transparent
        btnResetPassword.Location = New Point(0, 139)
        btnResetPassword.Name = "btnResetPassword"
        btnResetPassword.Padding = New Padding(30, 0, 0, 0)
        btnResetPassword.Size = New Size(227, 45)
        btnResetPassword.TabIndex = 3
        btnResetPassword.Text = "Reset Password"
        btnResetPassword.TextAlign = ContentAlignment.MiddleLeft
        btnResetPassword.UseVisualStyleBackColor = False
        ' 
        ' btnUserDetails
        ' 
        btnUserDetails.BackColor = SystemColors.MenuHighlight
        btnUserDetails.Dock = DockStyle.Top
        btnUserDetails.FlatAppearance.BorderSize = 0
        btnUserDetails.FlatStyle = FlatStyle.Flat
        btnUserDetails.Font = New Font("Times New Roman", 12F)
        btnUserDetails.ForeColor = Color.Transparent
        btnUserDetails.Location = New Point(0, 94)
        btnUserDetails.Name = "btnUserDetails"
        btnUserDetails.Padding = New Padding(30, 0, 0, 0)
        btnUserDetails.Size = New Size(227, 45)
        btnUserDetails.TabIndex = 2
        btnUserDetails.Text = "User Details"
        btnUserDetails.TextAlign = ContentAlignment.MiddleLeft
        btnUserDetails.UseVisualStyleBackColor = False
        ' 
        ' btnUpdateDeleteUser
        ' 
        btnUpdateDeleteUser.BackColor = SystemColors.MenuHighlight
        btnUpdateDeleteUser.Dock = DockStyle.Top
        btnUpdateDeleteUser.FlatAppearance.BorderSize = 0
        btnUpdateDeleteUser.FlatStyle = FlatStyle.Flat
        btnUpdateDeleteUser.Font = New Font("Times New Roman", 12F)
        btnUpdateDeleteUser.ForeColor = Color.Transparent
        btnUpdateDeleteUser.Location = New Point(0, 49)
        btnUpdateDeleteUser.Name = "btnUpdateDeleteUser"
        btnUpdateDeleteUser.Padding = New Padding(30, 0, 0, 0)
        btnUpdateDeleteUser.Size = New Size(227, 45)
        btnUpdateDeleteUser.TabIndex = 1
        btnUpdateDeleteUser.Text = "Update/Delete User"
        btnUpdateDeleteUser.TextAlign = ContentAlignment.MiddleLeft
        btnUpdateDeleteUser.UseVisualStyleBackColor = False
        ' 
        ' btnAddUser
        ' 
        btnAddUser.BackColor = SystemColors.MenuHighlight
        btnAddUser.Dock = DockStyle.Top
        btnAddUser.FlatAppearance.BorderSize = 0
        btnAddUser.FlatStyle = FlatStyle.Flat
        btnAddUser.Font = New Font("Times New Roman", 12F)
        btnAddUser.ForeColor = Color.Transparent
        btnAddUser.Location = New Point(0, 0)
        btnAddUser.Name = "btnAddUser"
        btnAddUser.Padding = New Padding(30, 0, 0, 0)
        btnAddUser.Size = New Size(227, 49)
        btnAddUser.TabIndex = 0
        btnAddUser.Text = "+ Add User"
        btnAddUser.TextAlign = ContentAlignment.MiddleLeft
        btnAddUser.UseVisualStyleBackColor = False
        ' 
        ' btnUserManagement
        ' 
        btnUserManagement.BackColor = SystemColors.MenuHighlight
        btnUserManagement.Dock = DockStyle.Top
        btnUserManagement.FlatAppearance.BorderSize = 0
        btnUserManagement.FlatStyle = FlatStyle.Flat
        btnUserManagement.Font = New Font("Times New Roman", 12F)
        btnUserManagement.ForeColor = Color.White
        btnUserManagement.Location = New Point(0, 128)
        btnUserManagement.Name = "btnUserManagement"
        btnUserManagement.Padding = New Padding(10, 0, 0, 0)
        btnUserManagement.Size = New Size(227, 50)
        btnUserManagement.TabIndex = 2
        btnUserManagement.Text = "User Management"
        btnUserManagement.TextAlign = ContentAlignment.MiddleLeft
        btnUserManagement.UseVisualStyleBackColor = False
        ' 
        ' btnDashboard
        ' 
        btnDashboard.BackColor = SystemColors.MenuHighlight
        btnDashboard.Dock = DockStyle.Top
        btnDashboard.FlatAppearance.BorderSize = 0
        btnDashboard.FlatStyle = FlatStyle.Flat
        btnDashboard.Font = New Font("Times New Roman", 12F)
        btnDashboard.ForeColor = Color.White
        btnDashboard.Location = New Point(0, 80)
        btnDashboard.Name = "btnDashboard"
        btnDashboard.Padding = New Padding(10, 0, 0, 0)
        btnDashboard.Size = New Size(227, 48)
        btnDashboard.TabIndex = 1
        btnDashboard.Text = "Dashboard"
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft
        btnDashboard.UseVisualStyleBackColor = False
        ' 
        ' lblAdminTitle
        ' 
        lblAdminTitle.BackColor = Color.Navy
        lblAdminTitle.Dock = DockStyle.Top
        lblAdminTitle.Font = New Font("Times New Roman", 14F, FontStyle.Bold)
        lblAdminTitle.ForeColor = Color.White
        lblAdminTitle.Location = New Point(0, 0)
        lblAdminTitle.Name = "lblAdminTitle"
        lblAdminTitle.Size = New Size(227, 80)
        lblAdminTitle.TabIndex = 0
        lblAdminTitle.Text = "MGOD LMS"
        lblAdminTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnLogout
        ' 
        btnLogout.BackColor = Color.FromArgb(192, 0, 0)
        btnLogout.Dock = DockStyle.Bottom
        btnLogout.FlatAppearance.BorderSize = 0
        btnLogout.FlatStyle = FlatStyle.Flat
        btnLogout.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        btnLogout.ForeColor = Color.White
        btnLogout.Location = New Point(0, 750)
        btnLogout.Name = "btnLogout"
        btnLogout.Padding = New Padding(10, 0, 0, 0)
        btnLogout.Size = New Size(227, 50)
        btnLogout.TabIndex = 4
        btnLogout.Text = "🚪 Logout"
        btnLogout.TextAlign = ContentAlignment.MiddleLeft
        btnLogout.UseVisualStyleBackColor = False
        ' 
        ' pnlMainContent
        ' 
        pnlMainContent.BackColor = Color.FromArgb(240, 240, 240)
        pnlMainContent.Controls.Add(pnlDepartmentManagement)
        pnlMainContent.Controls.Add(pnlAddDepartment)
        pnlMainContent.Controls.Add(pnlUpdateDeleteDepartment)
        pnlMainContent.Controls.Add(pnlDashboard)
        pnlMainContent.Controls.Add(pnlAddUser)
        pnlMainContent.Controls.Add(pnlUserDetails)
        pnlMainContent.Controls.Add(pnlResetPassword)
        pnlMainContent.Controls.Add(pnlUpdateDeleteUser)
        pnlMainContent.Dock = DockStyle.Fill
        pnlMainContent.Location = New Point(227, 0)
        pnlMainContent.Name = "pnlMainContent"
        pnlMainContent.Size = New Size(973, 800)
        pnlMainContent.TabIndex = 1
        ' 
        ' pnlDepartmentManagement
        ' 
        pnlDepartmentManagement.AutoScroll = True
        pnlDepartmentManagement.BackColor = Color.White
        pnlDepartmentManagement.Controls.Add(dgvDepartments)
        pnlDepartmentManagement.Controls.Add(lblDepartmentManagementTitle)
        pnlDepartmentManagement.Dock = DockStyle.Fill
        pnlDepartmentManagement.Location = New Point(0, 0)
        pnlDepartmentManagement.Name = "pnlDepartmentManagement"
        pnlDepartmentManagement.Padding = New Padding(20)
        pnlDepartmentManagement.Size = New Size(973, 800)
        pnlDepartmentManagement.TabIndex = 5
        pnlDepartmentManagement.Visible = False
        ' 
        ' dgvDepartments
        ' 
        dgvDepartments.AllowUserToAddRows = False
        dgvDepartments.AllowUserToDeleteRows = False
        dgvDepartments.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvDepartments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDepartments.BackgroundColor = SystemColors.Control
        dgvDepartments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = SystemColors.Window
        DataGridViewCellStyle1.Font = New Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0)
        DataGridViewCellStyle1.ForeColor = SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        dgvDepartments.DefaultCellStyle = DataGridViewCellStyle1
        dgvDepartments.Font = New Font("Times New Roman", 11F, FontStyle.Regular, GraphicsUnit.Point, 0)
        dgvDepartments.Location = New Point(20, 80)
        dgvDepartments.Name = "dgvDepartments"
        dgvDepartments.ReadOnly = True
        dgvDepartments.RowHeadersWidth = 25
        dgvDepartments.RowTemplate.Height = 30
        dgvDepartments.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDepartments.Size = New Size(932, 630)
        dgvDepartments.TabIndex = 1
        ' 
        ' lblDepartmentManagementTitle
        ' 
        lblDepartmentManagementTitle.AutoSize = True
        lblDepartmentManagementTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblDepartmentManagementTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblDepartmentManagementTitle.Location = New Point(20, 20)
        lblDepartmentManagementTitle.Name = "lblDepartmentManagementTitle"
        lblDepartmentManagementTitle.Size = New Size(370, 36)
        lblDepartmentManagementTitle.TabIndex = 0
        lblDepartmentManagementTitle.Text = "All Departments"
        ' 
        ' pnlAddDepartment
        ' 
        pnlAddDepartment.AutoScroll = True
        pnlAddDepartment.BackColor = Color.White
        pnlAddDepartment.Controls.Add(lblAddDepartmentTitle)
        pnlAddDepartment.Controls.Add(lblDeptCode)
        pnlAddDepartment.Controls.Add(txtDeptCode)
        pnlAddDepartment.Controls.Add(lblDeptName)
        pnlAddDepartment.Controls.Add(txtDeptName)
        pnlAddDepartment.Controls.Add(lblDeptDescription)
        pnlAddDepartment.Controls.Add(txtDeptDescription)
        pnlAddDepartment.Controls.Add(lblDeptHeadInstructor)
        pnlAddDepartment.Controls.Add(cmbDeptHeadInstructor)
        pnlAddDepartment.Controls.Add(btnSubmitDepartment)
        pnlAddDepartment.Dock = DockStyle.Fill
        pnlAddDepartment.Location = New Point(0, 0)
        pnlAddDepartment.Name = "pnlAddDepartment"
        pnlAddDepartment.Padding = New Padding(30, 20, 30, 20)
        pnlAddDepartment.Size = New Size(973, 800)
        pnlAddDepartment.TabIndex = 6
        pnlAddDepartment.Visible = False
        ' 
        ' lblAddDepartmentTitle
        ' 
        lblAddDepartmentTitle.AutoSize = True
        lblAddDepartmentTitle.Font = New Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblAddDepartmentTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblAddDepartmentTitle.Location = New Point(30, 20)
        lblAddDepartmentTitle.Name = "lblAddDepartmentTitle"
        lblAddDepartmentTitle.Size = New Size(268, 31)
        lblAddDepartmentTitle.TabIndex = 0
        lblAddDepartmentTitle.Text = "Add New Department"
        ' 
        ' lblDeptCode
        ' 
        lblDeptCode.AutoSize = True
        lblDeptCode.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblDeptCode.Location = New Point(50, 75)
        lblDeptCode.Name = "lblDeptCode"
        lblDeptCode.Size = New Size(130, 19)
        lblDeptCode.TabIndex = 1
        lblDeptCode.Text = "Department Code *"
        ' 
        ' txtDeptCode
        ' 
        txtDeptCode.CharacterCasing = CharacterCasing.Upper
        txtDeptCode.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtDeptCode.Location = New Point(50, 97)
        txtDeptCode.Name = "txtDeptCode"
        txtDeptCode.Size = New Size(400, 26)
        txtDeptCode.TabIndex = 2
        ' 
        ' lblDeptName
        ' 
        lblDeptName.AutoSize = True
        lblDeptName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblDeptName.Location = New Point(50, 145)
        lblDeptName.Name = "lblDeptName"
        lblDeptName.Size = New Size(133, 19)
        lblDeptName.TabIndex = 3
        lblDeptName.Text = "Department Name *"
        ' 
        ' txtDeptName
        ' 
        txtDeptName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtDeptName.Location = New Point(50, 167)
        txtDeptName.Name = "txtDeptName"
        txtDeptName.Size = New Size(790, 26)
        txtDeptName.TabIndex = 4
        ' 
        ' lblDeptDescription
        ' 
        lblDeptDescription.AutoSize = True
        lblDeptDescription.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblDeptDescription.Location = New Point(50, 215)
        lblDeptDescription.Name = "lblDeptDescription"
        lblDeptDescription.Size = New Size(144, 19)
        lblDeptDescription.TabIndex = 5
        lblDeptDescription.Text = "Description (Optional)"
        ' 
        ' txtDeptDescription
        ' 
        txtDeptDescription.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtDeptDescription.Location = New Point(50, 237)
        txtDeptDescription.Multiline = True
        txtDeptDescription.Name = "txtDeptDescription"
        txtDeptDescription.Size = New Size(790, 80)
        txtDeptDescription.TabIndex = 6
        ' 
        ' lblDeptHeadInstructor
        ' 
        lblDeptHeadInstructor.AutoSize = True
        lblDeptHeadInstructor.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblDeptHeadInstructor.Location = New Point(50, 340)
        lblDeptHeadInstructor.Name = "lblDeptHeadInstructor"
        lblDeptHeadInstructor.Size = New Size(170, 19)
        lblDeptHeadInstructor.TabIndex = 7
        lblDeptHeadInstructor.Text = "Head Instructor (Optional)"
        ' 
        ' cmbDeptHeadInstructor
        ' 
        cmbDeptHeadInstructor.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDeptHeadInstructor.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        cmbDeptHeadInstructor.FormattingEnabled = True
        cmbDeptHeadInstructor.Location = New Point(50, 362)
        cmbDeptHeadInstructor.Name = "cmbDeptHeadInstructor"
        cmbDeptHeadInstructor.Size = New Size(790, 27)
        cmbDeptHeadInstructor.TabIndex = 8
        ' 
        ' btnSubmitDepartment
        ' 
        btnSubmitDepartment.BackColor = Color.FromArgb(0, 122, 204)
        btnSubmitDepartment.FlatStyle = FlatStyle.Flat
        btnSubmitDepartment.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnSubmitDepartment.ForeColor = Color.White
        btnSubmitDepartment.Location = New Point(50, 420)
        btnSubmitDepartment.Name = "btnSubmitDepartment"
        btnSubmitDepartment.Size = New Size(200, 45)
        btnSubmitDepartment.TabIndex = 9
        btnSubmitDepartment.Text = "+ Add Department"
        btnSubmitDepartment.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteDepartment
        ' 
        pnlUpdateDeleteDepartment.AutoScroll = True
        pnlUpdateDeleteDepartment.BackColor = Color.White
        pnlUpdateDeleteDepartment.Controls.Add(lblUpdateDeleteDeptTitle)
        pnlUpdateDeleteDepartment.Controls.Add(lblSelectDepartment)
        pnlUpdateDeleteDepartment.Controls.Add(cmbSelectDepartment)
        pnlUpdateDeleteDepartment.Controls.Add(btnLoadDepartmentData)
        pnlUpdateDeleteDepartment.Controls.Add(grpDepartmentInfo)
        pnlUpdateDeleteDepartment.Controls.Add(btnUpdateDepartment)
        pnlUpdateDeleteDepartment.Controls.Add(btnDeleteDepartment)
        pnlUpdateDeleteDepartment.Dock = DockStyle.Fill
        pnlUpdateDeleteDepartment.Location = New Point(0, 0)
        pnlUpdateDeleteDepartment.Name = "pnlUpdateDeleteDepartment"
        pnlUpdateDeleteDepartment.Padding = New Padding(20)
        pnlUpdateDeleteDepartment.Size = New Size(973, 800)
        pnlUpdateDeleteDepartment.TabIndex = 7
        pnlUpdateDeleteDepartment.Visible = False
        ' 
        ' lblUpdateDeleteDeptTitle
        ' 
        lblUpdateDeleteDeptTitle.AutoSize = True
        lblUpdateDeleteDeptTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblUpdateDeleteDeptTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblUpdateDeleteDeptTitle.Location = New Point(20, 20)
        lblUpdateDeleteDeptTitle.Name = "lblUpdateDeleteDeptTitle"
        lblUpdateDeleteDeptTitle.Size = New Size(448, 36)
        lblUpdateDeleteDeptTitle.TabIndex = 0
        lblUpdateDeleteDeptTitle.Text = "Update/Delete Department Info"
        ' 
        ' lblSelectDepartment
        ' 
        lblSelectDepartment.AutoSize = True
        lblSelectDepartment.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblSelectDepartment.Location = New Point(40, 80)
        lblSelectDepartment.Name = "lblSelectDepartment"
        lblSelectDepartment.Size = New Size(146, 21)
        lblSelectDepartment.TabIndex = 1
        lblSelectDepartment.Text = "Select Department"
        ' 
        ' cmbSelectDepartment
        ' 
        cmbSelectDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectDepartment.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        cmbSelectDepartment.FormattingEnabled = True
        cmbSelectDepartment.Location = New Point(40, 105)
        cmbSelectDepartment.Name = "cmbSelectDepartment"
        cmbSelectDepartment.Size = New Size(400, 29)
        cmbSelectDepartment.TabIndex = 2
        ' 
        ' btnLoadDepartmentData
        ' 
        btnLoadDepartmentData.BackColor = Color.FromArgb(0, 122, 204)
        btnLoadDepartmentData.FlatStyle = FlatStyle.Flat
        btnLoadDepartmentData.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnLoadDepartmentData.ForeColor = Color.White
        btnLoadDepartmentData.Location = New Point(460, 105)
        btnLoadDepartmentData.Name = "btnLoadDepartmentData"
        btnLoadDepartmentData.Size = New Size(140, 29)
        btnLoadDepartmentData.TabIndex = 3
        btnLoadDepartmentData.Text = "Load Data"
        btnLoadDepartmentData.UseVisualStyleBackColor = False
        ' 
        ' grpDepartmentInfo
        ' 
        grpDepartmentInfo.Controls.Add(lblUpdateDeptCode)
        grpDepartmentInfo.Controls.Add(txtUpdateDeptCode)
        grpDepartmentInfo.Controls.Add(lblUpdateDeptName)
        grpDepartmentInfo.Controls.Add(txtUpdateDeptName)
        grpDepartmentInfo.Controls.Add(lblUpdateDeptDescription)
        grpDepartmentInfo.Controls.Add(txtUpdateDeptDescription)
        grpDepartmentInfo.Controls.Add(lblUpdateDeptHeadInstructor)
        grpDepartmentInfo.Controls.Add(cmbUpdateDeptHeadInstructor)
        grpDepartmentInfo.Location = New Point(40, 150)
        grpDepartmentInfo.Name = "grpDepartmentInfo"
        grpDepartmentInfo.Padding = New Padding(15)
        grpDepartmentInfo.Size = New Size(900, 400)
        grpDepartmentInfo.TabIndex = 4
        grpDepartmentInfo.TabStop = False
        grpDepartmentInfo.Text = "Department Information"
        grpDepartmentInfo.Visible = False
        ' 
        ' lblUpdateDeptCode
        ' 
        lblUpdateDeptCode.AutoSize = True
        lblUpdateDeptCode.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateDeptCode.Location = New Point(50, 30)
        lblUpdateDeptCode.Name = "lblUpdateDeptCode"
        lblUpdateDeptCode.Size = New Size(130, 19)
        lblUpdateDeptCode.TabIndex = 1
        lblUpdateDeptCode.Text = "Department Code *"
        ' 
        ' txtUpdateDeptCode
        ' 
        txtUpdateDeptCode.CharacterCasing = CharacterCasing.Upper
        txtUpdateDeptCode.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUpdateDeptCode.Location = New Point(50, 52)
        txtUpdateDeptCode.Name = "txtUpdateDeptCode"
        txtUpdateDeptCode.Size = New Size(400, 26)
        txtUpdateDeptCode.TabIndex = 2
        ' 
        ' lblUpdateDeptName
        ' 
        lblUpdateDeptName.AutoSize = True
        lblUpdateDeptName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateDeptName.Location = New Point(50, 100)
        lblUpdateDeptName.Name = "lblUpdateDeptName"
        lblUpdateDeptName.Size = New Size(133, 19)
        lblUpdateDeptName.TabIndex = 3
        lblUpdateDeptName.Text = "Department Name *"
        ' 
        ' txtUpdateDeptName
        ' 
        txtUpdateDeptName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUpdateDeptName.Location = New Point(50, 122)
        txtUpdateDeptName.Name = "txtUpdateDeptName"
        txtUpdateDeptName.Size = New Size(790, 26)
        txtUpdateDeptName.TabIndex = 4
        ' 
        ' lblUpdateDeptDescription
        ' 
        lblUpdateDeptDescription.AutoSize = True
        lblUpdateDeptDescription.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateDeptDescription.Location = New Point(50, 170)
        lblUpdateDeptDescription.Name = "lblUpdateDeptDescription"
        lblUpdateDeptDescription.Size = New Size(144, 19)
        lblUpdateDeptDescription.TabIndex = 5
        lblUpdateDeptDescription.Text = "Description (Optional)"
        ' 
        ' txtUpdateDeptDescription
        ' 
        txtUpdateDeptDescription.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUpdateDeptDescription.Location = New Point(50, 192)
        txtUpdateDeptDescription.Multiline = True
        txtUpdateDeptDescription.Name = "txtUpdateDeptDescription"
        txtUpdateDeptDescription.Size = New Size(790, 80)
        txtUpdateDeptDescription.TabIndex = 6
        ' 
        ' lblUpdateDeptHeadInstructor
        ' 
        lblUpdateDeptHeadInstructor.AutoSize = True
        lblUpdateDeptHeadInstructor.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateDeptHeadInstructor.Location = New Point(50, 295)
        lblUpdateDeptHeadInstructor.Name = "lblUpdateDeptHeadInstructor"
        lblUpdateDeptHeadInstructor.Size = New Size(170, 19)
        lblUpdateDeptHeadInstructor.TabIndex = 7
        lblUpdateDeptHeadInstructor.Text = "Head Instructor (Optional)"
        ' 
        ' cmbUpdateDeptHeadInstructor
        ' 
        cmbUpdateDeptHeadInstructor.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateDeptHeadInstructor.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        cmbUpdateDeptHeadInstructor.FormattingEnabled = True
        cmbUpdateDeptHeadInstructor.Location = New Point(50, 317)
        cmbUpdateDeptHeadInstructor.Name = "cmbUpdateDeptHeadInstructor"
        cmbUpdateDeptHeadInstructor.Size = New Size(790, 27)
        cmbUpdateDeptHeadInstructor.TabIndex = 8
        ' 
        ' btnUpdateDepartment
        ' 
        btnUpdateDepartment.BackColor = Color.FromArgb(0, 122, 204)
        btnUpdateDepartment.FlatStyle = FlatStyle.Flat
        btnUpdateDepartment.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnUpdateDepartment.ForeColor = Color.White
        btnUpdateDepartment.Location = New Point(40, 570)
        btnUpdateDepartment.Name = "btnUpdateDepartment"
        btnUpdateDepartment.Size = New Size(200, 45)
        btnUpdateDepartment.TabIndex = 5
        btnUpdateDepartment.Text = "Update Department"
        btnUpdateDepartment.UseVisualStyleBackColor = False
        btnUpdateDepartment.Visible = False
        ' 
        ' btnDeleteDepartment
        ' 
        btnDeleteDepartment.BackColor = Color.FromArgb(255, 71, 71)
        btnDeleteDepartment.FlatStyle = FlatStyle.Flat
        btnDeleteDepartment.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnDeleteDepartment.ForeColor = Color.White
        btnDeleteDepartment.Location = New Point(260, 570)
        btnDeleteDepartment.Name = "btnDeleteDepartment"
        btnDeleteDepartment.Size = New Size(200, 45)
        btnDeleteDepartment.TabIndex = 6
        btnDeleteDepartment.Text = "Delete Department"
        btnDeleteDepartment.UseVisualStyleBackColor = False
        btnDeleteDepartment.Visible = False
        ' 
        ' pnlDashboard
        ' 
        pnlDashboard.BackColor = Color.White
        pnlDashboard.Controls.Add(lblDashboardTitle)
        pnlDashboard.Controls.Add(lblWelcome)
        pnlDashboard.Controls.Add(pnlStats)
        pnlDashboard.Dock = DockStyle.Fill
        pnlDashboard.Location = New Point(0, 0)
        pnlDashboard.Name = "pnlDashboard"
        pnlDashboard.Padding = New Padding(20)
        pnlDashboard.Size = New Size(973, 800)
        pnlDashboard.TabIndex = 0
        ' 
        ' lblDashboardTitle
        ' 
        lblDashboardTitle.AutoSize = True
        lblDashboardTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblDashboardTitle.ForeColor = Color.Black
        lblDashboardTitle.Location = New Point(20, 15)
        lblDashboardTitle.Name = "lblDashboardTitle"
        lblDashboardTitle.Size = New Size(166, 36)
        lblDashboardTitle.TabIndex = 0
        lblDashboardTitle.Text = "Dashboard"
        ' 
        ' lblWelcome
        ' 
        lblWelcome.AutoSize = True
        lblWelcome.Font = New Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblWelcome.Location = New Point(20, 70)
        lblWelcome.Name = "lblWelcome"
        lblWelcome.Size = New Size(224, 25)
        lblWelcome.TabIndex = 1
        lblWelcome.Text = "Welcome, Administrator"
        ' 
        ' pnlStats
        ' 
        pnlStats.Controls.Add(lblTotalUsers)
        pnlStats.Controls.Add(lblTotalInstructors)
        pnlStats.Controls.Add(lblTotalStudents)
        pnlStats.Location = New Point(20, 120)
        pnlStats.Name = "pnlStats"
        pnlStats.Size = New Size(900, 150)
        pnlStats.TabIndex = 2
        ' 
        ' lblTotalUsers
        ' 
        lblTotalUsers.BackColor = SystemColors.MenuHighlight
        lblTotalUsers.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblTotalUsers.ForeColor = Color.White
        lblTotalUsers.Location = New Point(3, 10)
        lblTotalUsers.Name = "lblTotalUsers"
        lblTotalUsers.Size = New Size(280, 130)
        lblTotalUsers.TabIndex = 0
        lblTotalUsers.Text = "Total Users" + vbCrLf + "0"
        lblTotalUsers.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotalInstructors
        ' 
        lblTotalInstructors.BackColor = Color.RoyalBlue
        lblTotalInstructors.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblTotalInstructors.ForeColor = Color.White
        lblTotalInstructors.Location = New Point(300, 10)
        lblTotalInstructors.Name = "lblTotalInstructors"
        lblTotalInstructors.Size = New Size(280, 130)
        lblTotalInstructors.TabIndex = 1
        lblTotalInstructors.Text = "Total Instructors" + vbCrLf + "0"
        lblTotalInstructors.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblTotalStudents
        ' 
        lblTotalStudents.BackColor = Color.MediumBlue
        lblTotalStudents.Font = New Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblTotalStudents.ForeColor = Color.White
        lblTotalStudents.Location = New Point(598, 11)
        lblTotalStudents.Name = "lblTotalStudents"
        lblTotalStudents.Size = New Size(280, 130)
        lblTotalStudents.TabIndex = 2
        lblTotalStudents.Text = "Total Students" + vbCrLf + "0"
        lblTotalStudents.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlAddUser
        ' 
        pnlAddUser.AutoScroll = True
        pnlAddUser.BackColor = Color.White
        pnlAddUser.Controls.Add(lblAddUserTitle)
        pnlAddUser.Controls.Add(lblFirstName)
        pnlAddUser.Controls.Add(txtFirstName)
        pnlAddUser.Controls.Add(lblMiddleName)
        pnlAddUser.Controls.Add(txtMiddleName)
        pnlAddUser.Controls.Add(lblLastName)
        pnlAddUser.Controls.Add(txtLastName)
        pnlAddUser.Controls.Add(lblUsername)
        pnlAddUser.Controls.Add(txtUsername)
        pnlAddUser.Controls.Add(lblPassword)
        pnlAddUser.Controls.Add(txtPassword)
        pnlAddUser.Controls.Add(lblRole)
        pnlAddUser.Controls.Add(cmbRole)
        pnlAddUser.Controls.Add(pnlStudentFields)
        pnlAddUser.Controls.Add(pnlInstructorFields)
        pnlAddUser.Controls.Add(btnSubmitUser)
        pnlAddUser.Dock = DockStyle.Fill
        pnlAddUser.Location = New Point(0, 0)
        pnlAddUser.Name = "pnlAddUser"
        pnlAddUser.Padding = New Padding(30, 20, 30, 20)
        pnlAddUser.Size = New Size(973, 800)
        pnlAddUser.TabIndex = 1
        pnlAddUser.Visible = False
        ' 
        ' lblAddUserTitle
        ' 
        lblAddUserTitle.AutoSize = True
        lblAddUserTitle.Font = New Font("Times New Roman", 20F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblAddUserTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblAddUserTitle.Location = New Point(30, 20)
        lblAddUserTitle.Name = "lblAddUserTitle"
        lblAddUserTitle.Size = New Size(183, 31)
        lblAddUserTitle.TabIndex = 0
        lblAddUserTitle.Text = "Add New User"
        ' 
        ' lblFirstName
        ' 
        lblFirstName.AutoSize = True
        lblFirstName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblFirstName.Location = New Point(50, 75)
        lblFirstName.Name = "lblFirstName"
        lblFirstName.Size = New Size(89, 19)
        lblFirstName.TabIndex = 1
        lblFirstName.Text = "First Name *"
        ' 
        ' txtFirstName
        ' 
        txtFirstName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtFirstName.Location = New Point(50, 97)
        txtFirstName.Name = "txtFirstName"
        txtFirstName.Size = New Size(250, 26)
        txtFirstName.TabIndex = 2
        ' 
        ' lblMiddleName
        ' 
        lblMiddleName.AutoSize = True
        lblMiddleName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblMiddleName.Location = New Point(320, 75)
        lblMiddleName.Name = "lblMiddleName"
        lblMiddleName.Size = New Size(159, 19)
        lblMiddleName.TabIndex = 3
        lblMiddleName.Text = "Middle Name (Optional)"
        ' 
        ' txtMiddleName
        ' 
        txtMiddleName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtMiddleName.Location = New Point(320, 97)
        txtMiddleName.Name = "txtMiddleName"
        txtMiddleName.Size = New Size(250, 26)
        txtMiddleName.TabIndex = 4
        ' 
        ' lblLastName
        ' 
        lblLastName.AutoSize = True
        lblLastName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblLastName.Location = New Point(590, 75)
        lblLastName.Name = "lblLastName"
        lblLastName.Size = New Size(88, 19)
        lblLastName.TabIndex = 5
        lblLastName.Text = "Last Name *"
        ' 
        ' txtLastName
        ' 
        txtLastName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtLastName.Location = New Point(590, 97)
        txtLastName.Name = "txtLastName"
        txtLastName.Size = New Size(250, 26)
        txtLastName.TabIndex = 6
        ' 
        ' lblUsername
        ' 
        lblUsername.AutoSize = True
        lblUsername.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUsername.Location = New Point(50, 145)
        lblUsername.Name = "lblUsername"
        lblUsername.Size = New Size(82, 19)
        lblUsername.TabIndex = 7
        lblUsername.Text = "Username *"
        ' 
        ' txtUsername
        ' 
        txtUsername.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUsername.Location = New Point(50, 167)
        txtUsername.Name = "txtUsername"
        txtUsername.Size = New Size(790, 26)
        txtUsername.TabIndex = 8
        ' 
        ' lblPassword
        ' 
        lblPassword.AutoSize = True
        lblPassword.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblPassword.Location = New Point(50, 210)
        lblPassword.Name = "lblPassword"
        lblPassword.Size = New Size(81, 19)
        lblPassword.TabIndex = 9
        lblPassword.Text = "Password *"
        ' 
        ' txtPassword
        ' 
        txtPassword.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtPassword.Location = New Point(50, 232)
        txtPassword.Name = "txtPassword"
        txtPassword.PasswordChar = "*"c
        txtPassword.Size = New Size(790, 26)
        txtPassword.TabIndex = 10
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblRole.Location = New Point(50, 275)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(49, 19)
        lblRole.TabIndex = 11
        lblRole.Text = "Role *"
        ' 
        ' cmbRole
        ' 
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRole.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        cmbRole.FormattingEnabled = True
        cmbRole.Location = New Point(50, 297)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(790, 27)
        cmbRole.TabIndex = 12
        ' 
        ' pnlStudentFields
        ' 
        pnlStudentFields.BackColor = Color.FromArgb(240, 248, 255)
        pnlStudentFields.BorderStyle = BorderStyle.FixedSingle
        pnlStudentFields.Controls.Add(lblStudentFieldsTitle)
        pnlStudentFields.Controls.Add(lblDateOfBirth)
        pnlStudentFields.Controls.Add(dtpDateOfBirth)
        pnlStudentFields.Controls.Add(lblGender)
        pnlStudentFields.Controls.Add(cmbGender)
        pnlStudentFields.Controls.Add(lblYearLevel)
        pnlStudentFields.Controls.Add(cmbYearLevel)
        pnlStudentFields.Controls.Add(lblDepartment)
        pnlStudentFields.Controls.Add(cmbDepartment)
        pnlStudentFields.Controls.Add(lblStudentEmail)
        pnlStudentFields.Controls.Add(txtStudentEmail)
        pnlStudentFields.Controls.Add(lblEnrollmentStatus)
        pnlStudentFields.Controls.Add(cmbEnrollmentStatus)
        pnlStudentFields.Location = New Point(50, 345)
        pnlStudentFields.Name = "pnlStudentFields"
        pnlStudentFields.Size = New Size(790, 380)
        pnlStudentFields.TabIndex = 13
        pnlStudentFields.Visible = False
        ' 
        ' lblStudentFieldsTitle
        ' 
        lblStudentFieldsTitle.BackColor = Color.FromArgb(0, 122, 204)
        lblStudentFieldsTitle.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblStudentFieldsTitle.ForeColor = Color.White
        lblStudentFieldsTitle.Location = New Point(-1, -1)
        lblStudentFieldsTitle.Name = "lblStudentFieldsTitle"
        lblStudentFieldsTitle.Padding = New Padding(15, 8, 15, 8)
        lblStudentFieldsTitle.Size = New Size(790, 40)
        lblStudentFieldsTitle.TabIndex = 0
        lblStudentFieldsTitle.Text = "STUDENT INFORMATION"
        lblStudentFieldsTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblDateOfBirth
        ' 
        lblDateOfBirth.AutoSize = True
        lblDateOfBirth.Font = New Font("Times New Roman", 12F)
        lblDateOfBirth.Location = New Point(20, 60)
        lblDateOfBirth.Name = "lblDateOfBirth"
        lblDateOfBirth.Size = New Size(153, 19)
        lblDateOfBirth.TabIndex = 1
        lblDateOfBirth.Text = "Date of Birth (Optional)"
        ' 
        ' dtpDateOfBirth
        ' 
        dtpDateOfBirth.Font = New Font("Times New Roman", 12F)
        dtpDateOfBirth.Format = DateTimePickerFormat.Short
        dtpDateOfBirth.Location = New Point(20, 82)
        dtpDateOfBirth.Name = "dtpDateOfBirth"
        dtpDateOfBirth.Size = New Size(350, 26)
        dtpDateOfBirth.TabIndex = 2
        dtpDateOfBirth.Value = New Date(2007, 11, 29, 23, 4, 48, 510)
        ' 
        ' lblGender
        ' 
        lblGender.AutoSize = True
        lblGender.Font = New Font("Times New Roman", 12F)
        lblGender.Location = New Point(400, 60)
        lblGender.Name = "lblGender"
        lblGender.Size = New Size(120, 19)
        lblGender.TabIndex = 3
        lblGender.Text = "Gender (Optional)"
        ' 
        ' cmbGender
        ' 
        cmbGender.DropDownStyle = ComboBoxStyle.DropDownList
        cmbGender.Font = New Font("Times New Roman", 12F)
        cmbGender.FormattingEnabled = True
        cmbGender.Items.AddRange(New Object() {"Male", "Female", "Other", "Prefer not to say"})
        cmbGender.Location = New Point(400, 82)
        cmbGender.Name = "cmbGender"
        cmbGender.Size = New Size(350, 27)
        cmbGender.TabIndex = 4
        ' 
        ' lblYearLevel
        ' 
        lblYearLevel.AutoSize = True
        lblYearLevel.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblYearLevel.ForeColor = Color.FromArgb(192, 0, 0)
        lblYearLevel.Location = New Point(20, 130)
        lblYearLevel.Name = "lblYearLevel"
        lblYearLevel.Size = New Size(93, 19)
        lblYearLevel.TabIndex = 5
        lblYearLevel.Text = "Year Level *"
        ' 
        ' cmbYearLevel
        ' 
        cmbYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cmbYearLevel.Font = New Font("Times New Roman", 12F)
        cmbYearLevel.FormattingEnabled = True
        cmbYearLevel.Location = New Point(20, 152)
        cmbYearLevel.Name = "cmbYearLevel"
        cmbYearLevel.Size = New Size(350, 27)
        cmbYearLevel.TabIndex = 6
        ' 
        ' lblDepartment
        ' 
        lblDepartment.AutoSize = True
        lblDepartment.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblDepartment.ForeColor = Color.FromArgb(192, 0, 0)
        lblDepartment.Location = New Point(400, 130)
        lblDepartment.Name = "lblDepartment"
        lblDepartment.Size = New Size(101, 19)
        lblDepartment.TabIndex = 7
        lblDepartment.Text = "Department *"
        ' 
        ' cmbDepartment
        ' 
        cmbDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbDepartment.Font = New Font("Times New Roman", 12F)
        cmbDepartment.FormattingEnabled = True
        cmbDepartment.Location = New Point(400, 152)
        cmbDepartment.Name = "cmbDepartment"
        cmbDepartment.Size = New Size(350, 27)
        cmbDepartment.TabIndex = 8
        ' 
        ' lblStudentEmail
        ' 
        lblStudentEmail.AutoSize = True
        lblStudentEmail.Font = New Font("Times New Roman", 12F)
        lblStudentEmail.Location = New Point(20, 200)
        lblStudentEmail.Name = "lblStudentEmail"
        lblStudentEmail.Size = New Size(108, 19)
        lblStudentEmail.TabIndex = 9
        lblStudentEmail.Text = "Email (Optional)"
        ' 
        ' txtStudentEmail
        ' 
        txtStudentEmail.Font = New Font("Times New Roman", 12F)
        txtStudentEmail.Location = New Point(20, 222)
        txtStudentEmail.Name = "txtStudentEmail"
        txtStudentEmail.Size = New Size(730, 26)
        txtStudentEmail.TabIndex = 10
        ' 
        ' lblEnrollmentStatus
        ' 
        lblEnrollmentStatus.AutoSize = True
        lblEnrollmentStatus.Font = New Font("Times New Roman", 12F)
        lblEnrollmentStatus.Location = New Point(20, 270)
        lblEnrollmentStatus.Name = "lblEnrollmentStatus"
        lblEnrollmentStatus.Size = New Size(180, 19)
        lblEnrollmentStatus.TabIndex = 11
        lblEnrollmentStatus.Text = "Enrollment Status (Optional)"
        ' 
        ' cmbEnrollmentStatus
        ' 
        cmbEnrollmentStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbEnrollmentStatus.Font = New Font("Times New Roman", 12F)
        cmbEnrollmentStatus.FormattingEnabled = True
        cmbEnrollmentStatus.Location = New Point(20, 292)
        cmbEnrollmentStatus.Name = "cmbEnrollmentStatus"
        cmbEnrollmentStatus.Size = New Size(730, 27)
        cmbEnrollmentStatus.TabIndex = 12
        ' 
        ' pnlInstructorFields
        ' 
        pnlInstructorFields.BackColor = Color.FromArgb(240, 255, 240)
        pnlInstructorFields.BorderStyle = BorderStyle.FixedSingle
        pnlInstructorFields.Controls.Add(lblInstructorFieldsTitle)
        pnlInstructorFields.Controls.Add(lblInstructorEmail)
        pnlInstructorFields.Controls.Add(txtInstructorEmail)
        pnlInstructorFields.Controls.Add(lblInstructorDepartment)
        pnlInstructorFields.Controls.Add(cmbInstructorDepartment)
        pnlInstructorFields.Controls.Add(lblSpecialization)
        pnlInstructorFields.Controls.Add(txtSpecialization)
        pnlInstructorFields.Controls.Add(lblHireDate)
        pnlInstructorFields.Controls.Add(dtpHireDate)
        pnlInstructorFields.Location = New Point(50, 345)
        pnlInstructorFields.Name = "pnlInstructorFields"
        pnlInstructorFields.Size = New Size(790, 300)
        pnlInstructorFields.TabIndex = 14
        pnlInstructorFields.Visible = False
        ' 
        ' lblInstructorFieldsTitle
        ' 
        lblInstructorFieldsTitle.BackColor = Color.FromArgb(46, 204, 113)
        lblInstructorFieldsTitle.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblInstructorFieldsTitle.ForeColor = Color.White
        lblInstructorFieldsTitle.Location = New Point(-1, -1)
        lblInstructorFieldsTitle.Name = "lblInstructorFieldsTitle"
        lblInstructorFieldsTitle.Padding = New Padding(15, 8, 15, 8)
        lblInstructorFieldsTitle.Size = New Size(790, 40)
        lblInstructorFieldsTitle.TabIndex = 0
        lblInstructorFieldsTitle.Text = "INSTRUCTOR INFORMATION"
        lblInstructorFieldsTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblInstructorEmail
        ' 
        lblInstructorEmail.AutoSize = True
        lblInstructorEmail.Font = New Font("Times New Roman", 12F)
        lblInstructorEmail.Location = New Point(20, 60)
        lblInstructorEmail.Name = "lblInstructorEmail"
        lblInstructorEmail.Size = New Size(108, 19)
        lblInstructorEmail.TabIndex = 1
        lblInstructorEmail.Text = "Email (Optional)"
        ' 
        ' txtInstructorEmail
        ' 
        txtInstructorEmail.Font = New Font("Times New Roman", 12F)
        txtInstructorEmail.Location = New Point(20, 82)
        txtInstructorEmail.Name = "txtInstructorEmail"
        txtInstructorEmail.Size = New Size(730, 26)
        txtInstructorEmail.TabIndex = 2
        ' 
        ' lblInstructorDepartment
        ' 
        lblInstructorDepartment.AutoSize = True
        lblInstructorDepartment.Font = New Font("Times New Roman", 12F)
        lblInstructorDepartment.Location = New Point(20, 130)
        lblInstructorDepartment.Name = "lblInstructorDepartment"
        lblInstructorDepartment.Size = New Size(146, 19)
        lblInstructorDepartment.TabIndex = 3
        lblInstructorDepartment.Text = "Department (Optional)"
        ' 
        ' cmbInstructorDepartment
        ' 
        cmbInstructorDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbInstructorDepartment.Font = New Font("Times New Roman", 12F)
        cmbInstructorDepartment.FormattingEnabled = True
        cmbInstructorDepartment.Location = New Point(20, 152)
        cmbInstructorDepartment.Name = "cmbInstructorDepartment"
        cmbInstructorDepartment.Size = New Size(730, 27)
        cmbInstructorDepartment.TabIndex = 4
        ' 
        ' lblSpecialization
        ' 
        lblSpecialization.AutoSize = True
        lblSpecialization.Font = New Font("Times New Roman", 12F)
        lblSpecialization.Location = New Point(20, 200)
        lblSpecialization.Name = "lblSpecialization"
        lblSpecialization.Size = New Size(157, 19)
        lblSpecialization.TabIndex = 5
        lblSpecialization.Text = "Specialization (Optional)"
        ' 
        ' txtSpecialization
        ' 
        txtSpecialization.Font = New Font("Times New Roman", 12F)
        txtSpecialization.Location = New Point(20, 222)
        txtSpecialization.Name = "txtSpecialization"
        txtSpecialization.Size = New Size(350, 26)
        txtSpecialization.TabIndex = 6
        ' 
        ' lblHireDate
        ' 
        lblHireDate.AutoSize = True
        lblHireDate.Font = New Font("Times New Roman", 12F)
        lblHireDate.Location = New Point(400, 200)
        lblHireDate.Name = "lblHireDate"
        lblHireDate.Size = New Size(134, 19)
        lblHireDate.TabIndex = 7
        lblHireDate.Text = "Hire Date (Optional)"
        ' 
        ' dtpHireDate
        ' 
        dtpHireDate.Font = New Font("Times New Roman", 12F)
        dtpHireDate.Format = DateTimePickerFormat.Short
        dtpHireDate.Location = New Point(400, 222)
        dtpHireDate.Name = "dtpHireDate"
        dtpHireDate.Size = New Size(350, 26)
        dtpHireDate.TabIndex = 8
        ' 
        ' btnSubmitUser
        ' 
        btnSubmitUser.BackColor = Color.FromArgb(0, 122, 204)
        btnSubmitUser.FlatStyle = FlatStyle.Flat
        btnSubmitUser.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnSubmitUser.ForeColor = Color.White
        btnSubmitUser.Location = New Point(50, 745)
        btnSubmitUser.Name = "btnSubmitUser"
        btnSubmitUser.Size = New Size(200, 45)
        btnSubmitUser.TabIndex = 15
        btnSubmitUser.Text = "+ Add User"
        btnSubmitUser.UseVisualStyleBackColor = False
        ' 
        ' pnlUserDetails
        ' 
        pnlUserDetails.AutoScroll = True
        pnlUserDetails.BackColor = Color.White
        pnlUserDetails.Controls.Add(lblUserDetailsTitle)
        pnlUserDetails.Controls.Add(lblUsers)
        pnlUserDetails.Controls.Add(dgvUsers)
        pnlUserDetails.Controls.Add(lblInstructors)
        pnlUserDetails.Controls.Add(dgvInstructors)
        pnlUserDetails.Controls.Add(lblStudents)
        pnlUserDetails.Controls.Add(dgvStudents)
        pnlUserDetails.Dock = DockStyle.Fill
        pnlUserDetails.Location = New Point(0, 0)
        pnlUserDetails.Name = "pnlUserDetails"
        pnlUserDetails.Padding = New Padding(20)
        pnlUserDetails.Size = New Size(973, 800)
        pnlUserDetails.TabIndex = 2
        pnlUserDetails.Visible = False
        ' 
        ' lblUserDetailsTitle
        ' 
        lblUserDetailsTitle.AutoSize = True
        lblUserDetailsTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblUserDetailsTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblUserDetailsTitle.Location = New Point(20, 20)
        lblUserDetailsTitle.Name = "lblUserDetailsTitle"
        lblUserDetailsTitle.Size = New Size(266, 36)
        lblUserDetailsTitle.TabIndex = 0
        lblUserDetailsTitle.Text = "User Management"
        ' 
        ' lblUsers
        ' 
        lblUsers.AutoSize = True
        lblUsers.Font = New Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblUsers.Location = New Point(40, 80)
        lblUsers.Name = "lblUsers"
        lblUsers.Size = New Size(84, 22)
        lblUsers.TabIndex = 7
        lblUsers.Text = "All Users"
        ' 
        ' dgvUsers
        ' 
        dgvUsers.AllowUserToAddRows = False
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsers.BackgroundColor = SystemColors.Control
        dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvUsers.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        dgvUsers.Location = New Point(40, 110)
        dgvUsers.Name = "dgvUsers"
        dgvUsers.ReadOnly = True
        dgvUsers.Size = New Size(1100, 150)
        dgvUsers.TabIndex = 8
        ' 
        ' lblInstructors
        ' 
        lblInstructors.AutoSize = True
        lblInstructors.Font = New Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblInstructors.Location = New Point(40, 280)
        lblInstructors.Name = "lblInstructors"
        lblInstructors.Size = New Size(100, 22)
        lblInstructors.TabIndex = 9
        lblInstructors.Text = "Instructors"
        ' 
        ' dgvInstructors
        ' 
        dgvInstructors.AllowUserToAddRows = False
        dgvInstructors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvInstructors.BackgroundColor = SystemColors.Control
        dgvInstructors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvInstructors.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        dgvInstructors.Location = New Point(40, 310)
        dgvInstructors.Name = "dgvInstructors"
        dgvInstructors.ReadOnly = True
        dgvInstructors.Size = New Size(1100, 200)
        dgvInstructors.TabIndex = 10
        ' 
        ' lblStudents
        ' 
        lblStudents.AutoSize = True
        lblStudents.Font = New Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblStudents.Location = New Point(40, 530)
        lblStudents.Name = "lblStudents"
        lblStudents.Size = New Size(80, 22)
        lblStudents.TabIndex = 11
        lblStudents.Text = "Students"
        ' 
        ' dgvStudents
        ' 
        dgvStudents.AllowUserToAddRows = False
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvStudents.BackgroundColor = SystemColors.Control
        dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvStudents.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        dgvStudents.Location = New Point(40, 560)
        dgvStudents.Name = "dgvStudents"
        dgvStudents.ReadOnly = True
        dgvStudents.Size = New Size(1100, 200)
        dgvStudents.TabIndex = 12
        ' 
        ' pnlResetPassword
        ' 
        pnlResetPassword.BackColor = Color.White
        pnlResetPassword.Controls.Add(lblResetPasswordTitle)
        pnlResetPassword.Controls.Add(lblSelectUserReset)
        pnlResetPassword.Controls.Add(cmbSelectUserReset)
        pnlResetPassword.Controls.Add(lblNewPassword)
        pnlResetPassword.Controls.Add(txtNewPassword)
        pnlResetPassword.Controls.Add(btnGeneratePassword)
        pnlResetPassword.Controls.Add(btnResetPasswordSubmit)
        pnlResetPassword.Dock = DockStyle.Fill
        pnlResetPassword.Location = New Point(0, 0)
        pnlResetPassword.Name = "pnlResetPassword"
        pnlResetPassword.Padding = New Padding(20)
        pnlResetPassword.Size = New Size(973, 800)
        pnlResetPassword.TabIndex = 3
        pnlResetPassword.Visible = False
        ' 
        ' lblResetPasswordTitle
        ' 
        lblResetPasswordTitle.AutoSize = True
        lblResetPasswordTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblResetPasswordTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblResetPasswordTitle.Location = New Point(20, 20)
        lblResetPasswordTitle.Name = "lblResetPasswordTitle"
        lblResetPasswordTitle.Size = New Size(228, 36)
        lblResetPasswordTitle.TabIndex = 0
        lblResetPasswordTitle.Text = "Reset Password"
        ' 
        ' lblSelectUserReset
        ' 
        lblSelectUserReset.AutoSize = True
        lblSelectUserReset.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblSelectUserReset.Location = New Point(40, 90)
        lblSelectUserReset.Name = "lblSelectUserReset"
        lblSelectUserReset.Size = New Size(95, 21)
        lblSelectUserReset.TabIndex = 1
        lblSelectUserReset.Text = "Select User"
        ' 
        ' cmbSelectUserReset
        ' 
        cmbSelectUserReset.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectUserReset.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        cmbSelectUserReset.FormattingEnabled = True
        cmbSelectUserReset.Location = New Point(40, 115)
        cmbSelectUserReset.Name = "cmbSelectUserReset"
        cmbSelectUserReset.Size = New Size(400, 29)
        cmbSelectUserReset.TabIndex = 2
        ' 
        ' lblNewPassword
        ' 
        lblNewPassword.AutoSize = True
        lblNewPassword.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblNewPassword.Location = New Point(40, 160)
        lblNewPassword.Name = "lblNewPassword"
        lblNewPassword.Size = New Size(123, 21)
        lblNewPassword.TabIndex = 3
        lblNewPassword.Text = "New Password"
        ' 
        ' txtNewPassword
        ' 
        txtNewPassword.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtNewPassword.Location = New Point(40, 185)
        txtNewPassword.Name = "txtNewPassword"
        txtNewPassword.PasswordChar = "*"c
        txtNewPassword.Size = New Size(400, 29)
        txtNewPassword.TabIndex = 4
        ' 
        ' btnGeneratePassword
        ' 
        btnGeneratePassword.BackColor = Color.FromArgb(255, 159, 64)
        btnGeneratePassword.FlatStyle = FlatStyle.Flat
        btnGeneratePassword.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnGeneratePassword.ForeColor = Color.White
        btnGeneratePassword.Location = New Point(40, 240)
        btnGeneratePassword.Name = "btnGeneratePassword"
        btnGeneratePassword.Size = New Size(200, 40)
        btnGeneratePassword.TabIndex = 5
        btnGeneratePassword.Text = "Generate Password"
        btnGeneratePassword.UseVisualStyleBackColor = False
        ' 
        ' btnResetPasswordSubmit
        ' 
        btnResetPasswordSubmit.BackColor = Color.FromArgb(0, 122, 204)
        btnResetPasswordSubmit.FlatStyle = FlatStyle.Flat
        btnResetPasswordSubmit.Font = New Font("Times New Roman", 14F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnResetPasswordSubmit.ForeColor = Color.White
        btnResetPasswordSubmit.Location = New Point(40, 300)
        btnResetPasswordSubmit.Name = "btnResetPasswordSubmit"
        btnResetPasswordSubmit.Size = New Size(200, 45)
        btnResetPasswordSubmit.TabIndex = 6
        btnResetPasswordSubmit.Text = "Reset Password"
        btnResetPasswordSubmit.UseVisualStyleBackColor = False
        ' 
        ' pnlUpdateDeleteUser
        ' 
        pnlUpdateDeleteUser.AutoScroll = True
        pnlUpdateDeleteUser.BackColor = Color.White
        pnlUpdateDeleteUser.Controls.Add(lblUpdateDeleteTitle)
        pnlUpdateDeleteUser.Controls.Add(lblSelectUserUpdate)
        pnlUpdateDeleteUser.Controls.Add(cmbSelectUserUpdate)
        pnlUpdateDeleteUser.Controls.Add(btnLoadUserData)
        pnlUpdateDeleteUser.Controls.Add(grpUserInfo)
        pnlUpdateDeleteUser.Controls.Add(btnUpdateUser)
        pnlUpdateDeleteUser.Controls.Add(btnDeleteUser)
        pnlUpdateDeleteUser.Dock = DockStyle.Fill
        pnlUpdateDeleteUser.Location = New Point(0, 0)
        pnlUpdateDeleteUser.Name = "pnlUpdateDeleteUser"
        pnlUpdateDeleteUser.Padding = New Padding(20)
        pnlUpdateDeleteUser.Size = New Size(973, 800)
        pnlUpdateDeleteUser.TabIndex = 4
        pnlUpdateDeleteUser.Visible = False
        ' 
        ' lblUpdateDeleteTitle
        ' 
        lblUpdateDeleteTitle.AutoSize = True
        lblUpdateDeleteTitle.Font = New Font("Times New Roman", 24F, FontStyle.Bold, GraphicsUnit.Point, 0)
        lblUpdateDeleteTitle.ForeColor = Color.FromArgb(0, 122, 204)
        lblUpdateDeleteTitle.Location = New Point(20, 20)
        lblUpdateDeleteTitle.Name = "lblUpdateDeleteTitle"
        lblUpdateDeleteTitle.Size = New Size(344, 36)
        lblUpdateDeleteTitle.TabIndex = 0
        lblUpdateDeleteTitle.Text = "Update/Delete User Info"
        ' 
        ' lblSelectUserUpdate
        ' 
        lblSelectUserUpdate.AutoSize = True
        lblSelectUserUpdate.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblSelectUserUpdate.Location = New Point(40, 80)
        lblSelectUserUpdate.Name = "lblSelectUserUpdate"
        lblSelectUserUpdate.Size = New Size(95, 21)
        lblSelectUserUpdate.TabIndex = 1
        lblSelectUserUpdate.Text = "Select User"
        ' 
        ' cmbSelectUserUpdate
        ' 
        cmbSelectUserUpdate.DropDownStyle = ComboBoxStyle.DropDownList
        cmbSelectUserUpdate.Font = New Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0)
        cmbSelectUserUpdate.FormattingEnabled = True
        cmbSelectUserUpdate.Location = New Point(40, 105)
        cmbSelectUserUpdate.Name = "cmbSelectUserUpdate"
        cmbSelectUserUpdate.Size = New Size(400, 29)
        cmbSelectUserUpdate.TabIndex = 2
        ' 
        ' btnLoadUserData
        ' 
        btnLoadUserData.BackColor = Color.FromArgb(0, 122, 204)
        btnLoadUserData.FlatStyle = FlatStyle.Flat
        btnLoadUserData.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnLoadUserData.ForeColor = Color.White
        btnLoadUserData.Location = New Point(460, 105)
        btnLoadUserData.Name = "btnLoadUserData"
        btnLoadUserData.Size = New Size(140, 29)
        btnLoadUserData.TabIndex = 3
        btnLoadUserData.Text = "Load Data"
        btnLoadUserData.UseVisualStyleBackColor = False
        ' 
        ' grpUserInfo
        ' 
        grpUserInfo.Controls.Add(lblUpdateFirstName)
        grpUserInfo.Controls.Add(txtUpdateFirstName)
        grpUserInfo.Controls.Add(lblUpdateMiddleName)
        grpUserInfo.Controls.Add(txtUpdateMiddleName)
        grpUserInfo.Controls.Add(lblUpdateLastName)
        grpUserInfo.Controls.Add(txtUpdateLastName)
        grpUserInfo.Controls.Add(lblUpdateUsername)
        grpUserInfo.Controls.Add(txtUpdateUsername)
        grpUserInfo.Controls.Add(lblUpdateRole)
        grpUserInfo.Controls.Add(lblUpdateRoleDisplay)
        grpUserInfo.Controls.Add(cmbUpdateRole)
        grpUserInfo.Controls.Add(pnlUpdateStudentFields)
        grpUserInfo.Controls.Add(pnlUpdateInstructorFields)
        grpUserInfo.Location = New Point(40, 150)
        grpUserInfo.Name = "grpUserInfo"
        grpUserInfo.Padding = New Padding(15)
        grpUserInfo.Size = New Size(900, 620)
        grpUserInfo.TabIndex = 4
        grpUserInfo.TabStop = False
        grpUserInfo.Text = "User Information"
        grpUserInfo.Visible = False
        ' 
        ' lblUpdateFirstName
        ' 
        lblUpdateFirstName.AutoSize = True
        lblUpdateFirstName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateFirstName.Location = New Point(50, 30)
        lblUpdateFirstName.Name = "lblUpdateFirstName"
        lblUpdateFirstName.Size = New Size(89, 19)
        lblUpdateFirstName.TabIndex = 1
        lblUpdateFirstName.Text = "First Name *"
        ' 
        ' txtUpdateFirstName
        ' 
        txtUpdateFirstName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUpdateFirstName.Location = New Point(50, 52)
        txtUpdateFirstName.Name = "txtUpdateFirstName"
        txtUpdateFirstName.Size = New Size(250, 26)
        txtUpdateFirstName.TabIndex = 2
        ' 
        ' lblUpdateMiddleName
        ' 
        lblUpdateMiddleName.AutoSize = True
        lblUpdateMiddleName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateMiddleName.Location = New Point(320, 30)
        lblUpdateMiddleName.Name = "lblUpdateMiddleName"
        lblUpdateMiddleName.Size = New Size(159, 19)
        lblUpdateMiddleName.TabIndex = 3
        lblUpdateMiddleName.Text = "Middle Name (Optional)"
        ' 
        ' txtUpdateMiddleName
        ' 
        txtUpdateMiddleName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUpdateMiddleName.Location = New Point(320, 52)
        txtUpdateMiddleName.Name = "txtUpdateMiddleName"
        txtUpdateMiddleName.Size = New Size(250, 26)
        txtUpdateMiddleName.TabIndex = 4
        ' 
        ' lblUpdateLastName
        ' 
        lblUpdateLastName.AutoSize = True
        lblUpdateLastName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateLastName.Location = New Point(590, 30)
        lblUpdateLastName.Name = "lblUpdateLastName"
        lblUpdateLastName.Size = New Size(88, 19)
        lblUpdateLastName.TabIndex = 5
        lblUpdateLastName.Text = "Last Name *"
        ' 
        ' txtUpdateLastName
        ' 
        txtUpdateLastName.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUpdateLastName.Location = New Point(590, 52)
        txtUpdateLastName.Name = "txtUpdateLastName"
        txtUpdateLastName.Size = New Size(250, 26)
        txtUpdateLastName.TabIndex = 6
        ' 
        ' lblUpdateUsername
        ' 
        lblUpdateUsername.AutoSize = True
        lblUpdateUsername.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateUsername.Location = New Point(50, 90)
        lblUpdateUsername.Name = "lblUpdateUsername"
        lblUpdateUsername.Size = New Size(82, 19)
        lblUpdateUsername.TabIndex = 7
        lblUpdateUsername.Text = "Username *"
        ' 
        ' txtUpdateUsername
        ' 
        txtUpdateUsername.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        txtUpdateUsername.Location = New Point(50, 112)
        txtUpdateUsername.Name = "txtUpdateUsername"
        txtUpdateUsername.Size = New Size(790, 26)
        txtUpdateUsername.TabIndex = 8
        ' 
        ' lblUpdateRole
        ' 
        lblUpdateRole.AutoSize = True
        lblUpdateRole.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateRole.Location = New Point(50, 160)
        lblUpdateRole.Name = "lblUpdateRole"
        lblUpdateRole.Size = New Size(49, 19)
        lblUpdateRole.TabIndex = 11
        lblUpdateRole.Text = "Role *"
        ' 
        ' lblUpdateRoleDisplay
        ' 
        lblUpdateRoleDisplay.AutoSize = True
        lblUpdateRoleDisplay.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        lblUpdateRoleDisplay.Location = New Point(50, 190)
        lblUpdateRoleDisplay.Name = "lblUpdateRoleDisplay"
        lblUpdateRoleDisplay.Size = New Size(0, 19)
        lblUpdateRoleDisplay.TabIndex = 12
        lblUpdateRoleDisplay.Visible = False
        ' 
        ' cmbUpdateRole
        ' 
        cmbUpdateRole.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateRole.Font = New Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        cmbUpdateRole.FormattingEnabled = True
        cmbUpdateRole.Location = New Point(50, 182)
        cmbUpdateRole.Name = "cmbUpdateRole"
        cmbUpdateRole.Size = New Size(790, 27)
        cmbUpdateRole.TabIndex = 13
        ' 
        ' pnlUpdateStudentFields
        ' 
        pnlUpdateStudentFields.BackColor = Color.FromArgb(240, 248, 255)
        pnlUpdateStudentFields.BorderStyle = BorderStyle.FixedSingle
        pnlUpdateStudentFields.Controls.Add(lblUpdateStudentTitle)
        pnlUpdateStudentFields.Controls.Add(lblUpdateDateOfBirth)
        pnlUpdateStudentFields.Controls.Add(dtpUpdateDateOfBirth)
        pnlUpdateStudentFields.Controls.Add(lblUpdateGender)
        pnlUpdateStudentFields.Controls.Add(cmbUpdateGender)
        pnlUpdateStudentFields.Controls.Add(lblUpdateYearLevel)
        pnlUpdateStudentFields.Controls.Add(cmbUpdateYearLevel)
        pnlUpdateStudentFields.Controls.Add(lblUpdateDepartment)
        pnlUpdateStudentFields.Controls.Add(cmbUpdateDepartment)
        pnlUpdateStudentFields.Controls.Add(lblUpdateStudentEmail)
        pnlUpdateStudentFields.Controls.Add(txtUpdateStudentEmail)
        pnlUpdateStudentFields.Controls.Add(lblUpdateEnrollmentStatus)
        pnlUpdateStudentFields.Controls.Add(cmbUpdateEnrollmentStatus)
        pnlUpdateStudentFields.Location = New Point(50, 215)
        pnlUpdateStudentFields.Name = "pnlUpdateStudentFields"
        pnlUpdateStudentFields.Size = New Size(790, 380)
        pnlUpdateStudentFields.TabIndex = 13
        pnlUpdateStudentFields.Visible = False
        ' 
        ' lblUpdateStudentTitle
        ' 
        lblUpdateStudentTitle.BackColor = Color.FromArgb(0, 122, 204)
        lblUpdateStudentTitle.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateStudentTitle.ForeColor = Color.White
        lblUpdateStudentTitle.Location = New Point(-1, -1)
        lblUpdateStudentTitle.Name = "lblUpdateStudentTitle"
        lblUpdateStudentTitle.Padding = New Padding(15, 8, 15, 8)
        lblUpdateStudentTitle.Size = New Size(790, 40)
        lblUpdateStudentTitle.TabIndex = 0
        lblUpdateStudentTitle.Text = "UPDATE STUDENT INFORMATION"
        lblUpdateStudentTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblUpdateDateOfBirth
        ' 
        lblUpdateDateOfBirth.AutoSize = True
        lblUpdateDateOfBirth.Font = New Font("Times New Roman", 12F)
        lblUpdateDateOfBirth.Location = New Point(20, 60)
        lblUpdateDateOfBirth.Name = "lblUpdateDateOfBirth"
        lblUpdateDateOfBirth.Size = New Size(153, 19)
        lblUpdateDateOfBirth.TabIndex = 1
        lblUpdateDateOfBirth.Text = "Date of Birth (Optional)"
        ' 
        ' dtpUpdateDateOfBirth
        ' 
        dtpUpdateDateOfBirth.Font = New Font("Times New Roman", 12F)
        dtpUpdateDateOfBirth.Format = DateTimePickerFormat.Short
        dtpUpdateDateOfBirth.Location = New Point(20, 82)
        dtpUpdateDateOfBirth.Name = "dtpUpdateDateOfBirth"
        dtpUpdateDateOfBirth.Size = New Size(350, 26)
        dtpUpdateDateOfBirth.TabIndex = 2
        dtpUpdateDateOfBirth.Value = New Date(2007, 11, 29, 23, 4, 48, 510)
        ' 
        ' lblUpdateGender
        ' 
        lblUpdateGender.AutoSize = True
        lblUpdateGender.Font = New Font("Times New Roman", 12F)
        lblUpdateGender.Location = New Point(400, 60)
        lblUpdateGender.Name = "lblUpdateGender"
        lblUpdateGender.Size = New Size(120, 19)
        lblUpdateGender.TabIndex = 3
        lblUpdateGender.Text = "Gender (Optional)"
        ' 
        ' cmbUpdateGender
        ' 
        cmbUpdateGender.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateGender.Font = New Font("Times New Roman", 12F)
        cmbUpdateGender.FormattingEnabled = True
        cmbUpdateGender.Items.AddRange(New Object() {"Male", "Female", "Other", "Prefer not to say"})
        cmbUpdateGender.Location = New Point(400, 82)
        cmbUpdateGender.Name = "cmbUpdateGender"
        cmbUpdateGender.Size = New Size(350, 27)
        cmbUpdateGender.TabIndex = 4
        ' 
        ' lblUpdateYearLevel
        ' 
        lblUpdateYearLevel.AutoSize = True
        lblUpdateYearLevel.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateYearLevel.ForeColor = Color.FromArgb(192, 0, 0)
        lblUpdateYearLevel.Location = New Point(20, 130)
        lblUpdateYearLevel.Name = "lblUpdateYearLevel"
        lblUpdateYearLevel.Size = New Size(93, 19)
        lblUpdateYearLevel.TabIndex = 5
        lblUpdateYearLevel.Text = "Year Level *"
        ' 
        ' cmbUpdateYearLevel
        ' 
        cmbUpdateYearLevel.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateYearLevel.Font = New Font("Times New Roman", 12F)
        cmbUpdateYearLevel.FormattingEnabled = True
        cmbUpdateYearLevel.Location = New Point(20, 152)
        cmbUpdateYearLevel.Name = "cmbUpdateYearLevel"
        cmbUpdateYearLevel.Size = New Size(350, 27)
        cmbUpdateYearLevel.TabIndex = 6
        ' 
        ' lblUpdateDepartment
        ' 
        lblUpdateDepartment.AutoSize = True
        lblUpdateDepartment.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateDepartment.ForeColor = Color.FromArgb(192, 0, 0)
        lblUpdateDepartment.Location = New Point(400, 130)
        lblUpdateDepartment.Name = "lblUpdateDepartment"
        lblUpdateDepartment.Size = New Size(101, 19)
        lblUpdateDepartment.TabIndex = 7
        lblUpdateDepartment.Text = "Department *"
        ' 
        ' cmbUpdateDepartment
        ' 
        cmbUpdateDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateDepartment.Font = New Font("Times New Roman", 12F)
        cmbUpdateDepartment.FormattingEnabled = True
        cmbUpdateDepartment.Location = New Point(400, 152)
        cmbUpdateDepartment.Name = "cmbUpdateDepartment"
        cmbUpdateDepartment.Size = New Size(350, 27)
        cmbUpdateDepartment.TabIndex = 8
        ' 
        ' lblUpdateStudentEmail
        ' 
        lblUpdateStudentEmail.AutoSize = True
        lblUpdateStudentEmail.Font = New Font("Times New Roman", 12F)
        lblUpdateStudentEmail.Location = New Point(20, 200)
        lblUpdateStudentEmail.Name = "lblUpdateStudentEmail"
        lblUpdateStudentEmail.Size = New Size(108, 19)
        lblUpdateStudentEmail.TabIndex = 9
        lblUpdateStudentEmail.Text = "Email (Optional)"
        ' 
        ' txtUpdateStudentEmail
        ' 
        txtUpdateStudentEmail.Font = New Font("Times New Roman", 12F)
        txtUpdateStudentEmail.Location = New Point(20, 222)
        txtUpdateStudentEmail.Name = "txtUpdateStudentEmail"
        txtUpdateStudentEmail.Size = New Size(730, 26)
        txtUpdateStudentEmail.TabIndex = 10
        ' 
        ' lblUpdateEnrollmentStatus
        ' 
        lblUpdateEnrollmentStatus.AutoSize = True
        lblUpdateEnrollmentStatus.Font = New Font("Times New Roman", 12F)
        lblUpdateEnrollmentStatus.Location = New Point(20, 270)
        lblUpdateEnrollmentStatus.Name = "lblUpdateEnrollmentStatus"
        lblUpdateEnrollmentStatus.Size = New Size(180, 19)
        lblUpdateEnrollmentStatus.TabIndex = 11
        lblUpdateEnrollmentStatus.Text = "Enrollment Status (Optional)"
        ' 
        ' cmbUpdateEnrollmentStatus
        ' 
        cmbUpdateEnrollmentStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateEnrollmentStatus.Font = New Font("Times New Roman", 12F)
        cmbUpdateEnrollmentStatus.FormattingEnabled = True
        cmbUpdateEnrollmentStatus.Location = New Point(20, 292)
        cmbUpdateEnrollmentStatus.Name = "cmbUpdateEnrollmentStatus"
        cmbUpdateEnrollmentStatus.Size = New Size(730, 27)
        cmbUpdateEnrollmentStatus.TabIndex = 12
        ' 
        ' pnlUpdateInstructorFields
        ' 
        pnlUpdateInstructorFields.BackColor = Color.FromArgb(240, 255, 240)
        pnlUpdateInstructorFields.BorderStyle = BorderStyle.FixedSingle
        pnlUpdateInstructorFields.Controls.Add(lblUpdateInstructorTitle)
        pnlUpdateInstructorFields.Controls.Add(lblUpdateInstructorEmail)
        pnlUpdateInstructorFields.Controls.Add(txtUpdateInstructorEmail)
        pnlUpdateInstructorFields.Controls.Add(lblUpdateInstructorDepartment)
        pnlUpdateInstructorFields.Controls.Add(cmbUpdateInstructorDepartment)
        pnlUpdateInstructorFields.Controls.Add(lblUpdateSpecialization)
        pnlUpdateInstructorFields.Controls.Add(txtUpdateSpecialization)
        pnlUpdateInstructorFields.Controls.Add(lblUpdateHireDate)
        pnlUpdateInstructorFields.Controls.Add(dtpUpdateHireDate)
        pnlUpdateInstructorFields.Controls.Add(lblUpdateEmploymentStatus)
        pnlUpdateInstructorFields.Controls.Add(cmbUpdateEmploymentStatus)
        pnlUpdateInstructorFields.Location = New Point(50, 215)
        pnlUpdateInstructorFields.Name = "pnlUpdateInstructorFields"
        pnlUpdateInstructorFields.Size = New Size(790, 380)
        pnlUpdateInstructorFields.TabIndex = 14
        pnlUpdateInstructorFields.Visible = False
        ' 
        ' lblUpdateInstructorTitle
        ' 
        lblUpdateInstructorTitle.BackColor = Color.FromArgb(46, 204, 113)
        lblUpdateInstructorTitle.Font = New Font("Times New Roman", 12F, FontStyle.Bold)
        lblUpdateInstructorTitle.ForeColor = Color.White
        lblUpdateInstructorTitle.Location = New Point(-1, -1)
        lblUpdateInstructorTitle.Name = "lblUpdateInstructorTitle"
        lblUpdateInstructorTitle.Padding = New Padding(15, 8, 15, 8)
        lblUpdateInstructorTitle.Size = New Size(790, 40)
        lblUpdateInstructorTitle.TabIndex = 0
        lblUpdateInstructorTitle.Text = "UPDATE INSTRUCTOR INFORMATION"
        lblUpdateInstructorTitle.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblUpdateInstructorEmail
        ' 
        lblUpdateInstructorEmail.AutoSize = True
        lblUpdateInstructorEmail.Font = New Font("Times New Roman", 12F)
        lblUpdateInstructorEmail.Location = New Point(20, 60)
        lblUpdateInstructorEmail.Name = "lblUpdateInstructorEmail"
        lblUpdateInstructorEmail.Size = New Size(108, 19)
        lblUpdateInstructorEmail.TabIndex = 1
        lblUpdateInstructorEmail.Text = "Email (Optional)"
        ' 
        ' txtUpdateInstructorEmail
        ' 
        txtUpdateInstructorEmail.Font = New Font("Times New Roman", 12F)
        txtUpdateInstructorEmail.Location = New Point(20, 82)
        txtUpdateInstructorEmail.Name = "txtUpdateInstructorEmail"
        txtUpdateInstructorEmail.Size = New Size(730, 26)
        txtUpdateInstructorEmail.TabIndex = 2
        ' 
        ' lblUpdateInstructorDepartment
        ' 
        lblUpdateInstructorDepartment.AutoSize = True
        lblUpdateInstructorDepartment.Font = New Font("Times New Roman", 12F)
        lblUpdateInstructorDepartment.Location = New Point(20, 130)
        lblUpdateInstructorDepartment.Name = "lblUpdateInstructorDepartment"
        lblUpdateInstructorDepartment.Size = New Size(146, 19)
        lblUpdateInstructorDepartment.TabIndex = 3
        lblUpdateInstructorDepartment.Text = "Department (Optional)"
        ' 
        ' cmbUpdateInstructorDepartment
        ' 
        cmbUpdateInstructorDepartment.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateInstructorDepartment.Font = New Font("Times New Roman", 12F)
        cmbUpdateInstructorDepartment.FormattingEnabled = True
        cmbUpdateInstructorDepartment.Location = New Point(20, 152)
        cmbUpdateInstructorDepartment.Name = "cmbUpdateInstructorDepartment"
        cmbUpdateInstructorDepartment.Size = New Size(730, 27)
        cmbUpdateInstructorDepartment.TabIndex = 4
        ' 
        ' lblUpdateSpecialization
        ' 
        lblUpdateSpecialization.AutoSize = True
        lblUpdateSpecialization.Font = New Font("Times New Roman", 12F)
        lblUpdateSpecialization.Location = New Point(20, 200)
        lblUpdateSpecialization.Name = "lblUpdateSpecialization"
        lblUpdateSpecialization.Size = New Size(157, 19)
        lblUpdateSpecialization.TabIndex = 5
        lblUpdateSpecialization.Text = "Specialization (Optional)"
        ' 
        ' txtUpdateSpecialization
        ' 
        txtUpdateSpecialization.Font = New Font("Times New Roman", 12F)
        txtUpdateSpecialization.Location = New Point(20, 222)
        txtUpdateSpecialization.Name = "txtUpdateSpecialization"
        txtUpdateSpecialization.Size = New Size(350, 26)
        txtUpdateSpecialization.TabIndex = 6
        ' 
        ' lblUpdateHireDate
        ' 
        lblUpdateHireDate.AutoSize = True
        lblUpdateHireDate.Font = New Font("Times New Roman", 12F)
        lblUpdateHireDate.Location = New Point(400, 200)
        lblUpdateHireDate.Name = "lblUpdateHireDate"
        lblUpdateHireDate.Size = New Size(134, 19)
        lblUpdateHireDate.TabIndex = 7
        lblUpdateHireDate.Text = "Hire Date (Optional)"
        ' 
        ' dtpUpdateHireDate
        ' 
        dtpUpdateHireDate.Font = New Font("Times New Roman", 12F)
        dtpUpdateHireDate.Format = DateTimePickerFormat.Short
        dtpUpdateHireDate.Location = New Point(400, 222)
        dtpUpdateHireDate.Name = "dtpUpdateHireDate"
        dtpUpdateHireDate.Size = New Size(350, 26)
        dtpUpdateHireDate.TabIndex = 8
        ' 
        ' lblUpdateEmploymentStatus
        ' 
        lblUpdateEmploymentStatus.AutoSize = True
        lblUpdateEmploymentStatus.Font = New Font("Times New Roman", 12F)
        lblUpdateEmploymentStatus.Location = New Point(20, 270)
        lblUpdateEmploymentStatus.Name = "lblUpdateEmploymentStatus"
        lblUpdateEmploymentStatus.Size = New Size(191, 19)
        lblUpdateEmploymentStatus.TabIndex = 9
        lblUpdateEmploymentStatus.Text = "Employment Status (Optional)"
        ' 
        ' cmbUpdateEmploymentStatus
        ' 
        cmbUpdateEmploymentStatus.DropDownStyle = ComboBoxStyle.DropDownList
        cmbUpdateEmploymentStatus.Font = New Font("Times New Roman", 12F)
        cmbUpdateEmploymentStatus.FormattingEnabled = True
        cmbUpdateEmploymentStatus.Location = New Point(20, 292)
        cmbUpdateEmploymentStatus.Name = "cmbUpdateEmploymentStatus"
        cmbUpdateEmploymentStatus.Size = New Size(730, 27)
        cmbUpdateEmploymentStatus.TabIndex = 10
        ' 
        ' btnUpdateUser
        ' 
        btnUpdateUser.BackColor = Color.FromArgb(0, 122, 204)
        btnUpdateUser.FlatStyle = FlatStyle.Flat
        btnUpdateUser.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnUpdateUser.ForeColor = Color.White
        btnUpdateUser.Location = New Point(40, 790)
        btnUpdateUser.Name = "btnUpdateUser"
        btnUpdateUser.Size = New Size(200, 45)
        btnUpdateUser.TabIndex = 5
        btnUpdateUser.Text = "Update User"
        btnUpdateUser.UseVisualStyleBackColor = False
        btnUpdateUser.Visible = False
        ' 
        ' btnDeleteUser
        ' 
        btnDeleteUser.BackColor = Color.FromArgb(255, 71, 71)
        btnDeleteUser.FlatStyle = FlatStyle.Flat
        btnDeleteUser.Font = New Font("Times New Roman", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        btnDeleteUser.ForeColor = Color.White
        btnDeleteUser.Location = New Point(260, 790)
        btnDeleteUser.Name = "btnDeleteUser"
        btnDeleteUser.Size = New Size(200, 45)
        btnDeleteUser.TabIndex = 6
        btnDeleteUser.Text = "Delete User"
        btnDeleteUser.UseVisualStyleBackColor = False
        btnDeleteUser.Visible = False
        ' 
        ' Admin
        ' 
        AutoScaleDimensions = New SizeF(12F, 23F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1200, 800)
        Controls.Add(pnlMainContent)
        Controls.Add(pnlSidebar)
        Font = New Font("Times New Roman", 16F, FontStyle.Regular, GraphicsUnit.Point, 0)
        Name = "Admin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Admin Dashboard"
        pnlSidebar.ResumeLayout(False)
        pnlDepartmentManagementSubmenu.ResumeLayout(False)
        pnlUserManagementSubmenu.ResumeLayout(False)
        pnlMainContent.ResumeLayout(False)
        pnlDepartmentManagement.ResumeLayout(False)
        pnlDepartmentManagement.PerformLayout()
        CType(dgvDepartments, ComponentModel.ISupportInitialize).EndInit()
        pnlAddDepartment.ResumeLayout(False)
        pnlAddDepartment.PerformLayout()
        pnlUpdateDeleteDepartment.ResumeLayout(False)
        pnlUpdateDeleteDepartment.PerformLayout()
        grpDepartmentInfo.ResumeLayout(False)
        grpDepartmentInfo.PerformLayout()
        pnlDashboard.ResumeLayout(False)
        pnlDashboard.PerformLayout()
        pnlStats.ResumeLayout(False)
        pnlAddUser.ResumeLayout(False)
        pnlAddUser.PerformLayout()
        pnlStudentFields.ResumeLayout(False)
        pnlStudentFields.PerformLayout()
        pnlInstructorFields.ResumeLayout(False)
        pnlInstructorFields.PerformLayout()
        pnlUserDetails.ResumeLayout(False)
        pnlUserDetails.PerformLayout()
        CType(dgvUsers, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvInstructors, ComponentModel.ISupportInitialize).EndInit()
        CType(dgvStudents, ComponentModel.ISupportInitialize).EndInit()
        pnlResetPassword.ResumeLayout(False)
        pnlResetPassword.PerformLayout()
        pnlUpdateDeleteUser.ResumeLayout(False)
        pnlUpdateDeleteUser.PerformLayout()
        grpUserInfo.ResumeLayout(False)
        grpUserInfo.PerformLayout()
        pnlUpdateStudentFields.ResumeLayout(False)
        pnlUpdateStudentFields.PerformLayout()
        pnlUpdateInstructorFields.ResumeLayout(False)
        pnlUpdateInstructorFields.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Sidebar Controls
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents lblAdminTitle As Label
    Friend WithEvents btnDashboard As Button
    Friend WithEvents btnUserManagement As Button
    Friend WithEvents pnlUserManagementSubmenu As Panel
    Friend WithEvents btnAddUser As Button
    Friend WithEvents btnUserDetails As Button
    Friend WithEvents btnResetPassword As Button
    Friend WithEvents btnUpdateDeleteUser As Button
    Friend WithEvents btnDepartmentManagement As Button
    Friend WithEvents pnlDepartmentManagementSubmenu As Panel
    Friend WithEvents btnAddDepartment As Button
    Friend WithEvents btnUpdateDeleteDepartment As Button
    Friend WithEvents btnDepartmentDetails As Button
    Friend WithEvents btnLogout As Button
    Friend WithEvents btnCourseManagement As Button
    Friend WithEvents btnEnrollmentManagement As Button

    ' Main Content Panel
    Friend WithEvents pnlMainContent As Panel

    ' Dashboard Panel
    Friend WithEvents pnlDashboard As Panel
    Friend WithEvents lblDashboardTitle As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents pnlStats As Panel
    Friend WithEvents lblTotalUsers As Label
    Friend WithEvents lblTotalInstructors As Label
    Friend WithEvents lblTotalStudents As Label

    ' Department Management Panels
    Friend WithEvents pnlDepartmentManagement As Panel
    Friend WithEvents lblDepartmentManagementTitle As Label
    Friend WithEvents dgvDepartments As DataGridView
    Friend WithEvents pnlAddDepartment As Panel
    Friend WithEvents lblAddDepartmentTitle As Label
    Friend WithEvents lblDeptCode As Label
    Friend WithEvents txtDeptCode As TextBox
    Friend WithEvents lblDeptName As Label
    Friend WithEvents txtDeptName As TextBox
    Friend WithEvents lblDeptDescription As Label
    Friend WithEvents txtDeptDescription As TextBox
    Friend WithEvents lblDeptHeadInstructor As Label
    Friend WithEvents cmbDeptHeadInstructor As ComboBox
    Friend WithEvents btnSubmitDepartment As Button
    Friend WithEvents pnlUpdateDeleteDepartment As Panel
    Friend WithEvents lblUpdateDeleteDeptTitle As Label
    Friend WithEvents lblSelectDepartment As Label
    Friend WithEvents cmbSelectDepartment As ComboBox
    Friend WithEvents btnLoadDepartmentData As Button
    Friend WithEvents grpDepartmentInfo As GroupBox
    Friend WithEvents lblUpdateDeptCode As Label
    Friend WithEvents txtUpdateDeptCode As TextBox
    Friend WithEvents lblUpdateDeptName As Label
    Friend WithEvents txtUpdateDeptName As TextBox
    Friend WithEvents lblUpdateDeptDescription As Label
    Friend WithEvents txtUpdateDeptDescription As TextBox
    Friend WithEvents lblUpdateDeptHeadInstructor As Label
    Friend WithEvents cmbUpdateDeptHeadInstructor As ComboBox
    Friend WithEvents btnUpdateDepartment As Button
    Friend WithEvents btnDeleteDepartment As Button

    ' Add User Panel
    Friend WithEvents pnlAddUser As Panel
    Friend WithEvents lblAddUserTitle As Label
    Friend WithEvents lblFirstName As Label
    Friend WithEvents txtFirstName As TextBox
    Friend WithEvents lblMiddleName As Label
    Friend WithEvents txtMiddleName As TextBox
    Friend WithEvents lblLastName As Label
    Friend WithEvents txtLastName As TextBox
    Friend WithEvents lblUsername As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents lblPassword As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lblRole As Label
    Friend WithEvents cmbRole As ComboBox

    ' Student-specific fields panel
    Friend WithEvents pnlStudentFields As Panel
    Friend WithEvents lblStudentFieldsTitle As Label
    Friend WithEvents lblDateOfBirth As Label
    Friend WithEvents dtpDateOfBirth As DateTimePicker
    Friend WithEvents lblGender As Label
    Friend WithEvents cmbGender As ComboBox
    Friend WithEvents lblYearLevel As Label
    Friend WithEvents cmbYearLevel As ComboBox
    Friend WithEvents lblDepartment As Label
    Friend WithEvents cmbDepartment As ComboBox
    Friend WithEvents lblStudentEmail As Label
    Friend WithEvents txtStudentEmail As TextBox
    Friend WithEvents lblEnrollmentStatus As Label
    Friend WithEvents cmbEnrollmentStatus As ComboBox

    ' Instructor-specific fields panel
    Friend WithEvents pnlInstructorFields As Panel
    Friend WithEvents lblInstructorFieldsTitle As Label
    Friend WithEvents lblInstructorEmail As Label
    Friend WithEvents txtInstructorEmail As TextBox
    Friend WithEvents lblInstructorDepartment As Label
    Friend WithEvents cmbInstructorDepartment As ComboBox
    Friend WithEvents lblSpecialization As Label
    Friend WithEvents txtSpecialization As TextBox
    Friend WithEvents lblHireDate As Label
    Friend WithEvents dtpHireDate As DateTimePicker

    Friend WithEvents btnSubmitUser As Button

    ' User Details Panel
    Friend WithEvents pnlUserDetails As Panel
    Friend WithEvents lblUserDetailsTitle As Label
    Friend WithEvents lblUsers As Label
    Friend WithEvents dgvUsers As DataGridView
    Friend WithEvents lblInstructors As Label
    Friend WithEvents dgvInstructors As DataGridView
    Friend WithEvents lblStudents As Label
    Friend WithEvents dgvStudents As DataGridView

    ' Reset Password Panel
    Friend WithEvents pnlResetPassword As Panel
    Friend WithEvents lblResetPasswordTitle As Label
    Friend WithEvents lblSelectUserReset As Label
    Friend WithEvents cmbSelectUserReset As ComboBox
    Friend WithEvents lblNewPassword As Label
    Friend WithEvents txtNewPassword As TextBox
    Friend WithEvents btnGeneratePassword As Button
    Friend WithEvents btnResetPasswordSubmit As Button

    ' Update/Delete User Panel
    Friend WithEvents pnlUpdateDeleteUser As Panel
    Friend WithEvents lblUpdateDeleteTitle As Label
    Friend WithEvents lblSelectUserUpdate As Label
    Friend WithEvents cmbSelectUserUpdate As ComboBox
    Friend WithEvents btnLoadUserData As Button
    Friend WithEvents grpUserInfo As GroupBox
    Friend WithEvents lblUpdateFirstName As Label
    Friend WithEvents txtUpdateFirstName As TextBox
    Friend WithEvents lblUpdateMiddleName As Label
    Friend WithEvents txtUpdateMiddleName As TextBox
    Friend WithEvents lblUpdateLastName As Label
    Friend WithEvents txtUpdateLastName As TextBox
    Friend WithEvents lblUpdateUsername As Label
    Friend WithEvents txtUpdateUsername As TextBox
    Friend WithEvents lblUpdateRole As Label
    Friend WithEvents lblUpdateRoleDisplay As Label
    Friend WithEvents cmbUpdateRole As ComboBox
    Friend WithEvents pnlUpdateStudentFields As Panel
    Friend WithEvents lblUpdateStudentTitle As Label
    Friend WithEvents lblUpdateDateOfBirth As Label
    Friend WithEvents dtpUpdateDateOfBirth As DateTimePicker
    Friend WithEvents lblUpdateGender As Label
    Friend WithEvents cmbUpdateGender As ComboBox
    Friend WithEvents lblUpdateYearLevel As Label
    Friend WithEvents cmbUpdateYearLevel As ComboBox
    Friend WithEvents lblUpdateDepartment As Label
    Friend WithEvents cmbUpdateDepartment As ComboBox
    Friend WithEvents lblUpdateStudentEmail As Label
    Friend WithEvents txtUpdateStudentEmail As TextBox
    Friend WithEvents lblUpdateEnrollmentStatus As Label
    Friend WithEvents cmbUpdateEnrollmentStatus As ComboBox
    Friend WithEvents pnlUpdateInstructorFields As Panel
    Friend WithEvents lblUpdateInstructorTitle As Label
    Friend WithEvents lblUpdateInstructorEmail As Label
    Friend WithEvents txtUpdateInstructorEmail As TextBox
    Friend WithEvents lblUpdateInstructorDepartment As Label
    Friend WithEvents cmbUpdateInstructorDepartment As ComboBox
    Friend WithEvents lblUpdateSpecialization As Label
    Friend WithEvents txtUpdateSpecialization As TextBox
    Friend WithEvents lblUpdateHireDate As Label
    Friend WithEvents dtpUpdateHireDate As DateTimePicker
    Friend WithEvents lblUpdateEmploymentStatus As Label
    Friend WithEvents cmbUpdateEmploymentStatus As ComboBox
    Friend WithEvents btnUpdateUser As Button
    Friend WithEvents btnDeleteUser As Button
End Class
