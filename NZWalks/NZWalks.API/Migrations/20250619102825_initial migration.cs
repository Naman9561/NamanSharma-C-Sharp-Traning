using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Difficulties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Difficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Walks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthInkm = table.Column<double>(type: "float", nullable: false),
                    WalkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Walks_Difficulties_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "Difficulties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Walks_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("79416f6b-6c8d-4dd0-a2ed-2ab26ffa3d2b"), "Hard" },
                    { new Guid("a5aa266e-eb88-4152-b511-739d2b73beb4"), "Easy" },
                    { new Guid("f54972a4-0bb2-4687-99aa-6875c2a9388e"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "NI", "North Island", "https://example.com/north-island.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "SI", "South Island", "https://example.com/south-island.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "SI", "Stewart Island", "https://example.com/stewart-island.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "CI", "Chatham Islands", "https://example.com/chatham-islands.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "KI", "Kermadec Islands", "https://example.com/kermadec-islands.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "AI", "Auckland Islands", "https://example.com/auckland-islands.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "BI", "Bounty Islands", "https://example.com/bounty-islands.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "AI", "Antipodes Islands", "https://example.com/antipodes-islands.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "SI", "Snares Islands", "https://example.com/snares-islands.jpg" },
                    { new Guid("10000000-0000-0000-0000-000000000010"), "CI", "Campbell Island", "https://example.com/campbell-island.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walks_DifficultyId",
                table: "Walks",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Walks_RegionId",
                table: "Walks",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walks");

            migrationBuilder.DropTable(
                name: "Difficulties");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
