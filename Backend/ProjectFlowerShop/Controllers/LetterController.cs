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
    public class LetterController : ControllerBase
    {
        private readonly ILetterService service;

        public LetterController(ILetterService letterService)
        {
            this.service = letterService;
        }

        [HttpGet("Get_All_Letters")]
        public async Task<IActionResult> GetAllLetters()
        {
            var letters = service.GetAllLetters();
            return Ok(letters);
        }

        [HttpPut("Update_Letter")]
        public async Task<IActionResult> UpdateLetter([FromBody] LetterModel model)
        {
            service.UpdateLetter(model);
            return Ok();
        }


        [HttpPost("Create_Letter")]
        public async Task<IActionResult> CreateLetter([FromBody] LetterModel letterModel)
        {
            service.CreateLetter(letterModel);
            return Ok();
        }

        [HttpDelete("Delete_Letter{id}")]
        public async Task<IActionResult> DeleteLetter([FromRoute] int id)
        {
            service.DeleteLetter(id);
            return Ok();
        }
    }
}
