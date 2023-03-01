using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class JobTeamMembersTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMember_positions_PositionId",
                table: "TeamMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember");

            migrationBuilder.RenameTable(
                name: "TeamMember",
                newName: "JonTeamMembers");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMember_PositionId",
                table: "JonTeamMembers",
                newName: "IX_JonTeamMembers_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JonTeamMembers",
                table: "JonTeamMembers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JonTeamMembers_positions_PositionId",
                table: "JonTeamMembers",
                column: "PositionId",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JonTeamMembers_positions_PositionId",
                table: "JonTeamMembers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JonTeamMembers",
                table: "JonTeamMembers");

            migrationBuilder.RenameTable(
                name: "JonTeamMembers",
                newName: "TeamMember");

            migrationBuilder.RenameIndex(
                name: "IX_JonTeamMembers_PositionId",
                table: "TeamMember",
                newName: "IX_TeamMember_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamMember",
                table: "TeamMember",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMember_positions_PositionId",
                table: "TeamMember",
                column: "PositionId",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
