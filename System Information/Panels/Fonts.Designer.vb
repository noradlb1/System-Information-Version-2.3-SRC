<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Fonts
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
        Me.LabelNumberOfFonts = New System.Windows.Forms.Label
        Me.LabelSeparator = New System.Windows.Forms.Label
        Me.ColorPicker1 = New VirtualSoftware.ColorPicker
        Me.ComboBoxFontSize = New System.Windows.Forms.ComboBox
        Me.LabelFontColor = New System.Windows.Forms.Label
        Me.LabelFontSize = New System.Windows.Forms.Label
        Me.LabelFontSample = New System.Windows.Forms.Label
        Me.ListBoxFontList = New System.Windows.Forms.ListBox
        Me.LabelInstalledFonts = New System.Windows.Forms.Label
        Me.LabelSampleText = New System.Windows.Forms.Label
        Me.RadioButtonLoremIpsum = New System.Windows.Forms.RadioButton
        Me.RadioButtonAlphabet = New System.Windows.Forms.RadioButton
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
        Me.LabelTitle.Size = New System.Drawing.Size(141, 25)
        Me.LabelTitle.TabIndex = 12
        Me.LabelTitle.Text = "Installed Fonts"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Font_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 32)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 6
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelNumberOfFonts
        '
        Me.LabelNumberOfFonts.AutoSize = True
        Me.LabelNumberOfFonts.BackColor = System.Drawing.Color.Transparent
        Me.LabelNumberOfFonts.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNumberOfFonts.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelNumberOfFonts.Location = New System.Drawing.Point(87, 76)
        Me.LabelNumberOfFonts.Name = "LabelNumberOfFonts"
        Me.LabelNumberOfFonts.Size = New System.Drawing.Size(117, 17)
        Me.LabelNumberOfFonts.TabIndex = 11
        Me.LabelNumberOfFonts.Text = "Number of Fonts:"
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 98)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 10
        '
        'ColorPicker1
        '
        Me.ColorPicker1.Appearance = VirtualSoftware.ColorPickerAppearance.EditableComboBox
        Me.ColorPicker1.Location = New System.Drawing.Point(522, 143)
        Me.ColorPicker1.Name = "ColorPicker1"
        Me.ColorPicker1.Size = New System.Drawing.Size(207, 24)
        Me.ColorPicker1.TabIndex = 1
        '
        'ComboBoxFontSize
        '
        Me.ComboBoxFontSize.FormattingEnabled = True
        Me.ComboBoxFontSize.Items.AddRange(New Object() {"8", "9", "10", "11", "12", "14", "16", "18", "20", "22", "24", "26", "28"})
        Me.ComboBoxFontSize.Location = New System.Drawing.Point(612, 200)
        Me.ComboBoxFontSize.Name = "ComboBoxFontSize"
        Me.ComboBoxFontSize.Size = New System.Drawing.Size(117, 25)
        Me.ComboBoxFontSize.TabIndex = 2
        '
        'LabelFontColor
        '
        Me.LabelFontColor.AutoSize = True
        Me.LabelFontColor.BackColor = System.Drawing.Color.Transparent
        Me.LabelFontColor.Location = New System.Drawing.Point(522, 120)
        Me.LabelFontColor.Name = "LabelFontColor"
        Me.LabelFontColor.Size = New System.Drawing.Size(69, 17)
        Me.LabelFontColor.TabIndex = 8
        Me.LabelFontColor.Text = "Font Color"
        '
        'LabelFontSize
        '
        Me.LabelFontSize.AutoSize = True
        Me.LabelFontSize.BackColor = System.Drawing.Color.Transparent
        Me.LabelFontSize.Location = New System.Drawing.Point(612, 178)
        Me.LabelFontSize.Name = "LabelFontSize"
        Me.LabelFontSize.Size = New System.Drawing.Size(60, 17)
        Me.LabelFontSize.TabIndex = 9
        Me.LabelFontSize.Text = "Font Size"
        '
        'LabelFontSample
        '
        Me.LabelFontSample.BackColor = System.Drawing.SystemColors.Window
        Me.LabelFontSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelFontSample.Location = New System.Drawing.Point(87, 345)
        Me.LabelFontSample.Name = "LabelFontSample"
        Me.LabelFontSample.Size = New System.Drawing.Size(642, 98)
        Me.LabelFontSample.TabIndex = 6
        '
        'ListBoxFontList
        '
        Me.ListBoxFontList.FormattingEnabled = True
        Me.ListBoxFontList.ItemHeight = 17
        Me.ListBoxFontList.Location = New System.Drawing.Point(87, 143)
        Me.ListBoxFontList.Name = "ListBoxFontList"
        Me.ListBoxFontList.Size = New System.Drawing.Size(405, 157)
        Me.ListBoxFontList.TabIndex = 0
        '
        'LabelInstalledFonts
        '
        Me.LabelInstalledFonts.AutoSize = True
        Me.LabelInstalledFonts.BackColor = System.Drawing.Color.Transparent
        Me.LabelInstalledFonts.Location = New System.Drawing.Point(84, 120)
        Me.LabelInstalledFonts.Name = "LabelInstalledFonts"
        Me.LabelInstalledFonts.Size = New System.Drawing.Size(91, 17)
        Me.LabelInstalledFonts.TabIndex = 7
        Me.LabelInstalledFonts.Text = "Installed Fonts"
        '
        'LabelSampleText
        '
        Me.LabelSampleText.AutoSize = True
        Me.LabelSampleText.BackColor = System.Drawing.Color.Transparent
        Me.LabelSampleText.Location = New System.Drawing.Point(84, 322)
        Me.LabelSampleText.Name = "LabelSampleText"
        Me.LabelSampleText.Size = New System.Drawing.Size(79, 17)
        Me.LabelSampleText.TabIndex = 5
        Me.LabelSampleText.Text = "Sample Text"
        '
        'RadioButtonLoremIpsum
        '
        Me.RadioButtonLoremIpsum.AutoSize = True
        Me.RadioButtonLoremIpsum.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonLoremIpsum.Location = New System.Drawing.Point(475, 320)
        Me.RadioButtonLoremIpsum.Name = "RadioButtonLoremIpsum"
        Me.RadioButtonLoremIpsum.Size = New System.Drawing.Size(102, 21)
        Me.RadioButtonLoremIpsum.TabIndex = 3
        Me.RadioButtonLoremIpsum.TabStop = True
        Me.RadioButtonLoremIpsum.Text = "Lorem Ipsum"
        Me.RadioButtonLoremIpsum.UseVisualStyleBackColor = False
        '
        'RadioButtonAlphabet
        '
        Me.RadioButtonAlphabet.AutoSize = True
        Me.RadioButtonAlphabet.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonAlphabet.Location = New System.Drawing.Point(592, 320)
        Me.RadioButtonAlphabet.Name = "RadioButtonAlphabet"
        Me.RadioButtonAlphabet.Size = New System.Drawing.Size(137, 21)
        Me.RadioButtonAlphabet.TabIndex = 4
        Me.RadioButtonAlphabet.TabStop = True
        Me.RadioButtonAlphabet.Text = "Alphabet/Numbers"
        Me.RadioButtonAlphabet.UseVisualStyleBackColor = False
        '
        'Fonts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.RadioButtonAlphabet)
        Me.Controls.Add(Me.RadioButtonLoremIpsum)
        Me.Controls.Add(Me.LabelSampleText)
        Me.Controls.Add(Me.LabelInstalledFonts)
        Me.Controls.Add(Me.ListBoxFontList)
        Me.Controls.Add(Me.LabelFontSample)
        Me.Controls.Add(Me.LabelFontSize)
        Me.Controls.Add(Me.LabelFontColor)
        Me.Controls.Add(Me.ComboBoxFontSize)
        Me.Controls.Add(Me.ColorPicker1)
        Me.Controls.Add(Me.LabelNumberOfFonts)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Name = "Fonts"
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelNumberOfFonts As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Friend WithEvents ColorPicker1 As VirtualSoftware.ColorPicker
    Friend WithEvents ComboBoxFontSize As System.Windows.Forms.ComboBox
    Friend WithEvents LabelFontColor As System.Windows.Forms.Label
    Friend WithEvents LabelFontSize As System.Windows.Forms.Label
    Friend WithEvents LabelFontSample As System.Windows.Forms.Label
    Friend WithEvents ListBoxFontList As System.Windows.Forms.ListBox
    Friend WithEvents LabelInstalledFonts As System.Windows.Forms.Label
    Friend WithEvents LabelSampleText As System.Windows.Forms.Label
    Friend WithEvents RadioButtonLoremIpsum As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAlphabet As System.Windows.Forms.RadioButton

End Class
