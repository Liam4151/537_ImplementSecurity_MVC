﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SamsWarehouseWebApp.Models.DBContext;

#nullable disable

namespace SamsWarehouseWebApp.Migrations
{
    [DbContext(typeof(ItemDBContext))]
    partial class ItemDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.AppUser", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("Decimal(19,4)");

                    b.HasKey("ItemId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            ItemId = 1,
                            ItemName = "Granny Smith Apples",
                            Unit = "1kg",
                            UnitPrice = 5.5m
                        },
                        new
                        {
                            ItemId = 2,
                            ItemName = "Fresh Tomatoes",
                            Unit = "500g",
                            UnitPrice = 5.9m
                        },
                        new
                        {
                            ItemId = 3,
                            ItemName = "Watermelon",
                            Unit = "Whole",
                            UnitPrice = 6.6m
                        },
                        new
                        {
                            ItemId = 4,
                            ItemName = "Cucumber",
                            Unit = "1 whole",
                            UnitPrice = 1.9m
                        },
                        new
                        {
                            ItemId = 5,
                            ItemName = "Red Potato Washed",
                            Unit = "1kg",
                            UnitPrice = 4m
                        },
                        new
                        {
                            ItemId = 6,
                            ItemName = "Red Tipped Bananas",
                            Unit = "1kg",
                            UnitPrice = 4.9m
                        },
                        new
                        {
                            ItemId = 7,
                            ItemName = "Red Onion",
                            Unit = "1kg",
                            UnitPrice = 3.5m
                        },
                        new
                        {
                            ItemId = 8,
                            ItemName = "Carrots",
                            Unit = "1kg",
                            UnitPrice = 2m
                        },
                        new
                        {
                            ItemId = 9,
                            ItemName = "Iceburg Lettuce",
                            Unit = "1",
                            UnitPrice = 2.5m
                        },
                        new
                        {
                            ItemId = 10,
                            ItemName = "Helga's Wholemeal",
                            Unit = "1",
                            UnitPrice = 3.7m
                        },
                        new
                        {
                            ItemId = 11,
                            ItemName = "Free Range Chicken",
                            Unit = "1kg",
                            UnitPrice = 7.5m
                        },
                        new
                        {
                            ItemId = 12,
                            ItemName = "Manning Valley 6-pk",
                            Unit = "6 eggs",
                            UnitPrice = 3.6m
                        },
                        new
                        {
                            ItemId = 13,
                            ItemName = "A2 Light Milk",
                            Unit = "1 litre",
                            UnitPrice = 2.9m
                        },
                        new
                        {
                            ItemId = 14,
                            ItemName = "Chobani Strawberry Yoghurt",
                            Unit = "1",
                            UnitPrice = 1.5m
                        },
                        new
                        {
                            ItemId = 15,
                            ItemName = "Lurpark Salted Blend",
                            Unit = "250g",
                            UnitPrice = 5m
                        },
                        new
                        {
                            ItemId = 16,
                            ItemName = "Bega Farmers Tasty",
                            Unit = "250g",
                            UnitPrice = 4m
                        },
                        new
                        {
                            ItemId = 17,
                            ItemName = "Babybel Mini",
                            Unit = "100g",
                            UnitPrice = 4.2m
                        },
                        new
                        {
                            ItemId = 18,
                            ItemName = "Cobram EVOO",
                            Unit = "375ml",
                            UnitPrice = 8m
                        },
                        new
                        {
                            ItemId = 19,
                            ItemName = "Heinz Tomato Soup",
                            Unit = "535g",
                            UnitPrice = 2.5m
                        },
                        new
                        {
                            ItemId = 20,
                            ItemName = "John West Tuna can",
                            Unit = "95g",
                            UnitPrice = 1.5m
                        },
                        new
                        {
                            ItemId = 21,
                            ItemName = "Cadbury Dairy Milk",
                            Unit = "200g",
                            UnitPrice = 5m
                        },
                        new
                        {
                            ItemId = 22,
                            ItemName = "Coca Cola",
                            Unit = "2 litre",
                            UnitPrice = 2.85m
                        },
                        new
                        {
                            ItemId = 23,
                            ItemName = "Smith's Original Share Pack Crisps",
                            Unit = "170g",
                            UnitPrice = 3.29m
                        },
                        new
                        {
                            ItemId = 24,
                            ItemName = "Birds Eye Fish Fingers",
                            Unit = "375g",
                            UnitPrice = 4.5m
                        },
                        new
                        {
                            ItemId = 25,
                            ItemName = "Berri Orange Juice",
                            Unit = "2 litre",
                            UnitPrice = 6m
                        },
                        new
                        {
                            ItemId = 26,
                            ItemName = "Vegemite",
                            Unit = "380g",
                            UnitPrice = 6m
                        },
                        new
                        {
                            ItemId = 27,
                            ItemName = "Cheddar Shapes",
                            Unit = "175g",
                            UnitPrice = 2m
                        },
                        new
                        {
                            ItemId = 28,
                            ItemName = "Colgate Total ToothPaste",
                            Unit = "110g",
                            UnitPrice = 3.5m
                        },
                        new
                        {
                            ItemId = 29,
                            ItemName = "Milo Chocolate Malt",
                            Unit = "200g",
                            UnitPrice = 4m
                        },
                        new
                        {
                            ItemId = 30,
                            ItemName = "Weet Bix Saniatarium Organic",
                            Unit = "750g",
                            UnitPrice = 5.33m
                        },
                        new
                        {
                            ItemId = 31,
                            ItemName = "Lindt Excellence 70% Cocoa Block",
                            Unit = "100g",
                            UnitPrice = 4.25m
                        },
                        new
                        {
                            ItemId = 32,
                            ItemName = "Original Tim Tams Chocolate",
                            Unit = "200g",
                            UnitPrice = 3.65m
                        },
                        new
                        {
                            ItemId = 33,
                            ItemName = "Philadelphia Original Cream Cheese",
                            Unit = "250g",
                            UnitPrice = 4.3m
                        },
                        new
                        {
                            ItemId = 34,
                            ItemName = "Moccona Classic Instant Medium Roast",
                            Unit = "100g",
                            UnitPrice = 6m
                        },
                        new
                        {
                            ItemId = 35,
                            ItemName = "Capilano Sqeezable Honey",
                            Unit = "500g",
                            UnitPrice = 7.35m
                        },
                        new
                        {
                            ItemId = 36,
                            ItemName = "Nutella Jar",
                            Unit = "400g",
                            UnitPrice = 4m
                        },
                        new
                        {
                            ItemId = 37,
                            ItemName = "Arnott's Scotch Finger",
                            Unit = "250g",
                            UnitPrice = 2.85m
                        },
                        new
                        {
                            ItemId = 38,
                            ItemName = "South Cape Greek Feta",
                            Unit = "200g",
                            UnitPrice = 5m
                        },
                        new
                        {
                            ItemId = 39,
                            ItemName = "Sacla Pasta Tomato Basil Sauce",
                            Unit = "420g",
                            UnitPrice = 4.5m
                        },
                        new
                        {
                            ItemId = 40,
                            ItemName = "Primo English Ham",
                            Unit = "100g",
                            UnitPrice = 3m
                        },
                        new
                        {
                            ItemId = 41,
                            ItemName = "Primo Short Cut Rindless Bacon",
                            Unit = "175g",
                            UnitPrice = 5m
                        },
                        new
                        {
                            ItemId = 42,
                            ItemName = "Golden Circle Pinapple Pieces in natural juice",
                            Unit = "440g",
                            UnitPrice = 3.25m
                        },
                        new
                        {
                            ItemId = 43,
                            ItemName = "San Renmo Linguine Pasta No 1",
                            Unit = "500g",
                            UnitPrice = 1.95m
                        });
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.List", b =>
                {
                    b.Property<int>("ListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListId"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("ListName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ListId");

                    b.HasIndex("UserId");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.ListItems", b =>
                {
                    b.Property<int>("ListItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ListItemsId"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ListId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ListItemsId");

                    b.HasIndex("ItemId");

                    b.HasIndex("ListId");

                    b.ToTable("ListItems");
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.List", b =>
                {
                    b.HasOne("SamsWarehouseWebApp.Models.Data.AppUser", "User")
                        .WithMany("Lists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.ListItems", b =>
                {
                    b.HasOne("SamsWarehouseWebApp.Models.Data.Item", "Item")
                        .WithMany("ListItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SamsWarehouseWebApp.Models.Data.List", "List")
                        .WithMany("ListItems")
                        .HasForeignKey("ListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("List");
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.AppUser", b =>
                {
                    b.Navigation("Lists");
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.Item", b =>
                {
                    b.Navigation("ListItems");
                });

            modelBuilder.Entity("SamsWarehouseWebApp.Models.Data.List", b =>
                {
                    b.Navigation("ListItems");
                });
#pragma warning restore 612, 618
        }
    }
}
