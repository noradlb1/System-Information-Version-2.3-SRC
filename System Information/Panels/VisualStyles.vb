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

Friend Class VisualStyles
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As VisualStyles

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As VisualStyles
        If (panelInstance Is Nothing) Then
            panelInstance = New VisualStyles()
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

    Private _Info As New ComputerInformation

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            ' Allow panel to paint.
            Application.DoEvents()

            ' Modify header label
            If _Info.VisualStyleIsEnabledByUser = False Then
                LabelCurrentVisualStyle.Text = "Visual Styles Are Not Enabled By The User"
                LabelAuthor.Visible = False
                LabelAuthorDesc.Visible = False
                LabelCntrlHiLiteHotDesc.Visible = False
                PictureBoxControlHighlightHot.Visible = False
                LabelColorScheme.Visible = False
                LabelColorSchemeDesc.Visible = False
                LabelCompany.Visible = False
                LabelColorSchemeDesc.Visible = False
                LabelCompany.Visible = False
                LabelCompanyDesc.Visible = False
                LabelCopyright.Visible = False
                LabelCopyrightDesc.Visible = False
                LabelCurrentVisualStyle.Visible = False
                LabelDescription.Visible = False
                LabelDescriptionDesc.Visible = False
                LabelDisplayName.Visible = False
                LabelDisplayNameDesc.Visible = False
                LabelMinColorDepDesc.Visible = False
                LabelMinimumColorDepth.Visible = False
                LabelTextCtrlBrdrDesc.Visible = False
                PictureBoxTextControlBorder.Visible = False
                LabelVersionDesc.Visible = False
                LabelVersion.Visible = False
                LabelEnabeUserDesc.Visible = True
                LabelIsEnabledByUser.Visible = True
                LabelIsSupportedByOS.Visible = True
                LabelSuportOSDesc.Visible = True
            ElseIf _Info.VisualStyleIsSupportedByOS = False Then
                LabelCurrentVisualStyle.Text = "Visual Styles Are Disabled Or Not Supported"
                LabelAuthor.Visible = False
                LabelAuthorDesc.Visible = False
                LabelCntrlHiLiteHotDesc.Visible = False
                PictureBoxControlHighlightHot.Visible = False
                LabelColorScheme.Visible = False
                LabelColorSchemeDesc.Visible = False
                LabelCompany.Visible = False
                LabelColorSchemeDesc.Visible = False
                LabelCompany.Visible = False
                LabelCompanyDesc.Visible = False
                LabelCopyright.Visible = False
                LabelCopyrightDesc.Visible = False
                LabelCurrentVisualStyle.Visible = False
                LabelDescription.Visible = False
                LabelDescriptionDesc.Visible = False
                LabelDisplayName.Visible = False
                LabelDisplayNameDesc.Visible = False
                LabelMinColorDepDesc.Visible = False
                LabelMinimumColorDepth.Visible = False
                LabelTextCtrlBrdrDesc.Visible = False
                PictureBoxTextControlBorder.Visible = False
                LabelVersionDesc.Visible = False
                LabelVersion.Visible = False
                LabelEnabeUserDesc.Visible = True
                LabelIsEnabledByUser.Visible = True
                LabelIsSupportedByOS.Visible = True
                LabelSuportOSDesc.Visible = True
            Else
                LabelCurrentVisualStyle.Text = "Current Visual Styles"
            End If

            ' Fill in labels
            LabelCompany.Text = _Info.VisualStyleCompany
            LabelCopyright.Text = _Info.VisualStyleCopyright
            LabelAuthor.Text = _Info.VisualStyleAuthor
            LabelVersion.Text = _Info.VisualStyleVersion
            LabelDisplayName.Text = _Info.VisualStyleDisplayName
            LabelDescription.Text = _Info.VisualStyleDescription
            LabelColorScheme.Text = _Info.VisualStyleColorScheme
            LabelIsEnabledByUser.Text = _Info.VisualStyleIsEnabledByUser.ToString
            LabelIsSupportedByOS.Text = _Info.VisualStyleIsSupportedByOS.ToString
            LabelMinimumColorDepth.Text = _Info.VisualStyleMinimumColorDepth.ToString
            PictureBoxControlHighlightHot.BackColor = _Info.VisualStyleControlHighlightHot
            PictureBoxTextControlBorder.BackColor = _Info.VisualStyleTextControlBorder

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the CPU panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Class
