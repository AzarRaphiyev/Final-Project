using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class CatagoryTableUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_catagories_catagories_CatagoryId",
                table: "catagories");

            migrationBuilder.DropIndex(
                name: "IX_catagories_CatagoryId",
                table: "catagories");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "catagories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "catagories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_catagories_CatagoryId",
                table: "catagories",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_catagories_catagories_CatagoryId",
                table: "catagories",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id");
        }
    }
}
