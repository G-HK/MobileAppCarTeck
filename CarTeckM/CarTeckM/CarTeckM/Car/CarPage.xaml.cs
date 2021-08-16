using CarTeckM.Models;
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
        public CarPage()
        {
            InitializeComponent();
            CarListElement.ItemsSource = new List<CarDto>
            {
                new CarDto
                {
                    CarID = 1,
                    Brand = "BMW",
                    Model = "M3",
                    Transmission = "Manuel",
                    BodyType = "Berline",
                    BuildYear =  2021,
                    RangeType = "KM",
                    Range = 30000,
                    Torque = "510",
                    Power = "480",
                    Price = 99999,
                    Description = "A Car for Enthusiast,The Porsche 911 (pronounced Nine Eleven or in German: Neunelfer) is a two-door, " +
                    "2+2 high performance rear-engined sports car. Introduced in September 1964 by Porsche AG of Stuttgart, Germany." +
                    " It has a rear-mounted flat-six engine and all round independent suspension. It has undergone continuous development, " +
                    "though the basic concept has remained unchanged.[1] The engines were air-cooled until the introduction of the Type 996 in 1998, " +
                    "with the 993, produced from 1994–1998 model years, being the last of the air-cooled Porsche sports cars." +
                    "The 911 has been modified by private teams and by the factory itself for racing, rallying, and other forms of automotive competition." +
                    "It is among the most successful competition cars. In the mid-1970s, the naturally aspirated 911 Carrera RSR won major world championship sports car races," +
                    " such as Targa Florio and 24 Hours of Daytona, even against prototypes." +
                    "The 911-derived 935 turbo also won the 24 Hours of Le Mans in 1979 and Porsche won World Championship for Makes titles in 1976, ",
                    Picture = new string [] { "BMW1.png", "BMW2.png", "BMW3.png", "BMW4.png", "BMW5.png","BMW6.png" },
                    Color = "Black",
                    FuelType = "Benzine",
                    IdentityID = "1",
                    Currency = '€',
                    
                },
                new CarDto
                {
                    CarID =2,
                    Brand = "Porsche",
                    Model = "911 995",
                    Transmission = "Manuel",
                    BodyType = "Coupé",
                    BuildYear = 2020,
                    RangeType = "mil",
                    Range =  30000,
                    Torque = "650",
                    Power = "590",
                    Currency = '$',
                    Price = 99999,
                    Description = "A Car for Enthusiast.",
                    Picture = new  string []{ "BMW1.png", "BMW2.png", "BMW3.png", "BMW4.png", "BMW5.png","BMW6.png" },
                    FuelType = "Diesel",
                    IdentityID = "2",
                    Color = "Metalic Black"
                },
            };
        }

        private async void CarListElement_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //get list from API
            CarDto car = e.Item as CarDto;
            await this.Navigation.PushAsync(new CarDetail(car));
            ((ListView)sender).SelectedItem = null;
        }
    }
}