using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SERPRankingApp.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SearchResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SearchTerm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RankResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SearchDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchResults", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SearchResults",
                columns: new[] { "Id", "RankResults", "SearchDate", "SearchTerm", "TargetUrl" },
                values: new object[,]
                {
                    { 1, "[1,2,3]", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Land", "https://www.infotrack.co.uk" },
                    { 2, "[1,4,5]", new DateTime(2025, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Info", "https://www.infotrack.co.uk" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchResults");
        }
    }
}
