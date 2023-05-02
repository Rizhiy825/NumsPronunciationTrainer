using Microsoft.AspNetCore.Mvc;
using NumsPronunciationTrainer.Models;
using System.Diagnostics;

namespace NumsPronunciationTrainer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NumModel currentNum;

        public HomeController(ILogger<HomeController> logger)
        {
            var builder = new Random();
            currentNum = new NumModel(builder.Next(0, 10000));
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(currentNum);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}