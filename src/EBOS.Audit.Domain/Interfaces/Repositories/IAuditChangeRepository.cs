using EBOS.Audit.Domain.Entities;

namespace EBOS.Audit.Domain.Interfaces.Repositories;

public interface IAuditChangeRepository
{
    Task AddAsync(AuditChange change, CancellationToken cancellationToken = default);
}