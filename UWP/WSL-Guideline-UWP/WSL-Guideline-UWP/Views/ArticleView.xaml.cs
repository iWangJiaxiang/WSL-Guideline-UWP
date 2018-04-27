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
using WSL_Guideline_UWP.Controls;
using Windows.UI.Xaml.Media.Imaging;

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

        string articleName = "";

        private void ScrollViewer_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            if (args.NewValue == null)
                return;

            /* 加入下一段的判断是因为
             * 当Markdown文本中的嵌入图片url来源于网络时
             * 在Markdown加载完成后会触发第一次意料之中的该DataContextChanged事件
             * 但是在网络图片加载完成后会触发第二次意料外的该事件
             * 如果在图片载入的时间内用户已经向下滚动了Markdown文本
             * 那么在图片载入完成后会因为触发了DataContextChanged事件
             * 导致页面自动回到顶部
             */
            string newArticleName = ((Article)args.NewValue).Name;
            if (articleName == newArticleName)
                return;
            articleName = newArticleName;

            ScrollViewer scrollViewer = (ScrollViewer)sender;
            //下面的已过时
            //scrollViewer.ScrollToVerticalOffset(0);
            scrollViewer.ChangeView(null, 0, null);
        }

        private void Md_ImageClicked(object sender, Microsoft.Toolkit.Uwp.UI.Controls.LinkClickedEventArgs e)
        {
            ImgViewer.Source = new BitmapImage(new Uri(e.Link));
            ImgViewer.Show();
        }
    }
}
