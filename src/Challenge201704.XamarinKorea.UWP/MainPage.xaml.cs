using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Prism.Unity;
using Microsoft.Practices.Unity;
using ImageCircle.Forms.Plugin.UWP;

namespace Challenge201704.XamarinKorea.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            //Circle Image Plugin 초기화
            ImageCircleRenderer.Init();

            //Xamarin Forms Maps 초기화 하기
            Xamarin.FormsMaps.Init("cVboouuKHjgWOVjbXxoE~wveD4VbrZb9-d54E7FGWQg~Avk4hpvqJF3Ke6NvWZ9wVSai3Pv9pXb0a6pDk6orKqb_mBXYjHclp4kGX6EZwcqL");
            LoadApplication(new Challenge201704.XamarinKorea.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }

}
