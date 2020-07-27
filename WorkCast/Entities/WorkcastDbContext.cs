using Microsoft.EntityFrameworkCore;

namespace WorkCast.Entities
{
    public class WorkcastDbContext : DbContext
    {
        public WorkcastDbContext(DbContextOptions<WorkcastDbContext> options) : base(options)
        { }
        public DbSet<Command> Commands { get; set; }
    }
}