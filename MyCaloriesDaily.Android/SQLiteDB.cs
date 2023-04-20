using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyCaloriesDaily.Model;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(MyCaloriesDaily.Droid.SQLiteDB))]
namespace MyCaloriesDaily.Droid
{
   public class SQLiteDB : ISQLiteDB
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentPath, "stajMyCaloriesDaily.db");
            return new SQLiteAsyncConnection(path);
        }
    }
}