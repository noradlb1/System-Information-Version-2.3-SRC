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

#Region " Imported Namespaces "

Imports Microsoft.Win32
Imports System
Imports System.IO
Imports System.Environment
Imports System.Management
Imports System.Drawing
Imports System.Text
Imports System.Collections
imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports System.Security.Principal
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles

#End Region

#Region " Enums "

' enumeration of procedures that can be initialized
Public Enum Initializer
    GetAll = 0
    GetCpuInfo = 1
    GetBiosInfo = 2
    GetVolumeInfo = 3
    GetVideoInfo = 4
    GetSoundInfo = 5
    GetNetAdaptorInfo = 6
    GetNetInterfaceInfo = 7
    GetDriveInformation = 8
    GetServiceInfo = 9
    GetNone = 99
End Enum

#End Region

Public Class ComputerInformation

#Region " Constructor "

    Public Sub New()
        myApp = GetType(ComputerInformation)
    End Sub

#End Region

#Region " Initialize "

    ''' <summary>
    ''' Initialize according to property setting.
    ''' </summary>
    Public Sub Initialize(ByVal initializer As Initializer)
        Select Case initializer
            Case Initializer.GetAll
                GetAll()
            Case Initializer.GetBiosInfo
                GetBiosInfo()
            Case Initializer.GetCpuInfo
                GetCpuInfo()
            Case Initializer.GetDriveInformation
                GetDriveInformation()
            Case Initializer.GetNetAdaptorInfo
                GetNetAdaptorInfo()
            Case Initializer.GetNetInterfaceInfo
                GetNetInterfaceInfo()
            Case Initializer.GetSoundInfo
                GetSoundInfo()
            Case Initializer.GetVideoInfo
                GetVideoInfo()
            Case Initializer.GetVolumeInfo
                GetVolumeInfo()
            Case Initializer.GetServiceInfo
                GetServiceInfo()
            Case Initializer.GetNone
            Case Else
                GetAll()
        End Select
    End Sub

    Private Sub GetAll()
        GetCpuInfo()
        GetBiosInfo()
        GetVolumeInfo()
        GetVideoInfo()
        GetSoundInfo()
        GetNetAdaptorInfo()
        GetNetInterfaceInfo()
        GetDriveInformation()
        GetServiceInfo()
    End Sub

#End Region

#Region " Variables, Constants, Declarations, and Enums "

#Region " Class-level Variables, Constants, and Declarations "

    ' Class-level variables.
    Private info As ManagementObject
    Private mTempDate As Date = Nothing

    ' Class-level constants.
    Private Const mRevision As String = "Revision"
    Private Const mUnknown As String = "Unknown"
    Private Const mDefaultDate As Date = #1/1/2006#

    ' Used to access information from Assembly (application) Attributes.
    Private myApp As Type

#End Region

#Region " Operating System Code Name Constants "

    ' code names
    Private Const mstrChicago As String = "Chicago"
    Private Const mstrDaytona As String = "Daytona"
    Private Const mstrDetroit As String = "Detroit"
    Private Const mstrMemphis As String = "Memphis"
    Private Const mstrGeorgia As String = "Georgia"
    Private Const mstrCairo As String = "Cairo"
    Private Const mstrCairoNT5 As String = "Cairo/NT5"
    Private Const mstrWhistler As String = "Whistler"
    Private Const mstrWhistlerServer As String = "Whistler Server"
    Private Const mstrLonghorn As String = "Longhorn"

#End Region

#Region " Local Variables for Property Values "

    Private _AppBuild As String
    Private _AppCompanyName As String
    Private _AppCopyright As String
    Private _AppDescription As String
    Private _AppDirectory As String
    Private _AppMajorRevision As Integer
    Private _AppMajorVersion As Integer
    Private _AppMinorRevision As Integer
    Private _AppMinorVersion As Integer
    Private _AppProductName As String
    Private _AppRevision As String
    Private _AppShortVersion As String
    Private _AppTitle As String
    Private _AppTrademark As String
    Private _AppVersion As String
    Private _BiosFeatures As New Collection(Of String)
    Private _BiosManufacturer As String
    Private _BiosName As String
    Private _BiosReleaseDate As String
    Private _BiosSmBiosPresent As Boolean
    Private _BiosSmBiosVersion As String
    Private _BiosVersion As String
    Private _CDDrive As New Collection(Of String)
    Private _CDManufacturer As New Collection(Of String)
    Private _CDMediaSize As New Collection(Of String)
    Private _CDModel As New Collection(Of String)
    Private _CDRevisionLevel As New Collection(Of String)
    Private _CDStatus As New Collection(Of String)
    Private _CompAutomaticResetCapability As Boolean
    Private _CompDescription As String
    Private _CompManufacturer As String
    Private _CompModel As String
    Private _CompSystemType As String
    Private _CpuAddressWidth As String
    Private _CpuDescription As String
    Private _CpuFsbSpeed As String
    Private _CpuL2CacheSize As String
    Private _CpuL2CacheSpeed As String
    Private _CpuLoadPercentage As New Collection(Of Integer)
    Private _CpuManufacturer As String
    Private _CpuName As String
    Private _CpuNumberOfCores As Integer
    Private _CpuNumberOfLogicalProcessors As Integer
    Private _CpuNumberOfProcessors As Integer
    Private _CpuPowerManagementSupported As Boolean
    Private _CpuPowerManagementCapabilities As String
    Private _CpuProcessorId As String
    Private _CpuSocket As String
    Private _CpuSpeed As String
    Private _DriveCapacity As New Collection(Of String)
    Private _DriveInterface As New Collection(Of String)
    Private _DriveModelNo As New Collection(Of String)
    Private _DriveStatus As New Collection(Of String)
    Private _CLRMajorVersion As Integer
    Private _CLRMinorVersion As Integer
    Private _CLRServicePack As String
    Private _CLRShortVersion As String
    Private _CLRVersion As String
    Private _Is64Bit As Boolean
    Private _MainBoardManufacturer As String
    Private _MainBoardModel As String
    Private _MemAvailPhysical As String
    Private _MemAvailVirtual As String
    Private _MemTotalPhysical As String
    Private _MemTotalVirtual As String
    Private _NetFrameworkVersion As String
    Private _NetAdapterType As New Collection(Of String)
    Private _NetAutoSense As New Collection(Of String)
    Private _NetConnectionId As New Collection(Of String)
    Private _NetConnectionStatus As New Collection(Of String)
    Private _NetDefaultTtl As New Collection(Of String)
    Private _NetDhcpEnabled As New Collection(Of Boolean)
    Private _NetDhcpLeaseExpires As New Collection(Of String)
    Private _NetDhcpLeaseObtained As New Collection(Of String)
    Private _NetDhcpServer As New Collection(Of String)
    Private _NetDomain As New Collection(Of String)
    Private _NetHostName As New Collection(Of String)
    ' Modified to show all IP addresses including IPv6.
    Private _NetIPAddress As New Collection(Of String())
    Private _NetIPEnabled As New Collection(Of Boolean)
    Private _NetIsNetworkConfigured As Boolean
    Private _NetMacAddress As New Collection(Of String)
    Private _NetManufacturer As New Collection(Of String)
    Private _NetMaxSpeed As New Collection(Of String)
    Private _NetMtu As New Collection(Of String)
    Private _NetNumberOfAdaptors As Integer
    Private _NetProductName As New Collection(Of String)
    Private _NetSpeed As New Collection(Of String)
    Private _NetTcpNumConnections As New Collection(Of String)
    Private _NetTcpWindowSize As New Collection(Of String)
    Private _OSBootupState As String
    Private _OSBuild As String
    Private _OSCodename As String
    Private _OSDomain As String
    Private _OSFullName As String
    Private _OSInstallDate As Date
    Private _OSInstallTime As Date
    Private _OSMachineName As String
    Private _OSMajorVersion As Integer
    Private _OSMinorVersion As Integer
    Private _OSPartOfDomain As Boolean
    Private _OSPlatform As System.PlatformID
    Private _OSProductId As String
    Private _OSProductKey As String
    Private _OSServicePack As String
    Private _OSShortVersion As String
    Private _OSStartTime As Date
    Private _OSType As String
    Private _OSUptime As String
    Private _OSUserName As String
    Private _OSVersion As String
    Private _PwrCanHibernate As Boolean
    Private _PwrCanShutdown As Boolean
    Private _PwrCanSuspend As Boolean
    Private _ServiceDisplayName As New Collection(Of String)
    Private _ServiceDescription As New Collection(Of String)
    Private _ServiceStartMode As New Collection(Of String)
    Private _ServiceState As New Collection(Of String)
    Private _ServiceStatus As New Collection(Of String)
    Private _ServicePathName As New Collection(Of String)
    Private _SndController As New Collection(Of String)
    Private _SndDMABufferSize As New Collection(Of String)
    Private _SndManufacturer As New Collection(Of String)
    Private _SndNumberOfControllers As Integer
    Private _TimeCurrentTimeZone As String
    Private _TimeDaylightSavingsInEffect As Boolean
    Private _TimeDaylightSavingsName As String
    Private _TimeDaylightSavingsOffset As Integer
    Private _TimeLocalDaylightEndDate As Date
    Private _TimeLocalDaylightEndTime As Date
    Private _TimeLocalDaylightStartDate As Date
    Private _TimeLocalDaylightStartTime As Date
    Private _TimeLocalDateTime As Date
    Private _TimeUniversalDateTime As Date
    Private _TimeUniversalDaylightEndDate As Date
    Private _TimeUniversalDaylightEndTime As Date
    Private _TimeUniversalDaylightStartDate As Date
    Private _TimeUniversalDaylightStartTime As Date
    Private _UniversalTimeOffset As Integer
    Private _TimeWeekOfYear As Integer
    Private _UserFlags As New Collection(Of Integer)
    Private _UserRegisteredName As String
    Private _UserRegisteredOrganization As String
    Private _UserRegisteredNameWow6432Node As String
    Private _UserRegisteredOrganizationWow6432Node As String
    Private _UserIsAdministrator As Boolean
    Private _UserAccounts As New Collection(Of String)
    Private _UserFullNames As New Collection(Of String)
    Private _UserPrivileges As New Collection(Of String)
    Private _VidController As New Collection(Of String)
    Private _VidPrimaryScreenDimensions As String
    Private _VidPrimaryScreenWorkingArea As String
    Private _VidSecondaryScreenDimensions As String
    Private _VidSecondaryScreenWorkingArea As String
    Private _VidTertiaryScreenDimensions As String
    Private _VidTertiaryScreenWorkingArea As String
    Private _VidQuaternaryScreenDimensions As String
    Private _VidQuaternaryScreenWorkingArea As String
    Private _VidNumberOfControllers As Integer
    Private _VidRam As New Collection(Of String)
    Private _VidRefreshRate As New Collection(Of String)
    Private _VidScreenColors As New Collection(Of String)
    Private _VolumeFileSystem As New Collection(Of String)
    Private _VolumeFreeSpace As New Collection(Of String)
    Private _VolumeIsFloppyReady As Boolean
    Private _VolumeLabel As New Collection(Of String)
    Private _VolumeLetter As New Collection(Of String)
    Private _VolumePercentFreeSpace As New Collection(Of String)
    Private _VolumeReady As New Collection(Of Boolean)
    Private _VolumeSerialNumber As New Collection(Of String)
    Private _VolumeTotalSize As New Collection(Of String)
    Private _VolumeType As New Collection(Of String)
    Private _VolumeUsedSpace As New Collection(Of String)
    Private _VstAuthor As String
    Private _VstColorScheme As String
    Private _VstCompany As String
    Private _VstControlHighlightHot As Drawing.Color
    Private _VstCopyright As String
    Private _VstDescription As String
    Private _VstDisplayName As String
    Private _VstIsEnabledByUser As Boolean
    Private _VstIsSupportedByOS As Boolean
    Private _VstMinimumColorDepth As Integer
    Private _VstSize As String
    Private _VstSupportsFlatMenus As Boolean
    Private _VstTextControlBorder As Drawing.Color
    Private _VstUrl As String
    Private _VstVersion As String

#End Region

#End Region

#Region " Helper and Formating Methods "

#Region " Return BIOS Feature "

    Private Shared Function ReturnBiosFeature(ByVal shtFeature As Short) As String

        If shtFeature > 39 And shtFeature < 48 Then ' Eliminated complex case statements for C# compatibility.
            Return "Reserved for BIOS vendor"
        ElseIf shtFeature > 47 And shtFeature < 64 Then
            Return "Reserved for system vendor"
        Else
            Select Case shtFeature
                Case 0
                    Return "Reserved"
                Case 1
                    Return "Reserved"
                Case 2
                    Return mUnknown
                Case 3
                    Return "BIOS Characteristics Not Supported "
                Case 4
                    Return "ISA is supported"
                Case 5
                    Return "MCA is supported"
                Case 6
                    Return "EISA is supported"
                Case 7
                    Return "PCI is supported"
                Case 8
                    Return "PC Card(PCMCIA) Is supported"
                Case 9
                    Return "Plug and Play is supported"
                Case 10
                    Return "APM is supported"
                Case 11
                    Return "BIOS is Upgradable (Flash)"
                Case 12
                    Return "BIOS shadowing Is allowed"
                Case 13
                    Return "VL-VESA Is supported"
                Case 14
                    Return "ESCD support Is available"
                Case 15
                    Return "Boot from CD is supported"
                Case 16
                    Return "Selectable Boot Is supported"
                Case 17
                    Return "BIOS ROM Is socketed"
                Case 18
                    Return "Boot From PC Card (PCMCIA) is supported"
                Case 19
                    Return "EDD (Enhanced Disk Drive) Specification is supported"
                Case 20
                    Return "Int 13h - Japanese Floppy for NEC 9800 1.2mb (3.5, 1k Bytes/Sector, 360 RPM) is supported"
                Case 21
                    Return "Int 13h - Japanese Floppy for Toshiba 1.2mb (3.5, 360 RPM) is supported"
                Case 22
                    Return "Int 13h - 5.25 / 360 KB Floppy Services are supported"
                Case 23
                    Return "Int 13h - 5.25 /1.2MB Floppy Services are supported"
                Case 24
                    Return "Int 13h - 3.5 / 720 KB Floppy Services are supported"
                Case 25
                    Return "Int 13h - 3.5 / 2.88 MB Floppy Services are supported"
                Case 26
                    Return "Int 5h, Print Screen Service is supported"
                Case 27
                    Return "Int 9h, 8042 Keyboard services are supported"
                Case 28
                    Return "Int 14h, Serial Services are supported"
                Case 29
                    Return "Int 17h, printer services are supported"
                Case 30
                    Return "Int 10h, CGA/Mono Video Services are supported"
                Case 31
                    Return "NEC PC - 98"
                Case 32
                    Return "ACPI supported"
                Case 33
                    Return "USB Legacy Is supported"
                Case 34
                    Return "AGP is supported"
                Case 35
                    Return "I2O boot Is supported"
                Case 36
                    Return "LS-120 boot is supported"
                Case 37
                    Return "ATAPI ZIP Drive boot is supported"
                Case 38
                    Return "1394 boot is supported"
                Case 39
                    Return "Smart Battery supported"
                Case Else
                    Return ""
            End Select
        End If

    End Function

#End Region

#Region " Return Colors "

    Private Shared Function ReturnColors(ByVal Bits As Int32) As String

        ' no video card has more than 1.67 million colors
        If Bits > 24 Then Bits = 24

        Select Case Bits
            Case 2
                Return "2 Colors (Black and White)"
            Case 4
                Return "16 Colors"
            Case 8
                Return "256 Colors"
            Case 16
                Return "65,535 Colors (High Color)"
            Case 24
                Return "16.8 Million Colors (True Color)"
            Case Else
                Return mUnknown
        End Select

    End Function

#End Region

#Region " Return Network Connection Status "

    Private Shared Function ReturnNetConnectionStatus(ByVal intStatus As Integer) As String

        Select Case intStatus
            Case 0
                Return "Disconnected"
            Case 1
                Return "Connecting"
            Case 2
                Return "Connected"
            Case 3
                Return "Disconnecting"
            Case 4
                Return "Hardware not present"
            Case 5
                Return "Hardware disabled"
            Case 6
                Return "Hardware malfunction"
            Case 7
                Return "Media disconnected"
            Case 8
                Return "Authenticating"
            Case 9
                Return "Authentication succeeded"
            Case 10
                Return "Authentication failed"
            Case 11
                Return "Invalid address"
            Case 12
                Return "Credentials required"
            Case Else
                Return ""
        End Select

    End Function

#End Region

#Region " Return CPU Power Management Capabilities "

    Private Shared Function ReturnPowerCapabilites(ByVal powerCap As Integer) As String

        Dim returnValue As String

        Select Case powerCap
            Case 0
                returnValue = "Unknown"
            Case 1
                returnValue = "Not Supported"
            Case 2
                returnValue = "Disabled"
            Case 3
                returnValue = "Enabled"
            Case 4
                returnValue = "Automatic"
            Case 5
                returnValue = "Settable"
            Case 6
                returnValue = "Power Cycling Supported"
            Case 7
                returnValue = "Timed Power On Supported"
            Case Else
                returnValue = "Unknown"
        End Select

        Return returnValue

    End Function

#End Region

#Region " Formatting Subroutines "

    Private Shared Function FormatBytes(ByVal bytes As Double) As String
        Dim temp As Double

        If bytes >= 1073741824 Then
            temp = bytes / 1073741824   ' GB
            Return String.Format("{0:N2}", temp) & " GB"
        ElseIf bytes >= 1048576 And bytes <= 1073741823 Then
            temp = bytes / 1048576  'MB
            Return String.Format("{0:N0}", temp) & " MB"
        ElseIf bytes >= 1024 And bytes <= 1048575 Then
            temp = bytes / 1024 ' KB
            Return String.Format("{0:N0}", temp) & " KB"
        ElseIf bytes = 0 And bytes <= 1023 Then
            temp = bytes    ' bytes
            Return String.Format("{0:N0}", bytes) & " bytes"
        Else
            Return ""
        End If

    End Function

    Private Shared Function FormatHertz(ByVal hertz As Double) As String
        Dim temp As Double

        If hertz >= 1000000000 Then 'GHz
            temp = hertz / 1000000000
            Return String.Format("{0:N2}", temp) & " GHz"
        ElseIf hertz >= 1048576 And hertz <= 1073741823 Then
            temp = hertz / 1000000 'MHz
            Return String.Format("{0:N2}", temp) & " MHz"
        ElseIf hertz >= 1024 And hertz <= 1048575 Then
            temp = hertz / 1000 'KHz
            Return String.Format("{0:N2}", temp) & " KHz"
        ElseIf hertz >= 0 And hertz <= 1023 Then
            temp = hertz ' Hz
            Return String.Format("{0:N0}", hertz) & " Hz"
        Else
            Return ""
        End If

    End Function

#End Region

#End Region

#Region " Information Retrieval Methods "

#Region " Get Application Information "

    Private Function GetAppCompanyName() As String

        Dim at As Type = GetType(AssemblyCompanyAttribute)
        Dim r() As Object = myApp.Assembly.GetCustomAttributes(at, False)
        Dim ct As AssemblyCompanyAttribute = CType(r(0), AssemblyCompanyAttribute)
        Return ct.Company

    End Function

    Private Function GetAppCopyright() As String

        Dim at As Type = GetType(AssemblyCopyrightAttribute)
        Dim r() As Object = myApp.Assembly.GetCustomAttributes(at, False)
        Dim ct As AssemblyCopyrightAttribute = CType(r(0), AssemblyCopyrightAttribute)
        Return ct.Copyright

    End Function

    Private Function GetAppDescription() As String

        Dim at As Type = GetType(AssemblyDescriptionAttribute)
        Dim r() As Object = myApp.Assembly.GetCustomAttributes(at, False)
        Dim da As AssemblyDescriptionAttribute = CType(r(0), AssemblyDescriptionAttribute)
        Return da.Description

    End Function

    Private Function GetAppProductName() As String

        Dim at As Type = GetType(AssemblyProductAttribute)
        Dim r() As Object = myApp.Assembly.GetCustomAttributes(at, False)
        Dim pt As AssemblyProductAttribute = CType(r(0), AssemblyProductAttribute)
        Return pt.Product

    End Function

    Private Function GetAppTitle() As String

        Dim at As Type = GetType(AssemblyTitleAttribute)
        Dim r() As Object = myApp.Assembly.GetCustomAttributes(at, False)
        Dim ta As AssemblyTitleAttribute = CType(r(0), AssemblyTitleAttribute)
        Return ta.Title

    End Function

    Private Function GetAppTrademark() As String

        Dim at As Type = GetType(AssemblyTrademarkAttribute)
        Dim r() As Object = myApp.Assembly.GetCustomAttributes(at, False)
        Dim ma As AssemblyTrademarkAttribute = CType(r(0), AssemblyTrademarkAttribute)
        Return ma.Trademark

    End Function

    Private Function GetAppVersion() As String

        Return myApp.Assembly.GetName.Version.ToString()

    End Function

    Private Function GetAppMajorRevision() As Integer

        Return CInt(myApp.Assembly.GetName.Version.MajorRevision)

    End Function

    Private Function GetAppMajorVersion() As Integer

        Return myApp.Assembly.GetName.Version.Major

    End Function

    Private Function GetAppMinorRevision() As Integer

        Return myApp.Assembly.GetName.Version.Major

    End Function

    Private Function GetAppMinorVersion() As Integer

        Return myApp.Assembly.GetName.Version.Minor

    End Function

    Private Function GetAppRevision() As String

        Return myApp.Assembly.GetName.Version.Revision.ToString

    End Function

    Private Function GetAppShortVersion() As String

        Return myApp.Assembly.GetName.Version.ToString.Substring(0, 3)

    End Function

    Private Function GetAppBuild() As String

        Return myApp.Assembly.GetName.Version.Build.ToString

    End Function

    Private Shared Function GetAppDirectory() As String

        Return Environment.CurrentDirectory

    End Function

#End Region

#Region " Get BIOS Information "

    Private Sub GetBiosInfo()

        Dim query As New SelectQuery("Win32_BIOS")
        Dim search As New ManagementObjectSearcher(query)
        Dim features() As Short
        Dim count As Integer

        For Each info In search.Get()
            Try
                If info("PrimaryBios") IsNot Nothing Then
                    If CType(info("PrimaryBIOS"), Boolean) = True Then

                        Try
                            _BiosManufacturer = info("Manufacturer").ToString
                        Catch
                            _BiosManufacturer = mUnknown
                        End Try

                        Try
                            _BiosName = info("Name").ToString
                        Catch
                            _BiosName = mUnknown
                        End Try

                        Try
                            _BiosVersion = info("Version").ToString
                        Catch
                            _BiosVersion = mUnknown
                        End Try

                        Try
                            _BiosReleaseDate = _
                                info("ReleaseDate").ToString.Substring(0, 8).Insert(4, "-").Insert(7, "-")
                        Catch
                            _BiosReleaseDate = mUnknown
                        End Try

                        Try
                            features = CType(info("BiosCharacteristics"), Short())
                            For count = 0 To UBound(features)
                                If Not String.IsNullOrEmpty(ReturnBiosFeature(features(count))) Then
                                    _BiosFeatures.Add(ReturnBiosFeature(features(count)))
                                End If
                            Next
                        Catch
                            _BiosFeatures.Add("")
                        End Try
                    End If

                    Try
                        _BiosSmBiosPresent = CType(info("SMBIOSPresent"), Boolean)

                        If _BiosSmBiosPresent = True Then
                            _BiosSmBiosVersion = info("SMBIOSMajorVersion").ToString & "." & _
                                info("SMBIOSMinorVersion").ToString
                        Else
                            _BiosSmBiosVersion = ""
                        End If
                    Catch
                        _BiosSmBiosPresent = False
                        _BiosSmBiosVersion = ""
                    End Try

                End If

            Catch
                _BiosManufacturer = ""
                _BiosName = ""
                _BiosVersion = ""
                _BiosReleaseDate = ""
                _BiosFeatures = Nothing
                _BiosSmBiosPresent = False
                _BiosSmBiosVersion = ""
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

#End Region

#Region " Get CDROM Drive Information "

    Private Function GetCDDrive() As Collection(Of String)
        Dim temp As New Collection(Of String)

        Dim query As New SelectQuery("Win32_CDROMDrive")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp.Add(info("Drive").ToString)
            Catch
                temp.Add("")
            End Try

        Next

        Return temp

    End Function

    Private Function GetCDManufacturer() As Collection(Of String)
        Dim temp As New Collection(Of String)

        Dim query As New SelectQuery("Win32_CDROMDrive")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp.Add(info("Manufacturer").ToString)
            Catch
                temp.Add("")
            End Try

        Next

        Return temp

    End Function

    Private Function GetCDModel() As Collection(Of String)
        Dim temp As New Collection(Of String)

        Dim query As New SelectQuery("Win32_CDROMDrive")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            If info("Name") IsNot Nothing Then
                temp.Add(info("Name").ToString)
            End If
        Next

        Return temp

    End Function

    Private Function GetCDRevisionLevel() As Collection(Of String)
        Dim temp As New Collection(Of String)

        Dim query As New SelectQuery("Win32_CDROMDrive")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                If info("MfrAssignedRevisionLevel").ToString = "" Then
                    temp.Add(info("MfrAssignedRevisionLevel").ToString)
                ElseIf info("RevisionLevel").ToString = "" Then
                    temp.Add(info("RevisionLevel").ToString)
                End If
            Catch
                temp.Add("N/A")
            End Try

        Next

        Return temp

    End Function

    Private Function GetCDMediaSize() As Collection(Of String)
        Dim temp As New Collection(Of String)

        Dim query As New SelectQuery("Win32_CDROMDrive")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp.Add(FormatBytes(CDbl(info("Size"))))
            Catch
                temp.Add("Unknown")
            End Try

        Next

        Return temp

    End Function

    Private Function GetCDStatus() As Collection(Of String)
        Dim temp As New Collection(Of String)

        Dim query As New SelectQuery("Win32_CDROMDrive")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp.Add(info("Status").ToString())
            Catch
                temp.Add("Unknown")
            End Try

        Next

        Return temp

    End Function

#End Region

#Region " Get Computer Information "

    Private Function GetCompAutomaticResetCapability() As Boolean
        Dim temp As Boolean

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = CBool(info("Caption"))
            Catch
                temp = False
            End Try

        Next

        Return temp

    End Function

    Private Function GetCompDescription() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = info("Description").ToString
            Catch
                temp = ""
            End Try

        Next

        Return temp

    End Function

    Private Function GetCompManufacturer() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = info("Manufacturer").ToString
            Catch
                temp = ""
            End Try

        Next

        Return temp

    End Function

    Private Function GetCompModel() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = info("Model").ToString
            Catch
                temp = ""
            End Try

        Next

        Return temp

    End Function

    Private Function GetCompSystemType() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = info("SystemType").ToString
            Catch
                temp = ""
            End Try

        Next

        Return temp

    End Function

#End Region

#Region " Get CPU Information "

    Private Sub GetCpuInfo()

        Dim query As New SelectQuery("Win32_Processor")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get

            Try
                _CpuAddressWidth = info("AddressWidth").ToString & " bit"
            Catch
                _CpuAddressWidth = mUnknown
            End Try

            Try
                _CpuDescription = info("Description").ToString
            Catch
                _CpuDescription = mUnknown
            End Try

            Try
                _CpuFsbSpeed = info("ExtClock").ToString & " MHz"
            Catch
                _CpuFsbSpeed = mUnknown
            End Try

            Try
                If CDbl(info("L2CacheSize")) = 0 Then
                    _CpuL2CacheSize = mUnknown
                Else
                    _CpuL2CacheSize = FormatBytes(CDbl(info("L2CacheSize")) * 1024)
                End If
            Catch
                _CpuL2CacheSize = mUnknown
            End Try

            Try
                If CDbl(info("L2CacheSpeed")) = 0 Then
                    _CpuL2CacheSpeed = mUnknown
                Else
                    _CpuL2CacheSpeed = FormatHertz(CDbl(info("L2CacheSpeed")) * 1000000)
                End If
            Catch
                _CpuL2CacheSpeed = mUnknown
            End Try

            Try
                _CpuManufacturer = info("Manufacturer").ToString
            Catch
                _CpuManufacturer = mUnknown
            End Try

            Try
                _CpuName = info("Name").ToString
            Catch
                _CpuName = mUnknown
            End Try

            Try
                _CpuSocket = info("SocketDesignation").ToString
            Catch
                _CpuSocket = mUnknown
            End Try

            Try
                _CpuSpeed = FormatHertz(CDbl(info("CurrentClockSpeed")) * 1000000)
            Catch
                _CpuSpeed = mUnknown
            End Try

            Try
                _CpuPowerManagementSupported = CBool(info("PowerManagementSupported"))
            Catch
                _CpuPowerManagementSupported = False
            End Try

            Try
                _CpuPowerManagementCapabilities = ReturnPowerCapabilites(CInt(info("PowerManagementCapabilities")))
            Catch
                _CpuPowerManagementCapabilities = mUnknown
            End Try

            Try
                _CpuProcessorId = info("ProcessorID").ToString()
            Catch
                _CpuProcessorId = "Not Present or Unknown"
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

    Private Function GetCpuLoadPercentage() As Collection(Of Integer)

        Dim query As New SelectQuery("Win32_Processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim load As New Collection(Of Integer)

        For Each info In search.Get

            Try
                load.Add(CInt(info("LoadPercentage")))
            Catch
                load.Add(0)
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return load

    End Function

    Private Shared Function GetCpuNumberOfProcessors() As Integer

        Return CInt(Environment.ProcessorCount)

    End Function

    Private Function GetCpuNumberOfCores() As Integer

        Dim query As New SelectQuery("Win32_Processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim number As Integer

        For Each info In search.Get

            Try

                number = CInt(info("NumberOfCores"))
            Catch
                number = 0
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return number

    End Function

    Private Function GetCpuNumberOfLogicalProcessors() As Integer

        Dim query As New SelectQuery("Win32_Processor")
        Dim search As New ManagementObjectSearcher(query)
        Dim number As Integer

        For Each info In search.Get

            Try
                number = CInt(info("NumberOfLogicalProcessors"))
            Catch
                number = 0
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return number

    End Function

#End Region

#Region " Get Hard Drive Information "

    Private Sub GetDriveInformation()

        Dim query As New SelectQuery("Win32_DiskDrive")
        Dim search As New ManagementObjectSearcher(query)
        Dim count As Integer

        For Each info In search.Get()

            Try
                _DriveCapacity.Add( _
                    FormatBytes(CDbl((CType(info("TotalSectors"), UInt64) * _
                        CType(info("BytesPerSector"), UInt32)))))
            Catch
                _DriveCapacity.Add(mUnknown)
            End Try


            Try
                _DriveInterface.Add(info("InterfaceType").ToString)
            Catch
                _DriveInterface.Add(mUnknown)
            End Try

            Try
                _DriveModelNo.Add(info("Model").ToString)
            Catch
                _DriveModelNo.Add(mUnknown)
            End Try

            Try
                _DriveStatus.Add(info("Status").ToString)
            Catch
                _DriveStatus.Add(info("Status").ToString)
            End Try

            count += 1

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

#End Region

#Region " Get Mainboard Information "

    Private Function GetMainBoardManufacturer() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_BaseBoard")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get

            Try
                temp = (info("Manufacturer").ToString)
            Catch
                temp = "N/A"
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return temp

    End Function

    Private Function GetMainBoardModel() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_BaseBoard")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get

            Try
                temp = info("Product").ToString
            Catch
                temp = "N/A"
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return temp

    End Function

#End Region

#Region " Get CLR and NET Framework Information "

    Private Shared Function GetClrVersion() As String

        Return Environment.Version.ToString

    End Function

    Private Shared Function GetClrMajorVersion() As Integer

        Return Environment.Version.Major

    End Function

    Private Shared Function GetClrMinorVersion() As Integer

        Return Environment.Version.Minor

    End Function

    Private Shared Function GetClrShortVersion() As String

        Return Environment.Version.ToString.Substring(0, 3)

    End Function

    Private Shared Function GetClrServicePack() As String
        Dim strFrameworkMajorVersion As String = Environment.Version.Major.ToString
        Dim strFrameworkMinorVersion As String = Environment.Version.Minor.ToString
        Dim strFrameworkVersion As String = "v" & strFrameworkMajorVersion & "." & _
            strFrameworkMinorVersion & "." & Environment.Version.Build.ToString
        Dim rk As RegistryKey = Nothing
        Dim temp As String = ""

        Try
            ' try each registry key to determine the version, build, and service pack
            If strFrameworkMajorVersion.Trim = "2" And strFrameworkMinorVersion.Trim = "0" Then
                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\NET Framework Setup\NDP\" _
                    & strFrameworkVersion)
                temp = rk.GetValue("SP").ToString

            Else
                temp = ""
            End If

        Catch
            temp = ""
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        Return temp

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
    Private Shared Function GetFrameworkVersion() As String

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

#Region " Get Network Adaptor Information "

    Private Sub GetNetAdaptorInfo()
        Dim query As New SelectQuery("Win32_NetworkAdapter")
        Dim search As New ManagementObjectSearcher(query)
        Dim count As Integer

        For Each info In search.Get

            Try
                _NetAdapterType.Add(info("AdapterType").ToString)
            Catch
                _NetAdapterType.Add("N/A")
            End Try

            Try
                _NetAutoSense.Add(info("AutoSense").ToString)
            Catch
                _NetAutoSense.Add("N/A")
            End Try

            Try
                _NetMacAddress.Add(info("MACAddress").ToString)
            Catch
                _NetMacAddress.Add("N/A")
            End Try

            Try
                _NetManufacturer.Add(info("Manufacturer").ToString)
            Catch
                _NetManufacturer.Add("N/A")
            End Try

            Try
                _NetMaxSpeed.Add(info("MaxSpeed").ToString)
            Catch
                _NetMaxSpeed.Add("N/A")
            End Try

            Try
                _NetConnectionId.Add(info("NetConnectionID").ToString)
            Catch
                _NetConnectionId.Add("N/A")
            End Try

            ' this feature was not implemented until Windows XP
            Try
                If GetOSMajorVersion() >= 5 And GetOSMajorVersion() >= 1 Then
                    _NetConnectionStatus.Add( _
                        ReturnNetConnectionStatus(CInt(info("NetConnectionStatus"))))
                Else
                    _NetConnectionStatus.Add("N/A")
                End If
            Catch
                _NetConnectionStatus.Add("N/A")
            End Try

            Try
                _NetProductName.Add(info("ProductName").ToString)
            Catch
                _NetProductName.Add("N/A")
            End Try

            Try
                _NetSpeed.Add(info("Speed").ToString)
            Catch
                _NetSpeed.Add("N/A")
            End Try

            count += 1
            _NetNumberOfAdaptors = count

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

#End Region

#Region " Get Network Interface Information "

    Private Sub GetNetInterfaceInfo()
        Dim query As New SelectQuery("Win32_NetworkAdapterConfiguration")
        Dim search As New ManagementObjectSearcher(query)
        Dim count As Integer
        Dim temp() As String = Nothing

        For Each info In search.Get

            Try
                _NetDefaultTtl.Add(info("DefaultTTL").ToString)
            Catch
                _NetDefaultTtl.Add("N/A")
            End Try

            Try
                _NetDhcpEnabled.Add(CBool(info("DHCPEnabled")))
            Catch
                _NetDhcpEnabled.Add(False)
            End Try

            Try
                _NetDhcpLeaseExpires.Add(info("DHCPLeaseExpires").ToString.Substring( _
                    0, 8).Insert(4, "-").Insert(7, "-"))
            Catch
                _NetDhcpLeaseExpires.Add("N/A")
            End Try

            Try
                _NetDhcpLeaseObtained.Add(info("DHCPLeaseObtained").ToString.Substring( _
                    0, 8).Insert(4, "-").Insert(7, "-"))
            Catch
                _NetDhcpLeaseObtained.Add("N/A")
            End Try

            Try
                _NetDhcpServer.Add(info("DHCPServer").ToString)
            Catch
                _NetDhcpServer.Add("N/A")
            End Try

            Try
                _NetHostName.Add(info("DNSHostName").ToString)
            Catch
                _NetHostName.Add("N/A")
            End Try

            Try
                _NetDomain.Add(info("DNSDomain").ToString)
            Catch
                _NetDomain.Add("N/A")
            End Try

            Try
                _NetIPEnabled.Add(CBool(info("IPEnabled")))
            Catch
                _NetIPEnabled.Add(False)
            End Try

            Try
                ' Modified to show all IP addresses including IPv6.
                temp = CType(info("IPAddress"), String())
                _NetIPAddress.Add(temp)
            Catch
                _NetIPAddress.Add(Nothing)
            End Try

            Try
                _NetMtu.Add(FormatBytes(CDbl(info("MTU"))))
            Catch
                _NetMtu.Add("N/A")
            End Try

            Try
                _NetTcpNumConnections.Add(info("TCPNumConnections").ToString)
            Catch
                _NetTcpNumConnections.Add("N/A")
            End Try

            Try
                _NetTcpWindowSize.Add(FormatBytes(CDbl(info("TcpWindowSize"))))
            Catch
                _NetTcpWindowSize.Add("N/A")
            End Try

            count += 1

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

#End Region

#Region " Get Operating System Information "

    Private Function GetOSDomain() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = info("Domain").ToString
            Catch
                temp = ""
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return temp

    End Function

    Private Function GetOSPartOfDomain() As Boolean
        Dim temp As Boolean

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = CBool(info("PartOfDomain"))
            Catch
                temp = False
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return temp

    End Function

    Private Shared Function GetOSInstallDate() As Date

        ' The install date/time is stored in the registry as the number of seconds since 01/01/1970 @ midnight.
        Dim rk As RegistryKey = Nothing
        Dim installDate As Date
        Dim origDate As Date
        Dim secondsSince1970 As Double

        Try

            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
            secondsSince1970 = CDbl(rk.GetValue("InstallDate"))

            If DateTime.TryParse("01/01/1970 00:00:00", origDate) Then
                installDate = origDate.AddSeconds(secondsSince1970)
            End If

        Catch
            installDate = DateTime.Today    ' If error, just return today's date.
        Finally
            If rk IsNot Nothing Then
                rk.Close()
            End If
        End Try

        Return installDate

    End Function

    Private Function GetOSBootupState() As String
        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_ComputerSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = info("BootupState").ToString
            Catch
                temp = ""
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return temp

    End Function

    Private Shared Function GetOSMajorVersion() As Integer

        Return Environment.OSVersion.Version.Major

    End Function

    Private Shared Function GetOSMinorVersion() As Integer

        Return Environment.OSVersion.Version.Minor

    End Function

    Private Shared Function GetOSShortVersion() As String

        Return Environment.OSVersion.Version.Major.ToString & "." & _
                Environment.OSVersion.Version.Minor.ToString

    End Function

    Private Shared Function GetOSCodename() As String
        Dim intMinorVersion As Integer
        Dim intMajorVersion As Integer

        intMajorVersion = Environment.OSVersion.Version.Major
        intMinorVersion = Environment.OSVersion.Version.Minor

        Select Case Environment.OSVersion.Platform
            Case System.PlatformID.Win32Windows

                Select Case intMinorVersion
                    Case 0

                        If mRevision = String.Empty Then
                            Return mstrChicago
                        Else
                            Return mstrDetroit
                        End If

                    Case 10
                        Return mstrMemphis
                    Case 90
                        Return mstrGeorgia
                    Case Else
                        Return mUnknown
                End Select

            Case System.PlatformID.Win32NT

                ' get information for Windows NT SP6 and above
                If intMajorVersion = 4 And intMinorVersion = 0 Then
                    ' Windows NT
                    Return mstrCairo
                ElseIf intMajorVersion = 5 And intMinorVersion = 0 Then
                    ' Windows 2000
                    Return mstrCairoNT5
                ElseIf intMajorVersion = 5 And intMinorVersion = 1 Then
                    ' Windows XP
                    Return mstrWhistler
                ElseIf intMajorVersion = 5 And intMinorVersion = 2 Then
                    ' Windows Server 2003
                    Return mstrWhistlerServer
                ElseIf intMajorVersion = 6 Then
                    ' Windows Vista
                    Return mstrLonghorn
                Else
                    Return mUnknown
                End If
            Case Else
                Return mUnknown
        End Select

    End Function

    Private Shared Function GetOSServicePack() As String

        Return Environment.OSVersion.ServicePack.ToString()

    End Function

    Private Shared Function GetOSBuild() As String

        Return Environment.OSVersion.Version.Build.ToString

    End Function

    Private Function GetOSFullName() As String

        Dim temp As String = ""

        Dim query As New SelectQuery("Win32_OperatingSystem")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get()

            Try
                temp = info("Caption").ToString
            Catch
                temp = ""
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

        Return temp

    End Function

    Private Shared Function GetOSVersion() As String

        Return Environment.OSVersion.Version.ToString

    End Function

    Private Shared Function GetOSPlatform() As System.PlatformID

        Return Environment.OSVersion.Platform

    End Function

    Private Shared Function GetOSUserName() As String

        Return Environment.UserName

    End Function

    Private Shared Function GetOSMachineName() As String

        Return Environment.MachineName

    End Function

    Private Shared Function GetOSProductId() As String

        Dim rk As RegistryKey = Nothing

        Try
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")

            Dim productID As String = rk.GetValue("ProductID", "").ToString()
            rk.Close()
            Return productID
        Catch
            If rk IsNot Nothing Then
                rk.Close()
            End If
            Return ""
        End Try

    End Function

    Private Shared Function GetOSType() As String

        Dim rk As RegistryKey = Nothing

        Try
            rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows NT\CurrentVersion")
            Dim productID As String = rk.GetValue("CurrentType").ToString()
            rk.Close()
            Return productID
        Catch
            If rk IsNot Nothing Then
                rk.Close()
            End If
            Return ""
        End Try

    End Function

    Private Shared Function GetOSIs64Bit() As Boolean

        Dim returnValue As Boolean

        ' First try to determine if the 32-bit program files environment variable exists.
        If Not String.IsNullOrEmpty(Environment.GetEnvironmentVariable("ProgramFiles(x86)")) Then
            returnValue = True
        End If

        ' If false, try this method of determing if running in 64 or 32 Bit environment.
        If returnValue = False Then
            For Each ra As Reflection.Assembly In My.Application.Info.LoadedAssemblies
                If ra.Location.ToLower.Contains("framework64") Then returnValue = True
                Exit For
            Next
        End If

        Return returnValue

    End Function

#End Region

#Region " Get OS Product Key "

    ''' <summary>
    ''' Read the value of:
    ''' HKLM\SOFTWARE\MICROSOFT\Windows NT\CurrentVersion\DigitalProductId
    ''' and decode the Windows CD Key.
    ''' </summary>
    ''' <returns>
    ''' Returns the Windows CD Key if successful.
    ''' Returns "Unknown" upon failure.
    ''' </returns>
    Private Shared Function GetOSProductKey() As String

        Try
            ' Open the Registry Key and then get the value (byte array) from the SubKey.
            Dim regKey As RegistryKey = _
                Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion", False)
            Dim digitalPid() As Byte = CType(regKey.GetValue("DigitalProductID"), Byte())

            If digitalPid IsNot Nothing Then
                ' Transfer only the needed bytes into our Key Array.
                ' Key starts at byte 52 and is 15 bytes long.
                Dim key(14) As Byte '0-14 = 15 bytes
                Array.Copy(digitalPid, 52, key, 0, 15)

                ' Our "Array" of valid CD-Key characters.
                Dim characters As String = "BCDFGHJKMPQRTVWXY2346789"

                ' Finally, our decoded CD-Key to be returned
                Dim productKey As String = ""

                ' How Microsoft encodes this to begin with, I'd love to know...
                ' but here's how we decode the byte array into a string containing the CD-KEY.
                For j As Integer = 0 To 24
                    Dim curValue As Short = 0
                    For i As Integer = 14 To 0 Step -1
                        curValue = CShort(curValue * 256 Xor key(i))
                        key(i) = CByte(Int(curValue / 24))
                        curValue = CShort(curValue Mod 24)
                    Next
                    productKey = characters.Substring(curValue, 1) & productKey
                Next

                ' Finally, insert the dashes into the string.
                For i As Integer = 4 To 1 Step -1
                    productKey = productKey.Insert(i * 5, "-")
                Next

                Return productKey
            Else
                Return mUnknown
            End If
        Catch
            Return mUnknown
        End Try

    End Function

