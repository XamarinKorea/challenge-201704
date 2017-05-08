using GalaSoft.MvvmLight.Messaging;
using RandomUsers.Models;

namespace RandomUsers.ViewModel
{

    public class UserDetailViewModel : PageViewModelBase
    {
        private User _user;
        public UserDetailViewModel()
        {
            Messenger.Default.Register<User>(this, user => { User = user; });
        }

        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
                RaisePropertyChanged();
            }
        }
    }
}