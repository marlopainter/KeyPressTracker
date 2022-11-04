
Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices
Imports System.Threading

Partial Public Class MainForm

    'Needed Code Snippet
    <DllImport("user32.dll")>
    Private Shared Function GetAsyncKeyState(ByVal vKey As Keys) As Boolean
    End Function

    'Function for Time Intervals
    Function IntervalMath(ByVal startTime As DateTime, ByVal endTime As DateTime) As Decimal

        tempInterval = endTime.Subtract(startTime)
        tempSeconds = tempInterval.TotalSeconds
        Return CDec(tempSeconds)

    End Function

    Sub DataReset() Handles uiResetAllData.Click

        If uiResetAllDataCheck.Checked = False Then

            'Do Nothing

        Else

            mouseScrollTravel_UP = 0
            mouseScrollTravel_UP_Converted = 0

            mouseScrollTravel_DN = 0
            mouseScrollTravel_DN_Converted = 0

            mouseScrollTravel_Total = 0
            mouseScrollTravel_Total_Converted = 0

            uiScrollDistanceTotal.ForeColor = unusedStatFontColor
            uiScrollDistanceUP.ForeColor = unusedStatFontColor
            uiScrollDistanceDN.ForeColor = unusedStatFontColor


            totalPresses = 0
            totalPressTime = 0
            averagePressTime = 0












            'ESC
            ui_Panel_ESC.BackColor = unusedKeyBackgroundColor
            ui_Label_ESC.BackColor = unusedKeyBackgroundColor
            ui_Label_ESC.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_ESC.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_ESC.ForeColor = unusedStatFontColor
            ui_totalPressTime_ESC.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_ESC.ForeColor = unusedStatFontColor
            ui_averagePressTime_ESC.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_ESC.ForeColor = unusedStatFontColor
            ui_percent_ESC.BackColor = unusedKeyBackgroundColor
            ui_percent_ESC.ForeColor = unusedStatFontColor
            ui_bind_ESC.BackColor = unusedTextboxBackgroundColor
            ui_bind_ESC.ForeColor = unusedStatFontColor

            isHeld_ESC = False
            pressCount_ESC = 0
            pressTimeInterval_ESC = 0
            pressTimeTotal_ESC = 0
            pressTimeTotalConverted_ESC = 0
            pressTimeAverage_ESC = 0

            ui_totalPresses_ESC.Text = pressCount_ESC.ToString
            ui_totalPressTime_ESC.Text = pressTimeTotal_ESC.ToString("N3") & " secs"
            ui_averagePressTime_ESC.Text = pressTimeAverage_ESC.ToString("N3") & " secs"
            ui_percent_ESC.Text = "0.000%"

            'F1
            ui_Panel_F1.BackColor = unusedKeyBackgroundColor
            ui_Label_F1.BackColor = unusedKeyBackgroundColor
            ui_Label_F1.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F1.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F1.ForeColor = unusedStatFontColor
            ui_totalPressTime_F1.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F1.ForeColor = unusedStatFontColor
            ui_averagePressTime_F1.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F1.ForeColor = unusedStatFontColor
            ui_percent_F1.BackColor = unusedKeyBackgroundColor
            ui_percent_F1.ForeColor = unusedStatFontColor
            ui_bind_F1.BackColor = unusedTextboxBackgroundColor
            ui_bind_F1.ForeColor = unusedStatFontColor

            isHeld_F1 = False
            pressCount_F1 = 0
            pressTimeInterval_F1 = 0
            pressTimeTotal_F1 = 0
            pressTimeTotalConverted_F1 = 0
            pressTimeAverage_F1 = 0

            ui_totalPresses_F1.Text = pressCount_F1.ToString
            ui_totalPressTime_F1.Text = pressTimeTotal_F1.ToString("N3") & " secs"
            ui_averagePressTime_F1.Text = pressTimeAverage_F1.ToString("N3") & " secs"
            ui_percent_F1.Text = "0.000%"

            'F2
            ui_Panel_F2.BackColor = unusedKeyBackgroundColor
            ui_Label_F2.BackColor = unusedKeyBackgroundColor
            ui_Label_F2.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F2.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F2.ForeColor = unusedStatFontColor
            ui_totalPressTime_F2.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F2.ForeColor = unusedStatFontColor
            ui_averagePressTime_F2.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F2.ForeColor = unusedStatFontColor
            ui_percent_F2.BackColor = unusedKeyBackgroundColor
            ui_percent_F2.ForeColor = unusedStatFontColor
            ui_bind_F2.BackColor = unusedTextboxBackgroundColor
            ui_bind_F2.ForeColor = unusedStatFontColor

            isHeld_F2 = False
            pressCount_F2 = 0
            pressTimeInterval_F2 = 0
            pressTimeTotal_F2 = 0
            pressTimeTotalConverted_F2 = 0
            pressTimeAverage_F2 = 0

            ui_totalPresses_F2.Text = pressCount_F2.ToString
            ui_totalPressTime_F2.Text = pressTimeTotal_F2.ToString("N3") & " secs"
            ui_averagePressTime_F2.Text = pressTimeAverage_F2.ToString("N3") & " secs"
            ui_percent_F2.Text = "0.000%"

            'F3
            ui_Panel_F3.BackColor = unusedKeyBackgroundColor
            ui_Label_F3.BackColor = unusedKeyBackgroundColor
            ui_Label_F3.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F3.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F3.ForeColor = unusedStatFontColor
            ui_totalPressTime_F3.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F3.ForeColor = unusedStatFontColor
            ui_averagePressTime_F3.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F3.ForeColor = unusedStatFontColor
            ui_percent_F3.BackColor = unusedKeyBackgroundColor
            ui_percent_F3.ForeColor = unusedStatFontColor
            ui_bind_F3.BackColor = unusedTextboxBackgroundColor
            ui_bind_F3.ForeColor = unusedStatFontColor

            isHeld_F3 = False
            pressCount_F3 = 0
            pressTimeInterval_F3 = 0
            pressTimeTotal_F3 = 0
            pressTimeTotalConverted_F3 = 0
            pressTimeAverage_F3 = 0

            ui_totalPresses_F3.Text = pressCount_F3.ToString
            ui_totalPressTime_F3.Text = pressTimeTotal_F3.ToString("N3") & " secs"
            ui_averagePressTime_F3.Text = pressTimeAverage_F3.ToString("N3") & " secs"
            ui_percent_F3.Text = "0.000%"

            'F4
            ui_Panel_F4.BackColor = unusedKeyBackgroundColor
            ui_Label_F4.BackColor = unusedKeyBackgroundColor
            ui_Label_F4.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F4.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F4.ForeColor = unusedStatFontColor
            ui_totalPressTime_F4.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F4.ForeColor = unusedStatFontColor
            ui_averagePressTime_F4.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F4.ForeColor = unusedStatFontColor
            ui_percent_F4.BackColor = unusedKeyBackgroundColor
            ui_percent_F4.ForeColor = unusedStatFontColor
            ui_bind_F4.BackColor = unusedTextboxBackgroundColor
            ui_bind_F4.ForeColor = unusedStatFontColor

            isHeld_F4 = False
            pressCount_F4 = 0
            pressTimeInterval_F4 = 0
            pressTimeTotal_F4 = 0
            pressTimeTotalConverted_F4 = 0
            pressTimeAverage_F4 = 0

            ui_totalPresses_F4.Text = pressCount_F4.ToString
            ui_totalPressTime_F4.Text = pressTimeTotal_F4.ToString("N3") & " secs"
            ui_averagePressTime_F4.Text = pressTimeAverage_F4.ToString("N3") & " secs"
            ui_percent_F4.Text = "0.000%"

            'F5
            ui_Panel_F5.BackColor = unusedKeyBackgroundColor
            ui_Label_F5.BackColor = unusedKeyBackgroundColor
            ui_Label_F5.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F5.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F5.ForeColor = unusedStatFontColor
            ui_totalPressTime_F5.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F5.ForeColor = unusedStatFontColor
            ui_averagePressTime_F5.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F5.ForeColor = unusedStatFontColor
            ui_percent_F5.BackColor = unusedKeyBackgroundColor
            ui_percent_F5.ForeColor = unusedStatFontColor
            ui_bind_F5.BackColor = unusedTextboxBackgroundColor
            ui_bind_F5.ForeColor = unusedStatFontColor

            isHeld_F5 = False
            pressCount_F5 = 0
            pressTimeInterval_F5 = 0
            pressTimeTotal_F5 = 0
            pressTimeTotalConverted_F5 = 0
            pressTimeAverage_F5 = 0

            ui_totalPresses_F5.Text = pressCount_F5.ToString
            ui_totalPressTime_F5.Text = pressTimeTotal_F5.ToString("N3") & " secs"
            ui_averagePressTime_F5.Text = pressTimeAverage_F5.ToString("N3") & " secs"
            ui_percent_F5.Text = "0.000%"

            'F6
            ui_Panel_F6.BackColor = unusedKeyBackgroundColor
            ui_Label_F6.BackColor = unusedKeyBackgroundColor
            ui_Label_F6.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F6.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F6.ForeColor = unusedStatFontColor
            ui_totalPressTime_F6.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F6.ForeColor = unusedStatFontColor
            ui_averagePressTime_F6.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F6.ForeColor = unusedStatFontColor
            ui_percent_F6.BackColor = unusedKeyBackgroundColor
            ui_percent_F6.ForeColor = unusedStatFontColor
            ui_bind_F6.BackColor = unusedTextboxBackgroundColor
            ui_bind_F6.ForeColor = unusedStatFontColor

            isHeld_F6 = False
            pressCount_F6 = 0
            pressTimeInterval_F6 = 0
            pressTimeTotal_F6 = 0
            pressTimeTotalConverted_F6 = 0
            pressTimeAverage_F6 = 0

            ui_totalPresses_F6.Text = pressCount_F6.ToString
            ui_totalPressTime_F6.Text = pressTimeTotal_F6.ToString("N3") & " secs"
            ui_averagePressTime_F6.Text = pressTimeAverage_F6.ToString("N3") & " secs"
            ui_percent_F6.Text = "0.000%"

            'F7
            ui_Panel_F7.BackColor = unusedKeyBackgroundColor
            ui_Label_F7.BackColor = unusedKeyBackgroundColor
            ui_Label_F7.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F7.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F7.ForeColor = unusedStatFontColor
            ui_totalPressTime_F7.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F7.ForeColor = unusedStatFontColor
            ui_averagePressTime_F7.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F7.ForeColor = unusedStatFontColor
            ui_percent_F7.BackColor = unusedKeyBackgroundColor
            ui_percent_F7.ForeColor = unusedStatFontColor
            ui_bind_F7.BackColor = unusedTextboxBackgroundColor
            ui_bind_F7.ForeColor = unusedStatFontColor

            isHeld_F7 = False
            pressCount_F7 = 0
            pressTimeInterval_F7 = 0
            pressTimeTotal_F7 = 0
            pressTimeTotalConverted_F7 = 0
            pressTimeAverage_F7 = 0

            ui_totalPresses_F7.Text = pressCount_F7.ToString
            ui_totalPressTime_F7.Text = pressTimeTotal_F7.ToString("N3") & " secs"
            ui_averagePressTime_F7.Text = pressTimeAverage_F7.ToString("N3") & " secs"
            ui_percent_F7.Text = "0.000%"

            'F8
            ui_Panel_F8.BackColor = unusedKeyBackgroundColor
            ui_Label_F8.BackColor = unusedKeyBackgroundColor
            ui_Label_F8.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F8.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F8.ForeColor = unusedStatFontColor
            ui_totalPressTime_F8.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F8.ForeColor = unusedStatFontColor
            ui_averagePressTime_F8.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F8.ForeColor = unusedStatFontColor
            ui_percent_F8.BackColor = unusedKeyBackgroundColor
            ui_percent_F8.ForeColor = unusedStatFontColor
            ui_bind_F8.BackColor = unusedTextboxBackgroundColor
            ui_bind_F8.ForeColor = unusedStatFontColor

            isHeld_F8 = False
            pressCount_F8 = 0
            pressTimeInterval_F8 = 0
            pressTimeTotal_F8 = 0
            pressTimeTotalConverted_F8 = 0
            pressTimeAverage_F8 = 0

            ui_totalPresses_F8.Text = pressCount_F8.ToString
            ui_totalPressTime_F8.Text = pressTimeTotal_F8.ToString("N3") & " secs"
            ui_averagePressTime_F8.Text = pressTimeAverage_F8.ToString("N3") & " secs"
            ui_percent_F8.Text = "0.000%"

            'F9
            ui_Panel_F9.BackColor = unusedKeyBackgroundColor
            ui_Label_F9.BackColor = unusedKeyBackgroundColor
            ui_Label_F9.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F9.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F9.ForeColor = unusedStatFontColor
            ui_totalPressTime_F9.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F9.ForeColor = unusedStatFontColor
            ui_averagePressTime_F9.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F9.ForeColor = unusedStatFontColor
            ui_percent_F9.BackColor = unusedKeyBackgroundColor
            ui_percent_F9.ForeColor = unusedStatFontColor
            ui_bind_F9.BackColor = unusedTextboxBackgroundColor
            ui_bind_F9.ForeColor = unusedStatFontColor

            isHeld_F9 = False
            pressCount_F9 = 0
            pressTimeInterval_F9 = 0
            pressTimeTotal_F9 = 0
            pressTimeTotalConverted_F9 = 0
            pressTimeAverage_F9 = 0

            ui_totalPresses_F9.Text = pressCount_F9.ToString
            ui_totalPressTime_F9.Text = pressTimeTotal_F9.ToString("N3") & " secs"
            ui_averagePressTime_F9.Text = pressTimeAverage_F9.ToString("N3") & " secs"
            ui_percent_F9.Text = "0.000%"

            'F10
            ui_Panel_F10.BackColor = unusedKeyBackgroundColor
            ui_Label_F10.BackColor = unusedKeyBackgroundColor
            ui_Label_F10.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F10.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F10.ForeColor = unusedStatFontColor
            ui_totalPressTime_F10.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F10.ForeColor = unusedStatFontColor
            ui_averagePressTime_F10.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F10.ForeColor = unusedStatFontColor
            ui_percent_F10.BackColor = unusedKeyBackgroundColor
            ui_percent_F10.ForeColor = unusedStatFontColor
            ui_bind_F10.BackColor = unusedTextboxBackgroundColor
            ui_bind_F10.ForeColor = unusedStatFontColor

            isHeld_F10 = False
            pressCount_F10 = 0
            pressTimeInterval_F10 = 0
            pressTimeTotal_F10 = 0
            pressTimeTotalConverted_F10 = 0
            pressTimeAverage_F10 = 0

            ui_totalPresses_F10.Text = pressCount_F10.ToString
            ui_totalPressTime_F10.Text = pressTimeTotal_F10.ToString("N3") & " secs"
            ui_averagePressTime_F10.Text = pressTimeAverage_F10.ToString("N3") & " secs"
            ui_percent_F10.Text = "0.000%"

            'F11
            ui_Panel_F11.BackColor = unusedKeyBackgroundColor
            ui_Label_F11.BackColor = unusedKeyBackgroundColor
            ui_Label_F11.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F11.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F11.ForeColor = unusedStatFontColor
            ui_totalPressTime_F11.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F11.ForeColor = unusedStatFontColor
            ui_averagePressTime_F11.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F11.ForeColor = unusedStatFontColor
            ui_percent_F11.BackColor = unusedKeyBackgroundColor
            ui_percent_F11.ForeColor = unusedStatFontColor
            ui_bind_F11.BackColor = unusedTextboxBackgroundColor
            ui_bind_F11.ForeColor = unusedStatFontColor

            isHeld_F11 = False
            pressCount_F11 = 0
            pressTimeInterval_F11 = 0
            pressTimeTotal_F11 = 0
            pressTimeTotalConverted_F11 = 0
            pressTimeAverage_F11 = 0

            ui_totalPresses_F11.Text = pressCount_F11.ToString
            ui_totalPressTime_F11.Text = pressTimeTotal_F11.ToString("N3") & " secs"
            ui_averagePressTime_F11.Text = pressTimeAverage_F11.ToString("N3") & " secs"
            ui_percent_F11.Text = "0.000%"

            'F12
            ui_Panel_F12.BackColor = unusedKeyBackgroundColor
            ui_Label_F12.BackColor = unusedKeyBackgroundColor
            ui_Label_F12.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F12.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F12.ForeColor = unusedStatFontColor
            ui_totalPressTime_F12.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F12.ForeColor = unusedStatFontColor
            ui_averagePressTime_F12.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F12.ForeColor = unusedStatFontColor
            ui_percent_F12.BackColor = unusedKeyBackgroundColor
            ui_percent_F12.ForeColor = unusedStatFontColor
            ui_bind_F12.BackColor = unusedTextboxBackgroundColor
            ui_bind_F12.ForeColor = unusedStatFontColor

            isHeld_F12 = False
            pressCount_F12 = 0
            pressTimeInterval_F12 = 0
            pressTimeTotal_F12 = 0
            pressTimeTotalConverted_F12 = 0
            pressTimeAverage_F12 = 0

            ui_totalPresses_F12.Text = pressCount_F12.ToString
            ui_totalPressTime_F12.Text = pressTimeTotal_F12.ToString("N3") & " secs"
            ui_averagePressTime_F12.Text = pressTimeAverage_F12.ToString("N3") & " secs"
            ui_percent_F12.Text = "0.000%"

            'PRNT
            ui_Panel_PRNT.BackColor = unusedKeyBackgroundColor
            ui_Label_PRNT.BackColor = unusedKeyBackgroundColor
            ui_Label_PRNT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_PRNT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_PRNT.ForeColor = unusedStatFontColor
            ui_totalPressTime_PRNT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_PRNT.ForeColor = unusedStatFontColor
            ui_averagePressTime_PRNT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_PRNT.ForeColor = unusedStatFontColor
            ui_percent_PRNT.BackColor = unusedKeyBackgroundColor
            ui_percent_PRNT.ForeColor = unusedStatFontColor
            ui_bind_PRNT.BackColor = unusedTextboxBackgroundColor
            ui_bind_PRNT.ForeColor = unusedStatFontColor

            isHeld_PRNT = False
            pressCount_PRNT = 0
            pressTimeInterval_PRNT = 0
            pressTimeTotal_PRNT = 0
            pressTimeTotalConverted_PRNT = 0
            pressTimeAverage_PRNT = 0

            ui_totalPresses_PRNT.Text = pressCount_PRNT.ToString
            ui_totalPressTime_PRNT.Text = pressTimeTotal_PRNT.ToString("N3") & " secs"
            ui_averagePressTime_PRNT.Text = pressTimeAverage_PRNT.ToString("N3") & " secs"
            ui_percent_PRNT.Text = "0.000%"

            'SCRLOCK
            ui_Panel_SCRLOCK.BackColor = unusedKeyBackgroundColor
            ui_Label_SCRLOCK.BackColor = unusedKeyBackgroundColor
            ui_Label_SCRLOCK.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_SCRLOCK.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_SCRLOCK.ForeColor = unusedStatFontColor
            ui_totalPressTime_SCRLOCK.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_SCRLOCK.ForeColor = unusedStatFontColor
            ui_averagePressTime_SCRLOCK.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_SCRLOCK.ForeColor = unusedStatFontColor
            ui_percent_SCRLOCK.BackColor = unusedKeyBackgroundColor
            ui_percent_SCRLOCK.ForeColor = unusedStatFontColor
            ui_bind_SCRLOCK.BackColor = unusedTextboxBackgroundColor
            ui_bind_SCRLOCK.ForeColor = unusedStatFontColor

            isHeld_SCRLOCK = False
            pressCount_SCRLOCK = 0
            pressTimeInterval_SCRLOCK = 0
            pressTimeTotal_SCRLOCK = 0
            pressTimeTotalConverted_SCRLOCK = 0
            pressTimeAverage_SCRLOCK = 0

            ui_totalPresses_SCRLOCK.Text = pressCount_SCRLOCK.ToString
            ui_totalPressTime_SCRLOCK.Text = pressTimeTotal_SCRLOCK.ToString("N3") & " secs"
            ui_averagePressTime_SCRLOCK.Text = pressTimeAverage_SCRLOCK.ToString("N3") & " secs"
            ui_percent_SCRLOCK.Text = "0.000%"

            'PAUSE
            ui_Panel_PAUSE.BackColor = unusedKeyBackgroundColor
            ui_Label_PAUSE.BackColor = unusedKeyBackgroundColor
            ui_Label_PAUSE.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_PAUSE.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_PAUSE.ForeColor = unusedStatFontColor
            ui_totalPressTime_PAUSE.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_PAUSE.ForeColor = unusedStatFontColor
            ui_averagePressTime_PAUSE.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_PAUSE.ForeColor = unusedStatFontColor
            ui_percent_PAUSE.BackColor = unusedKeyBackgroundColor
            ui_percent_PAUSE.ForeColor = unusedStatFontColor
            ui_bind_PAUSE.BackColor = unusedTextboxBackgroundColor
            ui_bind_PAUSE.ForeColor = unusedStatFontColor

            isHeld_PAUSE = False
            pressCount_PAUSE = 0
            pressTimeInterval_PAUSE = 0
            pressTimeTotal_PAUSE = 0
            pressTimeTotalConverted_PAUSE = 0
            pressTimeAverage_PAUSE = 0

            ui_totalPresses_PAUSE.Text = pressCount_PAUSE.ToString
            ui_totalPressTime_PAUSE.Text = pressTimeTotal_PAUSE.ToString("N3") & " secs"
            ui_averagePressTime_PAUSE.Text = pressTimeAverage_PAUSE.ToString("N3") & " secs"
            ui_percent_PAUSE.Text = "0.000%"

            'PLAY
            ui_Panel_PLAY.BackColor = unusedKeyBackgroundColor
            ui_Label_PLAY.BackColor = unusedKeyBackgroundColor
            ui_Label_PLAY.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_PLAY.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_PLAY.ForeColor = unusedStatFontColor
            ui_totalPressTime_PLAY.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_PLAY.ForeColor = unusedStatFontColor
            ui_averagePressTime_PLAY.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_PLAY.ForeColor = unusedStatFontColor
            ui_percent_PLAY.BackColor = unusedKeyBackgroundColor
            ui_percent_PLAY.ForeColor = unusedStatFontColor
            ui_bind_PLAY.BackColor = unusedTextboxBackgroundColor
            ui_bind_PLAY.ForeColor = unusedStatFontColor

            isHeld_PLAY = False
            pressCount_PLAY = 0
            pressTimeInterval_PLAY = 0
            pressTimeTotal_PLAY = 0
            pressTimeTotalConverted_PLAY = 0
            pressTimeAverage_PLAY = 0

            ui_totalPresses_PLAY.Text = pressCount_PLAY.ToString
            ui_totalPressTime_PLAY.Text = pressTimeTotal_PLAY.ToString("N3") & " secs"
            ui_averagePressTime_PLAY.Text = pressTimeAverage_PLAY.ToString("N3") & " secs"
            ui_percent_PLAY.Text = "0.000%"

            'STOP
            ui_Panel_STOP.BackColor = unusedKeyBackgroundColor
            ui_Label_STOP.BackColor = unusedKeyBackgroundColor
            ui_Label_STOP.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_STOP.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_STOP.ForeColor = unusedStatFontColor
            ui_totalPressTime_STOP.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_STOP.ForeColor = unusedStatFontColor
            ui_averagePressTime_STOP.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_STOP.ForeColor = unusedStatFontColor
            ui_percent_STOP.BackColor = unusedKeyBackgroundColor
            ui_percent_STOP.ForeColor = unusedStatFontColor
            ui_bind_STOP.BackColor = unusedTextboxBackgroundColor
            ui_bind_STOP.ForeColor = unusedStatFontColor

            isHeld_STOP = False
            pressCount_STOP = 0
            pressTimeInterval_STOP = 0
            pressTimeTotal_STOP = 0
            pressTimeTotalConverted_STOP = 0
            pressTimeAverage_STOP = 0

            ui_totalPresses_STOP.Text = pressCount_STOP.ToString
            ui_totalPressTime_STOP.Text = pressTimeTotal_STOP.ToString("N3") & " secs"
            ui_averagePressTime_STOP.Text = pressTimeAverage_STOP.ToString("N3") & " secs"
            ui_percent_STOP.Text = "0.000%"

            'PREV
            ui_Panel_PREV.BackColor = unusedKeyBackgroundColor
            ui_Label_PREV.BackColor = unusedKeyBackgroundColor
            ui_Label_PREV.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_PREV.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_PREV.ForeColor = unusedStatFontColor
            ui_totalPressTime_PREV.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_PREV.ForeColor = unusedStatFontColor
            ui_averagePressTime_PREV.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_PREV.ForeColor = unusedStatFontColor
            ui_percent_PREV.BackColor = unusedKeyBackgroundColor
            ui_percent_PREV.ForeColor = unusedStatFontColor
            ui_bind_PREV.BackColor = unusedTextboxBackgroundColor
            ui_bind_PREV.ForeColor = unusedStatFontColor

            isHeld_PREV = False
            pressCount_PREV = 0
            pressTimeInterval_PREV = 0
            pressTimeTotal_PREV = 0
            pressTimeTotalConverted_PREV = 0
            pressTimeAverage_PREV = 0

            ui_totalPresses_PREV.Text = pressCount_PREV.ToString
            ui_totalPressTime_PREV.Text = pressTimeTotal_PREV.ToString("N3") & " secs"
            ui_averagePressTime_PREV.Text = pressTimeAverage_PREV.ToString("N3") & " secs"
            ui_percent_PREV.Text = "0.000%"

            'NEXT
            ui_Panel_NEXT.BackColor = unusedKeyBackgroundColor
            ui_Label_NEXT.BackColor = unusedKeyBackgroundColor
            ui_Label_NEXT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_NEXT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_NEXT.ForeColor = unusedStatFontColor
            ui_totalPressTime_NEXT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_NEXT.ForeColor = unusedStatFontColor
            ui_averagePressTime_NEXT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_NEXT.ForeColor = unusedStatFontColor
            ui_percent_NEXT.BackColor = unusedKeyBackgroundColor
            ui_percent_NEXT.ForeColor = unusedStatFontColor
            ui_bind_NEXT.BackColor = unusedTextboxBackgroundColor
            ui_bind_NEXT.ForeColor = unusedStatFontColor

            isHeld_NEXT = False
            pressCount_NEXT = 0
            pressTimeInterval_NEXT = 0
            pressTimeTotal_NEXT = 0
            pressTimeTotalConverted_NEXT = 0
            pressTimeAverage_NEXT = 0

            ui_totalPresses_NEXT.Text = pressCount_NEXT.ToString
            ui_totalPressTime_NEXT.Text = pressTimeTotal_NEXT.ToString("N3") & " secs"
            ui_averagePressTime_NEXT.Text = pressTimeAverage_NEXT.ToString("N3") & " secs"
            ui_percent_NEXT.Text = "0.000%"

            'TILDE
            ui_Panel_TILDE.BackColor = unusedKeyBackgroundColor
            ui_Label_TILDE.BackColor = unusedKeyBackgroundColor
            ui_Label_TILDE.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_TILDE.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_TILDE.ForeColor = unusedStatFontColor
            ui_totalPressTime_TILDE.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_TILDE.ForeColor = unusedStatFontColor
            ui_averagePressTime_TILDE.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_TILDE.ForeColor = unusedStatFontColor
            ui_percent_TILDE.BackColor = unusedKeyBackgroundColor
            ui_percent_TILDE.ForeColor = unusedStatFontColor
            ui_bind_TILDE.BackColor = unusedTextboxBackgroundColor
            ui_bind_TILDE.ForeColor = unusedStatFontColor

            isHeld_TILDE = False
            pressCount_TILDE = 0
            pressTimeInterval_TILDE = 0
            pressTimeTotal_TILDE = 0
            pressTimeTotalConverted_TILDE = 0
            pressTimeAverage_TILDE = 0

            ui_totalPresses_TILDE.Text = pressCount_TILDE.ToString
            ui_totalPressTime_TILDE.Text = pressTimeTotal_TILDE.ToString("N3") & " secs"
            ui_averagePressTime_TILDE.Text = pressTimeAverage_TILDE.ToString("N3") & " secs"
            ui_percent_TILDE.Text = "0.000%"

            '1
            ui_Panel_1.BackColor = unusedKeyBackgroundColor
            ui_Label_1.BackColor = unusedKeyBackgroundColor
            ui_Label_1.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_1.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_1.ForeColor = unusedStatFontColor
            ui_totalPressTime_1.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_1.ForeColor = unusedStatFontColor
            ui_averagePressTime_1.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_1.ForeColor = unusedStatFontColor
            ui_percent_1.BackColor = unusedKeyBackgroundColor
            ui_percent_1.ForeColor = unusedStatFontColor
            ui_bind_1.BackColor = unusedTextboxBackgroundColor
            ui_bind_1.ForeColor = unusedStatFontColor

            isHeld_1 = False
            pressCount_1 = 0
            pressTimeInterval_1 = 0
            pressTimeTotal_1 = 0
            pressTimeTotalConverted_1 = 0
            pressTimeAverage_1 = 0

            ui_totalPresses_1.Text = pressCount_1.ToString
            ui_totalPressTime_1.Text = pressTimeTotal_1.ToString("N3") & " secs"
            ui_averagePressTime_1.Text = pressTimeAverage_1.ToString("N3") & " secs"
            ui_percent_1.Text = "0.000%"

            '2
            ui_Panel_2.BackColor = unusedKeyBackgroundColor
            ui_Label_2.BackColor = unusedKeyBackgroundColor
            ui_Label_2.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_2.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_2.ForeColor = unusedStatFontColor
            ui_totalPressTime_2.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_2.ForeColor = unusedStatFontColor
            ui_averagePressTime_2.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_2.ForeColor = unusedStatFontColor
            ui_percent_2.BackColor = unusedKeyBackgroundColor
            ui_percent_2.ForeColor = unusedStatFontColor
            ui_bind_2.BackColor = unusedTextboxBackgroundColor
            ui_bind_2.ForeColor = unusedStatFontColor

            isHeld_2 = False
            pressCount_2 = 0
            pressTimeInterval_2 = 0
            pressTimeTotal_2 = 0
            pressTimeTotalConverted_2 = 0
            pressTimeAverage_2 = 0

            ui_totalPresses_2.Text = pressCount_2.ToString
            ui_totalPressTime_2.Text = pressTimeTotal_2.ToString("N3") & " secs"
            ui_averagePressTime_2.Text = pressTimeAverage_2.ToString("N3") & " secs"
            ui_percent_2.Text = "0.000%"

            '3
            ui_Panel_3.BackColor = unusedKeyBackgroundColor
            ui_Label_3.BackColor = unusedKeyBackgroundColor
            ui_Label_3.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_3.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_3.ForeColor = unusedStatFontColor
            ui_totalPressTime_3.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_3.ForeColor = unusedStatFontColor
            ui_averagePressTime_3.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_3.ForeColor = unusedStatFontColor
            ui_percent_3.BackColor = unusedKeyBackgroundColor
            ui_percent_3.ForeColor = unusedStatFontColor
            ui_bind_3.BackColor = unusedTextboxBackgroundColor
            ui_bind_3.ForeColor = unusedStatFontColor

            isHeld_3 = False
            pressCount_3 = 0
            pressTimeInterval_3 = 0
            pressTimeTotal_3 = 0
            pressTimeTotalConverted_3 = 0
            pressTimeAverage_3 = 0

            ui_totalPresses_3.Text = pressCount_3.ToString
            ui_totalPressTime_3.Text = pressTimeTotal_3.ToString("N3") & " secs"
            ui_averagePressTime_3.Text = pressTimeAverage_3.ToString("N3") & " secs"
            ui_percent_3.Text = "0.000%"

            '4
            ui_Panel_4.BackColor = unusedKeyBackgroundColor
            ui_Label_4.BackColor = unusedKeyBackgroundColor
            ui_Label_4.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_4.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_4.ForeColor = unusedStatFontColor
            ui_totalPressTime_4.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_4.ForeColor = unusedStatFontColor
            ui_averagePressTime_4.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_4.ForeColor = unusedStatFontColor
            ui_percent_4.BackColor = unusedKeyBackgroundColor
            ui_percent_4.ForeColor = unusedStatFontColor
            ui_bind_4.BackColor = unusedTextboxBackgroundColor
            ui_bind_4.ForeColor = unusedStatFontColor

            isHeld_4 = False
            pressCount_4 = 0
            pressTimeInterval_4 = 0
            pressTimeTotal_4 = 0
            pressTimeTotalConverted_4 = 0
            pressTimeAverage_4 = 0

            ui_totalPresses_4.Text = pressCount_4.ToString
            ui_totalPressTime_4.Text = pressTimeTotal_4.ToString("N3") & " secs"
            ui_averagePressTime_4.Text = pressTimeAverage_4.ToString("N3") & " secs"
            ui_percent_4.Text = "0.000%"

            '5
            ui_Panel_5.BackColor = unusedKeyBackgroundColor
            ui_Label_5.BackColor = unusedKeyBackgroundColor
            ui_Label_5.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_5.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_5.ForeColor = unusedStatFontColor
            ui_totalPressTime_5.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_5.ForeColor = unusedStatFontColor
            ui_averagePressTime_5.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_5.ForeColor = unusedStatFontColor
            ui_percent_5.BackColor = unusedKeyBackgroundColor
            ui_percent_5.ForeColor = unusedStatFontColor
            ui_bind_5.BackColor = unusedTextboxBackgroundColor
            ui_bind_5.ForeColor = unusedStatFontColor

            isHeld_5 = False
            pressCount_5 = 0
            pressTimeInterval_5 = 0
            pressTimeTotal_5 = 0
            pressTimeTotalConverted_5 = 0
            pressTimeAverage_5 = 0

            ui_totalPresses_5.Text = pressCount_5.ToString
            ui_totalPressTime_5.Text = pressTimeTotal_5.ToString("N3") & " secs"
            ui_averagePressTime_5.Text = pressTimeAverage_5.ToString("N3") & " secs"
            ui_percent_5.Text = "0.000%"

            '6
            ui_Panel_6.BackColor = unusedKeyBackgroundColor
            ui_Label_6.BackColor = unusedKeyBackgroundColor
            ui_Label_6.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_6.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_6.ForeColor = unusedStatFontColor
            ui_totalPressTime_6.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_6.ForeColor = unusedStatFontColor
            ui_averagePressTime_6.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_6.ForeColor = unusedStatFontColor
            ui_percent_6.BackColor = unusedKeyBackgroundColor
            ui_percent_6.ForeColor = unusedStatFontColor
            ui_bind_6.BackColor = unusedTextboxBackgroundColor
            ui_bind_6.ForeColor = unusedStatFontColor

            isHeld_6 = False
            pressCount_6 = 0
            pressTimeInterval_6 = 0
            pressTimeTotal_6 = 0
            pressTimeTotalConverted_6 = 0
            pressTimeAverage_6 = 0

            ui_totalPresses_6.Text = pressCount_6.ToString
            ui_totalPressTime_6.Text = pressTimeTotal_6.ToString("N3") & " secs"
            ui_averagePressTime_6.Text = pressTimeAverage_6.ToString("N3") & " secs"
            ui_percent_6.Text = "0.000%"

            '7
            ui_Panel_7.BackColor = unusedKeyBackgroundColor
            ui_Label_7.BackColor = unusedKeyBackgroundColor
            ui_Label_7.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_7.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_7.ForeColor = unusedStatFontColor
            ui_totalPressTime_7.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_7.ForeColor = unusedStatFontColor
            ui_averagePressTime_7.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_7.ForeColor = unusedStatFontColor
            ui_percent_7.BackColor = unusedKeyBackgroundColor
            ui_percent_7.ForeColor = unusedStatFontColor
            ui_bind_7.BackColor = unusedTextboxBackgroundColor
            ui_bind_7.ForeColor = unusedStatFontColor

            isHeld_7 = False
            pressCount_7 = 0
            pressTimeInterval_7 = 0
            pressTimeTotal_7 = 0
            pressTimeTotalConverted_7 = 0
            pressTimeAverage_7 = 0

            ui_totalPresses_7.Text = pressCount_7.ToString
            ui_totalPressTime_7.Text = pressTimeTotal_7.ToString("N3") & " secs"
            ui_averagePressTime_7.Text = pressTimeAverage_7.ToString("N3") & " secs"
            ui_percent_7.Text = "0.000%"

            '8
            ui_Panel_8.BackColor = unusedKeyBackgroundColor
            ui_Label_8.BackColor = unusedKeyBackgroundColor
            ui_Label_8.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_8.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_8.ForeColor = unusedStatFontColor
            ui_totalPressTime_8.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_8.ForeColor = unusedStatFontColor
            ui_averagePressTime_8.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_8.ForeColor = unusedStatFontColor
            ui_percent_8.BackColor = unusedKeyBackgroundColor
            ui_percent_8.ForeColor = unusedStatFontColor
            ui_bind_8.BackColor = unusedTextboxBackgroundColor
            ui_bind_8.ForeColor = unusedStatFontColor

            isHeld_8 = False
            pressCount_8 = 0
            pressTimeInterval_8 = 0
            pressTimeTotal_8 = 0
            pressTimeTotalConverted_8 = 0
            pressTimeAverage_8 = 0

            ui_totalPresses_8.Text = pressCount_8.ToString
            ui_totalPressTime_8.Text = pressTimeTotal_8.ToString("N3") & " secs"
            ui_averagePressTime_8.Text = pressTimeAverage_8.ToString("N3") & " secs"
            ui_percent_8.Text = "0.000%"

            '9
            ui_Panel_9.BackColor = unusedKeyBackgroundColor
            ui_Label_9.BackColor = unusedKeyBackgroundColor
            ui_Label_9.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_9.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_9.ForeColor = unusedStatFontColor
            ui_totalPressTime_9.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_9.ForeColor = unusedStatFontColor
            ui_averagePressTime_9.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_9.ForeColor = unusedStatFontColor
            ui_percent_9.BackColor = unusedKeyBackgroundColor
            ui_percent_9.ForeColor = unusedStatFontColor
            ui_bind_9.BackColor = unusedTextboxBackgroundColor
            ui_bind_9.ForeColor = unusedStatFontColor

            isHeld_9 = False
            pressCount_9 = 0
            pressTimeInterval_9 = 0
            pressTimeTotal_9 = 0
            pressTimeTotalConverted_9 = 0
            pressTimeAverage_9 = 0

            ui_totalPresses_9.Text = pressCount_9.ToString
            ui_totalPressTime_9.Text = pressTimeTotal_9.ToString("N3") & " secs"
            ui_averagePressTime_9.Text = pressTimeAverage_9.ToString("N3") & " secs"
            ui_percent_9.Text = "0.000%"

            '0
            ui_Panel_0.BackColor = unusedKeyBackgroundColor
            ui_Label_0.BackColor = unusedKeyBackgroundColor
            ui_Label_0.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_0.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_0.ForeColor = unusedStatFontColor
            ui_totalPressTime_0.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_0.ForeColor = unusedStatFontColor
            ui_averagePressTime_0.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_0.ForeColor = unusedStatFontColor
            ui_percent_0.BackColor = unusedKeyBackgroundColor
            ui_percent_0.ForeColor = unusedStatFontColor
            ui_bind_0.BackColor = unusedTextboxBackgroundColor
            ui_bind_0.ForeColor = unusedStatFontColor

            isHeld_0 = False
            pressCount_0 = 0
            pressTimeInterval_0 = 0
            pressTimeTotal_0 = 0
            pressTimeTotalConverted_0 = 0
            pressTimeAverage_0 = 0

            ui_totalPresses_0.Text = pressCount_0.ToString
            ui_totalPressTime_0.Text = pressTimeTotal_0.ToString("N3") & " secs"
            ui_averagePressTime_0.Text = pressTimeAverage_0.ToString("N3") & " secs"
            ui_percent_0.Text = "0.000%"

            'UnderScore
            ui_Panel_UnderScore.BackColor = unusedKeyBackgroundColor
            ui_Label_UnderScore.BackColor = unusedKeyBackgroundColor
            ui_Label_UnderScore.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_UnderScore.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_UnderScore.ForeColor = unusedStatFontColor
            ui_totalPressTime_UnderScore.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_UnderScore.ForeColor = unusedStatFontColor
            ui_averagePressTime_UnderScore.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_UnderScore.ForeColor = unusedStatFontColor
            ui_percent_UnderScore.BackColor = unusedKeyBackgroundColor
            ui_percent_UnderScore.ForeColor = unusedStatFontColor
            ui_bind_UnderScore.BackColor = unusedTextboxBackgroundColor
            ui_bind_UnderScore.ForeColor = unusedStatFontColor

            isHeld_UnderScore = False
            pressCount_UnderScore = 0
            pressTimeInterval_UnderScore = 0
            pressTimeTotal_UnderScore = 0
            pressTimeTotalConverted_UnderScore = 0
            pressTimeAverage_UnderScore = 0

            ui_totalPresses_UnderScore.Text = pressCount_UnderScore.ToString
            ui_totalPressTime_UnderScore.Text = pressTimeTotal_UnderScore.ToString("N3") & " secs"
            ui_averagePressTime_UnderScore.Text = pressTimeAverage_UnderScore.ToString("N3") & " secs"
            ui_percent_UnderScore.Text = "0.000%"

            'PlusEquals
            ui_Panel_PlusEquals.BackColor = unusedKeyBackgroundColor
            ui_Label_PlusEquals.BackColor = unusedKeyBackgroundColor
            ui_Label_PlusEquals.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_PlusEquals.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_PlusEquals.ForeColor = unusedStatFontColor
            ui_totalPressTime_PlusEquals.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_PlusEquals.ForeColor = unusedStatFontColor
            ui_averagePressTime_PlusEquals.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_PlusEquals.ForeColor = unusedStatFontColor
            ui_percent_PlusEquals.BackColor = unusedKeyBackgroundColor
            ui_percent_PlusEquals.ForeColor = unusedStatFontColor
            ui_bind_PlusEquals.BackColor = unusedTextboxBackgroundColor
            ui_bind_PlusEquals.ForeColor = unusedStatFontColor

            isHeld_PlusEquals = False
            pressCount_PlusEquals = 0
            pressTimeInterval_PlusEquals = 0
            pressTimeTotal_PlusEquals = 0
            pressTimeTotalConverted_PlusEquals = 0
            pressTimeAverage_PlusEquals = 0

            ui_totalPresses_PlusEquals.Text = pressCount_PlusEquals.ToString
            ui_totalPressTime_PlusEquals.Text = pressTimeTotal_PlusEquals.ToString("N3") & " secs"
            ui_averagePressTime_PlusEquals.Text = pressTimeAverage_PlusEquals.ToString("N3") & " secs"
            ui_percent_PlusEquals.Text = "0.000%"

            'BackSpace
            ui_Panel_BackSpace.BackColor = unusedKeyBackgroundColor
            ui_Label_BackSpace.BackColor = unusedKeyBackgroundColor
            ui_Label_BackSpace.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_BackSpace.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_BackSpace.ForeColor = unusedStatFontColor
            ui_totalPressTime_BackSpace.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_BackSpace.ForeColor = unusedStatFontColor
            ui_averagePressTime_BackSpace.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_BackSpace.ForeColor = unusedStatFontColor
            ui_percent_BackSpace.BackColor = unusedKeyBackgroundColor
            ui_percent_BackSpace.ForeColor = unusedStatFontColor
            ui_bind_BackSpace.BackColor = unusedTextboxBackgroundColor
            ui_bind_BackSpace.ForeColor = unusedStatFontColor

            isHeld_BackSpace = False
            pressCount_BackSpace = 0
            pressTimeInterval_BackSpace = 0
            pressTimeTotal_BackSpace = 0
            pressTimeTotalConverted_BackSpace = 0
            pressTimeAverage_BackSpace = 0

            ui_totalPresses_BackSpace.Text = pressCount_BackSpace.ToString
            ui_totalPressTime_BackSpace.Text = pressTimeTotal_BackSpace.ToString("N3") & " secs"
            ui_averagePressTime_BackSpace.Text = pressTimeAverage_BackSpace.ToString("N3") & " secs"
            ui_percent_BackSpace.Text = "0.000%"

            'Insert
            ui_Panel_Insert.BackColor = unusedKeyBackgroundColor
            ui_Label_Insert.BackColor = unusedKeyBackgroundColor
            ui_Label_Insert.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Insert.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Insert.ForeColor = unusedStatFontColor
            ui_totalPressTime_Insert.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Insert.ForeColor = unusedStatFontColor
            ui_averagePressTime_Insert.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Insert.ForeColor = unusedStatFontColor
            ui_percent_Insert.BackColor = unusedKeyBackgroundColor
            ui_percent_Insert.ForeColor = unusedStatFontColor
            ui_bind_Insert.BackColor = unusedTextboxBackgroundColor
            ui_bind_Insert.ForeColor = unusedStatFontColor

            isHeld_Insert = False
            pressCount_Insert = 0
            pressTimeInterval_Insert = 0
            pressTimeTotal_Insert = 0
            pressTimeTotalConverted_Insert = 0
            pressTimeAverage_Insert = 0

            ui_totalPresses_Insert.Text = pressCount_Insert.ToString
            ui_totalPressTime_Insert.Text = pressTimeTotal_Insert.ToString("N3") & " secs"
            ui_averagePressTime_Insert.Text = pressTimeAverage_Insert.ToString("N3") & " secs"
            ui_percent_Insert.Text = "0.000%"

            'Home
            ui_Panel_Home.BackColor = unusedKeyBackgroundColor
            ui_Label_Home.BackColor = unusedKeyBackgroundColor
            ui_Label_Home.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Home.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Home.ForeColor = unusedStatFontColor
            ui_totalPressTime_Home.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Home.ForeColor = unusedStatFontColor
            ui_averagePressTime_Home.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Home.ForeColor = unusedStatFontColor
            ui_percent_Home.BackColor = unusedKeyBackgroundColor
            ui_percent_Home.ForeColor = unusedStatFontColor
            ui_bind_Home.BackColor = unusedTextboxBackgroundColor
            ui_bind_Home.ForeColor = unusedStatFontColor

            isHeld_Home = False
            pressCount_Home = 0
            pressTimeInterval_Home = 0
            pressTimeTotal_Home = 0
            pressTimeTotalConverted_Home = 0
            pressTimeAverage_Home = 0

            ui_totalPresses_Home.Text = pressCount_Home.ToString
            ui_totalPressTime_Home.Text = pressTimeTotal_Home.ToString("N3") & " secs"
            ui_averagePressTime_Home.Text = pressTimeAverage_Home.ToString("N3") & " secs"
            ui_percent_Home.Text = "0.000%"

            'PgUp
            ui_Panel_PgUp.BackColor = unusedKeyBackgroundColor
            ui_Label_PgUp.BackColor = unusedKeyBackgroundColor
            ui_Label_PgUp.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_PgUp.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_PgUp.ForeColor = unusedStatFontColor
            ui_totalPressTime_PgUp.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_PgUp.ForeColor = unusedStatFontColor
            ui_averagePressTime_PgUp.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_PgUp.ForeColor = unusedStatFontColor
            ui_percent_PgUp.BackColor = unusedKeyBackgroundColor
            ui_percent_PgUp.ForeColor = unusedStatFontColor
            ui_bind_PgUp.BackColor = unusedTextboxBackgroundColor
            ui_bind_PgUp.ForeColor = unusedStatFontColor

            isHeld_PgUp = False
            pressCount_PgUp = 0
            pressTimeInterval_PgUp = 0
            pressTimeTotal_PgUp = 0
            pressTimeTotalConverted_PgUp = 0
            pressTimeAverage_PgUp = 0

            ui_totalPresses_PgUp.Text = pressCount_PgUp.ToString
            ui_totalPressTime_PgUp.Text = pressTimeTotal_PgUp.ToString("N3") & " secs"
            ui_averagePressTime_PgUp.Text = pressTimeAverage_PgUp.ToString("N3") & " secs"
            ui_percent_PgUp.Text = "0.000%"

            'NumLock
            ui_Panel_NumLock.BackColor = unusedKeyBackgroundColor
            ui_Label_NumLock.BackColor = unusedKeyBackgroundColor
            ui_Label_NumLock.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_NumLock.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_NumLock.ForeColor = unusedStatFontColor
            ui_totalPressTime_NumLock.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_NumLock.ForeColor = unusedStatFontColor
            ui_averagePressTime_NumLock.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_NumLock.ForeColor = unusedStatFontColor
            ui_percent_NumLock.BackColor = unusedKeyBackgroundColor
            ui_percent_NumLock.ForeColor = unusedStatFontColor
            ui_bind_NumLock.BackColor = unusedTextboxBackgroundColor
            ui_bind_NumLock.ForeColor = unusedStatFontColor

            isHeld_NumLock = False
            pressCount_NumLock = 0
            pressTimeInterval_NumLock = 0
            pressTimeTotal_NumLock = 0
            pressTimeTotalConverted_NumLock = 0
            pressTimeAverage_NumLock = 0

            ui_totalPresses_NumLock.Text = pressCount_NumLock.ToString
            ui_totalPressTime_NumLock.Text = pressTimeTotal_NumLock.ToString("N3") & " secs"
            ui_averagePressTime_NumLock.Text = pressTimeAverage_NumLock.ToString("N3") & " secs"
            ui_percent_NumLock.Text = "0.000%"

            'Divide
            ui_Panel_Divide.BackColor = unusedKeyBackgroundColor
            ui_Label_Divide.BackColor = unusedKeyBackgroundColor
            ui_Label_Divide.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Divide.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Divide.ForeColor = unusedStatFontColor
            ui_totalPressTime_Divide.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Divide.ForeColor = unusedStatFontColor
            ui_averagePressTime_Divide.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Divide.ForeColor = unusedStatFontColor
            ui_percent_Divide.BackColor = unusedKeyBackgroundColor
            ui_percent_Divide.ForeColor = unusedStatFontColor
            ui_bind_Divide.BackColor = unusedTextboxBackgroundColor
            ui_bind_Divide.ForeColor = unusedStatFontColor

            isHeld_Divide = False
            pressCount_Divide = 0
            pressTimeInterval_Divide = 0
            pressTimeTotal_Divide = 0
            pressTimeTotalConverted_Divide = 0
            pressTimeAverage_Divide = 0

            ui_totalPresses_Divide.Text = pressCount_Divide.ToString
            ui_totalPressTime_Divide.Text = pressTimeTotal_Divide.ToString("N3") & " secs"
            ui_averagePressTime_Divide.Text = pressTimeAverage_Divide.ToString("N3") & " secs"
            ui_percent_Divide.Text = "0.000%"

            'Multiply
            ui_Panel_Multiply.BackColor = unusedKeyBackgroundColor
            ui_Label_Multiply.BackColor = unusedKeyBackgroundColor
            ui_Label_Multiply.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Multiply.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Multiply.ForeColor = unusedStatFontColor
            ui_totalPressTime_Multiply.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Multiply.ForeColor = unusedStatFontColor
            ui_averagePressTime_Multiply.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Multiply.ForeColor = unusedStatFontColor
            ui_percent_Multiply.BackColor = unusedKeyBackgroundColor
            ui_percent_Multiply.ForeColor = unusedStatFontColor
            ui_bind_Multiply.BackColor = unusedTextboxBackgroundColor
            ui_bind_Multiply.ForeColor = unusedStatFontColor

            isHeld_Multiply = False
            pressCount_Multiply = 0
            pressTimeInterval_Multiply = 0
            pressTimeTotal_Multiply = 0
            pressTimeTotalConverted_Multiply = 0
            pressTimeAverage_Multiply = 0

            ui_totalPresses_Multiply.Text = pressCount_Multiply.ToString
            ui_totalPressTime_Multiply.Text = pressTimeTotal_Multiply.ToString("N3") & " secs"
            ui_averagePressTime_Multiply.Text = pressTimeAverage_Multiply.ToString("N3") & " secs"
            ui_percent_Multiply.Text = "0.000%"

            'Minus
            ui_Panel_Minus.BackColor = unusedKeyBackgroundColor
            ui_Label_Minus.BackColor = unusedKeyBackgroundColor
            ui_Label_Minus.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Minus.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Minus.ForeColor = unusedStatFontColor
            ui_totalPressTime_Minus.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Minus.ForeColor = unusedStatFontColor
            ui_averagePressTime_Minus.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Minus.ForeColor = unusedStatFontColor
            ui_percent_Minus.BackColor = unusedKeyBackgroundColor
            ui_percent_Minus.ForeColor = unusedStatFontColor
            ui_bind_Minus.BackColor = unusedTextboxBackgroundColor
            ui_bind_Minus.ForeColor = unusedStatFontColor

            isHeld_Minus = False
            pressCount_Minus = 0
            pressTimeInterval_Minus = 0
            pressTimeTotal_Minus = 0
            pressTimeTotalConverted_Minus = 0
            pressTimeAverage_Minus = 0

            ui_totalPresses_Minus.Text = pressCount_Minus.ToString
            ui_totalPressTime_Minus.Text = pressTimeTotal_Minus.ToString("N3") & " secs"
            ui_averagePressTime_Minus.Text = pressTimeAverage_Minus.ToString("N3") & " secs"
            ui_percent_Minus.Text = "0.000%"

            'TAB
            ui_Panel_TAB.BackColor = unusedKeyBackgroundColor
            ui_Label_TAB.BackColor = unusedKeyBackgroundColor
            ui_Label_TAB.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_TAB.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_TAB.ForeColor = unusedStatFontColor
            ui_totalPressTime_TAB.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_TAB.ForeColor = unusedStatFontColor
            ui_averagePressTime_TAB.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_TAB.ForeColor = unusedStatFontColor
            ui_percent_TAB.BackColor = unusedKeyBackgroundColor
            ui_percent_TAB.ForeColor = unusedStatFontColor
            ui_bind_TAB.BackColor = unusedTextboxBackgroundColor
            ui_bind_TAB.ForeColor = unusedStatFontColor

            isHeld_TAB = False
            pressCount_TAB = 0
            pressTimeInterval_TAB = 0
            pressTimeTotal_TAB = 0
            pressTimeTotalConverted_TAB = 0
            pressTimeAverage_TAB = 0

            ui_totalPresses_TAB.Text = pressCount_TAB.ToString
            ui_totalPressTime_TAB.Text = pressTimeTotal_TAB.ToString("N3") & " secs"
            ui_averagePressTime_TAB.Text = pressTimeAverage_TAB.ToString("N3") & " secs"
            ui_percent_TAB.Text = "0.000%"

            'Q
            ui_Panel_Q.BackColor = unusedKeyBackgroundColor
            ui_Label_Q.BackColor = unusedKeyBackgroundColor
            ui_Label_Q.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Q.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Q.ForeColor = unusedStatFontColor
            ui_totalPressTime_Q.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Q.ForeColor = unusedStatFontColor
            ui_averagePressTime_Q.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Q.ForeColor = unusedStatFontColor
            ui_percent_Q.BackColor = unusedKeyBackgroundColor
            ui_percent_Q.ForeColor = unusedStatFontColor
            ui_bind_Q.BackColor = unusedTextboxBackgroundColor
            ui_bind_Q.ForeColor = unusedStatFontColor

            isHeld_Q = False
            pressCount_Q = 0
            pressTimeInterval_Q = 0
            pressTimeTotal_Q = 0
            pressTimeTotalConverted_Q = 0
            pressTimeAverage_Q = 0

            ui_totalPresses_Q.Text = pressCount_Q.ToString
            ui_totalPressTime_Q.Text = pressTimeTotal_Q.ToString("N3") & " secs"
            ui_averagePressTime_Q.Text = pressTimeAverage_Q.ToString("N3") & " secs"
            ui_percent_Q.Text = "0.000%"

            'W
            ui_Panel_W.BackColor = unusedKeyBackgroundColor
            ui_Label_W.BackColor = unusedKeyBackgroundColor
            ui_Label_W.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_W.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_W.ForeColor = unusedStatFontColor
            ui_totalPressTime_W.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_W.ForeColor = unusedStatFontColor
            ui_averagePressTime_W.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_W.ForeColor = unusedStatFontColor
            ui_percent_W.BackColor = unusedKeyBackgroundColor
            ui_percent_W.ForeColor = unusedStatFontColor
            ui_bind_W.BackColor = unusedTextboxBackgroundColor
            ui_bind_W.ForeColor = unusedStatFontColor

            isHeld_W = False
            pressCount_W = 0
            pressTimeInterval_W = 0
            pressTimeTotal_W = 0
            pressTimeTotalConverted_W = 0
            pressTimeAverage_W = 0

            ui_totalPresses_W.Text = pressCount_W.ToString
            ui_totalPressTime_W.Text = pressTimeTotal_W.ToString("N3") & " secs"
            ui_averagePressTime_W.Text = pressTimeAverage_W.ToString("N3") & " secs"
            ui_percent_W.Text = "0.000%"

            'E
            ui_Panel_E.BackColor = unusedKeyBackgroundColor
            ui_Label_E.BackColor = unusedKeyBackgroundColor
            ui_Label_E.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_E.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_E.ForeColor = unusedStatFontColor
            ui_totalPressTime_E.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_E.ForeColor = unusedStatFontColor
            ui_averagePressTime_E.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_E.ForeColor = unusedStatFontColor
            ui_percent_E.BackColor = unusedKeyBackgroundColor
            ui_percent_E.ForeColor = unusedStatFontColor
            ui_bind_E.BackColor = unusedTextboxBackgroundColor
            ui_bind_E.ForeColor = unusedStatFontColor

            isHeld_E = False
            pressCount_E = 0
            pressTimeInterval_E = 0
            pressTimeTotal_E = 0
            pressTimeTotalConverted_E = 0
            pressTimeAverage_E = 0

            ui_totalPresses_E.Text = pressCount_E.ToString
            ui_totalPressTime_E.Text = pressTimeTotal_E.ToString("N3") & " secs"
            ui_averagePressTime_E.Text = pressTimeAverage_E.ToString("N3") & " secs"
            ui_percent_E.Text = "0.000%"

            'R
            ui_Panel_R.BackColor = unusedKeyBackgroundColor
            ui_Label_R.BackColor = unusedKeyBackgroundColor
            ui_Label_R.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_R.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_R.ForeColor = unusedStatFontColor
            ui_totalPressTime_R.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_R.ForeColor = unusedStatFontColor
            ui_averagePressTime_R.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_R.ForeColor = unusedStatFontColor
            ui_percent_R.BackColor = unusedKeyBackgroundColor
            ui_percent_R.ForeColor = unusedStatFontColor
            ui_bind_R.BackColor = unusedTextboxBackgroundColor
            ui_bind_R.ForeColor = unusedStatFontColor

            isHeld_R = False
            pressCount_R = 0
            pressTimeInterval_R = 0
            pressTimeTotal_R = 0
            pressTimeTotalConverted_R = 0
            pressTimeAverage_R = 0

            ui_totalPresses_R.Text = pressCount_R.ToString
            ui_totalPressTime_R.Text = pressTimeTotal_R.ToString("N3") & " secs"
            ui_averagePressTime_R.Text = pressTimeAverage_R.ToString("N3") & " secs"
            ui_percent_R.Text = "0.000%"

            'T
            ui_Panel_T.BackColor = unusedKeyBackgroundColor
            ui_Label_T.BackColor = unusedKeyBackgroundColor
            ui_Label_T.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_T.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_T.ForeColor = unusedStatFontColor
            ui_totalPressTime_T.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_T.ForeColor = unusedStatFontColor
            ui_averagePressTime_T.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_T.ForeColor = unusedStatFontColor
            ui_percent_T.BackColor = unusedKeyBackgroundColor
            ui_percent_T.ForeColor = unusedStatFontColor
            ui_bind_T.BackColor = unusedTextboxBackgroundColor
            ui_bind_T.ForeColor = unusedStatFontColor

            isHeld_T = False
            pressCount_T = 0
            pressTimeInterval_T = 0
            pressTimeTotal_T = 0
            pressTimeTotalConverted_T = 0
            pressTimeAverage_T = 0

            ui_totalPresses_T.Text = pressCount_T.ToString
            ui_totalPressTime_T.Text = pressTimeTotal_T.ToString("N3") & " secs"
            ui_averagePressTime_T.Text = pressTimeAverage_T.ToString("N3") & " secs"
            ui_percent_T.Text = "0.000%"

            'Y
            ui_Panel_Y.BackColor = unusedKeyBackgroundColor
            ui_Label_Y.BackColor = unusedKeyBackgroundColor
            ui_Label_Y.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Y.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Y.ForeColor = unusedStatFontColor
            ui_totalPressTime_Y.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Y.ForeColor = unusedStatFontColor
            ui_averagePressTime_Y.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Y.ForeColor = unusedStatFontColor
            ui_percent_Y.BackColor = unusedKeyBackgroundColor
            ui_percent_Y.ForeColor = unusedStatFontColor
            ui_bind_Y.BackColor = unusedTextboxBackgroundColor
            ui_bind_Y.ForeColor = unusedStatFontColor

            isHeld_Y = False
            pressCount_Y = 0
            pressTimeInterval_Y = 0
            pressTimeTotal_Y = 0
            pressTimeTotalConverted_Y = 0
            pressTimeAverage_Y = 0

            ui_totalPresses_Y.Text = pressCount_Y.ToString
            ui_totalPressTime_Y.Text = pressTimeTotal_Y.ToString("N3") & " secs"
            ui_averagePressTime_Y.Text = pressTimeAverage_Y.ToString("N3") & " secs"
            ui_percent_Y.Text = "0.000%"

            'U
            ui_Panel_U.BackColor = unusedKeyBackgroundColor
            ui_Label_U.BackColor = unusedKeyBackgroundColor
            ui_Label_U.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_U.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_U.ForeColor = unusedStatFontColor
            ui_totalPressTime_U.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_U.ForeColor = unusedStatFontColor
            ui_averagePressTime_U.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_U.ForeColor = unusedStatFontColor
            ui_percent_U.BackColor = unusedKeyBackgroundColor
            ui_percent_U.ForeColor = unusedStatFontColor
            ui_bind_U.BackColor = unusedTextboxBackgroundColor
            ui_bind_U.ForeColor = unusedStatFontColor

            isHeld_U = False
            pressCount_U = 0
            pressTimeInterval_U = 0
            pressTimeTotal_U = 0
            pressTimeTotalConverted_U = 0
            pressTimeAverage_U = 0

            ui_totalPresses_U.Text = pressCount_U.ToString
            ui_totalPressTime_U.Text = pressTimeTotal_U.ToString("N3") & " secs"
            ui_averagePressTime_U.Text = pressTimeAverage_U.ToString("N3") & " secs"
            ui_percent_U.Text = "0.000%"

            'I
            ui_Panel_I.BackColor = unusedKeyBackgroundColor
            ui_Label_I.BackColor = unusedKeyBackgroundColor
            ui_Label_I.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_I.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_I.ForeColor = unusedStatFontColor
            ui_totalPressTime_I.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_I.ForeColor = unusedStatFontColor
            ui_averagePressTime_I.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_I.ForeColor = unusedStatFontColor
            ui_percent_I.BackColor = unusedKeyBackgroundColor
            ui_percent_I.ForeColor = unusedStatFontColor
            ui_bind_I.BackColor = unusedTextboxBackgroundColor
            ui_bind_I.ForeColor = unusedStatFontColor

            isHeld_I = False
            pressCount_I = 0
            pressTimeInterval_I = 0
            pressTimeTotal_I = 0
            pressTimeTotalConverted_I = 0
            pressTimeAverage_I = 0

            ui_totalPresses_I.Text = pressCount_I.ToString
            ui_totalPressTime_I.Text = pressTimeTotal_I.ToString("N3") & " secs"
            ui_averagePressTime_I.Text = pressTimeAverage_I.ToString("N3") & " secs"
            ui_percent_I.Text = "0.000%"

            'O
            ui_Panel_O.BackColor = unusedKeyBackgroundColor
            ui_Label_O.BackColor = unusedKeyBackgroundColor
            ui_Label_O.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_O.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_O.ForeColor = unusedStatFontColor
            ui_totalPressTime_O.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_O.ForeColor = unusedStatFontColor
            ui_averagePressTime_O.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_O.ForeColor = unusedStatFontColor
            ui_percent_O.BackColor = unusedKeyBackgroundColor
            ui_percent_O.ForeColor = unusedStatFontColor
            ui_bind_O.BackColor = unusedTextboxBackgroundColor
            ui_bind_O.ForeColor = unusedStatFontColor

            isHeld_O = False
            pressCount_O = 0
            pressTimeInterval_O = 0
            pressTimeTotal_O = 0
            pressTimeTotalConverted_O = 0
            pressTimeAverage_O = 0

            ui_totalPresses_O.Text = pressCount_O.ToString
            ui_totalPressTime_O.Text = pressTimeTotal_O.ToString("N3") & " secs"
            ui_averagePressTime_O.Text = pressTimeAverage_O.ToString("N3") & " secs"
            ui_percent_O.Text = "0.000%"

            'P
            ui_Panel_P.BackColor = unusedKeyBackgroundColor
            ui_Label_P.BackColor = unusedKeyBackgroundColor
            ui_Label_P.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_P.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_P.ForeColor = unusedStatFontColor
            ui_totalPressTime_P.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_P.ForeColor = unusedStatFontColor
            ui_averagePressTime_P.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_P.ForeColor = unusedStatFontColor
            ui_percent_P.BackColor = unusedKeyBackgroundColor
            ui_percent_P.ForeColor = unusedStatFontColor
            ui_bind_P.BackColor = unusedTextboxBackgroundColor
            ui_bind_P.ForeColor = unusedStatFontColor

            isHeld_P = False
            pressCount_P = 0
            pressTimeInterval_P = 0
            pressTimeTotal_P = 0
            pressTimeTotalConverted_P = 0
            pressTimeAverage_P = 0

            ui_totalPresses_P.Text = pressCount_P.ToString
            ui_totalPressTime_P.Text = pressTimeTotal_P.ToString("N3") & " secs"
            ui_averagePressTime_P.Text = pressTimeAverage_P.ToString("N3") & " secs"
            ui_percent_P.Text = "0.000%"

            'LBracket
            ui_Panel_LBracket.BackColor = unusedKeyBackgroundColor
            ui_Label_LBracket.BackColor = unusedKeyBackgroundColor
            ui_Label_LBracket.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LBracket.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LBracket.ForeColor = unusedStatFontColor
            ui_totalPressTime_LBRacket.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LBRacket.ForeColor = unusedStatFontColor
            ui_averagePressTime_LBracket.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LBracket.ForeColor = unusedStatFontColor
            ui_percent_LBracket.BackColor = unusedKeyBackgroundColor
            ui_percent_LBracket.ForeColor = unusedStatFontColor
            ui_bind_LBracket.BackColor = unusedTextboxBackgroundColor
            ui_bind_LBracket.ForeColor = unusedStatFontColor

            isHeld_LBracket = False
            pressCount_LBracket = 0
            pressTimeInterval_LBracket = 0
            pressTimeTotal_LBracket = 0
            pressTimeTotalConverted_LBracket = 0
            pressTimeAverage_LBracket = 0

            ui_totalPresses_LBracket.Text = pressCount_LBracket.ToString
            ui_totalPressTime_LBRacket.Text = pressTimeTotal_LBracket.ToString("N3") & " secs"
            ui_averagePressTime_LBracket.Text = pressTimeAverage_LBracket.ToString("N3") & " secs"
            ui_percent_LBracket.Text = "0.000%"

            'RBracket
            ui_Panel_RBracket.BackColor = unusedKeyBackgroundColor
            ui_Label_RBRacket.BackColor = unusedKeyBackgroundColor
            ui_Label_RBRacket.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_RBracket.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_RBracket.ForeColor = unusedStatFontColor
            ui_totalPressTime_RBracket.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_RBracket.ForeColor = unusedStatFontColor
            ui_averagePressTime_RBracket.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_RBracket.ForeColor = unusedStatFontColor
            ui_percent_RBracket.BackColor = unusedKeyBackgroundColor
            ui_percent_RBracket.ForeColor = unusedStatFontColor
            ui_bind_RBracket.BackColor = unusedTextboxBackgroundColor
            ui_bind_RBracket.ForeColor = unusedStatFontColor

            isHeld_RBracket = False
            pressCount_RBracket = 0
            pressTimeInterval_RBracket = 0
            pressTimeTotal_RBracket = 0
            pressTimeTotalConverted_RBracket = 0
            pressTimeAverage_RBracket = 0

            ui_totalPresses_RBracket.Text = pressCount_RBracket.ToString
            ui_totalPressTime_RBracket.Text = pressTimeTotal_RBracket.ToString("N3") & " secs"
            ui_averagePressTime_RBracket.Text = pressTimeAverage_RBracket.ToString("N3") & " secs"
            ui_percent_RBracket.Text = "0.000%"

            'Slash
            ui_Panel_Divide.BackColor = unusedKeyBackgroundColor
            ui_Label_Slash.BackColor = unusedKeyBackgroundColor
            ui_Label_Slash.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Slash.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Slash.ForeColor = unusedStatFontColor
            ui_totalPressTime_Slash.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Slash.ForeColor = unusedStatFontColor
            ui_averagePressTime_Slash.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Slash.ForeColor = unusedStatFontColor
            ui_percent_Slash.BackColor = unusedKeyBackgroundColor
            ui_percent_Slash.ForeColor = unusedStatFontColor
            ui_bind_slash.BackColor = unusedTextboxBackgroundColor
            ui_bind_slash.ForeColor = unusedStatFontColor

            isHeld_Slash = False
            pressCount_Slash = 0
            pressTimeInterval_Slash = 0
            pressTimeTotal_Slash = 0
            pressTimeTotalConverted_Slash = 0
            pressTimeAverage_Slash = 0

            ui_totalPresses_Slash.Text = pressCount_Slash.ToString
            ui_totalPressTime_Slash.Text = pressTimeTotal_Slash.ToString("N3") & " secs"
            ui_averagePressTime_Slash.Text = pressTimeAverage_Slash.ToString("N3") & " secs"
            ui_percent_Slash.Text = "0.000%"

            'Delete
            ui_Panel_Delete.BackColor = unusedKeyBackgroundColor
            ui_Label_Delete.BackColor = unusedKeyBackgroundColor
            ui_Label_Delete.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Delete.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Delete.ForeColor = unusedStatFontColor
            ui_totalPressTime_Delete.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Delete.ForeColor = unusedStatFontColor
            ui_averagePressTime_Delete.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Delete.ForeColor = unusedStatFontColor
            ui_percent_Delete.BackColor = unusedKeyBackgroundColor
            ui_percent_Delete.ForeColor = unusedStatFontColor
            ui_bind_Delete.BackColor = unusedTextboxBackgroundColor
            ui_bind_Delete.ForeColor = unusedStatFontColor

            isHeld_Delete = False
            pressCount_Delete = 0
            pressTimeInterval_Delete = 0
            pressTimeTotal_Delete = 0
            pressTimeTotalConverted_Delete = 0
            pressTimeAverage_Delete = 0

            ui_totalPresses_Delete.Text = pressCount_Delete.ToString
            ui_totalPressTime_Delete.Text = pressTimeTotal_Delete.ToString("N3") & " secs"
            ui_averagePressTime_Delete.Text = pressTimeAverage_Delete.ToString("N3") & " secs"
            ui_percent_Delete.Text = "0.000%"

            'End
            ui_Panel_End.BackColor = unusedKeyBackgroundColor
            ui_Label_End.BackColor = unusedKeyBackgroundColor
            ui_Label_End.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_End.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_End.ForeColor = unusedStatFontColor
            ui_totalPressTime_End.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_End.ForeColor = unusedStatFontColor
            ui_averagePressTime_End.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_End.ForeColor = unusedStatFontColor
            ui.BackColor = unusedKeyBackgroundColor
            ui.ForeColor = unusedStatFontColor
            ui_bind_End.BackColor = unusedTextboxBackgroundColor
            ui_bind_End.ForeColor = unusedStatFontColor

            isHeld_End = False
            pressCount_End = 0
            pressTimeInterval_End = 0
            pressTimeTotal_End = 0
            pressTimeTotalConverted_End = 0
            pressTimeAverage_End = 0

            ui_totalPresses_End.Text = pressCount_End.ToString
            ui_totalPressTime_End.Text = pressTimeTotal_End.ToString("N3") & " secs"
            ui_averagePressTime_End.Text = pressTimeAverage_End.ToString("N3") & " secs"
            ui.Text = "0.000%"

            'PgDn
            ui_Panel_PgDn.BackColor = unusedKeyBackgroundColor
            ui_Label_PgDn.BackColor = unusedKeyBackgroundColor
            ui_Label_PgDn.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_PgDn.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_PgDn.ForeColor = unusedStatFontColor
            ui_totalPressTime_PgDn.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_PgDn.ForeColor = unusedStatFontColor
            ui_averagePressTime_PgDn.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_PgDn.ForeColor = unusedStatFontColor
            ui_percent_PgDn.BackColor = unusedKeyBackgroundColor
            ui_percent_PgDn.ForeColor = unusedStatFontColor
            ui_bind_PgDn.BackColor = unusedTextboxBackgroundColor
            ui_bind_PgDn.ForeColor = unusedStatFontColor

            isHeld_PgDn = False
            pressCount_PgDn = 0
            pressTimeInterval_PgDn = 0
            pressTimeTotal_PgDn = 0
            pressTimeTotalConverted_PgDn = 0
            pressTimeAverage_PgDn = 0

            ui_totalPresses_PgDn.Text = pressCount_PgDn.ToString
            ui_totalPressTime_PgDn.Text = pressTimeTotal_PgDn.ToString("N3") & " secs"
            ui_averagePressTime_PgDn.Text = pressTimeAverage_PgDn.ToString("N3") & " secs"
            ui_percent_PgDn.Text = "0.000%"

            'Num7
            ui_Panel_Num7.BackColor = unusedKeyBackgroundColor
            ui_Label_Num7.BackColor = unusedKeyBackgroundColor
            ui_Label_Num7.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num7.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num7.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num7.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num7.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num7.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num7.ForeColor = unusedStatFontColor
            ui_percent_Num7.BackColor = unusedKeyBackgroundColor
            ui_percent_Num7.ForeColor = unusedStatFontColor
            ui_bind_Num7.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num7.ForeColor = unusedStatFontColor

            isHeld_Num7 = False
            pressCount_Num7 = 0
            pressTimeInterval_Num7 = 0
            pressTimeTotal_Num7 = 0
            pressTimeTotalConverted_Num7 = 0
            pressTimeAverage_Num7 = 0

            ui_totalPresses_Num7.Text = pressCount_Num7.ToString
            ui_totalPressTime_Num7.Text = pressTimeTotal_Num7.ToString("N3") & " secs"
            ui_averagePressTime_Num7.Text = pressTimeAverage_Num7.ToString("N3") & " secs"
            ui_percent_Num7.Text = "0.000%"

            'Num8
            ui_Panel_Num8.BackColor = unusedKeyBackgroundColor
            ui_Label_Num8.BackColor = unusedKeyBackgroundColor
            ui_Label_Num8.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num8.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num8.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num8.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num8.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num8.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num8.ForeColor = unusedStatFontColor
            ui_percent_Num8.BackColor = unusedKeyBackgroundColor
            ui_percent_Num8.ForeColor = unusedStatFontColor
            ui_bind_Num8.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num8.ForeColor = unusedStatFontColor

            isHeld_Num8 = False
            pressCount_Num8 = 0
            pressTimeInterval_Num8 = 0
            pressTimeTotal_Num8 = 0
            pressTimeTotalConverted_Num8 = 0
            pressTimeAverage_Num8 = 0

            ui_totalPresses_Num8.Text = pressCount_Num8.ToString
            ui_totalPressTime_Num8.Text = pressTimeTotal_Num8.ToString("N3") & " secs"
            ui_averagePressTime_Num8.Text = pressTimeAverage_Num8.ToString("N3") & " secs"
            ui_percent_Num8.Text = "0.000%"

            'Num9
            ui_Panel_Num9.BackColor = unusedKeyBackgroundColor
            ui_Label_Num9.BackColor = unusedKeyBackgroundColor
            ui_Label_Num9.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num9.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num9.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num9.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num9.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num9.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num9.ForeColor = unusedStatFontColor
            ui_percent_Num9.BackColor = unusedKeyBackgroundColor
            ui_percent_Num9.ForeColor = unusedStatFontColor
            ui_bind_Num9.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num9.ForeColor = unusedStatFontColor

            isHeld_Num9 = False
            pressCount_Num9 = 0
            pressTimeInterval_Num9 = 0
            pressTimeTotal_Num9 = 0
            pressTimeTotalConverted_Num9 = 0
            pressTimeAverage_Num9 = 0

            ui_totalPresses_Num9.Text = pressCount_Num9.ToString
            ui_totalPressTime_Num9.Text = pressTimeTotal_Num9.ToString("N3") & " secs"
            ui_averagePressTime_Num9.Text = pressTimeAverage_Num9.ToString("N3") & " secs"
            ui_percent_Num9.Text = "0.000%"

            'CAPS
            ui_Panel_CAPS.BackColor = unusedKeyBackgroundColor
            ui_Label_CAPS.BackColor = unusedKeyBackgroundColor
            ui_Label_CAPS.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_CAPS.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_CAPS.ForeColor = unusedStatFontColor
            ui_totalPressTime_CAPS.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_CAPS.ForeColor = unusedStatFontColor
            ui_averagePressTime_CAPS.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_CAPS.ForeColor = unusedStatFontColor
            ui_percent_CAPS.BackColor = unusedKeyBackgroundColor
            ui_percent_CAPS.ForeColor = unusedStatFontColor
            ui_bind_CAPS.BackColor = unusedTextboxBackgroundColor
            ui_bind_CAPS.ForeColor = unusedStatFontColor

            isHeld_CAPS = False
            pressCount_CAPS = 0
            pressTimeInterval_CAPS = 0
            pressTimeTotal_CAPS = 0
            pressTimeTotalConverted_CAPS = 0
            pressTimeAverage_CAPS = 0

            ui_totalPresses_CAPS.Text = pressCount_CAPS.ToString
            ui_totalPressTime_CAPS.Text = pressTimeTotal_CAPS.ToString("N3") & " secs"
            ui_averagePressTime_CAPS.Text = pressTimeAverage_CAPS.ToString("N3") & " secs"
            ui_percent_CAPS.Text = "0.000%"

            'A
            ui_Panel_A.BackColor = unusedKeyBackgroundColor
            ui_Label_A.BackColor = unusedKeyBackgroundColor
            ui_Label_A.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_A.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_A.ForeColor = unusedStatFontColor
            ui_totalPressTime_A.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_A.ForeColor = unusedStatFontColor
            ui_averagePressTime_A.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_A.ForeColor = unusedStatFontColor
            ui_percent_A.BackColor = unusedKeyBackgroundColor
            ui_percent_A.ForeColor = unusedStatFontColor
            ui_bind_A.BackColor = unusedTextboxBackgroundColor
            ui_bind_A.ForeColor = unusedStatFontColor

            isHeld_A = False
            pressCount_A = 0
            pressTimeInterval_A = 0
            pressTimeTotal_A = 0
            pressTimeTotalConverted_A = 0
            pressTimeAverage_A = 0

            ui_totalPresses_A.Text = pressCount_A.ToString
            ui_totalPressTime_A.Text = pressTimeTotal_A.ToString("N3") & " secs"
            ui_averagePressTime_A.Text = pressTimeAverage_A.ToString("N3") & " secs"
            ui_percent_A.Text = "0.000%"

            'S
            ui_Panel_S.BackColor = unusedKeyBackgroundColor
            ui_Label_S.BackColor = unusedKeyBackgroundColor
            ui_Label_S.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_S.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_S.ForeColor = unusedStatFontColor
            ui_totalPressTime_S.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_S.ForeColor = unusedStatFontColor
            ui_averagePressTime_S.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_S.ForeColor = unusedStatFontColor
            ui_percent_S.BackColor = unusedKeyBackgroundColor
            ui_percent_S.ForeColor = unusedStatFontColor
            ui_bind_S.BackColor = unusedTextboxBackgroundColor
            ui_bind_S.ForeColor = unusedStatFontColor

            isHeld_S = False
            pressCount_S = 0
            pressTimeInterval_S = 0
            pressTimeTotal_S = 0
            pressTimeTotalConverted_S = 0
            pressTimeAverage_S = 0

            ui_totalPresses_S.Text = pressCount_S.ToString
            ui_totalPressTime_S.Text = pressTimeTotal_S.ToString("N3") & " secs"
            ui_averagePressTime_S.Text = pressTimeAverage_S.ToString("N3") & " secs"
            ui_percent_S.Text = "0.000%"

            'D
            ui_Panel_D.BackColor = unusedKeyBackgroundColor
            ui_Label_D.BackColor = unusedKeyBackgroundColor
            ui_Label_D.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_D.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_D.ForeColor = unusedStatFontColor
            ui_totalPressTime_D.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_D.ForeColor = unusedStatFontColor
            ui_averagePressTime_D.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_D.ForeColor = unusedStatFontColor
            ui_percent_D.BackColor = unusedKeyBackgroundColor
            ui_percent_D.ForeColor = unusedStatFontColor
            ui_bind_D.BackColor = unusedTextboxBackgroundColor
            ui_bind_D.ForeColor = unusedStatFontColor

            isHeld_D = False
            pressCount_D = 0
            pressTimeInterval_D = 0
            pressTimeTotal_D = 0
            pressTimeTotalConverted_D = 0
            pressTimeAverage_D = 0

            ui_totalPresses_D.Text = pressCount_D.ToString
            ui_totalPressTime_D.Text = pressTimeTotal_D.ToString("N3") & " secs"
            ui_averagePressTime_D.Text = pressTimeAverage_D.ToString("N3") & " secs"
            ui_percent_D.Text = "0.000%"

            'F
            ui_Panel_F.BackColor = unusedKeyBackgroundColor
            ui_Label_F.BackColor = unusedKeyBackgroundColor
            ui_Label_F.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_F.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_F.ForeColor = unusedStatFontColor
            ui_totalPressTime_F.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_F.ForeColor = unusedStatFontColor
            ui_averagePressTime_F.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_F.ForeColor = unusedStatFontColor
            ui_percent_F.BackColor = unusedKeyBackgroundColor
            ui_percent_F.ForeColor = unusedStatFontColor
            ui_bind_F.BackColor = unusedTextboxBackgroundColor
            ui_bind_F.ForeColor = unusedStatFontColor

            isHeld_F = False
            pressCount_F = 0
            pressTimeInterval_F = 0
            pressTimeTotal_F = 0
            pressTimeTotalConverted_F = 0
            pressTimeAverage_F = 0

            ui_totalPresses_F.Text = pressCount_F.ToString
            ui_totalPressTime_F.Text = pressTimeTotal_F.ToString("N3") & " secs"
            ui_averagePressTime_F.Text = pressTimeAverage_F.ToString("N3") & " secs"
            ui_percent_F.Text = "0.000%"

            'G
            ui_Panel_G.BackColor = unusedKeyBackgroundColor
            ui_Label_G.BackColor = unusedKeyBackgroundColor
            ui_Label_G.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_G.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_G.ForeColor = unusedStatFontColor
            ui_totalPressTime_G.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_G.ForeColor = unusedStatFontColor
            ui_averagePressTime_G.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_G.ForeColor = unusedStatFontColor
            ui_percent_G.BackColor = unusedKeyBackgroundColor
            ui_percent_G.ForeColor = unusedStatFontColor
            ui_bind_G.BackColor = unusedTextboxBackgroundColor
            ui_bind_G.ForeColor = unusedStatFontColor

            isHeld_G = False
            pressCount_G = 0
            pressTimeInterval_G = 0
            pressTimeTotal_G = 0
            pressTimeTotalConverted_G = 0
            pressTimeAverage_G = 0

            ui_totalPresses_G.Text = pressCount_G.ToString
            ui_totalPressTime_G.Text = pressTimeTotal_G.ToString("N3") & " secs"
            ui_averagePressTime_G.Text = pressTimeAverage_G.ToString("N3") & " secs"
            ui_percent_G.Text = "0.000%"

            'H
            ui_Panel_H.BackColor = unusedKeyBackgroundColor
            ui_Label_H.BackColor = unusedKeyBackgroundColor
            ui_Label_H.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_H.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_H.ForeColor = unusedStatFontColor
            ui_totalPressTime_H.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_H.ForeColor = unusedStatFontColor
            ui_averagePressTime_H.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_H.ForeColor = unusedStatFontColor
            ui_percent_H.BackColor = unusedKeyBackgroundColor
            ui_percent_H.ForeColor = unusedStatFontColor
            ui_bind_H.BackColor = unusedTextboxBackgroundColor
            ui_bind_H.ForeColor = unusedStatFontColor

            isHeld_H = False
            pressCount_H = 0
            pressTimeInterval_H = 0
            pressTimeTotal_H = 0
            pressTimeTotalConverted_H = 0
            pressTimeAverage_H = 0

            ui_totalPresses_H.Text = pressCount_H.ToString
            ui_totalPressTime_H.Text = pressTimeTotal_H.ToString("N3") & " secs"
            ui_averagePressTime_H.Text = pressTimeAverage_H.ToString("N3") & " secs"
            ui_percent_H.Text = "0.000%"

            'J
            ui_Panel_J.BackColor = unusedKeyBackgroundColor
            ui_Label_J.BackColor = unusedKeyBackgroundColor
            ui_Label_J.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_J.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_J.ForeColor = unusedStatFontColor
            ui_totalPressTime_J.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_J.ForeColor = unusedStatFontColor
            ui_averagePressTime_J.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_J.ForeColor = unusedStatFontColor
            ui_percent_J.BackColor = unusedKeyBackgroundColor
            ui_percent_J.ForeColor = unusedStatFontColor
            ui_bind_J.BackColor = unusedTextboxBackgroundColor
            ui_bind_J.ForeColor = unusedStatFontColor

            isHeld_J = False
            pressCount_J = 0
            pressTimeInterval_J = 0
            pressTimeTotal_J = 0
            pressTimeTotalConverted_J = 0
            pressTimeAverage_J = 0

            ui_totalPresses_J.Text = pressCount_J.ToString
            ui_totalPressTime_J.Text = pressTimeTotal_J.ToString("N3") & " secs"
            ui_averagePressTime_J.Text = pressTimeAverage_J.ToString("N3") & " secs"
            ui_percent_J.Text = "0.000%"

            'K
            ui_Panel_K.BackColor = unusedKeyBackgroundColor
            ui_Label_K.BackColor = unusedKeyBackgroundColor
            ui_Label_K.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_K.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_K.ForeColor = unusedStatFontColor
            ui_totalPressTime_K.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_K.ForeColor = unusedStatFontColor
            ui_averagePressTime_K.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_K.ForeColor = unusedStatFontColor
            ui_percent_K.BackColor = unusedKeyBackgroundColor
            ui_percent_K.ForeColor = unusedStatFontColor
            ui_bind_K.BackColor = unusedTextboxBackgroundColor
            ui_bind_K.ForeColor = unusedStatFontColor

            isHeld_K = False
            pressCount_K = 0
            pressTimeInterval_K = 0
            pressTimeTotal_K = 0
            pressTimeTotalConverted_K = 0
            pressTimeAverage_K = 0

            ui_totalPresses_K.Text = pressCount_K.ToString
            ui_totalPressTime_K.Text = pressTimeTotal_K.ToString("N3") & " secs"
            ui_averagePressTime_K.Text = pressTimeAverage_K.ToString("N3") & " secs"
            ui_percent_K.Text = "0.000%"

            'L
            ui_Panel_L.BackColor = unusedKeyBackgroundColor
            ui_Label_L.BackColor = unusedKeyBackgroundColor
            ui_Label_L.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_L.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_L.ForeColor = unusedStatFontColor
            ui_totalPressTime_L.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_L.ForeColor = unusedStatFontColor
            ui_averagePressTime_L.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_L.ForeColor = unusedStatFontColor
            ui_percent_L.BackColor = unusedKeyBackgroundColor
            ui_percent_L.ForeColor = unusedStatFontColor
            ui_bind_L.BackColor = unusedTextboxBackgroundColor
            ui_bind_L.ForeColor = unusedStatFontColor

            isHeld_L = False
            pressCount_L = 0
            pressTimeInterval_L = 0
            pressTimeTotal_L = 0
            pressTimeTotalConverted_L = 0
            pressTimeAverage_L = 0

            ui_totalPresses_L.Text = pressCount_L.ToString
            ui_totalPressTime_L.Text = pressTimeTotal_L.ToString("N3") & " secs"
            ui_averagePressTime_L.Text = pressTimeAverage_L.ToString("N3") & " secs"
            ui_percent_L.Text = "0.000%"

            'COLON
            ui_Panel_COLON.BackColor = unusedKeyBackgroundColor
            ui_Label_COLON.BackColor = unusedKeyBackgroundColor
            ui_Label_COLON.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_COLON.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_COLON.ForeColor = unusedStatFontColor
            ui_totalPressTime_COLON.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_COLON.ForeColor = unusedStatFontColor
            ui_averagePressTime_COLON.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_COLON.ForeColor = unusedStatFontColor
            ui_percent_COLON.BackColor = unusedKeyBackgroundColor
            ui_percent_COLON.ForeColor = unusedStatFontColor
            ui_bind_COLON.BackColor = unusedTextboxBackgroundColor
            ui_bind_COLON.ForeColor = unusedStatFontColor

            isHeld_COLON = False
            pressCount_COLON = 0
            pressTimeInterval_COLON = 0
            pressTimeTotal_COLON = 0
            pressTimeTotalConverted_COLON = 0
            pressTimeAverage_COLON = 0

            ui_totalPresses_COLON.Text = pressCount_COLON.ToString
            ui_totalPressTime_COLON.Text = pressTimeTotal_COLON.ToString("N3") & " secs"
            ui_averagePressTime_COLON.Text = pressTimeAverage_COLON.ToString("N3") & " secs"
            ui_percent_COLON.Text = "0.000%"

            'QUOTES
            ui_Panel_QUOTES.BackColor = unusedKeyBackgroundColor
            ui_Label_QUOTES.BackColor = unusedKeyBackgroundColor
            ui_Label_QUOTES.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_QUOTES.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_QUOTES.ForeColor = unusedStatFontColor
            ui_totalPressTime_QUOTES.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_QUOTES.ForeColor = unusedStatFontColor
            ui_averagePressTime_QUOTES.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_QUOTES.ForeColor = unusedStatFontColor
            ui_percent_QUOTES.BackColor = unusedKeyBackgroundColor
            ui_percent_QUOTES.ForeColor = unusedStatFontColor
            ui_bind_QUOTES.BackColor = unusedTextboxBackgroundColor
            ui_bind_QUOTES.ForeColor = unusedStatFontColor

            isHeld_QUOTES = False
            pressCount_QUOTES = 0
            pressTimeInterval_QUOTES = 0
            pressTimeTotal_QUOTES = 0
            pressTimeTotalConverted_QUOTES = 0
            pressTimeAverage_QUOTES = 0

            ui_totalPresses_QUOTES.Text = pressCount_QUOTES.ToString
            ui_totalPressTime_QUOTES.Text = pressTimeTotal_QUOTES.ToString("N3") & " secs"
            ui_averagePressTime_QUOTES.Text = pressTimeAverage_QUOTES.ToString("N3") & " secs"
            ui_percent_QUOTES.Text = "0.000%"

            'MainEnter
            ui_Panel_MainEnter.BackColor = unusedKeyBackgroundColor
            ui_Label_MainEnter.BackColor = unusedKeyBackgroundColor
            ui_Label_MainEnter.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_MainEnter.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_MainEnter.ForeColor = unusedStatFontColor
            ui_totalPressTime_MainEnter.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_MainEnter.ForeColor = unusedStatFontColor
            ui_averagePressTime_MainEnter.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_MainEnter.ForeColor = unusedStatFontColor
            ui_percent_MainEnter.BackColor = unusedKeyBackgroundColor
            ui_percent_MainEnter.ForeColor = unusedStatFontColor
            ui_bind_MainEnter.BackColor = unusedTextboxBackgroundColor
            ui_bind_MainEnter.ForeColor = unusedStatFontColor

            isHeld_MainEnter = False
            pressCount_MainEnter = 0
            pressTimeInterval_MainEnter = 0
            pressTimeTotal_MainEnter = 0
            pressTimeTotalConverted_MainEnter = 0
            pressTimeAverage_MainEnter = 0

            ui_totalPresses_MainEnter.Text = pressCount_MainEnter.ToString
            ui_totalPressTime_MainEnter.Text = pressTimeTotal_MainEnter.ToString("N3") & " secs"
            ui_averagePressTime_MainEnter.Text = pressTimeAverage_MainEnter.ToString("N3") & " secs"
            ui_percent_MainEnter.Text = "0.000%"

            'Num4
            ui_Panel_Num4.BackColor = unusedKeyBackgroundColor
            ui_Label_Num4.BackColor = unusedKeyBackgroundColor
            ui_Label_Num4.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num4.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num4.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num4.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num4.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num4.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num4.ForeColor = unusedStatFontColor
            ui_percent_Num4.BackColor = unusedKeyBackgroundColor
            ui_percent_Num4.ForeColor = unusedStatFontColor
            ui_bind_Num4.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num4.ForeColor = unusedStatFontColor

            isHeld_Num4 = False
            pressCount_Num4 = 0
            pressTimeInterval_Num4 = 0
            pressTimeTotal_Num4 = 0
            pressTimeTotalConverted_Num4 = 0
            pressTimeAverage_Num4 = 0

            ui_totalPresses_Num4.Text = pressCount_Num4.ToString
            ui_totalPressTime_Num4.Text = pressTimeTotal_Num4.ToString("N3") & " secs"
            ui_averagePressTime_Num4.Text = pressTimeAverage_Num4.ToString("N3") & " secs"
            ui_percent_Num4.Text = "0.000%"

            'Num5
            ui_Panel_Num5.BackColor = unusedKeyBackgroundColor
            ui_Label_Num5.BackColor = unusedKeyBackgroundColor
            ui_Label_Num5.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num5.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num5.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num5.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num5.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num5.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num5.ForeColor = unusedStatFontColor
            ui_percent_Num5.BackColor = unusedKeyBackgroundColor
            ui_percent_Num5.ForeColor = unusedStatFontColor
            ui_bind_Num5.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num5.ForeColor = unusedStatFontColor

            isHeld_Num5 = False
            pressCount_Num5 = 0
            pressTimeInterval_Num5 = 0
            pressTimeTotal_Num5 = 0
            pressTimeTotalConverted_Num5 = 0
            pressTimeAverage_Num5 = 0

            ui_totalPresses_Num5.Text = pressCount_Num5.ToString
            ui_totalPressTime_Num5.Text = pressTimeTotal_Num5.ToString("N3") & " secs"
            ui_averagePressTime_Num5.Text = pressTimeAverage_Num5.ToString("N3") & " secs"
            ui_percent_Num5.Text = "0.000%"

            'Num6
            ui_Panel_Num6.BackColor = unusedKeyBackgroundColor
            ui_Label_Num6.BackColor = unusedKeyBackgroundColor
            ui_Label_Num6.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num6.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num6.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num6.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num6.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num6.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num6.ForeColor = unusedStatFontColor
            ui_percent_Num6.BackColor = unusedKeyBackgroundColor
            ui_percent_Num6.ForeColor = unusedStatFontColor
            ui_bind_Num6.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num6.ForeColor = unusedStatFontColor

            isHeld_Num6 = False
            pressCount_Num6 = 0
            pressTimeInterval_Num6 = 0
            pressTimeTotal_Num6 = 0
            pressTimeTotalConverted_Num6 = 0
            pressTimeAverage_Num6 = 0

            ui_totalPresses_Num6.Text = pressCount_Num6.ToString
            ui_totalPressTime_Num6.Text = pressTimeTotal_Num6.ToString("N3") & " secs"
            ui_averagePressTime_Num6.Text = pressTimeAverage_Num6.ToString("N3") & " secs"
            ui_percent_Num6.Text = "0.000%"

            'Plus
            ui_Panel_Plus.BackColor = unusedKeyBackgroundColor
            ui_Label_Plus.BackColor = unusedKeyBackgroundColor
            ui_Label_Plus.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Plus.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Plus.ForeColor = unusedStatFontColor
            ui_totalPressTime_Plus.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Plus.ForeColor = unusedStatFontColor
            ui_averagePressTime_Plus.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Plus.ForeColor = unusedStatFontColor
            ui_percent_Plus.BackColor = unusedKeyBackgroundColor
            ui_percent_Plus.ForeColor = unusedStatFontColor
            ui_bind_Plus.BackColor = unusedTextboxBackgroundColor
            ui_bind_Plus.ForeColor = unusedStatFontColor

            isHeld_Plus = False
            pressCount_Plus = 0
            pressTimeInterval_Plus = 0
            pressTimeTotal_Plus = 0
            pressTimeTotalConverted_Plus = 0
            pressTimeAverage_Plus = 0

            ui_totalPresses_Plus.Text = pressCount_Plus.ToString
            ui_totalPressTime_Plus.Text = pressTimeTotal_Plus.ToString("N3") & " secs"
            ui_averagePressTime_Plus.Text = pressTimeAverage_Plus.ToString("N3") & " secs"
            ui_percent_Plus.Text = "0.000%"

            'LSHIFT
            ui_Panel_LSHIFT.BackColor = unusedKeyBackgroundColor
            ui_Label_LSHIFT.BackColor = unusedKeyBackgroundColor
            ui_Label_LSHIFT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LSHIFT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LSHIFT.ForeColor = unusedStatFontColor
            ui_totalPressTime_LSHIFT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LSHIFT.ForeColor = unusedStatFontColor
            ui_averagePressTime_LSHIFT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LSHIFT.ForeColor = unusedStatFontColor
            ui_percent_LSHIFT.BackColor = unusedKeyBackgroundColor
            ui_percent_LSHIFT.ForeColor = unusedStatFontColor
            ui_bind_LSHIFT.BackColor = unusedTextboxBackgroundColor
            ui_bind_LSHIFT.ForeColor = unusedStatFontColor

            isHeld_LSHIFT = False
            pressCount_LSHIFT = 0
            pressTimeInterval_LSHIFT = 0
            pressTimeTotal_LSHIFT = 0
            pressTimeTotalConverted_LSHIFT = 0
            pressTimeAverage_LSHIFT = 0

            ui_totalPresses_LSHIFT.Text = pressCount_LSHIFT.ToString
            ui_totalPressTime_LSHIFT.Text = pressTimeTotal_LSHIFT.ToString("N3") & " secs"
            ui_averagePressTime_LSHIFT.Text = pressTimeAverage_LSHIFT.ToString("N3") & " secs"
            ui_percent_LSHIFT.Text = "0.000%"

            'Z
            ui_Panel_Z.BackColor = unusedKeyBackgroundColor
            ui_Label_Z.BackColor = unusedKeyBackgroundColor
            ui_Label_Z.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Z.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Z.ForeColor = unusedStatFontColor
            ui_totalPressTime_Z.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Z.ForeColor = unusedStatFontColor
            ui_averagePressTime_Z.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Z.ForeColor = unusedStatFontColor
            ui_percent_Z.BackColor = unusedKeyBackgroundColor
            ui_percent_Z.ForeColor = unusedStatFontColor
            ui_bind_Z.BackColor = unusedTextboxBackgroundColor
            ui_bind_Z.ForeColor = unusedStatFontColor

            isHeld_Z = False
            pressCount_Z = 0
            pressTimeInterval_Z = 0
            pressTimeTotal_Z = 0
            pressTimeTotalConverted_Z = 0
            pressTimeAverage_Z = 0

            ui_totalPresses_Z.Text = pressCount_Z.ToString
            ui_totalPressTime_Z.Text = pressTimeTotal_Z.ToString("N3") & " secs"
            ui_averagePressTime_Z.Text = pressTimeAverage_Z.ToString("N3") & " secs"
            ui_percent_Z.Text = "0.000%"

            'X
            ui_Panel_X.BackColor = unusedKeyBackgroundColor
            ui_Label_X.BackColor = unusedKeyBackgroundColor
            ui_Label_X.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_X.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_X.ForeColor = unusedStatFontColor
            ui_totalPressTime_X.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_X.ForeColor = unusedStatFontColor
            ui_averagePressTime_X.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_X.ForeColor = unusedStatFontColor
            ui_percent_X.BackColor = unusedKeyBackgroundColor
            ui_percent_X.ForeColor = unusedStatFontColor
            ui_bind_X.BackColor = unusedTextboxBackgroundColor
            ui_bind_X.ForeColor = unusedStatFontColor

            isHeld_X = False
            pressCount_X = 0
            pressTimeInterval_X = 0
            pressTimeTotal_X = 0
            pressTimeTotalConverted_X = 0
            pressTimeAverage_X = 0

            ui_totalPresses_X.Text = pressCount_X.ToString
            ui_totalPressTime_X.Text = pressTimeTotal_X.ToString("N3") & " secs"
            ui_averagePressTime_X.Text = pressTimeAverage_X.ToString("N3") & " secs"
            ui_percent_X.Text = "0.000%"

            'C
            ui_Panel_C.BackColor = unusedKeyBackgroundColor
            ui_Label_C.BackColor = unusedKeyBackgroundColor
            ui_Label_C.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_C.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_C.ForeColor = unusedStatFontColor
            ui_totalPressTime_C.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_C.ForeColor = unusedStatFontColor
            ui_averagePressTime_C.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_C.ForeColor = unusedStatFontColor
            ui_percent_C.BackColor = unusedKeyBackgroundColor
            ui_percent_C.ForeColor = unusedStatFontColor
            ui_bind_C.BackColor = unusedTextboxBackgroundColor
            ui_bind_C.ForeColor = unusedStatFontColor

            isHeld_C = False
            pressCount_C = 0
            pressTimeInterval_C = 0
            pressTimeTotal_C = 0
            pressTimeTotalConverted_C = 0
            pressTimeAverage_C = 0

            ui_totalPresses_C.Text = pressCount_C.ToString
            ui_totalPressTime_C.Text = pressTimeTotal_C.ToString("N3") & " secs"
            ui_averagePressTime_C.Text = pressTimeAverage_C.ToString("N3") & " secs"
            ui_percent_C.Text = "0.000%"

            'V
            ui_Panel_V.BackColor = unusedKeyBackgroundColor
            ui_Label_V.BackColor = unusedKeyBackgroundColor
            ui_Label_V.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_V.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_V.ForeColor = unusedStatFontColor
            ui_totalPressTime_V.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_V.ForeColor = unusedStatFontColor
            ui_averagePressTime_V.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_V.ForeColor = unusedStatFontColor
            ui_percent_V.BackColor = unusedKeyBackgroundColor
            ui_percent_V.ForeColor = unusedStatFontColor
            ui_bind_V.BackColor = unusedTextboxBackgroundColor
            ui_bind_V.ForeColor = unusedStatFontColor

            isHeld_V = False
            pressCount_V = 0
            pressTimeInterval_V = 0
            pressTimeTotal_V = 0
            pressTimeTotalConverted_V = 0
            pressTimeAverage_V = 0

            ui_totalPresses_V.Text = pressCount_V.ToString
            ui_totalPressTime_V.Text = pressTimeTotal_V.ToString("N3") & " secs"
            ui_averagePressTime_V.Text = pressTimeAverage_V.ToString("N3") & " secs"
            ui_percent_V.Text = "0.000%"

            'B
            ui_Panel_B.BackColor = unusedKeyBackgroundColor
            ui_Label_B.BackColor = unusedKeyBackgroundColor
            ui_Label_B.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_B.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_B.ForeColor = unusedStatFontColor
            ui_totalPressTime_B.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_B.ForeColor = unusedStatFontColor
            ui_averagePressTime_B.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_B.ForeColor = unusedStatFontColor
            ui_percent_B.BackColor = unusedKeyBackgroundColor
            ui_percent_B.ForeColor = unusedStatFontColor
            ui_bind_B.BackColor = unusedTextboxBackgroundColor
            ui_bind_B.ForeColor = unusedStatFontColor

            isHeld_B = False
            pressCount_B = 0
            pressTimeInterval_B = 0
            pressTimeTotal_B = 0
            pressTimeTotalConverted_B = 0
            pressTimeAverage_B = 0

            ui_totalPresses_B.Text = pressCount_B.ToString
            ui_totalPressTime_B.Text = pressTimeTotal_B.ToString("N3") & " secs"
            ui_averagePressTime_B.Text = pressTimeAverage_B.ToString("N3") & " secs"
            ui_percent_B.Text = "0.000%"

            'N
            ui_Panel_N.BackColor = unusedKeyBackgroundColor
            ui_Label_N.BackColor = unusedKeyBackgroundColor
            ui_Label_N.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_N.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_N.ForeColor = unusedStatFontColor
            ui_totalPressTime_N.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_N.ForeColor = unusedStatFontColor
            ui_averagePressTime_N.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_N.ForeColor = unusedStatFontColor
            ui_percent_N.BackColor = unusedKeyBackgroundColor
            ui_percent_N.ForeColor = unusedStatFontColor
            ui_bind_N.BackColor = unusedTextboxBackgroundColor
            ui_bind_N.ForeColor = unusedStatFontColor

            isHeld_N = False
            pressCount_N = 0
            pressTimeInterval_N = 0
            pressTimeTotal_N = 0
            pressTimeTotalConverted_N = 0
            pressTimeAverage_N = 0

            ui_totalPresses_N.Text = pressCount_N.ToString
            ui_totalPressTime_N.Text = pressTimeTotal_N.ToString("N3") & " secs"
            ui_averagePressTime_N.Text = pressTimeAverage_N.ToString("N3") & " secs"
            ui_percent_N.Text = "0.000%"

            'M
            ui_Panel_M.BackColor = unusedKeyBackgroundColor
            ui_Label_M.BackColor = unusedKeyBackgroundColor
            ui_Label_M.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_M.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_M.ForeColor = unusedStatFontColor
            ui_totalPressTime_M.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_M.ForeColor = unusedStatFontColor
            ui_averagePressTime_M.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_M.ForeColor = unusedStatFontColor
            ui_percent_M.BackColor = unusedKeyBackgroundColor
            ui_percent_M.ForeColor = unusedStatFontColor
            ui_bind_M.BackColor = unusedTextboxBackgroundColor
            ui_bind_M.ForeColor = unusedStatFontColor

            isHeld_M = False
            pressCount_M = 0
            pressTimeInterval_M = 0
            pressTimeTotal_M = 0
            pressTimeTotalConverted_M = 0
            pressTimeAverage_M = 0

            ui_totalPresses_M.Text = pressCount_M.ToString
            ui_totalPressTime_M.Text = pressTimeTotal_M.ToString("N3") & " secs"
            ui_averagePressTime_M.Text = pressTimeAverage_M.ToString("N3") & " secs"
            ui_percent_M.Text = "0.000%"

            'LESS
            ui_Panel_LESS.BackColor = unusedKeyBackgroundColor
            ui_Label_LESS.BackColor = unusedKeyBackgroundColor
            ui_Label_LESS.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LESS.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LESS.ForeColor = unusedStatFontColor
            ui_totalPressTime_LESS.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LESS.ForeColor = unusedStatFontColor
            ui_averagePressTime_LESS.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LESS.ForeColor = unusedStatFontColor
            ui_percent_LESS.BackColor = unusedKeyBackgroundColor
            ui_percent_LESS.ForeColor = unusedStatFontColor
            ui_bind_LESS.BackColor = unusedTextboxBackgroundColor
            ui_bind_LESS.ForeColor = unusedStatFontColor

            isHeld_LESS = False
            pressCount_LESS = 0
            pressTimeInterval_LESS = 0
            pressTimeTotal_LESS = 0
            pressTimeTotalConverted_LESS = 0
            pressTimeAverage_LESS = 0

            ui_totalPresses_LESS.Text = pressCount_LESS.ToString
            ui_totalPressTime_LESS.Text = pressTimeTotal_LESS.ToString("N3") & " secs"
            ui_averagePressTime_LESS.Text = pressTimeAverage_LESS.ToString("N3") & " secs"
            ui_percent_LESS.Text = "0.000%"

            'Greater
            ui_Panel_Greater.BackColor = unusedKeyBackgroundColor
            ui_Label_Greater.BackColor = unusedKeyBackgroundColor
            ui_Label_Greater.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Greater.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Greater.ForeColor = unusedStatFontColor
            ui_totalPressTime_Greater.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Greater.ForeColor = unusedStatFontColor
            ui_averagePressTime_Greater.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Greater.ForeColor = unusedStatFontColor
            ui_percent_Greater.BackColor = unusedKeyBackgroundColor
            ui_percent_Greater.ForeColor = unusedStatFontColor
            ui_bind_Greater.BackColor = unusedTextboxBackgroundColor
            ui_bind_Greater.ForeColor = unusedStatFontColor

            isHeld_Greater = False
            pressCount_Greater = 0
            pressTimeInterval_Greater = 0
            pressTimeTotal_Greater = 0
            pressTimeTotalConverted_Greater = 0
            pressTimeAverage_Greater = 0

            ui_totalPresses_Greater.Text = pressCount_Greater.ToString
            ui_totalPressTime_Greater.Text = pressTimeTotal_Greater.ToString("N3") & " secs"
            ui_averagePressTime_Greater.Text = pressTimeAverage_Greater.ToString("N3") & " secs"
            ui_percent_Greater.Text = "0.000%"

            'Question
            ui_Panel_Question.BackColor = unusedKeyBackgroundColor
            ui_Label_Question.BackColor = unusedKeyBackgroundColor
            ui_Label_Question.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Question.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Question.ForeColor = unusedStatFontColor
            ui_totalPressTime_Question.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Question.ForeColor = unusedStatFontColor
            ui_averagePressTime_Question.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Question.ForeColor = unusedStatFontColor
            ui_percent_Question.BackColor = unusedKeyBackgroundColor
            ui_percent_Question.ForeColor = unusedStatFontColor
            ui_bind_Question.BackColor = unusedTextboxBackgroundColor
            ui_bind_Question.ForeColor = unusedStatFontColor

            isHeld_Question = False
            pressCount_Question = 0
            pressTimeInterval_Question = 0
            pressTimeTotal_Question = 0
            pressTimeTotalConverted_Question = 0
            pressTimeAverage_Question = 0

            ui_totalPresses_Question.Text = pressCount_Question.ToString
            ui_totalPressTime_Question.Text = pressTimeTotal_Question.ToString("N3") & " secs"
            ui_averagePressTime_Question.Text = pressTimeAverage_Question.ToString("N3") & " secs"
            ui_percent_Question.Text = "0.000%"

            'RSHIFT
            ui_Panel_RSHIFT.BackColor = unusedKeyBackgroundColor
            ui_Label_RSHIFT.BackColor = unusedKeyBackgroundColor
            ui_Label_RSHIFT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_RSHIFT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_RSHIFT.ForeColor = unusedStatFontColor
            ui_totalPressTime_RSHIFT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_RSHIFT.ForeColor = unusedStatFontColor
            ui_averagePressTime_RSHIFT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_RSHIFT.ForeColor = unusedStatFontColor
            ui_percent_RSHIFT.BackColor = unusedKeyBackgroundColor
            ui_percent_RSHIFT.ForeColor = unusedStatFontColor
            ui_bind_RSHIFT.BackColor = unusedTextboxBackgroundColor
            ui_bind_RSHIFT.ForeColor = unusedStatFontColor

            isHeld_RSHIFT = False
            pressCount_RSHIFT = 0
            pressTimeInterval_RSHIFT = 0
            pressTimeTotal_RSHIFT = 0
            pressTimeTotalConverted_RSHIFT = 0
            pressTimeAverage_RSHIFT = 0

            ui_totalPresses_RSHIFT.Text = pressCount_RSHIFT.ToString
            ui_totalPressTime_RSHIFT.Text = pressTimeTotal_RSHIFT.ToString("N3") & " secs"
            ui_averagePressTime_RSHIFT.Text = pressTimeAverage_RSHIFT.ToString("N3") & " secs"
            ui_percent_RSHIFT.Text = "0.000%"

            'UP
            ui_Panel_UP.BackColor = unusedKeyBackgroundColor
            ui_Label_UP.BackColor = unusedKeyBackgroundColor
            ui_Label_UP.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_UP.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_UP.ForeColor = unusedStatFontColor
            ui_totalPressTime_UP.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_UP.ForeColor = unusedStatFontColor
            ui_averagePressTime_UP.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_UP.ForeColor = unusedStatFontColor
            ui_percent_UP.BackColor = unusedKeyBackgroundColor
            ui_percent_UP.ForeColor = unusedStatFontColor
            ui_bind_UP.BackColor = unusedTextboxBackgroundColor
            ui_bind_UP.ForeColor = unusedStatFontColor

            isHeld_UP = False
            pressCount_UP = 0
            pressTimeInterval_UP = 0
            pressTimeTotal_UP = 0
            pressTimeTotalConverted_UP = 0
            pressTimeAverage_UP = 0

            ui_totalPresses_UP.Text = pressCount_UP.ToString
            ui_totalPressTime_UP.Text = pressTimeTotal_UP.ToString("N3") & " secs"
            ui_averagePressTime_UP.Text = pressTimeAverage_UP.ToString("N3") & " secs"
            ui_percent_UP.Text = "0.000%"

            'Num1
            ui_Panel_Num1.BackColor = unusedKeyBackgroundColor
            ui_Label_Num1.BackColor = unusedKeyBackgroundColor
            ui_Label_Num1.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num1.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num1.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num1.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num1.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num1.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num1.ForeColor = unusedStatFontColor
            ui_percent_Num1.BackColor = unusedKeyBackgroundColor
            ui_percent_Num1.ForeColor = unusedStatFontColor
            ui_bind_Num1.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num1.ForeColor = unusedStatFontColor

            isHeld_Num1 = False
            pressCount_Num1 = 0
            pressTimeInterval_Num1 = 0
            pressTimeTotal_Num1 = 0
            pressTimeTotalConverted_Num1 = 0
            pressTimeAverage_Num1 = 0

            ui_totalPresses_Num1.Text = pressCount_Num1.ToString
            ui_totalPressTime_Num1.Text = pressTimeTotal_Num1.ToString("N3") & " secs"
            ui_averagePressTime_Num1.Text = pressTimeAverage_Num1.ToString("N3") & " secs"
            ui_percent_Num1.Text = "0.000%"

            'Num2
            ui_Panel_Num2.BackColor = unusedKeyBackgroundColor
            ui_Label_Num2.BackColor = unusedKeyBackgroundColor
            ui_Label_Num2.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num2.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num2.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num2.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num2.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num2.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num2.ForeColor = unusedStatFontColor
            ui_percent_Num2.BackColor = unusedKeyBackgroundColor
            ui_percent_Num2.ForeColor = unusedStatFontColor
            ui_bind_Num2.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num2.ForeColor = unusedStatFontColor

            isHeld_Num2 = False
            pressCount_Num2 = 0
            pressTimeInterval_Num2 = 0
            pressTimeTotal_Num2 = 0
            pressTimeTotalConverted_Num2 = 0
            pressTimeAverage_Num2 = 0

            ui_totalPresses_Num2.Text = pressCount_Num2.ToString
            ui_totalPressTime_Num2.Text = pressTimeTotal_Num2.ToString("N3") & " secs"
            ui_averagePressTime_Num2.Text = pressTimeAverage_Num2.ToString("N3") & " secs"
            ui_percent_Num2.Text = "0.000%"

            'Num3
            ui_Panel_Num3.BackColor = unusedKeyBackgroundColor
            ui_Label_Num3.BackColor = unusedKeyBackgroundColor
            ui_Label_Num3.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num3.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num3.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num3.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num3.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num3.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num3.ForeColor = unusedStatFontColor
            ui_percent_Num3.BackColor = unusedKeyBackgroundColor
            ui_percent_Num3.ForeColor = unusedStatFontColor
            ui_bind_Num3.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num3.ForeColor = unusedStatFontColor

            isHeld_Num3 = False
            pressCount_Num3 = 0
            pressTimeInterval_Num3 = 0
            pressTimeTotal_Num3 = 0
            pressTimeTotalConverted_Num3 = 0
            pressTimeAverage_Num3 = 0

            ui_totalPresses_Num3.Text = pressCount_Num3.ToString
            ui_totalPressTime_Num3.Text = pressTimeTotal_Num3.ToString("N3") & " secs"
            ui_averagePressTime_Num3.Text = pressTimeAverage_Num3.ToString("N3") & " secs"
            ui_percent_Num3.Text = "0.000%"

            'LCTRL
            ui_Panel_LCTRL.BackColor = unusedKeyBackgroundColor
            ui_Label_LCTRL.BackColor = unusedKeyBackgroundColor
            ui_Label_LCTRL.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LCTRL.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LCTRL.ForeColor = unusedStatFontColor
            ui_totalPressTime_LCTRL.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LCTRL.ForeColor = unusedStatFontColor
            ui_averagePressTime_LCTRL.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LCTRL.ForeColor = unusedStatFontColor
            ui_percent_LCTRL.BackColor = unusedKeyBackgroundColor
            ui_percent_LCTRL.ForeColor = unusedStatFontColor
            ui_bind_LCTRL.BackColor = unusedTextboxBackgroundColor
            ui_bind_LCTRL.ForeColor = unusedStatFontColor

            isHeld_LCTRL = False
            pressCount_LCTRL = 0
            pressTimeInterval_LCTRL = 0
            pressTimeTotal_LCTRL = 0
            pressTimeTotalConverted_LCTRL = 0
            pressTimeAverage_LCTRL = 0

            ui_totalPresses_LCTRL.Text = pressCount_LCTRL.ToString
            ui_totalPressTime_LCTRL.Text = pressTimeTotal_LCTRL.ToString("N3") & " secs"
            ui_averagePressTime_LCTRL.Text = pressTimeAverage_LCTRL.ToString("N3") & " secs"
            ui_percent_LCTRL.Text = "0.000%"

            'LWIN
            ui_Panel_LWIN.BackColor = unusedKeyBackgroundColor
            ui_Label_LWIN.BackColor = unusedKeyBackgroundColor
            ui_Label_LWIN.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LWIN.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LWIN.ForeColor = unusedStatFontColor
            ui_totalPressTime_LWIN.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LWIN.ForeColor = unusedStatFontColor
            ui_averagePressTime_LWIN.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LWIN.ForeColor = unusedStatFontColor
            ui_percent_LWIN.BackColor = unusedKeyBackgroundColor
            ui_percent_LWIN.ForeColor = unusedStatFontColor
            ui_bind_LWIN.BackColor = unusedTextboxBackgroundColor
            ui_bind_LWIN.ForeColor = unusedStatFontColor

            isHeld_LWIN = False
            pressCount_LWIN = 0
            pressTimeInterval_LWIN = 0
            pressTimeTotal_LWIN = 0
            pressTimeTotalConverted_LWIN = 0
            pressTimeAverage_LWIN = 0

            ui_totalPresses_LWIN.Text = pressCount_LWIN.ToString
            ui_totalPressTime_LWIN.Text = pressTimeTotal_LWIN.ToString("N3") & " secs"
            ui_averagePressTime_LWIN.Text = pressTimeAverage_LWIN.ToString("N3") & " secs"
            ui_percent_LWIN.Text = "0.000%"

            'LALT
            ui_Panel_LALT.BackColor = unusedKeyBackgroundColor
            ui_Label_LALT.BackColor = unusedKeyBackgroundColor
            ui_Label_LALT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LALT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LALT.ForeColor = unusedStatFontColor
            ui_totalPressTime_LALT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LALT.ForeColor = unusedStatFontColor
            ui_averagePressTime_LALT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LALT.ForeColor = unusedStatFontColor
            ui_percent_LALT.BackColor = unusedKeyBackgroundColor
            ui_percent_LALT.ForeColor = unusedStatFontColor
            ui_bind_LALT.BackColor = unusedTextboxBackgroundColor
            ui_bind_LALT.ForeColor = unusedStatFontColor

            isHeld_LALT = False
            pressCount_LALT = 0
            pressTimeInterval_LALT = 0
            pressTimeTotal_LALT = 0
            pressTimeTotalConverted_LALT = 0
            pressTimeAverage_LALT = 0

            ui_totalPresses_LALT.Text = pressCount_LALT.ToString
            ui_totalPressTime_LALT.Text = pressTimeTotal_LALT.ToString("N3") & " secs"
            ui_averagePressTime_LALT.Text = pressTimeAverage_LALT.ToString("N3") & " secs"
            ui_percent_LALT.Text = "0.000%"

            'SpaceBar
            ui_Panel_SpaceBar.BackColor = unusedKeyBackgroundColor
            ui_Label_SpaceBar.BackColor = unusedKeyBackgroundColor
            ui_Label_SpaceBar.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_SpaceBar.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_SpaceBar.ForeColor = unusedStatFontColor
            ui_totalPressTime_SpaceBar.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_SpaceBar.ForeColor = unusedStatFontColor
            ui_averagePressTime_SpaceBar.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_SpaceBar.ForeColor = unusedStatFontColor
            ui_percent_SpaceBar.BackColor = unusedKeyBackgroundColor
            ui_percent_SpaceBar.ForeColor = unusedStatFontColor
            ui_bind_SpaceBar.BackColor = unusedTextboxBackgroundColor
            ui_bind_SpaceBar.ForeColor = unusedStatFontColor

            isHeld_SpaceBar = False
            pressCount_SpaceBar = 0
            pressTimeInterval_SpaceBar = 0
            pressTimeTotal_SpaceBar = 0
            pressTimeTotalConverted_SpaceBar = 0
            pressTimeAverage_SpaceBar = 0

            ui_totalPresses_SpaceBar.Text = pressCount_SpaceBar.ToString
            ui_totalPressTime_SpaceBar.Text = pressTimeTotal_SpaceBar.ToString("N3") & " secs"
            ui_averagePressTime_SpaceBar.Text = pressTimeAverage_SpaceBar.ToString("N3") & " secs"
            ui_percent_SpaceBar.Text = "0.000%"

            'RALT
            ui_Panel_RALT.BackColor = unusedKeyBackgroundColor
            ui_Label_RALT.BackColor = unusedKeyBackgroundColor
            ui_Label_RALT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_RALT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_RALT.ForeColor = unusedStatFontColor
            ui_totalPressTime_RALT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_RALT.ForeColor = unusedStatFontColor
            ui_averagePressTime_RALT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_RALT.ForeColor = unusedStatFontColor
            ui_percent_RALT.BackColor = unusedKeyBackgroundColor
            ui_percent_RALT.ForeColor = unusedStatFontColor
            ui_bind_RALT.BackColor = unusedTextboxBackgroundColor
            ui_bind_RALT.ForeColor = unusedStatFontColor

            isHeld_RALT = False
            pressCount_RALT = 0
            pressTimeInterval_RALT = 0
            pressTimeTotal_RALT = 0
            pressTimeTotalConverted_RALT = 0
            pressTimeAverage_RALT = 0

            ui_totalPresses_RALT.Text = pressCount_RALT.ToString
            ui_totalPressTime_RALT.Text = pressTimeTotal_RALT.ToString("N3") & " secs"
            ui_averagePressTime_RALT.Text = pressTimeAverage_RALT.ToString("N3") & " secs"
            ui_percent_RALT.Text = "0.000%"

            'RWIN
            ui_Panel_RWIN.BackColor = unusedKeyBackgroundColor
            ui_Label_RWIN.BackColor = unusedKeyBackgroundColor
            ui_Label_RWIN.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_RWIN.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_RWIN.ForeColor = unusedStatFontColor
            ui_totalPressTime_RWIN.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_RWIN.ForeColor = unusedStatFontColor
            ui_averagePressTime_RWIN.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_RWIN.ForeColor = unusedStatFontColor
            ui_percent_RWIN.BackColor = unusedKeyBackgroundColor
            ui_percent_RWIN.ForeColor = unusedStatFontColor
            ui_bind_RWIN.BackColor = unusedTextboxBackgroundColor
            ui_bind_RWIN.ForeColor = unusedStatFontColor

            isHeld_RWIN = False
            pressCount_RWIN = 0
            pressTimeInterval_RWIN = 0
            pressTimeTotal_RWIN = 0
            pressTimeTotalConverted_RWIN = 0
            pressTimeAverage_RWIN = 0

            ui_totalPresses_RWIN.Text = pressCount_RWIN.ToString
            ui_totalPressTime_RWIN.Text = pressTimeTotal_RWIN.ToString("N3") & " secs"
            ui_averagePressTime_RWIN.Text = pressTimeAverage_RWIN.ToString("N3") & " secs"
            ui_percent_RWIN.Text = "0.000%"

            'APPS
            ui_Panel_APPS.BackColor = unusedKeyBackgroundColor
            ui_Label_APPS.BackColor = unusedKeyBackgroundColor
            ui_Label_APPS.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_APPS.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_APPS.ForeColor = unusedStatFontColor
            ui_totalPressTime_APPS.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_APPS.ForeColor = unusedStatFontColor
            ui_averagePressTime_APPS.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_APPS.ForeColor = unusedStatFontColor
            ui_percent_APPS.BackColor = unusedKeyBackgroundColor
            ui_percent_APPS.ForeColor = unusedStatFontColor
            ui_bind_APPS.BackColor = unusedTextboxBackgroundColor
            ui_bind_APPS.ForeColor = unusedStatFontColor

            isHeld_APPS = False
            pressCount_APPS = 0
            pressTimeInterval_APPS = 0
            pressTimeTotal_APPS = 0
            pressTimeTotalConverted_APPS = 0
            pressTimeAverage_APPS = 0

            ui_totalPresses_APPS.Text = pressCount_APPS.ToString
            ui_totalPressTime_APPS.Text = pressTimeTotal_APPS.ToString("N3") & " secs"
            ui_averagePressTime_APPS.Text = pressTimeAverage_APPS.ToString("N3") & " secs"
            ui_percent_APPS.Text = "0.000%"

            'RCTRL
            ui_Panel_RCTRL.BackColor = unusedKeyBackgroundColor
            ui_Label_RCTRL.BackColor = unusedKeyBackgroundColor
            ui_Label_RCTRL.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_RCTRL.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_RCTRL.ForeColor = unusedStatFontColor
            ui_totalPressTime_RCTRL.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_RCTRL.ForeColor = unusedStatFontColor
            ui_averagePressTime_RCTRL.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_RCTRL.ForeColor = unusedStatFontColor
            ui_percent_RCTRL.BackColor = unusedKeyBackgroundColor
            ui_percent_RCTRL.ForeColor = unusedStatFontColor
            ui_bind_RCTRL.BackColor = unusedTextboxBackgroundColor
            ui_bind_RCTRL.ForeColor = unusedStatFontColor

            isHeld_RCTRL = False
            pressCount_RCTRL = 0
            pressTimeInterval_RCTRL = 0
            pressTimeTotal_RCTRL = 0
            pressTimeTotalConverted_RCTRL = 0
            pressTimeAverage_RCTRL = 0

            ui_totalPresses_RCTRL.Text = pressCount_RCTRL.ToString
            ui_totalPressTime_RCTRL.Text = pressTimeTotal_RCTRL.ToString("N3") & " secs"
            ui_averagePressTime_RCTRL.Text = pressTimeAverage_RCTRL.ToString("N3") & " secs"
            ui_percent_RCTRL.Text = "0.000%"

            'LT
            ui_Panel_LT.BackColor = unusedKeyBackgroundColor
            ui_Label_LT.BackColor = unusedKeyBackgroundColor
            ui_Label_LT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LT.ForeColor = unusedStatFontColor
            ui_totalPressTime_LT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LT.ForeColor = unusedStatFontColor
            ui_averagePressTime_LT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LT.ForeColor = unusedStatFontColor
            ui_percent_LT.BackColor = unusedKeyBackgroundColor
            ui_percent_LT.ForeColor = unusedStatFontColor
            ui_bind_LT.BackColor = unusedTextboxBackgroundColor
            ui_bind_LT.ForeColor = unusedStatFontColor

            isHeld_LT = False
            pressCount_LT = 0
            pressTimeInterval_LT = 0
            pressTimeTotal_LT = 0
            pressTimeTotalConverted_LT = 0
            pressTimeAverage_LT = 0

            ui_totalPresses_LT.Text = pressCount_LT.ToString
            ui_totalPressTime_LT.Text = pressTimeTotal_LT.ToString("N3") & " secs"
            ui_averagePressTime_LT.Text = pressTimeAverage_LT.ToString("N3") & " secs"
            ui_percent_LT.Text = "0.000%"

            'DN
            ui_Panel_DN.BackColor = unusedKeyBackgroundColor
            ui_Label_DN.BackColor = unusedKeyBackgroundColor
            ui_Label_DN.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_DN.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_DN.ForeColor = unusedStatFontColor
            ui_totalPressTime_DN.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_DN.ForeColor = unusedStatFontColor
            ui_averagePressTime_DN.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_DN.ForeColor = unusedStatFontColor
            ui_percent_DN.BackColor = unusedKeyBackgroundColor
            ui_percent_DN.ForeColor = unusedStatFontColor
            ui_bind_DN.BackColor = unusedTextboxBackgroundColor
            ui_bind_DN.ForeColor = unusedStatFontColor

            isHeld_DN = False
            pressCount_DN = 0
            pressTimeInterval_DN = 0
            pressTimeTotal_DN = 0
            pressTimeTotalConverted_DN = 0
            pressTimeAverage_DN = 0

            ui_totalPresses_DN.Text = pressCount_DN.ToString
            ui_totalPressTime_DN.Text = pressTimeTotal_DN.ToString("N3") & " secs"
            ui_averagePressTime_DN.Text = pressTimeAverage_DN.ToString("N3") & " secs"
            ui_percent_DN.Text = "0.000%"

            'RT
            ui_Panel_RT.BackColor = unusedKeyBackgroundColor
            ui_Label_RT.BackColor = unusedKeyBackgroundColor
            ui_Label_RT.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_RT.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_RT.ForeColor = unusedStatFontColor
            ui_totalPressTime_RT.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_RT.ForeColor = unusedStatFontColor
            ui_averagePressTime_RT.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_RT.ForeColor = unusedStatFontColor
            ui_percent_RT.BackColor = unusedKeyBackgroundColor
            ui_percent_RT.ForeColor = unusedStatFontColor
            ui_bind_RT.BackColor = unusedTextboxBackgroundColor
            ui_bind_RT.ForeColor = unusedStatFontColor

            isHeld_RT = False
            pressCount_RT = 0
            pressTimeInterval_RT = 0
            pressTimeTotal_RT = 0
            pressTimeTotalConverted_RT = 0
            pressTimeAverage_RT = 0

            ui_totalPresses_RT.Text = pressCount_RT.ToString
            ui_totalPressTime_RT.Text = pressTimeTotal_RT.ToString("N3") & " secs"
            ui_averagePressTime_RT.Text = pressTimeAverage_RT.ToString("N3") & " secs"
            ui_percent_RT.Text = "0.000%"

            'Num0
            ui_Panel_Num0.BackColor = unusedKeyBackgroundColor
            ui_Label_Num0.BackColor = unusedKeyBackgroundColor
            ui_Label_Num0.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Num0.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Num0.ForeColor = unusedStatFontColor
            ui_totalPressTime_Num0.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Num0.ForeColor = unusedStatFontColor
            ui_averagePressTime_Num0.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Num0.ForeColor = unusedStatFontColor
            ui_percent_Num0.BackColor = unusedKeyBackgroundColor
            ui_percent_Num0.ForeColor = unusedStatFontColor
            ui_bind_Num0.BackColor = unusedTextboxBackgroundColor
            ui_bind_Num0.ForeColor = unusedStatFontColor

            isHeld_Num0 = False
            pressCount_Num0 = 0
            pressTimeInterval_Num0 = 0
            pressTimeTotal_Num0 = 0
            pressTimeTotalConverted_Num0 = 0
            pressTimeAverage_Num0 = 0

            ui_totalPresses_Num0.Text = pressCount_Num0.ToString
            ui_totalPressTime_Num0.Text = pressTimeTotal_Num0.ToString("N3") & " secs"
            ui_averagePressTime_Num0.Text = pressTimeAverage_Num0.ToString("N3") & " secs"
            ui_percent_Num0.Text = "0.000%"

            'Decimal
            ui_Panel_Decimal.BackColor = unusedKeyBackgroundColor
            ui_Label_Decimal.BackColor = unusedKeyBackgroundColor
            ui_Label_Decimal.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_Decimal.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_Decimal.ForeColor = unusedStatFontColor
            ui_totalPressTime_Decimal.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_Decimal.ForeColor = unusedStatFontColor
            ui_averagePressTime_Decimal.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_Decimal.ForeColor = unusedStatFontColor
            ui_percent_Decimal.BackColor = unusedKeyBackgroundColor
            ui_percent_Decimal.ForeColor = unusedStatFontColor
            ui_bind_Decimal.BackColor = unusedTextboxBackgroundColor
            ui_bind_Decimal.ForeColor = unusedStatFontColor

            isHeld_Decimal = False
            pressCount_Decimal = 0
            pressTimeInterval_Decimal = 0
            pressTimeTotal_Decimal = 0
            pressTimeTotalConverted_Decimal = 0
            pressTimeAverage_Decimal = 0

            ui_totalPresses_Decimal.Text = pressCount_Decimal.ToString
            ui_totalPressTime_Decimal.Text = pressTimeTotal_Decimal.ToString("N3") & " secs"
            ui_averagePressTime_Decimal.Text = pressTimeAverage_Decimal.ToString("N3") & " secs"
            ui_percent_Decimal.Text = "0.000%"

            'LMB
            ui_Panel_LMB.BackColor = unusedKeyBackgroundColor
            ui_Label_LMB.BackColor = unusedKeyBackgroundColor
            ui_Label_LMB.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_LMB.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_LMB.ForeColor = unusedStatFontColor
            ui_totalPressTime_LMB.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_LMB.ForeColor = unusedStatFontColor
            ui_averagePressTime_LMB.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_LMB.ForeColor = unusedStatFontColor
            ui_percent_LMB.BackColor = unusedKeyBackgroundColor
            ui_percent_LMB.ForeColor = unusedStatFontColor
            ui_bind_LMB.BackColor = unusedTextboxBackgroundColor
            ui_bind_LMB.ForeColor = unusedStatFontColor

            isHeld_LMB = False
            pressCount_LMB = 0
            pressTimeInterval_LMB = 0
            pressTimeTotal_LMB = 0
            pressTimeTotalConverted_LMB = 0
            pressTimeAverage_LMB = 0

            ui_totalPresses_LMB.Text = pressCount_LMB.ToString
            ui_totalPressTime_LMB.Text = pressTimeTotal_LMB.ToString("N3") & " secs"
            ui_averagePressTime_LMB.Text = pressTimeAverage_LMB.ToString("N3") & " secs"
            ui_percent_LMB.Text = "0.000%"

            'MMB
            ui_Panel_MMB.BackColor = unusedKeyBackgroundColor
            ui_Label_MMB.BackColor = unusedKeyBackgroundColor
            ui_Label_MMB.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_MMB.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_MMB.ForeColor = unusedStatFontColor
            ui_totalPressTime_MMB.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_MMB.ForeColor = unusedStatFontColor
            ui_averagePressTime_MMB.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_MMB.ForeColor = unusedStatFontColor
            ui_percent_MMB.BackColor = unusedKeyBackgroundColor
            ui_percent_MMB.ForeColor = unusedStatFontColor
            ui_bind_MMB.BackColor = unusedTextboxBackgroundColor
            ui_bind_MMB.ForeColor = unusedStatFontColor

            isHeld_MMB = False
            pressCount_MMB = 0
            pressTimeInterval_MMB = 0
            pressTimeTotal_MMB = 0
            pressTimeTotalConverted_MMB = 0
            pressTimeAverage_MMB = 0

            ui_totalPresses_MMB.Text = pressCount_MMB.ToString
            ui_totalPressTime_MMB.Text = pressTimeTotal_MMB.ToString("N3") & " secs"
            ui_averagePressTime_MMB.Text = pressTimeAverage_MMB.ToString("N3") & " secs"
            ui_percent_MMB.Text = "0.000%"

            'RMB
            ui_Panel_RMB.BackColor = unusedKeyBackgroundColor
            ui_Label_RMB.BackColor = unusedKeyBackgroundColor
            ui_Label_RMB.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_RMB.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_RMB.ForeColor = unusedStatFontColor
            ui_totalPressTime_RMB.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_RMB.ForeColor = unusedStatFontColor
            ui_averagePressTime_RMB.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_RMB.ForeColor = unusedStatFontColor
            ui_percent_RMB.BackColor = unusedKeyBackgroundColor
            ui_percent_RMB.ForeColor = unusedStatFontColor
            ui_bind_RMB.BackColor = unusedTextboxBackgroundColor
            ui_bind_RMB.ForeColor = unusedStatFontColor

            isHeld_RMB = False
            pressCount_RMB = 0
            pressTimeInterval_RMB = 0
            pressTimeTotal_RMB = 0
            pressTimeTotalConverted_RMB = 0
            pressTimeAverage_RMB = 0

            ui_totalPresses_RMB.Text = pressCount_RMB.ToString
            ui_totalPressTime_RMB.Text = pressTimeTotal_RMB.ToString("N3") & " secs"
            ui_averagePressTime_RMB.Text = pressTimeAverage_RMB.ToString("N3") & " secs"
            ui_percent_RMB.Text = "0.000%"

            'MSU
            ui_Panel_MSU.BackColor = unusedKeyBackgroundColor
            ui_Label_MSU.BackColor = unusedKeyBackgroundColor
            ui_Label_MSU.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_MSU.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_MSU.ForeColor = unusedStatFontColor
            ui_totalPressTime_MSU.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_MSU.ForeColor = unusedStatFontColor
            ui_averagePressTime_MSU.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_MSU.ForeColor = unusedStatFontColor
            ui_percent_MSU.BackColor = unusedKeyBackgroundColor
            ui_percent_MSU.ForeColor = unusedStatFontColor
            ui_bind_MSU.BackColor = unusedTextboxBackgroundColor
            ui_bind_MSU.ForeColor = unusedStatFontColor

            isHeld_MSU = False
            pressCount_MSU = 0
            pressTimeInterval_MSU = 0
            pressTimeTotal_MSU = 0
            pressTimeTotalConverted_MSU = 0
            pressTimeAverage_MSU = 0

            ui_totalPresses_MSU.Text = pressCount_MSU.ToString
            ui_totalPressTime_MSU.Text = pressTimeTotal_MSU.ToString("N3") & " secs"
            ui_averagePressTime_MSU.Text = pressTimeAverage_MSU.ToString("N3") & " secs"
            ui_percent_MSU.Text = "0.000%"

            'MSD
            ui_Panel_MSD.BackColor = unusedKeyBackgroundColor
            ui_Label_MSD.BackColor = unusedKeyBackgroundColor
            ui_Label_MSD.ForeColor = unusedKeyNameFontColor
            ui_totalPresses_MSD.BackColor = unusedKeyBackgroundColor
            ui_totalPresses_MSD.ForeColor = unusedStatFontColor
            ui_totalPressTime_MSD.BackColor = unusedKeyBackgroundColor
            ui_totalPressTime_MSD.ForeColor = unusedStatFontColor
            ui_averagePressTime_MSD.BackColor = unusedKeyBackgroundColor
            ui_averagePressTime_MSD.ForeColor = unusedStatFontColor
            ui_percent_MSD.BackColor = unusedKeyBackgroundColor
            ui_percent_MSD.ForeColor = unusedStatFontColor
            ui_bind_MSD.BackColor = unusedTextboxBackgroundColor
            ui_bind_MSD.ForeColor = unusedStatFontColor

            isHeld_MSD = False
            pressCount_MSD = 0
            pressTimeInterval_MSD = 0
            pressTimeTotal_MSD = 0
            pressTimeTotalConverted_MSD = 0
            pressTimeAverage_MSD = 0

            ui_totalPresses_MSD.Text = pressCount_MSD.ToString
            ui_totalPressTime_MSD.Text = pressTimeTotal_MSD.ToString("N3") & " secs"
            ui_averagePressTime_MSD.Text = pressTimeAverage_MSD.ToString("N3") & " secs"
            ui_percent_MSD.Text = "0.000%"




        End If

        uiResetAllDataCheck.Checked = False



    End Sub

    Sub Sessions()







    End Sub

    Sub SaveProfile()





    End Sub

    Sub LoadProfile()




    End Sub

    Sub ExportCSV()






    End Sub

End Class