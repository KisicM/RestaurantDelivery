using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.Text;
using Domain;
using DTO;
using Microsoft.AspNetCore.Http;
using Service;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILoginService _loginService;

        private readonly IConfiguration _configuration;

        public AuthenticateController(ILoginService loginService, IUserService userService, IConfiguration configuration)
        {
            _loginService = loginService;
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDTO model)
        {
            User user = _loginService.GetUsingCredentials(model.Username, model.Password);
            if (user == null) return Unauthorized();
            
            var authClaims = new List<Claim>
            {
                new (ClaimTypes.Name, user.Id.ToString()),
                new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new (ClaimTypes.Role, user.UserRole == UserRole.Customer ? "Customer" : user.UserRole == UserRole.Deliverer ? "Deliverer" : "Admin")
            };

            //var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("webapplication123"));

            var token = JwtHelper.GetJwtToken(
                userId: user.Id,
                issuer: "http://localhost:9429",
                audience: "http://localhost:9429",
                expiration: DateTime.Now.AddHours(3),
                additionalClaims: authClaims.ToArray(),
                signingKey: "webapplication123"
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
            
        }

    }
}
