using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Meetings;

namespace DataAccess.Repository;
public class MeetingRepository : BaseRepository<Meeting>, IMeetingRepository
{
    public MeetingRepository(DbContext context) : base(context)
    {
    }
}