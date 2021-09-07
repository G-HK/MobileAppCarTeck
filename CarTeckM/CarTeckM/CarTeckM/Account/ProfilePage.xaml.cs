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

namespace CarTeckM.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {

        ApiConnect connect;

        public ProfilePage()
        {
            InitializeComponent();
            connect = new ApiConnect();

        }


        protected override async void OnAppearing()
        {

            User user = JsonConvert.DeserializeObject<User>(Preferences.Get("Userinfo", string.Empty));

            usernameEntry.Text = user.Username;
            emailEntry.Text = user.Email;
            pswEntry.Text = user.Password;
            birhtDatePicker.Date = user.BirthDate;



        }


        private async void EditData_Toggled(object sender, ToggledEventArgs e)
        {
            Switch sw = sender as Switch;

            if (sw.IsToggled)
            {
                usernameEntry.IsEnabled = true;
                emailEntry.IsEnabled = true;
                birhtDatePicker.IsEnabled = true;
                pswEntry.IsEnabled = true;
            }
            else
            {
                usernameEntry.IsEnabled = false;
                emailEntry.IsEnabled = false;
                birhtDatePicker.IsEnabled = false;
                pswEntry.IsEnabled = false;

                bool answer = await DisplayAlert("Question?", "Would you like to change you info", "Yes", "No");

                if (answer)
                {
                    //  API 

                   // connect.Update(userDto); Need to be done.

                }
                else
                {
                    await Navigation.PopAsync();
                }
            }


        }
    }
}