#End Region

#Region " Get OS Up Time "

    Private Shared Function GetOSUptime() As String
        Dim intDays As Integer
        Dim intHours As Integer
        Dim intMinutes As Integer
        Dim intSeconds As Integer
        Dim intRemainder As Integer
        Dim intTicks As Integer
        Dim strDays As String
        Dim strHours As String
        Dim strMinutes As String
        Dim strSeconds As String

        ' initialize string variables
        strDays = ""
        strHours = ""
        strMinutes = ""
        strSeconds = ""

        ' updates tick counter intTicks
        intTicks = System.Environment.TickCount

        ' there are  86400000 milliseconds in one day, compute whole days and get remainder
        Do
            intDays = Int(intTicks \ 86400000)
            intRemainder = intTicks Mod 86400000
        Loop Until intRemainder <= 86400000

        ' there are 3600000 milliseconds in one hour, compute whole hours and get remainder
        Do
            intHours = Int(intRemainder \ 3600000)
            intRemainder = intRemainder Mod 3600000
        Loop Until intRemainder <= 3600000

        ' there are 60000 milliseconds in one minute, compute whole minutes and get remainder
        Do
            intMinutes = Int(intRemainder \ 60000)
            intRemainder = intRemainder Mod 60000
        Loop Until intRemainder <= 60000

        ' there are 1000 milliseconds in one second, compute whole seconds and get remainder
        Do
            intSeconds = Int(intRemainder \ 1000)
            intRemainder = intRemainder Mod 1000
        Loop Until intRemainder <= 1000

        ' format days
        If intDays = 0 Then
            strDays = ""
        ElseIf intDays.ToString.Trim.Length = 1 Then
            strDays = " " & intDays.ToString.Trim & ":"
        ElseIf intDays.ToString.Trim.Length = 2 Then
            strDays = intDays.ToString.Trim & ":"
        End If

        ' format hours
        If intHours = 0 And intDays = 0 Then
            strHours = ""
        ElseIf intHours.ToString.Trim.Length = 1 Then
            strHours = "0" & intHours.ToString.Trim & ":"
        ElseIf intHours.ToString.Trim.Length = 2 Then
            strHours = intHours.ToString.Trim & ":"
        End If

        ' format minutes
        If intMinutes = 0 Then
            strMinutes = "00" & ":"
        ElseIf intMinutes.ToString.Trim.Length = 1 Then
            strMinutes = "0" & intMinutes.ToString.Trim & ":"
        ElseIf intMinutes.ToString.Trim.Length = 2 Then
            strMinutes = intMinutes.ToString.Trim & ":"
        End If

        ' format seconds
        If intSeconds = 0 Then
            strSeconds = "00"
        ElseIf intSeconds.ToString.Trim.Length = 1 Then
            strSeconds = "0" & intSeconds.ToString.Trim
        ElseIf intSeconds.ToString.Trim.Length = 2 Then
            strSeconds = intSeconds.ToString.Trim
        End If

        ' return time string
        Return strDays & strHours & strMinutes & strSeconds

    End Function

