using Asp.Versioning;
using EBOS.Audit.Client.Contracts;
using EBOS.Audit.Contracts.Filters;
using EBOS.Audit.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBOS.Audit.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/audit/events")]
[Produces("application/json")]
public sealed class DomainEventsController(AuditAppService service) : ControllerBase
{
    [Authorize(Policy = "AuditWrite")]
    [ApiVersion(1.0)]
    [ApiVersion(2.0)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DomainEventRequest request, CancellationToken ct)
    {
        await service.RegisterEventAsync(request, ct);
        return Accepted();
    }
    [Authorize(Policy = "AuditRead")]
    [ApiVersion(2.0)]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] DomainEventLogFilter filter, CancellationToken ct)
        => Ok(await service.GetDomainEventsAsync(filter, ct));
}