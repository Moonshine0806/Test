﻿using LinkedInTest.OperationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase4
    {
        // 1-1(因为是公共的，所以注意命名)
        //Session.TakeScreenshot().SaveAsFile();
        
        [TestMethod]
        public void WordPart()
        {
            Word.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            CommonPart();
        }

        [TestMethod]
        public void ExcelPart()
        {
            Excel.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            CommonPart();
        }

        [TestMethod]
        public void PowerPointPart()
        {
            PowerPoint.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            CommonPart();
        }

        [TestMethod]
        public void OutlookPart()
        {
            Outlook.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            CommonPart();
        }

        [TestMethod]
        public void PolicyPart()
        {
            // TODO wait to complete
            CommonPart();
        }

        private static void CommonPart()
        {
            // Screen shot
            Word.Open().OpenFileTab().AddAuthor();
            // Screen shot
        }
    }
}
