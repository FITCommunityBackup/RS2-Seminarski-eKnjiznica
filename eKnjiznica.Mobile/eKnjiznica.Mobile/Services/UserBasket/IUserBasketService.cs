using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eKnjiznica.Mobile.Services.UserBasket
{
    public interface IUserBasketService
    {
        bool ContainsBookOffer(int id);
        void AddBookOffer(BookOfferVM book);
        void RemoveBookOffer(BookOfferVM book);
        void RemoveBookOffer(int id);
        bool IsBasketEmpty();
        ObservableCollection<BookOfferVM> GetUserItems();
        void CompleteUserBasket();
    }
}
