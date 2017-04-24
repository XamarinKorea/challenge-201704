using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RandomUsers
{
    public partial class App : Application
    {
        public App()
        {
            
        }
        public static string Json;
        
        public App(string json)
        {
            Json = json;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            InitializeComponent();

            

            (MainPage as NavigationPage).Navigation.PushAsync(new MainPage());
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void Shake(int shakeCount)
        {
            (MainPage as NavigationPage).Navigation.PopAsync();
        }
    }
}
