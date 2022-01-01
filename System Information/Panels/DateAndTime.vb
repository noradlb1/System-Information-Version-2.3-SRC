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

Imports System
Imports System.IO
Imports System.Globalization
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Friend Class DateAndTime
    Inherits SystemInformation.TaskPanelBase

#Region " Panel Methods "

    Private Shared panelInstance As DateAndTime

    ' Get a global instance of this panel
    Public Shared Function CreateInstance() As DateAndTime
        If (panelInstance Is Nothing) Then
            panelInstance = New DateAndTime()
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

    Private _CurrentCalendar As Calendar = New Globalization.GregorianCalendar
    Private _Info As New ComputerInformation
    Private _CurrentYear As Integer      ' Used to track year changes in month calendar.
    Private _HolidayName() As String     ' Array of holiday names for the year.
    Private _HolidayDate() As Date       ' Array of holiday dates for the year.

#End Region

#Region " Panel Event Handlers "

    Private Sub Panel_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles MyBase.Load

        Try
            ' Allow panel to paint.
            Application.DoEvents()

            ' Get the Time Zone.
            LabelTimeZone.Text = _Info.TimeCurrentTimeZone

            ' Get the offset from UTC.
            LabelOffsetFromUTC.Text = _Info.TimeUniversalTimeOffset & " Hours"

            ' Get the local date and time.
            LabelLocalDateTime.Text = _Info.TimeLocalDateTime.ToLongDateString() & " " & _
                _Info.TimeLocalDateTime.ToLongTimeString()

            ' Get UTC date and time.
            LabelUniversalDateTime.Text = _Info.TimeUniversalDateTime.ToLongDateString() & " " & _
                _Info.TimeUniversalDateTime.ToLongTimeString()

            ' Get daylight savings start.
            LabelDaylightStart.Text = _Info.TimeLocalDaylightStartDate.ToLongDateString() & " " & _
                _Info.TimeLocalDaylightStartTime.ToLongTimeString()

            ' Get daylight end.
            LabelDaylightEnd.Text = _Info.TimeLocalDaylightEndDate.ToLongDateString() & " " & _
                _Info.TimeLocalDaylightEndTime.ToLongTimeString()

            ' Get the current date.
            LabelCurrentDate.Text = _Info.TimeLocalDateTime.ToShortDateString()

            ' Get the day of the year.
            LabelCurrentDayOfYear.Text = DateTime.Today.DayOfYear.ToString()

            ' Get the days remaining in the year.
            LabelCurrentDaysLeft.Text = ((_CurrentCalendar.GetDaysInYear(DateTime.Today.Year) _
                    - _CurrentCalendar.GetDayOfYear(DateTime.Today))).ToString()

            ' Get the current week of the year.
            LabelCurrentWeekOfYear.Text = ComputerInformation.GetWeekNumber(DateTime.Today).ToString()

            ' Get weeks left for the current date.
            LabelCurrentWeeksLeft.Text = (52 - ComputerInformation.GetWeekNumber(DateTime.Today)).ToString()

            ' Store the current year so we can check when it changes.
            _CurrentYear = DateTime.Today.Year

            ' Get the holidays.
            If GetHolidays(_CurrentYear) Then

                ' Add holidays as bolded dates to the MonthCalendar control.
                MonthCalendarDateTime.BoldedDates = _HolidayDate

            Else

                ' Unable to get holidays, so remove any bolded dates.
                MonthCalendarDateTime.RemoveAllBoldedDates()
                MonthCalendarDateTime.UpdateBoldedDates()

            End If

            ' Get the holiday name (if any).
            Dim holiday As String = GetHolidayName(DateTime.Today)

            ' Display the holiday name.
            If Not String.IsNullOrEmpty(holiday) Then
                LabelCurrentHoliday.Text = holiday
            Else
                LabelCurrentHoliday.Text = ""
            End If

            ' enable timer
            TimerDateTime.Enabled = True

        Catch exc As NullReferenceException
            ' Do Nothing - this means that the Holiday.xml file is missing.
        Catch ex As Exception
            MessageBox.Show("An error has occurred in the Operating Systems panel." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & ex.Source & vbCrLf & _
                "Description: " & ex.Message, Application.ProductName, MessageBoxButtons.OK, _
                MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

#Region " Timer Event Handlers"

    Private Sub TimerDateTime_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles TimerDateTime.Tick

        ' update date and time labels
        LabelLocalDateTime.Text = _Info.TimeLocalDateTime.ToLongDateString & " " & _
            _Info.TimeLocalDateTime.ToLongTimeString
        LabelUniversalDateTime.Text = _Info.TimeUniversalDateTime.ToLongDateString & " " & _
            _Info.TimeUniversalDateTime.ToLongTimeString

        ' Check if the year in the month calendar has changed.
        If MonthCalendarDateTime.SelectionStart.Year <> _CurrentYear Then

            ' Make sure the year has not been accidentally set to the beginning (1776).
            If MonthCalendarDateTime.SelectionStart.Year = 1776 Then

                ' Reset the calendar to today's date.
                MonthCalendarDateTime.SetDate(DateTime.Today)

            Else

                ' Store the new year.
                _CurrentYear = MonthCalendarDateTime.SelectionStart.Year

                ' Get the holidays.
                If GetHolidays(_CurrentYear) Then

                    ' Add holidays as bolded dates to the MonthCalendar control.
                    MonthCalendarDateTime.BoldedDates = _HolidayDate

                Else

                    ' Unable to get holidays, so remove any bolded dates.
                    MonthCalendarDateTime.RemoveAllBoldedDates()
                    MonthCalendarDateTime.UpdateBoldedDates()

                End If

            End If

        End If

        ' Get the holiday name (if any).
        Dim holiday As String = GetHolidayName(DateTime.Today)

        ' Display the holiday name.
        If Not String.IsNullOrEmpty(holiday) Then
            LabelCurrentHoliday.Text = holiday
        Else
            LabelCurrentHoliday.Text = ""
        End If

    End Sub

#End Region

#Region " MonthCalendar Event Handlers "

    Private Sub calendarDateTime_DateChanged(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendarDateTime.DateChanged

        ' Get the selected date.
        LabelSelectedDate.Text = e.Start.ToShortDateString()

        ' Get the day of the year.
        LabelSelectedDayOfYear.Text = e.Start.DayOfYear.ToString()

        ' Get the days remaining in the year.
        LabelSelectedDaysLeft.Text = ((_CurrentCalendar.GetDaysInYear(e.Start.Year) _
            - _CurrentCalendar.GetDayOfYear(e.Start))).ToString()

        ' Get the selected week of the year.
        LabelSelectedWeekOfYear.Text = ComputerInformation.GetWeekNumber(e.Start).ToString()

        ' Get weeks left for the selected date.
        LabelSelectedWeeksLeft.Text = (52 - ComputerInformation.GetWeekNumber(e.Start)).ToString()

        ' Get the holiday name (if any).
        Dim holiday As String = GetHolidayName(e.Start)

        ' Display the holiday name.
        If Not String.IsNullOrEmpty(holiday) Then
            labelSelectedHoliday.Text = holiday
        Else
            labelSelectedHoliday.Text = ""
        End If

        ' Get the offset from today.
        Dim offset As Integer = e.Start.Subtract(DateTime.Today).Days

        ' Format outout.
        If offset = +1 Then

            LabelOffsetFromToday.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            LabelOffsetFromToday.Text = offset.ToString() & " day ahead"

        ElseIf offset = -1 Then

            LabelOffsetFromToday.ForeColor = Color.DarkRed
            LabelOffsetFromToday.Text = Math.Abs(offset).ToString() & " day behind"

        ElseIf offset > 1 Then

            LabelOffsetFromToday.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            LabelOffsetFromToday.Text = String.Format("{0:N0}", offset) & " days ahead"

        ElseIf offset < -1 Then

            LabelOffsetFromToday.ForeColor = Color.DarkRed
            LabelOffsetFromToday.Text = String.Format("{0:N0}", Math.Abs(offset)) & " days behind"

        Else

            LabelOffsetFromToday.ForeColor = Color.FromKnownColor(KnownColor.WindowText)
            LabelOffsetFromToday.Text = ""

        End If

    End Sub

#End Region

#Region " Methods "

    Private Function GetHolidays(ByVal desiredYear As Integer) As Boolean

        Dim desiredDate As Date

        Try

            desiredDate = New DateTime(desiredYear, 1, 1)
            Dim xmlPath As String = Path.GetDirectoryName(Application.ExecutablePath) + "\Holidays.xml"

            If File.Exists(xmlPath) Then

                Dim hc As HolidayCalculator = New HolidayCalculator(desiredDate, xmlPath)
                Dim h As Holiday
                Dim i As Integer = 0

                ReDim _HolidayName(hc.OrderedHolidays.Count)
                ReDim _HolidayDate(hc.OrderedHolidays.Count)

                For Each h In hc.OrderedHolidays

                    ' Add name to string array.
                    _HolidayName(i) = h.HolidayName

                    ' Add desiredDate to Date array.
                    _HolidayDate(i) = h.HolidayDate

                    i += 1
                Next

                Return True

            Else
                Return False
            End If

        Catch exc As NullReferenceException
            ' Do Nothing - this means that the Holiday.xml file is missing.
            Return False
        Catch e As Exception
            MessageBox.Show("An error has occurred in the Date Time panel, GetHolidays method." & vbCrLf & _
                "The system returned the following information:" & vbCrLf & _
                "Source : " & e.Source & vbCrLf & "Description: " & e.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function

    Private Function GetHolidayName(ByVal inDate As Date) As String

        Try
            Dim index As Integer
            Dim testDate As Date
            Dim returnName As String = ""

            ' Try to find the inDate in the holidayDate array.
            For Each testDate In _HolidayDate

                If testDate = inDate Then

                    returnName = _HolidayName(index)
                    Exit For

                End If

                index += 1

            Next

            Return returnName

        Catch exc As NullReferenceException
            ' Do Nothing - this means that the Holiday.xml file is missing.
            Return ""
        Catch e As Exception
            MessageBox.Show("An error has occurred in the Date Time panel, GetHolidayName method." _
                & vbCrLf & "The system returned the following information:" & vbCrLf & _
                "Source : " & e.Source & vbCrLf & "Description: " & e.Message, _
                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try

    End Function

#End Region

End Class
