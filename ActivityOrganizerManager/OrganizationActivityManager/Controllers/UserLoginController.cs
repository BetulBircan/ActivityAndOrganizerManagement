
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActivitiesDataBase.Models;
using ActivitiesDataBase.ViewModels;

namespace Acitivity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {

        ActivitiesContext context = new ActivitiesContext();
        
        [HttpPost]
        public IActionResult Create(UserLoginViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserMailPassword login = new UserMailPassword();
            login.UserEmail = user.UserEmail;
            login.UserPassWord = user.UserPassword;
           
            var subscribermail = context.Users.Select(u => u.UserEmail);
            var subscriberpassword = context.Users.Select(u => u.UserPassword);

            var organizermail = context.Users.Select(u => u.UserEmail);
            //var organizerpassword = contextUsers.Select(u => u.UserPassword);
            
            

            if (subscribermail.Equals(login.UserEmail) && subscriberpassword.Equals(login.UserPassWord) || (organizermail.Equals(login.UserEmail)))
            {
                context.UserMailPasswords.Add(login);
            }
              
            else
            {
                return NotFound("Kullanıcı Bulunamadı");
            }





            context.SaveChanges();
            return Ok();






        }
    }
}
