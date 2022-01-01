'
' This library was wriiten by Jay Muntz and is available on The Code Project at
'
' http:'web6.codeproject.com/dotnet/HolidayCalculator.asp
'
' To the best of my knowledge, this software is not copyrighted.
'
' Converted to Visual Basic by Herbert N Swearengen III 11/1/2006
'
' THIS SOFTWARE IS PROVIDED BY THE CONTRIBUTORS "AS IS" AND 
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

Imports System
imports System.Collections
Imports System.Xml

Public Class HolidayCalculator

#Region " Constructor "

    ''' <summary>
    ''' Returns all of the holidays occuring in the year following the date that is passed in the constructor.
    ''' Holidays are defined in an XML file.
    ''' </summary>	
    ''' <param name="startDate">
    ''' The starting date for returning holidays.
    ''' All holidays for one year after this date are returned.
    ''' </param>
    ''' <param name="xmlPath">
    ''' The path to the XML file that contains the holiday definitions.
    ''' </param>
    Public Sub New(ByVal startDate As Date, ByVal xmlPath As String)

        ' Set the starting date.
        startingDate = startDate

        ' Clear old values.
        orderedHolidayList = New ArrayList()
        xHolidays = New XmlDocument()

        ' Load the holiday file.
        xHolidays.Load(xmlPath)

        ' Process the file.
        ProcessXML()

    End Sub

#End Region

#Region " Private Properties "

    Private orderedHolidayList As ArrayList
    Private xHolidays As XmlDocument
    Private startingDate As Date

#End Region

#Region " Public Properties "

    ''' <summary>
    ''' The holidays occuring after StartDate listed in chronological order;
    ''' </summary>
    Public ReadOnly Property OrderedHolidays() As ArrayList
        Get
            Return orderedHolidayList
        End Get
    End Property

#End Region

