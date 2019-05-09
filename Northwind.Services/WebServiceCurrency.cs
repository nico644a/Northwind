using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Northwind.Entities;

namespace Northwind.Servicel
{
    class WebServiceCurrency
    {
        readonly string url = @"https://openexchangerates.org/api/latest.json?app_id=e9d4fea2de054b06accca4c051a208d0";

        public Currency GetCurrency()
        {
            string urlforValuta = $@"{url}&symbols=DKK,EUR,AED,CAD,HKD";
            try
            {
                Task<string> resultTaks = CallWebApi(urlforValuta);
                return (Currency)UnpackFrom(resultTaks.Result);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private async Task<string> CallWebApi(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        private JsonCurrency UnpackFrom(string json)
        {
            return JsonConvert.DeserializeObject<JsonCurrency>(json);
        }

        
    }

    class JsonCurrency
    {
        public decimal DKK  { get; set;  }
      
        public static explicit operator Currency(JsonCurrency jsonCurrency)
        {
            return new Currency(jsonCurrency.DKK);
        }
    }
}
