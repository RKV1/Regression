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
    class Login
    {

        public static  void LoginToApplication(BrowserWindow bw,String Usernamevalue, String Passwordvalue)
        {
            LoginScreen loginscreenobj = new LoginScreen(bw);
            //Enter Username
            for (int i=0; i< Configurations.SyncTime; i++)
            {
                try
                {
                    loginscreenobj.UserName.Text = Usernamevalue;
                    Console.WriteLine("Entered username as " + Usernamevalue);
                    break;

                }
                catch (Exception)
                {

                    Playback.Wait(1000);
                }
            }

            //Enter Password
            for (int i = 0; i < Configurations.SyncTime; i++)
            {
                try
                {
                    loginscreenobj.Password.Text = Usernamevalue;
                    Console.WriteLine("Entered password");
                    break;

                }
                catch (Exception)
                {

                    Playback.Wait(1000);
                }
            }
            //Click on Login button

            for (int i = 0; i < Configurations.SyncTime; i++)
            {
                try
                {
                    Mouse.Click(loginscreenobj.LoginButton);
                    Console.WriteLine("Clicked on Login button");
                    break;

                }
                catch (Exception)
                {

                    Playback.Wait(1000);
                }
            }
        }
    }
}
