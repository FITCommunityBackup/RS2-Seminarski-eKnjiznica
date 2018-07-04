using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.ClientBook;
using eKnjiznica.Mobile.Navigation;
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
    public partial class MyBooksPage : ContentPage
    {
        private IApiClient apiClient;
        private ErrorHandlingUtil errorHandlingUtil;
        public MyBooksPage()
        {
            InitializeComponent();
            errorHandlingUtil = ServiceLocator.Current.GetInstance<ErrorHandlingUtil>();
            apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var response = await apiClient.GetClientBooks();
            if (response.IsSuccessStatusCode)
            {
                var jsonObject = await response.Content.ReadAsStringAsync();
                List<ClientBookVM> bookOffers = JsonConvert.DeserializeObject<List<ClientBookVM>>(jsonObject);
                bookOffers.ForEach(x =>
                {
                    x.ImageUrl = Services.Constants.ServiceBaseUrl + "/" + x.ImageUrl;
                    x.ImageUri = new Uri(x.ImageUrl);
                });

                booksList.ItemsSource = bookOffers;
            }
        }

        private void booksList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (booksList.SelectedItem != null)
            {
                ClientBookVM bookVm= (booksList.SelectedItem as ClientBookVM);

                var masterDetailsPage = (MyMasterDetailPage)App.Current.MainPage;
                var page = (ClientBookDetailsPage)Activator.CreateInstance(typeof(ClientBookDetailsPage));
                page.ClientBook=bookVm;
                masterDetailsPage.Detail = new NavigationPage(page);
                masterDetailsPage.IsPresented = false;
            }
        }

    }
}