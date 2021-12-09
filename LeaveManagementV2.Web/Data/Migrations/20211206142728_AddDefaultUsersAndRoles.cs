using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementV2.Web.Data.Migrations
{
    public partial class AddDefaultUsersAndRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85", "db42db41-0b31-418c-a51e-eb83a2ffd577", "Administrator", "ADMINISTRATOR" },
                    { "eb344fc9-5c10-4d57-97fe-2f584d136229", "1e431d94-4ca9-469a-bfcd-c51e078eb236", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateJoined", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TaxId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "568ba572-f8cd-4add-848b-081d88a6c80e", 0, "b0382f3d-646c-45e2-8fd8-37c84006c3d9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@localhost.com", false, "System", "User", false, null, "USER@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEDemAMcuxlRXbJMVn7v1TPKJKanWhkGjAIpXZlHvKr8VD+jOZ6SzLJWV88bz8zk7JQ==", null, false, "4691b29e-0a37-49ae-be95-71b30885dd3b", null, false, null },
                    { "9986b3eb-1b52-4956-a623-53413792571b", 0, "7dfa8f9f-1145-4c21-859d-a0875b4dca5e", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@localhost.com", false, "System", "Admin", false, null, "ADMIN@LOCALHOST.COM", null, "AQAAAAEAACcQAAAAEML120ta4hh0aVl9eSCsvKSvLVaC/xzhOFqNXYhOmrAPkoFKSS+0fa+Ubd0TUsOhow==", null, false, "6ea1b25f-08e0-461b-a867-6175374e2125", null, false, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eb344fc9-5c10-4d57-97fe-2f584d136229", "568ba572-f8cd-4add-848b-081d88a6c80e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85", "9986b3eb-1b52-4956-a623-53413792571b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eb344fc9-5c10-4d57-97fe-2f584d136229", "568ba572-f8cd-4add-848b-081d88a6c80e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85", "9986b3eb-1b52-4956-a623-53413792571b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb344fc9-5c10-4d57-97fe-2f584d136229");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "568ba572-f8cd-4add-848b-081d88a6c80e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9986b3eb-1b52-4956-a623-53413792571b");
        }
    }
}
