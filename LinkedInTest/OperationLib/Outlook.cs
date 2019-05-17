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
            const string excelAppId = "OUTLOOK.EXE";
            OpenHelper(excelAppId);

            return new Outlook();
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
