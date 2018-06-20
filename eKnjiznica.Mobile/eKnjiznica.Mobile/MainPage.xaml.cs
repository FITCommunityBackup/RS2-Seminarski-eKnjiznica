using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using System;
using Xamarin.Forms;

namespace eKnjiznica.Mobile
{
	public partial class MainPage : ContentPage
	{
        private IApiClient apiClient;
        private ErrorHandlingUtil errorHandlingUtil;
        public MainPage()
		{
            //this.apiClient = ServiceLocator.Current.GetInstance(typeof(IApiClient));

            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            this.errorHandlingUtil = ServiceLocator.Current.GetInstance<ErrorHandlingUtil>();
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
                await DisplayAlert("Login result", "Success", "OK", "Otkazi");
            }
            else
            {
                string error = await errorHandlingUtil.GetLoginErrorMessage(result);
                var title = Commons.Resources.LOGIN_ERROR;
           
                await DisplayAlert(title, error,"OK");

            }
        }
    }
}
    