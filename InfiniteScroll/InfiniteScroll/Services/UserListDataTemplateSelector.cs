using InfiniteScroll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InfiniteScroll.Services
{
    public class UserListDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ManTemplate { get; set; }
        public DataTemplate WomenTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object userinfo, BindableObject container)
        {
            var gender = ((UserInfo)userinfo).Gender;

            return ((UserInfo)userinfo).Gender == "male" ? ManTemplate : WomenTemplate;
        }
    }
}
