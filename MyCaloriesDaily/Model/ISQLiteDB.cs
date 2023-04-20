using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCaloriesDaily.Model
{
   public interface ISQLiteDB
    {
        SQLiteAsyncConnection GetConnection();
    }
}
