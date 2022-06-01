using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modify_user_favorite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteUserUsers");

            migrationBuilder.RenameColumn(
                name: "FavoriteId",
                table: "FavoriteUsers",
                newName: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "FavoriteUsers",
                newName: "FavoriteId");

            migrationBuilder.CreateTable(
                name: "FavoriteUserUsers",
                columns: table => new
                {
                    FavoriteUsersId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteUserUsers", x => new { x.FavoriteUsersId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_FavoriteUserUsers_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FavoriteUserUsers_FavoriteUsers_FavoriteUsersId",
                        column: x => x.FavoriteUsersId,
                        principalTable: "FavoriteUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteUserUsers_UsersId",
                table: "FavoriteUserUsers",
                column: "UsersId");
        }
    }
}
