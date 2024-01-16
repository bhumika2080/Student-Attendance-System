using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Attendance_System.Migrations
{
    public partial class was_desperate_so_gaveup_on_dropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dashboard_CoursesPicker_CoursesPickerid",
                table: "Dashboard");

            migrationBuilder.DropForeignKey(
                name: "FK_Dashboard_StudentNamePicker_snpStudentNamePickerID",
                table: "Dashboard");

            migrationBuilder.DropTable(
                name: "CoursesPicker");

            migrationBuilder.DropTable(
                name: "StudentNamePicker");

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

            migrationBuilder.AddColumn<string>(
                name: "SelectCourses",
                table: "Dashboard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectStudent",
                table: "Dashboard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectCourses",
                table: "Dashboard");

            migrationBuilder.DropColumn(
                name: "SelectStudent",
                table: "Dashboard");

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
                    Dashboardid = table.Column<int>(type: "int", nullable: true),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "IX_Dashboard_CoursesPickerid",
                table: "Dashboard",
                column: "CoursesPickerid");

            migrationBuilder.CreateIndex(
                name: "IX_Dashboard_snpStudentNamePickerID",
                table: "Dashboard",
                column: "snpStudentNamePickerID");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesPicker_Dashboardid",
                table: "CoursesPicker",
                column: "Dashboardid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentNamePicker_Dashboardid",
                table: "StudentNamePicker",
                column: "Dashboardid");

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
    }
}
