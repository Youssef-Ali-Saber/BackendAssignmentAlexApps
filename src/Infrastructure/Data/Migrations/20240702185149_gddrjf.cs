using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class gddrjf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "880045fb-a84a-4782-be0a-20be174da75e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aff18453-2629-4253-b51a-24be00f63ea3");

            migrationBuilder.RenameColumn(
                name: "VATValue",
                table: "Stores",
                newName: "VATRate");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Stores",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ae13ba52-0c23-48d2-8eab-e3fba3de704b", "3422ec32-7b08-4ec3-98a2-e50c9bbe1582", "User", "USER" },
                    { "b901b6b0-5d84-4c3c-a9af-7186be6e86dd", "6925f424-5dc8-466e-968e-63abd2339350", "Merchant", "MERCHANT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae13ba52-0c23-48d2-8eab-e3fba3de704b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b901b6b0-5d84-4c3c-a9af-7186be6e86dd");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "VATRate",
                table: "Stores",
                newName: "VATValue");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "880045fb-a84a-4782-be0a-20be174da75e", "2938d7e1-cc90-40af-9dff-3c2c27049989", "Merchant", "MERCHANT" },
                    { "aff18453-2629-4253-b51a-24be00f63ea3", "c40008b4-1824-4649-8fa8-e9afe029a792", "User", "USER" }
                });
        }
    }
}
