using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarTeckM.Car
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchCar : ContentPage
    {

        const string templateCarList = "CarFile.txt";
        public SearchCar()
        {
            InitializeComponent();

            string[] text;
            List<string> ls = new List<string>();

            AssetManager assets = Android.App.Application.Context.Assets;
            using (StreamReader reader = new StreamReader(assets.Open(templateCarList)))
            {
                text = reader.ReadToEnd().Split(',');
            }

            ListMerk.ItemsSource = text.ToList();



            BeginYearList.ItemsSource = ListYear(DateTime.Now.Year);
            BeginYearList.SelectedIndex = 0;

            EndYearList.ItemsSource = ListYear(DateTime.Now.Year, default , true);
            EndYearList.SelectedIndex = 0;
            FuelPicker.SelectedIndex = 0;
            GearBoxPicker.SelectedIndex = 0;
            PkrBodyType.SelectedIndex = 0;
            ListMerk.SelectedIndex = 0;
        }

        private void BeginPrice_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void EndPrice_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {

        }

        private void sliderPrice_LowerValueChanged(object sender, EventArgs e)
        {
            CultureInfo cur = new CultureInfo("fr-FR");
            BeginPrice.Text = sliderPrice.LowerValue.ToString("C", cur);
        }

        private void sliderPrice_UpperValueChanged(object sender, EventArgs e)
        {
            CultureInfo cur = new CultureInfo("fr-FR");

            EndPrice.Text = sliderPrice.UpperValue.ToString("C", cur);
        }

        private async void SearchButton_Clicked(object sender, EventArgs e)
        {


            await this.Navigation.PushAsync(new CarPage());
        }


        public List<int> ListYear(int limit = 0, int begin = 1950, bool reverse = false)
        {

            int range = limit == 0 ? DateTime.Now.Year : limit;

            List<int> Years = new List<int>();
            Years.Add(begin);
            for (int i = begin; i <= range; i++)
            {
                Years.Add(i);
            }
            if (reverse)
            {
                Years.Reverse();
            }
            return Years;
        }


    }
}