using eKnjiznica.Commons.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.AdminUI.Services.User
{
    public class UserService : IUserService
    {
        public bool IsUserLogged()
        {
            var token = Properties.Settings.Default.Token;
            var refreshToken = Properties.Settings.Default.RefreshToken;
            var tokenType = Properties.Settings.Default.TokenType;
            return !string.IsNullOrEmpty(token) && !string.IsNullOrEmpty(refreshToken) && !string.IsNullOrEmpty(tokenType);
        }

        public void LogoutUser()
        {
            Properties.Settings.Default.Token = "";
            Properties.Settings.Default.RefreshToken = "";
            Properties.Settings.Default.TokenType = "";
            Properties.Settings.Default.Save();
        }

        public void SaveAuthResponse(AuthenticationResponseVM response)
        {
            Properties.Settings.Default.Token = response.AccessToken;
            Properties.Settings.Default.RefreshToken = response.RefreshToken;
            Properties.Settings.Default.TokenType = response.TokenType;
            Properties.Settings.Default.Save();
        }
    }
}
