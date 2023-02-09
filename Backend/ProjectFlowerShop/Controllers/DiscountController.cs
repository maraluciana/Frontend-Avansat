using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService service;

        public DiscountController(IDiscountService discountService)
        {
            this.service = discountService;
        }

        [HttpGet("Get_All_Discounts")]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var discounts = service.GetAllDiscounts();
            return Ok(discounts);
        }

        [HttpGet("Get_Discount_By_Code{code}")]
        public async Task<IActionResult> GetDiscountsByCode([FromRoute] string code)
        {
            var discounts = service.GetDiscountsByCode(code);
            return Ok(discounts);
        }
        [HttpGet("Get_Discounts_By_Type{type}")]
        public async Task<IActionResult> GetDiscountsByType([FromRoute] string type)
        {
            var discounts = service.GetDiscountsByType(type);
            return Ok(discounts);
        }

        [HttpPost("Create_Discount")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountModel discountModel)
        {
            service.CreateDiscount(discountModel);
            return Ok();
        }

        [HttpDelete("Delete_Discount{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteDiscount([FromRoute] int id)
        {
            service.DeleteDiscount(id);
            return Ok();
        }
    }
}
