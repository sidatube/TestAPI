using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Adapters
{
    class FoodGroup
    {
        private readonly string baseURL = "http://foodgroup.herokuapp.com";
        private static FoodGroup instance;

        private FoodGroup()
        {

        }
        public static FoodGroup Getinstance()
        {
            if(instance == null)
            {
                instance = new FoodGroup();
            }
            return instance;
        }
        public string ApiHome
        {
            get => String.Format(baseURL + "/api/today-special");
        } 
        public string ApiCreateOrder
        {
            get => String.Format(baseURL + "/api/create-order");
        }
        public string ApiMenu
        {
            get => String.Format(baseURL + "/api/menu");
        }public string ApiCategory(string id)
        {
            return String.Format(baseURL + "/api/category/"+id);
        }public string ApiDetail(string id)
        {
            return String.Format(baseURL + "/api/food/"+id);
        }
    }
}
