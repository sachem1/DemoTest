using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISession _session;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration, ISession session, ILogger<HomeController> logger)
        {
            _configuration = configuration;
            _session = session;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var redisSetting =_configuration.GetSection("Redis").Get<Redis>();
            _logger.LogInformation($"sessionId:{_session.Id}");

            _session.Set("test", Encoding.Default.GetBytes("这是我测试的session"));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            _logger.LogInformation($"这是获取session:{Encoding.Default.GetString(_session.Get("test"))}");
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
