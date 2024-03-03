<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuestionPool
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label_ans = New System.Windows.Forms.Label()
        Me.Ques_tb = New System.Windows.Forms.RichTextBox()
        Me.LabelD = New System.Windows.Forms.Label()
        Me.LabelC = New System.Windows.Forms.Label()
        Me.LabelB = New System.Windows.Forms.Label()
        Me.addQsBtn = New System.Windows.Forms.Button()
        Me.LabelA = New System.Windows.Forms.Label()
        Me.optD_tb = New System.Windows.Forms.RichTextBox()
        Me.optC_tb = New System.Windows.Forms.RichTextBox()
        Me.optB_tb = New System.Windows.Forms.RichTextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.opt4 = New System.Windows.Forms.RadioButton()
        Me.opt3 = New System.Windows.Forms.RadioButton()
        Me.opt2 = New System.Windows.Forms.RadioButton()
        Me.opt1 = New System.Windows.Forms.RadioButton()
        Me.optA_tb = New System.Windows.Forms.RichTextBox()
        Me.Label_qs = New System.Windows.Forms.Label()
        Me.delQsBtn = New System.Windows.Forms.Button()
        Me.editQsBtn = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(238, 548)
        Me.Panel1.TabIndex = 9
        '
        'Label_ans
        '
        Me.Label_ans.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label_ans.AutoSize = True
        Me.Label_ans.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_ans.Location = New System.Drawing.Point(37, 475)
        Me.Label_ans.Name = "Label_ans"
        Me.Label_ans.Size = New System.Drawing.Size(208, 24)
        Me.Label_ans.TabIndex = 22
        Me.Label_ans.Text = "Choose Correct Option:"
        '
        'Ques_tb
        '
        Me.Ques_tb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Ques_tb.BackColor = System.Drawing.Color.Snow
        Me.Ques_tb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Ques_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Ques_tb.Location = New System.Drawing.Point(41, 50)
        Me.Ques_tb.Name = "Ques_tb"
        Me.Ques_tb.ReadOnly = True
        Me.Ques_tb.Size = New System.Drawing.Size(763, 84)
        Me.Ques_tb.TabIndex = 10
        Me.Ques_tb.Text = ""
        '
        'LabelD
        '
        Me.LabelD.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelD.AutoSize = True
        Me.LabelD.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelD.Location = New System.Drawing.Point(43, 366)
        Me.LabelD.Name = "LabelD"
        Me.LabelD.Size = New System.Drawing.Size(89, 24)
        Me.LabelD.TabIndex = 9
        Me.LabelD.Text = "Option D:"
        '
        'LabelC
        '
        Me.LabelC.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelC.AutoSize = True
        Me.LabelC.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelC.Location = New System.Drawing.Point(44, 300)
        Me.LabelC.Name = "LabelC"
        Me.LabelC.Size = New System.Drawing.Size(89, 24)
        Me.LabelC.TabIndex = 8
        Me.LabelC.Text = "Option C:"
        '
        'LabelB
        '
        Me.LabelB.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelB.AutoSize = True
        Me.LabelB.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelB.Location = New System.Drawing.Point(44, 236)
        Me.LabelB.Name = "LabelB"
        Me.LabelB.Size = New System.Drawing.Size(88, 24)
        Me.LabelB.TabIndex = 7
        Me.LabelB.Text = "Option B:"
        '
        'addQsBtn
        '
        Me.addQsBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.addQsBtn.BackColor = System.Drawing.Color.LawnGreen
        Me.addQsBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addQsBtn.Location = New System.Drawing.Point(568, 571)
        Me.addQsBtn.Name = "addQsBtn"
        Me.addQsBtn.Size = New System.Drawing.Size(174, 33)
        Me.addQsBtn.TabIndex = 8
        Me.addQsBtn.Text = "Add Question"
        Me.addQsBtn.UseVisualStyleBackColor = False
        Me.addQsBtn.UseWaitCursor = True
        '
        'LabelA
        '
        Me.LabelA.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LabelA.AutoSize = True
        Me.LabelA.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelA.Location = New System.Drawing.Point(43, 171)
        Me.LabelA.Name = "LabelA"
        Me.LabelA.Size = New System.Drawing.Size(89, 24)
        Me.LabelA.TabIndex = 6
        Me.LabelA.Text = "Option A:"
        '
        'optD_tb
        '
        Me.optD_tb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.optD_tb.BackColor = System.Drawing.Color.Snow
        Me.optD_tb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.optD_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optD_tb.Location = New System.Drawing.Point(170, 363)
        Me.optD_tb.Name = "optD_tb"
        Me.optD_tb.ReadOnly = True
        Me.optD_tb.Size = New System.Drawing.Size(245, 42)
        Me.optD_tb.TabIndex = 5
        Me.optD_tb.Text = ""
        '
        'optC_tb
        '
        Me.optC_tb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.optC_tb.BackColor = System.Drawing.Color.Snow
        Me.optC_tb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.optC_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optC_tb.Location = New System.Drawing.Point(170, 297)
        Me.optC_tb.Name = "optC_tb"
        Me.optC_tb.ReadOnly = True
        Me.optC_tb.Size = New System.Drawing.Size(245, 42)
        Me.optC_tb.TabIndex = 4
        Me.optC_tb.Text = ""
        '
        'optB_tb
        '
        Me.optB_tb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.optB_tb.BackColor = System.Drawing.Color.Snow
        Me.optB_tb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.optB_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optB_tb.Location = New System.Drawing.Point(170, 233)
        Me.optB_tb.Name = "optB_tb"
        Me.optB_tb.ReadOnly = True
        Me.optB_tb.Size = New System.Drawing.Size(245, 42)
        Me.optB_tb.TabIndex = 3
        Me.optB_tb.Text = ""
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel2.Controls.Add(Me.opt4)
        Me.Panel2.Controls.Add(Me.opt3)
        Me.Panel2.Controls.Add(Me.opt2)
        Me.Panel2.Controls.Add(Me.opt1)
        Me.Panel2.Controls.Add(Me.LabelA)
        Me.Panel2.Controls.Add(Me.LabelB)
        Me.Panel2.Controls.Add(Me.Label_ans)
        Me.Panel2.Controls.Add(Me.LabelC)
        Me.Panel2.Controls.Add(Me.Ques_tb)
        Me.Panel2.Controls.Add(Me.LabelD)
        Me.Panel2.Controls.Add(Me.optD_tb)
        Me.Panel2.Controls.Add(Me.optC_tb)
        Me.Panel2.Controls.Add(Me.optB_tb)
        Me.Panel2.Controls.Add(Me.optA_tb)
        Me.Panel2.Controls.Add(Me.Label_qs)
        Me.Panel2.Location = New System.Drawing.Point(256, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(846, 548)
        Me.Panel2.TabIndex = 10
        '
        'opt4
        '
        Me.opt4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.opt4.AutoSize = True
        Me.opt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt4.Location = New System.Drawing.Point(524, 475)
        Me.opt4.Name = "opt4"
        Me.opt4.Size = New System.Drawing.Size(45, 28)
        Me.opt4.TabIndex = 30
        Me.opt4.TabStop = True
        Me.opt4.Text = "D"
        Me.opt4.UseVisualStyleBackColor = True
        '
        'opt3
        '
        Me.opt3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.opt3.AutoSize = True
        Me.opt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt3.Location = New System.Drawing.Point(436, 475)
        Me.opt3.Name = "opt3"
        Me.opt3.Size = New System.Drawing.Size(45, 28)
        Me.opt3.TabIndex = 29
        Me.opt3.TabStop = True
        Me.opt3.Text = "C"
        Me.opt3.UseVisualStyleBackColor = True
        '
        'opt2
        '
        Me.opt2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.opt2.AutoSize = True
        Me.opt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt2.Location = New System.Drawing.Point(350, 475)
        Me.opt2.Name = "opt2"
        Me.opt2.Size = New System.Drawing.Size(44, 28)
        Me.opt2.TabIndex = 28
        Me.opt2.TabStop = True
        Me.opt2.Text = "B"
        Me.opt2.UseVisualStyleBackColor = True
        '
        'opt1
        '
        Me.opt1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.opt1.AutoSize = True
        Me.opt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.opt1.Location = New System.Drawing.Point(264, 474)
        Me.opt1.Name = "opt1"
        Me.opt1.Size = New System.Drawing.Size(45, 28)
        Me.opt1.TabIndex = 27
        Me.opt1.TabStop = True
        Me.opt1.Text = "A"
        Me.opt1.UseVisualStyleBackColor = True
        '
        'optA_tb
        '
        Me.optA_tb.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.optA_tb.BackColor = System.Drawing.Color.Snow
        Me.optA_tb.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.optA_tb.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optA_tb.Location = New System.Drawing.Point(170, 168)
        Me.optA_tb.Name = "optA_tb"
        Me.optA_tb.ReadOnly = True
        Me.optA_tb.Size = New System.Drawing.Size(245, 41)
        Me.optA_tb.TabIndex = 2
        Me.optA_tb.Text = ""
        '
        'Label_qs
        '
        Me.Label_qs.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label_qs.AutoSize = True
        Me.Label_qs.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_qs.Location = New System.Drawing.Point(37, 14)
        Me.Label_qs.Name = "Label_qs"
        Me.Label_qs.Size = New System.Drawing.Size(91, 24)
        Me.Label_qs.TabIndex = 1
        Me.Label_qs.Text = "Question:"
        '
        'delQsBtn
        '
        Me.delQsBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.delQsBtn.BackColor = System.Drawing.Color.Red
        Me.delQsBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.delQsBtn.Location = New System.Drawing.Point(928, 571)
        Me.delQsBtn.Name = "delQsBtn"
        Me.delQsBtn.Size = New System.Drawing.Size(174, 33)
        Me.delQsBtn.TabIndex = 11
        Me.delQsBtn.Text = "Delete Question"
        Me.delQsBtn.UseVisualStyleBackColor = False
        '
        'editQsBtn
        '
        Me.editQsBtn.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.editQsBtn.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.editQsBtn.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editQsBtn.Location = New System.Drawing.Point(748, 571)
        Me.editQsBtn.Name = "editQsBtn"
        Me.editQsBtn.Size = New System.Drawing.Size(174, 33)
        Me.editQsBtn.TabIndex = 26
        Me.editQsBtn.Text = "Edit Question"
        Me.editQsBtn.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Salmon
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 567)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(98, 41)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "LogOut"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'QuestionPool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1126, 628)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.editQsBtn)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.addQsBtn)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.delQsBtn)
        Me.Name = "QuestionPool"
        Me.Text = "Question Pool"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label_ans As System.Windows.Forms.Label
    Friend WithEvents Ques_tb As System.Windows.Forms.RichTextBox
    Friend WithEvents LabelD As System.Windows.Forms.Label
    Friend WithEvents LabelC As System.Windows.Forms.Label
    Friend WithEvents LabelB As System.Windows.Forms.Label
    Friend WithEvents addQsBtn As System.Windows.Forms.Button
    Friend WithEvents LabelA As System.Windows.Forms.Label
    Friend WithEvents optD_tb As System.Windows.Forms.RichTextBox
    Friend WithEvents optC_tb As System.Windows.Forms.RichTextBox
    Friend WithEvents optB_tb As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents optA_tb As System.Windows.Forms.RichTextBox
    Friend WithEvents Label_qs As System.Windows.Forms.Label
    Friend WithEvents delQsBtn As System.Windows.Forms.Button
    Friend WithEvents editQsBtn As System.Windows.Forms.Button
    Friend WithEvents opt4 As System.Windows.Forms.RadioButton
    Friend WithEvents opt3 As System.Windows.Forms.RadioButton
    Friend WithEvents opt2 As System.Windows.Forms.RadioButton
    Friend WithEvents opt1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
