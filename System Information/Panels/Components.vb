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

Imports Microsoft.Win32

Friend Class Component
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Component

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Component
        If (panelInstance Is Nothing) Then
            panelInstance = New Component()
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
    Private _Ascending As Boolean = True

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Me.KeyUp

        ' Also cancel with Escape.
        If e.KeyValue = Keys.Escape Then
            ButtonCancel.PerformClick()
        End If

    End Sub

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        LoadComponents()

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonCancel.Click

        ManagementInfo.Cancel()

    End Sub

#End Region

#Region " ListView Event Handlers "

    ''' <summary>
    ''' Set the ListViewItemSorter property to a new ListViewItemComparer 
    ''' object. Setting this property immediately sorts the 
    ''' ListView using the ListViewItemComparer object.
    ''' </summary>
    Private Sub ListViewComponents_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewComponents.ColumnClick

        ' Toggle sort order.
        If _Ascending = False Then
            _Ascending = True
        Else
            _Ascending = False
        End If

        ' Perform sort of items in specified column.
        ListViewComponents.ListViewItemSorter = New ListViewItemComparer(e.Column, _Ascending)

    End Sub

#End Region

#Region " Components Methods "

    ''' <summary>
    ''' Loading all components from registry.
    ''' </summary>
    Private Sub LoadComponents()

        Dim regKey As RegistryKey = Nothing
        Dim subKey As RegistryKey = Nothing
        Dim subKeyNames() As String

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Value = 0
        End With

        With ListViewComponents
            .Visible = True
            .Items.Clear()
            .Sorting = SortOrder.Ascending
            .SuspendLayout()
        End With

        Try
            regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Active Setup\Installed Components")
            subKeyNames = regKey.GetSubKeyNames()

            ' Create listview group.
            _ListViewGroup = ListViewComponents.Groups.Add("Components", "Components")

            Dim component As String

            MainForm.ToolStripProgressBar1.Maximum = subKeyNames.Length

            For Each component In subKeyNames

                MainForm.ToolStripProgressBar1.Value += 1

                _ListViewItem = New ListViewItem(_ListViewGroup)

                subKey = regKey.OpenSubKey(component)

                ' Add the text for the item.
                _ListViewItem.Text = subKey.GetValue("", "").ToString()

                ' Add the subitems.
                _ListViewItem.SubItems.Add(subKey.GetValue("ComponentID", "").ToString)
                _ListViewItem.SubItems.Add(subKey.GetValue("Version", "").ToString)
                _ListViewItem.SubItems.Add(subKey.GetValue("Locale", "").ToString)
                _ListViewItem.SubItems.Add(subKey.GetValue("StubPath", "").ToString)
                _ListViewItem.SubItems.Add(subKey.GetValue("KeyFileName", "").ToString)

                ' Set the image index.
                _ListViewItem.ImageIndex = 0

                ' Add the item to the listview.
                ListViewComponents.Items.Add(_ListViewItem)

            Next
        Catch ex As Exception
            MessageBox.Show("Unable to load components: " & ex.Message, My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Close keys.
            If regKey IsNot Nothing Then
                regKey.Close()
            End If
            If subKey IsNot Nothing Then
                subKey.Close()
            End If
        End Try

        ListViewComponents.ResumeLayout()

        MainForm.ToolStripProgressBar1.Visible = False

        ' Perform sort of items in first column.
        ListViewComponents.ListViewItemSorter = New ListViewItemComparer(0, True)

    End Sub

#End Region

End Class
