@Code
    ViewData("Title") = "Home Page"
End Code

@section featured
    <section class="featured">
    </section>
End Section

<script src="~/Scripts/jquery-1.7.1.min.js"></script>
<script src="~/Scripts/jquery.signalR-1.0.0.js"></script>
<script src="~/signalr/hubs"></script>

<link href="~/Content/bootstrap/css/bootstrap.css" rel="stylesheet" />
<script src="~/Content/bootstrap/js/bootstrap.min.js"></script>


<div id="MesajYaz" style="margin-top: 10px">
    <span>Nick</span><br />
    <input id="Nick" type="text" />

    <br />
    <span>Mesajınız</span><br />
    <textarea id="Mesaj"></textarea>

    <br />
    <input type="button" class="btn btn-large btn-primary" id="Gonder" value="Gönder" />
</div>

<div>
    <h5>Gelen mesajlar</h5>
    <hr />
    <ul class="round" id="MesajList">
    </ul>
</div>


<script>
    $(document).ready(function () {

        var chatHub = $.connection.chathub;
        chatHub.client.gonder = function (nick, mesaj) {
            $("#MesajList").append('<li><strong>' + nick + '</strong> :&nbsp;&nbsp;' + mesaj + '</li>');
        }

        $.connection.hub.start().done(function () {

            $("#Gonder").click(function () {
                chatHub.server.mesajgonder($("#Nick").val(), $("#Mesaj").val());
            });
            $('return false;');
        })

    });
</script>
