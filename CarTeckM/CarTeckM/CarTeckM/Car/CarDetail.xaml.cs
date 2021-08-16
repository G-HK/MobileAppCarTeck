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
    public partial class CarDetail : ContentPage
    {
        private CarDto _carSelect;

        public CarDetail(CarDto CarID) //testing 
        {
            InitializeComponent();

            // api call or sql Lite with carID
            _carSelect = CarID;
            this.BindingContext = CarID;

            //  CarouselImage.ItemsSource = _carSelect.Picture;

            //'ImageSource.FromStream(() => new MemoryStream(pictureByteArray))'

        }
    }
}