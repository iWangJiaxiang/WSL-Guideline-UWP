using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WSL_Guideline_UWP.Models;
using WSL_Guideline_UWP.Helpers;
using GalaSoft.MvvmLight;

namespace WSL_Guideline_UWP.ViewModels
{
    public class ArticleViewModel: ViewModelBase
    {
        private Article articleOne;

        public Article ArticleOne
        {
            get { return articleOne; }
            set { articleOne = value; }
        }

        public ArticleViewModel()
        {
            articleOne = new Article();
        }

        public async void LoadModelAsync(string filePath)
        {
            FileHelper fileHelper = new FileHelper();

            string temp = await fileHelper.ReadFileToStringAsync(filePath);
            temp = fileHelper.FormatString(temp,"");

            ArticleOne.Name = filePath;
            ArticleOne.Content = temp;
        }

    }
}
