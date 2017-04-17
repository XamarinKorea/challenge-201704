using Challenge201704.XamarinKorea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Challenge201704.XamarinKorea.Selectors
{
    /// <summary>
    /// 성별에 따른 Template Selector
    /// </summary>
    public class GenderDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Male { get; set; }
        public DataTemplate Female { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((User)item).Gender.Equals(Gender.Male) ? Male : Female;
        }
    }
}
