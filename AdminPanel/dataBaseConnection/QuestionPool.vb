Imports System.Data.Odbc
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

'This form does question pool management like add,edit and delete(for when admin comes not first time)
Public Class QuestionPool
    Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234;"
    Dim conn As New OdbcConnection(connString)
    Dim numberOfSections As Integer
    Dim numberOfQuestions As New List(Of Integer)
    Dim marksOfSections As New List(Of Integer)
    Dim sectionNames As New List(Of String)
    Dim currentQuestion As String = ""
    Dim correctAnswer As String
    Dim markedAnswers As New Dictionary(Of KeyValuePair(Of Integer, Integer), Integer)()
    Dim currentQuestionId As Integer = -1
    Dim currentSectionId As Integer = -1
    Private sectionData As New List(Of Tuple(Of String, Integer))

    Private Sub question_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.AutoScroll = True
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            'to fill the variables numberOfSections and numberOfQuestions from database
            conn.Open()
            Dim query As String = "SELECT sections from admin"
            Dim cmd As New OdbcCommand(query, conn)
            ' Execute the query
            Dim reader As OdbcDataReader = cmd.ExecuteReader()
            'Dim questionsString As String
            ' Check if there is a row
            If reader.Read() Then
                ' Retrieve sections into numberOfSections variable
                numberOfSections = reader.GetInt32(0)
                ' Retrieve questions into a string
            Else
                MessageBox.Show("No data retrieved.")
            End If
            reader.Close()

            Dim selectQuery As String = "SELECT section_name, no_of_qs,marks FROM section"
            Using cmdSelect As New OdbcCommand(selectQuery, conn)
                ' Execute the SELECT query and get the data reader
                Dim reader2 As OdbcDataReader = cmdSelect.ExecuteReader()

                ' Read data from the data reader
                While reader2.Read()
                    ' Read section name and number of questions
                    Dim sectionName As String = reader2("section_name").ToString()
                    Dim numberOfQs As Integer = Convert.ToInt32(reader2("no_of_qs"))
                    Dim marks As Integer = Convert.ToInt32(reader2("marks"))
                    ' Add section name and number of questions to the lists
                    sectionNames.Add(sectionName)
                    numberOfQuestions.Add(numberOfQs)
                    marksOfSections.Add(marks)
                End While

                ' Close the data reader
                reader2.Close()
            End Using
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'filling sectiondata with required tuples
        For i As Integer = 1 To numberOfSections
            ' Check if there are enough integers in the listOfIntegers
            If i <= numberOfQuestions.Count Then
                ' Create a tuple with the section number and an integer from the listOfIntegers
                Dim tuple As New Tuple(Of String, Integer)(sectionNames(i - 1), numberOfQuestions(i - 1))
                ' Add the tuple to the sectionData list
                sectionData.Add(tuple)
            End If
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'MessageBox.Show(numberOfQuestions(0))
        LoadSections()
    End Sub

    Private Sub LoadSections()
        ' Iterate through the list of tuples in reverse order and create labels for sections and question buttons
        For i As Integer = sectionData.Count - 1 To 0 Step -1
            Dim sectionLabel As New Label()
            sectionLabel.Text = sectionData(i).Item1 ' Item1 is the section name
            sectionLabel.AutoSize = True
            sectionLabel.Dock = DockStyle.Top
            sectionLabel.Margin = New Padding(5)
            Dim myFont As New Font("Arial", 12)
            sectionLabel.Font = myFont
            Dim questionCount As Integer = sectionData(i).Item2 ' Item2 is the number of questions
            ' Add question buttons for each section
            Dim rowCount As Integer = Math.Ceiling(questionCount / 3)
            Dim questionPanel As New TableLayoutPanel()
            questionPanel.Dock = DockStyle.Top
            questionPanel.AutoSize = True
            questionPanel.ColumnCount = 4
            questionPanel.RowCount = rowCount

            For j As Integer = 1 To questionCount
                Dim questionButton As New Button()
                'questionButton.Text = "S" & i & ", Q  " & j
                questionButton.Text = (i + 1) & "." & j
                questionButton.TextAlign = ContentAlignment.TopLeft
                questionButton.Width = 50
                questionButton.Height = 30
                Dim rowIndex As Integer = (j - 1) \ 3
                Dim columnIndex As Integer = (j - 1) Mod 3
                Dim myFont1 As New Font("Arial", 10)
                questionButton.Font = myFont1
                AddHandler questionButton.Click, AddressOf QuestionButton_Click
                questionPanel.Controls.Add(questionButton, columnIndex, rowIndex)
            Next
            ' Add question panel to the SplitContainer1.Panel1.Controls
            Panel1.Controls.Add(questionPanel)
            Panel1.Controls.Add(sectionLabel)
        Next
    End Sub

    Private Sub QuestionButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Handle click event of question buttons
        Dim questionButton As Button = DirectCast(sender, Button)
        Dim questionInfo As String = questionButton.Text
        currentQuestion = questionInfo
        'MessageBox.Show(questionInfo)
        ' Here you can change the question in the right panel
        ' For now, let's just change the text in a textbox
        Dim section_id As Integer
        Dim question_id As Integer
        Dim parts() As String = questionInfo.Split("."c)
        If Integer.TryParse(parts(0), section_id) AndAlso Integer.TryParse(parts(1), question_id) Then
            ' Use integerPart and fractionalPart here
            'Console.WriteLine("Integer part: " & section_id)
            'Console.WriteLine("Fractional part: " & question_id)
            currentQuestionId = question_id
            currentSectionId = section_id
        End If
        Dim p As Integer = 0
        Try
            conn.Open()
            Dim query As String = "SELECT question_id,section_id,question,answer,option1,option2,option3,option4 FROM question_pool where section_id= ? and question_id = ? "
            Dim cmd As New OdbcCommand(query, conn)
            cmd.Parameters.AddWithValue("@section_id", section_id)
            cmd.Parameters.AddWithValue("@question_id", question_id)
            ' Execute the query
            Dim reader As OdbcDataReader = cmd.ExecuteReader()
            'here reader reads the row if exists and stores the results into separate strings to be stored into rich text boxes
            If reader.HasRows Then
                ' Read the first row
                reader.Read()

                ' Retrieve the values as strings
                Dim questionText As String = reader("question").ToString()
                Dim optionA As String = reader("option1").ToString()
                Dim optionB As String = reader("option2").ToString()
                Dim optionC As String = reader("option3").ToString()
                Dim optionD As String = reader("option4").ToString()
                Dim correctOption As String = reader("answer").ToString()

                ' Process the retrieved data as needed
                ' For example, display it in message boxes
                'MessageBox.Show("Question: " & questionText & vbCrLf &
                '"Option A: " & optionA & vbCrLf &
                '"Option B: " & optionB & vbCrLf &
                '"Option C: " & optionC & vbCrLf &
                '"Option D: " & optionD & vbCrLf &
                '"Correct Option: " & correctOption)
                Ques_tb.Text = questionText
                optA_tb.Text = optionA
                optB_tb.Text = optionB
                optC_tb.Text = optionC
                optD_tb.Text = optionD
                correctAnswer = correctOption
                If correctOption = optionA Then
                    p = 1
                ElseIf correctOption = optionB Then
                    p = 2
                ElseIf correctOption = optionC Then
                    p = 3
                ElseIf correctOption = optionD Then
                    p = 4
                End If
                'opt1.Checked = True
            Else
                MessageBox.Show("No data found for the given section ID and question ID.")
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error connecting to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        If markedAnswers.ContainsKey((New KeyValuePair(Of Integer, Integer)(question_id, section_id))) Then
            Select Case markedAnswers((New KeyValuePair(Of Integer, Integer)(question_id, section_id)))
                Case 1
                    opt1.Checked = True
                Case 2
                    opt2.Checked = True
                Case 3
                    opt3.Checked = True
                Case 4
                    opt4.Checked = True
            End Select
        ElseIf p = 1 Then
            opt1.Checked = True
        ElseIf p = 2 Then
            opt2.Checked = True
        ElseIf p = 3 Then
            opt3.Checked = True
        ElseIf p = 4 Then
            opt4.Checked = True
        End If
    End Sub

    Private Sub addQsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles addQsBtn.Click
        'This shows adding a function
        Dim AddQsForm As New AddQuestions()
        AddQsForm.Show()
        Me.Hide()
    End Sub

    'below sub is for edit the current question
    Private Sub editQsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles editQsBtn.Click
        If editQsBtn.Text = "Edit Question" Then
            Ques_tb.ReadOnly = False
            optA_tb.ReadOnly = False
            optB_tb.ReadOnly = False
            optC_tb.ReadOnly = False
            optD_tb.ReadOnly = False

            Ques_tb.BackColor = SystemColors.Window
            optA_tb.BackColor = SystemColors.Window
            optB_tb.BackColor = SystemColors.Window
            optC_tb.BackColor = SystemColors.Window
            optD_tb.BackColor = SystemColors.Window

            Ques_tb.BorderStyle = BorderStyle.Fixed3D
            optA_tb.BorderStyle = BorderStyle.Fixed3D
            optB_tb.BorderStyle = BorderStyle.Fixed3D
            optC_tb.BorderStyle = BorderStyle.Fixed3D
            optD_tb.BorderStyle = BorderStyle.Fixed3D

            editQsBtn.Text = "Save Question"
        Else
            Dim section_id As Integer
            Dim question_id As Integer
            Dim parts() As String = currentQuestion.Split("."c)
            If Integer.TryParse(parts(0), section_id) AndAlso Integer.TryParse(parts(1), question_id) Then
                'save the question to database
                If opt1.Checked = True Then
                    markedAnswers(New KeyValuePair(Of Integer, Integer)(currentQuestionId, currentSectionId)) = 1
                ElseIf opt2.Checked = True Then
                    markedAnswers(New KeyValuePair(Of Integer, Integer)(currentQuestionId, currentSectionId)) = 2
                ElseIf opt3.Checked = True Then
                    markedAnswers(New KeyValuePair(Of Integer, Integer)(currentQuestionId, currentSectionId)) = 3
                ElseIf opt4.Checked = True Then
                    markedAnswers(New KeyValuePair(Of Integer, Integer)(currentQuestionId, currentSectionId)) = 4
                End If
                If String.IsNullOrEmpty(Ques_tb.Text) Or String.IsNullOrWhiteSpace(Ques_tb.Text) Or String.IsNullOrEmpty(optA_tb.Text) Or String.IsNullOrWhiteSpace(optA_tb.Text) Or String.IsNullOrEmpty(optB_tb.Text) Or String.IsNullOrWhiteSpace(optB_tb.Text) Or String.IsNullOrEmpty(optC_tb.Text) Or String.IsNullOrWhiteSpace(optC_tb.Text) Or String.IsNullOrEmpty(optD_tb.Text) Or String.IsNullOrWhiteSpace(optD_tb.Text) Then
                    MessageBox.Show("Empty text is not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Try
                    conn.Open()
                    Dim updateQuery As String = "UPDATE question_pool " &
                                        "SET question = ?, " &
                                        "    option1 = ?, " &
                                        "    option2 = ?, " &
                                        "    option3 = ?, " &
                                        "    option4 = ?, " &
                                        "    answer = ? " &
                                        "WHERE section_id = ? AND question_id = ?"
                    Using cmdUpdate As New OdbcCommand(updateQuery, conn)
                        ' Set parameters for the update query
                        If Ques_tb.Text = "" Then 'if empty value is entered stop the execution
                            MessageBox.Show("0 length text is not allowed")
                            Me.Close()
                        End If
                        cmdUpdate.Parameters.AddWithValue("@question", Ques_tb.Text)
                        cmdUpdate.Parameters.AddWithValue("@option1", optA_tb.Text)
                        cmdUpdate.Parameters.AddWithValue("@option2", optB_tb.Text)
                        cmdUpdate.Parameters.AddWithValue("@option3", optC_tb.Text)
                        cmdUpdate.Parameters.AddWithValue("@option4", optD_tb.Text)
                        cmdUpdate.Parameters.AddWithValue("@answer", correctAnswer)
                        cmdUpdate.Parameters.AddWithValue("@section_id", section_id)
                        cmdUpdate.Parameters.AddWithValue("@question_id", question_id)
                        ' Execute the update query
                        cmdUpdate.ExecuteNonQuery()
                    End Using
                Catch ex As Exception

                Finally
                    conn.Close()
                End Try
            End If
            Ques_tb.ReadOnly = True
            optA_tb.ReadOnly = True
            optB_tb.ReadOnly = True
            optC_tb.ReadOnly = True
            optD_tb.ReadOnly = True

            Ques_tb.BackColor = Color.Snow
            optA_tb.BackColor = Color.Snow
            optB_tb.BackColor = Color.Snow
            optC_tb.BackColor = Color.Snow
            optD_tb.BackColor = Color.Snow

            Ques_tb.BorderStyle = BorderStyle.None
            optA_tb.BorderStyle = BorderStyle.None
            optB_tb.BorderStyle = BorderStyle.None
            optC_tb.BorderStyle = BorderStyle.None
            optD_tb.BorderStyle = BorderStyle.None

            editQsBtn.Text = "Edit Question"
        End If
        
    End Sub

    'delete button functionality
    Private Sub delQsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delQsBtn.Click
        'section_id and question_id of the question clicked
        Dim section_id As Integer
        Dim question_id As Integer
        Dim parts() As String = currentQuestion.Split("."c)
        If Integer.TryParse(parts(0), section_id) AndAlso Integer.TryParse(parts(1), question_id) Then
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''to be added
        'check for minimum condition here ,if doesnt satisfy don't delete
        'we have to alter the ids of rest of the questions in that section and reflect the same in question_pool table
        'this should also reflect on the display
        Try
            conn.Open()
            'MessageBox.Show("section_id" & section_id & " question_id" & question_id)
            Dim min_number As Integer

            Dim selectQuery As String = "select no_qs from minimum_number_of_questions where section_id=?"
            Using cmdSelect As New OdbcCommand(selectQuery, conn)
                cmdSelect.Parameters.AddWithValue("@section_id", section_id)
                Dim reader As OdbcDataReader = cmdSelect.ExecuteReader()
                reader.Read()
                min_number = Convert.ToInt32(reader("no_qs"))
            End Using
            'MessageBox.Show(min_number)

            If min_number = numberOfQuestions(section_id - 1) Then
                MessageBox.Show("Invalid delete operation", "error")
                conn.Close()
                Exit Sub
            End If
            Dim deleteQuery As String = "DELETE from question_pool where section_id= ? and question_id= ? "
            Using cmdDelete As New OdbcCommand(deleteQuery, conn)
                cmdDelete.Parameters.AddWithValue("@section_id", section_id)
                cmdDelete.Parameters.AddWithValue("@question_id", question_id)
                cmdDelete.ExecuteNonQuery()
            End Using
            Dim updateQuery As String = "UPDATE question_pool set question_id = ? where section_id = ? and question_id = ?"
            For questionId As Integer = question_id + 1 To numberOfQuestions(section_id - 1) Step 1
                Using cmdUpdate As New OdbcCommand(updateQuery, conn)
                    cmdUpdate.Parameters.AddWithValue("@question_id", questionId - 1)
                    cmdUpdate.Parameters.AddWithValue("@section_id", section_id)
                    cmdUpdate.Parameters.AddWithValue("@question_id", questionId)
                    cmdUpdate.ExecuteNonQuery()
                    cmdUpdate.Parameters.Clear()
                End Using
            Next
            numberOfQuestions(section_id - 1) = numberOfQuestions(section_id - 1) - 1
            updateQuery = "UPDATE section set no_of_qs = ? where section_id = ? "
            Using cmdUpdate As New OdbcCommand(updateQuery, conn)
                cmdUpdate.Parameters.AddWithValue("@section_id", section_id)
                cmdUpdate.Parameters.AddWithValue("@no_of_qs", numberOfQuestions(section_id - 1))
                cmdUpdate.ExecuteNonQuery()
            End Using
            'sectionData(section_id - 1).Item2 = numberOfQuestions(section_id - 1)
            Dim tuple As New Tuple(Of String, Integer)(sectionNames(section_id - 1), numberOfQuestions(section_id - 1))
            sectionData(section_id - 1) = tuple
            For i As Integer = Panel1.Controls.Count - 1 To 0 Step -1
                Dim ctrl As Control = Panel1.Controls(i)
                If TypeOf ctrl Is Label Then
                    ctrl.Dispose() ' Dispose the label control
                Else
                    ctrl.Dispose()
                End If
            Next
            LoadSections()
        Catch ex As Exception

        Finally
            conn.Close()
        End Try

        ' clearing all rich text boxes after deleting a question 
        Ques_tb.Clear()
        optA_tb.Clear()
        optB_tb.Clear()
        optC_tb.Clear()
        optD_tb.Clear()

    End Sub

    Private Sub opt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt1.CheckedChanged, opt2.CheckedChanged, opt3.CheckedChanged, opt4.CheckedChanged
        Dim radioButton As RadioButton = CType(sender, RadioButton)
        If radioButton.Checked Then
            Select Case radioButton.Name
                Case "opt1"
                    correctAnswer = optA_tb.Text
                Case "opt2"
                    correctAnswer = optB_tb.Text
                Case "opt3"
                    correctAnswer = optC_tb.Text
                Case "opt4"
                    correctAnswer = optD_tb.Text
            End Select
        End If

    End Sub
End Class