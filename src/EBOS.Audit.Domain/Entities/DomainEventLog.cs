using EBOS.Core.Primitives;

namespace EBOS.Audit.Domain.Entities;

public sealed class DomainEventLog : BaseEntity
{
    public string SystemName { get; private set; } = null!;
    public string EventType { get; private set; } = null!;
    public string EntityName { get; private set; } = null!;
    public string EntityId { get; private set; } = null!;

    public string PayloadJson { get; private set; } = null!;
    public DateTime OccurredAt { get; private set; }
    public string TriggeredBy { get; private set; } = null!;
    public string? CorrelationId { get; private set; }

    private DomainEventLog() { }

    public DomainEventLog(string systemName, string eventType, string entityName, string entityId, string payloadJson,
        DateTime occurredAt, string triggeredBy, string? correlationId)
    {
        SystemName = systemName;
        EventType = eventType;
        EntityName = entityName;
        EntityId = entityId;
        PayloadJson = payloadJson;
        OccurredAt = occurredAt;
        TriggeredBy = triggeredBy;
        CorrelationId = correlationId;
    }
}