using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<EmailVerificationCode> EmailVerificationCodes { get; set; }  
    DbSet<Hospital> Hospitals { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
}