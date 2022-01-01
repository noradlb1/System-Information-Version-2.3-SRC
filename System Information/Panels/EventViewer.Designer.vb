<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EventViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EventViewer))
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.LabelFolders = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.ImageListEvents = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStripEventViewer = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuShowDetails = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuRefresh = New System.Windows.Forms.ToolStripMenuItem
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.PanelEventLog = New System.Windows.Forms.Panel
        Me.RadioButtonSecurity = New System.Windows.Forms.RadioButton
        Me.RadioButtonSystem = New System.Windows.Forms.RadioButton
        Me.RadioButtonApplication = New System.Windows.Forms.RadioButton
        Me.LabelEventLog = New System.Windows.Forms.Label
        Me.PanelTypeEvents = New System.Windows.Forms.Panel
        Me.CheckBoxSuccessAudit = New System.Windows.Forms.CheckBox
        Me.CheckBoxFailureAudit = New System.Windows.Forms.CheckBox
        Me.CheckBoxError = New System.Windows.Forms.CheckBox
        Me.CheckBoxWarning = New System.Windows.Forms.CheckBox
        Me.CheckBoxInformation = New System.Windows.Forms.CheckBox
        Me.LabelEventTypes = New System.Windows.Forms.Label
        Me.PanelNumberEvents = New System.Windows.Forms.Panel
        Me.NumericUpDownEntries = New System.Windows.Forms.NumericUpDown
        Me.RadioButtonSetNumber = New System.Windows.Forms.RadioButton
        Me.RadioButton1600 = New System.Windows.Forms.RadioButton
        Me.RadioButton800 = New System.Windows.Forms.RadioButton
        Me.RadioButton400 = New System.Windows.Forms.RadioButton
        Me.RadioButton200 = New System.Windows.Forms.RadioButton
        Me.LabelChooseNumber = New System.Windows.Forms.Label
        Me.ButtonRefresh = New System.Windows.Forms.Button
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewEventViewer = New System.Windows.Forms.ListView
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripEventViewer.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.PanelEventLog.SuspendLayout()
        Me.PanelTypeEvents.SuspendLayout()
        Me.PanelNumberEvents.SuspendLayout()
        CType(Me.NumericUpDownEntries, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LabelTitle.Size = New System.Drawing.Size(127, 25)
        Me.LabelTitle.TabIndex = 5
        Me.LabelTitle.Text = "Event Viewer"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.EventViewer_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
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
        Me.LabelFolders.Size = New System.Drawing.Size(438, 17)
        Me.LabelFolders.TabIndex = 4
        Me.LabelFolders.Text = "View error, warning and informational messages from Windows logs."
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 3
        '
        'ImageListEvents
        '
        Me.ImageListEvents.ImageStream = CType(resources.GetObject("ImageListEvents.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListEvents.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListEvents.Images.SetKeyName(0, "Information.png")
        Me.ImageListEvents.Images.SetKeyName(1, "Warning.png")
        Me.ImageListEvents.Images.SetKeyName(2, "Error.png")
        Me.ImageListEvents.Images.SetKeyName(3, "AuditFailure_16x16.png")
        Me.ImageListEvents.Images.SetKeyName(4, "AuditSuccess_16x16.png")
        '
        'ContextMenuStripEventViewer
        '
        Me.ContextMenuStripEventViewer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContextMenuShowDetails, Me.ContextMenuRefresh})
        Me.ContextMenuStripEventViewer.Name = "ContextMenuStripEventViewer"
        Me.ContextMenuStripEventViewer.Size = New System.Drawing.Size(142, 48)
        '
        'ContextMenuShowDetails
        '
        Me.ContextMenuShowDetails.Name = "ContextMenuShowDetails"
        Me.ContextMenuShowDetails.Size = New System.Drawing.Size(141, 22)
        Me.ContextMenuShowDetails.Text = "Show Details"
        '
        'ContextMenuRefresh
        '
        Me.ContextMenuRefresh.Name = "ContextMenuRefresh"
        Me.ContextMenuRefresh.Size = New System.Drawing.Size(141, 22)
        Me.ContextMenuRefresh.Text = "Refresh"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.PanelEventLog, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelTypeEvents, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PanelNumberEvents, 2, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(87, 468)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 152.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(482, 152)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'PanelEventLog
        '
        Me.PanelEventLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEventLog.Controls.Add(Me.RadioButtonSecurity)
        Me.PanelEventLog.Controls.Add(Me.RadioButtonSystem)
        Me.PanelEventLog.Controls.Add(Me.RadioButtonApplication)
        Me.PanelEventLog.Controls.Add(Me.LabelEventLog)
        Me.PanelEventLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEventLog.Location = New System.Drawing.Point(3, 3)
        Me.PanelEventLog.Name = "PanelEventLog"
        Me.PanelEventLog.Size = New System.Drawing.Size(154, 146)
        Me.PanelEventLog.TabIndex = 0
        '
        'RadioButtonSecurity
        '
        Me.RadioButtonSecurity.AutoSize = True
        Me.RadioButtonSecurity.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonSecurity.Location = New System.Drawing.Point(20, 108)
        Me.RadioButtonSecurity.Name = "RadioButtonSecurity"
        Me.RadioButtonSecurity.Size = New System.Drawing.Size(71, 21)
        Me.RadioButtonSecurity.TabIndex = 3
        Me.RadioButtonSecurity.TabStop = True
        Me.RadioButtonSecurity.Text = "Security"
        Me.RadioButtonSecurity.UseVisualStyleBackColor = False
        '
        'RadioButtonSystem
        '
        Me.RadioButtonSystem.AutoSize = True
        Me.RadioButtonSystem.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonSystem.Location = New System.Drawing.Point(20, 66)
        Me.RadioButtonSystem.Name = "RadioButtonSystem"
        Me.RadioButtonSystem.Size = New System.Drawing.Size(67, 21)
        Me.RadioButtonSystem.TabIndex = 2
        Me.RadioButtonSystem.TabStop = True
        Me.RadioButtonSystem.Text = "System"
        Me.RadioButtonSystem.UseVisualStyleBackColor = False
        '
        'RadioButtonApplication
        '
        Me.RadioButtonApplication.AutoSize = True
        Me.RadioButtonApplication.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonApplication.Location = New System.Drawing.Point(20, 24)
        Me.RadioButtonApplication.Name = "RadioButtonApplication"
        Me.RadioButtonApplication.Size = New System.Drawing.Size(91, 21)
        Me.RadioButtonApplication.TabIndex = 1
        Me.RadioButtonApplication.TabStop = True
        Me.RadioButtonApplication.Text = "Application"
        Me.RadioButtonApplication.UseVisualStyleBackColor = False
        '
        'LabelEventLog
        '
        Me.LabelEventLog.AutoSize = True
        Me.LabelEventLog.BackColor = System.Drawing.Color.Transparent
        Me.LabelEventLog.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEventLog.Location = New System.Drawing.Point(48, 5)
        Me.LabelEventLog.Name = "LabelEventLog"
        Me.LabelEventLog.Size = New System.Drawing.Size(59, 15)
        Me.LabelEventLog.TabIndex = 0
        Me.LabelEventLog.Text = "Event Log"
        Me.LabelEventLog.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PanelTypeEvents
        '
        Me.PanelTypeEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelTypeEvents.Controls.Add(Me.CheckBoxSuccessAudit)
        Me.PanelTypeEvents.Controls.Add(Me.CheckBoxFailureAudit)
        Me.PanelTypeEvents.Controls.Add(Me.CheckBoxError)
        Me.PanelTypeEvents.Controls.Add(Me.CheckBoxWarning)
        Me.PanelTypeEvents.Controls.Add(Me.CheckBoxInformation)
        Me.PanelTypeEvents.Controls.Add(Me.LabelEventTypes)
        Me.PanelTypeEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelTypeEvents.Location = New System.Drawing.Point(163, 3)
        Me.PanelTypeEvents.Name = "PanelTypeEvents"
        Me.PanelTypeEvents.Size = New System.Drawing.Size(154, 146)
        Me.PanelTypeEvents.TabIndex = 1
        '
        'CheckBoxSuccessAudit
        '
        Me.CheckBoxSuccessAudit.AutoSize = True
        Me.CheckBoxSuccessAudit.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxSuccessAudit.Location = New System.Drawing.Point(20, 108)
        Me.CheckBoxSuccessAudit.Name = "CheckBoxSuccessAudit"
        Me.CheckBoxSuccessAudit.Size = New System.Drawing.Size(106, 21)
        Me.CheckBoxSuccessAudit.TabIndex = 5
        Me.CheckBoxSuccessAudit.Text = "Success Audit"
        Me.CheckBoxSuccessAudit.UseVisualStyleBackColor = False
        '
        'CheckBoxFailureAudit
        '
        Me.CheckBoxFailureAudit.AutoSize = True
        Me.CheckBoxFailureAudit.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxFailureAudit.Location = New System.Drawing.Point(20, 87)
        Me.CheckBoxFailureAudit.Name = "CheckBoxFailureAudit"
        Me.CheckBoxFailureAudit.Size = New System.Drawing.Size(99, 21)
        Me.CheckBoxFailureAudit.TabIndex = 4
        Me.CheckBoxFailureAudit.Text = "Failure Audit"
        Me.CheckBoxFailureAudit.UseVisualStyleBackColor = False
        '
        'CheckBoxError
        '
        Me.CheckBoxError.AutoSize = True
        Me.CheckBoxError.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxError.Location = New System.Drawing.Point(20, 66)
        Me.CheckBoxError.Name = "CheckBoxError"
        Me.CheckBoxError.Size = New System.Drawing.Size(57, 21)
        Me.CheckBoxError.TabIndex = 3
        Me.CheckBoxError.Text = "Error"
        Me.CheckBoxError.UseVisualStyleBackColor = False
        '
        'CheckBoxWarning
        '
        Me.CheckBoxWarning.AutoSize = True
        Me.CheckBoxWarning.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxWarning.Location = New System.Drawing.Point(20, 45)
        Me.CheckBoxWarning.Name = "CheckBoxWarning"
        Me.CheckBoxWarning.Size = New System.Drawing.Size(76, 21)
        Me.CheckBoxWarning.TabIndex = 2
        Me.CheckBoxWarning.Text = "Warning"
        Me.CheckBoxWarning.UseVisualStyleBackColor = False
        '
        'CheckBoxInformation
        '
        Me.CheckBoxInformation.AutoSize = True
        Me.CheckBoxInformation.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxInformation.Location = New System.Drawing.Point(20, 24)
        Me.CheckBoxInformation.Name = "CheckBoxInformation"
        Me.CheckBoxInformation.Size = New System.Drawing.Size(94, 21)
        Me.CheckBoxInformation.TabIndex = 1
        Me.CheckBoxInformation.Text = "Information"
        Me.CheckBoxInformation.UseVisualStyleBackColor = False
        '
        'LabelEventTypes
        '
        Me.LabelEventTypes.AutoSize = True
        Me.LabelEventTypes.BackColor = System.Drawing.Color.Transparent
        Me.LabelEventTypes.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelEventTypes.Location = New System.Drawing.Point(42, 5)
        Me.LabelEventTypes.Name = "LabelEventTypes"
        Me.LabelEventTypes.Size = New System.Drawing.Size(70, 15)
        Me.LabelEventTypes.TabIndex = 0
        Me.LabelEventTypes.Text = "Event Types"
        '
        'PanelNumberEvents
        '
        Me.PanelNumberEvents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelNumberEvents.Controls.Add(Me.NumericUpDownEntries)
        Me.PanelNumberEvents.Controls.Add(Me.RadioButtonSetNumber)
        Me.PanelNumberEvents.Controls.Add(Me.RadioButton1600)
        Me.PanelNumberEvents.Controls.Add(Me.RadioButton800)
        Me.PanelNumberEvents.Controls.Add(Me.RadioButton400)
        Me.PanelNumberEvents.Controls.Add(Me.RadioButton200)
        Me.PanelNumberEvents.Controls.Add(Me.LabelChooseNumber)
        Me.PanelNumberEvents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelNumberEvents.Location = New System.Drawing.Point(323, 3)
        Me.PanelNumberEvents.Name = "PanelNumberEvents"
        Me.PanelNumberEvents.Size = New System.Drawing.Size(156, 146)
        Me.PanelNumberEvents.TabIndex = 2
        '
        'NumericUpDownEntries
        '
        Me.NumericUpDownEntries.Location = New System.Drawing.Point(90, 106)
        Me.NumericUpDownEntries.Maximum = New Decimal(New Integer() {30000, 0, 0, 0})
        Me.NumericUpDownEntries.Name = "NumericUpDownEntries"
        Me.NumericUpDownEntries.Size = New System.Drawing.Size(58, 25)
        Me.NumericUpDownEntries.TabIndex = 6
        Me.NumericUpDownEntries.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RadioButtonSetNumber
        '
        Me.RadioButtonSetNumber.AutoSize = True
        Me.RadioButtonSetNumber.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonSetNumber.Location = New System.Drawing.Point(20, 108)
        Me.RadioButtonSetNumber.Name = "RadioButtonSetNumber"
        Me.RadioButtonSetNumber.Size = New System.Drawing.Size(59, 21)
        Me.RadioButtonSetNumber.TabIndex = 5
        Me.RadioButtonSetNumber.TabStop = True
        Me.RadioButtonSetNumber.Text = "Enter:"
        Me.RadioButtonSetNumber.UseVisualStyleBackColor = False
        '
        'RadioButton1600
        '
        Me.RadioButton1600.AutoSize = True
        Me.RadioButton1600.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1600.Location = New System.Drawing.Point(20, 87)
        Me.RadioButton1600.Name = "RadioButton1600"
        Me.RadioButton1600.Size = New System.Drawing.Size(54, 21)
        Me.RadioButton1600.TabIndex = 4
        Me.RadioButton1600.TabStop = True
        Me.RadioButton1600.Text = "1600"
        Me.RadioButton1600.UseVisualStyleBackColor = False
        '
        'RadioButton800
        '
        Me.RadioButton800.AutoSize = True
        Me.RadioButton800.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton800.Location = New System.Drawing.Point(20, 66)
        Me.RadioButton800.Name = "RadioButton800"
        Me.RadioButton800.Size = New System.Drawing.Size(47, 21)
        Me.RadioButton800.TabIndex = 3
        Me.RadioButton800.TabStop = True
        Me.RadioButton800.Text = "800"
        Me.RadioButton800.UseVisualStyleBackColor = False
        '
        'RadioButton400
        '
        Me.RadioButton400.AutoSize = True
        Me.RadioButton400.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton400.Location = New System.Drawing.Point(20, 45)
        Me.RadioButton400.Name = "RadioButton400"
        Me.RadioButton400.Size = New System.Drawing.Size(47, 21)
        Me.RadioButton400.TabIndex = 2
        Me.RadioButton400.TabStop = True
        Me.RadioButton400.Text = "400"
        Me.RadioButton400.UseVisualStyleBackColor = False
        '
        'RadioButton200
        '
        Me.RadioButton200.AutoSize = True
        Me.RadioButton200.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton200.Location = New System.Drawing.Point(20, 24)
        Me.RadioButton200.Name = "RadioButton200"
        Me.RadioButton200.Size = New System.Drawing.Size(47, 21)
        Me.RadioButton200.TabIndex = 1
        Me.RadioButton200.TabStop = True
        Me.RadioButton200.Text = "200"
        Me.RadioButton200.UseVisualStyleBackColor = False
        '
        'LabelChooseNumber
        '
        Me.LabelChooseNumber.AutoSize = True
        Me.LabelChooseNumber.BackColor = System.Drawing.Color.Transparent
        Me.LabelChooseNumber.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelChooseNumber.Location = New System.Drawing.Point(27, 5)
        Me.LabelChooseNumber.Name = "LabelChooseNumber"
        Me.LabelChooseNumber.Size = New System.Drawing.Size(102, 15)
        Me.LabelChooseNumber.TabIndex = 0
        Me.LabelChooseNumber.Text = "Number of Events"
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.AutoSize = True
        Me.ButtonRefresh.Location = New System.Drawing.Point(652, 468)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(75, 27)
        Me.ButtonRefresh.TabIndex = 1
        Me.ButtonRefresh.Text = "&Refresh"
        Me.ButtonRefresh.UseVisualStyleBackColor = True
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewEventViewer)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 115)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 332)
        Me.PanelWait.TabIndex = 72
        '
        'ListViewEventViewer
        '
        Me.ListViewEventViewer.ContextMenuStrip = Me.ContextMenuStripEventViewer
        Me.ListViewEventViewer.FullRowSelect = True
        Me.ListViewEventViewer.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewEventViewer.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewEventViewer.MultiSelect = False
        Me.ListViewEventViewer.Name = "ListViewEventViewer"
        Me.ListViewEventViewer.Size = New System.Drawing.Size(640, 332)
        Me.ListViewEventViewer.SmallImageList = Me.ImageListEvents
        Me.ListViewEventViewer.TabIndex = 0
        Me.ListViewEventViewer.UseCompatibleStateImageBehavior = False
        Me.ListViewEventViewer.View = System.Windows.Forms.View.Details
        '
        'LabelWait
        '
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(176, 153)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(286, 25)
        Me.LabelWait.TabIndex = 1
        Me.LabelWait.Text = "Loading Event Log, Please Wait..."
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AutoSize = True
        Me.ButtonCancel.Location = New System.Drawing.Point(652, 513)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'EventViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.ButtonRefresh)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "EventViewer"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripEventViewer.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.PanelEventLog.ResumeLayout(False)
        Me.PanelEventLog.PerformLayout()
        Me.PanelTypeEvents.ResumeLayout(False)
        Me.PanelTypeEvents.PerformLayout()
        Me.PanelNumberEvents.ResumeLayout(False)
        Me.PanelNumberEvents.PerformLayout()
        CType(Me.NumericUpDownEntries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelFolders As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents ImageListEvents As System.Windows.Forms.ImageList
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PanelEventLog As System.Windows.Forms.Panel
    Friend WithEvents PanelTypeEvents As System.Windows.Forms.Panel
    Friend WithEvents PanelNumberEvents As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonSecurity As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonSystem As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonApplication As System.Windows.Forms.RadioButton
    Friend WithEvents LabelEventLog As System.Windows.Forms.Label
    Friend WithEvents CheckBoxSuccessAudit As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxFailureAudit As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxError As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxWarning As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInformation As System.Windows.Forms.CheckBox
    Friend WithEvents LabelEventTypes As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownEntries As System.Windows.Forms.NumericUpDown
    Friend WithEvents RadioButtonSetNumber As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1600 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton800 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton400 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton200 As System.Windows.Forms.RadioButton
    Friend WithEvents LabelChooseNumber As System.Windows.Forms.Label
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStripEventViewer As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ContextMenuShowDetails As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Friend WithEvents ListViewEventViewer As System.Windows.Forms.ListView
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button

End Class
