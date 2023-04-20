using Android.Net.Wifi.Hotspot2;
using Android.Widget;
using MyCaloriesDaily.Sayfalar;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static MyCaloriesDaily.Sayfalar.BreakfastPage;

namespace MyCaloriesDaily.Model
{
  public static  class DatabaseIslemleri
    {
        public static SQLiteAsyncConnection connection  = DependencyService.Get<ISQLiteDB>().GetConnection();
        static public void CreateTable()
        {
      

             connection.CreateTableAsync<Model.KullaniciTable>().Wait();
            connection.CreateTableAsync<Model.UrunBesinTable>().Wait();
           connection.CreateTableAsync<Model.SosyalMedyaTable>().Wait();
           connection.CreateTableAsync<Model.KulKaloriTable>().Wait();
           connection.CreateTableAsync<Model.KulKaloriUrunTable>().Wait();
          
        }
        async static public Task<IList<UrunBesinTable>> getRecordBesinTable()
        {
            return await connection.Table<UrunBesinTable>().ToListAsync();
        }
        
        async static public void urunBesinTableInsert()
        {
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi="Alabalık",
                urunGram=100,
                urunYag=10,
                urunProtein=10.83,
                urunKarbonhidrat=0,
                urunKalori=168
            });
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Levrek",
                urunGram = 100,
                urunYag = 1.2,
                urunProtein = 19.2,
                urunKarbonhidrat = 0,
                urunKalori = 93
            });
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Palamut",
                urunGram = 100,
                urunYag = 7.3,
                urunProtein = 24,
                urunKarbonhidrat = 0,
                urunKalori = 168
            });
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Dana Eti Az Yağlı",
                urunGram = 100,
                urunKalori = 156,
                urunProtein = 19.7,
                urunYag = 8,
                urunKarbonhidrat = 0
              
            });
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Dana Eti Yağlı",
                urunGram = 100,
                urunKalori = 223,
                urunProtein = 18.5,
                urunYag = 16,
                urunKarbonhidrat = 0
              
            });
              await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Salam",
                urunGram = 100,
                urunKalori = 450,
                urunProtein = 23.8,
                urunYag = 38.1,
                urunKarbonhidrat = 1.2
              
            });
                await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Sucuk",
                urunGram = 100,
                urunKalori = 452,
                urunProtein = 21.4,
                urunYag = 40.8,
                urunKarbonhidrat = 0
              
            });           
            
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Yumurta",
                urunGram = 100,
                urunKalori = 158,
                urunProtein = 12.1,
                urunYag = 11.2,
                urunKarbonhidrat = 1.2
              
            });      
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Çikolata Fıstıklı",
                urunGram = 100,
                urunKalori = 543,
                urunProtein = 14.1,
                urunYag = 38.1,
                urunKarbonhidrat = 44.6
              
            });      
            await connection.InsertAsync(new UrunBesinTable
            {
                urunAdi = "Cips (Patates)",
                urunGram = 100,
                urunKalori = 568,
                urunProtein = 2.3,
                urunYag = 39.8,
                urunKarbonhidrat = 50
              
            });




        }

        async static public Task<IList<KulKaloriUrunTable>> getRecordurunKullaniciTable()
        {
            return await connection.Table<KulKaloriUrunTable>().ToListAsync();
        }
    

        async static public Task< List<UrunBesinTable>> urunGetir(int id)
        {
            IEnumerable<UrunBesinTable> urun = await getRecordBesinTable();
            return  urun.Where(m => m.urunID == id).ToList();
        }
        async static public void kulKaloriUrunInsert(int urunGrami,int kcal,int kulKaloriID ,int urunId, string kayitZamani,int yemeZamani)
        {
            await connection.InsertAsync(new KulKaloriUrunTable { 
            kulKaloriID=kulKaloriID,
            urunBesinID=urunId,
            urunGramaji=urunGrami,
            urunKaloriToplami=kcal,
            yemekZamani=yemeZamani,
            raporTarihi=kayitZamani
            
            });
              
        }
        async static public Task<IList<SosyalMedyaTable>> GetSosyalMedyaTables()
        {
            return await connection.Table<SosyalMedyaTable>().ToListAsync();
        }

        async static public void socialMediaInsert(int userId, string icerikYazisi, int begeniSayisi=0, string resimYol="dinner.png")
        {
            await connection.InsertAsync(new SosyalMedyaTable
            {
                kullaniciID = userId,
                gonderiAciklamasi = icerikYazisi,
                begeniSayisi = begeniSayisi,
                gonderiResim = resimYol,
                begendiMi = false,
                begenenKullaniciId = -1

            }); 
        }

        static async public Task<int> begeniSayisiGetir(int socialId)
        {
            int begeniSayisi = 0;
            IEnumerable<SosyalMedyaTable> sosyal = await GetSosyalMedyaTables();
            if (sosyal.Where(m => m.sosyalMedyaID == socialId).Any())
            {
                begeniSayisi = sosyal.Where(m => m.sosyalMedyaID == socialId).FirstOrDefault().begeniSayisi;
                return begeniSayisi;
            }
            else
                return begeniSayisi;

        }
        async static public void kullaniciUpdate(int userId,float boy,int cinsiyet,string email,DateTime dTarih,int hareketMiktari,int hedef,string userImage,string isim,string soyisim, int kaloriSiniri,float kilogram,string pass )
        {
            await connection.UpdateAsync(new KullaniciTable
            {
              kulID=userId,
              boy=boy,
              cinsiyet=cinsiyet,
              email=email,
              dogumTarihi=dTarih,
              hareketMiktari=hareketMiktari,
              hedef=hedef,
              image=userImage,
              isim=isim,
              soyisim=soyisim,
              kaloriSiniri=kaloriSiniri,
              kilogram=kilogram,
              password=pass
              

            });
        }
        async static public void begeniUptade(int contentId,int begeniSayisi,bool begendiMi)
        {
            await connection.UpdateAsync(new SosyalMedyaTable
            {
                sosyalMedyaID=contentId,
                begeniSayisi=begeniSayisi,
                begendiMi=begendiMi,
               

            });
        }
        async static public Task<IList<KulKaloriTable>> GetRecordsKulKaloriTable()
        {
            return await connection.Table<KulKaloriTable>().ToListAsync();
        }
        static async public Task<int> alinanKaloriGetir(int id,string tarih)
         {
            int alinanKalori= -1;
            IEnumerable<KulKaloriTable> kullaniciEmail = await GetRecordsKulKaloriTable();
            if (kullaniciEmail.Where(m => m.kullaniciID == id).Where(m=>m.tarih==tarih).Any())
            {
                alinanKalori = kullaniciEmail.Where(m => m.kullaniciID == id).Where(m=>m.tarih==tarih).FirstOrDefault().kaloriAlinan;
                return alinanKalori;
            }
            else
                return alinanKalori;

        }
        static async public Task<int> kulKaloriIdGetir(int id, string tarih)
        {
            int KulKaloriTableID = -1;
            IEnumerable<KulKaloriTable> kullaniciEmail = await GetRecordsKulKaloriTable();
            if (kullaniciEmail.Where(m => m.kullaniciID == id).Where(m => m.tarih == tarih).Any())
            {
                KulKaloriTableID = kullaniciEmail.Where(m => m.kullaniciID == id).Where(m => m.tarih == tarih).FirstOrDefault().KulKaloriTableID;
                return KulKaloriTableID;
            }
            else
                return KulKaloriTableID;

        }

        async static public void kulKaloriTableInsert(int kullaniciID,int sabahAlinan,int aksamAlinan,int oglenAlinan,  int kaloriAlinan, string tarih)
        {
            await connection.InsertAsync(new KulKaloriTable
            {
                
                kullaniciID = kullaniciID,
                kaloriAlinan = kaloriAlinan,
                sabahAlinan=sabahAlinan,
                aksamAlinan=aksamAlinan,
                oglenAlinan=oglenAlinan,
                tarih = tarih

            });

        }
        static async public Task<bool> raporVarmi(int id, string gun)
        {
            IEnumerable<KulKaloriTable> kullaniciEmail = await GetRecordsKulKaloriTable();
            if (kullaniciEmail.Where(m => m.kullaniciID == id).Where(m => m.tarih == gun).Any())
            {

                return true;
            }
            else
                return false;

        }
        static async public Task<bool> eklenenKaloriVarmi(int id, string gun)
        {
            IEnumerable<KulKaloriTable> kullaniciEmail = await GetRecordsKulKaloriTable();
            if (kullaniciEmail.Where(m => m.kullaniciID == id).Where(m => m.tarih == gun).Any())
            {

                return true;
            }
            else
                return false;

        }
        async static public void kulKaloriTableUpdate(int sabahKalori,int oglenKalori,int aksamKalori,int kulKaloriId,int kullaniciID, int kaloriAlinan, string tarih)
        {
            await connection.UpdateAsync(new KulKaloriTable
            {
                KulKaloriTableID=kulKaloriId,
                kullaniciID=kullaniciID,
                kaloriAlinan=kaloriAlinan,
                sabahAlinan=sabahKalori,
                aksamAlinan=aksamKalori,
                oglenAlinan=oglenKalori,
                tarih=tarih
    });
        }
        async static public void KullaniciTableInsert(int kaloriSinirim,int hareketMiktariP,string emailP,int cinsiyetP, string passwordP, string isimP, string soyisimP, DateTime dogumTarihiP, float boyP, float kilogramP, string imageP)
        {
            await connection.InsertAsync(new KullaniciTable
            {
                email = emailP,
                password = passwordP,
                cinsiyet = cinsiyetP,
                isim = isimP,
                soyisim = soyisimP,
                dogumTarihi = dogumTarihiP,
                boy = boyP,
                kaloriSiniri=kaloriSinirim,
                hareketMiktari = hareketMiktariP,
                kilogram = kilogramP,
                image = imageP


            }) ;
           
        }
        async static public Task<IList<KullaniciTable>> GetRecordsKullanici()
        {
            return await connection.Table<KullaniciTable>().ToListAsync();
        }
       
         static async  public Task<bool> emailVarmi(string emailP)
        {
            IEnumerable<KullaniciTable> kullaniciEmail = await GetRecordsKullanici();
            if (kullaniciEmail.Where(m => m.email == emailP).Any())
            {
                return true; 
            }
            else
                return false;

        }

        static async public Task<bool> kullaniciVarmi(string emailP,string passwordP) 
        {
            IEnumerable<KullaniciTable> kullaniciEmail = await GetRecordsKullanici();
            if (kullaniciEmail.Where(m => m.email == emailP).Where(m=>m.password==passwordP).Any())
            {
                
                return true;
            }
            else
                return false;

        }
        static async public Task<bool> kullaniciVarmi(int userId)
        {
            IEnumerable<KullaniciTable> kullaniciEmail = await GetRecordsKullanici();
            if (kullaniciEmail.Where(m => m.kulID == userId).Any())
            {

                return true;
            }
            else
                return false;

        }
        static async public Task<int> idGetir(string emailP, string passwordP)
        {
            IEnumerable<KullaniciTable> kullaniciEmail = await GetRecordsKullanici();
            if (kullaniciEmail.Where(m => m.email == emailP).Where(m => m.password == passwordP).Any())
            {

                return kullaniciEmail.Where(m => m.email == emailP).FirstOrDefault().kulID;
            }
            else
                return 0;

        }
        static async public Task<int> kaloriSiniriGetir(string emailP, string passwordP)
        {
            IEnumerable<KullaniciTable> kullaniciEmail = await GetRecordsKullanici();
            if (kullaniciEmail.Where(m => m.email == emailP).Where(m => m.password == passwordP).Any())
            {

                return kullaniciEmail.Where(m => m.email == emailP).FirstOrDefault().kaloriSiniri;
            }
            else
                return 0;

        }
        static async public Task<string> isimGetir(int id)
        {
            string isimSoyisim = "null";
            IEnumerable<KullaniciTable> kullaniciEmail = await GetRecordsKullanici();
            if (kullaniciEmail.Where(m => m.kulID == id).Any())
            {
                 isimSoyisim = kullaniciEmail.Where(m => m.kulID == id).FirstOrDefault().isim + " " + kullaniciEmail.Where(m => m.kulID == id).FirstOrDefault().soyisim;
                return isimSoyisim;
            }
            else
                return isimSoyisim;

        }

    }
}
