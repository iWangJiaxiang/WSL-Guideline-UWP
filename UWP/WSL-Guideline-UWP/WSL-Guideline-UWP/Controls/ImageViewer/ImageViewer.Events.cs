using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace WSL_Guideline_UWP.Controls
{
    /// <summary>
    /// ImageViewer控件的事件处理
    /// </summary>
    public sealed partial class ImageViewer
    {
        private void _img_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            // Todo:增加图片另存为功能
        }

        private void _img_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            // Todo:鼠标滚路控制图片缩放
        }

        private void _bg_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }

        private void _img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }

        private void _img_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AjustImageSize();
        }

    }
}