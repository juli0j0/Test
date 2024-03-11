using Microsoft.AspNetCore.Mvc;
using TestServer.BL.Interfaces;
using TestServer.DTO.General;

namespace TestServer.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestIdController : Controller
    {
        private readonly ITestIdService _testService;

        public TestIdController(ITestIdService testService)
        {
            _testService = testService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(TestDTO))]
        public async Task<IActionResult> Get(int id)
        {
            var tests = _testService.GetTest(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tests);
        }
    }
}
