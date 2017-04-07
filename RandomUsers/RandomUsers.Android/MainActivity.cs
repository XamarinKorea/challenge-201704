using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;

namespace RandomUsers.Droid
{
    [Activity(Label = "RandomUsers", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
#if DEBUG
            StreamReader strm = new StreamReader(Assets.Open("data.json"));
            var json = strm.ReadToEnd();
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();
            LoadApplication(new App(json));
#else
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();
            LoadApplication(new App());
#endif
        }
    }
}

