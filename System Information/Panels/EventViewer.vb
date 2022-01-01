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

Friend Class EventViewer
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As EventViewer

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As EventViewer
        If (panelInstance Is Nothing) Then
            panelInstance = New EventViewer()
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
    Private _ListViewItem As ListViewItem
    Private _ListViewGroup As ListViewGroup
    Private _MaxEntries As Integer
    Private _Error As Boolean
    Private _FailureAudit As Boolean
    Private _SuccessAudit As Boolean
    Private _Information As Boolean
    Private _Warning As Boolean
    Private _ApplicationLog As Boolean
    Private _SystemLog As Boolean = True    ' Preset system log.
    Private _SecurityLog As Boolean
    Private _Initialized As Boolean
    Private _Cancel As Boolean

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
        Handles Me.KeyUp

        ' Also cancel with Escape.
        If e.KeyValue = Keys.Escape Then
            ButtonCancel.PerformClick()
        End If

    End Sub

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        _Initialized = False

        ' Clear all checkboxes.
        For Each ctrl As Control In PanelTypeEvents.Controls
            Try
                Dim chkbox As CheckBox = DirectCast(ctrl, CheckBox)
                chkbox.Checked = False
            Catch ex As Exception
            End Try
        Next

        _Initialized = True

        ' Set default number of entries to 200.
        RadioButton200.PerformClick()

        ' Preset system event log.
        RadioButtonSystem.PerformClick()

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonRefresh.Click

        If _Initialized Then
            Dim eventLog As String = ""

            If _ApplicationLog = True Then
                eventLog = "ApplicationVi"
            ElseIf _SystemLog = True Then
                eventLog = "SystemVi"
            ElseIf _SecurityLog = True Then
                eventLog = "SecurityVi"
            Else
                eventLog = "SystemVi"
            End If

            If Not String.IsNullOrEmpty(eventLog) Then
                LoadEvents(eventLog)
            End If
        End If

    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonCancel.Click

        _Cancel = True

    End Sub

#End Region

#Region " CheckBox Event Handlers "

    Private Sub CheckBoxInformation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxInformation.CheckedChanged

        If CheckBoxInformation.Checked AndAlso _Initialized Then
            _Information = True
        Else
            _Information = False
        End If

    End Sub

    Private Sub CheckBoxWarning_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxWarning.CheckedChanged

        If CheckBoxWarning.Checked AndAlso _Initialized Then
            _Warning = True
        Else
            _Warning = False
        End If

    End Sub

    Private Sub CheckBoxError_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxError.CheckedChanged

        If CheckBoxError.Checked AndAlso _Initialized Then
            _Error = True
        Else
            _Error = False
        End If

    End Sub

    Private Sub CheckBoxFailureAudit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxFailureAudit.CheckedChanged

        If CheckBoxFailureAudit.Checked AndAlso _Initialized Then
            _FailureAudit = True
        Else
            _FailureAudit = False
        End If

    End Sub

    Private Sub CheckBoxSuccessAudit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles CheckBoxSuccessAudit.CheckedChanged

        If CheckBoxSuccessAudit.Checked AndAlso _Initialized Then
            _SuccessAudit = True
        Else
            _SuccessAudit = False
        End If

    End Sub

#End Region

