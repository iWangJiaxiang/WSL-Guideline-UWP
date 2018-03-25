using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WSL_Guideline_UWP.Models;

namespace WSL_Guideline_UWP.ViewModels
{
    public class ArticleViewModel
    {
        private ObservableCollection<Article> articles;

        public ObservableCollection<Article> Articles
        {
            get { return articles; }
        }

        public ArticleViewModel()
        {
            articles = new ObservableCollection<Article>();
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
