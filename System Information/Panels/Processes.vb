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

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Collections
Imports System.Diagnostics
Imports System.Threading
Imports System
Imports System.Text
Imports System.IO

Friend Class Processes
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Processes

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Processes
        If (panelInstance Is Nothing) Then
            panelInstance = New Processes()
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

    Private ResourceManager As New  _
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(Processes).Assembly)
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup
    Private _Cancel As Boolean

#End Region

#Region " Constants and Variables "

    ' Boolean used to toggle listview sort.
    Private _Ascending As Boolean = True
    Private _SelectedIndex As Integer
    Private _Info As New ComputerInformation

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Me.KeyUp

        ' Also cancel with Escape.
        If e.KeyValue = Keys.Escape Then
            ButtonCancel.PerformClick()
        End If

    End Sub

    Private Sub Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' Add processes info to listview.
            Dim allProcesses() As Diagnostics.Process = Diagnostics.Process.GetProcesses()

            ' Clear listview.
            With ListViewProcesses
                .Items.Clear()
                .Visible = False
                .SuspendLayout()
            End With

            With MainForm.ToolStripProgressBar1
                .Visible = True
                .Value = 0
                .Maximum = allProcesses.Count
            End With

            ' Create listview group.
            _ListViewGroup = ListViewProcesses.Groups.Add("Processes", "Processes")

            Try
                For Each proc As Diagnostics.Process In allProcesses
                    Try
                        ' Bump the progress bar.
                        MainForm.ToolStripProgressBar1.Value += 1

                        ' Create new listview item.
                        _ListViewItem = New ListViewItem(_ListViewGroup)

                        ' Set the text for the item.
                        _ListViewItem.Text = proc.ProcessName

                        ' Add the subitems.
                        With _ListViewItem
                            .SubItems.Add(proc.Id.ToString)
                            .SubItems.Add(proc.Threads.Count.ToString)
                            Dim processPriority As String = "Normal"
                            Select Case proc.BasePriority
                                Case 13
                                    processPriority = "High"
                                Case 4
                                    processPriority = "Idle"
                                Case 8
                                    processPriority = "Normal"
                                Case 24
                                    processPriority = "Real Time"
                            End Select
                            .SubItems.Add(processPriority)
                            .SubItems.Add(FormatBytes(proc.PrivateMemorySize64))
                            .SubItems.Add(proc.StartTime.ToShortTimeString)
                        End With

                        ' Add the item to the listview.
                        ListViewProcesses.Items.Add(_ListViewItem)

                        ' Handle user cancel.
                        If _Cancel Then
                            _Cancel = False
                            Exit Try
                        End If

                    Catch ex As Exception
                        ' Ignore
                    End Try
                Next
            Catch ex As Exception
                ' Access error: ignore.
            End Try

            ' Indicate number of processes.
            LabelTotalProcesses.Text = "Total Processes: " & allProcesses.Length.ToString("#,#")

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Processes panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

        MainForm.ToolStripProgressBar1.Visible = False

        ManagementInfo.ResizeListViewColumns(ListViewProcesses, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewProcesses
            .ResumeLayout()
            .Visible = True
        End With

        ' Perform sort of items in first column.
        ListViewProcesses.ListViewItemSorter = New ListViewItemComparer(0, True)

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonCancel.Click

        _Cancel = True

    End Sub

#End Region

#Region " ListView Event Handlers "

    ''' <summary>
    ''' Set the ListViewItemSorter property to a new ListViewItemComparer 
    ''' object. Setting this property immediately sorts the 
    ''' ListView using the ListViewItemComparer object.
    ''' </summary>
    Private Sub ListViewProcesses_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewProcesses.ColumnClick

        ' Toggle sort order.
        If _Ascending = True Then
            _Ascending = False
        Else
            _Ascending = True
        End If

        ' Perform sort of items in specified column.
        ListViewProcesses.ListViewItemSorter = New ListViewItemComparer(e.Column, _Ascending)

    End Sub

    Private Sub ListViewProcesses_ItemSelectionChanged(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) _
        Handles ListViewProcesses.ItemSelectionChanged

        If e.IsSelected Then
            _SelectedIndex = e.ItemIndex
        End If

    End Sub

#End Region

#Region " Menu Event Handlers "

    Private Sub MenuEndProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MenuEndProcess.Click

        Dim processId As String = ListViewProcesses.Items(_SelectedIndex).SubItems(1).Text

        Diagnostics.Process.GetProcessById(CInt(processId), _Info.OSMachineName).Kill()

        ListViewProcesses.Items(_SelectedIndex).Remove()

    End Sub

#End Region

#Region " Private Methods "

    Private Shared Function FormatBytes(ByVal bytes As Double) As String
        Dim temp As Double

        If bytes >= 1024 And bytes <= 1073741823 Then
            temp = bytes / 1024 ' KB
            Return String.Format("{0:N0}", temp) & " KB"
        ElseIf bytes = 0 And bytes <= 1023 Then
            temp = bytes    ' bytes
            Return String.Format("{0:N0}", bytes) & " bytes"
        Else
            Return ""
        End If

    End Function

#End Region

End Class
