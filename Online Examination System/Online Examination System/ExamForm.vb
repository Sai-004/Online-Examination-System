Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class Form1
    Private connectionString As String = "DSN=oee;Uid=root;Pwd=1234"

    Private questionTextsByQuestionId As New Dictionary(Of Integer, String)()
    Private optionsByQuestionId As New Dictionary(Of Integer, List(Of String))()
    Private currentQuestionId As Integer = -1 ' To track the current question ID

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

        ' Load questions and options for the section from the database
        Dim questionsForSection As New Dictionary(Of Integer, String)()

        Using connection As New OdbcConnection(connectionString)
            Dim query As String = "SELECT question_id, question, option1, option2, option3, option4 FROM question_pool WHERE section_id = ?"
            Dim command As New OdbcCommand(query, connection)
            command.Parameters.AddWithValue("?", sectionId)

            Try
                connection.Open()
                Dim reader As OdbcDataReader = command.ExecuteReader()

                While reader.Read()
                    Dim questionId As Integer = reader.GetInt32(0)
                    Dim questionText As String = reader.GetString(1)
                    Dim options As New List(Of String)()
                    For i As Integer = 2 To 5 ' Options start from index 2
                        options.Add(reader.GetString(i))
                    Next
                    questionsForSection.Add(questionId, questionText)
                    optionsByQuestionId.Add(questionId, options)
                End While

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error loading questions for section " & sectionId & ": " & ex.Message)
            End Try
        End Using

        ' Store questions for the section in the dictionary
        For Each kvp As KeyValuePair(Of Integer, String) In questionsForSection
            questionTextsByQuestionId.Add(kvp.Key, kvp.Value)
        Next

        ' Display question buttons
        For Each kvp As KeyValuePair(Of Integer, String) In questionsForSection
            Dim questionButton As New Button()
            questionButton.Text = "Q" & kvp.Key ' Display question_id as text
            questionButton.Name = kvp.Key.ToString() ' Set button name to question ID
            questionButton.AutoSize = True
            questionButton.Margin = New Padding(5)
            AddHandler questionButton.Click, AddressOf QuestionButton_Click

            questionPanel.Controls.Add(questionButton)
        Next

        SplitContainer1.Panel1.Controls.Add(questionPanel)
        SplitContainer1.Panel1.Controls.Add(sectionLabel)
    End Sub

    Private Sub QuestionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim questionButton As Button = DirectCast(sender, Button)
        Dim questionId As Integer = Integer.Parse(questionButton.Name)

        ' Update the current question ID and display the question text and options
        currentQuestionId = questionId
        DisplayQuestionText(questionId)
        DisplayOptions(questionId)

        ' Disable the clicked button
        questionButton.Enabled = False

        ' Enable all other question buttons
        For Each ctrl As Control In SplitContainer1.Panel1.Controls
            If TypeOf ctrl Is TableLayoutPanel Then
                For Each btn As Control In ctrl.Controls
                    If TypeOf btn Is Button AndAlso btn IsNot questionButton Then
                        btn.Enabled = True
                    End If
                Next
            End If
        Next
    End Sub


    Private Sub DisplayQuestionText(ByVal questionId As Integer)
        ' Ensure the current question ID is valid
        If questionTextsByQuestionId.ContainsKey(questionId) Then
            question_text.Text = questionTextsByQuestionId(questionId)
        End If
    End Sub

    Private Sub DisplayOptions(ByVal questionId As Integer)
        ' Ensure the current question ID is valid
        If optionsByQuestionId.ContainsKey(questionId) Then
            Dim options As List(Of String) = optionsByQuestionId(questionId)
            If options.Count >= 4 Then
                opt1.Text = options(0)
                opt2.Text = options(1)
                opt3.Text = options(2)
                opt4.Text = options(3)
            End If
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveBtn.Click
        ' Move to the next question
        Dim nextQuestionId As Integer = currentQuestionId + 1

        If questionTextsByQuestionId.ContainsKey(nextQuestionId) Then
            currentQuestionId = nextQuestionId
            DisplayQuestionText(nextQuestionId)
            DisplayOptions(nextQuestionId)
        End If
        ' Enable or disable the buttons based on question availability
        SaveBtn.Enabled = questionTextsByQuestionId.ContainsKey(currentQuestionId + 1)
        PrevBtn.Enabled = True
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrevBtn.Click
        ' Move to the previous question
        Dim prevQuestionId As Integer = currentQuestionId - 1

        If questionTextsByQuestionId.ContainsKey(prevQuestionId) Then
            currentQuestionId = prevQuestionId
            DisplayQuestionText(prevQuestionId)
            DisplayOptions(prevQuestionId)
        End If
        ' Enable or disable the buttons based on question availability
        PrevBtn.Enabled = questionTextsByQuestionId.ContainsKey(currentQuestionId - 1)
        SaveBtn.Enabled = True
    End Sub
End Class