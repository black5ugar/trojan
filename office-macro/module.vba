Declare PtrSafe Function CreateFile Lib "kernel32" Alias "CreateFileA" (ByVal lpFileName As String, ByVal dwDesiredAccess As Long, ByVal dwShareMode As Long, ByVal lpSecurityAttributes As Long, ByVal dwCreationDistribution As Long, ByVal dwFlagsAndAttributes As Long, ByVal hTemplate As Long) As Long

Declare PtrSafe Function CloseHandle Lib "kernel32" (ByVal hObject As Long) As Long

Declare PtrSafe Function ReadFile Lib "kernel32" (ByVal hFile As Long, lpBuffer As Byte, ByVal dwNumberOfBytesToRead As Long, lpNumberOfBytesRead As Long, ByVal lpOverlapped As Long) As Long

Declare PtrSafe Function WriteFile Lib "kernel32" (ByVal hFile As Long, lpBuffer As Byte, ByVal dwNumberOfBytesToWrite As Long, lpNumberOfBytesWritten As Long, ByVal lpOverlapped As Long) As Long

Declare PtrSafe Function SetFilePointer Lib "kernel32" (ByVal hFile As Long, ByVal lDistanceToMove As Long, ByVal lpDistanceToMoveHigh As Long, ByVal dwMoveMethod As Long) As Long

Public Const GENERIC_READ As Long = &H80000000

Public Const GENERIC_WRITE As Long = &H40000000

Public Const FILE_SHARE_READ As Long = 1

Public Const FILE_SHARE_WRITE As Long = 2

Public Const CREATE_NEW As Long = 1

Public Const CREATE_ALWAYS As Long = 2

Public Const OPEN_EXISTING As Long = 3

Public Const OPEN_ALWAYS As Long = 4

Public Const TRUNCATE_EXISTING As Long = 5

Public Const INVALID_HANDLE_value As Long = -1

Public Const FILE_ATTRIBUTE_NORMAL As Long = &H80
