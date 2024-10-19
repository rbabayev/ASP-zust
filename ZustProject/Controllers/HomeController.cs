using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;
using ZustProject.Models;

namespace ZustProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly ZustDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<User> userManager, ZustDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.User = user;
            return View();
        }

        [HttpPost(Name = "AddMessage")]
        public async Task<IActionResult> AddMessage(MessageViewModel model)
        {
            try
            {
                var chat = await _context.Chats.FirstOrDefaultAsync(c => c.SenderUserId == model.SenderId &&
                c.ReceiverUserId == model.ReceiverId || c.SenderUserId == model.ReceiverId && c.ReceiverUserId == model.SenderId);
                if (chat != null)
                {
                    var message = new Message
                    {
                        ChatId = chat.Id,
                        Text = model.Content,
                        SentTime = DateTime.Now,
                        IsSeen = false,
                    };
                    await _context.Messages.AddAsync(message);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        public async Task<IActionResult> GetAllMessages(string receiverId, string senderId)
        {
            var chat = await _context.Chats.Include(nameof(Chat.Messages)).FirstOrDefaultAsync(c => c.SenderUserId == senderId &&
               c.ReceiverUserId == receiverId || c.SenderUserId == receiverId && c.ReceiverUserId == senderId);
            if (chat != null)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                return Ok(new { Messages = chat.Messages, CurrentUserId = user.Id });
            }
            return Ok();
        }

        public async Task<IActionResult> DeclineRequest(int id, string senderId)
        {
            try
            {
                var current = await _userManager.GetUserAsync(HttpContext.User);
                var request = await _context.FriendRequests.FirstOrDefaultAsync(f => f.Id == id.ToString());
                _context.FriendRequests.Remove(request);

                _context.FriendRequests.Add(new FriendRequest
                {
                    Content = $"{current.UserName} declined your friend request at {DateTime.Now.ToLongDateString()} {DateTime.Now.ToShortTimeString()}",
                    SenderId = current.Id,
                    Sender = current,
                    ReceiverId = senderId,
                    Status = "Notification"
                });
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeclineRequest(int id)
        {
            try
            {
                var request = await _context.FriendRequests.FirstOrDefaultAsync();
                if (request == null) return NotFound();
                _context.FriendRequests.Remove(request);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Notifications()
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> UnfollowUser(string id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var friend = await _context.UserFriends.FirstOrDefaultAsync(f => f.FriendId == user.Id && f.UserId == id || f.UserId == user.Id && f.FriendId == id);
            if (friend != null)
            {
                _context.UserFriends.Remove(friend);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return NotFound();

        }

        public async Task<IActionResult> Messages(string id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var chat = await _context.Chats.Include(nameof(Chat.Messages)).FirstOrDefaultAsync(c => c.SenderUserId == user.Id && c.ReceiverUserId == id || c.ReceiverUserId == user.Id && c.SenderUserId == id);
            if (chat == null)
            {
                chat = new Chat
                {
                    ReceiverUserId = id,
                    SenderUserId = user.Id,
                    Messages = new List<Message>()
                };

                await _context.Chats.AddAsync(chat);
                await _context.SaveChangesAsync();
            }

            var chats = _context.Chats.Include(nameof(Chat.ReceiverUser)).Where(c => c.SenderUserId == user.Id || c.ReceiverUserId == user.Id);


            var chatBlocks = from c in chats
                             let receiver = (user.Id != c.ReceiverUserId) ? c.ReceiverUser : _context.Users.FirstOrDefault(u => u.Id == c.SenderUserId)
                             select new Chat
                             {
                                 Messages = c.Messages,
                                 Id = c.Id,
                                 SenderUserId = c.SenderUserId,
                                 ReceiverUser = (User)receiver,
                                 ReceiverUserId = receiver.Id,
                             };

            var result = chatBlocks.ToList().Where(c => c.ReceiverUserId != user.Id);
            var model = new ChatViewModel
            {
                CurrentUserId = user.Id,
                CurrentReceiver = id,
                CurrentChat = chat,
                Chats = result.Count() == 0 ? chatBlocks : result,
            };

            return View(model);
        }

        public IActionResult Friends()
        {
            return View();
        }

        public IActionResult Event()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        public IActionResult MyProfile()
        {
            return View();
        }

        public IActionResult Setting()
        {
            return View();
        }

        public IActionResult HelpAndSupport()
        {
            return View();
        }
    }
}
