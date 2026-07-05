using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University_system.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "instructors",
                columns: table => new
                {
                    instructorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    officeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    hireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    academicTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    instructorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_instructors", x => x.instructorId);
                    table.ForeignKey(
                        name: "FK_instructors_instructors_instructorId1",
                        column: x => x.instructorId1,
                        principalTable: "instructors",
                        principalColumn: "instructorId");
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    stusentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    phoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enrollmentYear = table.Column<int>(type: "int", nullable: false),
                    gpa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.stusentId);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    departmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    departmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    building = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    headOfInstructorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.departmentId);
                    table.ForeignKey(
                        name: "FK_departments_instructors_headOfInstructorId",
                        column: x => x.headOfInstructorId,
                        principalTable: "instructors",
                        principalColumn: "instructorId");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    courseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    courseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    courseTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    creditHours = table.Column<int>(type: "int", nullable: false),
                    departmentId = table.Column<int>(type: "int", nullable: false),
                    instructorId = table.Column<int>(type: "int", nullable: true),
                    semesterOffered = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.courseId);
                    table.ForeignKey(
                        name: "FK_Courses_departments_departmentId",
                        column: x => x.departmentId,
                        principalTable: "departments",
                        principalColumn: "departmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Courses_instructors_instructorId",
                        column: x => x.instructorId,
                        principalTable: "instructors",
                        principalColumn: "instructorId");
                });

            migrationBuilder.CreateTable(
                name: "CourseStudent",
                columns: table => new
                {
                    CoursescourseId = table.Column<int>(type: "int", nullable: false),
                    StudentsstusentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudent", x => new { x.CoursescourseId, x.StudentsstusentId });
                    table.ForeignKey(
                        name: "FK_CourseStudent_Courses_CoursescourseId",
                        column: x => x.CoursescourseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseStudent_students_StudentsstusentId",
                        column: x => x.StudentsstusentId,
                        principalTable: "students",
                        principalColumn: "stusentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    finalGrade = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "courseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollments_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "stusentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_departmentId",
                table: "Courses",
                column: "departmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_instructorId",
                table: "Courses",
                column: "instructorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudent_StudentsstusentId",
                table: "CourseStudent",
                column: "StudentsstusentId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_headOfInstructorId",
                table: "departments",
                column: "headOfInstructorId",
                unique: true,
                filter: "[headOfInstructorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_CourseId",
                table: "enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_StudentId",
                table: "enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_instructors_instructorId1",
                table: "instructors",
                column: "instructorId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudent");

            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "instructors");
        }
    }
}
