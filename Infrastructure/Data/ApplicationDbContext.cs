using Application.Common.Interfaces;
using Domain;
using Infrastructure.Data.Configuration;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
: IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options), IApplicationDbContext
{
    public DbSet<EmailVerificationCode> EmailVerificationCodes { get; set; }    
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Doctor> Doctors { get; set; }  
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Attack> Attacks { get; set; }  
    public DbSet<MedicationLog> MedicationLogs { get; set; }
    public DbSet<LabResult> LabResults { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationUserConfiguration).Assembly);

        builder.Entity<EmailVerificationCode>().HasKey(e => e.Id);
        builder.Entity<Hospital>().HasKey(h => h.Id);
        builder.Entity<Doctor>().HasKey(d => d.Id);
        builder.Entity<DoctorHospital>().HasKey(dh => new { dh.DoctorId, dh.HospitalId });
        builder.Entity<PatientHospital>().HasKey(dp => new { dp.HospitalId, dp.PatientId });

        // Optional navigation if you want
        builder.Entity<EmailVerificationCode>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Hospital>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(h => h.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Doctor>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(d => d.UserId)
            .OnDelete(DeleteBehavior.NoAction);
        
        builder.Entity<Patient>()
            .HasOne<ApplicationUser>()
            .WithMany()
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Entity<DoctorHospital>()
            .HasOne(dh => dh.Doctor)
            .WithMany(d => d.DoctorHospitals)
            .HasForeignKey(dh => dh.DoctorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<DoctorHospital>()
            .HasOne(dh => dh.Hospital)
            .WithMany(h => h.DoctorHospitals)
            .HasForeignKey(dh => dh.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<PatientHospital>()
            .HasOne(dp => dp.Hospital)
            .WithMany(h => h.PatientHospitals)
            .HasForeignKey(dp => dp.HospitalId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<PatientHospital>()
            .HasOne(dp => dp.Patient)
            .WithMany(dp => dp.PatientHospitals)
            .HasForeignKey(p => p.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Entity<LabResult>()
            .HasOne<Patient>()
            .WithMany()
            .HasForeignKey(l => l.PatientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}