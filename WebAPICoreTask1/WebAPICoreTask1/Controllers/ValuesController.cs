using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPICoreTask1.Models;

namespace WebAPICoreTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly MyDbContext _db;

        public ValuesController(MyDbContext db)
        {
            _db = db;
        }

        //[HttpPost]
        //public IActionResult GetAllCategories()
        //{
        //    var AllCat = _db.Categories.ToList();

        //    return Ok(AllCat);

        //}

        //[HttpPost("{id}")]
        //public IActionResult GetOneCategory(int? id)
        //{
        //    var OneCat = _db.Categories.Where(c => c.CategoryId == id).FirstOrDefault();

        //    return Ok(OneCat);

        //}


        //[HttpPost("{CategoryId}")]
        [HttpGet]

        public IActionResult GetAllProducts()
        {
            var AllProducts = _db.Products.Include(p => p.Category).ToList();

            return Ok(AllProducts);

        }


        //[HttpPost("{ProductId}")]
        //[HttpPost]
        //public IActionResult GetOneProducts(int? id)
        //{
        //    var OneProducts = _db.Products.Where(p => p.ProductId == id).FirstOrDefault();

        //    return Ok(OneProducts);

        //}

    }
}

