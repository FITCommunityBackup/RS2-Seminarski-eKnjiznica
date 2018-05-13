using eKnjiznica.DAL.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.EF
{
    public class EKnjiznicaDB : IdentityDbContext<ApplicationUser>
    {
        public EKnjiznicaDB()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static EKnjiznicaDB Create()
        {
            return new EKnjiznicaDB();
        }
    }
}
