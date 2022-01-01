<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnvironmentVariables
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EnvironmentVariables))
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.ImageListEnvironmentVariables = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelProcessesDescription = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListViewVariables = New System.Windows.Forms.ListView
        Me.EnvironmentVariable = New System.Windows.Forms.ColumnHeader
        Me.ExpandedVariable = New System.Windows.Forms.ColumnHeader
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
        Me.LabelTitle.Size = New System.Drawing.Size(213, 25)
        Me.LabelTitle.TabIndex = 7
        Me.LabelTitle.Text = "Environment Variables"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.CMD_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'ImageListEnvironmentVariables
        '
        Me.ImageListEnvironmentVariables.ImageStream = CType(resources.GetObject("ImageListEnvironmentVariables.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListEnvironmentVariables.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListEnvironmentVariables.Images.SetKeyName(0, "CMD_16x16.png")
        '
        'LabelProcessesDescription
        '
        Me.LabelProcessesDescription.AutoSize = True
        Me.LabelProcessesDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelProcessesDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProcessesDescription.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelProcessesDescription.Location = New System.Drawing.Point(87, 76)
        Me.LabelProcessesDescription.Name = "LabelProcessesDescription"
        Me.LabelProcessesDescription.Size = New System.Drawing.Size(637, 17)
        Me.LabelProcessesDescription.TabIndex = 50
        Me.LabelProcessesDescription.Text = "These Environment Variable can be used at the command prompt by enclosing them wi" & _
            "th % symbols."
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 49
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewVariables)
        Me.PanelWait.Controls.Add(Me.Label1)
        Me.PanelWait.Location = New System.Drawing.Point(87, 122)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 495)
        Me.PanelWait.TabIndex = 51
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
        'ListViewVariables
        '
        Me.ListViewVariables.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewVariables.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.EnvironmentVariable, Me.ExpandedVariable})
        Me.ListViewVariables.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewVariables.ForeColor = System.Drawing.Color.Black
        Me.ListViewVariables.FullRowSelect = True
        Me.ListViewVariables.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewVariables.LabelWrap = False
        Me.ListViewVariables.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewVariables.MultiSelect = False
        Me.ListViewVariables.Name = "ListViewVariables"
        Me.ListViewVariables.Size = New System.Drawing.Size(640, 495)
        Me.ListViewVariables.SmallImageList = Me.ImageListEnvironmentVariables
        Me.ListViewVariables.TabIndex = 78
        Me.ListViewVariables.UseCompatibleStateImageBehavior = False
        Me.ListViewVariables.View = System.Windows.Forms.View.Details
        Me.ListViewVariables.Visible = False
        '
        'EnvironmentVariable
        '
        Me.EnvironmentVariable.Text = "Environment Variable"
        Me.EnvironmentVariable.Width = 200
        '
        'ExpandedVariable
        '
        Me.ExpandedVariable.Text = "Expanded Variable"
        Me.ExpandedVariable.Width = 415
        '
        'EnvironmentVariables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelProcessesDescription)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "EnvironmentVariables"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelProcessesDescription As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents ImageListEnvironmentVariables As System.Windows.Forms.ImageList
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ListViewVariables As System.Windows.Forms.ListView
    Private WithEvents EnvironmentVariable As System.Windows.Forms.ColumnHeader
    Friend WithEvents ExpandedVariable As System.Windows.Forms.ColumnHeader

End Class
