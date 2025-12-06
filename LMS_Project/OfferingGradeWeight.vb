Imports MySql.Data.MySqlClient

Public Class OfferingGradeWeight
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    Private Sub OfferingGradeWeight_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Offering Grade Weight Management - MGOD LMS"

        ' Add input validation event handlers
        AddHandler txtCustomWeight.KeyPress, AddressOf ValidateDecimalInput
        AddHandler txtMaxScore.KeyPress, AddressOf ValidateDecimalInput
        AddHandler txtUpdateCustomWeight.KeyPress, AddressOf ValidateDecimalInput
        AddHandler txtUpdateMaxScore.KeyPress, AddressOf ValidateDecimalInput

        ' Load dropdown data
        LoadOfferingsDropdown()
        LoadAssignmentTypesDropdown()
        LoadGradingPeriodsDropdown()

        ' Load data for view and update
        LoadWeightsData()
        LoadWeightsUpdateDropdown()

        ' Show View panel by default
        ShowPanel(pnlViewWeights)
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlCreateWeight.Visible = False
        pnlViewWeights.Visible = False
        pnlUpdateDeleteWeight.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnCreateWeight.BackColor = Color.FromArgb(35, 35, 38)
        btnViewWeights.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteWeight.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnCreateWeight_Click(sender As Object, e As EventArgs) Handles btnCreateWeight.Click
        ShowPanel(pnlCreateWeight)
        SetActiveButton(btnCreateWeight)
        ClearCreateForm()
        LoadOfferingsDropdown()
        LoadAssignmentTypesDropdown()
        LoadGradingPeriodsDropdown()
    End Sub

    Private Sub btnViewWeights_Click(sender As Object, e As EventArgs) Handles btnViewWeights.Click
        ShowPanel(pnlViewWeights)
        SetActiveButton(btnViewWeights)
        LoadWeightsData()
    End Sub

    Private Sub btnUpdateDeleteWeight_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteWeight.Click
        ShowPanel(pnlUpdateDeleteWeight)
        SetActiveButton(btnUpdateDeleteWeight)
        LoadWeightsUpdateDropdown()
        ClearUpdateForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= INPUT VALIDATION METHODS =============

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

    Private Function IsValidWeightInput(offeringId As Integer, typeId As Integer, customWeight As String, maxScore As String) As Boolean
        ' Validate offering selection
        If offeringId <= 0 Then
            MessageBox.Show("Please select a course offering.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate assignment type selection
        If typeId <= 0 Then
            MessageBox.Show("Please select an assignment type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate custom weight
        Dim weight As Decimal = 0
        If Not Decimal.TryParse(customWeight.Trim(), weight) OrElse weight < 0 OrElse weight > 100 Then
            MessageBox.Show("Custom weight must be a number between 0 and 100.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        ' Validate max score
        Dim score As Decimal = 0
        If Not Decimal.TryParse(maxScore.Trim(), score) OrElse score <= 0 Then
            MessageBox.Show("Max score must be a number greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Return True
    End Function

    ' ============= DROPDOWN LOADING METHODS =============

    Private Sub LoadOfferingsDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT co.offering_id, " &
  "CONCAT(c.course_code, ' - ', c.course_name, ' (', ay.academic_year_name, ' ', st.type_name, ', Section: ', IFNULL(co.section, 'N/A'), ')') as display_name " &
     "FROM Course_Offerings co " &
       "INNER JOIN Courses c ON co.course_id = c.course_id " &
         "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
     "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
        "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
    "WHERE co.offering_status IN ('Open', 'Full') " &
    "ORDER BY ay.year_start DESC, c.course_code"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim offeringsTable As New DataTable()
                    adapter.Fill(offeringsTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = offeringsTable.NewRow()
                    emptyRow("offering_id") = 0
                    emptyRow("display_name") = "-- Select Course Offering --"
                    offeringsTable.Rows.InsertAt(emptyRow, 0)

                    cmbOffering.DataSource = offeringsTable.Copy()
                    cmbOffering.DisplayMember = "display_name"
                    cmbOffering.ValueMember = "offering_id"

                    cmbUpdateOffering.DataSource = offeringsTable.Copy()
                    cmbUpdateOffering.DisplayMember = "display_name"
                    cmbUpdateOffering.ValueMember = "offering_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading course offerings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadAssignmentTypesDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT type_id, CONCAT(type_code, ' - ', type_name) as display_name " &
       "FROM AssignmentTypes " &
                  "WHERE is_active = TRUE " &
                   "ORDER BY display_order, type_name"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim typesTable As New DataTable()
                    adapter.Fill(typesTable)

                    ' Add empty row for selection
                    Dim emptyRow As DataRow = typesTable.NewRow()
                    emptyRow("type_id") = 0
                    emptyRow("display_name") = "-- Select Assignment Type --"
                    typesTable.Rows.InsertAt(emptyRow, 0)

                    cmbAssignmentType.DataSource = typesTable.Copy()
                    cmbAssignmentType.DisplayMember = "display_name"
                    cmbAssignmentType.ValueMember = "type_id"

                    cmbUpdateAssignmentType.DataSource = typesTable.Copy()
                    cmbUpdateAssignmentType.DisplayMember = "display_name"
                    cmbUpdateAssignmentType.ValueMember = "type_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading assignment types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadGradingPeriodsDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT period_id, CONCAT(period_code, ' - ', period_name) as display_name " &
                  "FROM Grading_Periods " &
                     "ORDER BY display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim periodsTable As New DataTable()
                    adapter.Fill(periodsTable)

                    ' Add empty row for optional selection
                    Dim emptyRow As DataRow = periodsTable.NewRow()
                    emptyRow("period_id") = DBNull.Value
                    emptyRow("display_name") = "-- No Specific Period --"
                    periodsTable.Rows.InsertAt(emptyRow, 0)

                    cmbGradingPeriod.DataSource = periodsTable.Copy()
                    cmbGradingPeriod.DisplayMember = "display_name"
                    cmbGradingPeriod.ValueMember = "period_id"

                    cmbUpdateGradingPeriod.DataSource = periodsTable.Copy()
                    cmbUpdateGradingPeriod.DisplayMember = "display_name"
                    cmbUpdateGradingPeriod.ValueMember = "period_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading grading periods: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' ============= CREATE METHODS =============

    Private Sub btnSubmitWeight_Click(sender As Object, e As EventArgs) Handles btnSubmitWeight.Click
        ' Get selected values
        Dim offeringId As Integer = If(cmbOffering.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbOffering.SelectedValue), Convert.ToInt32(cmbOffering.SelectedValue), 0)
        Dim typeId As Integer = If(cmbAssignmentType.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbAssignmentType.SelectedValue), Convert.ToInt32(cmbAssignmentType.SelectedValue), 0)

        ' Validate input
        If Not IsValidWeightInput(offeringId, typeId, txtCustomWeight.Text, txtMaxScore.Text) Then
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Get period_id (can be NULL)
                Dim periodId As Object = DBNull.Value
                If cmbGradingPeriod.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbGradingPeriod.SelectedValue) Then
                    periodId = cmbGradingPeriod.SelectedValue
                End If

                ' Check for duplicate entry
                Dim checkQuery As String = "SELECT COUNT(*) FROM Offering_Grading_Weights " &
            "WHERE offering_id = @offering_id AND type_id = @type_id " &
      "AND (@period_id IS NULL AND period_id IS NULL OR period_id = @period_id)"

                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@offering_id", offeringId)
                    checkCmd.Parameters.AddWithValue("@type_id", typeId)
                    checkCmd.Parameters.AddWithValue("@period_id", periodId)

                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    If count > 0 Then
                        MessageBox.Show("This weight configuration already exists for the selected offering, type, and period.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' Insert new weight
                Dim insertQuery As String = "INSERT INTO Offering_Grading_Weights " &
               "(offering_id, type_id, period_id, custom_weight, max_score, notes, created_at, updated_at) " &
   "VALUES (@offering_id, @type_id, @period_id, @custom_weight, @max_score, @notes, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@offering_id", offeringId)
                    insertCmd.Parameters.AddWithValue("@type_id", typeId)
                    insertCmd.Parameters.AddWithValue("@period_id", periodId)
                    insertCmd.Parameters.AddWithValue("@custom_weight", Convert.ToDecimal(txtCustomWeight.Text.Trim()))
                    insertCmd.Parameters.AddWithValue("@max_score", Convert.ToDecimal(txtMaxScore.Text.Trim()))
                    insertCmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, CType(txtNotes.Text.Trim(), Object)))

                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show($"Offering grade weight created successfully!" & vbCrLf & vbCrLf &
                        $"Custom Weight: {txtCustomWeight.Text.Trim()}%" & vbCrLf &
             $"Max Score: {txtMaxScore.Text.Trim()}",
                       "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
                ClearCreateForm()
                LoadWeightsData()
                LoadWeightsUpdateDropdown()
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("This weight configuration already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error creating offering grade weight: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateForm()
        If cmbOffering.Items.Count > 0 Then cmbOffering.SelectedIndex = 0
        If cmbAssignmentType.Items.Count > 0 Then cmbAssignmentType.SelectedIndex = 0
        If cmbGradingPeriod.Items.Count > 0 Then cmbGradingPeriod.SelectedIndex = 0
        txtCustomWeight.Text = "0.00"
        txtMaxScore.Text = "100.00"
        txtNotes.Clear()
    End Sub

    ' ============= VIEW METHODS =============

    Private Sub LoadWeightsData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT " &
       "ogw.weight_id as 'Weight ID', " &
            "CONCAT(c.course_code, ' - ', c.course_name) as 'Course', " &
"CONCAT(ay.academic_year_name, ' ', st.type_name, ', Sec: ', IFNULL(co.section, 'N/A')) as 'Offering', " &
                    "at.type_name as 'Assignment Type', " &
    "IFNULL(gp.period_name, 'All Periods') as 'Grading Period', " &
                 "CONCAT(ogw.custom_weight, '%') as 'Weight', " &
           "ogw.max_score as 'Max Score', " &
    "IFNULL(ogw.notes, 'N/A') as 'Notes', " &
"DATE_FORMAT(ogw.created_at, '%Y-%m-%d') as 'Created' " &
         "FROM Offering_Grading_Weights ogw " &
  "INNER JOIN Course_Offerings co ON ogw.offering_id = co.offering_id " &
  "INNER JOIN Courses c ON co.course_id = c.course_id " &
 "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
 "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
      "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
        "INNER JOIN AssignmentTypes at ON ogw.type_id = at.type_id " &
       "LEFT JOIN Grading_Periods gp ON ogw.period_id = gp.period_id " &
          "ORDER BY ay.year_start DESC, c.course_code, at.display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim weightsTable As New DataTable()
                    adapter.Fill(weightsTable)
                    dgvWeights.DataSource = weightsTable
                    dgvWeights.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading offering grade weights: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshWeights_Click(sender As Object, e As EventArgs) Handles btnRefreshWeights.Click
        LoadWeightsData()
        MessageBox.Show("Offering grade weights data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE METHODS =============

    Private Sub LoadWeightsUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT ogw.weight_id, " &
                "CONCAT(c.course_code, ' - ', at.type_code, ' (', IFNULL(gp.period_code, 'ALL'), ') - ', ogw.custom_weight, '%') as display_name " &
         "FROM Offering_Grading_Weights ogw " &
             "INNER JOIN Course_Offerings co ON ogw.offering_id = co.offering_id " &
            "INNER JOIN Courses c ON co.course_id = c.course_id " &
           "INNER JOIN AssignmentTypes at ON ogw.type_id = at.type_id " &
               "LEFT JOIN Grading_Periods gp ON ogw.period_id = gp.period_id " &
                  "ORDER BY c.course_code, at.display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim weightsTable As New DataTable()
                    adapter.Fill(weightsTable)
                    cmbSelectWeight.DataSource = weightsTable
                    cmbSelectWeight.DisplayMember = "display_name"
                    cmbSelectWeight.ValueMember = "weight_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading weights for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadWeightData_Click(sender As Object, e As EventArgs) Handles btnLoadWeightData.Click
        If cmbSelectWeight.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a weight configuration to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedWeightId As Integer = Convert.ToInt32(cmbSelectWeight.SelectedValue)
            LoadWeightDataForUpdate(selectedWeightId)
        Catch ex As Exception
            MessageBox.Show($"Error loading weight data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadWeightDataForUpdate(weightId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT offering_id, type_id, period_id, custom_weight, max_score, notes " &
  "FROM Offering_Grading_Weights " &
          "WHERE weight_id = @weight_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@weight_id", weightId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ' Load dropdowns first
                            LoadOfferingsDropdown()
                            LoadAssignmentTypesDropdown()
                            LoadGradingPeriodsDropdown()

                            ' Set values
                            cmbUpdateOffering.SelectedValue = reader("offering_id")
                            cmbUpdateAssignmentType.SelectedValue = reader("type_id")

                            If IsDBNull(reader("period_id")) Then
                                cmbUpdateGradingPeriod.SelectedIndex = 0
                            Else
                                cmbUpdateGradingPeriod.SelectedValue = reader("period_id")
                            End If

                            txtUpdateCustomWeight.Text = reader("custom_weight").ToString()
                            txtUpdateMaxScore.Text = reader("max_score").ToString()
                            txtUpdateNotes.Text = If(IsDBNull(reader("notes")), "", reader("notes").ToString())

                            grpWeightInfo.Visible = True
                            btnUpdateWeight.Visible = True
                            btnDeleteWeight.Visible = True
                        Else
                            MessageBox.Show("Weight data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading weight data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateWeight_Click(sender As Object, e As EventArgs) Handles btnUpdateWeight.Click
        If cmbSelectWeight.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a weight configuration to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get selected values
        Dim offeringId As Integer = If(cmbUpdateOffering.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbUpdateOffering.SelectedValue), Convert.ToInt32(cmbUpdateOffering.SelectedValue), 0)
        Dim typeId As Integer = If(cmbUpdateAssignmentType.SelectedValue IsNot Nothing AndAlso IsNumeric(cmbUpdateAssignmentType.SelectedValue), Convert.ToInt32(cmbUpdateAssignmentType.SelectedValue), 0)

        ' Validate input
        If Not IsValidWeightInput(offeringId, typeId, txtUpdateCustomWeight.Text, txtUpdateMaxScore.Text) Then
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this weight configuration?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedWeightId As Integer = Convert.ToInt32(cmbSelectWeight.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' Get period_id
                    Dim periodId As Object = DBNull.Value
                    If cmbUpdateGradingPeriod.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbUpdateGradingPeriod.SelectedValue) Then
                        periodId = cmbUpdateGradingPeriod.SelectedValue
                    End If

                    ' Check for duplicate (excluding current weight)
                    Dim checkQuery As String = "SELECT COUNT(*) FROM Offering_Grading_Weights " &
                     "WHERE offering_id = @offering_id AND type_id = @type_id " &
                        "AND (@period_id IS NULL AND period_id IS NULL OR period_id = @period_id) " &
                  "AND weight_id != @weight_id"

                    Using checkCmd As New MySqlCommand(checkQuery, connection)
                        checkCmd.Parameters.AddWithValue("@offering_id", offeringId)
                        checkCmd.Parameters.AddWithValue("@type_id", typeId)
                        checkCmd.Parameters.AddWithValue("@period_id", periodId)
                        checkCmd.Parameters.AddWithValue("@weight_id", selectedWeightId)

                        Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                        If count > 0 Then
                            MessageBox.Show("This weight configuration already exists for another entry.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    ' Update weight
                    Dim updateQuery As String = "UPDATE Offering_Grading_Weights SET " &
                    "offering_id = @offering_id, " &
                      "type_id = @type_id, " &
                          "period_id = @period_id, " &
                            "custom_weight = @custom_weight, " &
                         "max_score = @max_score, " &
                    "notes = @notes, " &
                               "updated_at = NOW() " &
                    "WHERE weight_id = @weight_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@offering_id", offeringId)
                        updateCmd.Parameters.AddWithValue("@type_id", typeId)
                        updateCmd.Parameters.AddWithValue("@period_id", periodId)
                        updateCmd.Parameters.AddWithValue("@custom_weight", Convert.ToDecimal(txtUpdateCustomWeight.Text.Trim()))
                        updateCmd.Parameters.AddWithValue("@max_score", Convert.ToDecimal(txtUpdateMaxScore.Text.Trim()))
                        updateCmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(txtUpdateNotes.Text), DBNull.Value, CType(txtUpdateNotes.Text.Trim(), Object)))
                        updateCmd.Parameters.AddWithValue("@weight_id", selectedWeightId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Offering grade weight updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    ' Refresh data
                    LoadWeightsData()
                    LoadWeightsUpdateDropdown()
                    ClearUpdateForm()
                End Using
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    MessageBox.Show("This weight configuration already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error updating offering grade weight: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDeleteWeight_Click(sender As Object, e As EventArgs) Handles btnDeleteWeight.Click
        If cmbSelectWeight.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a weight configuration to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedWeightDisplay As String = cmbSelectWeight.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete: {selectedWeightDisplay}?" & vbCrLf & vbCrLf &
              "This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedWeightId As Integer = Convert.ToInt32(cmbSelectWeight.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim deleteQuery As String = "DELETE FROM Offering_Grading_Weights WHERE weight_id = @weight_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@weight_id", selectedWeightId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Offering grade weight deleted successfully: {selectedWeightDisplay}", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            ' Refresh data
                            LoadWeightsData()
                            LoadWeightsUpdateDropdown()
                            ClearUpdateForm()
                        Else
                            MessageBox.Show("Failed to delete weight configuration. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting offering grade weight: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateForm()
        If cmbUpdateOffering.Items.Count > 0 Then cmbUpdateOffering.SelectedIndex = 0
        If cmbUpdateAssignmentType.Items.Count > 0 Then cmbUpdateAssignmentType.SelectedIndex = 0
        If cmbUpdateGradingPeriod.Items.Count > 0 Then cmbUpdateGradingPeriod.SelectedIndex = 0
        txtUpdateCustomWeight.Text = "0.00"
        txtUpdateMaxScore.Text = "100.00"
        txtUpdateNotes.Clear()
        grpWeightInfo.Visible = False
        btnUpdateWeight.Visible = False
        btnDeleteWeight.Visible = False
    End Sub
End Class