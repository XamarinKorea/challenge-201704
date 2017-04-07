using RandomUsers.Models;
using RandomUsers.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RandomUsers
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }

    public class UserDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MaleTemplate { get; set; }
        public DataTemplate FemaleTemplate { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var user = (User)item;
            if (user.Gender == "male")
            {
                return MaleTemplate;
            }
            else
            {
                return FemaleTemplate;
            }
        }
    }
}
