using Challenge201704.XamarinKorea.DataServices;
using Challenge201704.XamarinKorea.DataServices.Base;
using Challenge201704.XamarinKorea.DataServices.Interfaces;
using Challenge201704.XamarinKorea.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("MainNavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<IRequestProvider, RequestProvider>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IUserService, UserService>(new ContainerControlledLifetimeManager());

            Container.RegisterTypeForNavigation<MainNavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<UserDetailPage>();
        }
    }
}
