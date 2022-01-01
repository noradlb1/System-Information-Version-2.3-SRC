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

Friend Class UsbDevices
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As UsbDevices

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As UsbDevices
        If (panelInstance Is Nothing) Then
            panelInstance = New UsbDevices()
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

    Private _Initialized As Boolean

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        _Initialized = False
        ListViewUsb.Visible = False


        ManagementInfo.ManagementInfoToListView("Win32_USBController", ListViewUsb, True, 200, 400, _
                                       MainForm.ToolStripProgressBar1)

        If ListViewUsb.Items.Count = 0 Then
            ManagementInfo.AddGroupForNoResults(ListViewUsb, "Win32_USBController", "No Results Returned")
        End If

        ManagementInfo.ResizeListViewColumns(ListViewUsb, ColumnHeaderAutoResizeStyle.HeaderSize)

        ListViewUsb.Visible = True
        _Initialized = True

    End Sub

#End Region

#Region " RadioButton Event Handlers "

    Private Sub RadioButtonUsbController_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonUsbController.CheckedChanged

        If _Initialized AndAlso RadioButtonUsbController.Checked Then

            ListViewUsb.Visible = False

            ManagementInfo.ManagementInfoToListView("Win32_USBController", ListViewUsb, True, 200, 400, _
                                           MainForm.ToolStripProgressBar1)

            If ListViewUsb.Items.Count = 0 Then
                ManagementInfo.AddGroupForNoResults(ListViewUsb, "Win32_USBController", "No Results Returned")
            End If
            ManagementInfo.ResizeListViewColumns(ListViewUsb, ColumnHeaderAutoResizeStyle.HeaderSize)

            ListViewUsb.Visible = True
            _Initialized = True

        End If

    End Sub

    Private Sub RadioButtonUsbHub_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonUsbHub.CheckedChanged

        If _Initialized AndAlso RadioButtonUsbHub.Checked Then

            ListViewUsb.Visible = False

            ManagementInfo.ManagementInfoToListView("Win32_USBHub", ListViewUsb, True, 200, 400, _
                                           MainForm.ToolStripProgressBar1)

            If ListViewUsb.Items.Count = 0 Then
                ManagementInfo.AddGroupForNoResults(ListViewUsb, "Win32_USBHub", "No Results Returned")
            End If

            ManagementInfo.ResizeListViewColumns(ListViewUsb, ColumnHeaderAutoResizeStyle.HeaderSize)

            ListViewUsb.Visible = True
            _Initialized = True

        End If

    End Sub

#End Region

End Class
