using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinChallengeApril.Models;

namespace XamarinChallengeApril.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage(Person people)
        {
            InitializeComponent();
            detailImage.Source = ImageSource.FromUri(new Uri(people.ImageUrl));
            detailName.Text = people.Name;
            detailPhone.Text = people.PhoneNumber;
        }
    }
}
