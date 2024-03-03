<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StudentLandingPage
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
        Me.ExamBtn = New System.Windows.Forms.Button()
        Me.resultBtn = New System.Windows.Forms.Button()
        Me.topNameLabel = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.waitResults_tb = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.genCertificateBtn = New System.Windows.Forms.Button()
        Me.GradeLabel = New System.Windows.Forms.Label()
        Me.EmailLabel = New System.Windows.Forms.Label()
        Me.PercentileLabel = New System.Windows.Forms.Label()
        Me.RollNoLabel = New System.Windows.Forms.Label()
        Me.MarksLabel = New System.Windows.Forms.Label()
        Me.NameLabel = New System.Windows.Forms.Label()
        Me.GradeLb = New System.Windows.Forms.Label()
        Me.EmailLb = New System.Windows.Forms.Label()
        Me.PercentileLb = New System.Windows.Forms.Label()
        Me.MarksLb = New System.Windows.Forms.Label()
        Me.RollLb = New System.Windows.Forms.Label()
        Me.NameLb = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExamBtn
        '
        Me.ExamBtn.BackColor = System.Drawing.Color.Ivory
        Me.ExamBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExamBtn.Location = New System.Drawing.Point(130, 221)
        Me.ExamBtn.Margin = New System.Windows.Forms.Padding(27, 12, 27, 12)
        Me.ExamBtn.Name = "ExamBtn"
        Me.ExamBtn.Size = New System.Drawing.Size(190, 55)
        Me.ExamBtn.TabIndex = 1
        Me.ExamBtn.Text = "Start Exam"
        Me.ExamBtn.UseVisualStyleBackColor = False
        '
        'resultBtn
        '
        Me.resultBtn.BackColor = System.Drawing.Color.Ivory
        Me.resultBtn.Enabled = False
        Me.resultBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.resultBtn.Location = New System.Drawing.Point(130, 318)
        Me.resultBtn.Margin = New System.Windows.Forms.Padding(27, 12, 27, 12)
        Me.resultBtn.Name = "resultBtn"
        Me.resultBtn.Size = New System.Drawing.Size(190, 55)
        Me.resultBtn.TabIndex = 3
        Me.resultBtn.Text = "View result"
        Me.resultBtn.UseVisualStyleBackColor = False
        '
        'topNameLabel
        '
        Me.topNameLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.topNameLabel.AutoSize = True
        Me.topNameLabel.BackColor = System.Drawing.Color.Transparent
        Me.topNameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.topNameLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.topNameLabel.Location = New System.Drawing.Point(1049, 17)
        Me.topNameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.topNameLabel.Name = "topNameLabel"
        Me.topNameLabel.Size = New System.Drawing.Size(178, 29)
        Me.topNameLabel.TabIndex = 27
        Me.topNameLabel.Text = "Student Name"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label1.Location = New System.Drawing.Point(826, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 29)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Candidate Name:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.BackColor = System.Drawing.Color.Ivory
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.waitResults_tb)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.genCertificateBtn)
        Me.Panel1.Controls.Add(Me.GradeLabel)
        Me.Panel1.Controls.Add(Me.EmailLabel)
        Me.Panel1.Controls.Add(Me.PercentileLabel)
        Me.Panel1.Controls.Add(Me.RollNoLabel)
        Me.Panel1.Controls.Add(Me.MarksLabel)
        Me.Panel1.Controls.Add(Me.NameLabel)
        Me.Panel1.Controls.Add(Me.GradeLb)
        Me.Panel1.Controls.Add(Me.EmailLb)
        Me.Panel1.Controls.Add(Me.PercentileLb)
        Me.Panel1.Controls.Add(Me.MarksLb)
        Me.Panel1.Controls.Add(Me.RollLb)
        Me.Panel1.Controls.Add(Me.NameLb)
        Me.Panel1.Location = New System.Drawing.Point(590, 139)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Padding = New System.Windows.Forms.Padding(20)
        Me.Panel1.Size = New System.Drawing.Size(520, 511)
        Me.Panel1.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label3.Location = New System.Drawing.Point(23, 230)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(193, 36)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Exam Result"
        '
        'waitResults_tb
        '
        Me.waitResults_tb.BackColor = System.Drawing.Color.Black
        Me.waitResults_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.waitResults_tb.ForeColor = System.Drawing.Color.Red
        Me.waitResults_tb.Location = New System.Drawing.Point(83, 302)
        Me.waitResults_tb.Multiline = True
        Me.waitResults_tb.Name = "waitResults_tb"
        Me.waitResults_tb.Size = New System.Drawing.Size(326, 132)
        Me.waitResults_tb.TabIndex = 68
        Me.waitResults_tb.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please wait for Admin " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to release the Results" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.waitResults_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.Label2.Location = New System.Drawing.Point(23, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(226, 36)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Student Profile"
        '
        'genCertificateBtn
        '
        Me.genCertificateBtn.BackColor = System.Drawing.Color.Black
        Me.genCertificateBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.genCertificateBtn.ForeColor = System.Drawing.Color.Yellow
        Me.genCertificateBtn.Location = New System.Drawing.Point(149, 441)
        Me.genCertificateBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.genCertificateBtn.Name = "genCertificateBtn"
        Me.genCertificateBtn.Size = New System.Drawing.Size(217, 46)
        Me.genCertificateBtn.TabIndex = 67
        Me.genCertificateBtn.Text = "Generate Certificate"
        Me.genCertificateBtn.UseVisualStyleBackColor = False
        Me.genCertificateBtn.Visible = False
        '
        'GradeLabel
        '
        Me.GradeLabel.AutoSize = True
        Me.GradeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradeLabel.Location = New System.Drawing.Point(236, 374)
        Me.GradeLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.GradeLabel.Name = "GradeLabel"
        Me.GradeLabel.Size = New System.Drawing.Size(43, 29)
        Me.GradeLabel.TabIndex = 66
        Me.GradeLabel.Text = "AA"
        Me.GradeLabel.Visible = False
        '
        'EmailLabel
        '
        Me.EmailLabel.AutoSize = True
        Me.EmailLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailLabel.Location = New System.Drawing.Point(236, 179)
        Me.EmailLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EmailLabel.Name = "EmailLabel"
        Me.EmailLabel.Size = New System.Drawing.Size(248, 29)
        Me.EmailLabel.TabIndex = 65
        Me.EmailLabel.Text = "s.munagala@iitg.ac.in"
        '
        'PercentileLabel
        '
        Me.PercentileLabel.AutoSize = True
        Me.PercentileLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PercentileLabel.Location = New System.Drawing.Point(236, 324)
        Me.PercentileLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PercentileLabel.Name = "PercentileLabel"
        Me.PercentileLabel.Size = New System.Drawing.Size(52, 29)
        Me.PercentileLabel.TabIndex = 64
        Me.PercentileLabel.Text = "100"
        Me.PercentileLabel.Visible = False
        '
        'RollNoLabel
        '
        Me.RollNoLabel.AutoSize = True
        Me.RollNoLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RollNoLabel.Location = New System.Drawing.Point(236, 120)
        Me.RollNoLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.RollNoLabel.Name = "RollNoLabel"
        Me.RollNoLabel.Size = New System.Drawing.Size(130, 29)
        Me.RollNoLabel.TabIndex = 63
        Me.RollNoLabel.Text = "210101073"
        '
        'MarksLabel
        '
        Me.MarksLabel.AutoSize = True
        Me.MarksLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarksLabel.Location = New System.Drawing.Point(236, 279)
        Me.MarksLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MarksLabel.Name = "MarksLabel"
        Me.MarksLabel.Size = New System.Drawing.Size(72, 29)
        Me.MarksLabel.TabIndex = 62
        Me.MarksLabel.Text = "65/70"
        Me.MarksLabel.Visible = False
        '
        'NameLabel
        '
        Me.NameLabel.AutoSize = True
        Me.NameLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLabel.Location = New System.Drawing.Point(236, 71)
        Me.NameLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.NameLabel.Name = "NameLabel"
        Me.NameLabel.Size = New System.Drawing.Size(98, 29)
        Me.NameLabel.TabIndex = 61
        Me.NameLabel.Text = "Srinivas"
        '
        'GradeLb
        '
        Me.GradeLb.AutoSize = True
        Me.GradeLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GradeLb.Location = New System.Drawing.Point(80, 374)
        Me.GradeLb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.GradeLb.Name = "GradeLb"
        Me.GradeLb.Size = New System.Drawing.Size(86, 29)
        Me.GradeLb.TabIndex = 60
        Me.GradeLb.Text = "Grade:"
        Me.GradeLb.Visible = False
        '
        'EmailLb
        '
        Me.EmailLb.AutoSize = True
        Me.EmailLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EmailLb.Location = New System.Drawing.Point(80, 179)
        Me.EmailLb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.EmailLb.Name = "EmailLb"
        Me.EmailLb.Size = New System.Drawing.Size(106, 29)
        Me.EmailLb.TabIndex = 59
        Me.EmailLb.Text = "Email Id:"
        '
        'PercentileLb
        '
        Me.PercentileLb.AutoSize = True
        Me.PercentileLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PercentileLb.Location = New System.Drawing.Point(78, 324)
        Me.PercentileLb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.PercentileLb.Name = "PercentileLb"
        Me.PercentileLb.Size = New System.Drawing.Size(128, 29)
        Me.PercentileLb.TabIndex = 58
        Me.PercentileLb.Text = "Percentile:"
        Me.PercentileLb.Visible = False
        '
        'MarksLb
        '
        Me.MarksLb.AutoSize = True
        Me.MarksLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MarksLb.Location = New System.Drawing.Point(80, 279)
        Me.MarksLb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.MarksLb.Name = "MarksLb"
        Me.MarksLb.Size = New System.Drawing.Size(84, 29)
        Me.MarksLb.TabIndex = 57
        Me.MarksLb.Text = "Marks:"
        Me.MarksLb.Visible = False
        '
        'RollLb
        '
        Me.RollLb.AutoSize = True
        Me.RollLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RollLb.Location = New System.Drawing.Point(80, 120)
        Me.RollLb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.RollLb.Name = "RollLb"
        Me.RollLb.Size = New System.Drawing.Size(106, 29)
        Me.RollLb.TabIndex = 56
        Me.RollLb.Text = "Roll. No:"
        '
        'NameLb
        '
        Me.NameLb.AutoSize = True
        Me.NameLb.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameLb.Location = New System.Drawing.Point(80, 71)
        Me.NameLb.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.NameLb.Name = "NameLb"
        Me.NameLb.Size = New System.Drawing.Size(90, 29)
        Me.NameLb.TabIndex = 55
        Me.NameLb.Text = "Name: "
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Ivory
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(1087, 52)
        Me.Button1.Margin = New System.Windows.Forms.Padding(27, 12, 27, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 34)
        Me.Button1.TabIndex = 30
        Me.Button1.Text = "Log Out"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'StudentLandingPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Online_Examination_System.My.Resources.Resources.indian_institute_of_technology_guwahati_cover
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1214, 690)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ExamBtn)
        Me.Controls.Add(Me.resultBtn)
        Me.Controls.Add(Me.topNameLabel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "StudentLandingPage"
        Me.Padding = New System.Windows.Forms.Padding(20)
        Me.Text = "StudentLandingPage"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExamBtn As System.Windows.Forms.Button
    Friend WithEvents resultBtn As System.Windows.Forms.Button
    Friend WithEvents topNameLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents genCertificateBtn As System.Windows.Forms.Button
    Friend WithEvents GradeLabel As System.Windows.Forms.Label
    Friend WithEvents EmailLabel As System.Windows.Forms.Label
    Friend WithEvents PercentileLabel As System.Windows.Forms.Label
    Friend WithEvents RollNoLabel As System.Windows.Forms.Label
    Friend WithEvents MarksLabel As System.Windows.Forms.Label
    Friend WithEvents NameLabel As System.Windows.Forms.Label
    Friend WithEvents GradeLb As System.Windows.Forms.Label
    Friend WithEvents EmailLb As System.Windows.Forms.Label
    Friend WithEvents PercentileLb As System.Windows.Forms.Label
    Friend WithEvents MarksLb As System.Windows.Forms.Label
    Friend WithEvents RollLb As System.Windows.Forms.Label
    Friend WithEvents NameLb As System.Windows.Forms.Label
    Friend WithEvents waitResults_tb As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
