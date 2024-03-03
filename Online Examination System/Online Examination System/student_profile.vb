Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class student_profile
    ' Connection string to the database
    Private connectionString As String = "DSN=oee;Uid=user123;Pwd=1234"

    ' Variable to store the roll number received from the exam panel form
    Private rollNumber As Integer = 70 ' Default value

    Public Sub New(ByVal rollNumber As Integer)
        InitializeComponent()

        ' Set the rollNumber received from the exam panel form
        Me.rollNumber = rollNumber

        ' Load student details and results
        LoadStudentDetails()
        LoadResult()
    End Sub

    ' Method to load student details
    Private Sub LoadStudentDetails()
        Using connection As New OdbcConnection(connectionString)
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
                        nameTextBox.Text = reader.GetString(0)
                        emailTextBox.Text = reader.GetString(1)
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading student details: " & ex.Message)
            End Try
        End Using
    End Sub

    ' Method to load result
    Private Sub LoadResult()
        Using connection As New OdbcConnection(connectionString)
            Try
                connection.Open()

                ' Query to retrieve result
                Dim query As String = "SELECT marks, percentage, grade, percentile, rank FROM results WHERE roll_number = ?"
                Using command As New OdbcCommand(query, connection)
                    command.Parameters.AddWithValue("@roll_number", rollNumber)

                    ' Execute the query
                    Dim reader As OdbcDataReader = command.ExecuteReader()

                    ' Check if there are rows returned
                    If reader.HasRows Then
                        reader.Read()

                        ' Populate the result in the form
                        marksTextBox.Text = reader.GetInt32(0).ToString()
                        percentageTextBox.Text = reader.GetDouble(1).ToString()
                        gradeTextBox.Text = reader.GetString(2)
                        percentileTextBox.Text = reader.GetDouble(3).ToString()
                        rankTextBox.Text = reader.GetInt32(4).ToString()
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading result: " & ex.Message)
            End Try
        End Using
    End Sub
End Class
