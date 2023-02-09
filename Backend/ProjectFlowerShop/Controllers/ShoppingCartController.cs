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
    public class ShCartController : ControllerBase
    {
        private readonly IShoppingCartService service;

        public ShCartController(IShoppingCartService shcartService)
        {
            this.service = shcartService;
        }



        [HttpGet("Get_All_ShCarts")]
        public async Task<IActionResult> GetAllShCarts()
        {
            var shcarts = service.GetAllShCarts();
            return Ok(shcarts);
        }

        [HttpGet("Get_FinalPrice_of_ShCart{id}")]
        public async Task<IActionResult> GetFinalPriceOfShCart([FromRoute] int id)
        {
            var shcarts = service.GetFinalPriceOfShCart(id);
            return Ok(shcarts);
        }

        [HttpPut("Add_Discount_To_ShCart")]
        public async Task<IActionResult> UpdateShCartDiscount([FromBody] ShCartDiscountModel model)
        {
            service.AddDiscountToShCart(model);
            return Ok();
        }

        [HttpPut("Add_Letter_To_ShCart")]
        public async Task<IActionResult> UpdateShCartLetter([FromBody] LetterModel model)
        {
            service.AddLetterToShCart(model);
            return Ok();
        }


        [HttpPost("Create_ShCart")]
        public async Task<IActionResult> CreateShCart()
        {
            service.CreateShCart();
            return Ok();
        }

        [HttpDelete("Delete_ShCart{id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            service.DeleteShCart(id);
            return Ok();
        }
    }
}
