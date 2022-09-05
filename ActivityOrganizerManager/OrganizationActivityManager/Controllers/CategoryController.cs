using Microsoft.EntityFrameworkCore;
using Activities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Activities.Models;
using Acitivity.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Acitivity.Controllers { 

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

            return Ok();
        }

        [HttpDelete("{categoryID}")]
        public IActionResult Delete(int categoryID)
        {
            ActivitiesContext context = new ActivitiesContext();
            Category category = context.Categories.Find(categoryID);
            context.Categories.Remove(category);
            context.SaveChanges();

            //return NoContent();
            return Ok();
        }

        


    }
}
