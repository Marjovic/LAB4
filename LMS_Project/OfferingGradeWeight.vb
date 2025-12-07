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
                Dim periodDisplay As String = "All Periods"
                If cmbGradingPeriod.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbGradingPeriod.SelectedValue) Then
                    periodId = cmbGradingPeriod.SelectedValue
                    periodDisplay = cmbGradingPeriod.Text
                End If

                ' Get the new weight value
                Dim newWeight As Decimal = Convert.ToDecimal(txtCustomWeight.Text.Trim())

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

                ' ============= VALIDATE 100% TOTAL WEIGHT =============
                ' Calculate current total weight for this offering and period
                Dim totalWeightQuery As String = "SELECT COALESCE(SUM(custom_weight), 0) " &
             "FROM Offering_Grading_Weights " &
    "WHERE offering_id = @offering_id " &
"AND (@period_id IS NULL AND period_id IS NULL OR period_id = @period_id)"

                Dim currentTotal As Decimal = 0
                Using totalCmd As New MySqlCommand(totalWeightQuery, connection)
                    totalCmd.Parameters.AddWithValue("@offering_id", offeringId)
                    totalCmd.Parameters.AddWithValue("@period_id", periodId)
                    currentTotal = Convert.ToDecimal(totalCmd.ExecuteScalar())
                End Using

                Dim newTotal As Decimal = currentTotal + newWeight
                Dim remaining As Decimal = 100 - newTotal

                ' Get course name for better display
                Dim courseDisplay As String = cmbOffering.Text

                ' Show validation warning based on total
                If newTotal > 100 Then
                    ' EXCEEDS 100% - Not allowed
                    MessageBox.Show(
         $"❌ WEIGHT VALIDATION ERROR" & vbCrLf & vbCrLf &
 $"📚 Course: {courseDisplay}" & vbCrLf &
      $"📅 Period: {periodDisplay}" & vbCrLf & vbCrLf &
    $"Current total weight: {currentTotal:F2}%" & vbCrLf &
  $"New weight to add: {newWeight:F2}%" & vbCrLf &
        $"New total would be: {newTotal:F2}%" & vbCrLf & vbCrLf &
       $"⚠️ Total weight CANNOT exceed 100%!" & vbCrLf & vbCrLf &
   $"💡 Available weight: {100 - currentTotal:F2}%" & vbCrLf &
        $"   Please enter a weight of {100 - currentTotal:F2}% or less.",
            "Weight Exceeds 100%",
     MessageBoxButtons.OK,
               MessageBoxIcon.Error)
                    Return

                ElseIf newTotal = 100 Then
                    ' PERFECT 100% - Confirm
                    Dim perfectResult As DialogResult = MessageBox.Show(
 "✅ PERFECT 100% ALLOCATION!" & vbCrLf & vbCrLf &
             $"📚 Course: {courseDisplay}" & vbCrLf &
    $"📅 Period: {periodDisplay}" & vbCrLf & vbCrLf &
     $"Current total: {currentTotal:F2}%" & vbCrLf &
           $"Adding: {newWeight:F2}%" & vbCrLf &
         $"New total: {newTotal:F2}% ✓" & vbCrLf & vbCrLf &
       $"🎯 This completes the grading structure for this period!" & vbCrLf &
  $"   All assignment types are now configured." & vbCrLf & vbCrLf &
      $"Continue with this weight configuration?",
        "100% Weight Achieved",
       MessageBoxButtons.YesNo,
     MessageBoxIcon.Information)

                    If perfectResult = DialogResult.No Then
                        Return
                    End If

                ElseIf newTotal < 100 Then
                    ' LESS THAN 100% - Show remaining and warn
                    Dim remainingResult As DialogResult = MessageBox.Show(
              $"⚠️ INCOMPLETE WEIGHT ALLOCATION" & vbCrLf & vbCrLf &
$"📚 Course: {courseDisplay}" & vbCrLf &
         $"📅 Period: {periodDisplay}" & vbCrLf & vbCrLf &
         $"Current total: {currentTotal:F2}%" & vbCrLf &
 $"Adding: {newWeight:F2}%" & vbCrLf &
 $"New total: {newTotal:F2}%" & vbCrLf & vbCrLf &
              $"📊 Remaining to allocate: {remaining:F2}%" & vbCrLf & vbCrLf &
      $"💡 Reminder: Total weight MUST equal 100% to be complete." & vbCrLf &
$"   You'll need to add more assignment types totaling {remaining:F2}%." & vbCrLf & vbCrLf &
            $"Continue adding this weight?",
           "Weight Incomplete",
          MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

                    If remainingResult = DialogResult.No Then
                        Return
                    End If
                End If

                ' Insert new weight
                Dim insertQuery As String = "INSERT INTO Offering_Grading_Weights " &
               "(offering_id, type_id, period_id, custom_weight, max_score, notes, created_at, updated_at) " &
   "VALUES (@offering_id, @type_id, @period_id, @custom_weight, @max_score, @notes, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@offering_id", offeringId)
                    insertCmd.Parameters.AddWithValue("@type_id", typeId)
                    insertCmd.Parameters.AddWithValue("@period_id", periodId)
                    insertCmd.Parameters.AddWithValue("@custom_weight", newWeight)
                    insertCmd.Parameters.AddWithValue("@max_score", Convert.ToDecimal(txtMaxScore.Text.Trim()))
                    insertCmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(txtNotes.Text), DBNull.Value, CType(txtNotes.Text.Trim(), Object)))

                    insertCmd.ExecuteNonQuery()
                End Using

                ' Show success message with updated totals
                Dim successIcon As MessageBoxIcon = If(newTotal = 100, MessageBoxIcon.Information, MessageBoxIcon.Warning)
                Dim statusEmoji As String = If(newTotal = 100, "✅", "⚠️")

                MessageBox.Show(
 $"{statusEmoji} Offering grade weight created successfully!" & vbCrLf & vbCrLf &
          $"Assignment Type: {cmbAssignmentType.Text}" & vbCrLf &
           $"Weight: {newWeight:F2}%" & vbCrLf &
   $"Max Score: {txtMaxScore.Text.Trim()}" & vbCrLf & vbCrLf &
              $"📊 WEIGHT SUMMARY for {periodDisplay}:" & vbCrLf &
        $"   Total Allocated: {newTotal:F2}%" & vbCrLf &
          $"   Remaining: {remaining:F2}%" & vbCrLf &
          If(newTotal = 100, vbCrLf & "🎯 COMPLETE - 100% allocated!", ""),
      "Success",
                    MessageBoxButtons.OK,
              successIcon)

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

                ' Calculate completion statistics
                Dim statsQuery As String = "SELECT " &
       "COUNT(DISTINCT CONCAT(offering_id, '-', IFNULL(period_id, 'NULL'))) as total_configs, " &
      "SUM(CASE WHEN total_weight = 100 THEN 1 ELSE 0 END) as complete_configs " &
          "FROM ( " &
           "    SELECT offering_id, period_id, SUM(custom_weight) as total_weight " &
     "    FROM Offering_Grading_Weights " &
  "    GROUP BY offering_id, period_id " &
        ") AS weight_totals"

                Using statsCmd As New MySqlCommand(statsQuery, connection)
                    Using reader = statsCmd.ExecuteReader()
                        If reader.Read() Then
                            Dim totalConfigs As Integer = If(IsDBNull(reader("total_configs")), 0, Convert.ToInt32(reader("total_configs")))
                            Dim completeConfigs As Integer = If(IsDBNull(reader("complete_configs")), 0, Convert.ToInt32(reader("complete_configs")))
                            Dim incompleteConfigs As Integer = totalConfigs - completeConfigs

                            ' Update title with completion stats
                            lblViewTitle.Text = $"All Offering Grade Weights " &
       $"(✅ Complete: {completeConfigs} | ⚠️ Incomplete: {incompleteConfigs})"

                            ' Color code based on completion
                            If incompleteConfigs = 0 AndAlso totalConfigs > 0 Then
                                lblViewTitle.ForeColor = Color.FromArgb(0, 122, 204) ' Blue - All complete
                            ElseIf incompleteConfigs > 0 Then
                                lblViewTitle.ForeColor = Color.FromArgb(255, 140, 0) ' Orange - Some incomplete
                            Else
                                lblViewTitle.ForeColor = Color.FromArgb(0, 122, 204) ' Blue - No data
                            End If
                        End If
                    End Using
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

        Try
            Dim selectedWeightId As Integer = Convert.ToInt32(cmbSelectWeight.SelectedValue)

            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Get period_id
                Dim periodId As Object = DBNull.Value
                Dim periodDisplay As String = "All Periods"
                If cmbUpdateGradingPeriod.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbUpdateGradingPeriod.SelectedValue) Then
                    periodId = cmbUpdateGradingPeriod.SelectedValue
                    periodDisplay = cmbUpdateGradingPeriod.Text
                End If

                ' Get the new weight value
                Dim newWeight As Decimal = Convert.ToDecimal(txtUpdateCustomWeight.Text.Trim())

                ' Get the OLD weight for this record
                Dim oldWeight As Decimal = 0
                Dim oldQuery As String = "SELECT custom_weight FROM Offering_Grading_Weights WHERE weight_id = @weight_id"
                Using oldCmd As New MySqlCommand(oldQuery, connection)
                    oldCmd.Parameters.AddWithValue("@weight_id", selectedWeightId)
                    oldWeight = Convert.ToDecimal(oldCmd.ExecuteScalar())
                End Using

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

                ' ============= VALIDATE 100% TOTAL WEIGHT =============
                ' Calculate current total weight EXCLUDING this weight entry
                Dim totalOthersQuery As String = "SELECT COALESCE(SUM(custom_weight), 0) " &
