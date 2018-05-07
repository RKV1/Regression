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
    class M20_Auto_003_005Test
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
                lsobj.UserName.Text = LoginCredentials.UserName;
                Console.WriteLine("Entered username as " + LoginCredentials.UserName);
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
                hpobj.PropertySearchLink.WaitForControlExist(Configurations.SyncTime);
                Console.WriteLine("Property Search Link is displayed");
            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                hpobj.SearchbyAddress.WaitForControlExist(Configurations.SyncTime);
                Mouse.Click(hpobj.City);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_003_005_CityValue);
                Console.WriteLine("Entered City as " + TestData.M20_Auto_003_005_CityValue);

                Mouse.Click(hpobj.State);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_003_005_StateValue);
                Console.WriteLine("Entered State as " + TestData.M20_Auto_003_005_StateValue);

                Mouse.Click(hpobj.Zip);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_003_005_ZipValue);
                Console.WriteLine("Entered Zipcode as " + TestData.M20_Auto_003_005_ZipValue);

                Mouse.Click(hpobj.County);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_003_005_CountyValue);
                Console.WriteLine("Entered County as " + TestData.M20_Auto_003_005_CountyValue);

                Mouse.Click(hpobj.PropertyId);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_003_005_PropertyIdValue);
                Console.WriteLine("Entered Property ID as " + TestData.M20_Auto_003_005_PropertyIdValue);

                Mouse.Click(hpobj.SearchButton);
                Console.WriteLine("Clicked on Search Button");

                try
                {
                    hpobj.PaginationText.WaitForControlExist(Configurations.SyncTime);
                    int RecordCount = Int32.Parse(hpobj.PaginationText.InnerText.Trim().Split('-')[0]);
                    if (RecordCount == 1)
                    {
                        Console.WriteLine("Record is displayed");
                    }
                    if (RecordCount == 0)
                    {
                        Assert.Fail("Search did not display any records");
                    }
                   
                }
                catch (Exception)
                {

                    throw;
                }

            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                Mouse.Click(hpobj.ClearSearchButton);
                Console.WriteLine("Clicked on Clear Search button");
                Playback.Wait(2000);
                int RecordCount = Int32.Parse(hpobj.PaginationText.InnerText.Trim().Split('-')[0]);
                if (RecordCount == 1)
                {
                    Assert.Fail("Clicking on Clear Search button did not clear the results");
                }
                if (RecordCount == 0)
                {
                    Console.WriteLine("Clicking on Clear Search button has cleared the results");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