#Region " ContextMenu Event Handlers "

    Private Sub ContextMenuShowDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuShowDetails.Click

        Dim message As String
        message = ListViewEventViewer.SelectedItems(0).SubItems(7).Text
        MessageBox.Show(message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub ContextMenuRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ContextMenuRefresh.Click

        ButtonRefresh.PerformClick()

    End Sub

#End Region

#Region " ListView Event Handlers "

    Private Sub ListViewEventViewer_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListViewEventViewer.ItemActivate


        Dim message As String
        message = ListViewEventViewer.SelectedItems(0).SubItems(7).Text
        MessageBox.Show(message, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

#End Region

#Region " NumericUpDown Event Handlers "

    Private Sub NumericUpDownEntries_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles NumericUpDownEntries.ValueChanged

        If RadioButtonSetNumber.Checked AndAlso _Initialized Then
            _MaxEntries = CInt(NumericUpDownEntries.Value)
        End If

    End Sub

#End Region

#Region " RadioButton Event Handlers "

    Private Sub RadioButton200_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButton200.CheckedChanged

        If RadioButton200.Checked AndAlso _Initialized Then
            _MaxEntries = 200
        End If

    End Sub

    Private Sub RadioButton400_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButton400.CheckedChanged

        If RadioButton400.Checked AndAlso _Initialized Then
            _MaxEntries = 400
        End If

    End Sub

    Private Sub RadioButton800_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButton800.CheckedChanged

        If RadioButton800.Checked AndAlso _Initialized Then
            _MaxEntries = 800
        End If

    End Sub

    Private Sub RadioButton1600_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButton1600.CheckedChanged

        If RadioButton1600.Checked AndAlso _Initialized Then
            _MaxEntries = 1600
        End If

    End Sub

    Private Sub RadioButtonSetNumber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonSetNumber.CheckedChanged

        If RadioButtonSetNumber.Checked AndAlso _Initialized Then
            _MaxEntries = CInt(NumericUpDownEntries.Value)
        End If

    End Sub

    Private Sub RadioButtonApplication_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonApplication.CheckedChanged


        If RadioButtonApplication.Checked AndAlso _Initialized Then
            _SecurityLog = False
            _ApplicationLog = True
            _SystemLog = False
            LabelFolders.Text = "Application Event Log, " & ReturnTotalEntries("Application")
            CheckBoxFailureAudit.Checked = False
            CheckBoxSuccessAudit.Checked = False
            CheckBoxInformation.Checked = True
            CheckBoxError.Checked = True
            CheckBoxInformation.Checked = True
            CheckBoxWarning.Checked = True
            ' Refresh the display.
            LoadEvents("ApplicationVi")
        End If

    End Sub

    Private Sub RadioButtonSecurity_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonSecurity.CheckedChanged

        If RadioButtonSecurity.Checked AndAlso _Initialized Then
            _SecurityLog = True
            _ApplicationLog = False
            _SystemLog = False
            LabelFolders.Text = "Security Event Log, " & ReturnTotalEntries("Security")
            CheckBoxFailureAudit.Checked = True
            CheckBoxSuccessAudit.Checked = True
            CheckBoxInformation.Checked = False
            CheckBoxError.Checked = False
            CheckBoxInformation.Checked = False
            CheckBoxWarning.Checked = False
            ' Refresh the display.
            LoadEvents("SecurityVi")
        End If

    End Sub

    Private Sub RadioButtonLogType_CheckChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonSystem.CheckedChanged

        If RadioButtonSystem.Checked AndAlso _Initialized Then
            _SecurityLog = False
            _ApplicationLog = False
            _SystemLog = True
            LabelFolders.Text = "System Event Log, " & ReturnTotalEntries("System")
            CheckBoxFailureAudit.Checked = False
            CheckBoxSuccessAudit.Checked = False
            CheckBoxInformation.Checked = True
            CheckBoxError.Checked = True
            CheckBoxInformation.Checked = True
            CheckBoxWarning.Checked = True
            ' Refresh the display.
            LoadEvents("SystemVi")
        End If

    End Sub

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Loading general informations about events.
    ''' </summary>
    Private Shared Function ReturnTotalEntries(ByVal logName As String) As String

        Dim eventLogs() As EventLog = EventLog.GetEventLogs
        Dim returnValue As String = "Unknown"

        For Each evntLog As EventLog In eventLogs
            If evntLog.LogDisplayName.Contains(logName) Then
                returnValue = evntLog.Entries.Count.ToString("#,#") & " total entries."
            End If
        Next

        Return returnValue

    End Function

    ''' <summary>
    ''' Load all events.
    ''' </summary>
    Private Sub LoadEvents(ByVal logName As String)

        Dim i As Integer
        Dim j As Integer
        Dim eventLogs() As EventLog = EventLog.GetEventLogs
        Dim evntLog As EventLog

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Value = 0
        End With

        With ListViewEventViewer
            .Visible = False
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Event Type", 100, HorizontalAlignment.Left)
            .Columns.Add("Generated On", 120, HorizontalAlignment.Left)
            .Columns.Add("Event Source", 120, HorizontalAlignment.Left)
            .Columns.Add("UserName", 100, HorizontalAlignment.Left)
            .Columns.Add("Category", 100, HorizontalAlignment.Left)
            .Columns.Add("Category Number", 100, HorizontalAlignment.Left)
            .Columns.Add("Event ID", 90, HorizontalAlignment.Left)
            .SuspendLayout()
        End With

        Application.DoEvents()

        Me.Refresh()

        ' Create a new listview group.
        _ListViewGroup = ListViewEventViewer.Groups.Add(logName.Replace("Vi", "") & " Event Log", _
                                                        logName.Replace("Vi", "") & " Event Log")

        Try
            For i = 0 To eventLogs.Length - 1

                evntLog = eventLogs(i)
                Dim info As String = evntLog.Log & "Vi"

                If info = logName Then

                    Dim entryCount As Integer = evntLog.Entries.Count

                    If _MaxEntries > 0 Then
                        MainForm.ToolStripProgressBar1.Maximum = _MaxEntries + 1
                    Else
                        MainForm.ToolStripProgressBar1.Maximum = entryCount
                    End If

                    ' Keep track of filtered entries.
                    Dim filteredEntry As Integer = 0

                    ' Add most recent entries first.
                    For j = (entryCount - 1) To 0 Step -1

                        ' Exit loop if _MaxEntries has been reached.
                        If filteredEntry = _MaxEntries Then
                            Exit For
                        End If

                        ' Get the EntryType of the current log entry.
                        Dim entryType As EventLogEntryType = evntLog.Entries.Item(j).EntryType

                        ' Create a new listviewitem.
                        _ListViewItem = New ListViewItem(_ListViewGroup)

                        If (_Error And entryType = EventLogEntryType.Error) Or _
                                (_FailureAudit And entryType = EventLogEntryType.FailureAudit) Or _
                                (_Information And entryType = EventLogEntryType.Information) Or _
                                (_SuccessAudit And entryType = EventLogEntryType.SuccessAudit) Or _
                                (_Warning And entryType = EventLogEntryType.Warning) Then

                            ' Bump the filtered entry counter and toolbar.
                            filteredEntry += 1
                            MainForm.ToolStripProgressBar1.Value += 1
                            Application.DoEvents()

                            ' Alternate back color of items.
                            If ListViewEventViewer.Items.Count Mod 2 <> 0 Then
                                _ListViewItem.BackColor = Color.White
                            Else
                                _ListViewItem.BackColor = Color.WhiteSmoke
                            End If

                            Try

                                ' Add the text for the item.
                                _ListViewItem.Text = evntLog.Entries.Item(j).EntryType.ToString

                                ' Set the image index.
                                Select Case evntLog.Entries.Item(j).EntryType
                                    Case EventLogEntryType.Information
                                        _ListViewItem.ImageIndex = 0
                                    Case EventLogEntryType.Warning
                                        _ListViewItem.ImageIndex = 1
                                    Case EventLogEntryType.Error
                                        _ListViewItem.ImageIndex = 2
                                    Case EventLogEntryType.SuccessAudit
                                        _ListViewItem.ImageIndex = 3
                                    Case EventLogEntryType.FailureAudit
                                        _ListViewItem.ImageIndex = 4
                                End Select

                            Catch ex As NullReferenceException
                                _ListViewItem.Text = "Error"
                            End Try

                            ' Add the subitems.
                            Try
                                Dim eventTime As Date = evntLog.Entries.Item(j).TimeGenerated
                                _ListViewItem.SubItems.Add(eventTime.ToShortDateString & " " & eventTime.ToShortTimeString)
                            Catch ex As NullReferenceException
                                _ListViewItem.SubItems.Add("")
                            End Try

                            Try
                                _ListViewItem.SubItems.Add(evntLog.Entries.Item(j).Source)
                            Catch ex As NullReferenceException
                                _ListViewItem.SubItems.Add("")
                            End Try

                            Try
                                _ListViewItem.SubItems.Add(evntLog.Entries.Item(j).UserName)
                            Catch ex As NullReferenceException
                                _ListViewItem.SubItems.Add("")
                            End Try

                            If evntLog.Entries.Item(j).Category.ToString = "(0)" Then
                                _ListViewItem.SubItems.Add("")
                            Else
                                Try
                                    _ListViewItem.SubItems.Add(evntLog.Entries.Item(j).Category.ToString)
                                Catch ex As NullReferenceException
                                    _ListViewItem.SubItems.Add("")
                                End Try
                            End If

                            Try
                                _ListViewItem.SubItems.Add(evntLog.Entries.Item(j).CategoryNumber.ToString)
                            Catch ex As NullReferenceException
                                _ListViewItem.SubItems.Add("")
                            End Try

                            Try
                                _ListViewItem.SubItems.Add(evntLog.Entries.Item(j).InstanceId.ToString)
                            Catch ex As NullReferenceException
                                _ListViewItem.SubItems.Add("")
                            End Try

                            Try
                                _ListViewItem.SubItems.Add(evntLog.Entries.Item(j).Message.ToString)
                            Catch ex As NullReferenceException
                                _ListViewItem.SubItems.Add("")
                            End Try

                            ' Add the item to the listview.
                            ListViewEventViewer.Items.Add(_ListViewItem)

                            ' Handle user cancel.
                            If _Cancel Then
                                _Cancel = False
                                With ListViewEventViewer
                                    .ResumeLayout()
                                    .Visible = True
                                End With
                                MainForm.ToolStripProgressBar1.Visible = False
                                ManagementInfo.ResizeListViewColumns(ListViewEventViewer, _
                                                                     ColumnHeaderAutoResizeStyle.HeaderSize)
                            End If

                        End If

                        Application.DoEvents()

                    Next
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading event log: " & ex.Message, My.Application.Info.Title, _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        With ListViewEventViewer
            ManagementInfo.ResizeListViewColumns(ListViewEventViewer, ColumnHeaderAutoResizeStyle.HeaderSize)
            .ResumeLayout()
            .Visible = True
        End With

        MainForm.ToolStripProgressBar1.Visible = False

    End Sub

#End Region

End Class
