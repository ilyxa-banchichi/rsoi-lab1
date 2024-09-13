using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PersonService.Migrations
{
    /// <inheritdoc />
    public partial class removed_default_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Age", "Name", "Work" },
                values: new object[,]
                {
                    { 1L, "Default Address 1", 10, "Default Name 1", "Default Work 1" },
                    { 2L, "Default Address 2", 20, "Default Name 2", "Default Work 2" }
                });
        }
    }
}
