using Android.Content;
using CarTeckM.Models;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class Login : PopupPage
    {
        public ISharedPreferences sharedPreferences;

        ApiConnect connect;

        public Login()
        {
            InitializeComponent();
            connect = new ApiConnect();


            Accelerometer.ShakeDetected += Empty_Text;

        }


        private void Empty_Text(object sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                EmailEtry.Text = string.Empty;
                PswEntry.Text = string.Empty;
            });


        }


        protected override void OnAppearingAnimationBegin()
        {
            base.OnAppearingAnimationBegin();

            Accelerometer.Start(SensorSpeed.Game);
        }

        protected override void OnDisappearingAnimationBegin()
        {
            base.OnDisappearingAnimationBegin();
            Accelerometer.ShakeDetected -= Empty_Text;
            Accelerometer.Stop();
        }

        private async void btnX_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            UserDto usr = connect.GetUser(EmailEtry.Text, PswEntry.Text);

            if (usr != null)
            {
                Preferences.Set("UserOb", JsonConvert.SerializeObject(usr));
                UserDto userView = new UserDto();
                userView.UserName = usr.UserName;
                userView.Email = usr.Email;
                userView.Password = usr.Password;
                userView.ID = usr.ID;

                //MdiPageMasterViewModel md = new MdiPageMasterViewModel();
                //md.NameUser = usr.UserName;

                Preferences.Set("loginValid", true);

                // var user= JsonConvert.DeserializeObject<User>(Preferences.Get(UserKey, "default_value");
                await PopupNavigation.Instance.PopAsync(true);

                //save user
            }
        }


        private async void btnRegistater_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistrationPage());

            await PopupNavigation.Instance.PopAsync(true);
        }

        private void IbtnEye_Clicked(object sender, EventArgs e)
        {

            ImageButton imageButton = sender as ImageButton;
            if (!PswEntry.IsPassword)
            {
                imageButton.Source = "eyeClosed.png";
                PswEntry.IsPassword = true;
            }
            else
            {
                imageButton.Source = "eyeOpen.png";
                PswEntry.IsPassword = false;
            }
        }


        //not required
        //private void Email_Completed(object sender, EventArgs e)
        //{
        //    Entry entry = sender as Entry;
        //    // connect.ValidUser(entry.Text);
        //    if (!connect.ValidEmail(entry.Text))
        //    {
        //        FrameEmail.BackgroundColor = Color.FromHex("#97F382");
        //        InValidLbl.IsVisible = false;
        //    }
        //    else
        //    {
        //        InValidLbl.IsVisible = true;
        //    }

        //}

        //private void PswEntry_Completed(object sender, EventArgs e)
        //{
        //    Entry ps = sender as Entry;
        //    string email = EmailEtry.Text;
        //    if (connect.ValidPsw(email, ps.Text))
        //    {
        //        FramePsw.BackgroundColor = Color.FromHex("#97F382");
        //        alertPsw.IsVisible = false;
        //    }
        //    else
        //    {
        //        alertPsw.IsVisible = true;
        //    }
        //}
    }
}