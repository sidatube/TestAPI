using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace TestAPI.Services
{
    class OrderSevice
    {
        public async Task<Models.CreateOrder> CreateOrder()
        {
            CardSevice cardSevice = new CardSevice();
            var items = cardSevice.getCart();
            if (items.Count > 0)
            {
                Adapters.FoodGroup fg = Adapters.FoodGroup.Getinstance();
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri(fg.ApiCreateOrder);
                HttpStringContent content = new HttpStringContent(
                    "items:" + Newtonsoft.Json.JsonConvert.SerializeObject(items),
                    UnicodeEncoding.Utf8, "application/json"
                    );
                HttpResponseMessage msg = await httpClient.PostAsync(uri, content);
                msg.EnsureSuccessStatusCode();
                var rsBody = await msg.Content.ReadAsStringAsync();
                Models.CreateOrder createOrder = JsonConvert.DeserializeObject<Models.CreateOrder>(rsBody);
                return createOrder;
                // sau khi nhận or
            }
            return null;

        }
    }
}
