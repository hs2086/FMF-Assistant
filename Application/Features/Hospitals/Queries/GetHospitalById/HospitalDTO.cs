namespace Application.Features.Hospitals.Queries.GetHospitalById;


public record HospitalDTO(Guid Id, string Name, string Address, string Phone, string Email);