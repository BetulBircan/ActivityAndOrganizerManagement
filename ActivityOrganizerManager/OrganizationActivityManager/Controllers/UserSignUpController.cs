using Acitivities.ViewModels;
using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace OrganizationActivityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSignUpController : ControllerBase
    {
        ActivitiesContext context = new ActivitiesContext();

        [HttpGet]
        public IActionResult GetUserRole()
        {
            var query = from role in context.UserRoles
                        select role.RoleName;

            return Ok(query);
        }

        [HttpPost]
        public IActionResult Create(UserSignUpViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


           User newUser = new User();
            //newUser. = user.UserName;
            //newUser.UserSurname = user.UserSurname;
            //newUser.UserEmail = user.UserEmail;
            //newUser.UserPassword = user.UserPassword;
            //newUser.UserPasswordAgain = user.UserPasswordAgain;
            //newUser.RoleId = user.RoleId;
            //if (newUser.RoleId == 1)
            //{
            //    context.Users.Add(newUser);


            //}
            //User newOrganizer = new Organizer();
            //newOrganizer.UserName = user.UserName;
            //newOrganizer.UserSurname = user.UserSurname;
            //newOrganizer.UserEmail = user.UserEmail;
            //newOrganizer.UserPassword = user.UserPassword;
            //newOrganizer.UserPasswordAgain = user.UserPasswordAgain;
            //newOrganizer.RoleId = user.RoleId;
            //if (newOrganizer.RoleId == 2)
            //{
            //    context.Users.Add(newOrganizer);
            //}

            context.SaveChanges();
            return Ok();
        }
    }
}
