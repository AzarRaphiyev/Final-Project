using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class TableMembersTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_positions_PositionId",
                table: "TeamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers");

            migrationBuilder.RenameTable(
                name: "TeamMembers",
                newName: "TeamMembers2");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_PositionId",
                table: "TeamMembers2",
                newName: "IX_TeamMembers2_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers2",
                table: "TeamMembers2",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers2_positions_PositionId",
                table: "TeamMembers2",
                column: "PositionId",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers2_positions_PositionId",
                table: "TeamMembers2");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMembers2",
                table: "TeamMembers2");

            migrationBuilder.RenameTable(
                name: "TeamMembers2",
                newName: "TeamMembers");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers2_PositionId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMembers",
                table: "TeamMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_positions_PositionId",
                table: "TeamMembers",
                column: "PositionId",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
