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
<div style="width: 500px; float: left">
    <div id="NickAl">
        <span>Nick</span><br />
        <input id="KisiNick" type="text" />
        <br />
        <input type="button" class="btn btn-large btn-primary" id="Katil" value="Chate Başla!" />
    </div>

    <div id="Mesajlasma" style="display: none">
        <div id="MesajYaz" style="margin-top: 10px">
            <span>Nick</span><br />
            <input id="Nick" type="text" disabled="disabled" />
            <br />
            <span>Mesajınız</span><br />
            <textarea id="Mesaj"></textarea>

            <br />
            <input type="button" class="btn btn-large btn-primary" id="Gonder" value="Gönder" />
        </div>

        <div style="margin-top:20px">
            <h5>Gelen mesajlar</h5>
            <hr style="margin-top:-10px" />
            <ul class="round" id="MesajList">
            </ul>
        </div>
    </div>
</div>

<div style="float: right; display:none" id="Kisiler">
    <h4>Yeni Katılanlar</h4>
    <div style="width:200px; border:1px solid; border-radius:10px; padding-top:10px">
        <ul id="KisiList">
        </ul>
    </div>
</div>

 

<script>
    $(document).ready(function () {
        var katilHub = $.connection.userhub;
        katilHub.client.NickGonder = function (nick) {
            $("#KisiList").append('<li><strong>' + nick + '</strong></li>')
            $("#Kisiler").fadeIn();
        }

        var chatHub = $.connection.chathub;
        chatHub.client.gonder = function (nick, mesaj) {
            $("#MesajList").append('<li><strong>' + nick + '</strong> :&nbsp;&nbsp;' + mesaj + '</li>');
        }

        $.connection.hub.start().done(function () {
            $("#Katil").click(function () {
                $("#Nick").val($("#KisiNick").val());
                $("#NickAl").hide();
                $("#Mesajlasma").fadeIn();
                katilHub.server.chatkatil($("#KisiNick").val());
            })

            $("#Gonder").click(function () {
                chatHub.server.mesajgonder($("#Nick").val(), $("#Mesaj").val());
            });
            $('return false;');
        });
    });
</script>
