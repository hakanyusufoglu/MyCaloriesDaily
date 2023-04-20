using MyCaloriesDaily.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCaloriesDaily.Sayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kayitol_4 : ContentPage
    {
        public Kayitol_4()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");
            InitializeComponent();
            
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {

        }
        async void cachingKullaniciBilgileri(string isim, string soyisim, DateTime dogumTarihi, string email, string password,int hedef)
        {
            try
            {
                if ( Application.Current.Properties.ContainsKey("isim") && Application.Current.Properties.ContainsKey("soyisim") && Application.Current.Properties.ContainsKey("dogumTarihi") && Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("password") && Application.Current.Properties.ContainsKey("hedef"))
                {
                    Application.Current.Properties.Remove("isim");
                    Application.Current.Properties.Remove("soyisim");
                    Application.Current.Properties.Remove("dogumTarihi");
                    Application.Current.Properties.Remove("email");
                    Application.Current.Properties.Remove("password");
                    Application.Current.Properties.Remove("hedef");
                   
                }
                else
                {
                    Application.Current.Properties["isim"] = isim;
                    Application.Current.Properties["soyisim"] = soyisim;
                    Application.Current.Properties["dogumTarihi"] = dogumTarihi;
                    Application.Current.Properties["email"] = email;
                    Application.Current.Properties["password"] = password;
                    Application.Current.Properties["hedef"] = hedef;

                    // deneme await  DisplayAlert("asd", Application.Current.Properties["hareketMiktari"].ToString(), "çıkış");
                    await DisplayAlert("asd", Application.Current.Properties["hedef"].ToString(), "çıkış");
                    await Navigation.PushAsync(new Sayfalar.Kayitol_5());
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Hata !", e.Message, "Çıkış");
            }
        }
     
      async  private void ilerleBtn_Clicked(object sender, EventArgs e)
        {
            int hedefNo = 0;

            string emailRegex=  "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (String.IsNullOrWhiteSpace(isimText.Text)||String.IsNullOrWhiteSpace(soyisimText.Text)||String.IsNullOrWhiteSpace(dogumTarihi.ToString())||string.IsNullOrWhiteSpace(passText.Text))
            {
                isimKontrol.HasError = true;
                soyisimKontrol.HasError = true;
                tarihKontrol.HasError = true;
                passKontrol.HasError = true;
                emailKontrol.HasError = true;
              await  DisplayAlert("Uyarı", "Lütfen gerekli alanları kontrol ediniz", "Çıkış");
            }
           else if(!(Regex.IsMatch(emailText.Text,emailRegex)))
            {
                emailKontrol.HasError = true;
                emailKontrol.ErrorText = "Lütfen email adresinizi doğru giriniz"; 
            }
           
            else if( await DatabaseIslemleri.emailVarmi(emailText.Text))
            {
                emailKontrol.HasError = true;
                emailKontrol.ErrorText = "Zaten bu email adresine ait bir hesap bulunmaktadır.";
            }
            else
            {
                
                if (radioKiloAlmak.IsChecked == true)
                {
                     hedefNo = 2;

                }
                if(radioKiloKorumak.IsChecked==true)
                {
                    hedefNo = 1;
                }
                if(radioKiloVermek.IsChecked==true)
                {
                    hedefNo = 0;
                }
                cachingKullaniciBilgileri(isimText.Text.ToString(),soyisimText.Text,dogumTarihi.Date,emailText.Text,passText.Text,hedefNo);
            }
           


        }
    }
}