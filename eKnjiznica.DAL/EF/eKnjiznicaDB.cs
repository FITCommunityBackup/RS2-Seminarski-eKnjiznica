using eKnjiznica.DAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.EF
{
    public class EKnjiznicaDB : IdentityDbContext<ApplicationUser>
    {

        public DbSet<UserAudit> UserAudits{ get; set; }

        public EKnjiznicaDB()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(x => x.Audits)
                .WithRequired(x => x.ApplicationUser)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserAudit>()
                .HasRequired(x => x.ApplicationUser)
                .WithMany(x => x.Audits)
                .HasForeignKey(x => x.UserId);

        }
        public static EKnjiznicaDB Create()
        {
            return new EKnjiznicaDB();
        }
    }
}
