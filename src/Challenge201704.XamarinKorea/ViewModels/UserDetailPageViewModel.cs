using Challenge201704.XamarinKorea.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms.Maps;
using System.Linq;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Challenge201704.XamarinKorea.ViewModels
{
    /// <summary>
    /// UserDetailPage.xaml 페이지와 연결된 UserDetailPageViewModel class 
    /// </summary>
    /// <remarks>
    /// 사용자 상세 정보 페이지에서 사용되는 ViewModel
    /// Prism 참조 
    /// https://github.com/PrismLibrary/Prism/tree/master/docs/Xamarin-Forms
    /// Xamarin.Forms.Maps 참조
    /// https://developer.xamarin.com/guides/xamarin-forms/user-interface/map/
    /// </remarks>
    public class UserDetailPageViewModel : BindableBase, INavigationAware
    {
        #region Private Fields

        private User user;
        //private Position position = new Position(37.79752, -122.40183);
        private DelegateCommand<Map> mapInitCommand;
        private bool canNotSearchAddress;
        #endregion

        #region Property Area

        /// <summary>
        /// User 상세 정보
        /// </summary>
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        /// <summary>
        /// 지도창에 주소 검색 가능 여부
        /// </summary>
        /// <value><c>true</c> 주소 검색결과가 없는 경우; 주소 검색 결과가 있는 경우 <c>false</c></value>
        public bool CanNotSearchAddress
        {
            get { return canNotSearchAddress; }
            set { SetProperty(ref canNotSearchAddress, value); }
        }
        #endregion

        #region Constructor
        public UserDetailPageViewModel()
        {
            
        }
        #endregion

        #region Command Area
        /// <summary>
        /// Get MapInitCommand
        /// </summary>
        /// <remarks>
        /// Map 정보 처리용
        /// </remarks>
        public DelegateCommand<Map> MapInitCommand =>
                                        mapInitCommand ?? (mapInitCommand =
                                                                new DelegateCommand<Map>( async(Map map) => await MapInit(map)));
        #endregion

        #region INavagationAware 인터페이스 구현
        /*
         * https://github.com/PrismLibrary/Prism/blob/master/docs/Xamarin-Forms/3-Navigation-Service.md 설명 참조
         */
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("user"))
                User = (User)parameters["user"];
        }
        #endregion

        #region Private Method
        /// <summary>
        /// 사용자 주소정보를 이용하여 지도에 표시하기
        /// </summary>
        /// <param name="map">Map instance</param>
        private async Task MapInit(Map map)
        {
            if (map is null)
                return;
            try
            {
                var geocoder = new Geocoder();
                var address = $"{User.Address.Street}, {User.Address.City}, {User.Address.State}";
                var positions = await geocoder.GetPositionsForAddressAsync(address);
                
                if(positions?.Count() > 0)
                {
                    //주소 검색으로 찾은 위치 정보중 첫번째 위치 정보만 이용
                    var position = positions.FirstOrDefault();
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(5)));
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = $"{User.Name.First}'s Home" ,
                        Address = address
                    };
                    map.Pins.Add(pin);
                    CanNotSearchAddress = false;
                }
                else
                {
                    //주소 검색이 되지 않을경우 기본 지도 화면 보여주기
                    //var position = new Position(37.7767729, -122.4188051);
                    //map.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(5)));
                    //var pin = new Pin
                    //{
                    //    Type = PinType.SavedPin,
                    //    Position = position,
                    //    Label = "자마린 본사",
                    //};
                    //map.Pins.Add(pin);
                    CanNotSearchAddress = true;
                }
                
            }
            catch(Exception ex)
            {
                CanNotSearchAddress = true;
                Debug.WriteLine($"Error in: {ex}");
            }
        }
        #endregion

    }
}
