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
    /// ImageViewer控件可在整个Page范围内展示图片，类似“知乎UWP”查看图片细节的控件
    /// </summary>
    public sealed partial class ImageViewer : Control
    {
        #region Field

        private Image _img;
        private Grid _bg;

        #endregion

        #region DependencyProperty

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(ImageSource), typeof(ImageViewer), new PropertyMetadata(null));

        #endregion

        public ImageViewer()
        {
            this.DefaultStyleKey = typeof(ImageViewer);
            OnApplyTemplate();
        }

        protected override void OnApplyTemplate()
        {
            _img = (Image)GetTemplateChild("MainImage");
            _bg = (Grid)GetTemplateChild("BackgroundGrid");

            if (_img != null)
            {
                _img.Tapped += _img_Tapped;
                _img.PointerWheelChanged += _img_PointerWheelChanged;
                _img.RightTapped += _img_RightTapped;
                _img.SizeChanged += _img_SizeChanged;
            }
            if (_bg != null)
            {
                _bg.Tapped += _bg_Tapped;
            }

            base.OnApplyTemplate();
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;
            if (_img != null)
            {
                //AjustImageSize();
            }
        }

        /// <summary>
        /// 调整图片显示大小为当前控价大小的60%（以图片长宽中数值最大的数为基准计算）
        /// </summary>
        private void AjustImageSize()
        {
            double height = _img.ActualHeight;
            double width = _img.ActualWidth;
            if (height >= width)
            {
                _img.Height = 0.6 * this.ActualHeight;
            }
            else
            {
                _img.Width = 0.6 * this.ActualWidth;
            }
        }

        public void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
