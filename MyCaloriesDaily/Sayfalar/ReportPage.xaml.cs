using Android.Net.Wifi.Aware;
using Java.Security;
using Java.Security.Cert;
using MyCaloriesDaily.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCaloriesDaily.Sayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportPage : ContentPage
    {
        public ReportPage()
        {
            InitializeComponent();

            List<Calories> kaloriler = new List<Calories>();
            /*     kaloriler.Add(new Calories { id = 1, tur = "Kahvaltı", deger = 260 });
                 kaloriler.Add(new Calories { id = 2, tur = "Akşam Yemeği", deger = 690 });
                 kaloriler.Add(new Calories { id = 3, tur = "Öğle yemeği", deger = 150 });
            */
            // pieChart.ItemsSource = kaloriler;
            //gridList.ItemsSource = kaloriler;


        }
        async protected override void OnAppearing()
        {
            try
            {
                string bugun = DateTime.Now.ToString("MM/dd/yyyy");

                raporBilgisi(bugun);
                kaloriSiniriveAlinan(bugun);

                if (Application.Current.Properties.ContainsKey("id") && Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {
                    int id = Convert.ToInt32(Application.Current.Properties["id"]);
                    string avatar = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == id).FirstOrDefaultAsync().Result.image;
                    userImage.Source = avatar;
                    isimSoyisim.Text = "Hoşgeldiniz " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(await DatabaseIslemleri.isimGetir(id));
                }
            }
            catch
            {
                if (Application.Current.Properties.ContainsKey("id"))
                    Application.Current.Properties.Clear();

                await DisplayAlert("Hata", "Giriş Sayfasına Yönlendiriliyorsunuz", "Tamam");
                await Navigation.PushAsync(new GirisSayfasi());
            }


        }
        async void kaloriSiniriveAlinan(string tarih)
        {

            if (Application.Current.Properties.ContainsKey("id") && Application.Current.Properties.ContainsKey("kaloriSiniri"))
            {
                int userId = Convert.ToInt32(Application.Current.Properties["id"]);
                if (await DatabaseIslemleri.raporVarmi(userId, tarih))
                {

                    int kulKaloriId = await DatabaseIslemleri.kulKaloriIdGetir(userId, tarih);
                    int alinanKalori = Convert.ToInt32(DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == userId).Where(m => m.KulKaloriTableID == kulKaloriId).FirstOrDefaultAsync().Result.kaloriAlinan);

                    int kaloriSiniri = Convert.ToInt32(Application.Current.Properties["kaloriSiniri"]);
                    lblAlinanKalori.Text = "Alınan Kalori: " + alinanKalori;
                    lblKaloriSiniri.Text = "Kalori Sınırı " + kaloriSiniri;
                }
            }
        }
        List<Calories> deneme7;

        List<chartDeneme> deneme1;
        public class chartDeneme
        {
            public int id { get; set; }
            public string tur { get; set; }
            public int deger { get; set; }
        }












        public async void raporBilgisi(string tarih)
        {

            int userId = Convert.ToInt32(Application.Current.Properties["id"]);
            if (await DatabaseIslemleri.raporVarmi(userId, tarih))
            {


                deneme1 = new List<chartDeneme>();

                deneme1.Add(new chartDeneme
                {
                    tur = "Sabah",
                    deger = DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == userId).Where(m => m.tarih == tarih).FirstOrDefaultAsync().Result.sabahAlinan
                });
                deneme1.Add(new chartDeneme
                {
                    tur = "Oglen",
                    deger = DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == userId).Where(m => m.tarih == tarih).FirstOrDefaultAsync().Result.oglenAlinan
                });
                deneme1.Add(new chartDeneme
                {
                    tur = "aksam",
                    deger = DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == userId).Where(m => m.tarih == tarih).FirstOrDefaultAsync().Result.aksamAlinan
                });

                pieChart.ItemsSource = deneme1;

                IEnumerable<KulKaloriUrunTable> c2 = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == tarih).Where(m => m.kulKaloriID == userId).ToListAsync();

                deneme7 = new List<Calories>();
                foreach (var urunBesinID in c2)
                {
                    deneme7.Add(new Calories
                    {
                        urunAdi = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunAdi,
                        urunKalori = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID == urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunKaloriToplami,
                        urunGram = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID == urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunGramaji,
                        urunKarbonhidrat = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunKarbonhidrat,
                        urunProtein = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunProtein,
                        urunYag = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunYag,


                    });
                    //   List<KulKaloriUrunTable> c = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriID == userId).Where(m => m.raporTarihi == gelenTarih).ToListAsync().Result.GroupBy(m => m.yemekZamani == 0).Select(sinif=>new  })

                    // pieChart.ItemsSource = deneme7;

                }
                gridList.ItemsSource = deneme7;
            }
            else
            {

                await DisplayAlert("Rapor Bulunmamaktadır", "Raporunuz bulunmamaktadır", "Çıkış");
                tarihAlani.Date = DateTime.Now;
            }

        }
        private void menuBtn_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }
        async private void communityBtn_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CommunityPage());
        }


        async private void homeBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HomePage());
        }
        async private void reportBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ReportPage());
        }

        async private void nutritiveBtn_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NutritivePage());
        }

        async private void contactUsBtn_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactUsPage());
        }

        private void tarihAlani_DateSelected(object sender, DateChangedEventArgs e)
        {
            string date = e.NewDate.ToString("MM/dd/yyyy");
            raporBilgisi(date);
            kaloriSiniriveAlinan(date);

        }

        async private void oturumKapat_Clicked(object sender, EventArgs e)
        {
            if (Application.Current.Properties.ContainsKey("id"))
            {
                Application.Current.Properties.Remove("id");
                if (Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {
                    Application.Current.Properties.Remove("kaloriSiniri");
                }

                await Navigation.PushAsync(new GirisSayfasi());
            }
            await DisplayAlert("Çıkış Yapıldı", "Görüşmek Üzere ", "Kapat");
        }

        async private void settingsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}