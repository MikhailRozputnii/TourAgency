using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(1024);
            builder.HasMany(t => t.Images).WithOne(i => i.Tour);
        }
    }
}