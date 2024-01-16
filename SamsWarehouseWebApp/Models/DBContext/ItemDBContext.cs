﻿using Microsoft.EntityFrameworkCore;
using SamsWarehouseWebApp.Models.Data;

namespace SamsWarehouseWebApp.Models.DBContext
{
    public class ItemDBContext : DbContext
    {
        public ItemDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<ListItems> ListItems { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ListItems>()
                .HasOne(li => li.List)
                .WithMany(l => l.ListItems)
                .HasForeignKey(li => li.ListId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ListItems>()
                .HasOne(i => i.Item)
                .WithMany(li => li.ListItems)
                .HasForeignKey(li => li.ItemId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Item>().HasData(

                new Item
                {
                    ItemId = 1,
                    ItemName = "Granny Smith Apples",
                    Unit = "1kg",
                    UnitPrice = 5.50,
                },

                new Item
                {
                    ItemId = 2,
                    ItemName = "Fresh Tomatoes",
                    Unit = "500g",
                    UnitPrice = 5.90,
                },

                new Item
                {
                    ItemId = 3,
                    ItemName = "Watermelon",
                    Unit = "Whole",
                    UnitPrice = 6.60,
                },

                new Item
                {
                    ItemId = 4,
                    ItemName = "Cucumber",
                    Unit = "1 whole",
                    UnitPrice = 1.90,
                },

                new Item
                {
                    ItemId = 5,
                    ItemName = "Red Potato Washed",
                    Unit = "1kg",
                    UnitPrice = 4.00,
                },

                new Item
                {
                    ItemId = 6,
                    ItemName = "Red Tipped Bananas",
                    Unit = "1kg",
                    UnitPrice = 4.90,
                },

                new Item
                {
                    ItemId = 7,
                    ItemName = "Red Onion",
                    Unit = "1kg",
                    UnitPrice = 3.50,
                },

                new Item
                {
                    ItemId = 8,
                    ItemName = "Carrots",
                    Unit = "1kg",
                    UnitPrice = 2.00,
                },

                new Item
                {
                    ItemId = 9,
                    ItemName = "Iceburg Lettuce",
                    Unit = "1",
                    UnitPrice = 2.50,
                },

                new Item
                {
                    ItemId = 10,
                    ItemName = "Helga's Wholemeal",
                    Unit = "1",
                    UnitPrice = 3.70,
                },

                new Item
                {
                    ItemId = 11,
                    ItemName = "Free Range Chicken",
                    Unit = "1kg",
                    UnitPrice = 7.50,
                },

                new Item
                {
                    ItemId = 12,
                    ItemName = "Manning Valley 6-pk",
                    Unit = "6 eggs",
                    UnitPrice = 3.60,
                },

                new Item
                {
                    ItemId = 13,
                    ItemName = "A2 Light Milk",
                    Unit = "1 litre",
                    UnitPrice = 2.90,
                },

                new Item
                {
                    ItemId = 14,
                    ItemName = "Chobani Strawberry Yoghurt",
                    Unit = "1",
                    UnitPrice = 1.50,
                },

                new Item
                {
                    ItemId = 15,
                    ItemName = "Lurpark Salted Blend",
                    Unit = "250g",
                    UnitPrice = 5.00,
                },

                new Item
                {
                    ItemId = 16,
                    ItemName = "Bega Farmers Tasty",
                    Unit = "250g",
                    UnitPrice = 4.00,
                },

                new Item
                {
                    ItemId = 17,
                    ItemName = "Babybel Mini",
                    Unit = "100g",
                    UnitPrice = 4.20,
                },

                new Item
                {
                    ItemId = 18,
                    ItemName = "Cobram EVOO",
                    Unit = "375ml",
                    UnitPrice = 8.00,
                },

                new Item
                {
                    ItemId = 19,
                    ItemName = "Heinz Tomato Soup",
                    Unit = "535g",
                    UnitPrice = 2.50,
                },

                new Item
                {
                    ItemId = 20,
                    ItemName = "John West Tuna can",
                    Unit = "95g",
                    UnitPrice = 1.50,
                },

                new Item
                {
                    ItemId = 21,
                    ItemName = "Cadbury Dairy Milk",
                    Unit = "200g",
                    UnitPrice = 5.00,
                },

                new Item
                {
                    ItemId = 22,
                    ItemName = "Coca Cola",
                    Unit = "2 litre",
                    UnitPrice = 2.85,
                },

                new Item
                {
                    ItemId = 23,
                    ItemName = "Smith's Original Share Pack Crisps",
                    Unit = "170g",
                    UnitPrice = 3.29,
                },

                new Item
                {
                    ItemId = 24,
                    ItemName = "Birds Eye Fish Fingers",
                    Unit = "375g",
                    UnitPrice = 4.50,
                },

                new Item
                {
                    ItemId = 25,
                    ItemName = "Berri Orange Juice",
                    Unit = "2 litre",
                    UnitPrice = 6.00,
                },

                new Item
                {
                    ItemId = 26,
                    ItemName = "Vegemite",
                    Unit = "380g",
                    UnitPrice = 6.00,
                },

                new Item
                {
                    ItemId = 27,
                    ItemName = "Cheddar Shapes",
                    Unit = "175g",
                    UnitPrice = 2.00,
                },

                new Item
                {
                    ItemId = 28,
                    ItemName = "Colgate Total ToothPaste",
                    Unit = "110g",
                    UnitPrice = 3.50,
                },

                new Item
                {
                    ItemId = 29,
                    ItemName = "Milo Chocolate Malt",
                    Unit = "200g",
                    UnitPrice = 4.00,
                },

                new Item
                {
                    ItemId = 30,
                    ItemName = "Weet Bix Saniatarium Organic",
                    Unit = "750g",
                    UnitPrice = 5.33,
                },

                new Item
                {
                    ItemId = 31,
                    ItemName = "Lindt Excellence 70% Cocoa Block",
                    Unit = "100g",
                    UnitPrice = 4.25,
                },

                new Item
                {
                    ItemId = 32,
                    ItemName = "Original Tim Tams Chocolate",
                    Unit = "200g",
                    UnitPrice = 3.65,
                },

                new Item
                {
                    ItemId = 33,
                    ItemName = "Philadelphia Original Cream Cheese",
                    Unit = "250g",
                    UnitPrice = 4.30,
                },

                new Item
                {
                    ItemId = 34,
                    ItemName = "Moccona Classic Instant Medium Roast",
                    Unit = "100g",
                    UnitPrice = 6.00,
                },

                new Item
                {
                    ItemId = 35,
                    ItemName = "Capilano Sqeezable Honey",
                    Unit = "500g",
                    UnitPrice = 7.35,
                },

                new Item
                {
                    ItemId = 36,
                    ItemName = "Nutella Jar",
                    Unit = "400g",
                    UnitPrice = 4.00,
                },

                new Item
                {
                    ItemId = 37,
                    ItemName = "Arnott's Scotch Finger",
                    Unit = "250g",
                    UnitPrice = 2.85,
                },

                new Item
                {
                    ItemId = 38,
                    ItemName = "South Cape Greek Feta",
                    Unit = "200g",
                    UnitPrice = 5.00,
                },

                new Item
                {
                    ItemId = 39,
                    ItemName = "Sacla Pasta Tomato Basil Sauce",
                    Unit = "420g",
                    UnitPrice = 4.50,
                },

                new Item
                {
                    ItemId = 40,
                    ItemName = "Primo English Ham",
                    Unit = "100g",
                    UnitPrice = 3.00,
                },

                new Item
                {
                    ItemId = 41,
                    ItemName = "Primo Short Cut Rindless Bacon",
                    Unit = "175g",
                    UnitPrice = 5.00,
                },

                new Item
                {
                    ItemId = 42,
                    ItemName = "Golden Circle Pinapple Pieces in natural juice",
                    Unit = "440g",
                    UnitPrice = 3.25,
                },

                new Item
                {
                    ItemId = 43,
                    ItemName = "San Renmo Linguine Pasta No 1",
                    Unit = "500g",
                    UnitPrice = 1.95,
                });
        }

    }
}
