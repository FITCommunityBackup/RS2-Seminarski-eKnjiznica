using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Mobile.Base;
using eKnjiznica.Mobile.Services.UserBasket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace eKnjiznica.Mobile.UserBasket
{
    public class UserItemsListViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public decimal Price { get; set; }
        public Uri ImageUri{ get; set; }

        private Command removeCommand;
        private IUserBasketService userBasket;
        public UserItemsListViewModel(IUserBasketService userBasket)
        {
            this.userBasket = userBasket;
        }

        public ICommand RemoveCommand
        {
            get
            {
                if (removeCommand == null)
                {
                    removeCommand = new Command(() => OnRemoveItems());
                }
                return removeCommand;
            }
        }

        private void OnRemoveItems()
        {
            userBasket.RemoveBookOffer(Id);
        }
    }
}
