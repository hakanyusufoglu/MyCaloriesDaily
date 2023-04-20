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
    public partial class test2 : ContentPage
    {
        public test2()
        {
            InitializeComponent();
          //  SocialMediaContent();
        }
        void SocialMediaContent()
        {
            Label lblIcerik = new Label
            {
                Text = "veritabanından gelen icerik. Burada diyetik yemekler hakkında veya kilo ile ilgili bilgilerin paylaşılması sağlanacaktır",
                Margin = new Thickness(0, 20, 0, 0)
            };
            StackLayout ıcerikStack = new StackLayout();
            ıcerikStack.Children.Add(lblIcerik);//enson bitti


            Button btnBegeni = new Button
            {
                WidthRequest = 16,
                HeightRequest = 16,
                ImageSource = "like0.png"
            };
            Label lblBegeni = new Label
            {
                Text = "2 kişi beğendi",
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            StackLayout stkBegeniGrubu = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 20
            };
            stkBegeniGrubu.Children.Add(btnBegeni);
            stkBegeniGrubu.Children.Add(lblBegeni);


            Image imgIcerik = new Image
            {
                Source = "dinner.png",
                HeightRequest = 220,
                Aspect = Aspect.AspectFit
            };

            StackLayout stkBegeniGrubuUstu = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Margin = new Thickness(0, 16, 0, 0)
            };

            stkBegeniGrubuUstu.Children.Add(imgIcerik);
            stkBegeniGrubuUstu.Children.Add(stkBegeniGrubu); //resim ve yorum satırı alanı bitti

            Label lblIsim = new Label
            {
                Text = "Hakan Yusufoglu",
                Margin = new Thickness(10, 0, 0, 0),
                HorizontalOptions = LayoutOptions.Start
            };
            Image imgKisi = new Image
            {
                Source = "person.png",
                WidthRequest = 32,
                HeightRequest = 32,
                HorizontalOptions = LayoutOptions.Start,
                Aspect = Aspect.AspectFit
            };
            StackLayout stckIsimGrubu = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            stckIsimGrubu.Children.Add(imgKisi);
            stckIsimGrubu.Children.Add(lblIsim);

            StackLayout stck = new StackLayout();
            Grid.SetRow(stck, 2);
            stck.Children.Add(stckIsimGrubu);
            stck.Children.Add(stkBegeniGrubuUstu);
            stck.Children.Add(lblIcerik);

            Frame frame = new Frame
            {
                HasShadow = true
            };
            frame.Content = stck;
            StackLayout stck2 = new StackLayout
            {
                Margin = new Thickness(10, 10, 10, 10)
            };
            stck2.Children.Add(frame);

        //    scrollViewim.Content = stck2;
        }
    }
}