"FROM Offering_Grading_Weights " &
   "WHERE offering_id = @offering_id " &
  "AND (@period_id IS NULL AND period_id IS NULL OR period_id = @period_id) " &
  "AND weight_id != @weight_id"

                Dim totalOthers As Decimal = 0
                Using totalCmd As New MySqlCommand(totalOthersQuery, connection)
                    totalCmd.Parameters.AddWithValue("@offering_id", offeringId)
                    totalCmd.Parameters.AddWithValue("@period_id", periodId)
                    totalCmd.Parameters.AddWithValue("@weight_id", selectedWeightId)
                    totalOthers = Convert.ToDecimal(totalCmd.ExecuteScalar())
                End Using

                Dim newTotal As Decimal = totalOthers + newWeight
                Dim remaining As Decimal = 100 - newTotal

                ' Get course name for better display
                Dim courseDisplay As String = cmbUpdateOffering.Text

                ' Show validation warning based on total
                If newTotal > 100 Then
                    ' EXCEEDS 100% - Not allowed
                    MessageBox.Show(
   $"❌ WEIGHT VALIDATION ERROR" & vbCrLf & vbCrLf &
            $"📚 Course: {courseDisplay}" & vbCrLf &
  $"📅 Period: {periodDisplay}" & vbCrLf & vbCrLf &
   $"Other types total: {totalOthers:F2}%" & vbCrLf &
 $"Updated weight: {newWeight:F2}%" & vbCrLf &
             $"New total would be: {newTotal:F2}%" & vbCrLf & vbCrLf &
   $"⚠️ Total weight CANNOT exceed 100%!" & vbCrLf & vbCrLf &
       $"💡 Available weight: {100 - totalOthers:F2}%" & vbCrLf &
          $"   Maximum allowed for this type: {100 - totalOthers:F2}%",
  "Weight Exceeds 100%",
  MessageBoxButtons.OK,
      MessageBoxIcon.Error)
                    Return

                ElseIf newTotal = 100 Then
                    ' PERFECT 100% - Confirm
                    Dim perfectResult As DialogResult = MessageBox.Show(
      $"✅ PERFECT 100% ALLOCATION!" & vbCrLf & vbCrLf &
 $"📚 Course: {courseDisplay}" & vbCrLf &
  $"📅 Period: {periodDisplay}" & vbCrLf & vbCrLf &
$"Other types: {totalOthers:F2}%" & vbCrLf &
    $"This type: {newWeight:F2}%" & vbCrLf &
 $"New total: {newTotal:F2}% ✓" & vbCrLf & vbCrLf &
       $"🎯 This maintains the complete 100% grading structure!" & vbCrLf & vbCrLf &
   $"Continue with this update?",
    "100% Weight Maintained",
   MessageBoxButtons.YesNo,
           MessageBoxIcon.Information)

                    If perfectResult = DialogResult.No Then
                        Return
                    End If

                ElseIf newTotal < 100 Then
                    ' LESS THAN 100% - Show remaining and warn
                    Dim remainingResult As DialogResult = MessageBox.Show(
           $"⚠️ INCOMPLETE WEIGHT ALLOCATION" & vbCrLf & vbCrLf &
  $"📚 Course: {courseDisplay}" & vbCrLf &
        $"📅 Period: {periodDisplay}" & vbCrLf & vbCrLf &
         $"Other types: {totalOthers:F2}%" & vbCrLf &
   $"This type: {newWeight:F2}%" & vbCrLf &
    $"New total: {newTotal:F2}%" & vbCrLf & vbCrLf &
  $"📊 Remaining to allocate: {remaining:F2}%" & vbCrLf & vbCrLf &
         $"💡 Note: This will reduce the total weight below 100%." & vbCrLf &
 $"   Make sure to adjust other types to reach 100%." & vbCrLf & vbCrLf &
          $"Continue with this update?",
"Weight Incomplete",
   MessageBoxButtons.YesNo,
  MessageBoxIcon.Warning)

                    If remainingResult = DialogResult.No Then
                        Return
                    End If
                End If

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
                    updateCmd.Parameters.AddWithValue("@custom_weight", newWeight)
                    updateCmd.Parameters.AddWithValue("@max_score", Convert.ToDecimal(txtUpdateMaxScore.Text.Trim()))
                    updateCmd.Parameters.AddWithValue("@notes", If(String.IsNullOrWhiteSpace(txtUpdateNotes.Text), DBNull.Value, CType(txtUpdateNotes.Text.Trim(), Object)))
                    updateCmd.Parameters.AddWithValue("@weight_id", selectedWeightId)

                    updateCmd.ExecuteNonQuery()
                End Using

                ' Show success message with updated totals
                Dim successIcon As MessageBoxIcon = If(newTotal = 100, MessageBoxIcon.Information, MessageBoxIcon.Warning)
                Dim statusEmoji As String = If(newTotal = 100, "✅", "⚠️")

                MessageBox.Show(
        $"{statusEmoji} Offering grade weight updated successfully!" & vbCrLf & vbCrLf &
   $"📊 WEIGHT SUMMARY for {periodDisplay}:" & vbCrLf &
  $"   Total Allocated: {newTotal:F2}%" & vbCrLf &
       $"   Remaining: {remaining:F2}%" & vbCrLf &
   If(newTotal = 100, vbCrLf & "🎯 COMPLETE - 100% allocated!", ""),
       "Success",
    MessageBoxButtons.OK,
     successIcon)

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