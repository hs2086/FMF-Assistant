using Domain.Auth;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<EmailVerificationCode> EmailVerificationCodes { get; set; }  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken); 
}