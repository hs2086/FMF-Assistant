using Application.Common.Exceptions.NotFountException;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<EmailVerificationCode> EmailVerificationCodes { get; set; }  
    DbSet<Hospital> Hospitals { get; set; }
    DbSet<Doctor> Doctors { get; set; }  
    DbSet<Patient> Patients { get; set; }
    DbSet<Attack> Attacks { get; set; }  
    DbSet<MedicationLog> MedicationLogs { get; set; }
    DbSet<LabResult> LabResults { get; set; }
    DbSet<DoctorHospital> DoctorHospital { get; set; }
    DbSet<PatientHospital> PatientHospital { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);  
}