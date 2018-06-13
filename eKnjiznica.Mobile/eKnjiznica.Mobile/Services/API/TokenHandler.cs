using eKnjiznica.Commons.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace eKnjiznica.Mobile.Services.API
{
    public class TokenHandler : DelegatingHandler
    {
        public IUnityContainer Container { get; set; }
        public string RefreshTokenUri { get; set; }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {

            string tokenType = Properties.Settings.Default.TokenType;
            string token = Properties.Settings.Default.Token;
            request.AppendToken(token, tokenType);
            var response = await base.SendAsync(request, cancellationToken);



            if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Unauthorized)
            {

                AuthenticationResponseVM refreshTokenResponse = await MakeRefreshTokenRequest(cancellationToken);

                if (refreshTokenResponse == null)
                {
                    var form = Container.Resolve<LoginForm>();
                    if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    {
                        Properties.Settings.Default.RefreshToken = "";
                        Properties.Settings.Default.Token = "";
                        Properties.Settings.Default.TokenType = "";
                        Properties.Settings.Default.Save();
                        Application.Exit();
                    }
                    return response;
                }
                SaveNewAuthorizationData(refreshTokenResponse);
                request.AppendToken(refreshTokenResponse.AccessToken, refreshTokenResponse.TokenType);
                response = await base.SendAsync(request, cancellationToken);
            }


            return response;
        }

        private void SaveNewAuthorizationData(AuthenticationResponseVM refreshTokenResponse)
        {
            Properties.Settings.Default.RefreshToken = refreshTokenResponse.RefreshToken;
            Properties.Settings.Default.TokenType = refreshTokenResponse.TokenType;
            Properties.Settings.Default.Token = refreshTokenResponse.AccessToken;
            Properties.Settings.Default.Save();
        }

        private async Task<AuthenticationResponseVM> MakeRefreshTokenRequest(CancellationToken cancellationToken)
        {
            string refresh_token = Properties.Settings.Default.RefreshToken;

            var dict = new Dictionary<string, string>
            {
                { "refresh_token", refresh_token },
                { "grant_type", "refresh_token" }
            };
            var refreshTokenRequest = new HttpRequestMessage(HttpMethod.Post, RefreshTokenUri) { Content = new FormUrlEncodedContent(dict) };
            var response = await  base.SendAsync(refreshTokenRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null;

            return  response.Content.ReadAsAsync<AuthenticationResponseVM>().Result;
        }




    }
    public static class TokenRequestExtensions
    {
        public static void AppendToken(this HttpRequestMessage request, string token, string tokenType)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(tokenType))
                return;
            request.Headers.Authorization = new AuthenticationHeaderValue(tokenType, token);
        }
    }


}
