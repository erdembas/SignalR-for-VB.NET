Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Hubs

<HubName("userhub")>
Public Class UsersHub
    Inherits Hub

    Public Sub chatkatil(Nick As String)
        Clients.All.NickGonder(Nick + " - " + DateTime.Now)
    End Sub

End Class
