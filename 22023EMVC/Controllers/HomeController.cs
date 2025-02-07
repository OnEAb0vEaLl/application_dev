using System.Diagnostics;
using System.Security.Claims;
using _22023EMVC.Data;
using _22023EMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

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
            List<DataPoint> dataPoints = new List<DataPoint>();
            var products = _db.Products.ToList();
            foreach ( var p in products )
            {
                dataPoints.Add(new DataPoint(p.Name, p.Quantity));
            }
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View(model);
        }
        [HttpGet("SendMessageToAll")]
        [Authorize]
        public async Task<IActionResult> SendMessageToAll(string user, string message)
        {
            await _basicChatHub.Clients.All.SendAsync("MessageReceived", user, message);
            return Ok();
        }
        [HttpGet("SendMessageToReceiver")]
        [Authorize]
        public async Task<IActionResult> SendMessageToReceiver(string sender, string receiver, string message)
        {
            var userId = _db.Users.FirstOrDefault(u => u.Email.ToLower() == receiver.ToLower())?.Id;

            if (!string.IsNullOrEmpty(userId))
            {
                await _basicChatHub.Clients.User(userId).SendAsync("MessageReceived", sender, message);
            }
            return Ok();
        }
        [HttpGet("SendMessageToGroup")]
        [Authorize]
        public async Task SendMessageToGroup(string message)
        {
            var user = GetUserId();
            var role = (await GetUserRoles(user)).FirstOrDefault();
            var username = _db.Users.FirstOrDefault(u => u.Id == user)?.Email ?? "";
            if (!string.IsNullOrEmpty(role))
            {
                await _basicChatHub.Clients.Group(role).SendAsync("MessageReceived", username, message);
            }
        }
        private string GetUserId()
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
        }
        private async Task<IList<string>> GetUserRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
        [HttpGet("total-user")]
        public async Task<int> RegisteredUserCount()
        {
            return _userManager.Users.Count();
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
