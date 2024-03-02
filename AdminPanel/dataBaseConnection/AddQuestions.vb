'This is for adding a question to a section
Imports System.Data.Odbc
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class AddQuestions
    Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234;"
    Dim conn As New OdbcConnection(connString)
    Dim numberOfSections As Integer
    Dim numberOfQuestions As New List(Of Integer)
    Dim marksOfSections As New List(Of Integer)
    Dim sectionNames As New List(Of String)
    Dim correctOption As String
    Private selectedOption As String
    Dim selected As String = False
    Dim empty As String = False

    Private Sub ADD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        selected = False
        empty = False
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
        For i As Integer = 1 To numberOfSections Step 1
            ComboBox1.Items.Add(sectionNames(i - 1))
            'MessageBox.Show(sectionNames(i - 1))
        Next
        ComboBox1.SelectedIndex = 0
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        'RadioButton4.Checked = True
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Add items to the ComboBox
        selectedOption = ComboBox1.SelectedItem.ToString()
    End Sub

    Private Sub opt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles opt1.CheckedChanged, opt2.CheckedChanged, opt3.CheckedChanged, opt4.CheckedChanged
        Dim radioButton As RadioButton = CType(sender, RadioButton)
        If radioButton.Checked Then
            Select Case radioButton.Name
                Case "opt1"
                    correctOption = opt1.Text
                    selected = True
                Case "opt2"
                    correctOption = opt2.Text
                    selected = True
                Case "opt3"
                    correctOption = opt3.Text
                    selected = True
                Case "opt4"
                    correctOption = opt4.Text
                    selected = True
            End Select
        End If

    End Sub

    Private Sub checkForEmptiness()
        Dim cond As Boolean = True
        If String.IsNullOrEmpty(Ques_tb.Text) Or String.IsNullOrEmpty(optA_tb.Text) Or String.IsNullOrEmpty(optB_tb.Text) Or String.IsNullOrEmpty(optC_tb.Text) Or String.IsNullOrEmpty(optD_tb.Text) Or String.IsNullOrWhiteSpace(Ques_tb.Text) Or String.IsNullOrWhiteSpace(optA_tb.Text) Or String.IsNullOrWhiteSpace(optB_tb.Text) Or String.IsNullOrWhiteSpace(optC_tb.Text) Or String.IsNullOrWhiteSpace(optD_tb.Text) Then
            cond = False
        End If
        If cond = False Then
            MessageBox.Show("Empty text is not allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim Form7 As New AddQuestions()
            Form7.Show()
            Me.Hide()
            empty = True
            Exit Sub
        End If
        If selected = False Then
            MessageBox.Show("No correct option is selected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim Form7 As New AddQuestions()
            Form7.Show()
            Me.Hide()
            empty = True
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim section_id As Integer
        For i As Integer = 1 To numberOfSections
            If sectionNames(i - 1) = selectedOption Then
                section_id = i
                Exit For
            End If
        Next
        checkForEmptiness()
        If empty Then
            Exit Sub
        End If
        'change the tables and open the question pool management form again
        numberOfQuestions(section_id - 1) = numberOfQuestions(section_id - 1) + 1
        'MessageBox.Show(section_id, numberOfQuestions(section_id - 1))
        Try
            conn.Open()
            'MessageBox.Show("before insertion")
            Dim updateQuery As String = "UPDATE section SET no_of_qs = ? WHERE section_id = ? "
            Using cmdUpdate As New OdbcCommand(updateQuery, conn)
                cmdUpdate.Parameters.AddWithValue("@no_of_qs", numberOfQuestions(section_id - 1))
                cmdUpdate.Parameters.AddWithValue("@section_id", section_id)
                'MessageBox.Show(numberOfQuestions(section_id - 1) & "hereerre")
                cmdUpdate.ExecuteNonQuery()
            End Using
            Dim insertQuery As String = "insert into question_pool(question_id,section_id,question,answer,option1,option2,option3,option4) values (?,?,?,?,?,?,?,?)"
            Using cmdInsert As New OdbcCommand(insertQuery, conn)
                cmdInsert.Parameters.AddWithValue("@question_id", numberOfQuestions(section_id - 1))
                cmdInsert.Parameters.AddWithValue("@section_id", section_id)
                cmdInsert.Parameters.AddWithValue("@question", Ques_tb.Text)
                cmdInsert.Parameters.AddWithValue("@answer", correctOption)
                cmdInsert.Parameters.AddWithValue("@option1", optA_tb.Text)
                cmdInsert.Parameters.AddWithValue("@option2", optB_tb.Text)
                cmdInsert.Parameters.AddWithValue("@option3", optC_tb.Text)
                cmdInsert.Parameters.AddWithValue("@option4", optD_tb.Text)
                cmdInsert.ExecuteNonQuery()
            End Using
            'MessageBox.Show("reached after both insertions")
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
        Dim Form3 As New QuestionPool()
        Form3.Show()
        Me.Hide()
    End Sub
End Class