#End Region

#Region " Get Service Information "

    Private Sub GetServiceInfo()

        Dim query As New SelectQuery("Win32_Service")
        Dim search As New ManagementObjectSearcher(query)

        For Each info In search.Get

            If info IsNot Nothing Then

                Try
                    _ServiceDisplayName.Add(info("DisplayName").ToString())
                Catch
                    _ServiceDisplayName.Add(mUnknown)
                End Try

                Try
                    _ServiceDescription.Add(info("Description").ToString())
                Catch
                    _ServiceDescription.Add(mUnknown)
                End Try

                Try
                    _ServiceStartMode.Add(info("StartMode").ToString())
                Catch
                    _ServiceStartMode.Add(mUnknown)
                End Try

                Try
                    _ServiceState.Add(info("State").ToString())
                Catch
                    _ServiceState.Add(mUnknown)
                End Try

                Try
                    _ServiceStatus.Add(info("Status").ToString())
                Catch
                    _ServiceStatus.Add(mUnknown)
                End Try

                Try
                    _ServicePathName.Add(info("PathName").ToString())
                Catch
                    _ServicePathName.Add(mUnknown)
                End Try

            End If

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

#End Region

#Region " Get Sound Controller Information "

    Private Sub GetSoundInfo()

        Dim query As New SelectQuery("Win32_SoundDevice")
        Dim search As New ManagementObjectSearcher(query)
        Dim count As Integer

        For Each info In search.Get()

            Try
                _SndController.Add(info("Name").ToString)
            Catch
                _SndController.Add(mUnknown)
            End Try

            Try
                _SndManufacturer.Add(info("Manufacturer").ToString)
            Catch
                _SndManufacturer.Add(mUnknown)
            End Try

            Try
                _SndDMABufferSize.Add(info("DMABufferSize").ToString)
            Catch
                _SndDMABufferSize.Add(mUnknown)
            End Try

            count += 1
            _SndNumberOfControllers = count

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

