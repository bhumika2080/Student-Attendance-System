using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Attendance_System.Migrations
{
    public partial class initial_without_logic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dashboard",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isPresent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dashboard", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CoursesPicker",
                columns: table => new
                {
                    CoursesPickerid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Courses = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dashboardid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesPicker", x => x.CoursesPickerid);
                    table.ForeignKey(
                        name: "FK_CoursesPicker_Dashboard_Dashboardid",
                        column: x => x.Dashboardid,
                        principalTable: "Dashboard",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StudentNamePicker",
                columns: table => new
                {
                    StudentNamePickerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dashboardid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentNamePicker", x => x.StudentNamePickerID);
                    table.ForeignKey(
                        name: "FK_StudentNamePicker_Dashboard_Dashboardid",
                        column: x => x.Dashboardid,
                        principalTable: "Dashboard",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesPicker_Dashboardid",
                table: "CoursesPicker",
                column: "Dashboardid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNamePicker_Dashboardid",
                table: "StudentNamePicker",
                column: "Dashboardid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoursesPicker");

            migrationBuilder.DropTable(
                name: "StudentNamePicker");

            migrationBuilder.DropTable(
                name: "Dashboard");
        }
    }
}
