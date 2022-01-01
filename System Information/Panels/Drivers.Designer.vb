<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Drivers
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Drivers))
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.LabelFolders = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.ContextMenuStripDrivers = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuPause = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuContinue = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStop = New System.Windows.Forms.ToolStripMenuItem
        Me.ImageListDrivers = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewDrivers = New System.Windows.Forms.ListView
        Me.Driver = New System.Windows.Forms.ColumnHeader
        Me.DriverName = New System.Windows.Forms.ColumnHeader
        Me.Status = New System.Windows.Forms.ColumnHeader
        Me.DriverType = New System.Windows.Forms.ColumnHeader
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripDrivers.SuspendLayout()
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
        Me.LabelTitle.Size = New System.Drawing.Size(75, 25)
        Me.LabelTitle.TabIndex = 3
        Me.LabelTitle.Text = "Drivers"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Drivers_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 22)
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
        Me.LabelFolders.Size = New System.Drawing.Size(115, 17)
        Me.LabelFolders.TabIndex = 2
        Me.LabelFolders.Text = "Hardware Drivers"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 1
        '
        'ContextMenuStripDrivers
        '
        Me.ContextMenuStripDrivers.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuStart, Me.ContextMenuPause, Me.ContextMenuContinue, Me.ContextMenuStop})
        Me.ContextMenuStripDrivers.Name = "ContextMenuStripDrivers"
        Me.ContextMenuStripDrivers.Size = New System.Drawing.Size(124, 92)
        '
        'ContextMenuStart
        '
        Me.ContextMenuStart.Name = "ContextMenuStart"
        Me.ContextMenuStart.Size = New System.Drawing.Size(123, 22)
        Me.ContextMenuStart.Text = "Start"
        '
        'ContextMenuPause
        '
        Me.ContextMenuPause.Name = "ContextMenuPause"
        Me.ContextMenuPause.Size = New System.Drawing.Size(123, 22)
        Me.ContextMenuPause.Text = "Pause"
        '
        'ContextMenuContinue
        '
        Me.ContextMenuContinue.Name = "ContextMenuContinue"
        Me.ContextMenuContinue.Size = New System.Drawing.Size(123, 22)
        Me.ContextMenuContinue.Text = "Continue"
        '
        'ContextMenuStop
        '
        Me.ContextMenuStop.Name = "ContextMenuStop"
        Me.ContextMenuStop.Size = New System.Drawing.Size(123, 22)
        Me.ContextMenuStop.Text = "Stop"
        '
        'ImageListDrivers
        '
        Me.ImageListDrivers.ImageStream = CType(resources.GetObject("ImageListDrivers.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListDrivers.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListDrivers.Images.SetKeyName(0, "Drivers_16x16.png")
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewDrivers)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 122)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 495)
        Me.PanelWait.TabIndex = 33
        '
        'ListViewDrivers
        '
        Me.ListViewDrivers.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Driver, Me.DriverName, Me.Status, Me.DriverType})
        Me.ListViewDrivers.ContextMenuStrip = Me.ContextMenuStripDrivers
        Me.ListViewDrivers.FullRowSelect = True
        Me.ListViewDrivers.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewDrivers.MultiSelect = False
        Me.ListViewDrivers.Name = "ListViewDrivers"
        Me.ListViewDrivers.Size = New System.Drawing.Size(640, 495)
        Me.ListViewDrivers.SmallImageList = Me.ImageListDrivers
        Me.ListViewDrivers.StateImageList = Me.ImageListDrivers
        Me.ListViewDrivers.TabIndex = 0
        Me.ListViewDrivers.UseCompatibleStateImageBehavior = False
        Me.ListViewDrivers.View = System.Windows.Forms.View.Details
        Me.ListViewDrivers.Visible = False
        '
        'Driver
        '
        Me.Driver.Text = "Driver"
        Me.Driver.Width = 260
        '
        'DriverName
        '
        Me.DriverName.Text = "Name"
        Me.DriverName.Width = 135
        '
        'Status
        '
        Me.Status.Text = "Status"
        Me.Status.Width = 100
        '
        'DriverType
        '
        Me.DriverType.Text = "Driver Type"
        Me.DriverType.Width = 120
        '
        'LabelWait
        '
        Me.LabelWait.AllowDrop = True
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 234)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 1
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AutoSize = True
        Me.ButtonCancel.Location = New System.Drawing.Point(652, 66)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Drivers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Drivers"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripDrivers.ResumeLayout(False)
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelFolders As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripDrivers As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuContinue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageListDrivers As System.Windows.Forms.ImageList
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Friend WithEvents ListViewDrivers As System.Windows.Forms.ListView
    Friend WithEvents Driver As System.Windows.Forms.ColumnHeader
    Friend WithEvents DriverName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Status As System.Windows.Forms.ColumnHeader
    Friend WithEvents DriverType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button

End Class
