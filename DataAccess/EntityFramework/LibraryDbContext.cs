using Microsoft.EntityFrameworkCore;

namespace Homemade.DataAccess.EntityFramework {

    public class LibraryDbContext : DbContext {

        public LibraryDbContext(DbContextOptions options) : base(options) {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Homemade.Models.Book>(b => {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }

        public DbSet<Homemade.Models.Book> Book { get; set; }
    }

}