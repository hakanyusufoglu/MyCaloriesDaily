using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using static MyCaloriesDaily.Sayfalar.BreakfastPage;

namespace MyCaloriesDaily.Model
{

    [Table("KulKaloriUrunTable")]
   public class KulKaloriUrunTable
    {
        [PrimaryKey,AutoIncrement]
        public int kulKaloriUrunID { get; set; }

        
        public int kulKaloriID { get; set; }
        public int urunBesinID { get; set; }
        public int urunGramaji { get; set; }
        public int urunKaloriToplami { get; set; }
        public int yemekZamani { get; set; }
        public string raporTarihi { get; set; }
    }
}
