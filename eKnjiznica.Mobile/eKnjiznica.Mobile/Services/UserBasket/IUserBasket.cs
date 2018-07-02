using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKnjiznica.Mobile.Services.UserBasket
{
    public interface IUserBasket
    {
        bool ContainsBookOffer(int id);
        void AddBookOffer(BookOfferVM book);
        void RemoveBookOffer(BookOfferVM book);
    }
}
