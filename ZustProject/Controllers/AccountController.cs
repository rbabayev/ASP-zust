using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zust.Business.Abstract;
using Zust.DataAccess.Data;
using Zust.Entities.Entities;
using ZustProject.Models;
using ZustProject.Services;

namespace ZustProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserService _userService;
        private readonly ZustDbContext _context;
        private readonly IMediaService _mediaService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IUserService userService,
            ZustDbContext context, IMediaService mediaService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
            _context = context;
            _mediaService = mediaService;
        }


        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                User user = new User
                {
                    UserName = model.Username,
                    Email = model.Email,
                    ProfileImageUrl = model.ImageUrl
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

            }
            return RedirectToAction("Register", "Home", model);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    if (user != null)
                    {
                        user.ConnectTime = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
                        user.IsOnline = true;
                        await _context.SaveChangesAsync();
                        await _signInManager.SignOutAsync();
                    }
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid Login");
            }
            return RedirectToAction("Login", "Home", model);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                user.DisConnectTime = DateTime.Now;
                user.IsOnline = false;
                await _context.SaveChangesAsync();
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("Login", "Home");
        }

    }
}
