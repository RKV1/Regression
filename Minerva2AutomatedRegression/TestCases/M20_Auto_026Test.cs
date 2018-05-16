using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;

namespace Minerva2AutomatedRegression
{
    class M20_Auto_026Test
    {
        public static void Execute()
        {
            //Playback settings
            Playback.PlaybackSettings.WaitForReadyTimeout = Configurations.SyncTime;
            Playback.PlaybackSettings.SearchTimeout = Configurations.SyncTime;
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.UIThreadOnly;
            

            BrowserWindow.CurrentBrowser = Configurations.BrowserName;
            BrowserWindow TC_002_bw = BrowserWindow.Launch(new Uri(Configurations.MainUrl));
            TC_002_bw.Maximized = true;

            LoginScreen lsobj = new LoginScreen(TC_002_bw);
            HomePage hpobj = new HomePage(TC_002_bw);
            PropertyDetails pdobj = new PropertyDetails(TC_002_bw);


            try
            {
                lsobj.UserName.WaitForControlExist(Configurations.SyncTime);
                Login.LoginToApplication(TC_002_bw, LoginCredentials.UserName, LoginCredentials.Password);
                /*lsobj.UserName.Text = LoginCredentials.UserName;
                Console.WriteLine("Entered username as " + LoginCredentials.UserName);
                lsobj.Password.Text = LoginCredentials.Password;
                Console.WriteLine("Entered password");
                Mouse.Click(lsobj.LoginButton);
                
                Console.WriteLine("Clicked on Login button");
                */
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
                var value1 = "33955";
                Keyboard.SendKeys(value1);
                Console.WriteLine("Entered Property ID as " + value1);

                Mouse.Click(hpobj.SearchButton);
                Console.WriteLine("Clicked on Search Button");

                /* for(int i=0; i<Configurations.SyncTime; i++)
                 {
                     try
                     {
                         var documentStatus = TC_002_bw.ExecuteScript("var myState = document.readyState; return myState;");
                         if (documentStatus.ToString() == "complete")
                         {
                             break;
                         }
                         else { Playback.Wait(1000); }
                     }
                     catch (Exception)
                     {

                         throw;
                     }
                 }
                 */
                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;

               
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
                    Mouse.Click(hpobj.AddressHyperLink);
                    pdobj.PropertyDetailsText.WaitForControlExist(Configurations.SyncTime);
                    if (pdobj.PropertyDetailsText.Exists)
                    {
                        Console.WriteLine("Property Details Page is displayed");
                    }else {
                        Assert.Fail("Property Details page is not displayed");
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



        }
    }
}
