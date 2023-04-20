using Android.OS;
using MyCaloriesDaily.Model;
using Syncfusion.Data.Extensions;
using Syncfusion.SfNavigationDrawer.XForms;
using Syncfusion.XForms.PopupLayout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.PopupLayout;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Android.Provider;
using Syncfusion.XForms.TextInputLayout;
using Android.Media.Midi;
using Syncfusion.SfDataGrid.XForms.DataPager;
using System.Windows.Input;
using System.ComponentModel;
using Android.Widget;
using Syncfusion.SfDataGrid.XForms;

namespace MyCaloriesDaily.Sayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreakfastPage : ContentPage
    {
        public BreakfastPage()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjczNjU5QDMxMzgyZTMxMmUzMGhLOHZHZTgrV2h1QVpkRk9RUFBkRU5OTVlXcTRCTkVGbGo0cGxFaGJDTXM9");

            InitializeComponent();
            try
            {
            tabView.SelectedIndex = Convert.ToInt32(Application.Current.Properties["tabbedSelected"]);
            }
            catch(Exception e)
            {
                DisplayAlert("Cache Mekanizması Hatası", e.ToString(), "Çıkış");
            }
        //    kDeneme();
            // int a = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == gun).Where(m => m.kulKaloriID == userId).ToListAsync();
           getir2();

        }
       public class denemeSinifi
        {
            public int yemeZamani { get; set; }
        }
    //    List<FilterClass> deneme3;
      //  List<FilterClass> deneme7;
       // List<FilterClass> deneme4;
       
     async   public void getir2()
        {
            
            gun = DateTime.Now.ToString("MM/dd/yyyy");
            userId = Convert.ToInt32(Application.Current.Properties["id"]);
            IEnumerable<KulKaloriUrunTable> c = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == gun).Where(m => m.kulKaloriID == userId).ToListAsync();
            List<denemeSinifi> yemeZamani = new List<denemeSinifi>();
            foreach (var item in c)
            {

                yemeZamani.Add(new denemeSinifi { yemeZamani = item.yemekZamani });
            }
        List<FilterClass>    deneme8 = new List<FilterClass>();
            List<FilterClass> deneme9 = new List<FilterClass>();
            List<FilterClass> deneme10 = new List<FilterClass>();
            IEnumerable<UrunBesinTable> d;
            IEnumerable<KulKaloriUrunTable> cccdc = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == gun).Where(m => m.kulKaloriID == userId).Where(m => m.yemekZamani == 0).ToListAsync();



            foreach (var urunBesinID in cccdc)
                {
                    deneme7.Add(new FilterClass
                    {
                        urunAdi = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunAdi,
                        urunKalori = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID == urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunKaloriToplami,
                        urunGram = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID == urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunGramaji,
                        urunKarbonhidrat = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunKarbonhidrat,
                        urunProtein = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunProtein,
                        urunYag = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunYag


                    });
               
            }
            gridList.ItemsSource = deneme7;

            //dataGrid.ItemsSource = deneme2;


            IEnumerable<KulKaloriUrunTable> cccc = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == gun).Where(m => m.kulKaloriID == userId).Where(m => m.yemekZamani == 1).ToListAsync();

                foreach (var urunBesinID in cccc)
                {
                    deneme3.Add(new FilterClass
                    {
                        
                        urunAdi = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunAdi,
                        urunKalori = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID == urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunKaloriToplami,
                        urunGram = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID == urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunGramaji,
                        urunKarbonhidrat = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunKarbonhidrat,
                        urunProtein = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunProtein,
                        urunYag = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunYag

                    });
               
            }
            gridlistesi2.ItemsSource = deneme3;
            //  dataGri2.ItemsSource = deneme2;
            // listgrid.ItemsSource = deneme2;

            //   gridList2.ItemsSource = deneme2;




            IEnumerable<KulKaloriUrunTable> aaa = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == gun).Where(m => m.kulKaloriID == userId).Where(m => m.yemekZamani == 2).ToListAsync();

                foreach (var urunBesinID in aaa)
                {
                    deneme4.Add(new FilterClass
                    {
                        urunAdi = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunAdi,
                        urunKalori = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID== urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunKaloriToplami ,
                        urunGram = DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.kulKaloriUrunID == urunBesinID.kulKaloriUrunID).FirstOrDefaultAsync().Result.urunGramaji,
                        urunKarbonhidrat = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunKarbonhidrat,
                        urunProtein = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunProtein,
                        urunYag = DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunID == urunBesinID.urunBesinID).FirstOrDefaultAsync().Result.urunYag

                    });

                
                //   listgrid.ItemsSource = deneme2;
            }
            gridlistesi3.ItemsSource = deneme4;
            //   dataGri3.ItemsSource = deneme2;
            // gridList2.ItemsSource = deneme2;

           // int deger =Convert.ToInt32(  DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == 18).Where(m => m.KulKaloriTableID == 22).FirstOrDefaultAsync().Result.kaloriAlinan);
        // await   DisplayAlert("aa", deger.ToString(),"ss");
        }

