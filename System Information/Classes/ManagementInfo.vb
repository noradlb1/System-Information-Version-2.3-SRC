Imports System.Management
Imports System.Collections.Specialized

Public NotInheritable Class ManagementInfo

#Region " Private Members "

    Private Shared _Cancel As Boolean

#End Region

#Region " Constructor "

    Private Sub New()
        ' Just for the compiler.
    End Sub

#End Region

#Region " Split Camel Case "

    ''' <summary>
    ''' Parses a camel cased or pascal cased string and returns a new
    ''' string with spaces between the words in the string.
    ''' </summary>
    ''' <example>
    ''' The string "PascalCasing" will return an array with two
    ''' elements, "Pascal" and "Casing".
    ''' </example>
    Public Shared Function SplitUppercaseToString(ByVal source As String) As String

        Return String.Join(" ", SplitUppercase(source)).Trim()

    End Function

    ''' <summary>
    ''' Parses a camel cased or pascal cased string and returns an array
    ''' of the words within the string.
    ''' </summary>
    ''' <example>
    ''' The string "PascalCasing" will return an array with two
    ''' elements, "Pascal" and "Casing".
    ''' </example>
    Public Shared Function SplitUppercase(ByVal source As String) As String()

        Try
            If String.IsNullOrEmpty(source) Then
                Return New String() {} ' Return empty array.
            End If

            If source.Length = 0 Then
                Return New String() {""}
            End If

            Dim words As StringCollection = New StringCollection()
            Dim wordStartIndex As Integer = 0

            Dim letters As Char() = source.ToCharArray()

            '  Skip the first letter. we don't care what case it is.
            For i As Integer = 1 To letters.Length - 1                 ' (int i = 1; i < letters.Length; i++)

                ' This modification allows abbreviation to be output correctly. ie., "PNP" not "P N P"
                If Char.IsUpper(letters(i)) AndAlso i + 1 < letters.Length _
                    AndAlso Not Char.IsUpper(letters(i + 1)) Then
                    ' Grab everything before the current index.
                    words.Add(New String(letters, wordStartIndex, i - wordStartIndex))
                    wordStartIndex = i
                End If
            Next

            ' We need to have the last word.
            words.Add(New String(letters, wordStartIndex, letters.Length - wordStartIndex))

            ' Copy to a string array.
            Dim wordArray As String() = New String(words.Count) {}
            words.CopyTo(wordArray, 0)

            Return wordArray
        Catch ex As Exception
            Return New String() {""}
        End Try

    End Function

#End Region

