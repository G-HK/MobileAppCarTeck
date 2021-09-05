using Android.Content.Res;
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

        public SellCar()
        {
            InitializeComponent();

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
           var imageResult = await MediaGallery.PickAsync(3, MediaFileType.Image );

            if (imageResult?.Files == null) 
            {
                return;
            }

            foreach (var media in imageResult.Files)
            {
                var filebyte = media.OpenReadAsync();
                //var fileName = media.NameWithoutExtension;
                //var extension = media.Extension;
                //var contentType = media.ContentType;

                // await DisplayAlert(fileName, $"Extension: {extension}, Content-type: {contentType}", "OK");


                await DisplayAlert("file - in", $"file in byte: {filebyte}", "OK");


            }
        }
    }
}