using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonService.Migrations
{
    /// <inheritdoc />
    public partial class two_default_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Address", "Name", "Work" },
                values: new object[] { "Default Address 1", "Default Name 1", "Default Work 1" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Address", "Age", "Name", "Work" },
                values: new object[] { 2L, "Default Address 2", 20, "Default Name 2", "Default Work 2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.UpdateData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "Address", "Name", "Work" },
                values: new object[] { "Default Address", "Default Name", "Default Work" });
        }
    }
}
