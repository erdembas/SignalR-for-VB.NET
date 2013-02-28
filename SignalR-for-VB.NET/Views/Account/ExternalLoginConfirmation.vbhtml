@ModelType SignalR_for_VB.NET.RegisterExternalLoginModel
@Code
    ViewData("Title") = "Register"
End Code

<hgroup class="title">
    <h1>@ViewData("Title").</h1>
    <h2>Associate your @ViewData("ProviderDisplayName") account.</h2>
</hgroup>

@Using Html.BeginForm("ExternalLoginConfirmation", "Account", New With {.ReturnUrl = ViewData("ReturnUrl")})
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(true)

    @<fieldset>
        <legend>Association Form</legend>
        <p>
            You've successfully authenticated with <strong>@ViewData("ProviderDisplayName")</strong>.
            Please enter a user name for this site below and click the Confirm button to finish
            logging in.
        </p>
        <ol>
            <li class="name">
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </li>
        </ol>
        @Html.HiddenFor(Function(m) m.ExternalLoginData)
        <input type="submit" value="Register" />
    </fieldset>
End Using

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
