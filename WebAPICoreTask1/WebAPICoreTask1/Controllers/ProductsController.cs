using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask1.DTOS;
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


        [HttpGet("GetAllProductsByName")]
        public IActionResult GetAllProductsByName()
        {


            var allProducts = _db.Products.OrderBy(p => p.ProductName).Reverse().Take(5).Reverse().ToList();
            var x = _db.Products.OrderBy(x => x.ProductName).ToList().TakeLast(5);

            //for (int i = 0; i < 5; i++)
            //{
            //    return Ok(allProducts[i]);


            //}

            return Ok(x);

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

        [HttpGet("GetProductsByCatID/{CategoryID}")]

        public IActionResult GetProductsByCatID(int CategoryID)
        {
            if (CategoryID <= 0)
            {
                return BadRequest("ID should be greater than 0");

            }

            var products = _db.Products.Where(p => p.CategoryId == CategoryID).ToList();

            if (products == null || !products.Any())
            {
                return NotFound("No products found");
            }

            return Ok(products);

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


        [HttpGet("SortingProductsdescendingly")]

        public IActionResult SortingProducts()
        {

            var products = _db.Products.OrderByDescending(p => p.Price).ToList();

            return Ok(products);
        }


        [HttpGet("SortingProductsAscendingly")]

        public IActionResult SortingProductsAscendingly()
        {

            var products = _db.Products.OrderBy(p => p.Price).ToList();

            return Ok(products);
        }



        [HttpPost]

        public IActionResult CreateProduct([FromForm] ProductRequestDTO product)
        {

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var ImageFile = Path.Combine(uploadFolder, product.ProductImage.FileName);

            using (var stream = new FileStream(ImageFile, FileMode.Create))

            {
                product.ProductImage.CopyToAsync(stream);
            }

            var newProduct = new Product
            {
                ProductName = product.ProductName,
                Description = product.Description,
                Price = product.Price,
                CategoryId = product.CategoryId,
                ProductImage = product.ProductImage.FileName,


            };

            _db.Products.Add(newProduct);
            _db.SaveChanges();


            return Ok();
        }


        [HttpPut("UpdatedProduct/{id}")]

        public IActionResult UpdateProduct(int id, [FromForm] ProductRequestDTO product)
        {

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var ImageFile = Path.Combine(uploadFolder, product.ProductImage.FileName);

            using (var stream = new FileStream(ImageFile, FileMode.Create))

            {
                product.ProductImage.CopyToAsync(stream);
            }

            var p = _db.Products.FirstOrDefault(p => p.ProductId == id);

            p.ProductName = product.ProductName;
            p.Description = product.Description;
            p.Price = product.Price;
            p.CategoryId = product.CategoryId;
            p.ProductImage = product.ProductImage.FileName;

            _db.Products.Update(p);
            _db.SaveChanges();


            return Ok();

        }


        [HttpGet("GetProductsDTO")]
        public IActionResult GetProductByDTO()
        {
            var allproducts = _db.Products.Select(p => new ProductResponseDTO
            {
                ProductName = p.ProductName,
                Description = p.Description,
                Price = p.Price,
                ProductImage = p.ProductImage,

                CategoryDTO = p.Category != null ? new CategoryResponseDTO
                {
                    CategoryId = p.Category.CategoryId,
                    CategoryName = p.Category.CategoryName,
                    CategoryImage = p.Category.CategoryImage,
                } : null

            }).ToList();
            return Ok(allproducts);

        }




    }
}