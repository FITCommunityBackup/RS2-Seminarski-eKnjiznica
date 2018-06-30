using eKnjiznica.Commons.ViewModels;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
namespace eKnjiznica.Mobile
{
    public class SettingsHelper
    {
        private ISettings settings;
        private static string AUTH_KEY = "TOKEN_KEY";
        public SettingsHelper(ISettings settings)
        {
            this.settings = settings;
        }

   

        public AuthenticationResponseVM GetAuthenticationResponse()
        {
            var jsonString = settings.GetValueOrDefault(AUTH_KEY, null);
            if (jsonString == null)
                return null;
            return Newtonsoft.Json.JsonConvert.DeserializeObject<AuthenticationResponseVM>(jsonString);
        }

        public  void SaveAuthenticationResponse(AuthenticationResponseVM saveAuthenticationResponse)
        {
            string json = null;
            if (saveAuthenticationResponse!=null)
                json = Newtonsoft.Json.JsonConvert.SerializeObject(saveAuthenticationResponse);
            settings.AddOrUpdateValue(AUTH_KEY, json);
        }

    }
}
