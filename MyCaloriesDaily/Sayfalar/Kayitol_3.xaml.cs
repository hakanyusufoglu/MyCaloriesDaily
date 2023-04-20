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
    public partial class Kayitol_3 : ContentPage
    {
        public Kayitol_3()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");

            InitializeComponent();
            
        }
        async void cachinghareketMiktari(int hareketMiktari)
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("hareketMiktari"))
                {
                    Application.Current.Properties.Remove("hareketMiktari");
                }
                else
                {
                    Application.Current.Properties["hareketMiktari"] = hareketMiktari;
                       // deneme await  DisplayAlert("asd", Application.Current.Properties["hareketMiktari"].ToString(), "çıkış");
                    await Navigation.PushAsync(new Sayfalar.Kayitol_4());
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Hata !", e.Message, "Çıkış");
            }
        }
          private void hareketYokBtn_Clicked(object sender, EventArgs e)
        {
            cachinghareketMiktari(0);//0 = hareket yok anlamında
        }

        private void azHareket_Clicked(object sender, EventArgs e)
        {
            cachinghareketMiktari(1);//1 = az hareket  anlamında
        }

        private void coguKezSporBtn_Clicked(object sender, EventArgs e)
        {
            cachinghareketMiktari(2); //2 = cogukez spor anlamında
        }

       async private void sikliklaBtn_Clicked(object sender, EventArgs e)
        {
            cachinghareketMiktari(3); //3 = siklikla  spor anlamında
        }
    }
}