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
Imports System.Security.Permissions
Imports Microsoft.Win32

Friend Class UserInformation
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As UserInformation

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As UserInformation
        If (panelInstance Is Nothing) Then
            panelInstance = New UserInformation()
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

#Region " Private Methods "

    Private _Info As New ComputerInformation

    ' Set to true after load. Prevents false TextBox changed results.
    Private _Loaded As Boolean
    Private _AutoLogonEnabled As Boolean
    Private _AutoLogonName As String
    Private _AutoLogonPassword As String

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try

            ' Lock TextBoxes and hide save buttons if user is not an administrator.
            ' But display a normal background.
            If Not _Info.UserIsAdministrator Then
                TextBoxRegisteredOrganization.ReadOnly = True
                TextBoxRegisteredOrganization.BackColor = Color.FromKnownColor(KnownColor.Window)
                TextBoxRegisteredOrganization2.ReadOnly = True
                TextBoxRegisteredOrganization2.BackColor = Color.FromKnownColor(KnownColor.Window)
                TextBoxRegisteredUser.ReadOnly = True
                TextBoxRegisteredUser.BackColor = Color.FromKnownColor(KnownColor.Window)
                TextBoxRegisteredOrganization2.ReadOnly = True
                TextBoxRegisteredOrganization2.BackColor = Color.FromKnownColor(KnownColor.Window)
                ButtonSaveRegisteredOrganization.Enabled = False
                ButtonSaveRegisteredUser.Enabled = False
                ButtonSaveRegisteredOrganization2.Enabled = False
                ButtonSaveRegisteredUser2.Enabled = False
            End If

            ' Disable controls only meant for 64-bit.
            If Not _Info.OperatingSystemIs64Bit Then
                TextBoxRegisteredOrganization2.Enabled = False
                TextBoxRegisteredUser2.Enabled = False
                ButtonSaveRegisteredOrganization2.Enabled = False
                ButtonSaveRegisteredUser2.Enabled = False
            End If

            ' Add computer name to label.
            LabelRegistration.Text = "User Registration for Computer: " & _Info.OSMachineName
            If _Info.OperatingSystemIs64Bit Then
                LabelRegistration.Text &= " (64-Bit)"
            End If
            LabelRegistration2.Text = "User Registration for Computer: " & _Info.OSMachineName & " (32-Bit Compatilibity Node)"

            ' Fill in registration information.
            TextBoxRegisteredOrganization.Text = _Info.UserRegisteredOrganization
            TextBoxRegisteredUser.Text = _Info.UserRegisteredName
            TextBoxRegisteredOrganization2.Text = _Info.UserRegisteredOrganizationWow6432Node
            TextBoxRegisteredUser2.Text = _Info.UserRegisteredNameWow6432Node

            _AutoLogonEnabled = IsAutoLogonEnabled()

            If _AutoLogonEnabled Then
                LabelAutoLogonStatus.Text = "Auto Logon Is Enabled."
                ButtonClearAutoLogon.Enabled = True
                TextBoxUserName.Text = _AutoLogonName
                TextBoxPassword.Text = _AutoLogonPassword   ' TextBox set to show password character.
            Else
                LabelAutoLogonStatus.Text = "Auto Logon Is Disabled."
                ButtonClearAutoLogon.Enabled = False
            End If

            ' Flag that panel has loaded; enables TextChanged events.
            _Loaded = True

        Catch ex As SecurityException
            MessageBox.Show("An error has occurred in the Users panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonSaveRegisteredUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonSaveRegisteredUser.Click

        Try
            _Info.UserRegisteredName = TextBoxRegisteredUser.Text
            ButtonSaveRegisteredUser.Enabled = False
        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Private Sub ButtonSaveRegisteredOrganization_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonSaveRegisteredOrganization.Click

        Try
            _Info.UserRegisteredOrganization = TextBoxRegisteredOrganization.Text
            ButtonSaveRegisteredOrganization.Enabled = False
        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Private Sub ButtonSaveRegisteredUser2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonSaveRegisteredUser2.Click

        Try
            _Info.UserRegisteredNameWow6432Node = TextBoxRegisteredUser2.Text
            ButtonSaveRegisteredUser2.Enabled = False
        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Private Sub ButtonSaveRegisteredOrganization2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonSaveRegisteredOrganization2.Click

        Try
            _Info.UserRegisteredOrganizationWow6432Node = TextBoxRegisteredOrganization2.Text
            ButtonSaveRegisteredOrganization2.Enabled = False
        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Private Sub ButtonSetAutoLogon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonSetAutoLogon.Click

        If Not String.IsNullOrEmpty(TextBoxUserName.Text) And Not String.IsNullOrEmpty(TextBoxPassword.Text) _
            And _Info.UserIsAdministrator Then
            SetAutoLogon()
            LabelAutoLogonStatus.Text = "Auto Logon Is Enabled"
            ButtonSetAutoLogon.Enabled = False
        End If

    End Sub

    Private Sub ButtonClearAutoLogon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonClearAutoLogon.Click

        Dim results As DialogResult = MessageBox.Show("Are you sure you want to clear the auto logon information?", _
            Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

        If results = DialogResult.Yes Then
            ClearAutoLogon()
            TextBoxUserName.Text = ""
            TextBoxPassword.Text = ""
            LabelAutoLogonStatus.Text = "Auto Logon Is Disabled"
            ButtonClearAutoLogon.Enabled = False
        End If

    End Sub

#End Region

#Region " TextBox Event Handlers "

    Private Sub TextBoxRegisteredUser_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TextBoxRegisteredUser.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveRegisteredUser.Enabled = True
        End If

    End Sub

    Private Sub TextBoxRegisteredOrganization_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TextBoxRegisteredOrganization.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveRegisteredOrganization.Enabled = True
        End If

    End Sub

    Private Sub TextBoxRegisteredUser2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TextBoxRegisteredUser2.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveRegisteredUser2.Enabled = True
        End If

    End Sub

    Private Sub TextBoxRegisteredOrganization2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TextBoxRegisteredOrganization2.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveRegisteredOrganization2.Enabled = True
        End If

    End Sub

    Private Sub TextBoxUserName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TextBoxUserName.TextChanged

        If _Loaded And Not String.IsNullOrEmpty(TextBoxPassword.Text) And _Info.UserIsAdministrator Then
            ButtonSetAutoLogon.Enabled = True
        End If

    End Sub

    Private Sub TextBoxPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TextBoxPassword.TextChanged

        If _Loaded And Not String.IsNullOrEmpty(TextBoxUserName.Text) And _Info.UserIsAdministrator Then
            ButtonSetAutoLogon.Enabled = True
        End If

    End Sub

#End Region

#Region " Private Methods "

    Private Sub SetAutoLogon()

        Dim rk As RegistryKey = Nothing

        Try
            ' Clear the 32 and normal 64-Bit entries.
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", True)

            rk.SetValue("AutoAdminLogon", "1", RegistryValueKind.String)
            rk.SetValue("DefaultPassword", TextBoxPassword.Text, RegistryValueKind.String)
            rk.SetValue("DefaultUserName", TextBoxUserName.Text, RegistryValueKind.String)

            rk.Close()

            If _Info.OperatingSystemIs64Bit Then
                ' If 64-Bit, also set Wow6432Node.
                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon", True)

                rk.SetValue("AutoAdminLogon", "1", RegistryValueKind.String)
                rk.SetValue("DefaultPassword", TextBoxPassword.Text, RegistryValueKind.String)
                rk.SetValue("DefaultUserName", TextBoxUserName.Text, RegistryValueKind.String)
            End If

        Catch ex As Exception
            MessageBox.Show("This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

    End Sub

    Private Sub ClearAutoLogon()

        Dim rk As RegistryKey = Nothing

        Try
            ' Clear the 32 and normal 64-Bit entries.
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", True)

            rk.SetValue("AutoAdminLogon", "0", RegistryValueKind.String)
            rk.SetValue("DefaultPassword", "", RegistryValueKind.String)
            rk.SetValue("DefaultUserName", "", RegistryValueKind.String)

            rk.Close()

            If _Info.OperatingSystemIs64Bit Then
                ' If 64-Bit, also set Wow6432Node.
                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon", True)

                rk.SetValue("AutoAdminLogon", "0", RegistryValueKind.String)
                rk.SetValue("DefaultPassword", "", RegistryValueKind.String)
                rk.SetValue("DefaultUserName", "", RegistryValueKind.String)
            End If

        Catch ex As Exception
            MessageBox.Show("This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

    End Sub

    Private Function IsAutoLogonEnabled() As Boolean

        Dim rk As RegistryKey = Nothing
        Dim autoAdmin As String
        Dim returnValue As Boolean

        Try

            If _Info.OperatingSystemIs64Bit Then
                ' If 64-Bit, also check Wow6432Node.
                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Wow6432Node\Microsoft\Windows NT\CurrentVersion\Winlogon", True)

                autoAdmin = rk.GetValue("AutoAdminLogon", "0").ToString()
                _AutoLogonPassword = rk.GetValue("DefaultPassword", "").ToString()
                _AutoLogonName = rk.GetValue("DefaultUserName", "").ToString()

                If autoAdmin = "1" And Not String.IsNullOrEmpty(_AutoLogonPassword) And Not String.IsNullOrEmpty(_AutoLogonName) Then
                    returnValue = True
                End If

                rk.Close()

            End If

            ' Check the 32 and normal 64-Bit entries.
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", True)

            autoAdmin = rk.GetValue("AutoAdminLogon", "0").ToString()
            _AutoLogonPassword = rk.GetValue("DefaultPassword", "").ToString()
            _AutoLogonName = rk.GetValue("DefaultUserName", "").ToString()

            If autoAdmin = "1" And Not String.IsNullOrEmpty(_AutoLogonPassword) And Not String.IsNullOrEmpty(_AutoLogonName) Then
                returnValue = True
            End If

        Catch ex As Exception
            MessageBox.Show("This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        Return returnValue

    End Function

#End Region

End Class
