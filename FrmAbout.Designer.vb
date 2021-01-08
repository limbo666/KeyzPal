<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAbout))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.LblThanks = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "KeyzPal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(83, 88)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "0.0.0.0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(175, 26)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "An advanced tray utility to indicate  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "lock key status and normalize them."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(26, 346)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(160, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "©2018-2021 Hand Water Pump"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(81, 37)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Nikos Georgousis"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(130, 380)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 25)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.BurlyWood
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(-17, 190)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(246, 63)
        Me.Panel1.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(100, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Creator:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(43, 170)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(127, 13)
        Me.LinkLabel1.TabIndex = 8
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Donate to help developer"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 365)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "..."
        Me.Label6.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(44, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(125, 20)
        Me.TextBox1.TabIndex = 11
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(9, 386)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(89, 13)
        Me.LinkLabel2.TabIndex = 12
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Check for update"
        '
        'LblThanks
        '
        Me.LblThanks.AutoSize = True
        Me.LblThanks.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblThanks.ForeColor = System.Drawing.Color.Red
        Me.LblThanks.Location = New System.Drawing.Point(58, 68)
        Me.LblThanks.Name = "LblThanks"
        Me.LblThanks.Size = New System.Drawing.Size(96, 20)
        Me.LblThanks.TabIndex = 13
        Me.LblThanks.Text = "Thank you!"
        Me.LblThanks.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(69, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Enter your key"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.KeyzPal.My.Resources.Resources.KeyzPal_Key_Logo
        Me.PictureBox1.Location = New System.Drawing.Point(1, -4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(210, 89)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.KeyzPal.My.Resources.Resources.New_Patch_Ver1_250x250
        Me.PictureBox3.Location = New System.Drawing.Point(52, 251)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(110, 97)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 7
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.KeyzPal.My.Resources.Resources.paypalLogo2
        Me.PictureBox2.Location = New System.Drawing.Point(60, 132)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(92, 37)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 9
        Me.PictureBox2.TabStop = False
        '
        'FrmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(212, 409)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.LblThanks)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KeyzPal - About"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LblThanks As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
