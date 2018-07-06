using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.Auctions;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.ClientBook;
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
	public partial class AuctionDetailsPage : ContentPage
	{

        private IApiClient apiClient{ get; set; }
        public AuctionVM Auction { get; set; }
        public ErrorHandlingUtil errorHandlingUtil{ get; set; }
        public AuctionDetailsPage ()
		{
            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            this.errorHandlingUtil= ServiceLocator.Current.GetInstance<ErrorHandlingUtil>();
			InitializeComponent ();
		}
        protected async override void OnAppearing()
        {
            base.OnAppearing();


            PopulateData();
        }

        private void PopulateData()
        {
            title.Text = Auction.BookTitle;
            author.Text = Auction.AuthorName;
            currentPrice.Text = $"Trenutna cijena: {Auction.CurrentPrice} KM";
            startingPrice.Text = $"Početna cijena: {Auction.StartPrice} KM";
            dateFrom.Text = $"Početak aukcije {Auction.StartDate.ToString("dd.MM.yyyy hh:mm")}";
            dateTo.Text = $"Kraj aukcije {Auction.EndDate.ToString("dd.MM.yyyy hh:mm")}";
            image.Source = ImageSource.FromUri(new Uri( Auction.ImageUrl));
            lblCurrentWinner.Text = string.IsNullOrEmpty(Auction.WinnerBidderUsername) ? "Nema ponuda." : Auction.WinnerBidderUsername;
        }

        private async void BtnBid_Clicked(object sender, EventArgs e)
        {
            if (!Valid())
                return;

            var amount = decimal.Parse(entryBidOffer.Text);

            var result = await apiClient.MakeBid(amount, Auction.Id);

            if (result.IsSuccessStatusCode)
            {
                await RefreshAuctionData();
            }
            else
            {
                await DisplayAlert(Commons.Resources.ERROR, await errorHandlingUtil.GetErrorMessageAsync(result, "auction_bid")
                    ,"OK");
            }
        }

        private async Task RefreshAuctionData()
        {
            var result = await apiClient.GetAuctionDetail(Auction.Id);
            if (result.IsSuccessStatusCode)
            {
                var json =await result.Content.ReadAsStringAsync();
                Auction = JsonConvert.DeserializeObject<AuctionVM>(json);
                Auction.ImageUrl = eKnjiznica.Mobile.Services.Constants.ServiceBaseUrl + "/" + Auction.ImageUrl;
                PopulateData();
            }
        }

        private bool Valid()
        {
            decimal result;
            var isValid = decimal.TryParse(entryBidOffer.Text, out result);
            if (!isValid)
            {
                DisplayAlert(Commons.Resources.ERROR, "Unesite ispravnu vrijednost", "OK");
                return false;
            }
            else if (result <= Auction.CurrentPrice)
            {
                DisplayAlert(Commons.Resources.ERROR, $"Unesite cijenu veću od {Auction.CurrentPrice} KM", "OK");
                return false;
            }

            return true;
        }
    }
}