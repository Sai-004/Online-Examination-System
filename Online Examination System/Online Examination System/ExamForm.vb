Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class Form1
    Private connectionString As String = "DSN=oee;Uid=user123;Pwd=1234"
    Private correctans As Integer = -1
    Private questionTextsByQuestionId As New Dictionary(Of KeyValuePair(Of Integer, Integer), String)()
    Private optionsByQuestionId As New Dictionary(Of KeyValuePair(Of Integer, Integer), List(Of String))()
    Private MarkedAnswers As New Dictionary(Of KeyValuePair(Of Integer, Integer), Integer)()
    Private mapping As New Dictionary(Of KeyValuePair(Of Integer, Integer), Integer)()
    Private currentQuestionId As Integer = -1 ' To track the current question ID
    Private currentsectionId As Integer = -1

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadSectionsFromDatabase()
    End Sub

    Private Sub LoadSectionsFromDatabase()
        Using connection As New OdbcConnection(connectionString)
            Dim query As String = "SELECT section_id, section_name, no_of_qs FROM section order by section_id desc"
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
    'returns  number of questions that must be present in each section
    Private Function returnQuestions(ByVal num As Integer) As Integer
        Dim conn As New OdbcConnection(connectionString)
        Dim ans As Integer
        Try
            conn.Open()
            Dim selectQuery As String = "select no_qs from minimum_number_of_questions where section_id=?"
            Using cmdSelect As New OdbcCommand(selectQuery, conn)
                cmdSelect.Parameters.AddWithValue("@section_id", num)
                Dim reader As OdbcDataReader = cmdSelect.ExecuteReader()
                If reader.Read() Then
                    ans = reader.GetInt32(0)
                End If
            End Using
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
        Return ans
    End Function

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
        Dim questionsForSection As New Dictionary(Of KeyValuePair(Of Integer, Integer), String)()
        'Dim mapping As New Dictionary(Of Integer, Integer)
        Using connection As New OdbcConnection(connectionString)
            Dim num As Integer = returnQuestions(sectionId)
            Dim query As String = "SELECT question_id, question, option1, option2, option3, option4 FROM question_pool WHERE section_id = ? ORDER BY RAND() LIMIT ?"
            Dim command As New OdbcCommand(query, connection)
            command.Parameters.AddWithValue("@section_id", sectionId)
            command.Parameters.AddWithValue("?", num)
            Try
                connection.Open()
                Dim reader As OdbcDataReader = command.ExecuteReader()
                Dim j As Integer = 1
                While reader.Read()
                    Dim questionId As Integer = reader.GetInt32(0)
                    mapping.Add(New KeyValuePair(Of Integer, Integer)(j, sectionId), questionId)
                    j = j + 1
                    Dim questionText As String = reader.GetString(1)
                    Dim options As New List(Of String)()
                    For i As Integer = 2 To 5 ' Options start from index 2
                        options.Add(reader.GetString(i))
                    Next
                    questionsForSection.Add(New KeyValuePair(Of Integer, Integer)(j - 1, sectionId), questionText)
                    optionsByQuestionId.Add(New KeyValuePair(Of Integer, Integer)(j - 1, sectionId), options)
                End While

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error loading questions for section " & sectionId & ": " & ex.Message)
            End Try
        End Using

        ' Store questions for the section in the dictionary
        For Each kvp As KeyValuePair(Of KeyValuePair(Of Integer, Integer), String) In questionsForSection
            questionTextsByQuestionId.Add(kvp.Key, kvp.Value)
        Next

        ' Display question buttons
        For Each kvp As KeyValuePair(Of KeyValuePair(Of Integer, Integer), String) In questionsForSection
            Dim questionButton As New Button()
            questionButton.Text = "Q" & kvp.Key.Key ' Display question_id as text
            questionButton.Name = kvp.Key.Value & "_" & kvp.Key.Key ' Set button name to question ID
            questionButton.AutoSize = True
            questionButton.Margin = New Padding(5)
            AddHandler questionButton.Click, AddressOf QuestionButton_Click

            questionPanel.Controls.Add(questionButton)
        Next

        SplitContainer1.Panel1.Controls.Add(questionPanel)
        SplitContainer1.Panel1.Controls.Add(sectionLabel)
    End Sub
    'To get actual question id ,from generated one
    Private Function Actual(ByVal j As Integer, ByVal section_id As Integer) As Integer
        Return mapping(New KeyValuePair(Of Integer, Integer)(j, section_id))
    End Function
    Private Sub QuestionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim questionButton As Button = DirectCast(sender, Button)
        Dim parts() As String = questionButton.Name.Split("_"c)
        Dim questionId As Integer = Integer.Parse(parts(1))
        Dim sectionId As Integer = Integer.Parse(parts(0))

        ' Update the current question ID and display the question text and options

        'currentQuestionId = Actual(questionId, sectionId)
        currentsectionId = sectionId
        DisplayQuestionText(questionId, sectionId)
        DisplayOptions(questionId, sectionId)
    End Sub


    Private Sub DisplayQuestionText(ByVal questionId As Integer, ByVal sectionId As Integer)
        ' Ensure the current question ID is valid
        questionId = Actual(questionId, sectionId)
        If questionTextsByQuestionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(questionId, sectionId))) Then
            question_text.Text = questionTextsByQuestionId((New KeyValuePair(Of Integer, Integer)(questionId, sectionId)))
            ques_no.Text = questionId & ")"
        End If
    End Sub

    Private Sub DisplayOptions(ByVal questionId As Integer, ByVal sectionId As Integer)
        ' Ensure the current question ID is valid
        questionId = Actual(questionId, sectionId)
        If optionsByQuestionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(questionId, sectionId))) Then
            Dim options As List(Of String) = optionsByQuestionId((New KeyValuePair(Of Integer, Integer)(questionId, sectionId)))
            If options.Count >= 4 Then
                opt1.Text = options(0)
                opt2.Text = options(1)
                opt3.Text = options(2)
                opt4.Text = options(3)
            End If
        End If
        If MarkedAnswers.ContainsKey((New KeyValuePair(Of Integer, Integer)(questionId, sectionId))) Then
            Select Case MarkedAnswers((New KeyValuePair(Of Integer, Integer)(questionId, sectionId)))
                Case 1
                    opt1.Checked = True
                Case 2
                    opt2.Checked = True
                Case 3
                    opt3.Checked = True
                Case 4
                    opt4.Checked = True
            End Select
        Else
            opt1.Checked = False
            opt2.Checked = False
            opt3.Checked = False
            opt4.Checked = False

        End If


    End Sub

    Private Sub BtnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveBtn.Click
        ' Move to the next question
        MarkedAnswers(((New KeyValuePair(Of Integer, Integer)(currentQuestionId, currentsectionId)))) = correctans
        Dim nextQuestionId As Integer = currentQuestionId + 1
        Dim nextsectionid As Integer = currentsectionId + 1
        If questionTextsByQuestionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(nextQuestionId, currentsectionId))) Then
            currentQuestionId = nextQuestionId
            DisplayQuestionText(nextQuestionId, currentsectionId)
            DisplayOptions(nextQuestionId, currentsectionId)
        Else
            If questionTextsByQuestionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(1, nextsectionid))) Then
                currentQuestionId = 1
                currentsectionId = nextsectionid
                DisplayQuestionText(1, nextsectionid)
                DisplayOptions(1, nextsectionid)
            End If
        End If
        ' Enable or disable the buttons based on question availability
        ' SaveBtn.Enabled = questionTextsByQuestionId.ContainsKey(currentQuestionId + 1)
        ' PrevBtn.Enabled = True
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrevBtn.Click
        ' Move to the previous question
        Dim prevQuestionId As Integer = currentQuestionId - 1
        Dim prevsectionId As Integer = currentsectionId - 1
        If questionTextsByQuestionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(prevQuestionId, currentsectionId))) Then
            currentQuestionId = prevQuestionId
            DisplayQuestionText(prevQuestionId, currentsectionId)
            DisplayOptions(prevQuestionId, currentsectionId)
        Else
            If questionTextsByQuestionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(1, prevsectionId))) Then
                currentQuestionId = 1
                currentsectionId = prevsectionId
                DisplayQuestionText(1, prevsectionId)
                DisplayOptions(1, prevsectionId)
            End If

        End If
        ' Enable or disable the buttons based on question availability
        '  PrevBtn.Enabled = questionTextsByQuestionId.ContainsKey(currentQuestionId - 1)
        ' SaveBtn.Enabled = True
    End Sub

    Private Sub SubmitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitBtn.Click
        Dim newform As New student_profile()
        newform.Show()
    End Sub

    Private tt As Integer = 1
    Private ss As Integer = 59
    Private vv As Integer = 0

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If vv > 0 Or tt > 0 Or ss > 0 Then
            timer_count.Text = Format(tt, "00:") & Format(ss, "00")
            ss = ss - 1
            If ss < 0 Then
                ss = 59
                tt = tt - 1
            End If
        Else
            timer_count.Text = "00:00"
            timer_count.Enabled = False
            ' MessageBox.Show("Time Ended")
        End If
    End Sub

    Private Sub SplitContainer1_Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub opt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt1.CheckedChanged, opt2.CheckedChanged, opt3.CheckedChanged, opt4.CheckedChanged
        Dim radioButton As RadioButton = CType(sender, RadioButton)
        If radioButton.Checked Then
            Select Case radioButton.Name
                Case "opt1"
                    correctans = 1
                Case "opt2"
                    correctans = 2
                Case "opt3"
                    correctans = 3
                Case "opt4"
                    correctans = 4
            End Select
        End If

    End Sub
End Class
