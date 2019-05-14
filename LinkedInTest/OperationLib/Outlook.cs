using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using System.Diagnostics;


namespace LinkedInTest.OperationLib
{
    public struct OutlookFlag {}
    public class Outlook : CommonOperation<OutlookFlag>
    {
        public static Outlook Open()
        {
            var o = new Outlook();
            var k = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software\\microsoft\\windows\\currentversion\\app paths\\OUTLOOK.EXE");
            var path = (string)k.GetValue("Path");
            if (path != null)
            {
                Process.Start("EXCEL.EXE");
            }
            else
            {
                throw new Exception("This PC may not install Outlook, or you can use another way to locate it");
            }
            Thread.Sleep(3000);

            // Find desktop
            var desktopCapabilities = new DesiredCapabilities();
            desktopCapabilities.SetCapability("app", "Root");
            var desktopSession =
                new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), desktopCapabilities);

            // Use desktop to find opened app
            Thread.Sleep(2000);
            var excelWindow = desktopSession.FindElementByClassName("XLMAIN");
            var excelTopLevelWindowHandle = excelWindow.GetAttribute("NativeWindowHandle");
            excelTopLevelWindowHandle = (int.Parse(excelTopLevelWindowHandle)).ToString("x"); // Convert to Hex
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("appTopLevelWindow", excelTopLevelWindowHandle);
            Session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Session.Manage().Window.Maximize();
            // Open application
            Session.FindElementByName("Blank workbook").Click();
            Thread.Sleep(2000);
            return o;
            // 父类如何返回子类的类型
        }

        // 利用扩展方法解决这个问题？

        //private new CommonOperation<OutlookFlag> AddAuthor()
        //{
        //    // 在父类中，如何判断调用类型
        //    throw new Exception("Outlook don't have this function, please change code");
        //}
    }
}
