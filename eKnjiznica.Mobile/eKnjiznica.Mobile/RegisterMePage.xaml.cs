using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.Util;
using eKnjiznica.Commons.ViewModels.Clients;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterMePage : ContentPage
    {
        private IApiClient apiClient;
        private ErrorHandlingUtil errorHandlingUtil;
        private MyRegex myRegex;
        public RegisterMePage()
        {
            InitializeComponent();
            apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
            errorHandlingUtil = ServiceLocator.Current.GetInstance<ErrorHandlingUtil>();
            myRegex = ServiceLocator.Current.GetInstance<MyRegex>();


            BirthdayDate.MaximumDate = DateTime.Now;
            BirthdayDate.MinimumDate = DateTime.Now.AddYears(-150);
            BirthdayDate.Date = DateTime.Now;

        }

        private async void RegisterMe_Clicked(object sender, EventArgs e)
        {
            if (!Valid())
                return;
            ClientAddVM addVM = new ClientAddVM
            {
                DateOfBirth = BirthdayDate.Date,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                Email = Email.Text,
                Password = Password.Text,
                PhoneNumber = PhoneNumber.Text,
                UserName = UserName.Text
            };

            var result = await apiClient.CreateClientAccount(addVM);
            if (result.IsSuccessStatusCode)
            {
                await DisplayAlert(Commons.Resources.CLIENT_ADD_SUCCESS_TITLE, Commons.Resources.CLIENT_ADD_SUCCESS_MESSAGE, "OK");
            }
            else
            {
                var error = await errorHandlingUtil.GetErrorMessageAsync(result, "create_client");
                await DisplayAlert(Commons.Resources.REGISTRATION_ERROR, error, "OK");
            }
        }

        private bool Valid()
        {

            //DateOfBirth = BirthdayDate.Date,
            //    FirstName = FirstName.Text,
            //    LastName = LastName.Text,
            //    Email = Email.Text,
            //    Password = Password.Text,
            //    PhoneNumber = PhoneNumber.Text,
            //    UserName = UserName.Text
            if (string.IsNullOrEmpty(FirstName.Text) || string.IsNullOrEmpty(LastName.Text))
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIRST_AND_LAST_NAME_REQUIRED, "OK");
                return false;
            }
            if (UserName.Text.Length < 6)
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIELD_USERNAME_INVALID, "OK");
                return false;
            }

            if (!myRegex.ValidatePassword(Password.Text))
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIELD_PASSWORD_INVALID, "OK");
                return false;
            }
            if (!myRegex.IsValidPhone(PhoneNumber.Text))
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIELD_PHONE_INVALID, "OK");
                return false;
            }
            if (!myRegex.IsValidEmail(Email.Text))
            {
                DisplayAlert(Commons.Resources.ERROR, Commons.Resources.ERR_FIELD_EMAIL_INVALID, "OK");
                return false;

            }
     
          

        
            return true;
        }
    }
}