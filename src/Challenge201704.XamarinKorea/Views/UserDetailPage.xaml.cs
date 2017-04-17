﻿using Challenge201704.XamarinKorea.ViewModels;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea.Views
{
    public partial class UserDetailPage : ContentPage
    {
        UserDetailPageViewModel viewmodel;
        public UserDetailPage()
        {
            InitializeComponent();
            viewmodel = (UserDetailPageViewModel)this.BindingContext;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //지도 내용 표시
            viewmodel.MapInitCommand.Execute(AddressMap);
        }
    }
}
