using CarTeckM.Data;
using CarTeckM.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarTeckM.Car
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarPage : ContentPage
    {
        public ICRTKDatabase cRTKDatabase;

        private FilterCars FilterCars;

        public CarPage(FilterCars filterCars)
        {
            InitializeComponent();

            FilterCars = filterCars;


            //var cRTKDatabase = DependencyService.Get<CRTKDatabase>();


            //var list = await cRTKDatabase.GetCarsFilter(filterCar);

            //var tezs =   cRTKDatabase.GetCars();


            //CarListElement.ItemsSource = (System.Collections.IEnumerable)cRTKDatabase.GetCars();


        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var cRTKDatabase = DependencyService.Get<CRTKDatabase>();

            List<Data.Car> lst = new List<Data.Car>();
            lst.Clear();


            CarListElement.ItemsSource = lst;

            //var listc = new IEnumerable<Car>();


            if (FilterCars == null)
            {
                var listc = await cRTKDatabase.GetCars();
                CarListElement.ItemsSource = listc;
            }
            else
            {
                var listc = await cRTKDatabase.GetCarsFilter(FilterCars);
                CarListElement.ItemsSource = listc;

            }

            //var listc = await cRTKDatabase.GetCars();





            //    CarListElement.ItemsSource = new List<Data.Car>
            //{
            //    new Data.Car
            //    {
            //        CarID = 1,
            //        Brand = "BMW",
            //        Model = "M3",
            //        Transmission = "Manuel",
            //        BodyType = "Berline",
            //        BuildYear =  2021,
            //        RangeType = "KM",
            //        Range = 30000,
            //        Torque = "510",
            //        Power = "480",
            //        Price = 99999,
            //        Description = "A Car for Enthusiast,The Porsche 911 (pronounced Nine Eleven or in German: Neunelfer) is a two-door, " +
            //        "2+2 high performance rear-engined sports car. Introduced in September 1964 by Porsche AG of Stuttgart, Germany." +
            //        " It has a rear-mounted flat-six engine and all round independent suspension. It has undergone continuous development, " +
            //        "though the basic concept has remained unchanged.[1] The engines were air-cooled until the introduction of the Type 996 in 1998, " +
            //        "with the 993, produced from 1994–1998 model years, being the last of the air-cooled Porsche sports cars." +
            //        "The 911 has been modified by private teams and by the factory itself for racing, rallying, and other forms of automotive competition." +
            //        "It is among the most successful competition cars. In the mid-1970s, the naturally aspirated 911 Carrera RSR won major world championship sports car races," +
            //        " such as Targa Florio and 24 Hours of Daytona, even against prototypes." +
            //        "The 911-derived 935 turbo also won the 24 Hours of Le Mans in 1979 and Porsche won World Championship for Makes titles in 1976, ",
            //        Picture = "BMW1.png", //new string [] { "BMW1.png", "BMW2.png", "BMW3.png", "BMW4.png", "BMW5.png","BMW6.png" },
            //        Color = "Black",
            //        FuelType = "Benzine",
            //        UserID = "1",
            //        Currency = "€",

            //    },
            //    new Data.Car
            //    {
            //        CarID =2,
            //        Brand = "Porsche",
            //        Model = "911 995",
            //        Transmission = "Manuel",
            //        BodyType = "Coupé",
            //        BuildYear = 2020,
            //        RangeType = "mil",
            //        Range =  30000,
            //        Torque = "650",
            //        Power = "590",
            //        Currency = "$",
            //        Price = 99999,
            //        Description = "A Car for Enthusiast.",
            //        Picture =  "BMW5.png", //new  string []{ "BMW1.png", "BMW2.png", "BMW3.png", "BMW4.png", "BMW5.png","BMW6.png" },
            //        FuelType = "Diesel",
            //        UserID = "2",
            //        Color = "Metalic Black"
            //    },
            //};
        }


        private async void CarListElement_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //get list from API
            Data.Car car = e.Item as Data.Car;
            await this.Navigation.PushAsync(new CarDetail(car));
            ((ListView)sender).SelectedItem = null;
        }

        private async void RefreshView_Refreshing(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            myRefreshViewCar.IsRefreshing = false;

            var cRTKDatabase = DependencyService.Get<CRTKDatabase>();

            var listc = await cRTKDatabase.GetCars();

            CarListElement.ItemsSource = null;

            CarListElement.ItemsSource = listc;


        }
    }
}