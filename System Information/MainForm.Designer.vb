<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class MainForm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("BIOS", 2, 2)
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("CPU", 3, 3)
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Drives and Volumes", 36, 36)
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Keyboard", 26, 26)
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pointing Device", 27, 27)
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Input Devices", 25, 25, New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5})
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Network", 5, 5)
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ports", 32, 32)
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sound", 6, 6)
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("USB Devices", 31, 31)
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Video", 7, 7)
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Computer", 1, 1, New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode6, TreeNode7, TreeNode8, TreeNode9, TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Components", 20, 20)
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Date and Time", 9, 9)
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Desktop", 30, 30)
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Drivers", 21, 21)
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Environment Variables", 18, 18)
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Event Viewer", 22, 22)
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("File Types", 23, 23)
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Fonts", 19, 19)
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Installed Programs", 10, 10)
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Multimedia Codecs", 28, 28)
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("OEM Information", 16, 16)
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Processes", 17, 17)
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Services", 11, 11)
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Shares", 24, 24)
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Special Folders", 12, 12)
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Startup Programs", 13, 13)
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("User Information", 14, 14)
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Visual Styles", 15, 15)
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Operating System", 37, 37, New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23, TreeNode24, TreeNode25, TreeNode26, TreeNode27, TreeNode28, TreeNode29, TreeNode30})
        Dim TreeNode32 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Win32 Hardware", 34, 34)
        Dim TreeNode33 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Win32 Memory", 35, 35)
        Dim TreeNode34 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Win32 Network", 5, 5)
        Dim TreeNode35 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Win32 Storage", 4, 4)
        Dim TreeNode36 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Win32 System", 1, 1)
        Dim TreeNode37 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Win32 Users", 14, 14)
        Dim TreeNode38 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Win32 Class Explorer", 33, 33, New System.Windows.Forms.TreeNode() {TreeNode32, TreeNode33, TreeNode34, TreeNode35, TreeNode36, TreeNode37})
        Dim TreeNode39 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("System Information", 0, 0, New System.Windows.Forms.TreeNode() {TreeNode12, TreeNode31, TreeNode38})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.SplitContainerSystemInfo = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanelTreeView = New System.Windows.Forms.TableLayoutPanel()
        Me.TreeViewSystemInfo = New System.Windows.Forms.TreeView()
        Me.ImageListTree = New System.Windows.Forms.ImageList(Me.components)
        Me.PanelHeader = New System.Windows.Forms.Panel()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBarCpu = New System.Windows.Forms.ToolStripProgressBar()
        Me.StatusLabelComputerStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.TimerUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.PerformanceCounter1 = New System.Diagnostics.PerformanceCounter()
        Me.NotifyIconSystemInfo = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStripTrayIcon = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TrayContextMenuRestore = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrayContextMenuExit = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainerSystemInfo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerSystemInfo.Panel1.SuspendLayout()
        Me.SplitContainerSystemInfo.SuspendLayout()
        Me.TableLayoutPanelTreeView.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        CType(Me.PerformanceCounter1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripTrayIcon.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainerSystemInfo
        '
        Me.SplitContainerSystemInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.SplitContainerSystemInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.SplitContainerSystemInfo.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerSystemInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainerSystemInfo.IsSplitterFixed = True
        Me.SplitContainerSystemInfo.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerSystemInfo.Name = "SplitContainerSystemInfo"
        '
        'SplitContainerSystemInfo.Panel1
        '
        Me.SplitContainerSystemInfo.Panel1.Controls.Add(Me.TableLayoutPanelTreeView)
        Me.SplitContainerSystemInfo.Panel1MinSize = 235
        '
        'SplitContainerSystemInfo.Panel2
        '
        Me.SplitContainerSystemInfo.Panel2.AutoScroll = True
        Me.SplitContainerSystemInfo.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainerSystemInfo.Panel2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SplitContainerSystemInfo.Panel2MinSize = 100
        Me.SplitContainerSystemInfo.Size = New System.Drawing.Size(979, 639)
        Me.SplitContainerSystemInfo.SplitterDistance = 352
        Me.SplitContainerSystemInfo.SplitterWidth = 1
        Me.SplitContainerSystemInfo.TabIndex = 0
        '
        'TableLayoutPanelTreeView
        '
        Me.TableLayoutPanelTreeView.ColumnCount = 1
        Me.TableLayoutPanelTreeView.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelTreeView.Controls.Add(Me.TreeViewSystemInfo, 0, 1)
        Me.TableLayoutPanelTreeView.Controls.Add(Me.PanelHeader, 0, 0)
        Me.TableLayoutPanelTreeView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelTreeView.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanelTreeView.Name = "TableLayoutPanelTreeView"
        Me.TableLayoutPanelTreeView.RowCount = 2
        Me.TableLayoutPanelTreeView.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelTreeView.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelTreeView.Size = New System.Drawing.Size(352, 639)
        Me.TableLayoutPanelTreeView.TabIndex = 0
        '
        'TreeViewSystemInfo
        '
        Me.TreeViewSystemInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.TreeViewSystemInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeViewSystemInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeViewSystemInfo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeViewSystemInfo.ImageIndex = 0
        Me.TreeViewSystemInfo.ImageList = Me.ImageListTree
        Me.TreeViewSystemInfo.Location = New System.Drawing.Point(3, 23)
        Me.TreeViewSystemInfo.Name = "TreeViewSystemInfo"
        TreeNode1.ImageIndex = 2
        TreeNode1.Name = "BIOS"
        TreeNode1.SelectedImageIndex = 2
        TreeNode1.Text = "BIOS"
        TreeNode1.ToolTipText = "Information about the Basic Input Output System."
        TreeNode2.ImageIndex = 3
        TreeNode2.Name = "CPU"
        TreeNode2.SelectedImageIndex = 3
        TreeNode2.Text = "CPU"
        TreeNode2.ToolTipText = "Information about the Central Processing Unit (Processor)."
        TreeNode3.ImageIndex = 36
        TreeNode3.Name = "Drives"
        TreeNode3.SelectedImageIndex = 36
        TreeNode3.Text = "Drives and Volumes"
        TreeNode3.ToolTipText = "Information about hard drives, removable drives and volumes."
        TreeNode4.ImageIndex = 26
        TreeNode4.Name = "Keyboard"
        TreeNode4.SelectedImageIndex = 26
        TreeNode4.Text = "Keyboard"
        TreeNode5.ImageIndex = 27
        TreeNode5.Name = "PointingDevice"
        TreeNode5.SelectedImageIndex = 27
        TreeNode5.Text = "Pointing Device"
        TreeNode6.ImageIndex = 25
        TreeNode6.Name = "InputDevices"
        TreeNode6.SelectedImageIndex = 25
        TreeNode6.Text = "Input Devices"
        TreeNode7.ImageIndex = 5
        TreeNode7.Name = "Network"
        TreeNode7.SelectedImageIndex = 5
        TreeNode7.Text = "Network"
        TreeNode7.ToolTipText = "Information about network interfaces."
        TreeNode8.ImageIndex = 32
        TreeNode8.Name = "Ports"
        TreeNode8.SelectedImageIndex = 32
        TreeNode8.Text = "Ports"
        TreeNode9.ImageIndex = 6
        TreeNode9.Name = "Sound"
        TreeNode9.SelectedImageIndex = 6
        TreeNode9.Text = "Sound"
        TreeNode9.ToolTipText = "Information about sound controllers."
        TreeNode10.ImageIndex = 31
        TreeNode10.Name = "UsbDevices"
        TreeNode10.SelectedImageIndex = 31
        TreeNode10.Text = "USB Devices"
        TreeNode11.ImageIndex = 7
        TreeNode11.Name = "Video"
        TreeNode11.SelectedImageIndex = 7
        TreeNode11.Text = "Video"
        TreeNode11.ToolTipText = "Information about video controllers."
        TreeNode12.Checked = True
        TreeNode12.ImageIndex = 1
        TreeNode12.Name = "Computer"
        TreeNode12.SelectedImageIndex = 1
        TreeNode12.Text = "Computer"
        TreeNode12.ToolTipText = "General information about this computer."
        TreeNode13.ImageIndex = 20
        TreeNode13.Name = "Components"
        TreeNode13.SelectedImageIndex = 20
        TreeNode13.Text = "Components"
        TreeNode14.ImageIndex = 9
        TreeNode14.Name = "DateTime"
        TreeNode14.SelectedImageIndex = 9
        TreeNode14.Text = "Date and Time"
        TreeNode14.ToolTipText = "Date and time information."
        TreeNode15.ImageIndex = 30
        TreeNode15.Name = "Desktop"
        TreeNode15.SelectedImageIndex = 30
        TreeNode15.Text = "Desktop"
        TreeNode16.ImageIndex = 21
        TreeNode16.Name = "Drivers"
        TreeNode16.SelectedImageIndex = 21
        TreeNode16.Text = "Drivers"
        TreeNode17.ImageIndex = 18
        TreeNode17.Name = "EnvironmentVariables"
        TreeNode17.SelectedImageIndex = 18
        TreeNode17.Text = "Environment Variables"
        TreeNode17.ToolTipText = "List of variables used at the command line."
        TreeNode18.ImageIndex = 22
        TreeNode18.Name = "Event Viewer"
        TreeNode18.SelectedImageIndex = 22
        TreeNode18.Text = "Event Viewer"
        TreeNode19.ImageIndex = 23
        TreeNode19.Name = "File Types"
        TreeNode19.SelectedImageIndex = 23
        TreeNode19.Text = "File Types"
        TreeNode20.ImageIndex = 19
        TreeNode20.Name = "Fonts"
        TreeNode20.SelectedImageIndex = 19
        TreeNode20.Text = "Fonts"
        TreeNode21.ImageIndex = 10
        TreeNode21.Name = "Installed Programs"
        TreeNode21.SelectedImageIndex = 10
        TreeNode21.Text = "Installed Programs"
        TreeNode21.ToolTipText = "List of all installed programs."
        TreeNode22.ImageIndex = 28
        TreeNode22.Name = "MultimediaCodecs"
        TreeNode22.SelectedImageIndex = 28
        TreeNode22.Text = "Multimedia Codecs"
        TreeNode23.ImageIndex = 16
        TreeNode23.Name = "OEMInformation"
        TreeNode23.SelectedImageIndex = 16
        TreeNode23.Text = "OEM Information"
        TreeNode23.ToolTipText = "Information added by OEM."
        TreeNode24.ImageIndex = 17
        TreeNode24.Name = "Processes"
        TreeNode24.SelectedImageIndex = 17
        TreeNode24.Text = "Processes"
        TreeNode24.ToolTipText = "Running processes on this computer."
        TreeNode25.ImageIndex = 11
        TreeNode25.Name = "Services"
        TreeNode25.SelectedImageIndex = 11
        TreeNode25.Text = "Services"
        TreeNode25.ToolTipText = "List and description of all installed services."
        TreeNode26.ImageIndex = 24
        TreeNode26.Name = "Shares"
        TreeNode26.SelectedImageIndex = 24
        TreeNode26.Text = "Shares"
        TreeNode27.ImageIndex = 12
        TreeNode27.Name = "SpecialFolders"
        TreeNode27.SelectedImageIndex = 12
        TreeNode27.Text = "Special Folders"
        TreeNode27.ToolTipText = "List of Windows® Special Folders and their paths."
        TreeNode28.ImageIndex = 13
        TreeNode28.Name = "Startup Programs"
        TreeNode28.SelectedImageIndex = 13
        TreeNode28.Text = "Startup Programs"
        TreeNode28.ToolTipText = "Programs that run when you login."
        TreeNode29.ImageIndex = 14
        TreeNode29.Name = "UserInformation"
        TreeNode29.SelectedImageIndex = 14
        TreeNode29.Text = "User Information"
        TreeNode29.ToolTipText = "Information about user: owner and auto logon."
        TreeNode30.ImageIndex = 15
        TreeNode30.Name = "VisualStyles"
        TreeNode30.SelectedImageIndex = 15
        TreeNode30.Text = "Visual Styles"
        TreeNode30.ToolTipText = "Information about the visual style currently in use."
        TreeNode31.ImageIndex = 37
        TreeNode31.Name = "OperatingSystem"
        TreeNode31.SelectedImageIndex = 37
        TreeNode31.Text = "Operating System"
        TreeNode31.ToolTipText = "Information about the operating system."
        TreeNode32.ImageIndex = 34
        TreeNode32.Name = "Win32Hardware"
        TreeNode32.SelectedImageIndex = 34
        TreeNode32.Text = "Win32 Hardware"
        TreeNode33.ImageIndex = 35
        TreeNode33.Name = "Win32Memory"
        TreeNode33.SelectedImageIndex = 35
        TreeNode33.Text = "Win32 Memory"
        TreeNode34.ImageIndex = 5
        TreeNode34.Name = "Win32Network"
        TreeNode34.SelectedImageIndex = 5
        TreeNode34.Text = "Win32 Network"
        TreeNode35.ImageIndex = 4
        TreeNode35.Name = "Win32Storage"
        TreeNode35.SelectedImageIndex = 4
        TreeNode35.Text = "Win32 Storage"
        TreeNode36.ImageIndex = 1
        TreeNode36.Name = "Win32System"
        TreeNode36.SelectedImageIndex = 1
        TreeNode36.Text = "Win32 System"
        TreeNode37.ImageIndex = 14
        TreeNode37.Name = "Win32Users"
        TreeNode37.SelectedImageIndex = 14
        TreeNode37.Text = "Win32 Users"
        TreeNode38.ImageIndex = 33
        TreeNode38.Name = "Win32ClassExplorer"
        TreeNode38.SelectedImageIndex = 33
        TreeNode38.Text = "Win32 Class Explorer"
        TreeNode39.ImageIndex = 0
        TreeNode39.Name = "SystemInformation"
        TreeNode39.SelectedImageIndex = 0
        TreeNode39.Text = "System Information"
        Me.TreeViewSystemInfo.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode39})
        Me.TreeViewSystemInfo.SelectedImageIndex = 0
        Me.TreeViewSystemInfo.ShowNodeToolTips = True
        Me.TreeViewSystemInfo.Size = New System.Drawing.Size(346, 613)
        Me.TreeViewSystemInfo.TabIndex = 1
        '
        'ImageListTree
        '
        Me.ImageListTree.ImageStream = CType(resources.GetObject("ImageListTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListTree.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListTree.Images.SetKeyName(0, "System Information_16x16.png")
        Me.ImageListTree.Images.SetKeyName(1, "Computer_16x16.png")
        Me.ImageListTree.Images.SetKeyName(2, "")
        Me.ImageListTree.Images.SetKeyName(3, "")
        Me.ImageListTree.Images.SetKeyName(4, "Drive_16x16.png")
        Me.ImageListTree.Images.SetKeyName(5, "Network_16x16.png")
        Me.ImageListTree.Images.SetKeyName(6, "Sound_16x16.png")
        Me.ImageListTree.Images.SetKeyName(7, "Video_16x16.png")
        Me.ImageListTree.Images.SetKeyName(8, "")
        Me.ImageListTree.Images.SetKeyName(9, "Date-Time_16x16.png")
        Me.ImageListTree.Images.SetKeyName(10, "Installed Programs_16x16.png")
        Me.ImageListTree.Images.SetKeyName(11, "Services_16x16.png")
        Me.ImageListTree.Images.SetKeyName(12, "SpecialFolder_16x16.png")
        Me.ImageListTree.Images.SetKeyName(13, "Startup_16x16.png")
        Me.ImageListTree.Images.SetKeyName(14, "Users_16x16.png")
        Me.ImageListTree.Images.SetKeyName(15, "VisualStyles_16x16.png")
        Me.ImageListTree.Images.SetKeyName(16, "OEM_16x 16.png")
        Me.ImageListTree.Images.SetKeyName(17, "Processes_16x16.png")
        Me.ImageListTree.Images.SetKeyName(18, "CMD_16x16.png")
        Me.ImageListTree.Images.SetKeyName(19, "Font_16x16.png")
        Me.ImageListTree.Images.SetKeyName(20, "Components_16x16.png")
        Me.ImageListTree.Images.SetKeyName(21, "Drivers_16x16.png")
        Me.ImageListTree.Images.SetKeyName(22, "EventViewer_16x16.png")
        Me.ImageListTree.Images.SetKeyName(23, "FileTypes_16x16.png")
        Me.ImageListTree.Images.SetKeyName(24, "Shares_16x16.png")
        Me.ImageListTree.Images.SetKeyName(25, "InputDevices_16x16.png")
        Me.ImageListTree.Images.SetKeyName(26, "Keyboard_16x16.png")
        Me.ImageListTree.Images.SetKeyName(27, "Mouse_16x16.png")
        Me.ImageListTree.Images.SetKeyName(28, "Multimedia_16x16.png")
        Me.ImageListTree.Images.SetKeyName(29, "Video_16x16.png")
        Me.ImageListTree.Images.SetKeyName(30, "Desktop_16x16.png")
        Me.ImageListTree.Images.SetKeyName(31, "UsbDrive_16x16.png")
        Me.ImageListTree.Images.SetKeyName(32, "Ports_16x16.png")
        Me.ImageListTree.Images.SetKeyName(33, "Miscellaneous_16x16.png")
        Me.ImageListTree.Images.SetKeyName(34, "Motherboard_16x16.png")
        Me.ImageListTree.Images.SetKeyName(35, "Memory_16x16.png")
        Me.ImageListTree.Images.SetKeyName(36, "VolumeInformation_16x16.png")
        Me.ImageListTree.Images.SetKeyName(37, "Windows_16x16.png")
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelHeader.Location = New System.Drawing.Point(3, 3)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(346, 14)
        Me.PanelHeader.TabIndex = 2
        '
        'StatusStrip
        '
        Me.StatusStrip.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBarCpu, Me.StatusLabelComputerStatus, Me.ToolStripProgressBar1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 624)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(979, 22)
        Me.StatusStrip.SizingGrip = False
        Me.StatusStrip.TabIndex = 3
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'ToolStripProgressBarCpu
        '
        Me.ToolStripProgressBarCpu.Name = "ToolStripProgressBarCpu"
        Me.ToolStripProgressBarCpu.Size = New System.Drawing.Size(50, 16)
        '
        'StatusLabelComputerStatus
        '
        Me.StatusLabelComputerStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusLabelComputerStatus.Name = "StatusLabelComputerStatus"
        Me.StatusLabelComputerStatus.Size = New System.Drawing.Size(912, 17)
        Me.StatusLabelComputerStatus.Spring = True
        Me.StatusLabelComputerStatus.Text = "Monday, January 10, 2006"
        Me.StatusLabelComputerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 16)
        Me.ToolStripProgressBar1.Visible = False
        '
        'TimerUpdate
        '
        Me.TimerUpdate.Enabled = True
        Me.TimerUpdate.Interval = 1000
        '
        'PerformanceCounter1
        '
        Me.PerformanceCounter1.CategoryName = "Processor"
        Me.PerformanceCounter1.CounterName = "% Processor Time"
        Me.PerformanceCounter1.InstanceName = "_Total"
        '
        'NotifyIconSystemInfo
        '
        Me.NotifyIconSystemInfo.ContextMenuStrip = Me.ContextMenuStripTrayIcon
        Me.NotifyIconSystemInfo.Text = "System Information"
        '
        'ContextMenuStripTrayIcon
        '
        Me.ContextMenuStripTrayIcon.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TrayContextMenuRestore, Me.TrayContextMenuExit})
        Me.ContextMenuStripTrayIcon.Name = "ContextMenuStripTrayIcon"
        Me.ContextMenuStripTrayIcon.Size = New System.Drawing.Size(114, 48)
        '
        'TrayContextMenuRestore
        '
        Me.TrayContextMenuRestore.Image = Global.SystemInformation.My.Resources.Resources.Restore_16x16
        Me.TrayContextMenuRestore.Name = "TrayContextMenuRestore"
        Me.TrayContextMenuRestore.Size = New System.Drawing.Size(113, 22)
        Me.TrayContextMenuRestore.Text = "Restore"
        '
        'TrayContextMenuExit
        '
        Me.TrayContextMenuExit.Image = Global.SystemInformation.My.Resources.Resources.Exit_16x16
        Me.TrayContextMenuExit.Name = "TrayContextMenuExit"
        Me.TrayContextMenuExit.Size = New System.Drawing.Size(113, 22)
        Me.TrayContextMenuExit.Text = "Exit"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(979, 646)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.SplitContainerSystemInfo)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(995, 685)
        Me.MinimumSize = New System.Drawing.Size(995, 685)
        Me.Name = "MainForm"
        Me.Opacity = 0.0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Information II"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.SplitContainerSystemInfo.Panel1.ResumeLayout(False)
        CType(Me.SplitContainerSystemInfo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerSystemInfo.ResumeLayout(False)
        Me.TableLayoutPanelTreeView.ResumeLayout(False)
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.PerformanceCounter1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripTrayIcon.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SplitContainerSystemInfo As System.Windows.Forms.SplitContainer
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabelComputerStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageListTree As System.Windows.Forms.ImageList
    Friend WithEvents TimerUpdate As System.Windows.Forms.Timer
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripProgressBarCpu As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents PerformanceCounter1 As System.Diagnostics.PerformanceCounter
    Friend WithEvents NotifyIconSystemInfo As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStripTrayIcon As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TrayContextMenuRestore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrayContextMenuExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TableLayoutPanelTreeView As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TreeViewSystemInfo As System.Windows.Forms.TreeView
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel

End Class
