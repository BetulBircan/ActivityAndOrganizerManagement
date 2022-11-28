using ActivitiesDataBase.Models;
using ActivitiesDataBase.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ActivitiesDataBase.ViewModels;
using ActivitiesBusiness.Abstract;

namespace OrganizationActivityManager.Controllers
{
    //[Authorize(Roles ="Organizatör")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizerController : ControllerBase, IOrganizer
    {
        private readonly ActivitiesContext _context;
        private readonly Activitiy _activity;
        public OrganizerController()
        {
            _context = new ActivitiesContext();
            _activity = new Activitiy();
        }

        [HttpGet]
        [Route("cities")]
        public IActionResult GetCities()
        {
            var cities = _context.Cities.ToList();

            return Ok(cities);


        }

        [HttpGet]
        [Route("categories")]
        public IActionResult GetCategories()
        {

            var categories = _context.Categories.ToList();

            return Ok(categories);
        }


        [HttpPost]
        public IActionResult Create(ActivityViewModel newActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                _activity.ActivityName = newActivity.ActivityName;
                _activity.CityId = newActivity.CityId;
                _activity.Address = newActivity.Address;
                _activity.ActivityDate = newActivity.ActivityDate;
                _activity.ApplicationDeadline = newActivity.ApplicationDeadline;
                _activity.Description = newActivity.Description;
                _activity.Isticked = newActivity.Isticked;
                _activity.Quota = newActivity.Quota;
                _activity.CategoryId = newActivity.CategoryId;
                if (_activity.Isticked == "Ücretli")
                {
                    _activity.Price = newActivity.Price;
                    _activity.CompanyId = newActivity.CompanyId;
                    _context.Activitiys.Add(_activity);
                }
                else

                    _activity.Price = 0;
                _activity.CompanyId = null;
                _context.Activitiys.Add(_activity);
            }



            //activitynew.Category.CategoryId = activity.Category.CategoryId;


            _context.Activitiys.Add(_activity);
            _context.SaveChanges();



            //return CreatedAtAction(nameof(GetActivityByID), new { id = activitynew.ActivityId }, activitynew);

            return Ok();
            //return StatusCode(500, "Ürün eklenemedi");
        }

        [HttpGet("~/{categoryId}")]
        public IActionResult GetCategoryID(byte categoryId)
        {

            var category = _context.Categories.SingleOrDefault(a => a.CategoryId == categoryId);
            if (category == null)
            {
                return NotFound();
                //return BadRequest();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCityID(int cityId)
        {
            //var cities = from c in _context.Cities select c.CityName;
            var city = _context.Cities.SingleOrDefault(a => a.CityId == cityId);
            if (city == null)
            {
                return NotFound();
                //return BadRequest();
            }
            else
            {
                return Ok(city);
            }

        }


        [HttpPut("~/{id}")]
        public IActionResult UpdatePartial(int id, ActivityViewModel activity)
        {
            Activitiy originalActivity = _context.Activitiys.Find(id);
        originalActivity.ActivityName = activity.ActivityName;
        originalActivity.CityId = activity.CityId;
        originalActivity.Address = activity.Address;
        originalActivity.ActivityDate = activity.ActivityDate;
        originalActivity.ApplicationDeadline = activity.ApplicationDeadline;
        originalActivity.Description = activity.Description;
        originalActivity.Isticked = activity.Isticked;
        originalActivity.Quota = activity.Quota;

        _context.SaveChanges();

        return Ok(originalActivity);

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Activitiy activitiy = _context.Activitiys.Find(id);
            _context.Activitiys.Remove(activitiy);
            if (activitiy == null)
            {

                return BadRequest();
            }
            else
            {
                _context.SaveChanges();

                return NoContent();

            }

            //return Ok();
        }
    }
}
