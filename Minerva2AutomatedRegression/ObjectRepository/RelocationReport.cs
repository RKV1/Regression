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
    class RelocationReport
    {
        BrowserWindow localbw;

        public RelocationReport  (BrowserWindow bw)
         {
            localbw = bw;

         }

        private HtmlDiv relocationReportText;
        public HtmlDiv RelocationReportText
        {
            get
            {
                relocationReportText = new HtmlDiv(localbw);
                RelocationReportText.SearchProperties[HtmlDiv.PropertyNames.DisplayText] = "Relocation Report";
                return relocationReportText;
            }
        }


    }
}
