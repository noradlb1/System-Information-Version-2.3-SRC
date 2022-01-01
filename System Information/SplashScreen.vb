Imports System.Data
Imports System.Threading
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Security
Imports Microsoft.Win32

Public NotInheritable Class SplashScreen

#Region " Private Members "

    Private _Is64Bit As Boolean

#End Region

#Region " Form Event Handlers "

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        ' First try to determine if the 32-bit program files environment variable exists.
        If Not String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ProgramFiles(x86)")) Then
            _Is64Bit = True
        End If

        ' If false, try this method of determing if running in 64 or 32 Bit environment.
        If _Is64Bit = False Then
            For Each ra As Reflection.Assembly In My.Application.Info.LoadedAssemblies
                If ra.Location.ToLower.Contains("framework64") Then _Is64Bit = True
                Exit For
            Next
        End If

        ' Application title.
        If My.Application.Info.Title <> "" Then
            LabelTitle.Text = My.Application.Info.Title
        Else
            ' If the application title is missing, use the application name, without the extension.
            LabelTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        ' Application company.
        LabelCompany.Text = "A Product of " & My.Application.Info.CompanyName

        ' Version.
        LabelVersion.Text = "Version " & My.Application.Info.Version.Major & "." & _
                                                 My.Application.Info.Version.Minor _
                                                 & " Build " & My.Application.Info.Version.Build _
                                                 & " Revision " & My.Application.Info.Version.Revision

        'LabelVersion.Text = System.String.Format(LabelVersion.Text, My.Application.Info.Version.Major, _
        '                                         My.Application.Info.Version.Minor)

        ' Copyright info.
        LabelCopyright.Text = My.Application.Info.Copyright

        '  fill in system information
        LabelWindowsVersion.Text = My.Computer.Info.OSFullName
        LabelOSDescription.Text = System.Environment.OSVersion.ToString()

        ' Display if 32 or 64 bit OS.
        If _Is64Bit Then
            LabelOSDescription.Text &= " (64-Bit)"
        Else
            LabelOSDescription.Text &= " (32-Bit)"
        End If

        LabelFrameworkVersion.Text = ".NET Framework Version " & ReturnHighestFrameworkVersion()

        LabelClrVersion.Text = "Common Language Runtime Version " & GetFrameworkShortVersion()
        If Not String.IsNullOrEmpty(GetFrameworkServicePack()) Or GetFrameworkServicePack() = "0" Then
            LabelClrVersion.Text = LabelClrVersion.Text & " Service Pack " & GetFrameworkServicePack()
        End If

    End Sub

#End Region

