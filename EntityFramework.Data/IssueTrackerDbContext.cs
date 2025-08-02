using EntityFramework.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class IssueTrackerDbContext : DbContext , IIssueTrackerDbContext
    {

        public IssueTrackerDbContext(DbContextOptions<IssueTrackerDbContext> dbContextOptions) :base(dbContextOptions) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}
