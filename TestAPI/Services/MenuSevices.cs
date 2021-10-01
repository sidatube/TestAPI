using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace TestAPI.Services
{
    class MenuSevices
    {
        public async Task<Models.RootHome> GetHome()
        {
            Adapters.FoodGroup foodGroup = Adapters.FoodGroup.Getinstance();
            HttpClient hc = new HttpClient();// shipper -> lo việc kết nối api để lấy dữ liệu
            var rs = await hc.GetAsync(foodGroup.ApiHome);// get_file_content -> thao tác trả hàng của shipper
            if(rs.StatusCode== HttpStatusCode.OK)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();// chuyển thành string json
                Models.RootHome root = JsonConvert.DeserializeObject<Models.RootHome>(stringContent);
                return root;
            }
            return null;
        }
        public async Task<Models.RootMenu> GetMenu()
        {
            Adapters.FoodGroup foodGroup = Adapters.FoodGroup.Getinstance();
            HttpClient hc = new HttpClient();// shipper -> lo việc kết nối api để lấy dữ liệu
            var rs = await hc.GetAsync(foodGroup.ApiMenu);// get_file_content -> thao tác trả hàng của shipper
            if(rs.StatusCode== HttpStatusCode.OK)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();// chuyển thành string json
                Models.RootMenu root = JsonConvert.DeserializeObject<Models.RootMenu>(stringContent);
                return root;
            }
            return null;
        }
        public async Task<Models.RootDetail> GetDetail(string a)
        {
            Adapters.FoodGroup foodGroup = Adapters.FoodGroup.Getinstance();
            HttpClient hc = new HttpClient();// shipper -> lo việc kết nối api để lấy dữ liệu
            var rs = await hc.GetAsync(foodGroup.ApiDetail(a));// get_file_content -> thao tác trả hàng của shipper
            if(rs.StatusCode== HttpStatusCode.OK)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();// chuyển thành string json
                Models.RootDetail root = JsonConvert.DeserializeObject<Models.RootDetail>(stringContent);
                return root;
            }
            return null;
        }
        public async Task<Models.RootEat> GetData(string a)
        {
            Adapters.FoodGroup foodGroup = Adapters.FoodGroup.Getinstance();
            HttpClient hc = new HttpClient();// shipper -> lo việc kết nối api để lấy dữ liệu
            var rs = await hc.GetAsync(foodGroup.ApiCategory(a));// get_file_content -> thao tác trả hàng của shipper
            if(rs.StatusCode== HttpStatusCode.OK)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();// chuyển thành string json
                Models.RootEat root = JsonConvert.DeserializeObject<Models.RootEat>(stringContent);
                return root;
            }
            return null;
        } 
    }
}
