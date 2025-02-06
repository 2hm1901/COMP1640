using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Comments;

namespace DataAccess.Repository;
public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    public CommentRepository(DbContext context) : base(context)
    {
    }
}
