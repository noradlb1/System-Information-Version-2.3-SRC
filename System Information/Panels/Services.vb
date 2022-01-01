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

Imports System
Imports System.IO
Imports System.Security
Imports System.Diagnostics
Imports System.Reflection
Imports System.ComponentModel
Imports System.ServiceProcess
Imports Microsoft.Win32

Friend Class Services
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Services

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Services
        If (panelInstance Is Nothing) Then
            panelInstance = New Services()
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
    Private ResourceManager As New  _
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(Services).Assembly)
    Private _Collection As New Collection
    Private _ListViewGroup As ListViewGroup
    Private _Ascending As Boolean = True
    Private _ListViewItem As ListViewItem
    Private _Cancel As Boolean

#End Region

#Region " Private Enums "

    ' Listview column constants.
    Private Enum ListCol
        DisplayName = 0
        StartMode = 1
        State = 2
        PathName = 3
        Description = 4
    End Enum

#End Region

#Region " Panel Event Handlers "

    Private Sub Win32System_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Me.KeyUp

        ' Also cancel with Escape.
        If e.KeyValue = Keys.Escape Then
            ButtonCancel.PerformClick()
        End If

    End Sub

    Private Sub Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Style = ProgressBarStyle.Marquee
        End With

        ' Get services info.
        _Info.Initialize(Initializer.GetServiceInfo)
        LoadAllServices()

        With MainForm.ToolStripProgressBar1
            .Visible = False
            .Style = ProgressBarStyle.Blocks
        End With

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

        StartService()

    End Sub

    Private Sub ContextMenuPause_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuPause.Click

        PauseService()

    End Sub

    Private Sub ContextMenuContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuContinue.Click

        ContinueServices()

    End Sub

    Private Sub ContextMenuStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuStop.Click

        StopService()

    End Sub

    Private Sub ContextMenuShowDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuShowDetails.Click

        ' Display path and description.
        TextBoxPathName.Text = ListViewServices.FocusedItem.SubItems(ListCol.PathName).Text
        TextBoxDescription.Text = ListViewServices.FocusedItem.SubItems(ListCol.Description).Text

    End Sub

    Private Sub ContextMenuStripServices_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ContextMenuStripServices.VisibleChanged

        ' Set all menu items enabled.
        ContextMenuStart.Enabled = True
        ContextMenuPause.Enabled = True
        ContextMenuContinue.Enabled = True
        ContextMenuStop.Enabled = True
        ContextMenuShowDetails.Enabled = True

        ' Clear info textboxes.
        TextBoxPathName.Text = ""
        TextBoxDescription.Text = ""

        Dim proServ As ServiceController = CType(_Collection(ListViewServices.SelectedItems(0).SubItems(6).Text),  _
                        ServiceProcess.ServiceController)

        ' Disable pause and continue if not allowed.
        If Not proServ.CanPauseAndContinue Then
            ContextMenuPause.Enabled = False
            ContextMenuContinue.Enabled = False
        End If

        ' Disable start if already running.
        If proServ.Status = ServiceControllerStatus.Running Then
            ContextMenuStart.Enabled = False
        End If

        ' Disable stop if indicated.
        If Not proServ.CanStop Then
            ContextMenuStop.Enabled = False
        End If

    End Sub

#End Region

