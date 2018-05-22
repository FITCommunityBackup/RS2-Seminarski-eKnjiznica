using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class BookCategories
    {
        public int Id { get; set; }
        [Required]
        public DateTime Created{ get; set; }
        [Required]
        public bool IsActive { get; set; }
        #region Navigation
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int BookId { get; set; }
        public Book Book{ get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion

    }
}
