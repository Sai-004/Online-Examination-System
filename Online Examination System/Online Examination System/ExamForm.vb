Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class Form1
    Private connectionString As String = "DSN=oee;Uid=root;Pwd=1234"

    Private questionTexts As List(Of String) ' To store the question texts for the current section
    Private currentQuestionIndex As Integer ' To track the current question index

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadSectionsFromDatabase()
    End Sub

    Private Sub LoadSectionsFromDatabase()
        Using connection As New OdbcConnection(connectionString)
            Dim query As String = "SELECT section_id, section_name, no_of_qs FROM section"
            Dim command As New OdbcCommand(query, connection)

            Try
                connection.Open()
                Dim reader As OdbcDataReader = command.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read()
                        Dim sectionId As Integer = reader.GetInt32(0)
                        Dim sectionName As String = reader.GetString(1)
                        Dim questionCount As Integer = reader.GetInt32(2)
                        LoadSection(sectionId, sectionName, questionCount)
                    End While
                End If

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error loading sections: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub LoadSection(ByVal sectionId As Integer, ByVal sectionName As String, ByVal questionCount As Integer)
        Dim sectionLabel As New Label()
        sectionLabel.Text = sectionName
        sectionLabel.AutoSize = True
        sectionLabel.Dock = DockStyle.Top
        sectionLabel.Margin = New Padding(5)


        Dim rowCount As Integer = Math.Ceiling(questionCount / 3)
        Dim questionPanel As New TableLayoutPanel()
        questionPanel.Dock = DockStyle.Top
        questionPanel.AutoSize = True
        questionPanel.ColumnCount = 3
        questionPanel.RowCount = rowCount

        ' Load questions for the section from the database
        questionTexts = New List(Of String)()

        Using connection As New OdbcConnection(connectionString)
            Dim query As String = "SELECT question FROM question_pool WHERE section_id = ?"
            Dim command As New OdbcCommand(query, connection)
            command.Parameters.AddWithValue("?", sectionId)

            Try
                connection.Open()
                Dim reader As OdbcDataReader = command.ExecuteReader()

                While reader.Read()
                    questionTexts.Add(reader.GetString(0))
                End While

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error loading questions for section " & sectionId & ": " & ex.Message)
            End Try
        End Using

        ' Display question buttons
        For i As Integer = 0 To questionCount - 1
            Dim questionButton As New Button()
            questionButton.Text = "Q" & (i + 1)
            questionButton.AutoSize = True
            questionButton.Margin = New Padding(5)
            AddHandler questionButton.Click, AddressOf QuestionButton_Click

            Dim rowIndex As Integer = i \ 3
            Dim columnIndex As Integer = i Mod 3
            questionPanel.Controls.Add(questionButton, columnIndex, rowIndex)
        Next

        SplitContainer1.Panel1.Controls.Add(questionPanel)
        SplitContainer1.Panel1.Controls.Add(sectionLabel)
    End Sub

    Private Sub QuestionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim questionButton As Button = DirectCast(sender, Button)
        Dim parentControl As Control = questionButton.Parent

        If TypeOf parentControl Is TableLayoutPanel Then
            Dim questionPanel As TableLayoutPanel = DirectCast(parentControl, TableLayoutPanel)
            Dim questionIndex As Integer = questionPanel.Controls.GetChildIndex(questionButton)

            ' Update the current question index and display the question text
            currentQuestionIndex = questionIndex
            DisplayQuestionText()
        End If
    End Sub

    Private Sub DisplayQuestionText()
        ' Ensure there are questions loaded and the current question index is valid
        If questionTexts IsNot Nothing AndAlso currentQuestionIndex >= 0 AndAlso currentQuestionIndex < questionTexts.Count Then
            question_text.Text = questionTexts(currentQuestionIndex)
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Move to the next question within the same section
        If currentQuestionIndex < questionTexts.Count - 1 Then
            currentQuestionIndex += 1
            DisplayQuestionText()
        End If
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Move to the previous question within the same section
        If currentQuestionIndex > 0 Then
            currentQuestionIndex -= 1
            DisplayQuestionText()
        End If
    End Sub
End Class