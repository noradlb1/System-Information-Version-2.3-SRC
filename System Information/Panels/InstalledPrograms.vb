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
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports System.ComponentModel
Imports Microsoft.Win32

Friend Class InstalledPrograms
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As InstalledPrograms

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As InstalledPrograms
        If (panelInstance Is Nothing) Then
            panelInstance = New InstalledPrograms()
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
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(InstalledPrograms).Assembly)

    Private _Ascending As Boolean = True           ' Used to toggle listview sorting.
    Private _Info As New ComputerInformation
    Private _Native As New NativeMethods

    Private _Regkey As RegistryKey
    Private _SubKey As RegistryKey
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup
    Private _Count As Integer                    ' Count of installed programs.
    Private _SubKeyName As String
    Private _ValueNames(300) As String           ' It is very, very unlikely that there will be 300 values.
    Private _AppIcon As Icon                     ' Temporary variable for application icon.
    Private _IconPath As String                  ' Path to application icon.
    Private _IconIndex As Integer                ' Index to application icon in a dll or exe.
    Private _IconFound As Boolean                ' Indicates icon for application has been found.
    Private _Folder As String                    ' Temporary variable for folders.

    ' Installed program data.
    Private _DisplayName As String
    Private _Publisher As String
    Private _DisplayVersion As String
    Private _HelpLink As String
    Private _HelpTelephone As String
    Private _InstallDate As String
    Private _EstimatedSize As String
    Private _UninstallString As String
    Private _TempDate As Date

#End Region

#Region " Constants "

    Private Const c_UninstallKey64Bit As String = "Software\Microsoft\Windows\CurrentVersion\Uninstall"
    Private Const c_UninstallKey32Bit As String = "Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
    Private Const c_MaxPath As Integer = 255

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ' Programmer's comment: Wouldn't it be nice if everyone used the same installation standard?

        RefreshDisplay()

    End Sub

#End Region

