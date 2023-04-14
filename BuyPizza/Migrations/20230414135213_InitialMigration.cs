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
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    ToppingID = table.Column<long>(type: "bigint", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_OrderItemTopping_Topping_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "Topping",
                        principalColumn: "ToppingID");
                });

            migrationBuilder.InsertData(
                table: "Item",
                columns: new[] { "ItemID", "CreatedDate", "Description", "Image", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7863), "Pizza Cake", "PizzaCake.jpg", "Pizza Cake", 99m, null },
                    { 2L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7902), "St. Louis-Style Pizza", "StLouisStylePizza.jpg", "St. Louis-Style Pizza", 199m, null },
                    { 3L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7917), "Pizza ortolana", "Pizzaortolana.jpg", "Pizza ortolana", 299m, null },
                    { 4L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7931), "Pizza alla pala", "Pizzaallapala.jpg", "Pizza alla pala", 149m, null },
                    { 5L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7959), "Pizza pesto Genovese", "PizzapestoGenovese.jpg", "Pizza pesto Genovese", 249m, null },
                    { 6L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7981), "Pizza rustica", "Pizzarustica.jpg", "Pizza rustica", 349m, null },
                    { 7L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7996), "Fugazzeta", "Fugazzeta.jpg", "Fugazzeta", 399m, null },
                    { 8L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8010), "Pizza e fichi", "Pizzaefichi.jpg", "Pizza e fichi", 449m, null },
                    { 9L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8023), "Apizza", "Apizza.jpg", "Apizza", 229m, null },
                    { 10L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8039), "Pugliese Pizza", "PugliesePizza.jpg", "Pugliese Pizza", 279m, null },
                    { 11L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8052), "Tomato Pie", "TomatoPie.jpg", "Tomato Pie", 489m, null }
                });

            migrationBuilder.InsertData(
                table: "Topping",
                columns: new[] { "ToppingID", "CreatedDate", "Image", "Name", "Rate", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8073), "RoastedTomatoes.jpg", "Roasted Tomatoes", 49m, null },
                    { 2L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8095), "RoastedRedPeppers.jpg", "Roasted Red Peppers", 39m, null },
                    { 3L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8110), "RoastedArtichokes.jpg", "Roasted Artichokes", 59m, null },
                    { 4L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8124), "RoastedButternutSquash.jpg", "Roasted Butternut Squash", 89m, null },
                    { 5L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8140), "RoastedBroccoli.jpg", "Roasted Broccoli", 49m, null },
                    { 6L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8156), "RoastedFennel.jpg", "Roasted Fennel", 89m, null }
                });

            migrationBuilder.InsertData(
                table: "ItemTopping",
                columns: new[] { "ItemToppingID", "CreatedDate", "ItemID", "ToppingID", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8171), 1L, 1L, null },
                    { 2L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8187), 1L, 3L, null },
                    { 3L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8200), 2L, 5L, null },
                    { 4L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8212), 2L, 2L, null },
                    { 5L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8225), 3L, 4L, null },
                    { 6L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8238), 3L, 6L, null },
                    { 7L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8252), 4L, 1L, null },
                    { 8L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8264), 4L, 3L, null },
                    { 9L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8277), 5L, 5L, null },
                    { 10L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8290), 5L, 2L, null },
                    { 11L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8303), 6L, 4L, null },
                    { 12L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8325), 6L, 6L, null },
                    { 13L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8343), 7L, 1L, null },
                    { 14L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8356), 7L, 3L, null },
                    { 15L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8369), 7L, 5L, null },
                    { 16L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8383), 8L, 2L, null },
                    { 17L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8396), 8L, 4L, null },
                    { 18L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8410), 9L, 6L, null },
                    { 19L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8423), 9L, 1L, null },
                    { 20L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8436), 9L, 3L, null },
                    { 21L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8450), 10L, 5L, null },
                    { 22L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8463), 10L, 2L, null },
                    { 23L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8476), 11L, 4L, null },
                    { 24L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8489), 11L, 6L, null },
                    { 25L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8502), 11L, 1L, null },
                    { 26L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8515), 11L, 3L, null },
                    { 27L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8528), 8L, 5L, null },
                    { 28L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8541), 9L, 2L, null },
                    { 29L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8554), 8L, 4L, null },
                    { 30L, new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8566), 7L, 6L, null }
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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItemTopping_ToppingID",
                table: "OrderItemTopping",
                column: "ToppingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemTopping");

            migrationBuilder.DropTable(
                name: "OrderItemTopping");

            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
