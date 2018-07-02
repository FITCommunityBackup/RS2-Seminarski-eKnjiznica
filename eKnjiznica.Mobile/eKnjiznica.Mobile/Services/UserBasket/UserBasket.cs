using System;
using System.Collections.Generic;
using System.Text;
using eKnjiznica.Commons.ViewModels.Books;

namespace eKnjiznica.Mobile.Services.UserBasket
{
    public class UserBasket : IUserBasket
    {

        private List<BookOfferVM> Books{ get; set; }
        public UserBasket()
        {
            Books = new List<BookOfferVM>();
        }
        public void AddBookOffer(BookOfferVM book)
        {
            Books.Add(book);
        }

        public bool ContainsBookOffer(int id)
        {
            bool containsBook = false;
            Books.ForEach(x =>
            {
                if (x.Id == id)
                    containsBook = true;
            });
            return containsBook;
        }

        public void RemoveBookOffer(BookOfferVM book)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Id == book.Id)
                {
                    Books.RemoveAt(i);
                    return;
                }
            }
        }
    }
}
