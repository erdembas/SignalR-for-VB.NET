@ModelType SignalR_for_VB.NET.LocalPasswordModel

<p>
    You do not have a local password for this site. Add a local
    password so you can log in without an external login.
</p>

@Using Html.BeginForm("Manage", "Account")
    @Html.AntiForgeryToken()
    @Html.ValidationSummary()

    @<fieldset>
        <legend>Set Password Form</legend>
        <ol>
            <li>
                @Html.LabelFor(Function(m) m.NewPassword)
                @Html.PasswordFor(Function(m) m.NewPassword)
            </li>
            <li>
                @Html.LabelFor(Function(m) m.ConfirmPassword)
                @Html.PasswordFor(Function(m) m.ConfirmPassword)
            </li>
        </ol>
        <input type="submit" value="Set password" />
    </fieldset>
End Using
