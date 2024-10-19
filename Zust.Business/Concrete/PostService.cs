using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostDal _postDal;
        private readonly IUserService _userService;
        public PostService(IPostDal postDal, IUserService userService)
        {
            _postDal = postDal;
            _userService = userService;

        }

        public async Task AddPost(Post post)
        {
            await _postDal.AddAsync(post);
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var post = (await _postDal.GetAllAsync()).ToList();
            return post;
        }

        public Task<Post?> GetPostById(string postId)
        {
            return _postDal.GetAsync(p => p.Id == postId);
        }
    }
}
