using DataAccess.Repository.IRepository;

namespace DataAccess.Repository.Core;
public interface IUnitOfWork
{

    IAccountRepository Accounts { get; }
    ICommentRepository Comments { get; }
    IPostRepository Posts { get; }
    IDocumentRepository Documents { get; }
    IEmailRepository Emails { get; }
    IMeetingRepository Meetings { get; }
    IMessageRepository Messages { get; }
    IInteractionRepository Interactions { get; }

    Task<int> SaveAsync();
}
