﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SpecialFolders
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
        Me.ListViewFolders = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.LabelHint = New System.Windows.Forms.Label
        Me.LabelWait = New System.Windows.Forms.Label
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LabelTitle.Size = New System.Drawing.Size(144, 25)
        Me.LabelTitle.TabIndex = 7
        Me.LabelTitle.Text = "Special Folders"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.SpecialFolder_48x48
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
        Me.LabelFolders.Size = New System.Drawing.Size(161, 17)
        Me.LabelFolders.TabIndex = 32
        Me.LabelFolders.Text = "Windows Special Folders"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 31
        '
        'ListViewFolders
        '
        Me.ListViewFolders.BackColor = System.Drawing.SystemColors.Window
        Me.ListViewFolders.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.ListViewFolders.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListViewFolders.ForeColor = System.Drawing.Color.Black
        Me.ListViewFolders.FullRowSelect = True
        Me.ListViewFolders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFolders.LabelWrap = False
        Me.ListViewFolders.Location = New System.Drawing.Point(87, 122)
        Me.ListViewFolders.MultiSelect = False
        Me.ListViewFolders.Name = "ListViewFolders"
        Me.ListViewFolders.Size = New System.Drawing.Size(640, 495)
        Me.ListViewFolders.TabIndex = 47
        Me.ListViewFolders.UseCompatibleStateImageBehavior = False
        Me.ListViewFolders.View = System.Windows.Forms.View.Details
        Me.ListViewFolders.Visible = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Special Folder Name"
        Me.ColumnHeader1.Width = 140
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Path"
        Me.ColumnHeader2.Width = 475
        '
        'LabelHint
        '
        Me.LabelHint.AutoSize = True
        Me.LabelHint.BackColor = System.Drawing.Color.Transparent
        Me.LabelHint.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHint.Location = New System.Drawing.Point(553, 80)
        Me.LabelHint.Name = "LabelHint"
        Me.LabelHint.Size = New System.Drawing.Size(176, 13)
        Me.LabelHint.TabIndex = 48
        Me.LabelHint.Text = "(Click to copy path to Clipboard.)"
        '
        'LabelWait
        '
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(286, 357)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 76
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'SpecialFolders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.LabelHint)
        Me.Controls.Add(Me.ListViewFolders)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Controls.Add(Me.LabelWait)
        Me.Name = "SpecialFolders"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelFolders As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents ListViewFolders As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents LabelHint As System.Windows.Forms.Label
    Friend WithEvents LabelWait As System.Windows.Forms.Label

End Class
