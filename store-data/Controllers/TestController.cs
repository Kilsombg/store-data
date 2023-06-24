using Microsoft.AspNetCore.Mvc;
using store_data.Services;

namespace store_data.Controllers
{
    [ApiController]
    public class TestController : ControllerBase
    {
        private MongoDBService service;

        public TestController(MongoDBService mongoDBService) {
            service = mongoDBService;
        }

        [HttpGet("/test")]
        public IActionResult get()
        {
            return Ok();
        }
    }
}
