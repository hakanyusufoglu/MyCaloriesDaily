using MyCaloriesDaily.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace MyCaloriesDaily.Sayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NutritivePage : ContentPage
    {
        public NutritivePage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");
            InitializeComponent();
        }
       async  protected override void OnAppearing()
        {
            try { 
            if (Application.Current.Properties.ContainsKey("id") && Application.Current.Properties.ContainsKey("kaloriSiniri"))
            {
                    urunList.ItemsSource = await DatabaseIslemleri.getRecordBesinTable();

                    int id = Convert.ToInt32(Application.Current.Properties["id"]);
                string avatar = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == id).FirstOrDefaultAsync().Result.image;
                userImage.Source = avatar;
                kullaniciAdi.Text = "Hoşgeldiniz " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(await DatabaseIslemleri.isimGetir(id));
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
        private void menuBtn_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

       async private void qrCodeBtn_Clicked(object sender, EventArgs e)
        {
            ZXingScannerPage scanPage = new ZXingScannerPage();

            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                 
                    urunList.ItemsSource = await DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunAdi.ToLower().Contains(result.Text.ToLower())).ToListAsync();
                });
            };
            await Navigation.PushModalAsync(scanPage);
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

    async    private void SfButton_Clicked(object sender, EventArgs e)
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

     async   private void yiyecekSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            urunList.ItemsSource = await DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunAdi.ToLower().Contains(e.NewTextValue.ToLower())).ToListAsync();
        }

      async  private void settingsBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}