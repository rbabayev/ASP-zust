using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zust.Business.Abstract;
using Zust.Entities.Entities;
using ZustProject.Models;

namespace ZustProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;

        public CommentController(IMapper mapper, ICommentService commentService)
        {
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CreateCommentViewModel model)
        {

            Comment comment = _mapper.Map<Comment>(model);
            comment.CommentTime = DateTime.Now;

            try
            {
                await _commentService.AddComment(comment);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
