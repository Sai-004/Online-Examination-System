Imports System.Data.Odbc

Public Class Results
    Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234;"
    Dim conn As New OdbcConnection(connString)
    Dim marks As New List(Of Integer)
    Dim questions As New List(Of Integer)
    Dim totalMarks As Integer = 0
    Private Sub Results_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            Dim cmdSelect As New OdbcCommand("select no_qs from minimum_number_of_questions", conn)
            'Total Marks 
            Dim reader As OdbcDataReader = cmdSelect.ExecuteReader()
            While reader.Read()
                questions.Add(Convert.ToInt32(reader("no_qs")))
            End While
            reader.Close()
            'MessageBox.Show(questions.Count)
            Dim query As String = "select marks from section"
            Using cmd As New OdbcCommand(query, conn)
                reader = cmd.ExecuteReader()
                While reader.Read()
                    marks.Add(Convert.ToInt32(reader("marks")))
                End While
                reader.Close()
            End Using
            For i As Integer = 0 To marks.Count - 1 Step 1
                totalMarks = totalMarks + marks(i) * questions(i)
            Next
            'MessageBox.Show("Marks:" & totalMarks)
            '''''
            'Marks Calculation
            query = "delete from results"
            Using Command As New OdbcCommand(query, conn)
                Command.ExecuteNonQuery()
            End Using
            query = "INSERT INTO results (roll_number, marks) " &
                                     "SELECT sa.roll_number, SUM(CASE WHEN qp.answer = sa.selected_answer THEN s.marks ELSE 0 END) AS total_marks " &
                                     "FROM student_answers sa " &
                                     "JOIN question_pool qp ON sa.question_id = qp.question_id AND sa.section_id = qp.section_id " &
                                     "JOIN section s ON sa.section_id = s.section_id " &
                                     "GROUP BY sa.roll_number;"
            Using Command As New OdbcCommand(query, conn)
                Command.ExecuteNonQuery()
            End Using
            'MessageBox.Show("..")
            query = "UPDATE results SET percentage = ROUND((marks / ? ) * 100 ,2)"
            Using Command As New OdbcCommand(query, conn)
                Command.Parameters.AddWithValue("?", totalMarks)
                Command.ExecuteNonQuery()
            End Using
            'MessageBox.Show("....")
            query = "UPDATE results " &
        "SET grade = " &
            "CASE " &
                "WHEN percentage >= 90 THEN 'A' " &
                "WHEN percentage >= 70 THEN 'B' " &
                "WHEN percentage >= 50 THEN 'C' " &
                "WHEN percentage >= 30 THEN 'D' " &
                "WHEN percentage > 0 THEN 'E' " &
                "ELSE 'F' " &
            "END"

            Using Command As New OdbcCommand(query, conn)
                Command.ExecuteNonQuery()
            End Using
            'MessageBox.Show("/////")
            query = "UPDATE results " &
        "SET percentile = ROUND(" &
        "(SELECT COUNT(*) " &
        "FROM results r2 " &
        "WHERE r2.percentage <= results.percentage) / " &
        "(SELECT COUNT(*) FROM results) * 100,2)"

            Using Command As New OdbcCommand(query, conn)
                Command.ExecuteNonQuery()
            End Using
            'MessageBox.Show("......")
            'To show in the data grid
            Result_grid.DefaultCellStyle.Font = New Font("Arial", 10)
            Result_grid.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
            Dim da As New OdbcDataAdapter
            Dim new_column1 As New DataGridViewTextBoxColumn
            Dim new_column2 As New DataGridViewTextBoxColumn
            Dim new_column3 As New DataGridViewTextBoxColumn ' New column for percentile
            Dim cmd1 As New OdbcCommand("SELECT s.name as Name,r.roll_number as RollNumber, r.marks as Marks,r.percentage as Percentage,r.grade as Grade,r.percentile as Percentile,(SELECT COUNT(*) + 1 FROM results AS r2 WHERE r2.percentile > r.percentile) AS Rank FROM results r JOIN student s ON r.roll_number = s.roll_number", conn)
            da.SelectCommand = cmd1
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            Result_grid.DataSource = dt
            Result_grid.Sort(Result_grid.Columns("Marks"), System.ComponentModel.ListSortDirection.Descending)
            Result_grid.ReadOnly = True
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
    End Sub
    'Log out button functionality
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub
    'For results releasing 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            conn.Open()
            Dim query As String = "update results set released= TRUE"
            Using cmd As New OdbcCommand(query, conn)
                cmd.ExecuteNonQuery()
            End Using
            MessageBox.Show("The results of all the students above are released", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception

        Finally
            conn.Close()
        End Try
    End Sub

    ''for sorting the columns based on clicks
    'Private Sub dgv_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles Result_grid.ColumnHeaderMouseClick
    '    ' Determine the column to sort by
    '    Dim columnToSort As DataGridViewColumn = Result_grid.Columns(e.ColumnIndex)

    '    ' Check if the clicked column is already the column that is being sorted
    '    If Result_grid.SortedColumn IsNot Nothing AndAlso Result_grid.SortedColumn.Equals(columnToSort) Then
    '        ' Reverse the current sort direction
    '        If Result_grid.SortOrder = SortOrder.Ascending Then
    '            Try
    '                Result_grid.Sort(columnToSort, SortOrder.Descending)
    '            Catch ex As ArgumentException
    '            End Try
    '        Else
    '            Try
    '                Result_grid.Sort(columnToSort, SortOrder.Ascending)
    '            Catch ex As ArgumentException
    '            End Try
    '        End If
    '    Else
    '        ' Set the sort mode and sort the DataGridView
    '        Try
    '            Result_grid.Sort(columnToSort, SortOrder.Ascending)
    '        Catch ex As ArgumentException
    '        End Try
    '    End If

    '    ' Calculate Percentage and Grade after sorting
    '    CalculatePercentageAndGrade()
    'End Sub

    'Private Sub calculatepercentageandgrade()
    '    '    ' calculate percentage and grade for each row
    '    For i As Integer = 0 To result_grid.rows.count - 2
    '        Dim mark = result_grid.rows(i).cells("marks").value
    '        Dim marks_percentage = math.round((mark / totalmarks) * 100, 2)

    '        ' Update Percentage and Grade columns
    '        Result_grid.Rows(i).Cells("percentage_column").Value = marks_percentage

    '        ' Calculate Grade
    '        Dim grade As Char
    '        If marks_percentage >= 90 Then
    '            grade = "A"
    '        ElseIf marks_percentage >= 70 Then
    '            grade = "B"
    '        ElseIf marks_percentage >= 50 Then
    '            grade = "C"
    '        ElseIf marks_percentage >= 30 Then
    '            grade = "D"
    '        ElseIf marks_percentage > 0 Then
    '            grade = "E"
    '        Else
    '            grade = "F"
    '        End If
    '        Result_grid.Rows(i).Cells("grade_column").Value = grade
    '        'Result()
    '    Next
    'End Sub
End Class