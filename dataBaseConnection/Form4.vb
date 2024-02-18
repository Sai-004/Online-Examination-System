Imports System.Data.Odbc
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
'This form should open only when admin enters the system for the first time for addition of required number of questions
Public Class Form4
    Dim connString As String = "DSN=oee;Uid=root;Pwd=2004;"
    Dim conn As New OdbcConnection(connString)
    Dim numberOfSections As Integer
    Dim numberOfQuestions As New List(Of Integer)
    Dim currentQuestion As String = ""
    Private sectionData As New List(Of Tuple(Of String, Integer))
    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.AutoScroll = True
        Dim questionsString As String
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Try
            'to fill the variables numberOfSections and numberOfQuestions from database
            conn.Open()
            Dim query As String = "SELECT sections, questions FROM numberOfQuestions"
            Dim cmd As New OdbcCommand(query, conn)
            ' Execute the query
            Dim reader As OdbcDataReader = cmd.ExecuteReader()
            'Dim questionsString As String
            ' Check if there is a row
            If reader.Read() Then
                ' Retrieve sections into numberOfSections variable
                numberOfSections = reader.GetInt32(0)
                ' Retrieve questions into a string
                questionsString = reader.GetString(1)
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
                'MessageBox.Show("numberOfSections: " & numberOfSections.ToString() & vbCrLf &
                '"numberOfQuestions: " & String.Join(",", numberOfQuestions))
            Else
                MessageBox.Show("No data retrieved.")
            End If
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        MessageBox.Show("You must (atleast) enter " & questionsString & " questions in each of the sections respectively, else default values would be set", "information")
        'Filling the table with random questions
        Dim truncateQuery As String = "TRUNCATE TABLE quiz_questions"
        Dim insertQuery As String = "INSERT INTO quiz_questions (section_id, question_id, question_text, option_a, option_b, option_c, option_d, correct_option) VALUES (?, ?, ?, ?, ?, ?, ?, ?)"

        Try
            conn.Open()
            Using cmdTruncate As New OdbcCommand(truncateQuery, conn)
                cmdTruncate.ExecuteNonQuery()
            End Using

            ' Create the command object for inserting questions
            Using cmdInsert As New OdbcCommand(insertQuery, conn)
                ' Loop through sections and questions to insert sample data
                For section As Integer = 1 To numberOfSections
                    For questionId As Integer = 1 To numberOfQuestions(section - 1)
                        ' Sample question text and options
                        Dim questionText As String = "Sample question for Section " & section & ", Question " & questionId
                        Dim optionA As String = "Option A"
                        Dim optionB As String = "Option B"
                        Dim optionC As String = "Option C"
                        Dim optionD As String = "Option D"
                        Dim correctOption As String = "Option A" ' Change as needed

                        ' Set parameters for the insert query
                        cmdInsert.Parameters.AddWithValue("@section_id", section)
                        cmdInsert.Parameters.AddWithValue("@question_id", questionId)
                        cmdInsert.Parameters.AddWithValue("@question_text", questionText)
                        cmdInsert.Parameters.AddWithValue("@option_a", optionA)
                        cmdInsert.Parameters.AddWithValue("@option_b", optionB)
                        cmdInsert.Parameters.AddWithValue("@option_c", optionC)
                        cmdInsert.Parameters.AddWithValue("@option_d", optionD)
                        cmdInsert.Parameters.AddWithValue("@correct_option", correctOption)

                        ' Execute the insert query
                        cmdInsert.ExecuteNonQuery()

                        ' Clear parameters for next iteration
                        cmdInsert.Parameters.Clear()
                    Next
                Next
            End Using
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'filling sectiondata with required tuples
        For i As Integer = 1 To numberOfSections
            ' Check if there are enough integers in the listOfIntegers
            If i <= numberOfQuestions.Count Then
                ' Create a tuple with the section number and an integer from the listOfIntegers
                Dim tuple As New Tuple(Of String, Integer)("Section " & i.ToString(), numberOfQuestions(i - 1))
                ' Add the tuple to the sectionData list
                sectionData.Add(tuple)
            End If
        Next
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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
        End If

        Try
            conn.Open()
            Dim query As String = "SELECT section_id,question_id,question_text,option_a,option_b,option_c,option_d,correct_option FROM quiz_questions where section_id= ? and question_id = ? "
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
                Dim questionText As String = reader("question_text").ToString()
                Dim optionA As String = reader("option_a").ToString()
                Dim optionB As String = reader("option_b").ToString()
                Dim optionC As String = reader("option_c").ToString()
                Dim optionD As String = reader("option_d").ToString()
                Dim correctOption As String = reader("correct_option").ToString()

                ' Process the retrieved data as needed
                ' For example, display it in message boxes
                'MessageBox.Show("Question: " & questionText & vbCrLf &
                '"Option A: " & optionA & vbCrLf &
                '"Option B: " & optionB & vbCrLf &
                '"Option C: " & optionC & vbCrLf &
                '"Option D: " & optionD & vbCrLf &
                '"Correct Option: " & correctOption)
                RichTextBox1.Text = questionText
                RichTextBox2.Text = optionA
                RichTextBox3.Text = optionB
                RichTextBox4.Text = optionC
                RichTextBox5.Text = optionD
                RichTextBox6.Text = correctOption
            Else
                MessageBox.Show("No data found for the given section ID and question ID.")
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error connecting to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
        'RichTextBox1.Text = "You clicked on: " & questionInfo & ". Question details will be displayed here."
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Button2.Enabled = False
        Dim Form3 As New Form3()
        Form3.Show()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim section_id As Integer
        Dim question_id As Integer
        Dim parts() As String = currentQuestion.Split("."c)
        If Integer.TryParse(parts(0), section_id) AndAlso Integer.TryParse(parts(1), question_id) Then
            'save the question to database
            Try
                conn.Open()
                Dim updateQuery As String = "UPDATE quiz_questions " &
                                    "SET question_text = ?, " &
                                    "    option_a = ?, " &
                                    "    option_b = ?, " &
                                    "    option_c = ?, " &
                                    "    option_d = ?, " &
                                    "    correct_option = ? " &
                                    "WHERE section_id = ? AND question_id = ?"
                Using cmdUpdate As New OdbcCommand(updateQuery, conn)
                    ' Set parameters for the update query
                    cmdUpdate.Parameters.AddWithValue("@question_text", RichTextBox1.Text)
                    cmdUpdate.Parameters.AddWithValue("@option_a", RichTextBox2.Text)
                    cmdUpdate.Parameters.AddWithValue("@option_b", RichTextBox3.Text)
                    cmdUpdate.Parameters.AddWithValue("@option_c", RichTextBox4.Text)
                    cmdUpdate.Parameters.AddWithValue("@option_d", RichTextBox5.Text)
                    cmdUpdate.Parameters.AddWithValue("@correct_option", RichTextBox6.Text)
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
    End Sub
End Class