using Acr.UserDialogs;
using InfiniteScroll.Models;
using InfiniteScroll.Services;
using InfiniteScroll.Views;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace InfiniteScroll.ViewModels
{
    class UserListViewModel : BindableBase
    {
        private ObservableCollection<UserInfo> _DataSource;

        private bool _IsRefreshing;

        public INavigation navigationVR;

        public ObservableCollection<UserInfo> DataSource
        {
            get { return _DataSource; }
            set { this.SetProperty(ref this._DataSource, value); }
        }

        public ICommand LoadRefreshCommand { get; private set; }

        public bool isLoading;

        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set { this.SetProperty(ref this._IsRefreshing, value); }
        }

        public int page = 0;

        public ICommand ItemSelectedCommand { get; private set; }

        public UserListViewModel()
        {
            LoadRefreshCommand = new Command(LoadRefreshCommandTemp);

            ItemSelectedCommand = new Command<UserInfo>(ItemSelectedProc);
        }

        async public void ItemSelectedProc(UserInfo userinfo)
        {
            if (userinfo == null) return;
           
            await Task.Yield();

            await navigationVR.PushAsync(new UserDetail(userinfo), false);

        }

        public async Task LoadItems()
        {
            isLoading = true;

            ObservableCollection<UserInfo> userlist = new ObservableCollection<UserInfo>();

            UserInfo muser = null;

            using (UserDialogs.Instance.Loading("데이타 로딩중..."))
            {

                using (var client = new HttpClient())
                {
                    //http 연결

                    page++;

                    var uri = "https://randomuser.me/api/?page=" + page + "&results=20&seed=abc";

                    var response = await client.GetAsync(uri);

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();

                        //Json 오브젝트 생성
                        JObject obj = JObject.Parse(content);

                        //Member오브젝트 배열 생성
                        JArray arr = (JArray)obj["results"];

                        //배열 Json 오브젝트 파싱

                        var _idnumber = "";
                        var _gender = "";
                        var _nametitle = "";
                        var _namefirst = "";
                        var _namelast = "";
                        var _locationstreet = "";
                        var _locationcity = "";
                        var _locationstate = "";
                        var _email = "";
                        var _loginusername = "";
                        var _loginuserpassword = "";
                        var _dob = "";
                        var _registered = "";
                        var _phone = "";
                        var _cell = "";
                        var _large = "";
                        var _medium = "";

                        for (int i = 0; i < arr.Count; i++)
                        {
                            JObject arrObj = (JObject)arr[i];

                            _idnumber = arrObj["id"]["value"].ToString();
                            _gender = arrObj["gender"].ToString();
                            _nametitle = arrObj["name"]["title"].ToString();
                            _namefirst = arrObj["name"]["first"].ToString();
                            _namelast = arrObj["name"]["last"].ToString();
                            _locationstreet = arrObj["location"]["street"].ToString();
                            _locationcity = arrObj["location"]["city"].ToString();
                            _locationstate = arrObj["location"]["state"].ToString();
                            _email = arrObj["email"].ToString();
                            _loginusername = arrObj["login"]["username"].ToString();
                            _loginuserpassword = arrObj["login"]["password"].ToString();
                            _dob = arrObj["dob"].ToString();
                            _registered = arrObj["registered"].ToString();
                            _phone = arrObj["phone"].ToString();
                            _cell = arrObj["cell"].ToString();
                            _large = arrObj["picture"]["large"].ToString();
                            _medium = arrObj["picture"]["medium"].ToString();

                            muser = new UserInfo(_idnumber, _gender, _nametitle, _namefirst, _namelast, _locationstreet, _locationcity, _locationstate, _email, _loginusername, _loginuserpassword, _dob, _registered, _phone, _cell, _large, _medium);

                            if (page == 1) userlist.Add(muser);
                            else DataSource.Add(muser);

                        }

                        if (page == 1) DataSource = userlist;

                    }
                    else
                    {
                        page--;
                    }


                }
            }

            isLoading = false;
        }

        public void LoadRefreshCommandTemp()
        {
            Task.Run(async () =>
            {
                await LoadRefreshCommandPro();
            });

        }
        public async Task LoadRefreshCommandPro()
        {
            isLoading = true;

            IsRefreshing = true;

            ObservableCollection<UserInfo> userlist = new ObservableCollection<UserInfo>();

            UserInfo muser = null;

            var totalPerson = page * 10;

            // 한꺼번에 너무 많이 읽으면 200개로 제한하고 페이지 넘버를 10으로 준다.
            if (totalPerson > 200)
            {
                totalPerson = 200;
                page = 10;
            }

            using (var client = new HttpClient())
            {
                //http 연결
                var uri = "https://randomuser.me/api/?page=1&results=" + totalPerson + "&seed=abc";

                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    DataSource = null;

                    var content = await response.Content.ReadAsStringAsync();

                    //Json 오브젝트 생성
                    JObject obj = JObject.Parse(content);

                    //Member오브젝트 배열 생성
                    JArray arr = (JArray)obj["results"];

                    //배열 Json 오브젝트 파싱

                    var _idnumber = "";
                    var _gender = "";
                    var _nametitle = "";
                    var _namefirst = "";
                    var _namelast = "";
                    var _locationstreet = "";
                    var _locationcity = "";
                    var _locationstate = "";
                    var _email = "";
                    var _loginusername = "";
                    var _loginuserpassword = "";
                    var _dob = "";
                    var _registered = "";
                    var _phone = "";
                    var _cell = "";
                    var _large = "";
                    var _medium = "";

                    for (int i = 0; i < arr.Count; i++)
                    {
                        JObject arrObj = (JObject)arr[i];

                        _idnumber = arrObj["id"]["value"].ToString();
                        _gender = arrObj["gender"].ToString();
                        _nametitle = arrObj["name"]["title"].ToString();
                        _namefirst = arrObj["name"]["first"].ToString();
                        _namelast = arrObj["name"]["last"].ToString();
                        _locationstreet = arrObj["location"]["street"].ToString();
                        _locationcity = arrObj["location"]["city"].ToString();
                        _locationstate = arrObj["location"]["state"].ToString();
                        _email = arrObj["email"].ToString();
                        _loginusername = arrObj["login"]["username"].ToString();
                        _loginuserpassword = arrObj["login"]["password"].ToString();
                        _dob = arrObj["dob"].ToString();
                        _registered = arrObj["registered"].ToString();
                        _phone = arrObj["phone"].ToString();
                        _cell = arrObj["cell"].ToString();
                        _large = arrObj["picture"]["large"].ToString();
                        _medium = arrObj["picture"]["medium"].ToString();

                        muser = new UserInfo(_idnumber, _gender, _nametitle, _namefirst, _namelast, _locationstreet, _locationcity, _locationstate, _email, _loginusername, _loginuserpassword, _dob, _registered, _phone, _cell, _large, _medium);

                        userlist.Add(muser);

                    }

                    DataSource = userlist;


                }



            }


            isLoading = false;
            IsRefreshing = false;

        }

    }
}
