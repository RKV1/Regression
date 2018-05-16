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
    class RelocationScreen
    {
        BrowserWindow localbw;
        public RelocationScreen(BrowserWindow bw)
        {
            localbw = bw;
        }

        private HtmlDiv relocationHeader;
        public HtmlDiv RelocationHeader
        {
            get
            {
                relocationHeader = new HtmlDiv(localbw);
                relocationHeader.SearchProperties[HtmlDiv.PropertyNames.Class] = "d-flex flex-wrap justify-content-between";
                //relocationHeader.SearchProperties[HtmlDiv.PropertyNames.ControlType] = "Pabe";
                //relocationHeader.SearchProperties[HtmlDiv.PropertyNames.ClassName] = "HtmlPane";
                //relocationHeader.SearchProperties[HtmlDiv.PropertyNames.TagInstance] = "14";
                 return relocationHeader;
            }
        }

        private HtmlSpan generalInfoHeader;
        
        public HtmlSpan GeneralInfoHeader
        {
            get
            {
                generalInfoHeader= new HtmlSpan(localbw);
                generalInfoHeader.SearchProperties[HtmlSpan.PropertyNames.InnerText] = "General Info";
                return generalInfoHeader;
            }
        }

        private HtmlButton relocationReportLink;
        public HtmlButton RelocationReportLink
        {
            get
            {
                relocationReportLink = new HtmlButton(localbw);
                relocationReportLink.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "Relocation Report";
                return relocationReportLink;
            }
        }

        

    }
}
