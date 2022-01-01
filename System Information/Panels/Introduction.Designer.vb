<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Introduction
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
        Me.LabelDirections = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelAbout = New System.Windows.Forms.Label
        Me.LabelAppVersion = New System.Windows.Forms.Label
        Me.LabelAppDescription = New System.Windows.Forms.Label
        Me.LabelAppCopyright = New System.Windows.Forms.Label
        Me.LabelLicenseTerms = New System.Windows.Forms.Label
        Me.LinkLabelEULA = New System.Windows.Forms.LinkLabel
        Me.LabelCustomerName = New System.Windows.Forms.Label
        Me.LabelCustomerOrganization = New System.Windows.Forms.Label
        Me.LabelTitleCompany = New System.Windows.Forms.Label
        Me.LabelWindows = New System.Windows.Forms.Label
        Me.LabelOptions = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBoxStartWithWindows = New System.Windows.Forms.CheckBox
        Me.CheckBoxStartAsIconInTray = New System.Windows.Forms.CheckBox
        Me.CheckBoxMinimizeToIcon = New System.Windows.Forms.CheckBox
        Me.CheckBoxCloseToIcon = New System.Windows.Forms.CheckBox
        Me.CheckBoxIconIsAlwaysVisible = New System.Windows.Forms.CheckBox
        Me.ButtonExitSystemInformationII = New System.Windows.Forms.Button
        Me.CheckBoxShowSplashScreen = New System.Windows.Forms.CheckBox
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LabelTitle.Size = New System.Drawing.Size(205, 25)
        Me.LabelTitle.TabIndex = 21
        Me.LabelTitle.Text = "System Information II"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.System_Information_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 2
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelDirections
        '
        Me.LabelDirections.AutoSize = True
        Me.LabelDirections.BackColor = System.Drawing.Color.Transparent
        Me.LabelDirections.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDirections.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelDirections.Location = New System.Drawing.Point(87, 80)
        Me.LabelDirections.Name = "LabelDirections"
        Me.LabelDirections.Size = New System.Drawing.Size(344, 17)
        Me.LabelDirections.TabIndex = 20
        Me.LabelDirections.Text = "Click a icon at the left for specific system information."
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 156)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 18
        '
        'LabelAbout
        '
        Me.LabelAbout.AutoSize = True
        Me.LabelAbout.BackColor = System.Drawing.Color.Transparent
        Me.LabelAbout.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAbout.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelAbout.Location = New System.Drawing.Point(87, 132)
        Me.LabelAbout.Name = "LabelAbout"
        Me.LabelAbout.Size = New System.Drawing.Size(172, 17)
        Me.LabelAbout.TabIndex = 19
        Me.LabelAbout.Text = "About System Information"
        '
        'LabelAppVersion
        '
        Me.LabelAppVersion.AutoSize = True
        Me.LabelAppVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelAppVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAppVersion.Location = New System.Drawing.Point(87, 172)
        Me.LabelAppVersion.Name = "LabelAppVersion"
        Me.LabelAppVersion.Size = New System.Drawing.Size(121, 17)
        Me.LabelAppVersion.TabIndex = 17
        Me.LabelAppVersion.Text = "Application Version"
        '
        'LabelAppDescription
        '
        Me.LabelAppDescription.AutoSize = True
        Me.LabelAppDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelAppDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAppDescription.Location = New System.Drawing.Point(87, 192)
        Me.LabelAppDescription.Name = "LabelAppDescription"
        Me.LabelAppDescription.Size = New System.Drawing.Size(143, 17)
        Me.LabelAppDescription.TabIndex = 16
        Me.LabelAppDescription.Text = "Application Description"
        '
        'LabelAppCopyright
        '
        Me.LabelAppCopyright.AutoSize = True
        Me.LabelAppCopyright.BackColor = System.Drawing.Color.Transparent
        Me.LabelAppCopyright.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAppCopyright.Location = New System.Drawing.Point(87, 212)
        Me.LabelAppCopyright.Name = "LabelAppCopyright"
        Me.LabelAppCopyright.Size = New System.Drawing.Size(134, 17)
        Me.LabelAppCopyright.TabIndex = 15
        Me.LabelAppCopyright.Text = "Application Copyright"
        '
        'LabelLicenseTerms
        '
        Me.LabelLicenseTerms.AutoSize = True
        Me.LabelLicenseTerms.BackColor = System.Drawing.Color.Transparent
        Me.LabelLicenseTerms.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLicenseTerms.Location = New System.Drawing.Point(87, 240)
        Me.LabelLicenseTerms.Name = "LabelLicenseTerms"
        Me.LabelLicenseTerms.Size = New System.Drawing.Size(284, 17)
        Me.LabelLicenseTerms.TabIndex = 14
        Me.LabelLicenseTerms.Text = "This product is licensed under the terms of the "
        '
        'LinkLabelEULA
        '
        Me.LinkLabelEULA.AutoSize = True
        Me.LinkLabelEULA.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelEULA.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabelEULA.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabelEULA.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LinkLabelEULA.Location = New System.Drawing.Point(87, 260)
        Me.LinkLabelEULA.Name = "LinkLabelEULA"
        Me.LinkLabelEULA.Size = New System.Drawing.Size(236, 17)
        Me.LinkLabelEULA.TabIndex = 13
        Me.LinkLabelEULA.TabStop = True
        Me.LinkLabelEULA.Text = "End User License Agreement (EULA) to:"
        '
        'LabelCustomerName
        '
        Me.LabelCustomerName.AutoSize = True
        Me.LabelCustomerName.BackColor = System.Drawing.Color.Transparent
        Me.LabelCustomerName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCustomerName.Location = New System.Drawing.Point(87, 284)
        Me.LabelCustomerName.Name = "LabelCustomerName"
        Me.LabelCustomerName.Size = New System.Drawing.Size(103, 17)
        Me.LabelCustomerName.TabIndex = 12
        Me.LabelCustomerName.Text = "Customer Name"
        '
        'LabelCustomerOrganization
        '
        Me.LabelCustomerOrganization.AutoSize = True
        Me.LabelCustomerOrganization.BackColor = System.Drawing.Color.Transparent
        Me.LabelCustomerOrganization.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCustomerOrganization.Location = New System.Drawing.Point(87, 304)
        Me.LabelCustomerOrganization.Name = "LabelCustomerOrganization"
        Me.LabelCustomerOrganization.Size = New System.Drawing.Size(143, 17)
        Me.LabelCustomerOrganization.TabIndex = 11
        Me.LabelCustomerOrganization.Text = "Customer Organization"
        '
        'LabelTitleCompany
        '
        Me.LabelTitleCompany.AutoSize = True
        Me.LabelTitleCompany.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitleCompany.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitleCompany.Location = New System.Drawing.Point(87, 332)
        Me.LabelTitleCompany.Name = "LabelTitleCompany"
        Me.LabelTitleCompany.Size = New System.Drawing.Size(289, 17)
        Me.LabelTitleCompany.TabIndex = 10
        Me.LabelTitleCompany.Text = "Application Title is a product of Company Name"
        '
        'LabelWindows
        '
        Me.LabelWindows.AutoSize = True
        Me.LabelWindows.BackColor = System.Drawing.Color.Transparent
        Me.LabelWindows.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWindows.Location = New System.Drawing.Point(87, 360)
        Me.LabelWindows.Name = "LabelWindows"
        Me.LabelWindows.Size = New System.Drawing.Size(376, 17)
        Me.LabelWindows.TabIndex = 9
        Me.LabelWindows.Text = "Windows® is a registered trademark of Microsoft Corporation"
        '
        'LabelOptions
        '
        Me.LabelOptions.AutoSize = True
        Me.LabelOptions.BackColor = System.Drawing.Color.Transparent
        Me.LabelOptions.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelOptions.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelOptions.Location = New System.Drawing.Point(87, 414)
        Me.LabelOptions.Name = "LabelOptions"
        Me.LabelOptions.Size = New System.Drawing.Size(114, 17)
        Me.LabelOptions.TabIndex = 8
        Me.LabelOptions.Text = "Program Options"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Location = New System.Drawing.Point(87, 438)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(642, 3)
        Me.Label2.TabIndex = 7
        '
        'CheckBoxStartWithWindows
        '
        Me.CheckBoxStartWithWindows.AutoSize = True
        Me.CheckBoxStartWithWindows.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxStartWithWindows.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxStartWithWindows.Location = New System.Drawing.Point(90, 458)
        Me.CheckBoxStartWithWindows.Name = "CheckBoxStartWithWindows"
        Me.CheckBoxStartWithWindows.Size = New System.Drawing.Size(254, 21)
        Me.CheckBoxStartWithWindows.TabIndex = 1
        Me.CheckBoxStartWithWindows.Text = "Start Application When &Windows Starts"
        Me.CheckBoxStartWithWindows.UseVisualStyleBackColor = False
        '
        'CheckBoxStartAsIconInTray
        '
        Me.CheckBoxStartAsIconInTray.AutoSize = True
        Me.CheckBoxStartAsIconInTray.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxStartAsIconInTray.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxStartAsIconInTray.Location = New System.Drawing.Point(90, 483)
        Me.CheckBoxStartAsIconInTray.Name = "CheckBoxStartAsIconInTray"
        Me.CheckBoxStartAsIconInTray.Size = New System.Drawing.Size(211, 21)
        Me.CheckBoxStartAsIconInTray.TabIndex = 2
        Me.CheckBoxStartAsIconInTray.Text = "Start &Application as Icon in Tray"
        Me.CheckBoxStartAsIconInTray.UseVisualStyleBackColor = False
        '
        'CheckBoxMinimizeToIcon
        '
        Me.CheckBoxMinimizeToIcon.AutoSize = True
        Me.CheckBoxMinimizeToIcon.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxMinimizeToIcon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxMinimizeToIcon.Location = New System.Drawing.Point(90, 508)
        Me.CheckBoxMinimizeToIcon.Name = "CheckBoxMinimizeToIcon"
        Me.CheckBoxMinimizeToIcon.Size = New System.Drawing.Size(152, 21)
        Me.CheckBoxMinimizeToIcon.TabIndex = 3
        Me.CheckBoxMinimizeToIcon.Text = "&Minimize to Tray Icon"
        Me.CheckBoxMinimizeToIcon.UseVisualStyleBackColor = False
        '
        'CheckBoxCloseToIcon
        '
        Me.CheckBoxCloseToIcon.AutoSize = True
        Me.CheckBoxCloseToIcon.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxCloseToIcon.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCloseToIcon.Location = New System.Drawing.Point(90, 533)
        Me.CheckBoxCloseToIcon.Name = "CheckBoxCloseToIcon"
        Me.CheckBoxCloseToIcon.Size = New System.Drawing.Size(132, 21)
        Me.CheckBoxCloseToIcon.TabIndex = 4
        Me.CheckBoxCloseToIcon.Text = "&Close to Tray Icon"
        Me.CheckBoxCloseToIcon.UseVisualStyleBackColor = False
        '
        'CheckBoxIconIsAlwaysVisible
        '
        Me.CheckBoxIconIsAlwaysVisible.AutoSize = True
        Me.CheckBoxIconIsAlwaysVisible.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxIconIsAlwaysVisible.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxIconIsAlwaysVisible.Location = New System.Drawing.Point(90, 558)
        Me.CheckBoxIconIsAlwaysVisible.Name = "CheckBoxIconIsAlwaysVisible"
        Me.CheckBoxIconIsAlwaysVisible.Size = New System.Drawing.Size(178, 21)
        Me.CheckBoxIconIsAlwaysVisible.TabIndex = 5
        Me.CheckBoxIconIsAlwaysVisible.Text = "Tray Icon Is Always &Visible"
        Me.CheckBoxIconIsAlwaysVisible.UseVisualStyleBackColor = False
        '
        'ButtonExitSystemInformationII
        '
        Me.ButtonExitSystemInformationII.AutoSize = True
        Me.ButtonExitSystemInformationII.Location = New System.Drawing.Point(556, 577)
        Me.ButtonExitSystemInformationII.Name = "ButtonExitSystemInformationII"
        Me.ButtonExitSystemInformationII.Size = New System.Drawing.Size(164, 27)
        Me.ButtonExitSystemInformationII.TabIndex = 0
        Me.ButtonExitSystemInformationII.Text = "E&xit System Information II"
        Me.ButtonExitSystemInformationII.UseVisualStyleBackColor = True
        '
        'CheckBoxShowSplashScreen
        '
        Me.CheckBoxShowSplashScreen.AutoSize = True
        Me.CheckBoxShowSplashScreen.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxShowSplashScreen.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxShowSplashScreen.Location = New System.Drawing.Point(90, 583)
        Me.CheckBoxShowSplashScreen.Name = "CheckBoxShowSplashScreen"
        Me.CheckBoxShowSplashScreen.Size = New System.Drawing.Size(143, 21)
        Me.CheckBoxShowSplashScreen.TabIndex = 6
        Me.CheckBoxShowSplashScreen.Text = "&Show Splash Screen"
        Me.CheckBoxShowSplashScreen.UseVisualStyleBackColor = False
        '
        'Introduction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.CheckBoxShowSplashScreen)
        Me.Controls.Add(Me.ButtonExitSystemInformationII)
        Me.Controls.Add(Me.CheckBoxIconIsAlwaysVisible)
        Me.Controls.Add(Me.CheckBoxCloseToIcon)
        Me.Controls.Add(Me.CheckBoxMinimizeToIcon)
        Me.Controls.Add(Me.CheckBoxStartAsIconInTray)
        Me.Controls.Add(Me.CheckBoxStartWithWindows)
        Me.Controls.Add(Me.LabelOptions)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelWindows)
        Me.Controls.Add(Me.LabelTitleCompany)
        Me.Controls.Add(Me.LabelCustomerOrganization)
        Me.Controls.Add(Me.LabelCustomerName)
        Me.Controls.Add(Me.LinkLabelEULA)
        Me.Controls.Add(Me.LabelLicenseTerms)
        Me.Controls.Add(Me.LabelAppCopyright)
        Me.Controls.Add(Me.LabelAppDescription)
        Me.Controls.Add(Me.LabelAppVersion)
        Me.Controls.Add(Me.LabelAbout)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelDirections)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Introduction"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelDirections As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelAbout As System.Windows.Forms.Label
    Private WithEvents LabelAppVersion As System.Windows.Forms.Label
    Private WithEvents LabelAppDescription As System.Windows.Forms.Label
    Private WithEvents LabelAppCopyright As System.Windows.Forms.Label
    Private WithEvents LabelLicenseTerms As System.Windows.Forms.Label
    Private WithEvents LinkLabelEULA As System.Windows.Forms.LinkLabel
    Private WithEvents LabelCustomerName As System.Windows.Forms.Label
    Private WithEvents LabelCustomerOrganization As System.Windows.Forms.Label
    Private WithEvents LabelTitleCompany As System.Windows.Forms.Label
    Private WithEvents LabelWindows As System.Windows.Forms.Label
    Private WithEvents LabelOptions As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxStartWithWindows As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxStartAsIconInTray As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxMinimizeToIcon As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCloseToIcon As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxIconIsAlwaysVisible As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonExitSystemInformationII As System.Windows.Forms.Button
    Friend WithEvents CheckBoxShowSplashScreen As System.Windows.Forms.CheckBox

End Class
