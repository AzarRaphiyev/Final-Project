using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class addPositionandmembercolm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "positions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jobname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_positions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TeamMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Positionİd = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Fulname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    InstagramUlr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FecebookUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Positionid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers_positions_Positionid",
                        column: x => x.Positionid,
                        principalTable: "positions",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers_Positionid",
                table: "TeamMembers",
                column: "Positionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMembers");

            migrationBuilder.DropTable(
                name: "positions");
        }
    }
}
