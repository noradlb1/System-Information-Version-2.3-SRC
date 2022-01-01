<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartupPrograms
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
        Me.components = New System.ComponentModel.Container
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.ContextMenuStripStartup = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuAddNewCurrentUserStartupProgram = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuAddNewAllUsersStartupProgram = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuDeleteStartupProgram = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuRefreshDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.StartupImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelStartupDescription = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelDetails = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.LabelCommandDesc = New System.Windows.Forms.Label
        Me.LabelFileVersionDesc = New System.Windows.Forms.Label
        Me.LabelDescriptionDesc = New System.Windows.Forms.Label
        Me.LabelCompanyDesc = New System.Windows.Forms.Label
        Me.LabelCommand = New System.Windows.Forms.Label
        Me.LabelFileVersion = New System.Windows.Forms.Label
        Me.LabelDescription = New System.Windows.Forms.Label
        Me.LabelCompany = New System.Windows.Forms.Label
        Me.LabelProductNameDesc = New System.Windows.Forms.Label
        Me.LabelProductName = New System.Windows.Forms.Label
        Me.LabelArgumentsDesc = New System.Windows.Forms.Label
        Me.LabelArguments = New System.Windows.Forms.Label
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewStartup = New System.Windows.Forms.ListView
        Me.ItemName = New System.Windows.Forms.ColumnHeader
        Me.FileName = New System.Windows.Forms.ColumnHeader
        Me.Type = New System.Windows.Forms.ColumnHeader
        Me.Status = New System.Windows.Forms.ColumnHeader
        Me.DisplayCommand = New System.Windows.Forms.ColumnHeader
        Me.DisplayFilePath = New System.Windows.Forms.ColumnHeader
        Me.LabelWait = New System.Windows.Forms.Label
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripStartup.SuspendLayout()
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
        Me.LabelTitle.Size = New System.Drawing.Size(171, 25)
        Me.LabelTitle.TabIndex = 7
        Me.LabelTitle.Text = "Startup Programs"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Startup_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'ContextMenuStripStartup
        '
        Me.ContextMenuStripStartup.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuAddNewCurrentUserStartupProgram, Me.ContextMenuAddNewAllUsersStartupProgram, Me.ContextMenuDeleteStartupProgram, Me.ContextMenuRefreshDisplay})
        Me.ContextMenuStripStartup.Name = "ContextMenuStripStartup"
        Me.ContextMenuStripStartup.Size = New System.Drawing.Size(283, 92)
        '
        'ContextMenuAddNewCurrentUserStartupProgram
        '
        Me.ContextMenuAddNewCurrentUserStartupProgram.Name = "ContextMenuAddNewCurrentUserStartupProgram"
        Me.ContextMenuAddNewCurrentUserStartupProgram.Size = New System.Drawing.Size(282, 22)
        Me.ContextMenuAddNewCurrentUserStartupProgram.Text = "Add New Current User Startup Program"
        '
        'ContextMenuAddNewAllUsersStartupProgram
        '
        Me.ContextMenuAddNewAllUsersStartupProgram.Name = "ContextMenuAddNewAllUsersStartupProgram"
        Me.ContextMenuAddNewAllUsersStartupProgram.Size = New System.Drawing.Size(282, 22)
        Me.ContextMenuAddNewAllUsersStartupProgram.Text = "Add New All Users Startup Program"
        '
        'ContextMenuDeleteStartupProgram
        '
        Me.ContextMenuDeleteStartupProgram.Name = "ContextMenuDeleteStartupProgram"
        Me.ContextMenuDeleteStartupProgram.Size = New System.Drawing.Size(282, 22)
        Me.ContextMenuDeleteStartupProgram.Text = "Delete Startup Program"
        '
        'ContextMenuRefreshDisplay
        '
        Me.ContextMenuRefreshDisplay.Name = "ContextMenuRefreshDisplay"
        Me.ContextMenuRefreshDisplay.Size = New System.Drawing.Size(282, 22)
        Me.ContextMenuRefreshDisplay.Text = "Refresh Display"
        '
        'StartupImageList
        '
        Me.StartupImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.StartupImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.StartupImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'LabelStartupDescription
        '
        Me.LabelStartupDescription.AutoSize = True
        Me.LabelStartupDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelStartupDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStartupDescription.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelStartupDescription.Location = New System.Drawing.Point(87, 76)
        Me.LabelStartupDescription.Name = "LabelStartupDescription"
        Me.LabelStartupDescription.Size = New System.Drawing.Size(321, 17)
        Me.LabelStartupDescription.TabIndex = 50
        Me.LabelStartupDescription.Text = "Programs that automatically run when you log on."
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 49
        '
        'LabelDetails
        '
        Me.LabelDetails.AutoSize = True
        Me.LabelDetails.BackColor = System.Drawing.Color.Transparent
        Me.LabelDetails.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDetails.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelDetails.Location = New System.Drawing.Point(87, 442)
        Me.LabelDetails.Name = "LabelDetails"
        Me.LabelDetails.Size = New System.Drawing.Size(51, 17)
        Me.LabelDetails.TabIndex = 53
        Me.LabelDetails.Text = "Details"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(87, 463)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 52
        '
        'LabelCommandDesc
        '
        Me.LabelCommandDesc.AutoSize = True
        Me.LabelCommandDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelCommandDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelCommandDesc.Location = New System.Drawing.Point(87, 551)
        Me.LabelCommandDesc.Name = "LabelCommandDesc"
        Me.LabelCommandDesc.Size = New System.Drawing.Size(71, 17)
        Me.LabelCommandDesc.TabIndex = 61
        Me.LabelCommandDesc.Text = "Command:"
        '
        'LabelFileVersionDesc
        '
        Me.LabelFileVersionDesc.AutoSize = True
        Me.LabelFileVersionDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelFileVersionDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelFileVersionDesc.Location = New System.Drawing.Point(87, 531)
        Me.LabelFileVersionDesc.Name = "LabelFileVersionDesc"
        Me.LabelFileVersionDesc.Size = New System.Drawing.Size(78, 17)
        Me.LabelFileVersionDesc.TabIndex = 60
        Me.LabelFileVersionDesc.Text = "File Version:"
        '
        'LabelDescriptionDesc
        '
        Me.LabelDescriptionDesc.AutoSize = True
        Me.LabelDescriptionDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelDescriptionDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelDescriptionDesc.Location = New System.Drawing.Point(87, 511)
        Me.LabelDescriptionDesc.Name = "LabelDescriptionDesc"
        Me.LabelDescriptionDesc.Size = New System.Drawing.Size(77, 17)
        Me.LabelDescriptionDesc.TabIndex = 59
        Me.LabelDescriptionDesc.Text = "Description:"
        '
        'LabelCompanyDesc
        '
        Me.LabelCompanyDesc.AutoSize = True
        Me.LabelCompanyDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelCompanyDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelCompanyDesc.Location = New System.Drawing.Point(87, 471)
        Me.LabelCompanyDesc.Name = "LabelCompanyDesc"
        Me.LabelCompanyDesc.Size = New System.Drawing.Size(66, 17)
        Me.LabelCompanyDesc.TabIndex = 58
        Me.LabelCompanyDesc.Text = "Company:"
        '
        'LabelCommand
        '
        Me.LabelCommand.BackColor = System.Drawing.Color.Transparent
        Me.LabelCommand.ForeColor = System.Drawing.Color.Black
        Me.LabelCommand.Location = New System.Drawing.Point(186, 551)
        Me.LabelCommand.Name = "LabelCommand"
        Me.LabelCommand.Size = New System.Drawing.Size(398, 36)
        Me.LabelCommand.TabIndex = 57
        '
        'LabelFileVersion
        '
        Me.LabelFileVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelFileVersion.ForeColor = System.Drawing.Color.Black
        Me.LabelFileVersion.Location = New System.Drawing.Point(186, 531)
        Me.LabelFileVersion.Name = "LabelFileVersion"
        Me.LabelFileVersion.Size = New System.Drawing.Size(398, 17)
        Me.LabelFileVersion.TabIndex = 56
        '
        'LabelDescription
        '
        Me.LabelDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelDescription.ForeColor = System.Drawing.Color.Black
        Me.LabelDescription.Location = New System.Drawing.Point(186, 511)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(398, 17)
        Me.LabelDescription.TabIndex = 55
        '
        'LabelCompany
        '
        Me.LabelCompany.BackColor = System.Drawing.Color.Transparent
        Me.LabelCompany.ForeColor = System.Drawing.Color.Black
        Me.LabelCompany.Location = New System.Drawing.Point(186, 471)
        Me.LabelCompany.Name = "LabelCompany"
        Me.LabelCompany.Size = New System.Drawing.Size(398, 17)
        Me.LabelCompany.TabIndex = 54
        '
        'LabelProductNameDesc
        '
        Me.LabelProductNameDesc.AutoSize = True
        Me.LabelProductNameDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelProductNameDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelProductNameDesc.Location = New System.Drawing.Point(87, 491)
        Me.LabelProductNameDesc.Name = "LabelProductNameDesc"
        Me.LabelProductNameDesc.Size = New System.Drawing.Size(56, 17)
        Me.LabelProductNameDesc.TabIndex = 75
        Me.LabelProductNameDesc.Text = "Product:"
        '
        'LabelProductName
        '
        Me.LabelProductName.BackColor = System.Drawing.Color.Transparent
        Me.LabelProductName.ForeColor = System.Drawing.Color.Black
        Me.LabelProductName.Location = New System.Drawing.Point(186, 491)
        Me.LabelProductName.Name = "LabelProductName"
        Me.LabelProductName.Size = New System.Drawing.Size(398, 17)
        Me.LabelProductName.TabIndex = 74
        '
        'LabelArgumentsDesc
        '
        Me.LabelArgumentsDesc.AutoSize = True
        Me.LabelArgumentsDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelArgumentsDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelArgumentsDesc.Location = New System.Drawing.Point(87, 591)
        Me.LabelArgumentsDesc.Name = "LabelArgumentsDesc"
        Me.LabelArgumentsDesc.Size = New System.Drawing.Size(74, 17)
        Me.LabelArgumentsDesc.TabIndex = 76
        Me.LabelArgumentsDesc.Text = "Arguments:"
        Me.LabelArgumentsDesc.Visible = False
        '
        'LabelArguments
        '
        Me.LabelArguments.BackColor = System.Drawing.Color.Transparent
        Me.LabelArguments.ForeColor = System.Drawing.Color.Black
        Me.LabelArguments.Location = New System.Drawing.Point(186, 591)
        Me.LabelArguments.Name = "LabelArguments"
        Me.LabelArguments.Size = New System.Drawing.Size(398, 17)
        Me.LabelArguments.TabIndex = 77
        Me.LabelArguments.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewStartup)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 122)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 310)
        Me.PanelWait.TabIndex = 78
        '
        'ListViewStartup
        '
        Me.ListViewStartup.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewStartup.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ItemName, Me.FileName, Me.Type, Me.Status, Me.DisplayCommand, Me.DisplayFilePath})
        Me.ListViewStartup.ContextMenuStrip = Me.ContextMenuStripStartup
        Me.ListViewStartup.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewStartup.ForeColor = System.Drawing.Color.Black
        Me.ListViewStartup.FullRowSelect = True
        Me.ListViewStartup.LabelWrap = False
        Me.ListViewStartup.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewStartup.MultiSelect = False
        Me.ListViewStartup.Name = "ListViewStartup"
        Me.ListViewStartup.Size = New System.Drawing.Size(640, 310)
        Me.ListViewStartup.SmallImageList = Me.StartupImageList
        Me.ListViewStartup.TabIndex = 78
        Me.ListViewStartup.UseCompatibleStateImageBehavior = False
        Me.ListViewStartup.View = System.Windows.Forms.View.Details
        Me.ListViewStartup.Visible = False
        '
        'ItemName
        '
        Me.ItemName.Text = "Item Name"
        Me.ItemName.Width = 200
        '
        'FileName
        '
        Me.FileName.Text = "File Name"
        Me.FileName.Width = 200
        '
        'Type
        '
        Me.Type.Text = "Location"
        Me.Type.Width = 150
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 65
        '
        'DisplayCommand
        '
        Me.DisplayCommand.Text = ""
        Me.DisplayCommand.Width = 0
        '
        'DisplayFilePath
        '
        Me.DisplayFilePath.Text = ""
        Me.DisplayFilePath.Width = 0
        '
        'LabelWait
        '
        Me.LabelWait.AllowDrop = True
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 142)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 77
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'StartupPrograms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelArguments)
        Me.Controls.Add(Me.LabelArgumentsDesc)
        Me.Controls.Add(Me.LabelProductNameDesc)
        Me.Controls.Add(Me.LabelProductName)
        Me.Controls.Add(Me.LabelCommandDesc)
        Me.Controls.Add(Me.LabelFileVersionDesc)
        Me.Controls.Add(Me.LabelDescriptionDesc)
        Me.Controls.Add(Me.LabelCompanyDesc)
        Me.Controls.Add(Me.LabelCommand)
        Me.Controls.Add(Me.LabelFileVersion)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.LabelCompany)
        Me.Controls.Add(Me.LabelDetails)
        Me.Controls.Add(Me.LabelSeparator2)
        Me.Controls.Add(Me.LabelStartupDescription)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "StartupPrograms"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripStartup.ResumeLayout(False)
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelStartupDescription As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelDetails As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Private WithEvents LabelCommandDesc As System.Windows.Forms.Label
    Private WithEvents LabelFileVersionDesc As System.Windows.Forms.Label
    Private WithEvents LabelDescriptionDesc As System.Windows.Forms.Label
    Private WithEvents LabelCompanyDesc As System.Windows.Forms.Label
    Private WithEvents LabelCommand As System.Windows.Forms.Label
    Private WithEvents LabelFileVersion As System.Windows.Forms.Label
    Private WithEvents LabelDescription As System.Windows.Forms.Label
    Private WithEvents LabelCompany As System.Windows.Forms.Label
    Private WithEvents LabelProductNameDesc As System.Windows.Forms.Label
    Private WithEvents LabelProductName As System.Windows.Forms.Label
    Private WithEvents StartupImageList As System.Windows.Forms.ImageList
    Private WithEvents LabelArgumentsDesc As System.Windows.Forms.Label
    Private WithEvents LabelArguments As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripStartup As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuAddNewCurrentUserStartupProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuDeleteStartupProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ContextMenuRefreshDisplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuAddNewAllUsersStartupProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Private WithEvents ListViewStartup As System.Windows.Forms.ListView
    Private WithEvents ItemName As System.Windows.Forms.ColumnHeader
    Private WithEvents FileName As System.Windows.Forms.ColumnHeader
    Private WithEvents Type As System.Windows.Forms.ColumnHeader
    Private WithEvents Status As System.Windows.Forms.ColumnHeader
    Private WithEvents DisplayCommand As System.Windows.Forms.ColumnHeader
    Private WithEvents DisplayFilePath As System.Windows.Forms.ColumnHeader

End Class
