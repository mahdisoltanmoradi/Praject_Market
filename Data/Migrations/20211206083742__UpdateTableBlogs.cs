using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _UpdateTableBlogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlogTitle",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogTitle",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Blogs");
        }
    }
}
