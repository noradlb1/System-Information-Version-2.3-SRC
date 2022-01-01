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

Imports System.IO
Imports System.Environment
Imports System.Management

Friend Class Shares
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Shares

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Shares
        If (panelInstance Is Nothing) Then
            panelInstance = New Shares()
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
    Private _LastOpenFolder As String
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        My.Settings.Reload()
        _LastOpenFolder = My.Settings.LastOpenFolder

        LoadShares()

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonNewShare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonNewShare.Click

        NewShare()

    End Sub

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonRefresh.Click

        ' Clear new share values.
        TextBoxShareName.Text = ""
        TextBoxDescription.Text = ""
        NumericUpDownShares.Value = 10

        LoadShares()

    End Sub

#End Region

#Region " ContextMenu Event Handlers "

    Private Sub ContextMenuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuDelete.Click

        DeleteShare(ListViewShares.FocusedItem.Text)

    End Sub

    Private Sub ContextMenuRefreshDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuRefreshDisplay.Click

        ButtonRefresh.PerformClick()

    End Sub

#End Region

#Region " Sharing Methods "

    ''' <summary>
    ''' Share selected folder.
    ''' </summary>
    Private Sub NewShare()

        Dim folder As String

        With FolderBrowserDialog1
            If String.IsNullOrEmpty(_LastOpenFolder) Or Not Directory.Exists(_LastOpenFolder) Then
                .SelectedPath = Environment.GetFolderPath(SpecialFolder.MyDocuments)
            Else
                .SelectedPath = _LastOpenFolder
            End If
            .Description = "Select a folder to share"
        End With

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            folder = FolderBrowserDialog1.SelectedPath
            _LastOpenFolder = FolderBrowserDialog1.SelectedPath
            My.Settings.LastOpenFolder = _LastOpenFolder
            My.Settings.Save()

            Dim mgtClass As ManagementClass = New ManagementClass("Win32_Share")
            Dim mbObjIn As ManagementBaseObject
            Dim mbObjOut As ManagementBaseObject

            Try
                mbObjIn = mgtClass.GetMethodParameters("Create")
                mbObjIn("Path") = folder
                If String.IsNullOrEmpty(TextBoxShareName.Text) Then
                    mbObjIn("Name") = folder
                Else
                    mbObjIn("Name") = TextBoxDescription.Text
                End If
                mbObjIn("Type") = 0
                mbObjIn("MaximumAllowed") = NumericUpDownShares.Value.ToString
                mbObjIn("Description") = TextBoxDescription.Text

                mbObjOut = mgtClass.InvokeMethod("Create", mbObjIn, Nothing)

                ' Get return value and create error message.
                Dim msg As String = ""
                Dim returnValue As UInt32 = CUInt(mbObjOut.Properties("ReturnValue").Value)

                Select Case returnValue
                    Case 0
                        msg = "Share was sucessfully created."
                    Case 2
                        msg = "Access Denied"
                    Case 8
                        msg = "Unknown Failure"
                    Case 9
                        msg = "Invalid Name"
                    Case 10
                        msg = "Invalid Level"
                    Case 21
                        msg = "Invalid Parameter"
                    Case 22
                        msg = "Duplicate Share"
                    Case 23
                        msg = "Redirected Path"
                    Case 24
                        msg = "Unknown Device or Directory"
                    Case 25
                        msg = "Net Name Not Found"
                    Case Else
                        msg = "Unknown Error"
                End Select

                MessageBox.Show(msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Refresh display.
                LoadShares()

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                MessageBox.Show("Unable to create new share: " & ex.Message, My.Application.Info.Title, _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub DeleteShare(ByVal shareName As String)

        Dim outParams As ManagementBaseObject = Nothing
        Dim mc As ManagementClass = New ManagementClass("Win32_Share")    ' For local shares.

        Try

            For Each mo As ManagementObject In mc.GetInstances()

                If mo("Name").ToString() = shareName Then
                    outParams = mo.InvokeMethod("Delete", Nothing, Nothing)
                End If
            Next

            ' Get return value and create error message.
            Dim msg As String = ""
            Dim returnValue As UInt32 = CUInt(outParams.Properties("ReturnValue").Value)

            Select Case returnValue
                Case 0
                    msg = "Share was sucessfully deleted."
                Case 2
                    msg = "Access Denied"
                Case 8
                    msg = "Unknown Failure"
                Case 9
                    msg = "Invalid Name"
                Case 10
                    msg = "Invalid Level"
                Case 21
                    msg = "Invalid Parameter"
                Case 22
                    msg = "Duplicate Share"
                Case 23
                    msg = "Redirected Path"
                Case 24
                    msg = "Unknown Device or Directory"
                Case 25
                    msg = "Net Name Not Found"
                Case Else
                    msg = "Unknown Error"
            End Select

            MessageBox.Show(msg, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh display.
            LoadShares()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try

    End Sub

    ''' <summary>
    ''' Loading informations from system management.
    ''' </summary>
    Private Sub LoadShares()

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Value = 0
        End With

        With ListViewShares
            .Items.Clear()
            .SuspendLayout()
            .Visible = False
        End With

        ' Create a new listview group.
        _ListViewGroup = ListViewShares.Groups.Add("Shares", "Shares")

        Dim manObj As ManagementObject
        Dim manClass As New ManagementClass("Win32_Share")
        Dim manObjCol As ManagementObjectCollection = manClass.GetInstances()
        Dim manObjEnumerator As ManagementObjectCollection.ManagementObjectEnumerator = manObjCol.GetEnumerator

        manObjEnumerator.MoveNext()

        Try
            MainForm.ToolStripProgressBar1.Maximum = manObjCol.Count

            For Each manObj In manObjCol
                Try
                    If Not manObj("Name").ToString.EndsWith("$") Then

                        ' Create a new listview item
                        _ListViewItem = New ListViewItem(_ListViewGroup)

                        ' Alternate back color of items.
                        If ListViewShares.Items.Count Mod 2 <> 0 Then
                            _ListViewItem.BackColor = Color.White
                        Else
                            _ListViewItem.BackColor = Color.WhiteSmoke
                        End If

                        ' Choose icon.
                        Dim iconIndex As Integer
                        Select Case Choose(Convert.ToInt32(manObj("Type")) + 1, "Disk", "Printer", "Device", "IPC").ToString
                            Case "Disk"
                                iconIndex = 0
                            Case "Printer"
                                iconIndex = 1
                            Case "Device"
                                iconIndex = 2
                            Case "IPC"
                                iconIndex = 3
                            Case Else
                                iconIndex = 4
                        End Select

                        ' Add the image index.
                        _ListViewItem.ImageIndex = iconIndex

                        ' Add the text.
                        _ListViewItem.Text = manObj("Name").ToString()

                        ' Add the subitems.
                        With _ListViewItem
                        Select manObj("Type").ToString()
                                Case "0"
                                    .SubItems.Add("Disk Drive")
                                Case "1"
                                    .SubItems.Add("Print Queue")
                                Case "2"
                                    .SubItems.Add("Device")
                                Case "3"
                                    .SubItems.Add("IPC")
                                Case "2147483648"
                                    .SubItems.Add("Disk Drive Admin")
                                Case "2147483649"
                                    .SubItems.Add("Print Queue Admin")
                                Case "2147483650"
                                    .SubItems.Add("Device Admin")
                                Case Else
                                    .SubItems.Add("IPC Admin")
                            End Select
                        End With

                        ' Add more subitems.
                        With _ListViewItem
                            .SubItems.Add(manObj("Description").ToString)
                            .SubItems.Add(manObj("Path").ToString)
                        End With

                        ' Add the item to the listview.
                        ListViewShares.Items.Add(_ListViewItem)

                    End If
                Catch ex As Exception
                End Try
                MainForm.ToolStripProgressBar1.Value += 1
            Next

        Catch ex As Exception
            MessageBox.Show("Unable to get share information: " & ex.Message, My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
            MainForm.ToolStripProgressBar1.Visible = False
            Exit Sub
        End Try

        ManagementInfo.ResizeListViewColumns(ListViewShares, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewShares
            .ResumeLayout()
            .Visible = True
        End With

        MainForm.ToolStripProgressBar1.Visible = False

    End Sub

#End Region

End Class

