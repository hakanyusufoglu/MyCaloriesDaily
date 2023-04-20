using SQLite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCaloriesDaily.Model
{
    [Table("KullaniciTable")]
    public class KullaniciTable
    {
        [PrimaryKey, AutoIncrement]
        public int kulID { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public int cinsiyet { get; set; }
        public int hareketMiktari { get; set; }
        public DateTime dogumTarihi { get; set; }
        public float boy { get; set; }
        public float kilogram { get; set; }
        public string image { get; set; }
        public int hedef { get; set; }
        
        public int kaloriSiniri { get; set; }
    }
 
}
