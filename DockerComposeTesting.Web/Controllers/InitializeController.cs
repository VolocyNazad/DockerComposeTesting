using DockerComposeTesting.Data;
using DockerComposeTesting.Data.Abstractions;
using DockerComposeTesting.Data.Abstractions.Data;
using Microsoft.AspNetCore.Mvc;

namespace DockerComposeTesting.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InitializeController : ControllerBase
    {
        private readonly IDbInitializer _dbInitializer;

        public InitializeController(IDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        [HttpGet("Initialize")]
        public async Task<IActionResult> Initialize(CancellationToken cancellationToken)
        {
            _dbInitializer.Initialize();
            return Ok(true);
        }
    }
}
