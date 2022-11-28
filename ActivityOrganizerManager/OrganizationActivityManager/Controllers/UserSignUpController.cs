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
        private ActivitiesContext _context;
        private User _user;
        private UserDetail _userDetail;

        public UserSignUpController()
        {
            _context = new ActivitiesContext();
            _user = new User();
            _userDetail = new UserDetail();
        }
        

        [HttpGet]
        public IActionResult GetUserRole()
        {
            var query = from role in _context.UserRoles
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
            _user.UserEmail = user.UserEmail;
            _user.UserPassword = user.UserPassword;
            //user.RoleId = users.RoleId;
            _context.Add(_user);
            _context.SaveChanges();
            return Ok(_user);
            _userDetail.PasswordAgain = user.UserPasswordAgain;
            _userDetail.UserName = user.UserName;
            _userDetail.UserSurname = user.UserSurname;
            _userDetail.UserId = user.UserId;
            _userDetail.RoleId = user.RoleId;
            _context.UserDetails.Add(_userDetail);
            _context.SaveChanges();
            return Ok(_userDetail);

        }
    }
}
