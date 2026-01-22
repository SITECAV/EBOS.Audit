using EBOS.Audit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBOS.Audit.Infrastructure.Persistence.Configurations;

public sealed class AuditChangeConfiguration : IEntityTypeConfiguration<AuditChange>
{
    public void Configure(EntityTypeBuilder<AuditChange> builder)
    {
        builder.ToTable("AuditChanges");

        builder.HasKey(a => a.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        
        builder.Property(a => a.SystemName).IsRequired().HasMaxLength(100);
        builder.Property(a => a.EntityName).IsRequired().HasMaxLength(100);
        builder.Property(a => a.EntityId).IsRequired().HasMaxLength(100);
        builder.Property(a => a.PropertyName).IsRequired().HasMaxLength(100);
        
        builder.Property(x => x.OldValue);
        builder.Property(x => x.NewValue);
        
        builder.Property(a => a.ChangedAt).IsRequired();
        builder.Property(a => a.ChangedBy).IsRequired().HasMaxLength(100);
        
        builder.Property(a => a.CorrelationId).HasMaxLength(100);

        builder.HasIndex(x => x.SystemName); 
        builder.HasIndex(x => x.EntityName); 
        builder.HasIndex(x => x.EntityId); 
        builder.HasIndex(x => x.ChangedAt); 
        builder.HasIndex(x => x.CorrelationId);
        
        builder.HasIndex(a => new { a.SystemName, a.EntityName, a.EntityId })
            .HasDatabaseName("IX_AuditChange_Entity");
        builder.HasIndex(x => new { x.EntityName, x.EntityId, x.ChangedAt })
            .HasDatabaseName("IX_AuditChange_EntityName_EntityId_ChangedAt");
        builder.HasIndex(a => a.ChangedAt)
            .HasDatabaseName("IX_AuditChange_ChangedAt");
    }
}