#End Region

#Region " Get Time Information "

    Private Shared Function GetCurrentTimeZone() As String
        If TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now.Date) = True Then
            Return TimeZone.CurrentTimeZone.DaylightName
        Else
            Return TimeZone.CurrentTimeZone.StandardName
        End If
    End Function

    Private Shared Function GetDaylightSavingsInEffect() As Boolean
        Return TimeZone.CurrentTimeZone.IsDaylightSavingTime(Now.Date)
    End Function

    Private Shared Function GetDaylightSavingsName() As String
        Return TimeZone.CurrentTimeZone.DaylightName
    End Function

    Private Shared Function GetDaylightSavingsOffset() As Integer
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(Now.Year)
        Return CInt(Daylight.Delta.TotalHours)
    End Function

    Private Shared Function GetLocalDaylightEndDate(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)
        Return Daylight.End.ToLocalTime
    End Function

    Private Shared Function GetLocalDaylightEndTime(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)
        Return Daylight.End.ToLocalTime
    End Function

    Private Shared Function GetLocalDaylightStartDate(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)

        Return Daylight.Start.ToLocalTime
    End Function

    Private Shared Function GetLocalDaylightStartTime(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)
        Return Daylight.Start.ToLocalTime
    End Function

    Private Shared Function GetLocalDateTime() As Date
        Return TimeZone.CurrentTimeZone.ToLocalTime(Now)
    End Function

    Private Shared Function GetUniversalDateTime() As Date
        Return TimeZone.CurrentTimeZone.ToUniversalTime(Now)
    End Function

    Private Shared Function GetUniversalDaylightEndDate(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)
        Return Daylight.End.ToUniversalTime
    End Function

    Private Shared Function GetUniversalDaylightEndTime(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)
        Return Daylight.End.ToUniversalTime
    End Function

    Private Shared Function GetUniversalDaylightStartDate(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)
        Return Daylight.Start.ToUniversalTime
    End Function

    Private Shared Function GetUniversalDaylightStartTime(Optional ByVal dteDate As Date = mDefaultDate) As Date
        ' Get the DaylightTime object for the current year.
        Dim Daylight As DaylightTime = TimeZone.CurrentTimeZone.GetDaylightChanges(dteDate.Year)
        Return Daylight.Start.ToUniversalTime
    End Function

    Private Shared Function GetStandardTimeName() As String
        Return TimeZone.CurrentTimeZone.StandardName
    End Function

    Private Shared Function GetUniversalTimeOffset() As Integer
        Return CInt(TimeZone.CurrentTimeZone.GetUtcOffset(Now.Date).TotalHours)
    End Function

#End Region

#Region " Get/Set User Information "

    Private Shared Function GetUserOrganization() As String

        Select Case Environment.OSVersion.Platform
            Case System.PlatformID.Win32Windows
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", False)
                Return rk.GetValue("RegisteredOrganization").ToString
                rk.Close()

            Case System.PlatformID.Win32NT
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion", False)
                Return rk.GetValue("RegisteredOrganization").ToString
                rk.Close()

            Case Else
                Return ""
        End Select

    End Function

    Private Shared Function GetUserOrganizationWow6432Node() As String

        If GetOSIs64Bit() Then
            Select Case Environment.OSVersion.Platform
                Case System.PlatformID.Win32Windows
                    ' This is 64-Bit Only.
                    Return ""

                Case System.PlatformID.Win32NT
                    Dim rk As RegistryKey

                    rk = Registry.LocalMachine.OpenSubKey("Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion", False)
                    Return rk.GetValue("RegisteredOrganization").ToString
                    rk.Close()

                Case Else
                    Return ""
            End Select
        Else
            Return ""
        End If

    End Function

    Private Shared Sub SetUserRegisteredOrganization(ByVal organization As String)

        Select Case Environment.OSVersion.Platform
            Case System.PlatformID.Win32Windows
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
                rk.SetValue("RegisteredOrganization", organization)
                rk.Close()

            Case System.PlatformID.Win32NT
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion", True)
                rk.SetValue("RegisteredOrganization", organization)
                rk.Close()

            Case Else
                ' Do nothing.
        End Select

    End Sub

    Private Shared Sub SetUserRegisteredOrganizationWow6432Node(ByVal organization As String)

        If GetOSIs64Bit() Then
            Select Case Environment.OSVersion.Platform
                Case System.PlatformID.Win32Windows
                    ' 64-Bit Only - Do Nothing
                Case System.PlatformID.Win32NT
                    Dim rk As RegistryKey

                    rk = Registry.LocalMachine.OpenSubKey("Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion", True)
                    rk.SetValue("RegisteredOrganization", organization)
                    rk.Close()

                Case Else
                    ' Do nothing.
            End Select
        End If

    End Sub

    Private Shared Function GetUserRegisteredName() As String

        Select Case Environment.OSVersion.Platform
            Case System.PlatformID.Win32Windows
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", False)
                Return rk.GetValue("RegisteredOwner").ToString
                rk.Close()

            Case System.PlatformID.Win32NT
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion", False)
                Return rk.GetValue("RegisteredOwner").ToString
                rk.Close()

            Case Else
                Return ""
        End Select

    End Function

    Private Shared Function GetUserRegisteredNameWow6432Node() As String

        If GetOSIs64Bit() Then
            Select Case Environment.OSVersion.Platform
                Case System.PlatformID.Win32Windows
                    ' 64-Bit Only.
                    Return ""
                Case System.PlatformID.Win32NT
                    Dim rk As RegistryKey

                    rk = Registry.LocalMachine.OpenSubKey("Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion", False)
                    Return rk.GetValue("RegisteredOwner").ToString
                    rk.Close()

                Case Else
                    Return ""
            End Select
        Else
            Return ""
        End If

    End Function

    Private Shared Sub SetUserRegisteredName(ByVal user As String)

        Select Case Environment.OSVersion.Platform
            Case System.PlatformID.Win32Windows
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows\CurrentVersion", True)
                rk.SetValue("RegisteredOwner", user)
                rk.Close()

            Case System.PlatformID.Win32NT
                Dim rk As RegistryKey

                rk = Registry.LocalMachine.OpenSubKey("Software\Microsoft\Windows NT\CurrentVersion", True)
                rk.SetValue("RegisteredOwner", user)
                rk.Close()

            Case Else
                ' Do nothing.
        End Select

    End Sub

    Private Shared Sub SetUserRegisteredNameWow6432Node(ByVal user As String)

        If GetOSIs64Bit() Then
            Select Case Environment.OSVersion.Platform
                Case System.PlatformID.Win32Windows
                    ' 64-bit only do nothing.
                Case System.PlatformID.Win32NT
                    Dim rk As RegistryKey

                    rk = Registry.LocalMachine.OpenSubKey("Software\Wow6432Node\Microsoft\Windows NT\CurrentVersion", True)
                    rk.SetValue("RegisteredOwner", user)
                    rk.Close()

                Case Else
                    ' Do nothing.
            End Select
        End If

    End Sub

    Private Shared Function GetUserIsAdministrator() As Boolean

        Dim wp As New WindowsPrincipal(WindowsIdentity.GetCurrent())
        Return wp.IsInRole(WindowsBuiltInRole.Administrator)

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Private Shared Function GetUserFullNames() As Collection(Of String)
        Dim users As New Collection(Of String)
        Dim fullNames As New Collection(Of String)
        Dim user As String

        ' Get list of users.
        users = NativeMethods.EnumerateUsers

        ' Get full names
        For Each user In users
            fullNames.Add(NativeMethods.GetUserFullName(user))
        Next

        Return fullNames

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Private Shared Function GetUserPrivileges() As Collection(Of String)
        Dim users As New Collection(Of String)
        Dim privileges As New Collection(Of String)
        Dim user As String

        ' Get list of users.
        users = NativeMethods.EnumerateUsers

        ' Get full names
        For Each user In users
            privileges.Add(NativeMethods.GetUserPrivilege(user))
        Next

        Return privileges

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Private Shared Function GetUserFlags() As Collection(Of Integer)
        Dim users As New Collection(Of String)
        Dim flags As New Collection(Of Integer)
        Dim user As String

        ' Get list of users.
        users = NativeMethods.EnumerateUsers

        ' Get flags.
        For Each user In users
            flags.Add(NativeMethods.GetUserBits(user))
        Next

        Return flags

    End Function

#End Region

