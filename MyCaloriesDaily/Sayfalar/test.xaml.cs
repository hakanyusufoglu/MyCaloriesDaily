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
    public partial class test : ContentPage
    {
        public test()
        {
            InitializeComponent();
        }

        private void clickToShowPopup_Clicked(object sender, EventArgs e)
        {

        }
        public void tetikle()
        {
            popupLayout.Show();
        }
        public void deneme(object sender, EventArgs e)
        {
            DisplayAlert("aa", "cc", "dd");
        }
        public void clickToShowPopup_Clicked_1(object sender, EventArgs e)
        {
            popupLayout.Show();
        }
    }
}