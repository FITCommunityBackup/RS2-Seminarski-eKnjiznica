using System;
using System.Collections.Generic;
using System.Text;
using eKnjiznica.Commons.ViewModels;

namespace eKnjiznica.Mobile.Services.User
{
    public class UserService : IUserService
    {
        private SettingsHelper settingsHelper;

        public UserService(SettingsHelper settingsHelper)
        {
            this.settingsHelper = settingsHelper;
        }

        public AuthenticationResponseVM GetAuthenticationResponse()
        {
            return settingsHelper.GetAuthenticationResponse();
        }

        public bool IsUserLogged()
        {
            var response = GetAuthenticationResponse();
            return response != null && !string.IsNullOrEmpty(response.AccessToken) && !string.IsNullOrEmpty(response.TokenType);
        }

        public void LogoutUser()
        {
            settingsHelper.SaveAuthenticationResponse(null);
        }

        public void SaveAuthenticationResponse(AuthenticationResponseVM saveAuthenticationResponse)
        {
            settingsHelper.SaveAuthenticationResponse(saveAuthenticationResponse);

        }
    }
}
