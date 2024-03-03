<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Certificate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Certificate))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ranklabel = New System.Windows.Forms.Label()
        Me.gradelebel = New System.Windows.Forms.Label()
        Me.markslabel = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.namelabel = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(484, 405)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(156, 134)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 20
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.WaitOnLoad = True
        '
        'ranklabel
        '
        Me.ranklabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ranklabel.AutoSize = True
        Me.ranklabel.BackColor = System.Drawing.Color.Transparent
        Me.ranklabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ranklabel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ranklabel.Location = New System.Drawing.Point(602, 355)
        Me.ranklabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.ranklabel.Name = "ranklabel"
        Me.ranklabel.Size = New System.Drawing.Size(182, 46)
        Me.ranklabel.TabIndex = 19
        Me.ranklabel.Text = "RANK: 1"
        '
        'gradelebel
        '
        Me.gradelebel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.gradelebel.AutoSize = True
        Me.gradelebel.BackColor = System.Drawing.Color.Transparent
        Me.gradelebel.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gradelebel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.gradelebel.Location = New System.Drawing.Point(270, 355)
        Me.gradelebel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.gradelebel.Name = "gradelebel"
        Me.gradelebel.Size = New System.Drawing.Size(248, 46)
        Me.gradelebel.TabIndex = 18
        Me.gradelebel.Text = "GRADE: AA"
        '
        'markslabel
        '
        Me.markslabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.markslabel.AutoSize = True
        Me.markslabel.BackColor = System.Drawing.Color.Transparent
        Me.markslabel.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.markslabel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.markslabel.Location = New System.Drawing.Point(274, 291)
        Me.markslabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.markslabel.Name = "markslabel"
        Me.markslabel.Size = New System.Drawing.Size(491, 32)
        Me.markslabel.TabIndex = 17
        Me.markslabel.Text = "for scoring 65 out of 70 marks in Quiz 1"
        Me.markslabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label2.Location = New System.Drawing.Point(370, 114)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(270, 32)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "This is presented to :"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(234, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(584, 59)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Certificate of Completion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label4.Location = New System.Drawing.Point(157, 245)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(680, 46)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "                                                       "
        '
        'namelabel
        '
        Me.namelabel.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.namelabel.AutoSize = True
        Me.namelabel.BackColor = System.Drawing.Color.Transparent
        Me.namelabel.Font = New System.Drawing.Font("Gabriola", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.namelabel.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.namelabel.Location = New System.Drawing.Point(362, 172)
        Me.namelabel.Margin = New System.Windows.Forms.Padding(0)
        Me.namelabel.Name = "namelabel"
        Me.namelabel.Size = New System.Drawing.Size(278, 110)
        Me.namelabel.TabIndex = 16
        Me.namelabel.Text = "Nitya Parikh"
        Me.namelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Certificate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1028, 570)
        Me.Controls.Add(Me.namelabel)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ranklabel)
        Me.Controls.Add(Me.gradelebel)
        Me.Controls.Add(Me.markslabel)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Certificate"
        Me.Text = "certificate"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ranklabel As System.Windows.Forms.Label
    Friend WithEvents gradelebel As System.Windows.Forms.Label
    Friend WithEvents markslabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents namelabel As System.Windows.Forms.Label
End Class
