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
Imports System.Net
Imports System.Management

Friend Class Network
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As Network

    ''' <summary>
    ''' Create a global instance of this panel
    ''' </summary>>
    Public Shared Function CreateInstance() As Network
        If (panelInstance Is Nothing) Then
            panelInstance = New Network()
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
    Private _HostName As String
    Private _IpAddress() As String
    Private _Initialized As Boolean
    Private _AllAdaptors As New Collection(Of String)

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            _Initialized = False

            With MainForm.ToolStripProgressBar1
                .Style = ProgressBarStyle.Marquee
                .Visible = True
            End With

            ' Get Information
            _Info.Initialize(Initializer.GetNetAdaptorInfo)
            _Info.Initialize(Initializer.GetNetInterfaceInfo)

            ' Check if network is configured
            If _Info.NetNumberOfAdapters = 0 Then
                LabelNetworkID.Text = "No network Is configured on this computer."
                ListViewInterface.Enabled = False
                ListViewInterface.Visible = False
                Exit Sub
            Else
                If _Info.OSPartOfDomain = True Then
                    LabelNetworkID.Text = "Domain: " & _Info.OSDomain _
                        & " Computer: " & _Info.OSMachineName
                Else
                    LabelNetworkID.Text = "Workgroup: " & _Info.OSDomain _
                        & " Computer: " & _Info.OSMachineName
                End If

                ' Clear combobox.
                ComboBoxInterface.Items.Clear()

                ' Add interface descriptions.
                For i As Integer = 0 To _Info.NetNumberOfAdapters - 1
                    If CheckBoxHideInterfacesWithoutIPAddress.Checked Then

                        If _Info.NetIPAddress(i) IsNot Nothing Then
                            ComboBoxInterface.Items.Add(_Info.NetProductName(i))
                        End If
                    Else
                        ComboBoxInterface.Items.Add(_Info.NetProductName(i))
                    End If
                    ' Add all adaptors to a collection so that the index can be resolved from the combobox selection.
                    ' This is necessary since when adapters without ip addresses are filtered out then the index will be wrong.
                    _AllAdaptors.Add(_Info.NetProductName(i))
                Next

                ' Select first item.
                ComboBoxInterface.SelectedIndex = 0

                ' Get host name.
                _HostName = Net.Dns.GetHostName

                ' Get array of local IP addresses.
                Dim dimension As Integer = GetIpAddressList(_HostName).Length - 1
                ReDim _IpAddress(dimension)
                _IpAddress = GetIpAddressList(_HostName)

                ' Display general network information.
                GeneralNetworkInfo()

                _Initialized = True

                With MainForm.ToolStripProgressBar1
                    .Visible = False
                    .Style = ProgressBarStyle.Blocks
                End With

                RadioButtonGeneral.PerformClick()

            End If

        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Network panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Button Event Handlers "

    Private Sub ButtonRefreshNetwork_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonRefreshNetwork.Click

        If RadioButtonGeneral.Checked AndAlso _Initialized Then
            GeneralNetworkInfo()
        ElseIf RadioButtonConnections.Checked AndAlso _Initialized Then
            NetworkConnections()
        ElseIf RadioButtonModem.Checked AndAlso _Initialized Then
            POTSModemManagement()
        ElseIf RadioButtonNetworkAdapters.Checked AndAlso _Initialized Then
            GetNetworkAdapterInfo()
        End If

    End Sub

    Private Sub ButtonRefreshInterfaces_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles ButtonRefreshInterfaces.Click

        GetInterfaceInformation()

    End Sub

#End Region

#Region " ComboBox Event Handlers "

    Private Function TranslateIndex(ByVal productName As String) As Integer

        For i As Integer = 0 To _Info.NetProductName.Count - 1
            If productName = _Info.NetProductName(i) Then
                Return i
            End If
        Next

    End Function

    Private Sub ComboBoxInterface_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ComboBoxInterface.SelectedIndexChanged

        GetInterfaceInformation()

    End Sub

    Private Shared Function AlternateBackColor(ByVal count As Integer) As Color

        ' Alternate color of items.
        If count Mod 2 <> 0 Then
            Return Color.White
        Else
            Return Color.WhiteSmoke
        End If

    End Function

#End Region

#Region " RadioButton Event Handlers "

    Private Sub RadioButtonGeneral_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonGeneral.CheckedChanged

        If RadioButtonGeneral.Checked AndAlso _Initialized Then
            GeneralNetworkInfo()
        End If

    End Sub

    Private Sub RadioButtonConnections_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonConnections.CheckedChanged

        If RadioButtonConnections.Checked AndAlso _Initialized Then
            NetworkConnections()
        End If

    End Sub

    Private Sub RadioButtonModem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonModem.CheckedChanged

        If RadioButtonModem.Checked AndAlso _Initialized Then
            POTSModemManagement()
        End If

    End Sub

    Private Sub RadioButtonNetworkAdapters_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles RadioButtonNetworkAdapters.CheckedChanged

        If RadioButtonNetworkAdapters.Checked AndAlso _Initialized Then
            GetNetworkAdapterInfo()
        End If

    End Sub

#End Region

#Region " Networking Methods "

    Private Sub GetInterfaceInformation()

        Try

            Dim text As String = ComboBoxInterface.Text
            Dim i As Integer = TranslateIndex(text)
            Dim count As Integer = 0

            With ListViewInterface
                .Visible = False
                .SuspendLayout()
                .Items.Clear()
                .Columns.Clear()
                .Columns.Add("Item", 200)
                .Columns.Add("Value", 400)
            End With

            With MainForm.ToolStripProgressBar1
                .Visible = True
                .Value = 0
                .Maximum = 20 + _Info.NetIPAddress(i).Count
            End With

            ' Create new group.
            _ListViewGroup = ListViewInterface.Groups.Add("Interface Details", "Interface Details")

            If _Info.NetManufacturer.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "Manufacturer"
                    .SubItems.Add(_Info.NetManufacturer(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            ' Always increment the progress bar even it data is not available.
            MainForm.ToolStripProgressBar1.Value += 1

            If _Info.NetAdapterType.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "Adaptor Type"
                    .SubItems.Add(_Info.NetAdapterType.Item(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            ' Always increment the progress bar even it data is not available.
            MainForm.ToolStripProgressBar1.Value += 1

            If _Info.NetAutoSense.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "Auto Sense"
                    .SubItems.Add(_Info.NetAutoSense.Item(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            ' Always increment the progress bar even it data is not available.
            MainForm.ToolStripProgressBar1.Value += 1

            If _Info.NetMaxSpeed.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "Maximum Speed"
                    .SubItems.Add(_Info.NetMaxSpeed.Item(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            ' Always increment the progress bar even it data is not available.
            MainForm.ToolStripProgressBar1.Value += 1

            If _Info.NetSpeed.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "Speed"
                    .SubItems.Add(_Info.NetSpeed.Item(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            ' Always increment the progress bar even it data is not available.
            MainForm.ToolStripProgressBar1.Value += 1

            If _Info.NetConnectionId.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "Connection ID"
                    .SubItems.Add(_Info.NetConnectionId.Item(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            ' Always increment the progress bar even it data is not available.
            MainForm.ToolStripProgressBar1.Value += 1

            If _Info.NetConnectionStatus.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "Connection Status"
                    .SubItems.Add(_Info.NetConnectionStatus.Item(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            ' Always increment the progress bar even it data is not available.
            MainForm.ToolStripProgressBar1.Value += 1

            If _Info.NetMacAddress.Item(i) <> "N/A" Then

                _ListViewItem = New ListViewItem(_ListViewGroup)
                With _ListViewItem
                    .Text = "MAC Address"
                    .SubItems.Add(_Info.NetMacAddress.Item(i))
                    .BackColor = AlternateBackColor(count)
                End With
                ListViewInterface.Items.Add(_ListViewItem)
                count += 1

            End If

            If _Info.NetIPEnabled.Item(i) = True Then

                If _Info.NetIPAddress.Item(i) IsNot Nothing Then

                    ' Show all IP addresses including IPv6.
                    For j As Integer = 0 To _Info.NetIPAddress(i).Count - 1
                        _ListViewItem = New ListViewItem(_ListViewGroup)
                        With _ListViewItem
                            .Text = "IP Address"
                            .SubItems.Add(_Info.NetIPAddress(i)(j).ToUpper)
                            .BackColor = AlternateBackColor(count)
                        End With
                        ListViewInterface.Items.Add(_ListViewItem)
                        count += 1
                        ' Always increment the progress bar even it data is not available.
                        MainForm.ToolStripProgressBar1.Value += 1
                    Next
                End If

                If _Info.NetHostName.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "DNS Host Name"
                        .SubItems.Add(_Info.NetHostName.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

                If _Info.NetDomain.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "DNS Domain"
                        .SubItems.Add(_Info.NetDomain.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

                If _Info.NetTcpNumberConnections.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "Auto Sense"
                        .SubItems.Add(_Info.NetAutoSense.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                    ListViewInterface.Items.Add("Number of Connections: " & _Info.NetTcpNumberConnections.Item(i))

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

                If _Info.NetDefaultTimeToLive.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "Default Time-to-Live (TTL)"
                        .SubItems.Add(_Info.NetDefaultTimeToLive.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

                If _Info.NetMaximumTransmissionUnit.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "Maximum Transmission Unit (MTU)"
                        .SubItems.Add(_Info.NetMaximumTransmissionUnit.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

                If _Info.NetTcpWindowSize.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "TCP Window Size"
                        .SubItems.Add(_Info.NetTcpWindowSize.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

            Else

                _ListViewItem = New ListViewItem(_ListViewGroup)
                _ListViewItem.Text = "TCP/IP Is Not Installed"
                ListViewInterface.Items.Add(_ListViewItem)

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 9

            End If

            If _Info.NetDhcpEnabled.Item(i) = True Then

                If _Info.NetDhcpLeaseObtained.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "DHCP Lease Obtained"
                        .SubItems.Add(_Info.NetDhcpLeaseObtained.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

                If _Info.NetDhcpLeaseExpires.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "DHCP Lease Expires"
                        .SubItems.Add(_Info.NetDhcpLeaseExpires.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                End If

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 1

                If _Info.NetDhcpServer.Item(i) <> "N/A" Then

                    _ListViewItem = New ListViewItem(_ListViewGroup)
                    With _ListViewItem
                        .Text = "DHCP Server"
                        .SubItems.Add(_Info.NetDhcpServer.Item(i))
                        .BackColor = AlternateBackColor(count)
                    End With
                    ListViewInterface.Items.Add(_ListViewItem)
                    count += 1

                    ' Always increment the progress bar even it data is not available.
                    MainForm.ToolStripProgressBar1.Value += 1

                End If
            Else

                _ListViewItem = New ListViewItem(_ListViewGroup)
                _ListViewItem.Text = "DCHP Is Not Enabled"
                ListViewInterface.Items.Add(_ListViewItem)

                ' Always increment the progress bar even it data is not available.
                MainForm.ToolStripProgressBar1.Value += 4

            End If

        Catch ex As InvalidOperationException
        Catch ex As NullReferenceException
        Catch ex As ArgumentOutOfRangeException
            ' Ignore
        End Try

        MainForm.ToolStripProgressBar1.Visible = False

        ManagementInfo.ResizeListViewColumns(ListViewInterface, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewInterface
            .Visible = True
            .ResumeLayout()
        End With

    End Sub

    ''' <summary>
    ''' Loading informations about network connections.
    ''' </summary>
    Private Sub NetworkConnections()

        Try
            With ListViewNetwork
                .SuspendLayout()
                .Visible = False
                .Items.Clear()
                .Columns.Clear()
                .Columns.Add("Field", 200, HorizontalAlignment.Left)
                .Columns.Add("Value", 400, HorizontalAlignment.Left)
            End With

            With MainForm.ToolStripProgressBar1
                .Visible = True
                .Value = 0
                .Maximum = 5
            End With

            Dim i As Integer = 0

            ' Create listview group.
            _ListViewGroup = ListViewNetwork.Groups.Add("Network Connections", "Network Connections")

            Dim iconIndex As Integer

            If LanConnection() = True Then
                iconIndex = 1
            Else
                iconIndex = 0
            End If

            ' Create new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Alternate back color of items.
            If i Mod 2 <> 0 Then
                _ListViewItem.BackColor = Color.White
            Else
                _ListViewItem.BackColor = Color.WhiteSmoke
            End If

            ' Add the text for the item.
            _ListViewItem.Text = "Lan Connection"

            ' Add the image index.
            _ListViewItem.ImageIndex = iconIndex

            ' Add the subitems.
            _ListViewItem.SubItems.Add(LanConnection().ToString().Trim())

            ' Add the item to the listview.
            ListViewNetwork.Items.Add(_ListViewItem)

            i += 1
            MainForm.ToolStripProgressBar1.Value += 1

            If ModemConnection() = True Then
                iconIndex = 2
            Else
                iconIndex = 0
            End If

            ' Create new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Alternate back color of items.
            If i Mod 2 <> 0 Then
                _ListViewItem.BackColor = Color.White
            Else
                _ListViewItem.BackColor = Color.WhiteSmoke
            End If

            ' Add the text for the item.
            _ListViewItem.Text = "Modem Connection"

            ' Add the image index.
            _ListViewItem.ImageIndex = iconIndex

            ' Add the subitems.
            _ListViewItem.SubItems.Add(ModemConnection().ToString().Trim())

            ' Add the item to the listview.
            ListViewNetwork.Items.Add(_ListViewItem)

            i += 1
            MainForm.ToolStripProgressBar1.Value = i

            If InternetConnection() = True Then
                iconIndex = 3
            Else
                iconIndex = 0
            End If

            ' Create new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Alternate back color of items.
            If i Mod 2 <> 0 Then
                _ListViewItem.BackColor = Color.White
            Else
                _ListViewItem.BackColor = Color.WhiteSmoke
            End If

            ' Add the text for the item.
            _ListViewItem.Text = "Internet Connection"

            ' Add the image index.
            _ListViewItem.ImageIndex = iconIndex

            ' Add the subitems.
            _ListViewItem.SubItems.Add(InternetConnection().ToString().Trim())

            ' Add the item to the listview.
            ListViewNetwork.Items.Add(_ListViewItem)

            i += 1
            MainForm.ToolStripProgressBar1.Value += 1

            If ProxyConnection() = True Then
                iconIndex = 4
            Else
                iconIndex = 0
            End If

            ' Create new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Add text for the item.
            _ListViewItem.Text = "Proxy Connection"

            ' Add image index.
            _ListViewItem.ImageIndex = iconIndex

            ' Add subitems.
            _ListViewItem.SubItems.Add(ProxyConnection().ToString().Trim())

            ' Add the item to the listview.
            ListViewNetwork.Items.Add(_ListViewItem)

            i += 1
            MainForm.ToolStripProgressBar1.Value += 1

            If RasInstalled() Then
                iconIndex = 5
            Else
                iconIndex = 0
            End If

            ' Create new listview item.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Alternate back color of items.
            If i Mod 2 <> 0 Then
                _ListViewItem.BackColor = Color.White
            Else
                _ListViewItem.BackColor = Color.WhiteSmoke
            End If

            ' Add the text for the item.
            _ListViewItem.Text = "Remote Access Service"

            ' Add the image index.
            _ListViewItem.ImageIndex = iconIndex

            ' Add the subitems.
            If RasInstalled() = True Then
                _ListViewItem.SubItems.Add("Installed")
            Else
                _ListViewItem.SubItems.Add("Not Installed")
            End If

            ' Add the item to the listview.
            ListViewNetwork.Items.Add(_ListViewItem)

            With MainForm.ToolStripProgressBar1
                .Value += 1
                .Visible = False
            End With
        Catch ex As InvalidOperationException
        Catch ex As NullReferenceException
        Catch ex As ArgumentOutOfRangeException
            ' Ignore
        Finally
            MainForm.ToolStripProgressBar1.Visible = False

            ManagementInfo.ResizeListViewColumns(ListViewNetwork, ColumnHeaderAutoResizeStyle.HeaderSize)

            With ListViewNetwork
                .Visible = True
                .ResumeLayout()
            End With

        End Try

    End Sub

    ''' <summary>
    ''' Loading general network informations.
    ''' </summary>
    Private Sub GeneralNetworkInfo()

        Try
            With ListViewNetwork
                .SuspendLayout()
                .Visible = False
                .Items.Clear()
                .Columns.Clear()
                .Columns.Add("Field", 200, HorizontalAlignment.Left)
                .Columns.Add("Value", 400, HorizontalAlignment.Left)
            End With

            With MainForm.ToolStripProgressBar1
                .Visible = True
                .Value = 0
                .Maximum = 7
            End With

            Dim i As Integer = 0

            ' Create listview group.
            _ListViewGroup = ListViewNetwork.Groups.Add("General Information", "General Information")

            ' Associate the listviewitem with the group.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Alternate back color of items.
            If i Mod 2 <> 0 Then
                _ListViewItem.BackColor = Color.White
            Else
                _ListViewItem.BackColor = Color.WhiteSmoke
            End If

            ' Add the text for the item.
            _ListViewItem.Text = "Network Connection"

            ' Add the image index for the item.
            _ListViewItem.ImageIndex = 1

            ' Add the subitems.
            _ListViewItem.SubItems.Add(System.Windows.Forms.SystemInformation.Network.ToString().Trim())

            ' Add the item to the listview.
            ListViewNetwork.Items.Add(_ListViewItem)

            i += 1
            MainForm.ToolStripProgressBar1.Value += 1

            ' Associate the listviewitem with the group.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Alternate back color of items.
            If i Mod 2 <> 0 Then
                _ListViewItem.BackColor = Color.White
            Else
                _ListViewItem.BackColor = Color.WhiteSmoke
            End If

            ' Add the text to the item.
            _ListViewItem.Text = "Host Name"

            ' Add the image index to the item.
            _ListViewItem.ImageIndex = 1

            ' Add the subitems.
            _ListViewItem.SubItems.Add(_HostName.Trim())

            ' Add the item to the listview.
            ListViewNetwork.Items.Add(_ListViewItem)

            i += 1
            MainForm.ToolStripProgressBar1.Value += 1

            ' Associate the listviewitem with the group.
            _ListViewItem = New ListViewItem(_ListViewGroup)

            ' Alternate back color of items.
            If i Mod 2 <> 0 Then
                _ListViewItem.BackColor = Color.White
            Else
                _ListViewItem.BackColor = Color.WhiteSmoke
            End If

            For Each ip As String In _IpAddress

                ' Associate the listviewitem with the group.
                _ListViewItem = New ListViewItem(_ListViewGroup)

                ' Alternate back color of items.
                If i Mod 2 <> 0 Then
                    _ListViewItem.BackColor = Color.White
                Else
                    _ListViewItem.BackColor = Color.WhiteSmoke
                End If

                ' Add the text to the item
                _ListViewItem.Text = "Local IP Address"

                ' Add the image index to the item.
                _ListViewItem.ImageIndex = 1

                ' Add the subitem.
                _ListViewItem.SubItems.Add(FormatIPv6Address(ip))

                ' Add the item to the listview.
                ListViewNetwork.Items.Add(_ListViewItem)

                i += 1

            Next

            MainForm.ToolStripProgressBar1.Value += 1

        Catch ex As NullReferenceException
        Catch ex As ArgumentOutOfRangeException
            ' Ignore
        End Try

        MainForm.ToolStripProgressBar1.Visible = False

        ManagementInfo.ResizeListViewColumns(ListViewNetwork, ColumnHeaderAutoResizeStyle.HeaderSize)

        ' debug - There's a bug here that I haven't been able to solve. Eventhough column 1 is set to
        ' a width of 400 and the displayed text is not long, the above method always resizes column 1
        ' to 508 pixels. This makes a horizontal scroll bar appear. Maybe this has something to do
        ' with the characters in IP addresses. I don't know. So the line below is a kludge to fix this.
        If ListViewNetwork.Columns(0).Width + ListViewNetwork.Columns(1).Width > ListViewNetwork.Width - 25 Then
            ListViewNetwork.Columns(1).Width = ListViewNetwork.Width - 25 - ListViewNetwork.Columns(0).Width
        End If

        With ListViewNetwork
            .Visible = True
            .ResumeLayout()
        End With

    End Sub

    ''' <summary>
    ''' Loading informations from management.
    ''' </summary>
    Private Sub POTSModemManagement()

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Value = 0
            .Maximum = 4
        End With

        With ListViewNetwork
            .SuspendLayout()
            .Visible = False
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Field", 200, HorizontalAlignment.Left)
            .Columns.Add("Value", 400, HorizontalAlignment.Left)
        End With

        Dim i As Integer = 0

        Dim manClass As New ManagementClass("Win32_POTSModem")
        Dim manObjCol As ManagementObjectCollection = manClass.GetInstances()
        Dim manObjEnumerator As ManagementObjectCollection.ManagementObjectEnumerator = manObjCol.GetEnumerator

        ' Create listview group.
        _ListViewGroup = ListViewNetwork.Groups.Add("Modems", "Modems")

        manObjEnumerator.MoveNext()

        Try
            With manObjEnumerator.Current

                ' Create new listview item.
                _ListViewItem = New ListViewItem(_ListViewGroup)

                ' Alternate back color of items.
                If i Mod 2 <> 0 Then
                    _ListViewItem.BackColor = Color.White
                Else
                    _ListViewItem.BackColor = Color.WhiteSmoke
                End If

                ' Add text for the item.
                _ListViewItem.Text = "Modem"

                ' Add image index for the item.
                _ListViewItem.ImageIndex = 2

                ' Add subitems.
                If .Properties("Description").Value.ToString.Length > 100 Then
                    _ListViewItem.SubItems.Add((.Properties("Description").Value.ToString()).Substring(0, 100))
                Else
                    _ListViewItem.SubItems.Add(.Properties("Description").Value.ToString)
                End If

                ' Add the item to the listview.
                ListViewNetwork.Items.Add(_ListViewItem)

                ' Bump the item counter.
                i += 1

                MainForm.ToolStripProgressBar1.Value += 1

                ' Create new listview item.
                _ListViewItem = New ListViewItem(_ListViewGroup)

                ' Alternate back color of items.
                If i Mod 2 <> 0 Then
                    _ListViewItem.BackColor = Color.White
                Else
                    _ListViewItem.BackColor = Color.WhiteSmoke
                End If

                ' Add text for the item.
                _ListViewItem.Text = "Modem ID"

                ' Add image index for the item.
                _ListViewItem.ImageIndex = 2

                ' Add the subitem.
                _ListViewItem.SubItems.Add(Convert.ToInt32(.Properties("index").Value.ToString()).ToString)

                ' Add the item to the listview.
                ListViewNetwork.Items.Add(_ListViewItem)

                ' Bump the item counter.
                i += 1

                MainForm.ToolStripProgressBar1.Value += 1

                ' Create new listview item.
                _ListViewItem = New ListViewItem(_ListViewGroup)

                ' Alternate back color of items.
                If i Mod 2 <> 0 Then
                    _ListViewItem.BackColor = Color.White
                Else
                    _ListViewItem.BackColor = Color.WhiteSmoke
                End If

                ' Add text for the item.
                _ListViewItem.Text = "Modem Port"

                ' Add image index for the item.
                _ListViewItem.ImageIndex = 2

                ' Add the subitems.
                If .Properties("AttachedTo").Value.ToString().Length > 50 Then
                    _ListViewItem.SubItems.Add((.Properties("AttachedTo").Value.ToString()).Substring(0, 50))
                Else
                    _ListViewItem.SubItems.Add(.Properties("AttachedTo").Value.ToString())
                End If

                ' Add the item to the listview.
                ListViewNetwork.Items.Add(_ListViewItem)

                MainForm.ToolStripProgressBar1.Value += 1

                ' Create new listview item.
                _ListViewItem = New ListViewItem(_ListViewGroup)

                ' Alternate back color of items.
                If i Mod 2 <> 0 Then
                    _ListViewItem.BackColor = Color.White
                Else
                    _ListViewItem.BackColor = Color.WhiteSmoke
                End If

                ' Add text for the item.
                _ListViewItem.Text = "Modem Type"

                ' Add image index for the item.
                _ListViewItem.ImageIndex = 2

                ' Add the sub items.
                If .Properties("DeviceID").Value.ToString().Length > 50 Then
                    _ListViewItem.SubItems.Add((.Properties("DeviceID").Value.ToString()).Substring(0, 50))
                Else
                    _ListViewItem.SubItems.Add(.Properties("DeviceID").Value.ToString())
                End If

                ' Add the item to the listview.
                ListViewNetwork.Items.Add(_ListViewItem)

                ' Bump the item counter.
                i += 1

                MainForm.ToolStripProgressBar1.Value += 1

            End With
        Catch ex As InvalidOperationException
        Catch ex As NullReferenceException
        Catch ex As ArgumentOutOfRangeException
        End Try

        ' Indicate if there are no modems.
        If ListViewNetwork.Items.Count = 0 Then
            _ListViewItem = New ListViewItem(_ListViewGroup)
            _ListViewItem.Text = "No Modems Detected"
            _ListViewItem.ImageIndex = 0
            ListViewNetwork.Items.Add(_ListViewItem)
        End If

        MainForm.ToolStripProgressBar1.Visible = False

        ManagementInfo.ResizeListViewColumns(ListViewNetwork, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewNetwork
            .Visible = True
            .ResumeLayout()
        End With

    End Sub

    ''' <summary>
    ''' Loading informations from management.
    ''' </summary>
    Private Sub GetNetworkAdapterInfo()

        With MainForm.ToolStripProgressBar1
            .Visible = True
            .Value = 0
        End With

        Dim i As Integer = 0

        Dim manObj As ManagementObject
        Dim manClass As New ManagementClass("Win32_NetworkAdapter")
        Dim manObjCol As ManagementObjectCollection = manClass.GetInstances()
        Dim manObjEnumerator As ManagementObjectCollection.ManagementObjectEnumerator = manObjCol.GetEnumerator

        manObjEnumerator.MoveNext()

        With ListViewNetwork
            .SuspendLayout()
            .Visible = False
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Name", 240, HorizontalAlignment.Left)
            .Columns.Add("Manufacturer", 100, HorizontalAlignment.Left)
            .Columns.Add("Adapter ID", 70, HorizontalAlignment.Left)
            .Columns.Add("Description", 220, HorizontalAlignment.Left)
            .Columns.Add("MACAddress", 100, HorizontalAlignment.Left)
        End With

        MainForm.ToolStripProgressBar1.Maximum = manObjCol.Count

        ' Create listview group.
        _ListViewGroup = ListViewNetwork.Groups.Add("Network Adaptors", "Network Adaptors")

        For Each manObj In manObjCol
            Try
                ' Increment progress bar even if some adapters are not displayed.
                MainForm.ToolStripProgressBar1.Value += 1

                ' If checkbox is checked, don't display adaptors without mac addresses.
                If (CheckBoxHideNetworkAdaptorsWithoutMACAddress.Checked _
                    And Not String.IsNullOrEmpty(manObj("MACAddress").ToString)) _
                    OrElse CheckBoxHideNetworkAdaptorsWithoutMACAddress.Checked = False Then

                    ' Create new listview item.
                    _ListViewItem = New ListViewItem(_ListViewGroup)

                    ' Alternate back color of items.
                    If i Mod 2 <> 0 Then
                        _ListViewItem.BackColor = Color.White
                    Else
                        _ListViewItem.BackColor = Color.WhiteSmoke
                    End If

                    ' Add text for the item.
                    _ListViewItem.Text = manObj("Name").ToString

                    ' Add image index for the item.
                    _ListViewItem.ImageIndex = 6

                    ' Add subitems.
                    If manObj("Manufacturer").ToString = "" Then
                        _ListViewItem.SubItems.Add("")
                    Else
                        _ListViewItem.SubItems.Add(manObj("Manufacturer").ToString)
                    End If

                    _ListViewItem.SubItems.Add(Convert.ToInt32(manObj("index").ToString).ToString)

                    _ListViewItem.SubItems.Add(manObj("Description").ToString)

                    If manObj("MACAddress").ToString.Length > 50 Then
                        _ListViewItem.SubItems.Add((manObj("MACAddress").ToString).Substring(0, 50))
                    Else
                        _ListViewItem.SubItems.Add(manObj("MACAddress").ToString)
                    End If

                    ' Bump the item counter.
                    i += 1

                    ' Add the item to the listview.
                    ListViewNetwork.Items.Add(_ListViewItem)

                End If
            Catch ex As InvalidOperationException
            Catch ex As NullReferenceException
            Catch ex As ArgumentOutOfRangeException
            End Try
        Next

        ' Indicate if there are no network adaptors.
        If ListViewNetwork.Items.Count = 0 Then
            _ListViewItem.Text = "No Network Adaptors Detected."
            ListViewNetwork.Items.Add(_ListViewItem)
        End If

        MainForm.ToolStripProgressBar1.Visible = False

        ManagementInfo.ResizeListViewColumns(ListViewNetwork, ColumnHeaderAutoResizeStyle.HeaderSize)

        With ListViewNetwork
            .Visible = True
            .ResumeLayout()
        End With

    End Sub

#End Region

#Region " Private Functions "

    ''' <summary>
    ''' Checks for lan connection.
    ''' </summary>
    Private Shared Function LanConnection() As Boolean

        Dim factor As Integer = &H2S
        Dim flags As Integer
        If CBool(NetworkNativeMethods.InternetGetConnectedState(flags, 0)) = True Then
            LanConnection = CBool(flags And factor)
        End If

    End Function

    ''' <summary>
    ''' Checks for modem connection.
    ''' </summary>
    Private Shared Function ModemConnection() As Boolean

        Dim flags As Integer
        If CBool(NetworkNativeMethods.InternetGetConnectedState(flags, 0)) = True Then
            ModemConnection = CBool(flags And CInt(ModemConnection))
        End If

    End Function

    ''' <summary>
    ''' Checks for internet connection.
    ''' </summary>
    Private Shared Function InternetConnection() As Boolean

        InternetConnection = CBool(NetworkNativeMethods.InternetGetConnectedState(0, 0))

    End Function

    ''' <summary>
    ''' Checks for proxy connection.
    ''' </summary>
    Private Shared Function ProxyConnection() As Boolean

        Dim factor As Integer = &H4S
        Dim flags As Integer
        If CBool(NetworkNativeMethods.InternetGetConnectedState(flags, 0)) = True Then
            ProxyConnection = CBool(flags And factor)
        End If

    End Function

    ''' <summary>
    ''' Checks for remote access services.
    ''' </summary>
    Private Shared Function RasInstalled() As Boolean

        Dim factor As Integer = &H10S
        Dim flags As Integer
        If CBool(NetworkNativeMethods.InternetGetConnectedState(flags, 0)) = True Then
            RasInstalled = CBool(flags And factor)
        End If

    End Function

    ''' <summary>
    ''' Returns all local IP addresses, both V4 and V6 as a string array.
    ''' </summary>
    Private Shared Function GetIpAddressList(ByVal hostName As String) As String()

        Dim hostInfo As IPHostEntry = Dns.GetHostEntry(hostName)
        Dim addressListLength As Integer = hostInfo.AddressList.Length - 1
        Dim returnValue(addressListLength) As String

        For i As Integer = 0 To hostInfo.AddressList.Length - 1
            returnValue(i) = hostInfo.AddressList(i).ToString
        Next

        Return returnValue

    End Function

    ''' <summary>
    ''' Formats an IPv6 address by converting to upper case, if necessary.
    ''' Also removes "%" and extraneous number from Net.Dns.GetHostEntry.AddressList.
    ''' </summary>
    Private Shared Function FormatIPv6Address(ByVal ipAddress As String) As String

        Dim trimChars() As Char = {}

        For i As Integer = 0 To 32
            ReDim Preserve trimChars(i)
            trimChars(i) = Chr(i)
        Next

        For i As Integer = 127 To 255
            ReDim Preserve trimChars(i)
            trimChars(i) = Chr(i)
        Next


        If Not String.IsNullOrEmpty(ipAddress) Then
            Dim percentLocation As Integer = ipAddress.LastIndexOf("%")
            If percentLocation > 0 Then
                Return ipAddress.Substring(0, percentLocation).ToUpper
            Else

                Return ipAddress.ToUpper.Trim(trimChars)
            End If
        Else
            Return ""
        End If

    End Function

#End Region

End Class

#Region " Native Methods Class "

Friend Class NetworkNativeMethods

    Private Sub New()
        ' Private constructor.
    End Sub

    Friend Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef lpdwFlags As Integer, _
                                                                         ByVal dwReserved As Integer) As Integer

End Class

#End Region
