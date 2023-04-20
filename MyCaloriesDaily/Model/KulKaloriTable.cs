using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCaloriesDaily.Model
{
    [Table ("KulKaloriTable")]
   public class KulKaloriTable
    {
        [PrimaryKey, AutoIncrement]
        public int KulKaloriTableID { get; set; }

        public int kullaniciID { get; set; }

        public int kaloriAlinan { get; set; }
        public int sabahAlinan { get; set; }
        public int oglenAlinan { get; set; }
        public int aksamAlinan { get; set; }
        public string tarih { get; set; }
    }
}
