using Challenge201704.XamarinKorea.DataServices.Helpers;
using Challenge201704.XamarinKorea.DataServices.Interfaces;
using Challenge201704.XamarinKorea.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea.ViewModels
{
    /// <summary>
    /// MainPage.xaml 페이지와 연결된 MainlPageViewModel class 
    /// </summary>
    /// <remarks>
    /// 회원 리스트 페이지에서 사용되는 ViewModel
    /// Prism 참조 
    /// https://github.com/PrismLibrary/Prism/tree/master/docs/Xamarin-Forms
    /// Xamarin.Forms.Maps 참조
    /// https://developer.xamarin.com/guides/xamarin-forms/user-interface/map/
    /// </remarks>
    public class MainPageViewModel : BindableBase
    {
        #region private fields
        private INavigationService navigationService;
        private IUserService userService;
        private IPageDialogService dialogService;
        private int page = 1;
        private const int resultCnt = 20;
        private bool isBusy;
        private bool isNotBusy = true;
        private bool isRefreshing;
        private DelegateCommand refleshCommand;
        private DelegateCommand<User> dataLoadCommand;
        private DelegateCommand<User> userSelectedCommand;
        #endregion

        #region Property area
        /// <summary>
        /// Get or set the "IsBusy" property : 인스턴스 실행 가능 여부
        /// </summary>
        /// <value><c>true</c> if this instance is busy; otherwise, <c>false</c>.</value>
        public bool IsBusy
        {
            get { return isBusy; }
            set {
                SetProperty(ref isBusy, value);
                IsNotBusy = !isBusy;
            }
        }

        /// <summary>
        /// Get or set the "IsNotBusy" property
        /// </summary>
        /// <value><c>true</c> if this instance is not busy; otherwise, <c>false</c>.</value>
        public bool IsNotBusy
        {
            get { return isNotBusy; }
            private set { SetProperty(ref isNotBusy, value); }
        }


        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }
        /// <summary>
        /// Get or set the "Users" property
        /// </summary>
        /// <value>User 리스트</value>
        public ObservableRangeCollection<User> Users { get; set; } = new ObservableRangeCollection<User>();
        #endregion

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IUserService userService)
        {
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.userService = userService;
            Task.Run(async () => await LoadData()).Wait();
        }

        #region Command Area

        /// <summary>
        /// Get RefleshCommand
        /// </summary>
        /// <remarks>
        /// 참조 : Prism (https://github.com/PrismLibrary/Prism) DelegateCommand
        /// Pull to refresh 이벤트 처리용 
        /// </remarks>
        public DelegateCommand RefleshCommand =>
                                refleshCommand ?? (refleshCommand =
                                                    new DelegateCommand
                                                    (
                                                        async () =>
                                                        {
                                                            if (isRefreshing || isBusy)
                                                                return;

                                                            page = 1;
                                                            await LoadData();
                                                        }
                                                    ).ObservesCanExecute(() => IsNotBusy));
        /// <summary>
        /// Get DataLoadCommand
        /// </summary>
        /// <remarks>
        /// ListView ItemAppearing 이벤트 처리용
        /// </remarks>
        public DelegateCommand<User> DataLoadCommand =>
                                 dataLoadCommand ?? (dataLoadCommand =
                                                    new DelegateCommand<User>
                                                    (
                                                        async (User user) => 
                                                        {
                                                            if (IsBusy || Users.Count == 0)
                                                                return;

                                                            if (user == Users[Users.Count - 1])
                                                            {
                                                                await LoadData();
                                                            }
                                                        }
                                                    ).ObservesCanExecute(() => IsNotBusy));

        
        /// <summary>
        /// Get UserSelectedCommand
        /// </summary>
        /// <remarks>
        /// ListView ItemTapped 이벤트 처리용
        /// </remarks>
        public DelegateCommand<User> UserSelectedCommand => 
                                        userSelectedCommand ?? (userSelectedCommand = 
                                                                new DelegateCommand<User>
                                                                (
                                                                    async (User user) =>
                                                                    {
                                                                        var p = new NavigationParameters();
                                                                        p.Add("user", user);
                                                                        //Prim Navigation 내용 참조
                                                                        await navigationService.NavigateAsync("UserDetailPage", p);
                                                                    }
                                                                ).ObservesCanExecute(() => IsNotBusy));
        #endregion

        #region Private Method
        private async Task LoadData()
        {
            if (page == 1)
                isRefreshing = true;

            IsBusy = true;

            try
            {
                var users = await userService.GetUsersAsync(page,  resultCnt, "xamarinkorea", false);
                if (users?.Count > 0)
                {
                    if (page == 1)
                        Users.Clear();

                    Users.AddRange(users);
                    page++;
                }
            }
            catch (Exception ex) when (ex is WebException || ex is HttpRequestException)
            {
                await dialogService.DisplayAlertAsync("네트웍 에러 입니다.", "에러", "Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in: {ex}");
            }
            finally
            {
                IsBusy = false;
                isRefreshing = false;
            }
        }
        #endregion
    }
}
