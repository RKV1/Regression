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
    class M20_Auto_001Test
    {
        public static void Execute()
        {
            Playback.PlaybackSettings.WaitForReadyTimeout = Configurations.SyncTime;
            Playback.PlaybackSettings.SearchTimeout = Configurations.SyncTime;

            BrowserWindow.CurrentBrowser = Configurations.BrowserName;
            BrowserWindow TC_001_bw = BrowserWindow.Launch(new Uri(Configurations.MainUrl));
            TC_001_bw.Maximized = true;

            LoginScreen lsobj = new LoginScreen(TC_001_bw);

            try
            {
                lsobj.UserName.WaitForControlExist(Configurations.SyncTime);
                lsobj.UserName.Text = LoginCredentials.InvalidUserName;
                Console.WriteLine("Entered username as " + LoginCredentials.InvalidUserName);
                lsobj.Password.Text = LoginCredentials.Password;
                Console.WriteLine("Entered password");
                Mouse.Click(lsobj.LoginButton);
                Console.WriteLine("Clicked on Login button");
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                lsobj.InvalidLoginErrorTextMsg.WaitForControlExist(Configurations.SyncTime);
                String ExpMsg = "Incorrect user ID or password. Type the correct user ID and password, and try again.";
                String ActMsg = lsobj.InvalidLoginErrorTextMsg.InnerText.Trim();
                if (ExpMsg == ActMsg)
                {
                    Console.WriteLine("Values matched");
                    Console.WriteLine("Expected Value: " + ExpMsg);
                    Console.WriteLine("Actual value: " + ActMsg);
                }
                else
                {
                    Console.WriteLine("Expected Value: " + ExpMsg);
                    Console.WriteLine("Actual value: " + ActMsg);
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
