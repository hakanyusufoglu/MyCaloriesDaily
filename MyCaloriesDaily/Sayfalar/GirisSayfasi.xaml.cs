using MyCaloriesDaily.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCaloriesDaily.Sayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class GirisSayfasi : ContentPage
    {
       
        public GirisSayfasi()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");
          
           
          
               
           
            
                InitializeComponent();

            try
            {
                Model.DatabaseIslemleri.CreateTable();

            }
            catch
            {
                DisplayAlert("Hata", "Bir sorun nedeniyle bağlanılamadı", "Çıkış");    
            }
        }
      
      async  protected override void OnAppearing()
        {
            try
            {
                Model.DatabaseIslemleri.CreateTable();

                DatabaseIslemleri.urunBesinTableInsert();
                int dd = Convert.ToInt32(Application.Current.Properties.ContainsKey("id"));
                if (Application.Current.Properties.ContainsKey("id"))
                {
                    // await   DisplayAlert("aa", Application.Current.Properties["id"].ToString(), "cc");
                    await Navigation.PushAsync(new HomePage());
                }
            }
            catch (Exception e)
            {
                if (Application.Current.Properties.ContainsKey("id"))
                    Application.Current.Properties.Clear();

                await DisplayAlert("Hata !", e.Message, "Çıkış");
            }
           
         
            
        }


        async private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Kayitol_1());
        }

      async  private void girisBtn_Clicked(object sender, EventArgs e)
        {
            if(await DatabaseIslemleri.kullaniciVarmi(emailText.Text,passText.Text))
            {
                int did = await DatabaseIslemleri.idGetir(emailText.Text, passText.Text);
                int kaloriSiniri = await DatabaseIslemleri.idGetir(emailText.Text, passText.Text);
                Application.Current.Properties["id"] = did;
                Application.Current.Properties["kaloriSiniri"] = await DatabaseIslemleri.kaloriSiniriGetir(emailText.Text,passText.Text);
                 await Navigation.PushAsync(new HomePage()); 
            }
            else
            {

               await DisplayAlert("Uyarı", "Böyle bir hesap bulunmamaktadır. Dilerseniz kayıt olabilirsiniz", "Tamam");
            }
        }

       
    }
}