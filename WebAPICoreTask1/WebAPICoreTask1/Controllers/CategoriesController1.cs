using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask1.Models;

namespace WebAPICoreTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController1 : ControllerBase
    {

        private readonly MyDbContext _db;


        public CategoriesController1(MyDbContext db)
        {
            _db = db;
        }

        [Route("GettingAllCat")]
        [HttpGet]
        public IActionResult GetAllCat()
        {
            var allCat = _db.Categories.ToList();


            return Ok(allCat);
        }

        [HttpGet]
        [Route("GetCatByID/{id:int}")]
        public IActionResult GetCatByID(int? id)
        {

            var cat = _db.Categories.Where(c => c.CategoryId == id).FirstOrDefault();

            return Ok(cat);
        }



        [HttpGet]
        [Route("GetCatByName/{name}")]
        public IActionResult GetCatByName(string name)
        {

            var cat = _db.Categories.Where(c => c.CategoryName == name).FirstOrDefault();

            return Ok(cat);
        }


        [HttpDelete]
        [Route("DeleteCatByID/{id}")]
        public IActionResult DeleteCatByID(int id)
        {
            // Retrieve the category by ID
            var cat = _db.Categories.Where(c => c.CategoryId == id).FirstOrDefault();

            if (cat == null)
            {
                return NotFound($"Category with ID {id} does not exist.");
            }

            // Retrieve all products associated with this category
            var products = _db.Products.Where(p => p.CategoryId == id).ToList();

            if (products.Any())
            {
                // Remove all products associated with this category
                _db.Products.RemoveRange(products);
            }

            // Now remove the category
            _db.Categories.Remove(cat);
            _db.SaveChanges();

            return Ok(cat);
        }


    }
}
