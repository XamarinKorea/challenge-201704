using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
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

			aIndicator.IsRunning = false;

			getRandomData();

			lv.ItemsSource = listUser;

			lv.ItemAppearing += OnItemAppearing;
		}


		private void OnItemAppearing( object sender, ItemVisibilityEventArgs  e )
		{
			//Debug.WriteLine( "OnItemAppearing" + ((UserItem)e.Item).Idx );

			if ( ((UserItem)e.Item).Idx == listUser.Count - 1 )
			{
				Debug.WriteLine( "last" );

				getRandomData();
			}
		}


		private async Task getRandomData()
		{
			if (isLoading) return;

			isLoading = true;
			aIndicator.IsRunning = true;

			Debug.WriteLine( "get data ing/" );

			const string RANDON_DATA_URL = "https://randomuser.me/api/?results=30&nat=AU,BR,CA,CH,DE,DK,ES,FI,FR,GB,IE,NL,NZ,TR,US";

			HttpClient client = new HttpClient();

			HttpResponseMessage response = client.GetAsync(RANDON_DATA_URL).Result;  // Blocking call!

			if (!response.IsSuccessStatusCode)
			{
				return;
			}

			string result = response.Content.ReadAsStringAsync().Result;

			JObject json = JObject.Parse(result);
			JArray jarray = (JArray)json["results"];

			//Debug.WriteLine( result );

			//"results": [
			//   {
			//     "gender": "male",
			//     "name": {
			//       "title": "mr",
			//       "first": "romain",
			//       "last": "hoogmoed"

			//  },
			//     "location": {
			//       "street": "1861 jan pieterszoon coenstraat",
			//       "city": "maasdriel",
			//       "state": "zeeland",
			//       "postcode": 69217
			//     },
			//     "email": "romain.hoogmoed@example.com",
			//     "login": {
			//       "username": "lazyduck408",
			//       "password": "jokers",
			//       "salt": "UGtRFz4N",
			//       "md5": "6d83a8c084731ee73eb5f9398b923183",
			//       "sha1": "cb21097d8c430f2716538e365447910d90476f6e",
			//       "sha256": "5a9b09c86195b8d8b01ee219d7d9794e2abb6641a2351850c49c309f1fc204a0"
			//     },
			//     "dob": "1983-07-14 07:29:45",
			//     "registered": "2010-09-24 02:10:42",
			//     "phone": "(656)-976-4980",
			//     "cell": "(065)-247-9303",
			//     "id": {
			//       "name": "BSN",
			//       "value": "04242023"
			//     },
			//     "picture": {
			//       "large": "https://randomuser.me/api/portraits/men/83.jpg",
			//       "medium": "https://randomuser.me/api/portraits/med/men/83.jpg",
			//       "thumbnail": "https://randomuser.me/api/portraits/thumb/men/83.jpg"
			//     },
			//     "nat": "NL"
			//   }
			// ],

			UserItem userItem;

			foreach (JObject item in jarray)
			{
				//string strItem = item.ToString(Newtonsoft.Json.Formatting.None);

				userItem = new UserItem();

				userItem.Gender = (string)item[ "gender" ];

				userItem.NameFirst = (string)item["name"]["first"];

				userItem.LocationCity = (string)item["location"]["city"];
				userItem.LocationState = (string)item["location"]["state"];

				userItem.Cell = (string)item["cell"];

				userItem.PictureLarge = (string)item["picture"]["large"];
				userItem.PictureThumbnail = (string)item["picture"]["thumbnail"];

				userItem.Nat = (string)item["nat"];

				userItem.Idx = listUser.Count;

				//Debug.WriteLine( userItem.Idx + " / " + userItem.NameFirst + " / " + userItem.Nat );

				listUser.Add( userItem );
			}

			isLoading = false;
			aIndicator.IsRunning = false;

		}
	}
}
