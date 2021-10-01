using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Models
{

    // home
    //public class DataHome
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    public string image { get; set; }
    //    public string description { get; set; }
    //    public int price { get; set; }
    //}

    public class RootHome
    {
        public string message { get; set; }
        public List<Food> data { get; set; }
    }
    //Category 
    public class DataMenu
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class RootMenu
    {
        public string message { get; set; }
        public List<DataMenu> data { get; set; }
    }
    //Eat-in
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
    }

    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }

    public class DataEat
    {
        public Category category { get; set; }
        public List<Food> foods { get; set; }
    }

    public class RootEat
    {
        public string message { get; set; }
        public DataEat data { get; set; }
    }
    //Details
    public class DataDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int price { get; set; }
    }

    public class RootDetail
    {
        public string message { get; set; }
        public DataDetail data { get; set; }
    }
    //Order 
    public class OrderDetail
    {
        public int order_id { get; set; }
    }

    public class CreateOrder
    {
        public string message { get; set; }
        public OrderDetail data { get; set; }
    }
}