#Region " Threading Support Methods "

    ' Note: this code was converted from a C# example I found on the Internet. I'm sorry but the author's name
    ' was not in the project anywhere.

    ''' <summary>
    ''' Contains a singelton Shared splashscreen (runs in its own thread).
    ''' </summary>
    Private Shared singeltonSplashScreen As SplashScreen

    ''' <summary>
    ''' Indicates that the splasscreen is created.
    ''' </summary>
    Private Shared splashScreenCreatedEvent As ManualResetEvent = New ManualResetEvent(False)

    ''' <summary>
    ''' Constructor of the Splasscreen.
    ''' </summary>
    Public Sub New()

        InitializeComponent()

    End Sub

    ''' <summary>
    ''' Starts a new thread that runs the splasscreen.
    ''' </summary>
    Public Shared Sub StartSplashScreen()

        ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf StartSplashScreenMethod))

    End Sub

    ''' <summary>
    ''' Is the actual splashscreen method on a separate thread.
    ''' </summary>
    Private Shared Sub StartSplashScreenMethod(ByVal state As Object)

        Dim splashScreen As SplashScreen = New SplashScreen()
        singeltonSplashScreen = splashScreen
        Application.Run(splashScreen)

    End Sub

    ''' <summary>
    ''' Changes the state of the splasscreen.
    ''' </summary>
    ''' <param name="state"></param>
    Public Shared Sub SetSplashScreenState(ByVal state As String)

        ' Wait till the splasscreen is created.
        splashScreenCreatedEvent.WaitOne()

        ' BeginInvoke the SetSplashScreenStateMethod, this is thread-safe.
        singeltonSplashScreen.BeginInvoke(New ChangeSplashScreenDelegate(AddressOf singeltonSplashScreen.SetSplashScreenStateMethod), state)

    End Sub

    ''' <summary>
    ''' The private method called by SetSplasScreenState that actually changes the state.
    ''' </summary>
    Private Sub SetSplashScreenStateMethod(ByVal state As String)

        ProgressBarSplash.Value = CInt(state)

    End Sub

    ''' <summary>
    ''' Stops the splasscreen.
    ''' </summary>
    Public Shared Sub StopSplashScreen()

        ' Wait till the splasscreen is crated.
        splashScreenCreatedEvent.WaitOne()
        ' BeginInvoke the actual stopSplashScreenMethod, this is thread safe.
        singeltonSplashScreen.BeginInvoke(New ChangeSplashScreenDelegate(AddressOf singeltonSplashScreen.StopSplashScreenMethod), String.Empty)

    End Sub

    ''' <summary>
    ''' Stops the actual splashscreen.
    ''' </summary>
    ''' <param name="state"></param>
    Private Sub StopSplashScreenMethod(ByVal state As String)

        ' Just close the form.
        Me.Close()

    End Sub

    ''' <summary>
    ''' Handles the OnLoad of the splashscreen. When this is called the window and its handle exists.
    ''' </summary>
    Protected Overrides Sub OnLoad(ByVal e As EventArgs)

        ' Call the base.
        MyBase.OnLoad(e)

        ' Notify that the actual splasscreen is created, other methods may run now.
        splashScreenCreatedEvent.Set()

    End Sub

    ''' <summary>
    ''' Defines the delegate used to communicate with the splasscreen via BeginInvoke.
    ''' </summary>
    Private Delegate Sub ChangeSplashScreenDelegate(ByVal state As String)

#End Region

#Region " Get NET Framework Information "

    ''' <summary>
    ''' Framework short version, ie: 2.0
    ''' </summary>
    ''' <returns> Returns a string with the version number, if there is an error an
    ''' empty string is returned. </returns>
    Private Shared Function GetFrameworkShortVersion() As String

        Return Environment.Version.ToString().Substring(0, 3)

    End Function

    ''' <summary>
    ''' A special section of the registry has to be querried to find out the service pack
    ''' of the .NET Framework. A different location was used for 1.0 and 1.1, but since this
    ''' application only runs on version 2.0, we won't worry about that.
    ''' </summary>
    ''' <returns> A string containing the version number, for example: "2.0" </returns>
    Private Shared Function GetFrameworkServicePack() As String

        Dim frameworkMajorVersion As String = Environment.Version.Major.ToString()
        Dim frameworkMinorVersion As String = Environment.Version.Minor.ToString()
        Dim frameworkVersion As String = "v" & frameworkMajorVersion & "." & frameworkMinorVersion _
                & "." & Environment.Version.Build.ToString()
        Dim rk As RegistryKey
        Dim temp As String

        Try
            '  try each registry key to determine the version, build, and service pack
            If frameworkMajorVersion = "2" And frameworkMinorVersion = "0" Then

                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\" _
                        & frameworkVersion, False)
                temp = rk.GetValue("SP").ToString()
                If temp <> "0" Then
                    Return temp
                Else
                    Return ""
                End If
            Else
                Return String.Empty
            End If
        Catch ex As Win32Exception
            Return ""
        End Try

    End Function

    ''' <summary>
    ''' Queries the Registry and returns the highest .NET Framework version found or 0 if none is found.
    ''' </summary>
    ''' <returns>A double indicating the major and minor version of the .NET Framework.</returns>
    ''' <remarks>
    ''' This code is confirmed for versions 1.1, 2.0, 3.0 and 3.5. Later versions are simply educated guesses.
    ''' Hopefully beginning with version 3.5, Microsoft will assign the versioning task away from the
    ''' marketing department and this mess will not be necessary.
    ''' </remarks>
    Private Shared Function ReturnHighestFrameworkVersion() As String

        ' All values are "Install" except for V3.0. If version is installed, the DWORD = 1.
        Const netV11 As String = "Software\Microsoft\NET Framework Setup\NDP\v1.1.4322"
        Const netV20 As String = "Software\Microsoft\NET Framework Setup\NDP\v2.0.50727"
        Const netV30 As String = "Software\Microsoft\NET Framework Setup\NDP\v3.0\Setup" ' Value is "InstallSuccess"
        ' Alternate versions for .NET Framework on x64.
        Const netV30a As String = "Software\Microsoft\NET Framework Setup\NDP\v3.0\Setup\Windows Communication Foundation" ' Value is "InstallSuccess"
        Const netV30b As String = "Software\Microsoft\NET Framework Setup\NDP\v3.0\Setup\Windows Workflow Foundation" ' Value is "InstallSuccess"
        Const netV35 As String = "Software\Microsoft\NET Framework Setup\NDP\v3.5"
        Const netV40 As String = "Software\Microsoft\NET Framework Setup\NDP\v4.0"  ' Guess. Not Verified.
        Const netV45 As String = "Software\Microsoft\NET Framework Setup\NDP\v4.5"  ' Guess. Not Verified.
        Const netV50 As String = "Software\Microsoft\NET Framework Setup\NDP\v5.0"  ' Guess. Not Verified.

        Dim version As Double = 0
        Dim rk As RegistryKey = Nothing

        ' Surround whole set with Try-Catch to catch generic and security errors.
        Try
            ' Check if version 5.0 is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV50)
                    If rk.GetValue("Install").ToString = "1" Then
                        version = 5
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 4.5 is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV45)
                    If rk.GetValue("Install").ToString = "1" Then
                        version = 4.5
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 4.0 is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV40)
                    If rk.GetValue("Install").ToString = "1" Then
                        version = 4
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 3.5 is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV35)
                    If rk.GetValue("Install").ToString = "1" Then
                        version = 3.5
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 3.0 is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV30)
                    If rk.GetValue("InstallSuccess").ToString = "1" Then
                        version = 3
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 3.0a is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV30a)
                    If rk.GetValue("InstallSuccess").ToString = "1" Then
                        version = 3
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 3.0b is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV30b)
                    If rk.GetValue("InstallSuccess").ToString = "1" Then
                        version = 3
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 2.0 is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV20)
                    If rk.GetValue("Install").ToString = "1" Then
                        version = 2
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

            ' Check if version 1.1 is installed. Don't check if version is already found.
            If version = 0 Then
                Try
                    rk = Registry.LocalMachine.OpenSubKey(netV11)
                    If rk.GetValue("Install").ToString = "1" Then
                        version = 1.1
                    End If
                Catch ex As ArgumentException
                    version = 0
                Catch ex As NullReferenceException
                    version = 0
                End Try
            End If

        Catch ex As SecurityException
            MessageBox.Show("An error occurred reading the registry. The system returned this information:" _
                & vbCrLf & ex.Message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        Return version.ToString("0.0")

    End Function

#End Region

End Class
