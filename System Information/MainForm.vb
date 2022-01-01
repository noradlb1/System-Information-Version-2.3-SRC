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

Imports System.Threading
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class MainForm

#Region " Private Members "

    Private _Info As New ComputerInformation
    Private _Restoring As Boolean   ' Indicates application is restoring from notification icon.
    Private ResourceManager As New  _
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(MainForm).Assembly)

#End Region

#Region " TreeView Select Event Handler "

    ' Display the correct panel based on the node that was selected.
    Private Sub TreeviewSystemInfo_AfterSelect(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewSystemInfo.AfterSelect

        Select Case e.Node.Text
            Case "Computer"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Computer.CreateInstance())
            Case "CPU"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Cpu.CreateInstance())
            Case "BIOS"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Bios.CreateInstance())
            Case "Drives and Volumes"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Drives.CreateInstance())
            Case "Network"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Network.CreateInstance())
            Case "Sound"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Sound.CreateInstance())
            Case "Video"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Video.CreateInstance())
            Case "Operating System"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(OperatingSystem.CreateInstance())
            Case "Date and Time"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(DateAndTime.CreateInstance())
            Case "Installed Programs"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(InstalledPrograms.CreateInstance())
            Case "Services"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Services.CreateInstance())
            Case "Startup Programs"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(StartupPrograms.CreateInstance())
            Case "Special Folders"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(SpecialFolders.CreateInstance())
            Case "Environment Variables"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(EnvironmentVariables.CreateInstance())
            Case "OEM Information"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(OemInformation.CreateInstance())
            Case "Processes"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Processes.CreateInstance())
            Case "User Information"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(UserInformation.CreateInstance())
            Case "Visual Styles"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(VisualStyles.CreateInstance())
            Case "Fonts"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Fonts.CreateInstance())
            Case "Event Viewer"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(EventViewer.CreateInstance())
            Case "Drivers"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Drivers.CreateInstance())
            Case "Components"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Component.CreateInstance())
            Case "Shares"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Shares.CreateInstance())
            Case "File Types"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(FileTypes.CreateInstance)
            Case "Keyboard"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Keyboard.CreateInstance())
            Case "Pointing Device"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(PointingDevice.CreateInstance())
            Case "Multimedia Codecs"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(MultimediaCodecs.CreateInstance())
            Case "Desktop"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Desktop.CreateInstance())
            Case "USB Devices"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(UsbDevices.CreateInstance())
            Case "Ports"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Ports.CreateInstance())
            Case "Win32 Hardware"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Win32Hardware.CreateInstance())
            Case "Win32 Storage"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Win32Storage.CreateInstance())
            Case "Win32 Memory"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Win32Memory.CreateInstance())
            Case "Win32 System"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Win32System.CreateInstance())
            Case "Win32 Network"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Win32Network.CreateInstance())
            Case "Win32 Users"
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Win32Users.CreateInstance())
            Case Else
                SplitContainerSystemInfo.Panel2.Controls.Clear()
                SplitContainerSystemInfo.Panel2.Controls.Add(Introduction.CreateInstance())
        End Select

    End Sub

#End Region

