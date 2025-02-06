using Microsoft.EntityFrameworkCore;
using Models.Accounts;
using Models.Comments;
using Models.Documents;
using Models.Emails;
using Models.Interactions;
using Models.Meetings;
using Models.Messages;
using Models.Posts;

namespace DataAccess;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    #region DbSets
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Interaction> Interactions { get; set; }
    public DbSet<Meeting> Meetings { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Post> Posts { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
}