using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Country).HasMaxLength(25).IsRequired();
            builder.Property(l => l.City).HasMaxLength(25).IsRequired();
            builder.Property(l => l.Address).HasMaxLength(60).IsRequired();
        }
    }
}