#Region " ContextMenu Event Handlers "

    Private Sub ContextMenuUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuUninstall.Click

        Dim uninstallString As String = ""

        Try
            uninstallString = ListViewPrograms.FocusedItem.SubItems(7).Text
        Catch ex As ArgumentOutOfRangeException
            MessageBox.Show("Unable to located uninstall information for this program. " & _
                            "Try Windows or the program uninstall shortcut.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

        If Not String.IsNullOrEmpty(uninstallString) Then

            If Not Uninstall(uninstallString) Then
                MessageBox.Show("Unable to uninstall this program. Try using Windows or the program uninstall shortcut.", _
                                My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If

        Else
            MessageBox.Show("Unable to located uninstall information for this program. " & _
                            "Try Windows or the program uninstall shortcut.", My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If

    End Sub

    Private Sub ContextMenuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuRefresh.Click

        RefreshDisplay()

    End Sub

#End Region

#Region " ListView Event Handlers "

    Private Sub ListViewPrograms_ItemSelectionChanged(ByVal sender As Object, _
                ByVal e As ListViewItemSelectionChangedEventArgs) Handles ListViewPrograms.ItemSelectionChanged

        Try

            If e.IsSelected Then

                ' Get the index of the selected item in the listview.
                Dim i As Integer = e.ItemIndex

                ' All of the information is stored in the listview.
                ' Some items have 0 width, so they do not display.
                LabelDisplayName.Text = ListViewPrograms.Items(i).Text

                ' Hide values if they are not available.
                If ListViewPrograms.Items(i).SubItems.Count > 1 Then
                    If String.IsNullOrEmpty(ListViewPrograms.Items(i).SubItems(2).Text) Then
                        LabelDisplayVersionDesc.Visible = False
                        LabelDisplayVersion.Visible = False
                        LabelDisplayVersion.Text = ""
                    Else
                        LabelDisplayVersionDesc.Visible = True
                        LabelDisplayVersion.Visible = True
                        LabelDisplayVersion.Text = ListViewPrograms.Items(i).SubItems(2).Text
                    End If
                End If

                If ListViewPrograms.Items(i).SubItems.Count > 2 Then
                    If String.IsNullOrEmpty(ListViewPrograms.Items(i).SubItems(3).Text) Then
                        LabelHelpLinkDesc.Visible = False
                        LinkLabelHelpLink.Visible = False
                        LinkLabelHelpLink.Text = ""
                    Else
                        LabelHelpLinkDesc.Visible = True
                        LinkLabelHelpLink.Visible = True
                        LinkLabelHelpLink.Text = ListViewPrograms.Items(i).SubItems(3).Text
                    End If
                End If

                If ListViewPrograms.Items(i).SubItems.Count > 3 Then
                    If String.IsNullOrEmpty(ListViewPrograms.Items(i).SubItems(4).Text) Then
                        LabelHelpTelephoneDesc.Visible = False
                        LabelHelpTelephone.Visible = False
                        LabelHelpTelephone.Text = ""
                    Else
                        LabelHelpTelephoneDesc.Visible = True
                        LabelHelpTelephone.Visible = True
                        LabelHelpTelephone.Text = ListViewPrograms.Items(i).SubItems(4).Text
                    End If
                End If

                If ListViewPrograms.Items(i).SubItems.Count > 4 Then
                    If String.IsNullOrEmpty(ListViewPrograms.Items(i).SubItems(5).Text) Then
                        LabelInstallDateDesc.Visible = False
                        LabelInstallDate.Visible = False
                        LabelInstallDate.Text = ""
                    Else
                        LabelInstallDateDesc.Visible = True
                        LabelInstallDate.Visible = True
                        LabelInstallDate.Text = ListViewPrograms.Items(i).SubItems(5).Text
                    End If
                End If

                If ListViewPrograms.Items(i).SubItems.Count > 5 Then
                    If String.IsNullOrEmpty(ListViewPrograms.Items(i).SubItems(6).Text) Then
                        LabelEstSizeDesc.Visible = False
                        LabelEstimatedSize.Visible = False
                        LabelEstimatedSize.Text = ""
                    Else
                        LabelEstSizeDesc.Visible = True
                        LabelEstimatedSize.Visible = True
                        LabelEstimatedSize.Text = ListViewPrograms.Items(i).SubItems(6).Text
                    End If
                End If

                ' Display the picture.
                PictureBoxProgram.BackgroundImageLayout = ImageLayout.Stretch
                If ListViewPrograms.Items(i).SubItems.Count > 7 Then
                    PictureBoxProgram.BackgroundImage = LargeImageList.Images.Item(CInt(ListViewPrograms.Items(i).SubItems(8).Text))
                End If

            End If

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Installed Programs ListView." & vbCrLf & _
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
    Private Sub ListViewPrograms_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewPrograms.ColumnClick

        ' Toggle sort order.
        If _Ascending = True Then
            _Ascending = False
        Else
            _Ascending = True
        End If

        ' Perform sort of items in specified column.
        ListViewPrograms.ListViewItemSorter = New ListViewItemComparer(e.Column, _Ascending)

    End Sub

#End Region

#Region " Check 32-Bit Programs "

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")> _
    Private Sub Check32BitPrograms()

        ' Do this first for 32-bit programs.
        Try

            ' Image list and listview.
            ListViewPrograms.Items.Clear()
            SmallImageList.Images.Clear()

            ' Create a new listview group.
            _ListViewGroup = ListViewPrograms.Groups.Add("Installed 32-Bit Programs", "Installed 32-Bit Programs")

            ' Open the uninstall key. In 64-Bit systems, 32-Bit information is stored on a special key.
            ' But 32-Bit systems used the same key as 64-Bit systems.
            If _Info.OperatingSystemIs64Bit Then
                _Regkey = Registry.LocalMachine.OpenSubKey(c_UninstallKey32Bit, False)
            Else
                _Regkey = Registry.LocalMachine.OpenSubKey(c_UninstallKey64Bit, False)
            End If

            ' Create 2 new arrays with the first array as the display name.
            ' The second array would be the subkey name (stripped of it's path).
            ' The idea is to sort these alphabetically using the display name
            ' as the key using Array.Sort(array, array).
            Dim displayNames As String() = New String() {}
            Dim subKeyNames As String() = New String() {}
            Dim index As Integer = 0
            Dim count As Integer = 0

            For Each subKeyName As String In _Regkey.GetSubKeyNames
                Try
                    ' Open the sub key; these are in different places for 32-Bit. We only want 32-bit here.
                    If _Info.OperatingSystemIs64Bit Then
                        _SubKey = Registry.LocalMachine.OpenSubKey(c_UninstallKey32Bit & "\" & Path.GetFileName(subKeyName), False)
                    Else
                        _SubKey = Registry.LocalMachine.OpenSubKey(c_UninstallKey64Bit & "\" & Path.GetFileName(subKeyName), False)
                    End If

                    If _SubKey.ValueCount > 0 Then
                        ' Get an array of all value names.
                        Dim valueNames As String() = _SubKey.GetValueNames

                        ' Only display entries that are not system components.
                        If Array.IndexOf(valueNames, "SystemComponent") = -1 Then
                            ' Skip items that don't have display names.
                            If Array.IndexOf(valueNames, "DisplayName") > 0 Then
                                ReDim Preserve displayNames(count)
                                ReDim Preserve subKeyNames(count)
                                displayNames(count) = _SubKey.GetValue("DisplayName").ToString()
                                subKeyNames(count) = Path.GetFileName(_SubKey.Name)
                                count += 1
                            End If
                        End If
                    End If
                    index += 1
                Catch
                Finally
                    If _SubKey IsNot Nothing Then
                        _SubKey.Close()
                    End If
                End Try
            Next

            ' Sort the array.
            Array.Sort(displayNames, subKeyNames)

            ' Get all installed programs.
            For Each _SubKeyName In subKeyNames
                'For Each _SubKeyName In _Regkey.GetSubKeyNames()

                ' Clear the system array holding the value names.
                Array.Clear(_ValueNames, 0, _ValueNames.Length)

                ' Open the sub key.
                If _Info.OperatingSystemIs64Bit Then
                    _SubKey = Registry.LocalMachine.OpenSubKey(c_UninstallKey32Bit & "\" & _SubKeyName, False)
                Else
                    _SubKey = Registry.LocalMachine.OpenSubKey(c_UninstallKey64Bit & "\" & _SubKeyName, False)
                End If

                ' Iterate through all of the values
                If _SubKey.ValueCount > 0 Then

                    ' Save the value names in a system array.
                    _ValueNames = _SubKey.GetValueNames

                    ' Only display entries that are not system components.
                    If Array.IndexOf(_ValueNames, "SystemComponent") = -1 Then

                        ' Only add values that have a display name.
                        If Array.IndexOf(_ValueNames, "DisplayName") > 0 Then
                            ' Set iconFound to false since we have not found an icon for this item.
                            _IconFound = False

                            ' Get the display name.
                            _DisplayName = _SubKey.GetValue("DisplayName").ToString()

                            ' Get the publisher.
                            If Array.IndexOf(_ValueNames, "Publisher") > 0 Then
                                _Publisher = _SubKey.GetValue("Publisher").ToString()
                            Else
                                _Publisher = ""
                            End If

                            ' Get the display version.
                            If Array.IndexOf(_ValueNames, "DisplayVersion") > 0 Then
                                _DisplayVersion = _SubKey.GetValue("DisplayVersion").ToString()
                            Else
                                _DisplayVersion = ""
                            End If

                            ' Get the help link.
                            If Array.IndexOf(_ValueNames, "HelpLink") > 0 Then
                                _HelpLink = _SubKey.GetValue("HelpLink").ToString()
                            Else
                                _HelpLink = " "
                            End If

                            ' Get the help telephone.
                            If Array.IndexOf(_ValueNames, "HelpTelephone") > 0 Then
                                _HelpTelephone = _SubKey.GetValue("HelpTelephone").ToString()
                            Else
                                _HelpTelephone = ""
                            End If

                            ' Get the uninstall string.
                            If Array.IndexOf(_ValueNames, "UninstallString") > 0 Then
                                _UninstallString = _SubKey.GetValue("UninstallString").ToString()
                            Else
                                _UninstallString = ""
                            End If

                            ' Get the install date.
                            If Array.IndexOf(_ValueNames, "InstallDate") > 0 Then
                                _InstallDate = _SubKey.GetValue("InstallDate").ToString()

                                Try
                                    If Not (_InstallDate.Contains(",") Or _InstallDate.Contains("/")) Then
                                        ' If the install date does not contains "/" or ",",
                                        ' assume that the date format is YYYYMMDD.
                                        _InstallDate = New DateTime(CInt(_InstallDate.Substring(0, 4)), CInt(_InstallDate.Substring(4, 2)), CInt(_InstallDate.Substring(6, 2))).ToLongDateString()
                                        ' Remove the day of the week.
                                        _InstallDate = _InstallDate.Remove(0, _InstallDate.IndexOf(",") + 2)
                                    ElseIf _InstallDate.Contains("/") Then
                                        ' Declare tempDate As Date at the top of the method.
                                        ' TryParse will place the Date of the string in local format in tempDate.
                                        DateTime.TryParse(_InstallDate, _TempDate)
                                        ' Use the Framework to extract a local long date string.
                                        _InstallDate = _TempDate.ToLongDateString()
                                        ' Remove the day of the week.
                                        _InstallDate = _InstallDate.Remove(0, _InstallDate.IndexOf(",") + 2)
                                    End If
                                Catch ex As Exception
                                    _InstallDate = ""
                                End Try
                            Else
                                _InstallDate = ""
                            End If

                            ' Get the estimated size.
                            If Array.IndexOf(_ValueNames, "EstimatedSize") > 0 Then
                                ' EstimateSize is a DWORD, so it needs to be formatted as megabytes.
                                _EstimatedSize = String.Format("{0:N2}", _
                                    CDbl(_SubKey.GetValue("EstimatedSize")) / 1024) & " MB"
                            Else
                                _EstimatedSize = ""
                            End If

                            ' If there is a display icon, and add to image list.
                            If Array.IndexOf(_ValueNames, "DisplayIcon") > 0 Then
                                Try
                                    _IconPath = _SubKey.GetValue("DisplayIcon").ToString()

                                    If String.IsNullOrEmpty(_IconPath) Then
                                        _IconFound = False

                                    ElseIf _IconPath.Contains(",") Then

                                        ' Check if DisplayIcon contain an icon indes.
                                        _IconIndex = CInt(_IconPath.Substring(_IconPath.IndexOf(",") + 1, 1))
                                        _IconPath = _IconPath.Substring(0, _IconPath.IndexOf(",") - 1)

                                        ' Get the icon.
                                        _AppIcon = _Native.GetIcon(_IconPath, _IconIndex)

                                        If _AppIcon IsNot Nothing Then
                                            ' Add the icon to the both the small and image lists.
                                            AddIcon(_AppIcon)
                                            _IconFound = True
                                        End If
                                    Else
                                        ' Get the icon.
                                        _AppIcon = _Native.GetIcon(_IconPath)

                                        If _AppIcon IsNot Nothing Then
                                            ' Add the icon to the both the small and image lists.
                                            AddIcon(_AppIcon)
                                            _IconFound = True
                                        End If
                                    End If
                                Catch ex As Exception
                                    _IconFound = False

                                End Try
                            End If ' If there is a display icon, and add to image list.

                            ' Now try searching in Program Files for the Publisher\Display Name.
                            _Folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & _
                                    "\" & _Publisher & "\" & _DisplayName

                            If _IconFound = False Then
                                ' Look for executible files first.
                                _IconFound = SearchFolder(_Folder, "*.exe", True)
                            End If

                            If _IconFound = False Then
                                ' Look for icon files next.
                                _IconFound = SearchFolder(_Folder, "*.ico", True)
                            End If

                            ' Next try searching in Program Files for the  just the Display Name.
                            _Folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & _
                                     "\" & _DisplayName

                            If _IconFound = False Then
                                ' Look for executible files first.
                                _IconFound = SearchFolder(_Folder, "*.exe", True)
                            End If

                            If _IconFound = False Then
                                ' Look for icon files next.
                                _IconFound = SearchFolder(_Folder, "*.ico", True)
                            End If

                            ' Finally, check uninstall key that begin with "{" because icons for
                            ' Windows Installer installations may be stored in WINDOWS\Installer\KeyName.
                            If _SubKeyName.StartsWith("{") And _IconFound = False Then

                                _Folder = Environment.GetEnvironmentVariable("windir") & "\Installer\" & _SubKeyName

                                If Directory.Exists(_Folder) Then
                                    If _IconFound = False Then
                                        ' Look for an executible file first.
                                        _IconFound = SearchFolder(_Folder, "*.exe", False)
                                    End If

                                    If _IconFound = False Then
                                        ' Look for an an icon file next.
                                        _IconFound = SearchFolder(_Folder, "*.ico", False)
                                    End If

                                    If _IconFound = False Then
                                        ' Look for an an file that contains "ArpIco" next.
                                        _IconFound = SearchFolder(_Folder, "*ArpIco*", False)
                                    End If

                                End If ' Check uninstall key that begin with "{".
                            End If

                            ' If no icon was found, add a blank icon.
                            If _IconFound = False Then
                                AddGenericIcon()
                            End If

                            ' Create a new listview item.
                            _ListViewItem = New ListViewItem(_ListViewGroup)

                            ' Add the text to the item.
                            _ListViewItem.Text = _DisplayName

                            ' Add the image index.
                            _ListViewItem.ImageIndex = _Count

                            ' Add the other entries as subitems.
                            _ListViewItem.SubItems.Add(_Publisher)
                            _ListViewItem.SubItems.Add(_DisplayVersion)
                            _ListViewItem.SubItems.Add(_HelpLink)
                            _ListViewItem.SubItems.Add(_HelpTelephone)
                            _ListViewItem.SubItems.Add(_InstallDate)
                            _ListViewItem.SubItems.Add(_EstimatedSize)
                            _ListViewItem.SubItems.Add(_UninstallString)
                            _ListViewItem.SubItems.Add(CStr(_Count))    ' Icon Number.

                            ' Add the item to the listview.
                            ListViewPrograms.Items.Add(_ListViewItem)

                            _Count += 1

                        End If ' Only add values that have a display name.
                    End If ' Only display entries that are not system components.
                End If ' Iterate through all of the values
            Next ' Get all installed programs.

        Catch ex As NullReferenceException
            MsgBox(ex.Message) ' Do nothing.
        Catch ex As FormatException
            MsgBox(ex.Message) ' Do nothing.
        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Installed Programs panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        Finally
            If _Regkey IsNot Nothing Then
                ' Close the registry key.
                _Regkey.Close()
            End If
            If _SubKey IsNot Nothing Then
                'Close the registry key.
                _SubKey.Close()
            End If
            If Not _Info.OperatingSystemIs64Bit Then MainForm.ToolStripProgressBar1.Visible = False
        End Try
    End Sub

#End Region

#Region " Check 64-Bit Programs "

    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1806:DoNotIgnoreMethodResults")> _
    Private Sub Check64BitPrograms()

        Try
            If _Info.OperatingSystemIs64Bit Then
                ' Do this first next 64-bit programs.

                ' Create a new listview group.
                _ListViewGroup = ListViewPrograms.Groups.Add("Installed 64-Bit Programs", "Installed 64-Bit Programs")

                ' Open the uninstall key.
                _Regkey = Registry.LocalMachine.OpenSubKey(c_UninstallKey64Bit, False)

                ' Create 2 new arrays with the first array as the display name.
                ' The second array would be the subkey name (stripped of it's path).
                ' The idea is to sort these alphabetically using the display name
                ' as the key using Array.Sort(array, array).
                Dim displayNames As String() = New String() {}
                Dim subKeyNames As String() = New String() {}
                Dim index As Integer = 0
                Dim count As Integer = 0
                Dim subKey As RegistryKey

                For Each subKeyName As String In _Regkey.GetSubKeyNames

                    ' Open the sub key. Since we are only looking for 64-bit programs here, 
                    ' they will be in the same place as normal 32-bit programs. The other
                    ' programs would have been picked up by the 32-bit method.
                    Try
                        subKey = Registry.LocalMachine.OpenSubKey(c_UninstallKey64Bit & "\" & Path.GetFileName(subKeyName), False)
                    Catch
                        index += 1
                        Continue For
                    End Try

                    Try
                        If subKey.ValueCount > 0 Then
                            ' Get an array of all value names.
                            Dim valueNames As String() = subKey.GetValueNames

                            ' Only display entries that are not system components.
                            If Array.IndexOf(valueNames, "SystemComponent") = -1 Then
                                ' Skip items that don't have display names.
                                If Array.IndexOf(valueNames, "DisplayName") > 0 Then
                                    ReDim Preserve displayNames(count)
                                    ReDim Preserve subKeyNames(count)
                                    displayNames(count) = subKey.GetValue("DisplayName").ToString()
                                    subKeyNames(count) = Path.GetFileName(subKey.Name)
                                    count += 1
                                End If
                            End If
                        End If
                        index += 1
                    Catch ex As Exception
                        index += 1
                        Continue For
                    Finally
                        If subKey IsNot Nothing Then
                            subKey.Close()
                        End If
                    End Try
                Next

                ' Sort the array.
                Array.Sort(displayNames, subKeyNames)

                ' Get all installed programs.
                'For Each _SubKeyName In _Regkey.GetSubKeyNames()
                For Each _SubKeyName In subKeyNames

                    ' Clear the system array holding the value names.
                    Array.Clear(_ValueNames, 0, _ValueNames.Length)

                    ' Open the sub key.
                    _SubKey = Registry.LocalMachine.OpenSubKey(c_UninstallKey64Bit & "\" & _SubKeyName, False)

                    ' Iterate through all of the values
                    If _SubKey.ValueCount > 0 Then

                        ' Save the value names in a system array.
                        _ValueNames = _SubKey.GetValueNames

                        ' Only display entries that are not system components.
                        If Array.IndexOf(_ValueNames, "SystemComponent") = -1 Then

                            ' Only add values that have a display name.
                            If Array.IndexOf(_ValueNames, "DisplayName") > 0 Then

                                ' Set iconFound to false since we have not found an icon for this item.
                                _IconFound = False

                                ' Get the display name.
                                _DisplayName = _SubKey.GetValue("DisplayName").ToString()

                                ' Get the publisher.
                                If Array.IndexOf(_ValueNames, "Publisher") > 0 Then
                                    _Publisher = _SubKey.GetValue("Publisher").ToString()
                                Else
                                    _Publisher = ""
                                End If

                                ' Get the display version.
                                If Array.IndexOf(_ValueNames, "DisplayVersion") > 0 Then
                                    _DisplayVersion = _SubKey.GetValue("DisplayVersion").ToString()
                                Else
                                    _DisplayVersion = ""
                                End If

                                ' Get the help link.
                                If Array.IndexOf(_ValueNames, "HelpLink") > 0 Then
                                    _HelpLink = _SubKey.GetValue("HelpLink").ToString()
                                Else
                                    _HelpLink = ""
                                End If

                                ' Get the help telephone.
                                If Array.IndexOf(_ValueNames, "HelpTelephone") > 0 Then
                                    _HelpTelephone = _SubKey.GetValue("HelpTelephone").ToString()
                                Else
                                    _HelpTelephone = ""
                                End If

                                ' Get the uninstall string.
                                If Array.IndexOf(_ValueNames, "UninstallString") > 0 Then
                                    _UninstallString = _SubKey.GetValue("UninstallString").ToString()
                                Else
                                    _UninstallString = ""
                                End If

                                ' Get the install date.
                                If Array.IndexOf(_ValueNames, "_InstallDate") > 0 Then
                                    _InstallDate = _SubKey.GetValue("InstallDate").ToString()

                                    If Not (_InstallDate.Contains(",") Or _InstallDate.Contains("/")) Then
                                        ' If the install date does not contains "/" or ",",
                                        ' assume that the date format is YYYYMMDD.
                                        _InstallDate = New DateTime(CInt(_InstallDate.Substring(0, 4)), CInt(_InstallDate.Substring(4, 2)), CInt(_InstallDate.Substring(6, 2))).ToLongDateString()
                                        ' Remove the day of the week.
                                        _InstallDate = _InstallDate.Remove(0, _InstallDate.IndexOf(",") + 2)
                                    ElseIf _InstallDate.Contains("/") Then
                                        ' Declare tempDate As Date at the top of the method.
                                        ' TryParse will place the Date of the string in local format in tempDate.
                                        DateTime.TryParse(_InstallDate, _TempDate)
                                        ' Use the Framework to extract a local long date string.
                                        If Not String.IsNullOrEmpty(_TempDate.ToShortDateString) Then
                                            _InstallDate = _TempDate.ToLongDateString()
                                            ' Remove the day of the week.
                                            _InstallDate = _InstallDate.Remove(0, _InstallDate.IndexOf(",") + 2)
                                        Else
                                            _InstallDate = "Unknown"
                                        End If
                                    End If

                                Else
                                    _InstallDate = ""
                                End If

                                ' Get the estimated size.
                                If Array.IndexOf(_ValueNames, "EstimatedSize") > 0 Then
                                    ' EstimateSize is a DWORD, so it needs to be formatted as megabytes.
                                    _EstimatedSize = String.Format("{0:N2}", _
                                        CDbl(_SubKey.GetValue("EstimatedSize")) / 1024) & " MB"
                                Else
                                    _EstimatedSize = ""
                                End If

                                ' If there is a display icon, and add to image list.
                                If Array.IndexOf(_ValueNames, "DisplayIcon") > 0 Then

                                    _IconPath = _SubKey.GetValue("DisplayIcon").ToString()

                                    If String.IsNullOrEmpty(_IconPath) Then

                                        _IconFound = False

                                    ElseIf _IconPath.Contains(",") Then

                                        ' Check if DisplayIcon contain an icon indes.
                                        _IconIndex = CInt(_IconPath.Substring(_IconPath.IndexOf(",") + 1, 1))
                                        _IconPath = _IconPath.Substring(0, _IconPath.IndexOf(",") - 1)

                                        ' Get the icon.
                                        _AppIcon = _Native.GetIcon(_IconPath, _IconIndex)

                                        If _AppIcon IsNot Nothing Then
                                            ' Add the icon to the both the small and image lists.
                                            AddIcon(_AppIcon)
                                            _IconFound = True
                                        End If
                                    Else
                                        ' Get the icon.
                                        _AppIcon = _Native.GetIcon(_IconPath)

                                        If _AppIcon IsNot Nothing Then
                                            ' Add the icon to the both the small and image lists.
                                            AddIcon(_AppIcon)
                                            _IconFound = True
                                        End If
                                    End If

                                End If ' If there is a display icon, and add to image list.

                                ' Now try searching in Program Files for the Publisher\Display Name.
                                _Folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & _
                                        "\" & _Publisher & "\" & _DisplayName

                                If _IconFound = False Then
                                    ' Look for executible files first.
                                    _IconFound = SearchFolder(_Folder, "*.exe", True)
                                End If

                                If _IconFound = False Then
                                    ' Look for icon files next.
                                    _IconFound = SearchFolder(_Folder, "*.ico", True)
                                End If

                                ' Next try searching in Program Files for the  just the Display Name.
                                _Folder = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) & _
                                         "\" & _DisplayName

                                If _IconFound = False Then
                                    ' Look for executible files first.
                                    _IconFound = SearchFolder(_Folder, "*.exe", True)
                                End If

                                If _IconFound = False Then
                                    ' Look for icon files next.
                                    _IconFound = SearchFolder(_Folder, "*.ico", True)
                                End If

                                ' Finally, check uninstall key that begin with "{" because icons for
                                ' Windows Installer installations may be stored in WINDOWS\Installer\KeyName.
                                If _SubKeyName.StartsWith("{") And _IconFound = False Then

                                    _Folder = Environment.GetEnvironmentVariable("windir") & "\Installer\" _
                                        & _SubKeyName

                                    If Directory.Exists(_Folder) Then
                                        If _IconFound = False Then
                                            ' Look for an executible file first.
                                            _IconFound = SearchFolder(_Folder, "*.exe", False)
                                        End If

                                        If _IconFound = False Then
                                            ' Look for an an icon file next.
                                            _IconFound = SearchFolder(_Folder, "*.ico", False)
                                        End If

                                        If _IconFound = False Then
                                            ' Look for an an file that contains "ArpIco" next.
                                            _IconFound = SearchFolder(_Folder, "*ArpIco*", False)
                                        End If

                                    End If ' Check uninstall key that begin with "{".
                                End If

                                ' If no icon was found, add a blank icon.
                                If _IconFound = False Then
                                    AddGenericIcon()
                                End If

                                ' Create a new listview item.
                                _ListViewItem = New ListViewItem(_ListViewGroup)

                                ' Add the text to the item.
                                _ListViewItem.Text = _DisplayName

                                ' Add the image index to the item.
                                _ListViewItem.ImageIndex = _Count

                                ' Add the other entries as subitems.
                                _ListViewItem.SubItems.Add(_Publisher)
                                _ListViewItem.SubItems.Add(_DisplayVersion)
                                _ListViewItem.SubItems.Add(_HelpLink)
                                _ListViewItem.SubItems.Add(_HelpTelephone)
                                _ListViewItem.SubItems.Add(_InstallDate)
                                _ListViewItem.SubItems.Add(_EstimatedSize)
                                _ListViewItem.SubItems.Add(_UninstallString)
                                _ListViewItem.SubItems.Add(CStr(_Count))    ' Icon Number.

                                ' Add the item to the listview.
                                ListViewPrograms.Items.Add(_ListViewItem)

                                ' Bump count of programs.
                                _Count += 1

                            End If ' Only add values that have a display name.
                        End If ' Only display entries that are not system components.
                    End If ' Iterate through all of the values
                Next ' Get all installed programs.

            End If
        Catch ex As NullReferenceException
            ' Do nothing.
            MsgBox(ex.Message)
        Catch ex As FormatException
            ' Do nothing.
            MsgBox(ex.Message)
        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Installed Programs panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        Finally

            If _Regkey IsNot Nothing Then
                ' Close the registry key.
                _Regkey.Close()
            End If

            If _SubKey IsNot Nothing Then
                'Close the registry key.
                _SubKey.Close()
            End If

            MainForm.ToolStripProgressBar1.Visible = False

        End Try
    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Displays or refreshes the list of installed programs.
    ''' </summary>
    Private Sub RefreshDisplay()

        _Count = 0

        With ListViewPrograms
            .Visible = False
            .SuspendLayout()
        End With

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Style = ProgressBarStyle.Marquee
        End With

        Application.DoEvents()

        Check32BitPrograms()

        ' Display total items.
        If Not _Info.OperatingSystemIs64Bit Then LabelNumberPrograms.Text = (_Count - 1).ToString() & " Items"

        ' Sort the listview.
        If Not _Info.OperatingSystemIs64Bit Then

            ' Display total items.
            LabelNumberPrograms.Text = (_Count - 1).ToString() & " Items"

            ManagementInfo.ResizeListViewColumns(ListViewPrograms, ColumnHeaderAutoResizeStyle.HeaderSize)
            With ListViewPrograms
                .ResumeLayout()
                .Visible = True
            End With
        End If

        If _Info.OperatingSystemIs64Bit Then
            Check64BitPrograms()

            ' Display total items.
            LabelNumberPrograms.Text = (_Count - 1).ToString() & " Items"

            ManagementInfo.ResizeListViewColumns(ListViewPrograms, ColumnHeaderAutoResizeStyle.HeaderSize)
            With ListViewPrograms
                .ResumeLayout()
                .Visible = True
            End With
        End If

        With MainForm.ToolStripProgressBar1
            .Visible = False
            .Style = ProgressBarStyle.Blocks
        End With

        ' Perform sort of items in first column.
        ListViewPrograms.ListViewItemSorter = New ListViewItemComparer(0, True)

    End Sub

    ''' <summary>
    ''' Uninstalls a program using the UninstallString found in the registry.
    ''' This is stored along with the other information in the listview.
    ''' </summary>
    Private Function Uninstall(ByVal uninstallString As String) As Boolean

        ' Separate the file name from the arguments.
        Dim separatedParts As String() = ReturnFileNameAndArguments(uninstallString)
        Dim fileName As String = separatedParts(0)
        Dim arguments As String = separatedParts(1)

        ' Just quit if the file name is blank.
        If String.IsNullOrEmpty(fileName) Then Return False

        Try

            ' Try starting the process exactly as given in the UninstallString.
            If String.IsNullOrEmpty(arguments) Then
                Process.Start(fileName)
                RefreshDisplay()
                Return True
            Else
                Process.Start(fileName, arguments)
                RefreshDisplay()
                Return True
            End If

        Catch ex As IOException
        Catch ex As Win32Exception
        Catch ex As ArgumentNullException
        Catch ex As InvalidOperationException
        End Try

        ' If this fails try adding the path in the path environment variable one at a time.
        Dim pathArray As String() = Split(Environment.GetEnvironmentVariable("Path"), ";")

        For Each path As String In pathArray

            ' Add a trailing "\" if required.
            If Not path.EndsWith("\") Then
                path &= "\"
            End If

            Try

                If String.IsNullOrEmpty(arguments) Then
                    Process.Start(fileName)
                    RefreshDisplay()
                    Return True
                Else
                    Process.Start(path & fileName, arguments)
                    RefreshDisplay()
                    Return True
                End If

            Catch ex As IOException
            Catch ex As Win32Exception
            Catch ex As ArgumentNullException
            Catch ex As InvalidOperationException
            End Try

        Next

    End Function

    ''' <summary>
    ''' Given the UninstallString from the registry, this method attempts to
    ''' separate the command from the arguments.
    ''' </summary>
    Private Shared Function ReturnFileNameAndArguments(ByVal uninstallString As String) As String()

        Dim returnValue(2) As String

        Try

            ' Take care of filename that end with an extension.
            Dim fileNameLength As Integer

            If uninstallString.Contains(".exe") Then
                fileNameLength = uninstallString.IndexOf(".exe") + 4
            Else
                ' If there is no extension, use the first space.
                fileNameLength = uninstallString.IndexOf(" ")
            End If

            ' Extract the file name.
            If fileNameLength > 0 Then
                returnValue(0) = uninstallString.Substring(0, fileNameLength)
                ' Make sure the file name has leading and trailing quotes.
                If Not returnValue(0).Contains("""") Then
                    returnValue(0) = """" & returnValue(0) & """"
                ElseIf returnValue(0).StartsWith("""") And Not returnValue(0).EndsWith("""") Then
                    returnValue(0) = returnValue(0) & """"
                ElseIf returnValue(0).EndsWith("""") And Not returnValue(0).StartsWith("""") Then
                    returnValue(0) = """" & returnValue(0)
                End If
            End If

            ' Extract the arguments.
            If uninstallString.Length > returnValue(0).Length Then
                returnValue(1) = uninstallString.Substring(fileNameLength + 1, uninstallString.Length - fileNameLength - 1)
            End If
        Catch ex As Exception
            ' Ignore
        End Try

        Return returnValue

    End Function

    ''' <summary>
    ''' Adds a icon to both image lists.
    ''' </summary>
    ''' <param name="newIcon">Icon to be added.</param>
    Private Sub AddIcon(ByVal newIcon As Icon)

        ' Add the icon to the small image list.
        SmallImageList.Images.Add(newIcon)

        ' Also add the icon to the large image list.
        LargeImageList.Images.Add(newIcon)

    End Sub

    ''' <summary>
    ''' Adds a blank icon to both image lists.
    ''' </summary>
    Private Sub AddGenericIcon()

        ' Add a generic icon to the small image list.
        SmallImageList.Images.Add(CType(ResourceManager.GetObject("GenericSmall"),  _
            System.Drawing.Icon))

        ' Add a generic icon to the large image list.
        LargeImageList.Images.Add(CType(ResourceManager.GetObject("GenericLarge"),  _
           System.Drawing.Icon))

    End Sub

    ''' <summary>
    ''' Search folder using search pattern. If icon is found, it is added to both image lists.
    ''' </summary>
    ''' <param name="folder">Folder to be searched.</param>
    ''' <param name="searchPattern">Matching pattern</param>
    ''' <param name="searchSubDirs">If true, subdirectories are also searched.</param>
    ''' <returns>Return true if icon is found.</returns>
    Private Function SearchFolder(ByVal folder As String, ByVal searchPattern As String, _
        ByVal searchSubDirs As Boolean) As Boolean

        Dim iconPath As String
        Dim appIcon As Icon
        Dim found As Boolean
        Dim searchOpt As SearchOption

        ' Change a boolean method parameter to a SearchOption.
        If searchSubDirs Then
            searchOpt = SearchOption.AllDirectories
        Else
            searchOpt = SearchOption.TopDirectoryOnly
        End If

        ' Verify that the folder exists.
        If Directory.Exists(folder) Then

            For Each iconPath In Directory.GetFiles(folder, searchPattern, searchOpt)

                If iconPath.Contains("Adobe.ico") Or iconPath.Contains("GAC.exe") Then
                    ' Skip these files that are common on my computer. Add additional ones as you desire.
                ElseIf iconPath.Length <= c_MaxPath And File.Exists(iconPath) Then
                    ' Check to make sure the file is a valid icon.
                    appIcon = _Native.GetIcon(iconPath)
                    If appIcon IsNot Nothing Then
                        AddIcon(appIcon)
                        found = True
                        Exit For           ' This exit for must be here for this to work!
                    Else
                        found = False
                    End If
                End If
            Next

        Else
            ' If directory is not valid, return false.
            found = False
        End If

        ' Return result
        Return found

    End Function

#End Region

#Region " LinkLabel Event Handlers "

    Private Sub LinkLabelHelpLink_LinkClicked(ByVal sender As System.Object, ByVal e As  _
        System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelHelpLink.LinkClicked

        ' Open the link in the default browser.
        Try
            Dim startInfo As New ProcessStartInfo(LinkLabelHelpLink.Text)
            startInfo.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(startInfo)
        Catch
            ' cannot find file
            MessageBox.Show("Unable to open website.", Application.ProductName, _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

#End Region

End Class

