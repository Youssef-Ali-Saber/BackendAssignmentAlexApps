using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class referjf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "149065c9-4917-443e-ad85-8b68b87b64fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f88a8783-eee8-49f1-b29b-a8fff18757e7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "880045fb-a84a-4782-be0a-20be174da75e", "2938d7e1-cc90-40af-9dff-3c2c27049989", "Merchant", "MERCHANT" },
                    { "aff18453-2629-4253-b51a-24be00f63ea3", "c40008b4-1824-4649-8fa8-e9afe029a792", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "880045fb-a84a-4782-be0a-20be174da75e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aff18453-2629-4253-b51a-24be00f63ea3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "149065c9-4917-443e-ad85-8b68b87b64fe", null, "Merchant", "MERCHANT" },
                    { "f88a8783-eee8-49f1-b29b-a8fff18757e7", null, "User", "USER" }
                });
        }
    }
}
