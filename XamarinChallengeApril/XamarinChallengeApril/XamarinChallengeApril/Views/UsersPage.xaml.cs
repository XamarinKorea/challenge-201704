using ModernHttpClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChallengeApril.Controls;
using XamarinChallengeApril.Models;

namespace XamarinChallengeApril.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public int page = 1;
        private ObservableCollection<Person> _peoples;
        public UsersPage()
        {
            InitializeComponent();
            //리스트뷰에 매핑 
            //infiniteListView.ItemsSource = Peoples;
            //무한 리스트 추가에 매핑
            //infiniteListView.LoadMoreCommand = LoadCharactersCommand;
            //매핑이 아닌 바인딩
            infiniteListView.SetBinding(ListView.ItemsSourceProperty, new Binding("Peoples"));
            infiniteListView.SetBinding(InfiniteListView.LoadMoreCommandProperty, new Binding("LoadCharactersCommand"));
            GetUserInfo();
            LoadCharactersCommand = new Command(GetUserInfo);
            ListClickCommand = new Command(GetUserInfo);
            infiniteListView.ItemSelected += async (sender, e) => {
                ((ListView)sender).SelectedItem = null;
                if(((ListView)sender).SelectedItem != null)
                {
                    Debug.WriteLine("ItemSelected");
                    await Navigation.PushAsync(new UserDetailPage((Person)e.SelectedItem));
                }
            };
        }
        public ICommand LoadCharactersCommand { get; set; }
        public ICommand ListClickCommand { get; set; }
        public async void GetUserInfo()
        {
            //파싱할 데이터를 담을 변수들 
            string phoneNumber;
            string imageUrl;
            string name;

            //JSON URL 요청 
            string url = "https://randomuser.me/api/?page=" + page + "&results=15";

            //HttpClient 객체 생성
            HttpClient client = new HttpClient(new NativeMessageHandler());
            Debug.WriteLine("Page = "+page);
            //url로 요청 후 response에 결과값 담음
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                //결과 값을 String으로 변환한 후
                var content = await response.Content.ReadAsStringAsync();

                //NewtonSoft.Json 패키지를 이용하여 데이터 파싱 시작
                var data = JObject.Parse(content);

                for (int i = 0; i < 15; i++)
                {
                    //JSON 데이터 중 phone, thumbnail, first 만 담아서 리스트에 추가 
                    phoneNumber = (string)data["results"][i]["phone"];
                    imageUrl = (string)data["results"][i]["picture"]["thumbnail"];
                    name = (string)data["results"][i]["name"]["first"];
                    Peoples.Add(new Person(name, imageUrl, phoneNumber));
                }
                page++;
            }
        }
        public ObservableCollection<Person> Peoples
        {
            get { return _peoples ?? (_peoples = new ObservableCollection<Person>()); }
        }

    }
}
