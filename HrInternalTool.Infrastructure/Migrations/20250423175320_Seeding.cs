using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HrInternalTool.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "DateOfJoining", "Department", "Email", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "John@abc.com", true, "John" },
                    { 2, new DateTime(2022, 12, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Chris@abc.com", true, "Chris" },
                    { 3, new DateTime(2024, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Albert@abc.com", true, "Albert" }
                });

            migrationBuilder.InsertData(
                table: "PerformanceReviews",
                columns: new[] { "Id", "Comments", "EmployeeId", "ReviewDate", "Reviewer", "Score" },
                values: new object[,]
                {
                    { 1, "Great work", 1, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 2.5 },
                    { 2, "Great work", 1, new DateTime(2025, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", 4.0 },
                    { 3, "Great work", 2, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steph", 2.5 },
                    { 4, "Great work", 2, new DateTime(2025, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Steph", 3.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PerformanceReviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PerformanceReviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PerformanceReviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PerformanceReviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
