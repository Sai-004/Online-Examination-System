Imports System.Data.Odbc
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
'This form does question pool management like add,edit and delete
Public Class Form3
    Dim connString As String = "DSN=oee;Uid=root;Pwd=2004;"
    Dim conn As New OdbcConnection(connString)
    Dim numberOfSections As Integer
    Dim numberOfQuestions As New List(Of Integer)
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'to fill the variables numberOfSections and numberOfQuestions from database
            conn.Open()
            Dim query As String = "SELECT sections, questions FROM numberOfQuestions"
            Dim cmd As New OdbcCommand(query, conn)
            ' Execute the query
            Dim reader As OdbcDataReader = cmd.ExecuteReader()
            ' Check if there is a row
            If reader.Read() Then
                ' Retrieve sections into numberOfSections variable
                numberOfSections = reader.GetInt32(0)
                ' Retrieve questions into a string
                Dim questionsString As String = reader.GetString(1)
                ' Parse the string of integers into a list of integers
                Dim integerStrings() As String = questionsString.Split(","c)
                For Each intString As String In integerStrings
                    Dim intValue As Integer
                    If Integer.TryParse(intString, intValue) Then
                        numberOfQuestions.Add(intValue)
                    Else
                        MessageBox.Show("Error parsing the string of number of questions", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Next
                ' Now you have the numberOfSections and listOfIntegers
                MessageBox.Show("numberOfSections: " & numberOfSections.ToString() & vbCrLf &
                "numberOfQuestions: " & String.Join(",", numberOfQuestions))
            Else
                MessageBox.Show("No data retrieved.")
            End If
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
    End Sub
End Class