public void kDeneme()
        {
            gridList.ItemsSource = deneme7.ToList();
        }
        async  protected override void OnAppearing()
        {
            try {
                if (Application.Current.Properties.ContainsKey("id") && Application.Current.Properties.ContainsKey("kaloriSiniri"))
                {
                    int id = Convert.ToInt32(Application.Current.Properties["id"]);
                    string avatar = DatabaseIslemleri.connection.Table<KullaniciTable>().Where(m => m.kulID == id).FirstOrDefaultAsync().Result.image;
                    userImage.Source = avatar;
                    isimSoyisim.Text = "Hoşgeldiniz " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(await DatabaseIslemleri.isimGetir(id));
                }
                kahvaltiListesi.ItemsSource = await DatabaseIslemleri.getRecordBesinTable();
            ogleListesi.ItemsSource = await DatabaseIslemleri.getRecordBesinTable();
            aksamListesi.ItemsSource = await DatabaseIslemleri.getRecordBesinTable();
                //    accardionOglen.ItemsSource = await DatabaseIslemleri.getRecordBesinTable();
                //  dataGrid.ItemsSource = await DatabaseIslemleri.getRecordBesinTable();

            }
            catch
            {
              await  DisplayAlert("Hata", "Hata meydana geldi: Giriş Ekranına yönlendiriliyorsunuz", "Tamam");

                if (Application.Current.Properties.ContainsKey("id"))
                    Application.Current.Properties.Clear();

                await DisplayAlert("Hata", "Giriş Sayfasına Yönlendiriliyorsunuz", "Tamam");
                await Navigation.PushAsync(new GirisSayfasi());
            }
        }


        private void menuBtn_Clicked_1(object sender, EventArgs e)
        {
            navigationDrawer.ToggleDrawer();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Öğle yemeği Ekle", "anlasildi", "cikis");
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            DisplayAlert("Aksam yemeği Ekle", "anlasildi", "cikis");
        }

        private void tabView_SelectionChanged(object sender, Syncfusion.XForms.TabView.SelectionChangedEventArgs e)
        {
          
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            tabView.SelectedIndex=0;
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

       async private void kahvaltilikSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            kahvaltiListesi.ItemsSource = await DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunAdi.ToLower().Contains(e.NewTextValue.ToLower())).ToListAsync();

        }

       async private void ogleSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            ogleListesi.ItemsSource = await DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunAdi.ToLower().Contains(e.NewTextValue.ToLower())).ToListAsync();
        }

      async  private void aksamSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
                aksamListesi.ItemsSource = await DatabaseIslemleri.connection.Table<UrunBesinTable>().Where(m => m.urunAdi.ToLower().Contains(e.NewTextValue.ToLower())).ToListAsync();
        }
      
      
        DataTemplate contentTemplateView;
        SfPopupLayout popupLayout = new SfPopupLayout(); 
        Entry entry1;
        Label yiyecekGramText;
        Label yiyecekKaloriText;

        void popupOlustur(string yemekZamani,string yiyecekTuru,string yiyecekKalori,string yiyecekGram)
        {
            var inputLayout = new SfTextInputLayout();

            contentTemplateView = new DataTemplate(() =>
            {
                Label zamanText = new Label
                {
                    FontSize = 16,
                    Text = yemekZamani,
                    Margin = new Thickness(0, 10, 0,15),
                    TextColor = Color.Black,
                    HorizontalOptions=LayoutOptions.CenterAndExpand

                };
                Label yiyecekText = new Label { 
                FontSize=14,
                Text="Yiyecek Türü: "+yiyecekTuru,
                Margin=new Thickness(0,6,0,0),
                TextColor=Color.Black
                
                };
                yiyecekKaloriText = new Label
                {
                    FontSize = 14,
                    Text = "Yiyecek Kalori: "+ yiyecekKalori,
                    Margin =new Thickness(0,6,0,0),
                    TextColor = Color.Black

                };
                yiyecekGramText = new Label
                {
                    FontSize = 14,
                    Text = "Yiyecek Gram: " + yiyecekGram,
                    Margin = new Thickness(0, 6, 0, 10),
                    TextColor = Color.Black

                };
                StackLayout s1 = new StackLayout
                {
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    
                    Margin = new Thickness(8,0,8,2)
                    

                };
                entry1 = new Entry
                {
                    Text = "1",
                    Keyboard = Keyboard.Numeric,
                    
                };
                entry1.TextChanged += Entry1_TextChanged;
                inputLayout.ContainerType = ContainerType.Outlined;
                inputLayout.OutlineCornerRadius = 8;
                inputLayout.HasError = false;
                
                inputLayout.ErrorText = "Gerekli alan*";
                inputLayout.LeadingViewPosition = ViewPosition.Inside;
              //  inputLayout.LeadingView = new Entry {Text="1" };// entry1;
                inputLayout.LeadingView = new Image { Source = "eat.png" };
                inputLayout.InputView = entry1;
                inputLayout.Hint = "Miktarı Yazınız";
                s1.Children.Add(zamanText);
                s1.Children.Add(yiyecekText);
                s1.Children.Add(yiyecekKaloriText);
                s1.Children.Add(yiyecekGramText);
                s1.Children.Add(inputLayout);

                Grid grid = new Grid
                {
                    HeightRequest = 368,
                    RowDefinitions = { new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) } },
                   
                    
                };
                Grid.SetRow(s1, 0);
                grid.Children.Add(s1);
                return grid;


            });
            
            popupLayout.PopupView.HeightRequest = 230;
            popupLayout.PopupView.HeaderTitle = "Yiyeceğin Miktarını Giriniz";
            popupLayout.PopupView.AnimationMode = AnimationMode.Zoom;
       
            popupLayout.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            popupLayout.PopupView.AcceptButtonText = "Onayla";
            popupLayout.PopupView.DeclineButtonText = "Vazgeç";
            popupLayout.PopupView.AcceptCommand = new Command(() =>  PopupAcceptButton());
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

       
        double miktar = 1;
        private void Entry1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try { 
            if(!String.IsNullOrWhiteSpace(e.NewTextValue.ToString()))
                {
                    miktar = double.Parse( e.NewTextValue);
                     yiyecekGramText.Text ="Yiyecek Gram: "+ (Convert.ToInt32( dGram.ToString() )* Convert.ToInt32( e.NewTextValue.ToString())).ToString();
                     yiyecekKaloriText.Text ="Yiyecek Kalori: "+ (Convert.ToInt32(dKalori.ToString() )* Convert.ToInt32( e.NewTextValue.ToString())).ToString();
                }
                //DisplayAlert("aa", yiyecekGramText.Text, "cc");
            }
            catch 
            {
                DisplayAlert("Hata", "Sadece tam sayı giriniz", "Çıkış");
            }
        }

     public   class FilterClass
        {
           public int urunBesinID2 { get; set; }
            public int kullaniciID { get; set; }
            public string urunAdi { get; set; }
            public float urunGram { get; set; }
            public int urunKalori { get; set; }
            public double urunProtein { get; set; }
            public double urunYag { get; set; }
            public double urunKarbonhidrat { get; set; }

        }
        private void PopupDeclineButton()
        {
            alinanKalori -= listengelenYiyecekKalori;
           // await DisplayAlert("aa", alinanKalori.ToString(), "cc");
        }

     async    protected override void OnDisappearing()
        {
            sabahKalori = 0;
            aksamKalori = 0;
            oglenKalori = 0;
            //getir2();
            foreach (var item in deneme7)
            {
                sabahKalori += item.urunKalori;
            }
            foreach (var item in deneme3)
            {
                oglenKalori += item.urunKalori;
            }
            foreach (var item in deneme4)
            {
                aksamKalori += item.urunKalori;
            }

         
            if (await DatabaseIslemleri.eklenenKaloriVarmi(userId, gun))
            {
                int kulKaloriId = await DatabaseIslemleri.kulKaloriIdGetir(userId, gun);
                gun = DateTime.Now.ToString("MM/dd/yyyy");
                int databaseKalori = Convert.ToInt32(DatabaseIslemleri.connection.Table<KulKaloriTable>().Where(m => m.kullaniciID == userId).Where(m => m.KulKaloriTableID == kulKaloriId).FirstOrDefaultAsync().Result.kaloriAlinan);

                int toplamKalori = (sabahKalori + aksamKalori + oglenKalori);
                DatabaseIslemleri.kulKaloriTableUpdate(sabahKalori, oglenKalori, aksamKalori, kulKaloriId, userId, toplamKalori, gun);


                await DisplayAlert("cc", sabahKalori.ToString(), "cc");
            }
            else
            {
                gun = DateTime.Now.ToString("MM/dd/yyyy");
                int toplamKalori = (sabahKalori + aksamKalori + oglenKalori);

                DatabaseIslemleri.kulKaloriTableInsert(userId,sabahKalori,aksamKalori,oglenKalori,toplamKalori, gun);
                await DisplayAlert("cc", alinanKalori.ToString(), "cc");

            }
        }
       List<FilterClass> deneme7 = new List<FilterClass>();
       List<FilterClass> deneme3 = new List<FilterClass>();
       List<FilterClass> deneme4 = new List<FilterClass>();

        string gun="-1";
        int userId = -1;
        int sabahKalori = 0;
        int oglenKalori = 0;
        int aksamKalori = 0;
        async public void PopupAcceptButton() //popup accept butonu
        {
                         userId = Convert.ToInt32(Application.Current.Properties["id"]);
             gun = DateTime.Now.ToString("MM/dd/yyyy");

            List<int> deneme = new List<int>();
           
            
           await DisplayAlert("aa", (alinanKalori*miktar).ToString(), "cc");
            // int a = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == gun).Where(m => m.kulKaloriID == userId).ToListAsync();

            int toplamKalori2 = (int)(alinanKalori * miktar);
            IEnumerable<UrunBesinTable> d;

            if(yemeZamani==0)
            {
               
               deneme7.Add(new FilterClass
                {
                    urunAdi = yiyecekTuru,
                    urunKalori =Convert.ToInt32(yiyecekKalori)*Convert.ToInt32( miktar),
                    urunGram = Convert.ToInt32( dGram)*Convert.ToInt32(miktar),
                    urunKarbonhidrat =karbonhidrat ,
                    urunProtein = protein,
                    urunYag = yag
                    
                });

                DatabaseIslemleri.kulKaloriUrunInsert(Convert.ToInt32(dGram) * Convert.ToInt32(miktar), Convert.ToInt32(yiyecekKalori) * Convert.ToInt32(miktar), userId, urunId, gun, yemeZamani);
                // gridList1.ItemsSource = deneme2;


                /* foreach (var item in deneme2)
                 {
                     sabahKalori += item.urunKalori;
                 }*/
                //   gridList.ItemsSource = deneme7;
                //dataGrid.ItemsSource = deneme2;
            }
           
            else if(yemeZamani==1)
            {
               
                    deneme3.Add(new FilterClass
                    {
                        urunAdi = yiyecekTuru,
                        urunKalori = Convert.ToInt32(yiyecekKalori)*Convert.ToInt32(miktar),
                        urunGram = Convert.ToInt32(dGram) * Convert.ToInt32(miktar),
                        urunKarbonhidrat = karbonhidrat,
                        urunProtein = protein,
                        urunYag = yag


                    });

                DatabaseIslemleri.kulKaloriUrunInsert(Convert.ToInt32(dGram) * Convert.ToInt32(miktar), Convert.ToInt32(yiyecekKalori)*Convert.ToInt32(miktar), userId, urunId, gun, yemeZamani);
            }

            else if (yemeZamani == 2)
            {
             
            
                    deneme4.Add(new FilterClass
                    {
                        urunAdi = yiyecekTuru,
                        urunKalori = Convert.ToInt32(yiyecekKalori)* Convert.ToInt32(miktar),
                        urunGram = Convert.ToInt32(dGram) * Convert.ToInt32(miktar),
                        urunKarbonhidrat = karbonhidrat,
                        urunProtein = protein,
                        urunYag = yag

                    });
                DatabaseIslemleri.kulKaloriUrunInsert(Convert.ToInt32(dGram) * Convert.ToInt32(miktar), Convert.ToInt32(yiyecekKalori) * Convert.ToInt32(miktar), userId, urunId, gun, yemeZamani);
            }

            //   dataGrid.ItemsSource = await DatabaseIslemleri.connection.Table<KulKaloriUrunTable>().Where(m => m.raporTarihi == gun).Where(m => m.kulKaloriID == userId).ToListAsync().Result.

            //dataGrid.ItemsSource   = deneme2;
            // listgrid.ItemsSource = deneme2;

            gridList.ItemsSource = deneme7.ToList();
            gridlistesi2.ItemsSource = deneme3.ToList();
            gridlistesi3.ItemsSource = deneme4.ToList();

        }
        string dGram ="0";
        string dKalori ="0";
        int alinanKalori = 0;
        int listengelenYiyecekKalori = 0;
        string yiyecekTuru = "";
        string yiyecekKalori = "";


        double yag = -1;
        double karbonhidrat = -1;
        double protein = -1;

        int urunId = 0;

        void PoptanDegerOku(string zaman,ItemTappedEventArgs e)
        {
            
             yiyecekTuru = ((UrunBesinTable)e.Item).urunAdi;
             yiyecekKalori = ((UrunBesinTable)e.Item).urunKalori.ToString();
            string yiyecekGram = ((UrunBesinTable)e.Item).urunGram.ToString();
            listengelenYiyecekKalori=Convert.ToInt32( ((UrunBesinTable)e.Item).urunKalori);
            popupOlustur(zaman,yiyecekTuru, yiyecekKalori, yiyecekGram);
            dGram = yiyecekGram;
            dKalori = yiyecekKalori;
            alinanKalori +=Convert.ToInt32( yiyecekKalori);
            urunId = ((UrunBesinTable)e.Item).urunID;
            yag= ((UrunBesinTable)e.Item).urunYag;
            karbonhidrat= ((UrunBesinTable)e.Item).urunKarbonhidrat;
            protein= ((UrunBesinTable)e.Item).urunProtein;


            popupLayout.Show();
        }
        int yemeZamani = -1;
        private void kahvaltiListesi_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            yemeZamani = 0;
            
            PoptanDegerOku("Kahvaltı Zamanı",e);
          
          


        }
        private void ogleListesi_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            yemeZamani = 1;
            PoptanDegerOku("Öğle Zamanı",e);
          
        }
        private void aksamListesi_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            yemeZamani = 2;
            PoptanDegerOku("Akşam Zamanı",e);
          
        }

       async private void MenuItem_Clicked(object sender, EventArgs e)
        {
        
            var item = sender as MenuItem;
            var contact = item.CommandParameter as FilterClass;

            deneme7.Remove(contact);
           
            
            gridList.ItemsSource = deneme7.ToList();

        }

       async private void oturumBtn_Clicked(object sender, EventArgs e)
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

     async   private void btnSettings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
    }
   

 
