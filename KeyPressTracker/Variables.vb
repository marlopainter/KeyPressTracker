
Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices
Imports System.Threading

Partial Public Class MainForm

    '===============
    'Color Variables
    '===============
    Dim usedBackgroundColor As Color = System.Drawing.Color.FromArgb(20, 20, 20)
    Dim unusedKeyBackgroundColor As Color = System.Drawing.Color.FromArgb(5, 5, 5)

    Dim usedTextboxBackgroundColor As Color = System.Drawing.Color.FromArgb(50, 50, 50)
    Dim unusedTextboxBackgroundColor As Color = System.Drawing.Color.FromArgb(25, 25, 25)

    Dim usedStatFontColor As Color = System.Drawing.Color.Gainsboro
    Dim unusedStatFontColor As Color = System.Drawing.Color.DimGray

    Dim usedKeyNameFontColor As Color = System.Drawing.Color.Yellow
    Dim unusedKeyNameFontColor As Color = System.Drawing.Color.DarkGoldenrod





    '==========
    'Mouse Hook
    '==========
    Dim WithEvents MouseHook As New InputHelper.Hooks.MouseHook()




    '=======
    'Threads
    '=======
    Dim checkKeysThread As New Thread(AddressOf CheckKeyState) With {
            .IsBackground = True
        }

    Dim processKeysThread As New Thread(AddressOf ProcessKeyState) With {
            .IsBackground = True
        }


    '==================
    'Function Variables
    '==================
    Dim tempInterval As New TimeSpan
    Dim tempSeconds As Double

    Dim tempSessionInterval As New TimeSpan
    Dim tempMinutes As Double

    '=================
    'Session Variables
    '=================

    Dim session_Check As Integer = 0

    Dim session_StartTime As DateTime
    Dim session_EndTime As DateTime

    Dim session_Interval_Seconds As Decimal

    Dim session_TotalPresses As Integer

    Dim session_APM_Interval As Decimal
    Dim session_APM As Decimal



    '===============
    'Total Variables
    '===============
    Dim totalPresses As Integer = 0
    Dim totalPressTime As Decimal = 0
    Dim averagePressTime As Decimal = 0

    '=============
    'Key Variables
    '=============

    ':::::: (ROW 1)


    '::: Esc
    Dim isPressed_ESC As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_ESC As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_ESC As Integer = 0 'Total Presses
    Dim pressStartTime_ESC As DateTime 'Time Key Pressed
    Dim pressEndTime_ESC As DateTime 'Time Key Released
    Dim pressTimeInterval_ESC As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_ESC As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_ESC As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_ESC As Decimal = 0 'Average Press Time

    '::: F1
    Dim isPressed_F1 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F1 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F1 As Integer = 0 'Total Presses
    Dim pressStartTime_F1 As DateTime 'Time Key Pressed
    Dim pressEndTime_F1 As DateTime 'Time Key Released
    Dim pressTimeInterval_F1 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F1 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F1 As Decimal = 0 'Press Time Converted to Sec
    Dim pressTimeAverage_F1 As Decimal = 0 'Average Press Time

    '::: F2
    Dim isPressed_F2 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F2 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F2 As Integer = 0 'Total Presses
    Dim pressStartTime_F2 As DateTime 'Time Key Pressed
    Dim pressEndTime_F2 As DateTime 'Time Key Released
    Dim pressTimeInterval_F2 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F2 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F2 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F2 As Decimal = 0 'Average Press Time

    '::: F3
    Dim isPressed_F3 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F3 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F3 As Integer = 0 'Total Presses
    Dim pressStartTime_F3 As DateTime 'Time Key Pressed
    Dim pressEndTime_F3 As DateTime 'Time Key Released
    Dim pressTimeInterval_F3 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F3 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F3 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F3 As Decimal = 0 'Average Press Time

    '::: F4
    Dim isPressed_F4 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F4 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F4 As Integer = 0 'Total Presses
    Dim pressStartTime_F4 As DateTime 'Time Key Pressed
    Dim pressEndTime_F4 As DateTime 'Time Key Released
    Dim pressTimeInterval_F4 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F4 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F4 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F4 As Decimal = 0 'Average Press Time

    '::: F5
    Dim isPressed_F5 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F5 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F5 As Integer = 0 'Total Presses
    Dim pressStartTime_F5 As DateTime 'Time Key Pressed
    Dim pressEndTime_F5 As DateTime 'Time Key Released
    Dim pressTimeInterval_F5 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F5 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F5 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F5 As Decimal = 0 'Average Press Time

    '::: F6
    Dim isPressed_F6 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F6 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F6 As Integer = 0 'Total Presses
    Dim pressStartTime_F6 As DateTime 'Time Key Pressed
    Dim pressEndTime_F6 As DateTime 'Time Key Released
    Dim pressTimeInterval_F6 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F6 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F6 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F6 As Decimal = 0 'Average Press Time

    '::: F7
    Dim isPressed_F7 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F7 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F7 As Integer = 0 'Total Presses
    Dim pressStartTime_F7 As DateTime 'Time Key Pressed
    Dim pressEndTime_F7 As DateTime 'Time Key Released
    Dim pressTimeInterval_F7 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F7 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F7 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F7 As Decimal = 0 'Average Press Time

    '::: F8
    Dim isPressed_F8 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F8 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F8 As Integer = 0 'Total Presses
    Dim pressStartTime_F8 As DateTime 'Time Key Pressed
    Dim pressEndTime_F8 As DateTime 'Time Key Released
    Dim pressTimeInterval_F8 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F8 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F8 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F8 As Decimal = 0 'Average Press Time

    '::: F9
    Dim isPressed_F9 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F9 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F9 As Integer = 0 'Total Presses
    Dim pressStartTime_F9 As DateTime 'Time Key Pressed
    Dim pressEndTime_F9 As DateTime 'Time Key Released
    Dim pressTimeInterval_F9 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F9 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F9 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F9 As Decimal = 0 'Average Press Time

    '::: F10
    Dim isPressed_F10 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F10 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F10 As Integer = 0 'Total Presses
    Dim pressStartTime_F10 As DateTime 'Time Key Pressed
    Dim pressEndTime_F10 As DateTime 'Time Key Released
    Dim pressTimeInterval_F10 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F10 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F10 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F10 As Decimal = 0 'Average Press Time

    '::: F11
    Dim isPressed_F11 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F11 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F11 As Integer = 0 'Total Presses
    Dim pressStartTime_F11 As DateTime 'Time Key Pressed
    Dim pressEndTime_F11 As DateTime 'Time Key Released
    Dim pressTimeInterval_F11 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F11 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F11 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F11 As Decimal = 0 'Average Press Time

    '::: F12
    Dim isPressed_F12 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F12 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F12 As Integer = 0 'Total Presses
    Dim pressStartTime_F12 As DateTime 'Time Key Pressed
    Dim pressEndTime_F12 As DateTime 'Time Key Released
    Dim pressTimeInterval_F12 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F12 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F12 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F12 As Decimal = 0 'Average Press Time

    '::: PRNT
    Dim isPressed_PRNT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_PRNT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_PRNT As Integer = 0 'Total Presses
    Dim pressStartTime_PRNT As DateTime 'Time Key Pressed
    Dim pressEndTime_PRNT As DateTime 'Time Key Released
    Dim pressTimeInterval_PRNT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_PRNT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_PRNT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_PRNT As Decimal = 0 'Average Press Time

    '::: SCRLOCK
    Dim isPressed_SCRLOCK As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_SCRLOCK As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_SCRLOCK As Integer = 0 'Total Presses
    Dim pressStartTime_SCRLOCK As DateTime 'Time Key Pressed
    Dim pressEndTime_SCRLOCK As DateTime 'Time Key Released
    Dim pressTimeInterval_SCRLOCK As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_SCRLOCK As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_SCRLOCK As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_SCRLOCK As Decimal = 0 'Average Press Time

    '::: PAUSE
    Dim isPressed_PAUSE As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_PAUSE As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_PAUSE As Integer = 0 'Total Presses
    Dim pressStartTime_PAUSE As DateTime 'Time Key Pressed
    Dim pressEndTime_PAUSE As DateTime 'Time Key Released
    Dim pressTimeInterval_PAUSE As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_PAUSE As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_PAUSE As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_PAUSE As Decimal = 0 'Average Press Time

    '::: PLAY
    Dim isPressed_PLAY As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_PLAY As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_PLAY As Integer = 0 'Total Presses
    Dim pressStartTime_PLAY As DateTime 'Time Key Pressed
    Dim pressEndTime_PLAY As DateTime 'Time Key Released
    Dim pressTimeInterval_PLAY As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_PLAY As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_PLAY As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_PLAY As Decimal = 0 'Average Press Time

    '::: STOP
    Dim isPressed_STOP As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_STOP As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_STOP As Integer = 0 'Total Presses
    Dim pressStartTime_STOP As DateTime 'Time Key Pressed
    Dim pressEndTime_STOP As DateTime 'Time Key Released
    Dim pressTimeInterval_STOP As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_STOP As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_STOP As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_STOP As Decimal = 0 'Average Press Time

    '::: PREV
    Dim isPressed_PREV As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_PREV As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_PREV As Integer = 0 'Total Presses
    Dim pressStartTime_PREV As DateTime 'Time Key Pressed
    Dim pressEndTime_PREV As DateTime 'Time Key Released
    Dim pressTimeInterval_PREV As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_PREV As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_PREV As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_PREV As Decimal = 0 'Average Press Time

    '::: NEXT
    Dim isPressed_NEXT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_NEXT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_NEXT As Integer = 0 'Total Presses
    Dim pressStartTime_NEXT As DateTime 'Time Key Pressed
    Dim pressEndTime_NEXT As DateTime 'Time Key Released
    Dim pressTimeInterval_NEXT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_NEXT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_NEXT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_NEXT As Decimal = 0 'Average Press Time


    ':::::: (ROW 2)


    '::: TILDE
    Dim isPressed_TILDE As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_TILDE As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_TILDE As Integer = 0 'Total Presses
    Dim pressStartTime_TILDE As DateTime 'Time Key Pressed
    Dim pressEndTime_TILDE As DateTime 'Time Key Released
    Dim pressTimeInterval_TILDE As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_TILDE As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_TILDE As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_TILDE As Decimal = 0 'Average Press Time

    '::: 1
    Dim isPressed_1 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_1 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_1 As Integer = 0 'Total Presses
    Dim pressStartTime_1 As DateTime 'Time Key Pressed
    Dim pressEndTime_1 As DateTime 'Time Key Released
    Dim pressTimeInterval_1 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_1 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_1 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_1 As Decimal = 0 'Average Press Time

    '::: 2
    Dim isPressed_2 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_2 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_2 As Integer = 0 'Total Presses
    Dim pressStartTime_2 As DateTime 'Time Key Pressed
    Dim pressEndTime_2 As DateTime 'Time Key Released
    Dim pressTimeInterval_2 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_2 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_2 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_2 As Decimal = 0 'Average Press Time

    '::: 3
    Dim isPressed_3 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_3 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_3 As Integer = 0 'Total Presses
    Dim pressStartTime_3 As DateTime 'Time Key Pressed
    Dim pressEndTime_3 As DateTime 'Time Key Released
    Dim pressTimeInterval_3 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_3 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_3 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_3 As Decimal = 0 'Average Press Time

    '::: 4
    Dim isPressed_4 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_4 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_4 As Integer = 0 'Total Presses
    Dim pressStartTime_4 As DateTime 'Time Key Pressed
    Dim pressEndTime_4 As DateTime 'Time Key Released
    Dim pressTimeInterval_4 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_4 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_4 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_4 As Decimal = 0 'Average Press Time

    '::: 5
    Dim isPressed_5 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_5 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_5 As Integer = 0 'Total Presses
    Dim pressStartTime_5 As DateTime 'Time Key Pressed
    Dim pressEndTime_5 As DateTime 'Time Key Released
    Dim pressTimeInterval_5 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_5 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_5 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_5 As Decimal = 0 'Average Press Time

    '::: 6
    Dim isPressed_6 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_6 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_6 As Integer = 0 'Total Presses
    Dim pressStartTime_6 As DateTime 'Time Key Pressed
    Dim pressEndTime_6 As DateTime 'Time Key Released
    Dim pressTimeInterval_6 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_6 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_6 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_6 As Decimal = 0 'Average Press Time

    '::: 7
    Dim isPressed_7 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_7 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_7 As Integer = 0 'Total Presses
    Dim pressStartTime_7 As DateTime 'Time Key Pressed
    Dim pressEndTime_7 As DateTime 'Time Key Released
    Dim pressTimeInterval_7 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_7 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_7 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_7 As Decimal = 0 'Average Press Time

    '::: 8
    Dim isPressed_8 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_8 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_8 As Integer = 0 'Total Presses
    Dim pressStartTime_8 As DateTime 'Time Key Pressed
    Dim pressEndTime_8 As DateTime 'Time Key Released
    Dim pressTimeInterval_8 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_8 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_8 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_8 As Decimal = 0 'Average Press Time

    '::: 9
    Dim isPressed_9 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_9 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_9 As Integer = 0 'Total Presses
    Dim pressStartTime_9 As DateTime 'Time Key Pressed
    Dim pressEndTime_9 As DateTime 'Time Key Released
    Dim pressTimeInterval_9 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_9 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_9 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_9 As Decimal = 0 'Average Press Time

    '::: 0
    Dim isPressed_0 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_0 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_0 As Integer = 0 'Total Presses
    Dim pressStartTime_0 As DateTime 'Time Key Pressed
    Dim pressEndTime_0 As DateTime 'Time Key Released
    Dim pressTimeInterval_0 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_0 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_0 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_0 As Decimal = 0 'Average Press Time

    '::: UnderScore
    Dim isPressed_UnderScore As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_UnderScore As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_UnderScore As Integer = 0 'Total Presses
    Dim pressStartTime_UnderScore As DateTime 'Time Key Pressed
    Dim pressEndTime_UnderScore As DateTime 'Time Key Released
    Dim pressTimeInterval_UnderScore As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_UnderScore As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_UnderScore As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_UnderScore As Decimal = 0 'Average Press Time

    '::: PlusEquals
    Dim isPressed_PlusEquals As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_PlusEquals As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_PlusEquals As Integer = 0 'Total Presses
    Dim pressStartTime_PlusEquals As DateTime 'Time Key Pressed
    Dim pressEndTime_PlusEquals As DateTime 'Time Key Released
    Dim pressTimeInterval_PlusEquals As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_PlusEquals As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_PlusEquals As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_PlusEquals As Decimal = 0 'Average Press Time

    '::: BackSpace
    Dim isPressed_BackSpace As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_BackSpace As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_BackSpace As Integer = 0 'Total Presses
    Dim pressStartTime_BackSpace As DateTime 'Time Key Pressed
    Dim pressEndTime_BackSpace As DateTime 'Time Key Released
    Dim pressTimeInterval_BackSpace As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_BackSpace As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_BackSpace As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_BackSpace As Decimal = 0 'Average Press Time

    '::: Insert
    Dim isPressed_Insert As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Insert As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Insert As Integer = 0 'Total Presses
    Dim pressStartTime_Insert As DateTime 'Time Key Pressed
    Dim pressEndTime_Insert As DateTime 'Time Key Released
    Dim pressTimeInterval_Insert As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Insert As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Insert As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Insert As Decimal = 0 'Average Press Time

    '::: Home
    Dim isPressed_Home As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Home As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Home As Integer = 0 'Total Presses
    Dim pressStartTime_Home As DateTime 'Time Key Pressed
    Dim pressEndTime_Home As DateTime 'Time Key Released
    Dim pressTimeInterval_Home As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Home As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Home As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Home As Decimal = 0 'Average Press Time

    '::: PgUp
    Dim isPressed_PgUp As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_PgUp As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_PgUp As Integer = 0 'Total Presses
    Dim pressStartTime_PgUp As DateTime 'Time Key Pressed
    Dim pressEndTime_PgUp As DateTime 'Time Key Released
    Dim pressTimeInterval_PgUp As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_PgUp As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_PgUp As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_PgUp As Decimal = 0 'Average Press Time

    '::: NumLock
    Dim isPressed_NumLock As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_NumLock As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_NumLock As Integer = 0 'Total Presses
    Dim pressStartTime_NumLock As DateTime 'Time Key Pressed
    Dim pressEndTime_NumLock As DateTime 'Time Key Released
    Dim pressTimeInterval_NumLock As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_NumLock As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_NumLock As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_NumLock As Decimal = 0 'Average Press Time

    '::: Divide
    Dim isPressed_Divide As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Divide As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Divide As Integer = 0 'Total Presses
    Dim pressStartTime_Divide As DateTime 'Time Key Pressed
    Dim pressEndTime_Divide As DateTime 'Time Key Released
    Dim pressTimeInterval_Divide As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Divide As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Divide As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Divide As Decimal = 0 'Average Press Time

    '::: Multiply
    Dim isPressed_Multiply As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Multiply As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Multiply As Integer = 0 'Total Presses
    Dim pressStartTime_Multiply As DateTime 'Time Key Pressed
    Dim pressEndTime_Multiply As DateTime 'Time Key Released
    Dim pressTimeInterval_Multiply As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Multiply As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Multiply As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Multiply As Decimal = 0 'Average Press Time

    '::: Minus
    Dim isPressed_Minus As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Minus As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Minus As Integer = 0 'Total Presses
    Dim pressStartTime_Minus As DateTime 'Time Key Pressed
    Dim pressEndTime_Minus As DateTime 'Time Key Released
    Dim pressTimeInterval_Minus As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Minus As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Minus As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Minus As Decimal = 0 'Average Press Time


    ':::::: (ROW 3)


    '::: TAB
    Dim isPressed_TAB As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_TAB As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_TAB As Integer = 0 'Total Presses
    Dim pressStartTime_TAB As DateTime 'Time Key Pressed
    Dim pressEndTime_TAB As DateTime 'Time Key Released
    Dim pressTimeInterval_TAB As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_TAB As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_TAB As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_TAB As Decimal = 0 'Average Press Time

    '::: Q
    Dim isPressed_Q As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Q As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Q As Integer = 0 'Total Presses
    Dim pressStartTime_Q As DateTime 'Time Key Pressed
    Dim pressEndTime_Q As DateTime 'Time Key Released
    Dim pressTimeInterval_Q As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Q As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Q As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Q As Decimal = 0 'Average Press Time

    '::: W
    Dim isPressed_W As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_W As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_W As Integer = 0 'Total Presses
    Dim pressStartTime_W As DateTime 'Time Key Pressed
    Dim pressEndTime_W As DateTime 'Time Key Released
    Dim pressTimeInterval_W As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_W As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_W As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_W As Decimal = 0 'Average Press Time

    '::: E
    Dim isPressed_E As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_E As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_E As Integer = 0 'Total Presses
    Dim pressStartTime_E As DateTime 'Time Key Pressed
    Dim pressEndTime_E As DateTime 'Time Key Released
    Dim pressTimeInterval_E As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_E As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_E As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_E As Decimal = 0 'Average Press Time

    '::: R
    Dim isPressed_R As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_R As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_R As Integer = 0 'Total Presses
    Dim pressStartTime_R As DateTime 'Time Key Pressed
    Dim pressEndTime_R As DateTime 'Time Key Released
    Dim pressTimeInterval_R As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_R As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_R As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_R As Decimal = 0 'Average Press Time

    '::: T
    Dim isPressed_T As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_T As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_T As Integer = 0 'Total Presses
    Dim pressStartTime_T As DateTime 'Time Key Pressed
    Dim pressEndTime_T As DateTime 'Time Key Released
    Dim pressTimeInterval_T As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_T As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_T As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_T As Decimal = 0 'Average Press Time

    '::: Y
    Dim isPressed_Y As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Y As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Y As Integer = 0 'Total Presses
    Dim pressStartTime_Y As DateTime 'Time Key Pressed
    Dim pressEndTime_Y As DateTime 'Time Key Released
    Dim pressTimeInterval_Y As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Y As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Y As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Y As Decimal = 0 'Average Press Time

    '::: U
    Dim isPressed_U As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_U As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_U As Integer = 0 'Total Presses
    Dim pressStartTime_U As DateTime 'Time Key Pressed
    Dim pressEndTime_U As DateTime 'Time Key Released
    Dim pressTimeInterval_U As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_U As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_U As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_U As Decimal = 0 'Average Press Time

    '::: I
    Dim isPressed_I As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_I As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_I As Integer = 0 'Total Presses
    Dim pressStartTime_I As DateTime 'Time Key Pressed
    Dim pressEndTime_I As DateTime 'Time Key Released
    Dim pressTimeInterval_I As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_I As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_I As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_I As Decimal = 0 'Average Press Time

    '::: O
    Dim isPressed_O As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_O As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_O As Integer = 0 'Total Presses
    Dim pressStartTime_O As DateTime 'Time Key Pressed
    Dim pressEndTime_O As DateTime 'Time Key Released
    Dim pressTimeInterval_O As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_O As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_O As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_O As Decimal = 0 'Average Press Time

    '::: P
    Dim isPressed_P As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_P As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_P As Integer = 0 'Total Presses
    Dim pressStartTime_P As DateTime 'Time Key Pressed
    Dim pressEndTime_P As DateTime 'Time Key Released
    Dim pressTimeInterval_P As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_P As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_P As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_P As Decimal = 0 'Average Press Time

    '::: LBracket
    Dim isPressed_LBracket As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LBracket As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LBracket As Integer = 0 'Total Presses
    Dim pressStartTime_LBracket As DateTime 'Time Key Pressed
    Dim pressEndTime_LBracket As DateTime 'Time Key Released
    Dim pressTimeInterval_LBracket As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LBracket As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LBracket As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LBracket As Decimal = 0 'Average Press Time

    '::: RBracket
    Dim isPressed_RBracket As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_RBracket As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_RBracket As Integer = 0 'Total Presses
    Dim pressStartTime_RBracket As DateTime 'Time Key Pressed
    Dim pressEndTime_RBracket As DateTime 'Time Key Released
    Dim pressTimeInterval_RBracket As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_RBracket As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_RBracket As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_RBracket As Decimal = 0 'Average Press Time

    '::: Slash
    Dim isPressed_Slash As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Slash As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Slash As Integer = 0 'Total Presses
    Dim pressStartTime_Slash As DateTime 'Time Key Pressed
    Dim pressEndTime_Slash As DateTime 'Time Key Released
    Dim pressTimeInterval_Slash As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Slash As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Slash As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Slash As Decimal = 0 'Average Press Time

    '::: Delete
    Dim isPressed_Delete As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Delete As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Delete As Integer = 0 'Total Presses
    Dim pressStartTime_Delete As DateTime 'Time Key Pressed
    Dim pressEndTime_Delete As DateTime 'Time Key Released
    Dim pressTimeInterval_Delete As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Delete As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Delete As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Delete As Decimal = 0 'Average Press Time

    '::: End
    Dim isPressed_End As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_End As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_End As Integer = 0 'Total Presses
    Dim pressStartTime_End As DateTime 'Time Key Pressed
    Dim pressEndTime_End As DateTime 'Time Key Released
    Dim pressTimeInterval_End As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_End As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_End As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_End As Decimal = 0 'Average Press Time

    '::: PgDn
    Dim isPressed_PgDn As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_PgDn As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_PgDn As Integer = 0 'Total Presses
    Dim pressStartTime_PgDn As DateTime 'Time Key Pressed
    Dim pressEndTime_PgDn As DateTime 'Time Key Released
    Dim pressTimeInterval_PgDn As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_PgDn As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_PgDn As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_PgDn As Decimal = 0 'Average Press Time

    '::: Num7
    Dim isPressed_Num7 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num7 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num7 As Integer = 0 'Total Presses
    Dim pressStartTime_Num7 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num7 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num7 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num7 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num7 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num7 As Decimal = 0 'Average Press Time

    '::: Num8
    Dim isPressed_Num8 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num8 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num8 As Integer = 0 'Total Presses
    Dim pressStartTime_Num8 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num8 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num8 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num8 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num8 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num8 As Decimal = 0 'Average Press Time

    '::: Num9
    Dim isPressed_Num9 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num9 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num9 As Integer = 0 'Total Presses
    Dim pressStartTime_Num9 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num9 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num9 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num9 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num9 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num9 As Decimal = 0 'Average Press Time


    ':::::: (ROW 4)


    '::: CAPS
    Dim isPressed_CAPS As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_CAPS As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_CAPS As Integer = 0 'Total Presses
    Dim pressStartTime_CAPS As DateTime 'Time Key Pressed
    Dim pressEndTime_CAPS As DateTime 'Time Key Released
    Dim pressTimeInterval_CAPS As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_CAPS As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_CAPS As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_CAPS As Decimal = 0 'Average Press Time

    '::: A
    Dim isPressed_A As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_A As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_A As Integer = 0 'Total Presses
    Dim pressStartTime_A As DateTime 'Time Key Pressed
    Dim pressEndTime_A As DateTime 'Time Key Released
    Dim pressTimeInterval_A As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_A As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_A As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_A As Decimal = 0 'Average Press Time

    '::: S
    Dim isPressed_S As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_S As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_S As Integer = 0 'Total Presses
    Dim pressStartTime_S As DateTime 'Time Key Pressed
    Dim pressEndTime_S As DateTime 'Time Key Released
    Dim pressTimeInterval_S As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_S As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_S As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_S As Decimal = 0 'Average Press Time

    '::: D
    Dim isPressed_D As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_D As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_D As Integer = 0 'Total Presses
    Dim pressStartTime_D As DateTime 'Time Key Pressed
    Dim pressEndTime_D As DateTime 'Time Key Released
    Dim pressTimeInterval_D As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_D As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_D As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_D As Decimal = 0 'Average Press Time

    '::: F
    Dim isPressed_F As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_F As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_F As Integer = 0 'Total Presses
    Dim pressStartTime_F As DateTime 'Time Key Pressed
    Dim pressEndTime_F As DateTime 'Time Key Released
    Dim pressTimeInterval_F As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_F As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_F As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_F As Decimal = 0 'Average Press Time

    '::: G
    Dim isPressed_G As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_G As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_G As Integer = 0 'Total Presses
    Dim pressStartTime_G As DateTime 'Time Key Pressed
    Dim pressEndTime_G As DateTime 'Time Key Released
    Dim pressTimeInterval_G As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_G As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_G As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_G As Decimal = 0 'Average Press Time

    '::: H
    Dim isPressed_H As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_H As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_H As Integer = 0 'Total Presses
    Dim pressStartTime_H As DateTime 'Time Key Pressed
    Dim pressEndTime_H As DateTime 'Time Key Released
    Dim pressTimeInterval_H As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_H As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_H As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_H As Decimal = 0 'Average Press Time

    '::: J
    Dim isPressed_J As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_J As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_J As Integer = 0 'Total Presses
    Dim pressStartTime_J As DateTime 'Time Key Pressed
    Dim pressEndTime_J As DateTime 'Time Key Released
    Dim pressTimeInterval_J As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_J As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_J As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_J As Decimal = 0 'Average Press Time

    '::: K
    Dim isPressed_K As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_K As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_K As Integer = 0 'Total Presses
    Dim pressStartTime_K As DateTime 'Time Key Pressed
    Dim pressEndTime_K As DateTime 'Time Key Released
    Dim pressTimeInterval_K As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_K As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_K As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_K As Decimal = 0 'Average Press Time

    '::: L
    Dim isPressed_L As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_L As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_L As Integer = 0 'Total Presses
    Dim pressStartTime_L As DateTime 'Time Key Pressed
    Dim pressEndTime_L As DateTime 'Time Key Released
    Dim pressTimeInterval_L As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_L As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_L As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_L As Decimal = 0 'Average Press Time

    '::: COLON
    Dim isPressed_COLON As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_COLON As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_COLON As Integer = 0 'Total Presses
    Dim pressStartTime_COLON As DateTime 'Time Key Pressed
    Dim pressEndTime_COLON As DateTime 'Time Key Released
    Dim pressTimeInterval_COLON As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_COLON As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_COLON As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_COLON As Decimal = 0 'Average Press Time

    '::: QUOTES
    Dim isPressed_QUOTES As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_QUOTES As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_QUOTES As Integer = 0 'Total Presses
    Dim pressStartTime_QUOTES As DateTime 'Time Key Pressed
    Dim pressEndTime_QUOTES As DateTime 'Time Key Released
    Dim pressTimeInterval_QUOTES As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_QUOTES As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_QUOTES As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_QUOTES As Decimal = 0 'Average Press Time

    '::: MainEnter
    Dim isPressed_MainEnter As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_MainEnter As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_MainEnter As Integer = 0 'Total Presses
    Dim pressStartTime_MainEnter As DateTime 'Time Key Pressed
    Dim pressEndTime_MainEnter As DateTime 'Time Key Released
    Dim pressTimeInterval_MainEnter As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_MainEnter As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_MainEnter As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_MainEnter As Decimal = 0 'Average Press Time

    '::: Num4
    Dim isPressed_Num4 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num4 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num4 As Integer = 0 'Total Presses
    Dim pressStartTime_Num4 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num4 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num4 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num4 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num4 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num4 As Decimal = 0 'Average Press Time

    '::: Num5
    Dim isPressed_Num5 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num5 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num5 As Integer = 0 'Total Presses
    Dim pressStartTime_Num5 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num5 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num5 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num5 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num5 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num5 As Decimal = 0 'Average Press Time

    '::: Num6
    Dim isPressed_Num6 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num6 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num6 As Integer = 0 'Total Presses
    Dim pressStartTime_Num6 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num6 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num6 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num6 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num6 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num6 As Decimal = 0 'Average Press Time

    '::: Plus
    Dim isPressed_Plus As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Plus As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Plus As Integer = 0 'Total Presses
    Dim pressStartTime_Plus As DateTime 'Time Key Pressed
    Dim pressEndTime_Plus As DateTime 'Time Key Released
    Dim pressTimeInterval_Plus As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Plus As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Plus As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Plus As Decimal = 0 'Average Press Time


    ':::::: (ROW 5)


    '::: LSHIFT
    Dim isPressed_LSHIFT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LSHIFT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LSHIFT As Integer = 0 'Total Presses
    Dim pressStartTime_LSHIFT As DateTime 'Time Key Pressed
    Dim pressEndTime_LSHIFT As DateTime 'Time Key Released
    Dim pressTimeInterval_LSHIFT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LSHIFT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LSHIFT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LSHIFT As Decimal = 0 'Average Press Time

    '::: Z
    Dim isPressed_Z As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Z As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Z As Integer = 0 'Total Presses
    Dim pressStartTime_Z As DateTime 'Time Key Pressed
    Dim pressEndTime_Z As DateTime 'Time Key Released
    Dim pressTimeInterval_Z As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Z As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Z As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Z As Decimal = 0 'Average Press Time

    '::: X
    Dim isPressed_X As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_X As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_X As Integer = 0 'Total Presses
    Dim pressStartTime_X As DateTime 'Time Key Pressed
    Dim pressEndTime_X As DateTime 'Time Key Released
    Dim pressTimeInterval_X As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_X As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_X As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_X As Decimal = 0 'Average Press Time

    '::: C
    Dim isPressed_C As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_C As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_C As Integer = 0 'Total Presses
    Dim pressStartTime_C As DateTime 'Time Key Pressed
    Dim pressEndTime_C As DateTime 'Time Key Released
    Dim pressTimeInterval_C As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_C As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_C As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_C As Decimal = 0 'Average Press Time

    '::: V
    Dim isPressed_V As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_V As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_V As Integer = 0 'Total Presses
    Dim pressStartTime_V As DateTime 'Time Key Pressed
    Dim pressEndTime_V As DateTime 'Time Key Released
    Dim pressTimeInterval_V As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_V As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_V As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_V As Decimal = 0 'Average Press Time

    '::: B
    Dim isPressed_B As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_B As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_B As Integer = 0 'Total Presses
    Dim pressStartTime_B As DateTime 'Time Key Pressed
    Dim pressEndTime_B As DateTime 'Time Key Released
    Dim pressTimeInterval_B As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_B As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_B As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_B As Decimal = 0 'Average Press Time

    '::: N
    Dim isPressed_N As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_N As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_N As Integer = 0 'Total Presses
    Dim pressStartTime_N As DateTime 'Time Key Pressed
    Dim pressEndTime_N As DateTime 'Time Key Released
    Dim pressTimeInterval_N As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_N As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_N As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_N As Decimal = 0 'Average Press Time

    '::: M
    Dim isPressed_M As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_M As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_M As Integer = 0 'Total Presses
    Dim pressStartTime_M As DateTime 'Time Key Pressed
    Dim pressEndTime_M As DateTime 'Time Key Released
    Dim pressTimeInterval_M As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_M As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_M As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_M As Decimal = 0 'Average Press Time

    '::: LESS
    Dim isPressed_LESS As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LESS As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LESS As Integer = 0 'Total Presses
    Dim pressStartTime_LESS As DateTime 'Time Key Pressed
    Dim pressEndTime_LESS As DateTime 'Time Key Released
    Dim pressTimeInterval_LESS As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LESS As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LESS As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LESS As Decimal = 0 'Average Press Time

    '::: Greater
    Dim isPressed_Greater As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Greater As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Greater As Integer = 0 'Total Presses
    Dim pressStartTime_Greater As DateTime 'Time Key Pressed
    Dim pressEndTime_Greater As DateTime 'Time Key Released
    Dim pressTimeInterval_Greater As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Greater As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Greater As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Greater As Decimal = 0 'Average Press Time

    '::: Question
    Dim isPressed_Question As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Question As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Question As Integer = 0 'Total Presses
    Dim pressStartTime_Question As DateTime 'Time Key Pressed
    Dim pressEndTime_Question As DateTime 'Time Key Released
    Dim pressTimeInterval_Question As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Question As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Question As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Question As Decimal = 0 'Average Press Time

    '::: RSHIFT
    Dim isPressed_RSHIFT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_RSHIFT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_RSHIFT As Integer = 0 'Total Presses
    Dim pressStartTime_RSHIFT As DateTime 'Time Key Pressed
    Dim pressEndTime_RSHIFT As DateTime 'Time Key Released
    Dim pressTimeInterval_RSHIFT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_RSHIFT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_RSHIFT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_RSHIFT As Decimal = 0 'Average Press Time

    '::: UP
    Dim isPressed_UP As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_UP As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_UP As Integer = 0 'Total Presses
    Dim pressStartTime_UP As DateTime 'Time Key Pressed
    Dim pressEndTime_UP As DateTime 'Time Key Released
    Dim pressTimeInterval_UP As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_UP As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_UP As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_UP As Decimal = 0 'Average Press Time

    '::: Num1
    Dim isPressed_Num1 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num1 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num1 As Integer = 0 'Total Presses
    Dim pressStartTime_Num1 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num1 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num1 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num1 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num1 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num1 As Decimal = 0 'Average Press Time

    '::: Num2
    Dim isPressed_Num2 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num2 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num2 As Integer = 0 'Total Presses
    Dim pressStartTime_Num2 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num2 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num2 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num2 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num2 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num2 As Decimal = 0 'Average Press Time

    '::: Num3
    Dim isPressed_Num3 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num3 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num3 As Integer = 0 'Total Presses
    Dim pressStartTime_Num3 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num3 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num3 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num3 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num3 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num3 As Decimal = 0 'Average Press Time


    ':::::: (ROW 6)


    '::: LCTRL
    Dim isPressed_LCTRL As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LCTRL As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LCTRL As Integer = 0 'Total Presses
    Dim pressStartTime_LCTRL As DateTime 'Time Key Pressed
    Dim pressEndTime_LCTRL As DateTime 'Time Key Released
    Dim pressTimeInterval_LCTRL As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LCTRL As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LCTRL As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LCTRL As Decimal = 0 'Average Press Time

    '::: LWIN
    Dim isPressed_LWIN As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LWIN As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LWIN As Integer = 0 'Total Presses
    Dim pressStartTime_LWIN As DateTime 'Time Key Pressed
    Dim pressEndTime_LWIN As DateTime 'Time Key Released
    Dim pressTimeInterval_LWIN As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LWIN As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LWIN As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LWIN As Decimal = 0 'Average Press Time

    '::: LALT
    Dim isPressed_LALT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LALT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LALT As Integer = 0 'Total Presses
    Dim pressStartTime_LALT As DateTime 'Time Key Pressed
    Dim pressEndTime_LALT As DateTime 'Time Key Released
    Dim pressTimeInterval_LALT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LALT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LALT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LALT As Decimal = 0 'Average Press Time

    '::: SpaceBar
    Dim isPressed_SpaceBar As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_SpaceBar As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_SpaceBar As Integer = 0 'Total Presses
    Dim pressStartTime_SpaceBar As DateTime 'Time Key Pressed
    Dim pressEndTime_SpaceBar As DateTime 'Time Key Released
    Dim pressTimeInterval_SpaceBar As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_SpaceBar As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_SpaceBar As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_SpaceBar As Decimal = 0 'Average Press Time

    '::: RALT
    Dim isPressed_RALT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_RALT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_RALT As Integer = 0 'Total Presses
    Dim pressStartTime_RALT As DateTime 'Time Key Pressed
    Dim pressEndTime_RALT As DateTime 'Time Key Released
    Dim pressTimeInterval_RALT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_RALT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_RALT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_RALT As Decimal = 0 'Average Press Time

    '::: RWIN
    Dim isPressed_RWIN As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_RWIN As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_RWIN As Integer = 0 'Total Presses
    Dim pressStartTime_RWIN As DateTime 'Time Key Pressed
    Dim pressEndTime_RWIN As DateTime 'Time Key Released
    Dim pressTimeInterval_RWIN As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_RWIN As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_RWIN As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_RWIN As Decimal = 0 'Average Press Time

    '::: APPS
    Dim isPressed_APPS As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_APPS As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_APPS As Integer = 0 'Total Presses
    Dim pressStartTime_APPS As DateTime 'Time Key Pressed
    Dim pressEndTime_APPS As DateTime 'Time Key Released
    Dim pressTimeInterval_APPS As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_APPS As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_APPS As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_APPS As Decimal = 0 'Average Press Time

    '::: RCTRL
    Dim isPressed_RCTRL As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_RCTRL As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_RCTRL As Integer = 0 'Total Presses
    Dim pressStartTime_RCTRL As DateTime 'Time Key Pressed
    Dim pressEndTime_RCTRL As DateTime 'Time Key Released
    Dim pressTimeInterval_RCTRL As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_RCTRL As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_RCTRL As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_RCTRL As Decimal = 0 'Average Press Time

    '::: LT
    Dim isPressed_LT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LT As Integer = 0 'Total Presses
    Dim pressStartTime_LT As DateTime 'Time Key Pressed
    Dim pressEndTime_LT As DateTime 'Time Key Released
    Dim pressTimeInterval_LT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LT As Decimal = 0 'Average Press Time

    '::: DN
    Dim isPressed_DN As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_DN As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_DN As Integer = 0 'Total Presses
    Dim pressStartTime_DN As DateTime 'Time Key Pressed
    Dim pressEndTime_DN As DateTime 'Time Key Released
    Dim pressTimeInterval_DN As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_DN As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_DN As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_DN As Decimal = 0 'Average Press Time

    '::: RT
    Dim isPressed_RT As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_RT As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_RT As Integer = 0 'Total Presses
    Dim pressStartTime_RT As DateTime 'Time Key Pressed
    Dim pressEndTime_RT As DateTime 'Time Key Released
    Dim pressTimeInterval_RT As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_RT As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_RT As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_RT As Decimal = 0 'Average Press Time

    '::: Num0
    Dim isPressed_Num0 As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Num0 As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Num0 As Integer = 0 'Total Presses
    Dim pressStartTime_Num0 As DateTime 'Time Key Pressed
    Dim pressEndTime_Num0 As DateTime 'Time Key Released
    Dim pressTimeInterval_Num0 As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Num0 As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Num0 As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Num0 As Decimal = 0 'Average Press Time

    '::: Decimal
    Dim isPressed_Decimal As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_Decimal As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_Decimal As Integer = 0 'Total Presses
    Dim pressStartTime_Decimal As DateTime 'Time Key Pressed
    Dim pressEndTime_Decimal As DateTime 'Time Key Released
    Dim pressTimeInterval_Decimal As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_Decimal As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_Decimal As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_Decimal As Decimal = 0 'Average Press Time

    '::: NumEnter
    Dim isPressed_NumEnter As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_NumEnter As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_NumEnter As Integer = 0 'Total Presses
    Dim pressStartTime_NumEnter As DateTime 'Time Key Pressed
    Dim pressEndTime_NumEnter As DateTime 'Time Key Released
    Dim pressTimeInterval_NumEnter As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_NumEnter As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_NumEnter As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_NumEnter As Decimal = 0 'Average Press Time


    '::::::(ROW 7)


    '::: LMB
    Dim isPressed_LMB As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_LMB As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_LMB As Integer = 0 'Total Presses
    Dim pressStartTime_LMB As DateTime 'Time Key Pressed
    Dim pressEndTime_LMB As DateTime 'Time Key Released
    Dim pressTimeInterval_LMB As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_LMB As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_LMB As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_LMB As Decimal = 0 'Average Press Time

    '::: MMB
    Dim isPressed_MMB As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_MMB As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_MMB As Integer = 0 'Total Presses
    Dim pressStartTime_MMB As DateTime 'Time Key Pressed
    Dim pressEndTime_MMB As DateTime 'Time Key Released
    Dim pressTimeInterval_MMB As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_MMB As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_MMB As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_MMB As Decimal = 0 'Average Press Time

    '::: RMB
    Dim isPressed_RMB As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_RMB As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_RMB As Integer = 0 'Total Presses
    Dim pressStartTime_RMB As DateTime 'Time Key Pressed
    Dim pressEndTime_RMB As DateTime 'Time Key Released
    Dim pressTimeInterval_RMB As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_RMB As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_RMB As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_RMB As Decimal = 0 'Average Press Time

    '::: MSU
    Dim isPressed_MSU As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_MSU As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_MSU As Integer = 0 'Total Presses
    Dim pressStartTime_MSU As DateTime 'Time Key Pressed
    Dim pressEndTime_MSU As DateTime 'Time Key Released
    Dim pressTimeInterval_MSU As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_MSU As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_MSU As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_MSU As Decimal = 0 'Average Press Time

    '::: MSD
    Dim isPressed_MSD As Boolean 'Pressed = True | Not Pressed = False
    Dim isHeld_MSD As Boolean = False 'True when seen pressed | False when seen released
    Dim pressCount_MSD As Integer = 0 'Total Presses
    Dim pressStartTime_MSD As DateTime 'Time Key Pressed
    Dim pressEndTime_MSD As DateTime 'Time Key Released
    Dim pressTimeInterval_MSD As Decimal = 0 'Total Time Key Pressed
    Dim pressTimeTotal_MSD As Decimal = 0 'Total Press Time in Milliseconds
    Dim pressTimeTotalConverted_MSD As Decimal = 0 'Press Time Converted to Sec/Min/Hour
    Dim pressTimeAverage_MSD As Decimal = 0 'Average Press Time

    Dim mouseScroll_mm As Decimal = CDec(3.14962)

    Dim mouseScrollTravel_UP As Decimal = 0
    Dim mouseScrollTravel_UP_Converted As Decimal = 0

    Dim mouseScrollTravel_DN As Decimal = 0
    Dim mouseScrollTravel_DN_Converted As Decimal = 0

    Dim mouseScrollTravel_Total As Decimal = 0
    Dim mouseScrollTravel_Total_Converted As Decimal = 0

End Class