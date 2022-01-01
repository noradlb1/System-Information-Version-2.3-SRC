'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'
' Copyright © 1997-2008 Herbert N. Swearengen III
' All Rights Reserved.
'
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Option Strict On
Option Explicit On
Option Infer Off
Option Compare Text

Imports System.IO
Imports System.ComponentModel

Friend Class PointingDevice
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared PanelInstance As PointingDevice

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As PointingDevice
        If (PanelInstance Is Nothing) Then
            PanelInstance = New PointingDevice()
        End If
        Return PanelInstance
    End Function

    ''' <summary>
    ''' Resize panel to fit containing control.
    ''' </summary>
    Public Shared Sub ResizePanel(ByVal hostControl As Control)
        If PanelInstance IsNot Nothing Then
            PanelInstance.Size = New Size(hostControl.Width, hostControl.Height)
        End If
    End Sub

#End Region

#Region " Private Members "

    Private _Info As New ComputerInformation

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        ListViewPointingDevice.Visible = False

        ManagementInfo.ManagementInfoToListView("Win32_PointingDevice", ListViewPointingDevice, True, 200, 400)

        If ListViewPointingDevice.Items.Count = 0 Then
            ManagementInfo.AddGroupForNoResults(ListViewPointingDevice, "Win32_PointingDevice", "No Results Returned")
        End If

        ManagementInfo.ResizeListViewColumns(ListViewPointingDevice, ColumnHeaderAutoResizeStyle.HeaderSize)

        ListViewPointingDevice.Visible = True

    End Sub

#End Region

End Class
