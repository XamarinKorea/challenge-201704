using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace clg1704
{
	public partial class clg1704Page : ContentPage
	{

		public ObservableCollectionCustomized<UserItem> listUser = new ObservableCollectionCustomized<UserItem>();

		private bool isLoading = false;


		public clg1704Page()
		{
			InitializeComponent();

			lv.ItemsSource = listUser;

			aIndicator.IsRunning = false;

			getDataFirst();
		}


		private async Task getDataFirst()
		{
			ObservableCollectionCustomized<UserItem> gotData = await getRandomData();

			listUser.AddRange( gotData );
		}


		private async Task<ObservableCollectionCustomized<UserItem>> getRandomData()
		{
			if (isLoading) return new ObservableCollectionCustomized<UserItem>();

			isLoading = true;
			aIndicator.IsRunning = true;

			Debug.WriteLine("get data");

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

			ObservableCollectionCustomized<UserItem> gotData = makeUserDataPretty( jarray );

			isLoading = false;
			aIndicator.IsRunning = false;

			return gotData;
		}


		private ObservableCollectionCustomized<UserItem> makeUserDataPretty( JArray jarray )
		{
			ObservableCollectionCustomized<UserItem> gotData = new ObservableCollectionCustomized<UserItem>();

			UserItem userItem;

			foreach (JObject item in jarray)
			{
				userItem = new UserItem();

				userItem.Gender = (string)item["gender"];

				userItem.NameFirst = (string)item["name"]["first"];

				userItem.LocationCity = (string)item["location"]["city"];
				userItem.LocationState = (string)item["location"]["state"];

				userItem.Cell = (string)item["cell"];

				userItem.PictureLarge = (string)item["picture"]["large"];
				userItem.PictureThumbnail = (string)item["picture"]["thumbnail"];

				userItem.Nat = (string)item["nat"];

				gotData.Add(userItem);
			}

			return gotData;
		}


		private async void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			if( (UserItem)e.Item == listUser[ listUser.Count - 1 ] )
			{
				Debug.WriteLine("last item");

				ObservableCollectionCustomized<UserItem> gotData = await getRandomData();

				listUser.AddRange( gotData );
			}
		}


		private async void OnRefreshing(object sender, EventArgs e)
		{
			lv.IsRefreshing = false;

			ObservableCollectionCustomized<UserItem> gotData = await getRandomData();

			listUser.Clear();

			listUser.AddRange( gotData );
		}


		private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			UserItem model = lv.SelectedItem as UserItem;

			lv.SelectedItem = null;

			DetailPage detail = new DetailPage( model );

			await Navigation.PushAsync(detail);
		}

	}
}
