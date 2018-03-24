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
using Windows.UI.Xaml;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using WSL_Guideline_UWP.Models;
using System.Collections.ObjectModel;
using WSL_Guideline_UWP.Views;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;

namespace WSL_Guideline_UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //初始化TitleBar
            InitializeTitleBar();
            contentFrame.Navigate(typeof(ArticleMasterDetailView));
        }

        #region 自定义TitleBar
        /// 初始化TitleBar
        private void InitializeTitleBar()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
     
            //TitleBar尺寸改变事件
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
            //TitleBar可见性改变事件
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;
            Window.Current.SetTitleBar(MyTitleBar);
        }
        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            UpdateTitleBarLayout(sender);
        }
        private void UpdateTitleBarLayout(CoreApplicationViewTitleBar sender)
        {
            MyTitleBar.Height = sender.Height;
            TitleTB.Margin = new Thickness(sender.SystemOverlayLeftInset+10, 0, 0, 0);
        }
        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
            {
                MyTitleBar.Visibility = Visibility.Visible;
            }
            else
            {
                MyTitleBar.Visibility = Visibility.Collapsed;
            }
        }
        #endregion

    }
}
