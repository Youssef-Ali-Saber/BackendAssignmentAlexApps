using Domain.IUnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet("GetProducts")]
        [Authorize(Roles = "User")]
        public IActionResult GetProducts()
        {
            try
            {
                var products = unitOfWork.ProductRepository.GetAll().Select(selector => new
                {
                    id = selector.Id,
                    nameAr = selector.NameAr,
                    nameEn = selector.NameEn,
                    storeName = selector.Store.Name,
                });
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("GetProduct/{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetProduct(int id)
        {
            try
            {
                var product = await unitOfWork.ProductRepository.GetByIdAsync(id);
                return Ok(product);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
