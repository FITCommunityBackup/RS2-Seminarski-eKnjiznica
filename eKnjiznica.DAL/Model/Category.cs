using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [Required]
        public bool IsActive { get; set; }


        #region Navigation
        public string UserId { get; set; }
        public ApplicationUser AddedBy { get; set; }
        public ICollection<BookCategories> Books { get; set; }
        #endregion

    }
}