#Region " Management to ListView "

    ''' <summary>
    ''' Adds formatted Management information to a listview given the class name.
    ''' </summary>
    ''' <param name="win32Class">Name of System.Management Win32 Class</param>
    ''' <param name="listView">Name of ListView</param>
    ''' <param name="skipEmptyValues">If true empty values are not displayed.</param>
    ''' <param name="firstColumnHeaderWidth">Width of "Name" ListView column</param>
    ''' <param name="secondColumnHeaderWidth">Width of "Value" ListView column</param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")> _
    Public Shared Sub ManagementInfoToListView(ByVal win32Class As String, ByRef listView As ListView, _
                                                      ByVal skipEmptyValues As Boolean, _
                                                      ByVal firstColumnHeaderWidth As Integer, _
                                                      ByVal secondColumnHeaderWidth As Integer)
        With listView
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Name", firstColumnHeaderWidth)
            .Columns.Add("Value", secondColumnHeaderWidth)
            .SuspendLayout()
        End With

        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("select * from " & win32Class)

        Try

            For Each share As ManagementObject In searcher.Get()

                Application.DoEvents()

                Dim lstViewgroup As ListViewGroup

                Try
                    lstViewgroup = listView.Groups.Add(share("Name").ToString(), share("Name").ToString())
                Catch
                    lstViewgroup = listView.Groups.Add(share.ToString(), share.ToString())
                End Try

                If share.Properties.Count <= 0 Then
                    MessageBox.Show("No Information Available", "No Info", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information)
                    Return
                End If

                For Each propData As PropertyData In share.Properties

                    Try
                        Dim item As ListViewItem = New ListViewItem(lstViewgroup)

                        If (listView.Items.Count Mod 2 <> 0) Then
                            item.BackColor = Color.White
                        Else
                            item.BackColor = Color.WhiteSmoke
                        End If

                        ' Convert pascal case item names to regular text.
                        item.Text = SplitUppercaseToString(propData.Name)

                        If propData.Value IsNot Nothing And Not String.IsNullOrEmpty(propData.Value.ToString()) Then

                            Select Case propData.Value.GetType().ToString()

                                Case "System.String()"
                                    Dim strValues As String() = CType(propData.Value, String())

                                    Dim str2 As String = ""
                                    For Each st As String In strValues
                                        str2 &= st & " "
                                    Next

                                    item.SubItems.Add(str2)

                                Case "System.UInt16()"
                                    Dim shortData As UShort() = CType(propData.Value, UShort())

                                    Dim tstr2 As String = ""
                                    For Each st As UShort In shortData
                                        tstr2 &= st.ToString() & " "
                                    Next

                                    item.SubItems.Add(tstr2)

                                Case Else
                                    item.SubItems.Add(propData.Value.ToString())
                            End Select
                        Else
                            If Not skipEmptyValues Then
                                item.SubItems.Add("No Information available")
                            Else
                                Continue For
                            End If
                        End If

                        listView.Items.Add(item)
                    Catch ex As NullReferenceException
                    End Try

                    Application.DoEvents()

                    ' User has requested a cancel.
                    If _Cancel Then
                        _Cancel = False
                        listView.ResumeLayout()
                        Exit Try
                    End If
                    Application.DoEvents()

                Next

                ' User has requested a cancel.
                If _Cancel Then
                    _Cancel = False
                    listView.ResumeLayout()
                    Exit Try
                End If
                Application.DoEvents()

            Next


        Catch exp As Exception
            MessageBox.Show("Can't get data because of the followeing error: " & vbCrLf & exp.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally
            listView.ResumeLayout()
        End Try

    End Sub

    ''' <summary>
    ''' Adds formatted Management information to a listview given the class name.
    ''' This overload adds support for a tool strip progress bar.
    ''' </summary>
    ''' <param name="win32Class">Name of System.Management Win32 Class</param>
    ''' <param name="listView">Name of ListView</param>
    ''' <param name="skipEmptyValues">If true empty values are not displayed.</param>
    ''' <param name="firstColumnHeaderWidth">Width of "Name" ListView column</param>
    ''' <param name="secondColumnHeaderWidth">Width of "Value" ListView column</param>
    ''' <param name="progressBar">Name of ProgressBar</param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")> _
    Public Shared Sub ManagementInfoToListView(ByVal win32Class As String, ByRef listView As ListView, _
                                                      ByVal skipEmptyValues As Boolean, _
                                                      ByVal firstColumnHeaderWidth As Integer, _
                                                      ByVal secondColumnHeaderWidth As Integer, _
                                                      ByRef progressBar As ToolStripProgressBar)
        With listView
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Name", firstColumnHeaderWidth)
            .Columns.Add("Value", secondColumnHeaderWidth)
            .SuspendLayout()
        End With

        Dim searcher As ManagementObjectSearcher = New ManagementObjectSearcher("select * from " & win32Class)

        Try
            Dim maxCount As Integer

            progressBar.Value = 0

            For Each share As ManagementObject In searcher.Get
                Application.DoEvents()

                ' User has requested a cancel.
                If _Cancel Then
                    _Cancel = False
                    listView.ResumeLayout()
                    Exit Try
                End If
                Application.DoEvents()

                ' Calculate progressbar maximum.
                For Each propData As PropertyData In share.Properties
                    maxCount += 1

                    Application.DoEvents()

                    ' User has requested a cancel.
                    If _Cancel Then
                        _Cancel = False
                        listView.ResumeLayout()
                        Exit Try
                    End If
                    Application.DoEvents()

                Next
            Next

            With progressBar
                .Visible = True
                .Value = 0
                .Maximum = maxCount
            End With

            For Each share As ManagementObject In searcher.Get()

                Dim lstViewgroup As ListViewGroup

                Try
                    lstViewgroup = listView.Groups.Add(share("Name").ToString(), share("Name").ToString())
                Catch
                    lstViewgroup = listView.Groups.Add(share.ToString(), share.ToString())
                End Try

                If share.Properties.Count <= 0 Then
                    MessageBox.Show("No Information Available", "No Info", MessageBoxButtons.OK, _
                                    MessageBoxIcon.Information)
                    Return
                End If

                For Each propData As PropertyData In share.Properties

                    Try
                        ' Bump the progress bar.
                        progressBar.Value += 1

                        Dim item As ListViewItem = New ListViewItem(lstViewgroup)

                        If (listView.Items.Count Mod 2 <> 0) Then
                            item.BackColor = Color.White
                        Else
                            item.BackColor = Color.WhiteSmoke
                        End If

                        ' Convert pascal case item names to regular text.
                        item.Text = SplitUppercaseToString(propData.Name)

                        If propData.Value IsNot Nothing And Not String.IsNullOrEmpty(propData.Value.ToString()) Then

                            Select Case propData.Value.GetType().ToString()

                                Case "System.String()"
                                    Dim strValues As String() = CType(propData.Value, String())

                                    Dim str2 As String = ""
                                    For Each st As String In strValues
                                        str2 &= st & " "
                                    Next

                                    item.SubItems.Add(str2)

                                Case "System.UInt16()"
                                    Dim shortData As UShort() = CType(propData.Value, UShort())

                                    Dim tstr2 As String = ""
                                    For Each st As UShort In shortData
                                        tstr2 &= st.ToString() & " "
                                    Next

                                    item.SubItems.Add(tstr2)

                                Case Else
                                    item.SubItems.Add(propData.Value.ToString())
                            End Select
                        Else
                            If Not skipEmptyValues Then
                                item.SubItems.Add("No Information available")
                            Else
                                Continue For
                            End If
                        End If

                        listView.Items.Add(item)
                    Catch ex As NullReferenceException
                    End Try

                    Application.DoEvents()

                    ' User has requested a cancel.
                    If _Cancel Then
                        _Cancel = False
                        listView.ResumeLayout()
                        progressBar.Visible = False
                        Exit Try
                    End If

                Next

                ' User has requested a cancel.
                If _Cancel Then
                    _Cancel = False
                    listView.ResumeLayout()
                    Exit Try
                End If
                Application.DoEvents()

            Next

        Catch exp As Exception
            MessageBox.Show("Can't get data because of the followeing error: " & vbCrLf & exp.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Finally
            listView.ResumeLayout()
            progressBar.Visible = False
        End Try

    End Sub

    ''' <summary>
    ''' Cancels a WMI information gathering method at the end of the next iteration.
    ''' </summary>
    Public Shared Sub Cancel()

        _Cancel = True

    End Sub

    Private Shared Sub RemoveNullValue(ByRef lst As ListView)

        For Each item As ListViewItem In lst.Items
            If item.SubItems(1).Text = "No Information available" Then
                item.Remove()
            End If
        Next

    End Sub

    ''' <summary>
    ''' Adds a group and item to a listview when a Win32 class search returns no results.
    ''' The text of the group will be "Returned" and the text of the item will be "No Results Returned."
    ''' </summary>
    ''' <param name="referenceListView">Referenced ListView</param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")> _
    Public Shared Sub AddGroupForNoResults(ByRef referenceListView As ListView)

        Dim myListViewGroup As ListViewGroup = referenceListView.Groups.Add("Results", "Results")

        Dim myListViewItem As ListViewItem = New ListViewItem(myListViewGroup)

        myListViewItem.Text = "No Results Returned"

        referenceListView.Items.Add(myListViewItem)

    End Sub

    ''' <summary>
    ''' Adds a group and item to a listview when a Win32 class search returns no results.
    ''' The text of the group will be groupName and the text of the item will be message.
    ''' </summary>
    ''' <param name="referenceListView">Referenced ListView</param>
    ''' <param name="groupName">Text for Group</param>
    ''' <param name="message">Text for ListViewItem</param>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")> _
    Public Shared Sub AddGroupForNoResults(ByRef referenceListView As ListView, ByVal groupName As String, ByVal message As String)

        If String.IsNullOrEmpty(groupName) Or String.IsNullOrEmpty(message) Then

            Throw New ArgumentException("groupName and/or message cannot be blank")

        Else

            Dim myListViewGroup As ListViewGroup = referenceListView.Groups.Add(groupName, groupName)

            Dim myListViewItem As ListViewItem = New ListViewItem(myListViewGroup)

            myListViewItem.Text = message

            referenceListView.Items.Add(myListViewItem)

        End If

    End Sub

#End Region

#Region " Resize ListView Columns "

    ''' <summary>
    ''' Auto resizes ListView columns.
    ''' This overload provides the option to hide one column by setting its width to 0.
    ''' </summary>
    ''' <param name="referenceListView">The referenced ListView</param>
    ''' <param name="resizeStyle">The Windows ColumnHeaderAutoResizeStyle</param>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")> _
    Public Shared Sub ResizeListViewColumns(ByRef referenceListView As ListView, ByVal resizeStyle As ColumnHeaderAutoResizeStyle)

        referenceListView.SuspendLayout()

        ' Resize columns or hide if option is set.
        For i As Integer = 0 To referenceListView.Columns.Count - 1

            referenceListView.Columns(i).AutoResize(resizeStyle)

        Next

        referenceListView.ResumeLayout()
        referenceListView.Refresh()

    End Sub

    ''' <summary>
    ''' Auto resizes ListView columns.
    ''' This overload provides the option to hide one column by setting its width to 0.
    ''' </summary>
    ''' <param name="referenceListView">The referenced ListView</param>
    ''' <param name="resizeStyle">The Windows ColumnHeaderAutoResizeStyle</param>
    ''' <param name="hideColumn">The column index to hide</param>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1045:DoNotPassTypesByReference")> _
    Public Shared Sub ResizeListViewColumns(ByRef referenceListView As ListView, ByVal resizeStyle As ColumnHeaderAutoResizeStyle, ByVal hideColumn As Integer)

        referenceListView.SuspendLayout()

        ' Resize columns or hide if option is set.
        For i As Integer = 0 To referenceListView.Columns.Count - 1

            If hideColumn = i Then
                referenceListView.Columns(i).Width = 0
            Else
                referenceListView.Columns(i).AutoResize(resizeStyle)
            End If

        Next

        referenceListView.ResumeLayout()
        referenceListView.Refresh()

    End Sub

#End Region

End Class
