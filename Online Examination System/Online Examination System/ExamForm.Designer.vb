<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.SubmitBtn = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SaveBtn = New System.Windows.Forms.Button()
        Me.ReviewBtn = New System.Windows.Forms.Button()
        Me.PrevBtn = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(29, 28)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(781, 22)
        Me.TextBox1.TabIndex = 4
        '
        'SubmitBtn
        '
        Me.SubmitBtn.Location = New System.Drawing.Point(684, 439)
        Me.SubmitBtn.Name = "SubmitBtn"
        Me.SubmitBtn.Size = New System.Drawing.Size(127, 33)
        Me.SubmitBtn.TabIndex = 3
        Me.SubmitBtn.Text = "Submit"
        Me.SubmitBtn.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, -3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1144, 26)
        Me.Panel1.TabIndex = 3
        '
        'SaveBtn
        '
        Me.SaveBtn.Location = New System.Drawing.Point(354, 439)
        Me.SaveBtn.Name = "SaveBtn"
        Me.SaveBtn.Size = New System.Drawing.Size(127, 33)
        Me.SaveBtn.TabIndex = 2
        Me.SaveBtn.Text = "Save and Next"
        Me.SaveBtn.UseVisualStyleBackColor = True
        '
        'ReviewBtn
        '
        Me.ReviewBtn.Location = New System.Drawing.Point(192, 439)
        Me.ReviewBtn.Name = "ReviewBtn"
        Me.ReviewBtn.Size = New System.Drawing.Size(127, 33)
        Me.ReviewBtn.TabIndex = 1
        Me.ReviewBtn.Text = "Mark for review"
        Me.ReviewBtn.UseVisualStyleBackColor = True
        '
        'PrevBtn
        '
        Me.PrevBtn.Location = New System.Drawing.Point(33, 439)
        Me.PrevBtn.Name = "PrevBtn"
        Me.PrevBtn.Size = New System.Drawing.Size(127, 33)
        Me.PrevBtn.TabIndex = 0
        Me.PrevBtn.Text = "Previous"
        Me.PrevBtn.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 61)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SubmitBtn)
        Me.SplitContainer1.Panel2.Controls.Add(Me.SaveBtn)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ReviewBtn)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PrevBtn)
        Me.SplitContainer1.Size = New System.Drawing.Size(1144, 499)
        Me.SplitContainer1.SplitterDistance = 305
        Me.SplitContainer1.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(0, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1144, 26)
        Me.Panel2.TabIndex = 4
        '
        'ExamPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 557)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.Panel2)
        Me.Name = "ExamPanel"
        Me.Text = "Exam Panel"
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents SubmitBtn As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SaveBtn As System.Windows.Forms.Button
    Friend WithEvents ReviewBtn As System.Windows.Forms.Button
    Friend WithEvents PrevBtn As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

End Class
