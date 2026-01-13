using LibraryManagementSystemApi.Models.Entites;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystemApi.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
                : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<BookTransaction> BookTransactions { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //Book
        //    modelBuilder.Entity<Book>()
        //        .HasIndex(b => b.ISBN)
        //        .IsUnique();
        //    //BookTransaction relationships
        //    modelBuilder.Entity<BookTransaction>()
        //        .HasOne(bt => bt.Book)
        //        .WithMany(b => b.BookTransactions)
        //        .HasForeignKey(bt => bt.MemberId);

        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasIndex(b => b.ISBN)
                .IsUnique();

            modelBuilder.Entity<BookTransaction>()
                .HasOne(bt => bt.Book)
                .WithMany(b => b.BookTransactions)
                .HasForeignKey(bt => bt.BookId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookTransaction>()
                .HasOne(bt => bt.Member)
                .WithMany(m => m.BookTransactions)
                .HasForeignKey(bt => bt.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<BookTransaction>()
            .Property(bt => bt.FineAmount)
            .HasPrecision(10, 2);

        }

    }
}
