namespace Application.Features.Hospitals.Queries.GetHospitalStatistics;

public record HospitalStatisticsDTO(
    int DoctorsCount,
    int PatientsCount
);