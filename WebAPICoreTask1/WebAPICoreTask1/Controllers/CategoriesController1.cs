using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask1.DTOS;
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


        [HttpPost]

        public IActionResult CreateCategory([FromForm] CategoryRequestDTO category)
        {

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var ImageFile = Path.Combine(uploadFolder, category.CategoryImage.FileName);

            using (var stream = new FileStream(ImageFile, FileMode.Create))

            {
                category.CategoryImage.CopyToAsync(stream);
            }

            var newCategory = new Category
            {
                CategoryName = category.CategoryName,
                CategoryImage = category.CategoryImage.FileName,
            };

            _db.Categories.Add(newCategory);
            _db.SaveChanges();


            return Ok();
        }


        [HttpPut("UpdatedCategory/{id}")]

        public IActionResult UpdateCategory(int id, [FromForm] CategoryRequestDTO category)
        {

            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            var ImageFile = Path.Combine(uploadFolder, category.CategoryImage.FileName);

            using (var stream = new FileStream(ImageFile, FileMode.Create))

            {
                category.CategoryImage.CopyToAsync(stream);
            }

            var c = _db.Categories.FirstOrDefault(c => c.CategoryId == id);

            c.CategoryName = category.CategoryName;
            c.CategoryImage = category.CategoryImage.FileName;

            _db.Categories.Update(c);
            _db.SaveChanges();


            return Ok();

        }






        [HttpGet("Calculator")]
        public string Calculations(string x)
        {
            string[] arr = x.Split(" ");
            int num1 = Convert.ToInt32(arr[0]);
            int num2 = Convert.ToInt32(arr[2]);

            if (arr[1] == "-")
                return (num1 - num2).ToString();

            else if (arr[1] == "*")
                return (num2 * num1).ToString();

            else if (arr[1] == "/")
                return (num1 / num2).ToString();

            else if (arr[1] == "+")
                return (num1 + num2).ToString();

            else return ($"Invalid Operation: {arr[0]} {arr[1]} {arr[2]} is invalid.");


        }


        [HttpGet("NumbersChecker30")]
        public bool Chekcer(int num1, int num2)
        {
            if (num1 + num2 == 30 || num1 == 30 || num2 == 30)
            {

                return true;
            }

            else
            {
                return false;
            }
        }


        [HttpGet("NumbersMutlipleChecker")]
        public bool Chekcer(int num1)
        {
            if (num1 % 3 == 0 || num1 % 7 == 0)
            {

                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
