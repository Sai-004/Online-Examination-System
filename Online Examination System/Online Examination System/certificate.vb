Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class Certificate
    ' Connection string to the database
    Private connectionString As String = "DSN=oee;Uid=user123;Pwd=1234"
    Private connection As New OdbcConnection(connectionString)

    Private rollNumber As Integer
    Private totalMarks As Integer = 0
    Dim marks As New List(Of Integer)
    Dim questions As New List(Of Integer)

    Public Sub New(ByVal rollNumber As Integer)
        InitializeComponent()

        ' Set the rollNumber received from the exam panel form
        Me.rollNumber = rollNumber
    End Sub

    Private Sub Certificate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        getTotalMarks()
        LoadResult(rollNumber)
        LoadStudentDetails(rollNumber)
        GetRank(rollNumber)
    End Sub

    Private Sub getTotalMarks()
        Try
            connection.Open()
            Dim cmdSelect As New OdbcCommand("select no_qs from minimum_number_of_questions", connection)
            'Total Marks 
            Dim reader As OdbcDataReader = cmdSelect.ExecuteReader()
            While reader.Read()
                questions.Add(Convert.ToInt32(reader("no_qs")))
            End While
            reader.Close()
            'MessageBox.Show(questions.Count)
            Dim query As String = "select marks from section"
            Using cmd As New OdbcCommand(query, connection)
                reader = cmd.ExecuteReader()
                While reader.Read()
                    marks.Add(Convert.ToInt32(reader("marks")))
                End While
                reader.Close()
            End Using
            For i As Integer = 0 To marks.Count - 1 Step 1
                totalMarks = totalMarks + marks(i) * questions(i)
            Next
        Catch ex As Exception
            MessageBox.Show("Error loading student details: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Method to load student details
    Private Sub LoadStudentDetails(ByVal rollNumber As Integer)
        Try
            connection.Open()

            ' Query to retrieve student details
            Dim query As String = "SELECT name, email FROM student WHERE roll_number = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("@roll_number", rollNumber)

                ' Execute the query
                Dim reader As OdbcDataReader = command.ExecuteReader()

                ' Check if there are rows returned
                If reader.HasRows Then
                    reader.Read()

                    ' Populate the student details in the form
                    namelabel.Text = reader.GetString(0)
                    'emailTextBox.Text = reader.GetString(1)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading student details: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    ' Method to load result
    Private Sub LoadResult(ByVal rollNumber As Integer)
        Try
            connection.Open()

            ' Query to retrieve result
            Dim query As String = "SELECT marks, percentage, grade, percentile FROM results WHERE roll_number = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("@roll_number", rollNumber)

                ' Execute the query
                Dim reader As OdbcDataReader = command.ExecuteReader()

                ' Check if there are rows returned
                If reader.HasRows Then
                    reader.Read()

                    ' Populate the result in the form
                    markslabel.Text = "for scoring " & reader.GetInt32(0).ToString() & " out of " & totalMarks & " in " & "Exam 1"

                    'percentageTextBox.Text = reader.GetDouble(1).ToString()
                    gradelebel.Text = "GRADE: " & reader.GetString(2)
                    ' percentileTextBox.Text = reader.GetDouble(3).ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading result: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    Private Sub GetRank(ByVal rollNumber As Integer)
        Try
            connection.Open()
            ' Query to retrieve student rank
            Dim query As String = "SELECT r.roll_number as roll_number, DENSE_RANK() OVER (ORDER BY marks DESC) AS Rank FROM results r JOIN student s ON r.roll_number = s.roll_number WHERE r.roll_number = ?"
            Using command As New OdbcCommand(query, connection)
                command.Parameters.AddWithValue("?", rollNumber)

                ' Execute the query
                Dim reader As OdbcDataReader = command.ExecuteReader()

                If reader.Read() Then
                    MessageBox.Show(reader("Rank"))
                    ranklabel.Text = "RANK: " & reader("Rank").ToString()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading student details: " & ex.Message)
        Finally
            connection.Close()
        End Try
        
    End Sub

End Class