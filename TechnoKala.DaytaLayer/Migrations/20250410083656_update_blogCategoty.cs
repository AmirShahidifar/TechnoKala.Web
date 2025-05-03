using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnoKala.DaytaLayer.Migrations
{
    /// <inheritdoc />
    public partial class update_blogCategoty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // تغییر نوع داده parent_id به nullable
            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                table: "blog_Categories",
                type: "int",
                nullable: true, // اینجا nullable را true قرار می‌دهیم
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // برگرداندن parent_id به نوع غیر nullable
            migrationBuilder.AlterColumn<int>(
                name: "parent_id",
                table: "blog_Categories",
                type: "int",
                nullable: false, // اینجا nullable را false قرار می‌دهیم
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
