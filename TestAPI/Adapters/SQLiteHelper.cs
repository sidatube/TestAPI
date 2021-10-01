using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using System.IO;
using Windows.Storage;

namespace TestAPI.Adapters
{
    class SQLiteHelper
    {
        private readonly string Dbname = "TestAPI.db";
        private static SQLiteHelper sQLiteHelper;// ô nhớ lưu trưx 
        public SQLiteConnection _sQLiteConnection { get; set; }
        private SQLiteHelper()
        {
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, Dbname);
            _sQLiteConnection = new SQLiteConnection(path);
            var sql_txt = @"create table if not exists Cart(id integer primary key, name varchar(255), image varchar(255), price integer,qty integer)";
            var statement = _sQLiteConnection.Prepare(sql_txt);
            statement.Step();
        }
        public static SQLiteHelper GetIntance()
        {
            if (sQLiteHelper == null) sQLiteHelper = new SQLiteHelper();
            return sQLiteHelper;
        }
    }
}
