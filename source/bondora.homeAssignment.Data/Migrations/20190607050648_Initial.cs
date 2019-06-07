using Microsoft.EntityFrameworkCore.Migrations;

namespace bondora.homeAssignment.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoyaltyPrograms",
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
                    table.PrimaryKey("PK_LoyaltyPrograms", x => x.Id);
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
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategoryLoyaltyPrograms",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deleted = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<long>(nullable: false),
                    LoyaltyProgramId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLoyaltyPrograms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryLoyaltyPrograms_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryLoyaltyPrograms_LoyaltyPrograms_LoyaltyProgramId",
                        column: x => x.LoyaltyProgramId,
                        principalTable: "LoyaltyPrograms",
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
                    Duration = table.Column<int>(nullable: false),
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
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Deleted", "Name", "PricingFormula" },
                values: new object[] { 1L, false, "Heavy equipment", "OneTime + Premium * duration" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Deleted", "Name", "PricingFormula" },
                values: new object[] { 2L, false, "Regular equipment", "OneTime + min(duration, 2) * Premium + max(0, duration - 2) * Regular" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Deleted", "Name", "PricingFormula" },
                values: new object[] { 3L, false, "Specialized equipment", "min(duration, 3) * Premium + max(0, duration - 3) * Regular" });

            migrationBuilder.InsertData(
                table: "LoyaltyPrograms",
                columns: new[] { "Id", "Deleted", "Formula", "Name" },
                values: new object[] { 1L, false, "1", "Regular bonus program" });

            migrationBuilder.InsertData(
                table: "LoyaltyPrograms",
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
                table: "CategoryLoyaltyPrograms",
                columns: new[] { "Id", "CategoryId", "Deleted", "LoyaltyProgramId" },
                values: new object[] { 2L, 2L, false, 1L });

            migrationBuilder.InsertData(
                table: "CategoryLoyaltyPrograms",
                columns: new[] { "Id", "CategoryId", "Deleted", "LoyaltyProgramId" },
                values: new object[] { 3L, 3L, false, 1L });

            migrationBuilder.InsertData(
                table: "CategoryLoyaltyPrograms",
                columns: new[] { "Id", "CategoryId", "Deleted", "LoyaltyProgramId" },
                values: new object[] { 1L, 1L, false, 2L });

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
                name: "IX_CategoryLoyaltyPrograms_CategoryId",
                table: "CategoryLoyaltyPrograms",
                column: "CategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLoyaltyPrograms_LoyaltyProgramId",
                table: "CategoryLoyaltyPrograms",
                column: "LoyaltyProgramId");

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
                name: "CategoryLoyaltyPrograms");

            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "LoyaltyPrograms");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
