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

Imports System.ServiceProcess

Friend Class Drivers
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Drivers

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Drivers
        If (panelInstance Is Nothing) Then
            panelInstance = New Drivers()
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
    Private _Collection As New Collection
    Private _Ascending As Boolean = True
    Private _Cancel As Boolean

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

        ListAllDrivers()

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonCancel.Click

        _Cancel = True

    End Sub

#End Region

#Region " ContextMenu Event Handlers "

    Private Sub ContextMenuStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuStart.Click

        StartDriver()

    End Sub

    Private Sub ContextMenuStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuStop.Click

        StopDriver()

    End Sub

    Private Sub ContextMenuPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuPause.Click

        PauseDriver()

    End Sub

    Private Sub ContextMenuContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuContinue.Click

        ContinueDriver()

    End Sub

    Private Sub ContextMenuStripDrivers_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ContextMenuStripDrivers.VisibleChanged

        ' Enable all menu items.
        ContextMenuContinue.Enabled = True
        ContextMenuPause.Enabled = True
        ContextMenuStart.Enabled = True
        ContextMenuStop.Enabled = True

        Dim proServ As ServiceController = CType(_Collection(ListViewDrivers.SelectedItems(0).SubItems(4).Text),  _
                            ServiceProcess.ServiceController)

        ' Disable menu items that are not available.
        If Not proServ.CanPauseAndContinue Then
            ContextMenuPause.Enabled = False
            ContextMenuContinue.Enabled = False
        End If

        If Not proServ.CanStop Then
            ContextMenuStop.Enabled = False
        End If

        If proServ.Status = ServiceControllerStatus.Running Then
            ContextMenuStart.Enabled = False
        End If

    End Sub

#End Region

#Region " ListView Event Handlers "

    ''' <summary>
    ''' Set the ListViewItemSorter property to a new ListViewItemComparer 
    ''' object. Setting this property immediately sorts the 
    ''' ListView using the ListViewItemComparer object.
    ''' </summary>
    Private Sub ListViewDrivers_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewDrivers.ColumnClick

        ' Toggle sort order.
        If _Ascending = False Then
            _Ascending = True
        Else
            _Ascending = False
        End If

        ' Perform sort of items in specified column.
        ListViewDrivers.ListViewItemSorter = New ListViewItemComparer(e.Column, _Ascending)

    End Sub

#End Region

#Region " Driver Methods "

    ''' <summary>
    ''' Start selected driver.
    ''' </summary>
    Private Sub StartDriver()

        Dim proServ As ServiceController

        Try
            proServ = CType(_Collection(ListViewDrivers.SelectedItems(0).SubItems(4).Text),  _
                            ServiceProcess.ServiceController)
            proServ.Start()

            MessageBox.Show("Driver sucessfully started.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            ListAllDrivers()

        Catch ex As Exception
            MainForm.ToolStripProgressBar1.Visible = False
            MessageBox.Show("Driver unable to start.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Stop selected driver.
    ''' </summary>
    Private Sub StopDriver()

        Dim proServ As ServiceProcess.ServiceController

        Try
            proServ = CType(_Collection(ListViewDrivers.SelectedItems(0).SubItems(4).Text),  _
                            ServiceProcess.ServiceController)
            proServ.Stop()

            MessageBox.Show("Driver sucessfully stopped.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            ListAllDrivers()

        Catch ex As Exception
            MainForm.ToolStripProgressBar1.Visible = False
            MessageBox.Show("Driver unable to stop.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Pause selected driver.
    ''' </summary>
    Private Sub PauseDriver()

        Dim proServ As ServiceProcess.ServiceController

        Try
            proServ = CType(_Collection(ListViewDrivers.SelectedItems(0).SubItems(4).Text),  _
                ServiceProcess.ServiceController)

            proServ.Pause()

            MessageBox.Show("Driver sucessfully paused.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            ListAllDrivers()

        Catch ex As Exception
            MessageBox.Show("Driver unable to pause.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Continue selected driver.
    ''' </summary>
    Private Sub ContinueDriver()

        Dim proServ As ServiceProcess.ServiceController

        Try
            proServ = CType(_Collection(ListViewDrivers.SelectedItems(0).SubItems(4).Text),  _
                ServiceProcess.ServiceController)

            proServ.[Continue]()

            MessageBox.Show("Driver sucessfully continued.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

            ListAllDrivers()

        Catch ex As Exception
            MessageBox.Show("Driver unable to continue.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' List all drivers.
    ''' </summary>
    Private Sub ListAllDrivers()

        Dim allDrivers() As ServiceController
        Dim driver As ServiceController

        allDrivers = ServiceController.GetDevices
        _Collection = New Collection

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Value = 0
        End With

        With ListViewDrivers
            .Visible = False
            .Items.Clear()
            .Sorting = SortOrder.Ascending
            .SuspendLayout()
        End With

        MainForm.ToolStripProgressBar1.Maximum = allDrivers.Length

        ' Sort the drivers since we can't sort a listview shown in groups.
        'Array.Sort(allDrivers)

        _ListViewGroup = ListViewDrivers.Groups.Add("Drivers", "Drivers")

        For i As Integer = 0 To allDrivers.Length - 1

            MainForm.ToolStripProgressBar1.Value += 1

            _ListViewItem = New ListViewItem(_ListViewGroup)

            driver = allDrivers(i)

            _Collection.Add(driver, CStr(i + 1))

            _ListViewItem.Text = driver.DisplayName

            With _ListViewItem.SubItems
                .Add(driver.ServiceName)
                .Add(driver.Status.ToString)
                .Add(driver.ServiceType.ToString)
                .Add(CStr(i + 1))
            End With

            _ListViewItem.ImageIndex = 0

            ListViewDrivers.Items.Add(_ListViewItem)

            ' Handle user cancel.
            If _Cancel Then
                _Cancel = False
                Exit For
            End If

        Next

        ManagementInfo.ResizeListViewColumns(ListViewDrivers, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewDrivers
            .ResumeLayout()
            .Sorting = SortOrder.None
            .Visible = True
        End With

        MainForm.ToolStripProgressBar1.Visible = False

        ' Perform sort of items in first column.
        ListViewDrivers.ListViewItemSorter = New ListViewItemComparer(0, True)

    End Sub

#End Region

End Class
