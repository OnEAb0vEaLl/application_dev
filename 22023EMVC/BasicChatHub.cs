using Microsoft.AspNetCore.Authorization;
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
         public static List<string> GroupsJoined {  get; set; }= new List<string>();
        public string GetUserId()
        {
            var httpcontext =Context.GetHttpContext();
            var userId = httpcontext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return userId;
            
        }
        [Authorize]
        public async Task JoinGroup(string sender)
        {
            var user = GetUserId();
            var role = (await GetUserRoles(user)).FirstOrDefault();
            if (!GroupsJoined.Contains(Context.ConnectionId + ":" + role))
            {
                GroupsJoined.Add(Context.ConnectionId + ":" + role);
                await Groups.AddToGroupAsync(Context.ConnectionId, role);
            }
        }
    }
}
