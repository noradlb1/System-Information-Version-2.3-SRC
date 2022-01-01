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

Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Runtime.InteropServices
Imports System.Security
Imports System.Security.Permissions
Imports System.Windows.Forms

Public Class NativeMethods

#Region " Constructor "

    Public Sub New()

    End Sub

#End Region

#Region " Get Volume Serial Number "

#Region " API Declarations and Constants "

    Private Declare Function GetVolumeInformation Lib "kernel32" Alias "GetVolumeInformationA" _
        (ByVal lpRootPathName As String, ByVal lpVolumeNameBuffer As String, _
        ByVal nVolumeNameSize As Integer, ByRef lpVolumeSerialNumber As Integer, _
        ByRef lpMaximumComponentLength As Integer, ByRef lpFileSystemFlags As Integer, _
        ByVal lpFileSystemNameBuffer As String, ByVal nFileSystemNameSize As Integer) As Integer

#End Region

    ''' <summary>
    ''' Returns hexadecimal volume serial number.
    ''' </summary>
    ''' <param name="volume">volume "drive letter"</param>
    Public Shared Function GetVolumeSerialNumber(ByVal volume As String) As String
        Dim check As Integer
        Dim volumeSerialNumber As Integer
        Dim unused As String
        Dim volumeName As String

        ' Pad the strings.
        volumeName = Space(14)
        unused = Space(32)

        check = GetVolumeInformation(volume, volumeName, Len(volumeName), _
            volumeSerialNumber, 0, 0, unused, Len(unused))

        ' Error check.
        If check = 0 Then
            Return ""
        Else
            Return volumeSerialNumber.ToString("X").Insert(4, "-")
        End If

    End Function

#End Region

#Region " Get Memory Information "

#Region " API Declaration and Structure "

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Auto), CLSCompliant(False)> _
    Private Structure MEMORYSTATUSEX
        Dim dwLength As Integer
        Dim dwMemoryLoad As Integer
        Dim ullTotalPhys As UInt64
        Dim ullAvailPhys As UInt64
        Dim ullTotalPageFile As UInt64
        Dim ullAvailPageFile As UInt64
        Dim ullTotalVirtual As UInt64
        Dim ullAvailVirtual As UInt64
        Dim ullAvailExtendedVirtual As UInt64
    End Structure

    ' API declarations
    Private Declare Auto Function GlobalMemoryStatusEx Lib "kernel32" _
        (<MarshalAs(UnmanagedType.Struct)> ByRef lpBuffer As MEMORYSTATUSEX) As _
        <MarshalAs(UnmanagedType.Bool)> Boolean

#End Region

    ' Object declaration.
    Private Shared MemoryStatus As MEMORYSTATUSEX

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function GetMemoryAvailVirtual() As String
        Dim dblInfo As Double

        ' Call API
        MemoryStatus.dwLength = Marshal.SizeOf(MemoryStatus)
        GlobalMemoryStatusEx(MemoryStatus)

        ' get memory information
        dblInfo = CDbl(MemoryStatus.ullAvailVirtual)

        ' return formatted string
        Return FormatBytes(dblInfo)

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function GetMemoryAvailPhysical() As String
        Dim dblInfo As Double

        ' Call API
        MemoryStatus.dwLength = Marshal.SizeOf(MemoryStatus)
        GlobalMemoryStatusEx(MemoryStatus)

        ' get memory information
        dblInfo = CDbl(MemoryStatus.ullAvailPhys)

        ' return formatted string
        Return FormatBytes(dblInfo)

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function GetMemoryTotalVirtual() As String
        Dim dblInfo As Double

        ' Call API
        MemoryStatus.dwLength = Marshal.SizeOf(MemoryStatus)
        GlobalMemoryStatusEx(MemoryStatus)

        ' get memory information
        dblInfo = CDbl(MemoryStatus.ullTotalVirtual)

        ' return formatted string
        Return FormatBytes(dblInfo)

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function GetMemoryTotalPhysical() As String
        Dim dblInfo As Double

        ' Call API
        MemoryStatus.dwLength = Marshal.SizeOf(MemoryStatus)
        GlobalMemoryStatusEx(MemoryStatus)

        ' get memory information
        dblInfo = CDbl(MemoryStatus.ullTotalPhys)

        ' return formatted string
        Return FormatBytes(dblInfo)

    End Function

