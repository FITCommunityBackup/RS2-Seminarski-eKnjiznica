using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.Mobile.Navigation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.Auctions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AuctionsPage : ContentPage
	{
        private IApiClient apiClient;
		public AuctionsPage ()
		{
            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
			InitializeComponent ();

		}


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var response = await apiClient.GetActiveAuctions();
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = await response.Content.ReadAsStringAsync();
                List<AuctionVM> bookOffers = JsonConvert.DeserializeObject<List<AuctionVM>>(jsonObject);
                bookOffers.ForEach(x =>
                {
                    x.ImageUrl = Services.Constants.ServiceBaseUrl + "/" + x.ImageUrl;
                    x.ImageUri = new Uri(x.ImageUrl);
                });

                auctionList.ItemsSource = bookOffers;
            }
        }

        private void auctionList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (auctionList.SelectedItem != null)
            {
                AuctionVM auction = (auctionList.SelectedItem as AuctionVM);

                var masterDetailsPage = (MyMasterDetailPage)App.Current.MainPage;
                var page = (AuctionDetailsPage)Activator.CreateInstance(typeof(AuctionDetailsPage));
                page.Auction= auction;
                masterDetailsPage.Detail = new NavigationPage(page);
                masterDetailsPage.IsPresented = false;
            }
        }
    }
}