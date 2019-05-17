using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase6
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
            PowerPoint.Open().OpenFileTab().AddAuthor();
            // Screen shot
        }
    }
}
