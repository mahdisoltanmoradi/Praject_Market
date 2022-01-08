using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _EditTableBlogComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogComments_BlogComments_Reply_id",
                table: "BlogComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogComments_Reply_id",
                table: "BlogComments");

            migrationBuilder.DropColumn(
                name: "Reply_id",
                table: "BlogComments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Reply_id",
                table: "BlogComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogComments_Reply_id",
                table: "BlogComments",
                column: "Reply_id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogComments_BlogComments_Reply_id",
                table: "BlogComments",
                column: "Reply_id",
                principalTable: "BlogComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
