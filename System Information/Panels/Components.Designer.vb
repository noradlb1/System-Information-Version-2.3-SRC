<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Component
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Component))
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox
        Me.LabelFolders = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.ListViewComponents = New System.Windows.Forms.ListView
        Me.ComponentValue = New System.Windows.Forms.ColumnHeader
        Me.ComponentName = New System.Windows.Forms.ColumnHeader
        Me.Version = New System.Windows.Forms.ColumnHeader
        Me.Locale = New System.Windows.Forms.ColumnHeader
        Me.StubPath = New System.Windows.Forms.ColumnHeader
        Me.KeyFileName = New System.Windows.Forms.ColumnHeader
        Me.ImageListComponents = New System.Windows.Forms.ImageList(Me.components)
        Me.LabelWait = New System.Windows.Forms.Label
        Me.ButtonCancel = New System.Windows.Forms.Button
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
        Me.LabelTitle.Size = New System.Drawing.Size(126, 25)
        Me.LabelTitle.TabIndex = 5
        Me.LabelTitle.Text = "Components"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Components_48x48
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
        Me.LabelFolders.Size = New System.Drawing.Size(134, 17)
        Me.LabelFolders.TabIndex = 4
        Me.LabelFolders.Text = "System Components"
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
        'ListViewComponents
        '
        Me.ListViewComponents.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ComponentValue, Me.ComponentName, Me.Version, Me.Locale, Me.StubPath, Me.KeyFileName})
        Me.ListViewComponents.FullRowSelect = True
        Me.ListViewComponents.Location = New System.Drawing.Point(87, 122)
        Me.ListViewComponents.MultiSelect = False
        Me.ListViewComponents.Name = "ListViewComponents"
        Me.ListViewComponents.Size = New System.Drawing.Size(640, 495)
        Me.ListViewComponents.SmallImageList = Me.ImageListComponents
        Me.ListViewComponents.TabIndex = 1
        Me.ListViewComponents.UseCompatibleStateImageBehavior = False
        Me.ListViewComponents.View = System.Windows.Forms.View.Details
        Me.ListViewComponents.Visible = False
        '
        'ComponentValue
        '
        Me.ComponentValue.Text = "Component"
        Me.ComponentValue.Width = 250
        '
        'ComponentName
        '
        Me.ComponentName.Text = "Name"
        Me.ComponentName.Width = 210
        '
        'Version
        '
        Me.Version.Text = "Version"
        Me.Version.Width = 100
        '
        'Locale
        '
        Me.Locale.Text = "Locale"
        '
        'StubPath
        '
        Me.StubPath.Text = "Stub Path"
        Me.StubPath.Width = 300
        '
        'KeyFileName
        '
        Me.KeyFileName.Text = "Key File Name"
        Me.KeyFileName.Width = 300
        '
        'ImageListComponents
        '
        Me.ImageListComponents.ImageStream = CType(resources.GetObject("ImageListComponents.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageListComponents.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageListComponents.Images.SetKeyName(0, "Components_16x16.png")
        '
        'LabelWait
        '
        Me.LabelWait.AutoSize = True
        Me.LabelWait.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWait.Location = New System.Drawing.Point(286, 357)
        Me.LabelWait.Name = "LabelWait"
        Me.LabelWait.Size = New System.Drawing.Size(243, 25)
        Me.LabelWait.TabIndex = 2
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
        'Component
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ListViewComponents)
        Me.Controls.Add(Me.LabelFolders)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Controls.Add(Me.LabelWait)
        Me.Name = "Component"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelFolders As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents ListViewComponents As System.Windows.Forms.ListView
    Friend WithEvents ComponentValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents ComponentName As System.Windows.Forms.ColumnHeader
    Friend WithEvents Version As System.Windows.Forms.ColumnHeader
    Friend WithEvents Locale As System.Windows.Forms.ColumnHeader
    Friend WithEvents StubPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents KeyFileName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageListComponents As System.Windows.Forms.ImageList
    Friend WithEvents LabelWait As System.Windows.Forms.Label
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button

End Class
