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
Imports System.ComponentModel
Imports Microsoft.Win32

Friend Class Introduction
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Introduction

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Introduction
        If (panelInstance Is Nothing) Then
            panelInstance = New Introduction()
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
    Private _Initialized As Boolean

#End Region

#Region " Panel Event Handler "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            ' Allow panel to paint.
            Application.DoEvents()

            Dim build As String

            _Initialized = False

            LabelAppCopyright.Text = _Info.AppCopyright
            LabelAppDescription.Text = _Info.AppDescription
            If _Info.AppBuild = "0" Or String.IsNullOrEmpty(_Info.AppBuild) Then
                build = ""
            Else
                build = " Build " & _Info.AppBuild
            End If
            LabelAppVersion.Text = "Version " & _Info.AppShortVersion & _
                build
            LabelCustomerName.Text = _Info.UserRegisteredName
            LabelCustomerOrganization.Text = _Info.UserRegisteredOrganization
            LabelTitleCompany.Text = _Info.AppTitle & " is a product of " & _
                _Info.AppCompanyName

            ' Set check boxes from settings.
            My.Settings.Reload()

            CheckBoxCloseToIcon.Checked = My.Settings.CloseToTray
            CheckBoxIconIsAlwaysVisible.Checked = My.Settings.IconIsAlwaysVisible
            CheckBoxMinimizeToIcon.Checked = My.Settings.MinimizeToTray
            CheckBoxStartAsIconInTray.Checked = My.Settings.StartAsIconInTray
            CheckBoxStartWithWindows.Checked = My.Settings.StartWithWindows
            CheckBoxShowSplashScreen.Checked = My.Settings.ShowSplashScreen

            _Initialized = True

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Introduction panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonExitSystemInformationII_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonExitSystemInformationII.Click

        If MainForm.NotifyIconSystemInfo IsNot Nothing Then
            MainForm.NotifyIconSystemInfo.Dispose()
        End If

        Application.Exit()

    End Sub

#End Region

