using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _CreateVisitBlog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogVisit",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogVisit",
                table: "Blogs");
        }
    }
}
