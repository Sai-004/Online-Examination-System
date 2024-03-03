Imports System.Data.Odbc
Imports System.Media
'This form opens if admin is entering the admin section not first time
Public Class otherOpen
    Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234;"
    Dim conn As New OdbcConnection(connString)

    'Details of the test set by the admin
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        Me.BackgroundImage = Image.FromFile("C:\Users\navad\OneDrive\Desktop\Online-Examination-System\AdminPanel\dataBaseConnection\Resources\Admin1.jpg")

        ' Optionally, you can set the background image layout
        Me.BackgroundImageLayout = ImageLayout.Stretch ' Adjust as needed (Stretch, Tile, Center, etc.)
        Try
            conn.Open()
            Dim query = "select count(*) from section"
            Using Command As New OdbcCommand(query, conn)
                Dim sectionCount As Integer = Convert.ToInt32(Command.ExecuteScalar())

                ' Display the section count on the label
                no_sections.Text = sectionCount.ToString()
                Command.ExecuteNonQuery()
            End Using

            query = "select timeLimit from admin where admin_id = 1"
            Using Command As New OdbcCommand(query, conn)
                Dim sectionCount As Integer = Convert.ToInt32(Command.ExecuteScalar())

                ' Display the section count on the label
                timeLimit.Text = sectionCount.ToString()
                Command.ExecuteNonQuery()
            End Using

            Dim cmdSelect As New OdbcCommand("select count(*) from section", conn)
            'no of sections

            'To show in the data grid
            DataGridView1.DefaultCellStyle.Font = New Font("Arial", 10)
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Bold)
            Dim da As New OdbcDataAdapter
            'Dim new_column1 As New DataGridViewTextBoxColumn
            'Dim new_column2 As New DataGridViewTextBoxColumn
            'Dim new_column3 As New DataGridViewTextBoxColumn ' New column for percentile
            Dim cmd1 As New OdbcCommand("SELECT section_id as Section, no_of_qs as Questions, marks as Marks from section", conn)
            da.SelectCommand = cmd1
            Dim dt As New DataTable
            dt.Clear()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            DataGridView1.Sort(DataGridView1.Columns("Marks"), System.ComponentModel.ListSortDirection.Descending)
            DataGridView1.ReadOnly = True

        Catch ex As Exception
        Finally
            conn.Close()
        End Try
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Load the form for question pool management here
        Dim Form3 As New QuestionPool()
        Form3.Show()
        Me.Hide()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Load the form of student results here
        Dim Form5 As New Results()
        Form5.Show()
        Me.Hide()
    End Sub

    
    
    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Panel2.BackColor = Color.FromArgb(150, 255, 255, 255)
    End Sub
End Class