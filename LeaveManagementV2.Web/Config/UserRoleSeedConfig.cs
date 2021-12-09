using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementV2.Web.Data
{
    internal class UserRoleSeedConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85",
                    UserId = "9986b3eb-1b52-4956-a623-53413792571b"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "eb344fc9-5c10-4d57-97fe-2f584d136229",
                    UserId = "568ba572-f8cd-4add-848b-081d88a6c80e"
                }
            );
        }
    }
}