#Region " Form Event Handlers "

    Private Sub MainForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles Me.Resize

        If Not _Restoring AndAlso Me.WindowState = FormWindowState.Minimized AndAlso My.Settings.MinimizeToTray Then
            Me.ShowInTaskbar = False
            Me.Opacity = 0
            NotifyIconSystemInfo.Visible = True
        End If

    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) _
        Handles Me.FormClosing

        My.Settings.Reload()

        If e.CloseReason = CloseReason.UserClosing Then
            If My.Settings.CloseToTray = True Then
                Me.WindowState = FormWindowState.Minimized
                Me.ShowInTaskbar = False
                NotifyIconSystemInfo.Visible = True
                e.Cancel = True
            End If
        Else
            NotifyIconSystemInfo.Dispose()
        End If

    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            ' Set title and version.
            Me.Text = My.Application.Info.Title & " Version " & My.Application.Info.Version.Major.ToString() & _
                      "." & My.Application.Info.Version.Minor.ToString()

            My.Settings.Reload()

            ' The last image in the image list holds the os image.
            Dim index As Integer = ImageListTree.Images.Count - 1

            ' Set OS icon on treeview
            Select Case _Info.OSShortVersion
                Case "5.0"  ' Windows 2000
                    ImageListTree.Images.Item(index) = _
                        CType(ResourceManager.GetObject("Windows2000_16x16"), System.Drawing.Image)
                Case "5.1"  ' Windows XP
                    ImageListTree.Images.Item(index) = _
                        CType(ResourceManager.GetObject("Windows_XP_16x16"), System.Drawing.Image)
                Case "6.0"  ' Windows Vista
                    ImageListTree.Images.Item(index) = _
                        CType(ResourceManager.GetObject("Windows_Vista_16x16"), System.Drawing.Image)
                Case Else
                    ImageListTree.Images.Item(index) = _
                        CType(ResourceManager.GetObject("Windows_16x16"), System.Drawing.Image)
            End Select

            ' Add first panel
            SplitContainerSystemInfo.Panel2.Controls.Clear()
            SplitContainerSystemInfo.Panel2.Controls.Add(Introduction.CreateInstance())

            ' enable timer
            TimerUpdate.Enabled = True

            ' Setup notifyicon.
            NotifyIconSystemInfo.Icon = My.Resources.CPU00

            If My.Settings.StartAsIconInTray Then
                NotifyIconSystemInfo.Visible = True
                Me.WindowState = FormWindowState.Minimized
                Me.ShowInTaskbar = False
            Else
                If My.Settings.IconIsAlwaysVisible Then
                    NotifyIconSystemInfo.Visible = True
                Else
                    NotifyIconSystemInfo.Visible = False
                End If

                Me.WindowState = FormWindowState.Normal
                Me.ShowInTaskbar = True

                ' Make sure there's no problem when we start as an icon.
                If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
                    If SplitContainerSystemInfo.Width <> 235 Then
                        ' Make sure splitcontainer splitter distance doesn't change.
                        SplitContainerSystemInfo.SplitterDistance = 235
                    End If
                End If

                ' Expand the operating system node only.
                Dim parentNode As TreeNode = TreeViewSystemInfo.Nodes(0)
                Dim i As Integer = 0

                For Each childNode As TreeNode In parentNode.Nodes
                    If i = 1 Then
                        childNode.Expand()
                    End If
                    i += 1
                Next

                ' Expand parent node.
                parentNode.Expand()

                TreeViewSystemInfo.Refresh()

            End If

            ' Set the opacity to 1 because loading is over and this makes a cleaner display.
            Me.Opacity = 1

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the ""MainForm_Load"" procedure." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
            MsgBox("Split Container Width: " & SplitContainerSystemInfo.Width.ToString & vbCrLf & _
                   "Panel1 Width: " & SplitContainerSystemInfo.Panel1.Width.ToString & vbCrLf & _
                   "Splitter Distance: " & SplitContainerSystemInfo.SplitterDistance.ToString)
        End Try
    End Sub

#End Region

