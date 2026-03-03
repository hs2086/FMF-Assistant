using System.Security.Claims;
using API.Request.Hospital;
using Application.Features.Hospitals.Command.CreateHospital;
using Application.Features.Hospitals.Command.UpdateHospital;
using Application.Features.Hospitals.Queries.GetHospitalById;
using Application.Features.Hospitals.Queries.GetHospitals;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class HospitalsController(IMediator mediator) : ControllerBase
{
    [HttpPost("create")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateHospital(CreateHospitalRequest request)
    {
        string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null) return Unauthorized();

        var command = new CreateHospitalCommand(request.Name, request.Address, request.Phone, request.Email, userId, request.Password);
        Guid hospitalId = await mediator.Send(command);
        return Ok(hospitalId);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetHospitalById(string id)
    {
        var query = new GetHospitalByIdQuery(id);
        var hospital = await mediator.Send(query);
        return Ok(hospital);
    }
    
    [HttpGet("all")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetHospitals([FromQuery] HospitalParameter parameter)
    {
        var query = new GetHospitalsQuery(parameter);
        var hospitals = await mediator.Send(query);

        Response.Headers.Append("X-Pagination", System.Text.Json.JsonSerializer.Serialize(hospitals.MetaData));
        return Ok(hospitals);
    }

    [HttpPut("update/{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> UpdateHospital(string id, UpdateHospitalRequest request)
    {
        var command = new UpdateHospitalCommand(id, request.name, request.address, request.phone, request.email);
        var hospital = await mediator.Send(command);
        return Ok(hospital);
    }
}