using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.Clients;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private IApiClient apiClient;
        private ClientVM Client;
        private ErrorHandlingUtil errorHandlingUtil;
        private MyRegex myRegex;
        public ProfilePage()
        {
            this.apiClient = ServiceLocator.Current.GetService<IApiClient>();
            this.errorHandlingUtil= ServiceLocator.Current.GetService<ErrorHandlingUtil>();
            this.myRegex = ServiceLocator.Current.GetService<MyRegex>();
            InitializeComponent();

        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await BindData();
           
        }

        private async Task BindData()
        {
            var result = await apiClient.GetClientAccount();
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                Client = JsonConvert.DeserializeObject<ClientVM>(json);
                PopulateData();
            }
        }

        private void PopulateData()
        {
            FullName.Text = Client.FirstName + " " + Client.LastName;
            BookNumber.Text = Client.BookNumber + " knjiga";
            AccountBalance.Text = Client.AccountBalance + " KM";
            Birthdate.Text = Client.DateOfBirth.ToShortDateString();
            FirstName.Text = Client.FirstName;
            LastName.Text = Client.LastName;
            Email.Text = Client.Email;
            PhoneNumber.Text = Client.PhoneNumber;
            OldPassword.Text = "";
            NewPassword.Text = "";
            BirthdateDtp.Date = Client.DateOfBirth;
            BirthdateDtp.MaximumDate = DateTime.Now.AddYears(-6);
            BirthdateDtp.MinimumDate = DateTime.Now.AddYears(-150);
        }

   

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!Valid())
                return;
            var error_key = "profile_update";
            var result = await apiClient.UpdateClientAccount(new ClientUpdateVM
            {
                FirstName = FirstName.Text.Trim(),
                LastName = LastName.Text.Trim(),
                DateOfBirth = BirthdateDtp.Date,
                Email = Email.Text.Trim(),
                PhoneNumber = PhoneNumber.Text.Trim(),
                Password = NewPassword.Text.Trim(),
                OldPassword = OldPassword.Text.Trim(),
            });

            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert(Commons.Resources.ACTION_SUCCESS, Commons.Resources.PROFILE_UPDATE_SUCCESS_MESSAGE, "OK");
                await BindData();
            }
            else
            {
                await DisplayAlert(Commons.Resources.ERROR, await errorHandlingUtil.GetErrorMessageAsync(result,error_key), "OK");

            }

        }

        private bool Valid()
        {
            if (string.IsNullOrEmpty(FirstName.Text) || string.IsNullOrEmpty(LastName.Text))
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIRST_AND_LAST_NAME_REQUIRED, "OK");
                return false;
            }

            if (!myRegex.IsValidEmail(Email.Text))
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIELD_EMAIL_INVALID, "OK");
                return false;
            }

            if (!myRegex.IsValidPhone(PhoneNumber.Text))
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIELD_PHONE_INVALID, "OK");
                return false;
            }

            if (!string.IsNullOrEmpty(OldPassword.Text) && !string.IsNullOrEmpty(NewPassword.Text))
            {
                if(!myRegex.ValidatePassword(OldPassword.Text) || !myRegex.ValidatePassword(NewPassword.Text))
                {
                    DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_INVALID_PASSWORD_FIELDS, "OK");
                    return false;
                }
            }

            return true;
        }
    }
}