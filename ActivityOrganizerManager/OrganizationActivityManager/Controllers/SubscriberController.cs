
using ActivitiesBusiness.Abstract;
using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrganizationActivityManager.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase, ISubscriber
    {
        private ActivitiesContext _context;
        private readonly Activitiy _activity;
        public SubscriberController()
        {
            _context = new ActivitiesContext();
            _activity = new Activitiy();
        }
        

        [HttpGet]
        public IActionResult GetActivities()
        {

            var query = _context.Activitiys.ToList();

            return Ok(query);
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetActivitiesByCategory(byte categoryId)
        {
           

            var category = _context.Activitiys.Where(x => x.CategoryId == categoryId).ToList();

            return Ok(category);
        }

        
        [HttpGet("~/{cityId}")]
        
        public IActionResult GetActivitiesByCity(int cityId)
        {

            var query = _context.Activitiys.Where(x => x.CityId == cityId).ToList();

            return Ok(query);
        }

        

       
    }
}
