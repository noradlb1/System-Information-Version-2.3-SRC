
Public Class CustomComboBoxDisplay
    Inherits ComboBoxDisplay

    Protected Overrides Sub GetDisplayLayout(ByRef colorBoxRect As System.Drawing.Rectangle, _
                                             ByRef textBoxRect As System.Drawing.RectangleF, _
                                             ByRef buttonRect As System.Drawing.Rectangle)

        ' Let the base class calculate the general layout.
        MyBase.GetDisplayLayout(colorBoxRect, textBoxRect, buttonRect)

        ' Make the drop-down button 16x16 pixels.
        buttonRect.Width = 16
        buttonRect.Height = 16
        buttonRect.Y = (Me.Height - buttonRect.Height) \ 2
    End Sub

End Class
