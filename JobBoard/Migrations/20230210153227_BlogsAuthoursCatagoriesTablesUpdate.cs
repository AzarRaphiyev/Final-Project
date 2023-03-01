using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class BlogsAuthoursCatagoriesTablesUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "catagories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthourId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CatagoryId",
                table: "blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_catagories_CatagoryId",
                table: "catagories",
                column: "CatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_AuthourId",
                table: "blogs",
                column: "AuthourId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_CatagoryId",
                table: "blogs",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_authours_AuthourId",
                table: "blogs",
                column: "AuthourId",
                principalTable: "authours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_blogs_catagories_CatagoryId",
                table: "blogs",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_catagories_catagories_CatagoryId",
                table: "catagories",
                column: "CatagoryId",
                principalTable: "catagories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_blogs_authours_AuthourId",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_blogs_catagories_CatagoryId",
                table: "blogs");

            migrationBuilder.DropForeignKey(
                name: "FK_catagories_catagories_CatagoryId",
                table: "catagories");

            migrationBuilder.DropIndex(
                name: "IX_catagories_CatagoryId",
                table: "catagories");

            migrationBuilder.DropIndex(
                name: "IX_blogs_AuthourId",
                table: "blogs");

            migrationBuilder.DropIndex(
                name: "IX_blogs_CatagoryId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "catagories");

            migrationBuilder.DropColumn(
                name: "AuthourId",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "CatagoryId",
                table: "blogs");
        }
    }
}
