using AD60.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AD60.Controllers
{
    public class HomeController : Controller
    {
        [Route("GetAuthenticatedUser")]
        [HttpGet("[action]")]
        public IdentityUser GetUser()
        {
            return new IdentityUser()
            {
                Username = User.Identity?.Name,
                IsAuthenticated = User.Identity != null ? User.Identity.IsAuthenticated : false,
                AuthenticationType = User.Identity?.AuthenticationType
            };
        }

        public class IdentityUser
        {
            public string Username { get; set; }
            public bool IsAuthenticated { get; set; }
            public string AuthenticationType { get; set; }
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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