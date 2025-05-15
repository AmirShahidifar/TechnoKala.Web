using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnoKala.DaytaLayer.Migrations
{
    /// <inheritdoc />
    public partial class fix_blog_blogtext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // ابتدا ستون جدید را اضافه می‌کنیم
            migrationBuilder.AddColumn<string>(
                name: "blog_text",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            // داده‌های طولانی description را به blog_text منتقل می‌کنیم
            migrationBuilder.Sql(@"
                UPDATE blogs 
                SET blog_text = description
                WHERE LEN(description) > 30;
            ");

            // داده‌های description را به 30 کاراکتر اول محدود می‌کنیم
            migrationBuilder.Sql(@"
                UPDATE blogs 
                SET description = LEFT(description, 30)
                WHERE LEN(description) > 30;
            ");

            // حالا می‌توانیم نوع ستون description را تغییر دهیم
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "blogs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "blogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            // در صورت بازگشت، محتوای blog_text را به description منتقل می‌کنیم
            migrationBuilder.Sql(@"
                UPDATE blogs 
                SET description = blog_text
                WHERE blog_text <> '';
            ");

            migrationBuilder.DropColumn(
                name: "blog_text",
                table: "blogs");
        }
    }
}