using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnoKala.DaytaLayer.Migrations
{
    /// <inheritdoc />
    public partial class create_BaseEntiti : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "dleated_at",
                table: "blogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "is_dleated",
                table: "blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "blog_Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dleated_at",
                table: "blog_Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "is_dleated",
                table: "blog_Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dleated_at",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "is_dleated",
                table: "blogs");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "blog_Categories");

            migrationBuilder.DropColumn(
                name: "dleated_at",
                table: "blog_Categories");

            migrationBuilder.DropColumn(
                name: "is_dleated",
                table: "blog_Categories");
        }
    }
}
