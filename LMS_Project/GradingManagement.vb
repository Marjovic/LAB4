Public Class GradingManagement
    Private Sub GradingManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialize form
        Me.Text = "Grading Management - MGOD LMS"
    End Sub

    ' Navigate to Assignment Type Management
    Private Sub btnAssignmentType_Click(sender As Object, e As EventArgs) Handles btnAssignmentType.Click
        Dim assignmentTypeForm As New AssignmentType()
        assignmentTypeForm.ShowDialog()  ' Changed from Show() to ShowDialog()
        ' Removed Me.Hide() - no longer needed
    End Sub

    ' Navigate to Offering Grade Weight Management
    Private Sub btnOfferingGradeWeight_Click(sender As Object, e As EventArgs) Handles btnOfferingGradeWeight.Click
        Dim offeringGradeWeightForm As New OfferingGradeWeight()
        offeringGradeWeightForm.ShowDialog()  ' Changed from Show() to ShowDialog()
        ' Removed Me.Hide() - no longer needed
    End Sub

    ' Navigate to View Student Grades
    Private Sub btnViewStudentGrades_Click(sender As Object, e As EventArgs) Handles btnViewStudentGrades.Click
        Dim viewGradesForm As New ViewStudentGrades()
        viewGradesForm.ShowDialog()
    End Sub

    ' Navigate to Enrollment Management
    Private Sub btnEnrollmentManagement_Click(sender As Object, e As EventArgs) Handles btnEnrollmentManagement.Click
        Dim enrollmentManagementForm As New EnrollmentManagement()
        enrollmentManagementForm.ShowDialog()
    End Sub

    ' Navigate to Reports Form
    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        Dim reportsForm As New ReportsForm()
        reportsForm.ShowDialog()
    End Sub

    ' Close button handler
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class