#Region " Get Video Information "

    Private Sub GetVideoInfo()
        Dim query As New SelectQuery("Win32_VideoController")
        Dim search As New ManagementObjectSearcher(query)
        Dim count As Integer

        For Each info In search.Get()

            Try

                Try
                    _VidController.Add(info("Name").ToString)
                Catch
                    _VidController.Add(mUnknown)
                End Try

                Try
                    If CType(info("AdapterRAM"), Integer) = 0 Then
                        _VidRam.Add(mUnknown)
                    Else
                        _VidRam.Add(FormatBytes(CDbl(info("AdapterRAM"))))
                    End If
                Catch
                    _VidRam.Add(mUnknown)
                End Try

                Try
                    If CType(info("CurrentRefreshRate"), UInt32) = 0 Then
                        _VidRefreshRate.Add("Default")
                    ElseIf CType(info("CurrentRefreshRate"), UInt32) = &HFFFFFFFF Then
                        _VidRefreshRate.Add("Optimal")
                    Else
                        _VidRefreshRate.Add(info("CurrentRefreshRate").ToString & " Hz")
                    End If
                Catch
                    _VidRefreshRate.Add(mUnknown)
                End Try

                Try
                    _VidScreenColors.Add(ReturnColors(CType(info("CurrentBitsPerPixel"), Int32)))
                Catch
                    _VidScreenColors.Add(mUnknown)
                End Try

                count += 1
                _VidNumberOfControllers = count

            Catch
                _VidNumberOfControllers = 0
            End Try

        Next

        If search IsNot Nothing Then search.Dispose()

    End Sub

    Private Shared Function GetVidPrimaryScreenDimensions() As String

        Return Screen.PrimaryScreen.Bounds.Width.ToString & " x " & _
            Screen.PrimaryScreen.Bounds.Height.ToString

    End Function

    Private Shared Function GetVidPrimaryScreenWorkingArea() As String

        Return Screen.PrimaryScreen.WorkingArea.Width.ToString & " x " & _
            Screen.PrimaryScreen.WorkingArea.Height.ToString

    End Function

    Private Shared Function GetVidSecondaryScreenDimensions() As String

        If Screen.AllScreens.Count > 1 Then
            Return Screen.AllScreens(1).Bounds.Width.ToString & " x " & _
                Screen.AllScreens(1).Bounds.Height.ToString
        Else
            Return ""
        End If

    End Function

    Private Shared Function GetVidSecondaryScreenWorkingArea() As String

        If Screen.AllScreens.Count > 1 Then
            Return Screen.AllScreens(1).WorkingArea.Width.ToString & " x " & _
                Screen.AllScreens(1).WorkingArea.Height.ToString
        Else
            Return ""
        End If

    End Function

    Private Shared Function GetVidTertiaryScreenDimensions() As String

        If Screen.AllScreens.Count > 2 Then
            Return Screen.AllScreens(2).Bounds.Width.ToString & " x " & _
                Screen.AllScreens(2).Bounds.Height.ToString
        Else
            Return ""
        End If

    End Function

    Private Shared Function GetVidTertiaryScreenWorkingArea() As String

        If Screen.AllScreens.Count > 2 Then
            Return Screen.AllScreens(2).WorkingArea.Width.ToString & " x " & _
                Screen.AllScreens(2).WorkingArea.Height.ToString
        Else
            Return ""
        End If

    End Function

    Private Shared Function GetVidQuaternaryScreenDimensions() As String

        If Screen.AllScreens.Count > 3 Then
            Return Screen.AllScreens(3).Bounds.Width.ToString & " x " & _
                Screen.AllScreens(3).Bounds.Height.ToString
        Else
            Return ""
        End If

    End Function

    Private Shared Function GetVidQuaternaryScreenWorkingArea() As String

        If Screen.AllScreens.Count > 3 Then
            Return Screen.AllScreens(3).WorkingArea.Width.ToString & " x " & _
                Screen.AllScreens(3).WorkingArea.Height.ToString
        Else
            Return ""
        End If

    End Function

#End Region

#Region " Get Visual Style Information "

    Private Shared Function GetVstAuthor() As String

        Return VisualStyleInformation.Author

    End Function

    Private Shared Function GetVstColorScheme() As String

        Return VisualStyleInformation.ColorScheme

    End Function

    Private Shared Function GetVstCompany() As String

        Return VisualStyleInformation.Company

    End Function

    Private Shared Function GetVstControlHighlightHot() As Drawing.Color

        Return VisualStyleInformation.ControlHighlightHot

    End Function

    Private Shared Function GetVstCopyright() As String

        Return VisualStyleInformation.Copyright

    End Function

    Private Shared Function GetVstDescription() As String

        Return VisualStyleInformation.Description

    End Function

    Private Shared Function GetVstDisplayName() As String

        Return VisualStyleInformation.DisplayName

    End Function

    Private Shared Function GetVstIsEnabledByUser() As Boolean

        Return VisualStyleInformation.IsEnabledByUser

    End Function

    Private Shared Function GetVstIsSupportedByOS() As Boolean

        Return VisualStyleInformation.IsSupportedByOS

    End Function

    Private Shared Function GetVstMinimumColorDepth() As Integer

        Return VisualStyleInformation.MinimumColorDepth

    End Function

    Private Shared Function GetVstSize() As String

        Return VisualStyleInformation.Size

    End Function

    Private Shared Function GetVstSupportsFlatMenus() As Boolean

        Return VisualStyleInformation.SupportsFlatMenus

    End Function

    Private Shared Function GetVstTextControlBorder() As Drawing.Color

        Return VisualStyleInformation.TextControlBorder

    End Function

    Private Shared Function GetVstUrl() As String

        Return VisualStyleInformation.Url

    End Function

    Private Shared Function GetVstVersion() As String

        Return VisualStyleInformation.Version

    End Function

#End Region

#Region " Get Volume Information "

    Private Sub GetVolumeInfo()

        Dim allDrives() As DriveInfo = DriveInfo.GetDrives()
        Dim d As DriveInfo
        Const unknown As String = ""

        For Each d In allDrives

            _VolumeLetter.Add(d.RootDirectory.ToString)

            _VolumeType.Add(d.DriveType.ToString)

            If d.IsReady = True Then
                _VolumeFileSystem.Add(d.DriveFormat)
            Else
                _VolumeFileSystem.Add(unknown)
            End If

            _VolumeReady.Add(d.IsReady)

            If d.IsReady = True Then
                _VolumeLabel.Add(d.VolumeLabel)
            Else
                _VolumeLabel.Add(unknown)
            End If

            If d.IsReady = True Then
                _VolumeTotalSize.Add(FormatBytes(CDbl(d.TotalSize)))
            Else
                _VolumeTotalSize.Add(unknown)
            End If

            If d.IsReady = True Then
                _VolumeFreeSpace.Add(FormatBytes(CDbl(d.TotalFreeSpace)))
            Else
                _VolumeFreeSpace.Add(unknown)
            End If

            If d.IsReady = True Then
                _VolumeUsedSpace.Add(FormatBytes(CDbl(d.TotalSize - d.TotalFreeSpace)))
            Else
                _VolumeUsedSpace.Add("")
            End If

            If d.IsReady = True Then
                _VolumePercentFreeSpace.Add( _
                    String.Format("{0:N1}", (CDbl(d.TotalFreeSpace) / CDbl(d.TotalSize) * 100.0)) & "%")
            Else
                _VolumePercentFreeSpace.Add("0%")
            End If

            If d.IsReady = True Then
                _VolumeSerialNumber.Add(NativeMethods.GetVolumeSerialNumber(d.RootDirectory.ToString()))
            Else
                _VolumeSerialNumber.Add(unknown)
            End If

        Next

    End Sub

#End Region

#End Region

#Region " Public Methods "

#Region " Get Week Number "

    ''' <summary>
    ''' Description:this function will accept any date as the only parameter and will 
    ''' return you the week number the supplied date lies into.
    ''' </summary>>
    ''' <param name="inDate">Date for which the week number is desired.</param>
    ''' <returns>
    ''' Return the week number as an integer.
    ''' </returns>
    Public Shared Function GetWeekNumber(ByVal inDate As Date) As Integer

        Dim dayOfYear As Integer
        Dim weekNumber As Integer
        Dim compensation As Integer = 0
        Dim firstDayDate As Date

        Try

            dayOfYear = inDate.DayOfYear
            firstDayDate = New DateTime(inDate.Year, inDate.Month, 1)

            Select Case firstDayDate.DayOfWeek
                Case DayOfWeek.Sunday
                    compensation = 0
                Case DayOfWeek.Monday
                    compensation = 6
                Case DayOfWeek.Tuesday
                    compensation = 5
                Case DayOfWeek.Wednesday
                    compensation = 4
                Case DayOfWeek.Thursday
                    compensation = 3
                Case DayOfWeek.Friday
                    compensation = 2
                Case DayOfWeek.Saturday
                    compensation = 1
            End Select

            dayOfYear = dayOfYear - compensation

            If dayOfYear Mod 7 = 0 Then
                weekNumber = CInt(dayOfYear / 7)
            Else
                weekNumber = (dayOfYear \ 7) + 1
            End If
        Catch
            weekNumber = 0  ' Trap errors by returning a zero.
        End Try

        Return weekNumber

    End Function

#End Region

#End Region

#Region " Public Properties "

#Region " Application Public Properties "

    ''' <summary>
    ''' Application Build
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Build")> _
    Public ReadOnly Property AppBuild() As String
        Get
            _AppBuild = GetAppBuild()
            Return _AppBuild
        End Get
    End Property

    ''' <summary>
    ''' Application Company (Manufacturer)
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Company (Manufacturer)")> _
    Public ReadOnly Property AppCompanyName() As String
        Get
            _AppCompanyName = GetAppCompanyName()
            Return _AppCompanyName
        End Get
    End Property

    ''' <summary>
    ''' Application Copyright
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Copyright")> _
    Public ReadOnly Property AppCopyright() As String
        Get
            _AppCopyright = GetAppCopyright()
            Return _AppCopyright
        End Get
    End Property

    ''' <summary>
    ''' Application Copyright
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Copyright")> _
    Public ReadOnly Property AppDescription() As String
        Get
            _AppDescription = GetAppDescription()
            Return _AppDescription
        End Get
    End Property

    ''' <summary>
    ''' Application Major Revision
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Major Revision")> _
    Public ReadOnly Property AppMajorRevision() As Integer
        Get
            _AppMajorRevision = GetAppMajorRevision()
            Return _AppMajorRevision
        End Get
    End Property

    ''' <summary>
    ''' Application Major Version
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Major Version")> _
    Public ReadOnly Property AppMajorVersion() As Integer
        Get
            _AppMajorVersion = GetAppMajorVersion()
            Return _AppMajorVersion
        End Get
    End Property

    ''' <summary>
    ''' Application Minor Revision
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Minor Revision")> _
    Public ReadOnly Property AppMinorRevision() As Integer
        Get
            _AppMinorRevision = GetAppMinorRevision()
            Return _AppMinorRevision
        End Get
    End Property

    ''' <summary>
    ''' Application Minor Version
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Minor Version")> _
    Public ReadOnly Property AppMinorVersion() As Integer
        Get
            _AppMinorVersion = GetAppMinorVersion()
            Return _AppMinorVersion
        End Get
    End Property

    ''' <summary>
    ''' Application Product Name
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Product Name")> _
    Public ReadOnly Property AppProductName() As String
        Get
            _AppProductName = GetAppProductName()
            Return _AppProductName
        End Get

    End Property

    ''' <summary>
    ''' Application Revision
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Revision")> _
    Public ReadOnly Property AppRevision() As String
        Get
            _AppRevision = GetAppRevision()
            Return _AppRevision
        End Get
    End Property

    ''' <summary>
    ''' Application Major and Minor Version Separated by a Decimal
    ''' </summary>
    <Browsable(True), Category("Application"), _
        Description("Application Major and Minor Version Separated by a Decimal")> _
    Public ReadOnly Property AppShortVersion() As String
        Get
            _AppShortVersion = GetAppShortVersion()
            Return _AppShortVersion
        End Get
    End Property

    ''' <summary>
    ''' Application Title
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Title")> _
    Public ReadOnly Property AppTitle() As String
        Get
            _AppTitle = GetAppTitle()
            Return _AppTitle
        End Get
    End Property

    ''' <summary>
    ''' Application Trademark
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Trademark")> _
    Public ReadOnly Property AppTrademark() As String
        Get
            _AppTrademark = GetAppTrademark()
            Return _AppTrademark
        End Get
    End Property

    ''' <summary>
    ''' Application Version
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Version")> _
    Public ReadOnly Property AppVersion() As String
        Get
            _AppVersion = GetAppVersion()
            Return _AppVersion
        End Get
    End Property

    ''' <summary>
    ''' Application Version
    ''' </summary>
    <Browsable(True), Category("Application"), Description("Application Directory")> _
    Public ReadOnly Property AppDirectory() As String
        Get
            _AppDirectory = GetAppDirectory()
            Return _AppDirectory
        End Get
    End Property

#End Region

#Region " BIOS Public Properties "

    ''' <summary>
    ''' BIOS Manufacturer
    ''' </summary>
    <Browsable(True), Category("BIOS"), Description("BIOS Manufacturer")> _
    Public ReadOnly Property BiosManufacturer() As String
        Get
            Return _BiosManufacturer
        End Get
    End Property

    ''' <summary>
    ''' BIOS Name
    ''' </summary>
    <Browsable(True), Category("BIOS"), Description("BIOS Name")> _
    Public ReadOnly Property BiosName() As String
        Get
            Return _BiosName
        End Get
    End Property

    ''' <summary>
    ''' BIOS Version
    ''' </summary>
    <Browsable(True), Category("BIOS"), Description("BIOS Version")> _
    Public ReadOnly Property BiosVersion() As String
        Get
            Return _BiosVersion
        End Get
    End Property

    ''' <summary>
    ''' BIOS Release Date
    ''' </summary>
    <Browsable(True), Category("BIOS"), Description("BIOS Release Date")> _
    Public ReadOnly Property BiosReleaseDate() As String
        Get
            Return _BiosReleaseDate
        End Get
    End Property

    ''' <summary>
    ''' BIOS Features
    ''' </summary>
    <Browsable(True), Category("BIOS"), Description("BIOS Features")> _
    Public ReadOnly Property BiosFeatures() As Collection(Of String)
        Get
            Return _BiosFeatures
        End Get
    End Property

    ''' <summary>
    ''' SMBIOS Present
    ''' </summary>
    <Browsable(True), Category("BIOS"), Description("SMBIOS Present")> _
    Public ReadOnly Property BiosSMBiosPresent() As Boolean
        Get
            Return _BiosSmBiosPresent
        End Get
    End Property

    ''' <summary>
    ''' SMBIOS Version
    ''' </summary>
    <Browsable(True), Category("BIOS"), Description("SMBIOS Version")> _
    Public ReadOnly Property BiosSMBiosVersion() As String
        Get
            Return _BiosSmBiosVersion
        End Get
    End Property

#End Region

#Region " CD Drive Public Properties "

    ''' <summary>
    ''' CD Drive
    ''' </summary>
    <Browsable(True), Category("CD Drive"), Description("CD Drive")> _
    Public ReadOnly Property CDDrive() As Collection(Of String)
        Get
            _CDDrive = GetCDDrive()
            Return _CDDrive
        End Get
    End Property

    ''' <summary>
    ''' CD Drive Manufacturer
    ''' </summary>
    <Browsable(True), Category("CD Drive"), Description("CD Drive Manufacturer")> _
    Public ReadOnly Property CDManufacturer() As Collection(Of String)
        Get
            _CDManufacturer = GetCDManufacturer()
            Return _CDManufacturer
        End Get
    End Property

    ''' <summary>
    ''' CD Drive Model
    ''' </summary>
    <Browsable(True), Category("CD Drive"), Description("CD Drive Model")> _
    Public ReadOnly Property CDModel() As Collection(Of String)
        Get
            _CDModel = GetCDModel()
            Return _CDModel
        End Get
    End Property

    ''' <summary>
    ''' CD Drive Media Size
    ''' </summary>
    <Browsable(True), Category("CD Drive"), Description("CD Drive Media Size")> _
    Public ReadOnly Property CDMediaSize() As Collection(Of String)
        Get
            _CDMediaSize = GetCDMediaSize()
            Return _CDMediaSize
        End Get
    End Property

    ''' <summary>
    ''' CD Drive Revision Level
    ''' </summary>
    <Browsable(True), Category("CD Drive"), Description("CD Drive Revision Level")> _
    Public ReadOnly Property CDRevisionLevel() As Collection(Of String)
        Get
            _CDRevisionLevel = GetCDRevisionLevel()
            Return _CDRevisionLevel
        End Get
    End Property

    ''' <summary>
    ''' CD Drive Status
    ''' </summary>
    <Browsable(True), Category("CD Drive"), Description("CD Drive Status")> _
    Public ReadOnly Property CDStatus() As Collection(Of String)
        Get
            _CDStatus = GetCDStatus()
            Return _CDStatus
        End Get
    End Property

#End Region

#Region " Computer Public Properties "

    ''' <summary>
    ''' Computer Has Automatic Reset Capability
    ''' </summary>
    <Browsable(True), Category("Computer"), Description("Computer Has Automatic Reset Capability")> _
    Public ReadOnly Property CompAutomaticResetCapability() As Boolean
        Get
            _CompAutomaticResetCapability = GetCompAutomaticResetCapability()
            Return _CompAutomaticResetCapability
        End Get
    End Property

    ''' <summary>
    ''' Computer Description
    ''' </summary>
    <Browsable(True), Category("Computer"), Description("Computer Description")> _
    Public ReadOnly Property CompDescription() As String
        Get
            _CompDescription = GetCompDescription()
            Return _CompDescription
        End Get
    End Property

    ''' <summary>
    ''' Computer Manufacturer
    ''' </summary>
    <Browsable(True), Category("Computer"), Description("Computer Manufacturer")> _
    Public ReadOnly Property CompManufacturer() As String
        Get
            _CompManufacturer = GetCompManufacturer()
            Return _CompManufacturer
        End Get
    End Property

    ''' <summary>
    ''' Computer Model
    ''' </summary>
    <Browsable(True), Category("Computer"), Description("Computer Model")> _
    Public ReadOnly Property CompModel() As String
        Get
            _CompModel = GetCompModel()
            Return _CompModel
        End Get
    End Property

    ''' <summary>
    ''' Computer System Type
    ''' </summary>
    <Browsable(True), Category("Computer"), Description("Computer System Type")> _
    Public ReadOnly Property CompSystemType() As String
        Get
            _CompSystemType = GetCompSystemType()
            Return _CompSystemType
        End Get
    End Property

