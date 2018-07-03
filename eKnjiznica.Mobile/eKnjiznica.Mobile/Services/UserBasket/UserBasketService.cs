using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using eKnjiznica.Commons.ViewModels.Books;

namespace eKnjiznica.Mobile.Services.UserBasket
{
    public class UserBasketService : IUserBasketService
    {

        private ObservableCollection<BookOfferVM> Books{ get; set; }
        public UserBasketService()
        {
            Books = new ObservableCollection<BookOfferVM>();
         
        }
        public void AddBookOffer(BookOfferVM book)
        {
            Books.Add(book);
        }

        public bool ContainsBookOffer(int id)
        {
            foreach (var item in Books)
            {
                if (id == item.Id)
                    return true;
            }
            return false;
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

        public void RemoveBookOffer(int id)
        {
            for (int i = 0; i < Books.Count; i++)
            {
                if (Books[i].Id == id)
                {
                    Books.RemoveAt(i);
                    return;
                }
            }
        }

        public bool IsBasketEmpty()
        {
            return Books.Count == 0;
        }

        public ObservableCollection<BookOfferVM> GetUserItems()
        {
            return Books;
        }

        public void CompleteUserBasket()
        {
            this.Books.Clear();
        }
    }
}
