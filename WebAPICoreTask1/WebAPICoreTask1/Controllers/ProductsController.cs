using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask1.Models;

namespace WebAPICoreTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly MyDbContext _db;

        public ProductsController(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProducts()
        {


            var allProducts = _db.Products.ToList();

            return Ok(allProducts);

        }


        [HttpGet("GetOneProduct/{id:int}")]

        public IActionResult GetOneProduct(int id)
        {
            if (id <= 0)
            {

                return BadRequest("Plz enter an ID greater than 0");

            }


            var product = _db.Products.Find(id);

            if (product == null)
            {

                return NotFound($"Product with Id {id} not Found");

            }

            return Ok(product);

        }


        [HttpGet("GetProductByName")]

        public IActionResult GetProductByName([FromQuery] string name)
        {


            if (string.IsNullOrEmpty(name))
            {

                return BadRequest("Plz enter a valid name");

            }


            var product = _db.Products.Where(p => p.ProductName == name).FirstOrDefault();

            if (product == null)
            {


                return NotFound($"Product with Name: {name} not found");
            }

            return Ok(product);
        }




        [HttpDelete("DeleteProductByID")]

        public IActionResult DeleteProduct(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Plz enter a valid id");
            }

            var product = _db.Products.Find(id);

            if (product == null)
            {

                return NotFound($"Product with ID: {id} not found");

            }

            _db.Products.Remove(product);
            _db.SaveChanges();

            return Ok("Product Deleted");

        }

    }
}
