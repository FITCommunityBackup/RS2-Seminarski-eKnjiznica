using System;
using System.Collections.Generic;
using System.Text;
using eKnjiznica.Commons.ViewModels;
namespace eKnjiznica.Mobile.Services.User
{
    public interface IUserService
    {
        AuthenticationResponseVM GetAuthenticationResponse();
        void SaveAuthenticationResponse(AuthenticationResponseVM  saveAuthenticationResponse);
        bool IsUserLogged();
        void LogoutUser();
        bool HasUserTokenExpired();
    }
}
