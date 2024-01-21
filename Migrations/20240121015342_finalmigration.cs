using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Attendance_System.Migrations
{
    public partial class finalmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendanceData");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttendanceData",
                columns: table => new
                {
                    AttendanceDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<int>(type: "int", nullable: false),
                    LevelName = table.Column<int>(type: "int", nullable: false),
                    StudentName = table.Column<int>(type: "int", nullable: false),
                    AttendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPresentToday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceData", x => x.AttendanceDataId);
                    table.ForeignKey(
                        name: "FK_AttendanceData_Course_CourseName",
                        column: x => x.CourseName,
                        principalTable: "Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceData_Level_LevelName",
                        column: x => x.LevelName,
                        principalTable: "Level",
                        principalColumn: "LevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceData_RegisterStudent_StudentName",
                        column: x => x.StudentName,
                        principalTable: "RegisterStudent",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceData_CourseName",
                table: "AttendanceData",
                column: "CourseName");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceData_LevelName",
                table: "AttendanceData",
                column: "LevelName");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceData_StudentName",
                table: "AttendanceData",
                column: "StudentName");
        }
    }
}
