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
    public partial class Kayitol_5 : ContentPage
    {
        public Kayitol_5()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");
            InitializeComponent();
        }
        void kaloriSinirHesapla()
        {

        }

       void cacheTemizle()
        {
            try { 
           if(Application.Current.Properties.ContainsKey("cinsiyet")&& Application.Current.Properties.ContainsKey("hareketMiktari")&& Application.Current.Properties.ContainsKey("isim") && Application.Current.Properties.ContainsKey("soyisim") && Application.Current.Properties.ContainsKey("dogumTarihi") && Application.Current.Properties.ContainsKey("email") && Application.Current.Properties.ContainsKey("password"))
            {
                Application.Current.Properties.Remove("cinsiyet"); //sadece idyi tutmuyordum ama oda autoincrement onu nasıl yakalıcam ki nerde tutcan burda rnyi nerde tutcam olm id yi hangi fonksiyonda tutcan yani diğerlerini nerde tutuyosdun
                Application.Current.Properties.Remove("hareketMiktari");
                Application.Current.Properties.Remove("isim");
                Application.Current.Properties.Remove("dogumTarihi");
                Application.Current.Properties.Remove("email");
                Application.Current.Properties.Remove("password");
            }
            }
            catch(Exception e)
            {

                DisplayAlert("Hata ! ", e.Message, "Çıkış");


            }
        } //cache atadığım bilgilerin sonrasında silinmesi için remove ediyorum.

        async void cachingid(int id)
        {
            try
            {
                if (Application.Current.Properties.ContainsKey("id"))
                {
                    Application.Current.Properties.Remove("id");
                }
                else
                {
                    Application.Current.Properties["id"] = id;
                    //   deneme  await   DisplayAlert("asd", Application.Current.Properties["cinsiyet"].ToString(), "çıkış");
                }
            }
            catch (Exception e)
            {
                await DisplayAlert("Hata !", e.Message, "Çıkış");
            }
        }
        async  private void tamamlaBtn_Clicked(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(boyText.Text)||String.IsNullOrEmpty(kilogramText.Text))
            {
                boyKontrol.HasError = true;
                kilogramKontrol.HasError = true;
                
            }
            else if(!(float.Parse(boyText.Text.ToString())>120&&float.Parse(boyText.Text.ToString())<270))
            {
              await  DisplayAlert("Uyarı", "Lütfen Geçerli Boy (CM) Girininiz","Çıkış");
            }
            else if (!(float.Parse(kilogramText.Text.ToString()) > 40 && float.Parse(kilogramText.Text.ToString()) < 270))
            {
               await DisplayAlert("Uyarı", "Lütfen Geçerli Kilo (KG) Girininiz", "Çıkış");
            }
           
            else
            {
                int cinsiyet = Convert.ToInt32(Application.Current.Properties["cinsiyet"]);
                int hareketMiktari = Convert.ToInt32(Application.Current.Properties["hareketMiktari"]);
                string isim = Application.Current.Properties["isim"].ToString();
                string soyisim = Application.Current.Properties["soyisim"].ToString();
                DateTime dogumTarihi = Convert.ToDateTime(Application.Current.Properties["dogumTarihi"]);
                string email = Application.Current.Properties["email"].ToString();
                string password = Application.Current.Properties["password"].ToString();
                string resim = "userprofile.png";
                int yasim = DateTime.Now.Year - dogumTarihi.Year;

                int kaloriSinirim = kulKaloriSinir(hareketMiktari, cinsiyet, Convert.ToInt32(boyText.Text), yasim, Convert.ToInt32(kilogramText.Text));
                DatabaseIslemleri.KullaniciTableInsert(kaloriSinirim,hareketMiktari, email, cinsiyet, password, isim, soyisim, dogumTarihi, float.Parse(boyText.Text), float.Parse(kilogramText.Text), resim);
                //bakcam bakalım
                cachingid(await DatabaseIslemleri.idGetir(email, password));
                if(Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {
                    Application.Current.Properties.Remove("kaloriSiniri");
                }
                else
                Application.Current.Properties["kaloriSiniri"] = await DatabaseIslemleri.kaloriSiniriGetir(email,password);

               Application.Current.Properties["id"] = await DatabaseIslemleri.idGetir(email, password);
                int userId = Convert.ToInt32( Application.Current.Properties["id"]);
                await DisplayAlert("baslik", userId.ToString(), "cikis");
               
                await DisplayAlert("Tebrikler", "Başarılı şekilde kayıt oldunuz.", "çıkış");
                if (Application.Current.Properties.ContainsKey("id"))
                    await Navigation.PushAsync(new Sayfalar.HomePage());
       
                    cacheTemizle();

             

            }




     
        }
        public int kulKaloriSinir(int hareketMiktari,int cinsiyet, int boy, int yas, double kilo)
        {
            if (cinsiyet == 1)
            {
                if(hareketMiktari==0)
                {
                    return (int)(66 + (13.7 * kilo) + (5 * boy) - (6.8 * yas))-100;
                }
           else     if (hareketMiktari == 1)
                {
                    return (int)(66 + (13.7 * kilo) + (5 * boy) - (6.8 * yas)) - 50;
                }
            else    if (hareketMiktari == 2)
                {
                    return (int)(66 + (13.7 * kilo) + (5 * boy) - (6.8 * yas)) - 30;
                }
             else   if (hareketMiktari == 3)
                {
                    return (int)(66 + (13.7 * kilo) + (5 * boy) - (6.8 * yas)) +20;
                }

            }
            else
            {
                if(hareketMiktari==0)
                {
                    return (int)(665 + (9.6 * kilo) + (1.8 * boy) - (4.7 * yas))-70;
                }
            else    if (hareketMiktari == 1)
                {
                    return (int)(665 + (9.6 * kilo) + (1.8 * boy) - (4.7 * yas)) - 35;
                }
             else   if (hareketMiktari == 2)
                {
                    return (int)(665 + (9.6 * kilo) + (1.8 * boy) - (4.7 * yas)) - 15;
                }
              else if (hareketMiktari == 3)
                {
                    return (int)(665 + (9.6 * kilo) + (1.8 * boy) - (4.7 * yas)) +10;
                }

            }
            return -1;

        }
        private void kilogramText_TextChanged(object sender, TextChangedEventArgs e)
        {
           
           
            
        }

    }
}