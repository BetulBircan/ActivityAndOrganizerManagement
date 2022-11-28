
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActivitiesDataBase.Models;
using Microsoft.AspNetCore.Authorization;
using ActivitiesDataBase.ViewModels;

namespace AcitivityOrganizerManager.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class CategoryController : ControllerBase
    {

        ActivitiesContext context = new ActivitiesContext();

        [NonAction]
        [HttpGet("{id}")]
        //[Route("api/[controller]/{id}")]
        public IActionResult GetCategoryID(int id)
        {
            Category category = context.Categories.SingleOrDefault(a => a.CategoryId == id);
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

        [HttpPost] 
        public IActionResult Create(CategoryViewModel category)
        {
           
            Category newCategory = new Category();
            newCategory.CategoryName = category.CategoryName.ToUpper();
            context.Categories.Add(newCategory);
            context.SaveChanges();

            //return CreatedAtAction(nameof(GetProductByID), new { id = newProduct.ProductId }, newProduct);

            return Ok(newCategory);
            //return StatusCode(500, "Ürün eklenemedi");
        }

        [HttpPut("{id}")] 
        public IActionResult UpdatePartial(byte id, CategoryViewModel category)
        {
            Category originalCategory = context.Categories.Find(id);
            originalCategory.CategoryName = category.CategoryName.ToUpper();
            context.SaveChanges();

            return Ok(originalCategory);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(byte id)
        {
            ActivitiesContext context = new ActivitiesContext();
            Category category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();

            return NoContent();
           
        }

        


    }
}
