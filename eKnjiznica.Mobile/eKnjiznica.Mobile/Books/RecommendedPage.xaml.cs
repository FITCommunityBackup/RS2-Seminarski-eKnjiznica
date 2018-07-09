using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Mobile.Navigation;
using eKnjiznica.Mobile.Services.UserBasket;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.Books
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecommendedPage : ContentPage
	{

        private IApiClient apiClient;
        private IUserBasketService userBasketService;

        public RecommendedPage()
        {

            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            this.userBasketService = ServiceLocator.Current.GetInstance<IUserBasketService>();
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var response = await apiClient.GetRecommendedBooks();
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = await response.Content.ReadAsStringAsync();
                List<BookOfferVM> bookOffers = JsonConvert.DeserializeObject<List<BookOfferVM>>(jsonObject);
                bookOffers.ForEach(x => {
                    x.ImageUrl = Services.Constants.ServiceBaseUrl + "/" + x.ImageUrl;
                    x.ImageUri = new Uri(x.ImageUrl);
                    if (x.UserHasBook)
                    {
                        var state = Commons.Resources.BOOK_ALREADY_BUYED;
                        x.BookState = state;

                    }
                    else if (userBasketService.ContainsBookOffer(x.Id))
                    {
                        x.BookState = Commons.Resources.BOOK_IN_BASKET;
                    }
                    else
                    {
                        x.BookState = null;
                    }
                });

                booksList.ItemsSource = bookOffers;
            }

        }


        private void booksList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (booksList.SelectedItem != null)
            {
                BookOfferVM offerVM = (booksList.SelectedItem as BookOfferVM);

                var masterDetailsPage = (MyMasterDetailPage)App.Current.MainPage;
                var page = (BookOfferDetails)Activator.CreateInstance(typeof(BookOfferDetails));
                page.Offer = offerVM;
                masterDetailsPage.Detail = new NavigationPage(page);
                masterDetailsPage.IsPresented = false;
            }
        }

      
    }

}
