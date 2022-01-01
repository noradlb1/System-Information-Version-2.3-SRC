<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Shares
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Shares))
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.LabelFolders = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.ContextMenuStripShares = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuRefreshDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageListShares = New System.Windows.Forms.ImageList(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ButtonNewShare = New System.Windows.Forms.Button
        Me.ButtonRefresh = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.TextBoxShareName = New System.Windows.Forms.TextBox
        Me.TextBoxDescription = New System.Windows.Forms.TextBox
        Me.NumericUpDownShares = New System.Windows.Forms.NumericUpDown
        Me.LabelName = New System.Windows.Forms.Label
        Me.LabelDescription = New System.Windows.Forms.Label
        Me.LabelMaximumAllowed = New System.Windows.Forms.Label
        Me.LabelCreateDeleteShares = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewShares = New System.Windows.Forms.ListView
        Me.Share = New System.Windows.Forms.ColumnHeader
        Me.ShareType = New System.Windows.Forms.ColumnHeader
        Me.Description = New System.Windows.Forms.ColumnHeader
        Me.SharePath = New System.Windows.Forms.ColumnHeader
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripShares.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.NumericUpDownShares, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LabelTitle.Size = New System.Drawing.Size(70, 25)
        Me.LabelTitle.TabIndex = 0
        Me.LabelTitle.Text = "Shares"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Shares_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(16, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelFolders
        '
        Me.LabelFolders.AutoSize = True
        Me.LabelFolders.BackColor = System.Drawing.Color.Transparent
        Me.LabelFolders.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelFolders.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelFolders.Location = New System.Drawing.Point(87, 76)
        Me.LabelFolders.Name = "LabelFolders"
        Me.LabelFolders.Size = New System.Drawing.Size(99, 17)
        Me.LabelFolders.TabIndex = 12
        Me.LabelFolders.Text = "Shared Folders"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 11
        '
        'ContextMenuStripShares
        '
        Me.ContextMenuStripShares.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuDelete, Me.ContextMenuRefreshDisplay})
        Me.ContextMenuStripShares.Name = "ContextMenuStripShares"
        Me.ContextMenuStripShares.Size = New System.Drawing.Size(155, 48)
        '
        'ContextMenuDelete
        '
        Me.ContextMenuDelete.Name = "ContextMenuDelete"
        Me.ContextMenuDelete.Size = New System.Drawing.Size(154, 22)
        Me.ContextMenuDelete.Text = "Delete Share"
        '
        'ContextMenuRefreshDisplay
        '
        Me.ContextMenuRefreshDisplay.Name = "ContextMenuRefreshDisplay"
        Me.ContextMenuRefreshDisplay.Size = New System.Drawing.Size(154, 22)
        Me.ContextMenuRefreshDisplay.Text = "Refresh Display"
        '
        'ImageListShares
        '
        Me.ImageListShares.ImageStream = CType(resources.GetObject("ImageListShares.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListShares.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListShares.Images.SetKeyName(0, "Drive_16x16.png")
        Me.ImageListShares.Images.SetKeyName(1, "Printer_16x16.png")
        Me.ImageListShares.Images.SetKeyName(2, "Device_16x16.png")
        Me.ImageListShares.Images.SetKeyName(3, "SharedIPC_16x16.png")
        Me.ImageListShares.Images.SetKeyName(4, "Unknown_16x16.png")
        '
        'ButtonNewShare
        '
        Me.ButtonNewShare.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonNewShare.Location = New System.Drawing.Point(6, 3)
        Me.ButtonNewShare.Name = "ButtonNewShare"
        Me.ButtonNewShare.Size = New System.Drawing.Size(85, 26)
        Me.ButtonNewShare.TabIndex = 0
        Me.ButtonNewShare.Text = "&New Share"
        Me.ButtonNewShare.UseVisualStyleBackColor = True
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonRefresh.BackColor = System.Drawing.Color.Transparent
        Me.ButtonRefresh.Location = New System.Drawing.Point(101, 3)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(85, 26)
        Me.ButtonRefresh.TabIndex = 1
        Me.ButtonRefresh.Text = "&Refresh"
        Me.ButtonRefresh.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonNewShare, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ButtonRefresh, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(540, 590)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(189, 32)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'TextBoxShareName
        '
        Me.TextBoxShareName.Location = New System.Drawing.Point(92, 550)
        Me.TextBoxShareName.Name = "TextBoxShareName"
        Me.TextBoxShareName.Size = New System.Drawing.Size(259, 25)
        Me.TextBoxShareName.TabIndex = 2
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.Location = New System.Drawing.Point(357, 550)
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.Size = New System.Drawing.Size(259, 25)
        Me.TextBoxDescription.TabIndex = 3
        '
        'NumericUpDownShares
        '
        Me.NumericUpDownShares.Location = New System.Drawing.Point(622, 550)
        Me.NumericUpDownShares.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDownShares.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumericUpDownShares.Name = "NumericUpDownShares"
        Me.NumericUpDownShares.Size = New System.Drawing.Size(107, 25)
        Me.NumericUpDownShares.TabIndex = 4
        Me.NumericUpDownShares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.NumericUpDownShares.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'LabelName
        '
        Me.LabelName.AutoSize = True
        Me.LabelName.BackColor = System.Drawing.Color.Transparent
        Me.LabelName.Location = New System.Drawing.Point(89, 527)
        Me.LabelName.Name = "LabelName"
        Me.LabelName.Size = New System.Drawing.Size(110, 17)
        Me.LabelName.TabIndex = 6
        Me.LabelName.Text = "New Share Name"
        '
        'LabelDescription
        '
        Me.LabelDescription.AutoSize = True
        Me.LabelDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelDescription.Location = New System.Drawing.Point(354, 527)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(141, 17)
        Me.LabelDescription.TabIndex = 7
        Me.LabelDescription.Text = "New Share Description"
        '
        'LabelMaximumAllowed
        '
        Me.LabelMaximumAllowed.AutoSize = True
        Me.LabelMaximumAllowed.BackColor = System.Drawing.Color.Transparent
        Me.LabelMaximumAllowed.Location = New System.Drawing.Point(619, 527)
        Me.LabelMaximumAllowed.Name = "LabelMaximumAllowed"
        Me.LabelMaximumAllowed.Size = New System.Drawing.Size(115, 17)
        Me.LabelMaximumAllowed.TabIndex = 8
        Me.LabelMaximumAllowed.Text = "Maximum Allowed"
        '
        'LabelCreateDeleteShares
        '
        Me.LabelCreateDeleteShares.AutoSize = True
        Me.LabelCreateDeleteShares.BackColor = System.Drawing.Color.Transparent
        Me.LabelCreateDeleteShares.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCreateDeleteShares.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelCreateDeleteShares.Location = New System.Drawing.Point(87, 491)
        Me.LabelCreateDeleteShares.Name = "LabelCreateDeleteShares"
        Me.LabelCreateDeleteShares.Size = New System.Drawing.Size(449, 17)
        Me.LabelCreateDeleteShares.TabIndex = 10
        Me.LabelCreateDeleteShares.Text = "Create New Share (Fill in optional information before pressing button.)"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(87, 513)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 9
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewShares)
        Me.PanelWait.Controls.Add(Me.Label1)
        Me.PanelWait.Location = New System.Drawing.Point(87, 115)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 360)
        Me.PanelWait.TabIndex = 46
        '
        'ListViewShares
        '
        Me.ListViewShares.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Share, Me.ShareType, Me.Description, Me.SharePath})
        Me.ListViewShares.ContextMenuStrip = Me.ContextMenuStripShares
        Me.ListViewShares.FullRowSelect = True
        Me.ListViewShares.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewShares.Location = New System.Drawing.Point(-2, -1)
        Me.ListViewShares.MultiSelect = False
        Me.ListViewShares.Name = "ListViewShares"
        Me.ListViewShares.Size = New System.Drawing.Size(642, 360)
        Me.ListViewShares.SmallImageList = Me.ImageListShares
        Me.ListViewShares.TabIndex = 0
        Me.ListViewShares.UseCompatibleStateImageBehavior = False
        Me.ListViewShares.View = System.Windows.Forms.View.Details
        Me.ListViewShares.Visible = False
        '
        'Share
        '
        Me.Share.Text = "Share Name"
        Me.Share.Width = 200
        '
        'ShareType
        '
        Me.ShareType.Text = "Share Type"
        Me.ShareType.Width = 90
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 150
        '
        'SharePath
        '
        Me.SharePath.Text = "Share Path"
        Me.SharePath.Width = 400
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Loading Data, Please Wait..."
        '
        'Shares
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelCreateDeleteShares)
        Me.Controls.Add(Me.LabelSeparator2)
        Me.Controls.Add(Me.LabelMaximumAllowed)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.LabelName)
        Me.Controls.Add(Me.NumericUpDownShares)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.TextBoxShareName)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Shares"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripShares.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.NumericUpDownShares, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelFolders As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents ButtonNewShare As System.Windows.Forms.Button
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ImageListShares As System.Windows.Forms.ImageList
    Friend WithEvents TextBoxShareName As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Friend WithEvents NumericUpDownShares As System.Windows.Forms.NumericUpDown
    Friend WithEvents LabelName As System.Windows.Forms.Label
    Friend WithEvents LabelDescription As System.Windows.Forms.Label
    Friend WithEvents LabelMaximumAllowed As System.Windows.Forms.Label
    Private WithEvents LabelCreateDeleteShares As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripShares As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuRefreshDisplay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListViewShares As System.Windows.Forms.ListView
    Friend WithEvents Share As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShareType As System.Windows.Forms.ColumnHeader
    Friend WithEvents Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents SharePath As System.Windows.Forms.ColumnHeader

End Class
