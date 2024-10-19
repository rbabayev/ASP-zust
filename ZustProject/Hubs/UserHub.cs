using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using Zust.Business.Abstract;
using Zust.Entities.Entities;

namespace ZustProject.Hubs
{
    public class UserHub : Hub
    {
        private readonly IUserService _userService;

        public UserHub(IUserService userService)
        {
            _userService = userService;
        }


        public override async Task OnConnectedAsync()
        {

            string? userIdClaim = Context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User user = await _userService.GetUserById(userIdClaim!);
            string userName = $"{user.UserName}";
            await Clients.Caller.SendAsync("OnConnectedMethod", user.UserName, user.ProfileImageUrl, userName, user.Email, user.Id);

        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }

        public async Task PostUlReflash(string tagName)
        {
            await Clients.All.SendAsync("PostUlReflashStart", tagName);
        }

    }
}
