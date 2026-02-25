using API.Request.Role;
using Application.Features.Roles.Command.CreateRole;
using Application.Features.Roles.Command.DeleteRole;
using Application.Features.Roles.Command.UpdateRole;
using Application.Features.Roles.Queries.CheckExistanceById;
using Application.Features.Roles.Queries.CheckExistanceByName;
using Application.Features.Roles.Queries.GetRoleById;
using Application.Features.Roles.Queries.GetRoles;
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
        RoleDTO createdRole = await _mediator.Send(command);
        return Ok(createdRole);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteRole([FromBody] DeleteRoleRequest request)
    {
        var command = new DeleteRoleCommand(request.Id);
        RoleDTO deletedRole = await _mediator.Send(command);
        return Ok(deletedRole);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateRole([FromBody] UpdateRoleRequest request)
    {
        var command = new UpdateRoleCommand(request.Id, request.NewName);
        RoleDTO updatedRole = await _mediator.Send(command);
        return Ok(updatedRole);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        var query = new GetRolesQuery();
        IReadOnlyList<RoleDTO> roles = await _mediator.Send(query);
        return Ok(roles);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetRoleById(Guid id)
    {
        var query = new GetRoleByIdQuery(id);
        RoleDTO role = await _mediator.Send(query);
        return Ok(role);
    }

    [HttpGet("exist/{name}")]
    public async Task<IActionResult> RoleExists(string name)
    {
        var query = new CheckExistanceByNameQuery(name);
        bool found = await _mediator.Send(query);
        return Ok(found ? "Exist" : "Not exist");
    }

    [HttpGet("exist/{id:guid}")]
    public async Task<IActionResult> RoleExists(Guid id)
    {
        var query = new CheckExistanceByIdQuery(id);
        bool found = await _mediator.Send(query);
        return Ok(found ? "Exist" : "Not exist");
    }
}