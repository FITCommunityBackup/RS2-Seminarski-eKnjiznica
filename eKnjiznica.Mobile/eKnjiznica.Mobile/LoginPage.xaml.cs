using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels;
using eKnjiznica.Mobile.Navigation;
using eKnjiznica.Mobile.Services.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{

        private IApiClient apiClient;
        private ErrorHandlingUtil errorHandlingUtil;
        private IUserService userService;
        public LoginPage ()
		{

            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            this.errorHandlingUtil = ServiceLocator.Current.GetInstance<ErrorHandlingUtil>();
            this.userService= ServiceLocator.Current.GetInstance<IUserService>();

            InitializeComponent ();
		}


        private async void LoginBtn_Clicked(object sender, EventArgs e)
        {
            var uname =Username.Text;
            var password = Password.Text;
            if(string.IsNullOrEmpty(uname) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert(Commons.Resources.ERROR, Commons.Resources.PLEASE_FILL_IN_FIELDS, "OK");
                return;
            }
            var result = await apiClient.LoginUser(new Commons.LoginVM
            {
                Password = password,
                Username = uname
            },"mobile");


            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                var authResponse = JsonConvert.DeserializeObject<AuthenticationResponseVM>(json);
                userService.SaveAuthenticationResponse(authResponse);

                await Navigation.PopToRootAsync();
                App.Current.MainPage = new MyMasterDetailPage();
            }
            else
            {
                string error = await errorHandlingUtil.GetLoginErrorMessage(result);
                var title = Commons.Resources.LOGIN_ERROR;
                await DisplayAlert(title, error, "OK");
            }
        }

        private async void RegisterMeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterMePage());
        }
    }
}