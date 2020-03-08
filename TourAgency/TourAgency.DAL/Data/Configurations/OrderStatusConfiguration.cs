using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Configurations
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasKey(os => os.Id);
            builder.Property(os => os.Name).HasMaxLength(15).IsRequired();
        }
    }
}