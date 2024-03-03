Public Class StudentLandingPage

    ' Connection string to the database
    Private connectionString As String = "DSN=oee;Uid=user123;Pwd=1234"

    ' Variable to store the roll number received from the exam panel form
    Private rollNumber As Integer = 70 ' Default value

    Public Sub New(ByVal rollNumber As Integer)
        InitializeComponent()

        ' Set the rollNumber received from the exam panel form
        Me.rollNumber = rollNumber
    End Sub

    Private Sub ExamBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExamBtn.Click
        Dim exampanel As New ExamForm(rollNumber)
        exampanel.Show()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim genCertificate As New Certificate(rollNumber)
        genCertificate.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Panel1.Visible = True
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class
