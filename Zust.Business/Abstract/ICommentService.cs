using Zust.Entities.Entities;

namespace Zust.Business.Abstract
{
    public interface ICommentService
    {
        Task AddComment(Comment comment);
        Task<IEnumerable<Comment>> GetAllCommments(string commentId);
    }
}
