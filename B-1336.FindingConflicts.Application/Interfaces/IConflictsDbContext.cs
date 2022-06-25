using B_1336.FindingConflicts.DI;
using Microsoft.EntityFrameworkCore;
namespace B_1336.FindingConflicts.Application.Interfaces;
public interface IConflictsDbContext
{
    DbSet<IConflict> conflicts { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
}

