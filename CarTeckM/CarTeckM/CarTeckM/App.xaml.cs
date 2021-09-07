using CarTeckM.Data;
using CarTeckM.Helpers;
using CarTeckM.MasterDetail;
using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MonkeyCache.FileStore;

namespace CarTeckM
{
    public partial class App : Application
    {
        ICRTKDatabase cr ;
        public App()
        {
            InitializeComponent();

            Barrel.ApplicationId = AppInfo.PackageName;

            //cr = DependencyService.Get<ICRTKDatabase>();
          
           


            MainPage = new MDP();

        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }


    }
}
