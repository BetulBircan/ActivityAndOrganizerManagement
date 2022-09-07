using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganizationActivityManager.ViewModels;

namespace OrganizationActivityManager.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ActivitiesContext context = new ActivitiesContext();

        //[Authorize(Roles = "Organizatör")]
        [HttpPost]
        public IActionResult Create(CityViewModel city)
        {

            City newCity = new City();
            newCity.CityName = city.CityName.ToUpper();
            context.Cities.Add(newCity);
            context.SaveChanges();

            //return CreatedAtAction(nameof(GetCities), new { id = newCity.CityId }, newCity);

            return Ok(newCity);
            //return StatusCode(500, "Ürün eklenemedi");
        }

        [HttpPut("{id}")] // idempotent
        public IActionResult UpdatePartial(int id, CityViewModel city)
        {
            City originalCity = context.Cities.Find(id);
            originalCity.CityName = city.CityName.ToUpper();
            context.SaveChanges();

            return Ok(originalCity);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            City city = context.Cities.Find(id);
            context.Cities.Remove(city);
            context.SaveChanges();

            return NoContent();
            //return Ok();
        }

        
    }
}
