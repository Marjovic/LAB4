Imports MySql.Data.MySqlClient

Public Class CourseSchedule
    ' Connection string - same as other forms
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=Sheamar@442211;"

    ' Store current schedule ID for update/delete
    Private currentScheduleId As Integer = 0

    Private Sub CourseSchedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Course Schedule Management - MGOD LMS"

        ' Initialize dropdowns
        InitializeOfferingDropdown()
        InitializeDayDropdown()
        InitializeRoomDropdown()
        InitializeScheduleTypeDropdown()

        ' Initialize time pickers with default times
        dtpStartTime.Value = DateTime.Today.AddHours(8) ' 8:00 AM
        dtpEndTime.Value = DateTime.Today.AddHours(10)   ' 10:00 AM
        dtpUpdateStartTime.Value = DateTime.Today.AddHours(8)
        dtpUpdateEndTime.Value = DateTime.Today.AddHours(10)

        ' Load schedules data
        LoadSchedulesData()
        LoadScheduleUpdateDropdown()

        ' Show View Schedules panel by default
        ShowPanel(pnlViewSchedules)
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlCreateSchedule.Visible = False
        pnlViewSchedules.Visible = False
        pnlUpdateDeleteSchedule.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        btnCreateSchedule.BackColor = Color.FromArgb(35, 35, 38)
        btnViewSchedules.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteSchedule.BackColor = Color.FromArgb(35, 35, 38)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    Private Sub btnCreateSchedule_Click(sender As Object, e As EventArgs) Handles btnCreateSchedule.Click
        ShowPanel(pnlCreateSchedule)
        SetActiveButton(btnCreateSchedule)
        ClearCreateScheduleForm()
    End Sub

    Private Sub btnViewSchedules_Click(sender As Object, e As EventArgs) Handles btnViewSchedules.Click
        ShowPanel(pnlViewSchedules)
        SetActiveButton(btnViewSchedules)
        LoadSchedulesData()
    End Sub

    Private Sub btnUpdateDeleteSchedule_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteSchedule.Click
        ShowPanel(pnlUpdateDeleteSchedule)
        SetActiveButton(btnUpdateDeleteSchedule)
        LoadScheduleUpdateDropdown()
        ClearUpdateForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= INITIALIZATION METHODS =============

    Private Sub InitializeOfferingDropdown()
        Try
          Using connection As New MySqlConnection(connectionString)
   connection.Open()
 Dim query As String = "SELECT co.offering_id, " &
     "CONCAT(c.course_code, ' - ', c.course_name, ' (Sec ', co.section, ') - ', " &
           "ay.academic_year_name, ' ', st.type_name, ' ', tt.type_name, " &
        "' - ', IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA')) as display_name " &
   "FROM Course_Offerings co " &
         "INNER JOIN Courses c ON co.course_id = c.course_id " &
     "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
       "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
         "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
          "INNER JOIN Terms t ON co.term_id = t.term_id " &
          "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
                 "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " &
        "WHERE co.offering_status != 'Cancelled' " &
      "ORDER BY ay.year_start DESC, st.display_order, tt.display_order, c.course_code, co.section"

         Using adapter As New MySqlDataAdapter(query, connection)
        Dim offeringTable As New DataTable()
     adapter.Fill(offeringTable)

        ' Bind to Create dropdown
                cmbOffering.DataSource = offeringTable.Copy()
    cmbOffering.DisplayMember = "display_name"
           cmbOffering.ValueMember = "offering_id"

     ' Bind to Update dropdown
        cmbUpdateOffering.DataSource = offeringTable.Copy()
            cmbUpdateOffering.DisplayMember = "display_name"
        cmbUpdateOffering.ValueMember = "offering_id"

        If cmbOffering.Items.Count > 0 Then cmbOffering.SelectedIndex = 0
         If cmbUpdateOffering.Items.Count > 0 Then cmbUpdateOffering.SelectedIndex = 0
          End Using
   End Using
   Catch ex As Exception
    MessageBox.Show($"Error loading course offerings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
     End Try
    End Sub

    Private Sub InitializeDayDropdown()
        Try
         Using connection As New MySqlConnection(connectionString)
          connection.Open()
   Dim query As String = "SELECT day_id, CONCAT(day_name, ' (', day_code, ')') as display_name " &
 "FROM Days_Of_Week " &
     "ORDER BY display_order"

             Using adapter As New MySqlDataAdapter(query, connection)
        Dim dayTable As New DataTable()
           adapter.Fill(dayTable)

         ' Bind to Create dropdown
   cmbDay.DataSource = dayTable.Copy()
       cmbDay.DisplayMember = "display_name"
 cmbDay.ValueMember = "day_id"

         ' Bind to Update dropdown
   cmbUpdateDay.DataSource = dayTable.Copy()
     cmbUpdateDay.DisplayMember = "display_name"
             cmbUpdateDay.ValueMember = "day_id"

            If cmbDay.Items.Count > 0 Then cmbDay.SelectedIndex = 0
       If cmbUpdateDay.Items.Count > 0 Then cmbUpdateDay.SelectedIndex = 0
   End Using
    End Using
        Catch ex As Exception
  MessageBox.Show($"Error loading days: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
    End Sub

    Private Sub InitializeRoomDropdown()
    Try
          Using connection As New MySqlConnection(connectionString)
    connection.Open()
          Dim query As String = "SELECT room_id, CONCAT(room_code, ' - ', room_name, ' (', building, ') - Cap: ', capacity, ' - ', room_type) as display_name " &
 "FROM Rooms " &
       "WHERE is_active = TRUE " &
              "ORDER BY building, room_code"

    Using adapter As New MySqlDataAdapter(query, connection)
            Dim roomTable As New DataTable()
   adapter.Fill(roomTable)

        ' Add "None" option
  Dim noneRow As DataRow = roomTable.NewRow()
      noneRow("room_id") = DBNull.Value
    noneRow("display_name") = "-- None (To Be Assigned) --"
       roomTable.Rows.InsertAt(noneRow, 0)

                  ' Bind to Create dropdown
 cmbRoom.DataSource = roomTable.Copy()
      cmbRoom.DisplayMember = "display_name"
   cmbRoom.ValueMember = "room_id"
cmbRoom.SelectedIndex = 0

 ' Bind to Update dropdown
         cmbUpdateRoom.DataSource = roomTable.Copy()
     cmbUpdateRoom.DisplayMember = "display_name"
        cmbUpdateRoom.ValueMember = "room_id"
       cmbUpdateRoom.SelectedIndex = 0
           End Using
  End Using
    Catch ex As Exception
 MessageBox.Show($"Error loading rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

 Private Sub InitializeScheduleTypeDropdown()
        ' Initialize Create schedule type
        cmbScheduleType.Items.Clear()
        cmbScheduleType.Items.AddRange(New String() {"Lecture", "Laboratory", "Recitation", "Online"})
  cmbScheduleType.SelectedIndex = 0

        ' Initialize Update schedule type
        cmbUpdateScheduleType.Items.Clear()
     cmbUpdateScheduleType.Items.AddRange(New String() {"Lecture", "Laboratory", "Recitation", "Online"})
        cmbUpdateScheduleType.SelectedIndex = 0
    End Sub

 ' ============= CREATE SCHEDULE METHODS =============

    Private Sub btnSubmitSchedule_Click(sender As Object, e As EventArgs) Handles btnSubmitSchedule.Click
        ' Validate required fields
        If cmbOffering.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a course offering.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
   Return
        End If

        If cmbDay.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a day of the week.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
         Return
        End If

        ' Validate time sequence
        If dtpEndTime.Value <= dtpStartTime.Value Then
            MessageBox.Show("End time must be after start time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    Return
     End If

 Try
  Using connection As New MySqlConnection(connectionString)
                connection.Open()

   ' Check for duplicate schedule
      Dim checkQuery As String = "SELECT COUNT(*) FROM Course_Schedules " &
        "WHERE offering_id = @offering_id AND day_id = @day_id " &
               "AND start_time = @start_time"
        Using checkCmd As New MySqlCommand(checkQuery, connection)
 checkCmd.Parameters.AddWithValue("@offering_id", Convert.ToInt32(cmbOffering.SelectedValue))
           checkCmd.Parameters.AddWithValue("@day_id", Convert.ToInt32(cmbDay.SelectedValue))
           checkCmd.Parameters.AddWithValue("@start_time", dtpStartTime.Value.ToString("HH:mm:ss"))

      Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
          If count > 0 Then
 MessageBox.Show("This schedule already exists for the selected offering, day, and start time.",
           "Duplicate Schedule", MessageBoxButtons.OK, MessageBoxIcon.Warning)
     Return
     End If
      End Using

    ' Get room ID (nullable)
                Dim roomId As Object = DBNull.Value
      If cmbRoom.SelectedIndex > 0 AndAlso cmbRoom.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbRoom.SelectedValue) Then
roomId = Convert.ToInt32(cmbRoom.SelectedValue)
  End If

    ' Insert new schedule
    Dim insertQuery As String = "INSERT INTO Course_Schedules " &
   "(offering_id, day_id, room_id, start_time, end_time, schedule_type, is_active, created_at, updated_at) " &
        "VALUES (@offering_id, @day_id, @room_id, @start_time, @end_time, @schedule_type, @is_active, NOW(), NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
               insertCmd.Parameters.AddWithValue("@offering_id", Convert.ToInt32(cmbOffering.SelectedValue))
            insertCmd.Parameters.AddWithValue("@day_id", Convert.ToInt32(cmbDay.SelectedValue))
      insertCmd.Parameters.AddWithValue("@room_id", roomId)
  insertCmd.Parameters.AddWithValue("@start_time", dtpStartTime.Value.ToString("HH:mm:ss"))
         insertCmd.Parameters.AddWithValue("@end_time", dtpEndTime.Value.ToString("HH:mm:ss"))
                 insertCmd.Parameters.AddWithValue("@schedule_type", cmbScheduleType.SelectedItem.ToString())
        insertCmd.Parameters.AddWithValue("@is_active", If(chkIsActive.Checked, 1, 0))

        insertCmd.ExecuteNonQuery()
            End Using

      MessageBox.Show("Course schedule created successfully!" & vbCrLf & vbCrLf &
            $"Offering: {cmbOffering.Text}" & vbCrLf &
             $"Day: {cmbDay.Text}" & vbCrLf &
  $"Time: {dtpStartTime.Value.ToString("hh:mm tt")} - {dtpEndTime.Value.ToString("hh:mm tt")}" & vbCrLf &
        $"Type: {cmbScheduleType.SelectedItem}",
      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
          ClearCreateScheduleForm()
              LoadSchedulesData()
        LoadScheduleUpdateDropdown()
      End Using
        Catch ex As MySqlException
   If ex.Number = 1062 Then
        MessageBox.Show("This schedule already exists.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    Else
        MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
 Catch ex As Exception
            MessageBox.Show($"Error creating schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateScheduleForm()
        If cmbOffering.Items.Count > 0 Then cmbOffering.SelectedIndex = 0
   If cmbDay.Items.Count > 0 Then cmbDay.SelectedIndex = 0
    If cmbRoom.Items.Count > 0 Then cmbRoom.SelectedIndex = 0
   If cmbScheduleType.Items.Count > 0 Then cmbScheduleType.SelectedIndex = 0
        dtpStartTime.Value = DateTime.Today.AddHours(8)
        dtpEndTime.Value = DateTime.Today.AddHours(10)
  chkIsActive.Checked = True
  End Sub

    ' ============= VIEW SCHEDULES METHODS =============

    Private Sub LoadSchedulesData()
        Try
      Using connection As New MySqlConnection(connectionString)
    connection.Open()

    Dim query As String = "SELECT cs.schedule_id as 'Schedule ID', " &
        "c.course_code as 'Course Code', " &
         "c.course_name as 'Course Name', " &
      "co.section as 'Section', " &
         "CONCAT(ay.academic_year_name, ' - ', st.type_name, ' ', tt.type_name) as 'Semester/Term', " &
     "dw.day_name as 'Day', " &
       "TIME_FORMAT(cs.start_time, '%h:%i %p') as 'Start Time', " &
      "TIME_FORMAT(cs.end_time, '%h:%i %p') as 'End Time', " &
          "IFNULL(CONCAT(r.room_code, ' - ', r.building), 'TBA') as 'Room', " &
       "cs.schedule_type as 'Type', " &
           "IF(cs.is_active = TRUE, 'Active', 'Inactive') as 'Status', " &
             "IFNULL(CONCAT(i.first_name, ' ', i.last_name), 'TBA') as 'Instructor' " &
        "FROM Course_Schedules cs " &
       "INNER JOIN Course_Offerings co ON cs.offering_id = co.offering_id " &
 "INNER JOIN Courses c ON co.course_id = c.course_id " &
              "INNER JOIN Semesters s ON co.semester_id = s.semester_id " &
         "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
         "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
          "INNER JOIN Terms t ON co.term_id = t.term_id " &
     "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
               "INNER JOIN Days_Of_Week dw ON cs.day_id = dw.day_id " &
       "LEFT JOIN Rooms r ON cs.room_id = r.room_id " &
          "LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id " &
         "ORDER BY ay.year_start DESC, st.display_order, tt.display_order, c.course_code, co.section, dw.display_order, cs.start_time"

        Using adapter As New MySqlDataAdapter(query, connection)
                    Dim schedulesTable As New DataTable()
    adapter.Fill(schedulesTable)
   dgvSchedules.DataSource = schedulesTable
      dgvSchedules.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
             End Using
            End Using
        Catch ex As Exception
     MessageBox.Show($"Error loading schedules: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshSchedules_Click(sender As Object, e As EventArgs) Handles btnRefreshSchedules.Click
    LoadSchedulesData()
  MessageBox.Show("Schedules data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

' ============= UPDATE/DELETE SCHEDULE METHODS =============

    Private Sub LoadScheduleUpdateDropdown()
        Try
     Using connection As New MySqlConnection(connectionString)
          connection.Open()
          Dim query As String = "SELECT cs.schedule_id, " &
         "CONCAT(c.course_code, ' - ', c.course_name, ' (Sec ', co.section, ') - ', " &
     "dw.day_name, ' ', TIME_FORMAT(cs.start_time, '%h:%i %p'), '-', TIME_FORMAT(cs.end_time, '%h:%i %p'), " &
          "' - ', cs.schedule_type) as display_name " &
    "FROM Course_Schedules cs " &
         "INNER JOIN Course_Offerings co ON cs.offering_id = co.offering_id " &
          "INNER JOIN Courses c ON co.course_id = c.course_id " &
        "INNER JOIN Days_Of_Week dw ON cs.day_id = dw.day_id " &
           "ORDER BY c.course_code, co.section, dw.display_order, cs.start_time"

             Using adapter As New MySqlDataAdapter(query, connection)
Dim scheduleTable As New DataTable()
     adapter.Fill(scheduleTable)
          cmbSelectSchedule.DataSource = scheduleTable
         cmbSelectSchedule.DisplayMember = "display_name"
            cmbSelectSchedule.ValueMember = "schedule_id"
       End Using
            End Using
        Catch ex As Exception
    MessageBox.Show($"Error loading schedules for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadScheduleData_Click(sender As Object, e As EventArgs) Handles btnLoadScheduleData.Click
        If cmbSelectSchedule.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a schedule to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
Return
   End If

        Try
            currentScheduleId = Convert.ToInt32(cmbSelectSchedule.SelectedValue)
      LoadScheduleDataForUpdate(currentScheduleId)
    Catch ex As Exception
         MessageBox.Show($"Error loading schedule data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadScheduleDataForUpdate(scheduleId As Integer)
     Try
    Using connection As New MySqlConnection(connectionString)
   connection.Open()

           Dim query As String = "SELECT offering_id, day_id, room_id, start_time, end_time, schedule_type, is_active " &
                  "FROM Course_Schedules WHERE schedule_id = @schedule_id"

         Using cmd As New MySqlCommand(query, connection)
        cmd.Parameters.AddWithValue("@schedule_id", scheduleId)

        Using reader As MySqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
  cmbUpdateOffering.SelectedValue = Convert.ToInt32(reader("offering_id"))
       cmbUpdateDay.SelectedValue = Convert.ToInt32(reader("day_id"))

   If IsDBNull(reader("room_id")) Then
cmbUpdateRoom.SelectedIndex = 0
         Else
            cmbUpdateRoom.SelectedValue = Convert.ToInt32(reader("room_id"))
     End If

           ' Parse time values
            Dim startTime As TimeSpan = CType(reader("start_time"), TimeSpan)
           Dim endTime As TimeSpan = CType(reader("end_time"), TimeSpan)
     dtpUpdateStartTime.Value = DateTime.Today.Add(startTime)
                   dtpUpdateEndTime.Value = DateTime.Today.Add(endTime)

             cmbUpdateScheduleType.SelectedItem = reader("schedule_type").ToString()
 chkUpdateIsActive.Checked = Convert.ToBoolean(reader("is_active"))

          grpScheduleInfo.Visible = True
          btnUpdateSchedule.Visible = True
     btnDeleteSchedule.Visible = True
       Else
  MessageBox.Show("Schedule data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
  End If
        End Using
                End Using
     End Using
        Catch ex As Exception
      MessageBox.Show($"Error loading schedule data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateSchedule_Click(sender As Object, e As EventArgs) Handles btnUpdateSchedule.Click
  If currentScheduleId = 0 Then
  MessageBox.Show("Please load a schedule first.", "No Schedule Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
     End If

        ' Validate time sequence
        If dtpUpdateEndTime.Value <= dtpUpdateStartTime.Value Then
    MessageBox.Show("End time must be after start time.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
      Return
     End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this course schedule?",
         "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
    Using connection As New MySqlConnection(connectionString)
         connection.Open()

       ' Get room ID (nullable)
         Dim roomId As Object = DBNull.Value
             If cmbUpdateRoom.SelectedIndex > 0 AndAlso cmbUpdateRoom.SelectedValue IsNot Nothing AndAlso Not IsDBNull(cmbUpdateRoom.SelectedValue) Then
      roomId = Convert.ToInt32(cmbUpdateRoom.SelectedValue)
End If

            ' Update schedule
     Dim updateQuery As String = "UPDATE Course_Schedules SET " &
    "offering_id = @offering_id, " &
     "day_id = @day_id, " &
          "room_id = @room_id, " &
            "start_time = @start_time, " &
 "end_time = @end_time, " &
          "schedule_type = @schedule_type, " &
      "is_active = @is_active, " &
      "updated_at = NOW() " &
           "WHERE schedule_id = @schedule_id"

         Using updateCmd As New MySqlCommand(updateQuery, connection)
      updateCmd.Parameters.AddWithValue("@offering_id", Convert.ToInt32(cmbUpdateOffering.SelectedValue))
     updateCmd.Parameters.AddWithValue("@day_id", Convert.ToInt32(cmbUpdateDay.SelectedValue))
 updateCmd.Parameters.AddWithValue("@room_id", roomId)
             updateCmd.Parameters.AddWithValue("@start_time", dtpUpdateStartTime.Value.ToString("HH:mm:ss"))
         updateCmd.Parameters.AddWithValue("@end_time", dtpUpdateEndTime.Value.ToString("HH:mm:ss"))
    updateCmd.Parameters.AddWithValue("@schedule_type", cmbUpdateScheduleType.SelectedItem.ToString())
      updateCmd.Parameters.AddWithValue("@is_active", If(chkUpdateIsActive.Checked, 1, 0))
       updateCmd.Parameters.AddWithValue("@schedule_id", currentScheduleId)

     updateCmd.ExecuteNonQuery()
         End Using

            MessageBox.Show("Course schedule updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

      ' Refresh data
      LoadSchedulesData()
             LoadScheduleUpdateDropdown()
         ClearUpdateForm()
    End Using
            Catch ex As Exception
       MessageBox.Show($"Error updating schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
  End If
    End Sub

    Private Sub btnDeleteSchedule_Click(sender As Object, e As EventArgs) Handles btnDeleteSchedule.Click
   If currentScheduleId = 0 Then
    MessageBox.Show("Please load a schedule first.", "No Schedule Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning)
   Return
        End If

        Dim selectedScheduleDisplay As String = cmbSelectSchedule.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete this course schedule?" & vbCrLf & vbCrLf &
          $"{selectedScheduleDisplay}" & vbCrLf & vbCrLf &
      "This action cannot be undone.",
      "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
   Try
     Using connection As New MySqlConnection(connectionString)
          connection.Open()

             Dim deleteQuery As String = "DELETE FROM Course_Schedules WHERE schedule_id = @schedule_id"

      Using deleteCmd As New MySqlCommand(deleteQuery, connection)
     deleteCmd.Parameters.AddWithValue("@schedule_id", currentScheduleId)

      Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

         If rowsAffected > 0 Then
    MessageBox.Show($"Course schedule deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    ' Refresh data
  LoadSchedulesData()
            LoadScheduleUpdateDropdown()
      ClearUpdateForm()
     Else
      MessageBox.Show("Failed to delete schedule. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  End If
     End Using
       End Using
         Catch ex As Exception
      MessageBox.Show($"Error deleting schedule: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
   End Try
      End If
    End Sub

    Private Sub ClearUpdateForm()
        currentScheduleId = 0
        dtpUpdateStartTime.Value = DateTime.Today.AddHours(8)
        dtpUpdateEndTime.Value = DateTime.Today.AddHours(10)
        chkUpdateIsActive.Checked = True
        grpScheduleInfo.Visible = False
        btnUpdateSchedule.Visible = False
        btnDeleteSchedule.Visible = False
 End Sub
End Class