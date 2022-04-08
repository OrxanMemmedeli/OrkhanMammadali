using OrkhanMammadali.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace OrkhanMammadali.Tools
{
    public static class GetAdress
    {
        public static async Task<AdressViewModel> GetLastAdress()
        {
            var httpclient = new HttpClient();
            var responseMessage = await httpclient.GetAsync(url + "api/Default");
            var jsonString = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<AdressViewModel>(jsonString);
            return "";
        }
    }
}
