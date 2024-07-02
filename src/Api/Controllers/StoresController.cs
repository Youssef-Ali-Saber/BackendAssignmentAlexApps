using Application.DTOs;
using Domain.Entities;
using Domain.IUnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpPost("CreateStore")]
        [Authorize(Roles = "Merchant")]
        public async Task<IActionResult> CreateStore(StoreDto storeDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var store = new Store
                {
                    Name = storeDto.Name,
                    MerchantId = userId,
                    ShippingCost = storeDto.ShippingCost,
                    Description = storeDto.Description,
                    VATIncluded = storeDto.VATIncluded,
                    VATRate = storeDto.VATRate
                };

                await unitOfWork.StoreRepository.CreateAsync(store);

                await unitOfWork.SaveAsync();

                return Ok(new { message = "Store Created Successfully" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("GetStores")]
        [Authorize(Roles = "Merchant")]
        public IActionResult GetStores()
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var stores = unitOfWork.StoreRepository.GetByFilter(store => store.MerchantId == userId)
                    .Select(selector => new
                    {
                        Id = selector.Id,
                        Name = selector.Name
                    });
                return Ok(stores);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("{storeId}/AddProduct")]
        [Authorize(Roles = "Merchant")]
        public async Task<IActionResult> AddProduct(int storeId, ProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var product = new Product
                {
                    NameAr = productDto.NameAr,
                    NameEn = productDto.NameEn,
                    DescriptionAr = productDto.DescriptionAr,
                    DescriptionEn = productDto.DescriptionEn,
                    Price = productDto.Price,
                    StoreId = storeId,
                };
                await unitOfWork.ProductRepository.CreateAsync(product);
                await unitOfWork.SaveAsync();
                return Ok(new { message = "Product Created Successfully" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


    }
}
