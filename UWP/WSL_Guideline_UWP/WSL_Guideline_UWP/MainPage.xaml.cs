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
using WSL_Guideline_UWP.ViewModels;
namespace WSL_Guideline_UWP
{
    public sealed partial class MainPage : Page
    {
        private MenuItemViewModel ViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MenuItemViewModel();
            //初始化TitleBar
            InitializeTitleBar();
            UpdateAppTitleVisibility();

            ContentFrame.Navigate(typeof(ArticleView));
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

        private void UpdateAppTitleVisibility()
        {
            if (NavMenu.IsPaneOpen)
                AppTitle.Visibility = Visibility.Visible;
            else
                AppTitle.Visibility = Visibility.Collapsed;
        }

        private void UpdateTitleBarLayout(CoreApplicationViewTitleBar sender)
        {
            AppTitleBar.Height = sender.Height;
            AppTitle.Margin = new Thickness(sender.SystemOverlayLeftInset + 10, 0, 0, 0);
            UpdateNavMenu(sender.Height);
        }

        private void CoreTitleBar_IsVisibleChanged(CoreApplicationViewTitleBar sender, object args)
        {
            if (sender.IsVisible)
            {
                AppTitleBar.Visibility = Visibility.Visible;
                UpdateNavMenu(sender.Height);
            }
            else
            {
                AppTitleBar.Visibility = Visibility.Collapsed;
                UpdateNavMenu(0);
            }
        }
        #endregion

        /// 自定义页面内容上边距
        private void UpdateNavMenu(double appTitleBarHeight)
        {
            var currentMarginTop = MenuButton.Height +appTitleBarHeight;
            MenuListView.Margin = new Thickness(0, currentMarginTop, 0, 0);
           // ContentFrame.Padding = new Thickness(0, currentMarginTop, 0, 0);
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            NavMenu.IsPaneOpen = !NavMenu.IsPaneOpen;
            UpdateAppTitleVisibility();
        }

        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tag = ((MenuItem)((ListView)sender).SelectedItem).Tag;
            if (tag == ContentFrame.CurrentSourcePageType.Name)
            {
                return;
            }
            switch (tag)
            {
                case "HomeView":
                    ContentFrame.Navigate(typeof(HomeView));
                    break;
                case "ArticleView":
                    ContentFrame.Navigate(typeof(ArticleView));
                    break;
                case "AboutView":
                    ContentFrame.Navigate(typeof(AboutView));
                    break;
                default:
                    break;
            }
            if (NavMenu.DisplayMode != SplitViewDisplayMode.CompactInline)
            {
                NavMenu.IsPaneOpen = false;
            }
            UpdateAppTitleVisibility();
        }

        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            var name = ContentFrame.CurrentSourcePageType.Name;
            //To-do
            //Bug：ListView还未初始化
            //switch (name)
            //{
            //    case "HomeView":
            //        break;
            //    case "ArticleView":
            //        MenuListView.SelectedIndex = 2;
            //        break;
            //    case "AboutView":
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
