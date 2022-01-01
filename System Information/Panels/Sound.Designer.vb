<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sound
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
        Me.LabelControllers = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelNumberControllers = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListViewAdaptors = New System.Windows.Forms.ListView
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWait.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelTitle.Location = New System.Drawing.Point(87, 32)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(63, 18)
        Me.LabelTitle.TabIndex = 7
        Me.LabelTitle.Text = "Sound"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Sound_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelControllers
        '
        Me.LabelControllers.AutoSize = True
        Me.LabelControllers.BackColor = System.Drawing.Color.Transparent
        Me.LabelControllers.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControllers.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelControllers.Location = New System.Drawing.Point(87, 76)
        Me.LabelControllers.Name = "LabelControllers"
        Me.LabelControllers.Size = New System.Drawing.Size(88, 16)
        Me.LabelControllers.TabIndex = 15
        Me.LabelControllers.Text = "Controllers"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 14
        '
        'LabelNumberControllers
        '
        Me.LabelNumberControllers.AutoEllipsis = True
        Me.LabelNumberControllers.BackColor = System.Drawing.Color.Transparent
        Me.LabelNumberControllers.ForeColor = System.Drawing.Color.Black
        Me.LabelNumberControllers.Location = New System.Drawing.Point(458, 76)
        Me.LabelNumberControllers.Name = "LabelNumberControllers"
        Me.LabelNumberControllers.Size = New System.Drawing.Size(262, 16)
        Me.LabelNumberControllers.TabIndex = 18
        Me.LabelNumberControllers.Text = "Number of Controllers:"
        Me.LabelNumberControllers.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewAdaptors)
        Me.PanelWait.Controls.Add(Me.Label1)
        Me.PanelWait.Location = New System.Drawing.Point(87, 122)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 495)
        Me.PanelWait.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 25)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Loading Data, Please Wait..."
        '
        'ListViewAdaptors
        '
        Me.ListViewAdaptors.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewAdaptors.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewAdaptors.ForeColor = System.Drawing.Color.Black
        Me.ListViewAdaptors.FullRowSelect = True
        Me.ListViewAdaptors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewAdaptors.LabelWrap = False
        Me.ListViewAdaptors.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewAdaptors.MultiSelect = False
        Me.ListViewAdaptors.Name = "ListViewAdaptors"
        Me.ListViewAdaptors.Size = New System.Drawing.Size(640, 495)
        Me.ListViewAdaptors.TabIndex = 78
        Me.ListViewAdaptors.UseCompatibleStateImageBehavior = False
        Me.ListViewAdaptors.View = System.Windows.Forms.View.Details
        Me.ListViewAdaptors.Visible = False
        '
        'Sound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelNumberControllers)
        Me.Controls.Add(Me.LabelControllers)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Sound"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelControllers As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelNumberControllers As System.Windows.Forms.Label
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ListViewAdaptors As System.Windows.Forms.ListView

End Class
