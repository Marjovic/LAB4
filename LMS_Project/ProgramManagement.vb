Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class ProgramManagement
    ' Connection string - same as other forms
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current program ID for update/delete
    Private currentProgramId As Integer = 0

    Private Sub ProgramManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Program Management - MGOD LMS"

        ' Initialize dropdowns
        InitializeDepartmentDropdown()
        InitializeAccreditationDropdown()

        ' Load programs data
        LoadProgramsData()
        LoadProgramUpdateDropdown()

        ' Show View Programs panel by default
        ShowPanel(pnlViewPrograms)
    End Sub

    ' ============= VALIDATION METHODS =============

    ''' <summary>
    ''' Validates that the program code contains only letters (no numbers or special symbols)
    ''' </summary>
    Private Function ValidateProgramCode(programCode As String) As Boolean
        ' Check if empty
        If String.IsNullOrWhiteSpace(programCode) Then
            Return False
        End If

        ' Pattern: Only uppercase and lowercase letters allowed
        Dim pattern As String = "^[A-Za-z]+$"
        Return Regex.IsMatch(programCode.Trim(), pattern)
    End Function

    ''' <summary>
    ''' Validates that the program name contains only letters, spaces, hyphens, and ampersands
    ''' </summary>
    Private Function ValidateProgramName(programName As String) As Boolean
        ' Check if empty
        If String.IsNullOrWhiteSpace(programName) Then
            Return False
        End If

        ' Pattern: Only letters, spaces, hyphens, and ampersands allowed
        ' Examples: "College of Engineering and Technology", "Business Administration", "Computer Science & Technology"
        Dim pattern As String = "^[A-Za-z\s\-&]+$"
        Return Regex.IsMatch(programName.Trim(), pattern)
    End Function

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlCreateProgram.Visible = False
        pnlViewPrograms.Visible = False
        pnlUpdateDeleteProgram.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnCreateProgram.BackColor = Color.FromArgb(35, 35, 38)
        btnViewPrograms.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteProgram.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnCreateProgram_Click(sender As Object, e As EventArgs) Handles btnCreateProgram.Click
        ShowPanel(pnlCreateProgram)
        SetActiveButton(btnCreateProgram)
        ClearCreateProgramForm()
    End Sub

    Private Sub btnViewPrograms_Click(sender As Object, e As EventArgs) Handles btnViewPrograms.Click
        ShowPanel(pnlViewPrograms)
        SetActiveButton(btnViewPrograms)
        LoadProgramsData()
    End Sub

    Private Sub btnUpdateDeleteProgram_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteProgram.Click
        ShowPanel(pnlUpdateDeleteProgram)
        SetActiveButton(btnUpdateDeleteProgram)
        LoadProgramUpdateDropdown()
        ClearUpdateForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= INITIALIZATION METHODS =============

    Private Sub InitializeDepartmentDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT department_id, CONCAT(department_code, ' - ', department_name) as display_name " &
              "FROM Departments " &
                     "ORDER BY department_code"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim departmentTable As New DataTable()
                    adapter.Fill(departmentTable)

                    ' Bind to Create dropdown
                    cmbDepartment.DataSource = departmentTable.Copy()
                    cmbDepartment.DisplayMember = "display_name"
                    cmbDepartment.ValueMember = "department_id"

                    ' Bind to Update dropdown
                    cmbUpdateDepartment.DataSource = departmentTable.Copy()
                    cmbUpdateDepartment.DisplayMember = "display_name"
                    cmbUpdateDepartment.ValueMember = "department_id"

                    If cmbDepartment.Items.Count > 0 Then cmbDepartment.SelectedIndex = 0
                    If cmbUpdateDepartment.Items.Count > 0 Then cmbUpdateDepartment.SelectedIndex = 0
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeAccreditationDropdown()
        ' Initialize Create accreditation status
        cmbAccreditationStatus.Items.Clear()
        cmbAccreditationStatus.Items.AddRange(New String() {"Not Accredited", "Level I", "Level II", "Level III", "Level IV", "Autonomous"})
        cmbAccreditationStatus.SelectedIndex = 0

        ' Initialize Update accreditation status
        cmbUpdateAccreditationStatus.Items.Clear()
        cmbUpdateAccreditationStatus.Items.AddRange(New String() {"Not Accredited", "Level I", "Level II", "Level III", "Level IV", "Autonomous"})
        cmbUpdateAccreditationStatus.SelectedIndex = 0
    End Sub

    ' ============= CREATE PROGRAM METHODS =============

    Private Sub btnSubmitProgram_Click(sender As Object, e As EventArgs) Handles btnSubmitProgram.Click
        ' Validate required fields
        If String.IsNullOrWhiteSpace(txtProgramCode.Text) Then
            MessageBox.Show("Please enter a program code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProgramCode.Focus()
            Return
        End If

        ' Validate program code format (only letters, no numbers or symbols)
        If Not ValidateProgramCode(txtProgramCode.Text) Then
            MessageBox.Show("Program Code can only contain letters (no numbers or special symbols)." & vbCrLf & vbCrLf &
    "Valid examples: CET, BSIT, BSCS, COE" & vbCrLf &
            "Invalid examples: CET123, CS-IT, COE@2024",
          "Invalid Program Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProgramCode.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtProgramName.Text) Then
            MessageBox.Show("Please enter a program name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProgramName.Focus()
            Return
        End If

        ' Validate program name format (only letters, spaces, hyphens, and ampersands)
        If Not ValidateProgramName(txtProgramName.Text) Then
            MessageBox.Show("Program Name can only contain letters, spaces, hyphens, and ampersands (no numbers)." & vbCrLf & vbCrLf &
     "Valid examples:" & vbCrLf &
        "  • College of Engineering and Technology" & vbCrLf &
          "  • Business Administration" & vbCrLf &
             "  • Computer Science & Information Technology" & vbCrLf & vbCrLf &
       "Invalid examples:" & vbCrLf &
          "  • BS Information Technology 2024" & vbCrLf &
        "  • Engineering (Level 4)" & vbCrLf &
          "  • Computer Science #1",
       "Invalid Program Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtProgramName.Focus()
            Return
        End If

        If cmbDepartment.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a department.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate total units
        Dim totalUnits As Integer = 0
        If Not Integer.TryParse(txtTotalUnits.Text.Trim(), totalUnits) OrElse totalUnits <= 0 Then
            MessageBox.Show("Total units must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtTotalUnits.Focus()
            Return
        End If

        ' Validate years to complete
        Dim yearsToComplete As Integer = 0
        If Not Integer.TryParse(txtYearsToComplete.Text.Trim(), yearsToComplete) OrElse yearsToComplete <= 0 Then
            MessageBox.Show("Years to complete must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtYearsToComplete.Focus()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for duplicate program code
                Dim checkQuery As String = "SELECT COUNT(*) FROM Programs WHERE program_code = @program_code"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@program_code", txtProgramCode.Text.Trim().ToUpper())

                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("This program code already exists. Please use a different code.",
 "Duplicate Program Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtProgramCode.Focus()
                        Return
                    End If
                End Using

                ' Insert new program
                Dim insertQuery As String = "INSERT INTO Programs " &
            "(program_code, program_name, program_description, department_id, total_units_required, " &
      "years_to_complete, is_active, accreditation_status, created_at, updated_at) " &
             "VALUES (@program_code, @program_name, @program_description, @department_id, @total_units_required, " &
        "@years_to_complete, @is_active, @accreditation_status, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@program_code", txtProgramCode.Text.Trim().ToUpper())
                    insertCmd.Parameters.AddWithValue("@program_name", txtProgramName.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@program_description", If(String.IsNullOrWhiteSpace(txtProgramDescription.Text), DBNull.Value, txtProgramDescription.Text.Trim()))
                    insertCmd.Parameters.AddWithValue("@department_id", Convert.ToInt32(cmbDepartment.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@total_units_required", totalUnits)
                    insertCmd.Parameters.AddWithValue("@years_to_complete", yearsToComplete)
                    insertCmd.Parameters.AddWithValue("@is_active", chkIsActive.Checked)
                    insertCmd.Parameters.AddWithValue("@accreditation_status", If(cmbAccreditationStatus.SelectedItem Is Nothing, DBNull.Value, cmbAccreditationStatus.SelectedItem.ToString()))

                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Program created successfully!" & vbCrLf & vbCrLf &
       $"Program Code: {txtProgramCode.Text.Trim().ToUpper()}" & vbCrLf &
        $"Program Name: {txtProgramName.Text.Trim()}" & vbCrLf &
       $"Department: {cmbDepartment.Text}" & vbCrLf &
    $"Total Units: {totalUnits}" & vbCrLf &
                 $"Years to Complete: {yearsToComplete}",
     "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
                ClearCreateProgramForm()
                LoadProgramsData()
                LoadProgramUpdateDropdown()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("This program code already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error creating program: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateProgramForm()
        txtProgramCode.Clear()
        txtProgramName.Clear()
        txtProgramDescription.Clear()
        If cmbDepartment.Items.Count > 0 Then cmbDepartment.SelectedIndex = 0
        txtTotalUnits.Text = "160"
        txtYearsToComplete.Text = "4"
        cmbAccreditationStatus.SelectedIndex = 0
        chkIsActive.Checked = True
    End Sub

    ' ============= VIEW PROGRAMS METHODS =============

    Private Sub LoadProgramsData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT p.program_id as 'Program ID', " &
                       "p.program_code as 'Program Code', " &
                        "p.program_name as 'Program Name', " &
                  "SUBSTRING(p.program_description, 1, 50) as 'Description', " &
                  "d.department_name as 'Department', " &
              "p.total_units_required as 'Total Units', " &
                 "p.years_to_complete as 'Years', " &
                 "p.accreditation_status as 'Accreditation', " &
                     "CASE WHEN p.is_active = 1 THEN 'Active' ELSE 'Inactive' END as 'Status', " &
                     "DATE_FORMAT(p.created_at, '%Y-%m-%d') as 'Created' " &
                     "FROM Programs p " &
                     "LEFT JOIN Departments d ON p.department_id = d.department_id " &
                          "ORDER BY p.program_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim programsTable As New DataTable()
                    adapter.Fill(programsTable)
                    dgvPrograms.DataSource = programsTable
                    dgvPrograms.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading programs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshPrograms_Click(sender As Object, e As EventArgs) Handles btnRefreshPrograms.Click
        LoadProgramsData()
        MessageBox.Show("Programs data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE PROGRAM METHODS =============

    Private Sub LoadProgramUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT p.program_id, " &
                   "CONCAT(p.program_code, ' - ', p.program_name, ' (', d.department_code, ')') as display_name " &
             "FROM Programs p " &
         "LEFT JOIN Departments d ON p.department_id = d.department_id " &
           "ORDER BY p.program_code"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim programTable As New DataTable()
                    adapter.Fill(programTable)
                    cmbSelectProgram.DataSource = programTable
                    cmbSelectProgram.DisplayMember = "display_name"
                    cmbSelectProgram.ValueMember = "program_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading programs for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadProgramData_Click(sender As Object, e As EventArgs) Handles btnLoadProgramData.Click
        If cmbSelectProgram.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a program to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            currentProgramId = Convert.ToInt32(cmbSelectProgram.SelectedValue)
            LoadProgramDataForUpdate(currentProgramId)
        Catch ex As Exception
            MessageBox.Show($"Error loading program data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadProgramDataForUpdate(programId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT program_code, program_name, program_description, department_id, " &
           "total_units_required, years_to_complete, is_active, accreditation_status " &
                     "FROM Programs WHERE program_id = @program_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@program_id", programId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtUpdateProgramCode.Text = reader("program_code").ToString()
                            txtUpdateProgramName.Text = reader("program_name").ToString()
                            txtUpdateProgramDescription.Text = If(IsDBNull(reader("program_description")), "", reader("program_description").ToString())

                            If Not IsDBNull(reader("department_id")) Then
                                cmbUpdateDepartment.SelectedValue = Convert.ToInt32(reader("department_id"))
                            End If

                            txtUpdateTotalUnits.Text = reader("total_units_required").ToString()
                            txtUpdateYearsToComplete.Text = reader("years_to_complete").ToString()
                            chkUpdateIsActive.Checked = Convert.ToBoolean(reader("is_active"))

                            If Not IsDBNull(reader("accreditation_status")) Then
                                cmbUpdateAccreditationStatus.SelectedItem = reader("accreditation_status").ToString()
                            Else
                                cmbUpdateAccreditationStatus.SelectedIndex = 0
                            End If

                            grpProgramInfo.Visible = True
                            btnUpdateProgram.Visible = True
                            btnDeleteProgram.Visible = True
                        Else
                            MessageBox.Show("Program data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading program data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateProgram_Click(sender As Object, e As EventArgs) Handles btnUpdateProgram.Click
        If currentProgramId = 0 Then
            MessageBox.Show("Please load a program first.", "No Program Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate required fields
        If String.IsNullOrWhiteSpace(txtUpdateProgramCode.Text) Then
            MessageBox.Show("Please enter a program code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProgramCode.Focus()
            Return
        End If

        ' Validate program code format (only letters, no numbers or symbols)
        If Not ValidateProgramCode(txtUpdateProgramCode.Text) Then
            MessageBox.Show("Program Code can only contain letters (no numbers or special symbols)." & vbCrLf & vbCrLf &
                 "Valid examples: CET, BSIT, BSCS, COE" & vbCrLf &
              "Invalid examples: CET123, CS-IT, COE@2024",
              "Invalid Program Code", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProgramCode.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtUpdateProgramName.Text) Then
            MessageBox.Show("Please enter a program name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProgramName.Focus()
            Return
        End If

        ' Validate program name format (only letters, spaces, hyphens, and ampersands)
        If Not ValidateProgramName(txtUpdateProgramName.Text) Then
            MessageBox.Show("Program Name can only contain letters, spaces, hyphens, and ampersands (no numbers)." & vbCrLf & vbCrLf &
     "Valid examples:" & vbCrLf &
           "  • College of Engineering and Technology" & vbCrLf &
                  "  • Business Administration" & vbCrLf &
          "  • Computer Science & Information Technology" & vbCrLf & vbCrLf &
              "Invalid examples:" & vbCrLf &
               "  • BS Information Technology 2024" & vbCrLf &
   "  • Engineering (Level 4)" & vbCrLf &
           "  • Computer Science #1",
          "Invalid Program Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateProgramName.Focus()
            Return
        End If

        ' Validate total units
        Dim totalUnits As Integer = 0
        If Not Integer.TryParse(txtUpdateTotalUnits.Text.Trim(), totalUnits) OrElse totalUnits <= 0 Then
            MessageBox.Show("Total units must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateTotalUnits.Focus()
            Return
        End If

        ' Validate years to complete
        Dim yearsToComplete As Integer = 0
        If Not Integer.TryParse(txtUpdateYearsToComplete.Text.Trim(), yearsToComplete) OrElse yearsToComplete <= 0 Then
            MessageBox.Show("Years to complete must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUpdateYearsToComplete.Focus()
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this program?",
           "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Update program
                    Dim updateQuery As String = "UPDATE Programs SET " &
          "program_code = @program_code, " &
            "program_name = @program_name, " &
            "program_description = @program_description, " &
       "department_id = @department_id, " &
    "total_units_required = @total_units_required, " &
        "years_to_complete = @years_to_complete, " &
     "is_active = @is_active, " &
       "accreditation_status = @accreditation_status, " &
"updated_at = NOW() " &
         "WHERE program_id = @program_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@program_code", txtUpdateProgramCode.Text.Trim().ToUpper())
                        updateCmd.Parameters.AddWithValue("@program_name", txtUpdateProgramName.Text.Trim())
                        updateCmd.Parameters.AddWithValue("@program_description", If(String.IsNullOrWhiteSpace(txtUpdateProgramDescription.Text), DBNull.Value, txtUpdateProgramDescription.Text.Trim()))
                        updateCmd.Parameters.AddWithValue("@department_id", Convert.ToInt32(cmbUpdateDepartment.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@total_units_required", totalUnits)
                        updateCmd.Parameters.AddWithValue("@years_to_complete", yearsToComplete)
                        updateCmd.Parameters.AddWithValue("@is_active", chkUpdateIsActive.Checked)
                        updateCmd.Parameters.AddWithValue("@accreditation_status", If(cmbUpdateAccreditationStatus.SelectedItem Is Nothing, DBNull.Value, cmbUpdateAccreditationStatus.SelectedItem.ToString()))
                        updateCmd.Parameters.AddWithValue("@program_id", currentProgramId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Program updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh data
                    LoadProgramsData()
                    LoadProgramUpdateDropdown()
                    ClearUpdateForm()
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error updating program: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDeleteProgram_Click(sender As Object, e As EventArgs) Handles btnDeleteProgram.Click
        If currentProgramId = 0 Then
            MessageBox.Show("Please load a program first.", "No Program Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedProgramDisplay As String = cmbSelectProgram.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this program?" & vbCrLf & vbCrLf &
        $"{selectedProgramDisplay}" & vbCrLf & vbCrLf &
 "This action cannot be undone and may affect related records.",
          "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.Yes Then
            Try
                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim deleteQuery As String = "DELETE FROM Programs WHERE program_id = @program_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@program_id", currentProgramId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Program deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Refresh data
                            LoadProgramsData()
                            LoadProgramUpdateDropdown()
                            ClearUpdateForm()
                        Else
                            MessageBox.Show("Failed to delete program. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As MySqlException
                If ex.Number = 1451 Then ' Foreign key constraint fails
                    MessageBox.Show("Cannot delete this program because it is referenced by other records (e.g., curriculum, students)." & vbCrLf & vbCrLf &
                    "Please remove or update those records first, or set the program to inactive instead.",
                            "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error deleting program: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateForm()
        currentProgramId = 0
        txtUpdateProgramCode.Clear()
        txtUpdateProgramName.Clear()
        txtUpdateProgramDescription.Clear()
        txtUpdateTotalUnits.Text = "160"
        txtUpdateYearsToComplete.Text = "4"
        chkUpdateIsActive.Checked = True
        grpProgramInfo.Visible = False
        btnUpdateProgram.Visible = False
        btnDeleteProgram.Visible = False
    End Sub
End Class