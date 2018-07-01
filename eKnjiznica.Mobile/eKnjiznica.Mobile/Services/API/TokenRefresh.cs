using eKnjiznica.Commons.ViewModels;
using eKnjiznica.Mobile.Services.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace eKnjiznica.Mobile.Services.API
{
    public class TokenRefresh : DelegatingHandler
    {
        public IUserService userService;
        public string RefreshTokenUri { get; set; }
        public TokenRefresh():base(new HttpClientHandler())
        {
            
        }
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var auth = userService.GetAuthenticationResponse();
            request.AppendToken(auth.AccessToken, auth.TokenType);
            var response = await base.SendAsync(request, cancellationToken);



            if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Unauthorized)
            {
                AuthenticationResponseVM refreshTokenResponse = await MakeRefreshTokenRequest(cancellationToken);

                if (refreshTokenResponse == null)
                {
                    App.Current.MainPage = new NavigationPage(new LoginPage());
                    return response;
                }
                userService.SaveAuthenticationResponse(refreshTokenResponse);
                request.AppendToken(refreshTokenResponse.AccessToken, refreshTokenResponse.TokenType);
                response = await base.SendAsync(request, cancellationToken);
            }

            return response;
        }

       
        private async Task<AuthenticationResponseVM> MakeRefreshTokenRequest(CancellationToken cancellationToken)
        {
            var auth = userService.GetAuthenticationResponse();
            string refresh_token = auth.RefreshToken;

            var dict = new Dictionary<string, string>
            {
                { "refresh_token", refresh_token },
                { "grant_type", "refresh_token" }
            };
            var refreshTokenRequest = new HttpRequestMessage(HttpMethod.Post, RefreshTokenUri) { Content = new FormUrlEncodedContent(dict) };
            var response = await base.SendAsync(refreshTokenRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null;
            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<AuthenticationResponseVM>(json);
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
