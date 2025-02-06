using DataAccess.Repository.IRepository;

namespace DataAccess.Repository.Core;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public IAccountRepository Accounts { get; private set; }

    public ICommentRepository Comments { get; private set; }

    public IPostRepository Posts { get; private set; }

    public IDocumentRepository Documents { get; private set; }

    public IEmailRepository Emails { get; private set; }

    public IMeetingRepository Meetings { get; private set; }

    public IMessageRepository Messages { get; private set; }

    public IInteractionRepository Interactions { get; private set; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Accounts = new AccountRepository(context);
        Comments = new CommentRepository(context);
        Posts = new PostRepository(context);
        Documents = new DocumentRepository(context);
        Emails = new EmailRepository(context);
        Meetings = new MeetingRepository(context);
        Messages = new MessageRepository(context);
        Interactions = new InteractionRepository(context);
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
