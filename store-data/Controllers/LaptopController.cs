using Microsoft.AspNetCore.Mvc;
using store_data.Models.Mongo;
using store_data.Services;

namespace store_data.Controllers
{
    [ApiController]
    public class LaptopController : BaseController
    {
        private readonly LaptopService _laptopService;
        public LaptopController(LaptopService service) { 
            _laptopService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<LaptopModel>> GetAsync()
        {
           return await _laptopService.GetAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddOneAsync(LaptopModel laptop)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _laptopService.AddOneAsync(laptop);
            return Ok();
        }

        
    }
}
