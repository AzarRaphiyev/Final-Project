using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class TeamMemberTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMembers2");

            migrationBuilder.CreateTable(
                name: "TeamMember",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    InstagramUlr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FecebookUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMember_positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMember_PositionId",
                table: "TeamMember",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamMember");

            migrationBuilder.CreateTable(
                name: "TeamMembers2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FecebookUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InstagramUlr = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Order = table.Column<int>(type: "int", nullable: false),
                    TwitterUrl = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamMembers2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamMembers2_positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "positions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamMembers2_PositionId",
                table: "TeamMembers2",
                column: "PositionId");
        }
    }
}
