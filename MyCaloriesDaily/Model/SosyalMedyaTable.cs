using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCaloriesDaily.Model
{
    [Table("SosyalMedyaTable")]
    public class SosyalMedyaTable
    {
        [PrimaryKey,AutoIncrement]
        public int sosyalMedyaID { get; set; }
        public int kullaniciID{ get; set; }
        public string gonderiResim { get; set; }
        public string gonderiAciklamasi { get; set; }
        public int begeniSayisi { get; set; }
        public bool begendiMi { get; set; }
     public   int begenenKullaniciId { get; set; }
    }
}
