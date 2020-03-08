using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TourAgency.DAL.Data.Entities;

namespace TourAgency.DAL.Data.Configurations.Identity
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(25);
            builder.Property(u => u.LastName).HasMaxLength(25);
            builder.Property(u => u.Address).HasMaxLength(200);

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Admin",
                    LastName = "Adminovich",
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    PhoneNumber = "+380977777777",
                    PasswordHash = "AQAAAAEAACcQAAAAEGMzk0XBOIyAjROJuaPWloVfCy/SNaFDqzzoRS4+O+7koJ59ogwkPpG1QeyLbJvImQ==",
                    SecurityStamp = "VMJSYCCA5PW3A4GEXO545PGIIHVOKVBX",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
        }
    }
}