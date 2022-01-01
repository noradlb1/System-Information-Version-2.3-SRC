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
Imports System.Text
Imports System.Security
Imports System.Diagnostics
Imports System.Reflection
Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports System.Environment
Imports Microsoft.Win32

Friend Class StartupPrograms
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As StartupPrograms

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As StartupPrograms
        If (panelInstance Is Nothing) Then
            panelInstance = New StartupPrograms()
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
    Private _Native As New NativeMethods
    Private _LastOpenFolder As String
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup
    Private ResourceManager As New  _
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(StartupPrograms).Assembly)

#End Region

#Region " Constants and Variables "

    Private Const _RunKey As String = "Software\Microsoft\Windows\CurrentVersion\Run"
    Private Const _WowRunKey As String = "Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Run"
    Private _AllUsersStartup As String = Environment.GetFolderPath(Environment.SpecialFolder.Startup) & "\"
    Private _CurrentUserStartup As String = Environment.GetFolderPath(Environment.SpecialFolder.Programs) & _
        "\Startup\"
    Private _RegEntries As Integer                ' Counter for registry startup entries.
    Private _Ascending As Boolean = True        ' Used to toggle listview sorting.

    ' Listview column constants.
    Private Enum ListCol
        ItemName = 0
        FileName = 1
        Type = 2
        Status = 3
        Command = 4
        Path = 5
    End Enum

    ' Shortcut type (location) constants.
    Private Const HKCU As String = "Registry Current User"
    Private Const WHKCU As String = "Registry: x86 Current User"
    Private Const HKLM As String = "Registry All Users"
    Private Const WHKLM As String = "Registry: x86 All Users"
    Private Const StartupUser As String = "Startup Curreny User"
    Private Const StartupAllUsers As String = "Startup All Users"

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            My.Settings.Reload()
            _LastOpenFolder = My.Settings.LastOpenFolder

            _Info = New ComputerInformation

            DisplayAllStartupEntries()

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Startup panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " ContextMenu Event Handlers "

    Private Sub ContextMenuAddNewCurrentUserStartupProgramClick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuAddNewCurrentUserStartupProgram.Click

        AddStartUpProgram("Current User")

    End Sub

    Private Sub ContextMenuDeleteStartupProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuDeleteStartupProgram.Click

        With ListViewStartup.FocusedItem
            Dim name As String = .Text
            Dim regKey As String = .SubItems(2).Text
            Dim path As String = .SubItems(5).Text
            DeleteStartUpProgram(name, regKey, path)
        End With

    End Sub

    Private Sub ContextMenuRefreshDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuRefreshDisplay.Click

        DisplayAllStartupEntries()

    End Sub

    Private Sub ContextMenuAddNewAllUsersStartupProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuAddNewAllUsersStartupProgram.Click

        AddStartUpProgram("All Users")

    End Sub

#End Region

