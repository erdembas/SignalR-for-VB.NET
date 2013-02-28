@ModelType ICollection(Of AuthenticationClientData)

@If Model.Count = 0 Then
    @<div class="message-info">
        <p>There are no external authentication services configured. See <a href="http://go.microsoft.com/fwlink/?LinkId=252166">this article</a>
        for details on setting up this ASP.NET application to support logging in via external services.</p>
    </div>
Else
    Using Html.BeginForm("ExternalLogin", "Account", New With { .ReturnUrl = ViewData("ReturnUrl") })
    @Html.AntiForgeryToken()
    @<fieldset id="socialLoginList">
        <legend>Log in using another service</legend>
        <p>
        @For Each p as AuthenticationClientData in Model
            @<button type="submit" name="provider" value="@p.AuthenticationClient.ProviderName" title="Log in using your @p.DisplayName account">@p.DisplayName</button>
        Next
        </p>
    </fieldset>
    End Using
End If
