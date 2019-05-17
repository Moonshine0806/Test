using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using static LinkedInTest.Util.Log;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase8
    {
        private static CommonOperation<T> CommonPart<T>(CommonOperation<T> openedApp, MethodBase method)
        {
            var g = new ImageNameGenerator(method);
            void Shot() => openedApp.GetSession().ShotScreen(g.Gen());

            return openedApp.OpenFileTab().ViewOption().CheckText().ExecuteExternalAction(Shot)
                .CheckTip().ExecuteExternalAction(Shot)
                .CheckLink1().ExecuteExternalAction(Shot)
                .CheckLink2().ExecuteExternalAction(Shot);
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
    }
}
