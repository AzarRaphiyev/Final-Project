using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    public partial class CraeteJobTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    JobTypeId = table.Column<int>(type: "int", nullable: false),
                    JobRegionId = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", maxLength: 40, nullable: false),
                    ApplicationDeadline = table.Column<DateTime>(type: "datetime2", maxLength: 40, nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Experince = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Responsibilities = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EduExperience = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    OutherBenifits = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    InstagramUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FecebookUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TwitterUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LinkedinUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_jobTypes_JobTypeId",
                        column: x => x.JobTypeId,
                        principalTable: "jobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Regions_JobRegionId",
                        column: x => x.JobRegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_CompanyId",
                table: "Jobs",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_GenderId",
                table: "Jobs",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobRegionId",
                table: "Jobs",
                column: "JobRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobTypeId",
                table: "Jobs",
                column: "JobTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
