using BookReader.DAL.Configurations;
using BookReader.Domain.Entity;
using Microsoft.EntityFrameworkCore;


namespace BookReader.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted(); // This one I using for tests..
            Database.EnsureCreated();
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  We can do like that:

            //modelBuilder.Entity<BookView>().Property(x => x.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<BookView>().Property(x => x.Author).HasMaxLength(100);

            //  And like that:

            //modelBuilder.Entity<BookView>(builder =>
            //{
            //    builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //    builder.Property(x => x.Author).HasMaxLength(100);
            //    builder.Property(x => x.Description).HasMaxLength(100);
            //});
            modelBuilder.ApplyConfiguration(new BookConfiguration());    //  But in the end I moved my model configuration to Configurations folder.
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
        public DbSet<Book> Book { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
