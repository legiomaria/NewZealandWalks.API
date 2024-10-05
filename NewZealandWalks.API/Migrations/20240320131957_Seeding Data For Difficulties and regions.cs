using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewZealandWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("3b9a4379-7da3-4355-ae29-6a2397e19a0b"), "Medium" },
                    { new Guid("52ce5d3d-57f8-4de5-9824-792397e14697"), "Easy" },
                    { new Guid("8e0cbae9-c25d-4293-888b-5aa9fd4b3b61"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("19aa4a46-7e2c-4596-bde3-3268a7a6823e"), "WGN", "Wellington", "https://unsplash.com/photos/mountain-near-body-of-water-during-daytime-LZVmvKlchM0" },
                    { new Guid("33ad922a-0505-4859-b76e-d43d6ca48ccf"), "BOP", "Bay of plenty", null },
                    { new Guid("33e7f348-0d4e-41e1-801b-35f78df64c4f"), "NSN", "Nelson", "https://unsplash.com/photos/mountains-covered-with-snow-near-road-75_s8iWHKLs" },
                    { new Guid("aca28b41-818d-4e31-9a93-7d4728d26e21"), "AKL", "Auckland", "https://unsplash.com/photos/cityscape-photo-during-daytime-hIKVSVKH7No" },
                    { new Guid("b7879ce9-aca7-435f-b0e9-7960f7c11d6a"), "STL", "Southland", null },
                    { new Guid("eef803ba-b4e8-4bda-a218-b2086a309b4a"), "NTL", "Northland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3b9a4379-7da3-4355-ae29-6a2397e19a0b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("52ce5d3d-57f8-4de5-9824-792397e14697"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8e0cbae9-c25d-4293-888b-5aa9fd4b3b61"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("19aa4a46-7e2c-4596-bde3-3268a7a6823e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("33ad922a-0505-4859-b76e-d43d6ca48ccf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("33e7f348-0d4e-41e1-801b-35f78df64c4f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("aca28b41-818d-4e31-9a93-7d4728d26e21"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b7879ce9-aca7-435f-b0e9-7960f7c11d6a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("eef803ba-b4e8-4bda-a218-b2086a309b4a"));
        }
    }
}
