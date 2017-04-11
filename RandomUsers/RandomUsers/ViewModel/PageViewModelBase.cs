using GalaSoft.MvvmLight;
using Xamarin.Forms;

namespace RandomUsers.ViewModel
{

    public class PageViewModelBase : ViewModelBase
    {
        protected INavigation Navigation
        {
            get
            {
                return Application.Current.MainPage.Navigation;
            }
        }
    }
}