using Android.Media;
using Java.Security.Cert;
using MyCaloriesDaily.Model;
using Syncfusion.XForms.Buttons;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyCaloriesDaily.Sayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");
            InitializeComponent();
        }
      async  protected override void OnAppearing()
        {
            try
            {

                int userId = Convert.ToInt32(Application.Current.Properties["id"]);
                string isim = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.isim.ToString();
                string soyisim = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.soyisim.ToString();
                string emails = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.email.ToString();
                string imageUser = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.image.ToString();
                int hedef = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.hedef.ToString());
                float boy = float.Parse(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.boy.ToString());
                float kilo = float.Parse(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.kilogram.ToString());
                lblKullaniciAdi.Text = "Merhaba " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(isim) + " " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(soyisim);
                emailText.Text = emails;
                boyText.Text = boy.ToString();
                kilogramText.Text = kilo.ToString();
                if (hedef == 0)
                {
                    radioKiloVermek.IsChecked = true;
                    radioKiloKorumak.IsChecked = false;
                    radioKiloAlmak.IsChecked = false;

                }
                if (hedef == 1)
                {
                    radioKiloVermek.IsChecked = false;
                    radioKiloKorumak.IsChecked = true;
                    radioKiloAlmak.IsChecked = false;

                }
                if (hedef == 2)
                {
                    radioKiloVermek.IsChecked = false;
                    radioKiloKorumak.IsChecked = false;
                    radioKiloAlmak.IsChecked = true;

                }
                //   imageBtn.BackgroundImage = imageUser;
            }
            catch
            {
                if (Application.Current.Properties.ContainsKey("id"))
                    Application.Current.Properties.Clear();
              await  DisplayAlert("Hata", "Giriş Sayfasına Yönlendiriliyorsunuz", "Tamam");
                await Navigation.PushAsync(new GirisSayfasi());
            }
        }
        Label popupContent;
        DataTemplate contentTemplateView;
        SfPopupLayout popupLayout = new SfPopupLayout();
        Entry entry1;
        Label yiyecekGramText;
        Label yiyecekKaloriText;

        void popupOlustur()
        {
           
           contentTemplateView = new DataTemplate(() =>
            {
                SfButton btn1 = new SfButton
                {
                    CornerRadius = 40,
                    ImageWidth = 10,
                    HeightRequest = 300,
                    BackgroundColor = Color.Transparent,
                    BackgroundImage = "person.png"
                };
                btn1.Clicked += Btn1_Clicked;

                SfButton btn2 = new SfButton
                {
                    CornerRadius = 40,
                    ImageWidth = 10,
                    HeightRequest = 300,
                    BackgroundColor = Color.Transparent,
                    BackgroundImage = "userprofile.png"
                };
                btn2.Clicked += Btn2_Clicked;

                SfButton btn3 = new SfButton
                {
                    CornerRadius = 40,
                    HeightRequest=300,
                    ImageWidth=10,
                    BackgroundColor = Color.Transparent,
                    BackgroundImage = "robotandTalk.jpg"
                };
                btn3.Clicked += Btn3_Clicked;

                StackLayout s1 = new StackLayout { 
                HeightRequest=1000
                };
                s1.Children.Add(btn3);
                s1.Children.Add(btn2);
                s1.Children.Add(btn1);
                ScrollView a = new ScrollView();
                a.Content = s1;
                return a;


            });

            popupLayout.PopupView.HeightRequest = 450;
            popupLayout.PopupView.HeaderTitle = "Avatarınızı Seçiniz";
            popupLayout.PopupView.AnimationMode = AnimationMode.Zoom;

            popupLayout.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            popupLayout.PopupView.AcceptButtonText = "Onayla";
            popupLayout.PopupView.DeclineButtonText = "Vazgeç";
            popupLayout.PopupView.AcceptCommand = new Command(() => PopupAcceptButton());
            popupLayout.PopupView.DeclineCommand = new Command(() => PopupDeclineButton());
            popupLayout.PopupView.ShowFooter = true;
            popupLayout.PopupView.PopupStyle.AcceptButtonBackgroundColor = Color.FromHex("#28B351");

            popupLayout.PopupView.PopupStyle.AcceptButtonTextColor = Color.White;

            popupLayout.PopupView.PopupStyle.DeclineButtonBackgroundColor = Color.FromHex("#FF0000");
            popupLayout.PopupView.PopupStyle.DeclineButtonTextColor = Color.White;
            popupLayout.PopupView.PopupStyle.HeaderBackgroundColor = Color.FromHex("#33569F");
            popupLayout.PopupView.PopupStyle.HeaderFontFamily = "Helvetica - Bold";
            popupLayout.PopupView.PopupStyle.HeaderTextColor = Color.White;
            popupLayout.PopupView.ContentTemplate = contentTemplateView;
        }

        private void Btn3_Clicked(object sender, EventArgs e)
        {
            var s = (sender as SfButton);
            var selectedImage1 = s.BackgroundImage as FileImageSource;
            btn3Yol = selectedImage1.File.ToString();
        }

        private void Btn1_Clicked(object sender, EventArgs e)
        {
            var s = (sender as SfButton);
            var selectedImage1 = s.BackgroundImage as FileImageSource;
            btn1Yol = selectedImage1.File.ToString();
        }
        string btn2Yol = ""; string btn1Yol = ""; string btn3Yol = "";
        private void Btn2_Clicked(object sender, EventArgs e)
        {
            var s = (sender as SfButton);
            var selectedImage1 = s.BackgroundImage as FileImageSource;
            btn2Yol = selectedImage1.File.ToString();
        }

        private void PopupDeclineButton()
        {
            throw new NotImplementedException();
        }

      async  private void PopupAcceptButton()
        {
            try
            {


                string email = "";
                float boy = 0;
                float kilogram = 0;
                DateTime tarih;
                int hedefNo = 0;
                string emailRegex = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (String.IsNullOrWhiteSpace(dogumTarihi.ToString()) || string.IsNullOrWhiteSpace(emailText.Text))
                {
                    tarihKontrol.HasError = true;
                    emailKontrol.HasError = true;
                    await DisplayAlert("Uyarı", "Lütfen gerekli alanları kontrol ediniz", "Çıkış");
                }
                else if (!(Regex.IsMatch(emailText.Text, emailRegex)))
                {
                    emailKontrol.HasError = true;
                    emailKontrol.ErrorText = "Lütfen email adresinizi doğru giriniz";
                }


                else if (String.IsNullOrEmpty(boyText.Text) || String.IsNullOrEmpty(kilogramText.Text))
                {
                    boyKontrol.HasError = true;
                    kilogramKontrol.HasError = true;

                }
                else if (!(float.Parse(boyText.Text.ToString()) > 120 && float.Parse(boyText.Text.ToString()) < 270))
                {
                    await DisplayAlert("Uyarı", "Lütfen Geçerli Boy (CM) Girininiz", "Çıkış");
                }
                else if (!(float.Parse(kilogramText.Text.ToString()) > 40 && float.Parse(kilogramText.Text.ToString()) < 270))
                {
                    await DisplayAlert("Uyarı", "Lütfen Geçerli Kilo (KG) Girininiz", "Çıkış");
                }

                else
                {
                    email = emailText.Text;
                    boy = float.Parse(boyText.Text);
                    kilogram = float.Parse(kilogramText.Text);
                    tarih = dogumTarihi.Date;




                    if (radioKiloAlmak.IsChecked == true)
                    {
                        hedefNo = 2;

                    }
                    if (radioKiloKorumak.IsChecked == true)
                    {
                        hedefNo = 1;
                    }
                    if (radioKiloVermek.IsChecked == true)
                    {
                        hedefNo = 0;
                    }

                    int userId = Convert.ToInt32(Application.Current.Properties["id"]);
                    string isim = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.isim.ToString();
                    string soyisim = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.soyisim.ToString();
                    int hareketMiktari = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.hareketMiktari.ToString());
                    int hedef = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.hedef.ToString());
                    string pass = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.password.ToString();
                    string imageUser = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.image.ToString();
                    int cinsiyet = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.cinsiyet.ToString());
                    int kaloriSiniri = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.kaloriSiniri.ToString());
                    string profileImage = "userprofile.png";
                    if (!string.IsNullOrWhiteSpace(btn1Yol) && string.IsNullOrWhiteSpace(btn2Yol) && string.IsNullOrWhiteSpace(btn3Yol))
                    {
                        DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, btn1Yol, isim, soyisim, kaloriSiniri, kilogram, pass);

                    }
                    else if (!string.IsNullOrWhiteSpace(btn2Yol) && string.IsNullOrWhiteSpace(btn1Yol) && string.IsNullOrWhiteSpace(btn3Yol))
                    {
                        DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, btn2Yol, isim, soyisim, kaloriSiniri, kilogram, pass);

                    }
                    else if (!string.IsNullOrWhiteSpace(btn3Yol) && string.IsNullOrWhiteSpace(btn1Yol) && string.IsNullOrWhiteSpace(btn2Yol))
                    {
                        DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, btn3Yol, isim, soyisim, kaloriSiniri, kilogram, pass);

                    }
                    else
                    {
                        DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, profileImage, isim, soyisim, kaloriSiniri, kilogram, pass);

                    }
                }

               await DisplayAlert("Tebrikler", "Güncelleme işlemleri gerçekleştirildi. ", "Tamam");
            }
            catch
            {
                await DisplayAlert("Hata", "Güncelleme işlemleri başarısız ! ", "Tamam");
            }

        }

        private void resimYukle_Clicked(object sender, EventArgs e)
        {
            
            popupOlustur();
            popupLayout.Show();
           /* string a = "a";
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageSteamAsync();
            if (stream != null)
            {
                imageBtn.BackgroundImage = ImageSource.FromStream(() => stream);


            }*/
            
        }

      async  private void tamamlaBtn_Clicked(object sender, EventArgs e)
        {
            string email = "";
            float boy = 0;
            float kilogram = 0;
            DateTime tarih;
            int hedefNo = 0;
            string emailRegex = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (String.IsNullOrWhiteSpace(dogumTarihi.ToString()) || string.IsNullOrWhiteSpace(emailText.Text))
            {
                tarihKontrol.HasError = true;
                emailKontrol.HasError = true;
                await DisplayAlert("Uyarı", "Lütfen gerekli alanları kontrol ediniz", "Çıkış");
            }
            else if (!(Regex.IsMatch(emailText.Text, emailRegex)))
            {
                emailKontrol.HasError = true;
                emailKontrol.ErrorText = "Lütfen email adresinizi doğru giriniz";
            }

            else if (await DatabaseIslemleri.emailVarmi(emailText.Text))
            {
                emailKontrol.HasError = true;
                emailKontrol.ErrorText = "Zaten bu email adresine ait bir hesap bulunmaktadır.";
            }
            else if (String.IsNullOrEmpty(boyText.Text) || String.IsNullOrEmpty(kilogramText.Text))
            {
                boyKontrol.HasError = true;
                kilogramKontrol.HasError = true;

            }
            else if (!(float.Parse(boyText.Text.ToString()) > 120 && float.Parse(boyText.Text.ToString()) < 270))
            {
                await DisplayAlert("Uyarı", "Lütfen Geçerli Boy (CM) Girininiz", "Çıkış");
            }
            else if (!(float.Parse(kilogramText.Text.ToString()) > 40 && float.Parse(kilogramText.Text.ToString()) < 270))
            {
                await DisplayAlert("Uyarı", "Lütfen Geçerli Kilo (KG) Girininiz", "Çıkış");
            }

            else
            {
                email = emailText.Text;
                boy = float.Parse(boyText.Text);
                kilogram = float.Parse(kilogramText.Text);
                tarih = dogumTarihi.Date;




                if (radioKiloAlmak.IsChecked == true)
                {
                    hedefNo = 2;

                }
                if (radioKiloKorumak.IsChecked == true)
                {
                    hedefNo = 1;
                }
                if (radioKiloVermek.IsChecked == true)
                {
                    hedefNo = 0;
                }

                int userId = Convert.ToInt32(Application.Current.Properties["id"]);
                string isim = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.isim.ToString();
                string soyisim = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.soyisim.ToString();
                int hareketMiktari = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.hareketMiktari.ToString());
                int hedef = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.hedef.ToString());
                string pass = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.password.ToString();
                string imageUser = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.image.ToString();
                int cinsiyet = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.cinsiyet.ToString());
                int kaloriSiniri = Convert.ToInt32(DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == userId).FirstOrDefaultAsync().Result.kaloriSiniri.ToString());
                string profileImage = "userprofile.png";
                if(!string.IsNullOrWhiteSpace(btn1Yol)&&string.IsNullOrWhiteSpace(btn2Yol) && string.IsNullOrWhiteSpace(btn3Yol))
                {
                    DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, btn1Yol, isim, soyisim, kaloriSiniri, kilogram, pass);

                }
                else if(!string.IsNullOrWhiteSpace(btn2Yol) && string.IsNullOrWhiteSpace(btn1Yol) && string.IsNullOrWhiteSpace(btn3Yol))
                {
                    DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, btn2Yol, isim, soyisim, kaloriSiniri, kilogram, pass);

                }
                else if(!string.IsNullOrWhiteSpace(btn3Yol) && string.IsNullOrWhiteSpace(btn1Yol) && string.IsNullOrWhiteSpace(btn2Yol))
                {
                    DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, btn3Yol, isim, soyisim, kaloriSiniri, kilogram, pass);

                }
                else
                {
                    DatabaseIslemleri.kullaniciUpdate(userId, boy, cinsiyet, email, tarih, hareketMiktari, hedefNo, profileImage, isim, soyisim, kaloriSiniri, kilogram, pass);

                }

            }

        
    }
    }
}