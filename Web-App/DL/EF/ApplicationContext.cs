using Microsoft.EntityFrameworkCore;
using DL.Models;

namespace DL.EF
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Case> Cases { get; set; }
        public virtual DbSet<Headphones> Headphones { get; set; }
        public virtual DbSet<Charger> Chargers { get; set; }
        public virtual DbSet<Smartphone> Smartphones { get; set; }
        public virtual DbSet<Trademark> Trademarks { get; set; }
        public virtual DbSet<Delivery> Deliveries { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }


        //public ApplicationContext(DbContextOptions<ApplicationContext> options)
        //    : base(options)
        //{
        //    Database.EnsureCreated();
        //}

        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WebAppDB;Trusted_Connection=True;");
        }
    }
}
