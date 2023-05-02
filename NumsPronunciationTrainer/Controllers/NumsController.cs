using Microsoft.AspNetCore.Mvc;
using NumsPronunciationTrainer.Models;

namespace NumsPronunciationTrainer.Controllers
{
    public class NumsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public NumsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
