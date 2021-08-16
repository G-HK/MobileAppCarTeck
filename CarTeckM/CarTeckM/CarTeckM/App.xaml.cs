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

        static CRTKDatabase database;


        public static CRTKDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CRTKDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Crtk.db3"));
                }
                return database;
            }
        }
    }
}
