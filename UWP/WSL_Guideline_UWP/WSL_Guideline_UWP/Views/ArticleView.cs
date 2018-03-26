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
    /// <summary>
    /// 文章页面
    /// </summary>
    public sealed partial class ArticleView : Page
    {
        private string CurrentSelectionInMasterDetailView = "";
        private string PreviousSelectionInMasterDetailView = "";
        private string ArticleFolder = @"\ArticleData\WSL-Guideline\中文";

        private ArticlesViewModel ViewModel;
        public ArticleView()
        {
            this.InitializeComponent();

            ViewModel = new ArticlesViewModel();

            ViewModel.LoadModelsAsync(ArticleFolder);
            
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

        private void DetailScrollBar_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            if (PreviousSelectionInMasterDetailView == CurrentSelectionInMasterDetailView)
            {
                return;
            }
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            scrollViewer.ScrollToVerticalOffset(0);
            PreviousSelectionInMasterDetailView = CurrentSelectionInMasterDetailView;
        }

        private void MainMDView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectionName = ((Article)((Microsoft.Toolkit.Uwp.UI.Controls.MasterDetailsView)sender).SelectedItem).Name;
            if (CurrentSelectionInMasterDetailView != selectionName)
            {
                CurrentSelectionInMasterDetailView = selectionName;
            }
        }
    }
}
