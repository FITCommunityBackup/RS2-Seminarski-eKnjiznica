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
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookOffer> BookOffers { get; set; }
        public DbSet<UserFinancialAccount> UserFinancialAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<AuctionBid> AuctionBids { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }

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

            modelBuilder.Entity<ApplicationUser>()
             .HasOptional(x => x.UserFinancialAccount)
             .WithRequired(x => x.ApplicationUser);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.AddedTransactions)
                .WithOptional(x => x.Admin)
                .HasForeignKey(x => x.AdminId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.PurchasedBooks)
                .WithRequired(x => x.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.UserBids)
                .WithRequired(x => x.User)
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

            modelBuilder.Entity<Book>()
                .HasMany(x => x.BookOffers)
                .WithRequired(x => x.Book)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.BookAuctions)
                .WithRequired(x => x.Book)
                .HasForeignKey(x => x.BookId);
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

            #region BookOffers
            modelBuilder.Entity<BookOffer>()
                .HasRequired(x => x.Book)
                .WithMany(x => x.BookOffers)
                .HasForeignKey(x => x.BookId);
            modelBuilder.Entity<BookOffer>()
            .HasMany(x => x.PurchasedBooks)
            .WithRequired(x => x.BookOffer)
            .HasForeignKey(x => x.BookOfferId);
            #endregion

            #region UserFinancialAccount
            modelBuilder.Entity<UserFinancialAccount>()
              .HasRequired(x => x.ApplicationUser)
              .WithOptional(x => x.UserFinancialAccount);

            modelBuilder.Entity<UserFinancialAccount>()
            .HasMany(x => x.Transactions)
            .WithRequired(x => x.UserFinancialAccount)
            .HasForeignKey(x => x.UserFinancialAccountId);
            #endregion

            #region Transaction
            modelBuilder.Entity<Transaction>()
                .HasOptional(x => x.Admin)
                .WithMany(x => x.AddedTransactions)
                .HasForeignKey(x => x.AdminId);

            modelBuilder.Entity<Transaction>()
                .HasRequired(x => x.UserFinancialAccount)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserFinancialAccountId);

            modelBuilder.Entity<Transaction>()
                .HasMany(x => x.UserBooks)
                .WithRequired(x => x.Transaction)
                .HasForeignKey(x => x.TransactionId);
            #endregion

            #region UserBook
            modelBuilder.Entity<UserBook>()
                .HasRequired(x => x.User)
                .WithMany(x => x.PurchasedBooks)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserBook>()
                .HasRequired(x => x.BookOffer)
                .WithMany(x => x.PurchasedBooks)
                .HasForeignKey(x => x.BookOfferId);

            modelBuilder.Entity<UserBook>()
                .HasRequired(x => x.Transaction)
                .WithMany(x => x.UserBooks)
                .HasForeignKey(x => x.TransactionId);

            #endregion

            #region Auctions
            modelBuilder.Entity<Auction>()
                .HasRequired(x => x.Book)
                .WithMany(x => x.BookAuctions)
                .HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Auction>()
                 .HasMany(x => x.AuctionBids)
                 .WithRequired(x => x.Auction)
                 .HasForeignKey(x => x.AuctionId);
            #endregion

            #region AuctionBids
            modelBuilder.Entity<AuctionBid>()
                .HasRequired(x => x.Auction)
                .WithMany(x => x.AuctionBids)
                .HasForeignKey(x => x.AuctionId);

            modelBuilder.Entity<AuctionBid>()
                .HasRequired(x => x.User)
                .WithMany(x => x.UserBids)
                .HasForeignKey(x => x.UserId);
            #endregion
        }

        public static EKnjiznicaDB Create()
        {
            return new EKnjiznicaDB();
        }
    }
}
