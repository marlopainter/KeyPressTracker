
Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices
Imports System.Threading

Partial Public Class MainForm

    Sub FormLoadedStuff() Handles Me.Load

        MouseHook = New InputHelper.Hooks.MouseHook()
        checkKeysThread.Start()
        processKeysThread.Start()
        uiResetAllDataCheck.Checked = True
        session_StartTime = DateTime.Now
        DataReset()
        UpdateUI()

    End Sub

    Sub UpdateUI() Handles uiUpdateTimer.Tick

        '::::: Totals Updates

        'Total Presses
        uiTotalPresses.Text = totalPresses.ToString

        Dim tempTime As Decimal
        'Total Press Time
        If totalPressTime < 60 Then
            If totalPressTime = 1 Then
                uiTotalPessTime.Text = totalPressTime.ToString("N3") & " sec"
            Else
                uiTotalPessTime.Text = totalPressTime.ToString("N3") & " secs"
            End If
        ElseIf totalPressTime > 60 And totalPressTime < 3600 Then
            tempTime = totalPressTime / 60
            If totalPressTime = 1 Then
                uiTotalPessTime.Text = tempTime.ToString("N3") & " min"
            Else
                uiTotalPessTime.Text = tempTime.ToString("N3") & " mins"
            End If
        ElseIf totalPressTime > 3600 Or totalPressTime = 3600 Then
            tempTime = totalPressTime / 3600
            If tempTime = 1 Then
                uiTotalPessTime.Text = tempTime.ToString("N3") & " hour"
            Else
                uiTotalPessTime.Text = tempTime.ToString("N3") & " hours"
            End If
        End If

        'Average Press Time
        If totalPresses > 0 AndAlso totalPressTime > 0 Then
            averagePressTime = totalPressTime / totalPresses
        Else
            averagePressTime = 0
        End If

        If averagePressTime < 60 Then
            If averagePressTime = 1 Then
                uiAveragePressTime.Text = averagePressTime.ToString("N3") & " sec"
            Else
                uiAveragePressTime.Text = averagePressTime.ToString("N3") & " secs"
            End If
        ElseIf averagePressTime > 60 And averagePressTime < 3600 Then
            Dim tempTimeAvg As Decimal = averagePressTime / 60
            If averagePressTime = 1 Then
                uiAveragePressTime.Text = tempTimeAvg.ToString("N3") & " min"
            Else
                uiAveragePressTime.Text = tempTimeAvg.ToString("N3") & " mins"
            End If
        ElseIf averagePressTime > 3600 Or averagePressTime = 3600 Then
            Dim tempTimeAvg As Decimal = averagePressTime / 3600
            If tempTimeAvg = 1 Then
                uiAveragePressTime.Text = tempTimeAvg.ToString("N3") & " hour"
            Else
                uiAveragePressTime.Text = tempTimeAvg.ToString("N3") & " hours"
            End If
        End If


        '::::: Session Updates

        If session_Check = 0 Then

            session_TotalPresses = totalPresses

            session_EndTime = DateTime.Now
            session_Interval_Seconds = IntervalMath(session_StartTime, session_EndTime)

            session_APM_Interval = 60 / session_Interval_Seconds
            session_APM = session_APM_Interval * session_TotalPresses
            uiAPM.Text = session_APM.ToString("N3")


            If session_Interval_Seconds < 60 Then

                session_Interval_Seconds = IntervalMath(session_StartTime, session_EndTime)
                uiSessionTime.Text = session_Interval_Seconds.ToString("N3") & " seconds"

            Else

                session_Interval_Seconds /= 60
                uiSessionTime.Text = session_Interval_Seconds.ToString("N3") & " minutes"

            End If

        Else

            session_Interval_Seconds = IntervalMath(session_StartTime, session_EndTime)

            session_APM_Interval = 60 / session_Interval_Seconds
            session_APM = session_APM_Interval * session_TotalPresses
            uiAPM.Text = session_APM.ToString("N3")

            If session_Interval_Seconds < 60 Then

                session_Interval_Seconds = IntervalMath(session_StartTime, session_EndTime)
                uiSessionTime.Text = session_Interval_Seconds.ToString("N3") & " seconds"

            Else

                session_Interval_Seconds /= 60
                uiSessionTime.Text = session_Interval_Seconds.ToString("N3") & " minutes"

            End If

        End If









        '::::: Key Info Updates

        'ESC
        If pressCount_ESC > 0 Then 'Used

            ui_Panel_ESC.BackColor = usedBackgroundColor
            ui_Label_ESC.BackColor = usedBackgroundColor
            ui_Label_ESC.ForeColor = usedKeyNameFontColor
            ui_totalPresses_ESC.BackColor = usedBackgroundColor
            ui_totalPresses_ESC.ForeColor = usedStatFontColor
            ui_totalPressTime_ESC.BackColor = usedBackgroundColor
            ui_totalPressTime_ESC.ForeColor = usedStatFontColor
            ui_averagePressTime_ESC.BackColor = usedBackgroundColor
            ui_averagePressTime_ESC.ForeColor = usedStatFontColor
            ui_percent_ESC.BackColor = usedBackgroundColor
            ui_percent_ESC.ForeColor = usedStatFontColor
            ui_bind_ESC.BackColor = usedTextboxBackgroundColor
            ui_bind_ESC.ForeColor = usedStatFontColor
            ui_totalPresses_ESC.Text = pressCount_ESC.ToString

            Dim tempESCtime As Decimal = 0

            If pressTimeTotal_ESC < 60 Then
                If pressTimeTotal_ESC = 1 Then
                    ui_totalPressTime_ESC.Text = pressTimeTotal_ESC.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_ESC.Text = pressTimeTotal_ESC.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_ESC > 60 And pressTimeTotal_ESC < 3600 Then
                tempESCtime = pressTimeTotal_ESC / 60
                If pressTimeTotal_ESC = 1 Then
                    ui_totalPressTime_ESC.Text = tempESCtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_ESC.Text = tempESCtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_ESC > 3600 Or pressTimeTotal_ESC = 3600 Then
                tempESCtime = pressTimeTotal_ESC / 3600
                If tempESCtime = 1 Then
                    ui_totalPressTime_ESC.Text = tempESCtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_ESC.Text = tempESCtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_ESC = pressTimeTotal_ESC / pressCount_ESC

            If pressTimeAverage_ESC < 60 Then
                If pressTimeAverage_ESC = 1 Then
                    ui_averagePressTime_ESC.Text = pressTimeAverage_ESC.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_ESC.Text = pressTimeAverage_ESC.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_ESC > 60 And pressTimeAverage_ESC < 3600 Then
                pressTimeTotal_ESC /= 60
                If pressTimeTotal_ESC = 1 Then
                    ui_averagePressTime_ESC.Text = pressTimeTotal_ESC.ToString("N3") & " min"
                Else
                    ui_averagePressTime_ESC.Text = pressTimeTotal_ESC.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_ESC > 3600 Or pressTimeAverage_ESC = 3600 Then
                pressTimeTotal_ESC /= 3600
                If pressTimeTotal_ESC = 1 Then
                    ui_averagePressTime_ESC.Text = pressTimeTotal_ESC.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_ESC.Text = pressTimeTotal_ESC.ToString("N3") & " hours"
                End If
            End If

            ui_percent_ESC.Text = ((pressCount_ESC / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F1
        If pressCount_F1 > 0 Then 'Used

            ui_Panel_F1.BackColor = usedBackgroundColor
            ui_Label_F1.BackColor = usedBackgroundColor
            ui_Label_F1.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F1.BackColor = usedBackgroundColor
            ui_totalPresses_F1.ForeColor = usedStatFontColor
            ui_totalPressTime_F1.BackColor = usedBackgroundColor
            ui_totalPressTime_F1.ForeColor = usedStatFontColor
            ui_averagePressTime_F1.BackColor = usedBackgroundColor
            ui_averagePressTime_F1.ForeColor = usedStatFontColor
            ui_percent_F1.BackColor = usedBackgroundColor
            ui_percent_F1.ForeColor = usedStatFontColor
            ui_bind_F1.BackColor = usedTextboxBackgroundColor
            ui_bind_F1.ForeColor = usedStatFontColor
            ui_totalPresses_F1.Text = pressCount_F1.ToString

            Dim tempF1time As Decimal = 0

            If pressTimeTotal_F1 < 60 Then
                If pressTimeTotal_F1 = 1 Then
                    ui_totalPressTime_F1.Text = pressTimeTotal_F1.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F1.Text = pressTimeTotal_F1.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F1 > 60 And pressTimeTotal_F1 < 3600 Then
                tempF1time = pressTimeTotal_F1 / 60
                If pressTimeTotal_F1 = 1 Then
                    ui_totalPressTime_F1.Text = tempF1time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F1.Text = tempF1time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F1 > 3600 Or pressTimeTotal_F1 = 3600 Then
                tempF1time = pressTimeTotal_F1 / 3600
                If tempF1time = 1 Then
                    ui_totalPressTime_F1.Text = tempF1time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F1.Text = tempF1time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F1 = pressTimeTotal_F1 / pressCount_F1

            If pressTimeAverage_F1 < 60 Then
                If pressTimeAverage_F1 = 1 Then
                    ui_averagePressTime_F1.Text = pressTimeAverage_F1.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F1.Text = pressTimeAverage_F1.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F1 > 60 And pressTimeAverage_F1 < 3600 Then
                pressTimeTotal_F1 /= 60
                If pressTimeTotal_F1 = 1 Then
                    ui_averagePressTime_F1.Text = pressTimeTotal_F1.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F1.Text = pressTimeTotal_F1.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F1 > 3600 Or pressTimeAverage_F1 = 3600 Then
                pressTimeTotal_F1 /= 3600
                If pressTimeTotal_F1 = 1 Then
                    ui_averagePressTime_F1.Text = pressTimeTotal_F1.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F1.Text = pressTimeTotal_F1.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F1.Text = ((pressCount_F1 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F2
        If pressCount_F2 > 0 Then 'Used

            ui_Panel_F2.BackColor = usedBackgroundColor
            ui_Label_F2.BackColor = usedBackgroundColor
            ui_Label_F2.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F2.BackColor = usedBackgroundColor
            ui_totalPresses_F2.ForeColor = usedStatFontColor
            ui_totalPressTime_F2.BackColor = usedBackgroundColor
            ui_totalPressTime_F2.ForeColor = usedStatFontColor
            ui_averagePressTime_F2.BackColor = usedBackgroundColor
            ui_averagePressTime_F2.ForeColor = usedStatFontColor
            ui_percent_F2.BackColor = usedBackgroundColor
            ui_percent_F2.ForeColor = usedStatFontColor
            ui_bind_F2.BackColor = usedTextboxBackgroundColor
            ui_bind_F2.ForeColor = usedStatFontColor
            ui_totalPresses_F2.Text = pressCount_F2.ToString

            Dim tempF2time As Decimal = 0

            If pressTimeTotal_F2 < 60 Then
                If pressTimeTotal_F2 = 1 Then
                    ui_totalPressTime_F2.Text = pressTimeTotal_F2.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F2.Text = pressTimeTotal_F2.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F2 > 60 And pressTimeTotal_F2 < 3600 Then
                tempF2time = pressTimeTotal_F2 / 60
                If pressTimeTotal_F2 = 1 Then
                    ui_totalPressTime_F2.Text = tempF2time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F2.Text = tempF2time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F2 > 3600 Or pressTimeTotal_F2 = 3600 Then
                tempF2time = pressTimeTotal_F2 / 3600
                If tempF2time = 1 Then
                    ui_totalPressTime_F2.Text = tempF2time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F2.Text = tempF2time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F2 = pressTimeTotal_F2 / pressCount_F2

            If pressTimeAverage_F2 < 60 Then
                If pressTimeAverage_F2 = 1 Then
                    ui_averagePressTime_F2.Text = pressTimeAverage_F2.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F2.Text = pressTimeAverage_F2.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F2 > 60 And pressTimeAverage_F2 < 3600 Then
                pressTimeTotal_F2 /= 60
                If pressTimeTotal_F2 = 1 Then
                    ui_averagePressTime_F2.Text = pressTimeTotal_F2.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F2.Text = pressTimeTotal_F2.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F2 > 3600 Or pressTimeAverage_F2 = 3600 Then
                pressTimeTotal_F2 /= 3600
                If pressTimeTotal_F2 = 1 Then
                    ui_averagePressTime_F2.Text = pressTimeTotal_F2.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F2.Text = pressTimeTotal_F2.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F2.Text = ((pressCount_F2 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F3
        If pressCount_F3 > 0 Then 'Used

            ui_Panel_F3.BackColor = usedBackgroundColor
            ui_Label_F3.BackColor = usedBackgroundColor
            ui_Label_F3.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F3.BackColor = usedBackgroundColor
            ui_totalPresses_F3.ForeColor = usedStatFontColor
            ui_totalPressTime_F3.BackColor = usedBackgroundColor
            ui_totalPressTime_F3.ForeColor = usedStatFontColor
            ui_averagePressTime_F3.BackColor = usedBackgroundColor
            ui_averagePressTime_F3.ForeColor = usedStatFontColor
            ui_percent_F3.BackColor = usedBackgroundColor
            ui_percent_F3.ForeColor = usedStatFontColor
            ui_bind_F3.BackColor = usedTextboxBackgroundColor
            ui_bind_F3.ForeColor = usedStatFontColor
            ui_totalPresses_F3.Text = pressCount_F3.ToString

            Dim tempF3time As Decimal = 0

            If pressTimeTotal_F3 < 60 Then
                If pressTimeTotalConverted_F3 = 1 Then
                    ui_totalPressTime_F3.Text = pressTimeTotal_F3.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F3.Text = pressTimeTotal_F3.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F3 > 60 And pressTimeTotal_F3 < 3600 Then
                tempF3time = pressTimeTotal_F3 / 60
                If pressTimeTotal_F3 = 1 Then
                    ui_totalPressTime_F3.Text = tempF3time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F3.Text = tempF3time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F3 > 3600 Or pressTimeTotal_F3 = 3600 Then
                tempF3time = pressTimeTotal_F3 / 3600
                If tempF3time = 1 Then
                    ui_totalPressTime_F3.Text = tempF3time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F3.Text = tempF3time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F3 = pressTimeTotal_F3 / pressCount_F3

            If pressTimeAverage_F3 < 60 Then
                If pressTimeAverage_F3 = 1 Then
                    ui_averagePressTime_F3.Text = pressTimeAverage_F3.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F3.Text = pressTimeAverage_F3.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F3 > 60 And pressTimeAverage_F3 < 3600 Then
                pressTimeTotal_F3 /= 60
                If pressTimeTotal_F3 = 1 Then
                    ui_averagePressTime_F3.Text = pressTimeTotal_F3.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F3.Text = pressTimeTotal_F3.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F3 > 3600 Or pressTimeAverage_F3 = 3600 Then
                pressTimeTotal_F3 /= 3600
                If pressTimeTotal_F3 = 1 Then
                    ui_averagePressTime_F3.Text = pressTimeTotal_F3.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F3.Text = pressTimeTotal_F3.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F3.Text = ((pressCount_F3 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F4
        If pressCount_F4 > 0 Then 'Used

            ui_Panel_F4.BackColor = usedBackgroundColor
            ui_Label_F4.BackColor = usedBackgroundColor
            ui_Label_F4.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F4.BackColor = usedBackgroundColor
            ui_totalPresses_F4.ForeColor = usedStatFontColor
            ui_totalPressTime_F4.BackColor = usedBackgroundColor
            ui_totalPressTime_F4.ForeColor = usedStatFontColor
            ui_averagePressTime_F4.BackColor = usedBackgroundColor
            ui_averagePressTime_F4.ForeColor = usedStatFontColor
            ui_percent_F4.BackColor = usedBackgroundColor
            ui_percent_F4.ForeColor = usedStatFontColor
            ui_bind_F4.BackColor = usedTextboxBackgroundColor
            ui_bind_F4.ForeColor = usedStatFontColor
            ui_totalPresses_F4.Text = pressCount_F4.ToString

            Dim tempF4time As Decimal = 0

            If pressTimeTotal_F4 < 60 Then
                If pressTimeTotalConverted_F4 = 1 Then
                    ui_totalPressTime_F4.Text = pressTimeTotal_F4.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F4.Text = pressTimeTotal_F4.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F4 > 60 And pressTimeTotal_F4 < 3600 Then
                tempF4time = pressTimeTotal_F4 / 60
                If pressTimeTotal_F4 = 1 Then
                    ui_totalPressTime_F4.Text = tempF4time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F4.Text = tempF4time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F4 > 3600 Or pressTimeTotal_F4 = 3600 Then
                tempF4time = pressTimeTotal_F4 / 3600
                If tempF4time = 1 Then
                    ui_totalPressTime_F4.Text = tempF4time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F4.Text = tempF4time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F4 = pressTimeTotal_F4 / pressCount_F4

            If pressTimeAverage_F4 < 60 Then
                If pressTimeAverage_F4 = 1 Then
                    ui_averagePressTime_F4.Text = pressTimeAverage_F4.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F4.Text = pressTimeAverage_F4.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F4 > 60 And pressTimeAverage_F4 < 3600 Then
                pressTimeTotal_F4 /= 60
                If pressTimeTotal_F4 = 1 Then
                    ui_averagePressTime_F4.Text = pressTimeTotal_F4.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F4.Text = pressTimeTotal_F4.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F4 > 3600 Or pressTimeAverage_F4 = 3600 Then
                pressTimeTotal_F4 /= 3600
                If pressTimeTotal_F4 = 1 Then
                    ui_averagePressTime_F4.Text = pressTimeTotal_F4.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F4.Text = pressTimeTotal_F4.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F4.Text = ((pressCount_F4 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F5
        If pressCount_F5 > 0 Then 'Used

            ui_Panel_F5.BackColor = usedBackgroundColor
            ui_Label_F5.BackColor = usedBackgroundColor
            ui_Label_F5.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F5.BackColor = usedBackgroundColor
            ui_totalPresses_F5.ForeColor = usedStatFontColor
            ui_totalPressTime_F5.BackColor = usedBackgroundColor
            ui_totalPressTime_F5.ForeColor = usedStatFontColor
            ui_averagePressTime_F5.BackColor = usedBackgroundColor
            ui_averagePressTime_F5.ForeColor = usedStatFontColor
            ui_percent_F5.BackColor = usedBackgroundColor
            ui_percent_F5.ForeColor = usedStatFontColor
            ui_bind_F5.BackColor = usedTextboxBackgroundColor
            ui_bind_F5.ForeColor = usedStatFontColor
            ui_totalPresses_F5.Text = pressCount_F5.ToString

            Dim tempF5time As Decimal = 0

            If pressTimeTotal_F5 < 60 Then
                If pressTimeTotalConverted_F5 = 1 Then
                    ui_totalPressTime_F5.Text = pressTimeTotal_F5.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F5.Text = pressTimeTotal_F5.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F5 > 60 And pressTimeTotal_F5 < 3600 Then
                tempF5time = pressTimeTotal_F5 / 60
                If pressTimeTotal_F5 = 1 Then
                    ui_totalPressTime_F5.Text = tempF5time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F5.Text = tempF5time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F5 > 3600 Or pressTimeTotal_F5 = 3600 Then
                tempF5time = pressTimeTotal_F5 / 3600
                If tempF5time = 1 Then
                    ui_totalPressTime_F5.Text = tempF5time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F5.Text = tempF5time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F5 = pressTimeTotal_F5 / pressCount_F5

            If pressTimeAverage_F5 < 60 Then
                If pressTimeAverage_F5 = 1 Then
                    ui_averagePressTime_F5.Text = pressTimeAverage_F5.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F5.Text = pressTimeAverage_F5.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F5 > 60 And pressTimeAverage_F5 < 3600 Then
                pressTimeTotal_F5 /= 60
                If pressTimeTotal_F5 = 1 Then
                    ui_averagePressTime_F5.Text = pressTimeTotal_F5.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F5.Text = pressTimeTotal_F5.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F5 > 3600 Or pressTimeAverage_F5 = 3600 Then
                pressTimeTotal_F5 /= 3600
                If pressTimeTotal_F5 = 1 Then
                    ui_averagePressTime_F5.Text = pressTimeTotal_F5.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F5.Text = pressTimeTotal_F5.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F5.Text = ((pressCount_F5 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F6
        If pressCount_F6 > 0 Then 'Used

            ui_Panel_F6.BackColor = usedBackgroundColor
            ui_Label_F6.BackColor = usedBackgroundColor
            ui_Label_F6.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F6.BackColor = usedBackgroundColor
            ui_totalPresses_F6.ForeColor = usedStatFontColor
            ui_totalPressTime_F6.BackColor = usedBackgroundColor
            ui_totalPressTime_F6.ForeColor = usedStatFontColor
            ui_averagePressTime_F6.BackColor = usedBackgroundColor
            ui_averagePressTime_F6.ForeColor = usedStatFontColor
            ui_percent_F6.BackColor = usedBackgroundColor
            ui_percent_F6.ForeColor = usedStatFontColor
            ui_bind_F6.BackColor = usedTextboxBackgroundColor
            ui_bind_F6.ForeColor = usedStatFontColor
            ui_totalPresses_F6.Text = pressCount_F6.ToString

            Dim tempF6time As Decimal = 0

            If pressTimeTotal_F6 < 60 Then
                If pressTimeTotalConverted_F6 = 1 Then
                    ui_totalPressTime_F6.Text = pressTimeTotal_F6.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F6.Text = pressTimeTotal_F6.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F6 > 60 And pressTimeTotal_F6 < 3600 Then
                tempF6time = pressTimeTotal_F6 / 60
                If pressTimeTotal_F6 = 1 Then
                    ui_totalPressTime_F6.Text = tempF6time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F6.Text = tempF6time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F6 > 3600 Or pressTimeTotal_F6 = 3600 Then
                tempF6time = pressTimeTotal_F6 / 3600
                If tempF6time = 1 Then
                    ui_totalPressTime_F6.Text = tempF6time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F6.Text = tempF6time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F6 = pressTimeTotal_F6 / pressCount_F6

            If pressTimeAverage_F6 < 60 Then
                If pressTimeAverage_F6 = 1 Then
                    ui_averagePressTime_F6.Text = pressTimeAverage_F6.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F6.Text = pressTimeAverage_F6.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F6 > 60 And pressTimeAverage_F6 < 3600 Then
                pressTimeTotal_F6 /= 60
                If pressTimeTotal_F6 = 1 Then
                    ui_averagePressTime_F6.Text = pressTimeTotal_F6.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F6.Text = pressTimeTotal_F6.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F6 > 3600 Or pressTimeAverage_F6 = 3600 Then
                pressTimeTotal_F6 /= 3600
                If pressTimeTotal_F6 = 1 Then
                    ui_averagePressTime_F6.Text = pressTimeTotal_F6.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F6.Text = pressTimeTotal_F6.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F6.Text = ((pressCount_F6 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F7
        If pressCount_F7 > 0 Then 'Used

            ui_Panel_F7.BackColor = usedBackgroundColor
            ui_Label_F7.BackColor = usedBackgroundColor
            ui_Label_F7.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F7.BackColor = usedBackgroundColor
            ui_totalPresses_F7.ForeColor = usedStatFontColor
            ui_totalPressTime_F7.BackColor = usedBackgroundColor
            ui_totalPressTime_F7.ForeColor = usedStatFontColor
            ui_averagePressTime_F7.BackColor = usedBackgroundColor
            ui_averagePressTime_F7.ForeColor = usedStatFontColor
            ui_percent_F7.BackColor = usedBackgroundColor
            ui_percent_F7.ForeColor = usedStatFontColor
            ui_bind_F7.BackColor = usedTextboxBackgroundColor
            ui_bind_F7.ForeColor = usedStatFontColor
            ui_totalPresses_F7.Text = pressCount_F7.ToString

            Dim tempF7time As Decimal = 0

            If pressTimeTotal_F7 < 60 Then
                If pressTimeTotalConverted_F7 = 1 Then
                    ui_totalPressTime_F7.Text = pressTimeTotal_F7.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F7.Text = pressTimeTotal_F7.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F7 > 60 And pressTimeTotal_F7 < 3600 Then
                tempF7time = pressTimeTotal_F7 / 60
                If pressTimeTotal_F7 = 1 Then
                    ui_totalPressTime_F7.Text = tempF7time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F7.Text = tempF7time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F7 > 3600 Or pressTimeTotal_F7 = 3600 Then
                tempF7time = pressTimeTotal_F7 / 3600
                If tempF7time = 1 Then
                    ui_totalPressTime_F7.Text = tempF7time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F7.Text = tempF7time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F7 = pressTimeTotal_F7 / pressCount_F7

            If pressTimeAverage_F7 < 60 Then
                If pressTimeAverage_F7 = 1 Then
                    ui_averagePressTime_F7.Text = pressTimeAverage_F7.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F7.Text = pressTimeAverage_F7.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F7 > 60 And pressTimeAverage_F7 < 3600 Then
                pressTimeTotal_F7 /= 60
                If pressTimeTotal_F7 = 1 Then
                    ui_averagePressTime_F7.Text = pressTimeTotal_F7.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F7.Text = pressTimeTotal_F7.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F7 > 3600 Or pressTimeAverage_F7 = 3600 Then
                pressTimeTotal_F7 /= 3600
                If pressTimeTotal_F7 = 1 Then
                    ui_averagePressTime_F7.Text = pressTimeTotal_F7.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F7.Text = pressTimeTotal_F7.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F7.Text = ((pressCount_F7 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F8
        If pressCount_F8 > 0 Then 'Used

            ui_Panel_F8.BackColor = usedBackgroundColor
            ui_Label_F8.BackColor = usedBackgroundColor
            ui_Label_F8.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F8.BackColor = usedBackgroundColor
            ui_totalPresses_F8.ForeColor = usedStatFontColor
            ui_totalPressTime_F8.BackColor = usedBackgroundColor
            ui_totalPressTime_F8.ForeColor = usedStatFontColor
            ui_averagePressTime_F8.BackColor = usedBackgroundColor
            ui_averagePressTime_F8.ForeColor = usedStatFontColor
            ui_percent_F8.BackColor = usedBackgroundColor
            ui_percent_F8.ForeColor = usedStatFontColor
            ui_bind_F8.BackColor = usedTextboxBackgroundColor
            ui_bind_F8.ForeColor = usedStatFontColor
            ui_totalPresses_F8.Text = pressCount_F8.ToString

            Dim tempF8time As Decimal = 0

            If pressTimeTotal_F8 < 60 Then
                If pressTimeTotalConverted_F8 = 1 Then
                    ui_totalPressTime_F8.Text = pressTimeTotal_F8.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F8.Text = pressTimeTotal_F8.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F8 > 60 And pressTimeTotal_F8 < 3600 Then
                tempF8time = pressTimeTotal_F8 / 60
                If pressTimeTotal_F8 = 1 Then
                    ui_totalPressTime_F8.Text = tempF8time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F8.Text = tempF8time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F8 > 3600 Or pressTimeTotal_F8 = 3600 Then
                tempF8time = pressTimeTotal_F8 / 3600
                If tempF8time = 1 Then
                    ui_totalPressTime_F8.Text = tempF8time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F8.Text = tempF8time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F8 = pressTimeTotal_F8 / pressCount_F8

            If pressTimeAverage_F8 < 60 Then
                If pressTimeAverage_F8 = 1 Then
                    ui_averagePressTime_F8.Text = pressTimeAverage_F8.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F8.Text = pressTimeAverage_F8.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F8 > 60 And pressTimeAverage_F8 < 3600 Then
                pressTimeTotal_F8 /= 60
                If pressTimeTotal_F8 = 1 Then
                    ui_averagePressTime_F8.Text = pressTimeTotal_F8.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F8.Text = pressTimeTotal_F8.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F8 > 3600 Or pressTimeAverage_F8 = 3600 Then
                pressTimeTotal_F8 /= 3600
                If pressTimeTotal_F8 = 1 Then
                    ui_averagePressTime_F8.Text = pressTimeTotal_F8.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F8.Text = pressTimeTotal_F8.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F8.Text = ((pressCount_F8 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F9
        If pressCount_F9 > 0 Then 'Used

            ui_Panel_F9.BackColor = usedBackgroundColor
            ui_Label_F9.BackColor = usedBackgroundColor
            ui_Label_F9.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F9.BackColor = usedBackgroundColor
            ui_totalPresses_F9.ForeColor = usedStatFontColor
            ui_totalPressTime_F9.BackColor = usedBackgroundColor
            ui_totalPressTime_F9.ForeColor = usedStatFontColor
            ui_averagePressTime_F9.BackColor = usedBackgroundColor
            ui_averagePressTime_F9.ForeColor = usedStatFontColor
            ui_percent_F9.BackColor = usedBackgroundColor
            ui_percent_F9.ForeColor = usedStatFontColor
            ui_bind_F9.BackColor = usedTextboxBackgroundColor
            ui_bind_F9.ForeColor = usedStatFontColor
            ui_totalPresses_F9.Text = pressCount_F9.ToString

            Dim tempF9time As Decimal = 0

            If pressTimeTotal_F9 < 60 Then
                If pressTimeTotalConverted_F9 = 1 Then
                    ui_totalPressTime_F9.Text = pressTimeTotal_F9.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F9.Text = pressTimeTotal_F9.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F9 > 60 And pressTimeTotal_F9 < 3600 Then
                tempF9time = pressTimeTotal_F9 / 60
                If pressTimeTotal_F9 = 1 Then
                    ui_totalPressTime_F9.Text = tempF9time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F9.Text = tempF9time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F9 > 3600 Or pressTimeTotal_F9 = 3600 Then
                tempF9time = pressTimeTotal_F9 / 3600
                If tempF9time = 1 Then
                    ui_totalPressTime_F9.Text = tempF9time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F9.Text = tempF9time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F9 = pressTimeTotal_F9 / pressCount_F9

            If pressTimeAverage_F9 < 60 Then
                If pressTimeAverage_F9 = 1 Then
                    ui_averagePressTime_F9.Text = pressTimeAverage_F9.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F9.Text = pressTimeAverage_F9.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F9 > 60 And pressTimeAverage_F9 < 3600 Then
                pressTimeTotal_F9 /= 60
                If pressTimeTotal_F9 = 1 Then
                    ui_averagePressTime_F9.Text = pressTimeTotal_F9.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F9.Text = pressTimeTotal_F9.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F9 > 3600 Or pressTimeAverage_F9 = 3600 Then
                pressTimeTotal_F9 /= 3600
                If pressTimeTotal_F9 = 1 Then
                    ui_averagePressTime_F9.Text = pressTimeTotal_F9.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F9.Text = pressTimeTotal_F9.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F9.Text = ((pressCount_F9 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F10
        If pressCount_F10 > 0 Then 'Used

            ui_Panel_F10.BackColor = usedBackgroundColor
            ui_Label_F10.BackColor = usedBackgroundColor
            ui_Label_F10.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F10.BackColor = usedBackgroundColor
            ui_totalPresses_F10.ForeColor = usedStatFontColor
            ui_totalPressTime_F10.BackColor = usedBackgroundColor
            ui_totalPressTime_F10.ForeColor = usedStatFontColor
            ui_averagePressTime_F10.BackColor = usedBackgroundColor
            ui_averagePressTime_F10.ForeColor = usedStatFontColor
            ui_percent_F10.BackColor = usedBackgroundColor
            ui_percent_F10.ForeColor = usedStatFontColor
            ui_bind_F10.BackColor = usedTextboxBackgroundColor
            ui_bind_F10.ForeColor = usedStatFontColor
            ui_totalPresses_F10.Text = pressCount_F10.ToString

            Dim tempF10time As Decimal = 0

            If pressTimeTotal_F10 < 60 Then
                If pressTimeTotalConverted_F10 = 1 Then
                    ui_totalPressTime_F10.Text = pressTimeTotal_F10.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F10.Text = pressTimeTotal_F10.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F10 > 60 And pressTimeTotal_F10 < 3600 Then
                tempF10time = pressTimeTotal_F10 / 60
                If pressTimeTotal_F10 = 1 Then
                    ui_totalPressTime_F10.Text = tempF10time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F10.Text = tempF10time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F10 > 3600 Or pressTimeTotal_F10 = 3600 Then
                tempF10time = pressTimeTotal_F10 / 3600
                If tempF10time = 1 Then
                    ui_totalPressTime_F10.Text = tempF10time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F10.Text = tempF10time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F10 = pressTimeTotal_F10 / pressCount_F10

            If pressTimeAverage_F10 < 60 Then
                If pressTimeAverage_F10 = 1 Then
                    ui_averagePressTime_F10.Text = pressTimeAverage_F10.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F10.Text = pressTimeAverage_F10.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F10 > 60 And pressTimeAverage_F10 < 3600 Then
                pressTimeTotal_F10 /= 60
                If pressTimeTotal_F10 = 1 Then
                    ui_averagePressTime_F10.Text = pressTimeTotal_F10.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F10.Text = pressTimeTotal_F10.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F10 > 3600 Or pressTimeAverage_F10 = 3600 Then
                pressTimeTotal_F10 /= 3600
                If pressTimeTotal_F10 = 1 Then
                    ui_averagePressTime_F10.Text = pressTimeTotal_F10.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F10.Text = pressTimeTotal_F10.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F10.Text = ((pressCount_F10 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F11
        If pressCount_F11 > 0 Then 'Used

            ui_Panel_F11.BackColor = usedBackgroundColor
            ui_Label_F11.BackColor = usedBackgroundColor
            ui_Label_F11.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F11.BackColor = usedBackgroundColor
            ui_totalPresses_F11.ForeColor = usedStatFontColor
            ui_totalPressTime_F11.BackColor = usedBackgroundColor
            ui_totalPressTime_F11.ForeColor = usedStatFontColor
            ui_averagePressTime_F11.BackColor = usedBackgroundColor
            ui_averagePressTime_F11.ForeColor = usedStatFontColor
            ui_percent_F11.BackColor = usedBackgroundColor
            ui_percent_F11.ForeColor = usedStatFontColor
            ui_bind_F11.BackColor = usedTextboxBackgroundColor
            ui_bind_F11.ForeColor = usedStatFontColor
            ui_totalPresses_F11.Text = pressCount_F11.ToString

            Dim tempF11time As Decimal = 0

            If pressTimeTotal_F11 < 60 Then
                If pressTimeTotalConverted_F11 = 1 Then
                    ui_totalPressTime_F11.Text = pressTimeTotal_F11.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F11.Text = pressTimeTotal_F11.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F11 > 60 And pressTimeTotal_F11 < 3600 Then
                tempF11time = pressTimeTotal_F11 / 60
                If pressTimeTotal_F11 = 1 Then
                    ui_totalPressTime_F11.Text = tempF11time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F11.Text = tempF11time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F11 > 3600 Or pressTimeTotal_F11 = 3600 Then
                tempF11time = pressTimeTotal_F11 / 3600
                If tempF11time = 1 Then
                    ui_totalPressTime_F11.Text = tempF11time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F11.Text = tempF11time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F11 = pressTimeTotal_F11 / pressCount_F11

            If pressTimeAverage_F11 < 60 Then
                If pressTimeAverage_F11 = 1 Then
                    ui_averagePressTime_F11.Text = pressTimeAverage_F11.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F11.Text = pressTimeAverage_F11.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F11 > 60 And pressTimeAverage_F11 < 3600 Then
                pressTimeTotal_F11 /= 60
                If pressTimeTotal_F11 = 1 Then
                    ui_averagePressTime_F11.Text = pressTimeTotal_F11.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F11.Text = pressTimeTotal_F11.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F11 > 3600 Or pressTimeAverage_F11 = 3600 Then
                pressTimeTotal_F11 /= 3600
                If pressTimeTotal_F11 = 1 Then
                    ui_averagePressTime_F11.Text = pressTimeTotal_F11.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F11.Text = pressTimeTotal_F11.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F11.Text = ((pressCount_F11 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F12
        If pressCount_F12 > 0 Then 'Used

            ui_Panel_F12.BackColor = usedBackgroundColor
            ui_Label_F12.BackColor = usedBackgroundColor
            ui_Label_F12.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F12.BackColor = usedBackgroundColor
            ui_totalPresses_F12.ForeColor = usedStatFontColor
            ui_totalPressTime_F12.BackColor = usedBackgroundColor
            ui_totalPressTime_F12.ForeColor = usedStatFontColor
            ui_averagePressTime_F12.BackColor = usedBackgroundColor
            ui_averagePressTime_F12.ForeColor = usedStatFontColor
            ui_percent_F12.BackColor = usedBackgroundColor
            ui_percent_F12.ForeColor = usedStatFontColor
            ui_bind_F12.BackColor = usedTextboxBackgroundColor
            ui_bind_F12.ForeColor = usedStatFontColor
            ui_totalPresses_F12.Text = pressCount_F12.ToString

            Dim tempF12time As Decimal = 0

            If pressTimeTotal_F12 < 60 Then
                If pressTimeTotalConverted_F12 = 1 Then
                    ui_totalPressTime_F12.Text = pressTimeTotal_F12.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F12.Text = pressTimeTotal_F12.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F12 > 60 And pressTimeTotal_F12 < 3600 Then
                tempF12time = pressTimeTotal_F12 / 60
                If pressTimeTotal_F12 = 1 Then
                    ui_totalPressTime_F12.Text = tempF12time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F12.Text = tempF12time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F12 > 3600 Or pressTimeTotal_F12 = 3600 Then
                tempF12time = pressTimeTotal_F12 / 3600
                If tempF12time = 1 Then
                    ui_totalPressTime_F12.Text = tempF12time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F12.Text = tempF12time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F12 = pressTimeTotal_F12 / pressCount_F12

            If pressTimeAverage_F12 < 60 Then
                If pressTimeAverage_F12 = 1 Then
                    ui_averagePressTime_F12.Text = pressTimeAverage_F12.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F12.Text = pressTimeAverage_F12.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F12 > 60 And pressTimeAverage_F12 < 3600 Then
                pressTimeTotal_F12 /= 60
                If pressTimeTotal_F12 = 1 Then
                    ui_averagePressTime_F12.Text = pressTimeTotal_F12.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F12.Text = pressTimeTotal_F12.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F12 > 3600 Or pressTimeAverage_F12 = 3600 Then
                pressTimeTotal_F12 /= 3600
                If pressTimeTotal_F12 = 1 Then
                    ui_averagePressTime_F12.Text = pressTimeTotal_F12.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F12.Text = pressTimeTotal_F12.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F12.Text = ((pressCount_F12 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'PRNT
        If pressCount_PRNT > 0 Then 'Used

            ui_Panel_PRNT.BackColor = usedBackgroundColor
            ui_Label_PRNT.BackColor = usedBackgroundColor
            ui_Label_PRNT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_PRNT.BackColor = usedBackgroundColor
            ui_totalPresses_PRNT.ForeColor = usedStatFontColor
            ui_totalPressTime_PRNT.BackColor = usedBackgroundColor
            ui_totalPressTime_PRNT.ForeColor = usedStatFontColor
            ui_averagePressTime_PRNT.BackColor = usedBackgroundColor
            ui_averagePressTime_PRNT.ForeColor = usedStatFontColor
            ui_percent_PRNT.BackColor = usedBackgroundColor
            ui_percent_PRNT.ForeColor = usedStatFontColor
            ui_bind_PRNT.BackColor = usedTextboxBackgroundColor
            ui_bind_PRNT.ForeColor = usedStatFontColor
            ui_totalPresses_PRNT.Text = pressCount_PRNT.ToString

            Dim tempPRNTtime As Decimal = 0

            If pressTimeTotal_PRNT < 60 Then
                If pressTimeTotalConverted_PRNT = 1 Then
                    ui_totalPressTime_PRNT.Text = pressTimeTotal_PRNT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_PRNT.Text = pressTimeTotal_PRNT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_PRNT > 60 And pressTimeTotal_PRNT < 3600 Then
                tempPRNTtime = pressTimeTotal_PRNT / 60
                If pressTimeTotal_PRNT = 1 Then
                    ui_totalPressTime_PRNT.Text = tempPRNTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_PRNT.Text = tempPRNTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_PRNT > 3600 Or pressTimeTotal_PRNT = 3600 Then
                tempPRNTtime = pressTimeTotal_PRNT / 3600
                If tempPRNTtime = 1 Then
                    ui_totalPressTime_PRNT.Text = tempPRNTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_PRNT.Text = tempPRNTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_PRNT = pressTimeTotal_PRNT / pressCount_PRNT

            If pressTimeAverage_PRNT < 60 Then
                If pressTimeAverage_PRNT = 1 Then
                    ui_averagePressTime_PRNT.Text = pressTimeAverage_PRNT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_PRNT.Text = pressTimeAverage_PRNT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_PRNT > 60 And pressTimeAverage_PRNT < 3600 Then
                pressTimeTotal_PRNT /= 60
                If pressTimeTotal_PRNT = 1 Then
                    ui_averagePressTime_PRNT.Text = pressTimeTotal_PRNT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_PRNT.Text = pressTimeTotal_PRNT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_PRNT > 3600 Or pressTimeAverage_PRNT = 3600 Then
                pressTimeTotal_PRNT /= 3600
                If pressTimeTotal_PRNT = 1 Then
                    ui_averagePressTime_PRNT.Text = pressTimeTotal_PRNT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_PRNT.Text = pressTimeTotal_PRNT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_PRNT.Text = ((pressCount_PRNT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'SCRLOCK
        If pressCount_SCRLOCK > 0 Then 'Used

            ui_Panel_SCRLOCK.BackColor = usedBackgroundColor
            ui_Label_SCRLOCK.BackColor = usedBackgroundColor
            ui_Label_SCRLOCK.ForeColor = usedKeyNameFontColor
            ui_totalPresses_SCRLOCK.BackColor = usedBackgroundColor
            ui_totalPresses_SCRLOCK.ForeColor = usedStatFontColor
            ui_totalPressTime_SCRLOCK.BackColor = usedBackgroundColor
            ui_totalPressTime_SCRLOCK.ForeColor = usedStatFontColor
            ui_averagePressTime_SCRLOCK.BackColor = usedBackgroundColor
            ui_averagePressTime_SCRLOCK.ForeColor = usedStatFontColor
            ui_percent_SCRLOCK.BackColor = usedBackgroundColor
            ui_percent_SCRLOCK.ForeColor = usedStatFontColor
            ui_bind_SCRLOCK.BackColor = usedTextboxBackgroundColor
            ui_bind_SCRLOCK.ForeColor = usedStatFontColor
            ui_totalPresses_SCRLOCK.Text = pressCount_SCRLOCK.ToString

            Dim tempSCRLOCKtime As Decimal = 0

            If pressTimeTotal_SCRLOCK < 60 Then
                If pressTimeTotalConverted_SCRLOCK = 1 Then
                    ui_totalPressTime_SCRLOCK.Text = pressTimeTotal_SCRLOCK.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_SCRLOCK.Text = pressTimeTotal_SCRLOCK.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_SCRLOCK > 60 And pressTimeTotal_SCRLOCK < 3600 Then
                tempSCRLOCKtime = pressTimeTotal_SCRLOCK / 60
                If pressTimeTotal_SCRLOCK = 1 Then
                    ui_totalPressTime_SCRLOCK.Text = tempSCRLOCKtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_SCRLOCK.Text = tempSCRLOCKtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_SCRLOCK > 3600 Or pressTimeTotal_SCRLOCK = 3600 Then
                tempSCRLOCKtime = pressTimeTotal_SCRLOCK / 3600
                If tempSCRLOCKtime = 1 Then
                    ui_totalPressTime_SCRLOCK.Text = tempSCRLOCKtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_SCRLOCK.Text = tempSCRLOCKtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_SCRLOCK = pressTimeTotal_SCRLOCK / pressCount_SCRLOCK

            If pressTimeAverage_SCRLOCK < 60 Then
                If pressTimeAverage_SCRLOCK = 1 Then
                    ui_averagePressTime_SCRLOCK.Text = pressTimeAverage_SCRLOCK.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_SCRLOCK.Text = pressTimeAverage_SCRLOCK.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_SCRLOCK > 60 And pressTimeAverage_SCRLOCK < 3600 Then
                pressTimeTotal_SCRLOCK /= 60
                If pressTimeTotal_SCRLOCK = 1 Then
                    ui_averagePressTime_SCRLOCK.Text = pressTimeTotal_SCRLOCK.ToString("N3") & " min"
                Else
                    ui_averagePressTime_SCRLOCK.Text = pressTimeTotal_SCRLOCK.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_SCRLOCK > 3600 Or pressTimeAverage_SCRLOCK = 3600 Then
                pressTimeTotal_SCRLOCK /= 3600
                If pressTimeTotal_SCRLOCK = 1 Then
                    ui_averagePressTime_SCRLOCK.Text = pressTimeTotal_SCRLOCK.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_SCRLOCK.Text = pressTimeTotal_SCRLOCK.ToString("N3") & " hours"
                End If
            End If

            ui_percent_SCRLOCK.Text = ((pressCount_SCRLOCK / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'PAUSE
        If pressCount_PAUSE > 0 Then 'Used

            ui_Panel_PAUSE.BackColor = usedBackgroundColor
            ui_Label_PAUSE.BackColor = usedBackgroundColor
            ui_Label_PAUSE.ForeColor = usedKeyNameFontColor
            ui_totalPresses_PAUSE.BackColor = usedBackgroundColor
            ui_totalPresses_PAUSE.ForeColor = usedStatFontColor
            ui_totalPressTime_PAUSE.BackColor = usedBackgroundColor
            ui_totalPressTime_PAUSE.ForeColor = usedStatFontColor
            ui_averagePressTime_PAUSE.BackColor = usedBackgroundColor
            ui_averagePressTime_PAUSE.ForeColor = usedStatFontColor
            ui_percent_PAUSE.BackColor = usedBackgroundColor
            ui_percent_PAUSE.ForeColor = usedStatFontColor
            ui_bind_PAUSE.BackColor = usedTextboxBackgroundColor
            ui_bind_PAUSE.ForeColor = usedStatFontColor
            ui_totalPresses_PAUSE.Text = pressCount_PAUSE.ToString

            Dim tempPAUSEtime As Decimal = 0

            If pressTimeTotal_PAUSE < 60 Then
                If pressTimeTotalConverted_PAUSE = 1 Then
                    ui_totalPressTime_PAUSE.Text = pressTimeTotal_PAUSE.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_PAUSE.Text = pressTimeTotal_PAUSE.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_PAUSE > 60 And pressTimeTotal_PAUSE < 3600 Then
                tempPAUSEtime = pressTimeTotal_PAUSE / 60
                If pressTimeTotal_PAUSE = 1 Then
                    ui_totalPressTime_PAUSE.Text = tempPAUSEtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_PAUSE.Text = tempPAUSEtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_PAUSE > 3600 Or pressTimeTotal_PAUSE = 3600 Then
                tempPAUSEtime = pressTimeTotal_PAUSE / 3600
                If tempPAUSEtime = 1 Then
                    ui_totalPressTime_PAUSE.Text = tempPAUSEtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_PAUSE.Text = tempPAUSEtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_PAUSE = pressTimeTotal_PAUSE / pressCount_PAUSE

            If pressTimeAverage_PAUSE < 60 Then
                If pressTimeAverage_PAUSE = 1 Then
                    ui_averagePressTime_PAUSE.Text = pressTimeAverage_PAUSE.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_PAUSE.Text = pressTimeAverage_PAUSE.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_PAUSE > 60 And pressTimeAverage_PAUSE < 3600 Then
                pressTimeTotal_PAUSE /= 60
                If pressTimeTotal_PAUSE = 1 Then
                    ui_averagePressTime_PAUSE.Text = pressTimeTotal_PAUSE.ToString("N3") & " min"
                Else
                    ui_averagePressTime_PAUSE.Text = pressTimeTotal_PAUSE.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_PAUSE > 3600 Or pressTimeAverage_PAUSE = 3600 Then
                pressTimeTotal_PAUSE /= 3600
                If pressTimeTotal_PAUSE = 1 Then
                    ui_averagePressTime_PAUSE.Text = pressTimeTotal_PAUSE.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_PAUSE.Text = pressTimeTotal_PAUSE.ToString("N3") & " hours"
                End If
            End If

            ui_percent_PAUSE.Text = ((pressCount_PAUSE / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'PLAY
        If pressCount_PLAY > 0 Then 'Used

            ui_Panel_PLAY.BackColor = usedBackgroundColor
            ui_Label_PLAY.BackColor = usedBackgroundColor
            ui_Label_PLAY.ForeColor = usedKeyNameFontColor
            ui_totalPresses_PLAY.BackColor = usedBackgroundColor
            ui_totalPresses_PLAY.ForeColor = usedStatFontColor
            ui_totalPressTime_PLAY.BackColor = usedBackgroundColor
            ui_totalPressTime_PLAY.ForeColor = usedStatFontColor
            ui_averagePressTime_PLAY.BackColor = usedBackgroundColor
            ui_averagePressTime_PLAY.ForeColor = usedStatFontColor
            ui_percent_PLAY.BackColor = usedBackgroundColor
            ui_percent_PLAY.ForeColor = usedStatFontColor
            ui_bind_PLAY.BackColor = usedTextboxBackgroundColor
            ui_bind_PLAY.ForeColor = usedStatFontColor
            ui_totalPresses_PLAY.Text = pressCount_PLAY.ToString

            Dim tempPLAYtime As Decimal = 0

            If pressTimeTotal_PLAY < 60 Then
                If pressTimeTotalConverted_PLAY = 1 Then
                    ui_totalPressTime_PLAY.Text = pressTimeTotal_PLAY.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_PLAY.Text = pressTimeTotal_PLAY.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_PLAY > 60 And pressTimeTotal_PLAY < 3600 Then
                tempPLAYtime = pressTimeTotal_PLAY / 60
                If pressTimeTotal_PLAY = 1 Then
                    ui_totalPressTime_PLAY.Text = tempPLAYtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_PLAY.Text = tempPLAYtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_PLAY > 3600 Or pressTimeTotal_PLAY = 3600 Then
                tempPLAYtime = pressTimeTotal_PLAY / 3600
                If tempPLAYtime = 1 Then
                    ui_totalPressTime_PLAY.Text = tempPLAYtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_PLAY.Text = tempPLAYtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_PLAY = pressTimeTotal_PLAY / pressCount_PLAY

            If pressTimeAverage_PLAY < 60 Then
                If pressTimeAverage_PLAY = 1 Then
                    ui_averagePressTime_PLAY.Text = pressTimeAverage_PLAY.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_PLAY.Text = pressTimeAverage_PLAY.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_PLAY > 60 And pressTimeAverage_PLAY < 3600 Then
                pressTimeTotal_PLAY /= 60
                If pressTimeTotal_PLAY = 1 Then
                    ui_averagePressTime_PLAY.Text = pressTimeTotal_PLAY.ToString("N3") & " min"
                Else
                    ui_averagePressTime_PLAY.Text = pressTimeTotal_PLAY.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_PLAY > 3600 Or pressTimeAverage_PLAY = 3600 Then
                pressTimeTotal_PLAY /= 3600
                If pressTimeTotal_PLAY = 1 Then
                    ui_averagePressTime_PLAY.Text = pressTimeTotal_PLAY.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_PLAY.Text = pressTimeTotal_PLAY.ToString("N3") & " hours"
                End If
            End If

            ui_percent_PLAY.Text = ((pressCount_PLAY / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'STOP
        If pressCount_STOP > 0 Then 'Used

            ui_Panel_STOP.BackColor = usedBackgroundColor
            ui_Label_STOP.BackColor = usedBackgroundColor
            ui_Label_STOP.ForeColor = usedKeyNameFontColor
            ui_totalPresses_STOP.BackColor = usedBackgroundColor
            ui_totalPresses_STOP.ForeColor = usedStatFontColor
            ui_totalPressTime_STOP.BackColor = usedBackgroundColor
            ui_totalPressTime_STOP.ForeColor = usedStatFontColor
            ui_averagePressTime_STOP.BackColor = usedBackgroundColor
            ui_averagePressTime_STOP.ForeColor = usedStatFontColor
            ui_percent_STOP.BackColor = usedBackgroundColor
            ui_percent_STOP.ForeColor = usedStatFontColor
            ui_bind_STOP.BackColor = usedTextboxBackgroundColor
            ui_bind_STOP.ForeColor = usedStatFontColor
            ui_totalPresses_STOP.Text = pressCount_STOP.ToString

            Dim tempSTOPtime As Decimal = 0

            If pressTimeTotal_STOP < 60 Then
                If pressTimeTotalConverted_STOP = 1 Then
                    ui_totalPressTime_STOP.Text = pressTimeTotal_STOP.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_STOP.Text = pressTimeTotal_STOP.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_STOP > 60 And pressTimeTotal_STOP < 3600 Then
                tempSTOPtime = pressTimeTotal_STOP / 60
                If pressTimeTotal_STOP = 1 Then
                    ui_totalPressTime_STOP.Text = tempSTOPtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_STOP.Text = tempSTOPtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_STOP > 3600 Or pressTimeTotal_STOP = 3600 Then
                tempSTOPtime = pressTimeTotal_STOP / 3600
                If tempSTOPtime = 1 Then
                    ui_totalPressTime_STOP.Text = tempSTOPtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_STOP.Text = tempSTOPtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_STOP = pressTimeTotal_STOP / pressCount_STOP

            If pressTimeAverage_STOP < 60 Then
                If pressTimeAverage_STOP = 1 Then
                    ui_averagePressTime_STOP.Text = pressTimeAverage_STOP.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_STOP.Text = pressTimeAverage_STOP.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_STOP > 60 And pressTimeAverage_STOP < 3600 Then
                pressTimeTotal_STOP /= 60
                If pressTimeTotal_STOP = 1 Then
                    ui_averagePressTime_STOP.Text = pressTimeTotal_STOP.ToString("N3") & " min"
                Else
                    ui_averagePressTime_STOP.Text = pressTimeTotal_STOP.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_STOP > 3600 Or pressTimeAverage_STOP = 3600 Then
                pressTimeTotal_STOP /= 3600
                If pressTimeTotal_STOP = 1 Then
                    ui_averagePressTime_STOP.Text = pressTimeTotal_STOP.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_STOP.Text = pressTimeTotal_STOP.ToString("N3") & " hours"
                End If
            End If

            ui_percent_STOP.Text = ((pressCount_STOP / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'PREV
        If pressCount_PREV > 0 Then 'Used

            ui_Panel_PREV.BackColor = usedBackgroundColor
            ui_Label_PREV.BackColor = usedBackgroundColor
            ui_Label_PREV.ForeColor = usedKeyNameFontColor
            ui_totalPresses_PREV.BackColor = usedBackgroundColor
            ui_totalPresses_PREV.ForeColor = usedStatFontColor
            ui_totalPressTime_PREV.BackColor = usedBackgroundColor
            ui_totalPressTime_PREV.ForeColor = usedStatFontColor
            ui_averagePressTime_PREV.BackColor = usedBackgroundColor
            ui_averagePressTime_PREV.ForeColor = usedStatFontColor
            ui_percent_PREV.BackColor = usedBackgroundColor
            ui_percent_PREV.ForeColor = usedStatFontColor
            ui_bind_PREV.BackColor = usedTextboxBackgroundColor
            ui_bind_PREV.ForeColor = usedStatFontColor
            ui_totalPresses_PREV.Text = pressCount_PREV.ToString

            Dim tempPREVtime As Decimal = 0

            If pressTimeTotal_PREV < 60 Then
                If pressTimeTotalConverted_PREV = 1 Then
                    ui_totalPressTime_PREV.Text = pressTimeTotal_PREV.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_PREV.Text = pressTimeTotal_PREV.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_PREV > 60 And pressTimeTotal_PREV < 3600 Then
                tempPREVtime = pressTimeTotal_PREV / 60
                If pressTimeTotal_PREV = 1 Then
                    ui_totalPressTime_PREV.Text = tempPREVtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_PREV.Text = tempPREVtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_PREV > 3600 Or pressTimeTotal_PREV = 3600 Then
                tempPREVtime = pressTimeTotal_PREV / 3600
                If tempPREVtime = 1 Then
                    ui_totalPressTime_PREV.Text = tempPREVtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_PREV.Text = tempPREVtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_PREV = pressTimeTotal_PREV / pressCount_PREV

            If pressTimeAverage_PREV < 60 Then
                If pressTimeAverage_PREV = 1 Then
                    ui_averagePressTime_PREV.Text = pressTimeAverage_PREV.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_PREV.Text = pressTimeAverage_PREV.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_PREV > 60 And pressTimeAverage_PREV < 3600 Then
                pressTimeTotal_PREV /= 60
                If pressTimeTotal_PREV = 1 Then
                    ui_averagePressTime_PREV.Text = pressTimeTotal_PREV.ToString("N3") & " min"
                Else
                    ui_averagePressTime_PREV.Text = pressTimeTotal_PREV.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_PREV > 3600 Or pressTimeAverage_PREV = 3600 Then
                pressTimeTotal_PREV /= 3600
                If pressTimeTotal_PREV = 1 Then
                    ui_averagePressTime_PREV.Text = pressTimeTotal_PREV.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_PREV.Text = pressTimeTotal_PREV.ToString("N3") & " hours"
                End If
            End If

            ui_percent_PREV.Text = ((pressCount_PREV / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'NEXT
        If pressCount_NEXT > 0 Then 'Used

            ui_Panel_NEXT.BackColor = usedBackgroundColor
            ui_Label_NEXT.BackColor = usedBackgroundColor
            ui_Label_NEXT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_NEXT.BackColor = usedBackgroundColor
            ui_totalPresses_NEXT.ForeColor = usedStatFontColor
            ui_totalPressTime_NEXT.BackColor = usedBackgroundColor
            ui_totalPressTime_NEXT.ForeColor = usedStatFontColor
            ui_averagePressTime_NEXT.BackColor = usedBackgroundColor
            ui_averagePressTime_NEXT.ForeColor = usedStatFontColor
            ui_percent_NEXT.BackColor = usedBackgroundColor
            ui_percent_NEXT.ForeColor = usedStatFontColor
            ui_bind_NEXT.BackColor = usedTextboxBackgroundColor
            ui_bind_NEXT.ForeColor = usedStatFontColor
            ui_totalPresses_NEXT.Text = pressCount_NEXT.ToString

            Dim tempNEXTtime As Decimal = 0

            If pressTimeTotal_NEXT < 60 Then
                If pressTimeTotalConverted_NEXT = 1 Then
                    ui_totalPressTime_NEXT.Text = pressTimeTotal_NEXT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_NEXT.Text = pressTimeTotal_NEXT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_NEXT > 60 And pressTimeTotal_NEXT < 3600 Then
                tempNEXTtime = pressTimeTotal_NEXT / 60
                If pressTimeTotal_NEXT = 1 Then
                    ui_totalPressTime_NEXT.Text = tempNEXTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_NEXT.Text = tempNEXTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_NEXT > 3600 Or pressTimeTotal_NEXT = 3600 Then
                tempNEXTtime = pressTimeTotal_NEXT / 3600
                If tempNEXTtime = 1 Then
                    ui_totalPressTime_NEXT.Text = tempNEXTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_NEXT.Text = tempNEXTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_NEXT = pressTimeTotal_NEXT / pressCount_NEXT

            If pressTimeAverage_NEXT < 60 Then
                If pressTimeAverage_NEXT = 1 Then
                    ui_averagePressTime_NEXT.Text = pressTimeAverage_NEXT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_NEXT.Text = pressTimeAverage_NEXT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_NEXT > 60 And pressTimeAverage_NEXT < 3600 Then
                pressTimeTotal_NEXT /= 60
                If pressTimeTotal_NEXT = 1 Then
                    ui_averagePressTime_NEXT.Text = pressTimeTotal_NEXT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_NEXT.Text = pressTimeTotal_NEXT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_NEXT > 3600 Or pressTimeAverage_NEXT = 3600 Then
                pressTimeTotal_NEXT /= 3600
                If pressTimeTotal_NEXT = 1 Then
                    ui_averagePressTime_NEXT.Text = pressTimeTotal_NEXT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_NEXT.Text = pressTimeTotal_NEXT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_NEXT.Text = ((pressCount_NEXT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'TILDE
        If pressCount_TILDE > 0 Then 'Used

            ui_Panel_TILDE.BackColor = usedBackgroundColor
            ui_Label_TILDE.BackColor = usedBackgroundColor
            ui_Label_TILDE.ForeColor = usedKeyNameFontColor
            ui_totalPresses_TILDE.BackColor = usedBackgroundColor
            ui_totalPresses_TILDE.ForeColor = usedStatFontColor
            ui_totalPressTime_TILDE.BackColor = usedBackgroundColor
            ui_totalPressTime_TILDE.ForeColor = usedStatFontColor
            ui_averagePressTime_TILDE.BackColor = usedBackgroundColor
            ui_averagePressTime_TILDE.ForeColor = usedStatFontColor
            ui_percent_TILDE.BackColor = usedBackgroundColor
            ui_percent_TILDE.ForeColor = usedStatFontColor
            ui_bind_TILDE.BackColor = usedTextboxBackgroundColor
            ui_bind_TILDE.ForeColor = usedStatFontColor
            ui_totalPresses_TILDE.Text = pressCount_TILDE.ToString

            Dim tempTILDEtime As Decimal = 0

            If pressTimeTotal_TILDE < 60 Then
                If pressTimeTotalConverted_TILDE = 1 Then
                    ui_totalPressTime_TILDE.Text = pressTimeTotal_TILDE.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_TILDE.Text = pressTimeTotal_TILDE.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_TILDE > 60 And pressTimeTotal_TILDE < 3600 Then
                tempTILDEtime = pressTimeTotal_TILDE / 60
                If pressTimeTotal_TILDE = 1 Then
                    ui_totalPressTime_TILDE.Text = tempTILDEtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_TILDE.Text = tempTILDEtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_TILDE > 3600 Or pressTimeTotal_TILDE = 3600 Then
                tempTILDEtime = pressTimeTotal_TILDE / 3600
                If tempTILDEtime = 1 Then
                    ui_totalPressTime_TILDE.Text = tempTILDEtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_TILDE.Text = tempTILDEtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_TILDE = pressTimeTotal_TILDE / pressCount_TILDE

            If pressTimeAverage_TILDE < 60 Then
                If pressTimeAverage_TILDE = 1 Then
                    ui_averagePressTime_TILDE.Text = pressTimeAverage_TILDE.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_TILDE.Text = pressTimeAverage_TILDE.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_TILDE > 60 And pressTimeAverage_TILDE < 3600 Then
                pressTimeTotal_TILDE /= 60
                If pressTimeTotal_TILDE = 1 Then
                    ui_averagePressTime_TILDE.Text = pressTimeTotal_TILDE.ToString("N3") & " min"
                Else
                    ui_averagePressTime_TILDE.Text = pressTimeTotal_TILDE.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_TILDE > 3600 Or pressTimeAverage_TILDE = 3600 Then
                pressTimeTotal_TILDE /= 3600
                If pressTimeTotal_TILDE = 1 Then
                    ui_averagePressTime_TILDE.Text = pressTimeTotal_TILDE.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_TILDE.Text = pressTimeTotal_TILDE.ToString("N3") & " hours"
                End If
            End If

            ui_percent_TILDE.Text = ((pressCount_TILDE / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '1
        If pressCount_1 > 0 Then 'Used

            ui_Panel_1.BackColor = usedBackgroundColor
            ui_Label_1.BackColor = usedBackgroundColor
            ui_Label_1.ForeColor = usedKeyNameFontColor
            ui_totalPresses_1.BackColor = usedBackgroundColor
            ui_totalPresses_1.ForeColor = usedStatFontColor
            ui_totalPressTime_1.BackColor = usedBackgroundColor
            ui_totalPressTime_1.ForeColor = usedStatFontColor
            ui_averagePressTime_1.BackColor = usedBackgroundColor
            ui_averagePressTime_1.ForeColor = usedStatFontColor
            ui_percent_1.BackColor = usedBackgroundColor
            ui_percent_1.ForeColor = usedStatFontColor
            ui_bind_1.BackColor = usedTextboxBackgroundColor
            ui_bind_1.ForeColor = usedStatFontColor
            ui_totalPresses_1.Text = pressCount_1.ToString

            Dim temp1time As Decimal = 0

            If pressTimeTotal_1 < 60 Then
                If pressTimeTotalConverted_1 = 1 Then
                    ui_totalPressTime_1.Text = pressTimeTotal_1.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_1.Text = pressTimeTotal_1.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_1 > 60 And pressTimeTotal_1 < 3600 Then
                temp1time = pressTimeTotal_1 / 60
                If pressTimeTotal_1 = 1 Then
                    ui_totalPressTime_1.Text = temp1time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_1.Text = temp1time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_1 > 3600 Or pressTimeTotal_1 = 3600 Then
                temp1time = pressTimeTotal_1 / 3600
                If temp1time = 1 Then
                    ui_totalPressTime_1.Text = temp1time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_1.Text = temp1time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_1 = pressTimeTotal_1 / pressCount_1

            If pressTimeAverage_1 < 60 Then
                If pressTimeAverage_1 = 1 Then
                    ui_averagePressTime_1.Text = pressTimeAverage_1.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_1.Text = pressTimeAverage_1.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_1 > 60 And pressTimeAverage_1 < 3600 Then
                pressTimeTotal_1 /= 60
                If pressTimeTotal_1 = 1 Then
                    ui_averagePressTime_1.Text = pressTimeTotal_1.ToString("N3") & " min"
                Else
                    ui_averagePressTime_1.Text = pressTimeTotal_1.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_1 > 3600 Or pressTimeAverage_1 = 3600 Then
                pressTimeTotal_1 /= 3600
                If pressTimeTotal_1 = 1 Then
                    ui_averagePressTime_1.Text = pressTimeTotal_1.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_1.Text = pressTimeTotal_1.ToString("N3") & " hours"
                End If
            End If

            ui_percent_1.Text = ((pressCount_1 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '2
        If pressCount_2 > 0 Then 'Used

            ui_Panel_2.BackColor = usedBackgroundColor
            ui_Label_2.BackColor = usedBackgroundColor
            ui_Label_2.ForeColor = usedKeyNameFontColor
            ui_totalPresses_2.BackColor = usedBackgroundColor
            ui_totalPresses_2.ForeColor = usedStatFontColor
            ui_totalPressTime_2.BackColor = usedBackgroundColor
            ui_totalPressTime_2.ForeColor = usedStatFontColor
            ui_averagePressTime_2.BackColor = usedBackgroundColor
            ui_averagePressTime_2.ForeColor = usedStatFontColor
            ui_percent_2.BackColor = usedBackgroundColor
            ui_percent_2.ForeColor = usedStatFontColor
            ui_bind_2.BackColor = usedTextboxBackgroundColor
            ui_bind_2.ForeColor = usedStatFontColor
            ui_totalPresses_2.Text = pressCount_2.ToString

            Dim temp2time As Decimal = 0

            If pressTimeTotal_2 < 60 Then
                If pressTimeTotalConverted_2 = 1 Then
                    ui_totalPressTime_2.Text = pressTimeTotal_2.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_2.Text = pressTimeTotal_2.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_2 > 60 And pressTimeTotal_2 < 3600 Then
                temp2time = pressTimeTotal_2 / 60
                If pressTimeTotal_2 = 1 Then
                    ui_totalPressTime_2.Text = temp2time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_2.Text = temp2time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_2 > 3600 Or pressTimeTotal_2 = 3600 Then
                temp2time = pressTimeTotal_2 / 3600
                If temp2time = 1 Then
                    ui_totalPressTime_2.Text = temp2time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_2.Text = temp2time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_2 = pressTimeTotal_2 / pressCount_2

            If pressTimeAverage_2 < 60 Then
                If pressTimeAverage_2 = 1 Then
                    ui_averagePressTime_2.Text = pressTimeAverage_2.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_2.Text = pressTimeAverage_2.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_2 > 60 And pressTimeAverage_2 < 3600 Then
                pressTimeTotal_2 /= 60
                If pressTimeTotal_2 = 1 Then
                    ui_averagePressTime_2.Text = pressTimeTotal_2.ToString("N3") & " min"
                Else
                    ui_averagePressTime_2.Text = pressTimeTotal_2.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_2 > 3600 Or pressTimeAverage_2 = 3600 Then
                pressTimeTotal_2 /= 3600
                If pressTimeTotal_2 = 1 Then
                    ui_averagePressTime_2.Text = pressTimeTotal_2.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_2.Text = pressTimeTotal_2.ToString("N3") & " hours"
                End If
            End If

            ui_percent_2.Text = ((pressCount_2 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '3
        If pressCount_3 > 0 Then 'Used

            ui_Panel_3.BackColor = usedBackgroundColor
            ui_Label_3.BackColor = usedBackgroundColor
            ui_Label_3.ForeColor = usedKeyNameFontColor
            ui_totalPresses_3.BackColor = usedBackgroundColor
            ui_totalPresses_3.ForeColor = usedStatFontColor
            ui_totalPressTime_3.BackColor = usedBackgroundColor
            ui_totalPressTime_3.ForeColor = usedStatFontColor
            ui_averagePressTime_3.BackColor = usedBackgroundColor
            ui_averagePressTime_3.ForeColor = usedStatFontColor
            ui_percent_3.BackColor = usedBackgroundColor
            ui_percent_3.ForeColor = usedStatFontColor
            ui_bind_3.BackColor = usedTextboxBackgroundColor
            ui_bind_3.ForeColor = usedStatFontColor
            ui_totalPresses_3.Text = pressCount_3.ToString

            Dim temp3time As Decimal = 0

            If pressTimeTotal_3 < 60 Then
                If pressTimeTotalConverted_3 = 1 Then
                    ui_totalPressTime_3.Text = pressTimeTotal_3.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_3.Text = pressTimeTotal_3.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_3 > 60 And pressTimeTotal_3 < 3600 Then
                temp3time = pressTimeTotal_3 / 60
                If pressTimeTotal_3 = 1 Then
                    ui_totalPressTime_3.Text = temp3time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_3.Text = temp3time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_3 > 3600 Or pressTimeTotal_3 = 3600 Then
                temp3time = pressTimeTotal_3 / 3600
                If temp3time = 1 Then
                    ui_totalPressTime_3.Text = temp3time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_3.Text = temp3time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_3 = pressTimeTotal_3 / pressCount_3

            If pressTimeAverage_3 < 60 Then
                If pressTimeAverage_3 = 1 Then
                    ui_averagePressTime_3.Text = pressTimeAverage_3.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_3.Text = pressTimeAverage_3.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_3 > 60 And pressTimeAverage_3 < 3600 Then
                pressTimeTotal_3 /= 60
                If pressTimeTotal_3 = 1 Then
                    ui_averagePressTime_3.Text = pressTimeTotal_3.ToString("N3") & " min"
                Else
                    ui_averagePressTime_3.Text = pressTimeTotal_3.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_3 > 3600 Or pressTimeAverage_3 = 3600 Then
                pressTimeTotal_3 /= 3600
                If pressTimeTotal_3 = 1 Then
                    ui_averagePressTime_3.Text = pressTimeTotal_3.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_3.Text = pressTimeTotal_3.ToString("N3") & " hours"
                End If
            End If

            ui_percent_3.Text = ((pressCount_3 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '4
        If pressCount_4 > 0 Then 'Used

            ui_Panel_4.BackColor = usedBackgroundColor
            ui_Label_4.BackColor = usedBackgroundColor
            ui_Label_4.ForeColor = usedKeyNameFontColor
            ui_totalPresses_4.BackColor = usedBackgroundColor
            ui_totalPresses_4.ForeColor = usedStatFontColor
            ui_totalPressTime_4.BackColor = usedBackgroundColor
            ui_totalPressTime_4.ForeColor = usedStatFontColor
            ui_averagePressTime_4.BackColor = usedBackgroundColor
            ui_averagePressTime_4.ForeColor = usedStatFontColor
            ui_percent_4.BackColor = usedBackgroundColor
            ui_percent_4.ForeColor = usedStatFontColor
            ui_bind_4.BackColor = usedTextboxBackgroundColor
            ui_bind_4.ForeColor = usedStatFontColor
            ui_totalPresses_4.Text = pressCount_4.ToString

            Dim temp4time As Decimal = 0

            If pressTimeTotal_4 < 60 Then
                If pressTimeTotalConverted_4 = 1 Then
                    ui_totalPressTime_4.Text = pressTimeTotal_4.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_4.Text = pressTimeTotal_4.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_4 > 60 And pressTimeTotal_4 < 3600 Then
                temp4time = pressTimeTotal_4 / 60
                If pressTimeTotal_4 = 1 Then
                    ui_totalPressTime_4.Text = temp4time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_4.Text = temp4time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_4 > 3600 Or pressTimeTotal_4 = 3600 Then
                temp4time = pressTimeTotal_4 / 3600
                If temp4time = 1 Then
                    ui_totalPressTime_4.Text = temp4time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_4.Text = temp4time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_4 = pressTimeTotal_4 / pressCount_4

            If pressTimeAverage_4 < 60 Then
                If pressTimeAverage_4 = 1 Then
                    ui_averagePressTime_4.Text = pressTimeAverage_4.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_4.Text = pressTimeAverage_4.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_4 > 60 And pressTimeAverage_4 < 3600 Then
                pressTimeTotal_4 /= 60
                If pressTimeTotal_4 = 1 Then
                    ui_averagePressTime_4.Text = pressTimeTotal_4.ToString("N3") & " min"
                Else
                    ui_averagePressTime_4.Text = pressTimeTotal_4.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_4 > 3600 Or pressTimeAverage_4 = 3600 Then
                pressTimeTotal_4 /= 3600
                If pressTimeTotal_4 = 1 Then
                    ui_averagePressTime_4.Text = pressTimeTotal_4.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_4.Text = pressTimeTotal_4.ToString("N3") & " hours"
                End If
            End If

            ui_percent_4.Text = ((pressCount_4 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '5
        If pressCount_5 > 0 Then 'Used

            ui_Panel_5.BackColor = usedBackgroundColor
            ui_Label_5.BackColor = usedBackgroundColor
            ui_Label_5.ForeColor = usedKeyNameFontColor
            ui_totalPresses_5.BackColor = usedBackgroundColor
            ui_totalPresses_5.ForeColor = usedStatFontColor
            ui_totalPressTime_5.BackColor = usedBackgroundColor
            ui_totalPressTime_5.ForeColor = usedStatFontColor
            ui_averagePressTime_5.BackColor = usedBackgroundColor
            ui_averagePressTime_5.ForeColor = usedStatFontColor
            ui_percent_5.BackColor = usedBackgroundColor
            ui_percent_5.ForeColor = usedStatFontColor
            ui_bind_5.BackColor = usedTextboxBackgroundColor
            ui_bind_5.ForeColor = usedStatFontColor
            ui_totalPresses_5.Text = pressCount_5.ToString

            Dim temp5time As Decimal = 0

            If pressTimeTotal_5 < 60 Then
                If pressTimeTotalConverted_5 = 1 Then
                    ui_totalPressTime_5.Text = pressTimeTotal_5.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_5.Text = pressTimeTotal_5.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_5 > 60 And pressTimeTotal_5 < 3600 Then
                temp5time = pressTimeTotal_5 / 60
                If pressTimeTotal_5 = 1 Then
                    ui_totalPressTime_5.Text = temp5time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_5.Text = temp5time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_5 > 3600 Or pressTimeTotal_5 = 3600 Then
                temp5time = pressTimeTotal_5 / 3600
                If temp5time = 1 Then
                    ui_totalPressTime_5.Text = temp5time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_5.Text = temp5time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_5 = pressTimeTotal_5 / pressCount_5

            If pressTimeAverage_5 < 60 Then
                If pressTimeAverage_5 = 1 Then
                    ui_averagePressTime_5.Text = pressTimeAverage_5.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_5.Text = pressTimeAverage_5.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_5 > 60 And pressTimeAverage_5 < 3600 Then
                pressTimeTotal_5 /= 60
                If pressTimeTotal_5 = 1 Then
                    ui_averagePressTime_5.Text = pressTimeTotal_5.ToString("N3") & " min"
                Else
                    ui_averagePressTime_5.Text = pressTimeTotal_5.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_5 > 3600 Or pressTimeAverage_5 = 3600 Then
                pressTimeTotal_5 /= 3600
                If pressTimeTotal_5 = 1 Then
                    ui_averagePressTime_5.Text = pressTimeTotal_5.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_5.Text = pressTimeTotal_5.ToString("N3") & " hours"
                End If
            End If

            ui_percent_5.Text = ((pressCount_5 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '6
        If pressCount_6 > 0 Then 'Used

            ui_Panel_6.BackColor = usedBackgroundColor
            ui_Label_6.BackColor = usedBackgroundColor
            ui_Label_6.ForeColor = usedKeyNameFontColor
            ui_totalPresses_6.BackColor = usedBackgroundColor
            ui_totalPresses_6.ForeColor = usedStatFontColor
            ui_totalPressTime_6.BackColor = usedBackgroundColor
            ui_totalPressTime_6.ForeColor = usedStatFontColor
            ui_averagePressTime_6.BackColor = usedBackgroundColor
            ui_averagePressTime_6.ForeColor = usedStatFontColor
            ui_percent_6.BackColor = usedBackgroundColor
            ui_percent_6.ForeColor = usedStatFontColor
            ui_bind_6.BackColor = usedTextboxBackgroundColor
            ui_bind_6.ForeColor = usedStatFontColor
            ui_totalPresses_6.Text = pressCount_6.ToString

            Dim temp6time As Decimal = 0

            If pressTimeTotal_6 < 60 Then
                If pressTimeTotalConverted_6 = 1 Then
                    ui_totalPressTime_6.Text = pressTimeTotal_6.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_6.Text = pressTimeTotal_6.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_6 > 60 And pressTimeTotal_6 < 3600 Then
                temp6time = pressTimeTotal_6 / 60
                If pressTimeTotal_6 = 1 Then
                    ui_totalPressTime_6.Text = temp6time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_6.Text = temp6time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_6 > 3600 Or pressTimeTotal_6 = 3600 Then
                temp6time = pressTimeTotal_6 / 3600
                If temp6time = 1 Then
                    ui_totalPressTime_6.Text = temp6time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_6.Text = temp6time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_6 = pressTimeTotal_6 / pressCount_6

            If pressTimeAverage_6 < 60 Then
                If pressTimeAverage_6 = 1 Then
                    ui_averagePressTime_6.Text = pressTimeAverage_6.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_6.Text = pressTimeAverage_6.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_6 > 60 And pressTimeAverage_6 < 3600 Then
                pressTimeTotal_6 /= 60
                If pressTimeTotal_6 = 1 Then
                    ui_averagePressTime_6.Text = pressTimeTotal_6.ToString("N3") & " min"
                Else
                    ui_averagePressTime_6.Text = pressTimeTotal_6.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_6 > 3600 Or pressTimeAverage_6 = 3600 Then
                pressTimeTotal_6 /= 3600
                If pressTimeTotal_6 = 1 Then
                    ui_averagePressTime_6.Text = pressTimeTotal_6.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_6.Text = pressTimeTotal_6.ToString("N3") & " hours"
                End If
            End If

            ui_percent_6.Text = ((pressCount_6 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '7
        If pressCount_7 > 0 Then 'Used

            ui_Panel_7.BackColor = usedBackgroundColor
            ui_Label_7.BackColor = usedBackgroundColor
            ui_Label_7.ForeColor = usedKeyNameFontColor
            ui_totalPresses_7.BackColor = usedBackgroundColor
            ui_totalPresses_7.ForeColor = usedStatFontColor
            ui_totalPressTime_7.BackColor = usedBackgroundColor
            ui_totalPressTime_7.ForeColor = usedStatFontColor
            ui_averagePressTime_7.BackColor = usedBackgroundColor
            ui_averagePressTime_7.ForeColor = usedStatFontColor
            ui_percent_7.BackColor = usedBackgroundColor
            ui_percent_7.ForeColor = usedStatFontColor
            ui_bind_7.BackColor = usedTextboxBackgroundColor
            ui_bind_7.ForeColor = usedStatFontColor
            ui_totalPresses_7.Text = pressCount_7.ToString

            Dim temp7time As Decimal = 0

            If pressTimeTotal_7 < 60 Then
                If pressTimeTotalConverted_7 = 1 Then
                    ui_totalPressTime_7.Text = pressTimeTotal_7.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_7.Text = pressTimeTotal_7.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_7 > 60 And pressTimeTotal_7 < 3600 Then
                temp7time = pressTimeTotal_7 / 60
                If pressTimeTotal_7 = 1 Then
                    ui_totalPressTime_7.Text = temp7time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_7.Text = temp7time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_7 > 3600 Or pressTimeTotal_7 = 3600 Then
                temp7time = pressTimeTotal_7 / 3600
                If temp7time = 1 Then
                    ui_totalPressTime_7.Text = temp7time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_7.Text = temp7time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_7 = pressTimeTotal_7 / pressCount_7

            If pressTimeAverage_7 < 60 Then
                If pressTimeAverage_7 = 1 Then
                    ui_averagePressTime_7.Text = pressTimeAverage_7.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_7.Text = pressTimeAverage_7.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_7 > 60 And pressTimeAverage_7 < 3600 Then
                pressTimeTotal_7 /= 60
                If pressTimeTotal_7 = 1 Then
                    ui_averagePressTime_7.Text = pressTimeTotal_7.ToString("N3") & " min"
                Else
                    ui_averagePressTime_7.Text = pressTimeTotal_7.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_7 > 3600 Or pressTimeAverage_7 = 3600 Then
                pressTimeTotal_7 /= 3600
                If pressTimeTotal_7 = 1 Then
                    ui_averagePressTime_7.Text = pressTimeTotal_7.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_7.Text = pressTimeTotal_7.ToString("N3") & " hours"
                End If
            End If

            ui_percent_7.Text = ((pressCount_7 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '8
        If pressCount_8 > 0 Then 'Used

            ui_Panel_8.BackColor = usedBackgroundColor
            ui_Label_8.BackColor = usedBackgroundColor
            ui_Label_8.ForeColor = usedKeyNameFontColor
            ui_totalPresses_8.BackColor = usedBackgroundColor
            ui_totalPresses_8.ForeColor = usedStatFontColor
            ui_totalPressTime_8.BackColor = usedBackgroundColor
            ui_totalPressTime_8.ForeColor = usedStatFontColor
            ui_averagePressTime_8.BackColor = usedBackgroundColor
            ui_averagePressTime_8.ForeColor = usedStatFontColor
            ui_percent_8.BackColor = usedBackgroundColor
            ui_percent_8.ForeColor = usedStatFontColor
            ui_bind_8.BackColor = usedTextboxBackgroundColor
            ui_bind_8.ForeColor = usedStatFontColor
            ui_totalPresses_8.Text = pressCount_8.ToString

            Dim temp8time As Decimal = 0

            If pressTimeTotal_8 < 60 Then
                If pressTimeTotalConverted_8 = 1 Then
                    ui_totalPressTime_8.Text = pressTimeTotal_8.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_8.Text = pressTimeTotal_8.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_8 > 60 And pressTimeTotal_8 < 3600 Then
                temp8time = pressTimeTotal_8 / 60
                If pressTimeTotal_8 = 1 Then
                    ui_totalPressTime_8.Text = temp8time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_8.Text = temp8time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_8 > 3600 Or pressTimeTotal_8 = 3600 Then
                temp8time = pressTimeTotal_8 / 3600
                If temp8time = 1 Then
                    ui_totalPressTime_8.Text = temp8time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_8.Text = temp8time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_8 = pressTimeTotal_8 / pressCount_8

            If pressTimeAverage_8 < 60 Then
                If pressTimeAverage_8 = 1 Then
                    ui_averagePressTime_8.Text = pressTimeAverage_8.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_8.Text = pressTimeAverage_8.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_8 > 60 And pressTimeAverage_8 < 3600 Then
                pressTimeTotal_8 /= 60
                If pressTimeTotal_8 = 1 Then
                    ui_averagePressTime_8.Text = pressTimeTotal_8.ToString("N3") & " min"
                Else
                    ui_averagePressTime_8.Text = pressTimeTotal_8.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_8 > 3600 Or pressTimeAverage_8 = 3600 Then
                pressTimeTotal_8 /= 3600
                If pressTimeTotal_8 = 1 Then
                    ui_averagePressTime_8.Text = pressTimeTotal_8.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_8.Text = pressTimeTotal_8.ToString("N3") & " hours"
                End If
            End If

            ui_percent_8.Text = ((pressCount_8 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '9
        If pressCount_9 > 0 Then 'Used

            ui_Panel_9.BackColor = usedBackgroundColor
            ui_Label_9.BackColor = usedBackgroundColor
            ui_Label_9.ForeColor = usedKeyNameFontColor
            ui_totalPresses_9.BackColor = usedBackgroundColor
            ui_totalPresses_9.ForeColor = usedStatFontColor
            ui_totalPressTime_9.BackColor = usedBackgroundColor
            ui_totalPressTime_9.ForeColor = usedStatFontColor
            ui_averagePressTime_9.BackColor = usedBackgroundColor
            ui_averagePressTime_9.ForeColor = usedStatFontColor
            ui_percent_9.BackColor = usedBackgroundColor
            ui_percent_9.ForeColor = usedStatFontColor
            ui_bind_9.BackColor = usedTextboxBackgroundColor
            ui_bind_9.ForeColor = usedStatFontColor
            ui_totalPresses_9.Text = pressCount_9.ToString

            Dim temp9time As Decimal = 0

            If pressTimeTotal_9 < 60 Then
                If pressTimeTotalConverted_9 = 1 Then
                    ui_totalPressTime_9.Text = pressTimeTotal_9.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_9.Text = pressTimeTotal_9.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_9 > 60 And pressTimeTotal_9 < 3600 Then
                temp9time = pressTimeTotal_9 / 60
                If pressTimeTotal_9 = 1 Then
                    ui_totalPressTime_9.Text = temp9time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_9.Text = temp9time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_9 > 3600 Or pressTimeTotal_9 = 3600 Then
                temp9time = pressTimeTotal_9 / 3600
                If temp9time = 1 Then
                    ui_totalPressTime_9.Text = temp9time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_9.Text = temp9time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_9 = pressTimeTotal_9 / pressCount_9

            If pressTimeAverage_9 < 60 Then
                If pressTimeAverage_9 = 1 Then
                    ui_averagePressTime_9.Text = pressTimeAverage_9.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_9.Text = pressTimeAverage_9.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_9 > 60 And pressTimeAverage_9 < 3600 Then
                pressTimeTotal_9 /= 60
                If pressTimeTotal_9 = 1 Then
                    ui_averagePressTime_9.Text = pressTimeTotal_9.ToString("N3") & " min"
                Else
                    ui_averagePressTime_9.Text = pressTimeTotal_9.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_9 > 3600 Or pressTimeAverage_9 = 3600 Then
                pressTimeTotal_9 /= 3600
                If pressTimeTotal_9 = 1 Then
                    ui_averagePressTime_9.Text = pressTimeTotal_9.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_9.Text = pressTimeTotal_9.ToString("N3") & " hours"
                End If
            End If

            ui_percent_9.Text = ((pressCount_9 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        '0
        If pressCount_0 > 0 Then 'Used

            ui_Panel_0.BackColor = usedBackgroundColor
            ui_Label_0.BackColor = usedBackgroundColor
            ui_Label_0.ForeColor = usedKeyNameFontColor
            ui_totalPresses_0.BackColor = usedBackgroundColor
            ui_totalPresses_0.ForeColor = usedStatFontColor
            ui_totalPressTime_0.BackColor = usedBackgroundColor
            ui_totalPressTime_0.ForeColor = usedStatFontColor
            ui_averagePressTime_0.BackColor = usedBackgroundColor
            ui_averagePressTime_0.ForeColor = usedStatFontColor
            ui_percent_0.BackColor = usedBackgroundColor
            ui_percent_0.ForeColor = usedStatFontColor
            ui_bind_0.BackColor = usedTextboxBackgroundColor
            ui_bind_0.ForeColor = usedStatFontColor
            ui_totalPresses_0.Text = pressCount_0.ToString

            Dim temp0time As Decimal = 0

            If pressTimeTotal_0 < 60 Then
                If pressTimeTotalConverted_0 = 1 Then
                    ui_totalPressTime_0.Text = pressTimeTotal_0.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_0.Text = pressTimeTotal_0.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_0 > 60 And pressTimeTotal_0 < 3600 Then
                temp0time = pressTimeTotal_0 / 60
                If pressTimeTotal_0 = 1 Then
                    ui_totalPressTime_0.Text = temp0time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_0.Text = temp0time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_0 > 3600 Or pressTimeTotal_0 = 3600 Then
                temp0time = pressTimeTotal_0 / 3600
                If temp0time = 1 Then
                    ui_totalPressTime_0.Text = temp0time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_0.Text = temp0time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_0 = pressTimeTotal_0 / pressCount_0

            If pressTimeAverage_0 < 60 Then
                If pressTimeAverage_0 = 1 Then
                    ui_averagePressTime_0.Text = pressTimeAverage_0.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_0.Text = pressTimeAverage_0.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_0 > 60 And pressTimeAverage_0 < 3600 Then
                pressTimeTotal_0 /= 60
                If pressTimeTotal_0 = 1 Then
                    ui_averagePressTime_0.Text = pressTimeTotal_0.ToString("N3") & " min"
                Else
                    ui_averagePressTime_0.Text = pressTimeTotal_0.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_0 > 3600 Or pressTimeAverage_0 = 3600 Then
                pressTimeTotal_0 /= 3600
                If pressTimeTotal_0 = 1 Then
                    ui_averagePressTime_0.Text = pressTimeTotal_0.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_0.Text = pressTimeTotal_0.ToString("N3") & " hours"
                End If
            End If

            ui_percent_0.Text = ((pressCount_0 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'UnderScore
        If pressCount_UnderScore > 0 Then 'Used

            ui_Panel_UnderScore.BackColor = usedBackgroundColor
            ui_Label_UnderScore.BackColor = usedBackgroundColor
            ui_Label_UnderScore.ForeColor = usedKeyNameFontColor
            ui_totalPresses_UnderScore.BackColor = usedBackgroundColor
            ui_totalPresses_UnderScore.ForeColor = usedStatFontColor
            ui_totalPressTime_UnderScore.BackColor = usedBackgroundColor
            ui_totalPressTime_UnderScore.ForeColor = usedStatFontColor
            ui_averagePressTime_UnderScore.BackColor = usedBackgroundColor
            ui_averagePressTime_UnderScore.ForeColor = usedStatFontColor
            ui_percent_UnderScore.BackColor = usedBackgroundColor
            ui_percent_UnderScore.ForeColor = usedStatFontColor
            ui_bind_UnderScore.BackColor = usedTextboxBackgroundColor
            ui_bind_UnderScore.ForeColor = usedStatFontColor
            ui_totalPresses_UnderScore.Text = pressCount_UnderScore.ToString

            Dim tempUnderScoretime As Decimal = 0

            If pressTimeTotal_UnderScore < 60 Then
                If pressTimeTotalConverted_UnderScore = 1 Then
                    ui_totalPressTime_UnderScore.Text = pressTimeTotal_UnderScore.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_UnderScore.Text = pressTimeTotal_UnderScore.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_UnderScore > 60 And pressTimeTotal_UnderScore < 3600 Then
                tempUnderScoretime = pressTimeTotal_UnderScore / 60
                If pressTimeTotal_UnderScore = 1 Then
                    ui_totalPressTime_UnderScore.Text = tempUnderScoretime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_UnderScore.Text = tempUnderScoretime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_UnderScore > 3600 Or pressTimeTotal_UnderScore = 3600 Then
                tempUnderScoretime = pressTimeTotal_UnderScore / 3600
                If tempUnderScoretime = 1 Then
                    ui_totalPressTime_UnderScore.Text = tempUnderScoretime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_UnderScore.Text = tempUnderScoretime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_UnderScore = pressTimeTotal_UnderScore / pressCount_UnderScore

            If pressTimeAverage_UnderScore < 60 Then
                If pressTimeAverage_UnderScore = 1 Then
                    ui_averagePressTime_UnderScore.Text = pressTimeAverage_UnderScore.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_UnderScore.Text = pressTimeAverage_UnderScore.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_UnderScore > 60 And pressTimeAverage_UnderScore < 3600 Then
                pressTimeTotal_UnderScore /= 60
                If pressTimeTotal_UnderScore = 1 Then
                    ui_averagePressTime_UnderScore.Text = pressTimeTotal_UnderScore.ToString("N3") & " min"
                Else
                    ui_averagePressTime_UnderScore.Text = pressTimeTotal_UnderScore.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_UnderScore > 3600 Or pressTimeAverage_UnderScore = 3600 Then
                pressTimeTotal_UnderScore /= 3600
                If pressTimeTotal_UnderScore = 1 Then
                    ui_averagePressTime_UnderScore.Text = pressTimeTotal_UnderScore.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_UnderScore.Text = pressTimeTotal_UnderScore.ToString("N3") & " hours"
                End If
            End If

            ui_percent_UnderScore.Text = ((pressCount_UnderScore / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'PlusEquals
        If pressCount_PlusEquals > 0 Then 'Used

            ui_Panel_PlusEquals.BackColor = usedBackgroundColor
            ui_Label_PlusEquals.BackColor = usedBackgroundColor
            ui_Label_PlusEquals.ForeColor = usedKeyNameFontColor
            ui_totalPresses_PlusEquals.BackColor = usedBackgroundColor
            ui_totalPresses_PlusEquals.ForeColor = usedStatFontColor
            ui_totalPressTime_PlusEquals.BackColor = usedBackgroundColor
            ui_totalPressTime_PlusEquals.ForeColor = usedStatFontColor
            ui_averagePressTime_PlusEquals.BackColor = usedBackgroundColor
            ui_averagePressTime_PlusEquals.ForeColor = usedStatFontColor
            ui_percent_PlusEquals.BackColor = usedBackgroundColor
            ui_percent_PlusEquals.ForeColor = usedStatFontColor
            ui_bind_PlusEquals.BackColor = usedTextboxBackgroundColor
            ui_bind_PlusEquals.ForeColor = usedStatFontColor
            ui_totalPresses_PlusEquals.Text = pressCount_PlusEquals.ToString

            Dim tempPlusEqualstime As Decimal = 0

            If pressTimeTotal_PlusEquals < 60 Then
                If pressTimeTotalConverted_PlusEquals = 1 Then
                    ui_totalPressTime_PlusEquals.Text = pressTimeTotal_PlusEquals.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_PlusEquals.Text = pressTimeTotal_PlusEquals.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_PlusEquals > 60 And pressTimeTotal_PlusEquals < 3600 Then
                tempPlusEqualstime = pressTimeTotal_PlusEquals / 60
                If pressTimeTotal_PlusEquals = 1 Then
                    ui_totalPressTime_PlusEquals.Text = tempPlusEqualstime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_PlusEquals.Text = tempPlusEqualstime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_PlusEquals > 3600 Or pressTimeTotal_PlusEquals = 3600 Then
                tempPlusEqualstime = pressTimeTotal_PlusEquals / 3600
                If tempPlusEqualstime = 1 Then
                    ui_totalPressTime_PlusEquals.Text = tempPlusEqualstime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_PlusEquals.Text = tempPlusEqualstime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_PlusEquals = pressTimeTotal_PlusEquals / pressCount_PlusEquals

            If pressTimeAverage_PlusEquals < 60 Then
                If pressTimeAverage_PlusEquals = 1 Then
                    ui_averagePressTime_PlusEquals.Text = pressTimeAverage_PlusEquals.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_PlusEquals.Text = pressTimeAverage_PlusEquals.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_PlusEquals > 60 And pressTimeAverage_PlusEquals < 3600 Then
                pressTimeTotal_PlusEquals /= 60
                If pressTimeTotal_PlusEquals = 1 Then
                    ui_averagePressTime_PlusEquals.Text = pressTimeTotal_PlusEquals.ToString("N3") & " min"
                Else
                    ui_averagePressTime_PlusEquals.Text = pressTimeTotal_PlusEquals.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_PlusEquals > 3600 Or pressTimeAverage_PlusEquals = 3600 Then
                pressTimeTotal_PlusEquals /= 3600
                If pressTimeTotal_PlusEquals = 1 Then
                    ui_averagePressTime_PlusEquals.Text = pressTimeTotal_PlusEquals.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_PlusEquals.Text = pressTimeTotal_PlusEquals.ToString("N3") & " hours"
                End If
            End If

            ui_percent_PlusEquals.Text = ((pressCount_PlusEquals / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'BackSpace
        If pressCount_BackSpace > 0 Then 'Used

            ui_Panel_BackSpace.BackColor = usedBackgroundColor
            ui_Label_BackSpace.BackColor = usedBackgroundColor
            ui_Label_BackSpace.ForeColor = usedKeyNameFontColor
            ui_totalPresses_BackSpace.BackColor = usedBackgroundColor
            ui_totalPresses_BackSpace.ForeColor = usedStatFontColor
            ui_totalPressTime_BackSpace.BackColor = usedBackgroundColor
            ui_totalPressTime_BackSpace.ForeColor = usedStatFontColor
            ui_averagePressTime_BackSpace.BackColor = usedBackgroundColor
            ui_averagePressTime_BackSpace.ForeColor = usedStatFontColor
            ui_percent_BackSpace.BackColor = usedBackgroundColor
            ui_percent_BackSpace.ForeColor = usedStatFontColor
            ui_bind_BackSpace.BackColor = usedTextboxBackgroundColor
            ui_bind_BackSpace.ForeColor = usedStatFontColor
            ui_totalPresses_BackSpace.Text = pressCount_BackSpace.ToString

            Dim tempBackSpacetime As Decimal = 0

            If pressTimeTotal_BackSpace < 60 Then
                If pressTimeTotalConverted_BackSpace = 1 Then
                    ui_totalPressTime_BackSpace.Text = pressTimeTotal_BackSpace.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_BackSpace.Text = pressTimeTotal_BackSpace.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_BackSpace > 60 And pressTimeTotal_BackSpace < 3600 Then
                tempBackSpacetime = pressTimeTotal_BackSpace / 60
                If pressTimeTotal_BackSpace = 1 Then
                    ui_totalPressTime_BackSpace.Text = tempBackSpacetime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_BackSpace.Text = tempBackSpacetime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_BackSpace > 3600 Or pressTimeTotal_BackSpace = 3600 Then
                tempBackSpacetime = pressTimeTotal_BackSpace / 3600
                If tempBackSpacetime = 1 Then
                    ui_totalPressTime_BackSpace.Text = tempBackSpacetime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_BackSpace.Text = tempBackSpacetime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_BackSpace = pressTimeTotal_BackSpace / pressCount_BackSpace

            If pressTimeAverage_BackSpace < 60 Then
                If pressTimeAverage_BackSpace = 1 Then
                    ui_averagePressTime_BackSpace.Text = pressTimeAverage_BackSpace.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_BackSpace.Text = pressTimeAverage_BackSpace.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_BackSpace > 60 And pressTimeAverage_BackSpace < 3600 Then
                pressTimeTotal_BackSpace /= 60
                If pressTimeTotal_BackSpace = 1 Then
                    ui_averagePressTime_BackSpace.Text = pressTimeTotal_BackSpace.ToString("N3") & " min"
                Else
                    ui_averagePressTime_BackSpace.Text = pressTimeTotal_BackSpace.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_BackSpace > 3600 Or pressTimeAverage_BackSpace = 3600 Then
                pressTimeTotal_BackSpace /= 3600
                If pressTimeTotal_BackSpace = 1 Then
                    ui_averagePressTime_BackSpace.Text = pressTimeTotal_BackSpace.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_BackSpace.Text = pressTimeTotal_BackSpace.ToString("N3") & " hours"
                End If
            End If

            ui_percent_BackSpace.Text = ((pressCount_BackSpace / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Insert
        If pressCount_Insert > 0 Then 'Used

            ui_Panel_Insert.BackColor = usedBackgroundColor
            ui_Label_Insert.BackColor = usedBackgroundColor
            ui_Label_Insert.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Insert.BackColor = usedBackgroundColor
            ui_totalPresses_Insert.ForeColor = usedStatFontColor
            ui_totalPressTime_Insert.BackColor = usedBackgroundColor
            ui_totalPressTime_Insert.ForeColor = usedStatFontColor
            ui_averagePressTime_Insert.BackColor = usedBackgroundColor
            ui_averagePressTime_Insert.ForeColor = usedStatFontColor
            ui_percent_Insert.BackColor = usedBackgroundColor
            ui_percent_Insert.ForeColor = usedStatFontColor
            ui_bind_Insert.BackColor = usedTextboxBackgroundColor
            ui_bind_Insert.ForeColor = usedStatFontColor
            ui_totalPresses_Insert.Text = pressCount_Insert.ToString

            Dim tempInserttime As Decimal = 0

            If pressTimeTotal_Insert < 60 Then
                If pressTimeTotalConverted_Insert = 1 Then
                    ui_totalPressTime_Insert.Text = pressTimeTotal_Insert.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Insert.Text = pressTimeTotal_Insert.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Insert > 60 And pressTimeTotal_Insert < 3600 Then
                tempInserttime = pressTimeTotal_Insert / 60
                If pressTimeTotal_Insert = 1 Then
                    ui_totalPressTime_Insert.Text = tempInserttime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Insert.Text = tempInserttime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Insert > 3600 Or pressTimeTotal_Insert = 3600 Then
                tempInserttime = pressTimeTotal_Insert / 3600
                If tempInserttime = 1 Then
                    ui_totalPressTime_Insert.Text = tempInserttime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Insert.Text = tempInserttime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Insert = pressTimeTotal_Insert / pressCount_Insert

            If pressTimeAverage_Insert < 60 Then
                If pressTimeAverage_Insert = 1 Then
                    ui_averagePressTime_Insert.Text = pressTimeAverage_Insert.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Insert.Text = pressTimeAverage_Insert.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Insert > 60 And pressTimeAverage_Insert < 3600 Then
                pressTimeTotal_Insert /= 60
                If pressTimeTotal_Insert = 1 Then
                    ui_averagePressTime_Insert.Text = pressTimeTotal_Insert.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Insert.Text = pressTimeTotal_Insert.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Insert > 3600 Or pressTimeAverage_Insert = 3600 Then
                pressTimeTotal_Insert /= 3600
                If pressTimeTotal_Insert = 1 Then
                    ui_averagePressTime_Insert.Text = pressTimeTotal_Insert.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Insert.Text = pressTimeTotal_Insert.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Insert.Text = ((pressCount_Insert / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Home
        If pressCount_Home > 0 Then 'Used

            ui_Panel_Home.BackColor = usedBackgroundColor
            ui_Label_Home.BackColor = usedBackgroundColor
            ui_Label_Home.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Home.BackColor = usedBackgroundColor
            ui_totalPresses_Home.ForeColor = usedStatFontColor
            ui_totalPressTime_Home.BackColor = usedBackgroundColor
            ui_totalPressTime_Home.ForeColor = usedStatFontColor
            ui_averagePressTime_Home.BackColor = usedBackgroundColor
            ui_averagePressTime_Home.ForeColor = usedStatFontColor
            ui_percent_Home.BackColor = usedBackgroundColor
            ui_percent_Home.ForeColor = usedStatFontColor
            ui_bind_Home.BackColor = usedTextboxBackgroundColor
            ui_bind_Home.ForeColor = usedStatFontColor
            ui_totalPresses_Home.Text = pressCount_Home.ToString

            Dim tempHometime As Decimal = 0

            If pressTimeTotal_Home < 60 Then
                If pressTimeTotalConverted_Home = 1 Then
                    ui_totalPressTime_Home.Text = pressTimeTotal_Home.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Home.Text = pressTimeTotal_Home.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Home > 60 And pressTimeTotal_Home < 3600 Then
                tempHometime = pressTimeTotal_Home / 60
                If pressTimeTotal_Home = 1 Then
                    ui_totalPressTime_Home.Text = tempHometime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Home.Text = tempHometime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Home > 3600 Or pressTimeTotal_Home = 3600 Then
                tempHometime = pressTimeTotal_Home / 3600
                If tempHometime = 1 Then
                    ui_totalPressTime_Home.Text = tempHometime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Home.Text = tempHometime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Home = pressTimeTotal_Home / pressCount_Home

            If pressTimeAverage_Home < 60 Then
                If pressTimeAverage_Home = 1 Then
                    ui_averagePressTime_Home.Text = pressTimeAverage_Home.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Home.Text = pressTimeAverage_Home.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Home > 60 And pressTimeAverage_Home < 3600 Then
                pressTimeTotal_Home /= 60
                If pressTimeTotal_Home = 1 Then
                    ui_averagePressTime_Home.Text = pressTimeTotal_Home.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Home.Text = pressTimeTotal_Home.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Home > 3600 Or pressTimeAverage_Home = 3600 Then
                pressTimeTotal_Home /= 3600
                If pressTimeTotal_Home = 1 Then
                    ui_averagePressTime_Home.Text = pressTimeTotal_Home.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Home.Text = pressTimeTotal_Home.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Home.Text = ((pressCount_Home / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'PgUp
        If pressCount_PgUp > 0 Then 'Used

            ui_Panel_PgUp.BackColor = usedBackgroundColor
            ui_Label_PgUp.BackColor = usedBackgroundColor
            ui_Label_PgUp.ForeColor = usedKeyNameFontColor
            ui_totalPresses_PgUp.BackColor = usedBackgroundColor
            ui_totalPresses_PgUp.ForeColor = usedStatFontColor
            ui_totalPressTime_PgUp.BackColor = usedBackgroundColor
            ui_totalPressTime_PgUp.ForeColor = usedStatFontColor
            ui_averagePressTime_PgUp.BackColor = usedBackgroundColor
            ui_averagePressTime_PgUp.ForeColor = usedStatFontColor
            ui_percent_PgUp.BackColor = usedBackgroundColor
            ui_percent_PgUp.ForeColor = usedStatFontColor
            ui_bind_PgUp.BackColor = usedTextboxBackgroundColor
            ui_bind_PgUp.ForeColor = usedStatFontColor
            ui_totalPresses_PgUp.Text = pressCount_PgUp.ToString

            Dim tempPgUptime As Decimal = 0

            If pressTimeTotal_PgUp < 60 Then
                If pressTimeTotalConverted_PgUp = 1 Then
                    ui_totalPressTime_PgUp.Text = pressTimeTotal_PgUp.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_PgUp.Text = pressTimeTotal_PgUp.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_PgUp > 60 And pressTimeTotal_PgUp < 3600 Then
                tempPgUptime = pressTimeTotal_PgUp / 60
                If pressTimeTotal_PgUp = 1 Then
                    ui_totalPressTime_PgUp.Text = tempPgUptime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_PgUp.Text = tempPgUptime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_PgUp > 3600 Or pressTimeTotal_PgUp = 3600 Then
                tempPgUptime = pressTimeTotal_PgUp / 3600
                If tempPgUptime = 1 Then
                    ui_totalPressTime_PgUp.Text = tempPgUptime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_PgUp.Text = tempPgUptime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_PgUp = pressTimeTotal_PgUp / pressCount_PgUp

            If pressTimeAverage_PgUp < 60 Then
                If pressTimeAverage_PgUp = 1 Then
                    ui_averagePressTime_PgUp.Text = pressTimeAverage_PgUp.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_PgUp.Text = pressTimeAverage_PgUp.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_PgUp > 60 And pressTimeAverage_PgUp < 3600 Then
                pressTimeTotal_PgUp /= 60
                If pressTimeTotal_PgUp = 1 Then
                    ui_averagePressTime_PgUp.Text = pressTimeTotal_PgUp.ToString("N3") & " min"
                Else
                    ui_averagePressTime_PgUp.Text = pressTimeTotal_PgUp.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_PgUp > 3600 Or pressTimeAverage_PgUp = 3600 Then
                pressTimeTotal_PgUp /= 3600
                If pressTimeTotal_PgUp = 1 Then
                    ui_averagePressTime_PgUp.Text = pressTimeTotal_PgUp.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_PgUp.Text = pressTimeTotal_PgUp.ToString("N3") & " hours"
                End If
            End If

            ui_percent_PgUp.Text = ((pressCount_PgUp / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'NumLock
        If pressCount_NumLock > 0 Then 'Used

            ui_Panel_NumLock.BackColor = usedBackgroundColor
            ui_Label_NumLock.BackColor = usedBackgroundColor
            ui_Label_NumLock.ForeColor = usedKeyNameFontColor
            ui_totalPresses_NumLock.BackColor = usedBackgroundColor
            ui_totalPresses_NumLock.ForeColor = usedStatFontColor
            ui_totalPressTime_NumLock.BackColor = usedBackgroundColor
            ui_totalPressTime_NumLock.ForeColor = usedStatFontColor
            ui_averagePressTime_NumLock.BackColor = usedBackgroundColor
            ui_averagePressTime_NumLock.ForeColor = usedStatFontColor
            ui_percent_NumLock.BackColor = usedBackgroundColor
            ui_percent_NumLock.ForeColor = usedStatFontColor
            ui_bind_NumLock.BackColor = usedTextboxBackgroundColor
            ui_bind_NumLock.ForeColor = usedStatFontColor
            ui_totalPresses_NumLock.Text = pressCount_NumLock.ToString

            Dim tempNumLocktime As Decimal = 0

            If pressTimeTotal_NumLock < 60 Then
                If pressTimeTotalConverted_NumLock = 1 Then
                    ui_totalPressTime_NumLock.Text = pressTimeTotal_NumLock.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_NumLock.Text = pressTimeTotal_NumLock.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_NumLock > 60 And pressTimeTotal_NumLock < 3600 Then
                tempNumLocktime = pressTimeTotal_NumLock / 60
                If pressTimeTotal_NumLock = 1 Then
                    ui_totalPressTime_NumLock.Text = tempNumLocktime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_NumLock.Text = tempNumLocktime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_NumLock > 3600 Or pressTimeTotal_NumLock = 3600 Then
                tempNumLocktime = pressTimeTotal_NumLock / 3600
                If tempNumLocktime = 1 Then
                    ui_totalPressTime_NumLock.Text = tempNumLocktime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_NumLock.Text = tempNumLocktime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_NumLock = pressTimeTotal_NumLock / pressCount_NumLock

            If pressTimeAverage_NumLock < 60 Then
                If pressTimeAverage_NumLock = 1 Then
                    ui_averagePressTime_NumLock.Text = pressTimeAverage_NumLock.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_NumLock.Text = pressTimeAverage_NumLock.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_NumLock > 60 And pressTimeAverage_NumLock < 3600 Then
                pressTimeTotal_NumLock /= 60
                If pressTimeTotal_NumLock = 1 Then
                    ui_averagePressTime_NumLock.Text = pressTimeTotal_NumLock.ToString("N3") & " min"
                Else
                    ui_averagePressTime_NumLock.Text = pressTimeTotal_NumLock.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_NumLock > 3600 Or pressTimeAverage_NumLock = 3600 Then
                pressTimeTotal_NumLock /= 3600
                If pressTimeTotal_NumLock = 1 Then
                    ui_averagePressTime_NumLock.Text = pressTimeTotal_NumLock.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_NumLock.Text = pressTimeTotal_NumLock.ToString("N3") & " hours"
                End If
            End If

            ui_percent_NumLock.Text = ((pressCount_NumLock / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Divide
        If pressCount_Divide > 0 Then 'Used

            ui_Panel_Divide.BackColor = usedBackgroundColor
            ui_Label_Divide.BackColor = usedBackgroundColor
            ui_Label_Divide.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Divide.BackColor = usedBackgroundColor
            ui_totalPresses_Divide.ForeColor = usedStatFontColor
            ui_totalPressTime_Divide.BackColor = usedBackgroundColor
            ui_totalPressTime_Divide.ForeColor = usedStatFontColor
            ui_averagePressTime_Divide.BackColor = usedBackgroundColor
            ui_averagePressTime_Divide.ForeColor = usedStatFontColor
            ui_percent_Divide.BackColor = usedBackgroundColor
            ui_percent_Divide.ForeColor = usedStatFontColor
            ui_bind_Divide.BackColor = usedTextboxBackgroundColor
            ui_bind_Divide.ForeColor = usedStatFontColor
            ui_totalPresses_Divide.Text = pressCount_Divide.ToString

            Dim tempDividetime As Decimal = 0

            If pressTimeTotal_Divide < 60 Then
                If pressTimeTotalConverted_Divide = 1 Then
                    ui_totalPressTime_Divide.Text = pressTimeTotal_Divide.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Divide.Text = pressTimeTotal_Divide.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Divide > 60 And pressTimeTotal_Divide < 3600 Then
                tempDividetime = pressTimeTotal_Divide / 60
                If pressTimeTotal_Divide = 1 Then
                    ui_totalPressTime_Divide.Text = tempDividetime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Divide.Text = tempDividetime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Divide > 3600 Or pressTimeTotal_Divide = 3600 Then
                tempDividetime = pressTimeTotal_Divide / 3600
                If tempDividetime = 1 Then
                    ui_totalPressTime_Divide.Text = tempDividetime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Divide.Text = tempDividetime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Divide = pressTimeTotal_Divide / pressCount_Divide

            If pressTimeAverage_Divide < 60 Then
                If pressTimeAverage_Divide = 1 Then
                    ui_averagePressTime_Divide.Text = pressTimeAverage_Divide.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Divide.Text = pressTimeAverage_Divide.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Divide > 60 And pressTimeAverage_Divide < 3600 Then
                pressTimeTotal_Divide /= 60
                If pressTimeTotal_Divide = 1 Then
                    ui_averagePressTime_Divide.Text = pressTimeTotal_Divide.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Divide.Text = pressTimeTotal_Divide.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Divide > 3600 Or pressTimeAverage_Divide = 3600 Then
                pressTimeTotal_Divide /= 3600
                If pressTimeTotal_Divide = 1 Then
                    ui_averagePressTime_Divide.Text = pressTimeTotal_Divide.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Divide.Text = pressTimeTotal_Divide.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Divide.Text = ((pressCount_Divide / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Multiply
        If pressCount_Multiply > 0 Then 'Used

            ui_Panel_Multiply.BackColor = usedBackgroundColor
            ui_Label_Multiply.BackColor = usedBackgroundColor
            ui_Label_Multiply.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Multiply.BackColor = usedBackgroundColor
            ui_totalPresses_Multiply.ForeColor = usedStatFontColor
            ui_totalPressTime_Multiply.BackColor = usedBackgroundColor
            ui_totalPressTime_Multiply.ForeColor = usedStatFontColor
            ui_averagePressTime_Multiply.BackColor = usedBackgroundColor
            ui_averagePressTime_Multiply.ForeColor = usedStatFontColor
            ui_percent_Multiply.BackColor = usedBackgroundColor
            ui_percent_Multiply.ForeColor = usedStatFontColor
            ui_bind_Multiply.BackColor = usedTextboxBackgroundColor
            ui_bind_Multiply.ForeColor = usedStatFontColor
            ui_totalPresses_Multiply.Text = pressCount_Multiply.ToString

            Dim tempMultiplytime As Decimal = 0

            If pressTimeTotal_Multiply < 60 Then
                If pressTimeTotalConverted_Multiply = 1 Then
                    ui_totalPressTime_Multiply.Text = pressTimeTotal_Multiply.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Multiply.Text = pressTimeTotal_Multiply.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Multiply > 60 And pressTimeTotal_Multiply < 3600 Then
                tempMultiplytime = pressTimeTotal_Multiply / 60
                If pressTimeTotal_Multiply = 1 Then
                    ui_totalPressTime_Multiply.Text = tempMultiplytime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Multiply.Text = tempMultiplytime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Multiply > 3600 Or pressTimeTotal_Multiply = 3600 Then
                tempMultiplytime = pressTimeTotal_Multiply / 3600
                If tempMultiplytime = 1 Then
                    ui_totalPressTime_Multiply.Text = tempMultiplytime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Multiply.Text = tempMultiplytime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Multiply = pressTimeTotal_Multiply / pressCount_Multiply

            If pressTimeAverage_Multiply < 60 Then
                If pressTimeAverage_Multiply = 1 Then
                    ui_averagePressTime_Multiply.Text = pressTimeAverage_Multiply.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Multiply.Text = pressTimeAverage_Multiply.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Multiply > 60 And pressTimeAverage_Multiply < 3600 Then
                pressTimeTotal_Multiply /= 60
                If pressTimeTotal_Multiply = 1 Then
                    ui_averagePressTime_Multiply.Text = pressTimeTotal_Multiply.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Multiply.Text = pressTimeTotal_Multiply.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Multiply > 3600 Or pressTimeAverage_Multiply = 3600 Then
                pressTimeTotal_Multiply /= 3600
                If pressTimeTotal_Multiply = 1 Then
                    ui_averagePressTime_Multiply.Text = pressTimeTotal_Multiply.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Multiply.Text = pressTimeTotal_Multiply.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Multiply.Text = ((pressCount_Multiply / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Minus
        If pressCount_Minus > 0 Then 'Used

            ui_Panel_Minus.BackColor = usedBackgroundColor
            ui_Label_Minus.BackColor = usedBackgroundColor
            ui_Label_Minus.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Minus.BackColor = usedBackgroundColor
            ui_totalPresses_Minus.ForeColor = usedStatFontColor
            ui_totalPressTime_Minus.BackColor = usedBackgroundColor
            ui_totalPressTime_Minus.ForeColor = usedStatFontColor
            ui_averagePressTime_Minus.BackColor = usedBackgroundColor
            ui_averagePressTime_Minus.ForeColor = usedStatFontColor
            ui_percent_Minus.BackColor = usedBackgroundColor
            ui_percent_Minus.ForeColor = usedStatFontColor
            ui_bind_Minus.BackColor = usedTextboxBackgroundColor
            ui_bind_Minus.ForeColor = usedStatFontColor
            ui_totalPresses_Minus.Text = pressCount_Minus.ToString

            Dim tempMinustime As Decimal = 0

            If pressTimeTotal_Minus < 60 Then
                If pressTimeTotalConverted_Minus = 1 Then
                    ui_totalPressTime_Minus.Text = pressTimeTotal_Minus.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Minus.Text = pressTimeTotal_Minus.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Minus > 60 And pressTimeTotal_Minus < 3600 Then
                tempMinustime = pressTimeTotal_Minus / 60
                If pressTimeTotal_Minus = 1 Then
                    ui_totalPressTime_Minus.Text = tempMinustime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Minus.Text = tempMinustime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Minus > 3600 Or pressTimeTotal_Minus = 3600 Then
                tempMinustime = pressTimeTotal_Minus / 3600
                If tempMinustime = 1 Then
                    ui_totalPressTime_Minus.Text = tempMinustime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Minus.Text = tempMinustime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Minus = pressTimeTotal_Minus / pressCount_Minus

            If pressTimeAverage_Minus < 60 Then
                If pressTimeAverage_Minus = 1 Then
                    ui_averagePressTime_Minus.Text = pressTimeAverage_Minus.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Minus.Text = pressTimeAverage_Minus.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Minus > 60 And pressTimeAverage_Minus < 3600 Then
                pressTimeTotal_Minus /= 60
                If pressTimeTotal_Minus = 1 Then
                    ui_averagePressTime_Minus.Text = pressTimeTotal_Minus.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Minus.Text = pressTimeTotal_Minus.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Minus > 3600 Or pressTimeAverage_Minus = 3600 Then
                pressTimeTotal_Minus /= 3600
                If pressTimeTotal_Minus = 1 Then
                    ui_averagePressTime_Minus.Text = pressTimeTotal_Minus.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Minus.Text = pressTimeTotal_Minus.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Minus.Text = ((pressCount_Minus / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'TAB
        If pressCount_TAB > 0 Then 'Used

            ui_Panel_TAB.BackColor = usedBackgroundColor
            ui_Label_TAB.BackColor = usedBackgroundColor
            ui_Label_TAB.ForeColor = usedKeyNameFontColor
            ui_totalPresses_TAB.BackColor = usedBackgroundColor
            ui_totalPresses_TAB.ForeColor = usedStatFontColor
            ui_totalPressTime_TAB.BackColor = usedBackgroundColor
            ui_totalPressTime_TAB.ForeColor = usedStatFontColor
            ui_averagePressTime_TAB.BackColor = usedBackgroundColor
            ui_averagePressTime_TAB.ForeColor = usedStatFontColor
            ui_percent_TAB.BackColor = usedBackgroundColor
            ui_percent_TAB.ForeColor = usedStatFontColor
            ui_bind_TAB.BackColor = usedTextboxBackgroundColor
            ui_bind_TAB.ForeColor = usedStatFontColor
            ui_totalPresses_TAB.Text = pressCount_TAB.ToString

            Dim tempTABtime As Decimal = 0

            If pressTimeTotal_TAB < 60 Then
                If pressTimeTotalConverted_TAB = 1 Then
                    ui_totalPressTime_TAB.Text = pressTimeTotal_TAB.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_TAB.Text = pressTimeTotal_TAB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_TAB > 60 And pressTimeTotal_TAB < 3600 Then
                tempTABtime = pressTimeTotal_TAB / 60
                If pressTimeTotal_TAB = 1 Then
                    ui_totalPressTime_TAB.Text = tempTABtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_TAB.Text = tempTABtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_TAB > 3600 Or pressTimeTotal_TAB = 3600 Then
                tempTABtime = pressTimeTotal_TAB / 3600
                If tempTABtime = 1 Then
                    ui_totalPressTime_TAB.Text = tempTABtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_TAB.Text = tempTABtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_TAB = pressTimeTotal_TAB / pressCount_TAB

            If pressTimeAverage_TAB < 60 Then
                If pressTimeAverage_TAB = 1 Then
                    ui_averagePressTime_TAB.Text = pressTimeAverage_TAB.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_TAB.Text = pressTimeAverage_TAB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_TAB > 60 And pressTimeAverage_TAB < 3600 Then
                pressTimeTotal_TAB /= 60
                If pressTimeTotal_TAB = 1 Then
                    ui_averagePressTime_TAB.Text = pressTimeTotal_TAB.ToString("N3") & " min"
                Else
                    ui_averagePressTime_TAB.Text = pressTimeTotal_TAB.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_TAB > 3600 Or pressTimeAverage_TAB = 3600 Then
                pressTimeTotal_TAB /= 3600
                If pressTimeTotal_TAB = 1 Then
                    ui_averagePressTime_TAB.Text = pressTimeTotal_TAB.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_TAB.Text = pressTimeTotal_TAB.ToString("N3") & " hours"
                End If
            End If

            ui_percent_TAB.Text = ((pressCount_TAB / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Q
        If pressCount_Q > 0 Then 'Used

            ui_Panel_Q.BackColor = usedBackgroundColor
            ui_Label_Q.BackColor = usedBackgroundColor
            ui_Label_Q.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Q.BackColor = usedBackgroundColor
            ui_totalPresses_Q.ForeColor = usedStatFontColor
            ui_totalPressTime_Q.BackColor = usedBackgroundColor
            ui_totalPressTime_Q.ForeColor = usedStatFontColor
            ui_averagePressTime_Q.BackColor = usedBackgroundColor
            ui_averagePressTime_Q.ForeColor = usedStatFontColor
            ui_percent_Q.BackColor = usedBackgroundColor
            ui_percent_Q.ForeColor = usedStatFontColor
            ui_bind_Q.BackColor = usedTextboxBackgroundColor
            ui_bind_Q.ForeColor = usedStatFontColor
            ui_totalPresses_Q.Text = pressCount_Q.ToString

            Dim tempQtime As Decimal = 0

            If pressTimeTotal_Q < 60 Then
                If pressTimeTotalConverted_Q = 1 Then
                    ui_totalPressTime_Q.Text = pressTimeTotal_Q.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Q.Text = pressTimeTotal_Q.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Q > 60 And pressTimeTotal_Q < 3600 Then
                tempQtime = pressTimeTotal_Q / 60
                If pressTimeTotal_Q = 1 Then
                    ui_totalPressTime_Q.Text = tempQtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Q.Text = tempQtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Q > 3600 Or pressTimeTotal_Q = 3600 Then
                tempQtime = pressTimeTotal_Q / 3600
                If tempQtime = 1 Then
                    ui_totalPressTime_Q.Text = tempQtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Q.Text = tempQtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Q = pressTimeTotal_Q / pressCount_Q

            If pressTimeAverage_Q < 60 Then
                If pressTimeAverage_Q = 1 Then
                    ui_averagePressTime_Q.Text = pressTimeAverage_Q.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Q.Text = pressTimeAverage_Q.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Q > 60 And pressTimeAverage_Q < 3600 Then
                pressTimeTotal_Q /= 60
                If pressTimeTotal_Q = 1 Then
                    ui_averagePressTime_Q.Text = pressTimeTotal_Q.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Q.Text = pressTimeTotal_Q.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Q > 3600 Or pressTimeAverage_Q = 3600 Then
                pressTimeTotal_Q /= 3600
                If pressTimeTotal_Q = 1 Then
                    ui_averagePressTime_Q.Text = pressTimeTotal_Q.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Q.Text = pressTimeTotal_Q.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Q.Text = ((pressCount_Q / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'W
        If pressCount_W > 0 Then 'Used

            ui_Panel_W.BackColor = usedBackgroundColor
            ui_Label_W.BackColor = usedBackgroundColor
            ui_Label_W.ForeColor = usedKeyNameFontColor
            ui_totalPresses_W.BackColor = usedBackgroundColor
            ui_totalPresses_W.ForeColor = usedStatFontColor
            ui_totalPressTime_W.BackColor = usedBackgroundColor
            ui_totalPressTime_W.ForeColor = usedStatFontColor
            ui_averagePressTime_W.BackColor = usedBackgroundColor
            ui_averagePressTime_W.ForeColor = usedStatFontColor
            ui_percent_W.BackColor = usedBackgroundColor
            ui_percent_W.ForeColor = usedStatFontColor
            ui_bind_W.BackColor = usedTextboxBackgroundColor
            ui_bind_W.ForeColor = usedStatFontColor
            ui_totalPresses_W.Text = pressCount_W.ToString

            Dim tempWtime As Decimal = 0

            If pressTimeTotal_W < 60 Then
                If pressTimeTotalConverted_W = 1 Then
                    ui_totalPressTime_W.Text = pressTimeTotal_W.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_W.Text = pressTimeTotal_W.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_W > 60 And pressTimeTotal_W < 3600 Then
                tempWtime = pressTimeTotal_W / 60
                If pressTimeTotal_W = 1 Then
                    ui_totalPressTime_W.Text = tempWtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_W.Text = tempWtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_W > 3600 Or pressTimeTotal_W = 3600 Then
                tempWtime = pressTimeTotal_W / 3600
                If tempWtime = 1 Then
                    ui_totalPressTime_W.Text = tempWtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_W.Text = tempWtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_W = pressTimeTotal_W / pressCount_W

            If pressTimeAverage_W < 60 Then
                If pressTimeAverage_W = 1 Then
                    ui_averagePressTime_W.Text = pressTimeAverage_W.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_W.Text = pressTimeAverage_W.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_W > 60 And pressTimeAverage_W < 3600 Then
                pressTimeTotal_W /= 60
                If pressTimeTotal_W = 1 Then
                    ui_averagePressTime_W.Text = pressTimeTotal_W.ToString("N3") & " min"
                Else
                    ui_averagePressTime_W.Text = pressTimeTotal_W.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_W > 3600 Or pressTimeAverage_W = 3600 Then
                pressTimeTotal_W /= 3600
                If pressTimeTotal_W = 1 Then
                    ui_averagePressTime_W.Text = pressTimeTotal_W.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_W.Text = pressTimeTotal_W.ToString("N3") & " hours"
                End If
            End If

            ui_percent_W.Text = ((pressCount_W / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'E
        If pressCount_E > 0 Then 'Used

            ui_Panel_E.BackColor = usedBackgroundColor
            ui_Label_E.BackColor = usedBackgroundColor
            ui_Label_E.ForeColor = usedKeyNameFontColor
            ui_totalPresses_E.BackColor = usedBackgroundColor
            ui_totalPresses_E.ForeColor = usedStatFontColor
            ui_totalPressTime_E.BackColor = usedBackgroundColor
            ui_totalPressTime_E.ForeColor = usedStatFontColor
            ui_averagePressTime_E.BackColor = usedBackgroundColor
            ui_averagePressTime_E.ForeColor = usedStatFontColor
            ui_percent_E.BackColor = usedBackgroundColor
            ui_percent_E.ForeColor = usedStatFontColor
            ui_bind_E.BackColor = usedTextboxBackgroundColor
            ui_bind_E.ForeColor = usedStatFontColor
            ui_totalPresses_E.Text = pressCount_E.ToString

            Dim tempEtime As Decimal = 0

            If pressTimeTotal_E < 60 Then
                If pressTimeTotalConverted_E = 1 Then
                    ui_totalPressTime_E.Text = pressTimeTotal_E.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_E.Text = pressTimeTotal_E.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_E > 60 And pressTimeTotal_E < 3600 Then
                tempEtime = pressTimeTotal_E / 60
                If pressTimeTotal_E = 1 Then
                    ui_totalPressTime_E.Text = tempEtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_E.Text = tempEtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_E > 3600 Or pressTimeTotal_E = 3600 Then
                tempEtime = pressTimeTotal_E / 3600
                If tempEtime = 1 Then
                    ui_totalPressTime_E.Text = tempEtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_E.Text = tempEtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_E = pressTimeTotal_E / pressCount_E

            If pressTimeAverage_E < 60 Then
                If pressTimeAverage_E = 1 Then
                    ui_averagePressTime_E.Text = pressTimeAverage_E.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_E.Text = pressTimeAverage_E.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_E > 60 And pressTimeAverage_E < 3600 Then
                pressTimeTotal_E /= 60
                If pressTimeTotal_E = 1 Then
                    ui_averagePressTime_E.Text = pressTimeTotal_E.ToString("N3") & " min"
                Else
                    ui_averagePressTime_E.Text = pressTimeTotal_E.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_E > 3600 Or pressTimeAverage_E = 3600 Then
                pressTimeTotal_E /= 3600
                If pressTimeTotal_E = 1 Then
                    ui_averagePressTime_E.Text = pressTimeTotal_E.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_E.Text = pressTimeTotal_E.ToString("N3") & " hours"
                End If
            End If

            ui_percent_E.Text = ((pressCount_E / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'R
        If pressCount_R > 0 Then 'Used

            ui_Panel_R.BackColor = usedBackgroundColor
            ui_Label_R.BackColor = usedBackgroundColor
            ui_Label_R.ForeColor = usedKeyNameFontColor
            ui_totalPresses_R.BackColor = usedBackgroundColor
            ui_totalPresses_R.ForeColor = usedStatFontColor
            ui_totalPressTime_R.BackColor = usedBackgroundColor
            ui_totalPressTime_R.ForeColor = usedStatFontColor
            ui_averagePressTime_R.BackColor = usedBackgroundColor
            ui_averagePressTime_R.ForeColor = usedStatFontColor
            ui_percent_R.BackColor = usedBackgroundColor
            ui_percent_R.ForeColor = usedStatFontColor
            ui_bind_R.BackColor = usedTextboxBackgroundColor
            ui_bind_R.ForeColor = usedStatFontColor
            ui_totalPresses_R.Text = pressCount_R.ToString

            Dim tempRtime As Decimal = 0

            If pressTimeTotal_R < 60 Then
                If pressTimeTotalConverted_R = 1 Then
                    ui_totalPressTime_R.Text = pressTimeTotal_R.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_R.Text = pressTimeTotal_R.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_R > 60 And pressTimeTotal_R < 3600 Then
                tempRtime = pressTimeTotal_R / 60
                If pressTimeTotal_R = 1 Then
                    ui_totalPressTime_R.Text = tempRtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_R.Text = tempRtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_R > 3600 Or pressTimeTotal_R = 3600 Then
                tempRtime = pressTimeTotal_R / 3600
                If tempRtime = 1 Then
                    ui_totalPressTime_R.Text = tempRtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_R.Text = tempRtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_R = pressTimeTotal_R / pressCount_R

            If pressTimeAverage_R < 60 Then
                If pressTimeAverage_R = 1 Then
                    ui_averagePressTime_R.Text = pressTimeAverage_R.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_R.Text = pressTimeAverage_R.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_R > 60 And pressTimeAverage_R < 3600 Then
                pressTimeTotal_R /= 60
                If pressTimeTotal_R = 1 Then
                    ui_averagePressTime_R.Text = pressTimeTotal_R.ToString("N3") & " min"
                Else
                    ui_averagePressTime_R.Text = pressTimeTotal_R.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_R > 3600 Or pressTimeAverage_R = 3600 Then
                pressTimeTotal_R /= 3600
                If pressTimeTotal_R = 1 Then
                    ui_averagePressTime_R.Text = pressTimeTotal_R.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_R.Text = pressTimeTotal_R.ToString("N3") & " hours"
                End If
            End If

            ui_percent_R.Text = ((pressCount_R / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'T
        If pressCount_T > 0 Then 'Used

            ui_Panel_T.BackColor = usedBackgroundColor
            ui_Label_T.BackColor = usedBackgroundColor
            ui_Label_T.ForeColor = usedKeyNameFontColor
            ui_totalPresses_T.BackColor = usedBackgroundColor
            ui_totalPresses_T.ForeColor = usedStatFontColor
            ui_totalPressTime_T.BackColor = usedBackgroundColor
            ui_totalPressTime_T.ForeColor = usedStatFontColor
            ui_averagePressTime_T.BackColor = usedBackgroundColor
            ui_averagePressTime_T.ForeColor = usedStatFontColor
            ui_percent_T.BackColor = usedBackgroundColor
            ui_percent_T.ForeColor = usedStatFontColor
            ui_bind_T.BackColor = usedTextboxBackgroundColor
            ui_bind_T.ForeColor = usedStatFontColor
            ui_totalPresses_T.Text = pressCount_T.ToString

            Dim tempTtime As Decimal = 0

            If pressTimeTotal_T < 60 Then
                If pressTimeTotalConverted_T = 1 Then
                    ui_totalPressTime_T.Text = pressTimeTotal_T.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_T.Text = pressTimeTotal_T.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_T > 60 And pressTimeTotal_T < 3600 Then
                tempTtime = pressTimeTotal_T / 60
                If pressTimeTotal_T = 1 Then
                    ui_totalPressTime_T.Text = tempTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_T.Text = tempTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_T > 3600 Or pressTimeTotal_T = 3600 Then
                tempTtime = pressTimeTotal_T / 3600
                If tempTtime = 1 Then
                    ui_totalPressTime_T.Text = tempTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_T.Text = tempTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_T = pressTimeTotal_T / pressCount_T

            If pressTimeAverage_T < 60 Then
                If pressTimeAverage_T = 1 Then
                    ui_averagePressTime_T.Text = pressTimeAverage_T.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_T.Text = pressTimeAverage_T.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_T > 60 And pressTimeAverage_T < 3600 Then
                pressTimeTotal_T /= 60
                If pressTimeTotal_T = 1 Then
                    ui_averagePressTime_T.Text = pressTimeTotal_T.ToString("N3") & " min"
                Else
                    ui_averagePressTime_T.Text = pressTimeTotal_T.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_T > 3600 Or pressTimeAverage_T = 3600 Then
                pressTimeTotal_T /= 3600
                If pressTimeTotal_T = 1 Then
                    ui_averagePressTime_T.Text = pressTimeTotal_T.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_T.Text = pressTimeTotal_T.ToString("N3") & " hours"
                End If
            End If

            ui_percent_T.Text = ((pressCount_T / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Y
        If pressCount_Y > 0 Then 'Used

            ui_Panel_Y.BackColor = usedBackgroundColor
            ui_Label_Y.BackColor = usedBackgroundColor
            ui_Label_Y.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Y.BackColor = usedBackgroundColor
            ui_totalPresses_Y.ForeColor = usedStatFontColor
            ui_totalPressTime_Y.BackColor = usedBackgroundColor
            ui_totalPressTime_Y.ForeColor = usedStatFontColor
            ui_averagePressTime_Y.BackColor = usedBackgroundColor
            ui_averagePressTime_Y.ForeColor = usedStatFontColor
            ui_percent_Y.BackColor = usedBackgroundColor
            ui_percent_Y.ForeColor = usedStatFontColor
            ui_bind_Y.BackColor = usedTextboxBackgroundColor
            ui_bind_Y.ForeColor = usedStatFontColor
            ui_totalPresses_Y.Text = pressCount_Y.ToString

            Dim tempYtime As Decimal = 0

            If pressTimeTotal_Y < 60 Then
                If pressTimeTotalConverted_Y = 1 Then
                    ui_totalPressTime_Y.Text = pressTimeTotal_Y.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Y.Text = pressTimeTotal_Y.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Y > 60 And pressTimeTotal_Y < 3600 Then
                tempYtime = pressTimeTotal_Y / 60
                If pressTimeTotal_Y = 1 Then
                    ui_totalPressTime_Y.Text = tempYtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Y.Text = tempYtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Y > 3600 Or pressTimeTotal_Y = 3600 Then
                tempYtime = pressTimeTotal_Y / 3600
                If tempYtime = 1 Then
                    ui_totalPressTime_Y.Text = tempYtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Y.Text = tempYtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Y = pressTimeTotal_Y / pressCount_Y

            If pressTimeAverage_Y < 60 Then
                If pressTimeAverage_Y = 1 Then
                    ui_averagePressTime_Y.Text = pressTimeAverage_Y.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Y.Text = pressTimeAverage_Y.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Y > 60 And pressTimeAverage_Y < 3600 Then
                pressTimeTotal_Y /= 60
                If pressTimeTotal_Y = 1 Then
                    ui_averagePressTime_Y.Text = pressTimeTotal_Y.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Y.Text = pressTimeTotal_Y.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Y > 3600 Or pressTimeAverage_Y = 3600 Then
                pressTimeTotal_Y /= 3600
                If pressTimeTotal_Y = 1 Then
                    ui_averagePressTime_Y.Text = pressTimeTotal_Y.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Y.Text = pressTimeTotal_Y.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Y.Text = ((pressCount_Y / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'U
        If pressCount_U > 0 Then 'Used

            ui_Panel_U.BackColor = usedBackgroundColor
            ui_Label_U.BackColor = usedBackgroundColor
            ui_Label_U.ForeColor = usedKeyNameFontColor
            ui_totalPresses_U.BackColor = usedBackgroundColor
            ui_totalPresses_U.ForeColor = usedStatFontColor
            ui_totalPressTime_U.BackColor = usedBackgroundColor
            ui_totalPressTime_U.ForeColor = usedStatFontColor
            ui_averagePressTime_U.BackColor = usedBackgroundColor
            ui_averagePressTime_U.ForeColor = usedStatFontColor
            ui_percent_U.BackColor = usedBackgroundColor
            ui_percent_U.ForeColor = usedStatFontColor
            ui_bind_U.BackColor = usedTextboxBackgroundColor
            ui_bind_U.ForeColor = usedStatFontColor
            ui_totalPresses_U.Text = pressCount_U.ToString

            Dim tempUtime As Decimal = 0

            If pressTimeTotal_U < 60 Then
                If pressTimeTotalConverted_U = 1 Then
                    ui_totalPressTime_U.Text = pressTimeTotal_U.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_U.Text = pressTimeTotal_U.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_U > 60 And pressTimeTotal_U < 3600 Then
                tempUtime = pressTimeTotal_U / 60
                If pressTimeTotal_U = 1 Then
                    ui_totalPressTime_U.Text = tempUtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_U.Text = tempUtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_U > 3600 Or pressTimeTotal_U = 3600 Then
                tempUtime = pressTimeTotal_U / 3600
                If tempUtime = 1 Then
                    ui_totalPressTime_U.Text = tempUtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_U.Text = tempUtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_U = pressTimeTotal_U / pressCount_U

            If pressTimeAverage_U < 60 Then
                If pressTimeAverage_U = 1 Then
                    ui_averagePressTime_U.Text = pressTimeAverage_U.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_U.Text = pressTimeAverage_U.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_U > 60 And pressTimeAverage_U < 3600 Then
                pressTimeTotal_U /= 60
                If pressTimeTotal_U = 1 Then
                    ui_averagePressTime_U.Text = pressTimeTotal_U.ToString("N3") & " min"
                Else
                    ui_averagePressTime_U.Text = pressTimeTotal_U.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_U > 3600 Or pressTimeAverage_U = 3600 Then
                pressTimeTotal_U /= 3600
                If pressTimeTotal_U = 1 Then
                    ui_averagePressTime_U.Text = pressTimeTotal_U.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_U.Text = pressTimeTotal_U.ToString("N3") & " hours"
                End If
            End If

            ui_percent_U.Text = ((pressCount_U / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'I
        If pressCount_I > 0 Then 'Used

            ui_Panel_I.BackColor = usedBackgroundColor
            ui_Label_I.BackColor = usedBackgroundColor
            ui_Label_I.ForeColor = usedKeyNameFontColor
            ui_totalPresses_I.BackColor = usedBackgroundColor
            ui_totalPresses_I.ForeColor = usedStatFontColor
            ui_totalPressTime_I.BackColor = usedBackgroundColor
            ui_totalPressTime_I.ForeColor = usedStatFontColor
            ui_averagePressTime_I.BackColor = usedBackgroundColor
            ui_averagePressTime_I.ForeColor = usedStatFontColor
            ui_percent_I.BackColor = usedBackgroundColor
            ui_percent_I.ForeColor = usedStatFontColor
            ui_bind_I.BackColor = usedTextboxBackgroundColor
            ui_bind_I.ForeColor = usedStatFontColor
            ui_totalPresses_I.Text = pressCount_I.ToString

            Dim tempItime As Decimal = 0

            If pressTimeTotal_I < 60 Then
                If pressTimeTotalConverted_I = 1 Then
                    ui_totalPressTime_I.Text = pressTimeTotal_I.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_I.Text = pressTimeTotal_I.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_I > 60 And pressTimeTotal_I < 3600 Then
                tempItime = pressTimeTotal_I / 60
                If pressTimeTotal_I = 1 Then
                    ui_totalPressTime_I.Text = tempItime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_I.Text = tempItime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_I > 3600 Or pressTimeTotal_I = 3600 Then
                tempItime = pressTimeTotal_I / 3600
                If tempItime = 1 Then
                    ui_totalPressTime_I.Text = tempItime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_I.Text = tempItime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_I = pressTimeTotal_I / pressCount_I

            If pressTimeAverage_I < 60 Then
                If pressTimeAverage_I = 1 Then
                    ui_averagePressTime_I.Text = pressTimeAverage_I.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_I.Text = pressTimeAverage_I.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_I > 60 And pressTimeAverage_I < 3600 Then
                pressTimeTotal_I /= 60
                If pressTimeTotal_I = 1 Then
                    ui_averagePressTime_I.Text = pressTimeTotal_I.ToString("N3") & " min"
                Else
                    ui_averagePressTime_I.Text = pressTimeTotal_I.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_I > 3600 Or pressTimeAverage_I = 3600 Then
                pressTimeTotal_I /= 3600
                If pressTimeTotal_I = 1 Then
                    ui_averagePressTime_I.Text = pressTimeTotal_I.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_I.Text = pressTimeTotal_I.ToString("N3") & " hours"
                End If
            End If

            ui_percent_I.Text = ((pressCount_I / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'O
        If pressCount_O > 0 Then 'Used

            ui_Panel_O.BackColor = usedBackgroundColor
            ui_Label_O.BackColor = usedBackgroundColor
            ui_Label_O.ForeColor = usedKeyNameFontColor
            ui_totalPresses_O.BackColor = usedBackgroundColor
            ui_totalPresses_O.ForeColor = usedStatFontColor
            ui_totalPressTime_O.BackColor = usedBackgroundColor
            ui_totalPressTime_O.ForeColor = usedStatFontColor
            ui_averagePressTime_O.BackColor = usedBackgroundColor
            ui_averagePressTime_O.ForeColor = usedStatFontColor
            ui_percent_O.BackColor = usedBackgroundColor
            ui_percent_O.ForeColor = usedStatFontColor
            ui_bind_O.BackColor = usedTextboxBackgroundColor
            ui_bind_O.ForeColor = usedStatFontColor
            ui_totalPresses_O.Text = pressCount_O.ToString

            Dim tempOtime As Decimal = 0

            If pressTimeTotal_O < 60 Then
                If pressTimeTotalConverted_O = 1 Then
                    ui_totalPressTime_O.Text = pressTimeTotal_O.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_O.Text = pressTimeTotal_O.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_O > 60 And pressTimeTotal_O < 3600 Then
                tempOtime = pressTimeTotal_O / 60
                If pressTimeTotal_O = 1 Then
                    ui_totalPressTime_O.Text = tempOtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_O.Text = tempOtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_O > 3600 Or pressTimeTotal_O = 3600 Then
                tempOtime = pressTimeTotal_O / 3600
                If tempOtime = 1 Then
                    ui_totalPressTime_O.Text = tempOtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_O.Text = tempOtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_O = pressTimeTotal_O / pressCount_O

            If pressTimeAverage_O < 60 Then
                If pressTimeAverage_O = 1 Then
                    ui_averagePressTime_O.Text = pressTimeAverage_O.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_O.Text = pressTimeAverage_O.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_O > 60 And pressTimeAverage_O < 3600 Then
                pressTimeTotal_O /= 60
                If pressTimeTotal_O = 1 Then
                    ui_averagePressTime_O.Text = pressTimeTotal_O.ToString("N3") & " min"
                Else
                    ui_averagePressTime_O.Text = pressTimeTotal_O.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_O > 3600 Or pressTimeAverage_O = 3600 Then
                pressTimeTotal_O /= 3600
                If pressTimeTotal_O = 1 Then
                    ui_averagePressTime_O.Text = pressTimeTotal_O.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_O.Text = pressTimeTotal_O.ToString("N3") & " hours"
                End If
            End If

            ui_percent_O.Text = ((pressCount_O / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'P
        If pressCount_P > 0 Then 'Used

            ui_Panel_P.BackColor = usedBackgroundColor
            ui_Label_P.BackColor = usedBackgroundColor
            ui_Label_P.ForeColor = usedKeyNameFontColor
            ui_totalPresses_P.BackColor = usedBackgroundColor
            ui_totalPresses_P.ForeColor = usedStatFontColor
            ui_totalPressTime_P.BackColor = usedBackgroundColor
            ui_totalPressTime_P.ForeColor = usedStatFontColor
            ui_averagePressTime_P.BackColor = usedBackgroundColor
            ui_averagePressTime_P.ForeColor = usedStatFontColor
            ui_percent_P.BackColor = usedBackgroundColor
            ui_percent_P.ForeColor = usedStatFontColor
            ui_bind_P.BackColor = usedTextboxBackgroundColor
            ui_bind_P.ForeColor = usedStatFontColor
            ui_totalPresses_P.Text = pressCount_P.ToString

            Dim tempPtime As Decimal = 0

            If pressTimeTotal_P < 60 Then
                If pressTimeTotalConverted_P = 1 Then
                    ui_totalPressTime_P.Text = pressTimeTotal_P.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_P.Text = pressTimeTotal_P.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_P > 60 And pressTimeTotal_P < 3600 Then
                tempPtime = pressTimeTotal_P / 60
                If pressTimeTotal_P = 1 Then
                    ui_totalPressTime_P.Text = tempPtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_P.Text = tempPtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_P > 3600 Or pressTimeTotal_P = 3600 Then
                tempPtime = pressTimeTotal_P / 3600
                If tempPtime = 1 Then
                    ui_totalPressTime_P.Text = tempPtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_P.Text = tempPtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_P = pressTimeTotal_P / pressCount_P

            If pressTimeAverage_P < 60 Then
                If pressTimeAverage_P = 1 Then
                    ui_averagePressTime_P.Text = pressTimeAverage_P.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_P.Text = pressTimeAverage_P.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_P > 60 And pressTimeAverage_P < 3600 Then
                pressTimeTotal_P /= 60
                If pressTimeTotal_P = 1 Then
                    ui_averagePressTime_P.Text = pressTimeTotal_P.ToString("N3") & " min"
                Else
                    ui_averagePressTime_P.Text = pressTimeTotal_P.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_P > 3600 Or pressTimeAverage_P = 3600 Then
                pressTimeTotal_P /= 3600
                If pressTimeTotal_P = 1 Then
                    ui_averagePressTime_P.Text = pressTimeTotal_P.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_P.Text = pressTimeTotal_P.ToString("N3") & " hours"
                End If
            End If

            ui_percent_P.Text = ((pressCount_P / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LBracket
        If pressCount_LBracket > 0 Then 'Used

            ui_Panel_LBracket.BackColor = usedBackgroundColor
            ui_Label_LBracket.BackColor = usedBackgroundColor
            ui_Label_LBracket.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LBracket.BackColor = usedBackgroundColor
            ui_totalPresses_LBracket.ForeColor = usedStatFontColor
            ui_totalPressTime_LBRacket.BackColor = usedBackgroundColor
            ui_totalPressTime_LBRacket.ForeColor = usedStatFontColor
            ui_averagePressTime_LBracket.BackColor = usedBackgroundColor
            ui_averagePressTime_LBracket.ForeColor = usedStatFontColor
            ui_percent_LBracket.BackColor = usedBackgroundColor
            ui_percent_LBracket.ForeColor = usedStatFontColor
            ui_bind_LBracket.BackColor = usedTextboxBackgroundColor
            ui_bind_LBracket.ForeColor = usedStatFontColor
            ui_totalPresses_LBracket.Text = pressCount_LBracket.ToString

            Dim tempLBrackettime As Decimal = 0

            If pressTimeTotal_LBracket < 60 Then
                If pressTimeTotalConverted_LBracket = 1 Then
                    ui_totalPressTime_LBRacket.Text = pressTimeTotal_LBracket.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LBRacket.Text = pressTimeTotal_LBracket.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LBracket > 60 And pressTimeTotal_LBracket < 3600 Then
                tempLBrackettime = pressTimeTotal_LBracket / 60
                If pressTimeTotal_LBracket = 1 Then
                    ui_totalPressTime_LBRacket.Text = tempLBrackettime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LBRacket.Text = tempLBrackettime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LBracket > 3600 Or pressTimeTotal_LBracket = 3600 Then
                tempLBrackettime = pressTimeTotal_LBracket / 3600
                If tempLBrackettime = 1 Then
                    ui_totalPressTime_LBRacket.Text = tempLBrackettime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LBRacket.Text = tempLBrackettime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LBracket = pressTimeTotal_LBracket / pressCount_LBracket

            If pressTimeAverage_LBracket < 60 Then
                If pressTimeAverage_LBracket = 1 Then
                    ui_averagePressTime_LBracket.Text = pressTimeAverage_LBracket.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LBracket.Text = pressTimeAverage_LBracket.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LBracket > 60 And pressTimeAverage_LBracket < 3600 Then
                pressTimeTotal_LBracket /= 60
                If pressTimeTotal_LBracket = 1 Then
                    ui_averagePressTime_LBracket.Text = pressTimeTotal_LBracket.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LBracket.Text = pressTimeTotal_LBracket.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LBracket > 3600 Or pressTimeAverage_LBracket = 3600 Then
                pressTimeTotal_LBracket /= 3600
                If pressTimeTotal_LBracket = 1 Then
                    ui_averagePressTime_LBracket.Text = pressTimeTotal_LBracket.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LBracket.Text = pressTimeTotal_LBracket.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LBracket.Text = ((pressCount_LBracket / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'RBracket
        If pressCount_RBracket > 0 Then 'Used

            ui_Panel_RBracket.BackColor = usedBackgroundColor
            ui_Label_RBRacket.BackColor = usedBackgroundColor
            ui_Label_RBRacket.ForeColor = usedKeyNameFontColor
            ui_totalPresses_RBracket.BackColor = usedBackgroundColor
            ui_totalPresses_RBracket.ForeColor = usedStatFontColor
            ui_totalPressTime_RBracket.BackColor = usedBackgroundColor
            ui_totalPressTime_RBracket.ForeColor = usedStatFontColor
            ui_averagePressTime_RBracket.BackColor = usedBackgroundColor
            ui_averagePressTime_RBracket.ForeColor = usedStatFontColor
            ui_percent_RBracket.BackColor = usedBackgroundColor
            ui_percent_RBracket.ForeColor = usedStatFontColor
            ui_bind_RBracket.BackColor = usedTextboxBackgroundColor
            ui_bind_RBracket.ForeColor = usedStatFontColor
            ui_totalPresses_RBracket.Text = pressCount_RBracket.ToString

            Dim tempRBrackettime As Decimal = 0

            If pressTimeTotal_RBracket < 60 Then
                If pressTimeTotalConverted_RBracket = 1 Then
                    ui_totalPressTime_RBracket.Text = pressTimeTotal_RBracket.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_RBracket.Text = pressTimeTotal_RBracket.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_RBracket > 60 And pressTimeTotal_RBracket < 3600 Then
                tempRBrackettime = pressTimeTotal_RBracket / 60
                If pressTimeTotal_RBracket = 1 Then
                    ui_totalPressTime_RBracket.Text = tempRBrackettime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_RBracket.Text = tempRBrackettime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_RBracket > 3600 Or pressTimeTotal_RBracket = 3600 Then
                tempRBrackettime = pressTimeTotal_RBracket / 3600
                If tempRBrackettime = 1 Then
                    ui_totalPressTime_RBracket.Text = tempRBrackettime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_RBracket.Text = tempRBrackettime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_RBracket = pressTimeTotal_RBracket / pressCount_RBracket

            If pressTimeAverage_RBracket < 60 Then
                If pressTimeAverage_RBracket = 1 Then
                    ui_averagePressTime_RBracket.Text = pressTimeAverage_RBracket.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_RBracket.Text = pressTimeAverage_RBracket.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_RBracket > 60 And pressTimeAverage_RBracket < 3600 Then
                pressTimeTotal_RBracket /= 60
                If pressTimeTotal_RBracket = 1 Then
                    ui_averagePressTime_RBracket.Text = pressTimeTotal_RBracket.ToString("N3") & " min"
                Else
                    ui_averagePressTime_RBracket.Text = pressTimeTotal_RBracket.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_RBracket > 3600 Or pressTimeAverage_RBracket = 3600 Then
                pressTimeTotal_RBracket /= 3600
                If pressTimeTotal_RBracket = 1 Then
                    ui_averagePressTime_RBracket.Text = pressTimeTotal_RBracket.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_RBracket.Text = pressTimeTotal_RBracket.ToString("N3") & " hours"
                End If
            End If

            ui_percent_RBracket.Text = ((pressCount_RBracket / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Slash
        If pressCount_Slash > 0 Then 'Used

            ui_Panel_Slash.BackColor = usedBackgroundColor
            ui_Label_Slash.BackColor = usedBackgroundColor
            ui_Label_Slash.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Slash.BackColor = usedBackgroundColor
            ui_totalPresses_Slash.ForeColor = usedStatFontColor
            ui_totalPressTime_Slash.BackColor = usedBackgroundColor
            ui_totalPressTime_Slash.ForeColor = usedStatFontColor
            ui_averagePressTime_Slash.BackColor = usedBackgroundColor
            ui_averagePressTime_Slash.ForeColor = usedStatFontColor
            ui_percent_Slash.BackColor = usedBackgroundColor
            ui_percent_Slash.ForeColor = usedStatFontColor
            ui_bind_Slash.BackColor = usedTextboxBackgroundColor
            ui_bind_slash.ForeColor = usedStatFontColor
            ui_totalPresses_Slash.Text = pressCount_Slash.ToString

            Dim tempSlashtime As Decimal = 0

            If pressTimeTotal_Slash < 60 Then
                If pressTimeTotalConverted_Slash = 1 Then
                    ui_totalPressTime_Slash.Text = pressTimeTotal_Slash.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Slash.Text = pressTimeTotal_Slash.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Slash > 60 And pressTimeTotal_Slash < 3600 Then
                tempSlashtime = pressTimeTotal_Slash / 60
                If pressTimeTotal_Slash = 1 Then
                    ui_totalPressTime_Slash.Text = tempSlashtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Slash.Text = tempSlashtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Slash > 3600 Or pressTimeTotal_Slash = 3600 Then
                tempSlashtime = pressTimeTotal_Slash / 3600
                If tempSlashtime = 1 Then
                    ui_totalPressTime_Slash.Text = tempSlashtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Slash.Text = tempSlashtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Slash = pressTimeTotal_Slash / pressCount_Slash

            If pressTimeAverage_Slash < 60 Then
                If pressTimeAverage_Slash = 1 Then
                    ui_averagePressTime_Slash.Text = pressTimeAverage_Slash.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Slash.Text = pressTimeAverage_Slash.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Slash > 60 And pressTimeAverage_Slash < 3600 Then
                pressTimeTotal_Slash /= 60
                If pressTimeTotal_Slash = 1 Then
                    ui_averagePressTime_Slash.Text = pressTimeTotal_Slash.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Slash.Text = pressTimeTotal_Slash.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Slash > 3600 Or pressTimeAverage_Slash = 3600 Then
                pressTimeTotal_Slash /= 3600
                If pressTimeTotal_Slash = 1 Then
                    ui_averagePressTime_Slash.Text = pressTimeTotal_Slash.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Slash.Text = pressTimeTotal_Slash.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Slash.Text = ((pressCount_Slash / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

            ui_Panel_Slash.BackColor = unusedKeyBackgroundColor
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
            ui_bind_Slash.BackColor = unusedTextboxBackgroundColor
            ui_bind_Slash.ForeColor = unusedStatFontColor

        End If

        'Delete
        If pressCount_Delete > 0 Then 'Used

            ui_Panel_Delete.BackColor = usedBackgroundColor
            ui_Label_Delete.BackColor = usedBackgroundColor
            ui_Label_Delete.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Delete.BackColor = usedBackgroundColor
            ui_totalPresses_Delete.ForeColor = usedStatFontColor
            ui_totalPressTime_Delete.BackColor = usedBackgroundColor
            ui_totalPressTime_Delete.ForeColor = usedStatFontColor
            ui_averagePressTime_Delete.BackColor = usedBackgroundColor
            ui_averagePressTime_Delete.ForeColor = usedStatFontColor
            ui_percent_Delete.BackColor = usedBackgroundColor
            ui_percent_Delete.ForeColor = usedStatFontColor
            ui_bind_Delete.BackColor = usedTextboxBackgroundColor
            ui_bind_Delete.ForeColor = usedStatFontColor
            ui_totalPresses_Delete.Text = pressCount_Delete.ToString

            Dim tempDeletetime As Decimal = 0

            If pressTimeTotal_Delete < 60 Then
                If pressTimeTotalConverted_Delete = 1 Then
                    ui_totalPressTime_Delete.Text = pressTimeTotal_Delete.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Delete.Text = pressTimeTotal_Delete.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Delete > 60 And pressTimeTotal_Delete < 3600 Then
                tempDeletetime = pressTimeTotal_Delete / 60
                If pressTimeTotal_Delete = 1 Then
                    ui_totalPressTime_Delete.Text = tempDeletetime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Delete.Text = tempDeletetime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Delete > 3600 Or pressTimeTotal_Delete = 3600 Then
                tempDeletetime = pressTimeTotal_Delete / 3600
                If tempDeletetime = 1 Then
                    ui_totalPressTime_Delete.Text = tempDeletetime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Delete.Text = tempDeletetime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Delete = pressTimeTotal_Delete / pressCount_Delete

            If pressTimeAverage_Delete < 60 Then
                If pressTimeAverage_Delete = 1 Then
                    ui_averagePressTime_Delete.Text = pressTimeAverage_Delete.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Delete.Text = pressTimeAverage_Delete.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Delete > 60 And pressTimeAverage_Delete < 3600 Then
                pressTimeTotal_Delete /= 60
                If pressTimeTotal_Delete = 1 Then
                    ui_averagePressTime_Delete.Text = pressTimeTotal_Delete.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Delete.Text = pressTimeTotal_Delete.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Delete > 3600 Or pressTimeAverage_Delete = 3600 Then
                pressTimeTotal_Delete /= 3600
                If pressTimeTotal_Delete = 1 Then
                    ui_averagePressTime_Delete.Text = pressTimeTotal_Delete.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Delete.Text = pressTimeTotal_Delete.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Delete.Text = ((pressCount_Delete / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'End
        If pressCount_End > 0 Then 'Used

            ui_Panel_End.BackColor = usedBackgroundColor
            ui_Label_End.BackColor = usedBackgroundColor
            ui_Label_End.ForeColor = usedKeyNameFontColor
            ui_totalPresses_End.BackColor = usedBackgroundColor
            ui_totalPresses_End.ForeColor = usedStatFontColor
            ui_totalPressTime_End.BackColor = usedBackgroundColor
            ui_totalPressTime_End.ForeColor = usedStatFontColor
            ui_averagePressTime_End.BackColor = usedBackgroundColor
            ui_averagePressTime_End.ForeColor = usedStatFontColor
            ui.BackColor = usedBackgroundColor
            ui.ForeColor = usedStatFontColor
            ui_bind_End.BackColor = usedTextboxBackgroundColor
            ui_bind_End.ForeColor = usedStatFontColor
            ui_totalPresses_End.Text = pressCount_End.ToString

            Dim tempEndtime As Decimal = 0

            If pressTimeTotal_End < 60 Then
                If pressTimeTotalConverted_End = 1 Then
                    ui_totalPressTime_End.Text = pressTimeTotal_End.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_End.Text = pressTimeTotal_End.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_End > 60 And pressTimeTotal_End < 3600 Then
                tempEndtime = pressTimeTotal_End / 60
                If pressTimeTotal_End = 1 Then
                    ui_totalPressTime_End.Text = tempEndtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_End.Text = tempEndtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_End > 3600 Or pressTimeTotal_End = 3600 Then
                tempEndtime = pressTimeTotal_End / 3600
                If tempEndtime = 1 Then
                    ui_totalPressTime_End.Text = tempEndtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_End.Text = tempEndtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_End = pressTimeTotal_End / pressCount_End

            If pressTimeAverage_End < 60 Then
                If pressTimeAverage_End = 1 Then
                    ui_averagePressTime_End.Text = pressTimeAverage_End.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_End.Text = pressTimeAverage_End.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_End > 60 And pressTimeAverage_End < 3600 Then
                pressTimeTotal_End /= 60
                If pressTimeTotal_End = 1 Then
                    ui_averagePressTime_End.Text = pressTimeTotal_End.ToString("N3") & " min"
                Else
                    ui_averagePressTime_End.Text = pressTimeTotal_End.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_End > 3600 Or pressTimeAverage_End = 3600 Then
                pressTimeTotal_End /= 3600
                If pressTimeTotal_End = 1 Then
                    ui_averagePressTime_End.Text = pressTimeTotal_End.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_End.Text = pressTimeTotal_End.ToString("N3") & " hours"
                End If
            End If

            ui.Text = ((pressCount_End / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'PgDn
        If pressCount_PgDn > 0 Then 'Used

            ui_Panel_PgDn.BackColor = usedBackgroundColor
            ui_Label_PgDn.BackColor = usedBackgroundColor
            ui_Label_PgDn.ForeColor = usedKeyNameFontColor
            ui_totalPresses_PgDn.BackColor = usedBackgroundColor
            ui_totalPresses_PgDn.ForeColor = usedStatFontColor
            ui_totalPressTime_PgDn.BackColor = usedBackgroundColor
            ui_totalPressTime_PgDn.ForeColor = usedStatFontColor
            ui_averagePressTime_PgDn.BackColor = usedBackgroundColor
            ui_averagePressTime_PgDn.ForeColor = usedStatFontColor
            ui_percent_PgDn.BackColor = usedBackgroundColor
            ui_percent_PgDn.ForeColor = usedStatFontColor
            ui_bind_PgDn.BackColor = usedTextboxBackgroundColor
            ui_bind_PgDn.ForeColor = usedStatFontColor
            ui_totalPresses_PgDn.Text = pressCount_PgDn.ToString

            Dim tempPgDntime As Decimal = 0

            If pressTimeTotal_PgDn < 60 Then
                If pressTimeTotalConverted_PgDn = 1 Then
                    ui_totalPressTime_PgDn.Text = pressTimeTotal_PgDn.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_PgDn.Text = pressTimeTotal_PgDn.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_PgDn > 60 And pressTimeTotal_PgDn < 3600 Then
                tempPgDntime = pressTimeTotal_PgDn / 60
                If pressTimeTotal_PgDn = 1 Then
                    ui_totalPressTime_PgDn.Text = tempPgDntime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_PgDn.Text = tempPgDntime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_PgDn > 3600 Or pressTimeTotal_PgDn = 3600 Then
                tempPgDntime = pressTimeTotal_PgDn / 3600
                If tempPgDntime = 1 Then
                    ui_totalPressTime_PgDn.Text = tempPgDntime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_PgDn.Text = tempPgDntime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_PgDn = pressTimeTotal_PgDn / pressCount_PgDn

            If pressTimeAverage_PgDn < 60 Then
                If pressTimeAverage_PgDn = 1 Then
                    ui_averagePressTime_PgDn.Text = pressTimeAverage_PgDn.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_PgDn.Text = pressTimeAverage_PgDn.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_PgDn > 60 And pressTimeAverage_PgDn < 3600 Then
                pressTimeTotal_PgDn /= 60
                If pressTimeTotal_PgDn = 1 Then
                    ui_averagePressTime_PgDn.Text = pressTimeTotal_PgDn.ToString("N3") & " min"
                Else
                    ui_averagePressTime_PgDn.Text = pressTimeTotal_PgDn.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_PgDn > 3600 Or pressTimeAverage_PgDn = 3600 Then
                pressTimeTotal_PgDn /= 3600
                If pressTimeTotal_PgDn = 1 Then
                    ui_averagePressTime_PgDn.Text = pressTimeTotal_PgDn.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_PgDn.Text = pressTimeTotal_PgDn.ToString("N3") & " hours"
                End If
            End If

            ui_percent_PgDn.Text = ((pressCount_PgDn / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num7
        If pressCount_Num7 > 0 Then 'Used

            ui_Panel_Num7.BackColor = usedBackgroundColor
            ui_Label_Num7.BackColor = usedBackgroundColor
            ui_Label_Num7.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num7.BackColor = usedBackgroundColor
            ui_totalPresses_Num7.ForeColor = usedStatFontColor
            ui_totalPressTime_Num7.BackColor = usedBackgroundColor
            ui_totalPressTime_Num7.ForeColor = usedStatFontColor
            ui_averagePressTime_Num7.BackColor = usedBackgroundColor
            ui_averagePressTime_Num7.ForeColor = usedStatFontColor
            ui_percent_Num7.BackColor = usedBackgroundColor
            ui_percent_Num7.ForeColor = usedStatFontColor
            ui_bind_Num7.BackColor = usedTextboxBackgroundColor
            ui_bind_Num7.ForeColor = usedStatFontColor
            ui_totalPresses_Num7.Text = pressCount_Num7.ToString

            Dim tempNum7time As Decimal = 0

            If pressTimeTotal_Num7 < 60 Then
                If pressTimeTotalConverted_Num7 = 1 Then
                    ui_totalPressTime_Num7.Text = pressTimeTotal_Num7.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num7.Text = pressTimeTotal_Num7.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num7 > 60 And pressTimeTotal_Num7 < 3600 Then
                tempNum7time = pressTimeTotal_Num7 / 60
                If pressTimeTotal_Num7 = 1 Then
                    ui_totalPressTime_Num7.Text = tempNum7time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num7.Text = tempNum7time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num7 > 3600 Or pressTimeTotal_Num7 = 3600 Then
                tempNum7time = pressTimeTotal_Num7 / 3600
                If tempNum7time = 1 Then
                    ui_totalPressTime_Num7.Text = tempNum7time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num7.Text = tempNum7time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num7 = pressTimeTotal_Num7 / pressCount_Num7

            If pressTimeAverage_Num7 < 60 Then
                If pressTimeAverage_Num7 = 1 Then
                    ui_averagePressTime_Num7.Text = pressTimeAverage_Num7.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num7.Text = pressTimeAverage_Num7.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num7 > 60 And pressTimeAverage_Num7 < 3600 Then
                pressTimeTotal_Num7 /= 60
                If pressTimeTotal_Num7 = 1 Then
                    ui_averagePressTime_Num7.Text = pressTimeTotal_Num7.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num7.Text = pressTimeTotal_Num7.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num7 > 3600 Or pressTimeAverage_Num7 = 3600 Then
                pressTimeTotal_Num7 /= 3600
                If pressTimeTotal_Num7 = 1 Then
                    ui_averagePressTime_Num7.Text = pressTimeTotal_Num7.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num7.Text = pressTimeTotal_Num7.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num7.Text = ((pressCount_Num7 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num8
        If pressCount_Num8 > 0 Then 'Used

            ui_Panel_Num8.BackColor = usedBackgroundColor
            ui_Label_Num8.BackColor = usedBackgroundColor
            ui_Label_Num8.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num8.BackColor = usedBackgroundColor
            ui_totalPresses_Num8.ForeColor = usedStatFontColor
            ui_totalPressTime_Num8.BackColor = usedBackgroundColor
            ui_totalPressTime_Num8.ForeColor = usedStatFontColor
            ui_averagePressTime_Num8.BackColor = usedBackgroundColor
            ui_averagePressTime_Num8.ForeColor = usedStatFontColor
            ui_percent_Num8.BackColor = usedBackgroundColor
            ui_percent_Num8.ForeColor = usedStatFontColor
            ui_bind_Num8.BackColor = usedTextboxBackgroundColor
            ui_bind_Num8.ForeColor = usedStatFontColor
            ui_totalPresses_Num8.Text = pressCount_Num8.ToString

            Dim tempNum8time As Decimal = 0

            If pressTimeTotal_Num8 < 60 Then
                If pressTimeTotalConverted_Num8 = 1 Then
                    ui_totalPressTime_Num8.Text = pressTimeTotal_Num8.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num8.Text = pressTimeTotal_Num8.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num8 > 60 And pressTimeTotal_Num8 < 3600 Then
                tempNum8time = pressTimeTotal_Num8 / 60
                If pressTimeTotal_Num8 = 1 Then
                    ui_totalPressTime_Num8.Text = tempNum8time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num8.Text = tempNum8time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num8 > 3600 Or pressTimeTotal_Num8 = 3600 Then
                tempNum8time = pressTimeTotal_Num8 / 3600
                If tempNum8time = 1 Then
                    ui_totalPressTime_Num8.Text = tempNum8time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num8.Text = tempNum8time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num8 = pressTimeTotal_Num8 / pressCount_Num8

            If pressTimeAverage_Num8 < 60 Then
                If pressTimeAverage_Num8 = 1 Then
                    ui_averagePressTime_Num8.Text = pressTimeAverage_Num8.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num8.Text = pressTimeAverage_Num8.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num8 > 60 And pressTimeAverage_Num8 < 3600 Then
                pressTimeTotal_Num8 /= 60
                If pressTimeTotal_Num8 = 1 Then
                    ui_averagePressTime_Num8.Text = pressTimeTotal_Num8.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num8.Text = pressTimeTotal_Num8.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num8 > 3600 Or pressTimeAverage_Num8 = 3600 Then
                pressTimeTotal_Num8 /= 3600
                If pressTimeTotal_Num8 = 1 Then
                    ui_averagePressTime_Num8.Text = pressTimeTotal_Num8.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num8.Text = pressTimeTotal_Num8.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num8.Text = ((pressCount_Num8 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num9
        If pressCount_Num9 > 0 Then 'Used

            ui_Panel_Num9.BackColor = usedBackgroundColor
            ui_Label_Num9.BackColor = usedBackgroundColor
            ui_Label_Num9.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num9.BackColor = usedBackgroundColor
            ui_totalPresses_Num9.ForeColor = usedStatFontColor
            ui_totalPressTime_Num9.BackColor = usedBackgroundColor
            ui_totalPressTime_Num9.ForeColor = usedStatFontColor
            ui_averagePressTime_Num9.BackColor = usedBackgroundColor
            ui_averagePressTime_Num9.ForeColor = usedStatFontColor
            ui_percent_Num9.BackColor = usedBackgroundColor
            ui_percent_Num9.ForeColor = usedStatFontColor
            ui_bind_Num9.BackColor = usedTextboxBackgroundColor
            ui_bind_Num9.ForeColor = usedStatFontColor
            ui_totalPresses_Num9.Text = pressCount_Num9.ToString

            Dim tempNum9time As Decimal = 0

            If pressTimeTotal_Num9 < 60 Then
                If pressTimeTotalConverted_Num9 = 1 Then
                    ui_totalPressTime_Num9.Text = pressTimeTotal_Num9.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num9.Text = pressTimeTotal_Num9.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num9 > 60 And pressTimeTotal_Num9 < 3600 Then
                tempNum9time = pressTimeTotal_Num9 / 60
                If pressTimeTotal_Num9 = 1 Then
                    ui_totalPressTime_Num9.Text = tempNum9time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num9.Text = tempNum9time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num9 > 3600 Or pressTimeTotal_Num9 = 3600 Then
                tempNum9time = pressTimeTotal_Num9 / 3600
                If tempNum9time = 1 Then
                    ui_totalPressTime_Num9.Text = tempNum9time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num9.Text = tempNum9time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num9 = pressTimeTotal_Num9 / pressCount_Num9

            If pressTimeAverage_Num9 < 60 Then
                If pressTimeAverage_Num9 = 1 Then
                    ui_averagePressTime_Num9.Text = pressTimeAverage_Num9.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num9.Text = pressTimeAverage_Num9.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num9 > 60 And pressTimeAverage_Num9 < 3600 Then
                pressTimeTotal_Num9 /= 60
                If pressTimeTotal_Num9 = 1 Then
                    ui_averagePressTime_Num9.Text = pressTimeTotal_Num9.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num9.Text = pressTimeTotal_Num9.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num9 > 3600 Or pressTimeAverage_Num9 = 3600 Then
                pressTimeTotal_Num9 /= 3600
                If pressTimeTotal_Num9 = 1 Then
                    ui_averagePressTime_Num9.Text = pressTimeTotal_Num9.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num9.Text = pressTimeTotal_Num9.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num9.Text = ((pressCount_Num9 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'CAPS
        If pressCount_CAPS > 0 Then 'Used

            ui_Panel_CAPS.BackColor = usedBackgroundColor
            ui_Label_CAPS.BackColor = usedBackgroundColor
            ui_Label_CAPS.ForeColor = usedKeyNameFontColor
            ui_totalPresses_CAPS.BackColor = usedBackgroundColor
            ui_totalPresses_CAPS.ForeColor = usedStatFontColor
            ui_totalPressTime_CAPS.BackColor = usedBackgroundColor
            ui_totalPressTime_CAPS.ForeColor = usedStatFontColor
            ui_averagePressTime_CAPS.BackColor = usedBackgroundColor
            ui_averagePressTime_CAPS.ForeColor = usedStatFontColor
            ui_percent_CAPS.BackColor = usedBackgroundColor
            ui_percent_CAPS.ForeColor = usedStatFontColor
            ui_bind_CAPS.BackColor = usedTextboxBackgroundColor
            ui_bind_CAPS.ForeColor = usedStatFontColor
            ui_totalPresses_CAPS.Text = pressCount_CAPS.ToString

            Dim tempCAPStime As Decimal = 0

            If pressTimeTotal_CAPS < 60 Then
                If pressTimeTotalConverted_CAPS = 1 Then
                    ui_totalPressTime_CAPS.Text = pressTimeTotal_CAPS.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_CAPS.Text = pressTimeTotal_CAPS.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_CAPS > 60 And pressTimeTotal_CAPS < 3600 Then
                tempCAPStime = pressTimeTotal_CAPS / 60
                If pressTimeTotal_CAPS = 1 Then
                    ui_totalPressTime_CAPS.Text = tempCAPStime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_CAPS.Text = tempCAPStime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_CAPS > 3600 Or pressTimeTotal_CAPS = 3600 Then
                tempCAPStime = pressTimeTotal_CAPS / 3600
                If tempCAPStime = 1 Then
                    ui_totalPressTime_CAPS.Text = tempCAPStime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_CAPS.Text = tempCAPStime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_CAPS = pressTimeTotal_CAPS / pressCount_CAPS

            If pressTimeAverage_CAPS < 60 Then
                If pressTimeAverage_CAPS = 1 Then
                    ui_averagePressTime_CAPS.Text = pressTimeAverage_CAPS.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_CAPS.Text = pressTimeAverage_CAPS.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_CAPS > 60 And pressTimeAverage_CAPS < 3600 Then
                pressTimeTotal_CAPS /= 60
                If pressTimeTotal_CAPS = 1 Then
                    ui_averagePressTime_CAPS.Text = pressTimeTotal_CAPS.ToString("N3") & " min"
                Else
                    ui_averagePressTime_CAPS.Text = pressTimeTotal_CAPS.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_CAPS > 3600 Or pressTimeAverage_CAPS = 3600 Then
                pressTimeTotal_CAPS /= 3600
                If pressTimeTotal_CAPS = 1 Then
                    ui_averagePressTime_CAPS.Text = pressTimeTotal_CAPS.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_CAPS.Text = pressTimeTotal_CAPS.ToString("N3") & " hours"
                End If
            End If

            ui_percent_CAPS.Text = ((pressCount_CAPS / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'A
        If pressCount_A > 0 Then 'Used

            ui_Panel_A.BackColor = usedBackgroundColor
            ui_Label_A.BackColor = usedBackgroundColor
            ui_Label_A.ForeColor = usedKeyNameFontColor
            ui_totalPresses_A.BackColor = usedBackgroundColor
            ui_totalPresses_A.ForeColor = usedStatFontColor
            ui_totalPressTime_A.BackColor = usedBackgroundColor
            ui_totalPressTime_A.ForeColor = usedStatFontColor
            ui_averagePressTime_A.BackColor = usedBackgroundColor
            ui_averagePressTime_A.ForeColor = usedStatFontColor
            ui_percent_A.BackColor = usedBackgroundColor
            ui_percent_A.ForeColor = usedStatFontColor
            ui_bind_A.BackColor = usedTextboxBackgroundColor
            ui_bind_A.ForeColor = usedStatFontColor
            ui_totalPresses_A.Text = pressCount_A.ToString

            Dim tempAtime As Decimal = 0

            If pressTimeTotal_A < 60 Then
                If pressTimeTotalConverted_A = 1 Then
                    ui_totalPressTime_A.Text = pressTimeTotal_A.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_A.Text = pressTimeTotal_A.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_A > 60 And pressTimeTotal_A < 3600 Then
                tempAtime = pressTimeTotal_A / 60
                If pressTimeTotal_A = 1 Then
                    ui_totalPressTime_A.Text = tempAtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_A.Text = tempAtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_A > 3600 Or pressTimeTotal_A = 3600 Then
                tempAtime = pressTimeTotal_A / 3600
                If tempAtime = 1 Then
                    ui_totalPressTime_A.Text = tempAtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_A.Text = tempAtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_A = pressTimeTotal_A / pressCount_A

            If pressTimeAverage_A < 60 Then
                If pressTimeAverage_A = 1 Then
                    ui_averagePressTime_A.Text = pressTimeAverage_A.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_A.Text = pressTimeAverage_A.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_A > 60 And pressTimeAverage_A < 3600 Then
                pressTimeTotal_A /= 60
                If pressTimeTotal_A = 1 Then
                    ui_averagePressTime_A.Text = pressTimeTotal_A.ToString("N3") & " min"
                Else
                    ui_averagePressTime_A.Text = pressTimeTotal_A.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_A > 3600 Or pressTimeAverage_A = 3600 Then
                pressTimeTotal_A /= 3600
                If pressTimeTotal_A = 1 Then
                    ui_averagePressTime_A.Text = pressTimeTotal_A.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_A.Text = pressTimeTotal_A.ToString("N3") & " hours"
                End If
            End If

            ui_percent_A.Text = ((pressCount_A / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'S
        If pressCount_S > 0 Then 'Used

            ui_Panel_S.BackColor = usedBackgroundColor
            ui_Label_S.BackColor = usedBackgroundColor
            ui_Label_S.ForeColor = usedKeyNameFontColor
            ui_totalPresses_S.BackColor = usedBackgroundColor
            ui_totalPresses_S.ForeColor = usedStatFontColor
            ui_totalPressTime_S.BackColor = usedBackgroundColor
            ui_totalPressTime_S.ForeColor = usedStatFontColor
            ui_averagePressTime_S.BackColor = usedBackgroundColor
            ui_averagePressTime_S.ForeColor = usedStatFontColor
            ui_percent_S.BackColor = usedBackgroundColor
            ui_percent_S.ForeColor = usedStatFontColor
            ui_bind_S.BackColor = usedTextboxBackgroundColor
            ui_bind_S.ForeColor = usedStatFontColor
            ui_totalPresses_S.Text = pressCount_S.ToString

            Dim tempStime As Decimal = 0

            If pressTimeTotal_S < 60 Then
                If pressTimeTotalConverted_S = 1 Then
                    ui_totalPressTime_S.Text = pressTimeTotal_S.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_S.Text = pressTimeTotal_S.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_S > 60 And pressTimeTotal_S < 3600 Then
                tempStime = pressTimeTotal_S / 60
                If pressTimeTotal_S = 1 Then
                    ui_totalPressTime_S.Text = tempStime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_S.Text = tempStime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_S > 3600 Or pressTimeTotal_S = 3600 Then
                tempStime = pressTimeTotal_S / 3600
                If tempStime = 1 Then
                    ui_totalPressTime_S.Text = tempStime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_S.Text = tempStime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_S = pressTimeTotal_S / pressCount_S

            If pressTimeAverage_S < 60 Then
                If pressTimeAverage_S = 1 Then
                    ui_averagePressTime_S.Text = pressTimeAverage_S.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_S.Text = pressTimeAverage_S.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_S > 60 And pressTimeAverage_S < 3600 Then
                pressTimeTotal_S /= 60
                If pressTimeTotal_S = 1 Then
                    ui_averagePressTime_S.Text = pressTimeTotal_S.ToString("N3") & " min"
                Else
                    ui_averagePressTime_S.Text = pressTimeTotal_S.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_S > 3600 Or pressTimeAverage_S = 3600 Then
                pressTimeTotal_S /= 3600
                If pressTimeTotal_S = 1 Then
                    ui_averagePressTime_S.Text = pressTimeTotal_S.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_S.Text = pressTimeTotal_S.ToString("N3") & " hours"
                End If
            End If

            ui_percent_S.Text = ((pressCount_S / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'D
        If pressCount_D > 0 Then 'Used

            ui_Panel_D.BackColor = usedBackgroundColor
            ui_Label_D.BackColor = usedBackgroundColor
            ui_Label_D.ForeColor = usedKeyNameFontColor
            ui_totalPresses_D.BackColor = usedBackgroundColor
            ui_totalPresses_D.ForeColor = usedStatFontColor
            ui_totalPressTime_D.BackColor = usedBackgroundColor
            ui_totalPressTime_D.ForeColor = usedStatFontColor
            ui_averagePressTime_D.BackColor = usedBackgroundColor
            ui_averagePressTime_D.ForeColor = usedStatFontColor
            ui_percent_D.BackColor = usedBackgroundColor
            ui_percent_D.ForeColor = usedStatFontColor
            ui_bind_D.BackColor = usedTextboxBackgroundColor
            ui_bind_D.ForeColor = usedStatFontColor
            ui_totalPresses_D.Text = pressCount_D.ToString

            Dim tempDtime As Decimal = 0

            If pressTimeTotal_D < 60 Then
                If pressTimeTotalConverted_D = 1 Then
                    ui_totalPressTime_D.Text = pressTimeTotal_D.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_D.Text = pressTimeTotal_D.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_D > 60 And pressTimeTotal_D < 3600 Then
                tempDtime = pressTimeTotal_D / 60
                If pressTimeTotal_D = 1 Then
                    ui_totalPressTime_D.Text = tempDtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_D.Text = tempDtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_D > 3600 Or pressTimeTotal_D = 3600 Then
                tempDtime = pressTimeTotal_D / 3600
                If tempDtime = 1 Then
                    ui_totalPressTime_D.Text = tempDtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_D.Text = tempDtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_D = pressTimeTotal_D / pressCount_D

            If pressTimeAverage_D < 60 Then
                If pressTimeAverage_D = 1 Then
                    ui_averagePressTime_D.Text = pressTimeAverage_D.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_D.Text = pressTimeAverage_D.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_D > 60 And pressTimeAverage_D < 3600 Then
                pressTimeTotal_D /= 60
                If pressTimeTotal_D = 1 Then
                    ui_averagePressTime_D.Text = pressTimeTotal_D.ToString("N3") & " min"
                Else
                    ui_averagePressTime_D.Text = pressTimeTotal_D.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_D > 3600 Or pressTimeAverage_D = 3600 Then
                pressTimeTotal_D /= 3600
                If pressTimeTotal_D = 1 Then
                    ui_averagePressTime_D.Text = pressTimeTotal_D.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_D.Text = pressTimeTotal_D.ToString("N3") & " hours"
                End If
            End If

            ui_percent_D.Text = ((pressCount_D / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'F
        If pressCount_F > 0 Then 'Used

            ui_Panel_F.BackColor = usedBackgroundColor
            ui_Label_F.BackColor = usedBackgroundColor
            ui_Label_F.ForeColor = usedKeyNameFontColor
            ui_totalPresses_F.BackColor = usedBackgroundColor
            ui_totalPresses_F.ForeColor = usedStatFontColor
            ui_totalPressTime_F.BackColor = usedBackgroundColor
            ui_totalPressTime_F.ForeColor = usedStatFontColor
            ui_averagePressTime_F.BackColor = usedBackgroundColor
            ui_averagePressTime_F.ForeColor = usedStatFontColor
            ui_percent_F.BackColor = usedBackgroundColor
            ui_percent_F.ForeColor = usedStatFontColor
            ui_bind_F.BackColor = usedTextboxBackgroundColor
            ui_bind_F.ForeColor = usedStatFontColor
            ui_totalPresses_F.Text = pressCount_F.ToString

            Dim tempFtime As Decimal = 0

            If pressTimeTotal_F < 60 Then
                If pressTimeTotalConverted_F = 1 Then
                    ui_totalPressTime_F.Text = pressTimeTotal_F.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_F.Text = pressTimeTotal_F.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_F > 60 And pressTimeTotal_F < 3600 Then
                tempFtime = pressTimeTotal_F / 60
                If pressTimeTotal_F = 1 Then
                    ui_totalPressTime_F.Text = tempFtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_F.Text = tempFtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_F > 3600 Or pressTimeTotal_F = 3600 Then
                tempFtime = pressTimeTotal_F / 3600
                If tempFtime = 1 Then
                    ui_totalPressTime_F.Text = tempFtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_F.Text = tempFtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_F = pressTimeTotal_F / pressCount_F

            If pressTimeAverage_F < 60 Then
                If pressTimeAverage_F = 1 Then
                    ui_averagePressTime_F.Text = pressTimeAverage_F.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_F.Text = pressTimeAverage_F.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_F > 60 And pressTimeAverage_F < 3600 Then
                pressTimeTotal_F /= 60
                If pressTimeTotal_F = 1 Then
                    ui_averagePressTime_F.Text = pressTimeTotal_F.ToString("N3") & " min"
                Else
                    ui_averagePressTime_F.Text = pressTimeTotal_F.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_F > 3600 Or pressTimeAverage_F = 3600 Then
                pressTimeTotal_F /= 3600
                If pressTimeTotal_F = 1 Then
                    ui_averagePressTime_F.Text = pressTimeTotal_F.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_F.Text = pressTimeTotal_F.ToString("N3") & " hours"
                End If
            End If

            ui_percent_F.Text = ((pressCount_F / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'G
        If pressCount_G > 0 Then 'Used

            ui_Panel_G.BackColor = usedBackgroundColor
            ui_Label_G.BackColor = usedBackgroundColor
            ui_Label_G.ForeColor = usedKeyNameFontColor
            ui_totalPresses_G.BackColor = usedBackgroundColor
            ui_totalPresses_G.ForeColor = usedStatFontColor
            ui_totalPressTime_G.BackColor = usedBackgroundColor
            ui_totalPressTime_G.ForeColor = usedStatFontColor
            ui_averagePressTime_G.BackColor = usedBackgroundColor
            ui_averagePressTime_G.ForeColor = usedStatFontColor
            ui_percent_G.BackColor = usedBackgroundColor
            ui_percent_G.ForeColor = usedStatFontColor
            ui_bind_G.BackColor = usedTextboxBackgroundColor
            ui_bind_G.ForeColor = usedStatFontColor
            ui_totalPresses_G.Text = pressCount_G.ToString

            Dim tempGtime As Decimal = 0

            If pressTimeTotal_G < 60 Then
                If pressTimeTotalConverted_G = 1 Then
                    ui_totalPressTime_G.Text = pressTimeTotal_G.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_G.Text = pressTimeTotal_G.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_G > 60 And pressTimeTotal_G < 3600 Then
                tempGtime = pressTimeTotal_G / 60
                If pressTimeTotal_G = 1 Then
                    ui_totalPressTime_G.Text = tempGtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_G.Text = tempGtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_G > 3600 Or pressTimeTotal_G = 3600 Then
                tempGtime = pressTimeTotal_G / 3600
                If tempGtime = 1 Then
                    ui_totalPressTime_G.Text = tempGtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_G.Text = tempGtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_G = pressTimeTotal_G / pressCount_G

            If pressTimeAverage_G < 60 Then
                If pressTimeAverage_G = 1 Then
                    ui_averagePressTime_G.Text = pressTimeAverage_G.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_G.Text = pressTimeAverage_G.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_G > 60 And pressTimeAverage_G < 3600 Then
                pressTimeTotal_G /= 60
                If pressTimeTotal_G = 1 Then
                    ui_averagePressTime_G.Text = pressTimeTotal_G.ToString("N3") & " min"
                Else
                    ui_averagePressTime_G.Text = pressTimeTotal_G.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_G > 3600 Or pressTimeAverage_G = 3600 Then
                pressTimeTotal_G /= 3600
                If pressTimeTotal_G = 1 Then
                    ui_averagePressTime_G.Text = pressTimeTotal_G.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_G.Text = pressTimeTotal_G.ToString("N3") & " hours"
                End If
            End If

            ui_percent_G.Text = ((pressCount_G / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'H
        If pressCount_H > 0 Then 'Used

            ui_Panel_H.BackColor = usedBackgroundColor
            ui_Label_H.BackColor = usedBackgroundColor
            ui_Label_H.ForeColor = usedKeyNameFontColor
            ui_totalPresses_H.BackColor = usedBackgroundColor
            ui_totalPresses_H.ForeColor = usedStatFontColor
            ui_totalPressTime_H.BackColor = usedBackgroundColor
            ui_totalPressTime_H.ForeColor = usedStatFontColor
            ui_averagePressTime_H.BackColor = usedBackgroundColor
            ui_averagePressTime_H.ForeColor = usedStatFontColor
            ui_percent_H.BackColor = usedBackgroundColor
            ui_percent_H.ForeColor = usedStatFontColor
            ui_bind_H.BackColor = usedTextboxBackgroundColor
            ui_bind_H.ForeColor = usedStatFontColor
            ui_totalPresses_H.Text = pressCount_H.ToString

            Dim tempHtime As Decimal = 0

            If pressTimeTotal_H < 60 Then
                If pressTimeTotalConverted_H = 1 Then
                    ui_totalPressTime_H.Text = pressTimeTotal_H.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_H.Text = pressTimeTotal_H.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_H > 60 And pressTimeTotal_H < 3600 Then
                tempHtime = pressTimeTotal_H / 60
                If pressTimeTotal_H = 1 Then
                    ui_totalPressTime_H.Text = tempHtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_H.Text = tempHtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_H > 3600 Or pressTimeTotal_H = 3600 Then
                tempHtime = pressTimeTotal_H / 3600
                If tempHtime = 1 Then
                    ui_totalPressTime_H.Text = tempHtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_H.Text = tempHtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_H = pressTimeTotal_H / pressCount_H

            If pressTimeAverage_H < 60 Then
                If pressTimeAverage_H = 1 Then
                    ui_averagePressTime_H.Text = pressTimeAverage_H.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_H.Text = pressTimeAverage_H.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_H > 60 And pressTimeAverage_H < 3600 Then
                pressTimeTotal_H /= 60
                If pressTimeTotal_H = 1 Then
                    ui_averagePressTime_H.Text = pressTimeTotal_H.ToString("N3") & " min"
                Else
                    ui_averagePressTime_H.Text = pressTimeTotal_H.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_H > 3600 Or pressTimeAverage_H = 3600 Then
                pressTimeTotal_H /= 3600
                If pressTimeTotal_H = 1 Then
                    ui_averagePressTime_H.Text = pressTimeTotal_H.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_H.Text = pressTimeTotal_H.ToString("N3") & " hours"
                End If
            End If

            ui_percent_H.Text = ((pressCount_H / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'J
        If pressCount_J > 0 Then 'Used

            ui_Panel_J.BackColor = usedBackgroundColor
            ui_Label_J.BackColor = usedBackgroundColor
            ui_Label_J.ForeColor = usedKeyNameFontColor
            ui_totalPresses_J.BackColor = usedBackgroundColor
            ui_totalPresses_J.ForeColor = usedStatFontColor
            ui_totalPressTime_J.BackColor = usedBackgroundColor
            ui_totalPressTime_J.ForeColor = usedStatFontColor
            ui_averagePressTime_J.BackColor = usedBackgroundColor
            ui_averagePressTime_J.ForeColor = usedStatFontColor
            ui_percent_J.BackColor = usedBackgroundColor
            ui_percent_J.ForeColor = usedStatFontColor
            ui_bind_J.BackColor = usedTextboxBackgroundColor
            ui_bind_J.ForeColor = usedStatFontColor
            ui_totalPresses_J.Text = pressCount_J.ToString

            Dim tempJtime As Decimal = 0

            If pressTimeTotal_J < 60 Then
                If pressTimeTotalConverted_J = 1 Then
                    ui_totalPressTime_J.Text = pressTimeTotal_J.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_J.Text = pressTimeTotal_J.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_J > 60 And pressTimeTotal_J < 3600 Then
                tempJtime = pressTimeTotal_J / 60
                If pressTimeTotal_J = 1 Then
                    ui_totalPressTime_J.Text = tempJtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_J.Text = tempJtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_J > 3600 Or pressTimeTotal_J = 3600 Then
                tempJtime = pressTimeTotal_J / 3600
                If tempJtime = 1 Then
                    ui_totalPressTime_J.Text = tempJtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_J.Text = tempJtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_J = pressTimeTotal_J / pressCount_J

            If pressTimeAverage_J < 60 Then
                If pressTimeAverage_J = 1 Then
                    ui_averagePressTime_J.Text = pressTimeAverage_J.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_J.Text = pressTimeAverage_J.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_J > 60 And pressTimeAverage_J < 3600 Then
                pressTimeTotal_J /= 60
                If pressTimeTotal_J = 1 Then
                    ui_averagePressTime_J.Text = pressTimeTotal_J.ToString("N3") & " min"
                Else
                    ui_averagePressTime_J.Text = pressTimeTotal_J.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_J > 3600 Or pressTimeAverage_J = 3600 Then
                pressTimeTotal_J /= 3600
                If pressTimeTotal_J = 1 Then
                    ui_averagePressTime_J.Text = pressTimeTotal_J.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_J.Text = pressTimeTotal_J.ToString("N3") & " hours"
                End If
            End If

            ui_percent_J.Text = ((pressCount_J / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'K
        If pressCount_K > 0 Then 'Used

            ui_Panel_K.BackColor = usedBackgroundColor
            ui_Label_K.BackColor = usedBackgroundColor
            ui_Label_K.ForeColor = usedKeyNameFontColor
            ui_totalPresses_K.BackColor = usedBackgroundColor
            ui_totalPresses_K.ForeColor = usedStatFontColor
            ui_totalPressTime_K.BackColor = usedBackgroundColor
            ui_totalPressTime_K.ForeColor = usedStatFontColor
            ui_averagePressTime_K.BackColor = usedBackgroundColor
            ui_averagePressTime_K.ForeColor = usedStatFontColor
            ui_percent_K.BackColor = usedBackgroundColor
            ui_percent_K.ForeColor = usedStatFontColor
            ui_bind_K.BackColor = usedTextboxBackgroundColor
            ui_bind_K.ForeColor = usedStatFontColor
            ui_totalPresses_K.Text = pressCount_K.ToString

            Dim tempKtime As Decimal = 0

            If pressTimeTotal_K < 60 Then
                If pressTimeTotalConverted_K = 1 Then
                    ui_totalPressTime_K.Text = pressTimeTotal_K.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_K.Text = pressTimeTotal_K.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_K > 60 And pressTimeTotal_K < 3600 Then
                tempKtime = pressTimeTotal_K / 60
                If pressTimeTotal_K = 1 Then
                    ui_totalPressTime_K.Text = tempKtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_K.Text = tempKtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_K > 3600 Or pressTimeTotal_K = 3600 Then
                tempKtime = pressTimeTotal_K / 3600
                If tempKtime = 1 Then
                    ui_totalPressTime_K.Text = tempKtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_K.Text = tempKtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_K = pressTimeTotal_K / pressCount_K

            If pressTimeAverage_K < 60 Then
                If pressTimeAverage_K = 1 Then
                    ui_averagePressTime_K.Text = pressTimeAverage_K.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_K.Text = pressTimeAverage_K.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_K > 60 And pressTimeAverage_K < 3600 Then
                pressTimeTotal_K /= 60
                If pressTimeTotal_K = 1 Then
                    ui_averagePressTime_K.Text = pressTimeTotal_K.ToString("N3") & " min"
                Else
                    ui_averagePressTime_K.Text = pressTimeTotal_K.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_K > 3600 Or pressTimeAverage_K = 3600 Then
                pressTimeTotal_K /= 3600
                If pressTimeTotal_K = 1 Then
                    ui_averagePressTime_K.Text = pressTimeTotal_K.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_K.Text = pressTimeTotal_K.ToString("N3") & " hours"
                End If
            End If

            ui_percent_K.Text = ((pressCount_K / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'L
        If pressCount_L > 0 Then 'Used

            ui_Panel_L.BackColor = usedBackgroundColor
            ui_Label_L.BackColor = usedBackgroundColor
            ui_Label_L.ForeColor = usedKeyNameFontColor
            ui_totalPresses_L.BackColor = usedBackgroundColor
            ui_totalPresses_L.ForeColor = usedStatFontColor
            ui_totalPressTime_L.BackColor = usedBackgroundColor
            ui_totalPressTime_L.ForeColor = usedStatFontColor
            ui_averagePressTime_L.BackColor = usedBackgroundColor
            ui_averagePressTime_L.ForeColor = usedStatFontColor
            ui_percent_L.BackColor = usedBackgroundColor
            ui_percent_L.ForeColor = usedStatFontColor
            ui_bind_L.BackColor = usedTextboxBackgroundColor
            ui_bind_L.ForeColor = usedStatFontColor
            ui_totalPresses_L.Text = pressCount_L.ToString

            Dim tempLtime As Decimal = 0

            If pressTimeTotal_L < 60 Then
                If pressTimeTotalConverted_L = 1 Then
                    ui_totalPressTime_L.Text = pressTimeTotal_L.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_L.Text = pressTimeTotal_L.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_L > 60 And pressTimeTotal_L < 3600 Then
                tempLtime = pressTimeTotal_L / 60
                If pressTimeTotal_L = 1 Then
                    ui_totalPressTime_L.Text = tempLtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_L.Text = tempLtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_L > 3600 Or pressTimeTotal_L = 3600 Then
                tempLtime = pressTimeTotal_L / 3600
                If tempLtime = 1 Then
                    ui_totalPressTime_L.Text = tempLtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_L.Text = tempLtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_L = pressTimeTotal_L / pressCount_L

            If pressTimeAverage_L < 60 Then
                If pressTimeAverage_L = 1 Then
                    ui_averagePressTime_L.Text = pressTimeAverage_L.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_L.Text = pressTimeAverage_L.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_L > 60 And pressTimeAverage_L < 3600 Then
                pressTimeTotal_L /= 60
                If pressTimeTotal_L = 1 Then
                    ui_averagePressTime_L.Text = pressTimeTotal_L.ToString("N3") & " min"
                Else
                    ui_averagePressTime_L.Text = pressTimeTotal_L.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_L > 3600 Or pressTimeAverage_L = 3600 Then
                pressTimeTotal_L /= 3600
                If pressTimeTotal_L = 1 Then
                    ui_averagePressTime_L.Text = pressTimeTotal_L.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_L.Text = pressTimeTotal_L.ToString("N3") & " hours"
                End If
            End If

            ui_percent_L.Text = ((pressCount_L / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'COLON
        If pressCount_COLON > 0 Then 'Used

            ui_Panel_COLON.BackColor = usedBackgroundColor
            ui_Label_COLON.BackColor = usedBackgroundColor
            ui_Label_COLON.ForeColor = usedKeyNameFontColor
            ui_totalPresses_COLON.BackColor = usedBackgroundColor
            ui_totalPresses_COLON.ForeColor = usedStatFontColor
            ui_totalPressTime_COLON.BackColor = usedBackgroundColor
            ui_totalPressTime_COLON.ForeColor = usedStatFontColor
            ui_averagePressTime_COLON.BackColor = usedBackgroundColor
            ui_averagePressTime_COLON.ForeColor = usedStatFontColor
            ui_percent_COLON.BackColor = usedBackgroundColor
            ui_percent_COLON.ForeColor = usedStatFontColor
            ui_bind_COLON.BackColor = usedTextboxBackgroundColor
            ui_bind_COLON.ForeColor = usedStatFontColor
            ui_totalPresses_COLON.Text = pressCount_COLON.ToString

            Dim tempCOLONtime As Decimal = 0

            If pressTimeTotal_COLON < 60 Then
                If pressTimeTotalConverted_COLON = 1 Then
                    ui_totalPressTime_COLON.Text = pressTimeTotal_COLON.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_COLON.Text = pressTimeTotal_COLON.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_COLON > 60 And pressTimeTotal_COLON < 3600 Then
                tempCOLONtime = pressTimeTotal_COLON / 60
                If pressTimeTotal_COLON = 1 Then
                    ui_totalPressTime_COLON.Text = tempCOLONtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_COLON.Text = tempCOLONtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_COLON > 3600 Or pressTimeTotal_COLON = 3600 Then
                tempCOLONtime = pressTimeTotal_COLON / 3600
                If tempCOLONtime = 1 Then
                    ui_totalPressTime_COLON.Text = tempCOLONtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_COLON.Text = tempCOLONtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_COLON = pressTimeTotal_COLON / pressCount_COLON

            If pressTimeAverage_COLON < 60 Then
                If pressTimeAverage_COLON = 1 Then
                    ui_averagePressTime_COLON.Text = pressTimeAverage_COLON.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_COLON.Text = pressTimeAverage_COLON.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_COLON > 60 And pressTimeAverage_COLON < 3600 Then
                pressTimeTotal_COLON /= 60
                If pressTimeTotal_COLON = 1 Then
                    ui_averagePressTime_COLON.Text = pressTimeTotal_COLON.ToString("N3") & " min"
                Else
                    ui_averagePressTime_COLON.Text = pressTimeTotal_COLON.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_COLON > 3600 Or pressTimeAverage_COLON = 3600 Then
                pressTimeTotal_COLON /= 3600
                If pressTimeTotal_COLON = 1 Then
                    ui_averagePressTime_COLON.Text = pressTimeTotal_COLON.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_COLON.Text = pressTimeTotal_COLON.ToString("N3") & " hours"
                End If
            End If

            ui_percent_COLON.Text = ((pressCount_COLON / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'QUOTES
        If pressCount_QUOTES > 0 Then 'Used

            ui_Panel_QUOTES.BackColor = usedBackgroundColor
            ui_Label_QUOTES.BackColor = usedBackgroundColor
            ui_Label_QUOTES.ForeColor = usedKeyNameFontColor
            ui_totalPresses_QUOTES.BackColor = usedBackgroundColor
            ui_totalPresses_QUOTES.ForeColor = usedStatFontColor
            ui_totalPressTime_QUOTES.BackColor = usedBackgroundColor
            ui_totalPressTime_QUOTES.ForeColor = usedStatFontColor
            ui_averagePressTime_QUOTES.BackColor = usedBackgroundColor
            ui_averagePressTime_QUOTES.ForeColor = usedStatFontColor
            ui_percent_QUOTES.BackColor = usedBackgroundColor
            ui_percent_QUOTES.ForeColor = usedStatFontColor
            ui_bind_QUOTES.BackColor = usedTextboxBackgroundColor
            ui_bind_QUOTES.ForeColor = usedStatFontColor
            ui_totalPresses_QUOTES.Text = pressCount_QUOTES.ToString

            Dim tempQUOTEStime As Decimal = 0

            If pressTimeTotal_QUOTES < 60 Then
                If pressTimeTotalConverted_QUOTES = 1 Then
                    ui_totalPressTime_QUOTES.Text = pressTimeTotal_QUOTES.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_QUOTES.Text = pressTimeTotal_QUOTES.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_QUOTES > 60 And pressTimeTotal_QUOTES < 3600 Then
                tempQUOTEStime = pressTimeTotal_QUOTES / 60
                If pressTimeTotal_QUOTES = 1 Then
                    ui_totalPressTime_QUOTES.Text = tempQUOTEStime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_QUOTES.Text = tempQUOTEStime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_QUOTES > 3600 Or pressTimeTotal_QUOTES = 3600 Then
                tempQUOTEStime = pressTimeTotal_QUOTES / 3600
                If tempQUOTEStime = 1 Then
                    ui_totalPressTime_QUOTES.Text = tempQUOTEStime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_QUOTES.Text = tempQUOTEStime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_QUOTES = pressTimeTotal_QUOTES / pressCount_QUOTES

            If pressTimeAverage_QUOTES < 60 Then
                If pressTimeAverage_QUOTES = 1 Then
                    ui_averagePressTime_QUOTES.Text = pressTimeAverage_QUOTES.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_QUOTES.Text = pressTimeAverage_QUOTES.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_QUOTES > 60 And pressTimeAverage_QUOTES < 3600 Then
                pressTimeTotal_QUOTES /= 60
                If pressTimeTotal_QUOTES = 1 Then
                    ui_averagePressTime_QUOTES.Text = pressTimeTotal_QUOTES.ToString("N3") & " min"
                Else
                    ui_averagePressTime_QUOTES.Text = pressTimeTotal_QUOTES.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_QUOTES > 3600 Or pressTimeAverage_QUOTES = 3600 Then
                pressTimeTotal_QUOTES /= 3600
                If pressTimeTotal_QUOTES = 1 Then
                    ui_averagePressTime_QUOTES.Text = pressTimeTotal_QUOTES.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_QUOTES.Text = pressTimeTotal_QUOTES.ToString("N3") & " hours"
                End If
            End If

            ui_percent_QUOTES.Text = ((pressCount_QUOTES / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'MainEnter
        If pressCount_MainEnter > 0 Then 'Used

            ui_Panel_MainEnter.BackColor = usedBackgroundColor
            ui_Label_MainEnter.BackColor = usedBackgroundColor
            ui_Label_MainEnter.ForeColor = usedKeyNameFontColor
            ui_totalPresses_MainEnter.BackColor = usedBackgroundColor
            ui_totalPresses_MainEnter.ForeColor = usedStatFontColor
            ui_totalPressTime_MainEnter.BackColor = usedBackgroundColor
            ui_totalPressTime_MainEnter.ForeColor = usedStatFontColor
            ui_averagePressTime_MainEnter.BackColor = usedBackgroundColor
            ui_averagePressTime_MainEnter.ForeColor = usedStatFontColor
            ui_percent_MainEnter.BackColor = usedBackgroundColor
            ui_percent_MainEnter.ForeColor = usedStatFontColor
            ui_bind_MainEnter.BackColor = usedTextboxBackgroundColor
            ui_bind_MainEnter.ForeColor = usedStatFontColor
            ui_totalPresses_MainEnter.Text = pressCount_MainEnter.ToString

            Dim tempMainEntertime As Decimal = 0

            If pressTimeTotal_MainEnter < 60 Then
                If pressTimeTotalConverted_MainEnter = 1 Then
                    ui_totalPressTime_MainEnter.Text = pressTimeTotal_MainEnter.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_MainEnter.Text = pressTimeTotal_MainEnter.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_MainEnter > 60 And pressTimeTotal_MainEnter < 3600 Then
                tempMainEntertime = pressTimeTotal_MainEnter / 60
                If pressTimeTotal_MainEnter = 1 Then
                    ui_totalPressTime_MainEnter.Text = tempMainEntertime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_MainEnter.Text = tempMainEntertime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_MainEnter > 3600 Or pressTimeTotal_MainEnter = 3600 Then
                tempMainEntertime = pressTimeTotal_MainEnter / 3600
                If tempMainEntertime = 1 Then
                    ui_totalPressTime_MainEnter.Text = tempMainEntertime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_MainEnter.Text = tempMainEntertime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_MainEnter = pressTimeTotal_MainEnter / pressCount_MainEnter

            If pressTimeAverage_MainEnter < 60 Then
                If pressTimeAverage_MainEnter = 1 Then
                    ui_averagePressTime_MainEnter.Text = pressTimeAverage_MainEnter.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_MainEnter.Text = pressTimeAverage_MainEnter.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_MainEnter > 60 And pressTimeAverage_MainEnter < 3600 Then
                pressTimeTotal_MainEnter /= 60
                If pressTimeTotal_MainEnter = 1 Then
                    ui_averagePressTime_MainEnter.Text = pressTimeTotal_MainEnter.ToString("N3") & " min"
                Else
                    ui_averagePressTime_MainEnter.Text = pressTimeTotal_MainEnter.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_MainEnter > 3600 Or pressTimeAverage_MainEnter = 3600 Then
                pressTimeTotal_MainEnter /= 3600
                If pressTimeTotal_MainEnter = 1 Then
                    ui_averagePressTime_MainEnter.Text = pressTimeTotal_MainEnter.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_MainEnter.Text = pressTimeTotal_MainEnter.ToString("N3") & " hours"
                End If
            End If

            ui_percent_MainEnter.Text = ((pressCount_MainEnter / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num4
        If pressCount_Num4 > 0 Then 'Used

            ui_Panel_Num4.BackColor = usedBackgroundColor
            ui_Label_Num4.BackColor = usedBackgroundColor
            ui_Label_Num4.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num4.BackColor = usedBackgroundColor
            ui_totalPresses_Num4.ForeColor = usedStatFontColor
            ui_totalPressTime_Num4.BackColor = usedBackgroundColor
            ui_totalPressTime_Num4.ForeColor = usedStatFontColor
            ui_averagePressTime_Num4.BackColor = usedBackgroundColor
            ui_averagePressTime_Num4.ForeColor = usedStatFontColor
            ui_percent_Num4.BackColor = usedBackgroundColor
            ui_percent_Num4.ForeColor = usedStatFontColor
            ui_bind_Num4.BackColor = usedTextboxBackgroundColor
            ui_bind_Num4.ForeColor = usedStatFontColor
            ui_totalPresses_Num4.Text = pressCount_Num4.ToString

            Dim tempNum4time As Decimal = 0

            If pressTimeTotal_Num4 < 60 Then
                If pressTimeTotalConverted_Num4 = 1 Then
                    ui_totalPressTime_Num4.Text = pressTimeTotal_Num4.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num4.Text = pressTimeTotal_Num4.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num4 > 60 And pressTimeTotal_Num4 < 3600 Then
                tempNum4time = pressTimeTotal_Num4 / 60
                If pressTimeTotal_Num4 = 1 Then
                    ui_totalPressTime_Num4.Text = tempNum4time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num4.Text = tempNum4time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num4 > 3600 Or pressTimeTotal_Num4 = 3600 Then
                tempNum4time = pressTimeTotal_Num4 / 3600
                If tempNum4time = 1 Then
                    ui_totalPressTime_Num4.Text = tempNum4time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num4.Text = tempNum4time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num4 = pressTimeTotal_Num4 / pressCount_Num4

            If pressTimeAverage_Num4 < 60 Then
                If pressTimeAverage_Num4 = 1 Then
                    ui_averagePressTime_Num4.Text = pressTimeAverage_Num4.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num4.Text = pressTimeAverage_Num4.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num4 > 60 And pressTimeAverage_Num4 < 3600 Then
                pressTimeTotal_Num4 /= 60
                If pressTimeTotal_Num4 = 1 Then
                    ui_averagePressTime_Num4.Text = pressTimeTotal_Num4.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num4.Text = pressTimeTotal_Num4.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num4 > 3600 Or pressTimeAverage_Num4 = 3600 Then
                pressTimeTotal_Num4 /= 3600
                If pressTimeTotal_Num4 = 1 Then
                    ui_averagePressTime_Num4.Text = pressTimeTotal_Num4.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num4.Text = pressTimeTotal_Num4.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num4.Text = ((pressCount_Num4 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num5
        If pressCount_Num5 > 0 Then 'Used

            ui_Panel_Num5.BackColor = usedBackgroundColor
            ui_Label_Num5.BackColor = usedBackgroundColor
            ui_Label_Num5.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num5.BackColor = usedBackgroundColor
            ui_totalPresses_Num5.ForeColor = usedStatFontColor
            ui_totalPressTime_Num5.BackColor = usedBackgroundColor
            ui_totalPressTime_Num5.ForeColor = usedStatFontColor
            ui_averagePressTime_Num5.BackColor = usedBackgroundColor
            ui_averagePressTime_Num5.ForeColor = usedStatFontColor
            ui_percent_Num5.BackColor = usedBackgroundColor
            ui_percent_Num5.ForeColor = usedStatFontColor
            ui_bind_Num5.BackColor = usedTextboxBackgroundColor
            ui_bind_Num5.ForeColor = usedStatFontColor
            ui_totalPresses_Num5.Text = pressCount_Num5.ToString

            Dim tempNum5time As Decimal = 0

            If pressTimeTotal_Num5 < 60 Then
                If pressTimeTotalConverted_Num5 = 1 Then
                    ui_totalPressTime_Num5.Text = pressTimeTotal_Num5.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num5.Text = pressTimeTotal_Num5.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num5 > 60 And pressTimeTotal_Num5 < 3600 Then
                tempNum5time = pressTimeTotal_Num5 / 60
                If pressTimeTotal_Num5 = 1 Then
                    ui_totalPressTime_Num5.Text = tempNum5time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num5.Text = tempNum5time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num5 > 3600 Or pressTimeTotal_Num5 = 3600 Then
                tempNum5time = pressTimeTotal_Num5 / 3600
                If tempNum5time = 1 Then
                    ui_totalPressTime_Num5.Text = tempNum5time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num5.Text = tempNum5time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num5 = pressTimeTotal_Num5 / pressCount_Num5

            If pressTimeAverage_Num5 < 60 Then
                If pressTimeAverage_Num5 = 1 Then
                    ui_averagePressTime_Num5.Text = pressTimeAverage_Num5.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num5.Text = pressTimeAverage_Num5.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num5 > 60 And pressTimeAverage_Num5 < 3600 Then
                pressTimeTotal_Num5 /= 60
                If pressTimeTotal_Num5 = 1 Then
                    ui_averagePressTime_Num5.Text = pressTimeTotal_Num5.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num5.Text = pressTimeTotal_Num5.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num5 > 3600 Or pressTimeAverage_Num5 = 3600 Then
                pressTimeTotal_Num5 /= 3600
                If pressTimeTotal_Num5 = 1 Then
                    ui_averagePressTime_Num5.Text = pressTimeTotal_Num5.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num5.Text = pressTimeTotal_Num5.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num5.Text = ((pressCount_Num5 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num6
        If pressCount_Num6 > 0 Then 'Used

            ui_Panel_Num6.BackColor = usedBackgroundColor
            ui_Label_Num6.BackColor = usedBackgroundColor
            ui_Label_Num6.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num6.BackColor = usedBackgroundColor
            ui_totalPresses_Num6.ForeColor = usedStatFontColor
            ui_totalPressTime_Num6.BackColor = usedBackgroundColor
            ui_totalPressTime_Num6.ForeColor = usedStatFontColor
            ui_averagePressTime_Num6.BackColor = usedBackgroundColor
            ui_averagePressTime_Num6.ForeColor = usedStatFontColor
            ui_percent_Num6.BackColor = usedBackgroundColor
            ui_percent_Num6.ForeColor = usedStatFontColor
            ui_bind_Num6.BackColor = usedTextboxBackgroundColor
            ui_bind_Num6.ForeColor = usedStatFontColor
            ui_totalPresses_Num6.Text = pressCount_Num6.ToString

            Dim tempNum6time As Decimal = 0

            If pressTimeTotal_Num6 < 60 Then
                If pressTimeTotalConverted_Num6 = 1 Then
                    ui_totalPressTime_Num6.Text = pressTimeTotal_Num6.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num6.Text = pressTimeTotal_Num6.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num6 > 60 And pressTimeTotal_Num6 < 3600 Then
                tempNum6time = pressTimeTotal_Num6 / 60
                If pressTimeTotal_Num6 = 1 Then
                    ui_totalPressTime_Num6.Text = tempNum6time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num6.Text = tempNum6time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num6 > 3600 Or pressTimeTotal_Num6 = 3600 Then
                tempNum6time = pressTimeTotal_Num6 / 3600
                If tempNum6time = 1 Then
                    ui_totalPressTime_Num6.Text = tempNum6time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num6.Text = tempNum6time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num6 = pressTimeTotal_Num6 / pressCount_Num6

            If pressTimeAverage_Num6 < 60 Then
                If pressTimeAverage_Num6 = 1 Then
                    ui_averagePressTime_Num6.Text = pressTimeAverage_Num6.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num6.Text = pressTimeAverage_Num6.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num6 > 60 And pressTimeAverage_Num6 < 3600 Then
                pressTimeTotal_Num6 /= 60
                If pressTimeTotal_Num6 = 1 Then
                    ui_averagePressTime_Num6.Text = pressTimeTotal_Num6.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num6.Text = pressTimeTotal_Num6.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num6 > 3600 Or pressTimeAverage_Num6 = 3600 Then
                pressTimeTotal_Num6 /= 3600
                If pressTimeTotal_Num6 = 1 Then
                    ui_averagePressTime_Num6.Text = pressTimeTotal_Num6.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num6.Text = pressTimeTotal_Num6.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num6.Text = ((pressCount_Num6 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Plus
        If pressCount_Plus > 0 Then 'Used

            ui_Panel_Plus.BackColor = usedBackgroundColor
            ui_Label_Plus.BackColor = usedBackgroundColor
            ui_Label_Plus.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Plus.BackColor = usedBackgroundColor
            ui_totalPresses_Plus.ForeColor = usedStatFontColor
            ui_totalPressTime_Plus.BackColor = usedBackgroundColor
            ui_totalPressTime_Plus.ForeColor = usedStatFontColor
            ui_averagePressTime_Plus.BackColor = usedBackgroundColor
            ui_averagePressTime_Plus.ForeColor = usedStatFontColor
            ui_percent_Plus.BackColor = usedBackgroundColor
            ui_percent_Plus.ForeColor = usedStatFontColor
            ui_bind_Plus.BackColor = usedTextboxBackgroundColor
            ui_bind_Plus.ForeColor = usedStatFontColor
            ui_totalPresses_Plus.Text = pressCount_Plus.ToString

            Dim tempPlustime As Decimal = 0

            If pressTimeTotal_Plus < 60 Then
                If pressTimeTotalConverted_Plus = 1 Then
                    ui_totalPressTime_Plus.Text = pressTimeTotal_Plus.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Plus.Text = pressTimeTotal_Plus.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Plus > 60 And pressTimeTotal_Plus < 3600 Then
                tempPlustime = pressTimeTotal_Plus / 60
                If pressTimeTotal_Plus = 1 Then
                    ui_totalPressTime_Plus.Text = tempPlustime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Plus.Text = tempPlustime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Plus > 3600 Or pressTimeTotal_Plus = 3600 Then
                tempPlustime = pressTimeTotal_Plus / 3600
                If tempPlustime = 1 Then
                    ui_totalPressTime_Plus.Text = tempPlustime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Plus.Text = tempPlustime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Plus = pressTimeTotal_Plus / pressCount_Plus

            If pressTimeAverage_Plus < 60 Then
                If pressTimeAverage_Plus = 1 Then
                    ui_averagePressTime_Plus.Text = pressTimeAverage_Plus.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Plus.Text = pressTimeAverage_Plus.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Plus > 60 And pressTimeAverage_Plus < 3600 Then
                pressTimeTotal_Plus /= 60
                If pressTimeTotal_Plus = 1 Then
                    ui_averagePressTime_Plus.Text = pressTimeTotal_Plus.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Plus.Text = pressTimeTotal_Plus.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Plus > 3600 Or pressTimeAverage_Plus = 3600 Then
                pressTimeTotal_Plus /= 3600
                If pressTimeTotal_Plus = 1 Then
                    ui_averagePressTime_Plus.Text = pressTimeTotal_Plus.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Plus.Text = pressTimeTotal_Plus.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Plus.Text = ((pressCount_Plus / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LSHIFT
        If pressCount_LSHIFT > 0 Then 'Used

            ui_Panel_LSHIFT.BackColor = usedBackgroundColor
            ui_Label_LSHIFT.BackColor = usedBackgroundColor
            ui_Label_LSHIFT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LSHIFT.BackColor = usedBackgroundColor
            ui_totalPresses_LSHIFT.ForeColor = usedStatFontColor
            ui_totalPressTime_LSHIFT.BackColor = usedBackgroundColor
            ui_totalPressTime_LSHIFT.ForeColor = usedStatFontColor
            ui_averagePressTime_LSHIFT.BackColor = usedBackgroundColor
            ui_averagePressTime_LSHIFT.ForeColor = usedStatFontColor
            ui_percent_LSHIFT.BackColor = usedBackgroundColor
            ui_percent_LSHIFT.ForeColor = usedStatFontColor
            ui_bind_LSHIFT.BackColor = usedTextboxBackgroundColor
            ui_bind_LSHIFT.ForeColor = usedStatFontColor
            ui_totalPresses_LSHIFT.Text = pressCount_LSHIFT.ToString

            Dim tempLSHIFTtime As Decimal = 0

            If pressTimeTotal_LSHIFT < 60 Then
                If pressTimeTotalConverted_LSHIFT = 1 Then
                    ui_totalPressTime_LSHIFT.Text = pressTimeTotal_LSHIFT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LSHIFT.Text = pressTimeTotal_LSHIFT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LSHIFT > 60 And pressTimeTotal_LSHIFT < 3600 Then
                tempLSHIFTtime = pressTimeTotal_LSHIFT / 60
                If pressTimeTotal_LSHIFT = 1 Then
                    ui_totalPressTime_LSHIFT.Text = tempLSHIFTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LSHIFT.Text = tempLSHIFTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LSHIFT > 3600 Or pressTimeTotal_LSHIFT = 3600 Then
                tempLSHIFTtime = pressTimeTotal_LSHIFT / 3600
                If tempLSHIFTtime = 1 Then
                    ui_totalPressTime_LSHIFT.Text = tempLSHIFTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LSHIFT.Text = tempLSHIFTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LSHIFT = pressTimeTotal_LSHIFT / pressCount_LSHIFT

            If pressTimeAverage_LSHIFT < 60 Then
                If pressTimeAverage_LSHIFT = 1 Then
                    ui_averagePressTime_LSHIFT.Text = pressTimeAverage_LSHIFT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LSHIFT.Text = pressTimeAverage_LSHIFT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LSHIFT > 60 And pressTimeAverage_LSHIFT < 3600 Then
                pressTimeTotal_LSHIFT /= 60
                If pressTimeTotal_LSHIFT = 1 Then
                    ui_averagePressTime_LSHIFT.Text = pressTimeTotal_LSHIFT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LSHIFT.Text = pressTimeTotal_LSHIFT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LSHIFT > 3600 Or pressTimeAverage_LSHIFT = 3600 Then
                pressTimeTotal_LSHIFT /= 3600
                If pressTimeTotal_LSHIFT = 1 Then
                    ui_averagePressTime_LSHIFT.Text = pressTimeTotal_LSHIFT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LSHIFT.Text = pressTimeTotal_LSHIFT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LSHIFT.Text = ((pressCount_LSHIFT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Z
        If pressCount_Z > 0 Then 'Used

            ui_Panel_Z.BackColor = usedBackgroundColor
            ui_Label_Z.BackColor = usedBackgroundColor
            ui_Label_Z.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Z.BackColor = usedBackgroundColor
            ui_totalPresses_Z.ForeColor = usedStatFontColor
            ui_totalPressTime_Z.BackColor = usedBackgroundColor
            ui_totalPressTime_Z.ForeColor = usedStatFontColor
            ui_averagePressTime_Z.BackColor = usedBackgroundColor
            ui_averagePressTime_Z.ForeColor = usedStatFontColor
            ui_percent_Z.BackColor = usedBackgroundColor
            ui_percent_Z.ForeColor = usedStatFontColor
            ui_bind_Z.BackColor = usedTextboxBackgroundColor
            ui_bind_Z.ForeColor = usedStatFontColor
            ui_totalPresses_Z.Text = pressCount_Z.ToString

            Dim tempZtime As Decimal = 0

            If pressTimeTotal_Z < 60 Then
                If pressTimeTotalConverted_Z = 1 Then
                    ui_totalPressTime_Z.Text = pressTimeTotal_Z.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Z.Text = pressTimeTotal_Z.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Z > 60 And pressTimeTotal_Z < 3600 Then
                tempZtime = pressTimeTotal_Z / 60
                If pressTimeTotal_Z = 1 Then
                    ui_totalPressTime_Z.Text = tempZtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Z.Text = tempZtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Z > 3600 Or pressTimeTotal_Z = 3600 Then
                tempZtime = pressTimeTotal_Z / 3600
                If tempZtime = 1 Then
                    ui_totalPressTime_Z.Text = tempZtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Z.Text = tempZtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Z = pressTimeTotal_Z / pressCount_Z

            If pressTimeAverage_Z < 60 Then
                If pressTimeAverage_Z = 1 Then
                    ui_averagePressTime_Z.Text = pressTimeAverage_Z.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Z.Text = pressTimeAverage_Z.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Z > 60 And pressTimeAverage_Z < 3600 Then
                pressTimeTotal_Z /= 60
                If pressTimeTotal_Z = 1 Then
                    ui_averagePressTime_Z.Text = pressTimeTotal_Z.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Z.Text = pressTimeTotal_Z.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Z > 3600 Or pressTimeAverage_Z = 3600 Then
                pressTimeTotal_Z /= 3600
                If pressTimeTotal_Z = 1 Then
                    ui_averagePressTime_Z.Text = pressTimeTotal_Z.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Z.Text = pressTimeTotal_Z.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Z.Text = ((pressCount_Z / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'X
        If pressCount_X > 0 Then 'Used

            ui_Panel_X.BackColor = usedBackgroundColor
            ui_Label_X.BackColor = usedBackgroundColor
            ui_Label_X.ForeColor = usedKeyNameFontColor
            ui_totalPresses_X.BackColor = usedBackgroundColor
            ui_totalPresses_X.ForeColor = usedStatFontColor
            ui_totalPressTime_X.BackColor = usedBackgroundColor
            ui_totalPressTime_X.ForeColor = usedStatFontColor
            ui_averagePressTime_X.BackColor = usedBackgroundColor
            ui_averagePressTime_X.ForeColor = usedStatFontColor
            ui_percent_X.BackColor = usedBackgroundColor
            ui_percent_X.ForeColor = usedStatFontColor
            ui_bind_X.BackColor = usedTextboxBackgroundColor
            ui_bind_X.ForeColor = usedStatFontColor
            ui_totalPresses_X.Text = pressCount_X.ToString

            Dim tempXtime As Decimal = 0

            If pressTimeTotal_X < 60 Then
                If pressTimeTotalConverted_X = 1 Then
                    ui_totalPressTime_X.Text = pressTimeTotal_X.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_X.Text = pressTimeTotal_X.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_X > 60 And pressTimeTotal_X < 3600 Then
                tempXtime = pressTimeTotal_X / 60
                If pressTimeTotal_X = 1 Then
                    ui_totalPressTime_X.Text = tempXtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_X.Text = tempXtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_X > 3600 Or pressTimeTotal_X = 3600 Then
                tempXtime = pressTimeTotal_X / 3600
                If tempXtime = 1 Then
                    ui_totalPressTime_X.Text = tempXtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_X.Text = tempXtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_X = pressTimeTotal_X / pressCount_X

            If pressTimeAverage_X < 60 Then
                If pressTimeAverage_X = 1 Then
                    ui_averagePressTime_X.Text = pressTimeAverage_X.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_X.Text = pressTimeAverage_X.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_X > 60 And pressTimeAverage_X < 3600 Then
                pressTimeTotal_X /= 60
                If pressTimeTotal_X = 1 Then
                    ui_averagePressTime_X.Text = pressTimeTotal_X.ToString("N3") & " min"
                Else
                    ui_averagePressTime_X.Text = pressTimeTotal_X.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_X > 3600 Or pressTimeAverage_X = 3600 Then
                pressTimeTotal_X /= 3600
                If pressTimeTotal_X = 1 Then
                    ui_averagePressTime_X.Text = pressTimeTotal_X.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_X.Text = pressTimeTotal_X.ToString("N3") & " hours"
                End If
            End If

            ui_percent_X.Text = ((pressCount_X / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'C
        If pressCount_C > 0 Then 'Used

            ui_Panel_C.BackColor = usedBackgroundColor
            ui_Label_C.BackColor = usedBackgroundColor
            ui_Label_C.ForeColor = usedKeyNameFontColor
            ui_totalPresses_C.BackColor = usedBackgroundColor
            ui_totalPresses_C.ForeColor = usedStatFontColor
            ui_totalPressTime_C.BackColor = usedBackgroundColor
            ui_totalPressTime_C.ForeColor = usedStatFontColor
            ui_averagePressTime_C.BackColor = usedBackgroundColor
            ui_averagePressTime_C.ForeColor = usedStatFontColor
            ui_percent_C.BackColor = usedBackgroundColor
            ui_percent_C.ForeColor = usedStatFontColor
            ui_bind_C.BackColor = usedTextboxBackgroundColor
            ui_bind_C.ForeColor = usedStatFontColor
            ui_totalPresses_C.Text = pressCount_C.ToString

            Dim tempCtime As Decimal = 0

            If pressTimeTotal_C < 60 Then
                If pressTimeTotalConverted_C = 1 Then
                    ui_totalPressTime_C.Text = pressTimeTotal_C.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_C.Text = pressTimeTotal_C.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_C > 60 And pressTimeTotal_C < 3600 Then
                tempCtime = pressTimeTotal_C / 60
                If pressTimeTotal_C = 1 Then
                    ui_totalPressTime_C.Text = tempCtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_C.Text = tempCtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_C > 3600 Or pressTimeTotal_C = 3600 Then
                tempCtime = pressTimeTotal_C / 3600
                If tempCtime = 1 Then
                    ui_totalPressTime_C.Text = tempCtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_C.Text = tempCtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_C = pressTimeTotal_C / pressCount_C

            If pressTimeAverage_C < 60 Then
                If pressTimeAverage_C = 1 Then
                    ui_averagePressTime_C.Text = pressTimeAverage_C.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_C.Text = pressTimeAverage_C.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_C > 60 And pressTimeAverage_C < 3600 Then
                pressTimeTotal_C /= 60
                If pressTimeTotal_C = 1 Then
                    ui_averagePressTime_C.Text = pressTimeTotal_C.ToString("N3") & " min"
                Else
                    ui_averagePressTime_C.Text = pressTimeTotal_C.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_C > 3600 Or pressTimeAverage_C = 3600 Then
                pressTimeTotal_C /= 3600
                If pressTimeTotal_C = 1 Then
                    ui_averagePressTime_C.Text = pressTimeTotal_C.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_C.Text = pressTimeTotal_C.ToString("N3") & " hours"
                End If
            End If

            ui_percent_C.Text = ((pressCount_C / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'V
        If pressCount_V > 0 Then 'Used

            ui_Panel_V.BackColor = usedBackgroundColor
            ui_Label_V.BackColor = usedBackgroundColor
            ui_Label_V.ForeColor = usedKeyNameFontColor
            ui_totalPresses_V.BackColor = usedBackgroundColor
            ui_totalPresses_V.ForeColor = usedStatFontColor
            ui_totalPressTime_V.BackColor = usedBackgroundColor
            ui_totalPressTime_V.ForeColor = usedStatFontColor
            ui_averagePressTime_V.BackColor = usedBackgroundColor
            ui_averagePressTime_V.ForeColor = usedStatFontColor
            ui_percent_V.BackColor = usedBackgroundColor
            ui_percent_V.ForeColor = usedStatFontColor
            ui_bind_V.BackColor = usedTextboxBackgroundColor
            ui_bind_V.ForeColor = usedStatFontColor
            ui_totalPresses_V.Text = pressCount_V.ToString

            Dim tempVtime As Decimal = 0

            If pressTimeTotal_V < 60 Then
                If pressTimeTotalConverted_V = 1 Then
                    ui_totalPressTime_V.Text = pressTimeTotal_V.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_V.Text = pressTimeTotal_V.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_V > 60 And pressTimeTotal_V < 3600 Then
                tempVtime = pressTimeTotal_V / 60
                If pressTimeTotal_V = 1 Then
                    ui_totalPressTime_V.Text = tempVtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_V.Text = tempVtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_V > 3600 Or pressTimeTotal_V = 3600 Then
                tempVtime = pressTimeTotal_V / 3600
                If tempVtime = 1 Then
                    ui_totalPressTime_V.Text = tempVtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_V.Text = tempVtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_V = pressTimeTotal_V / pressCount_V

            If pressTimeAverage_V < 60 Then
                If pressTimeAverage_V = 1 Then
                    ui_averagePressTime_V.Text = pressTimeAverage_V.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_V.Text = pressTimeAverage_V.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_V > 60 And pressTimeAverage_V < 3600 Then
                pressTimeTotal_V /= 60
                If pressTimeTotal_V = 1 Then
                    ui_averagePressTime_V.Text = pressTimeTotal_V.ToString("N3") & " min"
                Else
                    ui_averagePressTime_V.Text = pressTimeTotal_V.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_V > 3600 Or pressTimeAverage_V = 3600 Then
                pressTimeTotal_V /= 3600
                If pressTimeTotal_V = 1 Then
                    ui_averagePressTime_V.Text = pressTimeTotal_V.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_V.Text = pressTimeTotal_V.ToString("N3") & " hours"
                End If
            End If

            ui_percent_V.Text = ((pressCount_V / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'B
        If pressCount_B > 0 Then 'Used

            ui_Panel_B.BackColor = usedBackgroundColor
            ui_Label_B.BackColor = usedBackgroundColor
            ui_Label_B.ForeColor = usedKeyNameFontColor
            ui_totalPresses_B.BackColor = usedBackgroundColor
            ui_totalPresses_B.ForeColor = usedStatFontColor
            ui_totalPressTime_B.BackColor = usedBackgroundColor
            ui_totalPressTime_B.ForeColor = usedStatFontColor
            ui_averagePressTime_B.BackColor = usedBackgroundColor
            ui_averagePressTime_B.ForeColor = usedStatFontColor
            ui_percent_B.BackColor = usedBackgroundColor
            ui_percent_B.ForeColor = usedStatFontColor
            ui_bind_B.BackColor = usedTextboxBackgroundColor
            ui_bind_B.ForeColor = usedStatFontColor
            ui_totalPresses_B.Text = pressCount_B.ToString

            Dim tempBtime As Decimal = 0

            If pressTimeTotal_B < 60 Then
                If pressTimeTotalConverted_B = 1 Then
                    ui_totalPressTime_B.Text = pressTimeTotal_B.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_B.Text = pressTimeTotal_B.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_B > 60 And pressTimeTotal_B < 3600 Then
                tempBtime = pressTimeTotal_B / 60
                If pressTimeTotal_B = 1 Then
                    ui_totalPressTime_B.Text = tempBtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_B.Text = tempBtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_B > 3600 Or pressTimeTotal_B = 3600 Then
                tempBtime = pressTimeTotal_B / 3600
                If tempBtime = 1 Then
                    ui_totalPressTime_B.Text = tempBtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_B.Text = tempBtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_B = pressTimeTotal_B / pressCount_B

            If pressTimeAverage_B < 60 Then
                If pressTimeAverage_B = 1 Then
                    ui_averagePressTime_B.Text = pressTimeAverage_B.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_B.Text = pressTimeAverage_B.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_B > 60 And pressTimeAverage_B < 3600 Then
                pressTimeTotal_B /= 60
                If pressTimeTotal_B = 1 Then
                    ui_averagePressTime_B.Text = pressTimeTotal_B.ToString("N3") & " min"
                Else
                    ui_averagePressTime_B.Text = pressTimeTotal_B.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_B > 3600 Or pressTimeAverage_B = 3600 Then
                pressTimeTotal_B /= 3600
                If pressTimeTotal_B = 1 Then
                    ui_averagePressTime_B.Text = pressTimeTotal_B.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_B.Text = pressTimeTotal_B.ToString("N3") & " hours"
                End If
            End If

            ui_percent_B.Text = ((pressCount_B / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'N
        If pressCount_N > 0 Then 'Used

            ui_Panel_N.BackColor = usedBackgroundColor
            ui_Label_N.BackColor = usedBackgroundColor
            ui_Label_N.ForeColor = usedKeyNameFontColor
            ui_totalPresses_N.BackColor = usedBackgroundColor
            ui_totalPresses_N.ForeColor = usedStatFontColor
            ui_totalPressTime_N.BackColor = usedBackgroundColor
            ui_totalPressTime_N.ForeColor = usedStatFontColor
            ui_averagePressTime_N.BackColor = usedBackgroundColor
            ui_averagePressTime_N.ForeColor = usedStatFontColor
            ui_percent_N.BackColor = usedBackgroundColor
            ui_percent_N.ForeColor = usedStatFontColor
            ui_bind_N.BackColor = usedTextboxBackgroundColor
            ui_bind_N.ForeColor = usedStatFontColor
            ui_totalPresses_N.Text = pressCount_N.ToString

            Dim tempNtime As Decimal = 0

            If pressTimeTotal_N < 60 Then
                If pressTimeTotalConverted_N = 1 Then
                    ui_totalPressTime_N.Text = pressTimeTotal_N.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_N.Text = pressTimeTotal_N.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_N > 60 And pressTimeTotal_N < 3600 Then
                tempNtime = pressTimeTotal_N / 60
                If pressTimeTotal_N = 1 Then
                    ui_totalPressTime_N.Text = tempNtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_N.Text = tempNtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_N > 3600 Or pressTimeTotal_N = 3600 Then
                tempNtime = pressTimeTotal_N / 3600
                If tempNtime = 1 Then
                    ui_totalPressTime_N.Text = tempNtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_N.Text = tempNtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_N = pressTimeTotal_N / pressCount_N

            If pressTimeAverage_N < 60 Then
                If pressTimeAverage_N = 1 Then
                    ui_averagePressTime_N.Text = pressTimeAverage_N.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_N.Text = pressTimeAverage_N.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_N > 60 And pressTimeAverage_N < 3600 Then
                pressTimeTotal_N /= 60
                If pressTimeTotal_N = 1 Then
                    ui_averagePressTime_N.Text = pressTimeTotal_N.ToString("N3") & " min"
                Else
                    ui_averagePressTime_N.Text = pressTimeTotal_N.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_N > 3600 Or pressTimeAverage_N = 3600 Then
                pressTimeTotal_N /= 3600
                If pressTimeTotal_N = 1 Then
                    ui_averagePressTime_N.Text = pressTimeTotal_N.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_N.Text = pressTimeTotal_N.ToString("N3") & " hours"
                End If
            End If

            ui_percent_N.Text = ((pressCount_N / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'M
        If pressCount_M > 0 Then 'Used

            ui_Panel_M.BackColor = usedBackgroundColor
            ui_Label_M.BackColor = usedBackgroundColor
            ui_Label_M.ForeColor = usedKeyNameFontColor
            ui_totalPresses_M.BackColor = usedBackgroundColor
            ui_totalPresses_M.ForeColor = usedStatFontColor
            ui_totalPressTime_M.BackColor = usedBackgroundColor
            ui_totalPressTime_M.ForeColor = usedStatFontColor
            ui_averagePressTime_M.BackColor = usedBackgroundColor
            ui_averagePressTime_M.ForeColor = usedStatFontColor
            ui_percent_M.BackColor = usedBackgroundColor
            ui_percent_M.ForeColor = usedStatFontColor
            ui_bind_M.BackColor = usedTextboxBackgroundColor
            ui_bind_M.ForeColor = usedStatFontColor
            ui_totalPresses_M.Text = pressCount_M.ToString

            Dim tempMtime As Decimal = 0

            If pressTimeTotal_M < 60 Then
                If pressTimeTotalConverted_M = 1 Then
                    ui_totalPressTime_M.Text = pressTimeTotal_M.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_M.Text = pressTimeTotal_M.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_M > 60 And pressTimeTotal_M < 3600 Then
                tempMtime = pressTimeTotal_M / 60
                If pressTimeTotal_M = 1 Then
                    ui_totalPressTime_M.Text = tempMtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_M.Text = tempMtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_M > 3600 Or pressTimeTotal_M = 3600 Then
                tempMtime = pressTimeTotal_M / 3600
                If tempMtime = 1 Then
                    ui_totalPressTime_M.Text = tempMtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_M.Text = tempMtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_M = pressTimeTotal_M / pressCount_M

            If pressTimeAverage_M < 60 Then
                If pressTimeAverage_M = 1 Then
                    ui_averagePressTime_M.Text = pressTimeAverage_M.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_M.Text = pressTimeAverage_M.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_M > 60 And pressTimeAverage_M < 3600 Then
                pressTimeTotal_M /= 60
                If pressTimeTotal_M = 1 Then
                    ui_averagePressTime_M.Text = pressTimeTotal_M.ToString("N3") & " min"
                Else
                    ui_averagePressTime_M.Text = pressTimeTotal_M.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_M > 3600 Or pressTimeAverage_M = 3600 Then
                pressTimeTotal_M /= 3600
                If pressTimeTotal_M = 1 Then
                    ui_averagePressTime_M.Text = pressTimeTotal_M.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_M.Text = pressTimeTotal_M.ToString("N3") & " hours"
                End If
            End If

            ui_percent_M.Text = ((pressCount_M / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LESS
        If pressCount_LESS > 0 Then 'Used

            ui_Panel_LESS.BackColor = usedBackgroundColor
            ui_Label_LESS.BackColor = usedBackgroundColor
            ui_Label_LESS.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LESS.BackColor = usedBackgroundColor
            ui_totalPresses_LESS.ForeColor = usedStatFontColor
            ui_totalPressTime_LESS.BackColor = usedBackgroundColor
            ui_totalPressTime_LESS.ForeColor = usedStatFontColor
            ui_averagePressTime_LESS.BackColor = usedBackgroundColor
            ui_averagePressTime_LESS.ForeColor = usedStatFontColor
            ui_percent_LESS.BackColor = usedBackgroundColor
            ui_percent_LESS.ForeColor = usedStatFontColor
            ui_bind_LESS.BackColor = usedTextboxBackgroundColor
            ui_bind_LESS.ForeColor = usedStatFontColor
            ui_totalPresses_LESS.Text = pressCount_LESS.ToString

            Dim tempLESStime As Decimal = 0

            If pressTimeTotal_LESS < 60 Then
                If pressTimeTotalConverted_LESS = 1 Then
                    ui_totalPressTime_LESS.Text = pressTimeTotal_LESS.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LESS.Text = pressTimeTotal_LESS.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LESS > 60 And pressTimeTotal_LESS < 3600 Then
                tempLESStime = pressTimeTotal_LESS / 60
                If pressTimeTotal_LESS = 1 Then
                    ui_totalPressTime_LESS.Text = tempLESStime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LESS.Text = tempLESStime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LESS > 3600 Or pressTimeTotal_LESS = 3600 Then
                tempLESStime = pressTimeTotal_LESS / 3600
                If tempLESStime = 1 Then
                    ui_totalPressTime_LESS.Text = tempLESStime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LESS.Text = tempLESStime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LESS = pressTimeTotal_LESS / pressCount_LESS

            If pressTimeAverage_LESS < 60 Then
                If pressTimeAverage_LESS = 1 Then
                    ui_averagePressTime_LESS.Text = pressTimeAverage_LESS.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LESS.Text = pressTimeAverage_LESS.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LESS > 60 And pressTimeAverage_LESS < 3600 Then
                pressTimeTotal_LESS /= 60
                If pressTimeTotal_LESS = 1 Then
                    ui_averagePressTime_LESS.Text = pressTimeTotal_LESS.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LESS.Text = pressTimeTotal_LESS.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LESS > 3600 Or pressTimeAverage_LESS = 3600 Then
                pressTimeTotal_LESS /= 3600
                If pressTimeTotal_LESS = 1 Then
                    ui_averagePressTime_LESS.Text = pressTimeTotal_LESS.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LESS.Text = pressTimeTotal_LESS.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LESS.Text = ((pressCount_LESS / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Greater
        If pressCount_Greater > 0 Then 'Used

            ui_Panel_Greater.BackColor = usedBackgroundColor
            ui_Label_Greater.BackColor = usedBackgroundColor
            ui_Label_Greater.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Greater.BackColor = usedBackgroundColor
            ui_totalPresses_Greater.ForeColor = usedStatFontColor
            ui_totalPressTime_Greater.BackColor = usedBackgroundColor
            ui_totalPressTime_Greater.ForeColor = usedStatFontColor
            ui_averagePressTime_Greater.BackColor = usedBackgroundColor
            ui_averagePressTime_Greater.ForeColor = usedStatFontColor
            ui_percent_Greater.BackColor = usedBackgroundColor
            ui_percent_Greater.ForeColor = usedStatFontColor
            ui_bind_Greater.BackColor = usedTextboxBackgroundColor
            ui_bind_Greater.ForeColor = usedStatFontColor
            ui_totalPresses_Greater.Text = pressCount_Greater.ToString

            Dim tempGreatertime As Decimal = 0

            If pressTimeTotal_Greater < 60 Then
                If pressTimeTotalConverted_Greater = 1 Then
                    ui_totalPressTime_Greater.Text = pressTimeTotal_Greater.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Greater.Text = pressTimeTotal_Greater.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Greater > 60 And pressTimeTotal_Greater < 3600 Then
                tempGreatertime = pressTimeTotal_Greater / 60
                If pressTimeTotal_Greater = 1 Then
                    ui_totalPressTime_Greater.Text = tempGreatertime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Greater.Text = tempGreatertime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Greater > 3600 Or pressTimeTotal_Greater = 3600 Then
                tempGreatertime = pressTimeTotal_Greater / 3600
                If tempGreatertime = 1 Then
                    ui_totalPressTime_Greater.Text = tempGreatertime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Greater.Text = tempGreatertime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Greater = pressTimeTotal_Greater / pressCount_Greater

            If pressTimeAverage_Greater < 60 Then
                If pressTimeAverage_Greater = 1 Then
                    ui_averagePressTime_Greater.Text = pressTimeAverage_Greater.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Greater.Text = pressTimeAverage_Greater.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Greater > 60 And pressTimeAverage_Greater < 3600 Then
                pressTimeTotal_Greater /= 60
                If pressTimeTotal_Greater = 1 Then
                    ui_averagePressTime_Greater.Text = pressTimeTotal_Greater.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Greater.Text = pressTimeTotal_Greater.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Greater > 3600 Or pressTimeAverage_Greater = 3600 Then
                pressTimeTotal_Greater /= 3600
                If pressTimeTotal_Greater = 1 Then
                    ui_averagePressTime_Greater.Text = pressTimeTotal_Greater.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Greater.Text = pressTimeTotal_Greater.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Greater.Text = ((pressCount_Greater / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Question
        If pressCount_Question > 0 Then 'Used

            ui_Panel_Question.BackColor = usedBackgroundColor
            ui_Label_Question.BackColor = usedBackgroundColor
            ui_Label_Question.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Question.BackColor = usedBackgroundColor
            ui_totalPresses_Question.ForeColor = usedStatFontColor
            ui_totalPressTime_Question.BackColor = usedBackgroundColor
            ui_totalPressTime_Question.ForeColor = usedStatFontColor
            ui_averagePressTime_Question.BackColor = usedBackgroundColor
            ui_averagePressTime_Question.ForeColor = usedStatFontColor
            ui_percent_Question.BackColor = usedBackgroundColor
            ui_percent_Question.ForeColor = usedStatFontColor
            ui_bind_Question.BackColor = usedTextboxBackgroundColor
            ui_bind_Question.ForeColor = usedStatFontColor
            ui_totalPresses_Question.Text = pressCount_Question.ToString

            Dim tempQuestiontime As Decimal = 0

            If pressTimeTotal_Question < 60 Then
                If pressTimeTotalConverted_Question = 1 Then
                    ui_totalPressTime_Question.Text = pressTimeTotal_Question.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Question.Text = pressTimeTotal_Question.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Question > 60 And pressTimeTotal_Question < 3600 Then
                tempQuestiontime = pressTimeTotal_Question / 60
                If pressTimeTotal_Question = 1 Then
                    ui_totalPressTime_Question.Text = tempQuestiontime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Question.Text = tempQuestiontime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Question > 3600 Or pressTimeTotal_Question = 3600 Then
                tempQuestiontime = pressTimeTotal_Question / 3600
                If tempQuestiontime = 1 Then
                    ui_totalPressTime_Question.Text = tempQuestiontime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Question.Text = tempQuestiontime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Question = pressTimeTotal_Question / pressCount_Question

            If pressTimeAverage_Question < 60 Then
                If pressTimeAverage_Question = 1 Then
                    ui_averagePressTime_Question.Text = pressTimeAverage_Question.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Question.Text = pressTimeAverage_Question.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Question > 60 And pressTimeAverage_Question < 3600 Then
                pressTimeTotal_Question /= 60
                If pressTimeTotal_Question = 1 Then
                    ui_averagePressTime_Question.Text = pressTimeTotal_Question.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Question.Text = pressTimeTotal_Question.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Question > 3600 Or pressTimeAverage_Question = 3600 Then
                pressTimeTotal_Question /= 3600
                If pressTimeTotal_Question = 1 Then
                    ui_averagePressTime_Question.Text = pressTimeTotal_Question.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Question.Text = pressTimeTotal_Question.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Question.Text = ((pressCount_Question / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'RSHIFT
        If pressCount_RSHIFT > 0 Then 'Used

            ui_Panel_RSHIFT.BackColor = usedBackgroundColor
            ui_Label_RSHIFT.BackColor = usedBackgroundColor
            ui_Label_RSHIFT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_RSHIFT.BackColor = usedBackgroundColor
            ui_totalPresses_RSHIFT.ForeColor = usedStatFontColor
            ui_totalPressTime_RSHIFT.BackColor = usedBackgroundColor
            ui_totalPressTime_RSHIFT.ForeColor = usedStatFontColor
            ui_averagePressTime_RSHIFT.BackColor = usedBackgroundColor
            ui_averagePressTime_RSHIFT.ForeColor = usedStatFontColor
            ui_percent_RSHIFT.BackColor = usedBackgroundColor
            ui_percent_RSHIFT.ForeColor = usedStatFontColor
            ui_bind_RSHIFT.BackColor = usedTextboxBackgroundColor
            ui_bind_RSHIFT.ForeColor = usedStatFontColor
            ui_totalPresses_RSHIFT.Text = pressCount_RSHIFT.ToString

            Dim tempRSHIFTtime As Decimal = 0

            If pressTimeTotal_RSHIFT < 60 Then
                If pressTimeTotalConverted_RSHIFT = 1 Then
                    ui_totalPressTime_RSHIFT.Text = pressTimeTotal_RSHIFT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_RSHIFT.Text = pressTimeTotal_RSHIFT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_RSHIFT > 60 And pressTimeTotal_RSHIFT < 3600 Then
                tempRSHIFTtime = pressTimeTotal_RSHIFT / 60
                If pressTimeTotal_RSHIFT = 1 Then
                    ui_totalPressTime_RSHIFT.Text = tempRSHIFTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_RSHIFT.Text = tempRSHIFTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_RSHIFT > 3600 Or pressTimeTotal_RSHIFT = 3600 Then
                tempRSHIFTtime = pressTimeTotal_RSHIFT / 3600
                If tempRSHIFTtime = 1 Then
                    ui_totalPressTime_RSHIFT.Text = tempRSHIFTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_RSHIFT.Text = tempRSHIFTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_RSHIFT = pressTimeTotal_RSHIFT / pressCount_RSHIFT

            If pressTimeAverage_RSHIFT < 60 Then
                If pressTimeAverage_RSHIFT = 1 Then
                    ui_averagePressTime_RSHIFT.Text = pressTimeAverage_RSHIFT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_RSHIFT.Text = pressTimeAverage_RSHIFT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_RSHIFT > 60 And pressTimeAverage_RSHIFT < 3600 Then
                pressTimeTotal_RSHIFT /= 60
                If pressTimeTotal_RSHIFT = 1 Then
                    ui_averagePressTime_RSHIFT.Text = pressTimeTotal_RSHIFT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_RSHIFT.Text = pressTimeTotal_RSHIFT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_RSHIFT > 3600 Or pressTimeAverage_RSHIFT = 3600 Then
                pressTimeTotal_RSHIFT /= 3600
                If pressTimeTotal_RSHIFT = 1 Then
                    ui_averagePressTime_RSHIFT.Text = pressTimeTotal_RSHIFT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_RSHIFT.Text = pressTimeTotal_RSHIFT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_RSHIFT.Text = ((pressCount_RSHIFT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'UP
        If pressCount_UP > 0 Then 'Used

            ui_Panel_UP.BackColor = usedBackgroundColor
            ui_Label_UP.BackColor = usedBackgroundColor
            ui_Label_UP.ForeColor = usedKeyNameFontColor
            ui_totalPresses_UP.BackColor = usedBackgroundColor
            ui_totalPresses_UP.ForeColor = usedStatFontColor
            ui_totalPressTime_UP.BackColor = usedBackgroundColor
            ui_totalPressTime_UP.ForeColor = usedStatFontColor
            ui_averagePressTime_UP.BackColor = usedBackgroundColor
            ui_averagePressTime_UP.ForeColor = usedStatFontColor
            ui_percent_UP.BackColor = usedBackgroundColor
            ui_percent_UP.ForeColor = usedStatFontColor
            ui_bind_UP.BackColor = usedTextboxBackgroundColor
            ui_bind_UP.ForeColor = usedStatFontColor
            ui_totalPresses_UP.Text = pressCount_UP.ToString

            Dim tempUPtime As Decimal = 0

            If pressTimeTotal_UP < 60 Then
                If pressTimeTotalConverted_UP = 1 Then
                    ui_totalPressTime_UP.Text = pressTimeTotal_UP.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_UP.Text = pressTimeTotal_UP.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_UP > 60 And pressTimeTotal_UP < 3600 Then
                tempUPtime = pressTimeTotal_UP / 60
                If pressTimeTotal_UP = 1 Then
                    ui_totalPressTime_UP.Text = tempUPtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_UP.Text = tempUPtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_UP > 3600 Or pressTimeTotal_UP = 3600 Then
                tempUPtime = pressTimeTotal_UP / 3600
                If tempUPtime = 1 Then
                    ui_totalPressTime_UP.Text = tempUPtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_UP.Text = tempUPtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_UP = pressTimeTotal_UP / pressCount_UP

            If pressTimeAverage_UP < 60 Then
                If pressTimeAverage_UP = 1 Then
                    ui_averagePressTime_UP.Text = pressTimeAverage_UP.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_UP.Text = pressTimeAverage_UP.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_UP > 60 And pressTimeAverage_UP < 3600 Then
                pressTimeTotal_UP /= 60
                If pressTimeTotal_UP = 1 Then
                    ui_averagePressTime_UP.Text = pressTimeTotal_UP.ToString("N3") & " min"
                Else
                    ui_averagePressTime_UP.Text = pressTimeTotal_UP.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_UP > 3600 Or pressTimeAverage_UP = 3600 Then
                pressTimeTotal_UP /= 3600
                If pressTimeTotal_UP = 1 Then
                    ui_averagePressTime_UP.Text = pressTimeTotal_UP.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_UP.Text = pressTimeTotal_UP.ToString("N3") & " hours"
                End If
            End If

            ui_percent_UP.Text = ((pressCount_UP / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num1
        If pressCount_Num1 > 0 Then 'Used

            ui_Panel_Num1.BackColor = usedBackgroundColor
            ui_Label_Num1.BackColor = usedBackgroundColor
            ui_Label_Num1.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num1.BackColor = usedBackgroundColor
            ui_totalPresses_Num1.ForeColor = usedStatFontColor
            ui_totalPressTime_Num1.BackColor = usedBackgroundColor
            ui_totalPressTime_Num1.ForeColor = usedStatFontColor
            ui_averagePressTime_Num1.BackColor = usedBackgroundColor
            ui_averagePressTime_Num1.ForeColor = usedStatFontColor
            ui_percent_Num1.BackColor = usedBackgroundColor
            ui_percent_Num1.ForeColor = usedStatFontColor
            ui_bind_Num1.BackColor = usedTextboxBackgroundColor
            ui_bind_Num1.ForeColor = usedStatFontColor
            ui_totalPresses_Num1.Text = pressCount_Num1.ToString

            Dim tempNum1time As Decimal = 0

            If pressTimeTotal_Num1 < 60 Then
                If pressTimeTotalConverted_Num1 = 1 Then
                    ui_totalPressTime_Num1.Text = pressTimeTotal_Num1.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num1.Text = pressTimeTotal_Num1.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num1 > 60 And pressTimeTotal_Num1 < 3600 Then
                tempNum1time = pressTimeTotal_Num1 / 60
                If pressTimeTotal_Num1 = 1 Then
                    ui_totalPressTime_Num1.Text = tempNum1time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num1.Text = tempNum1time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num1 > 3600 Or pressTimeTotal_Num1 = 3600 Then
                tempNum1time = pressTimeTotal_Num1 / 3600
                If tempNum1time = 1 Then
                    ui_totalPressTime_Num1.Text = tempNum1time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num1.Text = tempNum1time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num1 = pressTimeTotal_Num1 / pressCount_Num1

            If pressTimeAverage_Num1 < 60 Then
                If pressTimeAverage_Num1 = 1 Then
                    ui_averagePressTime_Num1.Text = pressTimeAverage_Num1.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num1.Text = pressTimeAverage_Num1.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num1 > 60 And pressTimeAverage_Num1 < 3600 Then
                pressTimeTotal_Num1 /= 60
                If pressTimeTotal_Num1 = 1 Then
                    ui_averagePressTime_Num1.Text = pressTimeTotal_Num1.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num1.Text = pressTimeTotal_Num1.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num1 > 3600 Or pressTimeAverage_Num1 = 3600 Then
                pressTimeTotal_Num1 /= 3600
                If pressTimeTotal_Num1 = 1 Then
                    ui_averagePressTime_Num1.Text = pressTimeTotal_Num1.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num1.Text = pressTimeTotal_Num1.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num1.Text = ((pressCount_Num1 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num2
        If pressCount_Num2 > 0 Then 'Used

            ui_Panel_Num2.BackColor = usedBackgroundColor
            ui_Label_Num2.BackColor = usedBackgroundColor
            ui_Label_Num2.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num2.BackColor = usedBackgroundColor
            ui_totalPresses_Num2.ForeColor = usedStatFontColor
            ui_totalPressTime_Num2.BackColor = usedBackgroundColor
            ui_totalPressTime_Num2.ForeColor = usedStatFontColor
            ui_averagePressTime_Num2.BackColor = usedBackgroundColor
            ui_averagePressTime_Num2.ForeColor = usedStatFontColor
            ui_percent_Num2.BackColor = usedBackgroundColor
            ui_percent_Num2.ForeColor = usedStatFontColor
            ui_bind_Num2.BackColor = usedTextboxBackgroundColor
            ui_bind_Num2.ForeColor = usedStatFontColor
            ui_totalPresses_Num2.Text = pressCount_Num2.ToString

            Dim tempNum2time As Decimal = 0

            If pressTimeTotal_Num2 < 60 Then
                If pressTimeTotalConverted_Num2 = 1 Then
                    ui_totalPressTime_Num2.Text = pressTimeTotal_Num2.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num2.Text = pressTimeTotal_Num2.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num2 > 60 And pressTimeTotal_Num2 < 3600 Then
                tempNum2time = pressTimeTotal_Num2 / 60
                If pressTimeTotal_Num2 = 1 Then
                    ui_totalPressTime_Num2.Text = tempNum2time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num2.Text = tempNum2time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num2 > 3600 Or pressTimeTotal_Num2 = 3600 Then
                tempNum2time = pressTimeTotal_Num2 / 3600
                If tempNum2time = 1 Then
                    ui_totalPressTime_Num2.Text = tempNum2time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num2.Text = tempNum2time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num2 = pressTimeTotal_Num2 / pressCount_Num2

            If pressTimeAverage_Num2 < 60 Then
                If pressTimeAverage_Num2 = 1 Then
                    ui_averagePressTime_Num2.Text = pressTimeAverage_Num2.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num2.Text = pressTimeAverage_Num2.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num2 > 60 And pressTimeAverage_Num2 < 3600 Then
                pressTimeTotal_Num2 /= 60
                If pressTimeTotal_Num2 = 1 Then
                    ui_averagePressTime_Num2.Text = pressTimeTotal_Num2.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num2.Text = pressTimeTotal_Num2.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num2 > 3600 Or pressTimeAverage_Num2 = 3600 Then
                pressTimeTotal_Num2 /= 3600
                If pressTimeTotal_Num2 = 1 Then
                    ui_averagePressTime_Num2.Text = pressTimeTotal_Num2.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num2.Text = pressTimeTotal_Num2.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num2.Text = ((pressCount_Num2 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num3
        If pressCount_Num3 > 0 Then 'Used

            ui_Panel_Num3.BackColor = usedBackgroundColor
            ui_Label_Num3.BackColor = usedBackgroundColor
            ui_Label_Num3.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num3.BackColor = usedBackgroundColor
            ui_totalPresses_Num3.ForeColor = usedStatFontColor
            ui_totalPressTime_Num3.BackColor = usedBackgroundColor
            ui_totalPressTime_Num3.ForeColor = usedStatFontColor
            ui_averagePressTime_Num3.BackColor = usedBackgroundColor
            ui_averagePressTime_Num3.ForeColor = usedStatFontColor
            ui_percent_Num3.BackColor = usedBackgroundColor
            ui_percent_Num3.ForeColor = usedStatFontColor
            ui_bind_Num3.BackColor = usedTextboxBackgroundColor
            ui_bind_Num3.ForeColor = usedStatFontColor
            ui_totalPresses_Num3.Text = pressCount_Num3.ToString

            Dim tempNum3time As Decimal = 0

            If pressTimeTotal_Num3 < 60 Then
                If pressTimeTotalConverted_Num3 = 1 Then
                    ui_totalPressTime_Num3.Text = pressTimeTotal_Num3.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num3.Text = pressTimeTotal_Num3.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num3 > 60 And pressTimeTotal_Num3 < 3600 Then
                tempNum3time = pressTimeTotal_Num3 / 60
                If pressTimeTotal_Num3 = 1 Then
                    ui_totalPressTime_Num3.Text = tempNum3time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num3.Text = tempNum3time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num3 > 3600 Or pressTimeTotal_Num3 = 3600 Then
                tempNum3time = pressTimeTotal_Num3 / 3600
                If tempNum3time = 1 Then
                    ui_totalPressTime_Num3.Text = tempNum3time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num3.Text = tempNum3time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num3 = pressTimeTotal_Num3 / pressCount_Num3

            If pressTimeAverage_Num3 < 60 Then
                If pressTimeAverage_Num3 = 1 Then
                    ui_averagePressTime_Num3.Text = pressTimeAverage_Num3.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num3.Text = pressTimeAverage_Num3.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num3 > 60 And pressTimeAverage_Num3 < 3600 Then
                pressTimeTotal_Num3 /= 60
                If pressTimeTotal_Num3 = 1 Then
                    ui_averagePressTime_Num3.Text = pressTimeTotal_Num3.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num3.Text = pressTimeTotal_Num3.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num3 > 3600 Or pressTimeAverage_Num3 = 3600 Then
                pressTimeTotal_Num3 /= 3600
                If pressTimeTotal_Num3 = 1 Then
                    ui_averagePressTime_Num3.Text = pressTimeTotal_Num3.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num3.Text = pressTimeTotal_Num3.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num3.Text = ((pressCount_Num3 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LCTRL
        If pressCount_LCTRL > 0 Then 'Used

            ui_Panel_LCTRL.BackColor = usedBackgroundColor
            ui_Label_LCTRL.BackColor = usedBackgroundColor
            ui_Label_LCTRL.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LCTRL.BackColor = usedBackgroundColor
            ui_totalPresses_LCTRL.ForeColor = usedStatFontColor
            ui_totalPressTime_LCTRL.BackColor = usedBackgroundColor
            ui_totalPressTime_LCTRL.ForeColor = usedStatFontColor
            ui_averagePressTime_LCTRL.BackColor = usedBackgroundColor
            ui_averagePressTime_LCTRL.ForeColor = usedStatFontColor
            ui_percent_LCTRL.BackColor = usedBackgroundColor
            ui_percent_LCTRL.ForeColor = usedStatFontColor
            ui_bind_LCTRL.BackColor = usedTextboxBackgroundColor
            ui_bind_LCTRL.ForeColor = usedStatFontColor
            ui_totalPresses_LCTRL.Text = pressCount_LCTRL.ToString

            Dim tempLCTRLtime As Decimal = 0

            If pressTimeTotal_LCTRL < 60 Then
                If pressTimeTotalConverted_LCTRL = 1 Then
                    ui_totalPressTime_LCTRL.Text = pressTimeTotal_LCTRL.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LCTRL.Text = pressTimeTotal_LCTRL.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LCTRL > 60 And pressTimeTotal_LCTRL < 3600 Then
                tempLCTRLtime = pressTimeTotal_LCTRL / 60
                If pressTimeTotal_LCTRL = 1 Then
                    ui_totalPressTime_LCTRL.Text = tempLCTRLtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LCTRL.Text = tempLCTRLtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LCTRL > 3600 Or pressTimeTotal_LCTRL = 3600 Then
                tempLCTRLtime = pressTimeTotal_LCTRL / 3600
                If tempLCTRLtime = 1 Then
                    ui_totalPressTime_LCTRL.Text = tempLCTRLtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LCTRL.Text = tempLCTRLtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LCTRL = pressTimeTotal_LCTRL / pressCount_LCTRL

            If pressTimeAverage_LCTRL < 60 Then
                If pressTimeAverage_LCTRL = 1 Then
                    ui_averagePressTime_LCTRL.Text = pressTimeAverage_LCTRL.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LCTRL.Text = pressTimeAverage_LCTRL.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LCTRL > 60 And pressTimeAverage_LCTRL < 3600 Then
                pressTimeTotal_LCTRL /= 60
                If pressTimeTotal_LCTRL = 1 Then
                    ui_averagePressTime_LCTRL.Text = pressTimeTotal_LCTRL.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LCTRL.Text = pressTimeTotal_LCTRL.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LCTRL > 3600 Or pressTimeAverage_LCTRL = 3600 Then
                pressTimeTotal_LCTRL /= 3600
                If pressTimeTotal_LCTRL = 1 Then
                    ui_averagePressTime_LCTRL.Text = pressTimeTotal_LCTRL.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LCTRL.Text = pressTimeTotal_LCTRL.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LCTRL.Text = ((pressCount_LCTRL / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LWIN
        If pressCount_LWIN > 0 Then 'Used

            ui_Panel_LWIN.BackColor = usedBackgroundColor
            ui_Label_LWIN.BackColor = usedBackgroundColor
            ui_Label_LWIN.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LWIN.BackColor = usedBackgroundColor
            ui_totalPresses_LWIN.ForeColor = usedStatFontColor
            ui_totalPressTime_LWIN.BackColor = usedBackgroundColor
            ui_totalPressTime_LWIN.ForeColor = usedStatFontColor
            ui_averagePressTime_LWIN.BackColor = usedBackgroundColor
            ui_averagePressTime_LWIN.ForeColor = usedStatFontColor
            ui_percent_LWIN.BackColor = usedBackgroundColor
            ui_percent_LWIN.ForeColor = usedStatFontColor
            ui_bind_LWIN.BackColor = usedTextboxBackgroundColor
            ui_bind_LWIN.ForeColor = usedStatFontColor
            ui_totalPresses_LWIN.Text = pressCount_LWIN.ToString

            Dim tempLWINtime As Decimal = 0

            If pressTimeTotal_LWIN < 60 Then
                If pressTimeTotalConverted_LWIN = 1 Then
                    ui_totalPressTime_LWIN.Text = pressTimeTotal_LWIN.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LWIN.Text = pressTimeTotal_LWIN.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LWIN > 60 And pressTimeTotal_LWIN < 3600 Then
                tempLWINtime = pressTimeTotal_LWIN / 60
                If pressTimeTotal_LWIN = 1 Then
                    ui_totalPressTime_LWIN.Text = tempLWINtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LWIN.Text = tempLWINtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LWIN > 3600 Or pressTimeTotal_LWIN = 3600 Then
                tempLWINtime = pressTimeTotal_LWIN / 3600
                If tempLWINtime = 1 Then
                    ui_totalPressTime_LWIN.Text = tempLWINtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LWIN.Text = tempLWINtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LWIN = pressTimeTotal_LWIN / pressCount_LWIN

            If pressTimeAverage_LWIN < 60 Then
                If pressTimeAverage_LWIN = 1 Then
                    ui_averagePressTime_LWIN.Text = pressTimeAverage_LWIN.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LWIN.Text = pressTimeAverage_LWIN.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LWIN > 60 And pressTimeAverage_LWIN < 3600 Then
                pressTimeTotal_LWIN /= 60
                If pressTimeTotal_LWIN = 1 Then
                    ui_averagePressTime_LWIN.Text = pressTimeTotal_LWIN.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LWIN.Text = pressTimeTotal_LWIN.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LWIN > 3600 Or pressTimeAverage_LWIN = 3600 Then
                pressTimeTotal_LWIN /= 3600
                If pressTimeTotal_LWIN = 1 Then
                    ui_averagePressTime_LWIN.Text = pressTimeTotal_LWIN.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LWIN.Text = pressTimeTotal_LWIN.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LWIN.Text = ((pressCount_LWIN / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LALT
        If pressCount_LALT > 0 Then 'Used

            ui_Panel_LALT.BackColor = usedBackgroundColor
            ui_Label_LALT.BackColor = usedBackgroundColor
            ui_Label_LALT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LALT.BackColor = usedBackgroundColor
            ui_totalPresses_LALT.ForeColor = usedStatFontColor
            ui_totalPressTime_LALT.BackColor = usedBackgroundColor
            ui_totalPressTime_LALT.ForeColor = usedStatFontColor
            ui_averagePressTime_LALT.BackColor = usedBackgroundColor
            ui_averagePressTime_LALT.ForeColor = usedStatFontColor
            ui_percent_LALT.BackColor = usedBackgroundColor
            ui_percent_LALT.ForeColor = usedStatFontColor
            ui_bind_LALT.BackColor = usedTextboxBackgroundColor
            ui_bind_LALT.ForeColor = usedStatFontColor
            ui_totalPresses_LALT.Text = pressCount_LALT.ToString

            Dim tempLALTtime As Decimal = 0

            If pressTimeTotal_LALT < 60 Then
                If pressTimeTotalConverted_LALT = 1 Then
                    ui_totalPressTime_LALT.Text = pressTimeTotal_LALT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LALT.Text = pressTimeTotal_LALT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LALT > 60 And pressTimeTotal_LALT < 3600 Then
                tempLALTtime = pressTimeTotal_LALT / 60
                If pressTimeTotal_LALT = 1 Then
                    ui_totalPressTime_LALT.Text = tempLALTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LALT.Text = tempLALTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LALT > 3600 Or pressTimeTotal_LALT = 3600 Then
                tempLALTtime = pressTimeTotal_LALT / 3600
                If tempLALTtime = 1 Then
                    ui_totalPressTime_LALT.Text = tempLALTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LALT.Text = tempLALTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LALT = pressTimeTotal_LALT / pressCount_LALT

            If pressTimeAverage_LALT < 60 Then
                If pressTimeAverage_LALT = 1 Then
                    ui_averagePressTime_LALT.Text = pressTimeAverage_LALT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LALT.Text = pressTimeAverage_LALT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LALT > 60 And pressTimeAverage_LALT < 3600 Then
                pressTimeTotal_LALT /= 60
                If pressTimeTotal_LALT = 1 Then
                    ui_averagePressTime_LALT.Text = pressTimeTotal_LALT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LALT.Text = pressTimeTotal_LALT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LALT > 3600 Or pressTimeAverage_LALT = 3600 Then
                pressTimeTotal_LALT /= 3600
                If pressTimeTotal_LALT = 1 Then
                    ui_averagePressTime_LALT.Text = pressTimeTotal_LALT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LALT.Text = pressTimeTotal_LALT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LALT.Text = ((pressCount_LALT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'SpaceBar
        If pressCount_SpaceBar > 0 Then 'Used

            ui_Panel_SpaceBar.BackColor = usedBackgroundColor
            ui_Label_SpaceBar.BackColor = usedBackgroundColor
            ui_Label_SpaceBar.ForeColor = usedKeyNameFontColor
            ui_totalPresses_SpaceBar.BackColor = usedBackgroundColor
            ui_totalPresses_SpaceBar.ForeColor = usedStatFontColor
            ui_totalPressTime_SpaceBar.BackColor = usedBackgroundColor
            ui_totalPressTime_SpaceBar.ForeColor = usedStatFontColor
            ui_averagePressTime_SpaceBar.BackColor = usedBackgroundColor
            ui_averagePressTime_SpaceBar.ForeColor = usedStatFontColor
            ui_percent_SpaceBar.BackColor = usedBackgroundColor
            ui_percent_SpaceBar.ForeColor = usedStatFontColor
            ui_bind_SpaceBar.BackColor = usedTextboxBackgroundColor
            ui_bind_SpaceBar.ForeColor = usedStatFontColor
            ui_totalPresses_SpaceBar.Text = pressCount_SpaceBar.ToString

            Dim tempSpaceBartime As Decimal = 0

            If pressTimeTotal_SpaceBar < 60 Then
                If pressTimeTotalConverted_SpaceBar = 1 Then
                    ui_totalPressTime_SpaceBar.Text = pressTimeTotal_SpaceBar.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_SpaceBar.Text = pressTimeTotal_SpaceBar.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_SpaceBar > 60 And pressTimeTotal_SpaceBar < 3600 Then
                tempSpaceBartime = pressTimeTotal_SpaceBar / 60
                If pressTimeTotal_SpaceBar = 1 Then
                    ui_totalPressTime_SpaceBar.Text = tempSpaceBartime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_SpaceBar.Text = tempSpaceBartime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_SpaceBar > 3600 Or pressTimeTotal_SpaceBar = 3600 Then
                tempSpaceBartime = pressTimeTotal_SpaceBar / 3600
                If tempSpaceBartime = 1 Then
                    ui_totalPressTime_SpaceBar.Text = tempSpaceBartime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_SpaceBar.Text = tempSpaceBartime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_SpaceBar = pressTimeTotal_SpaceBar / pressCount_SpaceBar

            If pressTimeAverage_SpaceBar < 60 Then
                If pressTimeAverage_SpaceBar = 1 Then
                    ui_averagePressTime_SpaceBar.Text = pressTimeAverage_SpaceBar.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_SpaceBar.Text = pressTimeAverage_SpaceBar.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_SpaceBar > 60 And pressTimeAverage_SpaceBar < 3600 Then
                pressTimeTotal_SpaceBar /= 60
                If pressTimeTotal_SpaceBar = 1 Then
                    ui_averagePressTime_SpaceBar.Text = pressTimeTotal_SpaceBar.ToString("N3") & " min"
                Else
                    ui_averagePressTime_SpaceBar.Text = pressTimeTotal_SpaceBar.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_SpaceBar > 3600 Or pressTimeAverage_SpaceBar = 3600 Then
                pressTimeTotal_SpaceBar /= 3600
                If pressTimeTotal_SpaceBar = 1 Then
                    ui_averagePressTime_SpaceBar.Text = pressTimeTotal_SpaceBar.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_SpaceBar.Text = pressTimeTotal_SpaceBar.ToString("N3") & " hours"
                End If
            End If

            ui_percent_SpaceBar.Text = ((pressCount_SpaceBar / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'RALT
        If pressCount_RALT > 0 Then 'Used

            ui_Panel_RALT.BackColor = usedBackgroundColor
            ui_Label_RALT.BackColor = usedBackgroundColor
            ui_Label_RALT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_RALT.BackColor = usedBackgroundColor
            ui_totalPresses_RALT.ForeColor = usedStatFontColor
            ui_totalPressTime_RALT.BackColor = usedBackgroundColor
            ui_totalPressTime_RALT.ForeColor = usedStatFontColor
            ui_averagePressTime_RALT.BackColor = usedBackgroundColor
            ui_averagePressTime_RALT.ForeColor = usedStatFontColor
            ui_percent_RALT.BackColor = usedBackgroundColor
            ui_percent_RALT.ForeColor = usedStatFontColor
            ui_bind_RALT.BackColor = usedTextboxBackgroundColor
            ui_bind_RALT.ForeColor = usedStatFontColor
            ui_totalPresses_RALT.Text = pressCount_RALT.ToString

            Dim tempRALTtime As Decimal = 0

            If pressTimeTotal_RALT < 60 Then
                If pressTimeTotalConverted_RALT = 1 Then
                    ui_totalPressTime_RALT.Text = pressTimeTotal_RALT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_RALT.Text = pressTimeTotal_RALT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_RALT > 60 And pressTimeTotal_RALT < 3600 Then
                tempRALTtime = pressTimeTotal_RALT / 60
                If pressTimeTotal_RALT = 1 Then
                    ui_totalPressTime_RALT.Text = tempRALTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_RALT.Text = tempRALTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_RALT > 3600 Or pressTimeTotal_RALT = 3600 Then
                tempRALTtime = pressTimeTotal_RALT / 3600
                If tempRALTtime = 1 Then
                    ui_totalPressTime_RALT.Text = tempRALTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_RALT.Text = tempRALTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_RALT = pressTimeTotal_RALT / pressCount_RALT

            If pressTimeAverage_RALT < 60 Then
                If pressTimeAverage_RALT = 1 Then
                    ui_averagePressTime_RALT.Text = pressTimeAverage_RALT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_RALT.Text = pressTimeAverage_RALT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_RALT > 60 And pressTimeAverage_RALT < 3600 Then
                pressTimeTotal_RALT /= 60
                If pressTimeTotal_RALT = 1 Then
                    ui_averagePressTime_RALT.Text = pressTimeTotal_RALT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_RALT.Text = pressTimeTotal_RALT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_RALT > 3600 Or pressTimeAverage_RALT = 3600 Then
                pressTimeTotal_RALT /= 3600
                If pressTimeTotal_RALT = 1 Then
                    ui_averagePressTime_RALT.Text = pressTimeTotal_RALT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_RALT.Text = pressTimeTotal_RALT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_RALT.Text = ((pressCount_RALT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'RWIN
        If pressCount_RWIN > 0 Then 'Used

            ui_Panel_RWIN.BackColor = usedBackgroundColor
            ui_Label_RWIN.BackColor = usedBackgroundColor
            ui_Label_RWIN.ForeColor = usedKeyNameFontColor
            ui_totalPresses_RWIN.BackColor = usedBackgroundColor
            ui_totalPresses_RWIN.ForeColor = usedStatFontColor
            ui_totalPressTime_RWIN.BackColor = usedBackgroundColor
            ui_totalPressTime_RWIN.ForeColor = usedStatFontColor
            ui_averagePressTime_RWIN.BackColor = usedBackgroundColor
            ui_averagePressTime_RWIN.ForeColor = usedStatFontColor
            ui_percent_RWIN.BackColor = usedBackgroundColor
            ui_percent_RWIN.ForeColor = usedStatFontColor
            ui_bind_RWIN.BackColor = usedTextboxBackgroundColor
            ui_bind_RWIN.ForeColor = usedStatFontColor
            ui_totalPresses_RWIN.Text = pressCount_RWIN.ToString

            Dim tempRWINtime As Decimal = 0

            If pressTimeTotal_RWIN < 60 Then
                If pressTimeTotalConverted_RWIN = 1 Then
                    ui_totalPressTime_RWIN.Text = pressTimeTotal_RWIN.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_RWIN.Text = pressTimeTotal_RWIN.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_RWIN > 60 And pressTimeTotal_RWIN < 3600 Then
                tempRWINtime = pressTimeTotal_RWIN / 60
                If pressTimeTotal_RWIN = 1 Then
                    ui_totalPressTime_RWIN.Text = tempRWINtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_RWIN.Text = tempRWINtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_RWIN > 3600 Or pressTimeTotal_RWIN = 3600 Then
                tempRWINtime = pressTimeTotal_RWIN / 3600
                If tempRWINtime = 1 Then
                    ui_totalPressTime_RWIN.Text = tempRWINtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_RWIN.Text = tempRWINtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_RWIN = pressTimeTotal_RWIN / pressCount_RWIN

            If pressTimeAverage_RWIN < 60 Then
                If pressTimeAverage_RWIN = 1 Then
                    ui_averagePressTime_RWIN.Text = pressTimeAverage_RWIN.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_RWIN.Text = pressTimeAverage_RWIN.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_RWIN > 60 And pressTimeAverage_RWIN < 3600 Then
                pressTimeTotal_RWIN /= 60
                If pressTimeTotal_RWIN = 1 Then
                    ui_averagePressTime_RWIN.Text = pressTimeTotal_RWIN.ToString("N3") & " min"
                Else
                    ui_averagePressTime_RWIN.Text = pressTimeTotal_RWIN.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_RWIN > 3600 Or pressTimeAverage_RWIN = 3600 Then
                pressTimeTotal_RWIN /= 3600
                If pressTimeTotal_RWIN = 1 Then
                    ui_averagePressTime_RWIN.Text = pressTimeTotal_RWIN.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_RWIN.Text = pressTimeTotal_RWIN.ToString("N3") & " hours"
                End If
            End If

            ui_percent_RWIN.Text = ((pressCount_RWIN / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'APPS
        If pressCount_APPS > 0 Then 'Used

            ui_Panel_APPS.BackColor = usedBackgroundColor
            ui_Label_APPS.BackColor = usedBackgroundColor
            ui_Label_APPS.ForeColor = usedKeyNameFontColor
            ui_totalPresses_APPS.BackColor = usedBackgroundColor
            ui_totalPresses_APPS.ForeColor = usedStatFontColor
            ui_totalPressTime_APPS.BackColor = usedBackgroundColor
            ui_totalPressTime_APPS.ForeColor = usedStatFontColor
            ui_averagePressTime_APPS.BackColor = usedBackgroundColor
            ui_averagePressTime_APPS.ForeColor = usedStatFontColor
            ui_percent_APPS.BackColor = usedBackgroundColor
            ui_percent_APPS.ForeColor = usedStatFontColor
            ui_bind_APPS.BackColor = usedTextboxBackgroundColor
            ui_bind_APPS.ForeColor = usedStatFontColor
            ui_totalPresses_APPS.Text = pressCount_APPS.ToString

            Dim tempAPPStime As Decimal = 0

            If pressTimeTotal_APPS < 60 Then
                If pressTimeTotalConverted_APPS = 1 Then
                    ui_totalPressTime_APPS.Text = pressTimeTotal_APPS.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_APPS.Text = pressTimeTotal_APPS.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_APPS > 60 And pressTimeTotal_APPS < 3600 Then
                tempAPPStime = pressTimeTotal_APPS / 60
                If pressTimeTotal_APPS = 1 Then
                    ui_totalPressTime_APPS.Text = tempAPPStime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_APPS.Text = tempAPPStime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_APPS > 3600 Or pressTimeTotal_APPS = 3600 Then
                tempAPPStime = pressTimeTotal_APPS / 3600
                If tempAPPStime = 1 Then
                    ui_totalPressTime_APPS.Text = tempAPPStime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_APPS.Text = tempAPPStime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_APPS = pressTimeTotal_APPS / pressCount_APPS

            If pressTimeAverage_APPS < 60 Then
                If pressTimeAverage_APPS = 1 Then
                    ui_averagePressTime_APPS.Text = pressTimeAverage_APPS.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_APPS.Text = pressTimeAverage_APPS.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_APPS > 60 And pressTimeAverage_APPS < 3600 Then
                pressTimeTotal_APPS /= 60
                If pressTimeTotal_APPS = 1 Then
                    ui_averagePressTime_APPS.Text = pressTimeTotal_APPS.ToString("N3") & " min"
                Else
                    ui_averagePressTime_APPS.Text = pressTimeTotal_APPS.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_APPS > 3600 Or pressTimeAverage_APPS = 3600 Then
                pressTimeTotal_APPS /= 3600
                If pressTimeTotal_APPS = 1 Then
                    ui_averagePressTime_APPS.Text = pressTimeTotal_APPS.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_APPS.Text = pressTimeTotal_APPS.ToString("N3") & " hours"
                End If
            End If

            ui_percent_APPS.Text = ((pressCount_APPS / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'RCTRL
        If pressCount_RCTRL > 0 Then 'Used

            ui_Panel_RCTRL.BackColor = usedBackgroundColor
            ui_Label_RCTRL.BackColor = usedBackgroundColor
            ui_Label_RCTRL.ForeColor = usedKeyNameFontColor
            ui_totalPresses_RCTRL.BackColor = usedBackgroundColor
            ui_totalPresses_RCTRL.ForeColor = usedStatFontColor
            ui_totalPressTime_RCTRL.BackColor = usedBackgroundColor
            ui_totalPressTime_RCTRL.ForeColor = usedStatFontColor
            ui_averagePressTime_RCTRL.BackColor = usedBackgroundColor
            ui_averagePressTime_RCTRL.ForeColor = usedStatFontColor
            ui_percent_RCTRL.BackColor = usedBackgroundColor
            ui_percent_RCTRL.ForeColor = usedStatFontColor
            ui_bind_RCTRL.BackColor = usedTextboxBackgroundColor
            ui_bind_RCTRL.ForeColor = usedStatFontColor
            ui_totalPresses_RCTRL.Text = pressCount_RCTRL.ToString

            Dim tempRCTRLtime As Decimal = 0

            If pressTimeTotal_RCTRL < 60 Then
                If pressTimeTotalConverted_RCTRL = 1 Then
                    ui_totalPressTime_RCTRL.Text = pressTimeTotal_RCTRL.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_RCTRL.Text = pressTimeTotal_RCTRL.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_RCTRL > 60 And pressTimeTotal_RCTRL < 3600 Then
                tempRCTRLtime = pressTimeTotal_RCTRL / 60
                If pressTimeTotal_RCTRL = 1 Then
                    ui_totalPressTime_RCTRL.Text = tempRCTRLtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_RCTRL.Text = tempRCTRLtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_RCTRL > 3600 Or pressTimeTotal_RCTRL = 3600 Then
                tempRCTRLtime = pressTimeTotal_RCTRL / 3600
                If tempRCTRLtime = 1 Then
                    ui_totalPressTime_RCTRL.Text = tempRCTRLtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_RCTRL.Text = tempRCTRLtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_RCTRL = pressTimeTotal_RCTRL / pressCount_RCTRL

            If pressTimeAverage_RCTRL < 60 Then
                If pressTimeAverage_RCTRL = 1 Then
                    ui_averagePressTime_RCTRL.Text = pressTimeAverage_RCTRL.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_RCTRL.Text = pressTimeAverage_RCTRL.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_RCTRL > 60 And pressTimeAverage_RCTRL < 3600 Then
                pressTimeTotal_RCTRL /= 60
                If pressTimeTotal_RCTRL = 1 Then
                    ui_averagePressTime_RCTRL.Text = pressTimeTotal_RCTRL.ToString("N3") & " min"
                Else
                    ui_averagePressTime_RCTRL.Text = pressTimeTotal_RCTRL.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_RCTRL > 3600 Or pressTimeAverage_RCTRL = 3600 Then
                pressTimeTotal_RCTRL /= 3600
                If pressTimeTotal_RCTRL = 1 Then
                    ui_averagePressTime_RCTRL.Text = pressTimeTotal_RCTRL.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_RCTRL.Text = pressTimeTotal_RCTRL.ToString("N3") & " hours"
                End If
            End If

            ui_percent_RCTRL.Text = ((pressCount_RCTRL / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LT
        If pressCount_LT > 0 Then 'Used

            ui_Panel_LT.BackColor = usedBackgroundColor
            ui_Label_LT.BackColor = usedBackgroundColor
            ui_Label_LT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LT.BackColor = usedBackgroundColor
            ui_totalPresses_LT.ForeColor = usedStatFontColor
            ui_totalPressTime_LT.BackColor = usedBackgroundColor
            ui_totalPressTime_LT.ForeColor = usedStatFontColor
            ui_averagePressTime_LT.BackColor = usedBackgroundColor
            ui_averagePressTime_LT.ForeColor = usedStatFontColor
            ui_percent_LT.BackColor = usedBackgroundColor
            ui_percent_LT.ForeColor = usedStatFontColor
            ui_bind_LT.BackColor = usedTextboxBackgroundColor
            ui_bind_LT.ForeColor = usedStatFontColor
            ui_totalPresses_LT.Text = pressCount_LT.ToString

            Dim tempLTtime As Decimal = 0

            If pressTimeTotal_LT < 60 Then
                If pressTimeTotalConverted_LT = 1 Then
                    ui_totalPressTime_LT.Text = pressTimeTotal_LT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LT.Text = pressTimeTotal_LT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LT > 60 And pressTimeTotal_LT < 3600 Then
                tempLTtime = pressTimeTotal_LT / 60
                If pressTimeTotal_LT = 1 Then
                    ui_totalPressTime_LT.Text = tempLTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LT.Text = tempLTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LT > 3600 Or pressTimeTotal_LT = 3600 Then
                tempLTtime = pressTimeTotal_LT / 3600
                If tempLTtime = 1 Then
                    ui_totalPressTime_LT.Text = tempLTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LT.Text = tempLTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LT = pressTimeTotal_LT / pressCount_LT

            If pressTimeAverage_LT < 60 Then
                If pressTimeAverage_LT = 1 Then
                    ui_averagePressTime_LT.Text = pressTimeAverage_LT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LT.Text = pressTimeAverage_LT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LT > 60 And pressTimeAverage_LT < 3600 Then
                pressTimeTotal_LT /= 60
                If pressTimeTotal_LT = 1 Then
                    ui_averagePressTime_LT.Text = pressTimeTotal_LT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LT.Text = pressTimeTotal_LT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LT > 3600 Or pressTimeAverage_LT = 3600 Then
                pressTimeTotal_LT /= 3600
                If pressTimeTotal_LT = 1 Then
                    ui_averagePressTime_LT.Text = pressTimeTotal_LT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LT.Text = pressTimeTotal_LT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LT.Text = ((pressCount_LT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'DN
        If pressCount_DN > 0 Then 'Used

            ui_Panel_DN.BackColor = usedBackgroundColor
            ui_Label_DN.BackColor = usedBackgroundColor
            ui_Label_DN.ForeColor = usedKeyNameFontColor
            ui_totalPresses_DN.BackColor = usedBackgroundColor
            ui_totalPresses_DN.ForeColor = usedStatFontColor
            ui_totalPressTime_DN.BackColor = usedBackgroundColor
            ui_totalPressTime_DN.ForeColor = usedStatFontColor
            ui_averagePressTime_DN.BackColor = usedBackgroundColor
            ui_averagePressTime_DN.ForeColor = usedStatFontColor
            ui_percent_DN.BackColor = usedBackgroundColor
            ui_percent_DN.ForeColor = usedStatFontColor
            ui_bind_DN.BackColor = usedTextboxBackgroundColor
            ui_bind_DN.ForeColor = usedStatFontColor
            ui_totalPresses_DN.Text = pressCount_DN.ToString

            Dim tempDNtime As Decimal = 0

            If pressTimeTotal_DN < 60 Then
                If pressTimeTotalConverted_DN = 1 Then
                    ui_totalPressTime_DN.Text = pressTimeTotal_DN.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_DN.Text = pressTimeTotal_DN.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_DN > 60 And pressTimeTotal_DN < 3600 Then
                tempDNtime = pressTimeTotal_DN / 60
                If pressTimeTotal_DN = 1 Then
                    ui_totalPressTime_DN.Text = tempDNtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_DN.Text = tempDNtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_DN > 3600 Or pressTimeTotal_DN = 3600 Then
                tempDNtime = pressTimeTotal_DN / 3600
                If tempDNtime = 1 Then
                    ui_totalPressTime_DN.Text = tempDNtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_DN.Text = tempDNtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_DN = pressTimeTotal_DN / pressCount_DN

            If pressTimeAverage_DN < 60 Then
                If pressTimeAverage_DN = 1 Then
                    ui_averagePressTime_DN.Text = pressTimeAverage_DN.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_DN.Text = pressTimeAverage_DN.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_DN > 60 And pressTimeAverage_DN < 3600 Then
                pressTimeTotal_DN /= 60
                If pressTimeTotal_DN = 1 Then
                    ui_averagePressTime_DN.Text = pressTimeTotal_DN.ToString("N3") & " min"
                Else
                    ui_averagePressTime_DN.Text = pressTimeTotal_DN.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_DN > 3600 Or pressTimeAverage_DN = 3600 Then
                pressTimeTotal_DN /= 3600
                If pressTimeTotal_DN = 1 Then
                    ui_averagePressTime_DN.Text = pressTimeTotal_DN.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_DN.Text = pressTimeTotal_DN.ToString("N3") & " hours"
                End If
            End If

            ui_percent_DN.Text = ((pressCount_DN / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'RT
        If pressCount_RT > 0 Then 'Used

            ui_Panel_RT.BackColor = usedBackgroundColor
            ui_Label_RT.BackColor = usedBackgroundColor
            ui_Label_RT.ForeColor = usedKeyNameFontColor
            ui_totalPresses_RT.BackColor = usedBackgroundColor
            ui_totalPresses_RT.ForeColor = usedStatFontColor
            ui_totalPressTime_RT.BackColor = usedBackgroundColor
            ui_totalPressTime_RT.ForeColor = usedStatFontColor
            ui_averagePressTime_RT.BackColor = usedBackgroundColor
            ui_averagePressTime_RT.ForeColor = usedStatFontColor
            ui_percent_RT.BackColor = usedBackgroundColor
            ui_percent_RT.ForeColor = usedStatFontColor
            ui_bind_RT.BackColor = usedTextboxBackgroundColor
            ui_bind_RT.ForeColor = usedStatFontColor
            ui_totalPresses_RT.Text = pressCount_RT.ToString

            Dim tempRTtime As Decimal = 0

            If pressTimeTotal_RT < 60 Then
                If pressTimeTotalConverted_RT = 1 Then
                    ui_totalPressTime_RT.Text = pressTimeTotal_RT.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_RT.Text = pressTimeTotal_RT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_RT > 60 And pressTimeTotal_RT < 3600 Then
                tempRTtime = pressTimeTotal_RT / 60
                If pressTimeTotal_RT = 1 Then
                    ui_totalPressTime_RT.Text = tempRTtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_RT.Text = tempRTtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_RT > 3600 Or pressTimeTotal_RT = 3600 Then
                tempRTtime = pressTimeTotal_RT / 3600
                If tempRTtime = 1 Then
                    ui_totalPressTime_RT.Text = tempRTtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_RT.Text = tempRTtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_RT = pressTimeTotal_RT / pressCount_RT

            If pressTimeAverage_RT < 60 Then
                If pressTimeAverage_RT = 1 Then
                    ui_averagePressTime_RT.Text = pressTimeAverage_RT.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_RT.Text = pressTimeAverage_RT.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_RT > 60 And pressTimeAverage_RT < 3600 Then
                pressTimeTotal_RT /= 60
                If pressTimeTotal_RT = 1 Then
                    ui_averagePressTime_RT.Text = pressTimeTotal_RT.ToString("N3") & " min"
                Else
                    ui_averagePressTime_RT.Text = pressTimeTotal_RT.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_RT > 3600 Or pressTimeAverage_RT = 3600 Then
                pressTimeTotal_RT /= 3600
                If pressTimeTotal_RT = 1 Then
                    ui_averagePressTime_RT.Text = pressTimeTotal_RT.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_RT.Text = pressTimeTotal_RT.ToString("N3") & " hours"
                End If
            End If

            ui_percent_RT.Text = ((pressCount_RT / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Num0
        If pressCount_Num0 > 0 Then 'Used

            ui_Panel_Num0.BackColor = usedBackgroundColor
            ui_Label_Num0.BackColor = usedBackgroundColor
            ui_Label_Num0.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Num0.BackColor = usedBackgroundColor
            ui_totalPresses_Num0.ForeColor = usedStatFontColor
            ui_totalPressTime_Num0.BackColor = usedBackgroundColor
            ui_totalPressTime_Num0.ForeColor = usedStatFontColor
            ui_averagePressTime_Num0.BackColor = usedBackgroundColor
            ui_averagePressTime_Num0.ForeColor = usedStatFontColor
            ui_percent_Num0.BackColor = usedBackgroundColor
            ui_percent_Num0.ForeColor = usedStatFontColor
            ui_bind_Num0.BackColor = usedTextboxBackgroundColor
            ui_bind_Num0.ForeColor = usedStatFontColor
            ui_totalPresses_Num0.Text = pressCount_Num0.ToString

            Dim tempNum0time As Decimal = 0

            If pressTimeTotal_Num0 < 60 Then
                If pressTimeTotalConverted_Num0 = 1 Then
                    ui_totalPressTime_Num0.Text = pressTimeTotal_Num0.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Num0.Text = pressTimeTotal_Num0.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Num0 > 60 And pressTimeTotal_Num0 < 3600 Then
                tempNum0time = pressTimeTotal_Num0 / 60
                If pressTimeTotal_Num0 = 1 Then
                    ui_totalPressTime_Num0.Text = tempNum0time.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Num0.Text = tempNum0time.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Num0 > 3600 Or pressTimeTotal_Num0 = 3600 Then
                tempNum0time = pressTimeTotal_Num0 / 3600
                If tempNum0time = 1 Then
                    ui_totalPressTime_Num0.Text = tempNum0time.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Num0.Text = tempNum0time.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Num0 = pressTimeTotal_Num0 / pressCount_Num0

            If pressTimeAverage_Num0 < 60 Then
                If pressTimeAverage_Num0 = 1 Then
                    ui_averagePressTime_Num0.Text = pressTimeAverage_Num0.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Num0.Text = pressTimeAverage_Num0.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Num0 > 60 And pressTimeAverage_Num0 < 3600 Then
                pressTimeTotal_Num0 /= 60
                If pressTimeTotal_Num0 = 1 Then
                    ui_averagePressTime_Num0.Text = pressTimeTotal_Num0.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Num0.Text = pressTimeTotal_Num0.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Num0 > 3600 Or pressTimeAverage_Num0 = 3600 Then
                pressTimeTotal_Num0 /= 3600
                If pressTimeTotal_Num0 = 1 Then
                    ui_averagePressTime_Num0.Text = pressTimeTotal_Num0.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Num0.Text = pressTimeTotal_Num0.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Num0.Text = ((pressCount_Num0 / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'Decimal
        If pressCount_Decimal > 0 Then 'Used

            ui_Panel_Decimal.BackColor = usedBackgroundColor
            ui_Label_Decimal.BackColor = usedBackgroundColor
            ui_Label_Decimal.ForeColor = usedKeyNameFontColor
            ui_totalPresses_Decimal.BackColor = usedBackgroundColor
            ui_totalPresses_Decimal.ForeColor = usedStatFontColor
            ui_totalPressTime_Decimal.BackColor = usedBackgroundColor
            ui_totalPressTime_Decimal.ForeColor = usedStatFontColor
            ui_averagePressTime_Decimal.BackColor = usedBackgroundColor
            ui_averagePressTime_Decimal.ForeColor = usedStatFontColor
            ui_percent_Decimal.BackColor = usedBackgroundColor
            ui_percent_Decimal.ForeColor = usedStatFontColor
            ui_bind_Decimal.BackColor = usedTextboxBackgroundColor
            ui_bind_Decimal.ForeColor = usedStatFontColor
            ui_totalPresses_Decimal.Text = pressCount_Decimal.ToString

            Dim tempDecimaltime As Decimal = 0

            If pressTimeTotal_Decimal < 60 Then
                If pressTimeTotalConverted_Decimal = 1 Then
                    ui_totalPressTime_Decimal.Text = pressTimeTotal_Decimal.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_Decimal.Text = pressTimeTotal_Decimal.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_Decimal > 60 And pressTimeTotal_Decimal < 3600 Then
                tempDecimaltime = pressTimeTotal_Decimal / 60
                If pressTimeTotal_Decimal = 1 Then
                    ui_totalPressTime_Decimal.Text = tempDecimaltime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_Decimal.Text = tempDecimaltime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_Decimal > 3600 Or pressTimeTotal_Decimal = 3600 Then
                tempDecimaltime = pressTimeTotal_Decimal / 3600
                If tempDecimaltime = 1 Then
                    ui_totalPressTime_Decimal.Text = tempDecimaltime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_Decimal.Text = tempDecimaltime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_Decimal = pressTimeTotal_Decimal / pressCount_Decimal

            If pressTimeAverage_Decimal < 60 Then
                If pressTimeAverage_Decimal = 1 Then
                    ui_averagePressTime_Decimal.Text = pressTimeAverage_Decimal.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_Decimal.Text = pressTimeAverage_Decimal.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_Decimal > 60 And pressTimeAverage_Decimal < 3600 Then
                pressTimeTotal_Decimal /= 60
                If pressTimeTotal_Decimal = 1 Then
                    ui_averagePressTime_Decimal.Text = pressTimeTotal_Decimal.ToString("N3") & " min"
                Else
                    ui_averagePressTime_Decimal.Text = pressTimeTotal_Decimal.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_Decimal > 3600 Or pressTimeAverage_Decimal = 3600 Then
                pressTimeTotal_Decimal /= 3600
                If pressTimeTotal_Decimal = 1 Then
                    ui_averagePressTime_Decimal.Text = pressTimeTotal_Decimal.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_Decimal.Text = pressTimeTotal_Decimal.ToString("N3") & " hours"
                End If
            End If

            ui_percent_Decimal.Text = ((pressCount_Decimal / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'LMB
        If pressCount_LMB > 0 Then 'Used

            ui_Panel_LMB.BackColor = usedBackgroundColor
            ui_Label_LMB.BackColor = usedBackgroundColor
            ui_Label_LMB.ForeColor = usedKeyNameFontColor
            ui_totalPresses_LMB.BackColor = usedBackgroundColor
            ui_totalPresses_LMB.ForeColor = usedStatFontColor
            ui_totalPressTime_LMB.BackColor = usedBackgroundColor
            ui_totalPressTime_LMB.ForeColor = usedStatFontColor
            ui_averagePressTime_LMB.BackColor = usedBackgroundColor
            ui_averagePressTime_LMB.ForeColor = usedStatFontColor
            ui_percent_LMB.BackColor = usedBackgroundColor
            ui_percent_LMB.ForeColor = usedStatFontColor
            ui_bind_LMB.BackColor = usedTextboxBackgroundColor
            ui_bind_LMB.ForeColor = usedStatFontColor
            ui_totalPresses_LMB.Text = pressCount_LMB.ToString

            Dim tempLMBtime As Decimal = 0

            If pressTimeTotal_LMB < 60 Then
                If pressTimeTotalConverted_LMB = 1 Then
                    ui_totalPressTime_LMB.Text = pressTimeTotal_LMB.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_LMB.Text = pressTimeTotal_LMB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_LMB > 60 And pressTimeTotal_LMB < 3600 Then
                tempLMBtime = pressTimeTotal_LMB / 60
                If pressTimeTotal_LMB = 1 Then
                    ui_totalPressTime_LMB.Text = tempLMBtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_LMB.Text = tempLMBtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_LMB > 3600 Or pressTimeTotal_LMB = 3600 Then
                tempLMBtime = pressTimeTotal_LMB / 3600
                If tempLMBtime = 1 Then
                    ui_totalPressTime_LMB.Text = tempLMBtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_LMB.Text = tempLMBtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_LMB = pressTimeTotal_LMB / pressCount_LMB

            If pressTimeAverage_LMB < 60 Then
                If pressTimeAverage_LMB = 1 Then
                    ui_averagePressTime_LMB.Text = pressTimeAverage_LMB.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_LMB.Text = pressTimeAverage_LMB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_LMB > 60 And pressTimeAverage_LMB < 3600 Then
                pressTimeTotal_LMB /= 60
                If pressTimeTotal_LMB = 1 Then
                    ui_averagePressTime_LMB.Text = pressTimeTotal_LMB.ToString("N3") & " min"
                Else
                    ui_averagePressTime_LMB.Text = pressTimeTotal_LMB.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_LMB > 3600 Or pressTimeAverage_LMB = 3600 Then
                pressTimeTotal_LMB /= 3600
                If pressTimeTotal_LMB = 1 Then
                    ui_averagePressTime_LMB.Text = pressTimeTotal_LMB.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_LMB.Text = pressTimeTotal_LMB.ToString("N3") & " hours"
                End If
            End If

            ui_percent_LMB.Text = ((pressCount_LMB / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'MMB
        If pressCount_MMB > 0 Then 'Used

            ui_Panel_MMB.BackColor = usedBackgroundColor
            ui_Label_MMB.BackColor = usedBackgroundColor
            ui_Label_MMB.ForeColor = usedKeyNameFontColor
            ui_totalPresses_MMB.BackColor = usedBackgroundColor
            ui_totalPresses_MMB.ForeColor = usedStatFontColor
            ui_totalPressTime_MMB.BackColor = usedBackgroundColor
            ui_totalPressTime_MMB.ForeColor = usedStatFontColor
            ui_averagePressTime_MMB.BackColor = usedBackgroundColor
            ui_averagePressTime_MMB.ForeColor = usedStatFontColor
            ui_percent_MMB.BackColor = usedBackgroundColor
            ui_percent_MMB.ForeColor = usedStatFontColor
            ui_bind_MMB.BackColor = usedTextboxBackgroundColor
            ui_bind_MMB.ForeColor = usedStatFontColor
            ui_totalPresses_MMB.Text = pressCount_MMB.ToString

            Dim tempMMBtime As Decimal = 0

            If pressTimeTotal_MMB < 60 Then
                If pressTimeTotalConverted_MMB = 1 Then
                    ui_totalPressTime_MMB.Text = pressTimeTotal_MMB.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_MMB.Text = pressTimeTotal_MMB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_MMB > 60 And pressTimeTotal_MMB < 3600 Then
                tempMMBtime = pressTimeTotal_MMB / 60
                If pressTimeTotal_MMB = 1 Then
                    ui_totalPressTime_MMB.Text = tempMMBtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_MMB.Text = tempMMBtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_MMB > 3600 Or pressTimeTotal_MMB = 3600 Then
                tempMMBtime = pressTimeTotal_MMB / 3600
                If tempMMBtime = 1 Then
                    ui_totalPressTime_MMB.Text = tempMMBtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_MMB.Text = tempMMBtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_MMB = pressTimeTotal_MMB / pressCount_MMB

            If pressTimeAverage_MMB < 60 Then
                If pressTimeAverage_MMB = 1 Then
                    ui_averagePressTime_MMB.Text = pressTimeAverage_MMB.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_MMB.Text = pressTimeAverage_MMB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_MMB > 60 And pressTimeAverage_MMB < 3600 Then
                pressTimeTotal_MMB /= 60
                If pressTimeTotal_MMB = 1 Then
                    ui_averagePressTime_MMB.Text = pressTimeTotal_MMB.ToString("N3") & " min"
                Else
                    ui_averagePressTime_MMB.Text = pressTimeTotal_MMB.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_MMB > 3600 Or pressTimeAverage_MMB = 3600 Then
                pressTimeTotal_MMB /= 3600
                If pressTimeTotal_MMB = 1 Then
                    ui_averagePressTime_MMB.Text = pressTimeTotal_MMB.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_MMB.Text = pressTimeTotal_MMB.ToString("N3") & " hours"
                End If
            End If

            ui_percent_MMB.Text = ((pressCount_MMB / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'RMB
        If pressCount_RMB > 0 Then 'Used

            ui_Panel_RMB.BackColor = usedBackgroundColor
            ui_Label_RMB.BackColor = usedBackgroundColor
            ui_Label_RMB.ForeColor = usedKeyNameFontColor
            ui_totalPresses_RMB.BackColor = usedBackgroundColor
            ui_totalPresses_RMB.ForeColor = usedStatFontColor
            ui_totalPressTime_RMB.BackColor = usedBackgroundColor
            ui_totalPressTime_RMB.ForeColor = usedStatFontColor
            ui_averagePressTime_RMB.BackColor = usedBackgroundColor
            ui_averagePressTime_RMB.ForeColor = usedStatFontColor
            ui_percent_RMB.BackColor = usedBackgroundColor
            ui_percent_RMB.ForeColor = usedStatFontColor
            ui_bind_RMB.BackColor = usedTextboxBackgroundColor
            ui_bind_RMB.ForeColor = usedStatFontColor
            ui_totalPresses_RMB.Text = pressCount_RMB.ToString

            Dim tempRMBtime As Decimal = 0

            If pressTimeTotal_RMB < 60 Then
                If pressTimeTotalConverted_RMB = 1 Then
                    ui_totalPressTime_RMB.Text = pressTimeTotal_RMB.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_RMB.Text = pressTimeTotal_RMB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_RMB > 60 And pressTimeTotal_RMB < 3600 Then
                tempRMBtime = pressTimeTotal_RMB / 60
                If pressTimeTotal_RMB = 1 Then
                    ui_totalPressTime_RMB.Text = tempRMBtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_RMB.Text = tempRMBtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_RMB > 3600 Or pressTimeTotal_RMB = 3600 Then
                tempRMBtime = pressTimeTotal_RMB / 3600
                If tempRMBtime = 1 Then
                    ui_totalPressTime_RMB.Text = tempRMBtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_RMB.Text = tempRMBtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_RMB = pressTimeTotal_RMB / pressCount_RMB

            If pressTimeAverage_RMB < 60 Then
                If pressTimeAverage_RMB = 1 Then
                    ui_averagePressTime_RMB.Text = pressTimeAverage_RMB.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_RMB.Text = pressTimeAverage_RMB.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_RMB > 60 And pressTimeAverage_RMB < 3600 Then
                pressTimeTotal_RMB /= 60
                If pressTimeTotal_RMB = 1 Then
                    ui_averagePressTime_RMB.Text = pressTimeTotal_RMB.ToString("N3") & " min"
                Else
                    ui_averagePressTime_RMB.Text = pressTimeTotal_RMB.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_RMB > 3600 Or pressTimeAverage_RMB = 3600 Then
                pressTimeTotal_RMB /= 3600
                If pressTimeTotal_RMB = 1 Then
                    ui_averagePressTime_RMB.Text = pressTimeTotal_RMB.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_RMB.Text = pressTimeTotal_RMB.ToString("N3") & " hours"
                End If
            End If

            ui_percent_RMB.Text = ((pressCount_RMB / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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

        End If

        'MSU
        If pressCount_MSU > 0 Then 'Used

            ui_Panel_MSU.BackColor = usedBackgroundColor
            ui_Label_MSU.BackColor = usedBackgroundColor
            ui_Label_MSU.ForeColor = usedKeyNameFontColor
            ui_totalPresses_MSU.BackColor = usedBackgroundColor
            ui_totalPresses_MSU.ForeColor = usedStatFontColor
            ui_totalPressTime_MSU.BackColor = usedBackgroundColor
            ui_totalPressTime_MSU.ForeColor = usedStatFontColor
            ui_averagePressTime_MSU.BackColor = usedBackgroundColor
            ui_averagePressTime_MSU.ForeColor = usedStatFontColor
            ui_percent_MSU.BackColor = usedBackgroundColor
            ui_percent_MSU.ForeColor = usedStatFontColor
            ui_bind_MSU.BackColor = usedTextboxBackgroundColor
            ui_bind_MSU.ForeColor = usedStatFontColor
            ui_totalPresses_MSU.Text = pressCount_MSU.ToString
            uiScrollDistanceUP.ForeColor = usedStatFontColor
            uiScrollDistanceTotal.ForeColor = usedStatFontColor

            Dim tempMSUtime As Decimal = 0

            If pressTimeTotal_MSU < 60 Then
                If pressTimeTotalConverted_MSU = 1 Then
                    ui_totalPressTime_MSU.Text = pressTimeTotal_MSU.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_MSU.Text = pressTimeTotal_MSU.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_MSU > 60 And pressTimeTotal_MSU < 3600 Then
                tempMSUtime = pressTimeTotal_MSU / 60
                If pressTimeTotal_MSU = 1 Then
                    ui_totalPressTime_MSU.Text = tempMSUtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_MSU.Text = tempMSUtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_MSU > 3600 Or pressTimeTotal_MSU = 3600 Then
                tempMSUtime = pressTimeTotal_MSU / 3600
                If tempMSUtime = 1 Then
                    ui_totalPressTime_MSU.Text = tempMSUtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_MSU.Text = tempMSUtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_MSU = pressTimeTotal_MSU / pressCount_MSU

            If pressTimeAverage_MSU < 60 Then
                If pressTimeAverage_MSU = 1 Then
                    ui_averagePressTime_MSU.Text = pressTimeAverage_MSU.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_MSU.Text = pressTimeAverage_MSU.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_MSU > 60 And pressTimeAverage_MSU < 3600 Then
                pressTimeTotal_MSU /= 60
                If pressTimeTotal_MSU = 1 Then
                    ui_averagePressTime_MSU.Text = pressTimeTotal_MSU.ToString("N3") & " min"
                Else
                    ui_averagePressTime_MSU.Text = pressTimeTotal_MSU.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_MSU > 3600 Or pressTimeAverage_MSU = 3600 Then
                pressTimeTotal_MSU /= 3600
                If pressTimeTotal_MSU = 1 Then
                    ui_averagePressTime_MSU.Text = pressTimeTotal_MSU.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_MSU.Text = pressTimeTotal_MSU.ToString("N3") & " hours"
                End If
            End If

            ui_percent_MSU.Text = ((pressCount_MSU / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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
            uiScrollDistanceUP.ForeColor = unusedStatFontColor
            uiScrollDistanceTotal.ForeColor = unusedStatFontColor


        End If

        'MSD
        If pressCount_MSD > 0 Then 'Used

            ui_Panel_MSD.BackColor = usedBackgroundColor
            ui_Label_MSD.BackColor = usedBackgroundColor
            ui_Label_MSD.ForeColor = usedKeyNameFontColor
            ui_totalPresses_MSD.BackColor = usedBackgroundColor
            ui_totalPresses_MSD.ForeColor = usedStatFontColor
            ui_totalPressTime_MSD.BackColor = usedBackgroundColor
            ui_totalPressTime_MSD.ForeColor = usedStatFontColor
            ui_averagePressTime_MSD.BackColor = usedBackgroundColor
            ui_averagePressTime_MSD.ForeColor = usedStatFontColor
            ui_percent_MSD.BackColor = usedBackgroundColor
            ui_percent_MSD.ForeColor = usedStatFontColor
            ui_bind_MSD.BackColor = usedTextboxBackgroundColor
            ui_bind_MSD.ForeColor = usedStatFontColor
            ui_totalPresses_MSD.Text = pressCount_MSD.ToString
            uiScrollDistanceTotal.ForeColor = usedStatFontColor
            uiScrollDistanceDN.ForeColor = usedStatFontColor

            Dim tempMSDtime As Decimal = 0

            If pressTimeTotal_MSD < 60 Then
                If pressTimeTotalConverted_MSD = 1 Then
                    ui_totalPressTime_MSD.Text = pressTimeTotal_MSD.ToString("N3") & " sec"
                Else
                    ui_totalPressTime_MSD.Text = pressTimeTotal_MSD.ToString("N3") & " secs"
                End If
            ElseIf pressTimeTotal_MSD > 60 And pressTimeTotal_MSD < 3600 Then
                tempMSDtime = pressTimeTotal_MSD / 60
                If pressTimeTotal_MSD = 1 Then
                    ui_totalPressTime_MSD.Text = tempMSDtime.ToString("N3") & " min"
                Else
                    ui_totalPressTime_MSD.Text = tempMSDtime.ToString("N3") & " mins"
                End If
            ElseIf pressTimeTotal_MSD > 3600 Or pressTimeTotal_MSD = 3600 Then
                tempMSDtime = pressTimeTotal_MSD / 3600
                If tempMSDtime = 1 Then
                    ui_totalPressTime_MSD.Text = tempMSDtime.ToString("N3") & " hour"
                Else
                    ui_totalPressTime_MSD.Text = tempMSDtime.ToString("N3") & " hours"
                End If
            End If

            pressTimeAverage_MSD = pressTimeTotal_MSD / pressCount_MSD

            If pressTimeAverage_MSD < 60 Then
                If pressTimeAverage_MSD = 1 Then
                    ui_averagePressTime_MSD.Text = pressTimeAverage_MSD.ToString("N3") & " sec"
                Else
                    ui_averagePressTime_MSD.Text = pressTimeAverage_MSD.ToString("N3") & " secs"
                End If
            ElseIf pressTimeAverage_MSD > 60 And pressTimeAverage_MSD < 3600 Then
                pressTimeTotal_MSD /= 60
                If pressTimeTotal_MSD = 1 Then
                    ui_averagePressTime_MSD.Text = pressTimeTotal_MSD.ToString("N3") & " min"
                Else
                    ui_averagePressTime_MSD.Text = pressTimeTotal_MSD.ToString("N3") & " mins"
                End If
            ElseIf pressTimeAverage_MSD > 3600 Or pressTimeAverage_MSD = 3600 Then
                pressTimeTotal_MSD /= 3600
                If pressTimeTotal_MSD = 1 Then
                    ui_averagePressTime_MSD.Text = pressTimeTotal_MSD.ToString("N4") & " hour"
                Else
                    ui_averagePressTime_MSD.Text = pressTimeTotal_MSD.ToString("N3") & " hours"
                End If
            End If

            ui_percent_MSD.Text = ((pressCount_MSD / totalPresses) * 100).ToString("N3") & "%"

        Else 'Unused

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
            uiScrollDistanceTotal.ForeColor = unusedStatFontColor
            uiScrollDistanceDN.ForeColor = unusedStatFontColor

        End If







        uiScrollDistanceTotal.Text = mouseScrollTravel_Total.ToString("N3") & " mm"







        uiScrollDistanceUP.Text = mouseScrollTravel_UP.ToString("N3") & " mm"








        uiScrollDistanceDN.Text = mouseScrollTravel_DN.ToString("N3") & " mm"


    End Sub

    'Mouse Wheel Tracking
    Sub MouseWheelAction(sender As Object, e As InputHelper.EventArgs.MouseHookEventArgs) Handles MouseHook.MouseWheel

        If e.Delta > 0 Then 'UP

            pressCount_MSU += 1
            totalPresses += 1
            pressTimeTotalConverted_MSU = CDec(0.085)
            pressTimeTotal_MSU += pressTimeTotalConverted_MSU
            totalPressTime += pressTimeTotalConverted_MSU
            mouseScrollTravel_UP += CDec(mouseScroll_mm)
            mouseScrollTravel_Total += CDec(mouseScroll_mm)

        Else 'DN

            pressCount_MSD += 1
            totalPresses += 1
            pressTimeTotalConverted_MSD = CDec(0.085)
            pressTimeTotal_MSD += pressTimeTotalConverted_MSD
            totalPressTime += pressTimeTotalConverted_MSD
            mouseScrollTravel_DN += CDec(mouseScroll_mm)
            mouseScrollTravel_Total += CDec(mouseScroll_mm)

        End If

    End Sub

    'Session Check Stop
    Sub SessionCheckStop() Handles Button1.Click

        session_Check = 1
        session_EndTime = DateTime.Now

    End Sub

    'Session Check Go
    Sub SessionCheckNew() Handles uiNewSession.Click

        If uiNewSessionCheck.Checked = False Then

        Else

            session_StartTime = DateTime.Now
            session_Check = 0
            uiNewSessionCheck.Checked = False
            uiResetAllDataCheck.Checked = True
            DataReset()

        End If

    End Sub

End Class