#Region " Private Methods "

    ''' <summary>
    ''' Loops through the holidays defined in the XML configuration file,
    ''' and adds the next occurance into the OrderHolidays collection if it occurs within one year.
    ''' </summary>
    Private Sub ProcessXML()

        Dim n As XmlNode

        For Each n In xHolidays.SelectNodes("/Holidays/Holiday")

            Dim h As Holiday = ProcessNode(n)

            If h.HolidayDate.Year > 1 Then
                orderedHolidayList.Add(h)
            End If
        Next

        orderedHolidayList.Sort()

    End Sub

    ''' <summary>
    ''' Processes a Holiday node from the XML configuration file.
    ''' </summary>
    ''' <param name="n">The Holdiay node to process.</param>
    Private Function ProcessNode(ByVal n As XmlNode) As Holiday

        Dim h As Holiday = New Holiday()
        h.HolidayName = n.Attributes("name").Value.ToString()
        Dim childNodes As ArrayList = New ArrayList()
        Dim o As XmlNode


        For Each o In n.ChildNodes

            childNodes.Add(o.Name.ToString())

        Next

        If (childNodes.Contains("WeekOfMonth")) Then

            Dim m As Integer = Int32.Parse(n.SelectSingleNode("./Month").InnerXml.ToString())
            Dim w As Integer = Int32.Parse(n.SelectSingleNode("./WeekOfMonth").InnerXml.ToString())
            Dim wd As Integer = Int32.Parse(n.SelectSingleNode("./DayOfWeek").InnerXml.ToString())
            h.HolidayDate = GetDateByMonthWeekWeekday(m, w, wd, startingDate)

        ElseIf childNodes.Contains("DayOfWeekOnOrAfter") Then

            Dim dow As Integer = Int32.Parse(n.SelectSingleNode("./DayOfWeekOnOrAfter/DayOfWeek").InnerXml.ToString())

            If dow > 6 Or dow < 0 Then
                Throw New Exception("DOW is greater than 6")
            End If

            Dim m As Integer = Int32.Parse(n.SelectSingleNode("./DayOfWeekOnOrAfter/Month").InnerXml.ToString())
            Dim d As Integer = Int32.Parse(n.SelectSingleNode("./DayOfWeekOnOrAfter/Day").InnerXml.ToString())
            h.HolidayDate = GetDateByWeekdayOnOrAfter(dow, m, d, startingDate)

        ElseIf (childNodes.Contains("WeekdayOnOrAfter")) Then

            Dim m As Integer = Int32.Parse(n.SelectSingleNode("./WeekdayOnOrAfter/Month").InnerXml.ToString())
            Dim d As Integer = Int32.Parse(n.SelectSingleNode("./WeekdayOnOrAfter/Day").InnerXml.ToString())
            Dim dt As Date = New DateTime(startingDate.Year, m, d)

            If (dt < startingDate) Then
                dt = dt.AddYears(1)
            End If

            While dt.DayOfWeek.Equals(DayOfWeek.Saturday) Or dt.DayOfWeek.Equals(DayOfWeek.Sunday)

                dt = dt.AddDays(1)

            End While

            h.HolidayDate = dt

        ElseIf childNodes.Contains("LastFullWeekOfMonth") Then

            Dim m As Integer = Int32.Parse(n.SelectSingleNode("./LastFullWeekOfMonth/Month").InnerXml.ToString())
            Dim weekday As Integer = Int32.Parse(n.SelectSingleNode("./LastFullWeekOfMonth/DayOfWeek").InnerXml.ToString())
            Dim dt As Date = GetDateByMonthWeekWeekday(m, 5, weekday, startingDate)

            If dt.AddDays(6 - weekday).Month = m Then
                h.HolidayDate = dt
            Else
                h.HolidayDate = dt.AddDays(-7)
            End If

        ElseIf (childNodes.Contains("DaysAfterHoliday")) Then

            Dim basis As XmlNode = xHolidays.SelectSingleNode("/Holidays/Holiday[@name='" _
                & n.SelectSingleNode("./DaysAfterHoliday").Attributes("Holiday").Value.ToString() & "']")
            Dim bHoliday As Holiday = Me.ProcessNode(basis)
            Dim days As Integer = Int32.Parse(n.SelectSingleNode("./DaysAfterHoliday/Days").InnerXml.ToString())

            ' This check was added when this was converted from C#. It does not cause an error in C#, but it
            ' does in Visual Basic. This codes attempts to add negative days to 1/1/0001 which causes the error.
            If bHoliday.HolidayDate <> New DateTime(1, 1, 1) Then
                h.HolidayDate = bHoliday.HolidayDate.AddDays(days)
            End If

        ElseIf childNodes.Contains("Easter") Then

            h.HolidayDate = Easter()

        Else

            If childNodes.Contains("Month") And childNodes.Contains("Day") Then

                Dim m As Integer = Int32.Parse(n.SelectSingleNode("./Month").InnerXml.ToString())
                Dim d As Integer = Int32.Parse(n.SelectSingleNode("./Day").InnerXml.ToString())
                Dim dt As Date = New DateTime(startingDate.Year, m, d)

                If (dt < startingDate) Then

                    dt = dt.AddYears(1)

                End If

                If childNodes.Contains("EveryXYears") Then

                    Dim yearMult As Integer = Int32.Parse(n.SelectSingleNode("./EveryXYears").InnerXml.ToString())
                    Dim startYear As Integer = Int32.Parse(n.SelectSingleNode("./StartYear").InnerXml.ToString())

                    If ((dt.Year - startYear) Mod yearMult) = 0 Then
                        h.HolidayDate = dt
                    End If

                Else

                    h.HolidayDate = dt

                End If

            End If

        End If

        Return h

    End Function

    ''' <summary>
    ''' Determines the next occurance of Easter (western Christian).
    ''' </summary>
    Private Function Easter() As Date

        Dim workDate As Date = GetFirstDayOfMonth(startingDate)

        Dim y As Integer = workDate.Year

        If workDate.Month > 4 Then
            y = y + 1
        End If

        Return Me.Easter(y)

    End Function

    ''' <summary>
    ''' Determines the occurance of Easter in the given year.  
    ''' If the result comes before StartDate, recalculates for the following year.
    ''' </summary>
    Private Function Easter(ByVal y As Integer) As Date

        Dim a As Integer = y Mod 19
        Dim b As Integer = y \ 100
        Dim c As Integer = y Mod 100
        Dim d As Integer = b \ 4
        Dim e As Integer = b Mod 4
        Dim f As Integer = (b + 8) \ 25
        Dim g As Integer = (b - f + 1) \ 3
        Dim h As Integer = (19 * a + b - d - g + 15) Mod 30
        Dim i As Integer = c \ 4
        Dim k As Integer = c Mod 4
        Dim l As Integer = (32 + 2 * e + 2 * i - h - k) Mod 7
        Dim m As Integer = (a + 11 * h + 22 * l) \ 451
        Dim easterMonth As Integer = (h + l - 7 * m + 114) \ 31
        Dim p As Integer = (h + l - 7 * m + 114) Mod 31
        Dim easterDay As Integer = p + 1

        Dim est As Date = New DateTime(y, easterMonth, easterDay)

        If est < startingDate Then
            Return Easter(y + 1)
        Else
            Return New DateTime(y, easterMonth, easterDay)
        End If

    End Function

    ''' <summary>
    ''' Gets the next occurance of a weekday after a given month and day in the year after StartDate.
    ''' </summary>
    ''' <param name="weekday">The day of the week (0=Sunday).</param>
    ''' <param name="m">The Month</param>
    ''' <param name="d">Day</param>
    Private Function GetDateByWeekdayOnOrAfter(ByVal weekday As Integer, ByVal m As Integer, _
           ByVal d As Integer, ByVal startDate As Date) As Date

        Dim workDate As Date = GetFirstDayOfMonth(startDate)

        While workDate.Month <> m

            workDate = workDate.AddMonths(1)

        End While

        workDate = workDate.AddDays(d - 1)

        While weekday <> CInt(workDate.DayOfWeek)

            workDate = workDate.AddDays(1)

        End While

        'It's possible the resulting date is before the specified starting date.  
        'If so we'll calculate again for the next year.
        If (workDate < startingDate) Then

            Return GetDateByWeekdayOnOrAfter(weekday, m, d, startDate.AddYears(1))

        Else

            Return workDate

        End If

    End Function

    ''' <summary>
    ''' Gets the n'th instance of a day-of-week in the given month after StartDate
    ''' </summary>
    ''' <param name="month">The month the Holiday falls on.</param>
    ''' <param name="week">The instance of weekday that the Holiday falls on (5=last instance in the month).</param>
    ''' <param name="weekday">The day of the week that the Holiday falls on.</param>
    Private Function GetDateByMonthWeekWeekday(ByVal month As Integer, ByVal week As Integer, _
      ByVal weekday As Integer, ByVal startDate As Date) As Date

        Dim workDate As Date = GetFirstDayOfMonth(startDate)

        While workDate.Month <> month

            workDate = workDate.AddMonths(1)

        End While

        While Convert.ToInt32(workDate.DayOfWeek) <> weekday

            workDate = workDate.AddDays(1)

        End While

        Dim result As Date

        If week = 1 Then

            result = workDate

        Else

            Dim addDays As Integer = (week * 7) - 7
            Dim day As Integer = workDate.Day + addDays

            If (day > DateTime.DaysInMonth(workDate.Year, workDate.Month)) Then

                day = day - 7

            End If

            result = New DateTime(workDate.Year, workDate.Month, day)

        End If

        'It's possible the resulting date is before the specified starting date.  
        'If so we'll calculate again for the next year.
        If (result >= startingDate) Then
            Return result
        Else
            Return GetDateByMonthWeekWeekday(month, week, weekday, startDate.AddYears(1))
        End If

    End Function

    ''' <summary>
    ''' Returns the first day of the month for the specified date.
    ''' </summary>
    Private Shared Function GetFirstDayOfMonth(ByVal dt As Date) As Date

        Return New DateTime(dt.Year, dt.Month, 1)

    End Function

#End Region

End Class

#Region " Holiday Object "

<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1036:OverrideMethodsOnComparableTypes")> _
Public Class Holiday
    Implements IComparable

    Private _HolidayDate As Date
    Private _HolidayName As String

#Region " Public Properties "

    Public Property HolidayDate() As Date
        Get
            Return _HolidayDate
        End Get
        Set(ByVal value As Date)
            _HolidayDate = value
        End Set
    End Property

    Public Property HolidayName() As String
        Get
            Return _HolidayName
        End Get
        Set(ByVal value As String)
            _HolidayName = value
        End Set
    End Property

#End Region

#Region " IComparable Members "

    Public Function CompareTo(ByVal obj As Object) As Integer Implements IComparable.CompareTo

        If TypeOf (obj) Is Holiday Then
            Dim h As Holiday = CType(obj, Holiday)
            Return _HolidayDate.CompareTo(h._HolidayDate)
        Else
            Throw New ArgumentException("Object is not a Holiday")
        End If

    End Function

#End Region

End Class

#End Region

