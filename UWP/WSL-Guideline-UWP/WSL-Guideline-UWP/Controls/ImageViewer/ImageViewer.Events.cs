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

        /// <summary>
        /// 根据缩放比例判断图片是否能被拖动
        /// </summary>
        private void _img_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            return;
            //判断图片长宽中数值最大者
            if (_img.ActualHeight >= _img.ActualWidth)
            {
                if(_img.ActualHeight* _zoom.ZoomFactor > this.ActualHeight)
                {
                    _img.CanDrag = true;
                }
                else
                {
                    _img.CanDrag = false;
                }
            }
            else
            {
                if(_img.ActualWidth* _zoom.ZoomFactor > this.ActualWidth)
                {
                    _img.CanDrag = true;
                }
                else
                {
                    _img.CanDrag = false;
                }
            }
        }

        /// <summary>
        /// 如果图片缩放不等于100%，则恢复图片默认缩放
        /// 如果等于100%，则隐藏ImageViewer
        /// </summary>
        private void _img_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (_zoom.ZoomFactor != 1)
            {
                _zoom.ChangeView(null, null, 1);
            }
            else
            {
                Hide();
            }
        }

        private void _img_Tapped(object sender, TappedRoutedEventArgs e)
        {
            //Hide();
            //处理Handled防止继续触发上一层_zoom_Tapped事件
            e.Handled = true;
        }

        private void _zoom_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Hide();
        }

        private void _img_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AjustImageSize();
        }

    }
}