#End Region

#Region " CPU Public Properties "

    ''' <summary>
    ''' Number of Processors
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("Number of Processors")> _
    Public ReadOnly Property CpuNumberOfProcessors() As Integer
        Get
            _CpuNumberOfProcessors = GetCpuNumberOfProcessors()
            Return _CpuNumberOfProcessors
        End Get
    End Property

    ''' <summary>
    ''' Number of Cores
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("Number of Cores")> _
    Public ReadOnly Property CpuNumberOfCores() As Integer
        Get
            _CpuNumberOfCores = GetCpuNumberOfCores()
            Return _CpuNumberOfCores
        End Get
    End Property

    ''' <summary>
    ''' Number of Logical Processors
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("Number of Logical Processors")> _
    Public ReadOnly Property CpuNumberOfLogicalProcessors() As Integer
        Get
            _CpuNumberOfLogicalProcessors = GetCpuNumberOfLogicalProcessors()
            Return _CpuNumberOfLogicalProcessors
        End Get
    End Property


    ''' <summary>
    ''' CPU Address Width
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Address Width")> _
    Public ReadOnly Property CpuAddressWidth() As String
        Get
            Return _CpuAddressWidth
        End Get
    End Property

    ''' <summary>
    ''' CPU Description
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Description")> _
    Public ReadOnly Property CpuDescription() As String
        Get
            Return _CpuDescription
        End Get
    End Property

    ''' <summary>
    ''' CPU Front Side Bus (FSB) Speed
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Front Side Bus (FSB) Speed")> _
    Public ReadOnly Property CpuFrontSideBusSpeed() As String
        Get
            Return _CpuFsbSpeed
        End Get
    End Property

    ''' <summary>
    ''' CPU Level 2 Cache Size
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Level 2 Cache Size")> _
    Public ReadOnly Property CpuL2CacheSize() As String
        Get
            Return _CpuL2CacheSize
        End Get
    End Property

    ''' <summary>
    ''' CPU Level 2 Cache Speed
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Level 2 Cache Speed")> _
    Public ReadOnly Property CpuL2CacheSpeed() As String
        Get
            Return _CpuL2CacheSpeed
        End Get
    End Property

    ''' <summary>
    ''' CPU Load Percentage
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Load Percentage")> _
    Public ReadOnly Property CpuLoadPercentage() As Collection(Of Integer)
        Get
            _CpuLoadPercentage = GetCpuLoadPercentage()
            Return _CpuLoadPercentage
        End Get
    End Property

    ''' <summary>
    ''' CPU Manufacturer
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Manufacturer")> _
    Public ReadOnly Property CpuManufacturer() As String
        Get
            Return _CpuManufacturer
        End Get
    End Property

    ''' <summary>
    ''' CPU Name
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Name")> _
    Public ReadOnly Property CpuName() As String
        Get
            Return _CpuName
        End Get
    End Property

    ''' <summary>
    ''' CPU Socket
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Socket")> _
    Public ReadOnly Property CpuSocket() As String
        Get
            Return _CpuSocket
        End Get
    End Property

    ''' <summary>
    ''' CPU Speed
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Speed")> _
    Public ReadOnly Property CpuSpeed() As String
        Get
            Return _CpuSpeed
        End Get
    End Property

    ''' <summary>
    ''' CPU Power Management Supported
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Power Management Supported")> _
    Public ReadOnly Property CpuPowerManagementSupported() As Boolean
        Get
            Return _CpuPowerManagementSupported
        End Get
    End Property

    ''' <summary>
    ''' CPU Power Management Capabilities
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Power Management Capabilities")> _
    Public ReadOnly Property CpuPowerManagementCapabilities() As String
        Get
            Return _CpuPowerManagementCapabilities
        End Get
    End Property

    ''' <summary>
    ''' CPU Processor ID
    ''' </summary>
    <Browsable(True), Category("CPU"), Description("CPU Processor ID")> _
    Public ReadOnly Property CpuProcessorId() As String
        Get
            Return _CpuProcessorId
        End Get
    End Property

#End Region

#Region " Drive Public Properties "

    ''' <summary>
    ''' Drive Capacity
    ''' </summary>
    <Browsable(True), Category("Drive"), Description("Drive Capacity")> _
    Public ReadOnly Property DriveCapacity() As Collection(Of String)
        Get
            Return _DriveCapacity
        End Get
    End Property

    ''' <summary>
    ''' Drive Interface
    ''' </summary>
    <Browsable(True), Category("Drive"), Description("Drive Interface")> _
    Public ReadOnly Property DriveInterface() As Collection(Of String)
        Get
            Return _DriveInterface
        End Get
    End Property

    ''' <summary>
    ''' Drive Model Number
    ''' </summary>
    <Browsable(True), Category("Drive"), Description("Drive Model Number")> _
    Public ReadOnly Property DriveModelNo() As Collection(Of String)
        Get
            Return _DriveModelNo
        End Get
    End Property


    <Browsable(True), Category("Drive"), Description("Drive Status")> _
    Public ReadOnly Property DriveStatus() As Collection(Of String)
        Get
            Return _DriveStatus
        End Get
    End Property

#End Region

#Region " Mainboard Public Properties "

    ''' <summary>
    ''' Mainboard (or Chipset) Manufacturer
    ''' </summary>
    <Browsable(True), Category("Mainboard"), Description("Mainboard (or Chipset) Manufacturer")> _
    Public ReadOnly Property MainBoardManufacturer() As String
        Get
            _MainBoardManufacturer = GetMainBoardManufacturer()
            Return _MainBoardManufacturer
        End Get
    End Property

    ''' <summary>
    ''' Mainboard (or Chipset) Model
    ''' </summary>
    <Browsable(True), Category("Mainboard"), Description("Mainboard (or Chipset) Model")> _
    Public ReadOnly Property MainBoardModel() As String
        Get
            _MainBoardModel = GetMainBoardModel()
            Return _MainBoardModel
        End Get
    End Property

#End Region

#Region " Memory Public Properties "

    ''' <summary>
    ''' Available Virtual Memory
    ''' </summary>
    <Browsable(True), Category("Memory"), Description("Available Virtual Memory")> _
    Public ReadOnly Property MemoryAvailVirtual() As String
        Get
            _MemAvailVirtual = NativeMethods.GetMemoryAvailVirtual()
            Return _MemAvailVirtual
        End Get
    End Property

    ''' <summary>
    ''' Available Physical Memory
    ''' </summary>
    <Browsable(True), Category("Memory"), Description("Available Physical Memory")> _
    Public ReadOnly Property MemoryAvailPhysical() As String
        Get
            _MemAvailPhysical = NativeMethods.GetMemoryAvailPhysical()
            Return _MemAvailPhysical
        End Get
    End Property

    ''' <summary>
    ''' Total Virtual Memory
    ''' </summary>
    <Browsable(True), Category("Memory"), Description("Total Virtual Memory")> _
    Public ReadOnly Property MemoryTotalVirtual() As String
        Get
            _MemTotalVirtual = NativeMethods.GetMemoryTotalVirtual()
            Return _MemTotalVirtual
        End Get
    End Property

    ''' <summary>
    ''' Total Physical Memory
    ''' </summary>
    <Browsable(True), Category("Memory"), Description("Total Physical Memory")> _
    Public ReadOnly Property MemoryTotalPhysical() As String
        Get
            _MemTotalPhysical = NativeMethods.GetMemoryTotalPhysical()
            Return _MemTotalPhysical
        End Get
    End Property

#End Region

#Region " CLR and .NET Framework Public Properties "

    ''' <summary>
    ''' CLR Version
    ''' </summary>
    <Browsable(True), Category(".NET Framework"), Description("CLR Version")> _
    Public ReadOnly Property ClrVersion() As String
        Get
            _CLRVersion = GetClrVersion()
            Return _CLRVersion
        End Get
    End Property

    ''' <summary>
    ''' CLR Major Version
    ''' </summary>
    <Browsable(True), Category(".NET Framework"), Description("CLR Major Version")> _
    Public ReadOnly Property ClrMajorVersion() As Integer
        Get
            _CLRMajorVersion = GetClrMajorVersion()
            Return _CLRMajorVersion
        End Get
    End Property

    ''' <summary>
    ''' .NET Framwork Minor Version
    ''' </summary>
    <Browsable(True), Category(".NET Framework"), Description(".NET Framwork Minor Version")> _
    Public ReadOnly Property FrameworkMinorVersion() As Integer
        Get
            _CLRMinorVersion = GetClrMinorVersion()
            Return _CLRMinorVersion
        End Get
    End Property

    ''' <summary>
    ''' CLR Service Pack
    ''' </summary>
    <Browsable(True), Category(".NET Framework"), Description("CLR Service Pack")> _
    Public ReadOnly Property ClrServicePack() As String
        Get
            _CLRServicePack = GetClrServicePack()
            Return _CLRServicePack
        End Get
    End Property

    ''' <summary>
    ''' CLR Major and Minor Version Separated by a Decimal
    ''' </summary>
    <Browsable(True), Category(".NET Framework"), _
        Description("CLR Major and Minor Version Separated by a Decimal")> _
    Public ReadOnly Property ClrShortVersion() As String
        Get
            _CLRShortVersion = GetClrShortVersion()
            Return _CLRShortVersion
        End Get
    End Property

    ''' <summary>
    ''' .NET Framework Major and Minor Version Separated by a Decimal
    ''' </summary>
    <Browsable(True), Category(".NET Framework"), _
        Description(".NET Framework Major and Minor Version Separated by a Decimal")> _
    Public ReadOnly Property NetFrameworkVersion() As String
        Get
            _NetFrameworkVersion = GetFrameworkVersion()
            Return _NetFrameworkVersion
        End Get
    End Property

#End Region

