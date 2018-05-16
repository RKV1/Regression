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

namespace Minerva2AutomatedRegression
{
    class M20_Auto_025Test
    {
        public static void Execute()
        {
            Playback.PlaybackSettings.WaitForReadyTimeout = Configurations.SyncTime;
            Playback.PlaybackSettings.SearchTimeout = Configurations.SyncTime;
            Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.UIThreadOnly;

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
                hpobj.SearchbyAddress.WaitForControlExist(Configurations.SyncTime);
                Console.WriteLine("Search By Address field is displyed. 'Property Search' search criteria is expanded.");
                Mouse.Click(hpobj.PropertySearchLink);
                Console.WriteLine("Clicked on Property Search Link");
               if (hpobj.SearchbyAddress.Width == 0 && hpobj.SearchbyAddress.Height == 0)
                {
                    Console.WriteLine("Search By Address field is not displayed. 'Property Search' search criteria is collapsed.");
                }
                else
                {
                    Assert.Fail("Search By Address field is not displayed. 'Property Search' search criteria is not collapsed.");
                }

                
                Mouse.Click(hpobj.PropertySearchLink);
                if (hpobj.PropertyType.Height ==0 && hpobj.PropertyType.Width == 0)
                {
                    Console.WriteLine("Property Type label is not displayed. 'Detailed Search' search criteria is collapsed");
                }else
                {
                    Assert.Fail("Property Type label is displayed. 'Detailed Search' search criteria is not collapsed");
                }
                
                Mouse.Click(hpobj.DetaieldSearchLink);
                Console.WriteLine("Clicked on Detailed Search Link");
                hpobj.PropertyType.WaitForControlExist(Configurations.SyncTime);
                Console.WriteLine("Property Type Label is displayed. 'Detailed Search' search criteria is expanded");
            }
            catch (Exception)
            {

                throw;
            }

           

        }
    }
}
