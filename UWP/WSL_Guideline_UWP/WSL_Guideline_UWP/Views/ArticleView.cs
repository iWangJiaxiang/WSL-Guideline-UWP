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
using WSL_Guideline_UWP.Models;
using System.Collections.ObjectModel;
using Windows.Storage;
using WSL_Guideline_UWP.ViewModels;
namespace WSL_Guideline_UWP.Views
{
    /// <summary>
    /// 文章页面
    /// </summary>
    public sealed partial class ArticleView : Page
    {
        private ArticleViewModel ViewModel;
        public ArticleView()
        {
            this.InitializeComponent();

            ViewModel = new ArticleViewModel();
        }
    }
}
