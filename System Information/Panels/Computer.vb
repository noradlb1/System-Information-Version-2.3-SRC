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

Imports System.Management

Friend Class Computer
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Computer

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Computer
        If (panelInstance Is Nothing) Then
            panelInstance = New Computer()
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

            With ListViewComputer
                .Visible = False
                .SuspendLayout()
            End With

            With MainForm.ToolStripProgressBar1
                .Value = 0
                .Visible = True
            End With

            ' Get Information
            _Info = New ComputerInformation
            _Info.Initialize(Initializer.GetNone)

            ' Fill in startup and up time information
            LabelBootupState.Text = _Info.OSBootUpstate
            LabelStartDateTime.Text = _Info.OSStartTime.ToShortDateString & " " & _Info.OSStartTime.ToLongTimeString

            ' Fill in Memory Information
            LabelTotalPhysical.Text = _Info.MemoryTotalPhysical
            LabelAvailablePhysical.Text = _Info.MemoryAvailPhysical
            LabelTotalVirtual.Text = _Info.MemoryTotalVirtual
            LabelAvailableVirtual.Text = _Info.MemoryAvailVirtual

            ' enable timer
            TimerTimeUp.Enabled = True

            ' Get general information from system management.
            ManagementInfo.ManagementInfoToListView("Win32_ComputerSystem", ListViewComputer, True, 200, 400, _
                                           MainForm.ToolStripProgressBar1)

        Catch ex As Security.SecurityException
            MessageBox.Show("An error has occurred in the Computer panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        Catch exp As NullReferenceException
            MessageBox.Show("An error has occurred in the Computer panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & exp.Source & vbCrLf & _
                "Description: " & exp.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

        If ListViewComputer.Items.Count = 0 Then
            ManagementInfo.AddGroupForNoResults(ListViewComputer, "Win32_Computer", "No Results Returned")
        End If

        ManagementInfo.ResizeListViewColumns(ListViewComputer, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewComputer
            .SuspendLayout()
            .Visible = True
        End With

        MainForm.ToolStripProgressBar1.Visible = False

    End Sub

#End Region

#Region " Timer Event Handlers "

    Private Sub TimerTimeUp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TimerTimeUp.Tick

        LabelUpTime.Text = _Info.OSUptime
    End Sub

#End Region

End Class
