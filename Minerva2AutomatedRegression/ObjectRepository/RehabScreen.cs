using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minerva2AutomatedRegression
{
    class RehabScreen
    {
        BrowserWindow localbw;
        public RehabScreen(BrowserWindow bw)
        {
            localbw = bw;
        }

        private HtmlSpan majorSystemsHeading;
        public HtmlSpan MajorSystemsHeading
        {
            get
            {
                majorSystemsHeading = new HtmlSpan(localbw);
                majorSystemsHeading.SearchProperties[HtmlSpan.PropertyNames.InnerText] = "Major Systems";
                return majorSystemsHeading;
            }
        }

        private HtmlDiv headerSection;
        public HtmlDiv HeaderSection
        {
            get
            {
                headerSection = new HtmlDiv(localbw);
                headerSection.SearchProperties[HtmlDiv.PropertyNames.Class] = "d-flex flex-wrap justify-content-between";
                return headerSection;
            }
        }
    }
}
