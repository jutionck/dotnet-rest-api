using System.IdentityModel.Tokens.Jwt;
using System.Text;
using dotnet_rest_api.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace dotnet_rest_api.Controllers;
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [AllowAnonymous]
    [HttpPost]
    public IActionResult Login([FromBody] UserModel payload)
    {
        IActionResult response = Unauthorized();
        var user = AuthenticateUser(payload);
        var tokenString = GenerateJsonWebToken(user);
        return Ok(new { token = tokenString });;
    }
    
    private string GenerateJsonWebToken(UserModel user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Issuer"],
            null,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    private UserModel AuthenticateUser(UserModel payload)
    {
        if (payload.Username == "enigma")
        {
            return new UserModel { Username = "enigma", Email = "admin@gmail.com" };
        }

        return new UserModel();
    }
}