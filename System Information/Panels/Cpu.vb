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

Friend Class Cpu
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Cpu

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Cpu
        If (panelInstance Is Nothing) Then
            panelInstance = New Cpu()
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

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        With ListViewCpu
            .Visible = False
            .SuspendLayout()
        End With

        MainForm.ToolStripProgressBar1.Visible = True

        ManagementInfo.ManagementInfoToListView("Win32_Processor", ListViewCpu, True, 200, 400, _
                                                MainForm.ToolStripProgressBar1)

        If ListViewCpu.Items.Count = 0 Then
            ManagementInfo.AddGroupForNoResults(ListViewCpu, "Win32_Processor", "No Results Returned")
        End If

        With ListViewCpu
            .ResumeLayout()
            .Visible = True
        End With

        ManagementInfo.ResizeListViewColumns(ListViewCpu, ColumnHeaderAutoResizeStyle.HeaderSize)

        MainForm.ToolStripProgressBar1.Visible = False

    End Sub

#End Region

End Class
