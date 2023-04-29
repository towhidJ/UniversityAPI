using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityAPI.Migrations
{
    public partial class updateallocateClassGradeLetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "GradePoint",
                table: "GradeLetterTb",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Action",
                table: "AllocateClassTb",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradePoint",
                table: "GradeLetterTb");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "AllocateClassTb");
        }
    }
}
