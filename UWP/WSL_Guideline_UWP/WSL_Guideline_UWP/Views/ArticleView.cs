using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
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
using WSL_Guideline_UWP.Models;
using System.Collections.ObjectModel;
using Windows.Storage;
using WSL_Guideline_UWP.ViewModels;
using WSL_Guideline_UWP.Helpers;

namespace WSL_Guideline_UWP.Views
{
    public sealed partial class ArticleView : Page
    {
        private string ArticleFolder = @"\ArticleData\WSL-Guideline\中文";

        private ArticlesViewModel ViewModel;
        public ArticleView()
        {
            this.InitializeComponent();

            ViewModel = new ArticlesViewModel();

            ViewModel.LoadModelsAsync(ArticleFolder);

            CurrentMarginTop.OnCurrentMarginTopChanged += CurrentMarginTop_OnCurrentMarginTopChanged;
            CurrentMarginTop_OnCurrentMarginTopChanged();
        }
        private void CurrentMarginTop_OnCurrentMarginTopChanged()
        {
            if (CurrentMarginTop.IsDisplayModeOverLay)
            {
                RootGrid.Padding = new Thickness(0, Models.CurrentMarginTop.MarginTop, 0, 0);
            }
            else
            {
                RootGrid.Padding = new Thickness(0, 0, 0, 0);
            }
        }

        private async void MarkdownTextBlock_LinkClicked(object sender, Microsoft.Toolkit.Uwp.UI.Controls.LinkClickedEventArgs e)
        {
            if (e.Link.StartsWith("http") || e.Link.StartsWith("mail"))
                await Windows.System.Launcher.LaunchUriAsync(new Uri(e.Link));
            else
            {
                MainMDView.SelectedItem = ViewModel.Articles.First(x => ((x.Name + ".md") == e.Link));
            }
        }

        private void ScrollViewer_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (args.NewValue == null)
                return;
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(0);
        }
    }
}
