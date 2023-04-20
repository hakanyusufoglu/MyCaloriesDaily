using Android.Content.Res;
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
    public partial class CommunityPage : ContentPage
    {
        public CommunityPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");

            InitializeComponent();
            //OnAppearing();
        }
        //  StackLayout ıcerikStack;
    
        async  protected override void OnAppearing()
        {
            try
            { 
            SocialMediaContent();

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
        public Label lblBegeni = new Label();
        public Button btnBegeni = new Button();
        StackLayout stkBegeniGrubu;
        Image imgIcerik;
        StackLayout stkBegeniGrubuUstu;
        Label lblIsim;
        Image imgKisi;
        StackLayout stckIsimGrubu;
        StackLayout stck;
        Frame frame;
        StackLayout stck2;
        async  void    SocialMediaContent()
        {
            icerikSayfa.Children.Clear();
            IEnumerable<SosyalMedyaTable> socialMedia = await DatabaseIslemleri.GetSosyalMedyaTables();
      
            foreach (var item in socialMedia)
            {
                int userId = Convert.ToInt32( Application.Current.Properties["id"]);
               string isimSoyisim= await DatabaseIslemleri.isimGetir(item.kullaniciID);
                Label lblIcerik = new Label
                {
                    Text = item.gonderiAciklamasi,
                    Margin = new Thickness(0, 20, 0, 0)
                };
                StackLayout ıcerikStack = new StackLayout();
                ıcerikStack.Children.Add(lblIcerik);//enson bitti
                string resimyolu = "like0.png";
               if(userId==item.begenenKullaniciId)
                {



                    if (item.begendiMi == true)
                    {
                        resimyolu = "like1.png";
                    }
                    else
                    {
                        resimyolu = "like0.png";
                    }
                }
                 btnBegeni = new Button
                {
                   
                    WidthRequest = 16,
                    HeightRequest = 16,
                    ImageSource = resimyolu
                };
                int i = 0;
                int btnCount = -1;
                int toplam = 0;

             // Label lblBegeni;
                StackLayout stkBegeniGrubu;
                Image imgIcerik;
                StackLayout stkBegeniGrubuUstu;
                Label lblIsim;
                Image imgKisi;
                StackLayout stckIsimGrubu;
                StackLayout stck;
                Frame frame;
                StackLayout stck2;
                btnBegeni.Clicked += async (sender, e)=> {

            int begeniSayisi=    await DatabaseIslemleri.begeniSayisiGetir(item.sosyalMedyaID);
                        
                    // await DisplayAlert("tik",  btnBegeni.ImageSource.FindByName("file0.png").ToString(), "cc"); 

                    int guncellenenBegeniSayisi = item.begeniSayisi ;
                    
                    var selectedImage=btnBegeni.ImageSource as FileImageSource;
                    if (selectedImage.File == "like1.png")
                    {
                        toplam = begeniSayisi - 1;
                     //   await DisplayAlert("cc", "begeni sayisi: " + toplam.ToString(), "cc");
                        btnBegeni.ImageSource = "like0.png";
                        btnCount--;
                        string a = item.sosyalMedyaID.ToString();
                        await DisplayAlert("cc", a, "ccc");
                        await DatabaseIslemleri.connection.UpdateAsync(new SosyalMedyaTable
                        {
                            sosyalMedyaID = item.sosyalMedyaID,
                            begeniSayisi = toplam,
                            kullaniciID = item.kullaniciID,
                            gonderiAciklamasi = item.gonderiAciklamasi,
                            gonderiResim = item.gonderiResim,
                            begendiMi = false,
                            begenenKullaniciId=userId

                        });
                        guncellenenBegeniSayisi = Convert.ToInt32(await DatabaseIslemleri.begeniSayisiGetir(item.sosyalMedyaID));
                        
                    }

                    else
                    {
                        item.begendiMi=true;
                        toplam = begeniSayisi + 1;
                        btnCount++;
                        await DisplayAlert("cc", "begeni sayisi: " + toplam.ToString(), "cc");
                        btnBegeni.ImageSource = "like1.png";
                        string a = item.sosyalMedyaID.ToString();
                      await  DisplayAlert("cc", a, "ccc");
                        await DatabaseIslemleri.connection.UpdateAsync(new SosyalMedyaTable
                        {
                            sosyalMedyaID = item.sosyalMedyaID,
                            begeniSayisi = toplam,
                            kullaniciID=item.kullaniciID,
                            gonderiAciklamasi=item.gonderiAciklamasi,
                            gonderiResim=item.gonderiResim,
                            begendiMi = true,
                            begenenKullaniciId=userId

                        });
                        
                       
                        // DatabaseIslemleri.begeniUptade(item.sosyalMedyaID, item.begeniSayisi, true);
                    }
                    guncellenenBegeniSayisi = Convert.ToInt32(await DatabaseIslemleri.begeniSayisiGetir(item.sosyalMedyaID));
                  
                 //   await  DisplayAlert("cc","Kullanici Id " +item.kullaniciID.ToString(),"cc");
            

                    lblBegeni.Text = guncellenenBegeniSayisi+ " kişi beğendi";
                    };

                int begeniSayim =Convert.ToInt32(await DatabaseIslemleri.begeniSayisiGetir(item.sosyalMedyaID));
                 lblBegeni = new Label
                {
                    Text = begeniSayim + " kişi beğendi",
                    HorizontalOptions = LayoutOptions.EndAndExpand
                };
               

                stkBegeniGrubu = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 20
                };
                stkBegeniGrubu.Children.Add(btnBegeni);
                stkBegeniGrubu.Children.Add(lblBegeni);


                 imgIcerik = new Image
                {
                    Source = item.gonderiResim,
                    HeightRequest = 220,
                    Aspect = Aspect.AspectFit
                };

                 stkBegeniGrubuUstu = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                    Margin = new Thickness(0, 16, 0, 0)
                };

                stkBegeniGrubuUstu.Children.Add(imgIcerik);
                stkBegeniGrubuUstu.Children.Add(stkBegeniGrubu); //resim ve yorum satırı alanı bitti

                 lblIsim = new Label
                {
                    Text = item.kullaniciID.ToString()+ isimSoyisim,
                    Margin = new Thickness(10, 0, 0, 0),
                    HorizontalOptions = LayoutOptions.Start
                };
                
                if(await DatabaseIslemleri.kullaniciVarmi(userId))
                {
                    string avatar = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == item.kullaniciID).FirstOrDefaultAsync().Result.image;
                    imgKisi = new Image
                    {
                        Source = avatar,
                        WidthRequest = 32,
                        HeightRequest = 32,
                        HorizontalOptions = LayoutOptions.Start,
                        Aspect = Aspect.AspectFit
                    };
                }
                else
                {
                    imgKisi = new Image
                    {
                        Source = "userprofile.png",
                        WidthRequest = 32,
                        HeightRequest = 32,
                        HorizontalOptions = LayoutOptions.Start,
                        Aspect = Aspect.AspectFit
                    };
                }
                
                 stckIsimGrubu = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                stckIsimGrubu.Children.Add(imgKisi);
                stckIsimGrubu.Children.Add(lblIsim);

                 stck = new StackLayout();
                Grid.SetRow(stck, 2);
                stck.Children.Add(stckIsimGrubu);
                stck.Children.Add(stkBegeniGrubuUstu);
                stck.Children.Add(lblIcerik);

                 frame = new Frame
                {
                    HasShadow = true
                };
                frame.Content = stck;
             stck2 = new StackLayout
                {
                    Margin = new Thickness(10, 10, 10, 10)
                };
                stck2.Children.Add(frame);

                icerikSayfa.Children.Add(stck2);
                
            }
           
        }
    

        private void btnBegeni_Clicked(object sender, EventArgs e)
        {
        //    DisplayAlert("ee", e.ToString(), "cc");
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

        private void postIslemi_Clicked(object sender, EventArgs e)
        {
          
            Navigation.PushAsync(new CreatePost());
        }

        private void scrollViewim_ChildAdded(object sender, ElementEventArgs e)
        {

        }

      async  private void oturumuKapat_Clicked(object sender, EventArgs e)
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

    async    private void btnSettings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}