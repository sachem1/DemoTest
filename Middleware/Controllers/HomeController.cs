using System;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Middleware.Models;
using ModuleCommon;

namespace Middleware.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptionService _optionService;



        public HomeController(ILogger<HomeController> logger, IOptionService optionService)
        {
            _logger = logger;
            _optionService = optionService;
        }

        public IActionResult Index()
        {
            _logger.LogDebug(HttpContext.Request.Host.Value, new Exception("test"), new object());
            _logger.LogDebug("这里是首页");
            _logger.LogInformation("首页出现了异常");
            
            
            _logger.LogError(_optionService.GetOptions().Result);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            _logger.LogInformation(HttpContext.Request.Host.Value, ViewData["Message"], new object());

            
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
