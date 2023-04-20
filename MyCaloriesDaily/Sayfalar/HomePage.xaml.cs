using Android.Provider;
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
    public partial class HomePage : ContentPage
    {

        int kaloriSiniri = 0;

        public HomePage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");

            InitializeComponent();
            // BindingContext = this;
            // deneme();
        }
      async  public void deneme()
        {

            if (Application.Current.Properties.ContainsKey("id"))
            {
                string gun = DateTime.Now.ToString("MM/dd/yyyy");
                int id = Convert.ToInt32(Application.Current.Properties["id"]);
                int kulKaloriId = await DatabaseIslemleri.kulKaloriIdGetir(id, gun);
                if (kulKaloriId != -1)
                {
                    int alinanKalori = Convert.ToInt32(DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == id).Where(m => m.KulKaloriTableID == kulKaloriId).FirstOrDefaultAsync().Result.kaloriAlinan);
                    // int alinanKalori = //await DatabaseIslemleri.alinanKaloriGetir(id, gun);
                    lblAlinanKalori.Text = "Alınan Kalori: " + alinanKalori;
                  
                    angle.EndValue = 2500;
                   
                    angle.StartAngle = 0;
                    valueDegeri.Value = alinanKalori;
                    if(valueDegeri.Value>=kaloriSiniri)
                    {
                        valueDegeri.Color = Color.Red;
                    }
                    else
                    {
                        valueDegeri.Color = Color.FromHex("#01bdae");
                    }
                }
                else
                { 
                    valueDegeri.Value = 0;

                    lblAlinanKalori.Text = "Alınan Kalori: 0";
                }
                    
              
               
            }
        }
      async  protected override void OnAppearing()
        {
            angle.StartAngle = 0;
            try
            {
                if (Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {
                    kaloriSiniri = Convert.ToInt32(Application.Current.Properties["kaloriSiniri"]);
                }
                angle.EndValue = kaloriSiniri;
                if (Application.Current.Properties.ContainsKey("id") && Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {
                    string gun = DateTime.Now.ToString("MM/dd/yyyy");
                    int id = Convert.ToInt32(Application.Current.Properties["id"]);

                    string avatar = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == id).FirstOrDefaultAsync().Result.image;
                    userProfile.Source = avatar;
                    lblKaloriSiniri.Text = "Kalori Sınırı: " + kaloriSiniri;
                    lblKalanKalori.Text = kaloriSiniri.ToString() + "Kalori Kaldı";
                    isimSoyisim.Text = "Hoşgeldiniz " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(await DatabaseIslemleri.isimGetir(id));
                    int kulKaloriId = await DatabaseIslemleri.kulKaloriIdGetir(id, gun);
                    if (kulKaloriId != -1)
                    {
                        int alinanKalori = Convert.ToInt32(DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == id).Where(m => m.KulKaloriTableID == kulKaloriId).FirstOrDefaultAsync().Result.kaloriAlinan);

                        // int alinanKalori = //await DatabaseIslemleri.alinanKaloriGetir(id, gun);

                        lblAlinanKalori.Text = "Alınan Kalori: " + alinanKalori;
                        lblKalanKalori.Text = (kaloriSiniri - alinanKalori).ToString();
                        angle.EndValue = kaloriSiniri;
                        valueDegeri.Value = alinanKalori;
                        if (valueDegeri.Value >= angle.EndValue)
                        {
                            valueDegeri.Color = Color.Red;
                        }
                        else
                        {
                            valueDegeri.Color = Color.FromHex("#01bdae");
                            lblKalanKalori.Text = (angle.EndValue - valueDegeri.Value).ToString() + " Kalori Kaldı";
                        }
                        if ((angle.EndValue - valueDegeri.Value) <= 0)
                        {

                            lblKalanKalori.Text = "Hedefi Aştınız !";


                        }
                        else
                            lblKalanKalori.Text = (angle.EndValue - valueDegeri.Value).ToString() + " Kalori Kaldı";



                    }
                    else
                        lblAlinanKalori.Text = "Alınan Kalori: 0";
                }
                else
                {
                    isimSoyisim.Text = "null";
                }
            }
            catch
            {
                if(Application.Current.Properties.ContainsKey("id"))
                Application.Current.Properties.Clear();


                await Navigation.PushAsync(new GirisSayfasi());
            }

          
           
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
         
        }

        public void cacheCollector()
        {
            if (Application.Current.Properties.ContainsKey("tabbedSelected")) //tabbedselected adlı bir anahtar var mı
            {
                Application.Current.Properties.Remove("tabbedSelected"); //varsa sil ki çakışma olmasın
            }
            else
            {
                Application.Current.Properties.ContainsKey("tabbedSelected"); //Breakfastpage sayfasıdna ki tabbedları selecteditemlarına değer atayabilmek için bir cache mekanizması kurdum.
            }
        }
        async private void KahvaltiEkleBtn_Clicked(object sender, EventArgs e)
        {
            //cacheCollector(); //her defasında çağırıyorum ki
            Application.Current.Properties["tabbedSelected"] = 1;
          
            
           await Navigation.PushAsync(new BreakfastPage());
        }

      async  private void OgleEkleBtn_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["tabbedSelected"] = 2;
            await Navigation.PushAsync(new BreakfastPage());
        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {

        }

       async private void aksamEkleBtn_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.Properties["tabbedSelected"] = 3;
            await Navigation.PushAsync(new BreakfastPage());
        }

      async  private void communityBtn_Clicked_1(object sender, EventArgs e)
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

      async  private void nutritiveBtn_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NutritivePage());
        }

      async  private void contactUsBtn_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ContactUsPage());
        }

     async   private void cikisYap_Clicked(object sender, EventArgs e)
        {
            if(Application.Current.Properties.ContainsKey("id"))
            {   
                Application.Current.Properties.Remove("id");
                if(Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {
                    Application.Current.Properties.Remove("kaloriSiniri");
                }
              
              await  Navigation.PushAsync(new GirisSayfasi());
            }
           await DisplayAlert("Çıkış Yapıldı", "Görüşmek Üzere ", "Kapat");
        }

        async private void settings_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}