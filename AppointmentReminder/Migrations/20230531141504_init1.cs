using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiAppointmentReminder.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e9963774-321f-44b0-be0f-f68731746641");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8c3b823-6c26-4048-84b8-bd8a6c508bf7");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppointmentCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f3c5df73-0d7b-4645-8a74-f11d38402b57", "5e9a7833-b1b2-4457-9dc3-8ac13e909b9c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f6630484-f469-4efc-8977-f290d3ec08a2", "36ea1b1f-033a-4ba2-912b-42140bba084f", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_UserId",
                table: "Appointments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3c5df73-0d7b-4645-8a74-f11d38402b57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6630484-f469-4efc-8977-f290d3ec08a2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9963774-321f-44b0-be0f-f68731746641", "7d3f2e8a-652c-4166-8b45-1b461556ee98", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f8c3b823-6c26-4048-84b8-bd8a6c508bf7", "e8e54268-0216-4228-89e8-62282f9f664d", "Admin", "ADMIN" });
        }
    }
}
