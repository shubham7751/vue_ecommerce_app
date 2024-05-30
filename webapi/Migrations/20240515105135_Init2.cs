using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class Init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolesTable",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0653ab06-6804-4fe1-aecd-15a3abcb3c96", null, "User", null },
                    { "555fe7ce-ff3f-48a5-b7ed-264f4b6197e0", null, "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesTable",
                keyColumn: "Id",
                keyValue: "0653ab06-6804-4fe1-aecd-15a3abcb3c96");

            migrationBuilder.DeleteData(
                table: "RolesTable",
                keyColumn: "Id",
                keyValue: "555fe7ce-ff3f-48a5-b7ed-264f4b6197e0");
        }
    }
}
