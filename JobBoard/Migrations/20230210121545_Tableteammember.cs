using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class Tableteammember : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_positions_Positionid",
                table: "TeamMembers");

            migrationBuilder.DropColumn(
                name: "PositionİD",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "Positionid",
                table: "TeamMembers",
                newName: "PositionId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TeamMembers",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Fulname",
                table: "TeamMembers",
                newName: "Fullname");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_Positionid",
                table: "TeamMembers",
                newName: "IX_TeamMembers_PositionId");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "TeamMembers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_positions_PositionId",
                table: "TeamMembers",
                column: "PositionId",
                principalTable: "positions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TeamMembers_positions_PositionId",
                table: "TeamMembers");

            migrationBuilder.RenameColumn(
                name: "PositionId",
                table: "TeamMembers",
                newName: "Positionid");

            migrationBuilder.RenameColumn(
                name: "Fullname",
                table: "TeamMembers",
                newName: "Fulname");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TeamMembers",
                newName: "Title");

            migrationBuilder.RenameIndex(
                name: "IX_TeamMembers_PositionId",
                table: "TeamMembers",
                newName: "IX_TeamMembers_Positionid");

            migrationBuilder.AlterColumn<int>(
                name: "Positionid",
                table: "TeamMembers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PositionİD",
                table: "TeamMembers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TeamMembers_positions_Positionid",
                table: "TeamMembers",
                column: "Positionid",
                principalTable: "positions",
                principalColumn: "id");
        }
    }
}
