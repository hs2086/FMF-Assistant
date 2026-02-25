using API.Request.Role;
using Application.Features.Roles.Command.CreateRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RolesController(IMediator _mediator) : ControllerBase
{
    [HttpPost("create")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
    {
        var command = new CreateRoleCommand(request.Name);
        RoleDTO role = await _mediator.Send(command);
        return Ok(role);
    }
}