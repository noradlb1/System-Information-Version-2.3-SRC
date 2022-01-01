<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Processes
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
        Me.ContextMenuStripProcesses = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuEndProcess = New System.Windows.Forms.ToolStripMenuItem
        Me.LabelProcessesDescription = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelTotalProcesses = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewProcesses = New System.Windows.Forms.ListView
        Me.Process = New System.Windows.Forms.ColumnHeader
        Me.PID = New System.Windows.Forms.ColumnHeader
        Me.Threads = New System.Windows.Forms.ColumnHeader
        Me.BasePriority = New System.Windows.Forms.ColumnHeader
        Me.Memory = New System.Windows.Forms.ColumnHeader
        Me.StartTime = New System.Windows.Forms.ColumnHeader
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripProcesses.SuspendLayout()
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
        Me.LabelTitle.Size = New System.Drawing.Size(97, 25)
        Me.LabelTitle.TabIndex = 4
        Me.LabelTitle.Text = "Processes"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Processes_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'ContextMenuStripProcesses
        '
        Me.ContextMenuStripProcesses.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuEndProcess})
        Me.ContextMenuStripProcesses.Name = "ContextMenuStripProcesses"
        Me.ContextMenuStripProcesses.Size = New System.Drawing.Size(138, 26)
        '
        'MenuEndProcess
        '
        Me.MenuEndProcess.Name = "MenuEndProcess"
        Me.MenuEndProcess.Size = New System.Drawing.Size(137, 22)
        Me.MenuEndProcess.Text = "End Process"
        '
        'LabelProcessesDescription
        '
        Me.LabelProcessesDescription.AutoSize = True
        Me.LabelProcessesDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelProcessesDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProcessesDescription.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelProcessesDescription.Location = New System.Drawing.Point(87, 76)
        Me.LabelProcessesDescription.Name = "LabelProcessesDescription"
        Me.LabelProcessesDescription.Size = New System.Drawing.Size(186, 17)
        Me.LabelProcessesDescription.TabIndex = 2
        Me.LabelProcessesDescription.Text = "Windows and User Processes"
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
        'LabelTotalProcesses
        '
        Me.LabelTotalProcesses.BackColor = System.Drawing.Color.Transparent
        Me.LabelTotalProcesses.Location = New System.Drawing.Point(360, 77)
        Me.LabelTotalProcesses.Name = "LabelTotalProcesses"
        Me.LabelTotalProcesses.Size = New System.Drawing.Size(178, 16)
        Me.LabelTotalProcesses.TabIndex = 3
        Me.LabelTotalProcesses.Text = "Total Processes"
        Me.LabelTotalProcesses.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewProcesses)
        Me.PanelWait.Controls.Add(Me.Label1)
        Me.PanelWait.Location = New System.Drawing.Point(87, 115)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 495)
        Me.PanelWait.TabIndex = 54
        '
        'ListViewProcesses
        '
        Me.ListViewProcesses.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewProcesses.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Process, Me.PID, Me.Threads, Me.BasePriority, Me.Memory, Me.StartTime})
        Me.ListViewProcesses.ContextMenuStrip = Me.ContextMenuStripProcesses
        Me.ListViewProcesses.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewProcesses.ForeColor = System.Drawing.Color.Black
        Me.ListViewProcesses.FullRowSelect = True
        Me.ListViewProcesses.LabelWrap = False
        Me.ListViewProcesses.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewProcesses.MultiSelect = False
        Me.ListViewProcesses.Name = "ListViewProcesses"
        Me.ListViewProcesses.Size = New System.Drawing.Size(640, 495)
        Me.ListViewProcesses.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.ListViewProcesses.TabIndex = 1
        Me.ListViewProcesses.UseCompatibleStateImageBehavior = False
        Me.ListViewProcesses.View = System.Windows.Forms.View.Details
        Me.ListViewProcesses.Visible = False
        '
        'Process
        '
        Me.Process.Text = "Process"
        Me.Process.Width = 170
        '
        'PID
        '
        Me.PID.Text = "PID"
        '
        'Threads
        '
        Me.Threads.Text = "Threads"
        '
        'BasePriority
        '
        Me.BasePriority.Text = "Base Priority"
        Me.BasePriority.Width = 120
        '
        'Memory
        '
        Me.Memory.Text = "Memory"
        Me.Memory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Memory.Width = 100
        '
        'StartTime
        '
        Me.StartTime.Text = "Start Time"
        Me.StartTime.Width = 100
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 25)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Loading Data, Please Wait..."
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AutoSize = True
        Me.ButtonCancel.Location = New System.Drawing.Point(654, 66)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Processes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelProcessesDescription)
        Me.Controls.Add(Me.LabelTotalProcesses)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Processes"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripProcesses.ResumeLayout(False)
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelProcessesDescription As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents LabelTotalProcesses As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStripProcesses As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuEndProcess As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents ListViewProcesses As System.Windows.Forms.ListView
    Private WithEvents Process As System.Windows.Forms.ColumnHeader
    Private WithEvents PID As System.Windows.Forms.ColumnHeader
    Private WithEvents Threads As System.Windows.Forms.ColumnHeader
    Private WithEvents BasePriority As System.Windows.Forms.ColumnHeader
    Friend WithEvents Memory As System.Windows.Forms.ColumnHeader
    Friend WithEvents StartTime As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button

End Class
