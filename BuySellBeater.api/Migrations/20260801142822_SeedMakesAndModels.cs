using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuySellBeater.api.Migrations
{
    /// <inheritdoc />
    public partial class SeedMakesAndModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Isuzu" },
                    { 2, "Nissan" },
                    { 3, "Honda" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Pup" },
                    { 2, 1, "Impulse" },
                    { 3, 1, "Trooper" },
                    { 4, 2, "Sentra" },
                    { 5, 2, "300ZX" },
                    { 6, 2, "XTerra" },
                    { 7, 3, "CRX" },
                    { 8, 3, "Civic" },
                    { 9, 3, "Prelude" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
