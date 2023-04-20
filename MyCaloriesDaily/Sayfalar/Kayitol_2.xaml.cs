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
    public partial class Kayitol_2 : ContentPage
    {
        public Kayitol_2()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");
            InitializeComponent();

            
        }
      async  void cachingCinsiyet(int cinsiyetDeger)
        {
            try
            { 
            if (Application.Current.Properties.ContainsKey("cinsiyet"))
            {
                Application.Current.Properties.Remove("cinsiyet");
            }
            else
            {
                Application.Current.Properties["cinsiyet"] = cinsiyetDeger;
                 //   deneme  await   DisplayAlert("asd", Application.Current.Properties["cinsiyet"].ToString(), "çıkış");
                await Navigation.PushAsync(new Sayfalar.Kayitol_3());
            }
            }
            catch (Exception e)
            {
               await DisplayAlert("Hata !", e.Message, "Çıkış");
            }
        }
        private void womanBtn_Clicked(object sender, EventArgs e)
        {
            cachingCinsiyet(0); //0 kadın


        }

        private void manBtn_Clicked(object sender, EventArgs e)
        {
            cachingCinsiyet(1); //1 erkek
           
        }
    }
}