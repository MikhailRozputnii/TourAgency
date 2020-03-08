using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Configurations
{
    public class TourLocationConfiguration : IEntityTypeConfiguration<TourLocation>
    {
        public void Configure(EntityTypeBuilder<TourLocation> builder)
        {
            builder.HasKey(tl => new { tl.TourId, tl.LocationId });

            builder
                 .HasOne(tl => tl.Tour)
                 .WithMany(t => t.TourLocations)
                 .HasForeignKey(tl => tl.TourId);

            builder
                .HasOne(tl => tl.Location)
                .WithMany(l => l.TourLocations)
                .HasForeignKey(tl => tl.LocationId);
        }
    }
}