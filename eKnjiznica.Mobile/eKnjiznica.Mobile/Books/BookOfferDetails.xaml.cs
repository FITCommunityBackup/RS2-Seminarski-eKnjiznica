using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Mobile.Services.UserBasket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.Books
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookOfferDetails : ContentPage
	{
        public BookOfferVM Offer { get; set; }
        private IApiClient apiClient;
        private IUserBasketService userBasket;
        private ErrorHandlingUtil errorHandlingUtil;

        public BookOfferDetails ()
		{
            InitializeComponent();
            userBasket = ServiceLocator.Current.GetInstance<IUserBasketService>();
            errorHandlingUtil = ServiceLocator.Current.GetInstance<ErrorHandlingUtil>();
            apiClient= ServiceLocator.Current.GetInstance<IApiClient>();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Offer.UserHasBook)
            {
                action.Text = "Pošalji na mail";
            }
            else if (userBasket.ContainsBookOffer(Offer.Id))
            {
                action.Text = "Ukloni";
            }
            else
            {
                action.Text = "Dodaj u košaricu";

            }

            image.Source = ImageSource.FromUri(new Uri(Offer.ImageUrl));
            title.Text = Offer.Title;
            author.Text = Offer.AuthorName;
            description.Text = Offer.Description;
            createdDate.Text = "Datum izdavanja " + Offer.BookReleaseDate.ToShortDateString();
            price.Text = Offer.Price + " KM";

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in Offer.Categories)
            {
                stringBuilder.AppendFormat("{0}, ",item.CategoryName);
                stringBuilder.Append(", ");
            }
            stringBuilder.Length -= 2;
            categories.Text = stringBuilder.ToString();

    }

        private async void action_Clicked(object sender, EventArgs e)
        {
            if (Offer.UserHasBook)
            {
                HttpResponseMessage result = await apiClient.ResendBookToEmail(Offer.BookId);
                if (result.IsSuccessStatusCode)
                {
                    await DisplayAlert(Commons.Resources.BOOK_RESEND_SUCCESS_TITLE, Commons.Resources.BOOK_RESEND_SUCCESS_MESSAGE, "OK");
                }
                else
                {
                    await DisplayAlert(Commons.Resources.ERROR, Commons.Resources.UNEXPECTED_ERROR_OCURRED, "OK");
                }
            }
            else if (userBasket.ContainsBookOffer(Offer.Id))
            {
                userBasket.RemoveBookOffer(Offer);
                action.Text = "Dodaj u košaricu";
            }
            else
            {
                userBasket.AddBookOffer(Offer);
                action.Text = "Ukloni";
            }
        }
    }
}