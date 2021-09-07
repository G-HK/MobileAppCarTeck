using Android.Content.Res;
using CarTeckM.Data;
using CarTeckM.Models;
using NativeMedia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarTeckM.Car
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellCar : ContentPage
    {
        const string templateCarList = "CarFile.txt";


        CRTKDatabase iCRTKDatabase;
        public SellCar()
        {
            InitializeComponent();

            iCRTKDatabase = DependencyService.Get<CRTKDatabase>();



            string[] text;
            List<string> ls = new List<string>();

            AssetManager assets = Android.App.Application.Context.Assets;
            using (StreamReader reader = new StreamReader(assets.Open(templateCarList)))
            {
                text = reader.ReadToEnd().Split(',');
            }

            ListBrand.ItemsSource = text.ToList();
        }

        private async void PickBtn_Clicked(object sender, EventArgs e)
        {
           var imageResult = await MediaGallery.PickAsync(1, MediaFileType.Image );

            if (imageResult?.Files == null) 
            {
                return;
            }

            foreach (var media in imageResult.Files)
            {
                var filebyte = media.OpenReadAsync();


                var tr = new MemoryStream(filebyte.Result.ReadByte());

                //using  (MemoryStream ms = new MemoryStream(filebyte))
                //{
                //    var trs= ms.ReadByte();
                //     DisplayAlert("file - in", $"file in byte: {trs}", "OK");


                //}
                //using (StringReader  in filebyte)
                //    {

                //}
                //var fileName = media.NameWithoutExtension;
                //var extension = media.Extension;
                //var contentType = media.ContentType;

                // await DisplayAlert(fileName, $"Extension: {extension}, Content-type: {contentType}", "OK");


                await DisplayAlert("file - in", $"file in byte: {tr}", "OK");


            }
        }

        private async void SellCarbtn_Clicked(object sender, EventArgs e)
        {

            Data.Car car = new Data.Car
            {
                Brand = ListBrand.SelectedItem.ToString().Replace("\r\n", string.Empty),
                Model = modelEntry.Text,
                Transmission = GearBoxPicker.SelectedItem.ToString(),
                BodyType = PkrBodyType.SelectedItem.ToString(),
                BuildYear = int.Parse(BluidEntry.Text),
                RangeType = "KM",
                Range = int.Parse(RangeEntry.Text),
                Torque = "600",
                Power = int.Parse(PowerEntry.Text),
                Price = Convert.ToDecimal(priceEntry.Text),
                Description = DesEntry.Text,
                Picture = "BMW1.png",
                Color = ColorEntry.Text,
                FuelType = FuelPicker.SelectedItem.ToString(),
                UserID = "1",
                Currency = "€",

            };



           await iCRTKDatabase.AddCar(car);

            //await Shell.Current.GoToAsync($"//{nameof(CarPage)}");

            var mdp = Application.Current.MainPage as MasterDetailPage;
            await mdp.Navigation.PushAsync( new  CarPage(new FilterCars()));

           // await Navigation.PushAsync(new CarPage());


        }
    }
}