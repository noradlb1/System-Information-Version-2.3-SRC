<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Win32System
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
        Me.LabelFolders = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelSelect = New System.Windows.Forms.Label
        Me.ComboBoxSelect = New System.Windows.Forms.ComboBox
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewWin32 = New System.Windows.Forms.ListView
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.ButtonRefresh = New System.Windows.Forms.Button
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
        Me.LabelTitle.Size = New System.Drawing.Size(75, 25)
        Me.LabelTitle.TabIndex = 6
        Me.LabelTitle.Text = "System"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Computer_48x48
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
        Me.LabelFolders.Size = New System.Drawing.Size(150, 17)
        Me.LabelFolders.TabIndex = 5
        Me.LabelFolders.Text = "Win32 System Explorer"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 4
        '
        'LabelSelect
        '
        Me.LabelSelect.AutoSize = True
        Me.LabelSelect.Location = New System.Drawing.Point(372, 123)
        Me.LabelSelect.Name = "LabelSelect"
        Me.LabelSelect.Size = New System.Drawing.Size(116, 17)
        Me.LabelSelect.TabIndex = 3
        Me.LabelSelect.Text = "Select Win32 Class"
        '
        'ComboBoxSelect
        '
        Me.ComboBoxSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxSelect.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxSelect.FormattingEnabled = True
        Me.ComboBoxSelect.Items.AddRange(New Object() {"Win32_Account", "Win32_AccountSID", "Win32_ACE", "Win32_ACE", "Win32_ActionCheck", "Win32_ActionCheck", "Win32_AllocatedResource", "Win32_AllocatedResource", "Win32_ApplicationCommandLine", "Win32_ApplicationCommandLine", "Win32_ApplicationService", "Win32_ApplicationService", "Win32_AssociatedBattery", "Win32_AssociatedProcessorMemory", "Win32_ComputerSystem", "Win32_ComputerSystemProcessor", "Win32_ComputerSystemProduct", "Win32_Process", "Win32_ProcessStartup", "Win32_Product", "Win32_ProductCheck", "Win32_ProductResource", "Win32_ProductSoftwareFeatures", "Win32_ProgIDSpecification", "Win32_ProgramGroup", "Win32_ProgramGroupContents", "Win32_ProgramGroupOrItem", "Win32_Property", "Win32_ProtocolBinding", "Win32_PublishComponentAction", "Win32_QuickFixEngineering", "Win32_Refrigeration", "Win32_Registry", "Win32_RegistryAction", "Win32_Service", "Win32_ServiceControl", "Win32_ServiceSpecification", "Win32_ServiceSpecificationService", "Win32_SystemAccount", "Win32_SystemBIOS", "Win32_SystemBootConfiguration", "Win32_SystemDesktop", "Win32_SystemDevices", "Win32_SystemDriver", "Win32_SystemDriverPNPEntity", "Win32_SystemEnclosure", "Win32_SystemLoadOrderGroups", "Win32_SystemLogicalMemoryConfiguration", "Win32_SystemMemoryResource", "Win32_SystemOperatingSystem", "Win32_SystemPartitions", "Win32_SystemProcesses", "Win32_SystemProgramGroups", "Win32_SystemResources", "Win32_SystemServices", "Win32_SystemSetting", "Win32_SystemSlot", "Win32_SystemSystemDriver", "Win32_SystemTimeZone"})
        Me.ComboBoxSelect.Location = New System.Drawing.Point(503, 119)
        Me.ComboBoxSelect.Name = "ComboBoxSelect"
        Me.ComboBoxSelect.Size = New System.Drawing.Size(226, 25)
        Me.ComboBoxSelect.Sorted = True
        Me.ComboBoxSelect.TabIndex = 0
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewWin32)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 160)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 457)
        Me.PanelWait.TabIndex = 77
        '
        'ListViewWin32
        '
        Me.ListViewWin32.FullRowSelect = True
        Me.ListViewWin32.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewWin32.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewWin32.Name = "ListViewWin32"
        Me.ListViewWin32.Size = New System.Drawing.Size(640, 457)
        Me.ListViewWin32.TabIndex = 1
        Me.ListViewWin32.UseCompatibleStateImageBehavior = False
        Me.ListViewWin32.View = System.Windows.Forms.View.Details
        Me.ListViewWin32.Visible = False
        '
        'LabelWait
        '
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 215)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 0
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AutoSize = True
        Me.ButtonCancel.Location = New System.Drawing.Point(87, 118)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "&Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.AutoSize = True
        Me.ButtonRefresh.Location = New System.Drawing.Point(178, 118)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(75, 27)
        Me.ButtonRefresh.TabIndex = 2
        Me.ButtonRefresh.Text = "&Refresh"
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'Win32System
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ButtonRefresh)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelSelect)
        Me.Controls.Add(Me.ComboBoxSelect)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Win32System"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelFolders As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents LabelSelect As System.Windows.Forms.Label
    Private WithEvents ComboBoxSelect As System.Windows.Forms.ComboBox
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Friend WithEvents ListViewWin32 As System.Windows.Forms.ListView
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button

End Class
