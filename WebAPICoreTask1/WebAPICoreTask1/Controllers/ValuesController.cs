using Microsoft.AspNetCore.Mvc;
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

        //[HttpGet]
        //public IActionResult GetAllCategories()
        //{
        //    var AllCat = _db.Categories.ToList();

        //    return Ok(AllCat);

        //}

        //[HttpGet("{id}")]
        //public IActionResult GetOneCategory(int? id)
        //{
        //    var OneCat = _db.Categories.Where(c => c.CategoryId == id).FirstOrDefault();

        //    return Ok(OneCat);

        //}


        //[HttpGet("{CategoryId}")]


        //public IActionResult GetAllProducts(int CategoryId)
        //{
        //    var AllProducts = _db.Products.Include(p => p.Category).Where(p => p.CategoryId == CategoryId).ToList();

        //    return Ok(AllProducts);

        //}


        //[HttpGet("{Id}")]

        //public IActionResult GetOneProduct(int? Id)
        //{
        //    var OneProducts = _db.Products.Where(p => p.ProductId == Id).FirstOrDefault();

        //    return Ok(OneProducts);

        //}



        //[HttpGet("products/{Categotyid}/{price}")]

        //public IActionResult GetOneProducts(int Categotyid, decimal price)
        //{
        //    var allprocuts = _db.Products.Where(p => p.CategoryId == Categotyid && Convert.ToDecimal(p.Price) > price).Count();

        //    return Ok(allprocuts);

        //}




        //////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////
        ///////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////
        /////////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////
        ///////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////
        /////////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////
        ///////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////
        /////////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////
        ///////////////////////////////////////// NEW DAY 21/8/2024 ///////////////////////////////////////////


        //[HttpGet("api/products/{productid}")]
        //public IActionResult GetProductById(int productid)
        //{
        //    var product = _db.Products.Find(productid);

        //    if (product == null)
        //    {

        //        return NotFound();
        //    }

        //    return Ok(product);

        //}


        //[HttpGet("api/products")]
        //public IActionResult GetProductsByCatAndPrice(int catid, int price)
        //{

        //    var products = _db.Products.Where(p => p.CategoryId == catid && Convert.ToDecimal(p.Price) >= price);

        //    if (!products.Any())
        //    {

        //        return NotFound();
        //    }

        //    return Ok(products);


        //}
        // [HttpGet("api/products/{id}")]
        //[HttpGet("api/products/byname/{name}")]
        //public IActionResult GetProductByNameORById(int id = 0, string name = null)
        //{

        //    Product product;
        //    if (id > 0)
        //    {
        //        product = _db.Products.Find(id);

        //    }
        //    else if (!string.IsNullOrEmpty(name))
        //    {

        //        product = _db.Products.FirstOrDefault(p => p.ProductName == name);
        //    }

        //    else
        //    {
        //        return BadRequest("Please provide either an ID or a name.");
        //    }

        //    if (product == null)
        //    {

        //        return NotFound();
        //    }

        //    return Ok(product);
        //}


        //[HttpGet("api/GettingAllCat")]
        //public IActionResult GetAllCat()
        //{

        //    var category = _db.Categories.ToList();
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(category);
        //}



        //[HttpGet("api/GettingCatByID/{id}")]
        //public IActionResult GetCatByID(int id)
        //{

        //    var cat = _db.Categories.Find(id);

        //    if (cat == null)
        //    {

        //        return NotFound();
        //    }
        //    return Ok(cat);

        //}


        //[HttpGet("api/GettingCatById/{id}")]
        //[HttpGet("api/GettingCatByname/{name}")]

        //public IActionResult GetCatByID(int id = 0, string name = null)
        //{

        //    Category cat;

        //    if (id > 0)
        //    {

        //        cat = _db.Categories.Find(id);

        //    }

        //    else if (!string.IsNullOrEmpty(name))
        //    {

        //        cat = _db.Categories.FirstOrDefault(p => p.CategoryName == name);


        //    }

        //    else
        //    {

        //        return BadRequest("Niether the name nor the Id is correct");
        //    }

        //    if (cat == null)
        //    {

        //        return NotFound();
        //    }


        //    return Ok(cat);

        //}

        //[Route("api/GettingProductCatIDWithOptionalPrice/{catId}")]
        //[HttpGet]

        //public IActionResult GettingProductCatIDWithOptionalPrice(int catId, int? price = null)
        //{


        //    var products = _db.Products.Where(p => p.CategoryId == catId && (price == null || Convert.ToDecimal(p.Price) >= price)).ToList();

        //    if (!products.Any())
        //    {
        //        return NotFound();
        //    }
        //    return Ok(products);

        //}

        //[HttpGet("api/product/{name}")]
        //[HttpGet("api/product/{id:int}")]


        //public IActionResult GetProduct(int id, string name)
        //{




        //    if (id > 0)
        //    {

        //        var products = _db.Products.FirstOrDefault(p => p.ProductId == id);
        //        return Ok(products);
        //    }

        //    else if (!string.IsNullOrEmpty(name))
        //    {

        //        var products = _db.Products.FirstOrDefault(p => p.ProductName == name);
        //        return Ok(products);

        //    }
        //    else
        //    {
        //        return NotFound();
        //    }






    }








}

