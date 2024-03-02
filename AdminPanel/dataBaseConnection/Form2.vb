Imports System.Data.Odbc
'This form opens if admin is entering the admin section not first time
Public Class Form2
    Dim connString As String = "DSN=oee;Uid=root;Pwd=2004;"
    Dim conn As New OdbcConnection(connString)
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Load the form for question pool management here
        Dim Form3 As New Form3()
        Form3.Show()
        Me.Hide()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Load the form of student results here
        Dim Form5 As New Form5()
        Form5.Show()
        Me.Hide()
    End Sub
End Class