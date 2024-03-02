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

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Add items to the ComboBox
        selectedOption = ComboBox1.SelectedItem.ToString()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        correctOption = TextBox3.Text
        selected = True
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        correctOption = TextBox4.Text
        selected = True
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        correctOption = TextBox6.Text
        selected = True
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        correctOption = TextBox5.Text
        selected = True
    End Sub
    Private Sub checkForEmptiness()
        Dim cond As Boolean = True
        If String.IsNullOrEmpty(TextBox2.Text) Or String.IsNullOrEmpty(TextBox3.Text) Or String.IsNullOrEmpty(TextBox4.Text) Or String.IsNullOrEmpty(TextBox5.Text) Or String.IsNullOrEmpty(TextBox6.Text) Or String.IsNullOrWhiteSpace(TextBox2.Text) Or String.IsNullOrWhiteSpace(TextBox3.Text) Or String.IsNullOrWhiteSpace(TextBox4.Text) Or String.IsNullOrWhiteSpace(TextBox5.Text) Or String.IsNullOrWhiteSpace(TextBox6.Text) Then
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
                cmdInsert.Parameters.AddWithValue("@question", TextBox2.Text)
                cmdInsert.Parameters.AddWithValue("@answer", correctOption)
                cmdInsert.Parameters.AddWithValue("@option1", TextBox4.Text)
                cmdInsert.Parameters.AddWithValue("@option2", TextBox3.Text)
                cmdInsert.Parameters.AddWithValue("@option3", TextBox6.Text)
                cmdInsert.Parameters.AddWithValue("@option4", TextBox5.Text)
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

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class