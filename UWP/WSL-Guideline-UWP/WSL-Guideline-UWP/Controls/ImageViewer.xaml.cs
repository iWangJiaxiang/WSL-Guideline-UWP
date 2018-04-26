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

namespace WSL_Guideline_UWP.Controls
{
    public sealed partial class ImageViewer : UserControl
    {
        #region 依赖属性
    
        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { img_ImageViewer.Source = value; SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageViewer), new PropertyMetadata(null));

        #endregion

        public ImageViewer()
        {
            this.InitializeComponent();
            Hide();
        }

        #region 事件
        private void bg_ImageViewer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }

        private void img_ImageViewer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }

        #endregion

        #region UI交互方法

        public void Show()
        {
            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }

        #endregion

    }
}
