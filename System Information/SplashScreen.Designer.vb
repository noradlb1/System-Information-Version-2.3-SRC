<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.PictureBoxGraphic = New System.Windows.Forms.PictureBox()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.LabelCompany = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.ProgressBarSplash = New System.Windows.Forms.ProgressBar()
        Me.LabelSeparator = New System.Windows.Forms.Label()
        Me.LabelWindowsVersion = New System.Windows.Forms.Label()
        Me.LabelOSDescription = New System.Windows.Forms.Label()
        Me.LabelFrameworkVersion = New System.Windows.Forms.Label()
        Me.LabelClrVersion = New System.Windows.Forms.Label()
        CType(Me.PictureBoxGraphic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBoxGraphic
        '
        Me.PictureBoxGraphic.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxGraphic.Image = Global.SystemInformation.My.Resources.Resources.SplashScreenGraphic
        Me.PictureBoxGraphic.Location = New System.Drawing.Point(25, 21)
        Me.PictureBoxGraphic.Name = "PictureBoxGraphic"
        Me.PictureBoxGraphic.Size = New System.Drawing.Size(256, 256)
        Me.PictureBoxGraphic.TabIndex = 0
        Me.PictureBoxGraphic.TabStop = False
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoEllipsis = True
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelTitle.Location = New System.Drawing.Point(299, 21)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(325, 32)
        Me.LabelTitle.TabIndex = 1
        Me.LabelTitle.Text = "Title"
        '
        'LabelCompany
        '
        Me.LabelCompany.AutoEllipsis = True
        Me.LabelCompany.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCompany.Location = New System.Drawing.Point(302, 65)
        Me.LabelCompany.Name = "LabelCompany"
        Me.LabelCompany.Size = New System.Drawing.Size(325, 17)
        Me.LabelCompany.TabIndex = 2
        Me.LabelCompany.Text = "A Product of "
        '
        'LabelVersion
        '
        Me.LabelVersion.AutoEllipsis = True
        Me.LabelVersion.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersion.Location = New System.Drawing.Point(302, 93)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(325, 17)
        Me.LabelVersion.TabIndex = 3
        Me.LabelVersion.Text = "Version "
        '
        'LabelCopyright
        '
        Me.LabelCopyright.AutoEllipsis = True
        Me.LabelCopyright.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCopyright.Location = New System.Drawing.Point(302, 121)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(325, 17)
        Me.LabelCopyright.TabIndex = 4
        Me.LabelCopyright.Text = "Copyright"
        '
        'ProgressBarSplash
        '
        Me.ProgressBarSplash.Location = New System.Drawing.Point(305, 264)
        Me.ProgressBarSplash.Maximum = 300
        Me.ProgressBarSplash.Name = "ProgressBarSplash"
        Me.ProgressBarSplash.Size = New System.Drawing.Size(325, 10)
        Me.ProgressBarSplash.TabIndex = 5
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.Location = New System.Drawing.Point(302, 150)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(325, 3)
        Me.LabelSeparator.TabIndex = 6
        Me.LabelSeparator.Text = "Label1"
        '
        'LabelWindowsVersion
        '
        Me.LabelWindowsVersion.Location = New System.Drawing.Point(302, 166)
        Me.LabelWindowsVersion.Name = "LabelWindowsVersion"
        Me.LabelWindowsVersion.Size = New System.Drawing.Size(325, 15)
        Me.LabelWindowsVersion.TabIndex = 7
        Me.LabelWindowsVersion.Text = "Windows Version"
        '
        'LabelOSDescription
        '
        Me.LabelOSDescription.Location = New System.Drawing.Point(302, 189)
        Me.LabelOSDescription.Name = "LabelOSDescription"
        Me.LabelOSDescription.Size = New System.Drawing.Size(325, 15)
        Me.LabelOSDescription.TabIndex = 8
        Me.LabelOSDescription.Text = "Windows Description"
        '
        'LabelFrameworkVersion
        '
        Me.LabelFrameworkVersion.Location = New System.Drawing.Point(302, 212)
        Me.LabelFrameworkVersion.Name = "LabelFrameworkVersion"
        Me.LabelFrameworkVersion.Size = New System.Drawing.Size(325, 15)
        Me.LabelFrameworkVersion.TabIndex = 9
        Me.LabelFrameworkVersion.Text = "Framework Version"
        '
        'LabelClrVersion
        '
        Me.LabelClrVersion.Location = New System.Drawing.Point(302, 235)
        Me.LabelClrVersion.Name = "LabelClrVersion"
        Me.LabelClrVersion.Size = New System.Drawing.Size(325, 15)
        Me.LabelClrVersion.TabIndex = 10
        Me.LabelClrVersion.Text = "CLR Version"
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(648, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelClrVersion)
        Me.Controls.Add(Me.LabelFrameworkVersion)
        Me.Controls.Add(Me.LabelOSDescription)
        Me.Controls.Add(Me.LabelWindowsVersion)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.ProgressBarSplash)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelCompany)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxGraphic)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBoxGraphic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBoxGraphic As System.Windows.Forms.PictureBox
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents LabelCompany As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label
    Friend WithEvents ProgressBarSplash As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents LabelWindowsVersion As System.Windows.Forms.Label
    Friend WithEvents LabelOSDescription As System.Windows.Forms.Label
    Friend WithEvents LabelFrameworkVersion As System.Windows.Forms.Label
    Friend WithEvents LabelClrVersion As System.Windows.Forms.Label

End Class
