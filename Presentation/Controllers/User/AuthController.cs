using Application.Common.Response;
using Application.User.Auth.Login;
using Microsoft.AspNetCore.Mvc;
using Presentation.Common;

namespace Presentation.Controllers.User;
[ApiExplorerSettings(GroupName = "V1 UserSwagger")]

public class AuthController:ControllerExtension
{
    [HttpPost("client/auth/signIn")]
    public async Task<ActionResult<StdResponse<LoginDto>>> SignIn(
        [FromForm] LoginCommand loginCommand)
    {
        return Base(await Mediator.Send(loginCommand));
    }
}