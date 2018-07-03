using CommonServiceLocator;
using eKnjiznica.Mobile.Books;
using eKnjiznica.Mobile.Services.UserBasket;
using eKnjiznica.Mobile.UserBasket;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage
    {
        public ListView ListView;
        public MasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }
            private IUserBasketService userBasketService;
            private MasterDetailPageMenuItem myBasketItem;
            public MasterDetailPageMasterViewModel()
            {
                userBasketService = ServiceLocator.Current.GetService<IUserBasketService>();

                myBasketItem = new MasterDetailPageMenuItem { Id = 3, Title = "Moja košarica", TargetType = typeof(UserBasketPage) };
                userBasketService.GetUserItems().CollectionChanged += BasketItemChanged;
                MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
                {
                    new MasterDetailPageMenuItem { Id = 0, Title = "Preporučeno",TargetType=typeof(MainPage) },
                    new MasterDetailPageMenuItem { Id = 1, Title = "Knjige" ,TargetType=typeof(BooksPage)},
                    new MasterDetailPageMenuItem { Id = 2, Title = "Kupljene knjige" ,TargetType=typeof(MainPage)},
                    myBasketItem,
                    new MasterDetailPageMenuItem { Id = 4, Title = "Moje transakcije" ,TargetType=typeof(MainPage)},
                    new MasterDetailPageMenuItem { Id = 4, Title = "Profil" ,TargetType=typeof(MainPage)},
                    new MasterDetailPageMenuItem { Id = 4, Title = "Odjava" ,TargetType=typeof(LoginPage)},
                });

                UpdateMyBasketItem();

            }

            private void BasketItemChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                UpdateMyBasketItem();

            }

            private void UpdateMyBasketItem()
            {
                MenuItems.Remove(myBasketItem);
                var items = userBasketService.GetUserItems();
                if (items.Count == 0)
                {
                    myBasketItem.Title = "Moja košarica";
                }
                else
                {
                    myBasketItem.Title = $"Moja košarica ({items.Count})";
                }
                MenuItems.Insert(3, myBasketItem);
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}