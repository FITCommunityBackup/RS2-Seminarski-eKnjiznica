using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Books;
using eKnjiznica.Commons.ViewModels.Category;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.Books
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BooksPage : ContentPage
    {
        private IApiClient apiClient;

        private List<CategoryVM> Categories;
        public BooksPage()
        {

            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var response = await apiClient.GetCategories(null, false);

            if (response.IsSuccessStatusCode)
            {
                Categories = JsonConvert.DeserializeObject<List<CategoryVM>>(await response.Content.ReadAsStringAsync());
                bookCategories.ItemsSource = Categories;
                bookCategories.ItemDisplayBinding = new Binding("CategoryName");
                if (Categories.Count > 0)
                    await BindList(Categories[0].Id);
            }

        }

        private async void bookCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookCategories.SelectedItem != null)
            {
                int categoryId= (bookCategories.SelectedItem as CategoryVM).Id;
                await BindList(categoryId);
            }
        }

        private void booksList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private async Task BindList(int categoryId)
        {
            var response = await apiClient.GetBookOffersByCategory(categoryId);
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = await response.Content.ReadAsStringAsync();
                List<BookOfferVM> bookOffers = JsonConvert.DeserializeObject<List<BookOfferVM>>(jsonObject);
                bookOffers.ForEach(x => {
                    x.ImageUrl = Services.Constants.ServiceBaseUrl + "/" + x.ImageUrl;
                    x.ImageUri = new Uri(x.ImageUrl);
                    });

            
                booksList.ItemsSource = bookOffers;
            }
        }
    }
}