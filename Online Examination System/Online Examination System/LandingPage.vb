Imports System.Data.Odbc
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions

Public Class LandingPage
    Dim connString As String = "DSN=oee;Uid=user123;Pwd=1234"
    Dim connection As New OdbcConnection(connString)

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles userSignin.Click
        Panel2.Visible = True
        Title.Text = "Student Sign In"
        Label1.Visible = False
        Textbox1.Visible = False
        Label2.Visible = True
        Textbox2.Visible = True
        Label2.Text = "Roll Number"
        Label3.Visible = True
        Textbox3.Visible = True
        Label3.Text = "Password"
        Textbox4.Visible = False
        Label4.Visible = False
        SignInBtn.Text = "Sign In"
        newuser.Visible = True
        signUp.Visible = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles adminSignin.Click
        Panel2.Visible = True
        Title.Text = "Admin Login"
        Label1.Visible = False
        Textbox1.Visible = False
        Label2.Visible = True
        Textbox2.Visible = True
        Label2.Text = "Email id"
        Label3.Visible = True
        Textbox3.Visible = True
        Label3.Text = "Password"
        Textbox4.Visible = False
        Label4.Visible = False
        SignInBtn.Text = "Login"
        newuser.Visible = False
        signUp.Visible = False
    End Sub

    Private Sub SignUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles signUp.Click
        Panel2.Visible = True
        Title.Text = "Student Registration"
        Label1.Text = "Name"
        Label1.Visible = True
        Textbox1.Visible = True
        Label2.Text = "Roll Number"
        Label2.Visible = True
        Textbox2.Visible = True
        Label3.Text = "Email id"
        Label3.Visible = True
        Textbox3.Visible = True
        Label4.Text = "Password"
        Textbox4.Visible = True
        Label4.Visible = True
        SignInBtn.Text = "Sign Up"
        newuser.Visible = False
        signUp.Visible = False
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint
        Panel1.BackColor = Color.FromArgb(150, 255, 255, 255)
    End Sub

    Private Function ValidateUserDetails(ByVal rollNumber As String, ByVal password As String, ByVal userType As String) As Boolean
        Dim query As String = ""
        Dim userExists As Boolean = False

        If userType = "Student" Then
            query = "SELECT COUNT(*) FROM student WHERE roll_number = ? AND password = ?"
        ElseIf userType = "Admin" Then
            query = "SELECT COUNT(*) FROM admin WHERE email_id = ? AND password = ?"
        End If

        Try
            connection.Open()
            Using cmd As New OdbcCommand(query, connection)
                If userType = "Student" Then
                    cmd.Parameters.AddWithValue("@roll_number", rollNumber)
                ElseIf userType = "Admin" Then
                    cmd.Parameters.AddWithValue("@email_id", rollNumber)
                End If
                cmd.Parameters.AddWithValue("@password", password)

                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                If count > 0 Then
                    userExists = True
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try

        Return userExists
    End Function

    Private Sub SaveUserDetails(ByVal name As String, ByVal rollNumber As String, ByVal email As String, ByVal password As String)
        Dim query As String = ""
        query = "INSERT INTO student (name, roll_number, email, password) VALUES (?, ?, ?, ?)"
        Try
            connection.Open()
            Using cmd As New OdbcCommand(query, connection)
                cmd.Parameters.AddWithValue("@name", name)
                cmd.Parameters.AddWithValue("@roll_number", rollNumber)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@password", password)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            connection.Close()
        End Try
    End Sub

    'to validate the email
    Private Function ValidateEmail(ByVal email As String) As Boolean
        Dim pattern As String = "^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"
        Dim regex As New Regex(pattern)
        Dim isMatch As Boolean = regex.IsMatch(email)
        Return isMatch
    End Function

    Private Sub SignIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SignInBtn.Click
        Dim Name As String
        Dim RollNumber As String
        Dim email As String
        Dim Password As String
        Dim userExists As Boolean

        If SignInBtn.Text = "Login" Then 'admin login
            email = Textbox2.Text
            Password = Textbox3.Text
            Dim validEmail As Boolean = ValidateEmail(email)
            userExists = ValidateUserDetails(email, Password, "Admin")
            If userExists = True And validEmail = True Then
                MessageBox.Show("Admin Validated!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'to check if the admin entered for the first time or not
                'Try
                '    Dim entered As Boolean = False
                '    connection.Open()
                '    Dim query As String = "select entered from admin"
                '    Using cmd As New OdbcCommand(query, connection)
                '        Dim reader As OdbcDataReader = cmd.ExecuteReader()
                '        If reader.Read() Then
                '            entered = Convert.ToBoolean(reader("entered"))
                '        End If
                '    End Using
                '    If entered = True Then
                '        Dim otherOpen As New otherOpen()
                '        otherOpen.Show()
                '        Me.Hide()
                '    Else
                '        'update the entry
                '        query = "update admin set entered=?"
                '        Using cmd As New OdbcCommand(query, connection)
                '            cmd.Parameters.AddWithValue("?", 1)
                '            cmd.ExecuteNonQuery()
                '        End Using
                '        Dim firstOpen As New firstOpen()
                '        firstOpen.Show()
                '        Me.Hide()
                '    End If
                'Catch ex As Exception
                'Finally
                '    connection.Close()
                'End Try
            Else
                MessageBox.Show("Invalid Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf SignInBtn.Text = "Sign In" Then 'student login
            RollNumber = Textbox2.Text
            Password = Textbox3.Text
            ValidateUserDetails(RollNumber, Password, "Student")
            userExists = ValidateUserDetails(RollNumber, Password, "Student")
            If userExists = True Then
                ' MessageBox.Show("Student Validated!")
                Dim intRoll As Integer
                If Not Integer.TryParse(RollNumber.Trim(), intRoll) Then
                    MessageBox.Show("Invalid input for roll number.")
                    Exit Sub
                End If
                Try
                    Dim logged_in As Boolean
                    connection.Open()
                    Dim query As String = "select logged_in from student where roll_number=?"
                    Using cmd As New OdbcCommand(query, connection)
                        cmd.Parameters.AddWithValue("?", intRoll)
                        Dim reader As OdbcDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            logged_in = Convert.ToBoolean(reader("logged_in"))
                        End If
                    End Using
                    If logged_in Then
                        MessageBox.Show("You are already logged in,please exit from the other application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Application.Exit()
                    Else
                        query = "update student set logged_in = TRUE where roll_number = ? "
                        Using cmd As New OdbcCommand(query, connection)
                            cmd.Parameters.AddWithValue("?", intRoll)
                            cmd.ExecuteNonQuery()
                        End Using
                        logged_in = True
                    End If
                Catch ex As Exception

                Finally
                    connection.Close()
                End Try
                Dim stuLandPage As New StudentLandingPage(RollNumber)
                stuLandPage.Show()
                Me.WindowState = FormWindowState.Minimized
            Else
                MessageBox.Show("Invalid Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        ElseIf SignInBtn.Text = "Sign Up" Then 'student registration
            Name = Textbox1.Text
            RollNumber = Textbox2.Text
            email = Textbox3.Text
            Password = Textbox4.Text
            Dim validEmail As Boolean = ValidateEmail(email)
            If validEmail = False Then
                MessageBox.Show("Invalid Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Application.Exit()
            End If
            ' Save user details into the database
            SaveUserDetails(Name, RollNumber, email, Password)
            ' MessageBox.Show("Student added successfully")
            Dim stuLandPage As New StudentLandingPage(RollNumber)
            stuLandPage.Show()
            Me.WindowState = FormWindowState.Minimized
        End If


        ' Clear textboxes or perform other actions as needed
        Textbox1.Clear()
        Textbox2.Clear()
        Textbox3.Clear()
        Textbox4.Clear()
    End Sub

    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Panel1.BackColor = Color.FromArgb(200, 255, 255, 255)
    End Sub

    Private Sub LandingPage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
