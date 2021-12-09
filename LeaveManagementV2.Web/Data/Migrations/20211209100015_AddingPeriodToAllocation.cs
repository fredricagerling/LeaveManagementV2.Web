using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementV2.Web.Data.Migrations
{
    public partial class AddingPeriodToAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "LeaveAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85",
                column: "ConcurrencyStamp",
                value: "c632e71c-0f82-4321-94f4-3cd39fe6837b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb344fc9-5c10-4d57-97fe-2f584d136229",
                column: "ConcurrencyStamp",
                value: "5c25c1f6-1bfb-408c-8050-b1a1bd277a99");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "568ba572-f8cd-4add-848b-081d88a6c80e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb6b6ef0-a928-4ca4-a597-0bdb61be6dc0", "AQAAAAEAACcQAAAAEAV8hTvtUQT/6qPFSf3HapngU+P4+mv+u7rlpb1AIpAWTET8ty5f2rrKRdQfh7lvjQ==", "700237ec-d707-4dd7-a810-796062303b65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9986b3eb-1b52-4956-a623-53413792571b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81bb5d96-539b-44af-b43b-33396b5e4820", "AQAAAAEAACcQAAAAEKP2FEpYYu8sbYG3CwQzvgfmS1OV/o45rcqwiTVhYER1ZjKDK7Pfsc9GcW2d6CIZnw==", "e1feb593-62fe-4602-bedd-05884cf281d3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "LeaveAllocations");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8672398c-fd30-4181-acc1-f89651e3da1a", "AQAAAAEAACcQAAAAEIRzF8Ij7EBd4mfRmgROUz7Mnssd99eRzQASmBKYAPNhTB103p7yFCtdD3Ua2uPTDw==", "253982cf-1d44-4814-9b9d-2ab7db9e548f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9986b3eb-1b52-4956-a623-53413792571b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92c02e51-919b-4158-a592-5c2fa673279b", "AQAAAAEAACcQAAAAEJh/BunAUhKpLazN1ByFUtSbkFXbe/BsEhXUqmUmXvxH0kzE/KqhIZ8O1F1L2sgjrw==", "64d780f1-abc4-4ac7-85b0-8d73d6e224fc" });
        }
    }
}
