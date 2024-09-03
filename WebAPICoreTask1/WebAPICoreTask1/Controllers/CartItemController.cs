using Microsoft.AspNetCore.Mvc;
using WebAPICoreTask1.DTOS;
using WebAPICoreTask1.Models;

namespace WebAPICoreTask1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CartItemController(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet("GetAllCartItems")]
        public ActionResult GetCartItems()
        {
            var cartItems = _db.CartItems.Select(x =>
            new CartItemResponseDTO
            {
                CartItemId = x.CartItemId,

                CartId = x.CartId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,

                prodcutDTO = new ProductResponseDTO
                {
                    ProductName = x.Product.ProductName,
                    Description = x.Product.Description,
                    Price = x.Product.Price,
                    ProductImage = x.Product.ProductImage,

                }



            }

            );

            return Ok(cartItems);

        }

        [HttpPost("CreateCartItem")]
        public ActionResult AddCart([FromBody] CartItemRequestDTO Request)
        {
            var data = new CartItem
            {
                CartId = Request.CartId,
                ProductId = Request.ProductId,
                Quantity = Request.Quantity,
            };

            _db.CartItems.Add(data);
            _db.SaveChanges();
            return Ok(data);
        }


        [HttpPut("UpdateCartById/{id:int}")]
        public IActionResult UpdateCart(int id, [FromBody] CartItemUpdateRequestDTO CartItemDTO)
        {
            var cartItem = _db.CartItems.FirstOrDefault(c => c.CartItemId == id);

            cartItem.Quantity = CartItemDTO.Quantity;

            _db.CartItems.Update(cartItem);
            _db.SaveChanges();
            return Ok(cartItem);

        }

        [HttpDelete("DeleteCartItemByID/{id:int}")]
        public IActionResult DeleteCartItem(int id)
        {

            var CartItem = _db.CartItems.FirstOrDefault(c => c.CartItemId == id);

            _db.CartItems.Remove(CartItem);
            _db.SaveChanges();
            return Ok($"Cart Item with id {id} has succesfully removed!");


        }

        [HttpGet("GetOddRepeated")]
        public IActionResult OddNumberRepeated(int num1, int num2, int num3, int num4, int num5, int num6)
        {
            int[] number = { num1, num2, num3, num4, num5, num6 };
            List<int> repeatedNumbers = new List<int>();

            for (int i = 0; i < number.Length; i++)
            {
                int count = 0;

                // Count occurrences of the current number
                for (int j = 0; j < number.Length; j++)
                {
                    if (number[i] == number[j])
                    {
                        count++;
                    }
                }

                // If the count is odd and not already added to repeatedNumbers, add it
                if (count % 2 != 0 && !repeatedNumbers.Contains(number[i]))
                {
                    repeatedNumbers.Add(number[i]);
                }
            }

            return Ok(repeatedNumbers);
        }

    }
}