#Region " ListView Event Handlers "

    Private Sub ListViewServices_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListViewServices.ItemActivate

        Try
            ' Display path and description.
            TextBoxPathName.Text = ListViewServices.FocusedItem.SubItems(ListCol.PathName).Text
            TextBoxDescription.Text = ListViewServices.FocusedItem.SubItems(ListCol.Description).Text
        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Startup panel ListView." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Set the ListViewItemSorter property to a new ListViewItemComparer 
    ''' object. Setting this property immediately sorts the 
    ''' ListView using the ListViewItemComparer object.
    ''' </summary>
    Private Sub ListViewServices_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewServices.ColumnClick

        ' Toggle sort order.
        If _Ascending = True Then
            _Ascending = False
        Else
            _Ascending = True
        End If

        ' Perform sort of items in specified column.
        ListViewServices.ListViewItemSorter = New ListViewItemComparer(e.Column, _Ascending)

    End Sub

#End Region

#Region " Service Methods "

    ''' <summary>
    ''' Start selected service.
    ''' </summary>
    Private Sub StartService()

        Dim proServ As ServiceProcess.ServiceController

        Try

            proServ = CType(_Collection(ListViewServices.SelectedItems(0).SubItems(6).Text),  _
                            ServiceProcess.ServiceController)
            proServ.Start()
            MessageBox.Show("Service sucessfully started.", My.Application.Info.Title, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllServices()

        Catch ex As Exception
            MessageBox.Show("Service unable to start.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.Cursor = Cursors.Default

    End Sub

    ''' <summary>
    ''' Stop selected service.
    ''' </summary>
    Private Sub StopService()

        Dim proServ As ServiceProcess.ServiceController

        Try

            proServ = CType(_Collection(ListViewServices.SelectedItems(0).SubItems(6).Text),  _
                            ServiceProcess.ServiceController)
            proServ.Stop()
            MessageBox.Show("Service sucessfully stopped.", My.Application.Info.Title, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllServices()

        Catch ex As Exception
            MessageBox.Show("Service unable to stop.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Pause selected service.
    ''' </summary>
    Private Sub PauseService()

        Dim proServ As ServiceProcess.ServiceController

        Try

            proServ = CType(_Collection(ListViewServices.SelectedItems(0).SubItems(6).Text),  _
                            ServiceProcess.ServiceController)
            proServ.Pause()
            MessageBox.Show("Service sucessfully paused.", My.Application.Info.Title, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllServices()

        Catch ex As Exception
            MessageBox.Show("Service unable to pause.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ''' <summary>
    ''' Continue selected service.
    ''' </summary>
    Private Sub ContinueServices()

        Dim proServ As ServiceProcess.ServiceController

        Try

            proServ = CType(_Collection(ListViewServices.SelectedItems(0).SubItems(6).Text),  _
                            ServiceProcess.ServiceController)
            proServ.[Continue]()
            MessageBox.Show("Service sucessfully continued.", My.Application.Info.Title, _
                                MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadAllServices()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            MessageBox.Show("Service unable to continue.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub LoadAllServices()

        Try

            ' Create new group.
            _ListViewGroup = ListViewServices.Groups.Add("Services", "Services")

            Dim services() As ServiceController
            Dim service As ServiceController

            services = ServiceController.GetServices

            _Collection = New Collection

            With MainForm.ToolStripProgressBar1
                .Visible = True
                .Value = 0
                .Maximum = services.Length
            End With

            With ListViewServices
                .Visible = False
                .Items.Clear()
                .SuspendLayout()
            End With

            For i As Integer = 0 To services.Length - 1

                MainForm.ToolStripProgressBar1.Value += 1

                service = services(i)

                _Collection.Add(service, (i + 1).ToString)

                Dim displayName As String = service.DisplayName

                ' Create new listview item.
                _ListViewItem = New ListViewItem(_ListViewGroup)

                ' Add the text.
                _ListViewItem.Text = displayName

                ' Add the subitems.
                With _ListViewItem.SubItems
                    .Add(ReturnAdditionalServiceInfo(displayName, "ServiceStartMode"))
                    .Add(ReturnAdditionalServiceInfo(displayName, "ServiceState"))
                    .Add(ReturnAdditionalServiceInfo(displayName, "ServicePathName"))
                    .Add(ReturnAdditionalServiceInfo(displayName, "ServiceDescription"))
                    .Add(service.ServiceName)
                    .Add((i + 1).ToString)
                End With

                ' Add the item to the listview.
                ListViewServices.Items.Add(_ListViewItem)

                ' Handle user cancel.
                If _Cancel Then
                    _Cancel = False
                    Exit Try
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Services panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

        ManagementInfo.ResizeListViewColumns(ListViewServices, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewServices
            .Sorting = SortOrder.Ascending
            .Sort()
            .ResumeLayout()
            .Visible = True
        End With

        MainForm.ToolStripProgressBar1.Visible = False

        ' Perform sort of items in first column.
        ListViewServices.ListViewItemSorter = New ListViewItemComparer(0, True)

    End Sub

    Private Function ReturnAdditionalServiceInfo(ByVal serviceDisplayName As String, _
                                                 ByVal infoReqested As String) As String
        Dim i As Integer
        Dim returnValue As String = ""

        For Each displayName As String In _Info.ServiceDisplayName
            If serviceDisplayName = displayName Then
                Select Case infoReqested
                    Case "ServiceStartMode"
                        returnValue = _Info.ServiceStartMode(i)
                    Case "ServiceState"
                        returnValue = _Info.ServiceState(i)
                    Case "ServicePathName"
                        returnValue = _Info.ServicePathName(i)
                    Case "ServiceDescription"
                        returnValue = _Info.ServiceDescription(i)
                    Case Else
                        returnValue = ""
                End Select
            End If

            i += 1
        Next

        Return returnValue

    End Function

#End Region

End Class
