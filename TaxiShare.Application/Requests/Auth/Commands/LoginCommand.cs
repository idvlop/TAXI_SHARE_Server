using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using TaxiShare.Application.Models.Users;
using TaxiShare.Domain.Entities;
using TaxiShare.Infrastructure.Context;

namespace TaxiShare.Application.Requests.Auth.Commands
{
    public class LoginCommand : IRequest<GenericResponse<UserLoginVM>>
    {
        public LoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }


    public class LoginCommandHandler : IRequestHandler<LoginCommand, GenericResponse<UserLoginVM>>
    {
        private readonly TaxiShareDbContext context;
        //private readonly SignInManager<User> signInManager;

        public LoginCommandHandler(TaxiShareDbContext context) //SignInManager<User> signInManager)
        {
            this.context = context;
            //this.signInManager = signInManager;
        }

        public async Task<GenericResponse<UserLoginVM>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await context.Users
                .Where(x => x.Username == request.Username && x.PasswordHash == request.Password && x.InExistance)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(cancellationToken);

            if (user == null)
                return new GenericResponse<UserLoginVM>(false, 401);

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, request.Username),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(3)), // время действия 1 день
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            var responseBody = new UserLoginVM("Bearer " + new JwtSecurityTokenHandler().WriteToken(jwt));
            return new GenericResponse<UserLoginVM>(true, responseBody);
        }
    }
}
