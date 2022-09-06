using AcitivityOrganizerManager.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActivitiesDataBase.Models;

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
           
            var subscribermail = context.Subscribers.Select(u => u.UserEmail);
            var subscriberpassword = context.Subscribers.Select(u => u.UserPassword);

            var organizermail = context.Organizers.Where(u => u.RoleId == 2).Select(u => u.UserEmail).ToList();
            var organizerpassword = context.Organizers.Where(u => u.RoleId == 2).Select(u => u.UserPassword).ToList();
            
            

            if (subscribermail.Equals(login.UserEmail) && subscriberpassword.Equals(login.UserPassWord) || (organizermail.Equals(login.UserEmail) && organizerpassword.Equals(login.UserPassWord)))
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
