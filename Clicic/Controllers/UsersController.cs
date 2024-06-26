using Application.Interfaces;
using Application.Repository.IBase;
using Azure.Core;
using Domain.DTO;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        [Route("Auth")]
        public ActionResult<string> AuthenticateUser(AuthenticationRequest request)
        {
            return Ok(userService.AuthenticateUser(request));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<bool> RegisterUser(RegisterationRequest request, CancellationToken cancellationToken)
        {
           return await userService.RegisterUser(request, cancellationToken);
        }
    }
}
