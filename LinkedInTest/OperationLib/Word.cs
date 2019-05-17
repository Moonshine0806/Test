using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;

namespace LinkedInTest.OperationLib
{
    public struct WordFlag {}
    public class Word : CommonOperation<WordFlag>
    {
        public static Word Open()
        {
            const string wordAppId = "WINWORD.EXE";
            OpenHelper(wordAppId);
            FindSpecificTypeElementByName(Session, ControlType.ListItem, "Blank document").Click();
            Session.Quit();

            return new Word();
        }
    }
}
