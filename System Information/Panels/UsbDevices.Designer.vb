<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UsbDevices
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
        Me.RadioButtonUsbController = New System.Windows.Forms.RadioButton
        Me.RadioButtonUsbHub = New System.Windows.Forms.RadioButton
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewUsb = New System.Windows.Forms.ListView
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
        Me.LabelTitle.Size = New System.Drawing.Size(120, 25)
        Me.LabelTitle.TabIndex = 4
        Me.LabelTitle.Text = "USB Devices"
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
        Me.LabelFolders.Size = New System.Drawing.Size(281, 17)
        Me.LabelFolders.TabIndex = 3
        Me.LabelFolders.Text = "Information about USB controllers and hubs"
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
        'RadioButtonUsbController
        '
        Me.RadioButtonUsbController.AutoSize = True
        Me.RadioButtonUsbController.Checked = True
        Me.RadioButtonUsbController.Location = New System.Drawing.Point(90, 112)
        Me.RadioButtonUsbController.Name = "RadioButtonUsbController"
        Me.RadioButtonUsbController.Size = New System.Drawing.Size(117, 21)
        Me.RadioButtonUsbController.TabIndex = 0
        Me.RadioButtonUsbController.TabStop = True
        Me.RadioButtonUsbController.Text = "USB Controllers"
        Me.RadioButtonUsbController.UseVisualStyleBackColor = True
        '
        'RadioButtonUsbHub
        '
        Me.RadioButtonUsbHub.AutoSize = True
        Me.RadioButtonUsbHub.Location = New System.Drawing.Point(218, 112)
        Me.RadioButtonUsbHub.Name = "RadioButtonUsbHub"
        Me.RadioButtonUsbHub.Size = New System.Drawing.Size(83, 21)
        Me.RadioButtonUsbHub.TabIndex = 1
        Me.RadioButtonUsbHub.Text = "USB Hubs"
        Me.RadioButtonUsbHub.UseVisualStyleBackColor = True
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewUsb)
        Me.PanelWait.Controls.Add(Me.Label1)
        Me.PanelWait.Location = New System.Drawing.Point(87, 142)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 475)
        Me.PanelWait.TabIndex = 36
        '
        'ListViewUsb
        '
        Me.ListViewUsb.FullRowSelect = True
        Me.ListViewUsb.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewUsb.Name = "ListViewUsb"
        Me.ListViewUsb.Size = New System.Drawing.Size(640, 475)
        Me.ListViewUsb.TabIndex = 0
        Me.ListViewUsb.UseCompatibleStateImageBehavior = False
        Me.ListViewUsb.View = System.Windows.Forms.View.Details
        Me.ListViewUsb.Visible = False
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
        'UsbDevices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.RadioButtonUsbHub)
        Me.Controls.Add(Me.RadioButtonUsbController)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "UsbDevices"
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
    Friend WithEvents RadioButtonUsbController As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonUsbHub As System.Windows.Forms.RadioButton
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListViewUsb As System.Windows.Forms.ListView

End Class
