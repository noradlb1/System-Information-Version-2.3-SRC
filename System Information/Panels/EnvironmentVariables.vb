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

Imports System.Environment
Imports System.Windows.Forms
Imports System.Collections
Imports System.Text
Imports System.IO

Friend Class EnvironmentVariables
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As EnvironmentVariables

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As EnvironmentVariables
        If (panelInstance Is Nothing) Then
            panelInstance = New EnvironmentVariables()
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

    Private ResourceManager As New  _
        System.Resources.ResourceManager("SystemInformation.Resources", GetType(Processes).Assembly)

#End Region

#Region " Constants and Variables "

    ' Boolean used to toggle listview sort.
    Private _SelectedIndex As Integer
    Private _Info As New ComputerInformation
    Private _ListViewItem As ListViewItem

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' Clear listview.
            With ListViewVariables
                .Visible = False
                .Items.Clear()
                .SuspendLayout()
            End With

            Dim lstViewgroup As ListViewGroup
            lstViewgroup = ListViewVariables.Groups.Add("Environment Variables", "Environment Variables")

            Dim envVariable As String() = Nothing

            ' Add all of the environment variable keys to the array.
            For i As Integer = 0 To GetEnvironmentVariables.Keys.Count - 1
                ReDim Preserve envVariable(i)
                envVariable(i) = GetEnvironmentVariables.Keys(i).ToString
            Next

            ' Sort the variables.
            Array.Sort(envVariable)

            ' Add all of the environment variables to the listview.
            For Each variable As String In envVariable
                _ListViewItem = New ListViewItem(lstViewgroup)

                ' Alternate back color of items.
                If (ListViewVariables.Items.Count Mod 2 <> 0) Then
                    _ListViewItem.BackColor = Color.White
                Else
                    _ListViewItem.BackColor = Color.WhiteSmoke
                End If


                _ListViewItem.Text = variable
                _ListViewItem.SubItems.Add(GetEnvironmentVariable(variable))

                _ListViewItem.ImageIndex = 0

                ListViewVariables.Items.Add(_ListViewItem)

            Next

            ManagementInfo.ResizeListViewColumns(ListViewVariables, ColumnHeaderAutoResizeStyle.HeaderSize)

            With ListViewVariables
                .ResumeLayout()
                .Visible = True
            End With

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Environment Variables panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Class
