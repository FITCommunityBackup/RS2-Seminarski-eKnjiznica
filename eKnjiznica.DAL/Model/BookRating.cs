using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class BookRating
    {
        public int Id { get; set; }
        [Required]
        public int Rating { get; set; }
        public bool IsActive { get; set; }


        #region Navigation
        public int BookId { get; set; }
        public Book Book { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        #endregion
    }
}
