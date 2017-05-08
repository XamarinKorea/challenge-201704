using RandomUsers.Models;
using Xamarin.Forms;

namespace RandomUsers
{

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