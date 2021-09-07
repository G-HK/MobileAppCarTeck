using CarTeckM.Models;
using Plugin.Media.Abstractions;
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
        private Data.Car _carSelect;

        public CarDetail(Data.Car CarID) //testing 
        {
            InitializeComponent();

            // api call or sql Lite with carID
            _carSelect = CarID;
            this.BindingContext = CarID;           


            //List<ImageCell> imageSources = new List<ImageCell>();

            //foreach (var item in CarID.Picture)
            //{
            //    var imagec = new ImageCell { ImageSource = ImageSource.FromFile(item) }; /*ImageSource.FromUri(new Uri(item))*/

            //imageSources.Add(imagec);
            //}

            //CarouselImage.ItemsSource = imageSources.ToArray();
            

            //foreach (MediaFile photoFile in photoFiles)
            //{
            //    CarouselImage.ImageSources.Add(ImageSource.FromFile(photoFile.Path));
            //}


            //'ImageSource.FromStream(() => new MemoryStream(pictureByteArray))'

        }
    }
}