#End Region

#Region " Get User Information "

#Region " API Declarations and Structures "

    ' Bit masks for field usriX_flags of USER_INFO_2
    Const UF_ACCOUNTDISABLE As Integer = &H2
    Const UF_LOCKOUT As Integer = &H10
    Const UF_PASSWD_NOTREQD As Integer = &H20
    Const UF_PASSWD_CANT_CHANGE As Integer = &H40
    Const UF_DONT_EXPIRE_PASSWD As Integer = &H10000

    ' USER_INF0_2 - Structure to hold advanced user information.
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure USER_INFO_2
        Dim usri2_name As String
        Dim usri2_password As String
        Dim usri2_password_age As Integer
        Dim usri2_priv As Integer
        Dim usri2_home_dir As String
        Dim usri2_comment As String
        Dim usri2_flags As Integer
        Dim usri2_script_path As String
        Dim usri2_auth_flags As Integer
        Dim usri2_full_name As String
        Dim usri2_usr_comment As String
        Dim usri2_parms As String
        Dim usri2_workstations As String
        Dim usri2_last_logon As Integer
        Dim usri2_last_logoff As Integer
        Dim usri2_acct_expires As Integer
        Dim usri2_max_storage As Integer
        Dim usri2_units_per_week As Integer
        Dim usri2_logon_hours As Byte
        Dim usri2_bad_pw_count As Integer
        Dim usri2_num_logons As Integer
        Dim usri2_logon_server As String
        Dim usri2_country_code As Integer
        Dim usri2_code_page As Integer
    End Structure

    ' USER_INFO_0 - Structure to hold Just Username.
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure USER_INFO_0
        Public Username As String
    End Structure

    ' NetUserGetInfo - Returns to a struct Information about the specified user
    Private Declare Auto Function NetUserGetInfo Lib "Netapi32" (<MarshalAs(UnmanagedType.LPWStr)> _
        ByVal servername As String, <MarshalAs(UnmanagedType.LPWStr)> _
        ByVal username As String, ByVal level As Integer, ByRef bufptr As IntPtr) As Integer

    ' NetUserEnum - Obtains a list of all users on local machine or network
    Private Declare Auto Function NetUserEnum Lib "Netapi32" (ByVal servername As String, _
        ByVal level As Integer, ByVal filter As Integer, ByRef bufptr As IntPtr, _
        ByRef prefmaxlen As Integer, ByRef entriesread As Integer, ByRef totalentries As Integer, _
        ByRef resume_handle As Integer) As Integer

    ' NetAPIBufferFree - Used to clear the Network buffer after NetUserEnum
    Private Declare Auto Function NetApiBufferFree Lib "Netapi32" (ByVal Buffer As IntPtr) As Integer

    ' User Privilege levels.
    Private Enum PrivilegeLevel
        Guest = 0
        User = 1
        Admin = 2
    End Enum

