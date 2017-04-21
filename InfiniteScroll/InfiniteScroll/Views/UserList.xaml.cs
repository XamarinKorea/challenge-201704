using InfiniteScroll.Models;
using InfiniteScroll.ViewModels;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InfiniteScroll.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserList : ContentPage
    {
        readonly UserListViewModel _vm;

        public UserList()
        {
            InitializeComponent();

            _vm = new ViewModels.UserListViewModel();

            BindingContext = _vm;

            userlist.ItemAppearing += async (sender, e) =>
            {
                if (_vm.isLoading || _vm.DataSource.Count == 0)
                    return;

                var itemunit = e.Item as UserInfo;

                if (itemunit.LoginUsername.ToString() == _vm.DataSource[_vm.DataSource.Count - 1].LoginUsername.ToString())
                {                    
                    await _vm.LoadItems();
                }

            };

            _vm.navigationVR = Navigation;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override async void OnAppearing()
        {
            if (_vm.isLoading || _vm.DataSource != null ) return;

            await _vm.LoadItems();

        }

        void UserTap(object sender, ItemTappedEventArgs e) => ((ListView)sender).SelectedItem = null;

        /* Event To Command로 처리
        async void UserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var userinfo = ((ListView)sender).SelectedItem as UserInfo;
            if (userinfo == null) return;

              await Task.Yield();

              await Navigation.PushAsync(new UserDetail(userinfo), false);
        }
        */

    }
}
