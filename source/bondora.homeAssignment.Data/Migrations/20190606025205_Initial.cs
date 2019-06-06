using Microsoft.EntityFrameworkCore.Migrations;

namespace bondora.homeAssignment.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BonusPoints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Formula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PricingFormula = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryBonusPoints",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    BonusPointsId = table.Column<long>(nullable: false),
                    ProductCategoryId = table.Column<long>(nullable: false),
                    BonusPointId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryBonusPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryBonusPoints_BonusPoints_BonusPointId",
                        column: x => x.BonusPointId,
                        principalTable: "BonusPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryBonusPoints_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    ProductId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BonusPoints",
                columns: new[] { "Id", "Deleted", "Formula", "Name" },
                values: new object[] { 1L, false, "1", "Regular bonus program" });

            migrationBuilder.InsertData(
                table: "BonusPoints",
                columns: new[] { "Id", "Deleted", "Formula", "Name" },
                values: new object[] { 2L, false, "2", "Heavy equipment bonus program" });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Deleted", "Name", "Value" },
                values: new object[] { 1L, false, "OneTime", 100m });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Deleted", "Name", "Value" },
                values: new object[] { 2L, false, "Regular", 40m });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Deleted", "Name", "Value" },
                values: new object[] { 3L, false, "Premium", 100m });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Deleted", "Name", "PricingFormula" },
                values: new object[] { 1L, false, "Heavy equipment", "OneTime + Premium * duration" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Deleted", "Name", "PricingFormula" },
                values: new object[] { 2L, false, "Regular equipment", "OneTime + min(duration, 2) * Premium + max(0, duration - 2) * Regular" });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Deleted", "Name", "PricingFormula" },
                values: new object[] { 3L, false, "Specialized equipment", "min(duration, 3) * Premium + max(0, duration - 3) * Regular" });

            migrationBuilder.InsertData(
                table: "CategoryBonusPoints",
                columns: new[] { "Id", "BonusPointId", "BonusPointsId", "Deleted", "ProductCategoryId" },
                values: new object[] { 1L, null, 2L, false, 1L });

            migrationBuilder.InsertData(
                table: "CategoryBonusPoints",
                columns: new[] { "Id", "BonusPointId", "BonusPointsId", "Deleted", "ProductCategoryId" },
                values: new object[] { 2L, null, 1L, false, 2L });

            migrationBuilder.InsertData(
                table: "CategoryBonusPoints",
                columns: new[] { "Id", "BonusPointId", "BonusPointsId", "Deleted", "ProductCategoryId" },
                values: new object[] { 3L, null, 1L, false, 3L });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Image", "Name" },
                values: new object[] { 1L, 1L, false, "https://i.imgur.com/XmUfJ41.png", "Caterpillar bulldozer" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Image", "Name" },
                values: new object[] { 3L, 1L, false, "https://i.imgur.com/JUH91Xj.png", "Komatsu crane" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Image", "Name" },
                values: new object[] { 2L, 2L, false, "https://i.imgur.com/8bP88dn.png", "KamAZ truck" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Image", "Name" },
                values: new object[] { 4L, 2L, false, "https://i.imgur.com/um0dalY.png", "Volvo steamroller" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Deleted", "Image", "Name" },
                values: new object[] { 5L, 3L, false, "https://i.imgur.com/AilecFp.png", "Bosch jackhammer" });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_UserId",
                table: "CartItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBonusPoints_BonusPointId",
                table: "CategoryBonusPoints",
                column: "BonusPointId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryBonusPoints_ProductCategoryId",
                table: "CategoryBonusPoints",
                column: "ProductCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "CategoryBonusPoints");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BonusPoints");

            migrationBuilder.DropTable(
                name: "ProductCategories");
        }
    }
}
