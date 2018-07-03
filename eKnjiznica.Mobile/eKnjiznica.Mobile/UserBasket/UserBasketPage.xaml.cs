using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Mobile.Services.UserBasket;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.UserBasket
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserBasketPage : ContentPage
    {
        private UserBasketViewModel viewModel;
        private IUserBasketService userBasketService;
        private IApiClient apiClient;
        private  ErrorHandlingUtil errorHandlingUtil;
        private ObservableCollection<UserItemsListViewModel> Items = new ObservableCollection<UserItemsListViewModel>();
        public UserBasketPage()
        {
            this.userBasketService = ServiceLocator.Current.GetInstance<IUserBasketService>();
            this.apiClient= ServiceLocator.Current.GetInstance<IApiClient>();
            this.errorHandlingUtil= ServiceLocator.Current.GetInstance<ErrorHandlingUtil>();
            InitializeComponent();
            viewModel = new UserBasketViewModel { Items = Items };
            this.BindingContext = viewModel;



        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var userItems = userBasketService.GetUserItems();
            userItems.CollectionChanged += RefreshData;
            PopulateUserData();
        }

        private void PopulateUserData()
        {
            Items.Clear();
            var userItems = userBasketService.GetUserItems();
            decimal tPrice = 0;
            foreach (var x in userItems)
            {
                Items.Add(new UserItemsListViewModel(userBasketService)
                {
                    Id = x.Id,
                    AuthorName = x.AuthorName,
                    Price = x.Price,
                    Title = x.Title
                });
                tPrice += x.Price;
            }
            this.Title = $"Moja košarica ({userItems.Count})";
            //viewModel.TotalPrice = tPrice + " KM";
            lblTotalPrice.Text = tPrice + " KM";
        }

        private void RefreshData(object sender, NotifyCollectionChangedEventArgs e)
        {
            PopulateUserData();
        }

        private async void btnCompleteOrder_Clicked(object sender, EventArgs e)
        {
            List<BookOfferVM> list = userBasketService.GetUserItems().ToList();
            var result  = await apiClient.BuyBook(list);

            if (result.IsSuccessStatusCode)
            {
                userBasketService.CompleteUserBasket();
               await  DisplayAlert(Commons.Resources.BOOK_BUY_SUCCESS_TITLE, Commons.Resources.BOOK_BUY_SUCCESS_MESSAGE, "OK");
            }
            else
            {
                await DisplayAlert(Commons.Resources.ERROR,await errorHandlingUtil.GetErrorMessageAsync(result,"buy_book"), "OK");
            }
        }
    }
}