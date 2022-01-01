<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Computer
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
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.LabelGeneral = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.LabelMemory = New System.Windows.Forms.Label
        Me.LabelSeparator2 = New System.Windows.Forms.Label
        Me.LabelBootupState = New System.Windows.Forms.Label
        Me.LabelTPDesc = New System.Windows.Forms.Label
        Me.LabelAPDesc = New System.Windows.Forms.Label
        Me.LabelTVDesc = New System.Windows.Forms.Label
        Me.LabelAVDesc = New System.Windows.Forms.Label
        Me.LabelTotalPhysical = New System.Windows.Forms.Label
        Me.LabelAvailablePhysical = New System.Windows.Forms.Label
        Me.LabelTotalVirtual = New System.Windows.Forms.Label
        Me.LabelAvailableVirtual = New System.Windows.Forms.Label
        Me.LabelUpTime = New System.Windows.Forms.Label
        Me.TimerTimeUp = New System.Windows.Forms.Timer(Me.components)
        Me.LabelUpTimeDesc = New System.Windows.Forms.Label
        Me.LabelBootupStateDesc = New System.Windows.Forms.Label
        Me.LabelStartDateTimeDescription = New System.Windows.Forms.Label
        Me.LabelStartDateTime = New System.Windows.Forms.Label
        Me.LabelTimeStats = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.ListViewComputer = New System.Windows.Forms.ListView
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWait.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Computer_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 0
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelTitle.Location = New System.Drawing.Point(87, 32)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(102, 25)
        Me.LabelTitle.TabIndex = 1
        Me.LabelTitle.Text = "Computer"
        '
        'LabelGeneral
        '
        Me.LabelGeneral.AutoSize = True
        Me.LabelGeneral.BackColor = System.Drawing.Color.Transparent
        Me.LabelGeneral.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGeneral.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelGeneral.Location = New System.Drawing.Point(87, 76)
        Me.LabelGeneral.Name = "LabelGeneral"
        Me.LabelGeneral.Size = New System.Drawing.Size(55, 17)
        Me.LabelGeneral.TabIndex = 8
        Me.LabelGeneral.Text = "General"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 7
        '
        'LabelMemory
        '
        Me.LabelMemory.AutoSize = True
        Me.LabelMemory.BackColor = System.Drawing.Color.Transparent
        Me.LabelMemory.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMemory.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelMemory.Location = New System.Drawing.Point(89, 493)
        Me.LabelMemory.Name = "LabelMemory"
        Me.LabelMemory.Size = New System.Drawing.Size(59, 17)
        Me.LabelMemory.TabIndex = 10
        Me.LabelMemory.Text = "Memory"
        '
        'LabelSeparator2
        '
        Me.LabelSeparator2.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator2.Location = New System.Drawing.Point(89, 515)
        Me.LabelSeparator2.Name = "LabelSeparator2"
        Me.LabelSeparator2.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator2.TabIndex = 9
        '
        'LabelBootupState
        '
        Me.LabelBootupState.BackColor = System.Drawing.Color.Transparent
        Me.LabelBootupState.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBootupState.ForeColor = System.Drawing.Color.Black
        Me.LabelBootupState.Location = New System.Drawing.Point(279, 425)
        Me.LabelBootupState.Name = "LabelBootupState"
        Me.LabelBootupState.Size = New System.Drawing.Size(218, 18)
        Me.LabelBootupState.TabIndex = 14
        '
        'LabelTPDesc
        '
        Me.LabelTPDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelTPDesc.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTPDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelTPDesc.Location = New System.Drawing.Point(89, 525)
        Me.LabelTPDesc.Name = "LabelTPDesc"
        Me.LabelTPDesc.Size = New System.Drawing.Size(115, 18)
        Me.LabelTPDesc.TabIndex = 15
        Me.LabelTPDesc.Text = "Total Physical"
        '
        'LabelAPDesc
        '
        Me.LabelAPDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelAPDesc.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAPDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelAPDesc.Location = New System.Drawing.Point(89, 545)
        Me.LabelAPDesc.Name = "LabelAPDesc"
        Me.LabelAPDesc.Size = New System.Drawing.Size(115, 18)
        Me.LabelAPDesc.TabIndex = 16
        Me.LabelAPDesc.Text = "Available Physical"
        '
        'LabelTVDesc
        '
        Me.LabelTVDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelTVDesc.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTVDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelTVDesc.Location = New System.Drawing.Point(89, 565)
        Me.LabelTVDesc.Name = "LabelTVDesc"
        Me.LabelTVDesc.Size = New System.Drawing.Size(115, 18)
        Me.LabelTVDesc.TabIndex = 17
        Me.LabelTVDesc.Text = "Total Virtual"
        '
        'LabelAVDesc
        '
        Me.LabelAVDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelAVDesc.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAVDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelAVDesc.Location = New System.Drawing.Point(89, 585)
        Me.LabelAVDesc.Name = "LabelAVDesc"
        Me.LabelAVDesc.Size = New System.Drawing.Size(115, 18)
        Me.LabelAVDesc.TabIndex = 18
        Me.LabelAVDesc.Text = "Available Virtual"
        '
        'LabelTotalPhysical
        '
        Me.LabelTotalPhysical.BackColor = System.Drawing.Color.Transparent
        Me.LabelTotalPhysical.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalPhysical.ForeColor = System.Drawing.Color.Black
        Me.LabelTotalPhysical.Location = New System.Drawing.Point(279, 525)
        Me.LabelTotalPhysical.Name = "LabelTotalPhysical"
        Me.LabelTotalPhysical.Size = New System.Drawing.Size(90, 18)
        Me.LabelTotalPhysical.TabIndex = 19
        '
        'LabelAvailablePhysical
        '
        Me.LabelAvailablePhysical.BackColor = System.Drawing.Color.Transparent
        Me.LabelAvailablePhysical.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAvailablePhysical.ForeColor = System.Drawing.Color.Black
        Me.LabelAvailablePhysical.Location = New System.Drawing.Point(279, 545)
        Me.LabelAvailablePhysical.Name = "LabelAvailablePhysical"
        Me.LabelAvailablePhysical.Size = New System.Drawing.Size(90, 18)
        Me.LabelAvailablePhysical.TabIndex = 20
        '
        'LabelTotalVirtual
        '
        Me.LabelTotalVirtual.BackColor = System.Drawing.Color.Transparent
        Me.LabelTotalVirtual.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalVirtual.ForeColor = System.Drawing.Color.Black
        Me.LabelTotalVirtual.Location = New System.Drawing.Point(279, 565)
        Me.LabelTotalVirtual.Name = "LabelTotalVirtual"
        Me.LabelTotalVirtual.Size = New System.Drawing.Size(90, 18)
        Me.LabelTotalVirtual.TabIndex = 21
        '
        'LabelAvailableVirtual
        '
        Me.LabelAvailableVirtual.BackColor = System.Drawing.Color.Transparent
        Me.LabelAvailableVirtual.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAvailableVirtual.ForeColor = System.Drawing.Color.Black
        Me.LabelAvailableVirtual.Location = New System.Drawing.Point(279, 585)
        Me.LabelAvailableVirtual.Name = "LabelAvailableVirtual"
        Me.LabelAvailableVirtual.Size = New System.Drawing.Size(90, 18)
        Me.LabelAvailableVirtual.TabIndex = 22
        '
        'LabelUpTime
        '
        Me.LabelUpTime.BackColor = System.Drawing.Color.Transparent
        Me.LabelUpTime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUpTime.ForeColor = System.Drawing.Color.Black
        Me.LabelUpTime.Location = New System.Drawing.Point(279, 465)
        Me.LabelUpTime.Name = "LabelUpTime"
        Me.LabelUpTime.Size = New System.Drawing.Size(218, 18)
        Me.LabelUpTime.TabIndex = 27
        '
        'TimerTimeUp
        '
        Me.TimerTimeUp.Interval = 1000
        '
        'LabelUpTimeDesc
        '
        Me.LabelUpTimeDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelUpTimeDesc.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUpTimeDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelUpTimeDesc.Location = New System.Drawing.Point(89, 465)
        Me.LabelUpTimeDesc.Name = "LabelUpTimeDesc"
        Me.LabelUpTimeDesc.Size = New System.Drawing.Size(184, 18)
        Me.LabelUpTimeDesc.TabIndex = 43
        Me.LabelUpTimeDesc.Text = "Up Time:"
        '
        'LabelBootupStateDesc
        '
        Me.LabelBootupStateDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelBootupStateDesc.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBootupStateDesc.ForeColor = System.Drawing.Color.Black
        Me.LabelBootupStateDesc.Location = New System.Drawing.Point(89, 425)
        Me.LabelBootupStateDesc.Name = "LabelBootupStateDesc"
        Me.LabelBootupStateDesc.Size = New System.Drawing.Size(184, 18)
        Me.LabelBootupStateDesc.TabIndex = 42
        Me.LabelBootupStateDesc.Text = "Bootup State:"
        '
        'LabelStartDateTimeDescription
        '
        Me.LabelStartDateTimeDescription.BackColor = System.Drawing.Color.Transparent
        Me.LabelStartDateTimeDescription.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStartDateTimeDescription.ForeColor = System.Drawing.Color.Black
        Me.LabelStartDateTimeDescription.Location = New System.Drawing.Point(89, 445)
        Me.LabelStartDateTimeDescription.Name = "LabelStartDateTimeDescription"
        Me.LabelStartDateTimeDescription.Size = New System.Drawing.Size(184, 18)
        Me.LabelStartDateTimeDescription.TabIndex = 45
        Me.LabelStartDateTimeDescription.Text = "Start Date/Time:"
        '
        'LabelStartDateTime
        '
        Me.LabelStartDateTime.BackColor = System.Drawing.Color.Transparent
        Me.LabelStartDateTime.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStartDateTime.ForeColor = System.Drawing.Color.Black
        Me.LabelStartDateTime.Location = New System.Drawing.Point(279, 445)
        Me.LabelStartDateTime.Name = "LabelStartDateTime"
        Me.LabelStartDateTime.Size = New System.Drawing.Size(218, 18)
        Me.LabelStartDateTime.TabIndex = 44
        '
        'LabelTimeStats
        '
        Me.LabelTimeStats.AutoSize = True
        Me.LabelTimeStats.BackColor = System.Drawing.Color.Transparent
        Me.LabelTimeStats.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTimeStats.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelTimeStats.Location = New System.Drawing.Point(89, 393)
        Me.LabelTimeStats.Name = "LabelTimeStats"
        Me.LabelTimeStats.Size = New System.Drawing.Size(136, 17)
        Me.LabelTimeStats.TabIndex = 48
        Me.LabelTimeStats.Text = "Startup and Up Time"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label2.Location = New System.Drawing.Point(89, 415)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(642, 3)
        Me.Label2.TabIndex = 47
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewComputer)
        Me.PanelWait.Controls.Add(Me.Label1)
        Me.PanelWait.Location = New System.Drawing.Point(87, 122)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 254)
        Me.PanelWait.TabIndex = 49
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(198, 114)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(243, 25)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Loading Data, Please Wait..."
        '
        'ListViewComputer
        '
        Me.ListViewComputer.FullRowSelect = True
        Me.ListViewComputer.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewComputer.Name = "ListViewComputer"
        Me.ListViewComputer.Size = New System.Drawing.Size(640, 254)
        Me.ListViewComputer.TabIndex = 78
        Me.ListViewComputer.UseCompatibleStateImageBehavior = False
        Me.ListViewComputer.View = System.Windows.Forms.View.Details
        Me.ListViewComputer.Visible = False
        '
        'Computer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelTimeStats)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelStartDateTimeDescription)
        Me.Controls.Add(Me.LabelStartDateTime)
        Me.Controls.Add(Me.LabelUpTimeDesc)
        Me.Controls.Add(Me.LabelBootupStateDesc)
        Me.Controls.Add(Me.LabelUpTime)
        Me.Controls.Add(Me.LabelAvailableVirtual)
        Me.Controls.Add(Me.LabelTotalVirtual)
        Me.Controls.Add(Me.LabelAvailablePhysical)
        Me.Controls.Add(Me.LabelTotalPhysical)
        Me.Controls.Add(Me.LabelAVDesc)
        Me.Controls.Add(Me.LabelTVDesc)
        Me.Controls.Add(Me.LabelAPDesc)
        Me.Controls.Add(Me.LabelTPDesc)
        Me.Controls.Add(Me.LabelBootupState)
        Me.Controls.Add(Me.LabelMemory)
        Me.Controls.Add(Me.LabelSeparator2)
        Me.Controls.Add(Me.LabelGeneral)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Computer"
        Me.Size = New System.Drawing.Size(748, 637)
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWait.ResumeLayout(False)
        Me.PanelWait.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents LabelGeneral As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents LabelMemory As System.Windows.Forms.Label
    Private WithEvents LabelSeparator2 As System.Windows.Forms.Label
    Private WithEvents LabelBootupState As System.Windows.Forms.Label
    Private WithEvents LabelTPDesc As System.Windows.Forms.Label
    Private WithEvents LabelAPDesc As System.Windows.Forms.Label
    Private WithEvents LabelTVDesc As System.Windows.Forms.Label
    Private WithEvents LabelAVDesc As System.Windows.Forms.Label
    Private WithEvents LabelTotalPhysical As System.Windows.Forms.Label
    Private WithEvents LabelAvailablePhysical As System.Windows.Forms.Label
    Private WithEvents LabelTotalVirtual As System.Windows.Forms.Label
    Private WithEvents LabelAvailableVirtual As System.Windows.Forms.Label
    Private WithEvents LabelUpTime As System.Windows.Forms.Label
    Private WithEvents TimerTimeUp As System.Windows.Forms.Timer
    Private WithEvents LabelUpTimeDesc As System.Windows.Forms.Label
    Private WithEvents LabelBootupStateDesc As System.Windows.Forms.Label
    Private WithEvents LabelStartDateTimeDescription As System.Windows.Forms.Label
    Private WithEvents LabelStartDateTime As System.Windows.Forms.Label
    Private WithEvents LabelTimeStats As System.Windows.Forms.Label
    Private WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListViewComputer As System.Windows.Forms.ListView

End Class
