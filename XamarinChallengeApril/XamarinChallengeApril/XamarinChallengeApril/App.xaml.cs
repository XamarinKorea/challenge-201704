using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XamarinChallengeApril.Views;

namespace XamarinChallengeApril
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new XamarinChallengeApril.MainPage());
            //MainPage = new XamarinChallengeApril.MainPage();
            BindingContext = new UsersPage();
            //MainPage = new XamarinChallengeApril.Views.UsersPage();
            MainPage = new NavigationPage(new XamarinChallengeApril.Views.UsersPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
