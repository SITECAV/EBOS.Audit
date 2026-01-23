using Asp.Versioning;
using EBOS.Audit.Client.Contracts;
using EBOS.Audit.Contracts.Filters;
using EBOS.Audit.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EBOS.Audit.Api.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/audit/activity")]
[Produces("application/json")]
public sealed class ActivityLogsController(AuditAppService service) : ControllerBase
{
    [Authorize(Policy = "AuditWrite")]
    [ApiVersion(1.0)]
    [ApiVersion(2.0)]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ActivityLogRequest request, CancellationToken ct)
    {
        await service.RegisterActivityAsync(request, ct);
        return Accepted();
    }
    
    [Authorize(Policy = "AuditRead")]
    [ApiVersion("2.0")]
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] ActivityLogFilter filter, CancellationToken ct)
        => Ok(await service.GetActivityLogsAsync(filter, ct));
}