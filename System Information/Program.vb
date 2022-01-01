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
Option Strict On
Option Explicit On

Imports System.IO
Imports System.Threading
Imports System.Diagnostics

Public Module Program

#Region " Constructor "

    ''' <summary>
    ''' Constructor of the MainForm.
    ''' </summary>
    Sub New()

        My.Settings.Reload()

        ' This code handles the splash screen so it's only needed when enabled.
        If My.Settings.ShowSplashScreen Then

            ' We want to hide the splashscreen when the mainform stops loading.
            AddHandler Application.Idle, AddressOf Application_Idle

            ' Enable visual styles.
            Application.EnableVisualStyles()

            ' Start the splashscreen in its own thread.
            SplashScreen.StartSplashScreen()

            ' Move the progress bar on the splash screen.
            For i As Integer = 0 To 300
                SplashScreen.SetSplashScreenState(i.ToString)
                Thread.Sleep(10)
            Next

        End If

    End Sub

#End Region

#Region " Sub Main "

    <STAThreadAttribute()> _
    Public Sub Main()

        Try
            ' Check if this process is running and exit if so.
            Dim processName As String = Process.GetCurrentProcess.ProcessName

            If CheckForDuplicateProcess(processName) Then Exit Try

            ' Enable visual styles.
            Application.EnableVisualStyles()

            ' Show player form.
            Application.Run(MainForm)

        Catch ex As Exception
            MessageBox.Show("Error initializing application in ""Sub Main.""" & vbCrLf & ex.Message, _
                My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Returns true if it finds more than one 'processName' running.
    ''' </summary>
    ''' <param name="processName">Name of process.</param>
    Private Function CheckForDuplicateProcess(ByVal processName As String) As Boolean

        Dim procs() As Process
        Dim proc As Process

        procs = Process.GetProcesses()

        Dim count As Integer = 0

        For Each proc In procs
            If proc.ProcessName.ToString.Equals(processName) Then
                count += 1
            End If
        Next proc

        If count > 1 Then
            Return True
        Else
            Return False
        End If

    End Function

#End Region

#Region " Splash Screen Idle Method "

    ' Handles the application idle.
    Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)

        ' Remove the event handler, we are done.
        RemoveHandler Application.Idle, AddressOf Application_Idle
        ' Stop the splasscreen.
        SplashScreen.StopSplashScreen()

    End Sub

#End Region

End Module
