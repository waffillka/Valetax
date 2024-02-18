using Microsoft.EntityFrameworkCore;
using Valetax.Db.Entities;

namespace Valetax.Db.Context;

public class AppDbContext : DbContext
{
    public DbSet<TreeNodeEntity> TreeNodes { get; set; }
    public DbSet<ExceptionJournalEntity> ExceptionJournal { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<TreeNodeEntity>()
            .HasIndex(e => new { e.Name, e.ParentId })
            .IsUnique();

        builder.Entity<TreeNodeEntity>()
            .HasOne(t => t.Parent)
            .WithMany(t => t.Children)
            .HasForeignKey(t => t.ParentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        base.OnModelCreating(builder);
    }
}