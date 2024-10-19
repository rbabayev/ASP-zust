using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface IPostService
    {

        Task AddPost(Post post);
        Task<IEnumerable<Post>> GetAllPosts();
        Task<Post> GetPostById(string postId);

    }
}
