using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


namespace Minerva2AutomatedRegression
{
    class TestInitiate
    {
        public static BrowserWindow OpenBrowser(string BrowserName)
        {
            BrowserWindow.CurrentBrowser = BrowserName;
            BrowserWindow bw = BrowserWindow.Launch(new Uri(Configurations.MainUrl));
            bw.Maximized = true;
            return bw;
        }
    }
}
