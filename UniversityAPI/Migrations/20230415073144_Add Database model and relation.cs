using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityAPI.Migrations
{
    public partial class AddDatabasemodelandrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTb_DepartmentTb_DepartmentId",
                table: "StudentTb");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "StudentTb",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DayTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DesignationTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeLetterTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeLetterMarkes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeLetterTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SemesterTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterTb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TeacherTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CreditToBeTaken = table.Column<double>(type: "float", nullable: false),
                    RemainingCredit = table.Column<double>(type: "float", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherTb_DepartmentTb_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherTb_DesignationTb_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "DesignationTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credit = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Action = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseTb_DepartmentTb_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseTb_SemesterTb_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "SemesterTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllocateClassTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocateClassTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllocateClassTb_CourseTb_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllocateClassTb_DayTb_DayId",
                        column: x => x.DayId,
                        principalTable: "DayTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllocateClassTb_DepartmentTb_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AllocateClassTb_RoomTb_RoomId",
                        column: x => x.RoomId,
                        principalTable: "RoomTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssignTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssignTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseAssignTb_CourseTb_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseAssignTb_DepartmentTb_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "DepartmentTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseAssignTb_TeacherTb_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "TeacherTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnrollCourseTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollCourseTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollCourseTb_CourseTb_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnrollCourseTb_StudentTb_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentResultTb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    GradeLetterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentResultTb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentResultTb_CourseTb_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CourseTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentResultTb_GradeLetterTb_GradeLetterId",
                        column: x => x.GradeLetterId,
                        principalTable: "GradeLetterTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentResultTb_StudentTb_StudentId",
                        column: x => x.StudentId,
                        principalTable: "StudentTb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassTb_CourseId",
                table: "AllocateClassTb",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassTb_DayId",
                table: "AllocateClassTb",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassTb_DepartmentId",
                table: "AllocateClassTb",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AllocateClassTb_RoomId",
                table: "AllocateClassTb",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignTb_CourseId",
                table: "CourseAssignTb",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignTb_DepartmentId",
                table: "CourseAssignTb",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssignTb_TeacherId",
                table: "CourseAssignTb",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTb_DepartmentId",
                table: "CourseTb",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTb_SemesterId",
                table: "CourseTb",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollCourseTb_CourseId",
                table: "EnrollCourseTb",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollCourseTb_StudentId",
                table: "EnrollCourseTb",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResultTb_CourseId",
                table: "StudentResultTb",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResultTb_GradeLetterId",
                table: "StudentResultTb",
                column: "GradeLetterId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentResultTb_StudentId",
                table: "StudentResultTb",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTb_DepartmentId",
                table: "TeacherTb",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTb_DesignationId",
                table: "TeacherTb",
                column: "DesignationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTb_DepartmentTb_DepartmentId",
                table: "StudentTb",
                column: "DepartmentId",
                principalTable: "DepartmentTb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTb_DepartmentTb_DepartmentId",
                table: "StudentTb");

            migrationBuilder.DropTable(
                name: "AllocateClassTb");

            migrationBuilder.DropTable(
                name: "CourseAssignTb");

            migrationBuilder.DropTable(
                name: "EnrollCourseTb");

            migrationBuilder.DropTable(
                name: "StudentResultTb");

            migrationBuilder.DropTable(
                name: "DayTb");

            migrationBuilder.DropTable(
                name: "RoomTb");

            migrationBuilder.DropTable(
                name: "TeacherTb");

            migrationBuilder.DropTable(
                name: "CourseTb");

            migrationBuilder.DropTable(
                name: "GradeLetterTb");

            migrationBuilder.DropTable(
                name: "DesignationTb");

            migrationBuilder.DropTable(
                name: "SemesterTb");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "StudentTb",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTb_DepartmentTb_DepartmentId",
                table: "StudentTb",
                column: "DepartmentId",
                principalTable: "DepartmentTb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
