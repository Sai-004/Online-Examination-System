Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class StudentLandingPage

    ' Connection string to the database
    Private connectionString As String = "DSN=oee;Uid=user123;Pwd=1234"
    Private connection As New OdbcConnection(connectionString)

    ' Variable to store the roll number received from the exam panel form
    Private rollNumber As Integer = 70 ' Default value
    Private result_released As Boolean = False

    Public Sub New(ByVal rollNumber As Integer)
        InitializeComponent()

        ' Set the rollNumber received from the exam panel form
        Me.rollNumber = rollNumber
    End Sub

    Private Sub StudentLandingPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MessageBox.Show(rollNumber)
        ' Populate labels with data from the database
        PopulateLabelsFromDatabase(rollNumber)

        ' Get Results from database
        GetResults(rollNumber)

        ' Check if exam is already given
        isExamDone(rollNumber)
    End Sub

    Private Sub PopulateLabelsFromDatabase(ByVal rollNumber As Integer)
        Try
            connection.Open()
            Dim query As String = "SELECT * FROM student WHERE roll_number = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("?", rollNumber)
                Dim reader As OdbcDataReader = command.ExecuteReader()
                If reader.Read() Then
                    NameLabel.Text = reader("name").ToString()
                    topNameLabel.Text = NameLabel.Text
                    ' Assuming you have corresponding labels for email and roll number, set them as well
                    EmailLabel.Text = reader("email").ToString()
                    RollNoLabel.Text = reader("roll_number").ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving data from the database: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub GetResults(ByVal rollNumber As Integer)
        Try
            connection.Open()
            Dim query As String = "SELECT * FROM results WHERE roll_number = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("?", rollNumber)
                Dim reader As OdbcDataReader = command.ExecuteReader()
                If reader.Read() Then
                    result_released = Convert.ToBoolean(reader("released"))
                    If result_released = True Then
                        MarksLabel.Text = reader("marks").ToString()
                        GradeLabel.Text = reader("grade").ToString()
                        PercentileLabel.Text = reader("percentile").ToString()
                        waitResults_tb.Visible = False
                        resultBtn.Enabled = True
                        genCertificateBtn.Visible = True
                    ElseIf result_released = False Then
                        waitResults_tb.Visible = True
                        genCertificateBtn.Visible = False
                        resultBtn.Enabled = False
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error retrieving data from the database: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub isExamDone(ByVal rollNumber As Integer)
        Try
            connection.Open()
            Dim shouldBeDisabled As Boolean = False
            Dim query As String = "select exam_given from student where roll_number=?"
            Using cmd As New OdbcCommand(query, connection)
                cmd.Parameters.AddWithValue("?", rollNumber)
                Dim reader As OdbcDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    shouldBeDisabled = Convert.ToBoolean(reader("exam_given"))
                End If
            End Using
            If shouldBeDisabled Then
                ExamBtn.Enabled = False
            End If
        Catch ex As Exception
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub ExamBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExamBtn.Click
        Dim exampanel As New ExamForm(rollNumber)
        exampanel.Show()
        Me.Close()
    End Sub

    Private Sub genCertificateBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles genCertificateBtn.Click
        Dim genCertificate As New Certificate(rollNumber)
        genCertificate.Show()
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub resultBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resultBtn.Click
        MarksLabel.Visible = True
        MarksLb.Visible = True
        GradeLabel.Visible = True
        GradeLb.Visible = True
        PercentileLabel.Visible = True
        PercentileLb.Visible = True
    End Sub
    'logout
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            connection.Open()
            Dim query As String = "update student set logged_in = FALSE where roll_number = ? "
            Using cmd As New OdbcCommand(query, connection)
                cmd.Parameters.AddWithValue("?", rollNumber)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception

        Finally
            connection.Close()
        End Try
        Application.Exit()
    End Sub
End Class