#Region " CheckBox Event Handlers "

    Private Sub CheckBoxStartWithWindows_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxStartWithWindows.CheckedChanged

        If _Initialized Then
            My.Settings.StartWithWindows = CheckBoxStartWithWindows.Checked
            My.Settings.Save()
            ' Set this in the registry.
            Dim value As Boolean = CheckBoxStartWithWindows.Checked
            StartWithWindows(value)
        End If

    End Sub

    Private Sub CheckBoxStartAsIconInTray_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxStartAsIconInTray.CheckedChanged

        If _Initialized Then
            ' Cannot start as icon and also show splash screen.
            If CheckBoxStartAsIconInTray.Checked AndAlso CheckBoxShowSplashScreen.Checked Then
                If MessageBox.Show("You cannot enable starting as an icon when " & My.Application.Info.Title & _
                                   " the splash screen is enabled. If you want to start this application as an icon, " & _
                                   "the option to display the splash screen will be turned off. Do you want to enable starting as an icon?", _
                                   My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                   MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    ' Make sure the CheckBoxStartAsIconInTray.CheckedChanged and CheckBoxStartAsIconInTray.CheckedChanged
                    ' events have no effect (because we already set the setting).
                    _Initialized = False
                    CheckBoxShowSplashScreen.Checked = False
                    CheckBoxStartAsIconInTray.Checked = True
                    _Initialized = True
                    My.Settings.ShowSplashScreen = False
                    My.Settings.StartAsIconInTray = True
                    My.Settings.Save()

                Else
                    _Initialized = False
                    CheckBoxShowSplashScreen.Checked = True
                    CheckBoxStartAsIconInTray.Checked = False
                    _Initialized = True
                    My.Settings.ShowSplashScreen = True
                    My.Settings.StartAsIconInTray = False
                    My.Settings.Save()

                End If
            Else
                My.Settings.StartAsIconInTray = CheckBoxStartAsIconInTray.Checked
                My.Settings.Save()

            End If

        End If

    End Sub

    Private Sub CheckBoxMinimizeToIcon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxMinimizeToIcon.CheckedChanged

        If _Initialized Then
            My.Settings.MinimizeToTray = CheckBoxMinimizeToIcon.Checked
            My.Settings.Save()
        End If

    End Sub

    Private Sub CheckBoxCloseToIcon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxCloseToIcon.CheckedChanged

        If _Initialized Then
            My.Settings.CloseToTray = CheckBoxCloseToIcon.Checked
            My.Settings.Save()
        End If

    End Sub

    Private Sub CheckBoxIconIsAlwaysVisible_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxIconIsAlwaysVisible.CheckedChanged

        If _Initialized Then
            My.Settings.IconIsAlwaysVisible = CheckBoxIconIsAlwaysVisible.Checked
            My.Settings.Save()
            If CheckBoxIconIsAlwaysVisible.Checked Then
                MainForm.NotifyIconSystemInfo.Visible = True
            End If
        End If

    End Sub

    Private Sub CheckBoxShowSplashScreen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxShowSplashScreen.CheckedChanged

        If _Initialized Then
            If CheckBoxShowSplashScreen.Checked AndAlso CheckBoxStartAsIconInTray.Checked Then
                If MessageBox.Show("You cannot enable the splash screen when " & My.Application.Info.Title & _
                                   " starts as an icon. If you want to enable the splash screen, " & _
                                   "the option to start as an icon will be turned off. Do you want to enable the splash screen?", _
                                   My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, _
                                   MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                    ' Make sure the CheckBoxStartAsIconInTray.CheckedChanged and CheckBoxShowSplashScreen.CheckChanged
                    ' events have no effect (because we already set the setting).
                    _Initialized = False
                    CheckBoxShowSplashScreen.Checked = True
                    CheckBoxStartAsIconInTray.Checked = False
                    _Initialized = True
                    My.Settings.ShowSplashScreen = True
                    My.Settings.StartAsIconInTray = False
                    My.Settings.Save()

                Else
                    _Initialized = False
                    CheckBoxShowSplashScreen.Checked = False
                    CheckBoxStartAsIconInTray.Checked = True
                    _Initialized = True
                    My.Settings.ShowSplashScreen = False
                    My.Settings.StartAsIconInTray = True
                    My.Settings.Save()

                End If

            Else
                My.Settings.ShowSplashScreen = CheckBoxShowSplashScreen.Checked
                My.Settings.Save()
            End If
        End If

    End Sub

#End Region

#Region " Link Labels "

    Private Sub LinkLabelEULA_LinkClicked(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelEULA.LinkClicked

        If File.Exists(_Info.AppDirectory & "\EULA.pdf") Then
            Try
                ' Now display EULA
                Dim startInfo As New  _
                    ProcessStartInfo(_Info.AppDirectory & "\EULA.pdf")
                startInfo.WindowStyle = ProcessWindowStyle.Normal
                Process.Start(startInfo)
            Catch ex As IOException
                ' cannot find file
                MessageBox.Show("Adobe Reader cannot be found.", Application.ProductName, _
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        Else
            ' cannot find file
            MessageBox.Show("The EULA.pdf file cannot be found.", Application.ProductName, _
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

    End Sub

#End Region

#Region " Private Methods "

    Private Shared Sub StartWithWindows(ByVal value As Boolean)

        Dim rk As RegistryKey = Nothing

        Try
            rk = Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Run", True)

            If value = True Then
                rk.SetValue(My.Application.Info.AssemblyName, My.Application.Info.DirectoryPath & "\" & My.Application.Info.AssemblyName & ".exe")
            Else
                rk.DeleteValue(My.Application.Info.AssemblyName, False)
            End If

        Catch ex As win32Exception
            MessageBox.Show("A registry write error occurred. The system returned the following information:" & _
                vbCrLf & ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

    End Sub

#End Region

End Class
