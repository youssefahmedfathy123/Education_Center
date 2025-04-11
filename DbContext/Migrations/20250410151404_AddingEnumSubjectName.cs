using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_Center_DbContext.Migrations
{
    /// <inheritdoc />
    public partial class AddingEnumSubjectName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "StudentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "StudentSubjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "StudentSubjects");
        }
    }
}
