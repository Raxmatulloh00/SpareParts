using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace SurveyHub.Admin.Services
{
    public class CookieService
    {
        private readonly IJSRuntime _jsRuntime;

        public CookieService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> GetCookie<T>(T modal, string name)
        {
            try
            {
                var res = await _jsRuntime.InvokeAsync<string>("getCookie", name);
                var data = JsonConvert.DeserializeObject<T>(res);
                return data ?? modal;
            }
            catch (Exception)
            {
                return modal;
            }
        }

        public async Task SetCookie<T>(T modal, string name, int minutes)
        {
            var value = JsonConvert.SerializeObject(modal);
            await _jsRuntime.InvokeVoidAsync("setCookie", name, value, minutes);
        }
        public async Task SetCookieWithExpiryDateTime(string name, string value, DateTime expirationDateTime)
        {
            await _jsRuntime.InvokeVoidAsync("setCookieWithExpirationDateTime", name, value, expirationDateTime);
        }


        public async Task DeleteCookie(string name)
        {
            await _jsRuntime.InvokeVoidAsync("deleteCookie", name);
        }
    }
}
