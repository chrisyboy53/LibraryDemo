using Microsoft.EntityFrameworkCore;

namespace Homemade.DataAccess.EntityFramework {

    public class LibraryDbContext : DbContext {

        public LibraryDbContext(DbContextOptions options) : base(options) {
            
        }

        public DbSet<Homemade.Models.Book> Book { get; set; }
    }

}