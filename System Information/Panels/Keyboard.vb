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
Imports System.Management
Imports System.Collections
Imports System.Collections.Specialized
Imports System.Text.RegularExpressions

Friend Class Keyboard
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared PanelInstance As Keyboard

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Keyboard
        If (PanelInstance Is Nothing) Then
            PanelInstance = New Keyboard()
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

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        ListViewKeyboard.Visible = False

        ManagementInfo.ManagementInfoToListView("Win32_Keyboard", ListViewKeyboard, True, 200, 400, _
                                                MainForm.ToolStripProgressBar1)

        If ListViewKeyboard.Items.Count = 0 Then
            ManagementInfo.AddGroupForNoResults(ListViewKeyboard, "Win32_Keyboard", "No Results Returned")
        End If

        ManagementInfo.ResizeListViewColumns(ListViewKeyboard, ColumnHeaderAutoResizeStyle.HeaderSize)

        ListViewKeyboard.Visible = True

    End Sub

#End Region

End Class
