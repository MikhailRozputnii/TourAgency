using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(i => i.Tour).WithMany(t => t.Images);
        }
    }
}