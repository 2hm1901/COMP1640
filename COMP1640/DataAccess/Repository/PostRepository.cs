using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Posts;

namespace DataAccess.Repository;
public class PostRepository : BaseRepository<Post>, IPostRepository
{
    public PostRepository(DbContext context) : base(context)
    {
    }
}