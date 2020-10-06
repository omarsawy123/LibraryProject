using LibraryDataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp.Api.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().HasData(new Location { id = 1, CityName = "Tanta", LibraryName = "TantaLibrary",PhotoPath="images/lib1.jpg" });
            modelBuilder.Entity<Location>().HasData(new Location { id = 2, CityName = "Mansoura", LibraryName = "MansouraLibrary",PhotoPath= "images/lib2.jpg" });


            modelBuilder.Entity<Book>().HasData(new Book()
            {
                id = 1,
                Name = "FirstBook",
                Author = "PFirstBook",
                Category = Category.Action,
                Price = 100,
                PhotoPath = "images/1.jpg",
                locationId = 1,
            });
            modelBuilder.Entity<Book>().HasData(new Book()
            {
                id = 2,
                Name = "SecondBook",
                Author = "PSecondBook",
                Category = Category.Action,
                Price = 120,
                PhotoPath = "images/2.jpg",
                locationId = 1,
            });
            modelBuilder.Entity<Book>().HasData(new Book()
            {
                id = 3,
                Name = "ThirdBook",
                Author = "PThirdBook",
                Category = Category.Horror,
                Price = 300,
                PhotoPath = "images/3.jpg",
                locationId = 2,
            });
            modelBuilder.Entity<Book>().HasData(new Book()
            {
                id = 4,
                Name = "FourthBook",
                Author = "PFourthBook",
                Category = Category.Thriller,
                Price = 210,
                PhotoPath = "images/4.jpg",
                locationId = 2,
            });
        }

    }
}
