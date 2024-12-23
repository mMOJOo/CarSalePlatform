//////////////////////////////////////////////////////////////////////
/////////       WEB PROGRAMMING HOMEWORK 23.12.2024      /////////////
///       BERKE ŞAHİN B221202053 / SUUDE NAS ÇETİN B221202006      ///
//////////////////////////////////////////////////////////////////////
using Microsoft.EntityFrameworkCore;

namespace CarSalePlatform.Models
{
    public class AppDbContext : DbContext // It manages the connection between the database and the application and contains classes that represent database tables.
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) // The DbContextOptions class provides database connection information (for example, which database to connect to).
        // Base, on the other hand, calls the constructor method of the DbContext class and passes the connection options to the base class.
        {
        }

        public DbSet<Car> Cars { get; set; } // Maps the Car class to the Cars table in the database.

        public DbSet<User> Users { get; set; } // Maps the User class to the Users table in the database.

    }
}
