using InfiniteScroll.Models;
using InfiniteScroll.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfiniteScroll.ViewModels
{
    class UserDetailViewModel : BindableBase
    {
        private UserInfo _userinfo;
        public ICommand tapBack { get; private set; }

        public INavigation navigationVR;

        public UserInfo userinfo
        {
            get { return _userinfo; }
            set { this.SetProperty(ref this._userinfo, value); }
        }

        public UserDetailViewModel()
        {
            tapBack = new Command(tabBackPro);

        }

        async private void tabBackPro(object s)
        {
//            await Task.Yield();

            await navigationVR.PopAsync(false);

        }
        

    }
}
