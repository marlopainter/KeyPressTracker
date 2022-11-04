
Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices
Imports System.Threading

Partial Public Class MainForm

    Sub CheckKeyState()

        Do

            ':::::: (ROW 1)

            isPressed_ESC = GetAsyncKeyState(Keys.Escape)
            isPressed_F1 = GetAsyncKeyState(Keys.F1)
            isPressed_F2 = GetAsyncKeyState(Keys.F2)
            isPressed_F3 = GetAsyncKeyState(Keys.F3)
            isPressed_F4 = GetAsyncKeyState(Keys.F4)
            isPressed_F5 = GetAsyncKeyState(Keys.F5)
            isPressed_F6 = GetAsyncKeyState(Keys.F6)
            isPressed_F7 = GetAsyncKeyState(Keys.F7)
            isPressed_F8 = GetAsyncKeyState(Keys.F8)
            isPressed_F9 = GetAsyncKeyState(Keys.F9)
            isPressed_F10 = GetAsyncKeyState(Keys.F10)
            isPressed_F11 = GetAsyncKeyState(Keys.F11)
            isPressed_F12 = GetAsyncKeyState(Keys.F12)
            isPressed_PRNT = GetAsyncKeyState(Keys.PrintScreen)
            isPressed_SCRLOCK = GetAsyncKeyState(Keys.Scroll)
            isPressed_PAUSE = GetAsyncKeyState(Keys.Pause)
            isPressed_PLAY = GetAsyncKeyState(Keys.MediaPlayPause)
            isPressed_STOP = GetAsyncKeyState(Keys.MediaStop)
            isPressed_PREV = GetAsyncKeyState(Keys.MediaPreviousTrack)
            isPressed_NEXT = GetAsyncKeyState(Keys.MediaNextTrack)

            ':::::: (ROW 2)

            isPressed_TILDE = GetAsyncKeyState(Keys.Oemtilde)
            isPressed_1 = GetAsyncKeyState(Keys.D1)
            isPressed_2 = GetAsyncKeyState(Keys.D2)
            isPressed_3 = GetAsyncKeyState(Keys.D3)
            isPressed_4 = GetAsyncKeyState(Keys.D4)
            isPressed_5 = GetAsyncKeyState(Keys.D5)
            isPressed_6 = GetAsyncKeyState(Keys.D6)
            isPressed_7 = GetAsyncKeyState(Keys.D7)
            isPressed_8 = GetAsyncKeyState(Keys.D8)
            isPressed_9 = GetAsyncKeyState(Keys.D9)
            isPressed_0 = GetAsyncKeyState(Keys.D0)
            isPressed_UnderScore = GetAsyncKeyState(Keys.OemMinus)
            isPressed_PlusEquals = GetAsyncKeyState(Keys.Oemplus)
            isPressed_BackSpace = GetAsyncKeyState(Keys.Back)
            isPressed_Insert = GetAsyncKeyState(Keys.Insert)
            isPressed_Home = GetAsyncKeyState(Keys.Home)
            isPressed_PgUp = GetAsyncKeyState(Keys.PageUp)
            isPressed_NumLock = GetAsyncKeyState(Keys.NumLock)
            isPressed_Divide = GetAsyncKeyState(Keys.Divide)
            isPressed_Multiply = GetAsyncKeyState(Keys.Multiply)
            isPressed_Minus = GetAsyncKeyState(Keys.Subtract)

            ':::::: (ROW 3)

            isPressed_TAB = GetAsyncKeyState(Keys.Tab)
            isPressed_Q = GetAsyncKeyState(Keys.Q)
            isPressed_W = GetAsyncKeyState(Keys.W)
            isPressed_E = GetAsyncKeyState(Keys.E)
            isPressed_R = GetAsyncKeyState(Keys.R)
            isPressed_T = GetAsyncKeyState(Keys.T)
            isPressed_Y = GetAsyncKeyState(Keys.Y)
            isPressed_U = GetAsyncKeyState(Keys.U)
            isPressed_I = GetAsyncKeyState(Keys.I)
            isPressed_O = GetAsyncKeyState(Keys.O)
            isPressed_P = GetAsyncKeyState(Keys.P)
            isPressed_LBracket = GetAsyncKeyState(Keys.OemOpenBrackets)
            isPressed_RBracket = GetAsyncKeyState(Keys.Oem6)
            isPressed_Slash = GetAsyncKeyState(Keys.Oem5)
            isPressed_Delete = GetAsyncKeyState(Keys.Delete)
            isPressed_End = GetAsyncKeyState(Keys.End)
            isPressed_PgDn = GetAsyncKeyState(Keys.Next)
            isPressed_Num7 = GetAsyncKeyState(Keys.NumPad7)
            isPressed_Num8 = GetAsyncKeyState(Keys.NumPad8)
            isPressed_Num9 = GetAsyncKeyState(Keys.NumPad9)

            ':::::: (ROW 4)

            isPressed_CAPS = GetAsyncKeyState(Keys.CapsLock)
            isPressed_A = GetAsyncKeyState(Keys.A)
            isPressed_S = GetAsyncKeyState(Keys.S)
            isPressed_D = GetAsyncKeyState(Keys.D)
            isPressed_F = GetAsyncKeyState(Keys.F)
            isPressed_G = GetAsyncKeyState(Keys.G)
            isPressed_H = GetAsyncKeyState(Keys.H)
            isPressed_J = GetAsyncKeyState(Keys.J)
            isPressed_K = GetAsyncKeyState(Keys.K)
            isPressed_L = GetAsyncKeyState(Keys.L)
            isPressed_COLON = GetAsyncKeyState(Keys.Oem1)
            isPressed_QUOTES = GetAsyncKeyState(Keys.Oem7)
            isPressed_MainEnter = GetAsyncKeyState(Keys.Return)
            isPressed_Num4 = GetAsyncKeyState(Keys.NumPad4)
            isPressed_Num5 = GetAsyncKeyState(Keys.NumPad5)
            isPressed_Num6 = GetAsyncKeyState(Keys.NumPad6)
            isPressed_Plus = GetAsyncKeyState(Keys.Add)

            ':::::: (ROW 5)

            isPressed_LSHIFT = GetAsyncKeyState(Keys.LShiftKey)
            isPressed_Z = GetAsyncKeyState(Keys.Z)
            isPressed_X = GetAsyncKeyState(Keys.X)
            isPressed_C = GetAsyncKeyState(Keys.C)
            isPressed_V = GetAsyncKeyState(Keys.V)
            isPressed_B = GetAsyncKeyState(Keys.B)
            isPressed_N = GetAsyncKeyState(Keys.N)
            isPressed_M = GetAsyncKeyState(Keys.M)
            isPressed_LESS = GetAsyncKeyState(Keys.Oemcomma)
            isPressed_Greater = GetAsyncKeyState(Keys.OemPeriod)
            isPressed_Question = GetAsyncKeyState(Keys.OemQuestion)
            isPressed_RSHIFT = GetAsyncKeyState(Keys.RShiftKey)
            isPressed_UP = GetAsyncKeyState(Keys.Up)
            isPressed_Num1 = GetAsyncKeyState(Keys.NumPad1)
            isPressed_Num2 = GetAsyncKeyState(Keys.NumPad2)
            isPressed_Num3 = GetAsyncKeyState(Keys.NumPad3)

            ':::::: (ROW 6)

            isPressed_LCTRL = GetAsyncKeyState(Keys.LControlKey)
            isPressed_LWIN = GetAsyncKeyState(Keys.LWin)
            isPressed_LALT = GetAsyncKeyState(Keys.LMenu)
            isPressed_SpaceBar = GetAsyncKeyState(Keys.Space)
            isPressed_RALT = GetAsyncKeyState(Keys.RMenu)
            isPressed_RWIN = GetAsyncKeyState(Keys.RWin)
            isPressed_APPS = GetAsyncKeyState(Keys.Apps)
            isPressed_RCTRL = GetAsyncKeyState(Keys.RControlKey)
            isPressed_LT = GetAsyncKeyState(Keys.Left)
            isPressed_DN = GetAsyncKeyState(Keys.Down)
            isPressed_RT = GetAsyncKeyState(Keys.Right)
            isPressed_Num0 = GetAsyncKeyState(Keys.NumPad0)
            isPressed_Decimal = GetAsyncKeyState(Keys.Decimal)
            isPressed_NumEnter = GetAsyncKeyState(Keys.Return)

            '::::::(ROW 7)

            isPressed_LMB = GetAsyncKeyState(Keys.LButton)
            isPressed_MMB = GetAsyncKeyState(Keys.MButton)
            isPressed_RMB = GetAsyncKeyState(Keys.RButton)

        Loop

    End Sub

    Sub ProcessKeyState()

        Do

            '[] IF ESC IS PRESSED
            If isPressed_ESC = True AndAlso isHeld_ESC = False Then
                isHeld_ESC = True
                pressStartTime_ESC = DateTime.Now
            End If

            '[] IF ESC WAS RELEASED
            If isPressed_ESC = False AndAlso isHeld_ESC = True Then
                pressEndTime_ESC = DateTime.Now
                isHeld_ESC = False
                pressCount_ESC += 1
                totalPresses += 1
                pressTimeTotalConverted_ESC =
                    IntervalMath(pressStartTime_ESC, pressEndTime_ESC)
                pressTimeTotal_ESC += pressTimeTotalConverted_ESC
                totalPressTime += pressTimeTotalConverted_ESC
            End If

            '[] IF F1 IS PRESSED
            If isPressed_F1 = True AndAlso isHeld_F1 = False Then
                isHeld_F1 = True
                pressStartTime_F1 = DateTime.Now
            End If

            '[] IF F1 WAS RELEASED
            If isPressed_F1 = False AndAlso isHeld_F1 = True Then
                pressEndTime_F1 = DateTime.Now
                isHeld_F1 = False
                pressCount_F1 += 1
                totalPresses += 1
                pressTimeTotalConverted_F1 =
                    IntervalMath(pressStartTime_F1, pressEndTime_F1)
                pressTimeTotal_F1 += pressTimeTotalConverted_F1
                totalPressTime += pressTimeTotalConverted_F1
            End If

            '[] IF F2 IS PRESSED
            If isPressed_F2 = True AndAlso isHeld_F2 = False Then
                isHeld_F2 = True
                pressStartTime_F2 = DateTime.Now
            End If

            '[] IF F2 WAS RELEASED
            If isPressed_F2 = False AndAlso isHeld_F2 = True Then
                pressEndTime_F2 = DateTime.Now
                isHeld_F2 = False
                pressCount_F2 += 1
                totalPresses += 1
                pressTimeTotalConverted_F2 =
                    IntervalMath(pressStartTime_F2, pressEndTime_F2)
                pressTimeTotal_F2 += pressTimeTotalConverted_F2
                totalPressTime += pressTimeTotalConverted_F2
            End If

            '[] IF F3 IS PRESSED
            If isPressed_F3 = True AndAlso isHeld_F3 = False Then
                isHeld_F3 = True
                pressStartTime_F3 = DateTime.Now
            End If

            '[] IF F3 WAS RELEASED
            If isPressed_F3 = False AndAlso isHeld_F3 = True Then
                pressEndTime_F3 = DateTime.Now
                isHeld_F3 = False
                pressCount_F3 += 1
                totalPresses += 1
                pressTimeTotalConverted_F3 =
                    IntervalMath(pressStartTime_F3, pressEndTime_F3)
                pressTimeTotal_F3 += pressTimeTotalConverted_F3
                totalPressTime += pressTimeTotalConverted_F3
            End If

            '[] IF F4 IS PRESSED
            If isPressed_F4 = True AndAlso isHeld_F4 = False Then
                isHeld_F4 = True
                pressStartTime_F4 = DateTime.Now
            End If

            '[] IF F4 WAS RELEASED
            If isPressed_F4 = False AndAlso isHeld_F4 = True Then
                pressEndTime_F4 = DateTime.Now
                isHeld_F4 = False
                pressCount_F4 += 1
                totalPresses += 1
                pressTimeTotalConverted_F4 =
                    IntervalMath(pressStartTime_F4, pressEndTime_F4)
                pressTimeTotal_F4 += pressTimeTotalConverted_F4
                totalPressTime += pressTimeTotalConverted_F4
            End If

            '[] IF F5 IS PRESSED
            If isPressed_F5 = True AndAlso isHeld_F5 = False Then
                isHeld_F5 = True
                pressStartTime_F5 = DateTime.Now
            End If

            '[] IF F5 WAS RELEASED
            If isPressed_F5 = False AndAlso isHeld_F5 = True Then
                pressEndTime_F5 = DateTime.Now
                isHeld_F5 = False
                pressCount_F5 += 1
                totalPresses += 1
                pressTimeTotalConverted_F5 =
                    IntervalMath(pressStartTime_F5, pressEndTime_F5)
                pressTimeTotal_F5 += pressTimeTotalConverted_F5
                totalPressTime += pressTimeTotalConverted_F5
            End If

            '[] IF F6 IS PRESSED
            If isPressed_F6 = True AndAlso isHeld_F6 = False Then
                isHeld_F6 = True
                pressStartTime_F6 = DateTime.Now
            End If

            '[] IF F6 WAS RELEASED
            If isPressed_F6 = False AndAlso isHeld_F6 = True Then
                pressEndTime_F6 = DateTime.Now
                isHeld_F6 = False
                pressCount_F6 += 1
                totalPresses += 1
                pressTimeTotalConverted_F6 =
                    IntervalMath(pressStartTime_F6, pressEndTime_F6)
                pressTimeTotal_F6 += pressTimeTotalConverted_F6
                totalPressTime += pressTimeTotalConverted_F6
            End If

            '[] IF F7 IS PRESSED
            If isPressed_F7 = True AndAlso isHeld_F7 = False Then
                isHeld_F7 = True
                pressStartTime_F7 = DateTime.Now
            End If

            '[] IF F7 WAS RELEASED
            If isPressed_F7 = False AndAlso isHeld_F7 = True Then
                pressEndTime_F7 = DateTime.Now
                isHeld_F7 = False
                pressCount_F7 += 1
                totalPresses += 1
                pressTimeTotalConverted_F7 =
                    IntervalMath(pressStartTime_F7, pressEndTime_F7)
                pressTimeTotal_F7 += pressTimeTotalConverted_F7
                totalPressTime += pressTimeTotalConverted_F7
            End If

            '[] IF F8 IS PRESSED
            If isPressed_F8 = True AndAlso isHeld_F8 = False Then
                isHeld_F8 = True
                pressStartTime_F8 = DateTime.Now
            End If

            '[] IF F8 WAS RELEASED
            If isPressed_F8 = False AndAlso isHeld_F8 = True Then
                pressEndTime_F8 = DateTime.Now
                isHeld_F8 = False
                pressCount_F8 += 1
                totalPresses += 1
                pressTimeTotalConverted_F8 =
                    IntervalMath(pressStartTime_F8, pressEndTime_F8)
                pressTimeTotal_F8 += pressTimeTotalConverted_F8
                totalPressTime += pressTimeTotalConverted_F8
            End If

            '[] IF F9 IS PRESSED
            If isPressed_F9 = True AndAlso isHeld_F9 = False Then
                isHeld_F9 = True
                pressStartTime_F9 = DateTime.Now
            End If

            '[] IF F9 WAS RELEASED
            If isPressed_F9 = False AndAlso isHeld_F9 = True Then
                pressEndTime_F9 = DateTime.Now
                isHeld_F9 = False
                pressCount_F9 += 1
                totalPresses += 1
                pressTimeTotalConverted_F9 =
                    IntervalMath(pressStartTime_F9, pressEndTime_F9)
                pressTimeTotal_F9 += pressTimeTotalConverted_F9
                totalPressTime += pressTimeTotalConverted_F9
            End If

            '[] IF F10 IS PRESSED
            If isPressed_F10 = True AndAlso isHeld_F10 = False Then
                isHeld_F10 = True
                pressStartTime_F10 = DateTime.Now
            End If

            '[] IF F10 WAS RELEASED
            If isPressed_F10 = False AndAlso isHeld_F10 = True Then
                pressEndTime_F10 = DateTime.Now
                isHeld_F10 = False
                pressCount_F10 += 1
                totalPresses += 1
                pressTimeTotalConverted_F10 =
                    IntervalMath(pressStartTime_F10, pressEndTime_F10)
                pressTimeTotal_F10 += pressTimeTotalConverted_F10
                totalPressTime += pressTimeTotalConverted_F10
            End If

            '[] IF F11 IS PRESSED
            If isPressed_F11 = True AndAlso isHeld_F11 = False Then
                isHeld_F11 = True
                pressStartTime_F11 = DateTime.Now
            End If

            '[] IF F11 WAS RELEASED
            If isPressed_F11 = False AndAlso isHeld_F11 = True Then
                pressEndTime_F11 = DateTime.Now
                isHeld_F11 = False
                pressCount_F11 += 1
                totalPresses += 1
                pressTimeTotalConverted_F11 =
                    IntervalMath(pressStartTime_F11, pressEndTime_F11)
                pressTimeTotal_F11 += pressTimeTotalConverted_F11
                totalPressTime += pressTimeTotalConverted_F11
            End If

            '[] IF F12 IS PRESSED
            If isPressed_F12 = True AndAlso isHeld_F12 = False Then
                isHeld_F12 = True
                pressStartTime_F12 = DateTime.Now
            End If

            '[] IF F12 WAS RELEASED
            If isPressed_F12 = False AndAlso isHeld_F12 = True Then
                pressEndTime_F12 = DateTime.Now
                isHeld_F12 = False
                pressCount_F12 += 1
                totalPresses += 1
                pressTimeTotalConverted_F12 =
                    IntervalMath(pressStartTime_F12, pressEndTime_F12)
                pressTimeTotal_F12 += pressTimeTotalConverted_F12
                totalPressTime += pressTimeTotalConverted_F12
            End If

            '[] IF PRNT IS PRESSED
            If isPressed_PRNT = True AndAlso isHeld_PRNT = False Then
                isHeld_PRNT = True
                pressStartTime_PRNT = DateTime.Now
            End If

            '[] IF PRNT WAS RELEASED
            If isPressed_PRNT = False AndAlso isHeld_PRNT = True Then
                pressEndTime_PRNT = DateTime.Now
                isHeld_PRNT = False
                pressCount_PRNT += 1
                totalPresses += 1
                pressTimeTotalConverted_PRNT =
                    IntervalMath(pressStartTime_PRNT, pressEndTime_PRNT)
                pressTimeTotal_PRNT += pressTimeTotalConverted_PRNT
                totalPressTime += pressTimeTotalConverted_PRNT
            End If

            '[] IF SCRLOCK IS PRESSED
            If isPressed_SCRLOCK = True AndAlso isHeld_SCRLOCK = False Then
                isHeld_SCRLOCK = True
                pressStartTime_SCRLOCK = DateTime.Now
            End If

            '[] IF SCRLOCK WAS RELEASED
            If isPressed_SCRLOCK = False AndAlso isHeld_SCRLOCK = True Then
                pressEndTime_SCRLOCK = DateTime.Now
                isHeld_SCRLOCK = False
                pressCount_SCRLOCK += 1
                totalPresses += 1
                pressTimeTotalConverted_SCRLOCK =
                    IntervalMath(pressStartTime_SCRLOCK, pressEndTime_SCRLOCK)
                pressTimeTotal_SCRLOCK += pressTimeTotalConverted_SCRLOCK
                totalPressTime += pressTimeTotalConverted_SCRLOCK
            End If

            '[] IF PAUSE IS PRESSED
            If isPressed_PAUSE = True AndAlso isHeld_PAUSE = False Then
                isHeld_PAUSE = True
                pressStartTime_PAUSE = DateTime.Now
            End If

            '[] IF PAUSE WAS RELEASED
            If isPressed_PAUSE = False AndAlso isHeld_PAUSE = True Then
                pressEndTime_PAUSE = DateTime.Now
                isHeld_PAUSE = False
                pressCount_PAUSE += 1
                totalPresses += 1
                pressTimeTotalConverted_PAUSE =
                    IntervalMath(pressStartTime_PAUSE, pressEndTime_PAUSE)
                pressTimeTotal_PAUSE += pressTimeTotalConverted_PAUSE
                totalPressTime += pressTimeTotalConverted_PAUSE
            End If

            '[] IF PLAY IS PRESSED
            If isPressed_PLAY = True AndAlso isHeld_PLAY = False Then
                isHeld_PLAY = True
                pressStartTime_PLAY = DateTime.Now
            End If

            '[] IF PLAY WAS RELEASED
            If isPressed_PLAY = False AndAlso isHeld_PLAY = True Then
                pressEndTime_PLAY = DateTime.Now
                isHeld_PLAY = False
                pressCount_PLAY += 1
                totalPresses += 1
                pressTimeTotalConverted_PLAY =
                    IntervalMath(pressStartTime_PLAY, pressEndTime_PLAY)
                pressTimeTotal_PLAY += pressTimeTotalConverted_PLAY
                totalPressTime += pressTimeTotalConverted_PLAY
            End If

            '[] IF STOP IS PRESSED
            If isPressed_STOP = True AndAlso isHeld_STOP = False Then
                isHeld_STOP = True
                pressStartTime_STOP = DateTime.Now
            End If

            '[] IF STOP WAS RELEASED
            If isPressed_STOP = False AndAlso isHeld_STOP = True Then
                pressEndTime_STOP = DateTime.Now
                isHeld_STOP = False
                pressCount_STOP += 1
                totalPresses += 1
                pressTimeTotalConverted_STOP =
                    IntervalMath(pressStartTime_STOP, pressEndTime_STOP)
                pressTimeTotal_STOP += pressTimeTotalConverted_STOP
                totalPressTime += pressTimeTotalConverted_STOP
            End If

            '[] IF PREV IS PRESSED
            If isPressed_PREV = True AndAlso isHeld_PREV = False Then
                isHeld_PREV = True
                pressStartTime_PREV = DateTime.Now
            End If

            '[] IF PREV WAS RELEASED
            If isPressed_PREV = False AndAlso isHeld_PREV = True Then
                pressEndTime_PREV = DateTime.Now
                isHeld_PREV = False
                pressCount_PREV += 1
                totalPresses += 1
                pressTimeTotalConverted_PREV =
                    IntervalMath(pressStartTime_PREV, pressEndTime_PREV)
                pressTimeTotal_PREV += pressTimeTotalConverted_PREV
                totalPressTime += pressTimeTotalConverted_PREV
            End If

            '[] IF NEXT IS PRESSED
            If isPressed_NEXT = True AndAlso isHeld_NEXT = False Then
                isHeld_NEXT = True
                pressStartTime_NEXT = DateTime.Now
            End If

            '[] IF NEXT WAS RELEASED
            If isPressed_NEXT = False AndAlso isHeld_NEXT = True Then
                pressEndTime_NEXT = DateTime.Now
                isHeld_NEXT = False
                pressCount_NEXT += 1
                totalPresses += 1
                pressTimeTotalConverted_NEXT =
                    IntervalMath(pressStartTime_NEXT, pressEndTime_NEXT)
                pressTimeTotal_NEXT += pressTimeTotalConverted_NEXT
                totalPressTime += pressTimeTotalConverted_NEXT
            End If

            '[] IF TILDE IS PRESSED
            If isPressed_TILDE = True AndAlso isHeld_TILDE = False Then
                isHeld_TILDE = True
                pressStartTime_TILDE = DateTime.Now
            End If

            '[] IF TILDE WAS RELEASED
            If isPressed_TILDE = False AndAlso isHeld_TILDE = True Then
                pressEndTime_TILDE = DateTime.Now
                isHeld_TILDE = False
                pressCount_TILDE += 1
                totalPresses += 1
                pressTimeTotalConverted_TILDE =
                    IntervalMath(pressStartTime_TILDE, pressEndTime_TILDE)
                pressTimeTotal_TILDE += pressTimeTotalConverted_TILDE
                totalPressTime += pressTimeTotalConverted_TILDE
            End If

            '[] IF 1 IS PRESSED
            If isPressed_1 = True AndAlso isHeld_1 = False Then
                isHeld_1 = True
                pressStartTime_1 = DateTime.Now
            End If

            '[] IF 1 WAS RELEASED
            If isPressed_1 = False AndAlso isHeld_1 = True Then
                pressEndTime_1 = DateTime.Now
                isHeld_1 = False
                pressCount_1 += 1
                totalPresses += 1
                pressTimeTotalConverted_1 =
                    IntervalMath(pressStartTime_1, pressEndTime_1)
                pressTimeTotal_1 += pressTimeTotalConverted_1
                totalPressTime += pressTimeTotalConverted_1
            End If

            '[] IF 2 IS PRESSED
            If isPressed_2 = True AndAlso isHeld_2 = False Then
                isHeld_2 = True
                pressStartTime_2 = DateTime.Now
            End If

            '[] IF 2 WAS RELEASED
            If isPressed_2 = False AndAlso isHeld_2 = True Then
                pressEndTime_2 = DateTime.Now
                isHeld_2 = False
                pressCount_2 += 1
                totalPresses += 1
                pressTimeTotalConverted_2 =
                    IntervalMath(pressStartTime_2, pressEndTime_2)
                pressTimeTotal_2 += pressTimeTotalConverted_2
                totalPressTime += pressTimeTotalConverted_2
            End If

            '[] IF 3 IS PRESSED
            If isPressed_3 = True AndAlso isHeld_3 = False Then
                isHeld_3 = True
                pressStartTime_3 = DateTime.Now
            End If

            '[] IF 3 WAS RELEASED
            If isPressed_3 = False AndAlso isHeld_3 = True Then
                pressEndTime_3 = DateTime.Now
                isHeld_3 = False
                pressCount_3 += 1
                totalPresses += 1
                pressTimeTotalConverted_3 =
                    IntervalMath(pressStartTime_3, pressEndTime_3)
                pressTimeTotal_3 += pressTimeTotalConverted_3
                totalPressTime += pressTimeTotalConverted_3
            End If

            '[] IF 4 IS PRESSED
            If isPressed_4 = True AndAlso isHeld_4 = False Then
                isHeld_4 = True
                pressStartTime_4 = DateTime.Now
            End If

            '[] IF 4 WAS RELEASED
            If isPressed_4 = False AndAlso isHeld_4 = True Then
                pressEndTime_4 = DateTime.Now
                isHeld_4 = False
                pressCount_4 += 1
                totalPresses += 1
                pressTimeTotalConverted_4 =
                    IntervalMath(pressStartTime_4, pressEndTime_4)
                pressTimeTotal_4 += pressTimeTotalConverted_4
                totalPressTime += pressTimeTotalConverted_4
            End If

            '[] IF 5 IS PRESSED
            If isPressed_5 = True AndAlso isHeld_5 = False Then
                isHeld_5 = True
                pressStartTime_5 = DateTime.Now
            End If

            '[] IF 5 WAS RELEASED
            If isPressed_5 = False AndAlso isHeld_5 = True Then
                pressEndTime_5 = DateTime.Now
                isHeld_5 = False
                pressCount_5 += 1
                totalPresses += 1
                pressTimeTotalConverted_5 =
                    IntervalMath(pressStartTime_5, pressEndTime_5)
                pressTimeTotal_5 += pressTimeTotalConverted_5
                totalPressTime += pressTimeTotalConverted_5
            End If

            '[] IF 6 IS PRESSED
            If isPressed_6 = True AndAlso isHeld_6 = False Then
                isHeld_6 = True
                pressStartTime_6 = DateTime.Now
            End If

            '[] IF 6 WAS RELEASED
            If isPressed_6 = False AndAlso isHeld_6 = True Then
                pressEndTime_6 = DateTime.Now
                isHeld_6 = False
                pressCount_6 += 1
                totalPresses += 1
                pressTimeTotalConverted_6 =
                    IntervalMath(pressStartTime_6, pressEndTime_6)
                pressTimeTotal_6 += pressTimeTotalConverted_6
                totalPressTime += pressTimeTotalConverted_6
            End If

            '[] IF 7 IS PRESSED
            If isPressed_7 = True AndAlso isHeld_7 = False Then
                isHeld_7 = True
                pressStartTime_7 = DateTime.Now
            End If

            '[] IF 7 WAS RELEASED
            If isPressed_7 = False AndAlso isHeld_7 = True Then
                pressEndTime_7 = DateTime.Now
                isHeld_7 = False
                pressCount_7 += 1
                totalPresses += 1
                pressTimeTotalConverted_7 =
                    IntervalMath(pressStartTime_7, pressEndTime_7)
                pressTimeTotal_7 += pressTimeTotalConverted_7
                totalPressTime += pressTimeTotalConverted_7
            End If

            '[] IF 8 IS PRESSED
            If isPressed_8 = True AndAlso isHeld_8 = False Then
                isHeld_8 = True
                pressStartTime_8 = DateTime.Now
            End If

            '[] IF 8 WAS RELEASED
            If isPressed_8 = False AndAlso isHeld_8 = True Then
                pressEndTime_8 = DateTime.Now
                isHeld_8 = False
                pressCount_8 += 1
                totalPresses += 1
                pressTimeTotalConverted_8 =
                    IntervalMath(pressStartTime_8, pressEndTime_8)
                pressTimeTotal_8 += pressTimeTotalConverted_8
                totalPressTime += pressTimeTotalConverted_8
            End If

            '[] IF 9 IS PRESSED
            If isPressed_9 = True AndAlso isHeld_9 = False Then
                isHeld_9 = True
                pressStartTime_9 = DateTime.Now
            End If

            '[] IF 9 WAS RELEASED
            If isPressed_9 = False AndAlso isHeld_9 = True Then
                pressEndTime_9 = DateTime.Now
                isHeld_9 = False
                pressCount_9 += 1
                totalPresses += 1
                pressTimeTotalConverted_9 =
                    IntervalMath(pressStartTime_9, pressEndTime_9)
                pressTimeTotal_9 += pressTimeTotalConverted_9
                totalPressTime += pressTimeTotalConverted_9
            End If

            '[] IF 0 IS PRESSED
            If isPressed_0 = True AndAlso isHeld_0 = False Then
                isHeld_0 = True
                pressStartTime_0 = DateTime.Now
            End If

            '[] IF 0 WAS RELEASED
            If isPressed_0 = False AndAlso isHeld_0 = True Then
                pressEndTime_0 = DateTime.Now
                isHeld_0 = False
                pressCount_0 += 1
                totalPresses += 1
                pressTimeTotalConverted_0 =
                    IntervalMath(pressStartTime_0, pressEndTime_0)
                pressTimeTotal_0 += pressTimeTotalConverted_0
                totalPressTime += pressTimeTotalConverted_0
            End If

            '[] IF UnderScore IS PRESSED
            If isPressed_UnderScore = True AndAlso isHeld_UnderScore = False Then
                isHeld_UnderScore = True
                pressStartTime_UnderScore = DateTime.Now
            End If

            '[] IF UnderScore WAS RELEASED
            If isPressed_UnderScore = False AndAlso isHeld_UnderScore = True Then
                pressEndTime_UnderScore = DateTime.Now
                isHeld_UnderScore = False
                pressCount_UnderScore += 1
                totalPresses += 1
                pressTimeTotalConverted_UnderScore =
                    IntervalMath(pressStartTime_UnderScore, pressEndTime_UnderScore)
                pressTimeTotal_UnderScore += pressTimeTotalConverted_UnderScore
                totalPressTime += pressTimeTotalConverted_UnderScore
            End If

            '[] IF PlusEquals IS PRESSED
            If isPressed_PlusEquals = True AndAlso isHeld_PlusEquals = False Then
                isHeld_PlusEquals = True
                pressStartTime_PlusEquals = DateTime.Now
            End If

            '[] IF PlusEquals WAS RELEASED
            If isPressed_PlusEquals = False AndAlso isHeld_PlusEquals = True Then
                pressEndTime_PlusEquals = DateTime.Now
                isHeld_PlusEquals = False
                pressCount_PlusEquals += 1
                totalPresses += 1
                pressTimeTotalConverted_PlusEquals =
                    IntervalMath(pressStartTime_PlusEquals, pressEndTime_PlusEquals)
                pressTimeTotal_PlusEquals += pressTimeTotalConverted_PlusEquals
                totalPressTime += pressTimeTotalConverted_PlusEquals
            End If

            '[] IF BackSpace IS PRESSED
            If isPressed_BackSpace = True AndAlso isHeld_BackSpace = False Then
                isHeld_BackSpace = True
                pressStartTime_BackSpace = DateTime.Now
            End If

            '[] IF BackSpace WAS RELEASED
            If isPressed_BackSpace = False AndAlso isHeld_BackSpace = True Then
                pressEndTime_BackSpace = DateTime.Now
                isHeld_BackSpace = False
                pressCount_BackSpace += 1
                totalPresses += 1
                pressTimeTotalConverted_BackSpace =
                    IntervalMath(pressStartTime_BackSpace, pressEndTime_BackSpace)
                pressTimeTotal_BackSpace += pressTimeTotalConverted_BackSpace
                totalPressTime += pressTimeTotalConverted_BackSpace
            End If

            '[] IF Insert IS PRESSED
            If isPressed_Insert = True AndAlso isHeld_Insert = False Then
                isHeld_Insert = True
                pressStartTime_Insert = DateTime.Now
            End If

            '[] IF Insert WAS RELEASED
            If isPressed_Insert = False AndAlso isHeld_Insert = True Then
                pressEndTime_Insert = DateTime.Now
                isHeld_Insert = False
                pressCount_Insert += 1
                totalPresses += 1
                pressTimeTotalConverted_Insert =
                    IntervalMath(pressStartTime_Insert, pressEndTime_Insert)
                pressTimeTotal_Insert += pressTimeTotalConverted_Insert
                totalPressTime += pressTimeTotalConverted_Insert
            End If

            '[] IF Home IS PRESSED
            If isPressed_Home = True AndAlso isHeld_Home = False Then
                isHeld_Home = True
                pressStartTime_Home = DateTime.Now
            End If

            '[] IF Home WAS RELEASED
            If isPressed_Home = False AndAlso isHeld_Home = True Then
                pressEndTime_Home = DateTime.Now
                isHeld_Home = False
                pressCount_Home += 1
                totalPresses += 1
                pressTimeTotalConverted_Home =
                    IntervalMath(pressStartTime_Home, pressEndTime_Home)
                pressTimeTotal_Home += pressTimeTotalConverted_Home
                totalPressTime += pressTimeTotalConverted_Home
            End If

            '[] IF PgUp IS PRESSED
            If isPressed_PgUp = True AndAlso isHeld_PgUp = False Then
                isHeld_PgUp = True
                pressStartTime_PgUp = DateTime.Now
            End If

            '[] IF PgUp WAS RELEASED
            If isPressed_PgUp = False AndAlso isHeld_PgUp = True Then
                pressEndTime_PgUp = DateTime.Now
                isHeld_PgUp = False
                pressCount_PgUp += 1
                totalPresses += 1
                pressTimeTotalConverted_PgUp =
                    IntervalMath(pressStartTime_PgUp, pressEndTime_PgUp)
                pressTimeTotal_PgUp += pressTimeTotalConverted_PgUp
                totalPressTime += pressTimeTotalConverted_PgUp
            End If

            '[] IF NumLock IS PRESSED
            If isPressed_NumLock = True AndAlso isHeld_NumLock = False Then
                isHeld_NumLock = True
                pressStartTime_NumLock = DateTime.Now
            End If

            '[] IF NumLock WAS RELEASED
            If isPressed_NumLock = False AndAlso isHeld_NumLock = True Then
                pressEndTime_NumLock = DateTime.Now
                isHeld_NumLock = False
                pressCount_NumLock += 1
                totalPresses += 1
                pressTimeTotalConverted_NumLock =
                    IntervalMath(pressStartTime_NumLock, pressEndTime_NumLock)
                pressTimeTotal_NumLock += pressTimeTotalConverted_NumLock
                totalPressTime += pressTimeTotalConverted_NumLock
            End If

            '[] IF Divide IS PRESSED
            If isPressed_Divide = True AndAlso isHeld_Divide = False Then
                isHeld_Divide = True
                pressStartTime_Divide = DateTime.Now
            End If

            '[] IF Divide WAS RELEASED
            If isPressed_Divide = False AndAlso isHeld_Divide = True Then
                pressEndTime_Divide = DateTime.Now
                isHeld_Divide = False
                pressCount_Divide += 1
                totalPresses += 1
                pressTimeTotalConverted_Divide =
                    IntervalMath(pressStartTime_Divide, pressEndTime_Divide)
                pressTimeTotal_Divide += pressTimeTotalConverted_Divide
                totalPressTime += pressTimeTotalConverted_Divide
            End If

            '[] IF Multiply IS PRESSED
            If isPressed_Multiply = True AndAlso isHeld_Multiply = False Then
                isHeld_Multiply = True
                pressStartTime_Multiply = DateTime.Now
            End If

            '[] IF Multiply WAS RELEASED
            If isPressed_Multiply = False AndAlso isHeld_Multiply = True Then
                pressEndTime_Multiply = DateTime.Now
                isHeld_Multiply = False
                pressCount_Multiply += 1
                totalPresses += 1
                pressTimeTotalConverted_Multiply =
                    IntervalMath(pressStartTime_Multiply, pressEndTime_Multiply)
                pressTimeTotal_Multiply += pressTimeTotalConverted_Multiply
                totalPressTime += pressTimeTotalConverted_Multiply
            End If

            '[] IF Minus IS PRESSED
            If isPressed_Minus = True AndAlso isHeld_Minus = False Then
                isHeld_Minus = True
                pressStartTime_Minus = DateTime.Now
            End If

            '[] IF Minus WAS RELEASED
            If isPressed_Minus = False AndAlso isHeld_Minus = True Then
                pressEndTime_Minus = DateTime.Now
                isHeld_Minus = False
                pressCount_Minus += 1
                totalPresses += 1
                pressTimeTotalConverted_Minus =
                    IntervalMath(pressStartTime_Minus, pressEndTime_Minus)
                pressTimeTotal_Minus += pressTimeTotalConverted_Minus
                totalPressTime += pressTimeTotalConverted_Minus
            End If

            '[] IF TAB IS PRESSED
            If isPressed_TAB = True AndAlso isHeld_TAB = False Then
                isHeld_TAB = True
                pressStartTime_TAB = DateTime.Now
            End If

            '[] IF TAB WAS RELEASED
            If isPressed_TAB = False AndAlso isHeld_TAB = True Then
                pressEndTime_TAB = DateTime.Now
                isHeld_TAB = False
                pressCount_TAB += 1
                totalPresses += 1
                pressTimeTotalConverted_TAB =
                    IntervalMath(pressStartTime_TAB, pressEndTime_TAB)
                pressTimeTotal_TAB += pressTimeTotalConverted_TAB
                totalPressTime += pressTimeTotalConverted_TAB
            End If

            '[] IF Q IS PRESSED
            If isPressed_Q = True AndAlso isHeld_Q = False Then
                isHeld_Q = True
                pressStartTime_Q = DateTime.Now
            End If

            '[] IF Q WAS RELEASED
            If isPressed_Q = False AndAlso isHeld_Q = True Then
                pressEndTime_Q = DateTime.Now
                isHeld_Q = False
                pressCount_Q += 1
                totalPresses += 1
                pressTimeTotalConverted_Q =
                    IntervalMath(pressStartTime_Q, pressEndTime_Q)
                pressTimeTotal_Q += pressTimeTotalConverted_Q
                totalPressTime += pressTimeTotalConverted_Q
            End If

            '[] IF W IS PRESSED
            If isPressed_W = True AndAlso isHeld_W = False Then
                isHeld_W = True
                pressStartTime_W = DateTime.Now
            End If

            '[] IF W WAS RELEASED
            If isPressed_W = False AndAlso isHeld_W = True Then
                pressEndTime_W = DateTime.Now
                isHeld_W = False
                pressCount_W += 1
                totalPresses += 1
                pressTimeTotalConverted_W =
                    IntervalMath(pressStartTime_W, pressEndTime_W)
                pressTimeTotal_W += pressTimeTotalConverted_W
                totalPressTime += pressTimeTotalConverted_W
            End If

            '[] IF E IS PRESSED
            If isPressed_E = True AndAlso isHeld_E = False Then
                isHeld_E = True
                pressStartTime_E = DateTime.Now
            End If

            '[] IF E WAS RELEASED
            If isPressed_E = False AndAlso isHeld_E = True Then
                pressEndTime_E = DateTime.Now
                isHeld_E = False
                pressCount_E += 1
                totalPresses += 1
                pressTimeTotalConverted_E =
                    IntervalMath(pressStartTime_E, pressEndTime_E)
                pressTimeTotal_E += pressTimeTotalConverted_E
                totalPressTime += pressTimeTotalConverted_E
            End If

            '[] IF R IS PRESSED
            If isPressed_R = True AndAlso isHeld_R = False Then
                isHeld_R = True
                pressStartTime_R = DateTime.Now
            End If

            '[] IF R WAS RELEASED
            If isPressed_R = False AndAlso isHeld_R = True Then
                pressEndTime_R = DateTime.Now
                isHeld_R = False
                pressCount_R += 1
                totalPresses += 1
                pressTimeTotalConverted_R =
                    IntervalMath(pressStartTime_R, pressEndTime_R)
                pressTimeTotal_R += pressTimeTotalConverted_R
                totalPressTime += pressTimeTotalConverted_R
            End If

            '[] IF T IS PRESSED
            If isPressed_T = True AndAlso isHeld_T = False Then
                isHeld_T = True
                pressStartTime_T = DateTime.Now
            End If

            '[] IF T WAS RELEASED
            If isPressed_T = False AndAlso isHeld_T = True Then
                pressEndTime_T = DateTime.Now
                isHeld_T = False
                pressCount_T += 1
                totalPresses += 1
                pressTimeTotalConverted_T =
                    IntervalMath(pressStartTime_T, pressEndTime_T)
                pressTimeTotal_T += pressTimeTotalConverted_T
                totalPressTime += pressTimeTotalConverted_T
            End If

            '[] IF Y IS PRESSED
            If isPressed_Y = True AndAlso isHeld_Y = False Then
                isHeld_Y = True
                pressStartTime_Y = DateTime.Now
            End If

            '[] IF Y WAS RELEASED
            If isPressed_Y = False AndAlso isHeld_Y = True Then
                pressEndTime_Y = DateTime.Now
                isHeld_Y = False
                pressCount_Y += 1
                totalPresses += 1
                pressTimeTotalConverted_Y =
                    IntervalMath(pressStartTime_Y, pressEndTime_Y)
                pressTimeTotal_Y += pressTimeTotalConverted_Y
                totalPressTime += pressTimeTotalConverted_Y
            End If

            '[] IF U IS PRESSED
            If isPressed_U = True AndAlso isHeld_U = False Then
                isHeld_U = True
                pressStartTime_U = DateTime.Now
            End If

            '[] IF U WAS RELEASED
            If isPressed_U = False AndAlso isHeld_U = True Then
                pressEndTime_U = DateTime.Now
                isHeld_U = False
                pressCount_U += 1
                totalPresses += 1
                pressTimeTotalConverted_U =
                    IntervalMath(pressStartTime_U, pressEndTime_U)
                pressTimeTotal_U += pressTimeTotalConverted_U
                totalPressTime += pressTimeTotalConverted_U
            End If

            '[] IF I IS PRESSED
            If isPressed_I = True AndAlso isHeld_I = False Then
                isHeld_I = True
                pressStartTime_I = DateTime.Now
            End If

            '[] IF I WAS RELEASED
            If isPressed_I = False AndAlso isHeld_I = True Then
                pressEndTime_I = DateTime.Now
                isHeld_I = False
                pressCount_I += 1
                totalPresses += 1
                pressTimeTotalConverted_I =
                    IntervalMath(pressStartTime_I, pressEndTime_I)
                pressTimeTotal_I += pressTimeTotalConverted_I
                totalPressTime += pressTimeTotalConverted_I
            End If

            '[] IF O IS PRESSED
            If isPressed_O = True AndAlso isHeld_O = False Then
                isHeld_O = True
                pressStartTime_O = DateTime.Now
            End If

            '[] IF O WAS RELEASED
            If isPressed_O = False AndAlso isHeld_O = True Then
                pressEndTime_O = DateTime.Now
                isHeld_O = False
                pressCount_O += 1
                totalPresses += 1
                pressTimeTotalConverted_O =
                    IntervalMath(pressStartTime_O, pressEndTime_O)
                pressTimeTotal_O += pressTimeTotalConverted_O
                totalPressTime += pressTimeTotalConverted_O
            End If

            '[] IF P IS PRESSED
            If isPressed_P = True AndAlso isHeld_P = False Then
                isHeld_P = True
                pressStartTime_P = DateTime.Now
            End If

            '[] IF P WAS RELEASED
            If isPressed_P = False AndAlso isHeld_P = True Then
                pressEndTime_P = DateTime.Now
                isHeld_P = False
                pressCount_P += 1
                totalPresses += 1
                pressTimeTotalConverted_P =
                    IntervalMath(pressStartTime_P, pressEndTime_P)
                pressTimeTotal_P += pressTimeTotalConverted_P
                totalPressTime += pressTimeTotalConverted_P
            End If

            '[] IF LBracket IS PRESSED
            If isPressed_LBracket = True AndAlso isHeld_LBracket = False Then
                isHeld_LBracket = True
                pressStartTime_LBracket = DateTime.Now
            End If

            '[] IF LBracket WAS RELEASED
            If isPressed_LBracket = False AndAlso isHeld_LBracket = True Then
                pressEndTime_LBracket = DateTime.Now
                isHeld_LBracket = False
                pressCount_LBracket += 1
                totalPresses += 1
                pressTimeTotalConverted_LBracket =
                    IntervalMath(pressStartTime_LBracket, pressEndTime_LBracket)
                pressTimeTotal_LBracket += pressTimeTotalConverted_LBracket
                totalPressTime += pressTimeTotalConverted_LBracket
            End If

            '[] IF RBracket IS PRESSED
            If isPressed_RBracket = True AndAlso isHeld_RBracket = False Then
                isHeld_RBracket = True
                pressStartTime_RBracket = DateTime.Now
            End If

            '[] IF RBracket WAS RELEASED
            If isPressed_RBracket = False AndAlso isHeld_RBracket = True Then
                pressEndTime_RBracket = DateTime.Now
                isHeld_RBracket = False
                pressCount_RBracket += 1
                totalPresses += 1
                pressTimeTotalConverted_RBracket =
                    IntervalMath(pressStartTime_RBracket, pressEndTime_RBracket)
                pressTimeTotal_RBracket += pressTimeTotalConverted_RBracket
                totalPressTime += pressTimeTotalConverted_RBracket
            End If

            '[] IF Slash IS PRESSED
            If isPressed_Slash = True AndAlso isHeld_Slash = False Then
                isHeld_Slash = True
                pressStartTime_Slash = DateTime.Now
            End If

            '[] IF Slash WAS RELEASED
            If isPressed_Slash = False AndAlso isHeld_Slash = True Then
                pressEndTime_Slash = DateTime.Now
                isHeld_Slash = False
                pressCount_Slash += 1
                totalPresses += 1
                pressTimeTotalConverted_Slash =
                    IntervalMath(pressStartTime_Slash, pressEndTime_Slash)
                pressTimeTotal_Slash += pressTimeTotalConverted_Slash
                totalPressTime += pressTimeTotalConverted_Slash
            End If

            '[] IF Delete IS PRESSED
            If isPressed_Delete = True AndAlso isHeld_Delete = False Then
                isHeld_Delete = True
                pressStartTime_Delete = DateTime.Now
            End If

            '[] IF Delete WAS RELEASED
            If isPressed_Delete = False AndAlso isHeld_Delete = True Then
                pressEndTime_Delete = DateTime.Now
                isHeld_Delete = False
                pressCount_Delete += 1
                totalPresses += 1
                pressTimeTotalConverted_Delete =
                    IntervalMath(pressStartTime_Delete, pressEndTime_Delete)
                pressTimeTotal_Delete += pressTimeTotalConverted_Delete
                totalPressTime += pressTimeTotalConverted_Delete
            End If

            '[] IF End IS PRESSED
            If isPressed_End = True AndAlso isHeld_End = False Then
                isHeld_End = True
                pressStartTime_End = DateTime.Now
            End If

            '[] IF End WAS RELEASED
            If isPressed_End = False AndAlso isHeld_End = True Then
                pressEndTime_End = DateTime.Now
                isHeld_End = False
                pressCount_End += 1
                totalPresses += 1
                pressTimeTotalConverted_End =
                    IntervalMath(pressStartTime_End, pressEndTime_End)
                pressTimeTotal_End += pressTimeTotalConverted_End
                totalPressTime += pressTimeTotalConverted_End
            End If

            '[] IF PgDn IS PRESSED
            If isPressed_PgDn = True AndAlso isHeld_PgDn = False Then
                isHeld_PgDn = True
                pressStartTime_PgDn = DateTime.Now
            End If

            '[] IF PgDn WAS RELEASED
            If isPressed_PgDn = False AndAlso isHeld_PgDn = True Then
                pressEndTime_PgDn = DateTime.Now
                isHeld_PgDn = False
                pressCount_PgDn += 1
                totalPresses += 1
                pressTimeTotalConverted_PgDn =
                    IntervalMath(pressStartTime_PgDn, pressEndTime_PgDn)
                pressTimeTotal_PgDn += pressTimeTotalConverted_PgDn
                totalPressTime += pressTimeTotalConverted_PgDn
            End If

            '[] IF Num7 IS PRESSED
            If isPressed_Num7 = True AndAlso isHeld_Num7 = False Then
                isHeld_Num7 = True
                pressStartTime_Num7 = DateTime.Now
            End If

            '[] IF Num7 WAS RELEASED
            If isPressed_Num7 = False AndAlso isHeld_Num7 = True Then
                pressEndTime_Num7 = DateTime.Now
                isHeld_Num7 = False
                pressCount_Num7 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num7 =
                    IntervalMath(pressStartTime_Num7, pressEndTime_Num7)
                pressTimeTotal_Num7 += pressTimeTotalConverted_Num7
                totalPressTime += pressTimeTotalConverted_Num7
            End If

            '[] IF Num8 IS PRESSED
            If isPressed_Num8 = True AndAlso isHeld_Num8 = False Then
                isHeld_Num8 = True
                pressStartTime_Num8 = DateTime.Now
            End If

            '[] IF Num8 WAS RELEASED
            If isPressed_Num8 = False AndAlso isHeld_Num8 = True Then
                pressEndTime_Num8 = DateTime.Now
                isHeld_Num8 = False
                pressCount_Num8 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num8 =
                    IntervalMath(pressStartTime_Num8, pressEndTime_Num8)
                pressTimeTotal_Num8 += pressTimeTotalConverted_Num8
                totalPressTime += pressTimeTotalConverted_Num8
            End If

            '[] IF Num9 IS PRESSED
            If isPressed_Num9 = True AndAlso isHeld_Num9 = False Then
                isHeld_Num9 = True
                pressStartTime_Num9 = DateTime.Now
            End If

            '[] IF Num9 WAS RELEASED
            If isPressed_Num9 = False AndAlso isHeld_Num9 = True Then
                pressEndTime_Num9 = DateTime.Now
                isHeld_Num9 = False
                pressCount_Num9 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num9 =
                    IntervalMath(pressStartTime_Num9, pressEndTime_Num9)
                pressTimeTotal_Num9 += pressTimeTotalConverted_Num9
                totalPressTime += pressTimeTotalConverted_Num9
            End If

            '[] IF CAPS IS PRESSED
            If isPressed_CAPS = True AndAlso isHeld_CAPS = False Then
                isHeld_CAPS = True
                pressStartTime_CAPS = DateTime.Now
            End If

            '[] IF CAPS WAS RELEASED
            If isPressed_CAPS = False AndAlso isHeld_CAPS = True Then
                pressEndTime_CAPS = DateTime.Now
                isHeld_CAPS = False
                pressCount_CAPS += 1
                totalPresses += 1
                pressTimeTotalConverted_CAPS =
                    IntervalMath(pressStartTime_CAPS, pressEndTime_CAPS)
                pressTimeTotal_CAPS += pressTimeTotalConverted_CAPS
                totalPressTime += pressTimeTotalConverted_CAPS
            End If

            '[] IF A IS PRESSED
            If isPressed_A = True AndAlso isHeld_A = False Then
                isHeld_A = True
                pressStartTime_A = DateTime.Now
            End If

            '[] IF A WAS RELEASED
            If isPressed_A = False AndAlso isHeld_A = True Then
                pressEndTime_A = DateTime.Now
                isHeld_A = False
                pressCount_A += 1
                totalPresses += 1
                pressTimeTotalConverted_A =
                    IntervalMath(pressStartTime_A, pressEndTime_A)
                pressTimeTotal_A += pressTimeTotalConverted_A
                totalPressTime += pressTimeTotalConverted_A
            End If

            '[] IF S IS PRESSED
            If isPressed_S = True AndAlso isHeld_S = False Then
                isHeld_S = True
                pressStartTime_S = DateTime.Now
            End If

            '[] IF S WAS RELEASED
            If isPressed_S = False AndAlso isHeld_S = True Then
                pressEndTime_S = DateTime.Now
                isHeld_S = False
                pressCount_S += 1
                totalPresses += 1
                pressTimeTotalConverted_S =
                    IntervalMath(pressStartTime_S, pressEndTime_S)
                pressTimeTotal_S += pressTimeTotalConverted_S
                totalPressTime += pressTimeTotalConverted_S
            End If

            '[] IF D IS PRESSED
            If isPressed_D = True AndAlso isHeld_D = False Then
                isHeld_D = True
                pressStartTime_D = DateTime.Now
            End If

            '[] IF D WAS RELEASED
            If isPressed_D = False AndAlso isHeld_D = True Then
                pressEndTime_D = DateTime.Now
                isHeld_D = False
                pressCount_D += 1
                totalPresses += 1
                pressTimeTotalConverted_D =
                    IntervalMath(pressStartTime_D, pressEndTime_D)
                pressTimeTotal_D += pressTimeTotalConverted_D
                totalPressTime += pressTimeTotalConverted_D
            End If

            '[] IF F IS PRESSED
            If isPressed_F = True AndAlso isHeld_F = False Then
                isHeld_F = True
                pressStartTime_F = DateTime.Now
            End If

            '[] IF F WAS RELEASED
            If isPressed_F = False AndAlso isHeld_F = True Then
                pressEndTime_F = DateTime.Now
                isHeld_F = False
                pressCount_F += 1
                totalPresses += 1
                pressTimeTotalConverted_F =
                    IntervalMath(pressStartTime_F, pressEndTime_F)
                pressTimeTotal_F += pressTimeTotalConverted_F
                totalPressTime += pressTimeTotalConverted_F
            End If

            '[] IF G IS PRESSED
            If isPressed_G = True AndAlso isHeld_G = False Then
                isHeld_G = True
                pressStartTime_G = DateTime.Now
            End If

            '[] IF G WAS RELEASED
            If isPressed_G = False AndAlso isHeld_G = True Then
                pressEndTime_G = DateTime.Now
                isHeld_G = False
                pressCount_G += 1
                totalPresses += 1
                pressTimeTotalConverted_G =
                    IntervalMath(pressStartTime_G, pressEndTime_G)
                pressTimeTotal_G += pressTimeTotalConverted_G
                totalPressTime += pressTimeTotalConverted_G
            End If

            '[] IF H IS PRESSED
            If isPressed_H = True AndAlso isHeld_H = False Then
                isHeld_H = True
                pressStartTime_H = DateTime.Now
            End If

            '[] IF H WAS RELEASED
            If isPressed_H = False AndAlso isHeld_H = True Then
                pressEndTime_H = DateTime.Now
                isHeld_H = False
                pressCount_H += 1
                totalPresses += 1
                pressTimeTotalConverted_H =
                    IntervalMath(pressStartTime_H, pressEndTime_H)
                pressTimeTotal_H += pressTimeTotalConverted_H
                totalPressTime += pressTimeTotalConverted_H
            End If

            '[] IF J IS PRESSED
            If isPressed_J = True AndAlso isHeld_J = False Then
                isHeld_J = True
                pressStartTime_J = DateTime.Now
            End If

            '[] IF J WAS RELEASED
            If isPressed_J = False AndAlso isHeld_J = True Then
                pressEndTime_J = DateTime.Now
                isHeld_J = False
                pressCount_J += 1
                totalPresses += 1
                pressTimeTotalConverted_J =
                    IntervalMath(pressStartTime_J, pressEndTime_J)
                pressTimeTotal_J += pressTimeTotalConverted_J
                totalPressTime += pressTimeTotalConverted_J
            End If

            '[] IF K IS PRESSED
            If isPressed_K = True AndAlso isHeld_K = False Then
                isHeld_K = True
                pressStartTime_K = DateTime.Now
            End If

            '[] IF K WAS RELEASED
            If isPressed_K = False AndAlso isHeld_K = True Then
                pressEndTime_K = DateTime.Now
                isHeld_K = False
                pressCount_K += 1
                totalPresses += 1
                pressTimeTotalConverted_K =
                    IntervalMath(pressStartTime_K, pressEndTime_K)
                pressTimeTotal_K += pressTimeTotalConverted_K
                totalPressTime += pressTimeTotalConverted_K
            End If

            '[] IF L IS PRESSED
            If isPressed_L = True AndAlso isHeld_L = False Then
                isHeld_L = True
                pressStartTime_L = DateTime.Now
            End If

            '[] IF L WAS RELEASED
            If isPressed_L = False AndAlso isHeld_L = True Then
                pressEndTime_L = DateTime.Now
                isHeld_L = False
                pressCount_L += 1
                totalPresses += 1
                pressTimeTotalConverted_L =
                    IntervalMath(pressStartTime_L, pressEndTime_L)
                pressTimeTotal_L += pressTimeTotalConverted_L
                totalPressTime += pressTimeTotalConverted_L
            End If

            '[] IF COLON IS PRESSED
            If isPressed_COLON = True AndAlso isHeld_COLON = False Then
                isHeld_COLON = True
                pressStartTime_COLON = DateTime.Now
            End If

            '[] IF COLON WAS RELEASED
            If isPressed_COLON = False AndAlso isHeld_COLON = True Then
                pressEndTime_COLON = DateTime.Now
                isHeld_COLON = False
                pressCount_COLON += 1
                totalPresses += 1
                pressTimeTotalConverted_COLON =
                    IntervalMath(pressStartTime_COLON, pressEndTime_COLON)
                pressTimeTotal_COLON += pressTimeTotalConverted_COLON
                totalPressTime += pressTimeTotalConverted_COLON
            End If

            '[] IF QUOTES IS PRESSED
            If isPressed_QUOTES = True AndAlso isHeld_QUOTES = False Then
                isHeld_QUOTES = True
                pressStartTime_QUOTES = DateTime.Now
            End If

            '[] IF QUOTES WAS RELEASED
            If isPressed_QUOTES = False AndAlso isHeld_QUOTES = True Then
                pressEndTime_QUOTES = DateTime.Now
                isHeld_QUOTES = False
                pressCount_QUOTES += 1
                totalPresses += 1
                pressTimeTotalConverted_QUOTES =
                    IntervalMath(pressStartTime_QUOTES, pressEndTime_QUOTES)
                pressTimeTotal_QUOTES += pressTimeTotalConverted_QUOTES
                totalPressTime += pressTimeTotalConverted_QUOTES
            End If

            '[] IF MainEnter IS PRESSED
            If isPressed_MainEnter = True AndAlso isHeld_MainEnter = False Then
                isHeld_MainEnter = True
                pressStartTime_MainEnter = DateTime.Now
            End If

            '[] IF MainEnter WAS RELEASED
            If isPressed_MainEnter = False AndAlso isHeld_MainEnter = True Then
                pressEndTime_MainEnter = DateTime.Now
                isHeld_MainEnter = False
                pressCount_MainEnter += 1
                totalPresses += 1
                pressTimeTotalConverted_MainEnter =
                    IntervalMath(pressStartTime_MainEnter, pressEndTime_MainEnter)
                pressTimeTotal_MainEnter += pressTimeTotalConverted_MainEnter
                totalPressTime += pressTimeTotalConverted_MainEnter
            End If

            '[] IF Num4 IS PRESSED
            If isPressed_Num4 = True AndAlso isHeld_Num4 = False Then
                isHeld_Num4 = True
                pressStartTime_Num4 = DateTime.Now
            End If

            '[] IF Num4 WAS RELEASED
            If isPressed_Num4 = False AndAlso isHeld_Num4 = True Then
                pressEndTime_Num4 = DateTime.Now
                isHeld_Num4 = False
                pressCount_Num4 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num4 =
                    IntervalMath(pressStartTime_Num4, pressEndTime_Num4)
                pressTimeTotal_Num4 += pressTimeTotalConverted_Num4
                totalPressTime += pressTimeTotalConverted_Num4
            End If

            '[] IF Num5 IS PRESSED
            If isPressed_Num5 = True AndAlso isHeld_Num5 = False Then
                isHeld_Num5 = True
                pressStartTime_Num5 = DateTime.Now
            End If

            '[] IF Num5 WAS RELEASED
            If isPressed_Num5 = False AndAlso isHeld_Num5 = True Then
                pressEndTime_Num5 = DateTime.Now
                isHeld_Num5 = False
                pressCount_Num5 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num5 =
                    IntervalMath(pressStartTime_Num5, pressEndTime_Num5)
                pressTimeTotal_Num5 += pressTimeTotalConverted_Num5
                totalPressTime += pressTimeTotalConverted_Num5
            End If

            '[] IF Num6 IS PRESSED
            If isPressed_Num6 = True AndAlso isHeld_Num6 = False Then
                isHeld_Num6 = True
                pressStartTime_Num6 = DateTime.Now
            End If

            '[] IF Num6 WAS RELEASED
            If isPressed_Num6 = False AndAlso isHeld_Num6 = True Then
                pressEndTime_Num6 = DateTime.Now
                isHeld_Num6 = False
                pressCount_Num6 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num6 =
                    IntervalMath(pressStartTime_Num6, pressEndTime_Num6)
                pressTimeTotal_Num6 += pressTimeTotalConverted_Num6
                totalPressTime += pressTimeTotalConverted_Num6
            End If

            '[] IF Plus IS PRESSED
            If isPressed_Plus = True AndAlso isHeld_Plus = False Then
                isHeld_Plus = True
                pressStartTime_Plus = DateTime.Now
            End If

            '[] IF Plus WAS RELEASED
            If isPressed_Plus = False AndAlso isHeld_Plus = True Then
                pressEndTime_Plus = DateTime.Now
                isHeld_Plus = False
                pressCount_Plus += 1
                totalPresses += 1
                pressTimeTotalConverted_Plus =
                    IntervalMath(pressStartTime_Plus, pressEndTime_Plus)
                pressTimeTotal_Plus += pressTimeTotalConverted_Plus
                totalPressTime += pressTimeTotalConverted_Plus
            End If

            '[] IF LSHIFT IS PRESSED
            If isPressed_LSHIFT = True AndAlso isHeld_LSHIFT = False Then
                isHeld_LSHIFT = True
                pressStartTime_LSHIFT = DateTime.Now
            End If

            '[] IF LSHIFT WAS RELEASED
            If isPressed_LSHIFT = False AndAlso isHeld_LSHIFT = True Then
                pressEndTime_LSHIFT = DateTime.Now
                isHeld_LSHIFT = False
                pressCount_LSHIFT += 1
                totalPresses += 1
                pressTimeTotalConverted_LSHIFT =
                    IntervalMath(pressStartTime_LSHIFT, pressEndTime_LSHIFT)
                pressTimeTotal_LSHIFT += pressTimeTotalConverted_LSHIFT
                totalPressTime += pressTimeTotalConverted_LSHIFT
            End If

            '[] IF Z IS PRESSED
            If isPressed_Z = True AndAlso isHeld_Z = False Then
                isHeld_Z = True
                pressStartTime_Z = DateTime.Now
            End If

            '[] IF Z WAS RELEASED
            If isPressed_Z = False AndAlso isHeld_Z = True Then
                pressEndTime_Z = DateTime.Now
                isHeld_Z = False
                pressCount_Z += 1
                totalPresses += 1
                pressTimeTotalConverted_Z =
                    IntervalMath(pressStartTime_Z, pressEndTime_Z)
                pressTimeTotal_Z += pressTimeTotalConverted_Z
                totalPressTime += pressTimeTotalConverted_Z
            End If

            '[] IF X IS PRESSED
            If isPressed_X = True AndAlso isHeld_X = False Then
                isHeld_X = True
                pressStartTime_X = DateTime.Now
            End If

            '[] IF X WAS RELEASED
            If isPressed_X = False AndAlso isHeld_X = True Then
                pressEndTime_X = DateTime.Now
                isHeld_X = False
                pressCount_X += 1
                totalPresses += 1
                pressTimeTotalConverted_X =
                    IntervalMath(pressStartTime_X, pressEndTime_X)
                pressTimeTotal_X += pressTimeTotalConverted_X
                totalPressTime += pressTimeTotalConverted_X
            End If

            '[] IF C IS PRESSED
            If isPressed_C = True AndAlso isHeld_C = False Then
                isHeld_C = True
                pressStartTime_C = DateTime.Now
            End If

            '[] IF C WAS RELEASED
            If isPressed_C = False AndAlso isHeld_C = True Then
                pressEndTime_C = DateTime.Now
                isHeld_C = False
                pressCount_C += 1
                totalPresses += 1
                pressTimeTotalConverted_C =
                    IntervalMath(pressStartTime_C, pressEndTime_C)
                pressTimeTotal_C += pressTimeTotalConverted_C
                totalPressTime += pressTimeTotalConverted_C
            End If

            '[] IF V IS PRESSED
            If isPressed_V = True AndAlso isHeld_V = False Then
                isHeld_V = True
                pressStartTime_V = DateTime.Now
            End If

            '[] IF V WAS RELEASED
            If isPressed_V = False AndAlso isHeld_V = True Then
                pressEndTime_V = DateTime.Now
                isHeld_V = False
                pressCount_V += 1
                totalPresses += 1
                pressTimeTotalConverted_V =
                    IntervalMath(pressStartTime_V, pressEndTime_V)
                pressTimeTotal_V += pressTimeTotalConverted_V
                totalPressTime += pressTimeTotalConverted_V
            End If

            '[] IF B IS PRESSED
            If isPressed_B = True AndAlso isHeld_B = False Then
                isHeld_B = True
                pressStartTime_B = DateTime.Now
            End If

            '[] IF B WAS RELEASED
            If isPressed_B = False AndAlso isHeld_B = True Then
                pressEndTime_B = DateTime.Now
                isHeld_B = False
                pressCount_B += 1
                totalPresses += 1
                pressTimeTotalConverted_B =
                    IntervalMath(pressStartTime_B, pressEndTime_B)
                pressTimeTotal_B += pressTimeTotalConverted_B
                totalPressTime += pressTimeTotalConverted_B
            End If

            '[] IF N IS PRESSED
            If isPressed_N = True AndAlso isHeld_N = False Then
                isHeld_N = True
                pressStartTime_N = DateTime.Now
            End If

            '[] IF N WAS RELEASED
            If isPressed_N = False AndAlso isHeld_N = True Then
                pressEndTime_N = DateTime.Now
                isHeld_N = False
                pressCount_N += 1
                totalPresses += 1
                pressTimeTotalConverted_N =
                    IntervalMath(pressStartTime_N, pressEndTime_N)
                pressTimeTotal_N += pressTimeTotalConverted_N
                totalPressTime += pressTimeTotalConverted_N
            End If

            '[] IF M IS PRESSED
            If isPressed_M = True AndAlso isHeld_M = False Then
                isHeld_M = True
                pressStartTime_M = DateTime.Now
            End If

            '[] IF M WAS RELEASED
            If isPressed_M = False AndAlso isHeld_M = True Then
                pressEndTime_M = DateTime.Now
                isHeld_M = False
                pressCount_M += 1
                totalPresses += 1
                pressTimeTotalConverted_M =
                    IntervalMath(pressStartTime_M, pressEndTime_M)
                pressTimeTotal_M += pressTimeTotalConverted_M
                totalPressTime += pressTimeTotalConverted_M
            End If

            '[] IF LESS IS PRESSED
            If isPressed_LESS = True AndAlso isHeld_LESS = False Then
                isHeld_LESS = True
                pressStartTime_LESS = DateTime.Now
            End If

            '[] IF LESS WAS RELEASED
            If isPressed_LESS = False AndAlso isHeld_LESS = True Then
                pressEndTime_LESS = DateTime.Now
                isHeld_LESS = False
                pressCount_LESS += 1
                totalPresses += 1
                pressTimeTotalConverted_LESS =
                    IntervalMath(pressStartTime_LESS, pressEndTime_LESS)
                pressTimeTotal_LESS += pressTimeTotalConverted_LESS
                totalPressTime += pressTimeTotalConverted_LESS
            End If

            '[] IF Greater IS PRESSED
            If isPressed_Greater = True AndAlso isHeld_Greater = False Then
                isHeld_Greater = True
                pressStartTime_Greater = DateTime.Now
            End If

            '[] IF Greater WAS RELEASED
            If isPressed_Greater = False AndAlso isHeld_Greater = True Then
                pressEndTime_Greater = DateTime.Now
                isHeld_Greater = False
                pressCount_Greater += 1
                totalPresses += 1
                pressTimeTotalConverted_Greater =
                    IntervalMath(pressStartTime_Greater, pressEndTime_Greater)
                pressTimeTotal_Greater += pressTimeTotalConverted_Greater
                totalPressTime += pressTimeTotalConverted_Greater
            End If

            '[] IF Question IS PRESSED
            If isPressed_Question = True AndAlso isHeld_Question = False Then
                isHeld_Question = True
                pressStartTime_Question = DateTime.Now
            End If

            '[] IF Question WAS RELEASED
            If isPressed_Question = False AndAlso isHeld_Question = True Then
                pressEndTime_Question = DateTime.Now
                isHeld_Question = False
                pressCount_Question += 1
                totalPresses += 1
                pressTimeTotalConverted_Question =
                    IntervalMath(pressStartTime_Question, pressEndTime_Question)
                pressTimeTotal_Question += pressTimeTotalConverted_Question
                totalPressTime += pressTimeTotalConverted_Question
            End If

            '[] IF RSHIFT IS PRESSED
            If isPressed_RSHIFT = True AndAlso isHeld_RSHIFT = False Then
                isHeld_RSHIFT = True
                pressStartTime_RSHIFT = DateTime.Now
            End If

            '[] IF RSHIFT WAS RELEASED
            If isPressed_RSHIFT = False AndAlso isHeld_RSHIFT = True Then
                pressEndTime_RSHIFT = DateTime.Now
                isHeld_RSHIFT = False
                pressCount_RSHIFT += 1
                totalPresses += 1
                pressTimeTotalConverted_RSHIFT =
                    IntervalMath(pressStartTime_RSHIFT, pressEndTime_RSHIFT)
                pressTimeTotal_RSHIFT += pressTimeTotalConverted_RSHIFT
                totalPressTime += pressTimeTotalConverted_RSHIFT
            End If

            '[] IF UP IS PRESSED
            If isPressed_UP = True AndAlso isHeld_UP = False Then
                isHeld_UP = True
                pressStartTime_UP = DateTime.Now
            End If

            '[] IF UP WAS RELEASED
            If isPressed_UP = False AndAlso isHeld_UP = True Then
                pressEndTime_UP = DateTime.Now
                isHeld_UP = False
                pressCount_UP += 1
                totalPresses += 1
                pressTimeTotalConverted_UP =
                    IntervalMath(pressStartTime_UP, pressEndTime_UP)
                pressTimeTotal_UP += pressTimeTotalConverted_UP
                totalPressTime += pressTimeTotalConverted_UP
            End If

            '[] IF Num1 IS PRESSED
            If isPressed_Num1 = True AndAlso isHeld_Num1 = False Then
                isHeld_Num1 = True
                pressStartTime_Num1 = DateTime.Now
            End If

            '[] IF Num1 WAS RELEASED
            If isPressed_Num1 = False AndAlso isHeld_Num1 = True Then
                pressEndTime_Num1 = DateTime.Now
                isHeld_Num1 = False
                pressCount_Num1 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num1 =
                    IntervalMath(pressStartTime_Num1, pressEndTime_Num1)
                pressTimeTotal_Num1 += pressTimeTotalConverted_Num1
                totalPressTime += pressTimeTotalConverted_Num1
            End If

            '[] IF Num2 IS PRESSED
            If isPressed_Num2 = True AndAlso isHeld_Num2 = False Then
                isHeld_Num2 = True
                pressStartTime_Num2 = DateTime.Now
            End If

            '[] IF Num2 WAS RELEASED
            If isPressed_Num2 = False AndAlso isHeld_Num2 = True Then
                pressEndTime_Num2 = DateTime.Now
                isHeld_Num2 = False
                pressCount_Num2 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num2 =
                    IntervalMath(pressStartTime_Num2, pressEndTime_Num2)
                pressTimeTotal_Num2 += pressTimeTotalConverted_Num2
                totalPressTime += pressTimeTotalConverted_Num2
            End If

            '[] IF Num3 IS PRESSED
            If isPressed_Num3 = True AndAlso isHeld_Num3 = False Then
                isHeld_Num3 = True
                pressStartTime_Num3 = DateTime.Now
            End If

            '[] IF Num3 WAS RELEASED
            If isPressed_Num3 = False AndAlso isHeld_Num3 = True Then
                pressEndTime_Num3 = DateTime.Now
                isHeld_Num3 = False
                pressCount_Num3 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num3 =
                    IntervalMath(pressStartTime_Num3, pressEndTime_Num3)
                pressTimeTotal_Num3 += pressTimeTotalConverted_Num3
                totalPressTime += pressTimeTotalConverted_Num3
            End If

            '[] IF LCTRL IS PRESSED
            If isPressed_LCTRL = True AndAlso isHeld_LCTRL = False Then
                isHeld_LCTRL = True
                pressStartTime_LCTRL = DateTime.Now
            End If

            '[] IF LCTRL WAS RELEASED
            If isPressed_LCTRL = False AndAlso isHeld_LCTRL = True Then
                pressEndTime_LCTRL = DateTime.Now
                isHeld_LCTRL = False
                pressCount_LCTRL += 1
                totalPresses += 1
                pressTimeTotalConverted_LCTRL =
                    IntervalMath(pressStartTime_LCTRL, pressEndTime_LCTRL)
                pressTimeTotal_LCTRL += pressTimeTotalConverted_LCTRL
                totalPressTime += pressTimeTotalConverted_LCTRL
            End If

            '[] IF LWIN IS PRESSED
            If isPressed_LWIN = True AndAlso isHeld_LWIN = False Then
                isHeld_LWIN = True
                pressStartTime_LWIN = DateTime.Now
            End If

            '[] IF LWIN WAS RELEASED
            If isPressed_LWIN = False AndAlso isHeld_LWIN = True Then
                pressEndTime_LWIN = DateTime.Now
                isHeld_LWIN = False
                pressCount_LWIN += 1
                totalPresses += 1
                pressTimeTotalConverted_LWIN =
                    IntervalMath(pressStartTime_LWIN, pressEndTime_LWIN)
                pressTimeTotal_LWIN += pressTimeTotalConverted_LWIN
                totalPressTime += pressTimeTotalConverted_LWIN
            End If

            '[] IF LALT IS PRESSED
            If isPressed_LALT = True AndAlso isHeld_LALT = False Then
                isHeld_LALT = True
                pressStartTime_LALT = DateTime.Now
            End If

            '[] IF LALT WAS RELEASED
            If isPressed_LALT = False AndAlso isHeld_LALT = True Then
                pressEndTime_LALT = DateTime.Now
                isHeld_LALT = False
                pressCount_LALT += 1
                totalPresses += 1
                pressTimeTotalConverted_LALT =
                    IntervalMath(pressStartTime_LALT, pressEndTime_LALT)
                pressTimeTotal_LALT += pressTimeTotalConverted_LALT
                totalPressTime += pressTimeTotalConverted_LALT
            End If

            '[] IF SpaceBar IS PRESSED
            If isPressed_SpaceBar = True AndAlso isHeld_SpaceBar = False Then
                isHeld_SpaceBar = True
                pressStartTime_SpaceBar = DateTime.Now
            End If

            '[] IF SpaceBar WAS RELEASED
            If isPressed_SpaceBar = False AndAlso isHeld_SpaceBar = True Then
                pressEndTime_SpaceBar = DateTime.Now
                isHeld_SpaceBar = False
                pressCount_SpaceBar += 1
                totalPresses += 1
                pressTimeTotalConverted_SpaceBar =
                    IntervalMath(pressStartTime_SpaceBar, pressEndTime_SpaceBar)
                pressTimeTotal_SpaceBar += pressTimeTotalConverted_SpaceBar
                totalPressTime += pressTimeTotalConverted_SpaceBar
            End If

            '[] IF RALT IS PRESSED
            If isPressed_RALT = True AndAlso isHeld_RALT = False Then
                isHeld_RALT = True
                pressStartTime_RALT = DateTime.Now
            End If

            '[] IF RALT WAS RELEASED
            If isPressed_RALT = False AndAlso isHeld_RALT = True Then
                pressEndTime_RALT = DateTime.Now
                isHeld_RALT = False
                pressCount_RALT += 1
                totalPresses += 1
                pressTimeTotalConverted_RALT =
                    IntervalMath(pressStartTime_RALT, pressEndTime_RALT)
                pressTimeTotal_RALT += pressTimeTotalConverted_RALT
                totalPressTime += pressTimeTotalConverted_RALT
            End If

            '[] IF RWIN IS PRESSED
            If isPressed_RWIN = True AndAlso isHeld_RWIN = False Then
                isHeld_RWIN = True
                pressStartTime_RWIN = DateTime.Now
            End If

            '[] IF RWIN WAS RELEASED
            If isPressed_RWIN = False AndAlso isHeld_RWIN = True Then
                pressEndTime_RWIN = DateTime.Now
                isHeld_RWIN = False
                pressCount_RWIN += 1
                totalPresses += 1
                pressTimeTotalConverted_RWIN =
                    IntervalMath(pressStartTime_RWIN, pressEndTime_RWIN)
                pressTimeTotal_RWIN += pressTimeTotalConverted_RWIN
                totalPressTime += pressTimeTotalConverted_RWIN
            End If

            '[] IF APPS IS PRESSED
            If isPressed_APPS = True AndAlso isHeld_APPS = False Then
                isHeld_APPS = True
                pressStartTime_APPS = DateTime.Now
            End If

            '[] IF APPS WAS RELEASED
            If isPressed_APPS = False AndAlso isHeld_APPS = True Then
                pressEndTime_APPS = DateTime.Now
                isHeld_APPS = False
                pressCount_APPS += 1
                totalPresses += 1
                pressTimeTotalConverted_APPS =
                    IntervalMath(pressStartTime_APPS, pressEndTime_APPS)
                pressTimeTotal_APPS += pressTimeTotalConverted_APPS
                totalPressTime += pressTimeTotalConverted_APPS
            End If

            '[] IF RCTRL IS PRESSED
            If isPressed_RCTRL = True AndAlso isHeld_RCTRL = False Then
                isHeld_RCTRL = True
                pressStartTime_RCTRL = DateTime.Now
            End If

            '[] IF RCTRL WAS RELEASED
            If isPressed_RCTRL = False AndAlso isHeld_RCTRL = True Then
                pressEndTime_RCTRL = DateTime.Now
                isHeld_RCTRL = False
                pressCount_RCTRL += 1
                totalPresses += 1
                pressTimeTotalConverted_RCTRL =
                    IntervalMath(pressStartTime_RCTRL, pressEndTime_RCTRL)
                pressTimeTotal_RCTRL += pressTimeTotalConverted_RCTRL
                totalPressTime += pressTimeTotalConverted_RCTRL
            End If

            '[] IF LT IS PRESSED
            If isPressed_LT = True AndAlso isHeld_LT = False Then
                isHeld_LT = True
                pressStartTime_LT = DateTime.Now
            End If

            '[] IF LT WAS RELEASED
            If isPressed_LT = False AndAlso isHeld_LT = True Then
                pressEndTime_LT = DateTime.Now
                isHeld_LT = False
                pressCount_LT += 1
                totalPresses += 1
                pressTimeTotalConverted_LT =
                    IntervalMath(pressStartTime_LT, pressEndTime_LT)
                pressTimeTotal_LT += pressTimeTotalConverted_LT
                totalPressTime += pressTimeTotalConverted_LT
            End If

            '[] IF DN IS PRESSED
            If isPressed_DN = True AndAlso isHeld_DN = False Then
                isHeld_DN = True
                pressStartTime_DN = DateTime.Now
            End If

            '[] IF DN WAS RELEASED
            If isPressed_DN = False AndAlso isHeld_DN = True Then
                pressEndTime_DN = DateTime.Now
                isHeld_DN = False
                pressCount_DN += 1
                totalPresses += 1
                pressTimeTotalConverted_DN =
                    IntervalMath(pressStartTime_DN, pressEndTime_DN)
                pressTimeTotal_DN += pressTimeTotalConverted_DN
                totalPressTime += pressTimeTotalConverted_DN
            End If

            '[] IF RT IS PRESSED
            If isPressed_RT = True AndAlso isHeld_RT = False Then
                isHeld_RT = True
                pressStartTime_RT = DateTime.Now
            End If

            '[] IF RT WAS RELEASED
            If isPressed_RT = False AndAlso isHeld_RT = True Then
                pressEndTime_RT = DateTime.Now
                isHeld_RT = False
                pressCount_RT += 1
                totalPresses += 1
                pressTimeTotalConverted_RT =
                    IntervalMath(pressStartTime_RT, pressEndTime_RT)
                pressTimeTotal_RT += pressTimeTotalConverted_RT
                totalPressTime += pressTimeTotalConverted_RT
            End If

            '[] IF Num0 IS PRESSED
            If isPressed_Num0 = True AndAlso isHeld_Num0 = False Then
                isHeld_Num0 = True
                pressStartTime_Num0 = DateTime.Now
            End If

            '[] IF Num0 WAS RELEASED
            If isPressed_Num0 = False AndAlso isHeld_Num0 = True Then
                pressEndTime_Num0 = DateTime.Now
                isHeld_Num0 = False
                pressCount_Num0 += 1
                totalPresses += 1
                pressTimeTotalConverted_Num0 =
                    IntervalMath(pressStartTime_Num0, pressEndTime_Num0)
                pressTimeTotal_Num0 += pressTimeTotalConverted_Num0
                totalPressTime += pressTimeTotalConverted_Num0
            End If

            '[] IF Decimal IS PRESSED
            If isPressed_Decimal = True AndAlso isHeld_Decimal = False Then
                isHeld_Decimal = True
                pressStartTime_Decimal = DateTime.Now
            End If

            '[] IF Decimal WAS RELEASED
            If isPressed_Decimal = False AndAlso isHeld_Decimal = True Then
                pressEndTime_Decimal = DateTime.Now
                isHeld_Decimal = False
                pressCount_Decimal += 1
                totalPresses += 1
                pressTimeTotalConverted_Decimal =
                    IntervalMath(pressStartTime_Decimal, pressEndTime_Decimal)
                pressTimeTotal_Decimal += pressTimeTotalConverted_Decimal
                totalPressTime += pressTimeTotalConverted_Decimal
            End If

            '[] IF LMB IS PRESSED
            If isPressed_LMB = True AndAlso isHeld_LMB = False Then
                isHeld_LMB = True
                pressStartTime_LMB = DateTime.Now
            End If

            '[] IF LMB WAS RELEASED
            If isPressed_LMB = False AndAlso isHeld_LMB = True Then
                pressEndTime_LMB = DateTime.Now
                isHeld_LMB = False
                pressCount_LMB += 1
                totalPresses += 1
                pressTimeTotalConverted_LMB =
                    IntervalMath(pressStartTime_LMB, pressEndTime_LMB)
                pressTimeTotal_LMB += pressTimeTotalConverted_LMB
                totalPressTime += pressTimeTotalConverted_LMB
            End If

            '[] IF MMB IS PRESSED
            If isPressed_MMB = True AndAlso isHeld_MMB = False Then
                isHeld_MMB = True
                pressStartTime_MMB = DateTime.Now
            End If

            '[] IF MMB WAS RELEASED
            If isPressed_MMB = False AndAlso isHeld_MMB = True Then
                pressEndTime_MMB = DateTime.Now
                isHeld_MMB = False
                pressCount_MMB += 1
                totalPresses += 1
                pressTimeTotalConverted_MMB =
                    IntervalMath(pressStartTime_MMB, pressEndTime_MMB)
                pressTimeTotal_MMB += pressTimeTotalConverted_MMB
                totalPressTime += pressTimeTotalConverted_MMB
            End If

            '[] IF RMB IS PRESSED
            If isPressed_RMB = True AndAlso isHeld_RMB = False Then
                isHeld_RMB = True
                pressStartTime_RMB = DateTime.Now
            End If

            '[] IF RMB WAS RELEASED
            If isPressed_RMB = False AndAlso isHeld_RMB = True Then
                pressEndTime_RMB = DateTime.Now
                isHeld_RMB = False
                pressCount_RMB += 1
                totalPresses += 1
                pressTimeTotalConverted_RMB =
                    IntervalMath(pressStartTime_RMB, pressEndTime_RMB)
                pressTimeTotal_RMB += pressTimeTotalConverted_RMB
                totalPressTime += pressTimeTotalConverted_RMB
            End If

        Loop

    End Sub

End Class