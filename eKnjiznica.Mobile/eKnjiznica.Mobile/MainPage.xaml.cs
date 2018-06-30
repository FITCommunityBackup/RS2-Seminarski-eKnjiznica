using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Mobile.Services.User;
using System;
using Xamarin.Forms;

namespace eKnjiznica.Mobile
{
	public partial class MainPage : ContentPage
	{
        private IUserService userService;

        public MainPage()
		{
            userService = ServiceLocator.Current.GetInstance<IUserService>();   
            InitializeComponent();
		}

        private async void BtnLogOut_Clicked(object sender, EventArgs e)
        {
            userService.LogoutUser();
            Navigation.InsertPageBefore(new LoginPage(),this);
            await Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
    