using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;


namespace _22023EMVC
{
    public class BasicChatHub: Hub
    {
        private readonly UserManager<IdentityUser> _userManager;
        
        public BasicChatHub(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IList<string>> GetUserRoles(string userId)
        {
            var user= await _userManager.FindByNameAsync(userId);
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
        }
        public override async Task OnConnectedAsync()
        {
            var httpContext =Context.GetHttpContext();
            var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var roles =await GetUserRoles(userId);
            //now you can use the userid as needed 
            await base.OnConnectedAsync();
        }
    }
}
