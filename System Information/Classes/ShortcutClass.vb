'
' Derived from a code library by Mattias Sjogren
' Used with permission of the original author.
' Modified by Herbert N Swearengen III (hswear3@swbell.net)
'
' This code library is provided AS-IS without any warranty whatsoever.
'
Option Explicit On
Option Strict On

Imports System
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

Public Class ShortcutClass
    Implements IDisposable

#Region " Private Constants "

    Private Const INFOTIPSIZE As Integer = 1024
    Private Const MAX_PATH As Integer = 260

#End Region

#Region " Private Variables "

    Private link As IShellLinkW
    Private spath As String

#End Region

#Region " Constructor "

    ''' <summary>
    ''' linkPath: Path to new or existing shortcut file (.lnk).
    ''' </summary>
    Public Sub New(ByVal linkPath As String)

        Dim pfile As IPersistFile
        Dim CLSID_ShellLink As Guid = New Guid("00021401-0000-0000-C000-000000000046")
        Dim shellLink As Type

        shellLink = Type.GetTypeFromCLSID(CLSID_ShellLink)
        link = CType(Activator.CreateInstance(shellLink), IShellLinkW)
        spath = linkPath

        If File.Exists(linkPath) Then
            pfile = CType(link, IPersistFile)
            pfile.Load(linkPath, 0)
        End If

    End Sub

#End Region

#Region " Destructor "

    ' Dispose() calls Dispose(true)
    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    ' The bulk of the clean-up code is implemented in Dispose(bool)
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)

        ' free native resources if there are any.
        If link IsNot Nothing Then

            Marshal.ReleaseComObject(link)
            link = Nothing
        End If

    End Sub

#End Region

#Region " Public Properties "

    ''' <summary>
    ''' Gets the argument list of the shortcut.
    ''' </summary>
    Public ReadOnly Property Arguments() As String
        Get
            Dim sb As StringBuilder = New StringBuilder(INFOTIPSIZE)
            link.GetArguments(sb, sb.Capacity)
            Return sb.ToString()
        End Get
    End Property

    ''' <summary>
    ''' Gets a the shortcut comment.
    ''' </summary>
    Public ReadOnly Property Comment() As String
        Get
            Dim sb As StringBuilder = New StringBuilder(INFOTIPSIZE)
            link.GetDescription(sb, sb.Capacity)
            Return sb.ToString()
        End Get
    End Property

    ''' <summary>
    ''' Gets the working directory of the shortcut.
    ''' </summary>
    Public ReadOnly Property WorkingDirectory() As String
        Get
            Dim sb As StringBuilder = New StringBuilder(MAX_PATH)
            link.GetWorkingDirectory(sb, sb.Capacity)
            Return sb.ToString()
        End Get
    End Property

    ''' <summary>
    ''' Gets the target path of the shortcut.
    ''' </summary>
    Public ReadOnly Property Path() As String
        Get
            Dim wfd As WIN32_FIND_DATAW = Nothing
            Dim sb As StringBuilder = New StringBuilder(MAX_PATH)
            link.GetPath(sb, sb.Capacity, wfd, SLGP_FLAGS.SLGP_UNCPRIORITY)
            Return sb.ToString()
        End Get
    End Property

    ''' <summary>
    ''' Gets the path of the Icon assigned to the shortcut.
    ''' </summary>
    Public ReadOnly Property IconLocation() As String
        Get
            Dim sb As StringBuilder = New StringBuilder(MAX_PATH)
            Dim nIconIdx As Integer
            link.GetIconLocation(sb, sb.Capacity, nIconIdx)
            Return sb.ToString()
        End Get
    End Property

    ''' <summary>
    ''' Gets the index of the Icon assigned to the shortcut.
    ''' </summary>
    ''' <remarks>
    ''' Set to zero when the IconLocation property specifies a .ICO file.
    ''' </remarks>
    Public ReadOnly Property IconIndex() As Integer
        Get
            Dim sb As StringBuilder = New StringBuilder(MAX_PATH)
            Dim nIconIdx As Integer
            link.GetIconLocation(sb, sb.Capacity, nIconIdx)
            Return nIconIdx
        End Get
    End Property

    ''' <summary>
    ''' Retrieves the Icon of the shortcut as it will appear in Explorer.
    ''' Use the IconPath and IconIndex properties to change it.
    ''' </summary>
    Public ReadOnly Property Icon() As Icon
        Get
            Dim sb As StringBuilder = New StringBuilder(MAX_PATH)
            Dim nIconIdx As Integer
            Dim hIcon, hInst As IntPtr
            Dim ico, clone As Icon

            link.GetIconLocation(sb, sb.Capacity, nIconIdx)

            hInst = Marshal.GetHINSTANCE(Me.GetType().Module)
            hIcon = ExtractIcon(hInst, sb.ToString(), nIconIdx)

            If hIcon.ToInt32() = 0 Then Return Nothing

            ' Return a cloned Icon, because we have to free the original ourself.
            ico = Drawing.Icon.FromHandle(hIcon)
            clone = CType(ico.Clone(), Icon)
            ico.Dispose()
            DestroyIcon(hIcon)
            Return clone
        End Get
    End Property

