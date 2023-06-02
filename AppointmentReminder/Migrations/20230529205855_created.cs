using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAppointmentReminder.Migrations
{
    public partial class created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9963774-321f-44b0-be0f-f68731746641", "7d3f2e8a-652c-4166-8b45-1b461556ee98", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8c3b823-6c26-4048-84b8-bd8a6c508bf7", "e8e54268-0216-4228-89e8-62282f9f664d", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9963774-321f-44b0-be0f-f68731746641");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8c3b823-6c26-4048-84b8-bd8a6c508bf7");
        }
    }
}
