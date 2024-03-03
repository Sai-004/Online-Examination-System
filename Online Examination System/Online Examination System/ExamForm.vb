Imports System.Windows.Forms
Imports System.Data.Odbc

Public Class Form
    Private connectionString As String = "DSN=oee;Uid=user123;Pwd=1234"

    ' Frequently used Dictionaries
    Private questionTextsBySectionId As New Dictionary(Of KeyValuePair(Of Integer, Integer), String)()
    Private optionsBySectionId As New Dictionary(Of KeyValuePair(Of Integer, Integer), List(Of String))()
    Private MarkedAnswers As New Dictionary(Of KeyValuePair(Of Integer, Integer), Integer)()
    Private Mapping As New Dictionary(Of KeyValuePair(Of Integer, Integer), Integer)()

    Private currentQuestionId As Integer = -1   ' To track the current question ID
    Private currentSectionId As Integer = -1    ' To track the current section ID
    Private selectedAns As Integer = -1         ' To save the selected answer

    Private Sub Form_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadSectionsFromDatabase()
        currentQuestionId = 1
        currentSectionId = 1
        DisplayQuestionText(1, 1)
        DisplayOptions(1, 1)
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
        questionPanel.Name = sectionId.ToString()
        questionPanel.Dock = DockStyle.Top
        questionPanel.AutoSize = True
        questionPanel.ColumnCount = 3
        questionPanel.RowCount = rowCount

        ' Load questions and options for the section from the database
        Dim questionsForSection As New Dictionary(Of KeyValuePair(Of Integer, Integer), String)()

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
                    Mapping.Add(New KeyValuePair(Of Integer, Integer)(j, sectionId), questionId)

                    Dim questionText As String = reader.GetString(1)
                    Dim options As New List(Of String)()
                    For i As Integer = 2 To 5 ' Options start from index 2
                        options.Add(reader.GetString(i))
                    Next

                    questionsForSection.Add(New KeyValuePair(Of Integer, Integer)(j, sectionId), questionText)
                    optionsBySectionId.Add(New KeyValuePair(Of Integer, Integer)(j, sectionId), options)
                    j = j + 1
                End While

                reader.Close()
            Catch ex As Exception
                MessageBox.Show("Error loading questions for section " & sectionId & ": " & ex.Message)
            End Try
        End Using

        ' Store questions for the section in the dictionary
        For Each kvp As KeyValuePair(Of KeyValuePair(Of Integer, Integer), String) In questionsForSection
            questionTextsBySectionId.Add(kvp.Key, kvp.Value)
        Next

        ' Display question buttons
        For Each kvp As KeyValuePair(Of KeyValuePair(Of Integer, Integer), String) In questionsForSection
            Dim questionButton As New Button()
            questionButton.Text = "Q" & kvp.Key.Key ' Display question_id as text
            questionButton.Name = kvp.Key.Value & "_" & kvp.Key.Key ' Set button name to sectionId_quesNum
            questionButton.AutoSize = True
            questionButton.Margin = New Padding(5)
            AddHandler questionButton.Click, AddressOf QuestionButton_Click

            questionPanel.Controls.Add(questionButton)
        Next
        'Zaxs
        SplitContainer1.Panel1.Controls.Add(questionPanel)
        SplitContainer1.Panel1.Controls.Add(sectionLabel)
    End Sub

    'To get actual question id ,from generated one
    Private Function ActualQuestionId(ByVal j As Integer, ByVal section_id As Integer) As Integer
        Return Mapping(New KeyValuePair(Of Integer, Integer)(j, section_id))
    End Function

    Private Sub QuestionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim questionButton As Button = DirectCast(sender, Button)
        Dim parts() As String = questionButton.Name.Split("_"c)
        Dim questionId As Integer = Integer.Parse(parts(1))
        Dim sectionId As Integer = Integer.Parse(parts(0))

        ' Update the current question ID and display the question text and options
        currentQuestionId = questionId
        currentSectionId = sectionId
        DisplayQuestionText(questionId, sectionId)
        DisplayOptions(questionId, sectionId)
    End Sub


    Private Sub DisplayQuestionText(ByVal questionId As Integer, ByVal sectionId As Integer)
        If questionTextsBySectionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(questionId, sectionId))) Then
            question_text.Text = questionTextsBySectionId((New KeyValuePair(Of Integer, Integer)(questionId, sectionId)))
            qNum_label.Text = questionId & ")"
        End If
    End Sub

    Private Sub DisplayOptions(ByVal questionId As Integer, ByVal sectionId As Integer)
        If optionsBySectionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(questionId, sectionId))) Then
            Dim options As List(Of String) = optionsBySectionId((New KeyValuePair(Of Integer, Integer)(questionId, sectionId)))
            If options.Count >= 4 Then
                opt1.Text = options(0)
                opt2.Text = options(1)
                opt3.Text = options(2)
                opt4.Text = options(3)
            End If
        End If
        If MarkedAnswers.ContainsKey((New KeyValuePair(Of Integer, Integer)(ActualQuestionId(questionId, sectionId), sectionId))) Then
            Select Case MarkedAnswers((New KeyValuePair(Of Integer, Integer)(ActualQuestionId(questionId, sectionId), sectionId)))
                Case 1
                    opt1.Checked = True
                Case 2
                    opt2.Checked = True
                Case 3
                    opt3.Checked = True
                Case 4
                    opt4.Checked = True
                Case -1
                    opt1.Checked = False
                    opt2.Checked = False
                    opt3.Checked = False
                    opt4.Checked = False
            End Select
        Else
            opt1.Checked = False
            opt2.Checked = False
            opt3.Checked = False
            opt4.Checked = False
        End If
    End Sub

    Private Sub BtnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveBtn.Click
        ' Mark question as answered if selected an option
        If opt1.Checked = True Or opt2.Checked = True Or opt3.Checked = True Or opt4.Checked = True Then
            changeBtnColor(currentSectionId, currentQuestionId, "save")
            ' Save the marked answer
            MarkedAnswers(New KeyValuePair(Of Integer, Integer)(ActualQuestionId(currentQuestionId, currentSectionId), currentSectionId)) = selectedAns
        End If



        Dim nextQuestionId As Integer = currentQuestionId + 1
        Dim nextsectionid As Integer = currentSectionId + 1

        If questionTextsBySectionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(nextQuestionId, currentsectionId))) Then
            ' Move to next question in same section
            currentQuestionId = nextQuestionId
            DisplayQuestionText(nextQuestionId, currentsectionId)
            DisplayOptions(nextQuestionId, currentsectionId)
        Else
            If questionTextsBySectionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(1, nextsectionid))) Then
                ' Move to next section
                currentQuestionId = 1
                currentSectionId = nextsectionid
                DisplayQuestionText(1, nextsectionid)
                DisplayOptions(1, nextsectionid)
            End If
        End If

        ' Enable or disable the buttons based on question availability
        ' SaveBtn.Enabled = questionTextsByQuestionId.ContainsKey(currentQuestionId + 1)
        ' PrevBtn.Enabled = True
    End Sub

    Private Sub BtnPrevious_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PrevBtn.Click
        Dim prevQuestionId As Integer = currentQuestionId - 1
        Dim prevsectionId As Integer = currentSectionId - 1

        If questionTextsBySectionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(prevQuestionId, currentsectionId))) Then
            ' Move to previous question in same section
            currentQuestionId = prevQuestionId
            DisplayQuestionText(prevQuestionId, currentsectionId)
            DisplayOptions(prevQuestionId, currentsectionId)
        Else
            If questionTextsBySectionId.ContainsKey((New KeyValuePair(Of Integer, Integer)(1, prevsectionId))) Then
                ' Move to first question of previous section
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

    Private tt As Integer = 1
    Private ss As Integer = 59
    Private vv As Integer = 0
    Private temp As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If vv > 0 Or tt > 0 Or ss > 0 Then
            timer_count.Text = Format(tt, "00:") & Format(ss, "00")
            ss = ss - 1
            If ss < 0 Then
                ss = 59S
                tt = tt - 1
            End If
        Else
            If temp = 0 Then
                timer_count.Text = "00:00"
                ' Save the selected answers to the database

                SaveSelectedAnswersToDatabase()

                ' Open a new instance of student_profile form with the roll number parameter
                Dim newform As New student_profile(70) ' Pass the roll number here
                newform.Show()
                Me.WindowState = FormWindowState.Minimized
                timer_count.Enabled = False
                temp = temp + 1
                ' MessageBox.Show("Time Ended")
            End If
            End If
    End Sub

    Private Sub opt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt1.CheckedChanged, opt2.CheckedChanged, opt3.CheckedChanged, opt4.CheckedChanged
        Dim radioButton As RadioButton = CType(sender, RadioButton)

        If radioButton.Checked Then
            Select Case radioButton.Name
                Case "opt1"
                    selectedAns = 1
                Case "opt2"
                    selectedAns = 2
                Case "opt3"
                    selectedAns = 3
                Case "opt4"
                    selectedAns = 4
            End Select
        End If
    End Sub

    Private Sub changeBtnColor(ByVal sectionIdToChange As Integer, ByVal questionNumToChange As Integer, ByVal type As String)
        ' Iterate through controls in SplitContainer1.Panel1 to find the questionPanel
        For Each control As Control In SplitContainer1.Panel1.Controls
            If TypeOf control Is TableLayoutPanel AndAlso control.Name = sectionIdToChange.ToString() Then
                ' Iterate through controls in the questionPanel to find the specific question button
                For Each button As Control In control.Controls
                    If TypeOf button Is Button Then
                        Dim buttonNameParts As String() = button.Name.Split("_"c)
                        If buttonNameParts.Length = 2 Then
                            Dim buttonSectionId As Integer
                            Dim buttonQuestionNumber As Integer
                            If Integer.TryParse(buttonNameParts(0), buttonSectionId) AndAlso
                               Integer.TryParse(buttonNameParts(1), buttonQuestionNumber) Then
                                If buttonSectionId = sectionIdToChange AndAlso buttonQuestionNumber = questionNumToChange Then
                                    If button.BackColor = Color.SkyBlue Then
                                        button.BackColor = SystemColors.Control
                                    ElseIf type = "review" Then
                                        ' Change the color of the button
                                        button.BackColor = Color.SkyBlue
                                    ElseIf type = "save" Then
                                        button.BackColor = Color.LightGreen
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub ReviewBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReviewBtn.Click
        changeBtnColor(currentSectionId, currentQuestionId, "review")
    End Sub

    Private Sub SubmitBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitBtn.Click
        ' Save the selected answers to the database
        If temp = 0 Then
            SaveSelectedAnswersToDatabase()

            ' Open a new instance of student_profile form with the roll number parameter
            Dim newform As New student_profile(70) ' Pass the roll number here
            newform.Show()
            Me.WindowState = FormWindowState.Minimized
            temp = temp + 1
        End If
        ' Me.Close()
    End Sub


    ' Method to save selected answers to the database
    Private Sub SaveSelectedAnswersToDatabase()
        Using connection As New OdbcConnection(connectionString)
            Try
                connection.Open()

                ' Iterate through the MarkedAnswers dictionary and save each entry to the database
                For Each entry As KeyValuePair(Of KeyValuePair(Of Integer, Integer), Integer) In MarkedAnswers
                    Dim section_id As Integer = entry.Key.Value
                    Dim question_id As Integer = entry.Key.Key

                    Dim selected_answer_int As Integer = entry.Value
                    Dim selected_answer As String
                    Select Case selected_answer_int
                        Case 1
                            selected_answer = "Option A"
                        Case 2
                            selected_answer = "Option B"
                        Case 3
                            selected_answer = "Option C"
                        Case 4
                            selected_answer = "Option D"
                        Case Else
                            selected_answer = "-1"
                    End Select

                    Dim query As String = "INSERT INTO student_answers (roll_number, section_id, question_id, selected_answer) VALUES (?, ?, ?, ?)"
                    Using command As New OdbcCommand(query, connection)
                        command.Parameters.AddWithValue("@roll_number", 70) ' Assuming fixed roll number
                        command.Parameters.AddWithValue("@section_id", section_id)
                        command.Parameters.AddWithValue("@question_id", question_id)
                        command.Parameters.AddWithValue("@selected_answer", selected_answer)
                        command.ExecuteNonQuery()
                    End Using
                Next
            Catch ex As Exception
                MessageBox.Show("Error saving answers to the database: " & ex.Message)
            End Try
        End Using
    End Sub
End Class