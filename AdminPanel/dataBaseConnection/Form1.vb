Imports System.Data.Odbc
Public Class Form1
    Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234;"
    Dim conn As New OdbcConnection(connString)
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim total_marks As Integer
        total_marks = 50
        conn.Open()
        Dim cmd As New OdbcCommand("Select roll_number, marks from results ", conn)
        Dim da As New OdbcDataAdapter
        Dim new_column1 As New DataGridViewTextBoxColumn
        Dim new_column2 As New DataGridViewTextBoxColumn
        da.SelectCommand = cmd
        Dim dt As New DataTable
        dt.Clear()
        da.Fill(dt)
        Result_grid.DataSource = dt
        With new_column1
            .Name = "percentage_column"
            .HeaderText = "percentage"
            .Width = 100
        End With
        With new_column2
            .Name = "grade_column"
            .HeaderText = "grade"
            .Width = 100
        End With
        Result_grid.Columns.Insert(2, new_column1)
        Result_grid.Columns.Insert(3, new_column2)
        Dim grade As Char
        Dim length As Integer
        length = Result_grid.Rows.Count
        For i As Integer = 0 To length - 2
            Dim mark = Result_grid.Rows(i).Cells(1).Value
            Dim marks_percentage = (mark / total_marks) * 100

            If marks_percentage >= 90 Then
                grade = "A"
            ElseIf marks_percentage >= 70 Then
                grade = "B"
            ElseIf marks_percentage >= 50 Then
                grade = "C"
            ElseIf marks_percentage >= 30 Then
                grade = "D"
            ElseIf marks_percentage > 0 Then
                grade = "E"
            Else
                grade = "F"
            End If
            Result_grid.Rows(i).Cells(2).Value = marks_percentage
            Result_grid.Rows(i).Cells(3).Value = grade

        Next

            conn.Close()
    End Sub
End Class
