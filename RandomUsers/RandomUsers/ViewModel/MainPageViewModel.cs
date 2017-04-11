using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using RandomUsers.Models;
using RandomUsers.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace RandomUsers.ViewModel
{
    public class MainPageViewModel : PageViewModelBase
    {
        private DataService _dataservice;
        private bool _isRefresh;
        private ObservableCollection<User> _users;

        public MainPageViewModel()
        {
            _dataservice = new DataService();
            Users = new ObservableCollection<User>();
            RefreshCommand = new RelayCommand(RefreshData);
            MoreCommand = new RelayCommand(More);
            TappedCommand = new RelayCommand<ItemTappedEventArgs>(Tapped);

            RefreshData();
        }

        public bool IsRefresh
        {
            get
            {
                return _isRefresh;
            }

            set
            {
                _isRefresh = value;
                RaisePropertyChanged();
            }
        }

        public ICommand MoreCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }
        public ICommand TappedCommand { get; private set; }

        public ObservableCollection<User> Users
        {
            get { return _users; }
            set { _users = value; RaisePropertyChanged(); }
        }

        private async void More()
        {
            IsRefresh = true;
            var items = await _dataservice.GetUsersMore();
            foreach(var item in items)
            {
                Users.Add(item);
            }
            IsRefresh = false;
        }

        private async void RefreshData()
        {
            IsRefresh = true;
            var items = await _dataservice.GetUsers();
            Users = new ObservableCollection<User>(items);
            IsRefresh = false;
        }

        private async void Tapped(ItemTappedEventArgs args)
        {
            await Navigation.PushAsync(new UserDetail());
            Messenger.Default.Send<User>((User)args.Item);
        }
    }
}