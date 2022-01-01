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
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.Win32

Friend Class OemInformation
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As OemInformation

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As OemInformation
        If (panelInstance Is Nothing) Then
            panelInstance = New OemInformation()
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
    ' Set to true after load. Prevents false TextBox changed results.
    Private _Loaded As Boolean
    Private _Logo As String = " "  ' This value cannot be null when creating the key.
    Private _Manufacturer As String
    Private _Model As String
    Private _SupportHours As String
    Private _SupportPhone As String
    Private _SupportUrl As String

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try

            ' Lock TextBoxes and hide save buttons if user is not an administrator.
            ' But display a normal background.
            If Not _Info.UserIsAdministrator Then
                TextBoxManufacturer.ReadOnly = True
                TextBoxManufacturer.BackColor = Color.FromKnownColor(KnownColor.Window)
                TextBoxModel.ReadOnly = True
                TextBoxModel.BackColor = Color.FromKnownColor(KnownColor.Window)
                TextBoxSupportHours.ReadOnly = True
                TextBoxSupportHours.BackColor = Color.FromKnownColor(KnownColor.Window)
                TextBoxSupportPhone.ReadOnly = True
                TextBoxSupportPhone.BackColor = Color.FromKnownColor(KnownColor.Window)
                TextBoxSupportWebsite.ReadOnly = True
                TextBoxSupportWebsite.BackColor = Color.FromKnownColor(KnownColor.Window)
                ButtonSaveOEMInfo.Enabled = False
                ButtonClearOEMInfo.Enabled = False
                ButtonAddLogo.Enabled = False
                ButtonRemoveLogo.Enabled = False
            End If

            ' Add computer name to label.
            LabelOEMInformation.Text = "OEM Information for Computer: " & _Info.OSMachineName

            ' Get the information.
            GetOemInformation()

            ' Fill in OEM information.
            TextBoxManufacturer.Text = _Manufacturer
            TextBoxModel.Text = _Model
            TextBoxSupportHours.Text = _SupportHours
            TextBoxSupportPhone.Text = _SupportPhone
            TextBoxSupportWebsite.Text = _SupportUrl
            LinkLabelOEMWebsite.Text = _SupportUrl

            ' If the path to the OEM logo exists, load into picture box.
            If File.Exists(_Logo) Then
                PictureBoxLogo.Load(_Logo)
                ' Also enable the remove button.
                ButtonRemoveLogo.Enabled = True
            Else
                ' Enable the add button.
                ButtonAddLogo.Enabled = True
            End If

            ' If any of the info textboxes are filled, enable the clear button.
            If Not String.IsNullOrEmpty(TextBoxManufacturer.Text) Or Not String.IsNullOrEmpty(TextBoxModel.Text) _
                Or Not String.IsNullOrEmpty(TextBoxSupportHours.Text) Or Not String.IsNullOrEmpty(TextBoxSupportPhone.Text) _
                Or Not String.IsNullOrEmpty(TextBoxSupportWebsite.Text) Then
                ButtonClearOEMInfo.Enabled = True
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

    Private Sub ButtonSaveOEMInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonSaveOEMInfo.Click

        Try
            _Manufacturer = TextBoxManufacturer.Text
            _Model = TextBoxModel.Text
            _SupportHours = TextBoxSupportHours.Text
            _SupportPhone = TextBoxSupportPhone.Text
            _SupportUrl = TextBoxSupportWebsite.Text
            SetOemInformation()
            LinkLabelOEMWebsite.Text = _SupportUrl
            ButtonSaveOEMInfo.Enabled = False
        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Private Sub ButtonClearOEMInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonClearOEMInfo.Click

        Try
            ClearOemInformation()
            TextBoxManufacturer.Text = ""
            TextBoxModel.Text = ""
            TextBoxSupportHours.Text = ""
            TextBoxSupportPhone.Text = ""
            TextBoxSupportWebsite.Text = ""
            LinkLabelOEMWebsite.Text = ""
            ButtonClearOEMInfo.Enabled = False
        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Private Sub ButtonAddLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonAddLogo.Click

        Try
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Bitmaps (*.bmp)|*.bmp"
            OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            OpenFileDialog1.Multiselect = False
            OpenFileDialog1.CheckFileExists = True

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                _Logo = OpenFileDialog1.FileName
                PictureBoxLogo.Load(_Logo)
                ButtonAddLogo.Enabled = False
                ButtonRemoveLogo.Enabled = True
                SetOemLogo()
            End If

        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

    Private Sub ButtonRemoveLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonRemoveLogo.Click

        Try
            PictureBoxLogo.Image = Nothing
            ClearOemLogo()
            ButtonRemoveLogo.Enabled = False
            ButtonAddLogo.Enabled = True
        Catch ex As SecurityException
            MessageBox.Show("Unable to save information." & vbCrLf & _
                "This action requires Administrative rights." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Description: " & ex.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try

    End Sub

#End Region

#Region " LinkLabel Event Handlers "

    Private Sub LinkLabelOEMWebsite_LinkClicked(ByVal sender As System.Object, _
        ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelOEMWebsite.LinkClicked

        Try
            Dim startInfo As New ProcessStartInfo(_SupportUrl)
            startInfo.WindowStyle = ProcessWindowStyle.Normal
            Process.Start(startInfo)
        Catch ex As Exception
            MessageBox.Show("Unable to open website and/or browser.", _
                My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " TextBox Event Handlers "

    Private Sub TextBoxManufacturer_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TextBoxManufacturer.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveOEMInfo.Enabled = True
        End If

    End Sub

    Private Sub TextBoxModel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles TextBoxModel.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveOEMInfo.Enabled = True
        End If

    End Sub

    Private Sub TextBoxSupportHours_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TextBoxSupportHours.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveOEMInfo.Enabled = True
        End If

    End Sub

    Private Sub TextBoxSupportPhone_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TextBoxSupportPhone.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonClearOEMInfo.Enabled = True
        End If

    End Sub

    Private Sub TextBoxSupportWebsite_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TextBoxSupportWebsite.TextChanged

        If _Loaded And _Info.UserIsAdministrator Then
            ButtonSaveOEMInfo.Enabled = True
        End If

    End Sub

#End Region

#Region " Private Methods "

    Private Sub SetOemInformation()

        Dim rk As RegistryKey = Nothing

        Try
            ' Save OEM information.
            rk = Registry.LocalMachine.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation")

            rk.SetValue("Logo", _Logo, RegistryValueKind.String)
            rk.SetValue("Manufacturer", _Manufacturer, RegistryValueKind.String)
            rk.SetValue("Model", _Model, RegistryValueKind.String)
            rk.SetValue("SupportHours", _SupportHours, RegistryValueKind.String)
            rk.SetValue("SupportPhone", _SupportPhone, RegistryValueKind.String)
            rk.SetValue("SupportURL", _SupportUrl, RegistryValueKind.String)

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

    Private Sub GetOemInformation()

        Dim rk As RegistryKey = Nothing

        Try
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", False)

            _Logo = rk.GetValue("Logo").ToString()
            _Manufacturer = rk.GetValue("Manufacturer").ToString()
            _Model = rk.GetValue("Model").ToString()
            _SupportHours = rk.GetValue("SupportHours").ToString()
            _SupportPhone = rk.GetValue("SupportPhone").ToString()
            _SupportUrl = rk.GetValue("SupportURL").ToString()

        Catch ex As Exception
            ' An exception will occur if there is no OEMInformation registry key. Just ignore this.
            'MessageBox.Show("This action requires Administrative rights." & vbCrLf & _
            '    "The system returned the following information:" & vbCrLf & _
            '    "Description: " & ex.Message, _
            '    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

    End Sub

    Private Shared Sub ClearOemInformation()

        Dim rk As RegistryKey = Nothing

        Try
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", True)

            rk.SetValue("Manufacturer", "", RegistryValueKind.String)
            rk.SetValue("Model", "", RegistryValueKind.String)
            rk.SetValue("SupportHours", "", RegistryValueKind.String)
            rk.SetValue("SupportPhone", "", RegistryValueKind.String)
            rk.SetValue("SupportURL", "", RegistryValueKind.String)

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

    Private Sub SetOemLogo()

        Dim rk As RegistryKey = Nothing

        Try
            ' Save OEM information.
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", True)

            rk.SetValue("Logo", _Logo, RegistryValueKind.String)

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

    Private Shared Sub ClearOemLogo()

        Dim rk As RegistryKey = Nothing

        Try
            ' Save OEM information.
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\OEMInformation", True)

            rk.SetValue("Logo", "", RegistryValueKind.String)

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

#End Region

End Class
