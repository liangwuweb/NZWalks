using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeeddatafroDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("089db1e9-4042-40e9-86eb-cfc54af2564a"), "Medium" },
                    { new Guid("823ac9eb-67f5-4218-ad6f-569eb1577dbc"), "Hard" },
                    { new Guid("cf485d88-a013-42b2-9dbc-3844bec54d1c"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("27c62abc-9a69-449a-91e9-60ebdda21b5d"), "BOP", "Bay Of Plenty", "https://unsplash.com/photos/tltoIabpBT8" },
                    { new Guid("7aa65464-9432-49e0-a3f6-024052467757"), "STL", "Southland", "https://unsplash.com/photos/uqAUg1zvMXQ" },
                    { new Guid("8ebc4748-ee50-4a70-9f1c-4c819958de05"), "WGN", "Wellington", "https://unsplash.com/photos/1Q3neJv6zHU" },
                    { new Guid("a5c79bc2-82e4-4273-b27b-2c67abe5a6bc"), "NSN", "Nelson", "https://unsplash.com/photos/p4q-Ra__g8M" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("089db1e9-4042-40e9-86eb-cfc54af2564a"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("823ac9eb-67f5-4218-ad6f-569eb1577dbc"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cf485d88-a013-42b2-9dbc-3844bec54d1c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("27c62abc-9a69-449a-91e9-60ebdda21b5d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7aa65464-9432-49e0-a3f6-024052467757"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("8ebc4748-ee50-4a70-9f1c-4c819958de05"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a5c79bc2-82e4-4273-b27b-2c67abe5a6bc"));
        }
    }
}
