using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Accounts;

namespace DataAccess.Repository;
public class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(DbContext context) : base(context)
    {
    }
}
