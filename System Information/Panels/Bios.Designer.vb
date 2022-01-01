<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Bios
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
        Me.LabelSMBIOSPresent = New System.Windows.Forms.Label
        Me.LabelReleaseDate = New System.Windows.Forms.Label
        Me.LabelVersion = New System.Windows.Forms.Label
        Me.LabelModel = New System.Windows.Forms.Label
        Me.LabelManufacturer = New System.Windows.Forms.Label
        Me.LabelSMPresentDesc = New System.Windows.Forms.Label
        Me.LabelRelDateDesc = New System.Windows.Forms.Label
        Me.LabelModelDesc = New System.Windows.Forms.Label
        Me.LabelManDesc = New System.Windows.Forms.Label
        Me.LabelGeneral = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelVersionDesc = New System.Windows.Forms.Label
        Me.LabelSMVerDesc = New System.Windows.Forms.Label
        Me.LabelSMBIOSVersion = New System.Windows.Forms.Label
        Me.LabelFeatures = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewFeatures = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.LabelWait = New System.Windows.Forms.Label
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWait.SuspendLayout()
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
        Me.LabelTitle.Size = New System.Drawing.Size(55, 25)
        Me.LabelTitle.TabIndex = 7
        Me.LabelTitle.Text = "BIOS"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.BIOS_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelSMBIOSPresent
        '
        Me.LabelSMBIOSPresent.AutoSize = True
        Me.LabelSMBIOSPresent.BackColor = System.Drawing.Color.Transparent
        Me.LabelSMBIOSPresent.Location = New System.Drawing.Point(207, 194)
        Me.LabelSMBIOSPresent.Name = "LabelSMBIOSPresent"
        Me.LabelSMBIOSPresent.Size = New System.Drawing.Size(0, 17)
        Me.LabelSMBIOSPresent.TabIndex = 41
        '
        'LabelReleaseDate
        '
        Me.LabelReleaseDate.AutoSize = True
        Me.LabelReleaseDate.BackColor = System.Drawing.Color.Transparent
        Me.LabelReleaseDate.Location = New System.Drawing.Point(207, 172)
        Me.LabelReleaseDate.Name = "LabelReleaseDate"
        Me.LabelReleaseDate.Size = New System.Drawing.Size(0, 17)
        Me.LabelReleaseDate.TabIndex = 40
        '
        'LabelVersion
        '
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelVersion.Location = New System.Drawing.Point(207, 150)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(0, 17)
        Me.LabelVersion.TabIndex = 39
        '
        'LabelModel
        '
        Me.LabelModel.AutoSize = True
        Me.LabelModel.BackColor = System.Drawing.Color.Transparent
        Me.LabelModel.Location = New System.Drawing.Point(207, 128)
        Me.LabelModel.Name = "LabelModel"
        Me.LabelModel.Size = New System.Drawing.Size(0, 17)
        Me.LabelModel.TabIndex = 38
        '
        'LabelManufacturer
        '
        Me.LabelManufacturer.AutoSize = True
        Me.LabelManufacturer.BackColor = System.Drawing.Color.Transparent
        Me.LabelManufacturer.Location = New System.Drawing.Point(207, 106)
        Me.LabelManufacturer.Name = "LabelManufacturer"
        Me.LabelManufacturer.Size = New System.Drawing.Size(0, 17)
        Me.LabelManufacturer.TabIndex = 37
        '
        'LabelSMPresentDesc
        '
        Me.LabelSMPresentDesc.AutoSize = True
        Me.LabelSMPresentDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelSMPresentDesc.Location = New System.Drawing.Point(87, 194)
        Me.LabelSMPresentDesc.Name = "LabelSMPresentDesc"
        Me.LabelSMPresentDesc.Size = New System.Drawing.Size(104, 17)
        Me.LabelSMPresentDesc.TabIndex = 36
        Me.LabelSMPresentDesc.Text = "SMBIOS Present:"
        '
        'LabelRelDateDesc
        '
        Me.LabelRelDateDesc.AutoSize = True
        Me.LabelRelDateDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelRelDateDesc.Location = New System.Drawing.Point(87, 172)
        Me.LabelRelDateDesc.Name = "LabelRelDateDesc"
        Me.LabelRelDateDesc.Size = New System.Drawing.Size(87, 17)
        Me.LabelRelDateDesc.TabIndex = 35
        Me.LabelRelDateDesc.Text = "Release Date:"
        '
        'LabelModelDesc
        '
        Me.LabelModelDesc.AutoSize = True
        Me.LabelModelDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelModelDesc.Location = New System.Drawing.Point(87, 128)
        Me.LabelModelDesc.Name = "LabelModelDesc"
        Me.LabelModelDesc.Size = New System.Drawing.Size(49, 17)
        Me.LabelModelDesc.TabIndex = 34
        Me.LabelModelDesc.Text = "Model:"
        '
        'LabelManDesc
        '
        Me.LabelManDesc.AutoSize = True
        Me.LabelManDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelManDesc.Location = New System.Drawing.Point(87, 106)
        Me.LabelManDesc.Name = "LabelManDesc"
        Me.LabelManDesc.Size = New System.Drawing.Size(89, 17)
        Me.LabelManDesc.TabIndex = 33
        Me.LabelManDesc.Text = "Manufacturer:"
        '
        'LabelGeneral
        '
        Me.LabelGeneral.AutoSize = True
        Me.LabelGeneral.BackColor = System.Drawing.Color.Transparent
        Me.LabelGeneral.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGeneral.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelGeneral.Location = New System.Drawing.Point(87, 76)
        Me.LabelGeneral.Name = "LabelGeneral"
        Me.LabelGeneral.Size = New System.Drawing.Size(55, 17)
        Me.LabelGeneral.TabIndex = 32
        Me.LabelGeneral.Text = "General"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 31
        '
        'LabelVersionDesc
        '
        Me.LabelVersionDesc.AutoSize = True
        Me.LabelVersionDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelVersionDesc.Location = New System.Drawing.Point(87, 150)
        Me.LabelVersionDesc.Name = "LabelVersionDesc"
        Me.LabelVersionDesc.Size = New System.Drawing.Size(55, 17)
        Me.LabelVersionDesc.TabIndex = 42
        Me.LabelVersionDesc.Text = "Version:"
        '
        'LabelSMVerDesc
        '
        Me.LabelSMVerDesc.AutoSize = True
        Me.LabelSMVerDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelSMVerDesc.Location = New System.Drawing.Point(87, 216)
        Me.LabelSMVerDesc.Name = "LabelSMVerDesc"
        Me.LabelSMVerDesc.Size = New System.Drawing.Size(105, 17)
        Me.LabelSMVerDesc.TabIndex = 43
        Me.LabelSMVerDesc.Text = "SMBIOS Version:"
        '
        'LabelSMBIOSVersion
        '
        Me.LabelSMBIOSVersion.AutoSize = True
        Me.LabelSMBIOSVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelSMBIOSVersion.Location = New System.Drawing.Point(207, 216)
        Me.LabelSMBIOSVersion.Name = "LabelSMBIOSVersion"
        Me.LabelSMBIOSVersion.Size = New System.Drawing.Size(0, 17)
        Me.LabelSMBIOSVersion.TabIndex = 44
        '
        'LabelFeatures
        '
        Me.LabelFeatures.AutoSize = True
        Me.LabelFeatures.BackColor = System.Drawing.Color.Transparent
        Me.LabelFeatures.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFeatures.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelFeatures.Location = New System.Drawing.Point(87, 252)
        Me.LabelFeatures.Name = "LabelFeatures"
        Me.LabelFeatures.Size = New System.Drawing.Size(60, 17)
        Me.LabelFeatures.TabIndex = 46
        Me.LabelFeatures.Text = "Features"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(87, 274)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 45
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewFeatures)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 286)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 326)
        Me.PanelWait.TabIndex = 47
        '
        'ListViewFeatures
        '
        Me.ListViewFeatures.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewFeatures.ForeColor = System.Drawing.Color.Black
        Me.ListViewFeatures.FullRowSelect = True
        Me.ListViewFeatures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFeatures.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewFeatures.Name = "ListViewFeatures"
        Me.ListViewFeatures.Size = New System.Drawing.Size(642, 326)
        Me.ListViewFeatures.TabIndex = 77
        Me.ListViewFeatures.UseCompatibleStateImageBehavior = False
        Me.ListViewFeatures.View = System.Windows.Forms.View.Details
        Me.ListViewFeatures.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Feature"
        Me.ColumnHeader1.Width = 200
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Value"
        Me.ColumnHeader2.Width = 415
        '
        'LabelWait
        '
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(182, 153)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(275, 25)
        Me.LabelWait.TabIndex = 76
        Me.LabelWait.Text = "Loading Features, Please Wait..."
        '
        'Bios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelFeatures)
        Me.Controls.Add(Me.LabelSeparator2)
        Me.Controls.Add(Me.LabelSMBIOSVersion)
        Me.Controls.Add(Me.LabelSMVerDesc)
        Me.Controls.Add(Me.LabelVersionDesc)
        Me.Controls.Add(Me.LabelSMBIOSPresent)
        Me.Controls.Add(Me.LabelReleaseDate)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelModel)
        Me.Controls.Add(Me.LabelManufacturer)
        Me.Controls.Add(Me.LabelSMPresentDesc)
        Me.Controls.Add(Me.LabelRelDateDesc)
        Me.Controls.Add(Me.LabelModelDesc)
        Me.Controls.Add(Me.LabelManDesc)
        Me.Controls.Add(Me.LabelGeneral)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Bios"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelSMBIOSPresent As System.Windows.Forms.Label
    Private WithEvents LabelReleaseDate As System.Windows.Forms.Label
    Private WithEvents LabelVersion As System.Windows.Forms.Label
    Private WithEvents LabelModel As System.Windows.Forms.Label
    Private WithEvents LabelManufacturer As System.Windows.Forms.Label
    Private WithEvents LabelSMPresentDesc As System.Windows.Forms.Label
    Private WithEvents LabelRelDateDesc As System.Windows.Forms.Label
    Private WithEvents LabelModelDesc As System.Windows.Forms.Label
    Private WithEvents LabelManDesc As System.Windows.Forms.Label
    Private WithEvents LabelGeneral As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelVersionDesc As System.Windows.Forms.Label
    Private WithEvents LabelSMVerDesc As System.Windows.Forms.Label
    Private WithEvents LabelSMBIOSVersion As System.Windows.Forms.Label
    Private WithEvents LabelFeatures As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Private WithEvents ListViewFeatures As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader

End Class
