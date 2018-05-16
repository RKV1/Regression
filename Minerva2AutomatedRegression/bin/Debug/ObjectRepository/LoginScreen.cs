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
    class LoginScreen
    {
        BrowserWindow localbw;

        public LoginScreen(BrowserWindow bw)
        {
            localbw = bw;
        }





        private HtmlEdit usernamefield;
        private  HtmlEdit passwordfield;
        private  HtmlSpan loginbuttonfield;
        private  HtmlLabel invalidloginerrortextmsg;
        

        public  HtmlEdit UserName { get{ usernamefield = new HtmlEdit(localbw); usernamefield.SearchProperties[HtmlEdit.PropertyNames.Name] = "UserName"; return usernamefield;}}
        public  HtmlEdit Password { get { passwordfield = new HtmlEdit(localbw); passwordfield.SearchProperties[HtmlEdit.PropertyNames.Name] = "Password"; return passwordfield; } }
        public  HtmlSpan LoginButton { get { loginbuttonfield = new HtmlSpan(localbw); loginbuttonfield.SearchProperties[HtmlSpan.PropertyNames.Id] = "submitButton"; return loginbuttonfield; } }
        public  HtmlLabel InvalidLoginErrorTextMsg { get { invalidloginerrortextmsg = new HtmlLabel(localbw); invalidloginerrortextmsg.SearchProperties[HtmlLabel.PropertyNames.Id] = "errorText"; return invalidloginerrortextmsg; } }
    }
}
