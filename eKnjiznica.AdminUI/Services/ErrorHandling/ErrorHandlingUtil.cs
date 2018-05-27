using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Error;

namespace eKnjiznica.AdminUI.Services.ErrorHandling
{
    public class ErrorHandlingUtil
    {
        public async Task<string> GetErrorMessageAsync(HttpResponseMessage httpResponseMessage,string key)
        {
            try
            {
                BaseErrorVM baseError = await 
                    httpResponseMessage.Content.ReadAsAsync<BaseErrorVM>();
                if (baseError == null)
                    return Commons.Resources.UNEXPECTED_ERROR_OCURRED;

                var modelState = baseError.ModelState;
                if (modelState== null)
                    return Commons.Resources.UNEXPECTED_ERROR_OCURRED;


                if (!modelState.ContainsKey(key) ||modelState[key].Count==0)
                    return Commons.Resources.UNEXPECTED_ERROR_OCURRED;

                return modelState[key][0];
            }
            catch(Exception e)
            {

            }
            return Commons.Resources.UNEXPECTED_ERROR_OCURRED; ;
        }

        public async Task<string> GetLoginErrorMessage(HttpResponseMessage result)
        {
            try
            {
                var loginError = await result.Content.ReadAsAsync<LoginErrorVM>();
                if (loginError != null && string.IsNullOrEmpty(loginError.ErrorDescription))
                    return Commons.Resources.UNEXPECTED_ERROR_OCURRED;
                return loginError.ErrorDescription;
            }
            catch (Exception e)
            {
                return Commons.Resources.UNEXPECTED_ERROR_OCURRED;
            }
        }
    }
}
