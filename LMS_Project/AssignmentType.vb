Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class AssignmentType
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    Private Sub AssignmentType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Assignment Type Management - MGOD LMS"

        ' Add input validation event handlers
        AddHandler txtTypeName.KeyPress, AddressOf ValidateTypeNameInput
        AddHandler txtTypeCode.KeyPress, AddressOf ValidateTypeCodeInput
        AddHandler txtDefaultWeight.KeyPress, AddressOf ValidateDecimalInput
        AddHandler txtDisplayOrder.KeyPress, AddressOf ValidateNumericInput

        ' Add validation for update fields
        AddHandler txtUpdateTypeName.KeyPress, AddressOf ValidateTypeNameInput
        AddHandler txtUpdateTypeCode.KeyPress, AddressOf ValidateTypeCodeInput
        AddHandler txtUpdateDefaultWeight.KeyPress, AddressOf ValidateDecimalInput
        AddHandler txtUpdateDisplayOrder.KeyPress, AddressOf ValidateNumericInput

        ' Load data
        LoadAssignmentTypesData()
        LoadAssignmentTypeUpdateDropdown()

        ' Show View panel by default
        ShowPanel(pnlViewAssignmentTypes)
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlCreateAssignmentType.Visible = False
        pnlViewAssignmentTypes.Visible = False
        pnlUpdateDeleteAssignmentType.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnCreateAssignmentType.BackColor = Color.FromArgb(35, 35, 38)
        btnViewAssignmentTypes.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteAssignmentType.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnCreateAssignmentType_Click(sender As Object, e As EventArgs) Handles btnCreateAssignmentType.Click
        ShowPanel(pnlCreateAssignmentType)
        SetActiveButton(btnCreateAssignmentType)
        ClearCreateForm()
    End Sub

    Private Sub btnViewAssignmentTypes_Click(sender As Object, e As EventArgs) Handles btnViewAssignmentTypes.Click
        ShowPanel(pnlViewAssignmentTypes)
        SetActiveButton(btnViewAssignmentTypes)
        LoadAssignmentTypesData()
    End Sub

    Private Sub btnUpdateDeleteAssignmentType_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteAssignmentType.Click
        ShowPanel(pnlUpdateDeleteAssignmentType)
        SetActiveButton(btnUpdateDeleteAssignmentType)
        LoadAssignmentTypeUpdateDropdown()
        ClearUpdateForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= INPUT VALIDATION METHODS =============

    Private Sub ValidateTypeNameInput(sender As Object, e As KeyPressEventArgs)
        ' Allow letters, numbers, and backspace ONLY
        If Not (Char.IsLetterOrDigit(e.KeyChar) OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            MessageBox.Show("Type name can only contain letters and numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ValidateTypeCodeInput(sender As Object, e As KeyPressEventArgs)
        ' Allow only uppercase letters, numbers, and hyphens
        If Not (Char.IsUpper(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "-"c OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            MessageBox.Show("Type code must contain only uppercase letters, numbers, and hyphens.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ValidateDecimalInput(sender As Object, e As KeyPressEventArgs)
        Dim textBox As TextBox = DirectCast(sender, TextBox)

        ' Allow numbers, one decimal point, and backspace
        If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "."c OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            Return
        End If

        ' Allow only one decimal point
        If e.KeyChar = "."c AndAlso textBox.Text.Contains("."c) Then
            e.Handled = True
            MessageBox.Show("Only one decimal point is allowed.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ValidateNumericInput(sender As Object, e As KeyPressEventArgs)
        ' Allow only numbers and backspace
        If Not (Char.IsDigit(e.KeyChar) OrElse e.KeyChar = ControlChars.Back) Then
            e.Handled = True
            MessageBox.Show("Please enter numbers only.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Function IsValidAssignmentTypeInput(typeName As String, typeCode As String, defaultWeight As String) As Boolean
        ' Validate type name
        If String.IsNullOrWhiteSpace(typeName) Then
            MessageBox.Show("Type name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not Regex.IsMatch(typeName.Trim(), "^[a-zA-Z0-9]+$") Then
            MessageBox.Show("Type name can only contain letters and numbers.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate type code
        If String.IsNullOrWhiteSpace(typeCode) Then
            MessageBox.Show("Type code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        If Not Regex.IsMatch(typeCode.Trim(), "^[A-Z0-9\-]+$") Then
            MessageBox.Show("Type code must contain only uppercase letters, numbers, and hyphens.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate default weight
        Dim weight As Decimal = 0
        If Not Decimal.TryParse(defaultWeight.Trim(), weight) OrElse weight < 0 OrElse weight > 100 Then
            MessageBox.Show("Default weight must be a number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' ============= CREATE METHODS =============

    Private Sub btnSubmitAssignmentType_Click(sender As Object, e As EventArgs) Handles btnSubmitAssignmentType.Click
        ' Validate input
        If Not IsValidAssignmentTypeInput(txtTypeName.Text, txtTypeCode.Text, txtDefaultWeight.Text) Then
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for duplicate type name or code
                Dim checkQuery As String = "SELECT COUNT(*) FROM AssignmentTypes WHERE type_name = @type_name OR type_code = @type_code"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@type_name", txtTypeName.Text.Trim())
                    checkCmd.Parameters.AddWithValue("@type_code", txtTypeCode.Text.Trim().ToUpper())
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("Type name or code already exists. Please use different values.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Get the weight for the new type
                Dim newWeight As Decimal = Convert.ToDecimal(txtDefaultWeight.Text.Trim())
                Dim isActive As Boolean = chkIsActive.Checked

                ' Calculate total weight including this new type (only if it's active)
                Dim totalWeightQuery As String = "SELECT COALESCE(SUM(default_weight), 0) FROM AssignmentTypes WHERE is_active = TRUE"
                Dim currentTotalWeight As Decimal = 0
                Using totalCmd As New MySqlCommand(totalWeightQuery, connection)
                    currentTotalWeight = Convert.ToDecimal(totalCmd.ExecuteScalar())
                End Using

                ' Calculate new total if this type is active
                Dim newTotalWeight As Decimal = currentTotalWeight
                If isActive Then
                    newTotalWeight = currentTotalWeight + newWeight
                End If

                ' Show warning if total exceeds 100% (but allow it)
                If isActive AndAlso newTotalWeight > 100 Then
                    Dim warningResult As DialogResult = MessageBox.Show(
   $"⚠️ WEIGHT WARNING" & vbCrLf & vbCrLf &
        $"Current total weight of active types: {currentTotalWeight:F2}%" & vbCrLf &
          $"New type weight: {newWeight:F2}%" & vbCrLf &
              $"New total will be: {newTotalWeight:F2}%" & vbCrLf & vbCrLf &
            $"💡 Note: These are DEFAULT weights (templates)" & vbCrLf &
        $"   Teachers will customize weights per course in 'Offering Grade Weight' management." & vbCrLf & vbCrLf &
         $"   When configuring course weights, the total MUST equal 100% per grading period." & vbCrLf & vbCrLf &
    $"Do you want to continue creating this assignment type?",
    "Total Weight Exceeds 100%",
      MessageBoxButtons.YesNo,
   MessageBoxIcon.Warning)

                    If warningResult = DialogResult.No Then
                        Return
                    End If
                End If

                ' Get display order (optional, default to NULL)
                Dim displayOrder As Object = DBNull.Value
                Dim tempOrder As Integer = 0
                If Not String.IsNullOrWhiteSpace(txtDisplayOrder.Text) AndAlso Integer.TryParse(txtDisplayOrder.Text.Trim(), tempOrder) Then
                    displayOrder = tempOrder
                End If

                ' Insert new assignment type
                Dim insertQuery As String = "INSERT INTO AssignmentTypes " &
                                            "(type_name, type_code, default_weight, description, is_active, display_order, created_at, updated_at) " &
                                            "VALUES (@type_name, @type_code, @default_weight, @description, @is_active, @display_order, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@type_name", txtTypeName.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@type_code", txtTypeCode.Text.Trim().ToUpper())
                    insertCmd.Parameters.AddWithValue("@default_weight", newWeight)
                    insertCmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(txtDescription.Text), DBNull.Value, CType(txtDescription.Text.Trim(), Object)))
                    insertCmd.Parameters.AddWithValue("@is_active", isActive)
                    insertCmd.Parameters.AddWithValue("@display_order", displayOrder)

                    insertCmd.ExecuteNonQuery()
                End Using

                ' Calculate final total for confirmation message
                Dim finalTotalQuery As String = "SELECT COALESCE(SUM(default_weight), 0) FROM AssignmentTypes WHERE is_active = TRUE"
                Dim finalTotal As Decimal = 0
                Using finalCmd As New MySqlCommand(finalTotalQuery, connection)
                    finalTotal = Convert.ToDecimal(finalCmd.ExecuteScalar())
                End Using

                MessageBox.Show($"✅ Assignment type created successfully!" & vbCrLf & vbCrLf &
    $"Type Name: {txtTypeName.Text.Trim()}" & vbCrLf &
  $"Type Code: {txtTypeCode.Text.Trim().ToUpper()}" & vbCrLf &
   $"Default Weight: {newWeight:F2}%" & vbCrLf &
     $"Status: {If(isActive, "Active", "Inactive")}" & vbCrLf & vbCrLf &
  $"📊 Total weight of all active types: {finalTotal:F2}%",
      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
                ClearCreateForm()
                LoadAssignmentTypesData()
                LoadAssignmentTypeUpdateDropdown()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Type name or code already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error creating assignment type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateForm()
        txtTypeName.Clear()
        txtTypeCode.Clear()
        txtDefaultWeight.Text = "0.00"
        txtDescription.Clear()
        txtDisplayOrder.Text = "1"
        chkIsActive.Checked = True
    End Sub

    ' ============= VIEW METHODS =============

    Private Sub LoadAssignmentTypesData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT " &
                                     "type_id as 'Type ID', " &
                                     "type_name as 'Type Name', " &
                                     "type_code as 'Type Code', " &
                                     "CONCAT(default_weight, '%') as 'Default Weight', " &
                                     "IFNULL(description, 'N/A') as 'Description', " &
                                     "IF(is_active, 'Active', 'Inactive') as 'Status', " &
                                     "IFNULL(display_order, 'N/A') as 'Display Order', " &
                                     "DATE_FORMAT(created_at, '%Y-%m-%d') as 'Created' " &
                                     "FROM AssignmentTypes " &
                                     "ORDER BY display_order, type_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim typesTable As New DataTable()
                    adapter.Fill(typesTable)
                    dgvAssignmentTypes.DataSource = typesTable
                    dgvAssignmentTypes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using

                ' Calculate and display total weight
                Dim totalActiveQuery As String = "SELECT COALESCE(SUM(default_weight), 0) FROM AssignmentTypes WHERE is_active = TRUE"
                Using totalCmd As New MySqlCommand(totalActiveQuery, connection)
                    Dim totalActive As Decimal = Convert.ToDecimal(totalCmd.ExecuteScalar())

                    ' Update the title to show total weight
                    lblViewTitle.Text = $"All Assignment Types (Active Total: {totalActive:F2}%)"

                    ' Color code the title based on total
                    If totalActive = 100 Then
                        lblViewTitle.ForeColor = Color.FromArgb(0, 122, 204) ' Blue - Perfect
                    ElseIf totalActive > 100 Then
                        lblViewTitle.ForeColor = Color.FromArgb(255, 140, 0) ' Orange - Warning
                    Else
                        lblViewTitle.ForeColor = Color.FromArgb(0, 122, 204) ' Blue - OK (templates can be less than 100)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading assignment types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshAssignmentTypes_Click(sender As Object, e As EventArgs) Handles btnRefreshAssignmentTypes.Click
        LoadAssignmentTypesData()
        MessageBox.Show("Assignment types data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE METHODS =============

    Private Sub LoadAssignmentTypeUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT type_id, CONCAT(type_code, ' - ', type_name) as display_name FROM AssignmentTypes ORDER BY display_order, type_name"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim typeTable As New DataTable()
                    adapter.Fill(typeTable)
                    cmbSelectAssignmentType.DataSource = typeTable
                    cmbSelectAssignmentType.DisplayMember = "display_name"
                    cmbSelectAssignmentType.ValueMember = "type_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading assignment types for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadAssignmentTypeData_Click(sender As Object, e As EventArgs) Handles btnLoadAssignmentTypeData.Click
        If cmbSelectAssignmentType.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an assignment type to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedTypeId As Integer = Convert.ToInt32(cmbSelectAssignmentType.SelectedValue)
            LoadAssignmentTypeDataForUpdate(selectedTypeId)
        Catch ex As Exception
            MessageBox.Show($"Error loading assignment type data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAssignmentTypeDataForUpdate(typeId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT type_name, type_code, default_weight, description, is_active, display_order FROM AssignmentTypes WHERE type_id = @type_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@type_id", typeId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            txtUpdateTypeName.Text = reader("type_name").ToString()
                            txtUpdateTypeCode.Text = reader("type_code").ToString()
                            txtUpdateDefaultWeight.Text = reader("default_weight").ToString()
                            txtUpdateDescription.Text = If(IsDBNull(reader("description")), "", reader("description").ToString())
                            chkUpdateIsActive.Checked = Convert.ToBoolean(reader("is_active"))
                            txtUpdateDisplayOrder.Text = If(IsDBNull(reader("display_order")), "", reader("display_order").ToString())

                            grpAssignmentTypeInfo.Visible = True
                            btnUpdateAssignmentType.Visible = True
                            btnDeleteAssignmentType.Visible = True
                        Else
                            MessageBox.Show("Assignment type data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading assignment type data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateAssignmentType_Click(sender As Object, e As EventArgs) Handles btnUpdateAssignmentType.Click
        If cmbSelectAssignmentType.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an assignment type to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate input
        If Not IsValidAssignmentTypeInput(txtUpdateTypeName.Text, txtUpdateTypeCode.Text, txtUpdateDefaultWeight.Text) Then
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this assignment type?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedTypeId As Integer = Convert.ToInt32(cmbSelectAssignmentType.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Check for duplicate (excluding current type)
                    Dim checkQuery As String = "SELECT COUNT(*) FROM AssignmentTypes WHERE (type_name = @type_name OR type_code = @type_code) AND type_id != @type_id"
                    Using checkCmd As New MySqlCommand(checkQuery, connection)
                        checkCmd.Parameters.AddWithValue("@type_name", txtUpdateTypeName.Text.Trim())
                        checkCmd.Parameters.AddWithValue("@type_code", txtUpdateTypeCode.Text.Trim().ToUpper())
                        checkCmd.Parameters.AddWithValue("@type_id", selectedTypeId)
                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                        If count > 0 Then
                            MessageBox.Show("Type name or code already exists for another type.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Get the new weight and status
                    Dim newWeight As Decimal = Convert.ToDecimal(txtUpdateDefaultWeight.Text.Trim())
                    Dim isActive As Boolean = chkUpdateIsActive.Checked

                    ' Get the OLD weight and status for this type
                    Dim oldWeight As Decimal = 0
                    Dim wasActive As Boolean = False
                    Dim oldQuery As String = "SELECT default_weight, is_active FROM AssignmentTypes WHERE type_id = @type_id"
                    Using oldCmd As New MySqlCommand(oldQuery, connection)
                        oldCmd.Parameters.AddWithValue("@type_id", selectedTypeId)
                        Using reader = oldCmd.ExecuteReader()
                            If reader.Read() Then
                                oldWeight = Convert.ToDecimal(reader("default_weight"))
                                wasActive = Convert.ToBoolean(reader("is_active"))
                            End If
                        End Using
                    End Using

                    ' Calculate total weight of OTHER active types (excluding this one)
                    Dim totalOthersQuery As String = "SELECT COALESCE(SUM(default_weight), 0) FROM AssignmentTypes " &
   "WHERE is_active = TRUE AND type_id != @type_id"
                    Dim totalOthersWeight As Decimal = 0
                    Using totalCmd As New MySqlCommand(totalOthersQuery, connection)
                        totalCmd.Parameters.AddWithValue("@type_id", selectedTypeId)
                        totalOthersWeight = Convert.ToDecimal(totalCmd.ExecuteScalar())
                    End Using

                    ' Calculate new total if this type is active
                    Dim newTotalWeight As Decimal = totalOthersWeight
                    If isActive Then
                        newTotalWeight = totalOthersWeight + newWeight
                    End If

                    ' Show warning if total exceeds 100% (but allow it)
                    If isActive AndAlso newTotalWeight > 100 Then
                        Dim warningResult As DialogResult = MessageBox.Show(
   $"⚠️ WEIGHT WARNING" & vbCrLf & vbCrLf &
   $"Total weight of other active types: {totalOthersWeight:F2}%" & vbCrLf &
          $"This type's new weight: {newWeight:F2}%" & vbCrLf &
    $"New total will be: {newTotalWeight:F2}%" & vbCrLf & vbCrLf &
       $"💡 Note: These are DEFAULT weights (templates)" & vbCrLf &
       $"   Teachers will customize weights per course in 'Offering Grade Weight' management." & vbCrLf & vbCrLf &
      $"   When configuring course weights, the total MUST equal 100% per grading period." & vbCrLf & vbCrLf &
   $"Do you want to continue updating this assignment type?",
         "Total Weight Exceeds 100%",
          MessageBoxButtons.YesNo,
   MessageBoxIcon.Warning)

                        If warningResult = DialogResult.No Then
                            Return
                        End If
                    End If

                    ' Get display order
                    Dim displayOrder As Object = DBNull.Value
                    Dim tempOrder As Integer = 0
                    If Not String.IsNullOrWhiteSpace(txtUpdateDisplayOrder.Text) AndAlso Integer.TryParse(txtUpdateDisplayOrder.Text.Trim(), tempOrder) Then
                        displayOrder = tempOrder
                    End If

                    ' Update assignment type
                    Dim updateQuery As String = "UPDATE AssignmentTypes SET " &
             "type_name = @type_name, " &
  "type_code = @type_code, " &
  "default_weight = @default_weight, " &
     "description = @description, " &
        "is_active = @is_active, " &
            "display_order = @display_order, " &
      "updated_at = NOW() " &
      "WHERE type_id = @type_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@type_name", txtUpdateTypeName.Text.Trim())
                        updateCmd.Parameters.AddWithValue("@type_code", txtUpdateTypeCode.Text.Trim().ToUpper())
                        updateCmd.Parameters.AddWithValue("@default_weight", newWeight)
                        updateCmd.Parameters.AddWithValue("@description", If(String.IsNullOrWhiteSpace(txtUpdateDescription.Text), DBNull.Value, CType(txtUpdateDescription.Text.Trim(), Object)))
                        updateCmd.Parameters.AddWithValue("@is_active", isActive)
                        updateCmd.Parameters.AddWithValue("@display_order", displayOrder)
                        updateCmd.Parameters.AddWithValue("@type_id", selectedTypeId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    ' Calculate final total for confirmation message
                    Dim finalTotalQuery As String = "SELECT COALESCE(SUM(default_weight), 0) FROM AssignmentTypes WHERE is_active = TRUE"
                    Dim finalTotal As Decimal = 0
                    Using finalCmd As New MySqlCommand(finalTotalQuery, connection)
                        finalTotal = Convert.ToDecimal(finalCmd.ExecuteScalar())
                    End Using

                    MessageBox.Show($"✅ Assignment type updated successfully!" & vbCrLf & vbCrLf &
          $"📊 Total weight of all active types: {finalTotal:F2}%",
     "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh data
                    LoadAssignmentTypesData()
                    LoadAssignmentTypeUpdateDropdown()
                    ClearUpdateForm()
                End Using
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    MessageBox.Show("Type name or code already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error updating assignment type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDeleteAssignmentType_Click(sender As Object, e As EventArgs) Handles btnDeleteAssignmentType.Click
        If cmbSelectAssignmentType.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an assignment type to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedTypeDisplay As String = cmbSelectAssignmentType.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete: {selectedTypeDisplay}?" & vbCrLf & vbCrLf &
                                                      "This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedTypeId As Integer = Convert.ToInt32(cmbSelectAssignmentType.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim deleteQuery As String = "DELETE FROM AssignmentTypes WHERE type_id = @type_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@type_id", selectedTypeId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Assignment type deleted successfully: {selectedTypeDisplay}", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Refresh data
                            LoadAssignmentTypesData()
                            LoadAssignmentTypeUpdateDropdown()
                            ClearUpdateForm()
                        Else
                            MessageBox.Show("Failed to delete assignment type. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting assignment type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateForm()
        txtUpdateTypeName.Clear()
        txtUpdateTypeCode.Clear()
        txtUpdateDefaultWeight.Text = "0.00"
        txtUpdateDescription.Clear()
        txtUpdateDisplayOrder.Clear()
        chkUpdateIsActive.Checked = True
        grpAssignmentTypeInfo.Visible = False
        btnUpdateAssignmentType.Visible = False
        btnDeleteAssignmentType.Visible = False
    End Sub
End Class