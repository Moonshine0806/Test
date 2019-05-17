using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase5
    {
        // 4 5 6 7 could be one
        private static CommonOperation<T> CommonPart<T>(CommonOperation<T> openedApp, MethodBase method)
        {
            var g = new ImageNameGenerator(method);
            void Shot() => Word.Session.ShotScreen(g.Gen());

            var res = openedApp.OpenFileTab().ViewOption().UncheckedLinkedInOption().ExecuteExternalAction(Shot).ClickOkButton();
            // TODO When the app is same, maybe occur conflict
            Excel.Open().OpenFileTab().AddAuthor();

            return res; // maybe should not return value
        }

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
            var g = new ImageNameGenerator(MethodBase.GetCurrentMethod());
            void Shot() => Excel.Session.ShotScreen(g.Gen());

            Excel.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            CommonPart();
        }

        [TestMethod]
        public void PowerPointPart()
        {
            var g = new ImageNameGenerator(MethodBase.GetCurrentMethod());
            void Shot() => PowerPoint.Session.ShotScreen(g.Gen());

            PowerPoint.Open().OpenFileTab().ViewOption().UncheckedLinkedInOption().ClickOkButton();
            CommonPart();
        }

        [TestMethod]
        public void OutlookPart()
        {
            var g = new ImageNameGenerator(MethodBase.GetCurrentMethod());
            void Shot() => Outlook.Session.ShotScreen(g.Gen());

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