#End Region

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function EnumerateUsers() As Collection(Of String)

        Dim entriesRead As Integer
        Dim totalEntries As Integer
        Dim resumeHandle As Integer
        Dim bufPtr As IntPtr
        Dim userName As Collection(Of String) = New Collection(Of String)

        If NetUserEnum(Nothing, 0, 2, bufPtr, -1, entriesRead, totalEntries, resumeHandle) = 0 Then

            If entriesRead > 0 Then
                Dim users(entriesRead) As USER_INFO_0
                Dim iter As IntPtr = bufPtr
                Dim i As Integer
                For i = 0 To entriesRead - 1

                    users(i) = CType(Marshal.PtrToStructure(iter, GetType(USER_INFO_0)), USER_INFO_0)
                    iter = CType(CInt(iter) + Marshal.SizeOf(GetType(USER_INFO_0)), IntPtr)
                    userName.Add(users(i).Username)
                Next i

                ' Free buffer.
                If Not NetApiBufferFree(bufPtr) = 0 Then
                    userName.Clear()
                End If
            End If

        End If

        Return userName

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function GetUserPrivilege(ByVal userName As String) As String
        Dim retValue As String
        Dim bufPtr As IntPtr
        Dim CurrentUser As New USER_INFO_2

        If NetUserGetInfo(Nothing, userName, 2, bufPtr) = 0 Then

            CurrentUser = CType(Marshal.PtrToStructure(bufPtr, GetType(USER_INFO_2)), USER_INFO_2)

            Select Case CurrentUser.usri2_priv
                Case PrivilegeLevel.Guest
                    retValue = "Guest"
                Case PrivilegeLevel.User
                    retValue = "Limited User"
                Case PrivilegeLevel.Admin
                    retValue = "Administrator"
                Case Else
                    retValue = "Unknown"
            End Select

            Return retValue
        Else
            Return "Unknown"
        End If

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function GetUserFullName(ByVal userName As String) As String
        Dim bufPtr As IntPtr
        Dim CurrentUser As New USER_INFO_2

        If NetUserGetInfo(Nothing, userName, 2, bufPtr) = 0 Then
            CurrentUser = CType(Marshal.PtrToStructure(bufPtr, GetType(USER_INFO_2)), USER_INFO_2)
            Return CurrentUser.usri2_full_name
        Else
            Return ""
        End If

    End Function

    <EnvironmentPermissionAttribute(SecurityAction.LinkDemand, Unrestricted:=True)> _
    Public Shared Function GetUserBits(ByVal userName As String) As Integer
        Dim bufPtr As IntPtr
        Dim CurrentUser As New USER_INFO_2

        If NetUserGetInfo(Nothing, userName, 2, bufPtr) = 0 Then
            CurrentUser = CType(Marshal.PtrToStructure(bufPtr, GetType(USER_INFO_2)), USER_INFO_2)
            Return CurrentUser.usri2_flags
        Else
            Return 0
        End If

    End Function

#End Region

#Region " Extract Icon "

#Region " API Declarations "

    Private Declare Auto Function ExtractIcon Lib "shell32.dll" _
        (ByVal hInst As IntPtr, ByVal lpszExeFileName As String, ByVal nIconIndex As Integer) As IntPtr

    Private Declare Function DestroyIcon Lib "user32.dll" (ByVal hIcon As IntPtr) As _
        <MarshalAs(UnmanagedType.Bool)> Boolean

#End Region

    ''' <summary>
    ''' Return first icon for an executible file.
    ''' </summary>
    ''' <remarks>
    ''' This overload does not require an icon index to be specified.
    ''' </remarks>
    Public Function GetIcon(ByVal filePath As String) As Icon

        Try

            Dim ico, clone As Icon
            Dim iconHandle As IntPtr

            ' Extract icon 0 from filePath.
            Dim iconIndex As Integer = 0

            Dim hInst As IntPtr = Marshal.GetHINSTANCE(Me.GetType().Module)

            iconHandle = ExtractIcon(hInst, filePath, iconIndex)

            ' Make sure we have a valid handle.
            If CInt(iconHandle) = 1 Then  ' file is not exe, dll, or ico

                Return Nothing

            ElseIf iconHandle = Nothing Then

                Return Nothing

            Else

                ' Return a cloned Icon, because we have to free the original ourself.
                ico = Icon.FromHandle(iconHandle)
                clone = CType(ico.Clone(), Icon)
                ico.Dispose()
                DestroyIcon(iconHandle)
                Return clone

            End If

        Catch ex As Exception

            ' Silently fail and return a null.
            Return Nothing

        End Try

    End Function

    ''' <summary>
    ''' Return specified icon for an executible file.
    ''' </summary>
    ''' <remarks>
    ''' This overload requires an icon index to be specified.
    ''' </remarks>
    Public Function GetIcon(ByVal filePath As String, ByVal iconIndex As Integer) As Icon

        Try
            Dim ico, clone As Icon
            Dim iconHandle As IntPtr

            Dim hInst As IntPtr = Marshal.GetHINSTANCE(Me.GetType().Module)

            iconHandle = ExtractIcon(hInst, filePath, iconIndex)

            ' Return a cloned Icon, because we have to free the original ourself.
            ico = Icon.FromHandle(iconHandle)
            clone = CType(ico.Clone(), Icon)
            ico.Dispose()
            DestroyIcon(iconHandle)
            Return clone

        Catch ex As Exception

            ' Silently fail and return a null.
            Return Nothing

        End Try

    End Function

