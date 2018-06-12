using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace eKnjiznica.DAL.Model
{
   
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        public DateTime? BirthDate { get; set; }
        
        #region Navigation
        public ICollection<UserAudit> Audits{ get; set; }
        public ICollection<BookCategories> AddedBooksCategories { get; set; }
        public ICollection<Book> AddedBooks { get; set; }
        public ICollection<Category> AddedCategories{ get; set; }
        public ICollection<Transaction> AddedTransactions{ get; set; }
        public ICollection<UserBook> PurchasedBooks{ get; set; }
        public ICollection<AuctionBid> UserBids{ get; set; }

        public virtual UserFinancialAccount UserFinancialAccount{ get; set; }
        #endregion

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

}