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

Friend Class Drives
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Drives

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Drives
        If (panelInstance Is Nothing) Then
            panelInstance = New Drives()
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
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            Dim i As Integer
            Dim j As Integer
            Dim index As Integer

            ' Get Information
            _Info = New ComputerInformation
            _Info.Initialize(Initializer.GetDriveInformation)
            _Info.Initialize(Initializer.GetVolumeInfo)

            With MainForm.ToolStripProgressBar1
                .Visible = True
                .Value = 0
                .Maximum = _Info.VolumeLetter.Count + _Info.DriveCapacity.Count + _Info.CDDrive.Count + 2
            End With

            ' Clear ListViewVolumes
            With ListViewVolumes
                .Visible = False
                .Items.Clear()
                .SuspendLayout()
            End With

            ' Create listview group.
            _ListViewGroup = ListViewVolumes.Groups.Add("Volumes", "Volumes")

            ' Fill Volume ListView
            If _Info.VolumeLetter IsNot Nothing Then
                For i = 0 To _Info.VolumeLetter.Count - 1

                    _ListViewItem = New ListViewItem(_ListViewGroup)

                    ' Alternate back color of items.
                    If (ListViewVolumes.Items.Count Mod 2 <> 0) Then
                        _ListViewItem.BackColor = Color.White
                    Else
                        _ListViewItem.BackColor = Color.WhiteSmoke
                    End If

                    MainForm.ToolStripProgressBar1.Value += 1

                    ' Get image list index for drive type
                    index = ReturnImageIndex(_Info.VolumeType.Item(i))

                    ' Set the text for the item.
                    _ListViewItem.Text = _Info.VolumeLetter.Item(i)

                    ' Change removable drive image to USB if drive letter is not "A" or "B"
                    If index = 0 Then
                        If _Info.VolumeLetter.Item(i) = "A:\" Or _Info.VolumeLetter(i) = "B:\" Then
                            index = 0
                        Else
                            index = 4
                        End If
                    End If

                    ' Set the image index for the item.
                    _ListViewItem.ImageIndex = index

                    Try
                        _ListViewItem.SubItems.Add(_Info.VolumeLabel.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.VolumeFileSystem.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.VolumeTotalSize.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.VolumeUsedSpace.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    If _Info.VolumeFreeSpace IsNot Nothing Then
                        _ListViewItem.SubItems.Add(_Info.VolumeFreeSpace.Item(i))
                    Else
                        _ListViewItem.SubItems.Add("N/A")
                    End If

                    Try
                        _ListViewItem.SubItems.Add(_Info.VolumePercentFreeSpace.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    If _Info.VolumeReady IsNot Nothing Then
                        If CBool(_Info.VolumeReady.Item(i)) = True Then
                            _ListViewItem.SubItems.Add("Y")
                        Else
                            _ListViewItem.SubItems.Add("N")
                        End If
                    Else
                        _ListViewItem.SubItems.Add("U")
                    End If

                    ' Add the item to the listview.
                    ListViewVolumes.Items.Add(_ListViewItem)

                Next i
            Else
                ListViewVolumes.Items.Add("")
                ListViewVolumes.Items(0).SubItems.Add("None")
            End If

            ManagementInfo.ResizeListViewColumns(ListViewVolumes, ColumnHeaderAutoResizeStyle.HeaderSize)

            With ListViewVolumes
                .ResumeLayout()
                .Visible = True
            End With

            With ListViewDrives
                .SuspendLayout()
                .Visible = False
            End With

            ' Create listview group.
            _ListViewGroup = ListViewDrives.Groups.Add("Physical Drives", "Physical Drives")

            ' Add physical hard drive information
            If _Info.DriveCapacity IsNot Nothing Then
                For i = 0 To _Info.DriveCapacity.Count - 1

                    MainForm.ToolStripProgressBar1.Value += 1

                    _ListViewItem = New ListViewItem(_ListViewGroup)

                    ' Alternate back color of items.
                    If (ListViewDrives.Items.Count Mod 2 <> 0) Then
                        _ListViewItem.BackColor = Color.White
                    Else
                        _ListViewItem.BackColor = Color.WhiteSmoke
                    End If

                    If _Info.DriveInterface.Item(i).ToString().ToUpper().Contains("USB") Then
                        ' If the drive model includes "USB" use USB image.
                        _ListViewItem.Text = CStr(i)
                        _ListViewItem.ImageIndex = 4
                    Else
                        ' Otherwise use hard drive image.
                        _ListViewItem.Text = CStr(i)
                        _ListViewItem.ImageIndex = 1
                    End If

                    Try
                        _ListViewItem.SubItems.Add(_Info.DriveInterface.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.DriveCapacity.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.DriveModelNo.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.DriveStatus.Item(i))
                    Catch
                        _ListViewItem.SubItems.Add("")
                    End Try

                    ' Add the item to the listview.
                    ListViewDrives.Items.Add(_ListViewItem)

                Next
            Else
                ListViewDrives.Items.Add("")
                ListViewDrives.Items(0).SubItems.Add("Not Available")
            End If

            ' Use this varable to properly number the CDROM drives.
            Dim driveCount As Integer = _Info.DriveCapacity.Count

            ' Add CDROM drive information to the end of hard drives
            If _Info.CDDrive IsNot Nothing Then
                For j = 0 To _Info.CDDrive.Count - 1

                    _ListViewItem = New ListViewItem(_ListViewGroup)

                    MainForm.ToolStripProgressBar1.Value += 1

                    ' Alternate back color of items.
                    If (ListViewDrives.Items.Count Mod 2 <> 0) Then
                        _ListViewItem.BackColor = Color.White
                    Else
                        _ListViewItem.BackColor = Color.WhiteSmoke
                    End If

                    ' Set the text for the item.
                    _ListViewItem.Text = driveCount.ToString()

                    ' Bump this number for the next cdrom drive.
                    driveCount += 1

                    ' Set the image index for the item.
                    _ListViewItem.ImageIndex = 3

                    ' Drive type (interface) is undefined for CD drives.
                    _ListViewItem.SubItems.Add("Optical")

                    Try
                        _ListViewItem.SubItems.Add(_Info.CDMediaSize.Item(j))
                    Catch
                        _ListViewItem.SubItems.Add("")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.CDModel.Item(j))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    Try
                        _ListViewItem.SubItems.Add(_Info.CDStatus.Item(j))
                    Catch
                        _ListViewItem.SubItems.Add("N/A")
                    End Try

                    ' Add the item to the listview.
                    ListViewDrives.Items.Add(_ListViewItem)

                Next
            End If

            ManagementInfo.ResizeListViewColumns(ListViewDrives, ColumnHeaderAutoResizeStyle.HeaderSize)

            With ListViewDrives
                .ResumeLayout()
                .Visible = True
            End With

            MainForm.ToolStripProgressBar1.Visible = False

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Drives panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            MainForm.ToolStripProgressBar1.Visible = False
        End Try

    End Sub

#End Region

#Region " Methods "

    ''' <summary>
    ''' Returns an integer that identifies the drive image in the image list.
    ''' </summary>
    Private Shared Function ReturnImageIndex(ByVal strDriveType As String) As Integer

        Select Case strDriveType.ToLower
            Case "removable"
                Return 0
            Case "fixed"
                Return 1
            Case "network"
                Return 2
            Case "cdrom"
                Return 3
            Case "usb"
                Return 4
            Case Else
                Return 5
        End Select

    End Function

#End Region

End Class
