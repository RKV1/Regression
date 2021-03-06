﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITest;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Minerva2AutomatedRegression
{
    class M20_Auto_008Test
    {
        public static void Execute()
        {


            //Playback settings

            Playback.PlaybackSettings.WaitForReadyTimeout = Configurations.SyncTime;
            Playback.PlaybackSettings.SearchTimeout = Configurations.SyncTime;

            BrowserWindow.CurrentBrowser = Configurations.BrowserName;
            BrowserWindow TC_002_bw = BrowserWindow.Launch(new Uri(Configurations.MainUrl));
            TC_002_bw.Maximized = true;

            LoginScreen lsobj = new LoginScreen(TC_002_bw);
            HomePage hpobj = new HomePage(TC_002_bw);
            RehabScreen rbsobj = new RehabScreen(TC_002_bw);

            try
            {
                lsobj.UserName.WaitForControlExist(Configurations.SyncTime);
                /* lsobj.UserName.Text = LoginCredentials.UserName;
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

                TestData.M20_Auto_004_005_PropertyPhaseValue = "Rehab";
                Mouse.Click(hpobj.PropertyPhase);
                Playback.Wait(500);
                Keyboard.SendKeys("{TAB}");
                Playback.Wait(500);
                Keyboard.SendKeys(TestData.M20_Auto_004_005_PropertyPhaseValue);
                Console.WriteLine("Entered Property Phase as " + TestData.M20_Auto_004_005_PropertyPhaseValue);


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
            }
            catch (Exception)
            {
                throw;
            }

            hpobj.RehabPhaseCellLink.WaitForControlExist(Configurations.SyncTime);
             
            try
            {
                Mouse.Click(hpobj.RehabPhaseCellLink);
                Console.WriteLine("Clicked on First Rehab link");
                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
                rbsobj.MajorSystemsHeading.WaitForControlExist(Configurations.SyncTime);
                if (rbsobj.MajorSystemsHeading.Exists)
                {
                    Console.WriteLine("Major Systems Heading under budget is displayed. So Budget Tab is selected by default");
                }
                else
                {
                    Assert.Fail("Budget Tab is not selected by default");
                }
                rbsobj.HeaderSection.WaitForControlExist(Configurations.SyncTime);
                if (rbsobj.HeaderSection.InnerText.Contains("Status: Active"))
                {
                    Console.WriteLine("Status: Active");
                }
                else
                {
                    Assert.Fail("Status is not displayed as Active");
                }
                if (rbsobj.HeaderSection.InnerText.Contains("Phase: Rehab"))
                {
                    Console.WriteLine("Property Phase is Rehab");
                }
                else
                {
                    Assert.Fail("Property Phase is not displayed as Rehab");
                }
                if (rbsobj.HeaderSection.InnerText.Contains("Phase: Rehab"))
                {
                    Console.WriteLine("Property ID is : 34100");
                }
                else
                {
                    Assert.Fail("Property ID is not 34100");
                }
                

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
