using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_Center_DbContext.Migrations
{
    /// <inheritdoc />
    public partial class removeTeacherIdfromGradeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_AspNetUsers_Teacher_id",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_GradeTypes_Grade_type_id",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_Subject_id",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_Teacher_id",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "Teacher_id",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "Subject_id",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Student_id",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Grade_type_id",
                table: "Grades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Grades",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_UserId",
                table: "Grades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_AspNetUsers_UserId",
                table: "Grades",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_GradeTypes_Grade_type_id",
                table: "Grades",
                column: "Grade_type_id",
                principalTable: "GradeTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_Subject_id",
                table: "Grades",
                column: "Subject_id",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_AspNetUsers_UserId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_GradeTypes_Grade_type_id",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Subjects_Subject_id",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_UserId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Grades");

            migrationBuilder.AlterColumn<int>(
                name: "Subject_id",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Student_id",
                table: "Grades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Grade_type_id",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Teacher_id",
                table: "Grades",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_Teacher_id",
                table: "Grades",
                column: "Teacher_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_AspNetUsers_Teacher_id",
                table: "Grades",
                column: "Teacher_id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_GradeTypes_Grade_type_id",
                table: "Grades",
                column: "Grade_type_id",
                principalTable: "GradeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Subjects_Subject_id",
                table: "Grades",
                column: "Subject_id",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
