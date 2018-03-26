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
using WSL_Guideline_UWP.ViewModels;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace WSL_Guideline_UWP.Views
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class HomeView : Page
    {
        private string HomeArticle = @"\ArticleData\WSL-Guideline\README.md";

        private ArticleViewModel ViewModel;

        public HomeView()
        {
            this.InitializeComponent();

            ViewModel = new ArticleViewModel();
            ViewModel.LoadModelAsync(HomeArticle);
        }

        private async void HomeMarkDown_LinkClicked(object sender, Microsoft.Toolkit.Uwp.UI.Controls.LinkClickedEventArgs e)
        {
            if (e.Link.StartsWith("http")|| e.Link.StartsWith("mail"))
                await Windows.System.Launcher.LaunchUriAsync(new Uri(e.Link));
            else
            {
                this.Frame.Navigate(typeof(ArticleView));
            }
        }
    }
}
