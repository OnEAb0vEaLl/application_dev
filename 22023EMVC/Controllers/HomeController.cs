using System.Diagnostics;
using _22023EMVC.Data;
using _22023EMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace _22023EMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
      
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IHubContext<BasicChatHub> _basicChatHub;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext db,
            IHubContext<BasicChatHub> basicChatHUb,
            UserManager<ApplicationUser> userManager
            )
                { 
            _logger = logger;
                _db = db;
                _userManager = userManager;
                _basicChatHub = basicChatHUb;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var model = new RoleViewModel();
            var user =await _userManager.GetUserAsync(User);
            if (user is not null)
            {
                var roles = await _userManager.GetRolesAsync(user);
                model.UserRoles = roles;

            }
            return View(model);
        }
      
        [Authorize(Roles ="Admin")]
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
