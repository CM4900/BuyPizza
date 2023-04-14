﻿// <auto-generated />
using System;
using BuyPizza.Models.dbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuyPizza.Migrations
{
    [DbContext(typeof(pizzaContext))]
    partial class pizzaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BuyPizza.Models.Item", b =>
                {
                    b.Property<long>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ItemID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemID");

                    b.ToTable("Item");

                    b.HasData(
                        new
                        {
                            ItemID = 1L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7863),
                            Description = "Pizza Cake",
                            Image = "PizzaCake.jpg",
                            Name = "Pizza Cake",
                            Rate = 99m
                        },
                        new
                        {
                            ItemID = 2L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7902),
                            Description = "St. Louis-Style Pizza",
                            Image = "StLouisStylePizza.jpg",
                            Name = "St. Louis-Style Pizza",
                            Rate = 199m
                        },
                        new
                        {
                            ItemID = 3L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7917),
                            Description = "Pizza ortolana",
                            Image = "Pizzaortolana.jpg",
                            Name = "Pizza ortolana",
                            Rate = 299m
                        },
                        new
                        {
                            ItemID = 4L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7931),
                            Description = "Pizza alla pala",
                            Image = "Pizzaallapala.jpg",
                            Name = "Pizza alla pala",
                            Rate = 149m
                        },
                        new
                        {
                            ItemID = 5L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7959),
                            Description = "Pizza pesto Genovese",
                            Image = "PizzapestoGenovese.jpg",
                            Name = "Pizza pesto Genovese",
                            Rate = 249m
                        },
                        new
                        {
                            ItemID = 6L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7981),
                            Description = "Pizza rustica",
                            Image = "Pizzarustica.jpg",
                            Name = "Pizza rustica",
                            Rate = 349m
                        },
                        new
                        {
                            ItemID = 7L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(7996),
                            Description = "Fugazzeta",
                            Image = "Fugazzeta.jpg",
                            Name = "Fugazzeta",
                            Rate = 399m
                        },
                        new
                        {
                            ItemID = 8L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8010),
                            Description = "Pizza e fichi",
                            Image = "Pizzaefichi.jpg",
                            Name = "Pizza e fichi",
                            Rate = 449m
                        },
                        new
                        {
                            ItemID = 9L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8023),
                            Description = "Apizza",
                            Image = "Apizza.jpg",
                            Name = "Apizza",
                            Rate = 229m
                        },
                        new
                        {
                            ItemID = 10L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8039),
                            Description = "Pugliese Pizza",
                            Image = "PugliesePizza.jpg",
                            Name = "Pugliese Pizza",
                            Rate = 279m
                        },
                        new
                        {
                            ItemID = 11L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8052),
                            Description = "Tomato Pie",
                            Image = "TomatoPie.jpg",
                            Name = "Tomato Pie",
                            Rate = 489m
                        });
                });

            modelBuilder.Entity("BuyPizza.Models.ItemTopping", b =>
                {
                    b.Property<long>("ItemToppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ItemToppingID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ItemID")
                        .HasColumnType("bigint")
                        .HasColumnName("ItemID");

                    b.Property<long>("ToppingID")
                        .HasColumnType("bigint")
                        .HasColumnName("ToppingID");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ItemToppingID");

                    b.HasIndex("ItemID");

                    b.HasIndex("ToppingID");

                    b.ToTable("ItemTopping");

                    b.HasData(
                        new
                        {
                            ItemToppingID = 1L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8171),
                            ItemID = 1L,
                            ToppingID = 1L
                        },
                        new
                        {
                            ItemToppingID = 2L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8187),
                            ItemID = 1L,
                            ToppingID = 3L
                        },
                        new
                        {
                            ItemToppingID = 3L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8200),
                            ItemID = 2L,
                            ToppingID = 5L
                        },
                        new
                        {
                            ItemToppingID = 4L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8212),
                            ItemID = 2L,
                            ToppingID = 2L
                        },
                        new
                        {
                            ItemToppingID = 5L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8225),
                            ItemID = 3L,
                            ToppingID = 4L
                        },
                        new
                        {
                            ItemToppingID = 6L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8238),
                            ItemID = 3L,
                            ToppingID = 6L
                        },
                        new
                        {
                            ItemToppingID = 7L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8252),
                            ItemID = 4L,
                            ToppingID = 1L
                        },
                        new
                        {
                            ItemToppingID = 8L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8264),
                            ItemID = 4L,
                            ToppingID = 3L
                        },
                        new
                        {
                            ItemToppingID = 9L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8277),
                            ItemID = 5L,
                            ToppingID = 5L
                        },
                        new
                        {
                            ItemToppingID = 10L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8290),
                            ItemID = 5L,
                            ToppingID = 2L
                        },
                        new
                        {
                            ItemToppingID = 11L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8303),
                            ItemID = 6L,
                            ToppingID = 4L
                        },
                        new
                        {
                            ItemToppingID = 12L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8325),
                            ItemID = 6L,
                            ToppingID = 6L
                        },
                        new
                        {
                            ItemToppingID = 13L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8343),
                            ItemID = 7L,
                            ToppingID = 1L
                        },
                        new
                        {
                            ItemToppingID = 14L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8356),
                            ItemID = 7L,
                            ToppingID = 3L
                        },
                        new
                        {
                            ItemToppingID = 15L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8369),
                            ItemID = 7L,
                            ToppingID = 5L
                        },
                        new
                        {
                            ItemToppingID = 16L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8383),
                            ItemID = 8L,
                            ToppingID = 2L
                        },
                        new
                        {
                            ItemToppingID = 17L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8396),
                            ItemID = 8L,
                            ToppingID = 4L
                        },
                        new
                        {
                            ItemToppingID = 18L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8410),
                            ItemID = 9L,
                            ToppingID = 6L
                        },
                        new
                        {
                            ItemToppingID = 19L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8423),
                            ItemID = 9L,
                            ToppingID = 1L
                        },
                        new
                        {
                            ItemToppingID = 20L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8436),
                            ItemID = 9L,
                            ToppingID = 3L
                        },
                        new
                        {
                            ItemToppingID = 21L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8450),
                            ItemID = 10L,
                            ToppingID = 5L
                        },
                        new
                        {
                            ItemToppingID = 22L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8463),
                            ItemID = 10L,
                            ToppingID = 2L
                        },
                        new
                        {
                            ItemToppingID = 23L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8476),
                            ItemID = 11L,
                            ToppingID = 4L
                        },
                        new
                        {
                            ItemToppingID = 24L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8489),
                            ItemID = 11L,
                            ToppingID = 6L
                        },
                        new
                        {
                            ItemToppingID = 25L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8502),
                            ItemID = 11L,
                            ToppingID = 1L
                        },
                        new
                        {
                            ItemToppingID = 26L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8515),
                            ItemID = 11L,
                            ToppingID = 3L
                        },
                        new
                        {
                            ItemToppingID = 27L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8528),
                            ItemID = 8L,
                            ToppingID = 5L
                        },
                        new
                        {
                            ItemToppingID = 28L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8541),
                            ItemID = 9L,
                            ToppingID = 2L
                        },
                        new
                        {
                            ItemToppingID = 29L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8554),
                            ItemID = 8L,
                            ToppingID = 4L
                        },
                        new
                        {
                            ItemToppingID = 30L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8566),
                            ItemID = 7L,
                            ToppingID = 6L
                        });
                });

            modelBuilder.Entity("BuyPizza.Models.Order", b =>
                {
                    b.Property<long>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("OrderID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BuyPizza.Models.OrderItem", b =>
                {
                    b.Property<long>("OrderItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderItemID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("ItemID")
                        .HasColumnType("bigint")
                        .HasColumnName("ItemID");

                    b.Property<long>("OrderID")
                        .HasColumnType("bigint")
                        .HasColumnName("OrderID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quentity")
                        .HasColumnType("int");

                    b.HasKey("OrderItemID");

                    b.HasIndex("ItemID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("BuyPizza.Models.OrderItemTopping", b =>
                {
                    b.Property<long>("OrderItemToppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("OrderItemToppingID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("OrderItemID")
                        .HasColumnType("bigint")
                        .HasColumnName("OrderItemID");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ToppingID")
                        .HasColumnType("bigint")
                        .HasColumnName("ToppingID");

                    b.HasKey("OrderItemToppingID");

                    b.HasIndex("OrderItemID");

                    b.HasIndex("ToppingID");

                    b.ToTable("OrderItemTopping");
                });

            modelBuilder.Entity("BuyPizza.Models.Topping", b =>
                {
                    b.Property<long>("ToppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ToppingID"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ToppingID");

                    b.ToTable("Topping");

                    b.HasData(
                        new
                        {
                            ToppingID = 1L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8073),
                            Image = "RoastedTomatoes.jpg",
                            Name = "Roasted Tomatoes",
                            Rate = 49m
                        },
                        new
                        {
                            ToppingID = 2L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8095),
                            Image = "RoastedRedPeppers.jpg",
                            Name = "Roasted Red Peppers",
                            Rate = 39m
                        },
                        new
                        {
                            ToppingID = 3L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8110),
                            Image = "RoastedArtichokes.jpg",
                            Name = "Roasted Artichokes",
                            Rate = 59m
                        },
                        new
                        {
                            ToppingID = 4L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8124),
                            Image = "RoastedButternutSquash.jpg",
                            Name = "Roasted Butternut Squash",
                            Rate = 89m
                        },
                        new
                        {
                            ToppingID = 5L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8140),
                            Image = "RoastedBroccoli.jpg",
                            Name = "Roasted Broccoli",
                            Rate = 49m
                        },
                        new
                        {
                            ToppingID = 6L,
                            CreatedDate = new DateTime(2023, 4, 14, 13, 52, 13, 19, DateTimeKind.Utc).AddTicks(8156),
                            Image = "RoastedFennel.jpg",
                            Name = "Roasted Fennel",
                            Rate = 89m
                        });
                });

            modelBuilder.Entity("BuyPizza.Models.ItemTopping", b =>
                {
                    b.HasOne("BuyPizza.Models.Item", "Item")
                        .WithMany("ItemToppings")
                        .HasForeignKey("ItemID")
                        .IsRequired();

                    b.HasOne("BuyPizza.Models.Topping", "Topping")
                        .WithMany("ItemToppings")
                        .HasForeignKey("ToppingID")
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("BuyPizza.Models.OrderItem", b =>
                {
                    b.HasOne("BuyPizza.Models.Item", "Item")
                        .WithMany("OrderItems")
                        .HasForeignKey("ItemID")
                        .IsRequired();

                    b.HasOne("BuyPizza.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BuyPizza.Models.OrderItemTopping", b =>
                {
                    b.HasOne("BuyPizza.Models.OrderItem", "OrderItem")
                        .WithMany("OrderItemToppings")
                        .HasForeignKey("OrderItemID")
                        .IsRequired();

                    b.HasOne("BuyPizza.Models.Topping", "Topping")
                        .WithMany("OrderItemToppings")
                        .HasForeignKey("ToppingID")
                        .IsRequired();

                    b.Navigation("OrderItem");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("BuyPizza.Models.Item", b =>
                {
                    b.Navigation("ItemToppings");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BuyPizza.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BuyPizza.Models.OrderItem", b =>
                {
                    b.Navigation("OrderItemToppings");
                });

            modelBuilder.Entity("BuyPizza.Models.Topping", b =>
                {
                    b.Navigation("ItemToppings");

                    b.Navigation("OrderItemToppings");
                });
#pragma warning restore 612, 618
        }
    }
}
