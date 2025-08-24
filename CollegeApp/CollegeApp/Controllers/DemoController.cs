using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;   // <-- Important

namespace CollegeApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;   // ✅ declare _logger

        public DemoController(ILogger<DemoController> logger)   // ✅ inject logger
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Index()
        {
            _logger.LogTrace("This is a demo log message.");
            _logger.LogDebug("Debug message for developers.");
            _logger.LogInformation("General info message.");
            _logger.LogWarning("Warning message.");
            _logger.LogError("Error occurred here!");
            _logger.LogCritical("Critical issue!");

            return Ok("Logs written successfully!");
        }
    }
}