#Region " ListView Event Handlers "

    Private Sub ListViewStartup_ItemSelectionChanged(ByVal sender As Object, _
        ByVal e As ListViewItemSelectionChangedEventArgs) Handles ListViewStartup.ItemSelectionChanged

        Try
            If e.IsSelected Then

                ' Get command and file path stored in listview.
                Dim command As String = ListViewStartup.Items(e.ItemIndex).SubItems(ListCol.ItemName).Text
                Dim filePath As String = ListViewStartup.Items(e.ItemIndex).SubItems(ListCol.Path).Text

                ' Display the file information.
                If filePath.Contains("cmd.exe") Then
                    ' Since this is a command window, we will not be able to resolve the properties.
                    LabelCompany.Text = ""
                    LabelProductName.Text = ""
                    LabelDescription.Text = ""
                    LabelFileVersion.Text = ""
                    LabelCommand.Text = command

                    ' Only display arguments for shortcuts.
                    LabelArgumentsDesc.Visible = False
                    LabelArguments.Visible = False
                    LabelArguments.Text = ""
                ElseIf Path.GetExtension(filePath) = ".lnk" Then
                    If File.Exists(filePath) Then
                        ' Resolve the shortcut.
                        Dim sc As New ShortcutClass(filePath)

                        ' Get the file version information.
                        Dim selectedFileVersionInfo As FileVersionInfo = _
                            FileVersionInfo.GetVersionInfo(sc.Path)

                        ' Display the properties of the resolved shortcut. 
                        LabelCompany.Text = selectedFileVersionInfo.CompanyName
                        LabelProductName.Text = selectedFileVersionInfo.ProductName
                        LabelDescription.Text = selectedFileVersionInfo.FileDescription
                        LabelFileVersion.Text = selectedFileVersionInfo.FileVersion
                        LabelCommand.Text = sc.Path

                        ' Display arguments for shortcuts, but only if present.
                        If String.IsNullOrEmpty(sc.Arguments) Then
                            LabelArgumentsDesc.Visible = False
                            LabelArguments.Visible = False
                        Else
                            LabelArgumentsDesc.Visible = True
                            LabelArguments.Visible = True
                            LabelArguments.Text = sc.Arguments
                        End If
                    Else
                        LabelCompany.Text = "File cannot be found"
                        LabelProductName.Text = ""
                        LabelDescription.Text = ""
                        LabelFileVersion.Text = ""
                        LabelCommand.Text = ""
                    End If
                Else
                    If File.Exists(filePath) Then
                        ' Get the file version information.
                        Dim selectedFileVersionInfo As FileVersionInfo = _
                            FileVersionInfo.GetVersionInfo(filePath)

                        ' Display the file properties.
                        LabelCompany.Text = selectedFileVersionInfo.CompanyName
                        LabelProductName.Text = selectedFileVersionInfo.ProductName
                        LabelDescription.Text = selectedFileVersionInfo.FileDescription
                        LabelFileVersion.Text = selectedFileVersionInfo.FileVersion
                        LabelCommand.Text = command

                        ' Only display arguments for shortcuts.
                        LabelArgumentsDesc.Visible = False
                        LabelArguments.Visible = False
                        LabelArguments.Text = ""
                    Else
                        LabelCompany.Text = "File cannot be found"
                        LabelProductName.Text = ""
                        LabelDescription.Text = ""
                        LabelFileVersion.Text = ""
                        LabelCommand.Text = ""
                    End If
                End If

            End If

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
    Private Sub ListViewStartup_ColumnClick(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles ListViewStartup.ColumnClick

        ' Toggle sort order.
        If _Ascending = True Then
            _Ascending = False
        Else
            _Ascending = True
        End If

        ' Perform sort of items in specified column.
        ListViewStartup.ListViewItemSorter = New ListViewItemComparer(e.Column, _Ascending)

    End Sub

#End Region

#Region " Private Display Methods "

    Private Sub DisplayAllStartupEntries()

        ' Image list and listview.
        With ListViewStartup
            .Items.Clear()
            .Visible = False
            .SuspendLayout()
        End With

        Dim rk As RegistryKey = Nothing
        Dim count As Integer = 0

        ' Get item count in the registry.
        Try
            rk = Registry.CurrentUser.OpenSubKey(_RunKey, False)
            If rk IsNot Nothing Then
                count += rk.GetValueNames.Count
            End If
        Catch
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        Try
            rk = Registry.LocalMachine.OpenSubKey(_RunKey, False)
            If rk IsNot Nothing Then
                count += rk.GetValueNames.Count
            End If
        Catch
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        Try
            rk = Registry.CurrentUser.OpenSubKey(_WowRunKey, False)
            If rk IsNot Nothing Then
                count += rk.GetValueNames.Count
            End If
        Catch
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        Try
            rk = Registry.LocalMachine.OpenSubKey(_WowRunKey, False)
            If rk IsNot Nothing Then
                count += rk.GetValueNames.Count
            End If
        Catch
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        ' Get item count in the startmenu\startup.
        count += Directory.GetFiles(_CurrentUserStartup).Count
        count += Directory.GetFiles(_AllUsersStartup).Count

        With MainForm.ToolStripProgressBar1
            .Value = 0
            .Visible = True
            .Maximum = count
        End With

        StartupImageList.Images.Clear()

        ' This must be here so that an error does not occur when the listview was sorted and then refreshed.
        With ListViewStartup
            .Sorting = SortOrder.None
            .SuspendLayout()
            .Visible = False
        End With

        ' Clear information labels.
        LabelArguments.Text = ""
        LabelCommand.Text = ""
        LabelCompany.Text = ""
        LabelDescription.Text = ""
        LabelDetails.Text = ""
        LabelFileVersion.Text = ""
        LabelProductName.Text = ""

        _RegEntries = 0

        Try
            ' Get all startup programs in HHEY_CURRENT_USER
            DisplayRegistryStartupEntries(HKCU)

            If _Info.OperatingSystemIs64Bit Then
                ' Get all startup programs in Wow6432Node.
                DisplayRegistryStartupEntries(WHKCU)
            End If

            ' Get all startup programs in HKEY_LOCAL_MACHINE
            DisplayRegistryStartupEntries(HKLM)

            If _Info.OperatingSystemIs64Bit Then
                ' Get all startup programs in Wow6432Node.
                DisplayRegistryStartupEntries(WHKLM)
            End If

            ' Get all startup shortcuts and programs in the Current User's Startup Folder.
            DisplayStartupShortcuts(StartupUser)

            ' Get all startup shortcuts and programs in the All Users' Startup Folder.
            DisplayStartupShortcuts(StartupAllUsers)

        Catch ex As Exception
            MessageBox.Show("Error getting startup programs: " & ex.Message, My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ManagementInfo.ResizeListViewColumns(ListViewStartup, ColumnHeaderAutoResizeStyle.HeaderSize)

        ' Hide last 2 columns.
        With ListViewStartup
            .Columns(4).Width = 0
            .Columns(5).Width = 0
            .ResumeLayout()
            .Visible = True
        End With

        ' Sort listview based upon first column.
        ListViewStartup.ListViewItemSorter = New ListViewItemComparer(0, True)

        With MainForm.ToolStripProgressBar1
            .Visible = False
            .Style = ProgressBarStyle.Blocks
        End With

    End Sub

    Private Sub DisplayRegistryStartupEntries(ByVal hive As String)

        Dim value As String
        Dim command As String
        Dim filePath As String
        Dim disabled As Boolean
        Dim rk As RegistryKey = Nothing

        Try
            If hive = HKCU Then
                ' Get all startup programs in HKEY_CURRENT_USER.
                rk = Registry.CurrentUser.OpenSubKey(_RunKey)
                ' Create a new group.
                If _Info.OperatingSystemIs64Bit Then
                    _ListViewGroup = ListViewStartup.Groups.Add("Registry: Current User (64-Bit)", "Registry: Current User")
                Else
                    _ListViewGroup = ListViewStartup.Groups.Add("Registry: Current User (32-Bit)", "Registry: Current User")
                End If
            ElseIf hive = HKLM Then
                ' Get all startup programs in HKEY_LOCAL_MACHINE.
                rk = Registry.LocalMachine.OpenSubKey(_RunKey)
                ' Create a new group.
                If _Info.OperatingSystemIs64Bit Then
                    _ListViewGroup = ListViewStartup.Groups.Add("Registry: Local Machine (64-Bit)", "Registry: Local Machine")
                Else
                    _ListViewGroup = ListViewStartup.Groups.Add("Registry: Local Machine (32-Bit)", "Registry: Local Machine")
                End If
            ElseIf hive = WHKCU Then
                rk = Registry.CurrentUser.OpenSubKey(_WowRunKey)
                ' Create a new group.
                _ListViewGroup = ListViewStartup.Groups.Add("Registry: Current User (Wow: 32-Bit)", "Registry: Current User (Wow: 32-Bit)")
            ElseIf hive = WHKLM Then
                rk = Registry.LocalMachine.OpenSubKey(_WowRunKey)
                ' Create a new group.
                _ListViewGroup = ListViewStartup.Groups.Add("Registry: Local Machine (WoW: 32-Bit)", "Registry: Local Machine (WoW: 32-Bit)")
            End If


            ' Make sure the key is not empty.
            If rk IsNot Nothing Then
                ' Get all of the entries.
                For Each value In rk.GetValueNames()

                    ' Reset disabled flag.
                    disabled = False

                    ' Save complete command to collection.
                    command = rk.GetValue(value).ToString()

                    ' Check if command is disabled (begins with a ":")
                    If command.StartsWith(":") Then

                        ' Flag this entry as disabled.
                        disabled = True

                        ' Remove semicolon so that path command work and save file path.
                        filePath = ReturnFilePath(command.Remove(0, 1))

                    Else
                        ' Save file path.
                        filePath = ReturnFilePath(command)

                    End If

                    ' Attempt to get application image (icon).
                    If _Native.GetIcon(filePath) IsNot Nothing Then

                        ' Add the icon to the image list so that the listview can access it.
                        StartupImageList.Images.Add(_Native.GetIcon(filePath))

                    Else
                        ' If there is no icon, just add a blank image from resources to keep the indexes proper.
                        StartupImageList.Images.Add(My.Resources.GenericSmall)
                    End If

                    ' Create a new listviewitem.
                    _ListViewItem = New ListViewItem(_ListViewGroup)

                    ' Get the text for the item.
                    _ListViewItem.Text = value.ToString()

                    ' Add the image index to the item.
                    _ListViewItem.ImageIndex = _RegEntries

                    ' Add all of the subitems.
                    ' Add file name (without path) to listview.
                    _ListViewItem.SubItems.Add(Path.GetFileName(filePath))

                    ' Add the subitems.
                    With _ListViewItem
                        ' Add location (type) information to listview.
                        If hive = HKCU Then
                            .SubItems.Add(HKCU)
                        ElseIf hive = WHKCU Then
                            .SubItems.Add(WHKCU)
                        ElseIf hive = HKLM Then
                            .SubItems.Add(HKLM)
                        ElseIf hive = WHKLM Then
                            .SubItems.Add(WHKLM)
                        End If
                    End With

                    ' Add status information.
                    With _ListViewItem
                        If disabled Then
                            .SubItems.Add("Disabled")
                        Else
                            .SubItems.Add("Enabled")
                        End If
                    End With

                    ' Add startup command.
                    _ListViewItem.SubItems.Add(command)

                    ' Add file path.
                    _ListViewItem.SubItems.Add(filePath)

                    ' Add the item to listview.
                    ListViewStartup.Items.Add(_ListViewItem)

                    ' Bump the progress bar.
                    MainForm.ToolStripProgressBar1.Value += 1

                    _RegEntries += 1
                Next
            End If

        Catch ex As NullReferenceException
            ' Ignore
        Catch ex As ArgumentOutOfRangeException
            ' Ignore
        Finally
            If rk IsNot Nothing Then
                ' Close the registry key.
                rk.Close()
            End If
        End Try

    End Sub

    Private Sub DisplayStartupShortcuts(ByVal type As String)

        Dim disabled As Boolean
        Dim command As String
        Dim filePath As String
        Dim link As String
        Dim folder As String

        If type = StartupUser Then

            ' Current users startup folder.
            folder = Environment.GetFolderPath(Environment.SpecialFolder.Startup)
            ' Create new group.
            _ListViewGroup = ListViewStartup.Groups.Add("Start Menu\Startup: Current User", _
                                                        "Start Menu\Startup: Current User")
        Else

            ' All users startup folder.
            folder = Environment.ExpandEnvironmentVariables("%AllUsersProfile%") & _
                "\Start Menu\Programs\Startup"
            ' Create a new group.
            _ListViewGroup = ListViewStartup.Groups.Add("Start Menu\Startup: All Users", _
                                                        "Start Menu\Startup: All Users")
        End If

        For Each link In Directory.GetFiles(folder, "*.*")

            ' Only process shortcuts or executible files.
            If Path.GetExtension(link) = ".lnk" Or Path.GetExtension(link) = ".exe" Then

                ' Reset disabled flag.
                disabled = False

                ' Save command.
                command = link

                ' Save file path.
                filePath = ReturnFilePath(command)

                ' Resolve the shortcut.
                Dim sc As New ShortcutClass(filePath)

                ' Attempt to get application image (icon).
                With StartupImageList
                    If sc.Icon IsNot Nothing Then
                        ' First try getting icon from shortcut.
                        .Images.Add(sc.Icon)
                    ElseIf _Native.GetIcon(sc.Path) IsNot Nothing Then
                        ' Then try getting icon from the resolved path.
                        .Images.Add(_Native.GetIcon(sc.Path))
                    Else

                        ' If both methods fail, display a blank icon.
                        .Images.Add(CType(ResourceManager.GetObject("Blank"), System.Drawing.Image))
                    End If
                End With

                ' Create a new listview item.
                _ListViewItem = New ListViewItem(_ListViewGroup)

                ' Add the text.
                _ListViewItem.Text = Path.GetFileNameWithoutExtension(link)

                ' Add the image index.
                _ListViewItem.ImageIndex = _RegEntries

                ' Add the subitems.
                With _ListViewItem
                    ' Add file name (without path) to listview.
                    .SubItems.Add(Path.GetFileName(filePath))

                    ' Add type information to listview.
                    If type = StartupUser Then
                        .SubItems.Add(StartupUser)
                    Else
                        .SubItems.Add(StartupAllUsers)
                    End If

                    ' Add status information.
                    If disabled Then
                        .SubItems.Add("Disabled")
                    Else
                        .SubItems.Add("Enabled")
                    End If

                    ' Add startup command.
                    .SubItems.Add(command)

                    ' Add file path.
                    .SubItems.Add(filePath)
                End With

                ' Add the item to the listview.
                ListViewStartup.Items.Add(_ListViewItem)

                ' Bump the progress bar.
                MainForm.ToolStripProgressBar1.Value += 1

                _RegEntries += 1

            End If

        Next

    End Sub

    Private Shared Function ReturnFilePath(ByVal value As String) As String

        Try
            Dim p As Integer

            ' Check for quotes, and if present, remove them.
            If value.Contains(Chr(34)) Then
                value = value.Replace(Chr(34), "")
            End If

            ' Check for hyphens, and if present, return the part before first one,
            ' unless it is before the extension.
            If value.Contains("-") Then
                p = value.IndexOf("-")
                Dim pDot As Integer = value.IndexOf(".")
                If p > pDot Then
                    value = value.Substring(0, p - 1)
                End If
            End If

            ' Check for forward slashes, and if present, return the part before first one.
            If value.Contains("/") Then
                p = value.IndexOf("/")
                value = value.Substring(0, p - 1)
            End If

            ' Check for a space followed by a percent sign, and if present, return the part before the first one.
            If value.Contains(" %") Then
                p = value.IndexOf(" %")
                value = value.Substring(0, p)
            End If

            If value <> "" Then
                Return Path.GetFullPath(value)
            Else
                Return ""
            End If

        Catch ex As Exception
            Return ""
        End Try

    End Function

#End Region

#Region " Private Add/Delete Startup Methods "

    ''' <summary>
    ''' Adding new StartUp program to registry.
    ''' </summary>
    Private Sub AddStartUpProgram(ByVal registryKey As String)

        Dim regKey As RegistryKey = Nothing
        Dim filename As String = ""

        Try
            If registryKey = "Current User" Then
                regKey = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)
            ElseIf registryKey = "All Users" Then
                regKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            End If

            With OpenFileDialog1
                If String.IsNullOrEmpty(_LastOpenFolder) Or Not Directory.Exists(_LastOpenFolder) Then
                    .InitialDirectory = Environment.GetFolderPath(SpecialFolder.MyDocuments)
                Else
                    .InitialDirectory = _LastOpenFolder
                End If
                .Filter = "Executible Files (*.exe)|*.exe|Batch Files (*.bat)|*.bat|Command Files (*.cmd)|*.cmd|Shortcut Files (*.lnk)|*.lnk"
                .FileName = ""

                If .ShowDialog() = DialogResult.OK Then
                    filename = .FileName
                    _LastOpenFolder = Path.GetDirectoryName(.FileName)
                End If

                ' This is here to convert file name to proper (or title) case.
                Dim curCulture As CultureInfo = Thread.CurrentThread.CurrentCulture
                Dim txtInfo As TextInfo = curCulture.TextInfo

                Dim file As FileInfo = New FileInfo(filename)
                regKey.SetValue(txtInfo.ToTitleCase(Path.GetFileNameWithoutExtension(file.Name)), file.FullName)

            End With

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show("Unable to add startup program: " & ex.Message, My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If regKey IsNot Nothing Then
                regKey.Close()
            End If
        End Try

        DisplayAllStartupEntries()

    End Sub

    ''' <summary>
    ''' Deleting selected StartUp program from registry.
    ''' </summary>
    Private Sub DeleteStartUpProgram(ByVal name As String, ByVal regName As String, ByVal path As String)

        If MessageBox.Show("Are you sure you want to permanently remove " & name & " as a StartUp Program?", _
                           My.Application.Info.Title, MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = DialogResult.Yes Then

            Dim regKey As RegistryKey = Nothing

            Try
                Select Case regName
                    Case "Registry Current User"
                        regKey = Registry.CurrentUser.OpenSubKey(_RunKey, True)
                        regKey.DeleteValue(name)
                    Case "Registry: x86 Current User"
                        regKey = Registry.CurrentUser.OpenSubKey(_WowRunKey, True)
                        regKey.DeleteValue(name)
                    Case "Registry All Users"
                        regKey = Registry.LocalMachine.OpenSubKey(_RunKey, True)
                        regKey.DeleteValue(name)
                    Case "Registry: x86 All Users"
                        regKey = Registry.LocalMachine.OpenSubKey(_WowRunKey, True)
                        regKey.DeleteValue(name)
                    Case "Startup Curreny User"
                        My.Computer.FileSystem.DeleteFile(path, FileIO.UIOption.OnlyErrorDialogs, _
                                                          FileIO.RecycleOption.SendToRecycleBin)
                    Case "Startup All Users"
                        My.Computer.FileSystem.DeleteFile(path, FileIO.UIOption.OnlyErrorDialogs, _
                                                          FileIO.RecycleOption.SendToRecycleBin)
                End Select


            Catch ex As Exception
                MessageBox.Show("Unable to delete startup program: " & ex.Message, My.Application.Info.Title, _
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                If regKey IsNot Nothing Then
                    regKey.Close()
                End If
            End Try

            DisplayAllStartupEntries()

        End If

    End Sub

#End Region

End Class
