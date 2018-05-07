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
    class M20_Auto_006Test
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
                hpobj.DetaieldSearchLink.WaitForControlExist(Configurations.SyncTime);
                Console.WriteLine("Detailed Search Link is displayed");
                Mouse.Click(hpobj.DetaieldSearchLink);
                Console.WriteLine("Clicked on Detailed Search Link to expand");

            }
            catch (Exception)
            {

                throw;
            }

            try
            {
                hpobj.PropertyType.WaitForControlExist(Configurations.SyncTime);
                Mouse.Click(hpobj.PropertyType);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_004_005_PropertyTypeValue);
                Console.WriteLine("Entered Property Type as " + TestData.M20_Auto_004_005_PropertyTypeValue);

                Mouse.Click(hpobj.PropertyPhase);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_004_005_PropertyPhaseValue);
                Console.WriteLine("Entered Property Phase as " + TestData.M20_Auto_004_005_PropertyPhaseValue);

                Mouse.Click(hpobj.PropertyStatus);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_004_005_PropertyStatusValue);
                Console.WriteLine("Entered Property Status as " + TestData.M20_Auto_004_005_PropertyStatusValue);

                Mouse.Click(hpobj.AssetType);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_004_005_AssetTypeValue);
                Console.WriteLine("Entered Asset Type as " + TestData.M20_Auto_004_005_AssetTypeValue);

                Mouse.Click(hpobj.SearchButton);
                Playback.Wait(5000);
                Console.WriteLine("Clicked on Search Button");

                Mouse.Click(hpobj.PropertyPhase);
                Playback.Wait(500);
                Keyboard.SendKeys("^{END}");



                int RecordCount = Int32.Parse(hpobj.PaginationText.InnerText.Trim().Split('-')[0].Trim());
                if (RecordCount == 0)
                {
                    Assert.Fail("Clicking on Search button did not display any records");
                }
                if (RecordCount == 1)
                {
                    Console.WriteLine("Clicking on Search button has displayed records");
                }

                String value1 = hpobj.PaginationText.InnerText.Trim();
                String value2 = value1.Split(new string[] { "of" }, StringSplitOptions.None)[0].Trim();
                int itemsperpage = Int32.Parse(value2.Split('-')[1].Trim());
                String value3 = value1.Split(new string[] { "of" }, StringSplitOptions.None)[1].Trim();
                value3 = value3.Split(new string[] { "items" }, StringSplitOptions.None)[0].Trim();
                int totalcount = Int32.Parse(value3);
                int totalpages;
                if (totalcount % itemsperpage == 0)
                {
                    totalpages = totalcount / itemsperpage;
                }
                else
                {
                    totalpages = (totalcount / itemsperpage) + 1;
                }
                Mouse.Click(hpobj.LastPageArrow);
                Console.WriteLine("Clicked on last page image");
                if (hpobj.PageSelected.InnerText.Trim() == totalpages.ToString())
                {
                    Console.WriteLine("Page no." + totalpages.ToString() + " was selected as expected");
                }
                else
                {
                    Console.WriteLine("Expected Page to be displayed: " + totalpages.ToString());
                    Console.WriteLine("Actual Page displayed: " + hpobj.PageSelected.InnerText.Trim());
                    Assert.Fail("Pagination is not working properly");
                }







            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
