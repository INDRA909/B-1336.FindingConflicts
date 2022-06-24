using B_1336.FindingConflicts.Entities;
using Microsoft.EntityFrameworkCore;
namespace B_1336.FindingConflicts.Application.Interfaces;
public interface IConflictsDbContext
{
    DbSet<Conflict> conflicts { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
}

