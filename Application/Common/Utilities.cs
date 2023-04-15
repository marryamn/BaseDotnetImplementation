using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;

namespace Application.Common;

public static class Utilities
{
    public static bool IsNullOrEmpty(this string value) => string.IsNullOrEmpty(value);

    public static bool IsNullOrEmpty(this StringValues value) => StringValues.IsNullOrEmpty(value);
    
    public static  string GenerateToken(IDictionary<string, string> claimDictionary, DateTime expireDate,IConfiguration _config)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = claimDictionary
            .Select(x => new Claim(x.Key, x.Value))
            .ToArray();
        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

           
        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}