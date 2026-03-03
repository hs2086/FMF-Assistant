using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class HospitalConfiguration : IEntityTypeConfiguration<Hospital>
{
    public void Configure(EntityTypeBuilder<Hospital> builder)
    {
        builder.Property(h => h.Name).IsRequired();
        builder.Property(h => h.Address).IsRequired();
        builder.Property(h => h.Phone).IsRequired();
        builder.Property(h => h.Email).IsRequired();
    }
}