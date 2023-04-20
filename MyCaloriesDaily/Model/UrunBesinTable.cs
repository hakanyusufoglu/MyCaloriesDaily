using SQLite;

namespace MyCaloriesDaily.Model
{
    [Table("UrunBesinTable")]
    public class UrunBesinTable
    {
        [PrimaryKey,AutoIncrement]
        public int urunID { get; set; }
        public string urunAdi { get; set; }
        public float urunGram { get; set; }
        public int urunKalori { get; set; }
        public double urunProtein { get; set; }
        public double urunYag { get; set; }
        public double urunKarbonhidrat { get; set; }
    }
}
