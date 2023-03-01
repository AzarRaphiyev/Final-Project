using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class UpdateJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FecebookUrl",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "LinkedinUrl",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "Jobs");

            migrationBuilder.AlterColumn<long>(
                name: "Order",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "MaxSalary",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MinSalary",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Jobs",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Vacancy",
                table: "Jobs",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxSalary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "MinSalary",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Vacancy",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "Order",
                table: "Jobs",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "FecebookUrl",
                table: "Jobs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Jobs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LinkedinUrl",
                table: "Jobs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Jobs",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "Jobs",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
