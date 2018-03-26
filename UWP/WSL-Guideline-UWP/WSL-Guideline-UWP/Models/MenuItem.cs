using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace WSL_Guideline_UWP.Models
{
    public class MenuItem : ObservableObject
    {
        public MenuItem(string iconFontFamilly, string iconContent, string menuContent ,string tag)
        {
            IconFontFamilly = iconFontFamilly;
            IconContent = iconContent;
            MenuContent = menuContent;
            Tag = tag;
        }

        public string IconFontFamilly { get; set; }

        public string IconContent { get; set; }

        public string MenuContent { get; set; }

        public string Tag { get; set; }
    }
}
