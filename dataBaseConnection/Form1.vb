Imports System.Data.Odbc

Public Class Form1
    Dim connString As String = "DSN=oee;Uid=root;Pwd=2004;"
    Dim conn As New OdbcConnection(connString)
    Dim numberOfSections As Integer
    Dim numberOfQuestions As New List(Of Integer)
    Dim enteredSections As Boolean = False
    Dim enteredNumberOfQuestions As Boolean = False
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Load data or perform other tasks when the form loads
        Try
            conn.Open()
            'MessageBox.Show("Connection Successful")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'The below code is to print all table names in a message box

            'Dim query As String = "SELECT table_name FROM information_schema.tables WHERE table_schema = DATABASE();"
            'Dim command As New OdbcCommand(query, conn)
            'Dim reader As OdbcDataReader = command.ExecuteReader()

            ' Display table names in message boxes
            ' Dim tables As String = "Tables in the database:" & vbCrLf
            'While reader.Read()
            'tables += reader("table_name").ToString() & vbCrLf
            'End While
            'tables += vbCrLf
            'tables += vbCrLf
            'MessageBox.Show(tables, "Database Tables")

            'reader.Close()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            MessageBox.Show("Error connecting to database: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'To take number of sections and number of questions in each section(number of questions in each section can be different using rich text box
        If Not Integer.TryParse(RichTextBox1.Text.Trim(), numberOfSections) Then
            MessageBox.Show("Invalid input for the number of sections.")
            Exit Sub
        End If
        enteredSections = True
        RichTextBox1.ReadOnly = True
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        ' Read the number of questions in each section from the second RichTextBox
        Dim lines() As String = RichTextBox2.Lines

        For i As Integer = 0 To lines.Length - 1
            Dim numQuestions As Integer
            If Not Integer.TryParse(lines(i).Trim(), numQuestions) Then
                MessageBox.Show("Invalid input for the number of questions in section " & (i + 1) & ".")
                Exit Sub
            End If
            ' Add the number of questions to the list
            numberOfQuestions.Add(numQuestions)
        Next
        enteredNumberOfQuestions = True
        RichTextBox2.ReadOnly = True
    End Sub
    'clear buttons functionality
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        RichTextBox1.Text = ""
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        RichTextBox2.Text = ""
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If (enteredNumberOfQuestions = True And enteredSections = True) Then
            If Not (numberOfSections = numberOfQuestions.Count) Then
                MessageBox.Show("The Entered number of questions in each section doesn't match number of sections", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If
            If numberOfSections = 0 Then
                MessageBox.Show("Number of sections cannot be 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
                Exit Sub
            End If
            For i As Integer = 0 To numberOfSections - 1
                If numberOfQuestions(i) = 0 Then
                    MessageBox.Show("Number of questions in any section cannot be 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Exit Sub
                End If
            Next
            Button5.Enabled = False
            'storing the correct values in table in the database
            Try
                conn.Open()
                Dim integerString As String = String.Join(",", numberOfQuestions)
                'MessageBox.Show(integerString)
                'To delete previous entries if present
                Dim queryToDelete As String = "delete from numberOfQuestions"
                Dim cmd1 As New OdbcCommand(queryToDelete, conn)
                cmd1.ExecuteNonQuery()
                'inserted the values in the table
                Dim query As String = "INSERT INTO numberOfQuestions (sections, questions) VALUES (?, ?)"
                Dim cmd As New OdbcCommand(query, conn)
                ' Parameters
                cmd.Parameters.AddWithValue("@numberOfSections", numberOfSections)
                cmd.Parameters.AddWithValue("@integerString", integerString)
                ' Execute query
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message)
            Finally
                conn.Close()
            End Try
            'Load next form where question pool management is done
            ''''''''''''''''''''''''''''''''''''''''''''''
        End If
    End Sub
End Class
