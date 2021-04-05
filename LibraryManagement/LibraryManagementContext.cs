using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LibraryData
{
    public partial class LibraryManagementContext : DbContext
    {
        public LibraryManagementContext()
        {
        }

        public LibraryManagementContext(DbContextOptions<LibraryManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorBook> AuthorBooks { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookGenre> BookGenres { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Location> Locations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectsV13;Initial Catalog=LibraryManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<AuthorBook>(entity =>
            {
                entity.HasKey(e => new { e.AuthorId, e.BookId })
                    .HasName("PK_BookAuthor");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorBooks_Authors");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.AuthorBooks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AuthorBooks_Books");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<BookGenre>(entity =>
            {
                entity.HasKey(e => new { e.GenreId, e.BookId })
                    .HasName("PK_BookGenre");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookGenres_Books");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.BookGenres)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BookGenres_Genres");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.Property(e => e.GenreName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.AisleName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations_Books");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
