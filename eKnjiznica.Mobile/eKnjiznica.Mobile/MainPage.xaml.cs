using CommonServiceLocator;
using eKnjiznica.Commons.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Xamarin.Forms;

namespace eKnjiznica.Mobile
{
	public partial class MainPage : ContentPage
	{
        private IApiClient apiClient;
		public MainPage()
		{
            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            InitializeComponent();
		}

        private void Register_Me_EventHandler(object sender, EventArgs e)
        {

        }

        private async void Log_In_Event_Handler(object sender, EventArgs e)
        {
            var user= username.Text;
            var pass= password.Text;

            var result = await apiClient.LoginUser(new Commons.LoginVM
            {
                Password = pass,
                Username = user
            });

            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert("Login result", "Success","");
            }
            else
            {
                await DisplayAlert("Login result", "Success", "");
            }
        }
    }
}
    