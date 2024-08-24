using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask1.Models;

namespace WebAPICoreTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;


        public UsersController(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet("GetAllUsers")]
        public IActionResult GetALLUsers()
        {

            var users = _db.Users.ToList();
            return Ok(users);

        }



        [HttpGet("GetOneUser/{id:int}")]

        public IActionResult GetOneUser(int id)
        {
            if (id <= 0)
            {

                return BadRequest("Plz enter an ID greater than 0");

            }


            var user = _db.Users.Find(id);

            if (user == null)
            {

                return NotFound($"user with Id {id} not Found");

            }

            return Ok(user);

        }


        [HttpGet("GetUserByName/{name}")]

        public IActionResult GetUserByName(string name)
        {


            if (string.IsNullOrEmpty(name))
            {

                return BadRequest("Plz enter a valid name");

            }


            var user = _db.Users.Where(p => p.Username == name).FirstOrDefault();



            if (user == null)
            {


                return NotFound($"user with Name: {name} not found");
            }

            return Ok(user);
        }




        [HttpDelete("DeleteUserByID")]

        public IActionResult DeleteUser(int id)
        {

            if (id <= 0)
            {
                return BadRequest("Plz enter a valid id");
            }

            var user = _db.Users.Find(id);

            if (user == null)
            {

                return NotFound($"user with ID: {id} not found");

            }

            var orders = _db.Orders.Where(o => o.UserId == id).ToList();
            _db.Orders.RemoveRange(orders);

            _db.Users.Remove(user);
            _db.SaveChanges();

            return Ok("User Deleted");

        }


    }
}
