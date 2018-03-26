using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSL_Guideline_UWP.Models;
namespace WSL_Guideline_UWP.ViewModels
{
    public class MenuItemViewModel
    {
        private ObservableCollection<MenuItem> menuItems;

        public ObservableCollection<MenuItem> MenuItems
        {
            get { return menuItems; }
        }

        public MenuItemViewModel()
        {
            menuItems = new ObservableCollection<MenuItem>();
            var resourceLoader = Windows.ApplicationModel.Resources.ResourceLoader.GetForCurrentView();

            menuItems.Add(new MenuItem("Segoe MDL2 Assets", "\xE10F", resourceLoader.GetString("MenuItem_Home"),"HomeView"));

            menuItems.Add(new MenuItem("Segoe MDL2 Assets", "\xE81E", resourceLoader.GetString("MenuItem_Article"), "ArticleView"));

            menuItems.Add(new MenuItem("Segoe MDL2 Assets", "\xEB95", resourceLoader.GetString("MenuItem_About"), "AboutView"));
        }

    }
}
