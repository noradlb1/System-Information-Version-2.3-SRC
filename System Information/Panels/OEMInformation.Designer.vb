<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OemInformation
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
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelOEMInformation = New System.Windows.Forms.Label
        Me.LabelManufactuer = New System.Windows.Forms.Label
        Me.LabelModel = New System.Windows.Forms.Label
        Me.TextBoxManufacturer = New System.Windows.Forms.TextBox
        Me.TextBoxModel = New System.Windows.Forms.TextBox
        Me.ButtonClearOEMInfo = New System.Windows.Forms.Button
        Me.ButtonSaveOEMInfo = New System.Windows.Forms.Button
        Me.TextBoxSupportPhone = New System.Windows.Forms.TextBox
        Me.TextBoxSupportHours = New System.Windows.Forms.TextBox
        Me.LabelSupportPhone = New System.Windows.Forms.Label
        Me.LabelSupportHours = New System.Windows.Forms.Label
        Me.TextBoxSupportWebsite = New System.Windows.Forms.TextBox
        Me.LabelSupportWebsite = New System.Windows.Forms.Label
        Me.LabelWebsiteLink = New System.Windows.Forms.Label
        Me.LinkLabelOEMWebsite = New System.Windows.Forms.LinkLabel
        Me.ButtonRemoveLogo = New System.Windows.Forms.Button
        Me.ButtonAddLogo = New System.Windows.Forms.Button
        Me.PictureBoxLogo = New System.Windows.Forms.PictureBox
        Me.LabelLogoNote = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.LabelLogo = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LabelTitle.Size = New System.Drawing.Size(167, 25)
        Me.LabelTitle.TabIndex = 21
        Me.LabelTitle.Text = "OEM Information"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.OEM_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 19
        '
        'LabelOEMInformation
        '
        Me.LabelOEMInformation.AutoSize = True
        Me.LabelOEMInformation.BackColor = System.Drawing.Color.Transparent
        Me.LabelOEMInformation.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOEMInformation.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelOEMInformation.Location = New System.Drawing.Point(87, 76)
        Me.LabelOEMInformation.Name = "LabelOEMInformation"
        Me.LabelOEMInformation.Size = New System.Drawing.Size(115, 17)
        Me.LabelOEMInformation.TabIndex = 20
        Me.LabelOEMInformation.Text = "OEM Information"
        '
        'LabelManufactuer
        '
        Me.LabelManufactuer.AutoSize = True
        Me.LabelManufactuer.BackColor = System.Drawing.Color.Transparent
        Me.LabelManufactuer.Location = New System.Drawing.Point(87, 122)
        Me.LabelManufactuer.Name = "LabelManufactuer"
        Me.LabelManufactuer.Size = New System.Drawing.Size(89, 17)
        Me.LabelManufactuer.TabIndex = 18
        Me.LabelManufactuer.Text = "Manufacturer:"
        '
        'LabelModel
        '
        Me.LabelModel.AutoSize = True
        Me.LabelModel.BackColor = System.Drawing.Color.Transparent
        Me.LabelModel.Location = New System.Drawing.Point(87, 150)
        Me.LabelModel.Name = "LabelModel"
        Me.LabelModel.Size = New System.Drawing.Size(49, 17)
        Me.LabelModel.TabIndex = 17
        Me.LabelModel.Text = "Model:"
        '
        'TextBoxManufacturer
        '
        Me.TextBoxManufacturer.Location = New System.Drawing.Point(220, 118)
        Me.TextBoxManufacturer.Name = "TextBoxManufacturer"
        Me.TextBoxManufacturer.Size = New System.Drawing.Size(344, 25)
        Me.TextBoxManufacturer.TabIndex = 0
        '
        'TextBoxModel
        '
        Me.TextBoxModel.AcceptsReturn = True
        Me.TextBoxModel.Location = New System.Drawing.Point(220, 146)
        Me.TextBoxModel.Name = "TextBoxModel"
        Me.TextBoxModel.Size = New System.Drawing.Size(344, 25)
        Me.TextBoxModel.TabIndex = 1
        '
        'ButtonClearOEMInfo
        '
        Me.ButtonClearOEMInfo.Enabled = False
        Me.ButtonClearOEMInfo.Location = New System.Drawing.Point(492, 286)
        Me.ButtonClearOEMInfo.Name = "ButtonClearOEMInfo"
        Me.ButtonClearOEMInfo.Size = New System.Drawing.Size(72, 27)
        Me.ButtonClearOEMInfo.TabIndex = 7
        Me.ButtonClearOEMInfo.Text = "Clear"
        Me.ButtonClearOEMInfo.UseVisualStyleBackColor = True
        '
        'ButtonSaveOEMInfo
        '
        Me.ButtonSaveOEMInfo.Enabled = False
        Me.ButtonSaveOEMInfo.Location = New System.Drawing.Point(414, 286)
        Me.ButtonSaveOEMInfo.Name = "ButtonSaveOEMInfo"
        Me.ButtonSaveOEMInfo.Size = New System.Drawing.Size(72, 27)
        Me.ButtonSaveOEMInfo.TabIndex = 6
        Me.ButtonSaveOEMInfo.Text = "Save"
        Me.ButtonSaveOEMInfo.UseVisualStyleBackColor = True
        '
        'TextBoxSupportPhone
        '
        Me.TextBoxSupportPhone.AcceptsReturn = True
        Me.TextBoxSupportPhone.Location = New System.Drawing.Point(220, 202)
        Me.TextBoxSupportPhone.Name = "TextBoxSupportPhone"
        Me.TextBoxSupportPhone.Size = New System.Drawing.Size(344, 25)
        Me.TextBoxSupportPhone.TabIndex = 3
        '
        'TextBoxSupportHours
        '
        Me.TextBoxSupportHours.Location = New System.Drawing.Point(220, 174)
        Me.TextBoxSupportHours.Name = "TextBoxSupportHours"
        Me.TextBoxSupportHours.Size = New System.Drawing.Size(344, 25)
        Me.TextBoxSupportHours.TabIndex = 2
        '
        'LabelSupportPhone
        '
        Me.LabelSupportPhone.AutoSize = True
        Me.LabelSupportPhone.BackColor = System.Drawing.Color.Transparent
        Me.LabelSupportPhone.Location = New System.Drawing.Point(87, 206)
        Me.LabelSupportPhone.Name = "LabelSupportPhone"
        Me.LabelSupportPhone.Size = New System.Drawing.Size(98, 17)
        Me.LabelSupportPhone.TabIndex = 15
        Me.LabelSupportPhone.Text = "Support Phone:"
        '
        'LabelSupportHours
        '
        Me.LabelSupportHours.AutoSize = True
        Me.LabelSupportHours.BackColor = System.Drawing.Color.Transparent
        Me.LabelSupportHours.Location = New System.Drawing.Point(87, 178)
        Me.LabelSupportHours.Name = "LabelSupportHours"
        Me.LabelSupportHours.Size = New System.Drawing.Size(97, 17)
        Me.LabelSupportHours.TabIndex = 16
        Me.LabelSupportHours.Text = "Support Hours:"
        '
        'TextBoxSupportWebsite
        '
        Me.TextBoxSupportWebsite.AcceptsReturn = True
        Me.TextBoxSupportWebsite.Location = New System.Drawing.Point(220, 230)
        Me.TextBoxSupportWebsite.Name = "TextBoxSupportWebsite"
        Me.TextBoxSupportWebsite.Size = New System.Drawing.Size(344, 25)
        Me.TextBoxSupportWebsite.TabIndex = 4
        '
        'LabelSupportWebsite
        '
        Me.LabelSupportWebsite.AutoSize = True
        Me.LabelSupportWebsite.BackColor = System.Drawing.Color.Transparent
        Me.LabelSupportWebsite.Location = New System.Drawing.Point(87, 234)
        Me.LabelSupportWebsite.Name = "LabelSupportWebsite"
        Me.LabelSupportWebsite.Size = New System.Drawing.Size(109, 17)
        Me.LabelSupportWebsite.TabIndex = 14
        Me.LabelSupportWebsite.Text = "Support Website:"
        '
        'LabelWebsiteLink
        '
        Me.LabelWebsiteLink.AutoSize = True
        Me.LabelWebsiteLink.BackColor = System.Drawing.Color.Transparent
        Me.LabelWebsiteLink.Location = New System.Drawing.Point(87, 262)
        Me.LabelWebsiteLink.Name = "LabelWebsiteLink"
        Me.LabelWebsiteLink.Size = New System.Drawing.Size(109, 17)
        Me.LabelWebsiteLink.TabIndex = 13
        Me.LabelWebsiteLink.Text = "Support Website:"
        '
        'LinkLabelOEMWebsite
        '
        Me.LinkLabelOEMWebsite.AutoEllipsis = True
        Me.LinkLabelOEMWebsite.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelOEMWebsite.Location = New System.Drawing.Point(220, 262)
        Me.LinkLabelOEMWebsite.Name = "LinkLabelOEMWebsite"
        Me.LinkLabelOEMWebsite.Size = New System.Drawing.Size(344, 21)
        Me.LinkLabelOEMWebsite.TabIndex = 5
        '
        'ButtonRemoveLogo
        '
        Me.ButtonRemoveLogo.AutoSize = True
        Me.ButtonRemoveLogo.Enabled = False
        Me.ButtonRemoveLogo.Location = New System.Drawing.Point(316, 447)
        Me.ButtonRemoveLogo.Name = "ButtonRemoveLogo"
        Me.ButtonRemoveLogo.Size = New System.Drawing.Size(72, 27)
        Me.ButtonRemoveLogo.TabIndex = 9
        Me.ButtonRemoveLogo.Text = "Remove"
        Me.ButtonRemoveLogo.UseVisualStyleBackColor = True
        '
        'ButtonAddLogo
        '
        Me.ButtonAddLogo.Enabled = False
        Me.ButtonAddLogo.Location = New System.Drawing.Point(238, 447)
        Me.ButtonAddLogo.Name = "ButtonAddLogo"
        Me.ButtonAddLogo.Size = New System.Drawing.Size(72, 27)
        Me.ButtonAddLogo.TabIndex = 8
        Me.ButtonAddLogo.Text = "Add"
        Me.ButtonAddLogo.UseVisualStyleBackColor = True
        '
        'PictureBoxLogo
        '
        Me.PictureBoxLogo.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxLogo.Location = New System.Drawing.Point(92, 354)
        Me.PictureBoxLogo.Name = "PictureBoxLogo"
        Me.PictureBoxLogo.Size = New System.Drawing.Size(120, 120)
        Me.PictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxLogo.TabIndex = 55
        Me.PictureBoxLogo.TabStop = False
        '
        'LabelLogoNote
        '
        Me.LabelLogoNote.BackColor = System.Drawing.Color.Transparent
        Me.LabelLogoNote.Location = New System.Drawing.Point(220, 354)
        Me.LabelLogoNote.Name = "LabelLogoNote"
        Me.LabelLogoNote.Size = New System.Drawing.Size(215, 43)
        Me.LabelLogoNote.TabIndex = 10
        Me.LabelLogoNote.Text = "Note: Logo is a 120 X 120 pixel bitmap (*.bmp"")."
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LabelLogo
        '
        Me.LabelLogo.AutoSize = True
        Me.LabelLogo.BackColor = System.Drawing.Color.Transparent
        Me.LabelLogo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLogo.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelLogo.Location = New System.Drawing.Point(87, 307)
        Me.LabelLogo.Name = "LabelLogo"
        Me.LabelLogo.Size = New System.Drawing.Size(39, 17)
        Me.LabelLogo.TabIndex = 12
        Me.LabelLogo.Text = "Logo"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Location = New System.Drawing.Point(87, 329)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(642, 3)
        Me.Label2.TabIndex = 11
        '
        'OemInformation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LabelLogo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelLogoNote)
        Me.Controls.Add(Me.PictureBoxLogo)
        Me.Controls.Add(Me.ButtonRemoveLogo)
        Me.Controls.Add(Me.ButtonAddLogo)
        Me.Controls.Add(Me.LinkLabelOEMWebsite)
        Me.Controls.Add(Me.LabelWebsiteLink)
        Me.Controls.Add(Me.TextBoxSupportWebsite)
        Me.Controls.Add(Me.LabelSupportWebsite)
        Me.Controls.Add(Me.ButtonClearOEMInfo)
        Me.Controls.Add(Me.ButtonSaveOEMInfo)
        Me.Controls.Add(Me.TextBoxSupportPhone)
        Me.Controls.Add(Me.TextBoxSupportHours)
        Me.Controls.Add(Me.LabelSupportPhone)
        Me.Controls.Add(Me.LabelSupportHours)
        Me.Controls.Add(Me.TextBoxModel)
        Me.Controls.Add(Me.TextBoxManufacturer)
        Me.Controls.Add(Me.LabelModel)
        Me.Controls.Add(Me.LabelManufactuer)
        Me.Controls.Add(Me.LabelOEMInformation)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "OemInformation"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelOEMInformation As System.Windows.Forms.Label
    Private WithEvents LabelManufactuer As System.Windows.Forms.Label
    Private WithEvents LabelModel As System.Windows.Forms.Label
    Private WithEvents TextBoxManufacturer As System.Windows.Forms.TextBox
    Private WithEvents TextBoxModel As System.Windows.Forms.TextBox
    Private WithEvents ButtonClearOEMInfo As System.Windows.Forms.Button
    Private WithEvents ButtonSaveOEMInfo As System.Windows.Forms.Button
    Private WithEvents TextBoxSupportPhone As System.Windows.Forms.TextBox
    Private WithEvents TextBoxSupportHours As System.Windows.Forms.TextBox
    Private WithEvents LabelSupportPhone As System.Windows.Forms.Label
    Private WithEvents LabelSupportHours As System.Windows.Forms.Label
    Private WithEvents TextBoxSupportWebsite As System.Windows.Forms.TextBox
    Private WithEvents LabelSupportWebsite As System.Windows.Forms.Label
    Private WithEvents LabelWebsiteLink As System.Windows.Forms.Label
    Friend WithEvents LinkLabelOEMWebsite As System.Windows.Forms.LinkLabel
    Private WithEvents ButtonRemoveLogo As System.Windows.Forms.Button
    Private WithEvents ButtonAddLogo As System.Windows.Forms.Button
    Friend WithEvents PictureBoxLogo As System.Windows.Forms.PictureBox
    Private WithEvents LabelLogoNote As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Private WithEvents LabelLogo As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label

End Class
