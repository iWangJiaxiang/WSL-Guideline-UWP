using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WSL_Guideline_UWP.ViewModels;

namespace WSL_Guideline_UWP.Views
{
    public sealed partial class HomeView : Page
    {
        private string HomeArticle = @"\ArticleData\WSL-Guideline\README.md";

        private ArticleViewModel ViewModel;

        public HomeView()
        {
            this.InitializeComponent();

            ViewModel = new ArticleViewModel();
            ViewModel.LoadModelAsync(HomeArticle);

            Models.CurrentMarginTop.OnCurrentMarginTopChanged += CurrentMarginTop_OnCurrentMarginTopChanged;
            CurrentMarginTop_OnCurrentMarginTopChanged();
                }

        private void CurrentMarginTop_OnCurrentMarginTopChanged()
        {
            if (Models.CurrentMarginTop.IsDisplayModeOverLay)
            {
                RootGrid.Padding = new Thickness(0, Models.CurrentMarginTop.MarginTop, 0, 0);
            }
            else
            {
                RootGrid.Padding = new Thickness(0, 0, 0, 0);
            }
        }

        private async void HomeMarkDown_LinkClicked(object sender, Microsoft.Toolkit.Uwp.UI.Controls.LinkClickedEventArgs e)
        {
            if (e.Link.StartsWith("http")|| e.Link.StartsWith("mail"))
                await Windows.System.Launcher.LaunchUriAsync(new Uri(e.Link));
            else
            {
                //await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>
                //{
                //    var current = Window.Current;
                //    var view = ApplicationView.GetForCurrentView();
                //});
                //await Window.Current.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.High, () =>{
                //    MainPage.
                //});
                this.Frame.Navigate(typeof(ArticleView));
            }
        }
    }
}
