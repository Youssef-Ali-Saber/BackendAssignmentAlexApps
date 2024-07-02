using Domain.Entities;
using Domain.IUnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(IUnitOfWork unitOfWork) : ControllerBase
    {


        [HttpGet("GetCart")]
        [Authorize(Roles = "User")]
        public IActionResult GetCart()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var cart = unitOfWork.CartRepository.GetByFilter(c => c.UserId == userId, [inc => inc.CartItems]).FirstOrDefault();
                var cartItems = unitOfWork.CartItemRepository.GetByFilter(c => c.CartId == cart.Id, [inc => inc.Product.Store]).ToList();
            
                if (cart == null)
                       return Ok();

                return Ok(new
                {
                    cartItems = cartItems.Select(selector => new
                    {
                        selector.Quantity,
                        Product = new
                        {
                            selector.Product.Id,
                            selector.Product.NameAr,
                            selector.Product.NameEn,
                            selector.Product.Price,
                        }
                    }),
                    totalPrice = cart.TotalPrice
                });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        

        [HttpPost("AddToCart/{productId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> AddToCart(int productId,[FromQuery][Required] int Quantity)
        {
            try
            {

            
                var product = await unitOfWork.ProductRepository.GetByIdAsync(productId);
                if (product == null)
                    return BadRequest();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var cart = unitOfWork.CartRepository.GetByFilter(c => c.UserId == userId ,[inc => inc.CartItems]).FirstOrDefault();
                if (cart == null)
                {
                    cart = new Cart
                    {
                        UserId = userId,
                        CartItems = new List<CartItem>
                        {
                            new CartItem
                            {
                                ProductId = productId,
                                Quantity = Quantity
                            }
                        }
                    };
                    await unitOfWork.CartRepository.CreateAsync(cart);
                }
                else
                {
                    var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
                    if (cartItem == null)
                    {
                        cart.CartItems.Add(new CartItem
                        {
                            ProductId = productId,
                            Quantity = Quantity
                        });
                    }
                    else
                    {
                        cartItem.Quantity += Quantity;
                    }
                    unitOfWork.CartRepository.Update(cart);
                }
                await unitOfWork.SaveAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

    }
}
