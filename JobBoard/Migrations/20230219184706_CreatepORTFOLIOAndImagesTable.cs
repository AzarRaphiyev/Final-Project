using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class CreatepORTFOLIOAndImagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "portfolioItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    poerfolioCatagoriesId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    YearStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Client = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WebUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioItems_JonTeamMembers_TeamId",
                        column: x => x.TeamId,
                        principalTable: "JonTeamMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_portfolioItems_poerfolioCatagories_poerfolioCatagoriesId",
                        column: x => x.poerfolioCatagoriesId,
                        principalTable: "poerfolioCatagories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "portfolioItemImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortfolioItemId = table.Column<int>(type: "int", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsPoster = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_portfolioItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_portfolioItemImages_portfolioItems_PortfolioItemId",
                        column: x => x.PortfolioItemId,
                        principalTable: "portfolioItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_portfolioItemImages_PortfolioItemId",
                table: "portfolioItemImages",
                column: "PortfolioItemId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioItems_poerfolioCatagoriesId",
                table: "portfolioItems",
                column: "poerfolioCatagoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_portfolioItems_TeamId",
                table: "portfolioItems",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "portfolioItemImages");

            migrationBuilder.DropTable(
                name: "portfolioItems");
        }
    }
}