#End Region

#Region " Native Win32 API functions "

    Private Declare Auto Function ExtractIcon Lib "shell32.dll" (ByVal hInst As IntPtr, _
        ByVal lpszExeFileName As String, ByVal nIconIndex As Integer) As IntPtr

    Private Declare Auto Function DestroyIcon Lib "user32.dll" (ByVal hIcon As IntPtr) As _
        <MarshalAs(UnmanagedType.Bool)> Boolean

#End Region

End Class

#Region " Flags "

'''' <summary>
'''' IShellLink.Resolve fFlags
'''' </summary>
<Flags()> _
Friend Enum SLR_FLAGS
    SLR_NO_UI = &H1
    SLR_ANY_MATCH = &H2
    SLR_UPDATE = &H4
    SLR_NOUPDATE = &H8
    SLR_NOSEARCH = &H10
    SLR_NOTRACK = &H20
    SLR_NOLINKINFO = &H40
    SLR_INVOKE_MSI = &H80
End Enum

''' <suumary>
''' IShellLink.GetPath fFlags
''' </suumary>
<Flags()> _
Friend Enum SLGP_FLAGS
    SLGP_SHORTPATH = &H1
    SLGP_UNCPRIORITY = &H2
    SLGP_RAWPATH = &H4
End Enum

#End Region

#Region " API Structure "

<StructLayoutAttribute(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
Friend Structure WIN32_FIND_DATAW
    Friend dwFileAttributes As Integer
    Friend ftCreationTime As ComTypes.FILETIME
    Friend ftLastAccessTime As ComTypes.FILETIME
    Friend ftLastWriteTime As ComTypes.FILETIME
    Friend nFileSizeHigh As Integer
    Friend nFileSizeLow As Integer
    Friend dwReserved0 As Integer
    Friend dwReserved1 As Integer
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Friend cFileName As String
    <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=14)> Friend cAlternateFileName As String
    Private Const MAX_PATH As Integer = 260
End Structure

#End Region

#Region " Interfaces "

<ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), _
Guid("0000010B-0000-0000-C000-000000000046")> _
Friend Interface IPersistFile

    ' Method inherited from IPersist.
    Sub GetClassID(<Out()> ByRef pClassID As Guid)

    <PreserveSig()> _
    Function IsDirty() As Integer

    Sub Load(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszFileName As String, ByVal dwMode As Integer)

End Interface

<ComImport(), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown), _
Guid("000214F9-0000-0000-C000-000000000046")> _
Friend Interface IShellLinkW

    Sub GetPath(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszFile As StringBuilder, _
        ByVal cchMaxPath As Integer, <Out()> ByRef pfd As WIN32_FIND_DATAW, ByVal fFlags As SLGP_FLAGS)

    Sub GetIDList(ByRef ppidl As IntPtr)

    Sub SetIDList(ByVal pidl As IntPtr)

    Sub GetDescription(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszName As StringBuilder, _
        ByVal cchMaxName As Integer)

    Sub SetDescription(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszName As String)

    Sub GetWorkingDirectory(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszDir As StringBuilder, _
        ByVal cchMaxPath As Integer)

    Sub SetWorkingDirectory(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszDir As String)

    Sub GetArguments(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszArgs As StringBuilder, _
        ByVal cchMaxPath As Integer)

    Sub SetArguments(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszArgs As String)

    Sub GetHotkey(ByRef pwHotkey As Short)

    Sub SetHotkey(ByVal wHotkey As Short)

    Sub GetShowCmd(ByRef piShowCmd As Integer)

    Sub SetShowCmd(ByVal iShowCmd As Integer)

    Sub GetIconLocation(<Out(), MarshalAs(UnmanagedType.LPWStr)> ByVal pszIconPath As StringBuilder, _
        ByVal cchIconPath As Integer, ByRef piIcon As Integer)

    Sub SetIconLocation(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszIconPath As String, _
        ByVal iIcon As Integer)

    Sub SetRelativePath(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszPathRel As String, _
        ByVal dwReserved As Integer)

    Sub Resolve(ByVal hwnd As IntPtr, ByVal fFlags As SLR_FLAGS)

    Sub SetPath(<MarshalAs(UnmanagedType.LPWStr)> ByVal pszFile As String)

End Interface

#End Region