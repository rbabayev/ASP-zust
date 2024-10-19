using Microsoft.AspNetCore.Mvc;
using Zust.Business.Abstract;
using Zust.Entities.Entities;
using ZustProject.Services;

namespace ZustProject.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMediaService _mediaService;
        private readonly IUserService _userService;

        public PostController(IPostService postService, IMediaService mediaService, IUserService userService)
        {
            _postService = postService;
            _mediaService = mediaService;
            _userService = userService;
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post, IFormFile? mediaFile)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            if (mediaFile != null)
            {
                var mediaUrl = await _mediaService.UploadMediaAsync(mediaFile);
                post.ImageUrl = mediaUrl;
            }

            await _postService.AddPost(post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await _postService.GetAllPosts();
            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Post post, IFormFile? mediaFile)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }

            if (mediaFile != null)
            {
                var mediaUrl = await _mediaService.UploadMediaAsync(mediaFile);
                post.ImageUrl = mediaUrl;
            }

            await _postService.AddPost(post);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var post = await _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }
    }

}

