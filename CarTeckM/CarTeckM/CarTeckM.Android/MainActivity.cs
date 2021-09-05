using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using CarTeckM.Helpers;
using Xamarin.Essentials;
using CarTeckM.Services;
using CarTeckM.Droid;
using System.IO;
using Android.Content;

[assembly: Dependency(typeof(Toaster))]
[assembly: Dependency(typeof(CarTeckM.Droid.Environment))]
//[assembly: Dependency(typeof(CarTeckM.Droid.FileService))]

namespace CarTeckM.Droid
{
    [Activity(Label = "CarFee", Icon = "@drawable/CarTeckLogo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            NativeMedia.Platform.Init(this, savedInstanceState);


            //Plugins
            Rg.Plugins.Popup.Popup.Init(this);


            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (NativeMedia.Platform.CheckCanProcessResult(requestCode, resultCode, data))
            {
                NativeMedia.Platform.OnActivityResult(requestCode, resultCode, data);
            }


            base.OnActivityResult(requestCode, resultCode, data);


        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override void OnBackPressed()
        {

            // Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed);

            //if (Rg.Plugins.Popup.Popup.SendBackPressed(base.OnBackPressed))
            //{
            //    // Do something if there are some pages in the `PopupStack`
            //}
            //else
            //{
            //    // Do something if there are not any pages in the `PopupStack`
            //}


        }

    }
    public class Toaster : IToast
    {
        public void MakeToast(string message)
        {
            Toast.MakeText(Platform.AppContext, message, ToastLength.Long).Show();
        }
    }
    public class Environment : IEnvironment
    {
        public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
        {
            if (Build.VERSION.SdkInt < Android.OS.BuildVersionCodes.Lollipop)
                return;

            var activity = Platform.CurrentActivity;
            var window = activity.Window;
            window.AddFlags(Android.Views.WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);
            window.SetStatusBarColor(color.ToPlatformColor());

            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.M)
            {
                var flag = (Android.Views.StatusBarVisibility)Android.Views.SystemUiFlags.LightStatusBar;
                window.DecorView.SystemUiVisibility = darkStatusBarTint ? flag : 0;
            }
        }
    }

    //public class FileService : IFileService
    //{
    //    public void SavePicture(string name, Stream data, string location = "temp")
    //    {
    //        var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
    //        documentsPath = Path.Combine(documentsPath, "Orders", location);
    //        Directory.CreateDirectory(documentsPath);

    //        string filePath = Path.Combine(documentsPath, name);

    //        byte[] bArray = new byte[data.Length];
    //        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
    //        {
    //            using (data)
    //            {
    //                data.Read(bArray, 0, (int)data.Length);
    //            }
    //            int length = bArray.Length;
    //            fs.Write(bArray, 0, length);
    //        }
    //    }
    //}

}