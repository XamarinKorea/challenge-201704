using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace clg1704
{
	public partial class MainPage : ContentPage
	{

		readonly MainPageViewModel vm;


		public MainPage()
		{
			InitializeComponent();

			vm = new MainPageViewModel();
			this.BindingContext = vm;
		}

		private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
		{
			vm.OnItemAppearing( sender, e );
		}

		private void OnRefreshing(object sender, EventArgs e)
		{
			vm.OnRefreshing( sender, e );
		}

		public async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null)
			{
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			UserItem model = lvMain.SelectedItem as UserItem;

			lvMain.SelectedItem = null;

			DetailPage detail = new DetailPage(model);

			await Navigation.PushAsync(detail);
		}

	}
}