#Region " Network Public Properties "

    ''' <summary>
    ''' Network Interface Type
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Type")> _
    Public ReadOnly Property NetAdapterType() As Collection(Of String)
        Get
            Return _NetAdapterType
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Auto Sense Capability
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Auto Sense Capability")> _
    Public ReadOnly Property NetAutoSense() As Collection(Of String)
        Get
            Return _NetAutoSense
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Media Access Control (MAC) Address
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Network Interface Media Access Control (MAC) Address")> _
    Public ReadOnly Property NetMacAddress() As Collection(Of String)
        Get
            Return _NetMacAddress
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Manufacturer
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Manufacturer")> _
    Public ReadOnly Property NetManufacturer() As Collection(Of String)
        Get
            Return _NetManufacturer
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Maximum Speed
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Maximum Speed")> _
    Public ReadOnly Property NetMaxSpeed() As Collection(Of String)
        Get
            Return _NetMaxSpeed
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Connection ID
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Connection ID")> _
    Public ReadOnly Property NetConnectionId() As Collection(Of String)
        Get
            Return _NetConnectionId
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Connection Status
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Connection Status")> _
    Public ReadOnly Property NetConnectionStatus() As Collection(Of String)
        Get
            Return _NetConnectionStatus
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Internet Protocol (IP) Enabled Status
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Network Interface Internet Protocol (IP) Enabled Status")> _
    Public ReadOnly Property NetIPEnabled() As Collection(Of Boolean)
        Get
            Return _NetIPEnabled
        End Get
    End Property

    ''' <summary>
    ''' Number of Network Interfaces
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Number of Network Interfaces")> _
    Public ReadOnly Property NetNumberOfAdapters() As Integer
        Get
            Return _NetNumberOfAdaptors
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Product Name
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Product Name")> _
    Public ReadOnly Property NetProductName() As Collection(Of String)
        Get
            Return _NetProductName
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Speed
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Speed")> _
    Public ReadOnly Property NetSpeed() As Collection(Of String)
        Get
            Return _NetSpeed
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Default Time-To-Live (TTL)
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Default Time-To-Live (TTL)")> _
    Public ReadOnly Property NetDefaultTimeToLive() As Collection(Of String)
        Get
            Return _NetDefaultTtl
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Dynamic Host Configuration Protocol (DHCP) Enabled Status
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Network Interface Dynamic Host Configuration Protocol (DHCP) Enabled Status")> _
    Public ReadOnly Property NetDhcpEnabled() As Collection(Of Boolean)
        Get
            Return _NetDhcpEnabled
        End Get
    End Property

    ''' <summary>
    ''' Date Network Interface Dynamic Host Configuration Protocol (DHCP) Lease Obtained
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Date Network Interface Dynamic Host Configuration Protocol (DHCP) Lease Obtained")> _
    Public ReadOnly Property NetDhcpLeaseObtained() As Collection(Of String)
        Get
            Return _NetDhcpLeaseObtained
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Date Network Interface Dynamic Host Configuration Protocol (DHCP) Lease Expires
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Date Network Interface Dynamic Host Configuration Protocol (DHCP) Lease Expires")> _
    Public ReadOnly Property NetDhcpLeaseExpires() As Collection(Of String)
        Get
            Return _NetDhcpLeaseExpires
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Date Network Interface Dynamic Host Configuration Protocol (DHCP) Server
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Date Network Interface Dynamic Host Configuration Protocol (DHCP) Server")> _
    Public ReadOnly Property NetDhcpServer() As Collection(Of String)
        Get
            Return _NetDhcpServer
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Maximum Transmission Unit (MTU)
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Maximum Transmission Unit (MTU)")> _
    Public ReadOnly Property NetMaximumTransmissionUnit() As Collection(Of String)
        Get
            Return _NetMtu
        End Get
    End Property

    ''' <summary>
    ''' Number of Network Interface Transmission Control Protocol (TCP) Connections
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Number of Network Interface Transmission Control Protocol (TCP) Connections")> _
    Public ReadOnly Property NetTcpNumberConnections() As Collection(Of String)
        Get
            Return _NetTcpNumConnections
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Transmission Control Protocol (TCP) Window Size
    ''' </summary>
    <Browsable(True), Category("Network"), _
        Description("Network Interface Transmission Control Protocol (TCP) Window Size")> _
    Public ReadOnly Property NetTcpWindowSize() As Collection(Of String)
        Get
            Return _NetTcpWindowSize
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Internet Protocol (IP) Address
    ''' </summary>
    ''' <remarks>
    ''' Modified to show all IP addresses including IPv6.
    ''' </remarks>
    <Browsable(True), Category("Network"), Description("Network Interface Internet Protocol (IP) Address")> _
    Public ReadOnly Property NetIPAddress() As Collection(Of String())
        Get
            Return _NetIPAddress
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Network Domain
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Network Domain")> _
    Public ReadOnly Property NetDomain() As Collection(Of String)
        Get
            Return _NetDomain
        End Get
    End Property

    ''' <summary>
    ''' Network Interface Network Host Name
    ''' </summary>
    <Browsable(True), Category("Network"), Description("Network Interface Network Host Name")> _
    Public ReadOnly Property NetHostName() As Collection(Of String)
        Get
            Return _NetHostName
        End Get
    End Property

#End Region

#Region " Operating System Public Properties "

    ''' <summary>
    ''' Operating System Code Name
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Code Name")> _
    Public ReadOnly Property OSCodename() As String
        Get
            _OSCodename = GetOSCodename()
            Return _OSCodename
        End Get
    End Property

    ''' <summary>
    ''' Build
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Build")> _
    Public ReadOnly Property OSBuild() As String
        Get
            _OSBuild = GetOSBuild()
            Return _OSBuild
        End Get
    End Property

    ''' <summary>
    ''' Machine Name
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Machine Name")> _
    Public ReadOnly Property OSMachineName() As String
        Get
            _OSMachineName = GetOSMachineName()
            Return _OSMachineName
        End Get
    End Property

    ''' <summary>
    ''' Operating System Version
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Version")> _
    Public ReadOnly Property OSVersion() As String
        Get
            _OSVersion = GetOSVersion()
            Return _OSVersion
        End Get
    End Property

    ''' <summary>
    ''' Operating System Full Name
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Full Name")> _
    Public ReadOnly Property OSFullName() As String
        Get
            _OSFullName = GetOSFullName()
            Return _OSFullName
        End Get
    End Property

    ''' <summary>
    ''' Operating System Platform
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Platform")> _
    Public ReadOnly Property OSPlatform() As System.PlatformID
        Get
            _OSPlatform = GetOSPlatform()
            Return _OSPlatform
        End Get
    End Property

    ''' <summary>
    ''' Operating System Minor Version
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Minor Version")> _
    Public ReadOnly Property OSMinorVersion() As Integer
        Get
            _OSMinorVersion = GetOSMinorVersion()
            Return _OSMinorVersion
        End Get
    End Property

    ''' <summary>
    ''' Operating System Major Version
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Major Version")> _
    Public ReadOnly Property OSMajorVersion() As Integer
        Get
            _OSMajorVersion = GetOSMajorVersion()
            Return _OSMajorVersion
        End Get
    End Property

    ''' <summary>
    ''' Operating System Service Pack
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Service Pack")> _
    Public ReadOnly Property OSServicePack() As String
        Get
            _OSServicePack = GetOSServicePack()
            Return _OSServicePack
        End Get
    End Property

    ''' <summary>
    ''' Logon User Name
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Logon User Name")> _
    Public ReadOnly Property OSUserName() As String
        Get
            _OSUserName = GetOSUserName()
            Return _OSUserName
        End Get
    End Property

    ''' <summary>
    ''' OS Product Key
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("OS Product Key")> _
    Public ReadOnly Property OSProductKey() As String
        Get
            _OSProductKey = GetOSProductKey()
            Return _OSProductKey
        End Get
    End Property

    ''' <summary>
    ''' Microsoft's Numeric Product ID
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Microsoft's Numeric Product ID")> _
    Public ReadOnly Property OSProductId() As String
        Get
            _OSProductId = GetOSProductId()
            Return _OSProductId
        End Get
    End Property

    ''' <summary>
    ''' Type of build, ie. checked/free and single/multi processor
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Type of build, ie. checked/free and single/multi processor")> _
    Public ReadOnly Property OSType() As String
        Get
            _OSType = GetOSType()
            Return _OSType
        End Get
    End Property

    ''' <summary>
    ''' Operating System Major and Minor Version Separated by a Decimal
    ''' </summary>
    <Browsable(True), Category("Operating System"), _
        Description("Operating System Major and Minor Version Separated by a Decimal")> _
    Public ReadOnly Property OSShortVersion() As String
        Get
            _OSShortVersion = GetOSShortVersion()
            Return _OSShortVersion
        End Get
    End Property

    ''' <summary>
    ''' Formatted Time Since Last Start
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Formatted Time Since Last Start")> _
    Public ReadOnly Property OSUptime() As String
        Get
            _OSUptime = GetOSUptime()
            Return _OSUptime
        End Get
    End Property

    ''' <summary>
    ''' Date/Time of Last System Start as Date
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Last System Start Date/Time as Date")> _
    Public ReadOnly Property OSStartTime() As Date
        Get
            _OSStartTime = NativeMethods.GetSystemStartTime()
            Return _OSStartTime
        End Get
    End Property

    ''' <summary>
    ''' Operating System Bootup State
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Bootup State")> _
    Public ReadOnly Property OSBootUpstate() As String
        Get
            _OSBootupState = GetOSBootupState()
            Return _OSBootupState
        End Get
    End Property

    ''' <summary>
    ''' Operating System Domain
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Domain")> _
    Public ReadOnly Property OSDomain() As String
        Get
            _OSDomain = GetOSDomain()
            Return _OSDomain
        End Get
    End Property

    ''' <summary>
    ''' Operating System Part of Domain
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Part of Domain")> _
    Public ReadOnly Property OSPartOfDomain() As Boolean
        Get
            _OSPartOfDomain = GetOSPartOfDomain()
            Return _OSPartOfDomain
        End Get
    End Property

    ''' <summary>
    ''' Operating System Installation Date
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System Installation Date")> _
    Public ReadOnly Property OSInstallDate() As Date
        Get
            _OSInstallDate = GetOSInstallDate()
            Return _OSInstallDate
        End Get
    End Property

    ''' <summary>
    ''' Returns True if Operating System 64-Bit Version Installed.
    ''' </summary>
    <Browsable(True), Category("Operating System"), Description("Operating System 64-Bit Version Installed")> _
    Public ReadOnly Property OperatingSystemIs64Bit() As Boolean
        Get
            _Is64Bit = GetOSIs64Bit()
            Return _Is64Bit
        End Get
    End Property

#End Region

#Region " Service Properties "

    ''' <summary>
    ''' Display Name for service
    ''' </summary>
    <Browsable(True), Category("Services"), Description("Display Name for service")> _
    Public ReadOnly Property ServiceDisplayName() As Collection(Of String)
        Get
            Return _ServiceDisplayName
        End Get
    End Property

    ''' <summary>
    ''' Description of service
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Services"), Description("Description of service")> _
    Public ReadOnly Property ServiceDescription() As Collection(Of String)
        Get
            Return _ServiceDescription
        End Get
    End Property

    ''' <summary>
    ''' Start mode of service
    ''' </summary>
    <Browsable(True), Category("Service"), Description("Start mode of service")> _
    Public ReadOnly Property ServiceStartMode() As Collection(Of String)
        Get
            Return _ServiceStartMode
        End Get
    End Property

    ''' <summary>
    ''' State of service
    ''' </summary>
    <Browsable(True), Category("Service"), Description("State of service")> _
    Public ReadOnly Property ServiceState() As Collection(Of String)
        Get
            Return _ServiceState
        End Get
    End Property

    ''' <summary>
    ''' Status of Service
    ''' </summary>
    <Browsable(True), Category("Service"), Description("Status of Service")> _
    Public ReadOnly Property ServiceStatus() As Collection(Of String)
        Get
            Return _ServiceStatus
        End Get
    End Property

    ''' <summary>
    ''' Path name for service
    ''' </summary>
    <Browsable(True), Category("Service"), Description("Path name for service")> _
    Public ReadOnly Property ServicePathName() As Collection(Of String)
        Get
            Return _ServicePathName
        End Get
    End Property

#End Region

#Region " Sound Public Properties "

    ''' <summary>
    ''' Sound Controller Name
    ''' </summary>
    <Browsable(True), Category("Sound"), Description("Sound Controller Name")> _
    Public ReadOnly Property SoundController() As Collection(Of String)
        Get
            Return _SndController
        End Get
    End Property

    ''' <summary>
    ''' Sound Controller Manufacturer
    ''' </summary>
    <Browsable(True), Category("Sound"), Description("Sound Controller Manufacturer")> _
    Public ReadOnly Property SoundManufacturer() As Collection(Of String)
        Get
            Return _SndManufacturer
        End Get
    End Property

    ''' <summary>
    ''' Sound Controller DMA Buffer Size
    ''' </summary>
    <Browsable(True), Category("Sound"), Description("Sound Controller DMA Buffer Size")> _
    Public ReadOnly Property SoundDmaBufferSize() As Collection(Of String)
        Get
            Return _SndDMABufferSize
        End Get
    End Property

    ''' <summary>
    ''' Number of Sound Controllers
    ''' </summary>
    <Browsable(True), Category("Sound"), Description("Number of Sound Controllers")> _
    Public ReadOnly Property SoundNumberOfControllers() As Integer
        Get
            Return _SndNumberOfControllers
        End Get
    End Property

#End Region

#Region " Time Public Properties "

    ''' <summary>
    ''' Current Time Zone
    ''' </summary>
    <Browsable(True), Category("Time"), Description("Current Time Zone")> _
    Public ReadOnly Property TimeCurrentTimeZone() As String
        Get
            _TimeCurrentTimeZone = GetCurrentTimeZone()
            Return _TimeCurrentTimeZone
        End Get
    End Property

    ''' <summary>
    ''' Daylight Savings in Effect
    ''' </summary>
    <Browsable(True), Category("Time"), Description("Daylight Savings in Effect")> _
    Public ReadOnly Property TimeDaylightSavingsInEffect() As Boolean
        Get
            _TimeDaylightSavingsInEffect = GetDaylightSavingsInEffect()
            Return _TimeDaylightSavingsInEffect
        End Get
    End Property

    ''' <summary>
    ''' Daylight Savings Name
    ''' </summary>
    <Browsable(True), Category("Time"), Description("Daylight Savings Name")> _
    Public ReadOnly Property TimeDaylightSavingsName() As String
        Get
            _TimeDaylightSavingsName = GetDaylightSavingsName()
            Return _TimeDaylightSavingsName
        End Get
    End Property

    ''' <summary>
    ''' Daylight Savings Offset
    ''' </summary>
    <Browsable(True), Category("Time"), Description("Daylight Savings Offset")> _
    Public Shared ReadOnly Property TimeDaylightSavingsOffset() As Integer
        Get
            Return GetDaylightSavingsOffset()
        End Get
    End Property

    ''' <summary>
    ''' (Date) Local Daylight Saving End Date
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Local Daylight Saving End Date")> _
    Public Property TimeLocalDaylightEndDate() As Date
        Get
            _TimeLocalDaylightEndDate = GetLocalDaylightEndDate(mTempDate)
            Return _TimeLocalDaylightEndDate
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' (Date) Local Daylight Saving End Time
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Local Daylight Saving End Time")> _
    Public Property TimeLocalDaylightEndTime() As Date
        Get
            _TimeLocalDaylightEndTime = GetLocalDaylightEndTime(mTempDate)
            Return _TimeLocalDaylightEndTime
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' (Date) Local Daylight Saving Start Date
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Local Daylight Saving Start Date")> _
    Public Property TimeLocalDaylightStartDate() As Date
        Get
            _TimeLocalDaylightStartDate = GetLocalDaylightStartDate(mTempDate)
            Return _TimeLocalDaylightStartDate
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' (Date) Local Daylight Saving Start Time
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Local Daylight Saving Start Time")> _
    Public Property TimeLocalDaylightStartTime() As Date
        Get
            _TimeLocalDaylightStartTime = GetLocalDaylightStartTime(mTempDate)
            Return _TimeLocalDaylightStartTime
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' (Date) Local Date and Time
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Local Date and Time")> _
    Public ReadOnly Property TimeLocalDateTime() As Date
        Get
            _TimeLocalDateTime = GetLocalDateTime()
            Return _TimeLocalDateTime
        End Get
    End Property

    ''' <summary>
    ''' (Date) Universal Date and Time
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Universal Date and Time")> _
    Public ReadOnly Property TimeUniversalDateTime() As Date
        Get
            _TimeUniversalDateTime = GetUniversalDateTime()
            Return _TimeUniversalDateTime
        End Get
    End Property

    ''' <summary>
    ''' (Date) Universal Daylight Saving End Date
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Universal Daylight Saving End Date")> _
    Public Property TimeUniversalDaylightEndDate() As Date
        Get
            _TimeUniversalDaylightEndDate = GetUniversalDaylightEndDate(mTempDate)
            Return _TimeUniversalDaylightEndDate
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' (Date) Universal Daylight Saving End Time
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Universal Daylight Saving End Time")> _
    Public Property TimeUniversalDaylightEndTime() As Date
        Get
            _TimeUniversalDaylightEndTime = GetUniversalDaylightEndTime(mTempDate)
            Return _TimeUniversalDaylightEndTime
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' (Date) Universal Daylight Saving Start Date
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Universal Daylight Saving Start Date")> _
    Public Property TimeUniversalDaylightStartDate() As Date
        Get
            _TimeUniversalDaylightStartDate = GetUniversalDaylightStartDate(mTempDate)
            Return _TimeUniversalDaylightStartDate
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' (Date) Universal Daylight Saving Start Time
    ''' </summary>
    <Browsable(True), Category("Time"), Description("(Date) Universal Daylight Saving Start Time")> _
    Public Property TimeUniversalDaylightStartTime() As Date
        Get
            _TimeUniversalDaylightStartTime = GetUniversalDaylightStartTime(mTempDate)
            Return _TimeUniversalDaylightStartTime
        End Get
        Set(ByVal Value As Date)
            mTempDate = Value
        End Set
    End Property

    ''' <summary>
    ''' Universal Time Offset
    ''' </summary>
    <Browsable(True), Category("Time"), Description("Universal Time Offset")> _
    Public ReadOnly Property TimeUniversalTimeOffset() As Integer
        Get
            _UniversalTimeOffset = GetUniversalTimeOffset()
            Return _UniversalTimeOffset
        End Get
    End Property

#End Region

#Region " User Account Public Properties "

    ''' <summary>
    ''' Administrator Status of Current User
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("Administrator Status of Current User")> _
    Public ReadOnly Property UserIsAdministrator() As Boolean
        Get
            _UserIsAdministrator = GetUserIsAdministrator()
            Return _UserIsAdministrator
        End Get
    End Property

    ''' <summary>
    ''' Registered Name
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("Registered Name")> _
    Public Property UserRegisteredName() As String
        Get
            _UserRegisteredName = GetUserRegisteredName()
            Return _UserRegisteredName
        End Get
        Set(ByVal value As String)
            _UserRegisteredName = value
            SetUserRegisteredName(_UserRegisteredName)
        End Set
    End Property

    ''' <summary>
    ''' Registered Organization
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("Registered Organization")> _
    Public Property UserRegisteredOrganization() As String
        Get
            _UserRegisteredOrganization = GetUserOrganization()
            Return _UserRegisteredOrganization
        End Get
        Set(ByVal value As String)
            _UserRegisteredOrganization = value
            SetUserRegisteredOrganization(_UserRegisteredOrganization)
        End Set
    End Property

    ''' <summary>
    ''' Registered User (Wow6432Node)
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("Register User (Wow6432Node)")> _
    Public Property UserRegisteredNameWow6432Node() As String
        Get
            _UserRegisteredNameWow6432Node = GetUserRegisteredNameWow6432Node()
            Return _UserRegisteredNameWow6432Node
        End Get
        Set(ByVal value As String)
            _UserRegisteredNameWow6432Node = value
            SetUserRegisteredNameWow6432Node(_UserRegisteredNameWow6432Node)
        End Set
    End Property

    ''' <summary>
    ''' Registered Organization (Wow6432Node)
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("Registered Organization (Wow6432Node)")> _
    Public Property UserRegisteredOrganizationWow6432Node() As String
        Get
            _UserRegisteredOrganizationWow6432Node = GetUserOrganizationWow6432Node()
            Return _UserRegisteredOrganizationWow6432Node
        End Get
        Set(ByVal value As String)
            _UserRegisteredOrganizationWow6432Node = value
            SetUserRegisteredOrganizationWow6432Node(_UserRegisteredOrganizationWow6432Node)
        End Set
    End Property

    ''' <summary>
    ''' User Account Flags
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("User Account Flags")> _
    Public ReadOnly Property UserAccountRights() As Collection(Of Integer)
        Get
            _UserFlags = GetUserFlags()
            Return _UserFlags
        End Get
    End Property

    ''' <summary>
    ''' Collection of User Accounts on This Computer
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("Collection of User Accounts on This Computer")> _
    Public ReadOnly Property UserAccounts() As Collection(Of String)
        Get
            _UserAccounts = NativeMethods.EnumerateUsers
            Return _UserAccounts
        End Get
    End Property

    ''' <summary>
    ''' User Full Name
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("User Full Name")> _
    Public ReadOnly Property UserFullName() As Collection(Of String)
        Get
            _UserFullNames = GetUserFullNames()
            Return _UserFullNames
        End Get
    End Property

    ''' <summary>
    ''' User Privilege
    ''' </summary>
    <Browsable(True), Category("User Account"), Description("User Privilege")> _
    Public ReadOnly Property UserPrivilege() As Collection(Of String)
        Get
            _UserPrivileges = GetUserPrivileges()
            Return _UserPrivileges
        End Get
    End Property

