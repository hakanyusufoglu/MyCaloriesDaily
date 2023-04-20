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
    public partial class CreatePost : ContentPage
    {
        public CreatePost()
        {
            InitializeComponent();
        }
      async  protected override void OnAppearing()
        {
            try { 
            if (Application.Current.Properties.ContainsKey("id") && Application.Current.Properties.ContainsKey("kaloriSiniri"))
            {
                int id = Convert.ToInt32(Application.Current.Properties["id"]);
                string avatar = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == id).FirstOrDefaultAsync().Result.image;
               userImage.Source = avatar;
                lblKullanici.Text = "Hoşgeldiniz " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(await DatabaseIslemleri.isimGetir(id));
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
        int begeniSayisi = 0;
        string resimYol = "dinner.png";
       async private void postSend_Clicked_2(object sender, EventArgs e)
        {
            try
            {
                int userId = Convert.ToInt32(Application.Current.Properties["id"]);
                DatabaseIslemleri.socialMediaInsert(userId, icerikYazisi.Text, begeniSayisi, resimYol);
              await  DisplayAlert("Tebrikler", "Gönderiniz Gönderilmiştir.", "Tamam");

              await  Navigation.PushAsync(new CommunityPage());
            }
            catch
            {
               await DisplayAlert("Hata", "Gönderi Paylaşma Başarısız Oldu", "Çıkış");
                await Navigation.PushAsync(new GirisSayfasi());
            }
        }
    }
}