
using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrganizationActivityManager.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        ActivitiesContext context = new ActivitiesContext();

        [HttpGet]
        public IActionResult GetActivities()
        {


            var query = context.Activitiys.ToList();


            //var query = from a in context.Activitiys
            //            join c in context.Categories on a.CategoryId equals c.CategoryId
            //            join ci in context.Cities on a.CityId equals ci.CityId
            //            join co in context.Companies on a.CompanyId equals co.CompanyId
            //            select new
            //            {
            //                a.ActivityName,
            //                a.ActivityDate,
            //                a.ApplicationDeadline,
            //                a.Description,
            //                a.Quota,
            //                c.CategoryName,
            //                ci.CityName,
            //                a.Isticked,
            //                a.Company.CompanyName,
            //            };

            return Ok(query);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetActivitiesByCategory(byte categoryId)
        {
           

            var category = context.Activitiys.Where(x => x.CategoryId == categoryId).ToList();


            //var query = from a in context.Activitiys
            //            join c in context.Categories on a.CategoryId equals c.CategoryId
            //            join ci in context.Cities on a.CityId equals ci.CityId
            //            join co in context.Companies on a.CompanyId equals co.CompanyId
            //            select new
            //            {
            //                a.ActivityName,
            //                a.ActivityDate,
            //                a.ApplicationDeadline,
            //                a.Description,
            //                a.Quota,
            //                c.CategoryName,
            //                ci.CityName,
            //                a.Isticked,
            //                a.Company.CompanyName,
            //            };

            return Ok(category);
        }

        
        [HttpGet("~/{cityId}")]
        
        public IActionResult GetActivitiesByCity(int cityId)
        {


            var query = context.Activitiys.Where(x => x.CityId == cityId).ToList();


            //var query = from a in context.Activitiys
            //            join c in context.Categories on a.CategoryId equals c.CategoryId
            //            join ci in context.Cities on a.CityId equals ci.CityId
            //            join co in context.Companies on a.CompanyId equals co.CompanyId
            //            select new
            //            {
            //                a.ActivityName,
            //                a.ActivityDate,
            //                a.ApplicationDeadline,
            //                a.Description,
            //                a.Quota,
            //                c.CategoryName,
            //                ci.CityName,
            //                a.Isticked,
            //                a.Company.CompanyName,
            //            };

            return Ok(query);
        }

       
    }
}
