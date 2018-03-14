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

namespace WSL_Guideline_UWP
{
    public sealed partial class MainPage : Page
    {
        //MVVM绑定文章
        ObservableCollection<Article> Articles = new ObservableCollection<Article>();

        public MainPage()
        {
            this.InitializeComponent();
            string localpic = ApplicationData.Current.LocalFolder.Path + "\\2.png";
            #region 给List赋值
            Articles.Add(new Article()
            {
                Name = "Article1",
                Content = @"# WSL 使用指南

### 01 WSL入门

#### 什么是WSL

![test](/Assets/StoreLogo.png)

&emsp;&emsp; WSL是“Windows Subsystem for Linux”的缩写，顾名思义，WSL就是Windows系统的Linux子系统，其作为Windows组件搭载在Windows10周年更新（1607）后的Windows系统中。 "
            });
            Articles[0].Content = Articles[0].Content.Replace("/Assets/StoreLogo.png", localpic);
            Articles.Add(new Article()
            {
                Name = "Article2",
                Content = Articles[0].Content
            });
            Articles.Add(new Article()
            {
                Name = "Article2",
                Content = Articles[0].Content
            });
            #endregion
        }

    }
}
