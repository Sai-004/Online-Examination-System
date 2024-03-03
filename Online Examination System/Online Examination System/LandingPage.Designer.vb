<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LandingPage
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SignInBtn = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Textbox4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Textbox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.signUp = New System.Windows.Forms.Button()
        Me.Textbox3 = New System.Windows.Forms.TextBox()
        Me.Textbox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.newuser = New System.Windows.Forms.Label()
        Me.Title = New System.Windows.Forms.Label()
        Me.adminSignin = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.userSignin = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SignInBtn
        '
        Me.SignInBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.SignInBtn.BackColor = System.Drawing.Color.Lime
        Me.SignInBtn.Location = New System.Drawing.Point(295, 397)
        Me.SignInBtn.Name = "SignInBtn"
        Me.SignInBtn.Size = New System.Drawing.Size(93, 45)
        Me.SignInBtn.TabIndex = 28
        Me.SignInBtn.Text = "Sign In"
        Me.SignInBtn.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel2.Controls.Add(Me.SignInBtn)
        Me.Panel2.Controls.Add(Me.Textbox4)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Textbox2)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.signUp)
        Me.Panel2.Controls.Add(Me.Textbox3)
        Me.Panel2.Controls.Add(Me.Textbox1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.newuser)
        Me.Panel2.Controls.Add(Me.Title)
        Me.Panel2.Location = New System.Drawing.Point(511, 67)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(686, 536)
        Me.Panel2.TabIndex = 3
        Me.Panel2.Visible = False
        '
        'Textbox4
        '
        Me.Textbox4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Textbox4.Location = New System.Drawing.Point(212, 329)
        Me.Textbox4.Name = "Textbox4"
        Me.Textbox4.Size = New System.Drawing.Size(261, 22)
        Me.Textbox4.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(208, 302)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(83, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Password"
        '
        'Textbox2
        '
        Me.Textbox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Textbox2.Location = New System.Drawing.Point(212, 189)
        Me.Textbox2.Name = "Textbox2"
        Me.Textbox2.Size = New System.Drawing.Size(261, 22)
        Me.Textbox2.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(208, 166)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Roll Number"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(208, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 20)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Email"
        Me.Label3.Visible = False
        '
        'signUp
        '
        Me.signUp.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.signUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signUp.ForeColor = System.Drawing.Color.MediumSeaGreen
        Me.signUp.Location = New System.Drawing.Point(537, 454)
        Me.signUp.Name = "signUp"
        Me.signUp.Size = New System.Drawing.Size(62, 26)
        Me.signUp.TabIndex = 22
        Me.signUp.Text = "Sign Up"
        Me.signUp.UseVisualStyleBackColor = True
        Me.signUp.Visible = False
        '
        'Textbox3
        '
        Me.Textbox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Textbox3.Location = New System.Drawing.Point(212, 257)
        Me.Textbox3.Name = "Textbox3"
        Me.Textbox3.Size = New System.Drawing.Size(261, 22)
        Me.Textbox3.TabIndex = 21
        Me.Textbox3.Visible = False
        '
        'Textbox1
        '
        Me.Textbox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Textbox1.Location = New System.Drawing.Point(212, 129)
        Me.Textbox1.Name = "Textbox1"
        Me.Textbox1.Size = New System.Drawing.Size(261, 22)
        Me.Textbox1.TabIndex = 20
        Me.Textbox1.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(208, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Name"
        Me.Label1.Visible = False
        '
        'newuser
        '
        Me.newuser.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.newuser.AutoSize = True
        Me.newuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.newuser.ForeColor = System.Drawing.Color.Magenta
        Me.newuser.Location = New System.Drawing.Point(364, 460)
        Me.newuser.Name = "newuser"
        Me.newuser.Size = New System.Drawing.Size(167, 17)
        Me.newuser.TabIndex = 18
        Me.newuser.Text = "New User? Register here"
        Me.newuser.Visible = False
        '
        'Title
        '
        Me.Title.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Title.AutoSize = True
        Me.Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Title.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Title.Location = New System.Drawing.Point(205, 59)
        Me.Title.Name = "Title"
        Me.Title.Size = New System.Drawing.Size(105, 31)
        Me.Title.TabIndex = 17
        Me.Title.Text = "Sign In"
        '
        'adminSignin
        '
        Me.adminSignin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.adminSignin.Location = New System.Drawing.Point(62, 102)
        Me.adminSignin.Name = "adminSignin"
        Me.adminSignin.Size = New System.Drawing.Size(140, 47)
        Me.adminSignin.TabIndex = 1
        Me.adminSignin.Text = "Sign-In as Admin"
        Me.adminSignin.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Panel1.Controls.Add(Me.adminSignin)
        Me.Panel1.Controls.Add(Me.userSignin)
        Me.Panel1.Location = New System.Drawing.Point(125, 201)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(273, 182)
        Me.Panel1.TabIndex = 2
        '
        'userSignin
        '
        Me.userSignin.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.userSignin.Location = New System.Drawing.Point(62, 27)
        Me.userSignin.Name = "userSignin"
        Me.userSignin.Size = New System.Drawing.Size(140, 47)
        Me.userSignin.TabIndex = 0
        Me.userSignin.Text = "Sign-In as User"
        Me.userSignin.UseVisualStyleBackColor = True
        '
        'LandingPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Online_Examination_System.My.Resources.Resources.indian_institute_of_technology_guwahati_cover
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1322, 671)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "LandingPage"
        Me.Text = "LandingPage"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SignInBtn As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Textbox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Textbox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents signUp As System.Windows.Forms.Button
    Friend WithEvents Textbox3 As System.Windows.Forms.TextBox
    Friend WithEvents Textbox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents newuser As System.Windows.Forms.Label
    Friend WithEvents Title As System.Windows.Forms.Label
    Friend WithEvents adminSignin As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents userSignin As System.Windows.Forms.Button
End Class
