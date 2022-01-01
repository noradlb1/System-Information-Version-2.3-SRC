'
' Copyright © 2006-2008 Herbert N Swearengen III (hswear3@swbell.net)
' All rights reserved.
'
' Redistribution and use in source and binary forms, with or without modification, 
' are permitted provided that the following conditions are met:
'
'   - Redistributions of source code must retain the above copyright notice, 
'     this list of conditions and the following disclaimer.
'
'   - Redistributions in binary form must reproduce the above copyright notice, 
'     this list of conditions and the following disclaimer in the documentation 
'     and/or other materials provided with the distribution.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
' ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
' WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
' IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
' INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
' NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, 
' OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
' WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
' ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
' OF SUCH DAMAGE.
'
Option Explicit On
Option Strict On

Imports VirtualSoftware.ColorPicker

Friend Class Fonts
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Fonts

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Fonts
        If (panelInstance Is Nothing) Then
            panelInstance = New Fonts()
        End If
        Return panelInstance
    End Function

    ''' <summary>
    ''' Resize panel to fit containing control.
    ''' </summary>
    Public Shared Sub ResizePanel(ByVal hostControl As Control)
        If panelInstance IsNot Nothing Then
            panelInstance.Size = New Size(hostControl.Width, hostControl.Height)
        End If
    End Sub

#End Region

#Region " Private Members "

    ' Text to display.
    Private _SampleText As String = vbCrLf & "Aa Bb Cc Dd Ee Ff Gg Hh Ii Jj Kk Ll Mm " & _
     "Nn Oo Pp Qq Rr Ss Tt Uu Vv Ww Xx Yy Zz" & vbCrLf & "1 2 3 4 5 6 7 8 9 0"

    Private _LoremIpsum As String = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, " & _
        "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, " & _
        "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " & _
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. " & _
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        ' Load the fonts into the font picker combo box.
        For i As Integer = 0 To FontFamily.Families.Length - 1

            Dim fontName As String = FontFamily.Families(i).Name
            ListBoxFontList.Items.Add(fontName)

        Next

        ' Set the defaults.
        LabelNumberOfFonts.Text = "Number of fonts: " & FontFamily.Families.Length.ToString()
        ComboBoxFontSize.SelectedItem = "12"
        LabelFontSample.BackColor = Color.FromName("White")
        ListBoxFontList.SelectedIndex = 0
        ListBoxFontList.Focus()
        ' Set sample text.
        RadioButtonLoremIpsum.PerformClick()

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub ListBoxFontList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListBoxFontList.SelectedIndexChanged

        ' Font Changed.	
        ' Set the FontFamily.
        Dim fntFamily As FontFamily = FontFamily.Families(ListBoxFontList.SelectedIndex)
        ' Set the labels font.  Check the FontStyle before setting it.
        LabelFontSample.Font = New Font(fntFamily.Name, LabelFontSample.Font.Size, GetFontStyle(fntFamily))

    End Sub

    Private Sub ComboBoxFontSize_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ComboBoxFontSize.SelectedIndexChanged

        ' Font Size Change.  

        Dim tempFontSize As Integer

        ' Cast the size.
        tempFontSize = Convert.ToInt32(ComboBoxFontSize.SelectedItem.ToString())
        LabelFontSample.Font = New Font(LabelFontSample.Font.Name, tempFontSize)

    End Sub

    Private Sub ColorPicker1_ColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ColorPicker1.ColorChanged

        ' Change the color.
        LabelFontSample.ForeColor = ColorPicker1.Color

    End Sub

    Private Sub RadioButtonLoremIpsum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonLoremIpsum.CheckedChanged

        LabelFontSample.Text = _LoremIpsum

    End Sub

    Private Sub RadioButtonAlphabet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonAlphabet.CheckedChanged

        LabelFontSample.Text = _SampleText

    End Sub

#End Region

#Region " Private Methods "

    Private Shared Function GetFontStyle(ByVal ff As FontFamily) As FontStyle

        ' Ensure that the FontStyle is supported by the selected font.

        Dim fntStyle As FontStyle = FontStyle.Regular

        If Not ff.IsStyleAvailable(FontStyle.Regular) Then
            fntStyle = FontStyle.Italic
        End If

        If Not ff.IsStyleAvailable(FontStyle.Italic) Then
            fntStyle = FontStyle.Bold
        End If

        Return fntStyle

    End Function

#End Region

End Class
