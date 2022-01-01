<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ports
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
        Me.RadioButtonParallelPort = New System.Windows.Forms.RadioButton
        Me.RadioButtonSerialPort = New System.Windows.Forms.RadioButton
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewPorts = New System.Windows.Forms.ListView
        Me.Label1 = New System.Windows.Forms.Label
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
        Me.LabelTitle.Size = New System.Drawing.Size(59, 25)
        Me.LabelTitle.TabIndex = 4
        Me.LabelTitle.Text = "Ports"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.UsbDrive_48x48
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
        Me.LabelFolders.Size = New System.Drawing.Size(272, 17)
        Me.LabelFolders.TabIndex = 3
        Me.LabelFolders.Text = "Information about parallel and serial ports"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 2
        '
        'RadioButtonParallelPort
        '
        Me.RadioButtonParallelPort.AutoSize = True
        Me.RadioButtonParallelPort.Checked = True
        Me.RadioButtonParallelPort.Location = New System.Drawing.Point(90, 112)
        Me.RadioButtonParallelPort.Name = "RadioButtonParallelPort"
        Me.RadioButtonParallelPort.Size = New System.Drawing.Size(102, 21)
        Me.RadioButtonParallelPort.TabIndex = 0
        Me.RadioButtonParallelPort.TabStop = True
        Me.RadioButtonParallelPort.Text = "Parallel Ports"
        Me.RadioButtonParallelPort.UseVisualStyleBackColor = True
        '
        'RadioButtonSerialPort
        '
        Me.RadioButtonSerialPort.AutoSize = True
        Me.RadioButtonSerialPort.Location = New System.Drawing.Point(218, 112)
        Me.RadioButtonSerialPort.Name = "RadioButtonSerialPort"
        Me.RadioButtonSerialPort.Size = New System.Drawing.Size(92, 21)
        Me.RadioButtonSerialPort.TabIndex = 1
        Me.RadioButtonSerialPort.Text = "Serial Ports"
        Me.RadioButtonSerialPort.UseVisualStyleBackColor = True
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewPorts)
        Me.PanelWait.Controls.Add(Me.Label1)
        Me.PanelWait.Location = New System.Drawing.Point(87, 142)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 475)
        Me.PanelWait.TabIndex = 36
        '
        'ListViewPorts
        '
        Me.ListViewPorts.FullRowSelect = True
        Me.ListViewPorts.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewPorts.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewPorts.MultiSelect = False
        Me.ListViewPorts.Name = "ListViewPorts"
        Me.ListViewPorts.Size = New System.Drawing.Size(640, 475)
        Me.ListViewPorts.TabIndex = 0
        Me.ListViewPorts.UseCompatibleStateImageBehavior = False
        Me.ListViewPorts.View = System.Windows.Forms.View.Details
        Me.ListViewPorts.Visible = False
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 224)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Loading Data, Please Wait..."
        '
        'Ports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.RadioButtonSerialPort)
        Me.Controls.Add(Me.RadioButtonParallelPort)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Ports"
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
    Friend WithEvents RadioButtonParallelPort As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonSerialPort As System.Windows.Forms.RadioButton
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListViewPorts As System.Windows.Forms.ListView

End Class
