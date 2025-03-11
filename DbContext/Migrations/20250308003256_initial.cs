using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education_Center_DbContext.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // إضافة مفتاح خارجي لربط AspNetUsers بـ Branches
            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_Branch_id", // اسم المفتاح الخارجي
                table: "AspNetUsers", // الجدول الذي يحتوي على المفتاح الخارجي
                column: "Branch_id", // العمود في جدول AspNetUsers
                principalTable: "Branches", // الجدول الرئيسي
                principalColumn: "Id", // العمود في الجدول الرئيسي
                onDelete: ReferentialAction.Restrict); // الإجراء عند الحذف
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // إزالة المفتاح الخارجي
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_Branch_id", // اسم المفتاح الخارجي
                table: "AspNetUsers"); // الجدول الذي يحتوي على المفتاح الخارجي
        }
    }
}



