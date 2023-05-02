using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityAPI.Migrations
{
    public partial class addstudentrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TeacherTb",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "StudentTb",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "AllocateClassTb",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTb_UserId",
                table: "TeacherTb",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTb_UserId",
                table: "StudentTb",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTb_AspNetUsers_UserId",
                table: "StudentTb",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherTb_AspNetUsers_UserId",
                table: "TeacherTb",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTb_AspNetUsers_UserId",
                table: "StudentTb");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherTb_AspNetUsers_UserId",
                table: "TeacherTb");

            migrationBuilder.DropIndex(
                name: "IX_TeacherTb_UserId",
                table: "TeacherTb");

            migrationBuilder.DropIndex(
                name: "IX_StudentTb_UserId",
                table: "StudentTb");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TeacherTb");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentTb");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "AllocateClassTb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
