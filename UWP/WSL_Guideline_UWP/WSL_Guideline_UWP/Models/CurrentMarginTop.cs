using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSL_Guideline_UWP.Models
{
    public static class CurrentMarginTop
    {
        private static double marginTop = 0;

        public static double MarginTop
        {
            get { return marginTop; }
            set
            {
                if (marginTop == value)
                    return;
                marginTop = value;
                Change();
            }
        }

        private static bool isDisplayModeOverLay;

        public static bool IsDisplayModeOverLay
        {
            get { return isDisplayModeOverLay; }
            set
            {
                if (isDisplayModeOverLay == value)
                    return;
                isDisplayModeOverLay = value;
                Change();
            }
        }


        public delegate void CurrentMarginTopChanged();

        public static event CurrentMarginTopChanged OnCurrentMarginTopChanged;

        private static void Change()
        {
            if (OnCurrentMarginTopChanged != null)
            {
                OnCurrentMarginTopChanged();
            }
        }
    }
}
