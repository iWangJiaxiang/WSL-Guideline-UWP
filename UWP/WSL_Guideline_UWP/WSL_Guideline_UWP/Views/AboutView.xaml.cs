using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WSL_Guideline_UWP.Models;
namespace WSL_Guideline_UWP.Views
{
    public sealed partial class AboutView : Page
    {
        public AboutView()
        {
            this.InitializeComponent();
            string appVersion = string.Format("Version: {0}.{1}.{2}.{3}",
                    Package.Current.Id.Version.Major,
                    Package.Current.Id.Version.Minor,
                    Package.Current.Id.Version.Build,
                    Package.Current.Id.Version.Revision);
            AppVersion.Text = appVersion;
            CurrentMarginTop.OnCurrentMarginTopChanged += CurrentMarginTop_OnCurrentMarginTopChanged;
            CurrentMarginTop_OnCurrentMarginTopChanged();
        }

        private void CurrentMarginTop_OnCurrentMarginTopChanged()
        {
            RootGrid.Padding = new Thickness(0, CurrentMarginTop.MarginTop, 0, 0);
        }
    }
}
