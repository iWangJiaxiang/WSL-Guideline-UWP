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
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
