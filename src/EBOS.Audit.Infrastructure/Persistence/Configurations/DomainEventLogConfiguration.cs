using EBOS.Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBOS.Audit.Infrastructure.Persistence.Configurations;

public sealed class DomainEventLogConfiguration : IEntityTypeConfiguration<DomainEventLog>
{
    public void Configure(EntityTypeBuilder<DomainEventLog> builder)
    {
        builder.ToTable("DomainEventLogs");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.SystemName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.EventType).IsRequired().HasMaxLength(100);
        builder.Property(x => x.EntityName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.EntityId).IsRequired().HasMaxLength(100);

        builder.Property(x => x.PayloadJson).IsRequired();

        builder.Property(x => x.OccurredAt).IsRequired();
        builder.Property(x => x.TriggeredBy).IsRequired().HasMaxLength(100);

        builder.Property(x => x.CorrelationId).HasMaxLength(100);
        
        builder.HasIndex(x => x.SystemName); 
        builder.HasIndex(x => x.EventType); 
        builder.HasIndex(x => x.EntityName); 
        builder.HasIndex(x => x.EntityId); 
        builder.HasIndex(x => x.OccurredAt); 
        builder.HasIndex(x => x.CorrelationId);
        
        builder.HasIndex(x => new { x.EventType, x.OccurredAt })
            .HasDatabaseName("IX_AuditChange_Event");
        
        
    }
}