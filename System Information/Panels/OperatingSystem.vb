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

Friend Class OperatingSystem
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As OperatingSystem

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As OperatingSystem
        If (panelInstance Is Nothing) Then
            panelInstance = New OperatingSystem()
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
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(OperatingSystem).Assembly)

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try

            Dim version As String

            ' Set operating system picture
            Select Case _Info.OSShortVersion
                Case "5.0"  ' Windows 2000
                    PictureBoxPanel.Image = _
                        CType(ResourceManager.GetObject("Windows2000_48x48"), System.Drawing.Image)
                Case "5.1"  'Windows XP
                    PictureBoxPanel.Image = _
                        CType(ResourceManager.GetObject("Windows_XP_48x48"), System.Drawing.Image)
                Case "6.0"  ' Windows Vista
                    PictureBoxPanel.Image = _
                        CType(ResourceManager.GetObject("Windows_Vista_48x48"), System.Drawing.Image)
                Case Else
                    PictureBoxPanel.Image = _
                        CType(ResourceManager.GetObject("Windows_48x48"), System.Drawing.Image)
            End Select

            ' Build long version string
            Select Case _Info.OSPlatform
                Case PlatformID.Win32NT
                    version = "Microsoft Windows NT " & _Info.OSShortVersion & " Build " & _
                        _Info.OSBuild & " " & _Info.OSServicePack
                Case PlatformID.Win32Windows
                    version = "Microsoft Windows " & _Info.OSShortVersion
                Case PlatformID.Unix
                    version = "Unix " & _Info.OSShortVersion
                Case PlatformID.Win32S
                    version = "Win32S " & "3.1"
                Case PlatformID.WinCE
                    version = "Microsoft Windows CE " & _Info.OSShortVersion & " Build " & _
                        _Info.OSBuild & " " & _Info.OSServicePack
                Case Else
                    version = "Unknown Operating System"
            End Select

            ' Fill in Windows information.
            If _Info.OperatingSystemIs64Bit Then
                TextBoxFullName.Text = _Info.OSFullName & " (64-Bit)"
            Else
                TextBoxFullName.Text = _Info.OSFullName & " (32-Bit)"
            End If

            TextBoxVersion.Text = version
            TextBoxFullVersion.Text = _Info.OSVersion

            ' Hide Service Pack if not present.
            If String.IsNullOrEmpty(_Info.OSServicePack) Then
                LabelServicePack.Visible = False
                TextBoxServicePack.Text = ""
            ElseIf _Info.OSServicePack.Trim() = "0" Then
                LabelServicePack.Visible = False
                TextBoxServicePack.Text = ""
            Else
                LabelServicePack.Visible = True
                TextBoxServicePack.Text = _Info.OSServicePack
            End If

            TextBoxType.Text = _Info.OSType
            TextBoxCodeName.Text = _Info.OSCodename
            TextBoxMachineName.Text = _Info.OSMachineName
            TextBoxUserName.Text = _Info.OSUserName

            ' Indicate if user is admin or limited.
            If _Info.UserIsAdministrator Then
                TextBoxUserName.Text = TextBoxUserName.Text & " (Administrator)"
            Else
                TextBoxUserName.Text = TextBoxUserName.Text & " (Limited User)"
            End If

            ' Fill in product ID and Key.
            TextBoxProductID.Text = _Info.OSProductId
            TextBoxProductKey.Text = _Info.OSProductKey

            ' Fill in install date and time.
            If _Info.OSInstallDate <> DateTime.Today Then
                TextBoxInstallDate.Text = _Info.OSInstallDate.ToShortDateString _
                    & " " & _Info.OSInstallDate.ToShortTimeString
            End If

            ' Fill in .NET Framework information.
            TextBoxFrameworkVersion.Text = "Microsoft .NET Framework " & _Info.NetFrameworkVersion
            TextBoxClrVersion.Text = _Info.ClrVersion

            ' Hide Service Pack if not present.
            If String.IsNullOrEmpty(_Info.ClrServicePack) Then
                LabelFrameworkServicePack.Visible = False
                TextBoxClrServicePack.Text = ""
            ElseIf _Info.ClrServicePack.Trim() = "0" Then
                LabelFrameworkServicePack.Visible = False
                TextBoxClrServicePack.Text = ""
            Else
                LabelFrameworkServicePack.Visible = True
                TextBoxClrServicePack.Text = _Info.ClrServicePack
            End If

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Operating Systems panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Class
