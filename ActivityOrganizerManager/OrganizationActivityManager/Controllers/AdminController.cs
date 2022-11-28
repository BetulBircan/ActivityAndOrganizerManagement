using ActivitiesBusiness.Abstract;
using ActivitiesDataBase.Models;
using ActivitiesDataBase.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrganizationActivityManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdmin
    {

        private readonly Category _category;
        private readonly City _city;
        private ActivitiesContext _context;

        public AdminController()
        {
            _category = new Category();
            _city = new City();
            _context = new ActivitiesContext();
        }

        [HttpPost]
        [Route("categories")]
        public IActionResult Create(CategoryViewModel newCategory)
        {
            _category.CategoryName = newCategory.CategoryName.ToUpper();
            _context.Categories.Add(_category);
            _context.SaveChanges();
            return Ok(_category);
        }

        [HttpPost]
        [Route("cities")]
        public IActionResult Create(CityViewModel newCity)
        {
            _city.CityName = newCity.CityName.ToUpper();
            _context.Cities.Add(_city);
            _context.SaveChanges();
            return Ok(_city);

        }

        [HttpDelete("{categoryID}")]
        public IActionResult Delete(int categoryID)
        {
            Category category = _context.Categories.Find(categoryID);
            _context.Categories.Remove(category);
            _context.SaveChanges();

            //return NoContent();
            return Ok();
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdatePartial(byte categoryId, CategoryViewModel category)
        {
            Category originalCategory = _context.Categories.Find(categoryId);
            originalCategory.CategoryName = category.CategoryName.ToUpper();
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut("~/{cityId}")]

        public IActionResult UpdatePartial(int cityId, CityViewModel city)
        {
            City originalCity = _context.Cities.Find(cityId);
            originalCity.CityName = city.CityName;
            _context.SaveChanges();

            return Ok();
        }
    }
}
