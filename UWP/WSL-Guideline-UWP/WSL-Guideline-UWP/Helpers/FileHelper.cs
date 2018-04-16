using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using System.Text.RegularExpressions;

namespace WSL_Guideline_UWP.Helpers
{
    public class FileHelper
    {
        private List<StorageFile> Files = new List<StorageFile>();
        private StorageFolder InstallLocation;

        public FileHelper()
        {
            InstallLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;
        }

        public async Task<List<StorageFile>> ScanFilesAsync(StorageFolder folder)
        {
            await RecursiveScanningAsync(folder);
            return Files;
        }
        public async Task<List<StorageFile>> ScanFilesAsync(string folderPath)
        {
            return await ScanFilesAsync(await StorageFolder.GetFolderFromPathAsync(InstallLocation.Path + folderPath));
        }

        private async Task RecursiveScanningAsync(StorageFolder folder)
        {
            foreach (var file in await folder.GetFilesAsync())
            {
                Files.Add(file);
            }
            foreach (var subFolder in await folder.GetFoldersAsync())
            {
                await RecursiveScanningAsync(subFolder);
            }
        }

        public async Task<string> ReadFileToStringAsync(StorageFile file)
        {
            using (StreamReader reader = new StreamReader(await file.OpenStreamForReadAsync()))
            {
                return await reader.ReadToEndAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">项目根目录开始的相对路径</param>
        /// <returns></returns>
        public async Task<string> ReadFileToStringAsync(string filePath)
        {
            return await ReadFileToStringAsync(await StorageFile.GetFileFromPathAsync(InstallLocation.Path + filePath));
        }


        public string FormatString(string input,string fileName)
        {
            string patternPrefix = @"(&emsp;&emsp;<img)(.*?src=""..)";
            string patternSuffix = @""">";

            input = Regex.Replace(input, patternPrefix, "![](ms-appx:/ArticleData/WSL-Guideline");
            input = Regex.Replace(input, patternSuffix, ")\r\n\r\n");

            //测试是否图片能显示，测试通过则注释掉，以下均通过测试
            //input += @"\n\n![](ms-appx:/ArticleData/WSL-Guideline/images/02-安装配置/control-panel.png)";
            //input += "\n\n![](ms-appx:/ArticleData/WSL-Guideline/images/02-安装配置/control-panel.png)";
            //input += "\n\n![](https://raw.githubusercontent.com/WangJiaxiang96/WSL-Guideline/master/WSL-Guideline/images/02-安装配置/open-powershell.png)";
            return input;
        }

    }
}
