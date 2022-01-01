<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Services
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
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.ContextMenuStripServices = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuPause = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuContinue = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStop = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuShowDetails = New System.Windows.Forms.ToolStripMenuItem
        Me.LabelServicesDescription = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelDetails = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.LabelPathName = New System.Windows.Forms.Label
        Me.LabelDescription = New System.Windows.Forms.Label
        Me.TextBoxDescription = New System.Windows.Forms.TextBox
        Me.TextBoxPathName = New System.Windows.Forms.TextBox
        Me.PanelServices = New System.Windows.Forms.Panel
        Me.ListViewServices = New System.Windows.Forms.ListView
        Me.DisplayName = New System.Windows.Forms.ColumnHeader
        Me.StartMode = New System.Windows.Forms.ColumnHeader
        Me.State = New System.Windows.Forms.ColumnHeader
        Me.PathName = New System.Windows.Forms.ColumnHeader
        Me.Description = New System.Windows.Forms.ColumnHeader
        Me.ServiceName = New System.Windows.Forms.ColumnHeader
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripServices.SuspendLayout()
        Me.PanelServices.SuspendLayout()
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
        Me.LabelTitle.Size = New System.Drawing.Size(83, 25)
        Me.LabelTitle.TabIndex = 10
        Me.LabelTitle.Text = "Services"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Services_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'ContextMenuStripServices
        '
        Me.ContextMenuStripServices.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuStart, Me.ContextMenuPause, Me.ContextMenuContinue, Me.ContextMenuStop, Me.ContextMenuShowDetails})
        Me.ContextMenuStripServices.Name = "ContextMenuStripServices"
        Me.ContextMenuStripServices.Size = New System.Drawing.Size(142, 114)
        '
        'ContextMenuStart
        '
        Me.ContextMenuStart.Name = "ContextMenuStart"
        Me.ContextMenuStart.Size = New System.Drawing.Size(141, 22)
        Me.ContextMenuStart.Text = "Start"
        '
        'ContextMenuPause
        '
        Me.ContextMenuPause.Name = "ContextMenuPause"
        Me.ContextMenuPause.Size = New System.Drawing.Size(141, 22)
        Me.ContextMenuPause.Text = "Pause"
        '
        'ContextMenuContinue
        '
        Me.ContextMenuContinue.Name = "ContextMenuContinue"
        Me.ContextMenuContinue.Size = New System.Drawing.Size(141, 22)
        Me.ContextMenuContinue.Text = "Continue"
        '
        'ContextMenuStop
        '
        Me.ContextMenuStop.Name = "ContextMenuStop"
        Me.ContextMenuStop.Size = New System.Drawing.Size(141, 22)
        Me.ContextMenuStop.Text = "Stop"
        '
        'ContextMenuShowDetails
        '
        Me.ContextMenuShowDetails.Name = "ContextMenuShowDetails"
        Me.ContextMenuShowDetails.Size = New System.Drawing.Size(141, 22)
        Me.ContextMenuShowDetails.Text = "Show Details"
        '
        'LabelServicesDescription
        '
        Me.LabelServicesDescription.AutoSize = True
        Me.LabelServicesDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelServicesDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelServicesDescription.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelServicesDescription.Location = New System.Drawing.Point(87, 76)
        Me.LabelServicesDescription.Name = "LabelServicesDescription"
        Me.LabelServicesDescription.Size = New System.Drawing.Size(219, 17)
        Me.LabelServicesDescription.TabIndex = 9
        Me.LabelServicesDescription.Text = "Windows and Third-Party Services"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 8
        '
        'LabelDetails
        '
        Me.LabelDetails.AutoSize = True
        Me.LabelDetails.BackColor = System.Drawing.Color.Transparent
        Me.LabelDetails.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDetails.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelDetails.Location = New System.Drawing.Point(87, 460)
        Me.LabelDetails.Name = "LabelDetails"
        Me.LabelDetails.Size = New System.Drawing.Size(51, 17)
        Me.LabelDetails.TabIndex = 7
        Me.LabelDetails.Text = "Details"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(87, 484)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 5
        '
        'LabelPathName
        '
        Me.LabelPathName.BackColor = System.Drawing.Color.Transparent
        Me.LabelPathName.ForeColor = System.Drawing.Color.Black
        Me.LabelPathName.Location = New System.Drawing.Point(86, 491)
        Me.LabelPathName.Name = "LabelPathName"
        Me.LabelPathName.Size = New System.Drawing.Size(82, 15)
        Me.LabelPathName.TabIndex = 4
        Me.LabelPathName.Text = "Path:"
        '
        'LabelDescription
        '
        Me.LabelDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelDescription.ForeColor = System.Drawing.Color.Black
        Me.LabelDescription.Location = New System.Drawing.Point(86, 531)
        Me.LabelDescription.Name = "LabelDescription"
        Me.LabelDescription.Size = New System.Drawing.Size(82, 15)
        Me.LabelDescription.TabIndex = 6
        Me.LabelDescription.Text = "Description:"
        '
        'TextBoxDescription
        '
        Me.TextBoxDescription.BackColor = System.Drawing.Color.White
        Me.TextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxDescription.Location = New System.Drawing.Point(171, 531)
        Me.TextBoxDescription.Multiline = True
        Me.TextBoxDescription.Name = "TextBoxDescription"
        Me.TextBoxDescription.ReadOnly = True
        Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBoxDescription.Size = New System.Drawing.Size(558, 76)
        Me.TextBoxDescription.TabIndex = 2
        '
        'TextBoxPathName
        '
        Me.TextBoxPathName.BackColor = System.Drawing.Color.White
        Me.TextBoxPathName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxPathName.Location = New System.Drawing.Point(171, 490)
        Me.TextBoxPathName.Multiline = True
        Me.TextBoxPathName.Name = "TextBoxPathName"
        Me.TextBoxPathName.ReadOnly = True
        Me.TextBoxPathName.Size = New System.Drawing.Size(558, 37)
        Me.TextBoxPathName.TabIndex = 3
        '
        'PanelServices
        '
        Me.PanelServices.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelServices.Controls.Add(Me.ListViewServices)
        Me.PanelServices.Controls.Add(Me.LabelWait)
        Me.PanelServices.Location = New System.Drawing.Point(87, 115)
        Me.PanelServices.Name = "PanelServices"
        Me.PanelServices.Size = New System.Drawing.Size(640, 330)
        Me.PanelServices.TabIndex = 79
        '
        'ListViewServices
        '
        Me.ListViewServices.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewServices.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DisplayName, Me.StartMode, Me.State, Me.PathName, Me.Description, Me.ServiceName})
        Me.ListViewServices.ContextMenuStrip = Me.ContextMenuStripServices
        Me.ListViewServices.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewServices.ForeColor = System.Drawing.Color.Black
        Me.ListViewServices.FullRowSelect = True
        Me.ListViewServices.LabelWrap = False
        Me.ListViewServices.Location = New System.Drawing.Point(-1, -2)
        Me.ListViewServices.MultiSelect = False
        Me.ListViewServices.Name = "ListViewServices"
        Me.ListViewServices.Size = New System.Drawing.Size(640, 332)
        Me.ListViewServices.TabIndex = 1
        Me.ListViewServices.UseCompatibleStateImageBehavior = False
        Me.ListViewServices.View = System.Windows.Forms.View.Details
        Me.ListViewServices.Visible = False
        '
        'DisplayName
        '
        Me.DisplayName.Text = "Display Name"
        Me.DisplayName.Width = 286
        '
        'StartMode
        '
        Me.StartMode.Text = "Start Mode"
        Me.StartMode.Width = 86
        '
        'State
        '
        Me.State.Text = "State"
        Me.State.Width = 86
        '
        'PathName
        '
        Me.PathName.Text = "PathName"
        Me.PathName.Width = 0
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 0
        '
        'ServiceName
        '
        Me.ServiceName.Text = "Service Name"
        Me.ServiceName.Width = 150
        '
        'LabelWait
        '
        Me.LabelWait.AllowDrop = True
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 152)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 0
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AutoSize = True
        Me.ButtonCancel.Location = New System.Drawing.Point(652, 66)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Services
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.PanelServices)
        Me.Controls.Add(Me.TextBoxDescription)
        Me.Controls.Add(Me.TextBoxPathName)
        Me.Controls.Add(Me.LabelDescription)
        Me.Controls.Add(Me.LabelPathName)
        Me.Controls.Add(Me.LabelDetails)
        Me.Controls.Add(Me.LabelSeparator2)
        Me.Controls.Add(Me.LabelServicesDescription)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Services"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripServices.ResumeLayout(False)
        Me.PanelServices.ResumeLayout(False)
        Me.PanelServices.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelServicesDescription As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelDetails As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Private WithEvents LabelPathName As System.Windows.Forms.Label
    Private WithEvents LabelDescription As System.Windows.Forms.Label
    Private WithEvents TextBoxDescription As System.Windows.Forms.TextBox
    Private WithEvents TextBoxPathName As System.Windows.Forms.TextBox
    Friend WithEvents ContextMenuStripServices As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuPause As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuContinue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStop As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuShowDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelServices As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Private WithEvents ListViewServices As System.Windows.Forms.ListView
    Private WithEvents DisplayName As System.Windows.Forms.ColumnHeader
    Private WithEvents StartMode As System.Windows.Forms.ColumnHeader
    Private WithEvents State As System.Windows.Forms.ColumnHeader
    Private WithEvents PathName As System.Windows.Forms.ColumnHeader
    Private WithEvents Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents ServiceName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button

End Class
