using CommonServiceLocator;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Mobile.Services.UserBasket;
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
	public partial class BookOfferDetails : ContentPage
	{
        public BookOfferVM Offer { get; set; }

        private IUserBasket userBasket;
        public BookOfferDetails ()
		{
            InitializeComponent();
            userBasket = ServiceLocator.Current.GetInstance<IUserBasket>();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (userBasket.ContainsBookOffer(Offer.Id))
            {
                action.Text = "Ukloni";
            }
            else
            {
                action.Text = "Dodaj u košaricu";
            }

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

        private void action_Clicked(object sender, EventArgs e)
        {
            if (userBasket.ContainsBookOffer(Offer.Id))
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