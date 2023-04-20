using Android.Net.Wifi.Aware;
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
    public partial class ContactUsPage : ContentPage
    {
        public ContactUsPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");
            InitializeComponent();
        }
      async  protected override void OnAppearing()
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("id") && Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {

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
                await Navigation.PushAsync(new GirisSayfasi());
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

      async  private void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
       await DisplayAlert("aa",    combobox.SelectedItem.ToString(),"cc");
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {

        }

       async private void btnOturumuKapat_Clicked(object sender, EventArgs e)
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

       async private void settingsCl_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage()); 
        }
    }
}