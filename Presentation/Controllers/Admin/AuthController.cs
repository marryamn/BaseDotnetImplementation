

using Application.Admin.Auth.Commands.Login;
using Application.Common.Response;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers.Admin;
[ApiExplorerSettings(GroupName = "V1 AdminSwagger")]

public class AuthController:ControllerExtension
{
    [HttpPost("admin/auth/signIn")]
    public async Task<ActionResult<StdResponse<LoginDto>>> SignIn(
        [FromForm] LoginCommand loginCommand)
    {
        return Base(await Mediator.Send(loginCommand));
    }
}