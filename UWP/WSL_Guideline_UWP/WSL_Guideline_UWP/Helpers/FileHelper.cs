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


        public async Task<string> FormatStringAsync(string input)
        {
            string patternPrefix = @"(&emsp;&emsp;<img)(.*?src=""..)";
            string patternSuffix = @""">";

            input = Regex.Replace(input, patternPrefix, @"!\[\]\(ms-appx:///ArticleData/WSL-Guideline");
            input = Regex.Replace(input, patternSuffix, @"\)");

            return input;
        }

    }
}
