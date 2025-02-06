using DataAccess.Repository.Core;
using DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Models.Documents;

namespace DataAccess.Repository;
public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(DbContext context) : base(context)
    {
    }
}
