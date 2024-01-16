using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SamsWarehouseWebApp.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UnitPrice = table.Column<decimal>(type: "Decimal(19,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_Lists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListItems",
                columns: table => new
                {
                    ListItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItems", x => x.ListItemsId);
                    table.ForeignKey(
                        name: "FK_ListItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListItems_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "ListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ItemName", "Unit", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Granny Smith Apples", "1kg", 5.5m },
                    { 2, "Fresh Tomatoes", "500g", 5.9m },
                    { 3, "Watermelon", "Whole", 6.6m },
                    { 4, "Cucumber", "1 whole", 1.9m },
                    { 5, "Red Potato Washed", "1kg", 4m },
                    { 6, "Red Tipped Bananas", "1kg", 4.9m },
                    { 7, "Red Onion", "1kg", 3.5m },
                    { 8, "Carrots", "1kg", 2m },
                    { 9, "Iceburg Lettuce", "1", 2.5m },
                    { 10, "Helga's Wholemeal", "1", 3.7m },
                    { 11, "Free Range Chicken", "1kg", 7.5m },
                    { 12, "Manning Valley 6-pk", "6 eggs", 3.6m },
                    { 13, "A2 Light Milk", "1 litre", 2.9m },
                    { 14, "Chobani Strawberry Yoghurt", "1", 1.5m },
                    { 15, "Lurpark Salted Blend", "250g", 5m },
                    { 16, "Bega Farmers Tasty", "250g", 4m },
                    { 17, "Babybel Mini", "100g", 4.2m },
                    { 18, "Cobram EVOO", "375ml", 8m },
                    { 19, "Heinz Tomato Soup", "535g", 2.5m },
                    { 20, "John West Tuna can", "95g", 1.5m },
                    { 21, "Cadbury Dairy Milk", "200g", 5m },
                    { 22, "Coca Cola", "2 litre", 2.85m },
                    { 23, "Smith's Original Share Pack Crisps", "170g", 3.29m },
                    { 24, "Birds Eye Fish Fingers", "375g", 4.5m },
                    { 25, "Berri Orange Juice", "2 litre", 6m },
                    { 26, "Vegemite", "380g", 6m },
                    { 27, "Cheddar Shapes", "175g", 2m },
                    { 28, "Colgate Total ToothPaste", "110g", 3.5m },
                    { 29, "Milo Chocolate Malt", "200g", 4m },
                    { 30, "Weet Bix Saniatarium Organic", "750g", 5.33m },
                    { 31, "Lindt Excellence 70% Cocoa Block", "100g", 4.25m },
                    { 32, "Original Tim Tams Chocolate", "200g", 3.65m },
                    { 33, "Philadelphia Original Cream Cheese", "250g", 4.3m },
                    { 34, "Moccona Classic Instant Medium Roast", "100g", 6m },
                    { 35, "Capilano Sqeezable Honey", "500g", 7.35m },
                    { 36, "Nutella Jar", "400g", 4m },
                    { 37, "Arnott's Scotch Finger", "250g", 2.85m },
                    { 38, "South Cape Greek Feta", "200g", 5m },
                    { 39, "Sacla Pasta Tomato Basil Sauce", "420g", 4.5m },
                    { 40, "Primo English Ham", "100g", 3m },
                    { 41, "Primo Short Cut Rindless Bacon", "175g", 5m },
                    { 42, "Golden Circle Pinapple Pieces in natural juice", "440g", 3.25m },
                    { 43, "San Renmo Linguine Pasta No 1", "500g", 1.95m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_ItemId",
                table: "ListItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_ListId",
                table: "ListItems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_UserId",
                table: "Lists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
