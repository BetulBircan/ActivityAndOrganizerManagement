using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrganizationActivityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        ActivitiesContext context = new ActivitiesContext();

        [HttpGet]
        public IActionResult GetActivities()
        {
            Activitiy activitynew = new Activitiy();


            var query = from a in context.Activitiys
                        join c in context.Categories on a.CategoryId equals c.CategoryId
                        join ci in context.Cities on a.CityId equals ci.CityId
                        join co in context.Companies on a.CompanyId equals co.CompanyId
                        select new
                        {
                            a.ActivityName,
                            a.ActivityDate,
                            a.ApplicationDeadline,
                            a.Description,
                            a.Quota,
                            c.CategoryName,
                            ci.CityName,
                            a.Isticked,
                            a.Company.CompanyName,
                        };

            return Ok(query);
        }
    }
}
