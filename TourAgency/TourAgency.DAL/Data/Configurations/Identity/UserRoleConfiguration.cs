using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Configurations.Identity
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                    new UserRole { UserId = 1, RoleId = (int)Constants.Constants.Role.Admin }
                );
        }
    }
}