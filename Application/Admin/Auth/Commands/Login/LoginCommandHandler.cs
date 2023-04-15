using System.Security.Claims;
using Application.Common;
using Application.Common.Response;
using Application.Common.Validations;
using Microsoft.AspNetCore.Http;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Application.Admin.Auth.Commands.Login
{
    public class LoginCommandHandler : AbstractRequestHandler<LoginCommand, StdResponse<LoginDto>>
    {
        private readonly IConfiguration _config;
        public LoginCommandHandler(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor,IConfiguration config)
            : base(dbContext, httpContextAccessor)
        {
            _config = config;
        }

        public override async Task<StdResponse<LoginDto>> Handle(LoginCommand request, CancellationToken _)
        {
            var validationResult = await new LoginCommandValidator(DbContext).StdValidateAsync(request, _);
            if (validationResult.Failed()) {
                return BadRequest<LoginDto>(validationResult.Messages());
            }
        
            var admin = await DbContext.Admins
                .FirstOrDefaultAsync(x => x.Email == request.Email, _);
            if (admin == null)
            {
                return NotFound<LoginDto>();
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, admin.Password))
            {
                return BadRequest<LoginDto>("اطلاعات وارد شده صحیح نمی باشد.");
            }

            var clames = new Dictionary<string, string>()
            {
                { "id", admin.Id.ToString() },
                { JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() },
                { ClaimTypes.Role, "Admin" },
                { "phone", admin.Phone }
            };
            var expireDate = DateTime.Now.AddMinutes(15);

            string tokent = Utilities.GenerateToken(clames,expireDate, _config);
            var token = new LoginDto()
            {
                AccessToken = "Bearer " + tokent,
                ExpireDate = DateTime.Now.AddMinutes(15)
            };
            
            return Ok(token);
        }
    }
}