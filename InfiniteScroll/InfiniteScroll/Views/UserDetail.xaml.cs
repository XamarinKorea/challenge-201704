using InfiniteScroll.Models;
using InfiniteScroll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfiniteScroll.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetail : ContentPage
    {
        readonly UserDetailViewModel _vm;

        public UserDetail(UserInfo _userinfo)
        {
            InitializeComponent();

            _vm = new ViewModels.UserDetailViewModel();

            _vm.navigationVR = Navigation;

            _vm.userinfo = _userinfo;

            BindingContext = _vm;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PopAsync(false);

            return true;
        }

    }
}
