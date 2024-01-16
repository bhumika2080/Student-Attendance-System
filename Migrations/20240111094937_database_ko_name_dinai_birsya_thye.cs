using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Attendance_System.Migrations
{
    public partial class database_ko_name_dinai_birsya_thye : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursesPickerid",
                table: "Dashboard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "snpStudentNamePickerID",
                table: "Dashboard",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_CoursesPickerid",
                table: "Dashboard",
                column: "CoursesPickerid");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_snpStudentNamePickerID",
                table: "Dashboard",
                column: "snpStudentNamePickerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboard_CoursesPicker_CoursesPickerid",
                table: "Dashboard",
                column: "CoursesPickerid",
                principalTable: "CoursesPicker",
                principalColumn: "CoursesPickerid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dashboard_StudentNamePicker_snpStudentNamePickerID",
                table: "Dashboard",
                column: "snpStudentNamePickerID",
                principalTable: "StudentNamePicker",
                principalColumn: "StudentNamePickerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboard_CoursesPicker_CoursesPickerid",
                table: "Dashboard");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboard_StudentNamePicker_snpStudentNamePickerID",
                table: "Dashboard");

            migrationBuilder.DropIndex(
                name: "IX_Dashboard_CoursesPickerid",
                table: "Dashboard");

            migrationBuilder.DropIndex(
                name: "IX_Dashboard_snpStudentNamePickerID",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "CoursesPickerid",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "snpStudentNamePickerID",
                table: "Dashboard");
        }
    }
}
