Module Module1
    ' подключаем dll для перехвата нажатий мыши вне текущего окна
    Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Short
    Declare Sub keybd_event Lib "User32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As UInteger, ByVal dwExtraInfo As UInteger)
    Private Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, _
       ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, _
       ByVal dwExtraInfo As Integer)


    Const KEYEVENTF_KEYDOWN As Integer = &H1
    Const KEYEVENTF_KEYUP As Integer = &H2
    ' при нажатии левой кнопки мыши GetAsyncKeyState(1)
    ' начинаем нажимать центральную кнопку мыши mouse_event(&H20, 0, 0, 0, 0)
    ' со случаной задержкой от 100 до 110 милисеккунд sleep = Int((110 - 100 + 1) * Rnd() + 100)
    Sub Main()
        Dim sleep = 100
        Dim I = 0
        Dim clicks = False
        While I < 1000 ' бесконечный цикл
            'I = I + 1

            If GetAsyncKeyState(1) And Not clicks Then ' если нажато левая кнопка мыши GetAsyncKeyState(1) - левая
                clicks = True

            End If

            If clicks Then  'выполняем клики с задержкой
                clicks = True
                mouse_event(&H20, 0, 0, 0, 0)
                mouse_event(&H40, 0, 0, 0, 0)
                sleep = Int((110 - 100 + 1) * Rnd() + 100)
                Threading.Thread.Sleep(sleep)
                'Console.WriteLine("Консоль остановлена " & sleep)
                clicks = False
            End If




            Threading.Thread.Sleep(30)
        End While



    End Sub

    ' добавить цикл на нажатие
    'Console.WriteLine("нажато")
    'keybd_event(86, 0, KEYEVENTF_KEYUP, 0)
    'Threading.Thread.Sleep(200)
    'keybd_event(86, 0, KEYEVENTF_KEYDOWN, 0)


End Module
