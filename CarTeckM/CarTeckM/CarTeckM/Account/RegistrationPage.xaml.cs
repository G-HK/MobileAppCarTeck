using CarTeckM.Models;
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
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            BindingContext = new UserDto();

            Accelerometer.ShakeDetected += Empty_Lbl;


        }


        private void Empty_Lbl(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                UserEntry.Text = string.Empty;
                EMailEntry.Text = string.Empty;
                PswEntry1.Text = string.Empty;
                PswEntry2.Text = string.Empty;
                BirhtDate.Date = DateTime.Now;
            });
        }
        //

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Accelerometer.Start(SensorSpeed.Default);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.ShakeDetected -= Empty_Lbl;
            Accelerometer.Stop();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }

        private void BtnRegisteren_Clicked(object sender, EventArgs e)
        {


        }

       
    }
}