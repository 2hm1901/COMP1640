using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Emails;

namespace DataAccess.Repository;
public class EmailRepository : BaseRepository<Email>, IEmailRepository
{
    public EmailRepository(DbContext context) : base(context)
    {
    }
}
