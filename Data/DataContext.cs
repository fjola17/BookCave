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
<<<<<<< HEAD
        //public DbSet<BookInCarts> BookInCarts{ get; set; }
       // public DbSet<ShippingInfo> ShippingInfos { get; set; }

        //Ekki viss með Author ef nota þá tek út komment, kommenta userinfo þegar það er rétt sett inn     
       //public DbSet<Author> Authors { get; set; }
=======
        public DbSet<BookInCart> BookInCarts{ get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
>>>>>>> 7181e9681da57059165158acca2cd673c835765e
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(
                    "Server=tcp:verklegt2.database.windows.net,1433;Initial Catalog=VLN2_2018_H29;Persist Security Info=False;User ID=VLN2_2018_H29_usr;Password=wildC@mel84;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}