using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Attendance_System.Migrations
{
    public partial class newAttendanceDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceData_Course_CourseID",
                table: "AttendanceData");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceData_Level_LevelID",
                table: "AttendanceData");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceData_RegisterStudent_StudentID",
                table: "AttendanceData");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "AttendanceData",
                newName: "StudentName");

            migrationBuilder.RenameColumn(
                name: "LevelID",
                table: "AttendanceData",
                newName: "LevelName");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "AttendanceData",
                newName: "CourseName");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceData_StudentID",
                table: "AttendanceData",
                newName: "IX_AttendanceData_StudentName");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceData_LevelID",
                table: "AttendanceData",
                newName: "IX_AttendanceData_LevelName");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceData_CourseID",
                table: "AttendanceData",
                newName: "IX_AttendanceData_CourseName");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceData_Course_CourseName",
                table: "AttendanceData",
                column: "CourseName",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceData_Level_LevelName",
                table: "AttendanceData",
                column: "LevelName",
                principalTable: "Level",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceData_RegisterStudent_StudentName",
                table: "AttendanceData",
                column: "StudentName",
                principalTable: "RegisterStudent",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceData_Course_CourseName",
                table: "AttendanceData");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceData_Level_LevelName",
                table: "AttendanceData");

            migrationBuilder.DropForeignKey(
                name: "FK_AttendanceData_RegisterStudent_StudentName",
                table: "AttendanceData");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "AttendanceData",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "LevelName",
                table: "AttendanceData",
                newName: "LevelID");

            migrationBuilder.RenameColumn(
                name: "CourseName",
                table: "AttendanceData",
                newName: "CourseID");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceData_StudentName",
                table: "AttendanceData",
                newName: "IX_AttendanceData_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceData_LevelName",
                table: "AttendanceData",
                newName: "IX_AttendanceData_LevelID");

            migrationBuilder.RenameIndex(
                name: "IX_AttendanceData_CourseName",
                table: "AttendanceData",
                newName: "IX_AttendanceData_CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceData_Course_CourseID",
                table: "AttendanceData",
                column: "CourseID",
                principalTable: "Course",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceData_Level_LevelID",
                table: "AttendanceData",
                column: "LevelID",
                principalTable: "Level",
                principalColumn: "LevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AttendanceData_RegisterStudent_StudentID",
                table: "AttendanceData",
                column: "StudentID",
                principalTable: "RegisterStudent",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
