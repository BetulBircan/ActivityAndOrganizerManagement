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

            Subscriber subscriber = new Subscriber();
            Organizer organizer = new Organizer();

            subscriber.UserEmail = user.UserEmail;
            subscriber.UserPassword = user.UserPassword;

           
            return BadRequest();

            
            
        }
    }
}