#End Region

#Region " Video Public Properties "

    ''' <summary>
    ''' Installed Video Controllers
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Installed Video Controllers")> _
    Public ReadOnly Property VideoController() As Collection(Of String)
        Get
            Return _VidController
        End Get
    End Property

    ''' <summary>
    ''' Primary Screen Dimensions
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Primary Screen Dimensions")> _
    Public ReadOnly Property VideoPrimaryScreenDimensions() As String
        Get
            _VidPrimaryScreenDimensions = GetVidPrimaryScreenDimensions()
            Return _VidPrimaryScreenDimensions
        End Get
    End Property

    ''' <summary>
    ''' Primary Screen Working Area
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Primary Screen Working Area")> _
    Public ReadOnly Property VideoPrimaryScreenWorkingArea() As String
        Get
            _VidPrimaryScreenWorkingArea = GetVidPrimaryScreenWorkingArea()
            Return _VidPrimaryScreenWorkingArea
        End Get
    End Property

    ''' <summary>
    ''' Secondary Screen Dimensions
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Secondary Screen Dimensions")> _
    Public ReadOnly Property VideoSecondaryScreenDimensions() As String
        Get
            _VidSecondaryScreenDimensions = GetVidSecondaryScreenDimensions()
            Return _VidSecondaryScreenDimensions
        End Get
    End Property

    ''' <summary>
    ''' Secondary Screen Working Area
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Secondary Screen Working Area")> _
    Public ReadOnly Property VideoSecondaryScreenWorkingArea() As String
        Get
            _VidSecondaryScreenWorkingArea = GetVidSecondaryScreenWorkingArea()
            Return _VidSecondaryScreenWorkingArea
        End Get
    End Property

    ''' <summary>
    ''' Tertiary Screen Dimensions
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Tertiary Screen Dimensions")> _
    Public ReadOnly Property VideoTertiaryScreenDimensions() As String
        Get
            _VidTertiaryScreenDimensions = GetVidTertiaryScreenDimensions()
            Return _VidTertiaryScreenDimensions
        End Get
    End Property

    ''' <summary>
    ''' Tertiary Screen Working Area
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Tertiary Screen Working Area")> _
    Public ReadOnly Property VideoTertiaryScreenWorkingArea() As String
        Get
            _VidTertiaryScreenWorkingArea = GetVidTertiaryScreenWorkingArea()
            Return _VidTertiaryScreenWorkingArea
        End Get
    End Property

    ''' <summary>
    ''' Quaternary Screen Dimensions
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Quaternary Screen Dimensions")> _
    Public ReadOnly Property VideoQuaternaryScreenDimensions() As String
        Get
            _VidQuaternaryScreenDimensions = GetVidQuaternaryScreenDimensions()
            Return _VidQuaternaryScreenDimensions
        End Get
    End Property

    ''' <summary>
    ''' Quaternary Screen Working Area
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Quaternary Screen Working Area")> _
    Public ReadOnly Property VideoQuaternaryScreenWorkingArea() As String
        Get
            _VidQuaternaryScreenWorkingArea = GetVidQuaternaryScreenWorkingArea()
            Return _VidQuaternaryScreenWorkingArea
        End Get
    End Property

    ''' <summary>
    ''' Number of Video Controllers
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Number of Video Controllers")> _
    Public ReadOnly Property VideoNumberOfControllers() As Integer
        Get
            Return _VidNumberOfControllers
        End Get
    End Property

    ''' <summary>
    ''' Video Controllers RAM
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Video Controllers RAM")> _
    Public ReadOnly Property VideoRam() As Collection(Of String)
        Get
            Return _VidRam
        End Get
    End Property

    ''' <summary>
    ''' Video Controllers Refresh Rate
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Video Controllers Refresh Rate")> _
    Public ReadOnly Property VideoRefreshRate() As Collection(Of String)
        Get
            Return _VidRefreshRate
        End Get
    End Property

    ''' <summary>
    ''' Video Controllers Colors
    ''' </summary>
    <Browsable(True), Category("Video"), Description("Video Controllers Colors")> _
    Public ReadOnly Property VideoScreenColors() As Collection(Of String)
        Get
            Return _VidScreenColors
        End Get
    End Property

#End Region

#Region " Visual Style Public Properties "

    ''' <summary>
    ''' Visual Style Author
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Author")> _
    Public ReadOnly Property VisualStyleAuthor() As String
        Get
            _VstAuthor = GetVstAuthor()
            Return _VstAuthor
        End Get
    End Property

    ''' <summary>
    ''' Visual Style ColorScheme
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style ColorScheme")> _
    Public ReadOnly Property VisualStyleColorScheme() As String
        Get
            _VstColorScheme = GetVstColorScheme()
            Return _VstColorScheme
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Company
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Company")> _
    Public ReadOnly Property VisualStyleCompany() As String
        Get
            _VstCompany = GetVstCompany()
            Return _VstCompany
        End Get
    End Property

    ''' <summary>
    ''' (Drawing.Color) Visual Style Control Highlight Hot
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), _
        Description("(Drawing.Color) Visual Style Control Highlight Hot")> _
    Public ReadOnly Property VisualStyleControlHighlightHot() As Drawing.Color
        Get
            _VstControlHighlightHot = GetVstControlHighlightHot()
            Return _VstControlHighlightHot
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Copyright
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Copyright")> _
    Public ReadOnly Property VisualStyleCopyright() As String
        Get
            _VstCopyright = GetVstCopyright()
            Return _VstCopyright
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Description
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Description")> _
    Public ReadOnly Property VisualStyleDescription() As String
        Get
            _VstDescription = GetVstDescription()
            Return _VstDescription
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Display Name
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Display Name")> _
    Public ReadOnly Property VisualStyleDisplayName() As String
        Get
            _VstDisplayName = GetVstDisplayName()
            Return _VstDisplayName
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Enabled by User
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Enabled by User")> _
    Public ReadOnly Property VisualStyleIsEnabledByUser() As Boolean
        Get
            _VstIsEnabledByUser = GetVstIsEnabledByUser()
            Return _VstIsEnabledByUser
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Supported by Operating System
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Supported by Operating System")> _
    Public ReadOnly Property VisualStyleIsSupportedByOS() As Boolean
        Get
            _VstIsSupportedByOS = GetVstIsSupportedByOS()
            Return _VstIsSupportedByOS
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Minimum Color Depth
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Minimum Color Depth")> _
    Public ReadOnly Property VisualStyleMinimumColorDepth() As Integer
        Get
            _VstMinimumColorDepth = GetVstMinimumColorDepth()
            Return _VstMinimumColorDepth
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Size
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Size")> _
    Public ReadOnly Property VisualStyleSize() As String
        Get
            _VstSize = GetVstSize()
            Return _VstSize
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Supports Flat Menus
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Supports Flat Menus")> _
    Public ReadOnly Property VisualStyleSupportsFlatMenus() As Boolean
        Get
            _VstSupportsFlatMenus = GetVstSupportsFlatMenus()
            Return _VstSupportsFlatMenus
        End Get
    End Property

    ''' <summary>
    ''' (Drawing.Color) Visual Style Text Control Border
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), _
        Description("(Drawing.Color) Visual Style Text Control Border")> _
    Public ReadOnly Property VisualStyleTextControlBorder() As Drawing.Color
        Get
            _VstTextControlBorder = GetVstTextControlBorder()
            Return _VstTextControlBorder
        End Get
    End Property

    ''' <summary>
    ''' Visual Style URL
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style URL")> _
    Public ReadOnly Property VisualStyleUrl() As String
        Get
            _VstUrl = GetVstUrl()
            Return _VstUrl
        End Get
    End Property

    ''' <summary>
    ''' Visual Style Version
    ''' </summary>
    <Browsable(True), Category("Visual Styles"), Description("Visual Style Version")> _
    Public ReadOnly Property VisualStyleVersion() As String
        Get
            _VstVersion = GetVstVersion()
            Return _VstVersion
        End Get
    End Property

#End Region

#Region " Volume Public Properties "

    ''' <summary>
    ''' Volume Letters
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Letters")> _
    Public ReadOnly Property VolumeLetter() As Collection(Of String)
        Get
            Return _VolumeLetter
        End Get
    End Property

    ''' <summary>
    ''' Volume Types
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Types")> _
    Public ReadOnly Property VolumeType() As Collection(Of String)
        Get
            Return _VolumeType
        End Get
    End Property

    ''' <summary>
    ''' Volume File Systems
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume File Systems")> _
    Public ReadOnly Property VolumeFileSystem() As Collection(Of String)
        Get
            Return _VolumeFileSystem
        End Get
    End Property

    ''' <summary>
    ''' Volume Ready Status
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Ready Status")> _
    Public ReadOnly Property VolumeReady() As Collection(Of Boolean)
        Get
            Return _VolumeReady
        End Get
    End Property

    ''' <summary>
    ''' Volume Label
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Label")> _
    Public ReadOnly Property VolumeLabel() As Collection(Of String)
        Get
            Return _VolumeLabel
        End Get
    End Property

    ''' <summary>
    ''' Volume Total Size
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Total Size")> _
    Public ReadOnly Property VolumeTotalSize() As Collection(Of String)
        Get
            Return _VolumeTotalSize
        End Get
    End Property

    ''' <summary>
    ''' Volume Free Space
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Free Space")> _
    Public ReadOnly Property VolumeFreeSpace() As Collection(Of String)
        Get
            Return _VolumeFreeSpace
        End Get
    End Property

    ''' <summary>
    ''' Volume Used Space
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Used Space")> _
    Public ReadOnly Property VolumeUsedSpace() As Collection(Of String)
        Get
            Return _VolumeUsedSpace
        End Get
    End Property

    ''' <summary>
    ''' Volume Percent Free Space
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Percent Free Space")> _
    Public ReadOnly Property VolumePercentFreeSpace() As Collection(Of String)
        Get
            Return _VolumePercentFreeSpace
        End Get
    End Property

    ''' <summary>
    ''' Volume Serial Number
    ''' </summary>
    <Browsable(True), Category("Volume"), Description("Volume Serial Number")> _
    Public ReadOnly Property VolumeSerialNumber() As Collection(Of String)
        Get
            Return _VolumeSerialNumber
        End Get
    End Property

#End Region

#End Region

End Class
