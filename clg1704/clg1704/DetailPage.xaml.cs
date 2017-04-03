using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace clg1704
{
	public partial class DetailPage : ContentPage
	{
		public DetailPage( UserItem item )
		{
			InitializeComponent();

			this.Title = item.NameFirst;

			imageUser.Source = item.PictureLarge;
		}
	}
}
