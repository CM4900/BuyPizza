using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BuyPizza.Models.dbContext
{
    public class pizzaContext : DbContext
    {
        private readonly string? _connectionString;
        public pizzaContext(string? connectionString)
        {
            _connectionString = connectionString;
        }

        public pizzaContext(DbContextOptions<pizzaContext> options)
            : base(options)
        {

        }

        public DbSet<Item> Item { get; set; }
        public DbSet<Topping> Topping { get; set; }
        public DbSet<ItemTopping> ItemTopping { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<OrderItemTopping> OrderItemTopping { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string staticConnString = "Server=DESKTOP-COVBKB0;Database=DBPizza;User Id=sa;Password=12345;Trusted_Connection=False;MultipleActiveResultSets=true;TrustServerCertificate=True;Encrypt=False";
                optionsBuilder.UseSqlServer(string.IsNullOrEmpty(_connectionString) ? staticConnString : _connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemTopping>(entity =>
            {
                entity.Property(e => e.ItemID).HasColumnName("ItemID");
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.ItemToppings)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.ToppingID).HasColumnName("ToppingID");
                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.ItemToppings)
                    .HasForeignKey(d => d.ToppingID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.ItemID).HasColumnName("ItemID");
                entity.HasOne(d => d.Item)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.OrderID).HasColumnName("OrderID");
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<OrderItemTopping>(entity =>
            {
                entity.Property(e => e.ToppingID).HasColumnName("ToppingID");
                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.OrderItemToppings)
                    .HasForeignKey(d => d.ToppingID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.OrderItemID).HasColumnName("OrderItemID");
                entity.HasOne(d => d.OrderItem)
                    .WithMany(p => p.OrderItemToppings)
                    .HasForeignKey(d => d.OrderItemID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 1, Name = "Pizza Cake", Description = "Pizza Cake", Image = "PizzaCake.jpg", Rate = 99, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 2, Name = "St. Louis-Style Pizza", Description = "St. Louis-Style Pizza", Image = "StLouisStylePizza.jpg", Rate = 199, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 3, Name = "Pizza ortolana", Description = "Pizza ortolana", Image = "Pizzaortolana.jpg", Rate = 299, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 4, Name = "Pizza alla pala", Description = "Pizza alla pala", Image = "Pizzaallapala.jpg", Rate = 149, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 5, Name = "Pizza pesto Genovese", Description = "Pizza pesto Genovese", Image = "PizzapestoGenovese.jpg", Rate = 249, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 6, Name = "Pizza rustica", Description = "Pizza rustica", Image = "Pizzarustica.jpg", Rate = 349, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 7, Name = "Fugazzeta", Description = "Fugazzeta", Image = "Fugazzeta.jpg", Rate = 399, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 8, Name = "Pizza e fichi", Description = "Pizza e fichi", Image = "Pizzaefichi.jpg", Rate = 449, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 9, Name = "Apizza", Description = "Apizza", Image = "Apizza.jpg", Rate = 229, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 10, Name = "Pugliese Pizza", Description = "Pugliese Pizza", Image = "PugliesePizza.jpg", Rate = 279, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Item>().HasData(new Item { ItemID = 11, Name = "Tomato Pie", Description = "Tomato Pie", Image = "TomatoPie.jpg", Rate = 489, CreatedDate = DateTime.UtcNow });

            modelBuilder.Entity<Topping>().HasData(new Topping { ToppingID = 1, Name = "Roasted Tomatoes", Image = "RoastedTomatoes.jpg", Rate = 49, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Topping>().HasData(new Topping { ToppingID = 2, Name = "Roasted Red Peppers", Image = "RoastedRedPeppers.jpg", Rate = 39, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Topping>().HasData(new Topping { ToppingID = 3, Name = "Roasted Artichokes", Image = "RoastedArtichokes.jpg", Rate = 59, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Topping>().HasData(new Topping { ToppingID = 4, Name = "Roasted Butternut Squash", Image = "RoastedButternutSquash.jpg", Rate = 89, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Topping>().HasData(new Topping { ToppingID = 5, Name = "Roasted Broccoli", Image = "RoastedBroccoli.jpg", Rate = 49, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<Topping>().HasData(new Topping { ToppingID = 6, Name = "Roasted Fennel", Image = "RoastedFennel.jpg", Rate = 89, CreatedDate = DateTime.UtcNow });

            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 1, ItemID = 1, ToppingID = 1, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 2, ItemID = 1, ToppingID = 3, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 3, ItemID = 2, ToppingID = 5, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 4, ItemID = 2, ToppingID = 2, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 5, ItemID = 3, ToppingID = 4, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 6, ItemID = 3, ToppingID = 6, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 7, ItemID = 4, ToppingID = 1, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 8, ItemID = 4, ToppingID = 3, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 9, ItemID = 5, ToppingID = 5, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 10, ItemID = 5, ToppingID = 2, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 11, ItemID = 6, ToppingID = 4, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 12, ItemID = 6, ToppingID = 6, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 13, ItemID = 7, ToppingID = 1, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 14, ItemID = 7, ToppingID = 3, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 15, ItemID = 7, ToppingID = 5, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 16, ItemID = 8, ToppingID = 2, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 17, ItemID = 8, ToppingID = 4, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 18, ItemID = 9, ToppingID = 6, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 19, ItemID = 9, ToppingID = 1, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 20, ItemID = 9, ToppingID = 3, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 21, ItemID = 10, ToppingID = 5, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 22, ItemID = 10, ToppingID = 2, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 23, ItemID = 11, ToppingID = 4, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 24, ItemID = 11, ToppingID = 6, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 25, ItemID = 11, ToppingID = 1, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 26, ItemID = 11, ToppingID = 3, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 27, ItemID = 8, ToppingID = 5, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 28, ItemID = 9, ToppingID = 2, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 29, ItemID = 8, ToppingID = 4, CreatedDate = DateTime.UtcNow });
            modelBuilder.Entity<ItemTopping>().HasData(new ItemTopping { ItemToppingID = 30, ItemID = 7, ToppingID = 6, CreatedDate = DateTime.UtcNow });
        }
    }
}
