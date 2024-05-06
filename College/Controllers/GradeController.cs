using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GradeController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<GradeController> _logger;

        public GradeController(ILogger<GradeController> logger)
        {
            _logger = logger;
        }
    }
}
