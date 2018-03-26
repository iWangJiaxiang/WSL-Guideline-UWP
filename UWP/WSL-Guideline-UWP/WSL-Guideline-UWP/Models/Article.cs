using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
namespace WSL_Guideline_UWP.Models
{
    public class Article : ObservableObject 
    {
        public Article()
        {
        }

        public Article(string name, string content)
        {
            Name = name;
            Content = content;
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
                RaisePropertyChanged();
            }
        }

    }
}
