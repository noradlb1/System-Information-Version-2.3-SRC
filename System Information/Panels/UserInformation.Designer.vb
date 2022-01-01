<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserInformation
    Inherits SystemInformation.TaskPanelBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelAutoLogonStatus = New System.Windows.Forms.Label
        Me.ButtonSetAutoLogon = New System.Windows.Forms.Button
        Me.ButtonClearAutoLogon = New System.Windows.Forms.Button
        Me.LabelPassword = New System.Windows.Forms.Label
        Me.TextBoxPassword = New System.Windows.Forms.TextBox
        Me.LabelUserName = New System.Windows.Forms.Label
        Me.TextBoxUserName = New System.Windows.Forms.TextBox
        Me.LabelAutoLogon = New System.Windows.Forms.Label
        Me.LabelSeparator3 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ButtonSaveRegisteredOrganization = New System.Windows.Forms.Button
        Me.ButtonSaveRegisteredUser = New System.Windows.Forms.Button
        Me.TextBoxRegisteredOrganization = New System.Windows.Forms.TextBox
        Me.TextBoxRegisteredUser = New System.Windows.Forms.TextBox
        Me.LabelRegisteredOrganization = New System.Windows.Forms.Label
        Me.LabelRegisteredUser = New System.Windows.Forms.Label
        Me.LabelRegistration = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ButtonSaveRegisteredOrganization2 = New System.Windows.Forms.Button
        Me.ButtonSaveRegisteredUser2 = New System.Windows.Forms.Button
        Me.TextBoxRegisteredOrganization2 = New System.Windows.Forms.TextBox
        Me.TextBoxRegisteredUser2 = New System.Windows.Forms.TextBox
        Me.LabelRegisteredOrganization2 = New System.Windows.Forms.Label
        Me.LabelRegisteredUser2 = New System.Windows.Forms.Label
        Me.LabelRegistration2 = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelTitle.Location = New System.Drawing.Point(87, 32)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(165, 25)
        Me.LabelTitle.TabIndex = 1
        Me.LabelTitle.Text = "User Information"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Users_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(16, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LabelAutoLogonStatus)
        Me.Panel1.Controls.Add(Me.ButtonSetAutoLogon)
        Me.Panel1.Controls.Add(Me.ButtonClearAutoLogon)
        Me.Panel1.Controls.Add(Me.LabelPassword)
        Me.Panel1.Controls.Add(Me.TextBoxPassword)
        Me.Panel1.Controls.Add(Me.LabelUserName)
        Me.Panel1.Controls.Add(Me.TextBoxUserName)
        Me.Panel1.Controls.Add(Me.LabelAutoLogon)
        Me.Panel1.Controls.Add(Me.LabelSeparator3)
        Me.Panel1.Location = New System.Drawing.Point(3, 341)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(647, 114)
        Me.Panel1.TabIndex = 2
        '
        'LabelAutoLogonStatus
        '
        Me.LabelAutoLogonStatus.AutoSize = True
        Me.LabelAutoLogonStatus.BackColor = System.Drawing.Color.Transparent
        Me.LabelAutoLogonStatus.Location = New System.Drawing.Point(476, 5)
        Me.LabelAutoLogonStatus.Name = "LabelAutoLogonStatus"
        Me.LabelAutoLogonStatus.Size = New System.Drawing.Size(144, 17)
        Me.LabelAutoLogonStatus.TabIndex = 9
        Me.LabelAutoLogonStatus.Text = "Auto Logon Is Disabled"
        '
        'ButtonSetAutoLogon
        '
        Me.ButtonSetAutoLogon.AutoSize = True
        Me.ButtonSetAutoLogon.Enabled = False
        Me.ButtonSetAutoLogon.Location = New System.Drawing.Point(494, 44)
        Me.ButtonSetAutoLogon.Name = "ButtonSetAutoLogon"
        Me.ButtonSetAutoLogon.Size = New System.Drawing.Size(126, 27)
        Me.ButtonSetAutoLogon.TabIndex = 1
        Me.ButtonSetAutoLogon.Text = "Set Auto Logon"
        Me.ButtonSetAutoLogon.UseVisualStyleBackColor = True
        '
        'ButtonClearAutoLogon
        '
        Me.ButtonClearAutoLogon.AutoSize = True
        Me.ButtonClearAutoLogon.Enabled = False
        Me.ButtonClearAutoLogon.Location = New System.Drawing.Point(494, 74)
        Me.ButtonClearAutoLogon.Name = "ButtonClearAutoLogon"
        Me.ButtonClearAutoLogon.Size = New System.Drawing.Size(126, 27)
        Me.ButtonClearAutoLogon.TabIndex = 3
        Me.ButtonClearAutoLogon.Text = "Clear Auto Logon"
        Me.ButtonClearAutoLogon.UseVisualStyleBackColor = True
        '
        'LabelPassword
        '
        Me.LabelPassword.AutoSize = True
        Me.LabelPassword.BackColor = System.Drawing.Color.Transparent
        Me.LabelPassword.Location = New System.Drawing.Point(3, 79)
        Me.LabelPassword.Name = "LabelPassword"
        Me.LabelPassword.Size = New System.Drawing.Size(67, 17)
        Me.LabelPassword.TabIndex = 7
        Me.LabelPassword.Text = "Password:"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(141, 75)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(341, 25)
        Me.TextBoxPassword.TabIndex = 2
        '
        'LabelUserName
        '
        Me.LabelUserName.AutoSize = True
        Me.LabelUserName.BackColor = System.Drawing.Color.Transparent
        Me.LabelUserName.Location = New System.Drawing.Point(2, 49)
        Me.LabelUserName.Name = "LabelUserName"
        Me.LabelUserName.Size = New System.Drawing.Size(77, 17)
        Me.LabelUserName.TabIndex = 6
        Me.LabelUserName.Text = "User Name:"
        '
        'TextBoxUserName
        '
        Me.TextBoxUserName.Location = New System.Drawing.Point(141, 45)
        Me.TextBoxUserName.Name = "TextBoxUserName"
        Me.TextBoxUserName.Size = New System.Drawing.Size(341, 25)
        Me.TextBoxUserName.TabIndex = 0
        '
        'LabelAutoLogon
        '
        Me.LabelAutoLogon.AutoSize = True
        Me.LabelAutoLogon.BackColor = System.Drawing.Color.Transparent
        Me.LabelAutoLogon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAutoLogon.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelAutoLogon.Location = New System.Drawing.Point(2, 7)
        Me.LabelAutoLogon.Name = "LabelAutoLogon"
        Me.LabelAutoLogon.Size = New System.Drawing.Size(415, 17)
        Me.LabelAutoLogon.TabIndex = 4
        Me.LabelAutoLogon.Text = "Auto Logon (Note: Your Password Will Be Visible In The Registry)"
        '
        'LabelSeparator3
        '
        Me.LabelSeparator3.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator3.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator3.Location = New System.Drawing.Point(2, 27)
        Me.LabelSeparator3.Name = "LabelSeparator3"
        Me.LabelSeparator3.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator3.TabIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.ButtonSaveRegisteredOrganization)
        Me.Panel2.Controls.Add(Me.ButtonSaveRegisteredUser)
        Me.Panel2.Controls.Add(Me.TextBoxRegisteredOrganization)
        Me.Panel2.Controls.Add(Me.TextBoxRegisteredUser)
        Me.Panel2.Controls.Add(Me.LabelRegisteredOrganization)
        Me.Panel2.Controls.Add(Me.LabelRegisteredUser)
        Me.Panel2.Controls.Add(Me.LabelRegistration)
        Me.Panel2.Controls.Add(Me.LabelSeparator)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(647, 114)
        Me.Panel2.TabIndex = 0
        '
        'ButtonSaveRegisteredOrganization
        '
        Me.ButtonSaveRegisteredOrganization.AutoSize = True
        Me.ButtonSaveRegisteredOrganization.Enabled = False
        Me.ButtonSaveRegisteredOrganization.Location = New System.Drawing.Point(550, 79)
        Me.ButtonSaveRegisteredOrganization.Name = "ButtonSaveRegisteredOrganization"
        Me.ButtonSaveRegisteredOrganization.Size = New System.Drawing.Size(70, 27)
        Me.ButtonSaveRegisteredOrganization.TabIndex = 3
        Me.ButtonSaveRegisteredOrganization.Text = "Save"
        Me.ButtonSaveRegisteredOrganization.UseVisualStyleBackColor = True
        '
        'ButtonSaveRegisteredUser
        '
        Me.ButtonSaveRegisteredUser.AutoSize = True
        Me.ButtonSaveRegisteredUser.Enabled = False
        Me.ButtonSaveRegisteredUser.Location = New System.Drawing.Point(550, 51)
        Me.ButtonSaveRegisteredUser.Name = "ButtonSaveRegisteredUser"
        Me.ButtonSaveRegisteredUser.Size = New System.Drawing.Size(70, 27)
        Me.ButtonSaveRegisteredUser.TabIndex = 2
        Me.ButtonSaveRegisteredUser.Text = "Save"
        Me.ButtonSaveRegisteredUser.UseVisualStyleBackColor = True
        '
        'TextBoxRegisteredOrganization
        '
        Me.TextBoxRegisteredOrganization.AcceptsReturn = True
        Me.TextBoxRegisteredOrganization.Location = New System.Drawing.Point(160, 80)
        Me.TextBoxRegisteredOrganization.Name = "TextBoxRegisteredOrganization"
        Me.TextBoxRegisteredOrganization.Size = New System.Drawing.Size(322, 25)
        Me.TextBoxRegisteredOrganization.TabIndex = 1
        '
        'TextBoxRegisteredUser
        '
        Me.TextBoxRegisteredUser.Location = New System.Drawing.Point(160, 52)
        Me.TextBoxRegisteredUser.Name = "TextBoxRegisteredUser"
        Me.TextBoxRegisteredUser.Size = New System.Drawing.Size(322, 25)
        Me.TextBoxRegisteredUser.TabIndex = 0
        '
        'LabelRegisteredOrganization
        '
        Me.LabelRegisteredOrganization.AutoSize = True
        Me.LabelRegisteredOrganization.BackColor = System.Drawing.Color.Transparent
        Me.LabelRegisteredOrganization.Location = New System.Drawing.Point(2, 84)
        Me.LabelRegisteredOrganization.Name = "LabelRegisteredOrganization"
        Me.LabelRegisteredOrganization.Size = New System.Drawing.Size(153, 17)
        Me.LabelRegisteredOrganization.TabIndex = 7
        Me.LabelRegisteredOrganization.Text = "Registered Organization:"
        '
        'LabelRegisteredUser
        '
        Me.LabelRegisteredUser.AutoSize = True
        Me.LabelRegisteredUser.BackColor = System.Drawing.Color.Transparent
        Me.LabelRegisteredUser.Location = New System.Drawing.Point(2, 56)
        Me.LabelRegisteredUser.Name = "LabelRegisteredUser"
        Me.LabelRegisteredUser.Size = New System.Drawing.Size(105, 17)
        Me.LabelRegisteredUser.TabIndex = 6
        Me.LabelRegisteredUser.Text = "Registered User:"
        '
        'LabelRegistration
        '
        Me.LabelRegistration.AutoEllipsis = True
        Me.LabelRegistration.BackColor = System.Drawing.Color.Transparent
        Me.LabelRegistration.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRegistration.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelRegistration.Location = New System.Drawing.Point(2, 12)
        Me.LabelRegistration.Name = "LabelRegistration"
        Me.LabelRegistration.Size = New System.Drawing.Size(480, 17)
        Me.LabelRegistration.TabIndex = 4
        Me.LabelRegistration.Text = "Registration"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(2, 34)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 5
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.ButtonSaveRegisteredOrganization2)
        Me.Panel3.Controls.Add(Me.ButtonSaveRegisteredUser2)
        Me.Panel3.Controls.Add(Me.TextBoxRegisteredOrganization2)
        Me.Panel3.Controls.Add(Me.TextBoxRegisteredUser2)
        Me.Panel3.Controls.Add(Me.LabelRegisteredOrganization2)
        Me.Panel3.Controls.Add(Me.LabelRegisteredUser2)
        Me.Panel3.Controls.Add(Me.LabelRegistration2)
        Me.Panel3.Controls.Add(Me.LabelSeparator2)
        Me.Panel3.Location = New System.Drawing.Point(3, 172)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(647, 114)
        Me.Panel3.TabIndex = 1
        '
        'ButtonSaveRegisteredOrganization2
        '
        Me.ButtonSaveRegisteredOrganization2.AutoSize = True
        Me.ButtonSaveRegisteredOrganization2.Enabled = False
        Me.ButtonSaveRegisteredOrganization2.Location = New System.Drawing.Point(550, 78)
        Me.ButtonSaveRegisteredOrganization2.Name = "ButtonSaveRegisteredOrganization2"
        Me.ButtonSaveRegisteredOrganization2.Size = New System.Drawing.Size(70, 27)
        Me.ButtonSaveRegisteredOrganization2.TabIndex = 3
        Me.ButtonSaveRegisteredOrganization2.Text = "Save"
        Me.ButtonSaveRegisteredOrganization2.UseVisualStyleBackColor = True
        '
        'ButtonSaveRegisteredUser2
        '
        Me.ButtonSaveRegisteredUser2.AutoSize = True
        Me.ButtonSaveRegisteredUser2.Enabled = False
        Me.ButtonSaveRegisteredUser2.Location = New System.Drawing.Point(550, 50)
        Me.ButtonSaveRegisteredUser2.Name = "ButtonSaveRegisteredUser2"
        Me.ButtonSaveRegisteredUser2.Size = New System.Drawing.Size(70, 27)
        Me.ButtonSaveRegisteredUser2.TabIndex = 1
        Me.ButtonSaveRegisteredUser2.Text = "Save"
        Me.ButtonSaveRegisteredUser2.UseVisualStyleBackColor = True
        '
        'TextBoxRegisteredOrganization2
        '
        Me.TextBoxRegisteredOrganization2.AcceptsReturn = True
        Me.TextBoxRegisteredOrganization2.Location = New System.Drawing.Point(160, 79)
        Me.TextBoxRegisteredOrganization2.Name = "TextBoxRegisteredOrganization2"
        Me.TextBoxRegisteredOrganization2.Size = New System.Drawing.Size(322, 25)
        Me.TextBoxRegisteredOrganization2.TabIndex = 2
        '
        'TextBoxRegisteredUser2
        '
        Me.TextBoxRegisteredUser2.Location = New System.Drawing.Point(160, 51)
        Me.TextBoxRegisteredUser2.Name = "TextBoxRegisteredUser2"
        Me.TextBoxRegisteredUser2.Size = New System.Drawing.Size(322, 25)
        Me.TextBoxRegisteredUser2.TabIndex = 0
        '
        'LabelRegisteredOrganization2
        '
        Me.LabelRegisteredOrganization2.AutoSize = True
        Me.LabelRegisteredOrganization2.BackColor = System.Drawing.Color.Transparent
        Me.LabelRegisteredOrganization2.Location = New System.Drawing.Point(2, 83)
        Me.LabelRegisteredOrganization2.Name = "LabelRegisteredOrganization2"
        Me.LabelRegisteredOrganization2.Size = New System.Drawing.Size(153, 17)
        Me.LabelRegisteredOrganization2.TabIndex = 7
        Me.LabelRegisteredOrganization2.Text = "Registered Organization:"
        '
        'LabelRegisteredUser2
        '
        Me.LabelRegisteredUser2.AutoSize = True
        Me.LabelRegisteredUser2.BackColor = System.Drawing.Color.Transparent
        Me.LabelRegisteredUser2.Location = New System.Drawing.Point(2, 55)
        Me.LabelRegisteredUser2.Name = "LabelRegisteredUser2"
        Me.LabelRegisteredUser2.Size = New System.Drawing.Size(105, 17)
        Me.LabelRegisteredUser2.TabIndex = 6
        Me.LabelRegisteredUser2.Text = "Registered User:"
        '
        'LabelRegistration2
        '
        Me.LabelRegistration2.AutoEllipsis = True
        Me.LabelRegistration2.BackColor = System.Drawing.Color.Transparent
        Me.LabelRegistration2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRegistration2.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelRegistration2.Location = New System.Drawing.Point(2, 13)
        Me.LabelRegistration2.Name = "LabelRegistration2"
        Me.LabelRegistration2.Size = New System.Drawing.Size(482, 17)
        Me.LabelRegistration2.TabIndex = 4
        Me.LabelRegistration2.Text = "Registration (32-Bit Compatilibity Node)"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(2, 34)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 5
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel3, 0, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(85, 77)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(655, 509)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'UserInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "UserInformation"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSetAutoLogon As System.Windows.Forms.Button
    Friend WithEvents ButtonClearAutoLogon As System.Windows.Forms.Button
    Friend WithEvents LabelPassword As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents LabelUserName As System.Windows.Forms.Label
    Friend WithEvents TextBoxUserName As System.Windows.Forms.TextBox
    Private WithEvents LabelAutoLogon As System.Windows.Forms.Label
    Private WithEvents LabelSeparator3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents ButtonSaveRegisteredOrganization As System.Windows.Forms.Button
    Private WithEvents ButtonSaveRegisteredUser As System.Windows.Forms.Button
    Private WithEvents TextBoxRegisteredOrganization As System.Windows.Forms.TextBox
    Private WithEvents TextBoxRegisteredUser As System.Windows.Forms.TextBox
    Private WithEvents LabelRegisteredOrganization As System.Windows.Forms.Label
    Private WithEvents LabelRegisteredUser As System.Windows.Forms.Label
    Private WithEvents LabelRegistration As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents ButtonSaveRegisteredOrganization2 As System.Windows.Forms.Button
    Private WithEvents ButtonSaveRegisteredUser2 As System.Windows.Forms.Button
    Private WithEvents TextBoxRegisteredOrganization2 As System.Windows.Forms.TextBox
    Private WithEvents TextBoxRegisteredUser2 As System.Windows.Forms.TextBox
    Private WithEvents LabelRegisteredOrganization2 As System.Windows.Forms.Label
    Private WithEvents LabelRegisteredUser2 As System.Windows.Forms.Label
    Private WithEvents LabelRegistration2 As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents LabelAutoLogonStatus As System.Windows.Forms.Label

End Class
