using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using WSL_Guideline_UWP.Models;
using WSL_Guideline_UWP.Helpers;

namespace WSL_Guideline_UWP.ViewModels
{
    public class ArticlesViewModel
    {
        private ObservableCollection<Article> articles;

        public ObservableCollection<Article> Articles
        {
            get { return articles; }
            set { articles = value; }
        }

        public ArticlesViewModel()
        {
            articles = new ObservableCollection<Article>();
        }

        public async Task LoadModelsAsync(string folderPath)
        {
            FileHelper fileHelper = new FileHelper();

            //string articleRootPath = @"ms-appx:///ArticleData/WSL-Guideline/中文/";
            StorageFolder installPath = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFolder articleRootFolder = await StorageFolder.GetFolderFromPathAsync(installPath.Path + @"\ArticleData\WSL-Guideline\中文");


            var files = await fileHelper.ScanFilesAsync(folderPath);

            string temp;

            foreach (var file in files)
            {
                temp = await fileHelper.ReadFileToStringAsync(file);
                temp = await fileHelper.FormatStringAsync(temp);

                Articles.Add(new Article(file.DisplayName, temp));
            }
        }

    }
}
