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
    class M20_Auto_021Test
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
            RelocationScreen rlsobj = new RelocationScreen(TC_002_bw);
           

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

                TestData.M20_Auto_004_005_PropertyPhaseValue = "Relocation";
                Mouse.Click(hpobj.PropertyPhase);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_004_005_PropertyPhaseValue);
                Console.WriteLine("Entered Property Phase as " + TestData.M20_Auto_004_005_PropertyPhaseValue);


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
            }
            catch (Exception)
            {
                throw;
            }


            //hpobj.RelocationPhaseCellLink.WaitForControlExist(Configurations.SyncTime);
            try
            {

                var pid = hpobj.PIDTableCell.InnerText.Trim();
                Mouse.Click(hpobj.RelocationPhaseCellLink);
                Console.WriteLine("Clicked on FIrst Relocation link");
                Keyboard.SendKeys("^{END}");
                rlsobj.RelocationHeader.WaitForControlExist(Configurations.SyncTime);
                Console.WriteLine("Relocation Page is displayed");
                if (rlsobj.RelocationReportLink.Exists)
                {
                    Console.WriteLine("Relocation Report link is displayed");
                }
                else
                {
                    Assert.Fail("Relocation Report link is displayed");
                }
                Mouse.Click(rlsobj.RelocationReportLink);
                Console.WriteLine("Clicked on Relocation Report Link");

                //rlrobj.RelocationReportText.WaitForControlExist(Configurations.SyncTime);
                //Playback.Wait(90000);

                BrowserWindow bw1= new BrowserWindow();
                RelocationReport rlrobj = new RelocationReport(bw1);
                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;

                HtmlDiv RelocationReportText = new HtmlDiv(bw1);
                RelocationReportText.SearchProperties[HtmlDiv.PropertyNames.InnerText] = "Relocation Report";

                Playback.Wait(60000);
                RelocationReportText.WaitForControlReady(Configurations.SyncTime);
                
                Mouse.Click(RelocationReportText);
                /*if (RelocationReportText.Exists)
                {
                    Console.WriteLine("Relocation Report is displayed");
                }
                else
                {
                    Assert.Fail("Relocation Report is not displayed");
                }*/



            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
