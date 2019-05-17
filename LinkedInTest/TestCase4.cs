using System.Reflection;
using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase4
    {
        private static CommonOperation<T> CommonPart<T>(CommonOperation<T> openedApp, MethodBase method)
        {
            var g = new ImageNameGenerator(method);
            void Shot() => Word.Session.ShotScreen(g.Gen());

            var res = openedApp.OpenFileTab().ViewOption().UncheckedLinkedInOption().ExecuteExternalAction(Shot).ClickOkButton();
            // TODO When the app is same, maybe occur conflict
            Word.Open().OpenFileTab().AddAuthor();

            return res; // maybe should not return value
        }

        [TestMethod]
        public void WordPart()
        {
            CommonPart(Word.Open(), MethodBase.GetCurrentMethod());
        }

        [TestMethod]
        public void ExcelPart()
        {
            CommonPart(Excel.Open(), MethodBase.GetCurrentMethod());
        }

        [TestMethod]
        public void PowerPointPart()
        {
            CommonPart(PowerPoint.Open(), MethodBase.GetCurrentMethod());
        }

        [TestMethod]
        public void OutlookPart()
        {
            CommonPart(Outlook.Open(), MethodBase.GetCurrentMethod());
        }

        [TestMethod]
        public void PolicyPart()
        {
            // TODO wait to complete
        }
    }
}
