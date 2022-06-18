using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using DTO;
using HospitalAPI.JWT;
using Service;

namespace WebApplication.JWT
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
    {

        private readonly IConfiguration _configuration;

        private readonly IServiceProvider _serviceProvider;

      

        public RoleAuthorizationHandler(IHttpContextAccessor httpContextAccessor, IConfiguration configuration, IServiceProvider serviceProvider, ILoginService loginService, IUserService userService)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
           
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            using var scope1 = _serviceProvider.CreateScope();
            var _httpContextAccessor = scope1.ServiceProvider.GetRequiredService<IHttpContextAccessor>();

            if (_httpContextAccessor.HttpContext != null)
            {
                var authHeader = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization];
                if (authHeader.Count == 0)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }
                string accessToken = authHeader[0].Replace("Bearer ", "");
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidAudience = _configuration["JwtToken:Audience"],
                    ValidIssuer = _configuration["JwtToken:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:SigningKey"])),
                };

                SecurityToken validToken = null;
                try
                {
                    var principal = handler.ValidateToken(accessToken, validationParameters, out validToken);

                }
                catch (Exception)
                {

                    context.Fail();
                    return Task.CompletedTask;
                }

                var userToken = handler.ReadJwtToken(accessToken);

                var claims = userToken.Claims.ToList();

                using var scope = _serviceProvider.CreateScope();
                var _userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                var _loginService = scope.ServiceProvider.GetRequiredService<ILoginService>();

                User user = _userService.GetUser(int.Parse(claims[0].Value));
                if (user == null) context.Fail();

                User loggedIn = _loginService.GetUsingCredentials(user.Username, user.Password);
                if (loggedIn != null && loggedIn.UserRole.ToString().Equals(claims[2].Value)) context.Succeed(requirement);
                else context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}
