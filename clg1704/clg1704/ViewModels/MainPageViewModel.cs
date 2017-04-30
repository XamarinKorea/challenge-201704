using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace clg1704
{
	public class MainPageViewModel : BaseViewModel
	{

		public ObservableCollectionCustomized<UserItem> listUser = new ObservableCollectionCustomized<UserItem>();

		private bool isLoading = false;
		private bool isRefreshing = false;

		//private uint nItemIdx = 0;


		public MainPageViewModel()
		{
			getDataFirst();
		}

		public async Task getDataFirst()
		{
			ObservableCollectionCustomized<UserItem> gotData = await getRandomData();

			listUser.AddRange(gotData);
		}

		private async Task<ObservableCollectionCustomized<UserItem>> getRandomData()
		{
			if (isLoading) return new ObservableCollectionCustomized<UserItem>();

			IsLoading = true;

			const string RANDON_DATA_URL = "https://randomuser.me/api/?results=20&nat=AU,BR,CA,CH,DE,DK,ES,FI,FR,GB,IE,NL,NZ,TR,US";

			//var httpClient = new HttpClient(new NativeMessageHandler());
			//var httpClient = new HttpClient();
			//HttpResponseMessage res = await httpClient.GetAsync("https://randomuser.me/api/?results=20");
			//string message = await res.Content.ReadAsStringAsync();
			//Debug.WriteLine("Message : " + message);

			HttpClient client = new HttpClient();

			HttpResponseMessage response = await client.GetAsync(RANDON_DATA_URL);

			if (!response.IsSuccessStatusCode)
			{
				return new ObservableCollectionCustomized<UserItem>();
			}

			string result = response.Content.ReadAsStringAsync().Result;

			JObject json = JObject.Parse(result);
			JArray jarray = (JArray)json["results"];

			ObservableCollectionCustomized<UserItem> gotData = makeUserDataPretty(jarray);

			IsLoading = false;

			return gotData;
		}

		public async void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			if ((UserItem)e.Item == listUser[listUser.Count - 1])
			{
				Debug.WriteLine("last item");

				ObservableCollectionCustomized<UserItem> gotData = await getRandomData();

				listUser.AddRange(gotData);
			}
		}


		public async void OnRefreshing(object sender, EventArgs e)
		{
			Debug.WriteLine( "OnRefreshing" );

			IsRefreshing = false;

			ObservableCollectionCustomized<UserItem> gotData = await getRandomData();

			listUser.Clear();

			listUser.AddRange(gotData);
		}

		private ObservableCollectionCustomized<UserItem> makeUserDataPretty(JArray jarray)
		{
			ObservableCollectionCustomized<UserItem> gotData = new ObservableCollectionCustomized<UserItem>();

			UserItem userItem;

			foreach (JObject item in jarray)
			{
				userItem = new UserItem();

				userItem.Gender = (string)item["gender"];

				userItem.NameFirst = (string)item["name"]["first"];

				userItem.Cell = (string)item["cell"];

				userItem.PictureLarge = (string)item["picture"]["large"];
				userItem.PictureThumbnail = (string)item["picture"]["thumbnail"];

				//userItem.Idx = nItemIdx;
				//++nItemIdx;

				gotData.Add(userItem);
			}

			return gotData;
		}

		public ObservableCollectionCustomized<UserItem> ListUser
		{
			get
			{
				return listUser;
			}
			set
			{
				listUser = value;
			}
		}

		public bool IsLoading
		{
			get
			{
				return isLoading;
			}
			set
			{
				isLoading = value;

				OnPropertyChanged( "IsLoading" );
			}
		}

		public bool IsRefreshing
		{
			get
			{
				return isRefreshing;
			}
			set
			{
				isRefreshing = value;

				OnPropertyChanged("IsRefreshing");
			}
		}

	}
}
