<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSettings))
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.ChkRunAtStartup = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(22, 24)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(77, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Caps Lock"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(117, 24)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(75, 17)
        Me.CheckBox2.TabIndex = 1
        Me.CheckBox2.Text = "Num Lock"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(212, 24)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(79, 17)
        Me.CheckBox3.TabIndex = 2
        Me.CheckBox3.Text = "Scroll Lock"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(350, 281)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 25)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "OK "
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBox3)
        Me.GroupBox1.Controls.Add(Me.CheckBox2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(101, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(324, 58)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Icons to show on tray"
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(22, 24)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(97, 17)
        Me.CheckBox4.TabIndex = 5
        Me.CheckBox4.Text = "Normalize keys"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox2.Controls.Add(Me.CheckBox4)
        Me.GroupBox2.Location = New System.Drawing.Point(101, 142)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 58)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Advanced options"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(163, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "seconds after last key pressed"
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(116, 23)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {3600, 0, 0, 0})
        Me.NumericUpDown1.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(44, 20)
        Me.NumericUpDown1.TabIndex = 7
        Me.NumericUpDown1.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'ChkRunAtStartup
        '
        Me.ChkRunAtStartup.AutoSize = True
        Me.ChkRunAtStartup.Location = New System.Drawing.Point(22, 26)
        Me.ChkRunAtStartup.Name = "ChkRunAtStartup"
        Me.ChkRunAtStartup.Size = New System.Drawing.Size(114, 17)
        Me.ChkRunAtStartup.TabIndex = 7
        Me.ChkRunAtStartup.Text = "Start with windows"
        Me.ChkRunAtStartup.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ChkRunAtStartup)
        Me.GroupBox3.Location = New System.Drawing.Point(101, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(324, 58)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Autostart"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CheckBox5)
        Me.GroupBox4.Location = New System.Drawing.Point(104, 206)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(321, 58)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Additional functions"
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(19, 24)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(251, 17)
        Me.CheckBox5.TabIndex = 0
        Me.CheckBox5.Text = "Show screen notifications on each lock change"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.KeyzPal.My.Resources.Resources.KeyzPal_Key_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(11, 11)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(75, 75)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'FrmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(440, 309)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSettings"
        Me.Text = "KeyzPal - Settings"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents ChkRunAtStartup As CheckBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CheckBox5 As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
