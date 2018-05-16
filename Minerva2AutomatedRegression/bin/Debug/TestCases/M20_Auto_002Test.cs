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
    class M20_Auto_002Test
    {
        public static void Execute()
        {
            Playback.PlaybackSettings.WaitForReadyTimeout = Configurations.SyncTime;
            Playback.PlaybackSettings.SearchTimeout = Configurations.SyncTime;

            BrowserWindow.CurrentBrowser = Configurations.BrowserName;
            BrowserWindow TC_002_bw = BrowserWindow.Launch(new Uri(Configurations.MainUrl));
            TC_002_bw.Maximized = true;

            LoginScreen lsobj = new LoginScreen(TC_002_bw);
            HomePage hpobj = new HomePage(TC_002_bw);

            try
            {
                lsobj.UserName.WaitForControlExist(Configurations.SyncTime);
                /*lsobj.UserName.Text = LoginCredentials.UserName;
                Console.WriteLine("Entered username as " + LoginCredentials.UserName);
                lsobj.Password.Text = LoginCredentials.Password;
                Console.WriteLine("Entered password");
                Mouse.Click(lsobj.LoginButton);
                Console.WriteLine("Clicked on Login button");
                */
                Login.LoginToApplication(TC_002_bw, LoginCredentials.UserName, LoginCredentials.Password);
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                hpobj.PropertySearchLink.WaitForControlExist(Configurations.SyncTime);
                Console.WriteLine("Property Search Link is displayed");
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                string ExpMsg = "RAVI VALLEPU";
                string ActMsg = hpobj.Loggedinusername.InnerText.Trim();
                if (ExpMsg == ActMsg)
                {
                    Console.WriteLine("Values matched");
                    Console.WriteLine("Expected Message: " + ExpMsg);
                    Console.WriteLine("Actual Message: " + ActMsg);
                }
                else
                {
                    Console.WriteLine("Expected Message: " + ExpMsg);
                    Console.WriteLine("Actual Message: " + ActMsg);
                    Assert.Fail("Values did not match");
                }


            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
