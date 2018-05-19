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

namespace eKnjiznica.AdminUI.Services.API
{
    public class TokenHandler : DelegatingHandler
    {
        public string RefreshTokenUri { get; set; }
        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Create the response.
            string tokenType = Properties.Settings.Default.TokenType;
            string token= Properties.Settings.Default.Token;

            request.AppendToken(token, tokenType);
            var response = await base.SendAsync(request, cancellationToken);

            if (!response.IsSuccessStatusCode && response.StatusCode == HttpStatusCode.Unauthorized)
            {

                AuthenticationResponseVM refreshTokenResponse = await MakeRefreshTokenRequest(cancellationToken);

                if (refreshTokenResponse == null)
                    throw new ApiUnauthorizedException();
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

            var dict = new Dictionary<string,string>();
            dict.Add("refresh_token", refresh_token);
            dict.Add("grant_type", "refresh_token");
            var refreshTokenRequest = new HttpRequestMessage(HttpMethod.Post, RefreshTokenUri) { Content = new FormUrlEncodedContent(dict) };
            var response = await base.SendAsync(refreshTokenRequest, cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadAsAsync<AuthenticationResponseVM>();
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