#Region " Timer Event Handlers "

    Private Sub TimerUpdate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TimerUpdate.Tick

        Dim totalPhysicalMemory As ULong
        Dim availablePhysicalMemory As ULong
        Dim networkStatus As String = ""
        Dim memoryUsage As Long
        Dim cpuUsage As Long

        'Update Date and Time.
        StatusLabelComputerStatus.Text = FormatDateTime(Now, DateFormat.LongDate) & "  " & _
           FormatDateTime(Now, DateFormat.LongTime)

        'Update Up Time.
        StatusLabelComputerStatus.Text &= " Up Time: " & _Info.OSUptime

        ' Get total and available physical memory.
        totalPhysicalMemory = My.Computer.Info.TotalPhysicalMemory
        availablePhysicalMemory = My.Computer.Info.AvailablePhysicalMemory

        ' Calculate memory usage percent.
        memoryUsage = CLng((availablePhysicalMemory / totalPhysicalMemory) * 100)

        If InternetConnection() = True Then
            networkStatus = "Connected"
        Else
            networkStatus = "Disconected"
        End If

        ' Get the CPU utilization and display it on a toolbar.
        ToolStripProgressBarCpu.Value = CInt(Fix(PerformanceCounter1.NextValue()))

        cpuUsage = ToolStripProgressBarCpu.Value

        ' Display CPU utilization, Memory utilization, and Internet connection status as text.
        StatusLabelComputerStatus.Text &= " CPU Usage: " & cpuUsage.ToString("00") & "%," & "   Memory Usage: " & _
            memoryUsage.ToString("00") & "%," & "   Internet: " & networkStatus

        ' Take care of notify icon.

        Try
            With NotifyIconSystemInfo
                If cpuUsage < 1 Then
                    .Icon = My.Resources.CPU00
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 0 And cpuUsage <= 5 Then
                    .Icon = My.Resources.CPU05
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 5 And cpuUsage <= 10 Then
                    .Icon = My.Resources.CPU10
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 10 And cpuUsage <= 20 Then
                    .Icon = My.Resources.CPU20
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 20 And cpuUsage <= 30 Then
                    .Icon = My.Resources.CPU30
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 30 And cpuUsage <= 40 Then
                    .Icon = My.Resources.CPU40
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 40 And cpuUsage <= 50 Then
                    .Icon = My.Resources.CPU50
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 50 And cpuUsage <= 60 Then
                    .Icon = My.Resources.CPU60
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 60 And cpuUsage <= 80 Then
                    .Icon = My.Resources.CPU80
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 80 And cpuUsage <= 90 Then
                    .Icon = My.Resources.CPU90
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                ElseIf cpuUsage > 90 Then
                    .Icon = My.Resources.CPU100
                    .Text = "CPU Usage: " & cpuUsage.ToString & "%"
                Else
                    .Icon = My.Resources.CPU00
                    .Text = "Error"
                End If
            End With
        Catch ex As NullReferenceException
            ' Ignore
        End Try

    End Sub

#End Region

#Region " Tray ContextMenu Event Handlers "

    Private Sub TrayContextMenuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TrayContextMenuExit.Click

        NotifyIconSystemInfo.Dispose()
        Application.Exit()

    End Sub

    Private Sub TrayContextMenuRestore_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TrayContextMenuRestore.Click, NotifyIconSystemInfo.DoubleClick

        ' Signal that form is now restoring.
        _Restoring = True

        Me.Opacity = 0  ' Assure clean state change.
        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal

        If Not My.Settings.IconIsAlwaysVisible Then
            NotifyIconSystemInfo.Visible = False
        End If

        Application.DoEvents()

        ' Make sure there's no problem showing form.
        If Me.WindowState = FormWindowState.Normal Or Me.WindowState = FormWindowState.Maximized Then
            If SplitContainerSystemInfo.Width <> 235 Then
                ' Make sure splitcontainer splitter distance doesn't change.
                SplitContainerSystemInfo.SplitterDistance = 235
            End If

            ' Expand the operating system node only.
            Dim parentNode As TreeNode = TreeViewSystemInfo.Nodes(0)
            Dim i As Integer = 0

            For Each childNode As TreeNode In parentNode.Nodes
                If i = 1 Then
                    childNode.Expand()
                End If
                i += 1
            Next

            ' Expand parent node.
            parentNode.Expand()

            TreeViewSystemInfo.Refresh()

        End If

        ' Make form visible.
        Me.Opacity = 1

        ' Signal that restoring is now over.
        _Restoring = False

    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Checks for internet connection.
    ''' </summary>
    Private Shared Function InternetConnection() As Boolean

        InternetConnection = CBool(SafeNativeMethods.InternetGetConnectedState(0, 0))

    End Function

#End Region

End Class

#Region " Native Methods Class "

Friend Class SafeNativeMethods

    Private Sub New()
        ' Private constructor.
    End Sub

    Friend Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Integer, _
                                                                         ByVal dwReserved As Integer) As Integer

End Class

#End Region
