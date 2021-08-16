using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarTeckM.Account
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
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
                    // save in SqlLite or API 
                }
                else
                {
                    // set entry files to original input
                }
            }


        }
    }
}