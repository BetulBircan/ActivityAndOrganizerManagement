using AcitivityOrganizerManager.ViewModels;
using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTokenController : ControllerBase
    {
        
        
        [HttpPost]
        public IActionResult GetToken(UserLoginViewModel user)
        {
            ActivitiesContext context = new ActivitiesContext();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            UserMailPassword userMailPassword = new UserMailPassword();
            userMailPassword.UserEmail = user.UserEmail;
            userMailPassword.UserPassWord = user.UserPassword;

            var query = context.Subscribers.Select(u => u.UserEmail);
            var query2 = context.Subscribers.Select(u => u.UserPassword);


            if ((query.Contains(userMailPassword.UserEmail) && (query2.Contains(userMailPassword.UserPassWord))))
            {
                
                List<Claim> claims = new List<Claim>();
                //claims.Add(new Claim("username",user.Username));
                claims.Add(new Claim(ClaimTypes.Email, user.UserEmail));

               
                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserEmail));
                claims.Add(new Claim(ClaimTypes.Role, "Katılımcı"));
                claims.Add(new Claim(ClaimTypes.Role, "Organizatör"));
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gaussgaussgaussgaussgaussgaussga"));
                SigningCredentials signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "www.gauss.com",
                    audience: "www.gauss.com",
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
