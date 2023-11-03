using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookStoreApp.API.Data
{
    public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
    {
        public BookStoreDbContext()
        {
        }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Bio).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAEC36F419")
                    .IsUnique();

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("ISBN");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Summary)
                    .HasMaxLength(250)
                    .HasColumnName("summary");

                entity.Property(e => e.Tititle).HasMaxLength(50);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_Authors_Id");
            });

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "9df4a2bd-e083-4299-957c-dbf0a296ae6b"
                },
                new IdentityRole
                {
                    Name ="Administrator",
                    NormalizedName="ADMINISTRATOR",
                    Id= "1701f22a-ec9f-4d0a-8db6-19fc3a73bc3f"
                }
              );
            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                new ApiUser
                {
                    Id= "ee82860c-b2b5-49b0-8c02-defe6f8e434c",
                    Email="admin@bookstore.com",
                    NormalizedEmail="ADMIN@BOOKSTORE.COM",
                    UserName = "admin@bookstaor.com",
                    NormalizedUserName= "ADMIN@BOOKSTORE.COM",
                    FirstName="System",
                    LastName="Admin",
                    PasswordHash= hasher.HashPassword(null,"P@ssword1")
                },
                new ApiUser
                {
                    Id = "f4d77821-6610-402e-8e98-11b0d83a0426",
                    Email = "user@bookstore.com",
                    NormalizedEmail = "USER@BOOKSTORE.COM",
                    UserName = "user@bookstaor.com",
                    NormalizedUserName = "USER@BOOKSTORE.COM",
                    FirstName = "System",
                    LastName = "uSER",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1")
                }
              );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                      RoleId  = "9df4a2bd-e083-4299-957c-dbf0a296ae6b",
                      UserId= "f4d77821-6610-402e-8e98-11b0d83a0426"
                    },
                    new IdentityUserRole<string>
                    {
                        RoleId = "1701f22a-ec9f-4d0a-8db6-19fc3a73bc3f",
                        UserId = "ee82860c-b2b5-49b0-8c02-defe6f8e434c"
                    }
                );
            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
