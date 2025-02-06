using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Messages;

namespace DataAccess.Repository;
public class MessageRepository : BaseRepository<Message>, IMessageRepository
{
    public MessageRepository(DbContext context) : base(context)
    {
    }
}