using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using InfiniteScroll.Droid.Renderers;
using Android.Graphics;


[assembly: ExportRenderer(typeof(Label), typeof(CustomFontLabelRenderer))]
namespace InfiniteScroll.Droid.Renderers
{
    class CustomFontLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var fontFamily = e.NewElement.FontFamily?.ToLower();
            if (fontFamily != null && (fontFamily.EndsWith(".otf") || fontFamily.EndsWith(".ttf")))
            {
                var lable = (TextView)Control;
                lable.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets, e.NewElement.FontFamily);
            }
        }
    }
}