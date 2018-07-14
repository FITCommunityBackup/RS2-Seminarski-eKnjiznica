using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.ClientBook;
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
    public partial class ClientBookDetailsPage : ContentPage
    {
        public ClientBookVM ClientBook { get; set; }
        private IApiClient apiClient;
        public ClientBookDetailsPage()
        {
            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            bookRatings.ItemsSource = new List<string> { "Ne sviđa mi se", "Nije loše", "U redu je", "Odlična je", "Preporučujem" };
            if (ClientBook.UserRating != 0)
            {
                bookRatings.SelectedIndex = ClientBook.UserRating - 1;
            }

            image.Source = ImageSource.FromUri(new Uri(ClientBook.ImageUrl));
            title.Text = ClientBook.BookTitle;
            author.Text = ClientBook.AuthorName;
            description.Text = ClientBook.BookDescription;
            createdDate.Text = "Datum izdavanja " + ClientBook.BookReleaseDate.ToShortDateString();
            buyDate.Text = ClientBook.BuyDate.ToShortDateString();
            price.Text = ClientBook.Price + " KM";
            if (ClientBook.AverageRating != null)
                averageRating.Text = "Prosječna ocjena " + ClientBook.AverageRating;

            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in ClientBook.Categories)
            {
                stringBuilder.AppendFormat("{0}, ", item.CategoryName);
                stringBuilder.Append(", ");
            }
            stringBuilder.Length -= 2;
            categories.Text = stringBuilder.ToString();

        }

        private async void action_Clicked(object sender, EventArgs e)
        {

            HttpResponseMessage result = await apiClient.ResendBookToEmail(ClientBook.Id);
            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert(Commons.Resources.BOOK_RESEND_SUCCESS_TITLE, Commons.Resources.BOOK_RESEND_SUCCESS_MESSAGE, "OK");
            }
            else
            {
                await DisplayAlert(Commons.Resources.ERROR, Commons.Resources.UNEXPECTED_ERROR_OCURRED, "OK");
            }

        }

        private async void btnRate_Clicked(object sender, EventArgs e)
        {
            if (bookRatings.SelectedIndex == null)
                return;

            int rating = bookRatings.SelectedIndex + 1;
            HttpResponseMessage result = await apiClient.RateBook(ClientBook.BookId, rating);
            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert(Commons.Resources.ACTION_SUCCESS, "Ocjena uspješno pohranjena", "OK");
            }

        }
    }
}