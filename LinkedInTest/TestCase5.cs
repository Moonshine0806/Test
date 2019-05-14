﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinkedInTest.OperationLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase5
    {
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
            Excel.Open().OpenFileTab().AddAuthor();
            // Screen shot
        }
    }
}