using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.DAL.Model
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string FileLocation{ get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public bool IsActive { get; set; }



        #region Navigation
        public string UserId { get; set; }
        public ApplicationUser AddedBy { get; set; }

        public ICollection<BookCategories> Categories { get; set; }
        #endregion

    }
}
