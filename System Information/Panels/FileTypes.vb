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

Imports System.Security
Imports Microsoft.Win32
Imports System.IO

Friend Class FileTypes
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As FileTypes

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As FileTypes
        If (panelInstance Is Nothing) Then
            panelInstance = New FileTypes()
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
    Private _Native As New NativeMethods
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup
    Private _Cancel As Boolean
    Private ResourceManager As New  _
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(StartupPrograms).Assembly)

#End Region

#Region " Panel Event Handler "

    Private Sub Panel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Me.KeyUp

        ' Also cancel with Escape.
        If e.KeyValue = Keys.Escape Then
            ButtonCancel.PerformClick()
        End If

    End Sub

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Application.DoEvents()
        LoadFileTypes()

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonCancel.Click

        _Cancel = True

    End Sub

#End Region

#Region " FileTypes Methods "

    ''' <summary>
    ''' Loading all files types from registry.
    ''' </summary>
    Private Sub LoadFileTypes()

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Value = 0
        End With

        Dim key As RegistryKey = Nothing
        Dim subKey As RegistryKey = Nothing
        Dim subKeyNames() As String
        Dim errorMsg As String = ""
        Dim imageIndex As Integer = 0

        With ListViewFileTypes
            .Visible = False
            .Items.Clear()
            .SuspendLayout()
        End With

        ' Create new listview group.
        _ListViewGroup = ListViewFileTypes.Groups.Add("File Types", "File Types")

        ImageListFileTypes.Images.Clear()
        ListViewFileTypes.Items.Clear()

        Try
            key = Registry.ClassesRoot.OpenSubKey("", False)
            subKeyNames = key.GetSubKeyNames()

            MainForm.ToolStripProgressBar1.Maximum = subKeyNames.Length

            For Each keyName As String In subKeyNames

                MainForm.ToolStripProgressBar1.Value += 1

                Application.DoEvents()

                If keyName.StartsWith(".") Then

                    ' Create new listview item.
                    _ListViewItem = New ListViewItem(_ListViewGroup)

                    ' Alternate back color of items.
                    If ListViewFileTypes.Items.Count Mod 2 <> 0 Then
                        _ListViewItem.BackColor = Color.White
                    Else
                        _ListViewItem.BackColor = Color.WhiteSmoke
                    End If

                    ' Add the item text.
                    _ListViewItem.Text = keyName

                    subKey = Registry.ClassesRoot.OpenSubKey(keyName, False)
                    Dim description As String = subKey.GetValue("", "").ToString
                    Dim contentType As String = subKey.GetValue("Content Type", "").ToString
                    Dim perceivedType As String = subKey.GetValue("PerceivedType", "").ToString

                    ' Try to locate a subkey under this subkey called "DefaultIcon"
                    Dim iconPath As String = ""
                    Dim iconIndex As Integer = 0

                    If subKey.SubKeyCount > 0 Then
                        Dim subKeys As String() = subKey.GetSubKeyNames

                        For Each subKeyName As String In subKeys

                            Application.DoEvents()

                            If subKeyName = "DefaultIcon" Then
                                Dim iconSubKey As RegistryKey = Nothing
                                Try
                                    iconSubKey = Registry.ClassesRoot.OpenSubKey(keyName & "\" & subKeyName, False)
                                    iconPath = iconSubKey.GetValue("", "").ToString
                                    ' If icon has an index then make sure we use it.
                                    If iconPath.Contains(",") Then
                                        Dim iconInfo() As String = Split(iconPath, ",")
                                        iconPath = iconInfo(0)
                                        iconIndex = CInt(iconInfo(1))
                                    End If
                                Catch ex As Exception
                                    If iconSubKey IsNot Nothing Then
                                        iconSubKey.Close()
                                    End If
                                End Try
                            End If

                            ' Check for user cancel.
                            If _Cancel Then
                                _Cancel = False
                                ManagementInfo.ResizeListViewColumns(ListViewFileTypes, ColumnHeaderAutoResizeStyle.HeaderSize)

                                With ListViewFileTypes
                                    .ResumeLayout()
                                    .Visible = True
                                End With

                                MainForm.ToolStripProgressBar1.Visible = False
                                Exit Try

                            End If

                        Next
                    End If

                    If iconIndex = 0 Then
                        ' Attempt to get application image (icon).
                        If _Native.GetIcon(iconPath) IsNot Nothing Then

                            ' Add the icon to the image list so that the listview can access it.
                            ImageListFileTypes.Images.Add(_Native.GetIcon(iconPath))

                        Else
                            ' If there is no icon, just add a blank image from resources to keep the indexes proper.
                            ImageListFileTypes.Images.Add(CType(ResourceManager.GetObject("Blank"), System.Drawing.Image))
                        End If
                    Else
                        ' Attempt to get application image (icon).
                        If _Native.GetIcon(iconPath, iconIndex) IsNot Nothing Then

                            ' Add the icon to the image list so that the listview can access it.
                            ImageListFileTypes.Images.Add(_Native.GetIcon(iconPath))

                        Else
                            ' If there is no icon, just add a blank image from resources to keep the indexes proper.
                            ImageListFileTypes.Images.Add(CType(ResourceManager.GetObject("Blank"), System.Drawing.Image))
                        End If
                    End If

                    ' Add the image index.
                    _ListViewItem.ImageIndex = imageIndex

                    ' Add the subitems.
                    _ListViewItem.SubItems.Add(description)
                    _ListViewItem.SubItems.Add(contentType)
                    _ListViewItem.SubItems.Add(perceivedType)

                    ' Add the item to the listview.
                    ListViewFileTypes.Items.Add(_ListViewItem)

                    Application.DoEvents()

                    ' Check for user cancel.
                    If _Cancel Then
                        _Cancel = False
                        ManagementInfo.ResizeListViewColumns(ListViewFileTypes, ColumnHeaderAutoResizeStyle.HeaderSize)

                        With ListViewFileTypes
                            .ResumeLayout()
                            .Visible = True
                        End With

                        MainForm.ToolStripProgressBar1.Visible = False
                        Exit Try
                    End If

                    ' Bump count.
                    imageIndex += 1

                End If
            Next
        Catch ex As NullReferenceException
            errorMsg = ex.Message
        Catch ex As ArgumentException
            errorMsg = ex.Message
        Catch ex As ObjectDisposedException
            errorMsg = ex.Message
        Catch ex As SecurityException
            errorMsg = ex.Message
        Finally
            If key IsNot Nothing Then
                key.Close()
            End If
            If subKey IsNot Nothing Then
                subKey.Close()
            End If
        End Try

        If Not String.IsNullOrEmpty(errorMsg) Then
            MessageBox.Show("An error occurred loading file types: " & errorMsg, My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ManagementInfo.ResizeListViewColumns(ListViewFileTypes, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewFileTypes
            .ResumeLayout()
            .Visible = True
        End With

        MainForm.ToolStripProgressBar1.Visible = False

        ' Display the total number of file types.
        LabelNumberFileTypes.Text = ImageListFileTypes.Images.Count.ToString("#,#") & " Registered File Types"

    End Sub

#End Region

End Class
