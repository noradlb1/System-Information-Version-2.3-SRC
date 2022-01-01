<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DateAndTime
    Inherits SystemInformation.TaskPanelBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LabelTitle = New System.Windows.Forms.Label()
        Me.PictureBoxPanel = New System.Windows.Forms.PictureBox()
        Me.LabelTimeZone = New System.Windows.Forms.Label()
        Me.LabelSeparator = New System.Windows.Forms.Label()
        Me.TimerDateTime = New System.Windows.Forms.Timer(Me.components)
        Me.MonthCalendarDateTime = New System.Windows.Forms.MonthCalendar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabelDateInfo = New System.Windows.Forms.Label()
        Me.LabelSelectedWeekOfYear = New System.Windows.Forms.Label()
        Me.LabelSelectedWeeksLeft = New System.Windows.Forms.Label()
        Me.LabelSelectedWeekOfYearDesc = New System.Windows.Forms.Label()
        Me.LabelSelectedWeeksLeftDesc = New System.Windows.Forms.Label()
        Me.LabelCurrentWeekOfYear = New System.Windows.Forms.Label()
        Me.LabelCurrentWeeksLeft = New System.Windows.Forms.Label()
        Me.LabelCurrentWeekOfYearDesc = New System.Windows.Forms.Label()
        Me.LabelCurrentWeeksLeftDesc = New System.Windows.Forms.Label()
        Me.LabelSelectedDate = New System.Windows.Forms.Label()
        Me.LabelSelectedDayOfYear = New System.Windows.Forms.Label()
        Me.LabelSelectedDaysLeft = New System.Windows.Forms.Label()
        Me.LabelOffsetFromToday = New System.Windows.Forms.Label()
        Me.LabelSelectedDayOfYearDesc = New System.Windows.Forms.Label()
        Me.LabelSelectedDaysLeftDesc = New System.Windows.Forms.Label()
        Me.LabelOffsetFromTodayDesc = New System.Windows.Forms.Label()
        Me.LabelSelectedDateDesc = New System.Windows.Forms.Label()
        Me.LabelTCurrentDateDesc = New System.Windows.Forms.Label()
        Me.LabelCurrentDayOfYear = New System.Windows.Forms.Label()
        Me.LabelCurrentDaysLeft = New System.Windows.Forms.Label()
        Me.LabelCurrentDayOfYearDesc = New System.Windows.Forms.Label()
        Me.LabelCurrentDaysLeftDesc = New System.Windows.Forms.Label()
        Me.LabelCurrentDate = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LabelTimeInformation = New System.Windows.Forms.Label()
        Me.LabelOffset = New System.Windows.Forms.Label()
        Me.LabelLocal = New System.Windows.Forms.Label()
        Me.LabelUniversalDateTime = New System.Windows.Forms.Label()
        Me.LabelUniversal = New System.Windows.Forms.Label()
        Me.LabelLocalDateTime = New System.Windows.Forms.Label()
        Me.LabelOffsetFromUTC = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.labelSelectedHoliday = New System.Windows.Forms.Label()
        Me.LabelCurrentHoliday = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.LabelDaylightEnd = New System.Windows.Forms.Label()
        Me.LabelDaylightEndDesc = New System.Windows.Forms.Label()
        Me.LabelDaylightStart = New System.Windows.Forms.Label()
        Me.LabelDaylightStartDesc = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.BackColor = System.Drawing.Color.Transparent
        Me.LabelTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.ForeColor = System.Drawing.Color.DarkBlue
        Me.LabelTitle.Location = New System.Drawing.Point(87, 16)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(140, 25)
        Me.LabelTitle.TabIndex = 3
        Me.LabelTitle.Text = "Date and Time"
        '
        'PictureBoxPanel
        '
        Me.PictureBoxPanel.BackColor = System.Drawing.Color.Transparent
        Me.PictureBoxPanel.Image = Global.SystemInformation.My.Resources.Resources.Date_Time_48x48
        Me.PictureBoxPanel.Location = New System.Drawing.Point(22, 16)
        Me.PictureBoxPanel.Name = "PictureBoxPanel"
        Me.PictureBoxPanel.Size = New System.Drawing.Size(48, 48)
        Me.PictureBoxPanel.TabIndex = 2
        Me.PictureBoxPanel.TabStop = False
        '
        'LabelTimeZone
        '
        Me.LabelTimeZone.BackColor = System.Drawing.Color.Transparent
        Me.LabelTimeZone.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelTimeZone.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelTimeZone.Location = New System.Drawing.Point(87, 49)
        Me.LabelTimeZone.Name = "LabelTimeZone"
        Me.LabelTimeZone.Size = New System.Drawing.Size(420, 17)
        Me.LabelTimeZone.TabIndex = 2
        '
        'LabelSeparator
        '
        Me.LabelSeparator.BackColor = System.Drawing.Color.Black
        Me.LabelSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSeparator.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.LabelSeparator.Location = New System.Drawing.Point(87, 72)
        Me.LabelSeparator.Name = "LabelSeparator"
        Me.LabelSeparator.Size = New System.Drawing.Size(642, 3)
        Me.LabelSeparator.TabIndex = 1
        '
        'TimerDateTime
        '
        Me.TimerDateTime.Interval = 1000
        '
        'MonthCalendarDateTime
        '
        Me.MonthCalendarDateTime.BackColor = System.Drawing.SystemColors.Window
        Me.MonthCalendarDateTime.CalendarDimensions = New System.Drawing.Size(3, 2)
        Me.MonthCalendarDateTime.Location = New System.Drawing.Point(30, 84)
        Me.MonthCalendarDateTime.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.MonthCalendarDateTime.MaxSelectionCount = 1
        Me.MonthCalendarDateTime.MinDate = New Date(1776, 7, 1, 0, 0, 0, 0)
        Me.MonthCalendarDateTime.Name = "MonthCalendarDateTime"
        Me.MonthCalendarDateTime.TabIndex = 0
        Me.MonthCalendarDateTime.TitleBackColor = System.Drawing.Color.DarkGreen
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LabelDateInfo)
        Me.Panel1.Controls.Add(Me.LabelSelectedWeekOfYear)
        Me.Panel1.Controls.Add(Me.LabelSelectedWeeksLeft)
        Me.Panel1.Controls.Add(Me.LabelSelectedWeekOfYearDesc)
        Me.Panel1.Controls.Add(Me.LabelSelectedWeeksLeftDesc)
        Me.Panel1.Controls.Add(Me.LabelCurrentWeekOfYear)
        Me.Panel1.Controls.Add(Me.LabelCurrentWeeksLeft)
        Me.Panel1.Controls.Add(Me.LabelCurrentWeekOfYearDesc)
        Me.Panel1.Controls.Add(Me.LabelCurrentWeeksLeftDesc)
        Me.Panel1.Controls.Add(Me.LabelSelectedDate)
        Me.Panel1.Controls.Add(Me.LabelSelectedDayOfYear)
        Me.Panel1.Controls.Add(Me.LabelSelectedDaysLeft)
        Me.Panel1.Controls.Add(Me.LabelOffsetFromToday)
        Me.Panel1.Controls.Add(Me.LabelSelectedDayOfYearDesc)
        Me.Panel1.Controls.Add(Me.LabelSelectedDaysLeftDesc)
        Me.Panel1.Controls.Add(Me.LabelOffsetFromTodayDesc)
        Me.Panel1.Controls.Add(Me.LabelSelectedDateDesc)
        Me.Panel1.Controls.Add(Me.LabelTCurrentDateDesc)
        Me.Panel1.Controls.Add(Me.LabelCurrentDayOfYear)
        Me.Panel1.Controls.Add(Me.LabelCurrentDaysLeft)
        Me.Panel1.Controls.Add(Me.LabelCurrentDayOfYearDesc)
        Me.Panel1.Controls.Add(Me.LabelCurrentDaysLeftDesc)
        Me.Panel1.Controls.Add(Me.LabelCurrentDate)
        Me.Panel1.Location = New System.Drawing.Point(42, 425)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(465, 85)
        Me.Panel1.TabIndex = 4
        '
        'LabelDateInfo
        '
        Me.LabelDateInfo.AutoSize = True
        Me.LabelDateInfo.BackColor = System.Drawing.Color.Transparent
        Me.LabelDateInfo.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelDateInfo.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelDateInfo.Location = New System.Drawing.Point(8, 5)
        Me.LabelDateInfo.Name = "LabelDateInfo"
        Me.LabelDateInfo.Size = New System.Drawing.Size(130, 15)
        Me.LabelDateInfo.TabIndex = 0
        Me.LabelDateInfo.Text = "Day/Date Information"
        '
        'LabelSelectedWeekOfYear
        '
        Me.LabelSelectedWeekOfYear.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedWeekOfYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedWeekOfYear.Location = New System.Drawing.Point(434, 25)
        Me.LabelSelectedWeekOfYear.Name = "LabelSelectedWeekOfYear"
        Me.LabelSelectedWeekOfYear.Size = New System.Drawing.Size(24, 15)
        Me.LabelSelectedWeekOfYear.TabIndex = 21
        Me.LabelSelectedWeekOfYear.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelSelectedWeeksLeft
        '
        Me.LabelSelectedWeeksLeft.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedWeeksLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedWeeksLeft.Location = New System.Drawing.Point(434, 45)
        Me.LabelSelectedWeeksLeft.Name = "LabelSelectedWeeksLeft"
        Me.LabelSelectedWeeksLeft.Size = New System.Drawing.Size(24, 15)
        Me.LabelSelectedWeeksLeft.TabIndex = 22
        Me.LabelSelectedWeeksLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelSelectedWeekOfYearDesc
        '
        Me.LabelSelectedWeekOfYearDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedWeekOfYearDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedWeekOfYearDesc.Location = New System.Drawing.Point(350, 25)
        Me.LabelSelectedWeekOfYearDesc.Name = "LabelSelectedWeekOfYearDesc"
        Me.LabelSelectedWeekOfYearDesc.Size = New System.Drawing.Size(80, 15)
        Me.LabelSelectedWeekOfYearDesc.TabIndex = 19
        Me.LabelSelectedWeekOfYearDesc.Text = "Week of Year:"
        '
        'LabelSelectedWeeksLeftDesc
        '
        Me.LabelSelectedWeeksLeftDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedWeeksLeftDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedWeeksLeftDesc.Location = New System.Drawing.Point(350, 45)
        Me.LabelSelectedWeeksLeftDesc.Name = "LabelSelectedWeeksLeftDesc"
        Me.LabelSelectedWeeksLeftDesc.Size = New System.Drawing.Size(80, 15)
        Me.LabelSelectedWeeksLeftDesc.TabIndex = 16
        Me.LabelSelectedWeeksLeftDesc.Text = "Weeks Left:"
        '
        'LabelCurrentWeekOfYear
        '
        Me.LabelCurrentWeekOfYear.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentWeekOfYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentWeekOfYear.Location = New System.Drawing.Point(208, 45)
        Me.LabelCurrentWeekOfYear.Name = "LabelCurrentWeekOfYear"
        Me.LabelCurrentWeekOfYear.Size = New System.Drawing.Size(24, 15)
        Me.LabelCurrentWeekOfYear.TabIndex = 10
        Me.LabelCurrentWeekOfYear.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelCurrentWeeksLeft
        '
        Me.LabelCurrentWeeksLeft.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentWeeksLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentWeeksLeft.Location = New System.Drawing.Point(208, 65)
        Me.LabelCurrentWeeksLeft.Name = "LabelCurrentWeeksLeft"
        Me.LabelCurrentWeeksLeft.Size = New System.Drawing.Size(24, 15)
        Me.LabelCurrentWeeksLeft.TabIndex = 9
        Me.LabelCurrentWeeksLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelCurrentWeekOfYearDesc
        '
        Me.LabelCurrentWeekOfYearDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentWeekOfYearDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentWeekOfYearDesc.Location = New System.Drawing.Point(124, 45)
        Me.LabelCurrentWeekOfYearDesc.Name = "LabelCurrentWeekOfYearDesc"
        Me.LabelCurrentWeekOfYearDesc.Size = New System.Drawing.Size(80, 15)
        Me.LabelCurrentWeekOfYearDesc.TabIndex = 7
        Me.LabelCurrentWeekOfYearDesc.Text = "Week of Year:"
        '
        'LabelCurrentWeeksLeftDesc
        '
        Me.LabelCurrentWeeksLeftDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentWeeksLeftDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentWeeksLeftDesc.Location = New System.Drawing.Point(124, 65)
        Me.LabelCurrentWeeksLeftDesc.Name = "LabelCurrentWeeksLeftDesc"
        Me.LabelCurrentWeeksLeftDesc.Size = New System.Drawing.Size(80, 15)
        Me.LabelCurrentWeeksLeftDesc.TabIndex = 6
        Me.LabelCurrentWeeksLeftDesc.Text = "Weeks Left:"
        '
        'LabelSelectedDate
        '
        Me.LabelSelectedDate.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedDate.Location = New System.Drawing.Point(350, 5)
        Me.LabelSelectedDate.Name = "LabelSelectedDate"
        Me.LabelSelectedDate.Size = New System.Drawing.Size(108, 15)
        Me.LabelSelectedDate.TabIndex = 20
        '
        'LabelSelectedDayOfYear
        '
        Me.LabelSelectedDayOfYear.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedDayOfYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedDayOfYear.Location = New System.Drawing.Point(318, 25)
        Me.LabelSelectedDayOfYear.Name = "LabelSelectedDayOfYear"
        Me.LabelSelectedDayOfYear.Size = New System.Drawing.Size(28, 15)
        Me.LabelSelectedDayOfYear.TabIndex = 15
        Me.LabelSelectedDayOfYear.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelSelectedDaysLeft
        '
        Me.LabelSelectedDaysLeft.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedDaysLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedDaysLeft.Location = New System.Drawing.Point(318, 45)
        Me.LabelSelectedDaysLeft.Name = "LabelSelectedDaysLeft"
        Me.LabelSelectedDaysLeft.Size = New System.Drawing.Size(28, 15)
        Me.LabelSelectedDaysLeft.TabIndex = 17
        Me.LabelSelectedDaysLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelOffsetFromToday
        '
        Me.LabelOffsetFromToday.BackColor = System.Drawing.Color.Transparent
        Me.LabelOffsetFromToday.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelOffsetFromToday.Location = New System.Drawing.Point(350, 65)
        Me.LabelOffsetFromToday.Name = "LabelOffsetFromToday"
        Me.LabelOffsetFromToday.Size = New System.Drawing.Size(108, 15)
        Me.LabelOffsetFromToday.TabIndex = 18
        '
        'LabelSelectedDayOfYearDesc
        '
        Me.LabelSelectedDayOfYearDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedDayOfYearDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedDayOfYearDesc.Location = New System.Drawing.Point(238, 25)
        Me.LabelSelectedDayOfYearDesc.Name = "LabelSelectedDayOfYearDesc"
        Me.LabelSelectedDayOfYearDesc.Size = New System.Drawing.Size(76, 15)
        Me.LabelSelectedDayOfYearDesc.TabIndex = 13
        Me.LabelSelectedDayOfYearDesc.Text = "Day of Year:"
        '
        'LabelSelectedDaysLeftDesc
        '
        Me.LabelSelectedDaysLeftDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedDaysLeftDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedDaysLeftDesc.Location = New System.Drawing.Point(238, 45)
        Me.LabelSelectedDaysLeftDesc.Name = "LabelSelectedDaysLeftDesc"
        Me.LabelSelectedDaysLeftDesc.Size = New System.Drawing.Size(76, 15)
        Me.LabelSelectedDaysLeftDesc.TabIndex = 11
        Me.LabelSelectedDaysLeftDesc.Text = "Days Left:"
        '
        'LabelOffsetFromTodayDesc
        '
        Me.LabelOffsetFromTodayDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelOffsetFromTodayDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelOffsetFromTodayDesc.Location = New System.Drawing.Point(238, 65)
        Me.LabelOffsetFromTodayDesc.Name = "LabelOffsetFromTodayDesc"
        Me.LabelOffsetFromTodayDesc.Size = New System.Drawing.Size(108, 15)
        Me.LabelOffsetFromTodayDesc.TabIndex = 12
        Me.LabelOffsetFromTodayDesc.Text = "Offset from Today:"
        '
        'LabelSelectedDateDesc
        '
        Me.LabelSelectedDateDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelSelectedDateDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSelectedDateDesc.Location = New System.Drawing.Point(238, 5)
        Me.LabelSelectedDateDesc.Name = "LabelSelectedDateDesc"
        Me.LabelSelectedDateDesc.Size = New System.Drawing.Size(108, 15)
        Me.LabelSelectedDateDesc.TabIndex = 14
        Me.LabelSelectedDateDesc.Text = "Selected Date:"
        '
        'LabelTCurrentDateDesc
        '
        Me.LabelTCurrentDateDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelTCurrentDateDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelTCurrentDateDesc.Location = New System.Drawing.Point(12, 25)
        Me.LabelTCurrentDateDesc.Name = "LabelTCurrentDateDesc"
        Me.LabelTCurrentDateDesc.Size = New System.Drawing.Size(108, 15)
        Me.LabelTCurrentDateDesc.TabIndex = 1
        Me.LabelTCurrentDateDesc.Text = "Today:"
        '
        'LabelCurrentDayOfYear
        '
        Me.LabelCurrentDayOfYear.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentDayOfYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentDayOfYear.Location = New System.Drawing.Point(92, 45)
        Me.LabelCurrentDayOfYear.Name = "LabelCurrentDayOfYear"
        Me.LabelCurrentDayOfYear.Size = New System.Drawing.Size(28, 15)
        Me.LabelCurrentDayOfYear.TabIndex = 4
        Me.LabelCurrentDayOfYear.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelCurrentDaysLeft
        '
        Me.LabelCurrentDaysLeft.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentDaysLeft.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentDaysLeft.Location = New System.Drawing.Point(92, 65)
        Me.LabelCurrentDaysLeft.Name = "LabelCurrentDaysLeft"
        Me.LabelCurrentDaysLeft.Size = New System.Drawing.Size(28, 15)
        Me.LabelCurrentDaysLeft.TabIndex = 5
        Me.LabelCurrentDaysLeft.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LabelCurrentDayOfYearDesc
        '
        Me.LabelCurrentDayOfYearDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentDayOfYearDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentDayOfYearDesc.Location = New System.Drawing.Point(12, 45)
        Me.LabelCurrentDayOfYearDesc.Name = "LabelCurrentDayOfYearDesc"
        Me.LabelCurrentDayOfYearDesc.Size = New System.Drawing.Size(76, 15)
        Me.LabelCurrentDayOfYearDesc.TabIndex = 2
        Me.LabelCurrentDayOfYearDesc.Text = "Day of Year:"
        '
        'LabelCurrentDaysLeftDesc
        '
        Me.LabelCurrentDaysLeftDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentDaysLeftDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentDaysLeftDesc.Location = New System.Drawing.Point(12, 65)
        Me.LabelCurrentDaysLeftDesc.Name = "LabelCurrentDaysLeftDesc"
        Me.LabelCurrentDaysLeftDesc.Size = New System.Drawing.Size(76, 15)
        Me.LabelCurrentDaysLeftDesc.TabIndex = 3
        Me.LabelCurrentDaysLeftDesc.Text = "Days Left:"
        '
        'LabelCurrentDate
        '
        Me.LabelCurrentDate.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelCurrentDate.Location = New System.Drawing.Point(124, 25)
        Me.LabelCurrentDate.Name = "LabelCurrentDate"
        Me.LabelCurrentDate.Size = New System.Drawing.Size(108, 15)
        Me.LabelCurrentDate.TabIndex = 8
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LabelTimeInformation)
        Me.Panel2.Controls.Add(Me.LabelOffset)
        Me.Panel2.Controls.Add(Me.LabelLocal)
        Me.Panel2.Controls.Add(Me.LabelUniversalDateTime)
        Me.Panel2.Controls.Add(Me.LabelUniversal)
        Me.Panel2.Controls.Add(Me.LabelLocalDateTime)
        Me.Panel2.Controls.Add(Me.LabelOffsetFromUTC)
        Me.Panel2.Location = New System.Drawing.Point(42, 516)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(417, 98)
        Me.Panel2.TabIndex = 6
        '
        'LabelTimeInformation
        '
        Me.LabelTimeInformation.AutoSize = True
        Me.LabelTimeInformation.BackColor = System.Drawing.Color.Transparent
        Me.LabelTimeInformation.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTimeInformation.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelTimeInformation.Location = New System.Drawing.Point(8, 5)
        Me.LabelTimeInformation.Name = "LabelTimeInformation"
        Me.LabelTimeInformation.Size = New System.Drawing.Size(105, 15)
        Me.LabelTimeInformation.TabIndex = 0
        Me.LabelTimeInformation.Text = "Time Information"
        '
        'LabelOffset
        '
        Me.LabelOffset.BackColor = System.Drawing.Color.Transparent
        Me.LabelOffset.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelOffset.Location = New System.Drawing.Point(8, 28)
        Me.LabelOffset.Name = "LabelOffset"
        Me.LabelOffset.Size = New System.Drawing.Size(156, 15)
        Me.LabelOffset.TabIndex = 1
        Me.LabelOffset.Text = "Offset from Univeral Time:"
        '
        'LabelLocal
        '
        Me.LabelLocal.BackColor = System.Drawing.Color.Transparent
        Me.LabelLocal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelLocal.Location = New System.Drawing.Point(8, 48)
        Me.LabelLocal.Name = "LabelLocal"
        Me.LabelLocal.Size = New System.Drawing.Size(156, 15)
        Me.LabelLocal.TabIndex = 2
        Me.LabelLocal.Text = "Local Date and Time:"
        '
        'LabelUniversalDateTime
        '
        Me.LabelUniversalDateTime.BackColor = System.Drawing.Color.Transparent
        Me.LabelUniversalDateTime.Location = New System.Drawing.Point(164, 68)
        Me.LabelUniversalDateTime.Name = "LabelUniversalDateTime"
        Me.LabelUniversalDateTime.Size = New System.Drawing.Size(245, 15)
        Me.LabelUniversalDateTime.TabIndex = 6
        '
        'LabelUniversal
        '
        Me.LabelUniversal.BackColor = System.Drawing.Color.Transparent
        Me.LabelUniversal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelUniversal.Location = New System.Drawing.Point(8, 68)
        Me.LabelUniversal.Name = "LabelUniversal"
        Me.LabelUniversal.Size = New System.Drawing.Size(156, 15)
        Me.LabelUniversal.TabIndex = 3
        Me.LabelUniversal.Text = "Universal Date and Time:"
        '
        'LabelLocalDateTime
        '
        Me.LabelLocalDateTime.BackColor = System.Drawing.Color.Transparent
        Me.LabelLocalDateTime.Location = New System.Drawing.Point(164, 48)
        Me.LabelLocalDateTime.Name = "LabelLocalDateTime"
        Me.LabelLocalDateTime.Size = New System.Drawing.Size(245, 15)
        Me.LabelLocalDateTime.TabIndex = 5
        '
        'LabelOffsetFromUTC
        '
        Me.LabelOffsetFromUTC.BackColor = System.Drawing.Color.Transparent
        Me.LabelOffsetFromUTC.Location = New System.Drawing.Point(164, 28)
        Me.LabelOffsetFromUTC.Name = "LabelOffsetFromUTC"
        Me.LabelOffsetFromUTC.Size = New System.Drawing.Size(245, 15)
        Me.LabelOffsetFromUTC.TabIndex = 4
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.labelSelectedHoliday)
        Me.Panel3.Controls.Add(Me.LabelCurrentHoliday)
        Me.Panel3.Location = New System.Drawing.Point(513, 425)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(195, 85)
        Me.Panel3.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(8, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Holiday Information"
        '
        'labelSelectedHoliday
        '
        Me.labelSelectedHoliday.BackColor = System.Drawing.Color.Transparent
        Me.labelSelectedHoliday.ForeColor = System.Drawing.Color.DarkGreen
        Me.labelSelectedHoliday.Location = New System.Drawing.Point(6, 41)
        Me.labelSelectedHoliday.Name = "labelSelectedHoliday"
        Me.labelSelectedHoliday.Size = New System.Drawing.Size(182, 15)
        Me.labelSelectedHoliday.TabIndex = 1
        '
        'LabelCurrentHoliday
        '
        Me.LabelCurrentHoliday.BackColor = System.Drawing.Color.Transparent
        Me.LabelCurrentHoliday.ForeColor = System.Drawing.Color.DarkGreen
        Me.LabelCurrentHoliday.Location = New System.Drawing.Point(6, 61)
        Me.LabelCurrentHoliday.Name = "LabelCurrentHoliday"
        Me.LabelCurrentHoliday.Size = New System.Drawing.Size(182, 15)
        Me.LabelCurrentHoliday.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.LabelDaylightEnd)
        Me.Panel4.Controls.Add(Me.LabelDaylightEndDesc)
        Me.Panel4.Controls.Add(Me.LabelDaylightStart)
        Me.Panel4.Controls.Add(Me.LabelDaylightStartDesc)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(465, 516)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(243, 98)
        Me.Panel4.TabIndex = 7
        '
        'LabelDaylightEnd
        '
        Me.LabelDaylightEnd.BackColor = System.Drawing.Color.Transparent
        Me.LabelDaylightEnd.Location = New System.Drawing.Point(11, 75)
        Me.LabelDaylightEnd.Name = "LabelDaylightEnd"
        Me.LabelDaylightEnd.Size = New System.Drawing.Size(225, 15)
        Me.LabelDaylightEnd.TabIndex = 4
        '
        'LabelDaylightEndDesc
        '
        Me.LabelDaylightEndDesc.AutoSize = True
        Me.LabelDaylightEndDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelDaylightEndDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelDaylightEndDesc.Location = New System.Drawing.Point(8, 58)
        Me.LabelDaylightEndDesc.Name = "LabelDaylightEndDesc"
        Me.LabelDaylightEndDesc.Size = New System.Drawing.Size(123, 15)
        Me.LabelDaylightEndDesc.TabIndex = 3
        Me.LabelDaylightEndDesc.Text = "Daylight Savings End: "
        '
        'LabelDaylightStart
        '
        Me.LabelDaylightStart.BackColor = System.Drawing.Color.Transparent
        Me.LabelDaylightStart.Location = New System.Drawing.Point(11, 41)
        Me.LabelDaylightStart.Name = "LabelDaylightStart"
        Me.LabelDaylightStart.Size = New System.Drawing.Size(225, 15)
        Me.LabelDaylightStart.TabIndex = 2
        '
        'LabelDaylightStartDesc
        '
        Me.LabelDaylightStartDesc.AutoSize = True
        Me.LabelDaylightStartDesc.BackColor = System.Drawing.Color.Transparent
        Me.LabelDaylightStartDesc.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelDaylightStartDesc.Location = New System.Drawing.Point(8, 24)
        Me.LabelDaylightStartDesc.Name = "LabelDaylightStartDesc"
        Me.LabelDaylightStartDesc.Size = New System.Drawing.Size(124, 15)
        Me.LabelDaylightStartDesc.TabIndex = 1
        Me.LabelDaylightStartDesc.Text = "Daylight Savings Start:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(8, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Daylight Savings"
        '
        'DateAndTime
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.White
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MonthCalendarDateTime)
        Me.Controls.Add(Me.LabelTimeZone)
        Me.Controls.Add(Me.LabelSeparator)
        Me.Controls.Add(Me.LabelTitle)
        Me.Controls.Add(Me.PictureBoxPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "DateAndTime"
        Me.Size = New System.Drawing.Size(750, 623)
        CType(Me.PictureBoxPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LabelTitle As System.Windows.Forms.Label
    Private WithEvents PictureBoxPanel As System.Windows.Forms.PictureBox
    Private WithEvents LabelTimeZone As System.Windows.Forms.Label
    Private WithEvents LabelSeparator As System.Windows.Forms.Label
    Private WithEvents TimerDateTime As System.Windows.Forms.Timer
    Private WithEvents MonthCalendarDateTime As System.Windows.Forms.MonthCalendar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents LabelSelectedWeekOfYear As System.Windows.Forms.Label
    Private WithEvents LabelSelectedWeeksLeft As System.Windows.Forms.Label
    Private WithEvents LabelSelectedWeekOfYearDesc As System.Windows.Forms.Label
    Private WithEvents LabelSelectedWeeksLeftDesc As System.Windows.Forms.Label
    Private WithEvents LabelCurrentWeekOfYear As System.Windows.Forms.Label
    Private WithEvents LabelCurrentWeeksLeft As System.Windows.Forms.Label
    Private WithEvents LabelCurrentWeekOfYearDesc As System.Windows.Forms.Label
    Private WithEvents LabelCurrentWeeksLeftDesc As System.Windows.Forms.Label
    Private WithEvents LabelSelectedDate As System.Windows.Forms.Label
    Private WithEvents LabelSelectedDayOfYear As System.Windows.Forms.Label
    Private WithEvents LabelSelectedDaysLeft As System.Windows.Forms.Label
    Private WithEvents LabelOffsetFromToday As System.Windows.Forms.Label
    Private WithEvents LabelSelectedDayOfYearDesc As System.Windows.Forms.Label
    Private WithEvents LabelSelectedDaysLeftDesc As System.Windows.Forms.Label
    Private WithEvents LabelOffsetFromTodayDesc As System.Windows.Forms.Label
    Private WithEvents LabelSelectedDateDesc As System.Windows.Forms.Label
    Private WithEvents LabelTCurrentDateDesc As System.Windows.Forms.Label
    Private WithEvents LabelCurrentDayOfYear As System.Windows.Forms.Label
    Private WithEvents LabelCurrentDaysLeft As System.Windows.Forms.Label
    Private WithEvents LabelCurrentDayOfYearDesc As System.Windows.Forms.Label
    Private WithEvents LabelCurrentDaysLeftDesc As System.Windows.Forms.Label
    Private WithEvents LabelCurrentDate As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents LabelOffset As System.Windows.Forms.Label
    Private WithEvents LabelLocal As System.Windows.Forms.Label
    Private WithEvents LabelUniversalDateTime As System.Windows.Forms.Label
    Private WithEvents LabelUniversal As System.Windows.Forms.Label
    Private WithEvents LabelLocalDateTime As System.Windows.Forms.Label
    Private WithEvents LabelOffsetFromUTC As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents labelSelectedHoliday As System.Windows.Forms.Label
    Private WithEvents LabelCurrentHoliday As System.Windows.Forms.Label
    Friend WithEvents LabelTimeInformation As System.Windows.Forms.Label
    Friend WithEvents LabelDateInfo As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents LabelDaylightEnd As System.Windows.Forms.Label
    Private WithEvents LabelDaylightEndDesc As System.Windows.Forms.Label
    Private WithEvents LabelDaylightStart As System.Windows.Forms.Label
    Private WithEvents LabelDaylightStartDesc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
