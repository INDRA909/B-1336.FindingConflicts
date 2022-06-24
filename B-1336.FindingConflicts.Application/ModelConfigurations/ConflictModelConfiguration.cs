using B_1336.FindingConflicts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B_1336.FindingConflicts.Application.ModelConfigurations;
public class ConflictModelConfiguration : IEntityTypeConfiguration<Conflict>
{
    public void Configure(EntityTypeBuilder<Conflict> builder)
    {
        builder.ToTable("Conflicts");
        builder.HasKey(x => x.BrigadeCode);
        builder.Property(x => x.DevicesSerials);
    }
}

