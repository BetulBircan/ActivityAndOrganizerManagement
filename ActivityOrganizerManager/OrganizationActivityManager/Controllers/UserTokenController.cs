﻿using Acitivity.ViewModels;
using Activities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        private readonly string[] args;

        [HttpPost]
        public IActionResult GetToken(UserTokenViewModel user)
        {
            var builder = WebApplication.CreateBuilder(args);

            if ((user.UserEmail == user.UserEmail) && (user.UserPassword == user.UserPassword) && user.RoleName == user.RoleName)
            {
                
                List<Claim> claims = new List<Claim>();
                //claims.Add(new Claim("username",user.Username));
                claims.Add(new Claim(ClaimTypes.Email, user.UserEmail));

               
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserEmail));
                claims.Add(new Claim(ClaimTypes.Role, "Katılımcı"));
                claims.Add(new Claim(ClaimTypes.Role, "Organizatör"));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
                SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: builder.Configuration["Jwt:Issuer"],
                    audience: builder.Configuration["Jwt:Audience"],
                    claims: claims,
                    signingCredentials: signingCredentials,
                    expires: DateTime.Now.AddMinutes(30)
                );

                string jwt = handler.WriteToken(token);
                return Ok(jwt);


              
                



                //JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                //SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
                //SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //JwtSecurityToken token = new JwtSecurityToken(
                //    issuer: builder.Configuration["Jwt:Issuer"],
                //    audience: builder.Configuration["Jwt:Audience"],
                //    claims: claims,
                //    signingCredentials: signingCredentials,
                //    expires: DateTime.Now.AddMinutes(30)
                //);

                //string jwt = handler.WriteToken(token);
                //return Ok(jwt);
            }
            return NotFound("Kullanıcı Bulunamadı");
        }
    }
}