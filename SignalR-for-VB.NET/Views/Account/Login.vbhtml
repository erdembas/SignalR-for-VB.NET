@ModelType SignalR_for_VB.NET.LoginModel

@Code
    ViewData("Title") = "Log in"
End Code

<hgroup class="title">
    <h1>@ViewData("Title").</h1>
</hgroup>

<section id="loginForm">
<h2>Use a local account to log in.</h2>
@Using Html.BeginForm(New With { .ReturnUrl = ViewData("ReturnUrl") })
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(true)

    @<fieldset>
        <legend>Log in Form</legend>
        <ol>
            <li>
                @Html.LabelFor(Function(m) m.UserName)
                @Html.TextBoxFor(Function(m) m.UserName)
                @Html.ValidationMessageFor(Function(m) m.UserName)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.Password)
                @Html.PasswordFor(Function(m) m.Password)
                @Html.ValidationMessageFor(Function(m) m.Password)
            </li>
            <li>
                @Html.CheckBoxFor(Function(m) m.RememberMe)
                @Html.LabelFor(Function(m) m.RememberMe, New With { .Class = "checkbox" })
            </li>
        </ol>
        <input type="submit" value="Log in" />
    </fieldset>
    @<p>
        @Html.ActionLink("Register", "Register") if you don't have an account.
    </p>
End Using
</section>

<section class="social" id="socialLoginForm">
    <h2>Use another service to log in.</h2>
    @Html.Action("ExternalLoginsList", New With {.ReturnUrl = ViewData("ReturnUrl")})
</section>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
