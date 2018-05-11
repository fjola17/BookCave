using BookCave.Data.EntityModels;
using BookCave.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BookCave.Data
{
    public class DataContext : DbContext 
    {
        public DbSet<Book> Books{ get; set; }
        public DbSet<Review> Reviews{ get; set; }
        public DbSet<Order> Orders{ get; set; }
        public DbSet<BooksInCart> BooksInCarts{ get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
        public DbSet<BillingInfo> BillingInfos { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H29;Persist Security Info=False;User ID=VLN2_2018_H29_usr;Password=wildC@mel84;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}