using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKnjiznica.Mobile
{
    public class SettingsHelper
    {
        private ISettings settings;
        private static string TOKEN_KEY = "TOKEN_KEY";
        private static string TOKEN_KEY_TYPE = "TOKEN_KEY_TYPE";
        public SettingsHelper(ISettings settings)
        {
            this.settings = settings;
        }

        public string GetToken()
        {
            return settings.GetValueOrDefault(TOKEN_KEY, null);
        }
        public string GetTokenType()
        {
            return settings.GetValueOrDefault(TOKEN_KEY_TYPE, null);
        }
    }
}
