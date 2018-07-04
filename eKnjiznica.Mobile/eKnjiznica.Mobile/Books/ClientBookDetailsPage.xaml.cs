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
        public ClientBookDetailsPage ()
		{
            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            image.Source = ImageSource.FromUri(new Uri(ClientBook.ImageUrl));
            title.Text = ClientBook.BookTitle;
            author.Text = ClientBook.AuthorName;
            description.Text = ClientBook.BookDescription;
            createdDate.Text = "Datum izdavanja " + ClientBook.BookReleaseDate.ToShortDateString();
            buyDate.Text = ClientBook.BuyDate.ToShortDateString();
            price.Text = ClientBook.Price + " KM";

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
    }
}