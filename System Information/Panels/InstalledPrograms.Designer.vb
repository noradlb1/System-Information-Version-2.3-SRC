<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InstalledPrograms
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
        Me.ContextMenuStripInstalledPrograms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuUninstall = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.SmallImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelInstalledProgramsDescription = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelDetails = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.LabelHelpTelephoneDesc = New System.Windows.Forms.Label
        Me.LabelHelpLinkDesc = New System.Windows.Forms.Label
        Me.LabelInstallDateDesc = New System.Windows.Forms.Label
        Me.LabelHelpTelephone = New System.Windows.Forms.Label
        Me.LabelInstallDate = New System.Windows.Forms.Label
        Me.LabelEstSizeDesc = New System.Windows.Forms.Label
        Me.LabelEstimatedSize = New System.Windows.Forms.Label
        Me.LabelNumberPrograms = New System.Windows.Forms.Label
        Me.PictureBoxProgram = New System.Windows.Forms.PictureBox
        Me.LabelDisplayVersion = New System.Windows.Forms.Label
        Me.LabelDisplayVersionDesc = New System.Windows.Forms.Label
        Me.LabelDisplayName = New System.Windows.Forms.Label
        Me.LargeImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.LinkLabelHelpLink = New System.Windows.Forms.LinkLabel
        Me.LabelClick = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewPrograms = New System.Windows.Forms.ListView
        Me.ColumnHeaderDisplayName = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderPublisher = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderDisplayVersion = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderHelpLink = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderHelpTelephone = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderInstallDate = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderEstimatedSize = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderIconIndex = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeaderUninstallString = New System.Windows.Forms.ColumnHeader
        Me.LabelWait = New System.Windows.Forms.Label
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripInstalledPrograms.SuspendLayout()
        CType(Me.PictureBoxProgram, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LabelTitle.Size = New System.Drawing.Size(179, 25)
        Me.LabelTitle.TabIndex = 2
        Me.LabelTitle.Text = "Installed Programs"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Installed_Programs_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'ContextMenuStripInstalledPrograms
        '
        Me.ContextMenuStripInstalledPrograms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuUninstall, Me.ContextMenuRefresh})
        Me.ContextMenuStripInstalledPrograms.Name = "ContextMenuStripInstalledPrograms"
        Me.ContextMenuStripInstalledPrograms.Size = New System.Drawing.Size(121, 48)
        '
        'ContextMenuUninstall
        '
        Me.ContextMenuUninstall.Name = "ContextMenuUninstall"
        Me.ContextMenuUninstall.Size = New System.Drawing.Size(120, 22)
        Me.ContextMenuUninstall.Text = "Uninstall"
        '
        'ContextMenuRefresh
        '
        Me.ContextMenuRefresh.Name = "ContextMenuRefresh"
        Me.ContextMenuRefresh.Size = New System.Drawing.Size(120, 22)
        Me.ContextMenuRefresh.Text = "Refresh"
        '
        'SmallImageList
        '
        Me.SmallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.SmallImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.SmallImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'LabelInstalledProgramsDescription
        '
        Me.LabelInstalledProgramsDescription.AutoSize = True
        Me.LabelInstalledProgramsDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelInstalledProgramsDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInstalledProgramsDescription.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelInstalledProgramsDescription.Location = New System.Drawing.Point(87, 76)
        Me.LabelInstalledProgramsDescription.Name = "LabelInstalledProgramsDescription"
        Me.LabelInstalledProgramsDescription.Size = New System.Drawing.Size(377, 17)
        Me.LabelInstalledProgramsDescription.TabIndex = 1
        Me.LabelInstalledProgramsDescription.Text = "Applications and other software installed on this computer."
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 0
        '
        'LabelDetails
        '
        Me.LabelDetails.AutoSize = True
        Me.LabelDetails.BackColor = System.Drawing.Color.Transparent
        Me.LabelDetails.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDetails.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelDetails.Location = New System.Drawing.Point(84, 506)
        Me.LabelDetails.Name = "LabelDetails"
        Me.LabelDetails.Size = New System.Drawing.Size(51, 17)
        Me.LabelDetails.TabIndex = 4
        Me.LabelDetails.Text = "Details"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(84, 528)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 6
        '
        'LabelHelpTelephoneDesc
        '
        Me.LabelHelpTelephoneDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelHelpTelephoneDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelHelpTelephoneDesc.Location = New System.Drawing.Point(145, 602)
        Me.LabelHelpTelephoneDesc.Name = "LabelHelpTelephoneDesc"
        Me.LabelHelpTelephoneDesc.Size = New System.Drawing.Size(76, 15)
        Me.LabelHelpTelephoneDesc.TabIndex = 10
        Me.LabelHelpTelephoneDesc.Text = "Help Phone:"
        Me.LabelHelpTelephoneDesc.Visible = False
        '
        'LabelHelpLinkDesc
        '
        Me.LabelHelpLinkDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelHelpLinkDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelHelpLinkDesc.Location = New System.Drawing.Point(145, 582)
        Me.LabelHelpLinkDesc.Name = "LabelHelpLinkDesc"
        Me.LabelHelpLinkDesc.Size = New System.Drawing.Size(76, 15)
        Me.LabelHelpLinkDesc.TabIndex = 9
        Me.LabelHelpLinkDesc.Text = "Help Link:"
        Me.LabelHelpLinkDesc.Visible = False
        '
        'LabelInstallDateDesc
        '
        Me.LabelInstallDateDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelInstallDateDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelInstallDateDesc.Location = New System.Drawing.Point(145, 562)
        Me.LabelInstallDateDesc.Name = "LabelInstallDateDesc"
        Me.LabelInstallDateDesc.Size = New System.Drawing.Size(76, 15)
        Me.LabelInstallDateDesc.TabIndex = 8
        Me.LabelInstallDateDesc.Text = "Install Date:"
        Me.LabelInstallDateDesc.Visible = False
        '
        'LabelHelpTelephone
        '
        Me.LabelHelpTelephone.BackColor = System.Drawing.Color.Transparent
        Me.LabelHelpTelephone.ForeColor = System.Drawing.Color.Black
        Me.LabelHelpTelephone.Location = New System.Drawing.Point(225, 602)
        Me.LabelHelpTelephone.Name = "LabelHelpTelephone"
        Me.LabelHelpTelephone.Size = New System.Drawing.Size(343, 15)
        Me.LabelHelpTelephone.TabIndex = 13
        Me.LabelHelpTelephone.Visible = False
        '
        'LabelInstallDate
        '
        Me.LabelInstallDate.BackColor = System.Drawing.Color.Transparent
        Me.LabelInstallDate.ForeColor = System.Drawing.Color.Black
        Me.LabelInstallDate.Location = New System.Drawing.Point(225, 562)
        Me.LabelInstallDate.Name = "LabelInstallDate"
        Me.LabelInstallDate.Size = New System.Drawing.Size(128, 15)
        Me.LabelInstallDate.TabIndex = 11
        Me.LabelInstallDate.Visible = False
        '
        'LabelEstSizeDesc
        '
        Me.LabelEstSizeDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelEstSizeDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelEstSizeDesc.Location = New System.Drawing.Point(357, 562)
        Me.LabelEstSizeDesc.Name = "LabelEstSizeDesc"
        Me.LabelEstSizeDesc.Size = New System.Drawing.Size(92, 15)
        Me.LabelEstSizeDesc.TabIndex = 14
        Me.LabelEstSizeDesc.Text = "Estimated Size:"
        Me.LabelEstSizeDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LabelEstSizeDesc.Visible = False
        '
        'LabelEstimatedSize
        '
        Me.LabelEstimatedSize.BackColor = System.Drawing.Color.Transparent
        Me.LabelEstimatedSize.ForeColor = System.Drawing.Color.Black
        Me.LabelEstimatedSize.Location = New System.Drawing.Point(453, 562)
        Me.LabelEstimatedSize.Name = "LabelEstimatedSize"
        Me.LabelEstimatedSize.Size = New System.Drawing.Size(115, 15)
        Me.LabelEstimatedSize.TabIndex = 17
        Me.LabelEstimatedSize.Visible = False
        '
        'LabelNumberPrograms
        '
        Me.LabelNumberPrograms.BackColor = System.Drawing.Color.Transparent
        Me.LabelNumberPrograms.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumberPrograms.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelNumberPrograms.Location = New System.Drawing.Point(622, 76)
        Me.LabelNumberPrograms.Name = "LabelNumberPrograms"
        Me.LabelNumberPrograms.Size = New System.Drawing.Size(104, 17)
        Me.LabelNumberPrograms.TabIndex = 3
        Me.LabelNumberPrograms.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PictureBoxProgram
        '
        Me.PictureBoxProgram.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxProgram.Location = New System.Drawing.Point(85, 542)
        Me.PictureBoxProgram.Name = "PictureBoxProgram"
        Me.PictureBoxProgram.Size = New System.Drawing.Size(32, 32)
        Me.PictureBoxProgram.TabIndex = 79
        Me.PictureBoxProgram.TabStop = False
        '
        'LabelDisplayVersion
        '
        Me.LabelDisplayVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelDisplayVersion.ForeColor = System.Drawing.Color.Black
        Me.LabelDisplayVersion.Location = New System.Drawing.Point(453, 542)
        Me.LabelDisplayVersion.Name = "LabelDisplayVersion"
        Me.LabelDisplayVersion.Size = New System.Drawing.Size(115, 15)
        Me.LabelDisplayVersion.TabIndex = 16
        Me.LabelDisplayVersion.Visible = False
        '
        'LabelDisplayVersionDesc
        '
        Me.LabelDisplayVersionDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelDisplayVersionDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelDisplayVersionDesc.Location = New System.Drawing.Point(397, 542)
        Me.LabelDisplayVersionDesc.Name = "LabelDisplayVersionDesc"
        Me.LabelDisplayVersionDesc.Size = New System.Drawing.Size(52, 15)
        Me.LabelDisplayVersionDesc.TabIndex = 15
        Me.LabelDisplayVersionDesc.Text = "Version:"
        Me.LabelDisplayVersionDesc.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LabelDisplayVersionDesc.Visible = False
        '
        'LabelDisplayName
        '
        Me.LabelDisplayName.BackColor = System.Drawing.Color.Transparent
        Me.LabelDisplayName.ForeColor = System.Drawing.Color.Black
        Me.LabelDisplayName.Location = New System.Drawing.Point(145, 542)
        Me.LabelDisplayName.Name = "LabelDisplayName"
        Me.LabelDisplayName.Size = New System.Drawing.Size(248, 15)
        Me.LabelDisplayName.TabIndex = 7
        '
        'LargeImageList
        '
        Me.LargeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.LargeImageList.ImageSize = New System.Drawing.Size(32, 32)
        Me.LargeImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'LinkLabelHelpLink
        '
        Me.LinkLabelHelpLink.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabelHelpLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabelHelpLink.LinkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.LinkLabelHelpLink.Location = New System.Drawing.Point(225, 582)
        Me.LinkLabelHelpLink.Name = "LinkLabelHelpLink"
        Me.LinkLabelHelpLink.Size = New System.Drawing.Size(343, 15)
        Me.LinkLabelHelpLink.TabIndex = 12
        '
        'LabelClick
        '
        Me.LabelClick.AutoSize = True
        Me.LabelClick.BackColor = System.Drawing.Color.Transparent
        Me.LabelClick.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelClick.Location = New System.Drawing.Point(141, 506)
        Me.LabelClick.Name = "LabelClick"
        Me.LabelClick.Size = New System.Drawing.Size(251, 17)
        Me.LabelClick.TabIndex = 5
        Me.LabelClick.Text = "(Click on item in list above to view details)"
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewPrograms)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 115)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 379)
        Me.PanelWait.TabIndex = 0
        '
        'ListViewPrograms
        '
        Me.ListViewPrograms.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewPrograms.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeaderDisplayName, Me.ColumnHeaderPublisher, Me.ColumnHeaderDisplayVersion, Me.ColumnHeaderHelpLink, Me.ColumnHeaderHelpTelephone, Me.ColumnHeaderInstallDate, Me.ColumnHeaderEstimatedSize, Me.ColumnHeaderIconIndex, Me.ColumnHeaderUninstallString})
        Me.ListViewPrograms.ContextMenuStrip = Me.ContextMenuStripInstalledPrograms
        Me.ListViewPrograms.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewPrograms.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ListViewPrograms.FullRowSelect = True
        Me.ListViewPrograms.LabelWrap = False
        Me.ListViewPrograms.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewPrograms.MultiSelect = False
        Me.ListViewPrograms.Name = "ListViewPrograms"
        Me.ListViewPrograms.Size = New System.Drawing.Size(640, 379)
        Me.ListViewPrograms.SmallImageList = Me.SmallImageList
        Me.ListViewPrograms.TabIndex = 0
        Me.ListViewPrograms.UseCompatibleStateImageBehavior = False
        Me.ListViewPrograms.View = System.Windows.Forms.View.Details
        Me.ListViewPrograms.Visible = False
        '
        'ColumnHeaderDisplayName
        '
        Me.ColumnHeaderDisplayName.Text = "Name"
        Me.ColumnHeaderDisplayName.Width = 280
        '
        'ColumnHeaderPublisher
        '
        Me.ColumnHeaderPublisher.Text = "Publisher"
        Me.ColumnHeaderPublisher.Width = 177
        '
        'ColumnHeaderDisplayVersion
        '
        Me.ColumnHeaderDisplayVersion.Text = "Version"
        Me.ColumnHeaderDisplayVersion.Width = 0
        '
        'ColumnHeaderHelpLink
        '
        Me.ColumnHeaderHelpLink.Text = "HelpLink"
        Me.ColumnHeaderHelpLink.Width = 0
        '
        'ColumnHeaderHelpTelephone
        '
        Me.ColumnHeaderHelpTelephone.Text = "HelpTelephone"
        Me.ColumnHeaderHelpTelephone.Width = 0
        '
        'ColumnHeaderInstallDate
        '
        Me.ColumnHeaderInstallDate.Text = "Date Installed"
        Me.ColumnHeaderInstallDate.Width = 160
        '
        'ColumnHeaderEstimatedSize
        '
        Me.ColumnHeaderEstimatedSize.Text = "EstimatedSize"
        Me.ColumnHeaderEstimatedSize.Width = 0
        '
        'ColumnHeaderIconIndex
        '
        Me.ColumnHeaderIconIndex.Text = "IconNumber"
        Me.ColumnHeaderIconIndex.Width = 0
        '
        'ColumnHeaderUninstallString
        '
        Me.ColumnHeaderUninstallString.Width = 0
        '
        'LabelWait
        '
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 176)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 1
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'InstalledPrograms
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelClick)
        Me.Controls.Add(Me.LinkLabelHelpLink)
        Me.Controls.Add(Me.LabelDisplayName)
        Me.Controls.Add(Me.LabelDisplayVersion)
        Me.Controls.Add(Me.LabelDisplayVersionDesc)
        Me.Controls.Add(Me.PictureBoxProgram)
        Me.Controls.Add(Me.LabelNumberPrograms)
        Me.Controls.Add(Me.LabelEstimatedSize)
        Me.Controls.Add(Me.LabelEstSizeDesc)
        Me.Controls.Add(Me.LabelHelpTelephoneDesc)
        Me.Controls.Add(Me.LabelHelpLinkDesc)
        Me.Controls.Add(Me.LabelInstallDateDesc)
        Me.Controls.Add(Me.LabelHelpTelephone)
        Me.Controls.Add(Me.LabelInstallDate)
        Me.Controls.Add(Me.LabelDetails)
        Me.Controls.Add(Me.LabelSeparator2)
        Me.Controls.Add(Me.LabelInstalledProgramsDescription)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "InstalledPrograms"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripInstalledPrograms.ResumeLayout(False)
        CType(Me.PictureBoxProgram, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelInstalledProgramsDescription As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelDetails As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Private WithEvents LabelHelpTelephoneDesc As System.Windows.Forms.Label
    Private WithEvents LabelHelpLinkDesc As System.Windows.Forms.Label
    Private WithEvents LabelInstallDateDesc As System.Windows.Forms.Label
    Private WithEvents LabelHelpTelephone As System.Windows.Forms.Label
    Private WithEvents LabelInstallDate As System.Windows.Forms.Label
    Private WithEvents SmallImageList As System.Windows.Forms.ImageList
    Private WithEvents LabelEstSizeDesc As System.Windows.Forms.Label
    Private WithEvents LabelEstimatedSize As System.Windows.Forms.Label
    Private WithEvents LabelNumberPrograms As System.Windows.Forms.Label
    Private WithEvents PictureBoxProgram As System.Windows.Forms.PictureBox
    Private WithEvents LabelDisplayVersion As System.Windows.Forms.Label
    Private WithEvents LabelDisplayVersionDesc As System.Windows.Forms.Label
    Private WithEvents LabelDisplayName As System.Windows.Forms.Label
    Private WithEvents LargeImageList As System.Windows.Forms.ImageList
    Friend WithEvents LinkLabelHelpLink As System.Windows.Forms.LinkLabel
    Friend WithEvents LabelClick As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripInstalledPrograms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuUninstall As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Private WithEvents ListViewPrograms As System.Windows.Forms.ListView
    Private WithEvents ColumnHeaderDisplayName As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeaderPublisher As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeaderDisplayVersion As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeaderHelpLink As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeaderHelpTelephone As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeaderInstallDate As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeaderEstimatedSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderIconIndex As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeaderUninstallString As System.Windows.Forms.ColumnHeader

End Class
