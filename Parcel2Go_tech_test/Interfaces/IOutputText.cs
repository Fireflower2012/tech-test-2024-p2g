using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcel2Go_tech_test
{
    internal interface IOutputText
    {
        static abstract void DisplayIntroText();
        static abstract void DisplayExitText();
        static abstract void DisplayServiceList();
        static abstract void DisplayRunningTotal(decimal price);
        static abstract void DisplayInvalidServiceText();
        static abstract void DisplayBasketSummaryText(Dictionary<string, int> summary);
    }
}
