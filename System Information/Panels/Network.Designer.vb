<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Network
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Network))
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.LabelNetworkID = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelGeneralInfo = New System.Windows.Forms.Label
        Me.ComboBoxInterface = New System.Windows.Forms.ComboBox
        Me.LabelInterfaces = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.ImageListNetwork = New System.Windows.Forms.ImageList(Me.components)
        Me.RadioButtonGeneral = New System.Windows.Forms.RadioButton
        Me.RadioButtonConnections = New System.Windows.Forms.RadioButton
        Me.RadioButtonModem = New System.Windows.Forms.RadioButton
        Me.RadioButtonNetworkAdapters = New System.Windows.Forms.RadioButton
        Me.CheckBoxHideInterfacesWithoutIPAddress = New System.Windows.Forms.CheckBox
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress = New System.Windows.Forms.CheckBox
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewNetwork = New System.Windows.Forms.ListView
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ButtonRefreshNetwork = New System.Windows.Forms.Button
        Me.ButtonRefreshInterfaces = New System.Windows.Forms.Button
        Me.PanelWaitInterface = New System.Windows.Forms.Panel
        Me.ListViewInterface = New System.Windows.Forms.ListView
        Me.LabelWait2 = New System.Windows.Forms.Label
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWait.SuspendLayout()
        Me.PanelWaitInterface.SuspendLayout()
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
        Me.LabelTitle.Size = New System.Drawing.Size(90, 25)
        Me.LabelTitle.TabIndex = 14
        Me.LabelTitle.Text = "Network"
        '
        'LabelNetworkID
        '
        Me.LabelNetworkID.AutoEllipsis = True
        Me.LabelNetworkID.BackColor = System.Drawing.Color.Transparent
        Me.LabelNetworkID.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNetworkID.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelNetworkID.Location = New System.Drawing.Point(235, 76)
        Me.LabelNetworkID.Name = "LabelNetworkID"
        Me.LabelNetworkID.Size = New System.Drawing.Size(477, 17)
        Me.LabelNetworkID.TabIndex = 13
        Me.LabelNetworkID.TextAlign = System.Drawing.ContentAlignment.TopRight
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
        'LabelGeneralInfo
        '
        Me.LabelGeneralInfo.AutoSize = True
        Me.LabelGeneralInfo.BackColor = System.Drawing.Color.Transparent
        Me.LabelGeneralInfo.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGeneralInfo.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelGeneralInfo.Location = New System.Drawing.Point(87, 76)
        Me.LabelGeneralInfo.Name = "LabelGeneralInfo"
        Me.LabelGeneralInfo.Size = New System.Drawing.Size(133, 17)
        Me.LabelGeneralInfo.TabIndex = 12
        Me.LabelGeneralInfo.Text = "General Information"
        '
        'ComboBoxInterface
        '
        Me.ComboBoxInterface.FormattingEnabled = True
        Me.ComboBoxInterface.Location = New System.Drawing.Point(87, 398)
        Me.ComboBoxInterface.Name = "ComboBoxInterface"
        Me.ComboBoxInterface.Size = New System.Drawing.Size(640, 25)
        Me.ComboBoxInterface.Sorted = True
        Me.ComboBoxInterface.TabIndex = 6
        '
        'LabelInterfaces
        '
        Me.LabelInterfaces.AutoSize = True
        Me.LabelInterfaces.BackColor = System.Drawing.Color.Transparent
        Me.LabelInterfaces.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelInterfaces.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelInterfaces.Location = New System.Drawing.Point(87, 358)
        Me.LabelInterfaces.Name = "LabelInterfaces"
        Me.LabelInterfaces.Size = New System.Drawing.Size(68, 17)
        Me.LabelInterfaces.TabIndex = 9
        Me.LabelInterfaces.Text = "Interfaces"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(87, 380)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 10
        '
        'ImageListNetwork
        '
        Me.ImageListNetwork.ImageStream = CType(resources.GetObject("ImageListNetwork.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListNetwork.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListNetwork.Images.SetKeyName(0, "No_16x16.png")
        Me.ImageListNetwork.Images.SetKeyName(1, "Network_16x16.png")
        Me.ImageListNetwork.Images.SetKeyName(2, "Modem_16x16.png")
        Me.ImageListNetwork.Images.SetKeyName(3, "Internet_16x16.png")
        Me.ImageListNetwork.Images.SetKeyName(4, "Proxy_16x16.png")
        Me.ImageListNetwork.Images.SetKeyName(5, "Services_16x16.png")
        Me.ImageListNetwork.Images.SetKeyName(6, "Adaptor_16x16.png")
        '
        'RadioButtonGeneral
        '
        Me.RadioButtonGeneral.AutoSize = True
        Me.RadioButtonGeneral.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonGeneral.Checked = True
        Me.RadioButtonGeneral.Location = New System.Drawing.Point(87, 111)
        Me.RadioButtonGeneral.Name = "RadioButtonGeneral"
        Me.RadioButtonGeneral.Size = New System.Drawing.Size(71, 21)
        Me.RadioButtonGeneral.TabIndex = 0
        Me.RadioButtonGeneral.TabStop = True
        Me.RadioButtonGeneral.Text = "General"
        Me.RadioButtonGeneral.UseVisualStyleBackColor = True
        '
        'RadioButtonConnections
        '
        Me.RadioButtonConnections.AutoSize = True
        Me.RadioButtonConnections.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonConnections.Location = New System.Drawing.Point(159, 111)
        Me.RadioButtonConnections.Name = "RadioButtonConnections"
        Me.RadioButtonConnections.Size = New System.Drawing.Size(97, 21)
        Me.RadioButtonConnections.TabIndex = 1
        Me.RadioButtonConnections.Text = "Connections"
        Me.RadioButtonConnections.UseVisualStyleBackColor = True
        '
        'RadioButtonModem
        '
        Me.RadioButtonModem.AutoSize = True
        Me.RadioButtonModem.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonModem.Location = New System.Drawing.Point(257, 111)
        Me.RadioButtonModem.Name = "RadioButtonModem"
        Me.RadioButtonModem.Size = New System.Drawing.Size(72, 21)
        Me.RadioButtonModem.TabIndex = 2
        Me.RadioButtonModem.Text = "Modem"
        Me.RadioButtonModem.UseVisualStyleBackColor = True
        '
        'RadioButtonNetworkAdapters
        '
        Me.RadioButtonNetworkAdapters.AutoSize = True
        Me.RadioButtonNetworkAdapters.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonNetworkAdapters.Location = New System.Drawing.Point(330, 111)
        Me.RadioButtonNetworkAdapters.Name = "RadioButtonNetworkAdapters"
        Me.RadioButtonNetworkAdapters.Size = New System.Drawing.Size(80, 21)
        Me.RadioButtonNetworkAdapters.TabIndex = 3
        Me.RadioButtonNetworkAdapters.Text = "Adaptors"
        Me.RadioButtonNetworkAdapters.UseVisualStyleBackColor = True
        '
        'CheckBoxHideInterfacesWithoutIPAddress
        '
        Me.CheckBoxHideInterfacesWithoutIPAddress.AutoSize = True
        Me.CheckBoxHideInterfacesWithoutIPAddress.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxHideInterfacesWithoutIPAddress.Checked = True
        Me.CheckBoxHideInterfacesWithoutIPAddress.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxHideInterfacesWithoutIPAddress.Location = New System.Drawing.Point(495, 356)
        Me.CheckBoxHideInterfacesWithoutIPAddress.Name = "CheckBoxHideInterfacesWithoutIPAddress"
        Me.CheckBoxHideInterfacesWithoutIPAddress.Size = New System.Drawing.Size(242, 21)
        Me.CheckBoxHideInterfacesWithoutIPAddress.TabIndex = 5
        Me.CheckBoxHideInterfacesWithoutIPAddress.Text = "Hide Interfaces Without IP Addresses"
        Me.CheckBoxHideInterfacesWithoutIPAddress.UseVisualStyleBackColor = True
        '
        'CheckBoxHideNetworkAdaptorsWithoutMACAddress
        '
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.AutoSize = True
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.Checked = True
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.Location = New System.Drawing.Point(479, 112)
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.Name = "CheckBoxHideNetworkAdaptorsWithoutMACAddress"
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.Size = New System.Drawing.Size(258, 21)
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.TabIndex = 4
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.Text = "Hide Adaptors Without MAC Addresses"
        Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress.UseVisualStyleBackColor = True
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Network_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewNetwork)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(89, 136)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 207)
        Me.PanelWait.TabIndex = 20
        '
        'ListViewNetwork
        '
        Me.ListViewNetwork.FullRowSelect = True
        Me.ListViewNetwork.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewNetwork.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewNetwork.MultiSelect = False
        Me.ListViewNetwork.Name = "ListViewNetwork"
        Me.ListViewNetwork.Size = New System.Drawing.Size(640, 207)
        Me.ListViewNetwork.TabIndex = 1
        Me.ListViewNetwork.UseCompatibleStateImageBehavior = False
        Me.ListViewNetwork.View = System.Windows.Forms.View.Details
        Me.ListViewNetwork.Visible = False
        '
        'LabelWait
        '
        Me.LabelWait.AllowDrop = True
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 90)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 0
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'ButtonRefreshNetwork
        '
        Me.ButtonRefreshNetwork.AutoSize = True
        Me.ButtonRefreshNetwork.Location = New System.Drawing.Point(15, 136)
        Me.ButtonRefreshNetwork.Name = "ButtonRefreshNetwork"
        Me.ButtonRefreshNetwork.Size = New System.Drawing.Size(66, 27)
        Me.ButtonRefreshNetwork.TabIndex = 7
        Me.ButtonRefreshNetwork.Text = "Refresh"
        Me.ButtonRefreshNetwork.UseVisualStyleBackColor = True
        '
        'ButtonRefreshInterfaces
        '
        Me.ButtonRefreshInterfaces.AutoSize = True
        Me.ButtonRefreshInterfaces.Location = New System.Drawing.Point(15, 427)
        Me.ButtonRefreshInterfaces.Name = "ButtonRefreshInterfaces"
        Me.ButtonRefreshInterfaces.Size = New System.Drawing.Size(66, 27)
        Me.ButtonRefreshInterfaces.TabIndex = 8
        Me.ButtonRefreshInterfaces.Text = "Refresh"
        Me.ButtonRefreshInterfaces.UseVisualStyleBackColor = True
        '
        'PanelWaitInterface
        '
        Me.PanelWaitInterface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWaitInterface.Controls.Add(Me.ListViewInterface)
        Me.PanelWaitInterface.Controls.Add(Me.LabelWait2)
        Me.PanelWaitInterface.Location = New System.Drawing.Point(87, 427)
        Me.PanelWaitInterface.Name = "PanelWaitInterface"
        Me.PanelWaitInterface.Size = New System.Drawing.Size(640, 181)
        Me.PanelWaitInterface.TabIndex = 21
        '
        'ListViewInterface
        '
        Me.ListViewInterface.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewInterface.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewInterface.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ListViewInterface.FullRowSelect = True
        Me.ListViewInterface.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewInterface.LabelWrap = False
        Me.ListViewInterface.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewInterface.Name = "ListViewInterface"
        Me.ListViewInterface.Size = New System.Drawing.Size(640, 181)
        Me.ListViewInterface.TabIndex = 1
        Me.ListViewInterface.UseCompatibleStateImageBehavior = False
        Me.ListViewInterface.View = System.Windows.Forms.View.Details
        Me.ListViewInterface.Visible = False
        '
        'LabelWait2
        '
        Me.LabelWait2.AutoSize = True
        Me.LabelWait2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait2.Location = New System.Drawing.Point(198, 77)
        Me.LabelWait2.Name = "LabelWait2"
        Me.LabelWait2.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait2.TabIndex = 0
        Me.LabelWait2.Text = "Loading Data, Please Wait..."
        '
        'Network
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWaitInterface)
        Me.Controls.Add(Me.ButtonRefreshInterfaces)
        Me.Controls.Add(Me.ButtonRefreshNetwork)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.CheckBoxHideNetworkAdaptorsWithoutMACAddress)
        Me.Controls.Add(Me.CheckBoxHideInterfacesWithoutIPAddress)
        Me.Controls.Add(Me.RadioButtonNetworkAdapters)
        Me.Controls.Add(Me.RadioButtonModem)
        Me.Controls.Add(Me.RadioButtonConnections)
        Me.Controls.Add(Me.RadioButtonGeneral)
        Me.Controls.Add(Me.LabelInterfaces)
        Me.Controls.Add(Me.LabelSeparator2)
        Me.Controls.Add(Me.ComboBoxInterface)
        Me.Controls.Add(Me.LabelGeneralInfo)
        Me.Controls.Add(Me.LabelNetworkID)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Network"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.PanelWaitInterface.ResumeLayout(False)
        Me.PanelWaitInterface.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelNetworkID As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelGeneralInfo As System.Windows.Forms.Label
    Private WithEvents ComboBoxInterface As System.Windows.Forms.ComboBox
    Private WithEvents LabelInterfaces As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonGeneral As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonConnections As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonModem As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNetworkAdapters As System.Windows.Forms.RadioButton
    Friend WithEvents CheckBoxHideInterfacesWithoutIPAddress As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxHideNetworkAdaptorsWithoutMACAddress As System.Windows.Forms.CheckBox
    Friend WithEvents ImageListNetwork As System.Windows.Forms.ImageList
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Friend WithEvents ListViewNetwork As System.Windows.Forms.ListView
    Friend WithEvents ButtonRefreshNetwork As System.Windows.Forms.Button
    Friend WithEvents ButtonRefreshInterfaces As System.Windows.Forms.Button
    Friend WithEvents PanelWaitInterface As System.Windows.Forms.Panel
    Friend WithEvents LabelWait2 As System.Windows.Forms.Label
    Private WithEvents ListViewInterface As System.Windows.Forms.ListView

End Class
