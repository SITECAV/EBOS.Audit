using EBOS.Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBOS.Audit.Infrastructure.Persistence.Configurations;

public sealed class ActivityLogConfiguration : IEntityTypeConfiguration<ActivityLog>
{
    public void Configure(EntityTypeBuilder<ActivityLog> builder)
    {
        builder.ToTable("ActivityLogs");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.SystemName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Action).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
        builder.Property(x => x.User).IsRequired().HasMaxLength(100);

        builder.Property(x => x.Timestamp).IsRequired().HasColumnType("datetime2");

        builder.Property(x => x.IpAddress).HasMaxLength(50);
        builder.Property(x => x.UserAgent).HasMaxLength(500);
        builder.Property(x => x.MetadataJson);

        builder.Property(x => x.CorrelationId).HasMaxLength(100);
        
        builder.HasIndex(x => x.SystemName); 
        builder.HasIndex(x => x.User); 
        builder.HasIndex(x => x.Timestamp);
        builder.HasIndex(x => x.CorrelationId);
        
        builder.HasIndex(x => new { x.User, x.Timestamp })
            .HasDatabaseName("IX_AuditChange_User");
    }
}