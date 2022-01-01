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

Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Friend Class Video
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Video

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Video
        If (panelInstance Is Nothing) Then
            panelInstance = New Video()
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

    Private _Info As ComputerInformation

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            ' Get information.
            _Info = New ComputerInformation
            _Info.Initialize(Initializer.GetVideoInfo)

            ' Display number of adaptors
            LabelNumberControllers.Text = "Number of Video Controllers: " & _
                _Info.VideoNumberOfControllers.ToString

            ' Display dimensions
            If Windows.Forms.Screen.AllScreens.Count > 0 Then
                LabelPrimaryScreenDimensions.Text = "Primary Screen Dimensions: " & _
                    _Info.VideoPrimaryScreenDimensions
                LabelPrimaryScreenWorkingArea.Text = "Primary Screen Working Area: " & _
                    _Info.VideoPrimaryScreenWorkingArea
            Else
                LabelPrimaryScreenDimensions.Text = ""
                LabelPrimaryScreenWorkingArea.Text = ""
            End If

            If Windows.Forms.Screen.AllScreens.Count > 1 Then
                LabelSecondaryScreenDimensions.Text = "Secondary Screen Dimensions: " & _
                    _Info.VideoSecondaryScreenDimensions
                LabelSecondaryScreenWorkingArea.Text = "Secondary Screen Working Area: " & _
                    _Info.VideoSecondaryScreenWorkingArea
            Else
                LabelSecondaryScreenDimensions.Text = ""
                LabelSecondaryScreenWorkingArea.Text = ""
            End If

            If Windows.Forms.Screen.AllScreens.Count > 2 Then
                LabelTertiaryScreenDimensions.Text = "Tertiary Screen Dimensions: " & _
                    _Info.VideoTertiaryScreenDimensions
                LabelTertiaryScreenWorkingArea.Text = "Tertiatry Screen Working Area: " & _
                    _Info.VideoTertiaryScreenWorkingArea
            Else
                LabelTertiaryScreenDimensions.Text = ""
                LabelTertiaryScreenWorkingArea.Text = ""
            End If

            If Windows.Forms.Screen.AllScreens.Count > 3 Then
                LabelQuatnernaryScreenDimensions.Text = "Quaternary Screen Dimensions: " & _
                    _Info.VideoQuaternaryScreenDimensions
                LabelQuatnernaryScreenWorkingArea.Text = "Quaternary Screen Working Area: " & _
                    _Info.VideoQuaternaryScreenWorkingArea
            Else
                LabelQuatnernaryScreenDimensions.Text = ""
                LabelQuatnernaryScreenWorkingArea.Text = ""
            End If

            ListViewAdaptors.Visible = False

            ManagementInfo.ManagementInfoToListView("Win32_VideoController", ListViewAdaptors, False, 200, 400, _
                                           MainForm.ToolStripProgressBar1)

            If ListViewAdaptors.Items.Count = 0 Then
                ManagementInfo.AddGroupForNoResults(ListViewAdaptors, "Win32_VideoController", "No Results Returned")
            End If

            ManagementInfo.ResizeListViewColumns(ListViewAdaptors, ColumnHeaderAutoResizeStyle.HeaderSize)

            ListViewAdaptors.Visible = True

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Video panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Class
