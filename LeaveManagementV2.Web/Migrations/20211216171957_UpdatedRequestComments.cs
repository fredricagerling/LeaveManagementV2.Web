using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementV2.Web.Migrations
{
    public partial class UpdatedRequestComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85",
                column: "ConcurrencyStamp",
                value: "23c18a44-9a0f-43e0-93a7-f924bf2ce1f2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb344fc9-5c10-4d57-97fe-2f584d136229",
                column: "ConcurrencyStamp",
                value: "19236b44-27e1-4408-bf1f-95655da3cf9a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "568ba572-f8cd-4add-848b-081d88a6c80e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "59864f6d-0118-40eb-961a-2e47ee6f529c", "AQAAAAEAACcQAAAAEGaKbX2Plb3U4F9yI2jPYM5rXu/7/e3eDIntZDBftM+zK1eDMJAF0k1hKXjb3sBg0A==", "a6cbdc69-25a8-41c6-a5ad-9c8a34de2f47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9986b3eb-1b52-4956-a623-53413792571b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7f8436a-6949-4367-a647-02a4a2171c42", "AQAAAAEAACcQAAAAEM/O9vLBL6OT2qqi5yejUfp41Al0n3PXC0I0tUr5E3iCSPUmM0OdnG2bSfTerJ6uPw==", "d6352a4c-b80e-44d6-9358-401f249eba00" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d84b1e7-db77-4c9d-a225-1da8bb5cdb85",
                column: "ConcurrencyStamp",
                value: "1e4de49d-e2e6-448f-864f-307b2022e3a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb344fc9-5c10-4d57-97fe-2f584d136229",
                column: "ConcurrencyStamp",
                value: "92999717-0f2b-4742-9a12-ba62eff419fd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "568ba572-f8cd-4add-848b-081d88a6c80e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e99d9ab-2c29-439f-8720-fc7029d05fde", "AQAAAAEAACcQAAAAEAPh17yoSGbuZl5qkRYUHOZY6eH2cIPcpdphjrq5q1U6Ta80WVNkjXodqlbJOJJW7g==", "3db01ce6-6294-4944-94b4-609c8f2390a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9986b3eb-1b52-4956-a623-53413792571b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4da71d28-0ed4-455c-87c3-337f435a2ad0", "AQAAAAEAACcQAAAAEOv1s8zZYqUh8okC2lzZtrs6enpdWWvDjbjhsc45ljHWjv1VvaG2WoR2hq+pPoZUTQ==", "c2a5478e-b1da-4d5b-a4b2-efd92fd5602b" });
        }
    }
}
