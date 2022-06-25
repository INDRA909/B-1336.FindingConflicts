using B_1336.FindingConflicts.DI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace B_1336.FindingConflicts.Application.ModelConfigurations;
public class ConflictModelConfiguration : IEntityTypeConfiguration<IConflict>
{
    public void Configure(EntityTypeBuilder<IConflict> builder)
    {
        builder.ToTable("Conflicts");
        builder.HasKey(x => x.BrigadeCode);
        builder.Property(x => x.DevicesSerials);
    }
}

