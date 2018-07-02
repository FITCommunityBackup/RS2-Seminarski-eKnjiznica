using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eKnjiznica.Commons.ViewModels.Error;
using Newtonsoft.Json;

namespace eKnjiznica.Commons.Util
{
    public class ErrorHandlingUtil
    {
        public async Task<string> GetErrorMessageAsync(HttpResponseMessage httpResponseMessage,string key)
        {
            try
            {
                var resultString = await httpResponseMessage.Content.ReadAsStringAsync();
                BaseErrorVM baseError = JsonConvert.DeserializeObject<BaseErrorVM>(resultString);
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
                var resultString = await result.Content.ReadAsStringAsync();
                var loginError = JsonConvert.DeserializeObject<LoginErrorVM>(resultString);

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
