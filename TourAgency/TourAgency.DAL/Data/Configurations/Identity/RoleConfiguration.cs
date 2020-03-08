using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static TourAgency.DAL.Constants.Constants;

namespace TourAgency.DAL.Data.Configurations.Identity
{
    public class RoleConfiguration : IEntityTypeConfiguration<Entities.Role>
    {
        public void Configure(EntityTypeBuilder<Entities.Role> builder)
        {
            builder.Property(u => u.Name).HasMaxLength(50);
            builder.Property(u => u.NormalizedName).HasMaxLength(50);

            builder.HasData(
                    new Entities.Role
                    {
                        Id = (int)Role.Admin,
                        Name = Roles.Admin,
                        NormalizedName = Roles.Admin.ToUpper(),
                        ConcurrencyStamp = "0d555559-895c-40d1-b4c6-64ff31f86271"
                    },
                    new Entities.Role
                    {
                        Id = (int)Role.Customer,
                        Name = Roles.Customer,
                        NormalizedName = Roles.Customer.ToUpper(),
                        ConcurrencyStamp = "04e29d4f-a4ba-4ac1-9f75-a003e49e9e52"
                    }
                );
        }
    }
}