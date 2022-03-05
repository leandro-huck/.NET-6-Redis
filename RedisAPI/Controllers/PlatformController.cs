using Microsoft.AspNetCore.Mvc;
using RedisAPI.Data;
using RedisAPI.Models;

namespace RedisAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repository;

        public PlatformController(IPlatformRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetPlatformByIdAsync")]
        public async Task<ActionResult<Platform>> GetPlatformByIdAsync(string id)
        {
            Console.WriteLine($"--> Getting platform: {id}");

            var platform = await _repository.GetPlatformByIdAsync(id);

            if (platform != null)
            {
                return Ok(platform);
            }
            return NotFound();
        }

        [HttpPost]
        public ActionResult<Platform> CreatePlatform(Platform platform)
        {
            Console.WriteLine($"--> Creating platform: {platform.Id}");

            _repository.CreatePlatform(platform);

            return CreatedAtRoute(nameof(GetPlatformByIdAsync), new { Id = platform.Id }, platform);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Platform>>> GetAllPlatformsAsync()
        {
            Console.WriteLine($"--> Getting all platforms");

            return Ok(await _repository.GetAllPlatformsAsync());
        }
    }
}