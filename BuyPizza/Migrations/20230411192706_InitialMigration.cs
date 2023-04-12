using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuyPizza.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    ItemID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.ItemID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ToppingID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    OrderItemID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<long>(type: "bigint", nullable: false),
                    OrderID = table.Column<long>(type: "bigint", nullable: false),
                    Quentity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItem_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "OrderID");
                });

            migrationBuilder.CreateTable(
                name: "ItemTopping",
                columns: table => new
                {
                    ItemToppingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemID = table.Column<long>(type: "bigint", nullable: false),
                    ToppingID = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTopping", x => x.ItemToppingID);
                    table.ForeignKey(
                        name: "FK_ItemTopping_Item_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Item",
                        principalColumn: "ItemID");
                    table.ForeignKey(
                        name: "FK_ItemTopping_Topping_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Topping",
                        principalColumn: "ToppingID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItemTopping",
                columns: table => new
                {
                    OrderItemToppingID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderItemID = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItemTopping", x => x.OrderItemToppingID);
                    table.ForeignKey(
                        name: "FK_OrderItemTopping_OrderItem_OrderItemID",
                        column: x => x.OrderItemID,
                        principalTable: "OrderItem",
                        principalColumn: "OrderItemID");
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemID", "CreatedDate", "Description", "Image", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(5780), "Pizza Cake", "PizzaCake.jpg", "Pizza Cake", 99.0, null },
                    { 2L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(5850), "St. Louis-Style Pizza", "StLouisStylePizza.jpg", "St. Louis-Style Pizza", 199.0, null },
                    { 3L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(5887), "Pizza ortolana", "Pizzaortolana.jpg", "Pizza ortolana", 299.0, null },
                    { 4L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(5921), "Pizza alla pala", "Pizzaallapala.jpg", "Pizza alla pala", 149.0, null },
                    { 5L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(5957), "Pizza pesto Genovese", "PizzapestoGenovese.jpg", "Pizza pesto Genovese", 249.0, null },
                    { 6L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6002), "Pizza rustica", "Pizzarustica.jpg", "Pizza rustica", 349.0, null },
                    { 7L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6040), "Fugazzeta", "Fugazzeta.jpg", "Fugazzeta", 399.0, null },
                    { 8L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6072), "Pizza e fichi", "Pizzaefichi.jpg", "Pizza e fichi", 449.0, null },
                    { 9L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6104), "Apizza", "Apizza.jpg", "Apizza", 229.0, null },
                    { 10L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6180), "Pugliese Pizza", "PugliesePizza.jpg", "Pugliese Pizza", 279.0, null },
                    { 11L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6213), "Tomato Pie", "TomatoPie.jpg", "Tomato Pie", 489.0, null }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "ToppingID", "CreatedDate", "Image", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6260), "RoastedTomatoes.jpg", "Roasted Tomatoes", 49.0, null },
                    { 2L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6313), "RoastedRedPeppers.jpg", "Roasted Red Peppers", 39.0, null },
                    { 3L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6352), "RoastedArtichokes.jpg", "Roasted Artichokes", 59.0, null },
                    { 4L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6390), "RoastedButternutSquash.jpg", "Roasted Butternut Squash", 89.0, null },
                    { 5L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6426), "RoastedBroccoli.jpg", "Roasted Broccoli", 49.0, null },
                    { 6L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6461), "RoastedFennel.jpg", "Roasted Fennel", 89.0, null }
                });

            migrationBuilder.InsertData(
                table: "ItemTopping",
                columns: new[] { "ItemToppingID", "CreatedDate", "ItemID", "ToppingID", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6509), 1L, 1L, null },
                    { 2L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6552), 1L, 3L, null },
                    { 3L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6584), 2L, 5L, null },
                    { 4L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6619), 2L, 2L, null },
                    { 5L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6655), 3L, 4L, null },
                    { 6L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6697), 3L, 6L, null },
                    { 7L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6735), 4L, 1L, null },
                    { 8L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6764), 4L, 3L, null },
                    { 9L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6792), 5L, 5L, null },
                    { 10L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6824), 5L, 2L, null },
                    { 11L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6854), 6L, 4L, null },
                    { 12L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6892), 6L, 6L, null },
                    { 13L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6924), 7L, 1L, null },
                    { 14L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6959), 7L, 3L, null },
                    { 15L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(6996), 7L, 5L, null },
                    { 16L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7038), 8L, 2L, null },
                    { 17L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7102), 8L, 4L, null },
                    { 18L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7151), 9L, 6L, null },
                    { 19L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7189), 9L, 1L, null },
                    { 20L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7226), 9L, 3L, null },
                    { 21L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7263), 10L, 5L, null },
                    { 22L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7300), 10L, 2L, null },
                    { 23L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7338), 11L, 4L, null },
                    { 24L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7374), 11L, 6L, null },
                    { 25L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7408), 11L, 1L, null },
                    { 26L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7445), 11L, 3L, null },
                    { 27L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7481), 8L, 5L, null },
                    { 28L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7518), 9L, 2L, null },
                    { 29L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7554), 8L, 4L, null },
                    { 30L, new DateTime(2023, 4, 11, 19, 27, 5, 883, DateTimeKind.Utc).AddTicks(7588), 7L, 6L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemTopping_ItemID",
                table: "ItemTopping",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTopping_ToppingID",
                table: "ItemTopping",
                column: "ToppingID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ItemID",
                table: "OrderItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItem",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemTopping_OrderItemID",
                table: "OrderItemTopping",
                column: "OrderItemID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTopping");

            migrationBuilder.DropTable(
                name: "OrderItemTopping");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
