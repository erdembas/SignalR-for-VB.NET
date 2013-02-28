Imports Microsoft.AspNet.SignalR.Hubs
Imports Microsoft.AspNet.SignalR


<HubName("chathub")>
Public Class ChatHub
    Inherits Hub

    Public Sub mesajgonder(Nick As String, Mesaj As String)
        Clients.All.Gonder(Nick, Mesaj + " - " + DateTime.Now)
    End Sub
End Class
