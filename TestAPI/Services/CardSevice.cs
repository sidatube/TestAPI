using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAPI.Models;
using TestAPI.Adapters;
using SQLitePCL;

namespace TestAPI.Services
{
    interface ICardSevice
    {
        List<CardItem> getCart();
        bool addToCard(CardItem item);
        bool removeItem(CardItem item);
        bool updateItem(CardItem item, int qty);
        bool ClearCard();

    }
    class CardSevice : ICardSevice
    {
        public bool addToCard(CardItem item)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetIntance()._sQLiteConnection;
                string sql = "insert into Cart(id,name,image,price,qty) values(?,?,?,?,?)";
                var statement = connection.Prepare(sql);
                statement.Bind(1, item.id);
                statement.Bind(2, item.name);
                statement.Bind(3, item.image);
                statement.Bind(4, item.price);
                statement.Bind(5, item.qty);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public bool ClearCard()
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetIntance()._sQLiteConnection;
                string sql = "delete from Cart";
                var statement = connection.Prepare(sql);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch
            {
                return false;
            }
        }

        public List<CardItem> getCart()
        {
            List<CardItem> list = new List<CardItem>();
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetIntance()._sQLiteConnection;
                string sql = "select * from Cart";
                var statement = connection.Prepare(sql);
                //var rs = statement.Step();
                while (SQLiteResult.ROW == statement.Step())
                {
                    CardItem item = new CardItem()
                    {
                        id = Convert.ToInt32(statement[0]),
                        name = statement[1] as string,
                        image = statement[2] as string,
                        price = Convert.ToInt32(statement[3]),
                        qty = Convert.ToInt32(statement[4])
                    };
                    list.Add(item);
                }
            }
            catch (Exception e)
            {

            };
            return list;
        }

        public bool removeItem(CardItem item)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetIntance()._sQLiteConnection;
                string sql = "delete from Cart where id =?";
                var statement = connection.Prepare(sql);
                statement.Bind(1, item.id);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch
            {
                return false;
            }
        }

        public bool updateItem(CardItem item, int qty)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetIntance()._sQLiteConnection;
                string sql = "update Cart set qty=? where id =?";
                var statement = connection.Prepare(sql);
                statement.Bind(1, qty);
                statement.Bind(1, qty);
                statement.Bind(2, item.id);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch
            {
                return false;
            }
        }
    }
}
