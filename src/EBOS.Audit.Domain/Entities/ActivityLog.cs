using EBOS.Core.Primitives;

namespace EBOS.Audit.Domain.Entities;

public sealed class ActivityLog : BaseEntity
{
    public string SystemName { get; private set; } = null!;
    public string Action { get; private set; } = null!;
    public string Description { get; private set; } = null!;

    public string User { get; private set; } = null!;
    public DateTime Timestamp { get; private set; }

    public string? IpAddress { get; private set; }
    public string? UserAgent { get; private set; }
    public string? MetadataJson { get; private set; }
    public string? CorrelationId { get; private set; }

    private ActivityLog() { }

    public ActivityLog(string systemName, string action, string description, string user, DateTime timestamp,
        string? ipAddress, string? userAgent, string? metadataJson, string? correlationId)
    {
        SystemName = systemName;
        Action = action;
        Description = description;
        User = user;
        Timestamp = timestamp;
        IpAddress = ipAddress;
        UserAgent = userAgent;
        MetadataJson = metadataJson;
        CorrelationId = correlationId;
    }
}