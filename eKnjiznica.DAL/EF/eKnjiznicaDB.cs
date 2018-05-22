using eKnjiznica.DAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.EF
{
    public class EKnjiznicaDB : IdentityDbContext<ApplicationUser>
    {

        public DbSet<UserAudit> UserAudits { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<BookCategories> BookCategories{ get; set; }
        public DbSet<Book> Books{ get; set; }

        public EKnjiznicaDB()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            #region ApplicationUser

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Audits)
                .WithRequired(x => x.ApplicationUser)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.AddedBooksCategories)
                .WithRequired(x => x.ApplicationUser)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.AddedBooks)
                .WithRequired(x => x.AddedBy)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.AddedCategories)
                .WithRequired(x => x.AddedBy)
                .HasForeignKey(x => x.UserId);


            #endregion

            #region UserAudit
            modelBuilder.Entity<UserAudit>()
                .HasRequired(x => x.ApplicationUser)
                .WithMany(x => x.Audits)
                .HasForeignKey(x => x.UserId);
            #endregion

            #region Books
            modelBuilder.Entity<Book>()
                .HasMany(x => x.Categories)
                .WithRequired(x => x.Book)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Book>()
                .HasRequired(x => x.AddedBy)
                .WithMany(x => x.AddedBooks)
                .HasForeignKey(x => x.UserId);
            #endregion

            #region Categories
            modelBuilder.Entity<Category>()
               .HasMany(x => x.Books)
               .WithRequired(x => x.Category)
               .HasForeignKey(x => x.CategoryId);


            modelBuilder.Entity<Category>()
             .HasRequired(x => x.AddedBy)
             .WithMany(x => x.AddedCategories)
             .HasForeignKey(x => x.UserId);

            #endregion

            #region BookCategories
            modelBuilder.Entity<BookCategories>()
                           .HasRequired(x => x.Book)
                           .WithMany(x => x.Categories)
                           .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<BookCategories>()
                           .HasRequired(x => x.Category)
                           .WithMany(x => x.Books)
                           .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<BookCategories>()
                    .HasRequired(x => x.ApplicationUser)
                    .WithMany(x => x.AddedBooksCategories)
                    .HasForeignKey(x => x.UserId);
            #endregion
        }
        public static EKnjiznicaDB Create()
        {
            return new EKnjiznicaDB();
        }
    }
}
