using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class LikeService : ILikeService
    {
        private readonly ILikeDal _likeDal;
        public LikeService(ILikeDal likedal)
        {
            _likeDal = likedal;
        }

        public async Task AddLike(Like like)
        {
            await _likeDal.AddAsync(like);
        }

        public async Task<int> GetLikesCount(string postId)
        {
            return (await _likeDal.GetAllAsync(l => l.PostId == postId)).Count();
        }

        public async Task RemoveLike(string userId, string postId)
        {
            var like = await _likeDal.GetAsync(l => l.UserId == userId && l.PostId == postId);

            if (like != null)
            {
                await _likeDal.DeleteAsync(like);
            }
            else
            {
                throw new Exception("Like not found");
            }
        }

    }
}
