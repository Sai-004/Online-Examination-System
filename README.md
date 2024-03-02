# Online-Examination-System
CS-346 Assignment-2 Online Examination System
## All Required pages
1.Login page for admin and student(2 or 3 pages).  
2.Student exam interface with timer.  
3.Student result pages(one waiting and other showing results and option to generate certificate).  
4.Admin when entered for the first time,asking him the exam pattern.  
5.Admin when entered not the first time,asking him whether he wants to do question pool management or view student results or release the test results of students whose results weren't released.  
6.Students results page for Admin.  
7.Question Pool management (2 or 3 pages for add,delete ,edit).  
## To Connect to the database  
1.The database is hosted on xampp server in lab PC.So, you must connect to intranet to access the database.  
2.Enter 172.16.114.214 to access the xampp server.Navigate to phpmyadmin after this.  
3.The currently using database is schema is 'onlineexaminationsystem'.All tables created and manipulated are visible here.  

## To connect visual basic application to the above hosted database(as admin)  
//add connection string for student here later  
0.Install odbc mysql driver 32bit from [here](https://dev.mysql.com/downloads/connector/odbc/) (select version 8.0.36)  
    If the above exe file doesn't run, you might have to install visualstudio 2019 redistributable from [here](https://aka.ms/vs/17/release/vc_redist.x86.exe)  
    Run this appliaction as administrator.Navigate to systemDSN, add a connection(choose mysql driver ANSI) .Give DSN name as oee,Username as user123,password as 1234.Choose the database "onlineexaminationsystem".  
    This will create the necessary connection,which can be used through our visual basic application.  
1.The below is the code to insert into some table  
```vb
Dim connString as String = "DSN=oee;Uid=user123;Pwd=1234;"
Dim conn As New OdbcConnection(connString)
Try
    conn.open()
    Dim insertQuery As String = "insert into minimum_number_of_questions(section_id,no_qs) values (?,?) "
    For i As Integer = 1 To numberOfSections Step 1
      Using cmdInsert As New OdbcCommand(insertQuery, conn)
          cmdInsert.Parameters.AddWithValue("@section_id", i)
          cmdInsert.Parameters.AddWithValue("@no_qs", numberOfQuestions(i - 1))
          cmdInsert.ExecuteNonQuery()
          cmdInsert.Parameters.Clear()
      End Using
    Next
catch ex as Exception
Finally
    conn.close()
End Try
```

2.The below is code to read from the table and store in variables created in visual basic
```vb
Dim connString as String = "DSN=oee;Uid=user123;Pwd=1234;"
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
            Else
                MessageBox.Show("No data found for the given section ID and question ID.")
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error connecting to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            conn.Close()
        End Try
```
3.Sample update query
```vb
Try
    conn.Open()
    Dim updateQuery As String = "UPDATE admin SET sections = ? WHERE admin_id = 1"
    Using cmdUpdate As New OdbcCommand(updateQuery, conn)
        ' Set parameter for the new value of sections
        cmdUpdate.Parameters.AddWithValue("@sections", numberOfSections)
        ' Execute the UPDATE query
        cmdUpdate.ExecuteNonQuery()
    End Using
Catch ex as Exception

Finally
    conn.Close()
End Try
```
4.Sample delete query
```vb
Try
    conn.Open()
    Dim deleteQuery As String = "delete from section"
    Using cmdDelete As New OdbcCommand(deleteQuery, conn)
        cmdDelete.ExecuteNonQuery()
    End Using
Catch ex as Exception

Finally
    conn.Close()
End Try
```
## Properties of the above software
Built using visual basic in visual studio 2010.
