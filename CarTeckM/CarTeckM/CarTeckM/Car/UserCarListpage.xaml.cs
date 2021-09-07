using CarTeckM.Data;
using CarTeckM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarTeckM.Car
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserCarListpage : ContentPage
    {
        public UserCarListpage()
        {
            InitializeComponent();
        }


        protected override async void OnAppearing()
        {
            User user = JsonConvert.DeserializeObject<User>(Preferences.Get("Userinfo", string.Empty));  // Preferences.Get("Userinfo", string.Empty);

            List<Data.Car> lst = new List<Data.Car>();
            lst.Clear();


            listView.ItemsSource = lst;

            // JsonConvert.DeserializeObject<UserDto>(Preferences.Get("Userinfo", string.Empty)) ?? null;

            if (user == null)
            {
                await DisplayAlert("User?", "No user is sigin./r/nplease sigin or creat an account.","OK");
            }
            else
            {
                var cRTKDatabase = DependencyService.Get<CRTKDatabase>();

                var listc = await cRTKDatabase.GetUserCars(user.UserID);


                //await DisplayAlert("User?", $"{user}", "OK");

                listView.ItemsSource = listc;

            }


        }
    }
}