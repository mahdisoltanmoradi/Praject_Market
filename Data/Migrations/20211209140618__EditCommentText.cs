using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _EditCommentText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "BlogComments",
                newName: "CommentText");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CommentText",
                table: "BlogComments",
                newName: "Text");
        }
    }
}
