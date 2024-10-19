using Zust.Business.Abstract;
using Zust.DataAccess.Abstract;
using Zust.Entities.Entities;

namespace Zust.Business.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public async Task AddComment(Comment comment)
        {
            await _commentDal.AddAsync(comment);
        }

        public async Task<IEnumerable<Comment>> GetAllCommments(string commentId)
        {
            return await _commentDal.GetAllAsync(comment => comment.Id == commentId);
        }
    }
}
