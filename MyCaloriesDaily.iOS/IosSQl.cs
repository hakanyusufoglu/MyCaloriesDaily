using Foundation;
using MyCaloriesDaily.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UIKit;

namespace MyCaloriesDaily.iOS
{
    public class IosSQl : ISQLiteDB
    {
        public IosSQl()
        {
        }

    
      

        SQLiteAsyncConnection ISQLiteDB.GetConnection()
        {
            var fileName = "stajMyCaloriesDaily.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);

            var platform = new SQLite.SQLitePlatformIOS();
         
            var connection = new SQLite.SQLiteConnection(platform, path);

            return connection;
        }

    }
    
}