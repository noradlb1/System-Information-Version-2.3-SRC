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

Friend Class Bios
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Bios

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Bios
        If (panelInstance Is Nothing) Then
            panelInstance = New Bios()
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
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            Dim feature As Object

            ' Get Information
            _Info.Initialize(Initializer.GetBiosInfo)

            ' Fill in labels
            LabelManufacturer.Text = _Info.BiosManufacturer
            LabelModel.Text = _Info.BiosName
            LabelReleaseDate.Text = _Info.BiosReleaseDate
            LabelSMBIOSPresent.Text = CStr(_Info.BiosSMBiosPresent)
            LabelSMBIOSVersion.Text = _Info.BiosSMBiosVersion
            LabelVersion.Text = _Info.BiosVersion

            With ListViewFeatures
                .Visible = False
                .Items.Clear()
                .SuspendLayout()
            End With

            ' Create listview group.
            _ListViewGroup = ListViewFeatures.Groups.Add("Features", "Features")

            ' Fill in listview with features, if present
            If _Info.BiosFeatures IsNot Nothing Then
                For Each feature In _Info.BiosFeatures

                    _ListViewItem = New ListViewItem(_ListViewGroup)

                    ' Alternate back color of items.
                    If (ListViewFeatures.Items.Count Mod 2 <> 0) Then
                        _ListViewItem.BackColor = Color.White
                    Else
                        _ListViewItem.BackColor = Color.WhiteSmoke
                    End If

                    ' Add the subitems.
                    '_ListViewItem.SubItems.Add("Example")

                    ' Add the text for the item.
                    _ListViewItem.Text = feature.ToString()

                    ' Set the image index.
                    '_ListViewItem.ImageIndex = 0

                    ' Add the item to the listview.
                    ListViewFeatures.Items.Add(_ListViewItem)

                Next
            Else
                ListViewFeatures.Items.Add("Not Available")
            End If

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the BIOS panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

        With ListViewFeatures
            ManagementInfo.ResizeListViewColumns(ListViewFeatures, ColumnHeaderAutoResizeStyle.HeaderSize)
            .ResumeLayout()
            .Visible = True
        End With

    End Sub

#End Region

End Class
