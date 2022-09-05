using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizationActivityManager.ViewModels;

namespace OrganizationActivityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase
    {
        ActivitiesContext context = new ActivitiesContext();

        [HttpGet]
        [Route("cities")]
        public IActionResult GetCities()
        {
            var cities = from c in context.Cities select c.CityName;

            return Ok(cities);


        }

        [HttpGet]
        [Route("categories")]
        public IActionResult GetCategories()
        {

            var categories = from c in context.Categories select c.CategoryName;


            return Ok(categories);
        }


        [HttpPost]
        public IActionResult Create(ActivityViewModel activity)
        {

            Activitiy activitynew = new Activitiy();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                activitynew.ActivityName = activity.ActivityName;
                activitynew.CityId = activity.CityId;
                activitynew.Address = activity.Address;
                activitynew.ActivityDate = activity.ActivityDate;
                activitynew.ApplicationDeadline = activity.ApplicationDeadline;
                activitynew.Description = activity.Description;
                activitynew.Isticked = activity.Isticked;
                activitynew.Quota = activity.Quota;
                activitynew.CategoryId = activity.CategoryId;
                if (activitynew.Isticked == "Ücretli")
                {
                    activitynew.Price = activity.Price;
                    activitynew.CompanyId = activity.CompanyId;
                    context.Activitiys.Add(activitynew);
                }
                else
                {
                    activitynew.Price = null;
                    activitynew.CompanyId = null;
                    context.Activitiys.Add(activitynew);
                }


                //activitynew.Category.CategoryId = activity.Category.CategoryId;


                context.Activitiys.Add(activitynew);
                context.SaveChanges();



                //return CreatedAtAction(nameof(GetActivityByID), new { id = activitynew.ActivityId }, activitynew);

                return Ok();
                //return StatusCode(500, "Ürün eklenemedi");
            }

        }

        [HttpPut("{id}")]
        public IActionResult UpdatePartial(int id, ActivityViewModel activity)
        {
            ActivitiesContext context = new ActivitiesContext();
            Activitiy originalActivity = context.Activitiys.Find(id);
            originalActivity.ActivityName = activity.ActivityName;
            originalActivity.CityId = activity.CityId;
            originalActivity.Address = activity.Address;
            originalActivity.ActivityDate = activity.ActivityDate;
            originalActivity.ApplicationDeadline = activity.ApplicationDeadline;
            originalActivity.Description = activity.Description;
            originalActivity.Isticked = activity.Isticked;
            originalActivity.Quota = activity.Quota;

            context.SaveChanges();



            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ActivitiesContext context = new ActivitiesContext();
            Activitiy activitiy = context.Activitiys.Find(id);
            context.Activitiys.Remove(activitiy);
            if (activitiy == null)
            {

                return BadRequest();
            }
            else
            {
                context.SaveChanges();

                return NoContent();

            }

            //return Ok();
        }
    }
}
