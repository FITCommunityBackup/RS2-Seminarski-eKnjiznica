using eKnjiznica.Commons.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKnjiznica.AdminUI.Services.User
{
    public interface IUserService
    {
        void SaveAuthResponse(AuthenticationResponseVM response);
        void LogoutUser();
        bool IsUserLogged();
    }
}
