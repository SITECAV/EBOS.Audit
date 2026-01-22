using EBOS.Audit.Domain.Entities;

namespace EBOS.Audit.Domain.Interfaces.Services;

public interface IAuditService
{
    Task RegisterChangeAsync(AuditChange change, CancellationToken ct = default);
    Task RegisterEventAsync(DomainEventLog domainEvent, CancellationToken ct = default);
    Task RegisterActivityAsync(ActivityLog activity, CancellationToken ct = default);
}