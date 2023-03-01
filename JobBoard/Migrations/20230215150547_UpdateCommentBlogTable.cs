using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class UpdateCommentBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "commentBlogs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "commentBlogs",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "commentBlogs");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "commentBlogs");
        }
    }
}
