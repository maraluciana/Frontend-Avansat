using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectFlowerShop.BLL.Interfaces;
using ProjectFlowerShop.BLL.Models;
using ProjectFlowerShop.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectFlowerShop.BLL.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class ProductController : ControllerBase
    {
        public List<Product> Product = new List<Product>
        {
            new Product {Id = 1, productType = "ceva", Name = "Fl1", Path = "path1", Price = 1},
            new Product {Id = 2, productType = "ceva", Name = "Fl2", Path = "path2", Price = 2},
            new Product {Id = 3, productType = "ceva", Name = "Fl3", Path = "path3", Price = 3},
        };
        private readonly IProductService service;

        public ProductController(IProductService productService)
        {
            this.service = productService;
            this.Product = Product;
        }

        [HttpGet("Get_All_Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = service.GetAllProducts();
            return Ok(products);
        }

        [HttpGet()]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(this.Product);
        }


        [HttpGet("Get_Products_By_Type{type}")]
        public async Task<IActionResult> GetProductsByType([FromRoute] string type)
        {
            var products = service.GetProductsByType(type);
            return Ok(products);
        }

        [HttpGet("Get_Product_By_Id{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = service.GetProductById(id);
            return Ok(product);
        }

        [HttpPost("Create_Product")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> CreatePost([FromBody] ProductCreateModel model)
        {
            service.CreateProduct(model);
            return Ok();
        }

        [HttpPut("Update_Product")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdatePost([FromBody] ProductUpdateModel model)
        {
            service.UpdateProduct(model);
            return Ok();
        }

        [HttpDelete("Delete_Product{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            service.DeleteProduct(id);
            return Ok();
        }
    }
}
