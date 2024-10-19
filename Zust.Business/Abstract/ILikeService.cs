using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface ILikeService
    {
        Task AddLike(Like like);
        Task RemoveLike(string userId, string postId);
        Task<int> GetLikesCount(string postId);

    }
}
