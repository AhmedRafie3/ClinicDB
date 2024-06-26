using Application.Interfaces;
using Application.Repository.IBase;
using Clinic;
using Domain.DTO;
using Infrastructure.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Classes
{
    public class UserService(JwtOptions options, IUnitOfWork unitOfWork) : IUserService
    {
        public async Task<string> AuthenticateUser(AuthenticationRequest request)
        {
            var data = unitOfWork.Repository<TbUser>().FindByCondition(s => s.Email == request.UserName &&s.Password==request.Password).ToList();
            if (data.Count <= 0) return "";

            var tokenHandeler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = options.Issuer,
                Audience = options.Audance,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.SigningKey)),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, request.UserName),
                    new(ClaimTypes.Email, request.UserName)
                }),
                Expires = DateTime.UtcNow.AddHours(1) // Token expiry time
            };
            var securityToken = tokenHandeler.CreateToken(tokenDescriptor);
            var accesstoken = tokenHandeler.WriteToken(securityToken);
            return  accesstoken;
        }

        public async Task<bool> RegisterUser(RegisterationRequest request, CancellationToken cancellationToken)
        {
            var data = unitOfWork.Repository<TbUser>().FindByCondition(s => s.Email == request.Email || s.FullName == request.FullName).ToList();
            if (data.Count <= 0 ) return false;

            var user = new TbUser();
            user.UserTypeId = request.UserTypeId;
            user.ActivationStatus = request.ActivationStatus;
            user.DateCreated = Encoding.UTF8.GetBytes(request.DateCreated);
            user.Email = request.Email;
            user.EnableCrossEdit = request.EnableCrossEdit;
            user.FullName = request.FullName;
            user.ImageKey = request.ImageKey;
            user.Phone = request.Phone;
            user.Password = request.Password;

            unitOfWork.Repository<TbUser>().Create(user);
            var res = await unitOfWork.CompleteAsync(cancellationToken);
            return res == 1 ? true : false;
        }
    }
}
