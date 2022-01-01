<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Video
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelQuatnernaryScreenWorkingArea = New System.Windows.Forms.Label
        Me.LabelQuatnernaryScreenDimensions = New System.Windows.Forms.Label
        Me.LabelTertiaryScreenWorkingArea = New System.Windows.Forms.Label
        Me.LabelTertiaryScreenDimensions = New System.Windows.Forms.Label
        Me.LabelSecondaryScreenWorkingArea = New System.Windows.Forms.Label
        Me.LabelSecondaryScreenDimensions = New System.Windows.Forms.Label
        Me.LabelPrimaryScreenWorkingArea = New System.Windows.Forms.Label
        Me.LabelPrimaryScreenDimensions = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ListViewAdaptors = New System.Windows.Forms.ListView
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
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
        Me.LabelTitle.Size = New System.Drawing.Size(64, 25)
        Me.LabelTitle.TabIndex = 7
        Me.LabelTitle.Text = "Video"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Video_48x48
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
        Me.LabelControllers.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControllers.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelControllers.Location = New System.Drawing.Point(87, 76)
        Me.LabelControllers.Name = "LabelControllers"
        Me.LabelControllers.Size = New System.Drawing.Size(76, 17)
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
        Me.LabelSeparator.Size = New System.Drawing.Size(640, 3)
        Me.LabelSeparator.TabIndex = 14
        '
        'LabelNumberControllers
        '
        Me.LabelNumberControllers.AutoEllipsis = True
        Me.LabelNumberControllers.BackColor = System.Drawing.Color.Transparent
        Me.LabelNumberControllers.ForeColor = System.Drawing.Color.Black
        Me.LabelNumberControllers.Location = New System.Drawing.Point(468, 76)
        Me.LabelNumberControllers.Name = "LabelNumberControllers"
        Me.LabelNumberControllers.Size = New System.Drawing.Size(252, 16)
        Me.LabelNumberControllers.TabIndex = 16
        Me.LabelNumberControllers.Text = "Number of Controllers"
        Me.LabelNumberControllers.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LabelQuatnernaryScreenWorkingArea)
        Me.Panel1.Controls.Add(Me.LabelQuatnernaryScreenDimensions)
        Me.Panel1.Controls.Add(Me.LabelTertiaryScreenWorkingArea)
        Me.Panel1.Controls.Add(Me.LabelTertiaryScreenDimensions)
        Me.Panel1.Controls.Add(Me.LabelSecondaryScreenWorkingArea)
        Me.Panel1.Controls.Add(Me.LabelSecondaryScreenDimensions)
        Me.Panel1.Controls.Add(Me.LabelPrimaryScreenWorkingArea)
        Me.Panel1.Controls.Add(Me.LabelPrimaryScreenDimensions)
        Me.Panel1.Location = New System.Drawing.Point(87, 114)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(640, 131)
        Me.Panel1.TabIndex = 27
        '
        'LabelQuatnernaryScreenWorkingArea
        '
        Me.LabelQuatnernaryScreenWorkingArea.AutoEllipsis = True
        Me.LabelQuatnernaryScreenWorkingArea.BackColor = System.Drawing.Color.Transparent
        Me.LabelQuatnernaryScreenWorkingArea.ForeColor = System.Drawing.Color.Black
        Me.LabelQuatnernaryScreenWorkingArea.Location = New System.Drawing.Point(328, 89)
        Me.LabelQuatnernaryScreenWorkingArea.Name = "LabelQuatnernaryScreenWorkingArea"
        Me.LabelQuatnernaryScreenWorkingArea.Size = New System.Drawing.Size(275, 17)
        Me.LabelQuatnernaryScreenWorkingArea.TabIndex = 34
        '
        'LabelQuatnernaryScreenDimensions
        '
        Me.LabelQuatnernaryScreenDimensions.AutoEllipsis = True
        Me.LabelQuatnernaryScreenDimensions.BackColor = System.Drawing.Color.Transparent
        Me.LabelQuatnernaryScreenDimensions.ForeColor = System.Drawing.Color.Black
        Me.LabelQuatnernaryScreenDimensions.Location = New System.Drawing.Point(328, 69)
        Me.LabelQuatnernaryScreenDimensions.Name = "LabelQuatnernaryScreenDimensions"
        Me.LabelQuatnernaryScreenDimensions.Size = New System.Drawing.Size(275, 17)
        Me.LabelQuatnernaryScreenDimensions.TabIndex = 33
        '
        'LabelTertiaryScreenWorkingArea
        '
        Me.LabelTertiaryScreenWorkingArea.AutoEllipsis = True
        Me.LabelTertiaryScreenWorkingArea.BackColor = System.Drawing.Color.Transparent
        Me.LabelTertiaryScreenWorkingArea.ForeColor = System.Drawing.Color.Black
        Me.LabelTertiaryScreenWorkingArea.Location = New System.Drawing.Point(17, 89)
        Me.LabelTertiaryScreenWorkingArea.Name = "LabelTertiaryScreenWorkingArea"
        Me.LabelTertiaryScreenWorkingArea.Size = New System.Drawing.Size(275, 17)
        Me.LabelTertiaryScreenWorkingArea.TabIndex = 32
        '
        'LabelTertiaryScreenDimensions
        '
        Me.LabelTertiaryScreenDimensions.AutoEllipsis = True
        Me.LabelTertiaryScreenDimensions.BackColor = System.Drawing.Color.Transparent
        Me.LabelTertiaryScreenDimensions.ForeColor = System.Drawing.Color.Black
        Me.LabelTertiaryScreenDimensions.Location = New System.Drawing.Point(17, 69)
        Me.LabelTertiaryScreenDimensions.Name = "LabelTertiaryScreenDimensions"
        Me.LabelTertiaryScreenDimensions.Size = New System.Drawing.Size(275, 17)
        Me.LabelTertiaryScreenDimensions.TabIndex = 31
        '
        'LabelSecondaryScreenWorkingArea
        '
        Me.LabelSecondaryScreenWorkingArea.AutoEllipsis = True
        Me.LabelSecondaryScreenWorkingArea.BackColor = System.Drawing.Color.Transparent
        Me.LabelSecondaryScreenWorkingArea.ForeColor = System.Drawing.Color.Black
        Me.LabelSecondaryScreenWorkingArea.Location = New System.Drawing.Point(328, 45)
        Me.LabelSecondaryScreenWorkingArea.Name = "LabelSecondaryScreenWorkingArea"
        Me.LabelSecondaryScreenWorkingArea.Size = New System.Drawing.Size(275, 17)
        Me.LabelSecondaryScreenWorkingArea.TabIndex = 30
        '
        'LabelSecondaryScreenDimensions
        '
        Me.LabelSecondaryScreenDimensions.AutoEllipsis = True
        Me.LabelSecondaryScreenDimensions.BackColor = System.Drawing.Color.Transparent
        Me.LabelSecondaryScreenDimensions.ForeColor = System.Drawing.Color.Black
        Me.LabelSecondaryScreenDimensions.Location = New System.Drawing.Point(328, 25)
        Me.LabelSecondaryScreenDimensions.Name = "LabelSecondaryScreenDimensions"
        Me.LabelSecondaryScreenDimensions.Size = New System.Drawing.Size(275, 17)
        Me.LabelSecondaryScreenDimensions.TabIndex = 29
        '
        'LabelPrimaryScreenWorkingArea
        '
        Me.LabelPrimaryScreenWorkingArea.AutoEllipsis = True
        Me.LabelPrimaryScreenWorkingArea.BackColor = System.Drawing.Color.Transparent
        Me.LabelPrimaryScreenWorkingArea.ForeColor = System.Drawing.Color.Black
        Me.LabelPrimaryScreenWorkingArea.Location = New System.Drawing.Point(17, 45)
        Me.LabelPrimaryScreenWorkingArea.Name = "LabelPrimaryScreenWorkingArea"
        Me.LabelPrimaryScreenWorkingArea.Size = New System.Drawing.Size(275, 17)
        Me.LabelPrimaryScreenWorkingArea.TabIndex = 28
        '
        'LabelPrimaryScreenDimensions
        '
        Me.LabelPrimaryScreenDimensions.AutoEllipsis = True
        Me.LabelPrimaryScreenDimensions.BackColor = System.Drawing.Color.Transparent
        Me.LabelPrimaryScreenDimensions.ForeColor = System.Drawing.Color.Black
        Me.LabelPrimaryScreenDimensions.Location = New System.Drawing.Point(17, 25)
        Me.LabelPrimaryScreenDimensions.Name = "LabelPrimaryScreenDimensions"
        Me.LabelPrimaryScreenDimensions.Size = New System.Drawing.Size(275, 17)
        Me.LabelPrimaryScreenDimensions.TabIndex = 27
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewAdaptors)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 258)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 346)
        Me.PanelWait.TabIndex = 28
        '
        'LabelWait
        '
        Me.LabelWait.AllowDrop = True
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 160)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 77
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'ListViewAdaptors
        '
        Me.ListViewAdaptors.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewAdaptors.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewAdaptors.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ListViewAdaptors.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewAdaptors.LabelWrap = False
        Me.ListViewAdaptors.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewAdaptors.MultiSelect = False
        Me.ListViewAdaptors.Name = "ListViewAdaptors"
        Me.ListViewAdaptors.Size = New System.Drawing.Size(640, 346)
        Me.ListViewAdaptors.TabIndex = 78
        Me.ListViewAdaptors.UseCompatibleStateImageBehavior = False
        Me.ListViewAdaptors.View = System.Windows.Forms.View.Details
        Me.ListViewAdaptors.Visible = False
        '
        'Video
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LabelNumberControllers)
        Me.Controls.Add(Me.LabelControllers)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Video"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents LabelQuatnernaryScreenWorkingArea As System.Windows.Forms.Label
    Private WithEvents LabelQuatnernaryScreenDimensions As System.Windows.Forms.Label
    Private WithEvents LabelTertiaryScreenWorkingArea As System.Windows.Forms.Label
    Private WithEvents LabelTertiaryScreenDimensions As System.Windows.Forms.Label
    Private WithEvents LabelSecondaryScreenWorkingArea As System.Windows.Forms.Label
    Private WithEvents LabelSecondaryScreenDimensions As System.Windows.Forms.Label
    Private WithEvents LabelPrimaryScreenWorkingArea As System.Windows.Forms.Label
    Private WithEvents LabelPrimaryScreenDimensions As System.Windows.Forms.Label
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Private WithEvents ListViewAdaptors As System.Windows.Forms.ListView

End Class
