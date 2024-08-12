using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Backend.Class.Records;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/[controller]/[action]")]
public class LoginController(IConfiguration config) : ControllerBase
{
    public IConfiguration _config = config;

    [NonAction]
    private string GenerateJWTToken(LoginData user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]!));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

        var jwtToken = new JwtSecurityToken(
            _config["JWT:Issuer"],
            _config["JWT:Issuer"],
            claims,
            expires: DateTime.Now.AddMonths(1),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }

    [HttpPost]
    public IActionResult Authorize([FromBody] LoginData user)
    {
        LoginObject? returnObject;
        if (user.Username != "login" && user.Password != "login")
        {
            returnObject = new LoginObject(false, null, "Bad Login");
        }
        else
        {
            returnObject = new LoginObject(true, GenerateJWTToken(user), "Success");
        }

        return new OkObjectResult(returnObject);
    }
}
public class LoginObject(bool success, string? token, string? message)
{
    public bool Success { get; set; } = success;
    public string? Token { get; set; } = token;
    public string? Message { get; set; } = message;
}
