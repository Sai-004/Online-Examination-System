### CS-346 Assignment-2 
# Online Examination System

## Overview

The Online Examination System is a Visual Basic Forms application developed using Visual Studio. Its primary purpose is to facilitate online examinations for students under the supervision of an administrator. The system comprises several pages and features to manage exams effectively.

## Features

### 1. User Authentication

- **Landing Page:** Users are directed to the landing page where they can log in as an administrator or a student.
- **Admin Landing Page:** Upon successful login, admins are redirected to their dashboard where they can manage exam-related tasks.
- **Student Landing Page:** Students are directed to their dashboard where they can access exams and view their results.

### 2. Admin Functions

- **Question Pool Management:** Admins can add, edit, or delete questions in the question pool.
- **Admin Results Page:** Provides admins with access to view student results.
- **Release Results Option:** Admins can release exam results to students.

### 3. Student Functions

- **Student Exam Panel:** Students can access the exam interface to take exams.
- **Student Results Page:** After completing an exam, students can view their results.

### 4. Database Connectivity

- The database is hosted on an Apache server in PHPMyAdmin.
- All data manipulation and retrieval are done through SQL queries from the Visual Basic Forms application.

### 5. Multi-Device Compatibility

- The application is designed to run on multiple devices, ensuring accessibility for both admins and students.

### 6. Error Handling and Restrictions

- **Concurrent User Handling:** If two users log in with the same credentials simultaneously, the latest user will receive an error message, ensuring data integrity.
- **Admin Limitations:** Admin functionalities such as test pattern finalization and question addition/modification have specific limitations to maintain test integrity.
- **Test Timer:** A timer is set for each student during exams, ensuring exams are completed within the allocated time.

## Usage

1. **Login:** Users log in as either an administrator or a student.
2. **Admin Functions:** Admins manage exams, question pools, and result release.
3. **Student Functions:** Students take exams and view results.
4. **Database Connection:** Ensure the application is connected to the MySQL database hosted on PHPMyAdmin.
5. **Error Handling:** Follow prompts and error messages to ensure smooth operation.

## Conclusion

The Online Examination System provides a comprehensive platform for administering online exams securely and efficiently. With features tailored for both administrators and students, the system ensures seamless exam management and a user-friendly experience. For any queries or issues, please contact the system administrator.

## To Connect to the database  
1. The database is hosted on Xampp server in a lab PC. So, you must connect to intranet to access the database.  
2. Enter `172.16.114.214` to access the Xampp server. Navigate to phpmyadmin after this.  
3. The currently using database is schema is `onlineexaminationsystem`. All tables created and manipulated are visible here.  

## Connecting Visual Basic Application to Hosted Database

To establish a connection between the Visual Basic application and the hosted database (for the admin), follow these steps:

### Prerequisites
1. **Install ODBC MySQL Driver:** Download and install the 32-bit ODBC MySQL driver from [here](https://dev.mysql.com/downloads/connector/odbc/) (choose version 8.0.36).
   
   If the installer doesn't run, install the Visual Studio 2019 redistributable from [here](https://aka.ms/vs/17/release/vc_redist.x86.exe).

2. **Run as Administrator:** Run the application as an administrator.

### Creating System DSN
1. **Navigate to System DSN:** Open the ODBC Data Source Administrator. Add a system DSN by choosing MySQL ANSI driver.
   
2. **Configure Connection:** Set DSN name, username as `user123`, and password as `1234`. Select the database `onlineexaminationsystem`.

### Code Samples

#### Inserting Data into Table
```vb
Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234;"
Dim conn As New OdbcConnection(connString)
Try
    conn.Open()
    Dim insertQuery As String = "INSERT INTO minimum_number_of_questions(section_id, no_qs) VALUES (?, ?)"
    For i As Integer = 1 To numberOfSections Step 1
      Using cmdInsert As New OdbcCommand(insertQuery, conn)
          cmdInsert.Parameters.AddWithValue("@section_id", i)
          cmdInsert.Parameters.AddWithValue("@no_qs", numberOfQuestions(i - 1))
          cmdInsert.ExecuteNonQuery()
          cmdInsert.Parameters.Clear()
      End Using
    Next
Catch ex As Exception
Finally
    conn.Close()
End Try
```

#### Reading Data from Table
```vb
Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234;"
Try
    conn.Open()
    Dim query As String = "SELECT question_id, section_id, question, answer, option1, option2, option3, option4 FROM question_pool WHERE section_id = ? AND question_id = ?"
    Dim cmd As New OdbcCommand(query, conn)
    cmd.Parameters.AddWithValue("@section_id", section_id)
    cmd.Parameters.AddWithValue("@question_id", question_id)
    Dim reader As OdbcDataReader = cmd.ExecuteReader()
    If reader.HasRows Then
        reader.Read()
        Dim questionText As String = reader("question").ToString()
        Dim optionA As String = reader("option1").ToString()
        ' Retrieve other values similarly
    Else
        MessageBox.Show("No data found for the given section ID and question ID.")
    End If
    reader.Close()
Catch ex As Exception
Finally
    conn.Close()
End Try
```

#### Updating Data
```vb
Try
    conn.Open()
    Dim updateQuery As String = "UPDATE admin SET sections = ? WHERE admin_id = 1"
    Using cmdUpdate As New OdbcCommand(updateQuery, conn)
        cmdUpdate.Parameters.AddWithValue("@sections", numberOfSections)
        cmdUpdate.ExecuteNonQuery()
    End Using
Catch ex As Exception

Finally
    conn.Close()
End Try
```

#### Deleting Data
```vb
Try
    conn.Open()
    Dim deleteQuery As String = "DELETE FROM section"
    Using cmdDelete As New OdbcCommand(deleteQuery, conn)
        cmdDelete.ExecuteNonQuery()
    End Using
Catch ex As Exception

Finally
    conn.Close()
End Try
```

## Software Properties
- **Built Using:** Visual Basic in Visual Studio 2010.
- **Database:** MySQL database hosted in Apache server using phpMyAdmin.
- **Compatibility:** Application runs on multiple devices.
- **Concurrency Handling:** Ensures error messages for simultaneous user logins and prevents multiple admin addition or modification.
- **Admin Control:** Provides exclusive admin access to test pattern and questions, ensuring proper configuration before student access.
- **User Experience:** Timer-based exam control prevents exam restarts and releases results only upon admin authorization.
- **Error Handling:** Displays appropriate error messages for database connectivity issues or invalid user actions.
