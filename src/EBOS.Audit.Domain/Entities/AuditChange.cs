using EBOS.Core.Primitives;

namespace EBOS.Audit.Domain.Entities;

public sealed class AuditChange : BaseEntity
{
    public string SystemName { get; private set; } = null!;
    public string EntityName { get; private set; } = null!;
    public string EntityId { get; private set; } = null!;

    public string PropertyName { get; private set; } = null!;
    public string? OldValue { get; private set; }
    public string? NewValue { get; private set; }

    public DateTime ChangedAt { get; private set; }
    public string ChangedBy { get; private set; } = null!;
    public string? CorrelationId { get; private set; }

    private AuditChange() { }

    public AuditChange(string systemName, string entityName, string entityId, string propertyName, string? oldValue, 
        string? newValue, DateTime changedAt, string changedBy, string? correlationId)
    {
        SystemName = systemName;
        EntityName = entityName;
        EntityId = entityId;
        PropertyName = propertyName;
        OldValue = oldValue;
        NewValue = newValue;
        ChangedAt = changedAt;
        ChangedBy = changedBy;
        CorrelationId = correlationId;
    }
}