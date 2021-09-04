using CarTeckM.Data;
using CarTeckM.MasterDetail;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
 
namespace CarTeckM
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new MDP();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        
    }
}
