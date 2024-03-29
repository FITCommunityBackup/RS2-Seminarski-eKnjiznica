﻿using eKnjiznica.Commons.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.Commons.ViewModels.Books
{
    [DataContract]
    public class BookOfferVM
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BookId { get; set; }
        [DataMember]
        public IList<CategoryVM> Categories { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime BookReleaseDate { get; set; }

        [DataMember]
        public bool UserHasBook { get; set; }
        [DataMember]
        public int UserRating{ get; set; }


        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public DateTime OfferCreatedDate { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }

        [DataMember]
        public double? AverageRating { get; set; }

        [IgnoreDataMember]
        public string BookState { get; set; }
        [IgnoreDataMember]
        public Uri ImageUri { get; set; }
    }
}
