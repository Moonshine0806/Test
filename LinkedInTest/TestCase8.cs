using LinkedInTest.OperationLib;
using LinkedInTest.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace LinkedInTest
{
    [TestClass]
    public class TestCase8
    {
        private static readonly Func<MethodBase> CatchCurrentMethod = MethodBase.GetCurrentMethod;

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
            CommonPart(Word.Open(), CatchCurrentMethod());
        }

        [TestMethod]
        public void ExcelPart()
        {
            CommonPart(Excel.Open(), CatchCurrentMethod());
        }

        [TestMethod]
        public void PowerPointPart()
        {
            CommonPart(PowerPoint.Open(), CatchCurrentMethod());
        }

        [TestMethod]
        public void OutlookPart()
        {
            CommonPart(Outlook.Open(), CatchCurrentMethod());
        }
    }
}
