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
using Windows.Storage;
using System.Threading.Tasks;
using WSL_Guideline_UWP.Models;
using System.Collections.ObjectModel;
using WSL_Guideline_UWP.Views;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Core;
using Windows.UI;

namespace WSL_Guideline_UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //初始化TitleBar
            InitializeTitleBar();
            UpdateAppTitleVisibility();
            ContentFrame.Navigate(typeof(ArticleMasterDetailView));
        }

        #region 自定义TitleBar
        /// 初始化TitleBar
        private void InitializeTitleBar()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            //remove the solid-colored backgrounds behind the caption controls and system back button
            var viewTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.ButtonBackgroundColor = Colors.Transparent;
            viewTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            viewTitleBar.ButtonForegroundColor = (Color)Resources["SystemBaseHighColor"];

            //TitleBar尺寸改变事件
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
            //TitleBar可见性改变事件
            coreTitleBar.IsVisibleChanged += CoreTitleBar_IsVisibleChanged;

            Window.Current.SetTitleBar(AppTitleBar);

        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            UpdateTitleBarLayout(sender);
        }

        private void UpdateTitleBarLayout(CoreApplicationViewTitleBar sender)
        {
            AppTitleBar.Height = sender.Height;
            AppTitle.Margin = new Thickness(sender.SystemOverlayLeftInset + 10, 0, 0, 0);
            UpdateNavView(sender.Height);
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
            {
                AppTitleBar.Visibility = Visibility.Visible;
                UpdateNavView(sender.Height);
            }
            else
            {
                AppTitleBar.Visibility = Visibility.Collapsed;
                UpdateNavView(0);
            }
        }
        #endregion

        /// 自定义页面内容上边距
        private void UpdateNavView(double appTitleBarHeight)
        {
            var currentMarginTop = MenuButton.Height +appTitleBarHeight;
            MenuListView.Margin = new Thickness(0, currentMarginTop, 0, 0);
            ContentFrame.Padding = new Thickness(0, currentMarginTop, 0, 0);

        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavView.IsPaneOpen = !NavView.IsPaneOpen;
            UpdateAppTitleVisibility();
        }

        private void UpdateAppTitleVisibility()
        {
            if (NavView.IsPaneOpen)
                AppTitle.Visibility = Visibility.Visible;
            else
                AppTitle.Visibility = Visibility.Collapsed;
        }

        private void MenuListView_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}
