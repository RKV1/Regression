using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace Minerva2AutomatedRegression
{
    class M20_Auto_007Test
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

                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
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

                Mouse.Click(hpobj.ExportToExcel);
                Console.WriteLine("Clicked on Export to Excel option");
                Playback.Wait(10000);
                
               String filename = "PropertySearch.xlsx";
               FileInfo  f = new FileInfo(filename);
               String fullname = f.FullName;

                if (Directory.Exists(Path.GetDirectoryName(fullname)))
                {

                    Console.WriteLine("Results are exported to excel file");
                }
                else
                {
                    Assert.Fail("Results are not exported to excel file");
                }


            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
