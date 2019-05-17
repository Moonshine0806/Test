using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase7
    {
        [TestMethod]
        public void WordPart()
        {
            var g = new ImageNameGenerator(MethodBase.GetCurrentMethod());
            void Shot() => Word.Session.ShotScreen(g.Gen());

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
            Outlook.Open().OpenFileTab().ViewContact();
            // Screen shot
        }
    }
}
