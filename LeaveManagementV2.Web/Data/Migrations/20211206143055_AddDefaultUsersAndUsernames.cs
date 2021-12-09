using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementV2.Web.Data.Migrations
{
    public partial class AddDefaultUsersAndUsernames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85",
                column: "ConcurrencyStamp",
                value: "d71689bc-da40-4164-b2ba-549d5e706771");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb344fc9-5c10-4d57-97fe-2f584d136229",
                column: "ConcurrencyStamp",
                value: "c28e8ad2-7dfb-4e41-a133-e3a2c6a3429b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "568ba572-f8cd-4add-848b-081d88a6c80e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "8672398c-fd30-4181-acc1-f89651e3da1a", true, "USER@LOCALHOST.COM", "AQAAAAEAACcQAAAAEIRzF8Ij7EBd4mfRmgROUz7Mnssd99eRzQASmBKYAPNhTB103p7yFCtdD3Ua2uPTDw==", "253982cf-1d44-4814-9b9d-2ab7db9e548f", "user@localhost.com" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9986b3eb-1b52-4956-a623-53413792571b",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "92c02e51-919b-4158-a592-5c2fa673279b", true, "ADMIN@LOCALHOST.COM", "AQAAAAEAACcQAAAAEJh/BunAUhKpLazN1ByFUtSbkFXbe/BsEhXUqmUmXvxH0kzE/KqhIZ8O1F1L2sgjrw==", "64d780f1-abc4-4ac7-85b0-8d73d6e224fc", "admin@localhost.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85",
                column: "ConcurrencyStamp",
                value: "db42db41-0b31-418c-a51e-eb83a2ffd577");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb344fc9-5c10-4d57-97fe-2f584d136229",
                column: "ConcurrencyStamp",
                value: "1e431d94-4ca9-469a-bfcd-c51e078eb236");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "568ba572-f8cd-4add-848b-081d88a6c80e",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b0382f3d-646c-45e2-8fd8-37c84006c3d9", false, null, "AQAAAAEAACcQAAAAEDemAMcuxlRXbJMVn7v1TPKJKanWhkGjAIpXZlHvKr8VD+jOZ6SzLJWV88bz8zk7JQ==", "4691b29e-0a37-49ae-be95-71b30885dd3b", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9986b3eb-1b52-4956-a623-53413792571b",
                columns: new[] { "ConcurrencyStamp", "EmailConfirmed", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "7dfa8f9f-1145-4c21-859d-a0875b4dca5e", false, null, "AQAAAAEAACcQAAAAEML120ta4hh0aVl9eSCsvKSvLVaC/xzhOFqNXYhOmrAPkoFKSS+0fa+Ubd0TUsOhow==", "6ea1b25f-08e0-461b-a867-6175374e2125", null });
        }
    }
}
