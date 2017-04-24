using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace RandomUsers.ViewModel
{

    public class PageViewModelBase : ViewModelBase
    {
        public App App
        {
            get
            {
                return (App)Application.Current;
            }
        }
        protected INavigation Navigation
        {
            get
            {
                return (Application.Current as App).MainPage.Navigation;
            }
        }
    }
}