using Microsoft.EntityFrameworkCore;

namespace LAB13_TASK1.Models.Database
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> option) : base(option)
        {
        }

        public DbSet<Book> books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .Property(b => b.BookId)
                        .ValueGeneratedNever();
        }
    }
}
