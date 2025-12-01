Imports MySql.Data.MySqlClient
Imports System.Text.RegularExpressions

Public Class Enrollment
    ' Connection string
    Private connectionString As String = "Server=localhost;Database=db_alejado;Uid=root;Password=;"

    Private Sub Enrollment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form title
        Me.Text = "Enrollment Management - MGOD LMS"

        ' Only load data for View panels (these use designer controls that already exist)
        LoadSemestersData()

        ' Show View Semester panel by default
        ShowPanel(pnlViewSemester)

        ' Set initial button state
        SetActiveButton(btnViewSemester)
    End Sub

    ' ============= NAVIGATION METHODS =============

    Private Sub ShowPanel(panelToShow As Panel)
        ' Hide all panels
        pnlCreateSemester.Visible = False
        pnlViewSemester.Visible = False
        pnlUpdateDeleteSemester.Visible = False
        pnlCreateTerm.Visible = False
        pnlViewTerm.Visible = False
        pnlUpdateDeleteTerm.Visible = False

        ' Show selected panel
        panelToShow.Visible = True

        ' Update button colors
        ResetButtonColors()
    End Sub

    Private Sub ResetButtonColors()
        ' Semester Management submenu buttons
        btnCreateSemester.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteSemester.BackColor = Color.FromArgb(35, 35, 38)
        btnViewSemester.BackColor = Color.FromArgb(35, 35, 38)

        ' Term Management submenu buttons
        btnCreateTerm.BackColor = Color.FromArgb(35, 35, 38)
        btnUpdateDeleteTerm.BackColor = Color.FromArgb(35, 35, 38)
        btnViewTerm.BackColor = Color.FromArgb(35, 35, 38)

        ' Main buttons
        btnSemesterManagement.BackColor = Color.FromArgb(45, 45, 48)
        btnTermManagement.BackColor = Color.FromArgb(45, 45, 48)
    End Sub

    Private Sub SetActiveButton(btn As Button)
        btn.BackColor = Color.FromArgb(0, 122, 204)
    End Sub

    ' Semester Management Navigation
    Private Sub btnSemesterManagement_Click(sender As Object, e As EventArgs) Handles btnSemesterManagement.Click
        ' Toggle submenu visibility
        pnlSemesterSubmenu.Visible = Not pnlSemesterSubmenu.Visible
        ' Hide term submenu when semester is clicked
        If pnlSemesterSubmenu.Visible Then
            pnlTermSubmenu.Visible = False
        End If
    End Sub

    Private Sub btnCreateSemester_Click(sender As Object, e As EventArgs) Handles btnCreateSemester.Click
        ShowPanel(pnlCreateSemester)
        SetActiveButton(btnCreateSemester)
        SetActiveButton(btnSemesterManagement)
        InitializeCreateSemesterControls()
        ClearCreateSemesterForm()
    End Sub

    Private Sub btnViewSemester_Click(sender As Object, e As EventArgs) Handles btnViewSemester.Click
        ShowPanel(pnlViewSemester)
        SetActiveButton(btnViewSemester)
        SetActiveButton(btnSemesterManagement)
        LoadSemestersData()
    End Sub

    Private Sub btnUpdateDeleteSemester_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteSemester.Click
        ShowPanel(pnlUpdateDeleteSemester)
        SetActiveButton(btnUpdateDeleteSemester)
        SetActiveButton(btnSemesterManagement)
        InitializeUpdateSemesterControls()
        ClearUpdateSemesterForm()
    End Sub

    ' Term Management Navigation
    Private Sub btnTermManagement_Click(sender As Object, e As EventArgs) Handles btnTermManagement.Click
        ' Toggle submenu visibility
        pnlTermSubmenu.Visible = Not pnlTermSubmenu.Visible
        ' Hide semester submenu when term is clicked
        If pnlTermSubmenu.Visible Then
            pnlSemesterSubmenu.Visible = False
        End If
    End Sub

    Private Sub btnCreateTerm_Click(sender As Object, e As EventArgs) Handles btnCreateTerm.Click
        ShowPanel(pnlCreateTerm)
        SetActiveButton(btnCreateTerm)
        SetActiveButton(btnTermManagement)
        InitializeCreateTermControls()
        ClearCreateTermForm()
    End Sub

    Private Sub btnViewTerm_Click(sender As Object, e As EventArgs) Handles btnViewTerm.Click
        ShowPanel(pnlViewTerm)
        SetActiveButton(btnViewTerm)
        SetActiveButton(btnTermManagement)
        LoadTermsData()
    End Sub

    Private Sub btnUpdateDeleteTerm_Click(sender As Object, e As EventArgs) Handles btnUpdateDeleteTerm.Click
        ShowPanel(pnlUpdateDeleteTerm)
        SetActiveButton(btnUpdateDeleteTerm)
        SetActiveButton(btnTermManagement)
        InitializeUpdateTermControls()
        ClearUpdateTermForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ============= INITIALIZATION METHODS =============

    Private Sub InitializeAcademicYearDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT academic_year_id, academic_year_name, is_current " &
                                    "FROM Academic_Years " &
                                    "ORDER BY year_start DESC"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim yearTable As New DataTable()
                    adapter.Fill(yearTable)

                    ' Bind to Create Semester dropdown (only if it exists)
                    If cmbAcademicYear IsNot Nothing Then
                        cmbAcademicYear.DataSource = yearTable.Copy()
                        cmbAcademicYear.DisplayMember = "academic_year_name"
                        cmbAcademicYear.ValueMember = "academic_year_id"

                        ' Set to current academic year if available
                        For Each row As DataRow In yearTable.Rows
                            If Convert.ToBoolean(row("is_current")) Then
                                cmbAcademicYear.SelectedValue = row("academic_year_id")
                                Exit For
                            End If
                        Next
                    End If

                    ' Bind to Update Semester dropdown (only if it exists)
                    If cmbUpdateAcademicYear IsNot Nothing Then
                        cmbUpdateAcademicYear.DataSource = yearTable.Copy()
                        cmbUpdateAcademicYear.DisplayMember = "academic_year_name"
                        cmbUpdateAcademicYear.ValueMember = "academic_year_id"

                        ' Set to current academic year if available
                        For Each row As DataRow In yearTable.Rows
                            If Convert.ToBoolean(row("is_current")) Then
                                cmbUpdateAcademicYear.SelectedValue = row("academic_year_id")
                                Exit For
                            End If
                        Next
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading academic years: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeSemesterTypeDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT semester_type_id, type_name, type_code " &
                                    "FROM Semester_Types " &
                                    "ORDER BY display_order"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim typeTable As New DataTable()
                    adapter.Fill(typeTable)

                    ' Bind to Create Semester dropdown (only if it exists)
                    If cmbSemesterType IsNot Nothing Then
                        cmbSemesterType.DataSource = typeTable.Copy()
                        cmbSemesterType.DisplayMember = "type_name"
                        cmbSemesterType.ValueMember = "semester_type_id"

                        ' Set to first item if available
                        If cmbSemesterType.Items.Count > 0 Then
                            cmbSemesterType.SelectedIndex = 0
                        End If
                    End If

                    ' Bind to Update Semester dropdown (only if it exists)
                    If cmbUpdateSemesterType IsNot Nothing Then
                        cmbUpdateSemesterType.DataSource = typeTable.Copy()
                        cmbUpdateSemesterType.DisplayMember = "type_name"
                        cmbUpdateSemesterType.ValueMember = "semester_type_id"

                        ' Set to first item if available
                        If cmbUpdateSemesterType.Items.Count > 0 Then
                            cmbUpdateSemesterType.SelectedIndex = 0
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading semester types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeSemesterDropdownForTerms()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT s.semester_id, " &
             "CONCAT(ay.academic_year_name, ' - ', st.type_name) as display_name " &
           "FROM Semesters s " &
               "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
              "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                   "WHERE s.is_active = TRUE " &
            "ORDER BY ay.year_start DESC, st.display_order"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim semesterTable As New DataTable()
                    adapter.Fill(semesterTable)

                    ' Bind to Create Term dropdown (only if it exists)
                    If cmbTermSemester IsNot Nothing Then
                        If semesterTable.Rows.Count = 0 Then
                            MessageBox.Show("No active semesters found. Please create and activate a semester first before creating terms.", _
                           "No Active Semesters", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            cmbTermSemester.DataSource = Nothing
                            Return
                        End If

                        cmbTermSemester.DataSource = semesterTable.Copy()
                        cmbTermSemester.DisplayMember = "display_name"
                        cmbTermSemester.ValueMember = "semester_id"

                        If cmbTermSemester.Items.Count > 0 Then
                            cmbTermSemester.SelectedIndex = 0
                        End If
                    End If

                    ' Bind to Update Term dropdown (only if it exists)
                    If cmbUpdateTermSemester IsNot Nothing Then
                        If semesterTable.Rows.Count = 0 Then
                            cmbUpdateTermSemester.DataSource = Nothing
                            Return
                        End If

                        cmbUpdateTermSemester.DataSource = semesterTable.Copy()
                        cmbUpdateTermSemester.DisplayMember = "display_name"
                        cmbUpdateTermSemester.ValueMember = "semester_id"

                        If cmbUpdateTermSemester.Items.Count > 0 Then
                            cmbUpdateTermSemester.SelectedIndex = 0
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading semesters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeTermTypeDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT term_type_id, type_name, type_code " &
           "FROM Term_Types " &
         "ORDER BY display_order"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim typeTable As New DataTable()
                    adapter.Fill(typeTable)

                    ' Bind to Create Term dropdown (only if it exists)
                    If cmbTermType IsNot Nothing Then
                        cmbTermType.DataSource = typeTable.Copy()
                        cmbTermType.DisplayMember = "type_name"
                        cmbTermType.ValueMember = "term_type_id"

                        If cmbTermType.Items.Count > 0 Then
                            cmbTermType.SelectedIndex = 0
                        End If
                    End If

                    ' Bind to Update Term dropdown (only if it exists)
                    If cmbUpdateTermType IsNot Nothing Then
                        cmbUpdateTermType.DataSource = typeTable.Copy()
                        cmbUpdateTermType.DisplayMember = "type_name"
                        cmbUpdateTermType.ValueMember = "term_type_id"

                        If cmbUpdateTermType.Items.Count > 0 Then
                            cmbUpdateTermType.SelectedIndex = 0
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading term types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub InitializeCreateSemesterControls()
        ' Create and add controls dynamically for Create Semester panel
        pnlCreateSemester.Controls.Clear()

        ' Title Label (already exists in designer)
        Dim lblTitle As New Label With {
            .Text = "Create New Semester",
            .Font = New Font("Times New Roman", 20, FontStyle.Bold),
            .ForeColor = Color.FromArgb(0, 122, 204),
            .Location = New Point(30, 20),
            .AutoSize = True
        }
        pnlCreateSemester.Controls.Add(lblTitle)

        ' Academic Year
        Dim lblAcademicYear As New Label With {
            .Text = "Academic Year:",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 80),
            .Size = New Size(200, 25)
        }
        pnlCreateSemester.Controls.Add(lblAcademicYear)

        cmbAcademicYear = New ComboBox With {
            .Name = "cmbAcademicYear",
            .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 110),
            .Size = New Size(400, 30),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        pnlCreateSemester.Controls.Add(cmbAcademicYear)

        ' Semester Type
        Dim lblSemesterType As New Label With {
            .Text = "Semester Type:",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 150),
            .Size = New Size(200, 25)
        }
        pnlCreateSemester.Controls.Add(lblSemesterType)

        cmbSemesterType = New ComboBox With {
            .Name = "cmbSemesterType",
            .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 180),
            .Size = New Size(400, 30),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        pnlCreateSemester.Controls.Add(cmbSemesterType)

        ' Start Date
        Dim lblStartDate As New Label With {
            .Text = "Start Date:",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 220),
            .Size = New Size(200, 25)
        }
        pnlCreateSemester.Controls.Add(lblStartDate)

        dtpStartDate = New DateTimePicker With {
            .Name = "dtpStartDate",
            .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 250),
            .Size = New Size(400, 30),
            .Format = DateTimePickerFormat.Short
        }
        pnlCreateSemester.Controls.Add(dtpStartDate)

        ' End Date
        Dim lblEndDate As New Label With {
            .Text = "End Date:",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 290),
            .Size = New Size(200, 25)
        }
        pnlCreateSemester.Controls.Add(lblEndDate)

        dtpEndDate = New DateTimePicker With {
            .Name = "dtpEndDate",
            .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 320),
            .Size = New Size(400, 30),
            .Format = DateTimePickerFormat.Short
        }
        pnlCreateSemester.Controls.Add(dtpEndDate)

        ' Registration Start Date
        Dim lblRegStartDate As New Label With {
            .Text = "Registration Start Date (Optional):",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 360),
            .Size = New Size(300, 25)
        }
        pnlCreateSemester.Controls.Add(lblRegStartDate)

        dtpRegStartDate = New DateTimePicker With {
            .Name = "dtpRegStartDate",
            .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 390),
            .Size = New Size(400, 30),
            .Format = DateTimePickerFormat.Short
        }
        pnlCreateSemester.Controls.Add(dtpRegStartDate)

        ' Registration End Date
        Dim lblRegEndDate As New Label With {
            .Text = "Registration End Date (Optional):",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 430),
            .Size = New Size(300, 25)
        }
        pnlCreateSemester.Controls.Add(lblRegEndDate)

        dtpRegEndDate = New DateTimePicker With {
            .Name = "dtpRegEndDate",
            .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 460),
            .Size = New Size(400, 30),
            .Format = DateTimePickerFormat.Short
        }
        pnlCreateSemester.Controls.Add(dtpRegEndDate)

        ' Is Active Checkbox
        chkIsActive = New CheckBox With {
            .Name = "chkIsActive",
            .Text = "Set as Active Semester",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 510),
            .Size = New Size(300, 30),
            .Checked = False
        }
        pnlCreateSemester.Controls.Add(chkIsActive)

        ' Submit Button
        Dim btnSubmit As New Button With {
            .Name = "btnSubmitSemester",
            .Text = "Create Semester",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 560),
            .Size = New Size(200, 40),
            .BackColor = Color.FromArgb(0, 122, 204),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnSubmit.Click, AddressOf btnSubmitSemester_Click
        pnlCreateSemester.Controls.Add(btnSubmit)

        ' Reinitialize dropdowns
        InitializeAcademicYearDropdown()
        InitializeSemesterTypeDropdown()
    End Sub

    Private Sub InitializeUpdateSemesterControls()
        ' Clear existing controls except title
        Dim controlsToRemove As New List(Of Control)()
        For Each ctrl As Control In pnlUpdateDeleteSemester.Controls
            If TypeOf ctrl IsNot Label OrElse ctrl.Name <> "lblUpdateDeleteSemesterTitle" Then
                controlsToRemove.Add(ctrl)
            End If
        Next

        For Each ctrl As Control In controlsToRemove
            pnlUpdateDeleteSemester.Controls.Remove(ctrl)
        Next

        ' Select Semester Dropdown
        Dim lblSelectSemester As New Label With {
            .Text = "Select Semester to Update/Delete:",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 80),
            .Size = New Size(300, 25)
        }
        pnlUpdateDeleteSemester.Controls.Add(lblSelectSemester)

        cmbSelectSemester = New ComboBox With {
            .Name = "cmbSelectSemester",
            .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 110),
            .Size = New Size(500, 30),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        pnlUpdateDeleteSemester.Controls.Add(cmbSelectSemester)

        ' Load Button
        Dim btnLoad As New Button With {
            .Name = "btnLoadSemesterData",
            .Text = "Load Semester Data",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(540, 110),
            .Size = New Size(200, 30),
            .BackColor = Color.FromArgb(0, 122, 204),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnLoad.Click, AddressOf btnLoadSemesterData_Click
        pnlUpdateDeleteSemester.Controls.Add(btnLoad)

        ' Group Box for semester details
        grpSemesterInfo = New GroupBox With {
            .Name = "grpSemesterInfo",
            .Text = "Semester Information",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 160),
            .Size = New Size(750, 500),
            .Visible = False
        }
        pnlUpdateDeleteSemester.Controls.Add(grpSemesterInfo)

        ' Academic Year (Update)
        Dim lblUpdateAcademicYear As New Label With {
            .Text = "Academic Year:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 40),
            .Size = New Size(200, 25)
        }
        grpSemesterInfo.Controls.Add(lblUpdateAcademicYear)

        cmbUpdateAcademicYear = New ComboBox With {
            .Name = "cmbUpdateAcademicYear",
            .Font = New Font("Times New Roman", 11),
            .Location = New Point(20, 70),
            .Size = New Size(350, 30),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpSemesterInfo.Controls.Add(cmbUpdateAcademicYear)

        ' Semester Type (Update)
        Dim lblUpdateSemesterType As New Label With {
            .Text = "Semester Type:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 110),
            .Size = New Size(200, 25)
        }
        grpSemesterInfo.Controls.Add(lblUpdateSemesterType)

        cmbUpdateSemesterType = New ComboBox With {
            .Name = "cmbUpdateSemesterType",
            .Font = New Font("Times New Roman", 11),
            .Location = New Point(20, 140),
            .Size = New Size(350, 30),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpSemesterInfo.Controls.Add(cmbUpdateSemesterType)

        ' Update Start Date
        Dim lblUpdateStartDate As New Label With {
            .Text = "Start Date:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 180),
            .Size = New Size(200, 25)
        }
        grpSemesterInfo.Controls.Add(lblUpdateStartDate)

        dtpUpdateStartDate = New DateTimePicker With {
            .Name = "dtpUpdateStartDate",
            .Font = New Font("Times New Roman", 11),
            .Location = New Point(20, 210),
            .Size = New Size(350, 30),
            .Format = DateTimePickerFormat.Short
        }
        grpSemesterInfo.Controls.Add(dtpUpdateStartDate)

        ' Update End Date
        Dim lblUpdateEndDate As New Label With {
            .Text = "End Date:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 250),
            .Size = New Size(200, 25)
        }
        grpSemesterInfo.Controls.Add(lblUpdateEndDate)

        dtpUpdateEndDate = New DateTimePicker With {
            .Name = "dtpUpdateEndDate",
            .Font = New Font("Times New Roman", 11),
            .Location = New Point(20, 280),
            .Size = New Size(350, 30),
            .Format = DateTimePickerFormat.Short
        }
        grpSemesterInfo.Controls.Add(dtpUpdateEndDate)

        ' Update Registration Start Date
        Dim lblUpdateRegStartDate As New Label With {
            .Text = "Registration Start Date:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 320),
            .Size = New Size(250, 25)
        }
        grpSemesterInfo.Controls.Add(lblUpdateRegStartDate)

        dtpUpdateRegStartDate = New DateTimePicker With {
            .Name = "dtpUpdateRegStartDate",
            .Font = New Font("Times New Roman", 11),
            .Location = New Point(20, 350),
            .Size = New Size(350, 30),
            .Format = DateTimePickerFormat.Short
        }
        grpSemesterInfo.Controls.Add(dtpUpdateRegStartDate)

        ' Update Registration End Date
        Dim lblUpdateRegEndDate As New Label With {
            .Text = "Registration End Date:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 390),
            .Size = New Size(250, 25)
        }
        grpSemesterInfo.Controls.Add(lblUpdateRegEndDate)

        dtpUpdateRegEndDate = New DateTimePicker With {
            .Name = "dtpUpdateRegEndDate",
            .Font = New Font("Times New Roman", 11),
            .Location = New Point(20, 420),
            .Size = New Size(350, 30),
            .Format = DateTimePickerFormat.Short
        }
        grpSemesterInfo.Controls.Add(dtpUpdateRegEndDate)

        ' Update Is Active Checkbox
        chkUpdateIsActive = New CheckBox With {
            .Name = "chkUpdateIsActive",
            .Text = "Set as Active Semester",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(400, 70),
            .Size = New Size(250, 30)
        }
        grpSemesterInfo.Controls.Add(chkUpdateIsActive)

        ' Update Button
        Dim btnUpdate As New Button With {
            .Name = "btnUpdateSemester",
            .Text = "Update Semester",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(400, 150),
            .Size = New Size(200, 40),
            .BackColor = Color.FromArgb(0, 122, 204),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnUpdate.Click, AddressOf btnUpdateSemester_Click
        grpSemesterInfo.Controls.Add(btnUpdate)

        ' Delete Button
        Dim btnDelete As New Button With {
            .Name = "btnDeleteSemester",
            .Text = "Delete Semester",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(400, 200),
            .Size = New Size(200, 40),
            .BackColor = Color.FromArgb(192, 0, 0),
            .ForeColor = Color.White,
            .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnDelete.Click, AddressOf btnDeleteSemester_Click
        grpSemesterInfo.Controls.Add(btnDelete)

        ' Reinitialize dropdowns
        InitializeAcademicYearDropdown()
        InitializeSemesterTypeDropdown()
        LoadSemesterUpdateDropdown()  ' FIX: Changed from LoadTermUpdateDropdown()
    End Sub

    Private Sub InitializeCreateTermControls()
        ' Create and add controls dynamically for Create Term panel
        pnlCreateTerm.Controls.Clear()

        ' Title Label
        Dim lblTitle As New Label With {
     .Text = "Create New Term",
      .Font = New Font("Times New Roman", 20, FontStyle.Bold),
               .ForeColor = Color.FromArgb(0, 122, 204),
          .Location = New Point(30, 20),
               .AutoSize = True
           }
        pnlCreateTerm.Controls.Add(lblTitle)

        ' Semester
        Dim lblSemester As New Label With {
          .Text = "Semester:",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
   .Location = New Point(30, 80),
            .Size = New Size(200, 25)
   }
        pnlCreateTerm.Controls.Add(lblSemester)

        cmbTermSemester = New ComboBox With {
            .Name = "cmbTermSemester",
       .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 110),
            .Size = New Size(400, 30),
            .DropDownStyle = ComboBoxStyle.DropDownList
 }
        pnlCreateTerm.Controls.Add(cmbTermSemester)

        ' Term Type
        Dim lblTermType As New Label With {
              .Text = "Term Type:",
          .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 150),
   .Size = New Size(200, 25)
   }
        pnlCreateTerm.Controls.Add(lblTermType)

        cmbTermType = New ComboBox With {
 .Name = "cmbTermType",
    .Font = New Font("Times New Roman", 12),
        .Location = New Point(30, 180),
        .Size = New Size(400, 30),
  .DropDownStyle = ComboBoxStyle.DropDownList
   }
        pnlCreateTerm.Controls.Add(cmbTermType)

        ' Start Date
        Dim lblTermStartDate As New Label With {
            .Text = "Start Date:",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
.Location = New Point(30, 220),
   .Size = New Size(200, 25)
        }
        pnlCreateTerm.Controls.Add(lblTermStartDate)

        dtpTermStartDate = New DateTimePicker With {
   .Name = "dtpTermStartDate",
            .Font = New Font("Times New Roman", 12),
     .Location = New Point(30, 250),
        .Size = New Size(400, 30),
       .Format = DateTimePickerFormat.Short
        }
        pnlCreateTerm.Controls.Add(dtpTermStartDate)

        ' End Date
        Dim lblTermEndDate As New Label With {
       .Text = "End Date:",
      .Font = New Font("Times New Roman", 12, FontStyle.Bold),
                .Location = New Point(30, 290),
        .Size = New Size(200, 25)
     }
        pnlCreateTerm.Controls.Add(lblTermEndDate)

        dtpTermEndDate = New DateTimePicker With {
    .Name = "dtpTermEndDate",
      .Font = New Font("Times New Roman", 12),
            .Location = New Point(30, 320),
     .Size = New Size(400, 30),
            .Format = DateTimePickerFormat.Short
        }
        pnlCreateTerm.Controls.Add(dtpTermEndDate)

        ' Is Active Checkbox
        chkTermIsActive = New CheckBox With {
  .Name = "chkTermIsActive",
            .Text = "Set as Active Term",
    .Font = New Font("Times New Roman", 12, FontStyle.Bold),
  .Location = New Point(30, 370),
         .Size = New Size(300, 30),
  .Checked = False
        }
        pnlCreateTerm.Controls.Add(chkTermIsActive)

        ' Submit Button
        Dim btnSubmit As New Button With {
            .Name = "btnSubmitTerm",
            .Text = "Create Term",
      .Font = New Font("Times New Roman", 12, FontStyle.Bold),
        .Location = New Point(30, 420),
            .Size = New Size(200, 40),
      .BackColor = Color.FromArgb(0, 122, 204),
     .ForeColor = Color.White,
  .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnSubmit.Click, AddressOf btnSubmitTerm_Click
        pnlCreateTerm.Controls.Add(btnSubmit)

        ' Reinitialize dropdowns
        InitializeSemesterDropdownForTerms()
        InitializeTermTypeDropdown()
    End Sub

    Private Sub InitializeUpdateTermControls()
        ' Clear existing controls except title
        Dim controlsToRemove As New List(Of Control)()
        For Each ctrl As Control In pnlUpdateDeleteTerm.Controls
            If TypeOf ctrl IsNot Label OrElse ctrl.Name <> "lblUpdateDeleteTermTitle" Then
                controlsToRemove.Add(ctrl)
            End If
        Next

        For Each ctrl As Control In controlsToRemove
            pnlUpdateDeleteTerm.Controls.Remove(ctrl)
        Next

        ' Select Term Dropdown
        Dim lblSelectTerm As New Label With {
            .Text = "Select Term to Update/Delete:",
       .Font = New Font("Times New Roman", 12, FontStyle.Bold),
  .Location = New Point(30, 80),
      .Size = New Size(300, 25)
        }
        pnlUpdateDeleteTerm.Controls.Add(lblSelectTerm)

        cmbSelectTerm = New ComboBox With {
 .Name = "cmbSelectTerm",
       .Font = New Font("Times New Roman", 12),
       .Location = New Point(30, 110),
  .Size = New Size(500, 30),
  .DropDownStyle = ComboBoxStyle.DropDownList
     }
        pnlUpdateDeleteTerm.Controls.Add(cmbSelectTerm)

        ' Load Button
        Dim btnLoad As New Button With {
        .Name = "btnLoadTermData",
            .Text = "Load Term Data",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(540, 110),
            .Size = New Size(200, 30),
.BackColor = Color.FromArgb(0, 122, 204),
  .ForeColor = Color.White,
    .FlatStyle = FlatStyle.Flat
  }
        AddHandler btnLoad.Click, AddressOf btnLoadTermData_Click
        pnlUpdateDeleteTerm.Controls.Add(btnLoad)

        ' Group Box for term details
        grpTermInfo = New GroupBox With {
      .Name = "grpTermInfo",
            .Text = "Term Information",
            .Font = New Font("Times New Roman", 12, FontStyle.Bold),
            .Location = New Point(30, 160),
            .Size = New Size(750, 400),
        .Visible = False
        }
        pnlUpdateDeleteTerm.Controls.Add(grpTermInfo)

        ' Semester (Update)
        Dim lblUpdateSemester As New Label With {
          .Text = "Semester:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 40),
            .Size = New Size(200, 25)
        }
        grpTermInfo.Controls.Add(lblUpdateSemester)

        cmbUpdateTermSemester = New ComboBox With {
       .Name = "cmbUpdateTermSemester",
          .Font = New Font("Times New Roman", 11),
            .Location = New Point(20, 70),
            .Size = New Size(350, 30),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        grpTermInfo.Controls.Add(cmbUpdateTermSemester)

        ' Term Type (Update)
        Dim lblUpdateTermType As New Label With {
      .Text = "Term Type:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
     .Location = New Point(20, 110),
        .Size = New Size(200, 25)
        }
        grpTermInfo.Controls.Add(lblUpdateTermType)

        cmbUpdateTermType = New ComboBox With {
            .Name = "cmbUpdateTermType",
            .Font = New Font("Times New Roman", 11),
      .Location = New Point(20, 140),
            .Size = New Size(350, 30),
       .DropDownStyle = ComboBoxStyle.DropDownList
    }
        grpTermInfo.Controls.Add(cmbUpdateTermType)

        ' Update Start Date
        Dim lblUpdateTermStartDate As New Label With {
          .Text = "Start Date:",
               .Font = New Font("Times New Roman", 11, FontStyle.Bold),
      .Location = New Point(20, 180),
       .Size = New Size(200, 25)
           }
        grpTermInfo.Controls.Add(lblUpdateTermStartDate)

        dtpUpdateTermStartDate = New DateTimePicker With {
           .Name = "dtpUpdateTermStartDate",
               .Font = New Font("Times New Roman", 11),
             .Location = New Point(20, 210),
                   .Size = New Size(350, 30),
         .Format = DateTimePickerFormat.Short
               }
        grpTermInfo.Controls.Add(dtpUpdateTermStartDate)

        ' Update End Date
        Dim lblUpdateTermEndDate As New Label With {
            .Text = "End Date:",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
            .Location = New Point(20, 250),
    .Size = New Size(200, 25)
        }
        grpTermInfo.Controls.Add(lblUpdateTermEndDate)

        dtpUpdateTermEndDate = New DateTimePicker With {
          .Name = "dtpUpdateTermEndDate",
              .Font = New Font("Times New Roman", 11),
  .Location = New Point(20, 280),
          .Size = New Size(350, 30),
          .Format = DateTimePickerFormat.Short
          }
        grpTermInfo.Controls.Add(dtpUpdateTermEndDate)

        ' Update Is Active Checkbox
        chkUpdateTermIsActive = New CheckBox With {
    .Name = "chkUpdateTermIsActive",
   .Text = "Set as Active Term",
            .Font = New Font("Times New Roman", 11, FontStyle.Bold),
     .Location = New Point(400, 70),
            .Size = New Size(250, 30)
        }
        grpTermInfo.Controls.Add(chkUpdateTermIsActive)

        ' Update Button
        Dim btnUpdate As New Button With {
  .Name = "btnUpdateTerm",
        .Text = "Update Term",
              .Font = New Font("Times New Roman", 12, FontStyle.Bold),
        .Location = New Point(400, 150),
       .Size = New Size(200, 40),
            .BackColor = Color.FromArgb(0, 122, 204),
              .ForeColor = Color.White,
     .FlatStyle = FlatStyle.Flat
   }
        AddHandler btnUpdate.Click, AddressOf btnUpdateTerm_Click
        grpTermInfo.Controls.Add(btnUpdate)

        ' Delete Button
        Dim btnDelete As New Button With {
          .Name = "btnDeleteTerm",
         .Text = "Delete Term",
  .Font = New Font("Times New Roman", 12, FontStyle.Bold),
        .Location = New Point(400, 200),
    .Size = New Size(200, 40),
      .BackColor = Color.FromArgb(192, 0, 0),
      .ForeColor = Color.White,
           .FlatStyle = FlatStyle.Flat
        }
        AddHandler btnDelete.Click, AddressOf btnDeleteTerm_Click
        grpTermInfo.Controls.Add(btnDelete)

        ' Reinitialize dropdowns
        InitializeSemesterDropdownForTerms()
        InitializeTermTypeDropdown()
        LoadTermUpdateDropdown()
    End Sub

    ' Control declarations
    Private WithEvents cmbAcademicYear As ComboBox
    Private WithEvents cmbSemesterType As ComboBox
    Private WithEvents dtpStartDate As DateTimePicker
    Private WithEvents dtpEndDate As DateTimePicker
    Private WithEvents dtpRegStartDate As DateTimePicker
    Private WithEvents dtpRegEndDate As DateTimePicker
    Private WithEvents chkIsActive As CheckBox

    Private WithEvents cmbSelectSemester As ComboBox
    Private WithEvents cmbUpdateAcademicYear As ComboBox
    Private WithEvents cmbUpdateSemesterType As ComboBox
    Private WithEvents dtpUpdateStartDate As DateTimePicker
    Private WithEvents dtpUpdateEndDate As DateTimePicker
    Private WithEvents dtpUpdateRegStartDate As DateTimePicker
    Private WithEvents dtpUpdateRegEndDate As DateTimePicker
    Private WithEvents chkUpdateIsActive As CheckBox
    Private WithEvents grpSemesterInfo As GroupBox

    ' Term Control declarations
    Private WithEvents cmbTermSemester As ComboBox
    Private WithEvents cmbTermType As ComboBox
    Private WithEvents dtpTermStartDate As DateTimePicker
    Private WithEvents dtpTermEndDate As DateTimePicker
    Private WithEvents chkTermIsActive As CheckBox

    Private WithEvents cmbSelectTerm As ComboBox
    Private WithEvents cmbUpdateTermSemester As ComboBox
    Private WithEvents cmbUpdateTermType As ComboBox
    Private WithEvents dtpUpdateTermStartDate As DateTimePicker
    Private WithEvents dtpUpdateTermEndDate As DateTimePicker
    Private WithEvents chkUpdateTermIsActive As CheckBox
    Private WithEvents grpTermInfo As GroupBox

    ' ============= CREATE SEMESTER METHODS =============

    Private Sub btnSubmitSemester_Click(sender As Object, e As EventArgs)
        ' Validate input
        If cmbAcademicYear.SelectedValue Is Nothing Then
            MessageBox.Show("Please select an Academic Year.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbSemesterType.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a Semester Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get academic year date range
        Dim academicYearStart As Date
        Dim academicYearEnd As Date

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim ayQuery As String = "SELECT year_start, year_end FROM Academic_Years WHERE academic_year_id = @academic_year_id"
                Using ayCmd As New MySqlCommand(ayQuery, connection)
                    ayCmd.Parameters.AddWithValue("@academic_year_id", Convert.ToInt32(cmbAcademicYear.SelectedValue))
                    Using reader As MySqlDataReader = ayCmd.ExecuteReader()
                        If reader.Read() Then
                            Dim yearStart As Integer = Convert.ToInt32(reader("year_start"))
                            Dim yearEnd As Integer = Convert.ToInt32(reader("year_end"))
                            academicYearStart = New Date(yearStart, 1, 1)  ' January 1 of start year
                            academicYearEnd = New Date(yearEnd, 12, 31)     ' December 31 of end year
                        Else
                            MessageBox.Show("Unable to retrieve academic year information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving academic year dates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Validate semester dates fall within academic year
        If dtpStartDate.Value.Date < academicYearStart OrElse dtpStartDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Semester Start Date must be within the Academic Year period:" & vbCrLf & _
               $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpStartDate.Focus()
            Return
        End If

        If dtpEndDate.Value.Date < academicYearStart OrElse dtpEndDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Semester End Date must be within the Academic Year period:" & vbCrLf & _
    $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
 "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpEndDate.Focus()
            Return
        End If

        ' Validate end date is after start date
        If dtpEndDate.Value.Date <= dtpStartDate.Value.Date Then
            MessageBox.Show("Semester End Date must be after Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpEndDate.Focus()
            Return
        End If

        ' Validate registration dates are BEFORE semester start date
        If dtpRegStartDate.Value.Date >= dtpStartDate.Value.Date Then
            MessageBox.Show("Registration Start Date must be BEFORE the Semester Start Date." & vbCrLf & _
        "Students must register before classes begin.",
        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpRegStartDate.Focus()
            Return
        End If

        If dtpRegEndDate.Value.Date >= dtpStartDate.Value.Date Then
            MessageBox.Show("Registration End Date must be BEFORE the Semester Start Date." & vbCrLf & _
 "Registration must close before classes begin.",
           "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpRegEndDate.Focus()
            Return
        End If

        ' Validate registration end date is after or equal to registration start date
        If dtpRegEndDate.Value.Date < dtpRegStartDate.Value.Date Then
            MessageBox.Show("Registration End Date must be on or after Registration Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpRegEndDate.Focus()
            Return
        End If

        ' Validate registration dates are within academic year
        If dtpRegStartDate.Value.Date < academicYearStart OrElse dtpRegStartDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Registration Start Date must be within the Academic Year period:" & vbCrLf & _
       $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpRegStartDate.Focus()
            Return
        End If

        If dtpRegEndDate.Value.Date < academicYearStart OrElse dtpRegEndDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Registration End Date must be within the Academic Year period:" & vbCrLf & _
   $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
          "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpRegEndDate.Focus()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for duplicate semester (same academic year + semester type)
                Dim checkQuery As String = "SELECT COUNT(*) FROM Semesters WHERE academic_year_id = @academic_year_id AND semester_type_id = @semester_type_id"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@academic_year_id", Convert.ToInt32(cmbAcademicYear.SelectedValue))
                    checkCmd.Parameters.AddWithValue("@semester_type_id", Convert.ToInt32(cmbSemesterType.SelectedValue))
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("A semester with this Academic Year and Semester Type already exists.", "Duplicate Semester", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' If setting as active, deactivate all other semesters
                If chkIsActive.Checked Then
                    Dim deactivateQuery As String = "UPDATE Semesters SET is_active = FALSE"
                    Using deactivateCmd As New MySqlCommand(deactivateQuery, connection)
                        deactivateCmd.ExecuteNonQuery()
                    End Using
                End If

                ' Insert new semester
                Dim insertQuery As String = "INSERT INTO Semesters (academic_year_id, semester_type_id, start_date, end_date, is_active, registration_start_date, registration_end_date, created_at) " &
        "VALUES (@academic_year_id, @semester_type_id, @start_date, @end_date, @is_active, @reg_start_date, @reg_end_date, NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@academic_year_id", Convert.ToInt32(cmbAcademicYear.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@semester_type_id", Convert.ToInt32(cmbSemesterType.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@start_date", dtpStartDate.Value.Date)
                    insertCmd.Parameters.AddWithValue("@end_date", dtpEndDate.Value.Date)
                    insertCmd.Parameters.AddWithValue("@is_active", chkIsActive.Checked)
                    insertCmd.Parameters.AddWithValue("@reg_start_date", dtpRegStartDate.Value.Date)
                    insertCmd.Parameters.AddWithValue("@reg_end_date", dtpRegEndDate.Value.Date)

                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Semester created successfully!" & vbCrLf & vbCrLf &
  $"Academic Year: {cmbAcademicYear.Text}" & vbCrLf &
      $"Semester: {cmbSemesterType.Text}" & vbCrLf &
  $"Classes: {dtpStartDate.Value:MMM dd, yyyy} - {dtpEndDate.Value:MMM dd, yyyy}" & vbCrLf &
  $"Registration: {dtpRegStartDate.Value:MMM dd, yyyy} - {dtpRegEndDate.Value:MMM dd, yyyy}",
        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
                ClearCreateSemesterForm()
                LoadSemestersData()
                LoadTermUpdateDropdown()

            End Using
        Catch ex As Exception
            MessageBox.Show($"Error creating semester: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateSemesterForm()
        If cmbAcademicYear IsNot Nothing AndAlso cmbAcademicYear.Items.Count > 0 Then
            cmbAcademicYear.SelectedIndex = 0
        End If
        If cmbSemesterType IsNot Nothing AndAlso cmbSemesterType.Items.Count > 0 Then
            cmbSemesterType.SelectedIndex = 0
        End If
        If dtpStartDate IsNot Nothing Then
            dtpStartDate.Value = DateTime.Now
        End If
        If dtpEndDate IsNot Nothing Then
            dtpEndDate.Value = DateTime.Now.AddMonths(4)
        End If
        If dtpRegStartDate IsNot Nothing Then
            dtpRegStartDate.Value = DateTime.Now
        End If
        If dtpRegEndDate IsNot Nothing Then
            dtpRegEndDate.Value = DateTime.Now.AddDays(14) ' Changed from AddWeeks to AddDays
        End If
        If chkIsActive IsNot Nothing Then
            chkIsActive.Checked = False
        End If
    End Sub

    ' ============= VIEW SEMESTERS METHODS =============

    Private Sub LoadSemestersData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT s.semester_id as 'Semester ID', " &
                                    "ay.academic_year_name as 'Academic Year', " &
                                    "st.type_name as 'Semester Type', " &
                                    "DATE_FORMAT(s.start_date, '%Y-%m-%d') as 'Start Date', " &
                                    "DATE_FORMAT(s.end_date, '%Y-%m-%d') as 'End Date', " &
                                    "DATE_FORMAT(s.registration_start_date, '%Y-%m-%d') as 'Reg. Start', " &
                                    "DATE_FORMAT(s.registration_end_date, '%Y-%m-%d') as 'Reg. End', " &
                                    "IF(s.is_active, 'Active', 'Inactive') as 'Status', " &
                                    "DATE_FORMAT(s.created_at, '%Y-%m-%d') as 'Created' " &
                                    "FROM Semesters s " &
                                    "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                                    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                                    "ORDER BY ay.year_start DESC, st.display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim semestersTable As New DataTable()
                    adapter.Fill(semestersTable)
                    dgvSemesters.DataSource = semestersTable
                    dgvSemesters.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading semesters: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshSemesters_Click(sender As Object, e As EventArgs) Handles btnRefreshSemesters.Click
        LoadSemestersData()
        MessageBox.Show("Semesters data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE SEMESTER METHODS =============

    Private Sub LoadSemesterUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT s.semester_id, CONCAT(ay.academic_year_name, ' - ', st.type_name) as display_name " &
                                    "FROM Semesters s " &
                                    "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                                    "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                                    "ORDER BY ay.year_start DESC, st.display_order"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim semesterTable As New DataTable()
                    adapter.Fill(semesterTable)
                    ' Add null check to prevent errors if control doesn't exist yet
                    If cmbSelectSemester Is Nothing Then
                        Exit Sub
                    End If
                    cmbSelectSemester.DataSource = semesterTable
                    cmbSelectSemester.DisplayMember = "display_name"
                    cmbSelectSemester.ValueMember = "semester_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading semesters for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadSemesterData_Click(sender As Object, e As EventArgs)
        If cmbSelectSemester Is Nothing OrElse cmbSelectSemester.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a semester to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedSemesterId As Integer = Convert.ToInt32(cmbSelectSemester.SelectedValue)
            LoadSemesterDataForUpdate(selectedSemesterId)
        Catch ex As Exception
            MessageBox.Show($"Error loading semester data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadSemesterDataForUpdate(semesterId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT academic_year_id, semester_type_id, start_date, end_date, registration_start_date, registration_end_date, is_active " &
                                    "FROM Semesters WHERE semester_id = @semester_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@semester_id", semesterId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            cmbUpdateAcademicYear.SelectedValue = Convert.ToInt32(reader("academic_year_id"))
                            cmbUpdateSemesterType.SelectedValue = Convert.ToInt32(reader("semester_type_id"))
                            dtpUpdateStartDate.Value = Convert.ToDateTime(reader("start_date"))
                            dtpUpdateEndDate.Value = Convert.ToDateTime(reader("end_date"))
                            dtpUpdateRegStartDate.Value = Convert.ToDateTime(reader("registration_start_date"))
                            dtpUpdateRegEndDate.Value = Convert.ToDateTime(reader("registration_end_date"))
                            chkUpdateIsActive.Checked = Convert.ToBoolean(reader("is_active"))

                            grpSemesterInfo.Visible = True
                        Else
                            MessageBox.Show("Semester data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading semester data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateSemester_Click(sender As Object, e As EventArgs)
        If cmbSelectSemester Is Nothing OrElse cmbSelectSemester.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a semester to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get academic year date range
        Dim academicYearStart As Date
        Dim academicYearEnd As Date

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim ayQuery As String = "SELECT year_start, year_end FROM Academic_Years WHERE academic_year_id = @academic_year_id"
                Using ayCmd As New MySqlCommand(ayQuery, connection)
                    ayCmd.Parameters.AddWithValue("@academic_year_id", Convert.ToInt32(cmbUpdateAcademicYear.SelectedValue))
                    Using reader As MySqlDataReader = ayCmd.ExecuteReader()
                        If reader.Read() Then
                            Dim yearStart As Integer = Convert.ToInt32(reader("year_start"))
                            Dim yearEnd As Integer = Convert.ToInt32(reader("year_end"))
                            academicYearStart = New Date(yearStart, 1, 1)
                            academicYearEnd = New Date(yearEnd, 12, 31)
                        Else
                            MessageBox.Show("Unable to retrieve academic year information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving academic year dates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Validate semester dates fall within academic year
        If dtpUpdateStartDate.Value.Date < academicYearStart OrElse dtpUpdateStartDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Semester Start Date must be within the Academic Year period:" & vbCrLf & _
       $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
 "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateStartDate.Focus()
            Return
        End If

        If dtpUpdateEndDate.Value.Date < academicYearStart OrElse dtpUpdateEndDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Semester End Date must be within the Academic Year period:" & vbCrLf & _
          $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateEndDate.Focus()
            Return
        End If

        ' Validate end date is after start date
        If dtpUpdateEndDate.Value.Date <= dtpUpdateStartDate.Value.Date Then
            MessageBox.Show("Semester End Date must be after Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateEndDate.Focus()
            Return
        End If

        ' Validate registration dates are BEFORE semester start date
        If dtpUpdateRegStartDate.Value.Date >= dtpUpdateStartDate.Value.Date Then
            MessageBox.Show("Registration Start Date must be BEFORE the Semester Start Date." & vbCrLf & _
     "Students must register before classes begin.",
         "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateRegStartDate.Focus()
            Return
        End If

        If dtpUpdateRegEndDate.Value.Date >= dtpUpdateStartDate.Value.Date Then
            MessageBox.Show("Registration End Date must be BEFORE the Semester Start Date." & vbCrLf & _
          "Registration must close before classes begin.",
      "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateRegEndDate.Focus()
            Return
        End If

        ' Validate registration end date is after or equal to registration start date
        If dtpUpdateRegEndDate.Value.Date < dtpUpdateRegStartDate.Value.Date Then
            MessageBox.Show("Registration End Date must be on or after Registration Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateRegEndDate.Focus()
            Return
        End If

        ' Validate registration dates are within academic year
        If dtpUpdateRegStartDate.Value.Date < academicYearStart OrElse dtpUpdateRegStartDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Registration Start Date must be within the Academic Year period:" & vbCrLf & _
      $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateRegStartDate.Focus()
            Return
        End If

        If dtpUpdateRegEndDate.Value.Date < academicYearStart OrElse dtpUpdateRegEndDate.Value.Date > academicYearEnd Then
            MessageBox.Show($"Registration End Date must be within the Academic Year period:" & vbCrLf & _
 $"{academicYearStart:MMMM dd, yyyy} to {academicYearEnd:MMMM dd, yyyy}",
     "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateRegEndDate.Focus()
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this semester?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedSemesterId As Integer = Convert.ToInt32(cmbSelectSemester.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' If setting as active, deactivate all other semesters
                    If chkUpdateIsActive.Checked Then
                        Dim deactivateQuery As String = "UPDATE Semesters SET is_active = FALSE WHERE semester_id != @semester_id"
                        Using deactivateCmd As New MySqlCommand(deactivateQuery, connection)
                            deactivateCmd.Parameters.AddWithValue("@semester_id", selectedSemesterId)
                            deactivateCmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' Update semester
                    Dim updateQuery As String = "UPDATE Semesters SET " &
      "academic_year_id = @academic_year_id, " &
             "semester_type_id = @semester_type_id, " &
        "start_date = @start_date, " &
               "end_date = @end_date, " &
  "registration_start_date = @reg_start_date, " &
    "registration_end_date = @reg_end_date, " &
            "is_active = @is_active " &
               "WHERE semester_id = @semester_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@academic_year_id", Convert.ToInt32(cmbUpdateAcademicYear.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@semester_type_id", Convert.ToInt32(cmbUpdateSemesterType.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@start_date", dtpUpdateStartDate.Value.Date)
                        updateCmd.Parameters.AddWithValue("@end_date", dtpUpdateEndDate.Value.Date)
                        updateCmd.Parameters.AddWithValue("@reg_start_date", dtpUpdateRegStartDate.Value.Date)
                        updateCmd.Parameters.AddWithValue("@reg_end_date", dtpUpdateRegEndDate.Value.Date)
                        updateCmd.Parameters.AddWithValue("@is_active", chkUpdateIsActive.Checked)
                        updateCmd.Parameters.AddWithValue("@semester_id", selectedSemesterId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Semester updated successfully!" & vbCrLf & vbCrLf &
       $"Academic Year: {cmbUpdateAcademicYear.Text}" & vbCrLf &
         $"Semester: {cmbUpdateSemesterType.Text}" & vbCrLf &
   $"Classes: {dtpUpdateStartDate.Value:MMM dd, yyyy} - {dtpUpdateEndDate.Value:MMM dd, yyyy}" & vbCrLf &
     $"Registration: {dtpUpdateRegStartDate.Value:MMM dd, yyyy} - {dtpUpdateRegEndDate.Value:MMM dd, yyyy}",
   "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LoadSemestersData()
                    LoadTermUpdateDropdown()
                    ClearUpdateSemesterForm()
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error updating semester: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDeleteSemester_Click(sender As Object, e As EventArgs)
        If cmbSelectSemester Is Nothing OrElse cmbSelectSemester.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a semester to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedSemesterDisplay As String = cmbSelectSemester.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the semester: {selectedSemesterDisplay}?" & vbCrLf & vbCrLf +
                                                     "This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedSemesterId As Integer = Convert.ToInt32(cmbSelectSemester.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim deleteQuery As String = "DELETE FROM Semesters WHERE semester_id = @semester_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@semester_id", selectedSemesterId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Semester deleted successfully: {selectedSemesterDisplay}", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            LoadSemestersData()
                            LoadTermUpdateDropdown()
                            ClearUpdateSemesterForm()
                        Else
                            MessageBox.Show("Failed to delete semester. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting semester: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateSemesterForm()
        If grpSemesterInfo IsNot Nothing Then
            grpSemesterInfo.Visible = False
        End If
    End Sub

    ' ============= CREATE TERM METHODS =============

    Private Sub btnSubmitTerm_Click(sender As Object, e As EventArgs)
        ' Validate input
        If cmbTermSemester.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a Semester.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If cmbTermType.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a Term Type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get semester date range
        Dim semesterStart As Date
        Dim semesterEnd As Date

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim semQuery As String = "SELECT start_date, end_date FROM Semesters WHERE semester_id = @semester_id"
                Using semCmd As New MySqlCommand(semQuery, connection)
                    semCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbTermSemester.SelectedValue))
                    Using reader As MySqlDataReader = semCmd.ExecuteReader()
                        If reader.Read() Then
                            semesterStart = Convert.ToDateTime(reader("start_date"))
                            semesterEnd = Convert.ToDateTime(reader("end_date"))
                        Else
                            MessageBox.Show("Unable to retrieve semester information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving semester dates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Validate term dates fall within semester
        If dtpTermStartDate.Value.Date < semesterStart OrElse dtpTermStartDate.Value.Date > semesterEnd Then
            MessageBox.Show($"Term Start Date must be within the Semester period:" & vbCrLf &
       $"{semesterStart:MMMM dd, yyyy} to {semesterEnd:MMMM dd, yyyy}",
   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpTermStartDate.Focus()
            Return
        End If

        If dtpTermEndDate.Value.Date < semesterStart OrElse dtpTermEndDate.Value.Date > semesterEnd Then
            MessageBox.Show($"Term End Date must be within the Semester period:" & vbCrLf &
      $"{semesterStart:MMMM dd, yyyy} to {semesterEnd:MMMM dd, yyyy}",
   "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpTermEndDate.Focus()
            Return
        End If

        ' Validate end date is after start date
        If dtpTermEndDate.Value.Date <= dtpTermStartDate.Value.Date Then
            MessageBox.Show("Term End Date must be after Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpTermEndDate.Focus()
            Return
        End If

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check for duplicate term (same semester + term type)
                Dim checkQuery As String = "SELECT COUNT(*) FROM Terms WHERE semester_id = @semester_id AND term_type_id = @term_type_id"
                Using checkCmd As New MySqlCommand(checkQuery, connection)
                    checkCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbTermSemester.SelectedValue))
                    checkCmd.Parameters.AddWithValue("@term_type_id", Convert.ToInt32(cmbTermType.SelectedValue))
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                    If count > 0 Then
                        MessageBox.Show("A term with this Semester and Term Type already exists.", "Duplicate Term", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                End Using

                ' If setting as active, deactivate all other terms
                If chkTermIsActive.Checked Then
                    Dim deactivateQuery As String = "UPDATE Terms SET is_active = FALSE"
                    Using deactivateCmd As New MySqlCommand(deactivateQuery, connection)
                        deactivateCmd.ExecuteNonQuery()
                    End Using
                End If

                ' Insert new term
                Dim insertQuery As String = "INSERT INTO Terms (semester_id, term_type_id, start_date, end_date, is_active, created_at) " &
         "VALUES (@semester_id, @term_type_id, @start_date, @end_date, @is_active, NOW())"

                Using insertCmd As New MySqlCommand(insertQuery, connection)
                    insertCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbTermSemester.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@term_type_id", Convert.ToInt32(cmbTermType.SelectedValue))
                    insertCmd.Parameters.AddWithValue("@start_date", dtpTermStartDate.Value.Date)
                    insertCmd.Parameters.AddWithValue("@end_date", dtpTermEndDate.Value.Date)
                    insertCmd.Parameters.AddWithValue("@is_active", chkTermIsActive.Checked)

                    insertCmd.ExecuteNonQuery()
                End Using

                MessageBox.Show("Term created successfully!" & vbCrLf & vbCrLf &
        $"Semester: {cmbTermSemester.Text}" & vbCrLf &
         $"Term: {cmbTermType.Text}" & vbCrLf &
      $"Duration: {dtpTermStartDate.Value:MMM dd, yyyy} - {dtpTermEndDate.Value:MMM dd, yyyy}",
               "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Clear form and reload data
                ClearCreateTermForm()
                LoadTermsData()
                LoadTermUpdateDropdown()

            End Using
        Catch ex As Exception
            MessageBox.Show($"Error creating term: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearCreateTermForm()
        If cmbTermSemester IsNot Nothing AndAlso cmbTermSemester.Items.Count > 0 Then
            cmbTermSemester.SelectedIndex = 0
        End If
        If cmbTermType IsNot Nothing AndAlso cmbTermType.Items.Count > 0 Then
            cmbTermType.SelectedIndex = 0
        End If
        If dtpTermStartDate IsNot Nothing Then
            dtpTermStartDate.Value = DateTime.Now
        End If
        If dtpTermEndDate IsNot Nothing Then
            dtpTermEndDate.Value = DateTime.Now.AddMonths(2)
        End If
        If chkTermIsActive IsNot Nothing Then
            chkTermIsActive.Checked = False
        End If
    End Sub

    ' ============= VIEW TERMS METHODS =============

    Private Sub LoadTermsData()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT t.term_id as 'Term ID', " &
                 "CONCAT(ay.academic_year_name, ' - ', st.type_name, ' - ', tt.type_name) as 'Semester', " &
              "tt.type_name as 'Term Type', " &
             "DATE_FORMAT(t.start_date, '%Y-%m-%d') as 'Start Date', " &
          "DATE_FORMAT(t.end_date, '%Y-%m-%d') as 'End Date', " &
            "IF(t.is_active, 'Active', 'Inactive') as 'Status', " &
           "DATE_FORMAT(t.created_at, '%Y-%m-%d') as 'Created' " &
                "FROM Terms t " &
                   "INNER JOIN Semesters s ON t.semester_id = s.semester_id " &
               "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                     "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
                  "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
                     "ORDER BY ay.year_start DESC, st.display_order, tt.display_order"

                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim termsTable As New DataTable()
                    adapter.Fill(termsTable)
                    dgvTerms.DataSource = termsTable
                    dgvTerms.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading terms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnRefreshTerms_Click(sender As Object, e As EventArgs) Handles btnRefreshTerms.Click
        LoadTermsData()
        MessageBox.Show("Terms data refreshed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' ============= UPDATE/DELETE TERM METHODS =============

    Private Sub LoadTermUpdateDropdown()
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT t.term_id, " &
            "CONCAT(ay.academic_year_name, ' - ', st.type_name, ' - ', tt.type_name) as display_name " &
          "FROM Terms t " &
               "INNER JOIN Semesters s ON t.semester_id = s.semester_id " &
            "INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id " &
                     "INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id " &
           "INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id " &
              "ORDER BY ay.year_start DESC, st.display_order, tt.display_order"
                Using adapter As New MySqlDataAdapter(query, connection)
                    Dim termTable As New DataTable()
                    adapter.Fill(termTable)
                    If cmbSelectTerm Is Nothing Then
                        Exit Sub
                    End If
                    cmbSelectTerm.DataSource = termTable
                    cmbSelectTerm.DisplayMember = "display_name"
                    cmbSelectTerm.ValueMember = "term_id"
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading terms for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLoadTermData_Click(sender As Object, e As EventArgs)
        If cmbSelectTerm Is Nothing OrElse cmbSelectTerm.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a term to load.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim selectedTermId As Integer = Convert.ToInt32(cmbSelectTerm.SelectedValue)
            LoadTermDataForUpdate(selectedTermId)
        Catch ex As Exception
            MessageBox.Show($"Error loading term data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadTermDataForUpdate(termId As Integer)
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Dim query As String = "SELECT semester_id, term_type_id, start_date, end_date, is_active " &
              "FROM Terms WHERE term_id = @term_id"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@term_id", termId)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            cmbUpdateTermSemester.SelectedValue = Convert.ToInt32(reader("semester_id"))
                            cmbUpdateTermType.SelectedValue = Convert.ToInt32(reader("term_type_id"))
                            dtpUpdateTermStartDate.Value = Convert.ToDateTime(reader("start_date"))
                            dtpUpdateTermEndDate.Value = Convert.ToDateTime(reader("end_date"))
                            chkUpdateTermIsActive.Checked = Convert.ToBoolean(reader("is_active"))

                            grpTermInfo.Visible = True
                        Else
                            MessageBox.Show("Term data not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error loading term data for update: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnUpdateTerm_Click(sender As Object, e As EventArgs)
        If cmbSelectTerm Is Nothing OrElse cmbSelectTerm.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a term to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Get semester date range
        Dim semesterStart As Date
        Dim semesterEnd As Date

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
                Dim semQuery As String = "SELECT start_date, end_date FROM Semesters WHERE semester_id = @semester_id"
                Using semCmd As New MySqlCommand(semQuery, connection)
                    semCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbUpdateTermSemester.SelectedValue))
                    Using reader As MySqlDataReader = semCmd.ExecuteReader()
                        If reader.Read() Then
                            semesterStart = Convert.ToDateTime(reader("start_date"))
                            semesterEnd = Convert.ToDateTime(reader("end_date"))
                        Else
                            MessageBox.Show("Unable to retrieve semester information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error retrieving semester dates: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        ' Validate term dates fall within semester
        If dtpUpdateTermStartDate.Value.Date < semesterStart OrElse dtpUpdateTermStartDate.Value.Date > semesterEnd Then
            MessageBox.Show($"Term Start Date must be within the Semester period:" & vbCrLf &
     $"{semesterStart:MMMM dd, yyyy} to {semesterEnd:MMMM dd, yyyy}",
     "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateTermStartDate.Focus()
            Return
        End If

        If dtpUpdateTermEndDate.Value.Date < semesterStart OrElse dtpUpdateTermEndDate.Value.Date > semesterEnd Then
            MessageBox.Show($"Term End Date must be within the Semester period:" & vbCrLf &
      $"{semesterStart:MMMM dd, yyyy} to {semesterEnd:MMMM dd, yyyy}",
        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateTermEndDate.Focus()
            Return
        End If

        ' Validate end date is after start date
        If dtpUpdateTermEndDate.Value.Date <= dtpUpdateTermStartDate.Value.Date Then
            MessageBox.Show("Term End Date must be after Start Date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpUpdateTermEndDate.Focus()
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to update this term?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedTermId As Integer = Convert.ToInt32(cmbSelectTerm.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    ' If setting as active, deactivate all other terms
                    If chkUpdateTermIsActive.Checked Then
                        Dim deactivateQuery As String = "UPDATE Terms SET is_active = FALSE WHERE term_id != @term_id"
                        Using deactivateCmd As New MySqlCommand(deactivateQuery, connection)
                            deactivateCmd.Parameters.AddWithValue("@term_id", selectedTermId)
                            deactivateCmd.ExecuteNonQuery()
                        End Using
                    End If

                    ' Update term
                    Dim updateQuery As String = "UPDATE Terms SET " &
                    "semester_id = @semester_id, " &
                "term_type_id = @term_type_id, " &
                "start_date = @start_date, " &
               "end_date = @end_date, " &
                 "is_active = @is_active " &
            "WHERE term_id = @term_id"

                    Using updateCmd As New MySqlCommand(updateQuery, connection)
                        updateCmd.Parameters.AddWithValue("@semester_id", Convert.ToInt32(cmbUpdateTermSemester.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@term_type_id", Convert.ToInt32(cmbUpdateTermType.SelectedValue))
                        updateCmd.Parameters.AddWithValue("@start_date", dtpUpdateTermStartDate.Value.Date)
                        updateCmd.Parameters.AddWithValue("@end_date", dtpUpdateTermEndDate.Value.Date)
                        updateCmd.Parameters.AddWithValue("@is_active", chkUpdateTermIsActive.Checked)
                        updateCmd.Parameters.AddWithValue("@term_id", selectedTermId)

                        updateCmd.ExecuteNonQuery()
                    End Using

                    MessageBox.Show("Term updated successfully!" & vbCrLf & vbCrLf &
                  $"Semester: {cmbUpdateTermSemester.Text}" & vbCrLf &
                     $"Term: {cmbUpdateTermType.Text}" & vbCrLf &
                 $"Duration: {dtpUpdateTermStartDate.Value:MMM dd, yyyy} - {dtpUpdateTermEndDate.Value:MMM dd, yyyy}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LoadTermsData()
                    LoadTermUpdateDropdown()
                    ClearUpdateTermForm()
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error updating term: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub btnDeleteTerm_Click(sender As Object, e As EventArgs)
        If cmbSelectTerm Is Nothing OrElse cmbSelectTerm.SelectedValue Is Nothing Then
            MessageBox.Show("Please select a term to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim selectedTermDisplay As String = cmbSelectTerm.Text
        Dim result As DialogResult = MessageBox.Show($"Are you sure you want to delete the term: {selectedTermDisplay}?" & vbCrLf & vbCrLf +
      "This action cannot be undone.", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Try
                Dim selectedTermId As Integer = Convert.ToInt32(cmbSelectTerm.SelectedValue)

                Using connection As New MySqlConnection(connectionString)
                    connection.Open()

                    Dim deleteQuery As String = "DELETE FROM Terms WHERE term_id = @term_id"

                    Using deleteCmd As New MySqlCommand(deleteQuery, connection)
                        deleteCmd.Parameters.AddWithValue("@term_id", selectedTermId)

                        Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                        If rowsAffected > 0 Then
                            MessageBox.Show($"Term deleted successfully: {selectedTermDisplay}", "Deletion Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)

                            LoadTermsData()
                            LoadTermUpdateDropdown()
                            ClearUpdateTermForm()
                        Else
                            MessageBox.Show("Failed to delete term. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show($"Error deleting term: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ClearUpdateTermForm()
        If grpTermInfo IsNot Nothing Then
            grpTermInfo.Visible = False
        End If
    End Sub

    Private Sub pnlCreateSemester_Paint(sender As Object, e As PaintEventArgs) Handles pnlCreateSemester.Paint

    End Sub
End Class