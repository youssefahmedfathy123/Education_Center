using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_Center_DbContext.Migrations
{
    /// <inheritdoc />
    public partial class s : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionAttendance_AspNetUsers_Recorded_by",
                table: "SessionAttendance");

            migrationBuilder.AlterColumn<string>(
                name: "Student_id",
                table: "SessionAttendance",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Recorded_by",
                table: "SessionAttendance",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAttendance_AspNetUsers_Recorded_by",
                table: "SessionAttendance",
                column: "Recorded_by",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SessionAttendance_AspNetUsers_Recorded_by",
                table: "SessionAttendance");

            migrationBuilder.AlterColumn<string>(
                name: "Student_id",
                table: "SessionAttendance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Recorded_by",
                table: "SessionAttendance",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SessionAttendance_AspNetUsers_Recorded_by",
                table: "SessionAttendance",
                column: "Recorded_by",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
