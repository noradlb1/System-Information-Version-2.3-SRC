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

Friend Class Ports
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Ports

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Ports
        If (panelInstance Is Nothing) Then
            panelInstance = New Ports()
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
    Private _Initialized As Boolean

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        _Initialized = False

        ListViewPorts.Visible = False

        ManagementInfo.ManagementInfoToListView("Win32_ParallelPort", ListViewPorts, True, 200, 400)

        If ListViewPorts.Items.Count = 0 Then
            ManagementInfo.AddGroupForNoResults(ListViewPorts, "Win32_ParalletPort", "No Results Returned")
        End If

        ManagementInfo.ResizeListViewColumns(ListViewPorts, ColumnHeaderAutoResizeStyle.HeaderSize)

        ListViewPorts.Visible = True

        _Initialized = True

    End Sub

#End Region

#Region " RadioButton Event Handlers "

    Private Sub RadioButtonParallelPort_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonParallelPort.CheckedChanged

        If _Initialized AndAlso RadioButtonParallelPort.Checked Then
            ListViewPorts.Visible = False
            ManagementInfo.ManagementInfoToListView("Win32_ParallelPort", ListViewPorts, True, 200, 400)
            If ListViewPorts.Items.Count = 0 Then
                ManagementInfo.AddGroupForNoResults(ListViewPorts, "Win32_ParallelPort", "No Results Returned")
            End If
            ManagementInfo.ResizeListViewColumns(ListViewPorts, ColumnHeaderAutoResizeStyle.HeaderSize)
            ListViewPorts.Visible = True
        End If

    End Sub

    Private Sub RadioButtonSerialPort_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonSerialPort.CheckedChanged

        If _Initialized AndAlso RadioButtonSerialPort.Checked Then
            ListViewPorts.Visible = False
            ManagementInfo.ManagementInfoToListView("Win32_SerialPort", ListViewPorts, True, 200, 400)
            If ListViewPorts.Items.Count = 0 Then
                ManagementInfo.AddGroupForNoResults(ListViewPorts, "Win32_SerialPort", "No Results Returned")
            End If
            ManagementInfo.ResizeListViewColumns(ListViewPorts, ColumnHeaderAutoResizeStyle.HeaderSize)
            ListViewPorts.Visible = True
        End If

    End Sub

#End Region

End Class
