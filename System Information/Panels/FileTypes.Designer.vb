<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FileTypes
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
        Me.LabelFolders = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.ImageListFileTypes = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelNumberFileTypes = New System.Windows.Forms.Label
        Me.PanelWait = New System.Windows.Forms.Panel
        Me.ListViewFileTypes = New System.Windows.Forms.ListView
        Me.FileType = New System.Windows.Forms.ColumnHeader
        Me.Description = New System.Windows.Forms.ColumnHeader
        Me.ContentType = New System.Windows.Forms.ColumnHeader
        Me.PerceivedType = New System.Windows.Forms.ColumnHeader
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
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
        Me.LabelTitle.Size = New System.Drawing.Size(98, 25)
        Me.LabelTitle.TabIndex = 3
        Me.LabelTitle.Text = "File Types"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.FileTypes_48x48
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
        Me.LabelFolders.Size = New System.Drawing.Size(200, 17)
        Me.LabelFolders.TabIndex = 2
        Me.LabelFolders.Text = "Windows Registered File Types"
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
        'ImageListFileTypes
        '
        Me.ImageListFileTypes.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.ImageListFileTypes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageListFileTypes.TransparentColor = System.Drawing.Color.Transparent
        '
        'LabelNumberFileTypes
        '
        Me.LabelNumberFileTypes.AutoEllipsis = True
        Me.LabelNumberFileTypes.Location = New System.Drawing.Point(426, 77)
        Me.LabelNumberFileTypes.Name = "LabelNumberFileTypes"
        Me.LabelNumberFileTypes.Size = New System.Drawing.Size(179, 16)
        Me.LabelNumberFileTypes.TabIndex = 4
        Me.LabelNumberFileTypes.Text = "Registered File Types"
        Me.LabelNumberFileTypes.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'PanelWait
        '
        Me.PanelWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWait.Controls.Add(Me.ListViewFileTypes)
        Me.PanelWait.Controls.Add(Me.LabelWait)
        Me.PanelWait.Location = New System.Drawing.Point(87, 122)
        Me.PanelWait.Name = "PanelWait"
        Me.PanelWait.Size = New System.Drawing.Size(640, 495)
        Me.PanelWait.TabIndex = 37
        '
        'ListViewFileTypes
        '
        Me.ListViewFileTypes.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.FileType, Me.Description, Me.ContentType, Me.PerceivedType})
        Me.ListViewFileTypes.FullRowSelect = True
        Me.ListViewFileTypes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListViewFileTypes.Location = New System.Drawing.Point(-1, -1)
        Me.ListViewFileTypes.MultiSelect = False
        Me.ListViewFileTypes.Name = "ListViewFileTypes"
        Me.ListViewFileTypes.Size = New System.Drawing.Size(640, 495)
        Me.ListViewFileTypes.SmallImageList = Me.ImageListFileTypes
        Me.ListViewFileTypes.TabIndex = 0
        Me.ListViewFileTypes.UseCompatibleStateImageBehavior = False
        Me.ListViewFileTypes.View = System.Windows.Forms.View.Details
        Me.ListViewFileTypes.Visible = False
        '
        'FileType
        '
        Me.FileType.Text = "File Type"
        Me.FileType.Width = 90
        '
        'Description
        '
        Me.Description.Text = "Description"
        Me.Description.Width = 240
        '
        'ContentType
        '
        Me.ContentType.Text = "Content Type"
        Me.ContentType.Width = 180
        '
        'PerceivedType
        '
        Me.PerceivedType.Text = "Perceived Type"
        Me.PerceivedType.Width = 100
        '
        'LabelWait
        '
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(198, 234)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 1
        Me.LabelWait.Text = "Loading Data, Please Wait..."
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AutoSize = True
        Me.ButtonCancel.Location = New System.Drawing.Point(652, 66)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCancel.TabIndex = 0
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'FileTypes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.PanelWait)
        Me.Controls.Add(Me.LabelNumberFileTypes)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "FileTypes"
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
    Friend WithEvents ImageListFileTypes As System.Windows.Forms.ImageList
    Friend WithEvents LabelNumberFileTypes As System.Windows.Forms.Label
    Friend WithEvents PanelWait As System.Windows.Forms.Panel
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Friend WithEvents ListViewFileTypes As System.Windows.Forms.ListView
    Friend WithEvents FileType As System.Windows.Forms.ColumnHeader
    Friend WithEvents Description As System.Windows.Forms.ColumnHeader
    Friend WithEvents ContentType As System.Windows.Forms.ColumnHeader
    Friend WithEvents PerceivedType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button

End Class
