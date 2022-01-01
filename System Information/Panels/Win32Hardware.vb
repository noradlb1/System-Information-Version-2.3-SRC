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

Friend Class Win32Hardware
    Inherits SystemInformation.TaskPanelBase

    Private Shared panelInstance As Win32Hardware

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Win32Hardware
        If (panelInstance Is Nothing) Then
            panelInstance = New Win32Hardware()
        End If
        Return panelInstance
    End Function

#Region " Panel Event Handlers "

    Private Sub Win32Hardware_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Me.KeyUp

        ' Also cancel with Escape.
        If e.KeyValue = Keys.Escape Then
            ButtonCancel.PerformClick()
        End If

    End Sub

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        ComboBoxSelect.SelectedItem = "Win32_Processor"


    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonCancel.Click

        ManagementInfo.Cancel()

    End Sub

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonRefresh.Click

        DisplayClass()

    End Sub

#End Region

#Region " ComboBox Event Handlers "

    Private Sub ComboBoxSelectClass_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ComboBoxSelect.SelectedIndexChanged

        DisplayClass()

    End Sub

#End Region

#Region " Private Methods "

    Private Sub DisplayClass()

        With ListViewWin32
            .Visible = False
            .SuspendLayout()
        End With
        MainForm.ToolStripProgressBar1.Visible = True

        ManagementInfo.ManagementInfoToListView(ComboBoxSelect.SelectedItem.ToString().Trim(), ListViewWin32, True, 200, 400, _
                                                MainForm.ToolStripProgressBar1)

        If ListViewWin32.Items.Count = 0 Then
            ManagementInfo.AddGroupForNoResults(ListViewWin32, ComboBoxSelect.SelectedItem.ToString().Trim(), "No Results Returned")
        End If

        ManagementInfo.ResizeListViewColumns(ListViewWin32, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewWin32
            .ResumeLayout()
            .Visible = True
        End With

        MainForm.ToolStripProgressBar1.Visible = False

    End Sub

#End Region

End Class
