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
    class PropertyDetails
    {
        private BrowserWindow localbw;
        public PropertyDetails(BrowserWindow bw)
        {
            localbw = bw;
        }

        private HtmlSpan propertyDetailsText;
        public HtmlSpan PropertyDetailsText
        {
            get
            {
                propertyDetailsText = new HtmlSpan(localbw);
                propertyDetailsText.SearchProperties[HtmlSpan.PropertyNames.InnerText] = "Property Details";
                return propertyDetailsText;
            }
        }
    }
}
