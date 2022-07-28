using CaixaMagica.MunichRE.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CaixaMagica.MunichRE.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            CaixaMagica.MunichRE.Data.Models.InspirationalQuotesdbContext inspirationalQuotesdbContext = new Data.Models.InspirationalQuotesdbContext();
            var aaa = inspirationalQuotesdbContext.Quotes.ToList();
            return View();
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