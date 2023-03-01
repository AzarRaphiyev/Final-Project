using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class updatecontacttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "Contacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "Contacts");
        }
    }
}
