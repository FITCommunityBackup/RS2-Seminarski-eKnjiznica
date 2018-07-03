using eKnjiznica.Mobile.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace eKnjiznica.Mobile.UserBasket
{
    public class UserBasketViewModel : ViewModelBase
    {
        public ObservableCollection<UserItemsListViewModel> Items{ get; set; }
        public string TotalPrice { get; set; }
    }
}
