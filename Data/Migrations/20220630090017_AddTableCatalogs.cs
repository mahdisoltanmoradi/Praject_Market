using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class AddTableCatalogs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatalogItemId",
                table: "Discounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CatalogBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentCatalogTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogTypes_CatalogTypes_ParentCatalogTypeId",
                        column: x => x.ParentCatalogTypeId,
                        principalTable: "CatalogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    OldPrice = table.Column<int>(type: "int", nullable: true),
                    PercentDiscount = table.Column<int>(type: "int", nullable: true),
                    CatalogTypeId = table.Column<int>(type: "int", nullable: false),
                    CatalogBrandId = table.Column<int>(type: "int", nullable: false),
                    AvailableStock = table.Column<int>(type: "int", nullable: false),
                    RestockThreshold = table.Column<int>(type: "int", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "int", nullable: false),
                    VisitCount = table.Column<int>(type: "int", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogBrands_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CatalogItems_CatalogTypes_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogItemId = table.Column<int>(type: "int", nullable: true),
                    CatlogItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItemFeatures_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItemImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Src = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogItemId = table.Column<int>(type: "int", nullable: true),
                    CatlogItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItemImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItemImages_CatalogItems_CatalogItemId",
                        column: x => x.CatalogItemId,
                        principalTable: "CatalogItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CatalogItemId",
                table: "OrderDetails",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CatalogItemId",
                table: "Discounts",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemFeatures_CatalogItemId",
                table: "CatalogItemFeatures",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItemImages_CatalogItemId",
                table: "CatalogItemImages",
                column: "CatalogItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogBrandId",
                table: "CatalogItems",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItems_CatalogTypeId",
                table: "CatalogItems",
                column: "CatalogTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogTypes_ParentCatalogTypeId",
                table: "CatalogTypes",
                column: "ParentCatalogTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_CatalogItems_CatalogItemId",
                table: "Discounts",
                column: "CatalogItemId",
                principalTable: "CatalogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_CatalogItems_CatalogItemId",
                table: "OrderDetails",
                column: "CatalogItemId",
                principalTable: "CatalogItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_CatalogItems_CatalogItemId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_CatalogItems_CatalogItemId",
                table: "OrderDetails");

            migrationBuilder.DropTable(
                name: "CatalogItemFeatures");

            migrationBuilder.DropTable(
                name: "CatalogItemImages");

            migrationBuilder.DropTable(
                name: "CatalogItems");

            migrationBuilder.DropTable(
                name: "CatalogBrands");

            migrationBuilder.DropTable(
                name: "CatalogTypes");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_CatalogItemId",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_CatalogItemId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "CatalogItemId",
                table: "Discounts");
        }
    }
}
