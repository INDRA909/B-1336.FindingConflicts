using B_1336.FindingConflicts.Application.Interfaces;
using B_1336.FindingConflicts.Application.ModelConfigurations;
using B_1336.FindingConflicts.DI;
using Microsoft.EntityFrameworkCore;

namespace B_1336.FindingConflicts.Application;
public class ApplicationDbContext :DbContext, IConflictsDbContext
{
    public DbSet<IConflict>? conflicts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder optionsBuilder)
    {
        optionsBuilder.ApplyConfiguration(new ConflictModelConfiguration());
        base.OnModelCreating(optionsBuilder);
    }
}

