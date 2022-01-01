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

Friend Class SpecialFolders
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As SpecialFolders

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As SpecialFolders
        If (panelInstance Is Nothing) Then
            panelInstance = New SpecialFolders()
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

    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try

            With ListViewFolders
                .Visible = False
                .Items.Clear()
                .SuspendLayout()
            End With

            With MainForm.ToolStripProgressBar1
                .Visible = True
                .Value = 0
                .Maximum = 23
            End With

            ' Create listview group.
            _ListViewGroup = ListViewFolders.Groups.Add("Special Folder", "Special Folders")

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.ApplicationData.ToString()
            ' Add the subitem.
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.ApplicationData))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.CommonApplicationData.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.CommonApplicationData))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.CommonProgramFiles.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.CommonProgramFiles))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Cookies.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Cookies))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Desktop.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Desktop))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.DesktopDirectory.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.DesktopDirectory))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Favorites.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Favorites))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.History.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.History))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.InternetCache.ToString()
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.InternetCache))

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.LocalApplicationData.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.LocalApplicationData))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.MyComputer.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.MyComputer))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.MyDocuments.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.MyDocuments))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.MyMusic.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.MyMusic))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.MyPictures.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.MyPictures))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Personal.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Personal))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.ProgramFiles.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.ProgramFiles))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Programs.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Programs))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Recent.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Recent))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.SendTo.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.SendTo))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.StartMenu.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.StartMenu))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Startup.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Startup))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.System.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.System))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

            ' Create a new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)
            ' Alternate back colors.
            _ListViewItem.BackColor = AlternateColors(ListViewFolders.Items.Count)
            ' Add the text.
            _ListViewItem.Text = SpecialFolder.Templates.ToString()
            _ListViewItem.SubItems.Add(GetFolderPath(SpecialFolder.Templates))
            ' Add item to the listview.
            ListViewFolders.Items.Add(_ListViewItem)
            ' Bump the progressbar.
            MainForm.ToolStripProgressBar1.Value += 1

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Special Folders panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

        MainForm.ToolStripProgressBar1.Visible = False

        ManagementInfo.ResizeListViewColumns(ListViewFolders, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewFolders
            .ResumeLayout()
            .Visible = True
        End With

    End Sub

    Private Shared Function AlternateColors(ByVal itemCount As Integer) As Color

        ' Alternate back color of items.
        If itemCount Mod 2 <> 0 Then
            Return Color.White
        Else
            Return Color.WhiteSmoke
        End If

    End Function

#End Region

#Region " Listview Event Handlers "

    Private Sub ListViewFolders_ItemSelectionChanged(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) _
        Handles ListViewFolders.ItemSelectionChanged

        If e.IsSelected Then

            ' Copy path to clipboard.
            Dim folder As String = ListViewFolders.Items(e.ItemIndex).SubItems(1).Text
            Clipboard.SetText(folder, TextDataFormat.Text)

        End If

    End Sub

#End Region

End Class