#End Region

#Region " Get Last Start Time "

    <DllImport("Netapi32.dll", CharSet:=CharSet.Unicode, ExactSpelling:=True)> _
    Private Shared Function NetStatisticsGet( _
        <MarshalAs(UnmanagedType.LPWStr)> ByVal serverName As String, _
        <MarshalAs(UnmanagedType.LPWStr)> ByVal service As String, _
        ByVal level As Integer, _
        ByVal options As Integer, _
        ByRef BufPtr As IntPtr) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure STAT_WORKSTATION_0

        <MarshalAs(UnmanagedType.I8)> _
        Public StatisticsStartTime As Int64

        Public BytesReceived As Long
        Public SmbsReceived As Long
        Public PagingReadBytesRequested As Long
        Public NonPagingReadBytesRequested As Long
        Public CacheReadBytesRequested As Long
        Public NetworkReadBytesRequested As Long

        Public BytesTransmitted As Long
        Public SmbsTransmitted As Long
        Public PagingWriteBytesRequested As Long
        Public NonPagingWriteBytesRequested As Long
        Public CacheWriteBytesRequested As Long
        Public NetworkWriteBytesRequested As Long

        Public InitiallyFailedOperations As Integer
        Public FailedCompletionOperations As Integer

        Public ReadOperations As Integer
        Public RandomReadOperations As Integer
        Public ReadSmbs As Integer
        Public LargeReadSmbs As Integer
        Public SmallReadSmbs As Integer

        Public WriteOperations As Integer
        Public RandomWriteOperations As Integer
        Public WriteSmbs As Integer
        Public LargeWriteSmbs As Integer
        Public SmallWriteSmbs As Integer

        Public RawReadsDenied As Integer
        Public RawWritesDenied As Integer

        Public NetworkErrors As Integer

        '  Connection/Session counts
        Public Sessions As Integer
        Public FailedSessions As Integer
        Public Reconnects As Integer
        Public CoreConnects As Integer
        Public Lanman20Connects As Integer
        Public Lanman21Connects As Integer
        Public LanmanNtConnects As Integer
        Public ServerDisconnects As Integer
        Public HungSessions As Integer
        Public UseCount As Integer
        Public FailedUseCount As Integer

        Public CurrentCommands As Integer

    End Structure

    Public Shared Function GetSystemStartTime() As Date

        Dim bufPtr As IntPtr = IntPtr.Zero
        Dim val As Integer = NetStatisticsGet(Nothing, "LanmanWorkstation", 0, 0, bufPtr)
        Dim wks As STAT_WORKSTATION_0 = New STAT_WORKSTATION_0()

        If val = 0 Then
            wks = CType(Marshal.PtrToStructure(bufPtr, GetType(STAT_WORKSTATION_0)), STAT_WORKSTATION_0)
        End If

        Return DateTime.FromFileTime(wks.StatisticsStartTime)

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
            Return String.Format("{0:N0}", temp) & " bytes"
        Else
            Return ""
        End If

    End Function

#End Region

End Class
