using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ipAddress_for_chatmessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "ClientChatRooms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "ClientChatRooms");
        }
    }
}
