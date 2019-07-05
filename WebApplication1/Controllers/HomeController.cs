using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<HomeController> _logger;
        private ISession Session => _httpContextAccessor.HttpContext.Session;

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var redisSetting = _configuration.GetSection("Redis").Get<Redis>();
            _logger.LogInformation($"sessionId:{Session.Id}");

            Session.Set("test", Encoding.Default.GetBytes("这是我测试的session"));
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            _logger.LogInformation($"这是获取session:{Encoding.Default.GetString(Session.Get("test"))}");
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

        static ConcurrentQueue<string> requestQueue = new ConcurrentQueue<string>();


        public async Task<IActionResult> GrabBill(string requestId)
        {
            requestQueue.Enqueue(requestId);
            var cts = new TaskCompletionSource<bool>();
            while (true)
            {
                Thread.Sleep(1200);
                cts.SetResult(true);
                break;
            }
            return await Task.FromResult(new JsonResult(new { Success = requestQueue.Count }));
        }
    }
}
