using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Android.Hardware;
using Android.Content;

namespace RandomUsers.Droid
{
    [Activity(Label = "RandomUsers", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static readonly object _syncLock = new object();

        private SensorManager _sensorManager;
        private Sensor _sensor;
        private ShakeDetector _shakeDetector;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircle.Forms.Plugin.Droid.ImageCircleRenderer.Init();
            _sensorManager = (SensorManager)GetSystemService(Context.SensorService);
            _sensor = _sensorManager.GetDefaultSensor(SensorType.Accelerometer);

            _shakeDetector = new ShakeDetector();
#if DEBUG
            StreamReader strm = new StreamReader(Assets.Open("data.json"));
            var json = strm.ReadToEnd();
            
            
            
            LoadApplication(new App(json));
#else
            var app = new App();

            _shakeDetector.Shaked += (sender, shakeCount) =>
            {
                lock (_syncLock)
                {
                    app.Shake(shakeCount);
                }
            };

            LoadApplication(app);
#endif
        }

        protected override void OnResume()
        {
            base.OnResume();
            _sensorManager.RegisterListener(_shakeDetector, _sensor, SensorDelay.Ui);
        }

        protected override void OnPause()
        {
            base.OnPause();
            _sensorManager.UnregisterListener(_shakeDetector);
        }
    }
}

