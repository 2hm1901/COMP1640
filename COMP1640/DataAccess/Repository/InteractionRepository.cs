using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Interactions;

namespace DataAccess.Repository;
public class InteractionRepository : BaseRepository<Interaction>, IInteractionRepository
{
    public InteractionRepository(DbContext context) : base(context)
    {
    }
}
